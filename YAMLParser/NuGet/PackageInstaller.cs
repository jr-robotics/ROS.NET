using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Configuration;
using NuGet.Frameworks;
using NuGet.PackageManagement;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Packaging.PackageExtraction;
using NuGet.Packaging.Signing;
using NuGet.ProjectManagement;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Resolver;
using NuGet.Versioning;

namespace YAMLParser.NuGet
{
    public class PackageInstaller
    {
        private ISettings settings;
        public ILogger Logger { get; set; } = NullLogger.Instance;

        public ISettings Settings
        {
            get => settings;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                
                settings = value;
                
                SourceProvider = new PackageSourceProvider(Settings);
            }
        }

        private IPackageSourceProvider SourceProvider { get; set; }
        
        public async Task InstallPackageAsync(
            PackageIdentity packageIdentity,
            string installPath)
        {
            var packageId = packageIdentity.Id;
            var version = packageIdentity.Version;
            var framework = GetTargetFramework();

            // Create the project and set the framework if available.
            var project = new FolderNuGetProject(
                installPath,
                new PackagePathResolver(installPath),
                framework);

            var sourceRepositoryProvider = GetSourceRepositoryProvider();
            var packageManager = new NuGetPackageManager(sourceRepositoryProvider, Settings, installPath);

            var packageSources = GetPackageSources(Settings);
            var primaryRepositories = packageSources.Select(sourceRepositoryProvider.CreateRepository);

            using (var sourceCacheContext = new SourceCacheContext())
            {
                var resolutionContext = new ResolutionContext(
                    DependencyBehavior.Lowest,
                    false,
                    true,
                    VersionConstraints.None,
                    new GatherCache(),
                    sourceCacheContext);

                if (version == null)
                {
                    // Find the latest version using NuGetPackageManager
                    var resolvePackage = await NuGetPackageManager.GetLatestVersionAsync(
                        packageId,
                        project,
                        resolutionContext,
                        primaryRepositories,
                        Logger,
                        CancellationToken.None);

                    if (resolvePackage == null || resolvePackage.LatestVersion == null)
                    {
                        throw new InvalidOperationException($"Could not find package {packageId}");
                    }

                    version = resolvePackage.LatestVersion;
                }

                // Get a list of packages already in the folder.
                var installedPackages = await project.GetInstalledPackagesAsync(CancellationToken.None);

                // Find existing versions of the package
                var alreadyInstalledVersions = new HashSet<NuGetVersion>(installedPackages
                    .Where(e => StringComparer.OrdinalIgnoreCase.Equals(packageId, e.PackageIdentity.Id))
                    .Select(e => e.PackageIdentity.Version));

                // Check if the package already exists or a higher version exists already.
                var skipInstall = project.PackageExists(packageIdentity);

                // For SxS allow other versions to install. For non-SxS skip if a higher version exists.
                skipInstall |= alreadyInstalledVersions.Any(e => e >= version);

                if (skipInstall)
                {
                    Logger.LogMinimal($"Skipping package {packageIdentity}");
                }
                else
                {
                    var clientPolicyContext = ClientPolicyContext.GetClientPolicy(Settings, Logger);

                    var projectContext = new EmptyNuGetProjectContext()
                    {
                        PackageExtractionContext = new PackageExtractionContext(
                            PackageSaveMode.Defaultv3,
                            PackageExtractionBehavior.XmlDocFileSaveMode,
                            clientPolicyContext,
                            Logger)
                    };

                    const bool directDownload = true;
                    
                    resolutionContext.SourceCacheContext.NoCache = false;
                    resolutionContext.SourceCacheContext.DirectDownload = directDownload;

                    var downloadContext = new PackageDownloadContext(resolutionContext.SourceCacheContext, installPath, directDownload)
                    {
                        ClientPolicyContext = clientPolicyContext
                    };

                    await packageManager.InstallPackageAsync(
                        project,
                        packageIdentity,
                        resolutionContext,
                        projectContext,
                        downloadContext,
                        primaryRepositories,
                        Enumerable.Empty<SourceRepository>(),
                        CancellationToken.None);

                    if (downloadContext.DirectDownload)
                    {
                        GetDownloadResultUtility.CleanUpDirectDownloads(downloadContext);
                    }
                }
            }
        }

        protected IReadOnlyCollection<PackageSource> GetPackageSources(ISettings settings)
        {
            var packageSources = new List<PackageSource>();

            // Add the v3 global packages folder
            var globalPackageFolder = SettingsUtility.GetGlobalPackagesFolder(settings);

            if (!string.IsNullOrEmpty(globalPackageFolder) && Directory.Exists(globalPackageFolder))
            {
                packageSources.Add(new FeedTypePackageSource(globalPackageFolder, FeedType.FileSystemV3));
            }
            
            
            var availableSources = SourceProvider.LoadPackageSources().Where(source => source.IsEnabled);
            packageSources.AddRange(availableSources);

            return packageSources;
        }
        
        private ISourceRepositoryProvider GetSourceRepositoryProvider()
        {
            var resourceProviders = new List<Lazy<INuGetResourceProvider>>();
            resourceProviders.AddRange(FactoryExtensionsV3.GetCoreV3(Repository.Provider));
            
            return new SourceRepositoryProvider(SourceProvider, resourceProviders);
        }

        /// <summary>
        /// Load with the current framework version
        /// </summary>
        private NuGetFramework GetTargetFramework()
        {
            var frameworkName = Assembly.GetExecutingAssembly().GetCustomAttributes(true)
                .OfType<System.Runtime.Versioning.TargetFrameworkAttribute>()
                .Select(x => x.FrameworkName)
                .FirstOrDefault();
            
            var currentFramework = frameworkName == null
                ? NuGetFramework.AnyFramework
                : NuGetFramework.ParseFrameworkName(frameworkName, new DefaultFrameworkNameProvider());

            return currentFramework;
        }
    }
}