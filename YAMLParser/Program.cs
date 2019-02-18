using FauxMessages;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using NuGet.Common;
using NuGet.Packaging.Core;
using NuGet.Versioning;
using Uml.Robotics.Ros;
using YAMLParser.NuGet;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace YAMLParser
{
    internal class Program
    {
        const string DEFAULT_OUTPUT_FOLDERNAME = "Uml.Robotics.Ros.Messages";
        const string DEFAULT_PROJECT_NAME = "Uml.Robotics.Ros.Messages";

        static List<MsgFile> msgsFiles = new List<MsgFile>();
        static List<SrvFile> srvFiles = new List<SrvFile>();
        static List<ActionFile> actionFiles = new List<ActionFile>();
        private static ILogger Logger { get; set; }

        public static void Main(params string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: true);

            CommandOption messageDirectories = app.Option("-m|--message-dirs", "Directories where ROS message definitions are located, separated by comma. (required)", CommandOptionType.MultipleValue);
            CommandOption assemblies = app.Option("-a|--assemblies", "Full filename of assemblies that contain additional generated RosMessages. (optional)", CommandOptionType.MultipleValue);
            CommandOption nugetPackages =  app.Option("-p|--packages", "List of nuget packages which should be added to the generated assembly. (optional)", CommandOptionType.MultipleValue);
            CommandOption interactive = app.Option("-i|--interactive", "Run in interactive mode. Default: false", CommandOptionType.NoValue);
            // Change of output directory requires more work, since the reference to Uml.Robotics.Ros.MessageBase needs to be adjusted
            CommandOption outputDirectory = app.Option("-o|--output", "Output directory for generated message. Default: ../Uml.Robotics.Ros.Messages", CommandOptionType.SingleValue);
            CommandOption runtime = app.Option("-c|--config", "Specify build-configuration, e.g. Debug or Release. Default: Debug", CommandOptionType.SingleValue);
            CommandOption projectName = app.Option("-n|--name", "Name of the generated project file. Default: Uml.Robotics.Ros.Messages", CommandOptionType.SingleValue);

            app.HelpOption("-? | -h | --help");

            app.OnExecute(() =>
            {
                if (!messageDirectories.HasValue())
                {
                    Console.WriteLine("At least one directory with ROS message definitions is required.");

                    return 1;
                }

                Program.Run(
                    messageDirectories.HasValue() ? messageDirectories.Values : null,
                    assemblies.HasValue() ? assemblies.Values : null,
                    nugetPackages.HasValue() ? nugetPackages.Values : null,
                    outputDirectory.HasValue() ? outputDirectory.Value() : null,
                    interactive.HasValue(),
                    runtime.HasValue() ? runtime.Value() : "Debug",
                    projectName.HasValue() ? projectName.Value() : DEFAULT_PROJECT_NAME
                );

                return 0;
            });

            app.Execute(args);
        }

        private static void Run(List<string> messageDirs, List<string> assemblies = null, IEnumerable<string> nugetPackages = null, string outputdir = null, bool interactive = false, string configuration = "Debug", string projectName = "Messages")
        {
            InitializeLogger();
            var programRootDir = GetYamlParserDirectory();
            
            if (outputdir == null)
            {
                outputdir = Path.Combine(Directory.GetParent(programRootDir.FullName).FullName, DEFAULT_OUTPUT_FOLDERNAME);
            }

            Templates.LoadTemplateStrings(Path.Combine(programRootDir.FullName, "TemplateProject"));

            MessageTypeRegistry.Default.ParseAssemblyAndRegisterRosMessages(MessageTypeRegistry.Default.GetType().GetTypeInfo().Assembly);

            
            var projectReferences = new StringBuilder();

            if (assemblies != null &&  assemblies.Any())
            {
                projectReferences.AppendLine("<ItemGroup>");

                foreach (var assemblyPath in assemblies)
                {
                    var assembly = LoadMessageAssemnly(assemblyPath);

                    // TODO: more sophisticated name resolving
                    projectReferences.AppendLine($@"    <Reference Include=""{assembly.GetName().Name}"">
        <HintPath>{assembly.Location}</HintPath>
    </Reference>");
                }
                
                projectReferences.AppendLine("</ItemGroup>");
            }

            if (nugetPackages != null && nugetPackages.Any())
            {
                projectReferences.AppendLine("<ItemGroup>");

                var nugetPackageDefinitions = ParseNugetPackageIdentities(nugetPackages);
                var nugetSettings = new NugetSettingsLoader(programRootDir.FullName).CalculateEffectiveSettings();
                var logger = new NuGet.ConsoleLogger();
                const string installPath = "..\\Temp\\nuget\\";

                var nugetPackageInstaller = new PackageInstaller(nugetSettings, logger, installPath);
                
                logger.LogMinimal("Installing NuGet packages...");
                
                foreach (var nugetPackage in nugetPackageDefinitions)
                {                    
                    // TODO: Load Nuget Packages and add to message type registry (https://stackoverflow.com/questions/31859267/load-nuget-dependencies-at-runtime)

                    // Install NuGet package (download to temp folder)
                    nugetPackageInstaller
                        .InstallPackageAsync(nugetPackage)
                        .Wait();
                    
                    // Load Messages
                    var packagePath = nugetPackageInstaller.GetInstalledPath(nugetPackage);
                    var assemblyFileNames = Directory.GetFiles(packagePath, "*.dll", SearchOption.AllDirectories);

                    foreach (var assemblyFileName in assemblyFileNames)
                    {
                        LoadMessageAssemnly(assemblyFileName);
                    }
                    

                    // Add to project file
                    projectReferences.Append($"    <PackageReference Include=\"{nugetPackage.Id}\"");

                    if (nugetPackage.HasVersion)
                    {
                        projectReferences.Append($" Version=\"{nugetPackage.Version.ToString()}\"");
                    }
                    
                    projectReferences.AppendLine(" />");
                }
                
                projectReferences.AppendLine("</ItemGroup>");
            }
            
            Templates.MessagesProj = Templates.MessagesProj.Replace("$$HINTS$$", projectReferences.ToString());

            
            
            
            
            var paths = new List<MsgFileLocation>();
            var pathssrv = new List<MsgFileLocation>();
            var actionFileLocations = new List<MsgFileLocation>();
            Console.WriteLine("Generatinc C# classes for ROS Messages...\n");
            foreach (var messageDir in messageDirs)
            {
                string d = new DirectoryInfo(Path.GetFullPath(messageDir)).FullName;
                Console.WriteLine("Looking in " + d);
                MsgFileLocator.findMessages(paths, pathssrv, actionFileLocations, d);
            }

            // first pass: create all msg files (and register them in static resolver dictionary)
            var baseTypes = MessageTypeRegistry.Default.GetTypeNames().ToList();
            foreach (MsgFileLocation path in paths)
            {
                var typeName = $"{path.package}/{path.basename}";
                if (baseTypes.Contains(typeName))
                {
                    Logger.LogInformation($"Skip file {path} because MessageBase already contains this message");
                }
                else
                {
                    msgsFiles.Add(new MsgFile(path));
                }
            }
            Logger.LogDebug($"Added {msgsFiles.Count} message files");

            foreach (MsgFileLocation path in pathssrv)
            {
                srvFiles.Add(new SrvFile(path));
            }

            // second pass: parse and resolve types
            foreach (var msg in msgsFiles)
            {
                msg.ParseAndResolveTypes();
            }
            
            foreach (var srv in srvFiles)
            {
                srv.ParseAndResolveTypes();
            }

            var actionFileParser = new ActionFileParser(actionFileLocations);
            actionFiles = actionFileParser.GenerateRosMessageClasses();
            //var actionFiles = new List<ActionFile>();

            if (paths.Count + pathssrv.Count+actionFiles.Count > 0)
            {
                MakeTempDir(outputdir);
                GenerateFiles(msgsFiles, srvFiles, actionFiles, outputdir);
                GenerateProject(msgsFiles, srvFiles, projectName, outputdir);
                BuildProject(configuration, projectName, outputdir);
            }
            else
            {
                Console.WriteLine("Usage:         YAMLParser.exe <SolutionFolder> [... other directories to search]\n      The Messages dll will be output to <SolutionFolder>/Messages/Messages.dll");
                if (interactive)
                    Console.ReadLine();
                Environment.Exit(1);
            }
            if (interactive)
            {
                Console.WriteLine("Finished. Press enter.");
                Console.ReadLine();
            }
        }

        private static Assembly LoadMessageAssemnly(string assemblyPath)
        {
            var assembly = Assembly.LoadFile(Path.GetFullPath(assemblyPath));
            MessageTypeRegistry.Default.ParseAssemblyAndRegisterRosMessages(assembly);
            return assembly;
        }

        private static IEnumerable<PackageIdentity> ParseNugetPackageIdentities(IEnumerable<string> nugetPackages)
        {
            if (nugetPackages == null || !nugetPackages.Any())
            {
                return Enumerable.Empty<PackageIdentity>();
            }

            var packages = new List<PackageIdentity>();

            foreach (var nugetPackageString in nugetPackages)
            {
                if (nugetPackageString == null) throw new ArgumentNullException(nameof(nugetPackageString));
            
                var parts = nugetPackageString.Split(",");

                if (parts.Length > 2)
                {
                    throw new ArgumentException("NuGet package string must only contain package id and an optional version in format \"packageId,version\".");
                }

                var version = parts.Length > 1 ? NuGetVersion.Parse(parts[1]) : null;
                var package = new PackageIdentity(parts[0], version);

                packages.Add(package);
            }
            
            return packages;
        }

        private static DirectoryInfo GetYamlParserDirectory()
        {
            var di = new DirectoryInfo(Directory.GetCurrentDirectory());
            
            while (di != null && di.Name != "YAMLParser")
            {
                di = Directory.GetParent(di.FullName);
            }

            if (di == null)
                throw new InvalidOperationException("Not started from within YAMLParser directory.");
            
            return di;
        }

        private static void InitializeLogger()
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(
                new ConsoleLoggerProvider(
                    (string text, LogLevel logLevel) => { return logLevel >= LogLevel.Debug; }, true)
            );
            ApplicationLogging.LoggerFactory = loggerFactory;
            Logger = ApplicationLogging.CreateLogger("Program");
        }

        private static void MakeTempDir(string outputdir)
        {
            if (!Directory.Exists(outputdir))
                Directory.CreateDirectory(outputdir);
            else
            {
                foreach (string s in Directory.GetFiles(outputdir, "*.cs"))
                {
                    try
                    {
                        File.Delete(s);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                foreach (string s in Directory.GetDirectories(outputdir))
                {
                    if (s != "Properties")
                    {
                        try
                        {
                            Directory.Delete(s, true);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            if (!Directory.Exists(outputdir))
                Directory.CreateDirectory(outputdir);
            else
            {
                foreach (string s in Directory.GetFiles(outputdir, "*.cs"))
                {
                    try
                    {
                        File.Delete(s);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                foreach (string s in Directory.GetDirectories(outputdir))
                {
                    if (s != "Properties")
                    {
                        try
                        {
                            Directory.Delete(s, true);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
        }

        private static void GenerateFiles(List<MsgFile> files, List<SrvFile> srvfiles, List<ActionFile> actionFiles, string outputdir)
        {
            List<MsgFile> mresolved = new List<MsgFile>();
            List<SrvFile> sresolved = new List<SrvFile>();
            List<ActionFile> actionFilesResolved = new List<ActionFile>();
            while (files.Except(mresolved).Any())
            {
                Debug.WriteLine("MSG: Running for " + files.Count + "/" + mresolved.Count + "\n" + files.Except(mresolved).Aggregate("\t", (o, n) => "" + o + "\n\t" + n.Name));
                foreach (MsgFile m in files.Except(mresolved))
                {
                    string md5 = null;
                    string typename = null;
                    md5 = MD5.Sum(m);
                    typename = m.Name;
                    if (md5 != null && !md5.StartsWith("$") && !md5.EndsWith("MYMD5SUM"))
                    {
                        mresolved.Add(m);
                    }
                    else
                    {
                        Debug.WriteLine("Waiting for children of " + typename + " to have sums");
                    }
                }
                if (files.Except(mresolved).Any())
                {
                    Debug.WriteLine("MSG: Rerunning sums for remaining " + files.Except(mresolved).Count() + " definitions");
                }
            }
            while (srvfiles.Except(sresolved).Any())
            {
                Debug.WriteLine("SRV: Running for " + srvfiles.Count + "/" + sresolved.Count + "\n" + srvfiles.Except(sresolved).Aggregate("\t", (o, n) => "" + o + "\n\t" + n.Name));
                foreach (SrvFile s in srvfiles.Except(sresolved))
                {
                    string md5 = null;
                    string typename = null;
                    s.Request.Stuff.ForEach(a => s.Request.resolve(a));
                    s.Response.Stuff.ForEach(a => s.Request.resolve(a));
                    md5 = MD5.Sum(s);
                    typename = s.Name;
                    if (md5 != null && !md5.StartsWith("$") && !md5.EndsWith("MYMD5SUM"))
                    {
                        sresolved.Add(s);
                    }
                    else
                    {
                        Debug.WriteLine("Waiting for children of " + typename + " to have sums");
                    }
                }
                if (srvfiles.Except(sresolved).Any())
                {
                    Debug.WriteLine("SRV: Rerunning sums for remaining " + srvfiles.Except(sresolved).Count() + " definitions");
                }
            }
            while (actionFiles.Except(actionFilesResolved).Any())
            {
                Debug.WriteLine("SRV: Running for " + actionFiles.Count + "/" + actionFilesResolved.Count + "\n" + actionFiles.Except(actionFilesResolved).Aggregate("\t", (o, n) => "" + o + "\n\t" + n.Name));
                foreach (ActionFile actionFile in actionFiles.Except(actionFilesResolved))
                {
                    string md5 = null;
                    string typename = null;
                    actionFile.GoalMessage.Stuff.ForEach(a => actionFile.GoalMessage.resolve(a));
                    actionFile.ResultMessage.Stuff.ForEach(a => actionFile.ResultMessage.resolve(a));
                    actionFile.FeedbackMessage.Stuff.ForEach(a => actionFile.FeedbackMessage.resolve(a));
                    md5 = MD5.Sum(actionFile);
                    typename = actionFile.Name;
                    if (md5 != null && !md5.StartsWith("$") && !md5.EndsWith("MYMD5SUM"))
                    {
                        actionFilesResolved.Add(actionFile);
                    }
                    else
                    {
                        Logger.LogDebug("Waiting for children of " + typename + " to have sums");
                    }
                }
                if (actionFiles.Except(actionFilesResolved).Any())
                {
                    Logger.LogDebug("ACTION: Rerunning sums for remaining " + actionFiles.Except(actionFilesResolved).Count() + " definitions");
                }
            }
            foreach (MsgFile file in files)
            {
                file.Write(outputdir);
            }
            foreach (SrvFile file in srvfiles)
            {
                file.Write(outputdir);
            }
            foreach (ActionFile actionFile in actionFiles)
            {
                actionFile.Write(outputdir);
            }
            File.WriteAllText(Path.Combine(outputdir, "MessageTypes.cs"), ToString().Replace("FauxMessages", "Messages"));
        }

        private static void GenerateProject(List<MsgFile> files, List<SrvFile> srvfiles, string projectName, string outputdir)
        {
            string[] lines = Templates.MessagesProj.Split('\n');
            string output = "";
            for (int i = 0; i < lines.Length; i++)
            {
                output += "" + lines[i] + "\n";
                /*if (lines[i].Contains("<Compile Include="))
                {
                    foreach (MsgsFile m in files)
                    {
                        output += "\t<Compile Include=\"" + m.Name.Replace('.', '\\') + ".cs\" />\n";
                    }
                    foreach (SrvsFile m in srvfiles)
                    {
                        output += "\t<Compile Include=\"" + m.Name.Replace('.', '\\') + ".cs\" />\n";
                    }
                    output += "\t<Compile Include=\"SerializationHelper.cs\" />\n";
                    output += "\t<Compile Include=\"Interfaces.cs\" />\n";
                    output += "\t<Compile Include=\"MessageTypes.cs\" />\n";
                }*/
            }
            File.WriteAllText(Path.Combine(outputdir, projectName + ".csproj"), output);
            File.WriteAllText(Path.Combine(outputdir, ".gitignore"), "*");
        }

        private static void BuildProject(string configuration, string projectName, string outputdir)
        {
            BuildProject("BUILDING GENERATED PROJECT WITH MSBUILD!", configuration, projectName, outputdir);
        }

        static Process RunDotNet(string args)
        {
            string fn = "dotnet";
            var proc = new Process();
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = fn;
            proc.StartInfo.Arguments = args;
            proc.Start();
            return proc;
        }

        private static void BuildProject(string spam, string configuration, string projectName, string outputdir)
        {
            Console.WriteLine("\n\n" + spam);

            string output, error;

            Console.WriteLine("Running dotnet restore...");
            string restoreArgs = "restore \"" + Path.Combine(outputdir, projectName) + ".csproj\"";
            var proc = RunDotNet(restoreArgs);
            output = proc.StandardOutput.ReadToEnd();
            error = proc.StandardError.ReadToEnd();
            if (output.Length > 0)
                Console.WriteLine(output);
            if (error.Length > 0)
                Console.WriteLine(error);

            Console.WriteLine("Running dotnet build...");
            string buildArgs = "build -f netcoreapp2.1 \"" + Path.Combine(outputdir, projectName) + ".csproj\" -c " + configuration;
            proc = RunDotNet(buildArgs);

            output = proc.StandardOutput.ReadToEnd();
            error = proc.StandardError.ReadToEnd();
            proc.WaitForExit();

            if (output.Length > 0)
                Console.WriteLine(output);
            if (error.Length > 0)
                Console.WriteLine(error);

            if (proc.ExitCode == 0)
            {
                Console.WriteLine("ROS Messages .Net assembly was successfully built.");
            }
        }

        private new static string ToString()
        {
            return "";
        }
    }
}