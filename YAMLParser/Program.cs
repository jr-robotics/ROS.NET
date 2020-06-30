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
using Microsoft.Extensions.Options;
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
        static List<MsgFile> msgsFiles = new List<MsgFile>();
        static List<SrvFile> srvFiles = new List<SrvFile>();
        static List<ActionFile> actionFiles = new List<ActionFile>();
        
        private static ILogger Logger { get; set; }
        
        private static List<Assembly> externalMessageAssemblies = new List<Assembly>();

        public static void Main(params string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: true);

            CommandOption projectName = app.Option("-n|--name", "Name of the generated project file. (required)", CommandOptionType.SingleValue);
            CommandOption messageDirectories = app.Option("-m|--message-dirs", "Directories where ROS message definitions are located. (required)", CommandOptionType.MultipleValue);
            CommandOption assemblies = app.Option("-a|--assemblies", "Full filename of assemblies that contain additional generated RosMessages. (optional)", CommandOptionType.MultipleValue);
            CommandOption nugetPackages =  app.Option("-p|--packages", "List of nuget packages which should be added to the generated assembly. Specify a package in the Format <PACKAGE-NAME>[/<VERSION>]. <VERSION> is optional (e.g.: ROS.Messages.common_msgs/0.0.1). (optional)", CommandOptionType.MultipleValue);
            CommandOption interactive = app.Option("-i|--interactive", "Run in interactive mode. Default: false", CommandOptionType.NoValue);
            // Change of output directory requires more work, since the reference to Uml.Robotics.Ros.MessageBase needs to be adjusted
            CommandOption outputDirectory = app.Option("-o|--output", "Output directory for generated message. Default: ../Temp/<ProjectName>", CommandOptionType.SingleValue);
            CommandOption runtime = app.Option("-c|--config", "Specify the build configuration (Debug or Release). Default: Release", CommandOptionType.SingleValue);
            CommandOption outputVersion = app.Option("-v|--version", "Output assembly version. Default: 1.0.0", CommandOptionType.SingleValue);

            app.HelpOption("-? | -h | --help");

            app.OnExecute(() =>
            {
                if (!messageDirectories.HasValue() || !projectName.HasValue())
                {
                    Console.WriteLine("Invalid Parameters.");
                    app.ShowHelp();
                    
                    return 1;
                }

                Program.Run(
                    messageDirectories.HasValue() ? messageDirectories.Values : null,
                    assemblies.HasValue() ? assemblies.Values : null,
                    nugetPackages.HasValue() ? nugetPackages.Values : null,
                    outputDirectory.HasValue() ? outputDirectory.Value() : null,
                    interactive.HasValue(),
                    runtime.HasValue() ? runtime.Value() : "Release",
                    projectName.HasValue() ? projectName.Value() : null,
                    outputVersion.HasValue() ? outputVersion.Value() : null
                );

                return 0;
            });

            app.Execute(args);
        }

        private static void Run(List<string> messageDirs, List<string> assemblies, IEnumerable<string> nugetPackages, string projectDir, bool interactive, string configuration, string projectName, string outputVersion)
        {
            InitializeLogger();
            var programRootDir = GetYamlParserDirectory();
            var tempDir = Path.Combine(Directory.GetParent(programRootDir.FullName).FullName, "Temp");

            if (projectDir == null)
            {
                projectDir = Path.Combine(tempDir, projectName);
            }

            Templates.LoadTemplateStrings(Path.Combine(programRootDir.FullName, "TemplateProject"));

            SetProjectVersion(outputVersion);
            BuildExternalProjectReferences(assemblies, nugetPackages, projectName, programRootDir, tempDir);

            using (new AssemblyResolver(externalMessageAssemblies, AppDomain.CurrentDomain))
            {
                RegisterExternalMessageAssemblies();
                
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

                if (paths.Count + pathssrv.Count + actionFiles.Count > 0)
                {
                    CreateProjectDir(projectDir);
                    GenerateFiles(msgsFiles, srvFiles, actionFiles, projectDir);
                    GenerateProject(msgsFiles, srvFiles, projectName, projectDir);
                    BuildProject(configuration, projectName, projectDir);
                }
                else
                {
                    Console.WriteLine(
                        "Usage:         YAMLParser.exe <SolutionFolder> [... other directories to search]\n      The Messages dll will be output to <SolutionFolder>/Messages/Messages.dll");
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
        }

        private static void RegisterExternalMessageAssemblies()
        {
            MessageTypeRegistry.Default.ParseAssemblyAndRegisterRosMessages(typeof(TypeRegistryBase).Assembly);

            foreach (var assembly in externalMessageAssemblies)
            {
                MessageTypeRegistry.Default.ParseAssemblyAndRegisterRosMessages(assembly);
            }
        }

        private static void SetProjectVersion(string version)
        {
            if (string.IsNullOrEmpty(version))
            {
                version = "1.0.0";
            }
            
            Templates.MessagesProj = Templates.MessagesProj.Replace("$$VERSION$$", version);
        }

        private static void BuildExternalProjectReferences(List<string> assemblies, IEnumerable<string> nugetPackages, string projectName,
            DirectoryInfo programRootDir, string tempFolder)
        {
            var projectReferences = new StringBuilder();

            if (assemblies != null && assemblies.Any())
            {
                projectReferences.AppendLine("  <ItemGroup>");

                foreach (var assemblyPath in assemblies)
                {
                    var assembly = LoadMessageAssembly(assemblyPath);

                    // TODO: more sophisticated name resolving
                    projectReferences.AppendLine($@"    <Reference Include=""{assembly.GetName().Name}"">
      <HintPath>{assembly.Location}</HintPath>
    </Reference>");
                }

                projectReferences.AppendLine("  </ItemGroup>");
            }


            var nugetPackageDefinitions = BuildNugetPackageDefinitions(nugetPackages);

            if (nugetPackageDefinitions.Any())
            {
                projectReferences.AppendLine("  <ItemGroup>");

                var nugetSettings = new NugetSettingsLoader(programRootDir.FullName).CalculateEffectiveSettings();
                var logger = new NuGet.ConsoleLogger();

                var installPath = Path.Combine(tempFolder, "ParserNugetCache", projectName);

                var nugetPackageInstaller = new PackageInstaller(nugetSettings, logger, installPath);

                logger.LogMinimal("Installing NuGet packages...");
                
                foreach (var nugetPackage in nugetPackageDefinitions)
                {
                    var package = nugetPackage;
                    if (!package.HasVersion)
                    {
                        package = nugetPackageInstaller.FindLatestPackageVersion(package.Id);
                    }
                    
                    // Install NuGet package (download to temp folder)
                    if (!nugetPackage.IsRosMessageBasePackage()) // Message base is already referenced and loaded in YAMLParser project
                    {
                        InstallAndLoadMessageNugetPackage(nugetPackageInstaller, package);
                    }

                    // Add to project file
                    projectReferences.AppendLine($"    <PackageReference Include=\"{package.Id}\" Version=\"{package.Version.ToString()}\" />");
                }

                projectReferences.AppendLine("  </ItemGroup>");
            }

            Templates.MessagesProj = Templates.MessagesProj.Replace("$$HINTS$$", projectReferences.ToString());
        }

        private static void InstallAndLoadMessageNugetPackage(PackageInstaller nugetPackageInstaller, PackageIdentity nugetPackage)
        {
            nugetPackageInstaller
                .InstallPackageAsync(nugetPackage)
                .Wait();

            // Load Messages
            var packagePath = nugetPackageInstaller.GetInstalledPath(nugetPackage);
            var assemblyFileNames = Directory.GetFiles(packagePath, "*.dll", SearchOption.AllDirectories);

            foreach (var assemblyFileName in assemblyFileNames)
            {
                LoadMessageAssembly(assemblyFileName);
            }
        }

        private static Assembly LoadMessageAssembly(string assemblyPath)
        {
            var assembly = Assembly.LoadFile(Path.GetFullPath(assemblyPath));
            externalMessageAssemblies.Add(assembly);
            
            return assembly;
        }

        private static IEnumerable<PackageIdentity> BuildNugetPackageDefinitions(IEnumerable<string> nugetPackages)
        {
            var packages = new List<PackageIdentity>();

            if (nugetPackages != null)
            {
                foreach (var nugetPackageString in nugetPackages)
                {
                    if (nugetPackageString == null) throw new ArgumentNullException(nameof(nugetPackageString));

                    var parts = nugetPackageString.Split(new []{ ',', '/' });

                    if (parts.Length > 2)
                    {
                        throw new ArgumentException(
                            "NuGet package string must only contain package id and an optional version in format \"packageId,version\".");
                    }

                    var version = parts.Length > 1 ? NuGetVersion.Parse(parts[1]) : null;
                    var package = new PackageIdentity(parts[0], version);

                    packages.Add(package);
                }
            }

            if (!packages.HasRosMessageBasePackage())
            {
                packages.AddRosMessageBasePackage();
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
            // Here a method had been used that was marked as obsolete in Microsoft.Extensions.Logging 2.2
            // and has been removed in version 3.0 -> this is the workaround for it.
            // Refactoring the whole thing to make use of dependencyInjection will become necessary at some
            // point in the future.
            var configureNamedOptions = new ConfigureNamedOptions<ConsoleLoggerOptions>("", null);
            var postConfigureOptions = Enumerable.Empty<IPostConfigureOptions<ConsoleLoggerOptions>>();
            var setups = new []{ configureNamedOptions };
            var optionsFactory = new OptionsFactory<ConsoleLoggerOptions>(setups, postConfigureOptions);
            var optionsChangeTokenSources = Enumerable.Empty<IOptionsChangeTokenSource<ConsoleLoggerOptions>>();
            var optionsMonitorCache = new OptionsCache<ConsoleLoggerOptions>();
            var optionsMonitor = new OptionsMonitor<ConsoleLoggerOptions>(optionsFactory, optionsChangeTokenSources, optionsMonitorCache);
            var loggerFilterOptions = new LoggerFilterOptions { MinLevel = LogLevel.Debug };
            var consoleLoggerProvider = new ConsoleLoggerProvider(optionsMonitor);
                        
            var loggerFactory = new LoggerFactory(new[] { consoleLoggerProvider }, loggerFilterOptions);
            ApplicationLogging.LoggerFactory = loggerFactory;
            Logger = ApplicationLogging.CreateLogger("Program");
        }

        private static void CreateProjectDir(string projectDir)
        {
            if (Directory.Exists(projectDir))
            {
                Directory.Delete(projectDir, true);
            }
            
            Directory.CreateDirectory(projectDir);
        }

        private static void GenerateFiles(List<MsgFile> files, List<SrvFile> srvfiles, List<ActionFile> actionFiles, string outputdir)
        {
            var resolvedMessages = new List<MsgFile>();
            var resolvedServices = new List<SrvFile>();
            var resolvedActions = new List<ActionFile>();
            
            while (files.Except(resolvedMessages).Any())
            {
                Debug.WriteLine("MSG: Running for " + files.Count + "/" + resolvedMessages.Count + "\n" + files.Except(resolvedMessages).Aggregate("\t", (o, n) => "" + o + "\n\t" + n.Name));
                foreach (var m in files.Except(resolvedMessages))
                {
                    var md5 = MD5.Sum(m);
                    var typename = m.Name;
                    
                    if (md5 != null && !md5.StartsWith("$") && !md5.EndsWith("MYMD5SUM"))
                    {
                        resolvedMessages.Add(m);
                    }
                    else
                    {
                        Debug.WriteLine("Waiting for children of " + typename + " to have sums");
                    }
                }
                
                if (files.Except(resolvedMessages).Any())
                {
                    Debug.WriteLine("MSG: Rerunning sums for remaining " + files.Except(resolvedMessages).Count() + " definitions");
                }
            }
            
            while (srvfiles.Except(resolvedServices).Any())
            {
                Debug.WriteLine("SRV: Running for " + srvfiles.Count + "/" + resolvedServices.Count + "\n" + srvfiles.Except(resolvedServices).Aggregate("\t", (o, n) => "" + o + "\n\t" + n.Name));
                foreach (var s in srvfiles.Except(resolvedServices))
                {
                    s.Request.Stuff.ForEach(a => s.Request.resolve(a));
                    s.Response.Stuff.ForEach(a => s.Request.resolve(a));
                    
                    var md5 = MD5.Sum(s);
                    var typename = s.Name;
                    
                    if (md5 != null && !md5.StartsWith("$") && !md5.EndsWith("MYMD5SUM"))
                    {
                        resolvedServices.Add(s);
                    }
                    else
                    {
                        Debug.WriteLine("Waiting for children of " + typename + " to have sums");
                    }
                }
                
                if (srvfiles.Except(resolvedServices).Any())
                {
                    Debug.WriteLine("SRV: Rerunning sums for remaining " + srvfiles.Except(resolvedServices).Count() + " definitions");
                }
            }
            
            while (actionFiles.Except(resolvedActions).Any())
            {
                Debug.WriteLine("SRV: Running for " + actionFiles.Count + "/" + resolvedActions.Count + "\n" + actionFiles.Except(resolvedActions).Aggregate("\t", (o, n) => "" + o + "\n\t" + n.Name));
                foreach (var actionFile in actionFiles.Except(resolvedActions))
                {
                    actionFile.GoalMessage.Stuff.ForEach(a => actionFile.GoalMessage.resolve(a));
                    actionFile.ResultMessage.Stuff.ForEach(a => actionFile.ResultMessage.resolve(a));
                    actionFile.FeedbackMessage.Stuff.ForEach(a => actionFile.FeedbackMessage.resolve(a));
                    
                    var md5 = MD5.Sum(actionFile);
                    var typename = actionFile.Name;
                    
                    if (md5 != null && !md5.StartsWith("$") && !md5.EndsWith("MYMD5SUM"))
                    {
                        resolvedActions.Add(actionFile);
                    }
                    else
                    {
                        Logger.LogDebug("Waiting for children of " + typename + " to have sums");
                    }
                }
                
                if (actionFiles.Except(resolvedActions).Any())
                {
                    Logger.LogDebug("ACTION: Rerunning sums for remaining " + actionFiles.Except(resolvedActions).Count() + " definitions");
                }
            }
            
            foreach (var file in files)
            {
                file.Write(outputdir);
            }
            
            foreach (var file in srvfiles)
            {
                file.Write(outputdir);
            }
            
            foreach (var actionFile in actionFiles)
            {
                actionFile.Write(outputdir);
            }
        }

        private static void GenerateProject(List<MsgFile> files, List<SrvFile> srvfiles, string projectName, string outputdir)
        {
            File.WriteAllText(Path.Combine(outputdir, projectName + ".csproj"), Templates.MessagesProj);
            File.WriteAllText(Path.Combine(outputdir, ".gitignore"), "*");
        }

        private static void BuildProject(string configuration, string projectName, string outputdir)
        {
            Console.WriteLine("\n\nBUILDING GENERATED PROJECT!");
            
            Console.WriteLine("Running dotnet build...");
            string buildArgs = "\"" + Path.Combine(outputdir, projectName) + ".csproj\" -c " + configuration;
            var proc = RunDotNet("build", buildArgs);

            Console.WriteLine(proc.StandardOutput.ReadToEnd());
            Console.WriteLine(proc.StandardError.ReadToEnd());
            
            proc.WaitForExit();

            if (proc.ExitCode == 0)
            {
                Console.WriteLine("ROS Messages assembly was successfully built.");
            }
        }

        static Process RunDotNet(string command, string args)
        {
            const string programName = "dotnet";
            
            var proc = new Process();
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = programName;
            proc.StartInfo.Arguments = $"{command} {args}";
            proc.Start();
            
            return proc;
        }
    }
}