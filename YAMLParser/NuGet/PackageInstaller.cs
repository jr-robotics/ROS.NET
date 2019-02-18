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
        private ISettings _settings;
        
        private readonly string _installPath;

        private readonly FolderNuGetProject _nugetProject;
        private readonly NuGetPackageManager _nugetPackageManager;
        private readonly IEnumerable<SourceRepository> _primaryRepositories;
        private readonly IPackageSourceProvider _sourceProvider;

        public ILogger Logger { get; set; } = NullLogger.Instance;

        public ISettings Settings
        {
            get => _settings;
        }

        public PackageInstaller(ISettings settings, ILogger logger, string installPath)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
            
            if (string.IsNullOrEmpty(installPath))
            {
                throw new ArgumentNullException(nameof(installPath));
            }

            _settings = settings;
            _installPath = installPath;

            if (logger != null)
            {
                Logger = logger;
            }
            
                
            _sourceProvider = new PackageSourceProvider(Settings);
            
            
            var framework = GetTargetFramework();
            var sourceRepositoryProvider = GetSourceRepositoryProvider();

            // Create the project and set the framework if available.
            _nugetProject = new FolderNuGetProject(
                installPath,
                new PackagePathResolver(installPath),
                framework);
            
            _nugetPackageManager = new NuGetPackageManager(sourceRepositoryProvider, Settings, installPath);

            var packageSources = GetPackageSources(Settings);
            _primaryRepositories = packageSources.Select(sourceRepositoryProvider.CreateRepository);
        }
        
        public async Task InstallPackageAsync(
            PackageIdentity packageIdentity)
        {
            var packageId = packageIdentity.Id;
            var version = packageIdentity.Version;
            
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
                        _nugetProject,
                        resolutionContext,
                        _primaryRepositories,
                        Logger,
                        CancellationToken.None);

                    if (resolvePackage == null || resolvePackage.LatestVersion == null)
                    {
                        throw new InvalidOperationException($"Could not find package {packageId}");
                    }

                    version = resolvePackage.LatestVersion;
                }

                // Get a list of packages already in the folder.
                var installedPackages = await _nugetProject.GetInstalledPackagesAsync(CancellationToken.None);

                // Find existing versions of the package
                var alreadyInstalledVersions = new HashSet<NuGetVersion>(installedPackages
                    .Where(e => StringComparer.OrdinalIgnoreCase.Equals(packageId, e.PackageIdentity.Id))
                    .Select(e => e.PackageIdentity.Version));

                // Check if the package already exists or a higher version exists already.
                var skipInstall = _nugetProject.PackageExists(packageIdentity);

                // For SxS allow other versions to install. For non-SxS skip if a higher version exists.
                skipInstall |= alreadyInstalledVersions.Any(e => e >= version);

                if (skipInstall)
                {
                    Logger.LogMinimal($"Skipping package {packageIdentity}");
                }
                else
                {
                    Logger.LogMinimal($"Installing package {packageIdentity}");
                    
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

                    var downloadContext = new PackageDownloadContext(resolutionContext.SourceCacheContext, _installPath, directDownload)
                    {
                        ClientPolicyContext = clientPolicyContext
                    };

                    await _nugetPackageManager.InstallPackageAsync(
                        _nugetProject,
                        packageIdentity,
                        resolutionContext,
                        projectContext,
                        downloadContext,
                        _primaryRepositories,
                        Enumerable.Empty<SourceRepository>(),
                        CancellationToken.None);
 
                    if (downloadContext.DirectDownload)
                    {
                        GetDownloadResultUtility.CleanUpDirectDownloads(downloadContext);
                    }
                }
            }
        }

        private IReadOnlyCollection<PackageSource> GetPackageSources(ISettings settings)
        {
            var packageSources = new List<PackageSource>();

            // Add the v3 global packages folder
            var globalPackageFolder = SettingsUtility.GetGlobalPackagesFolder(settings);

            if (!string.IsNullOrEmpty(globalPackageFolder) && Directory.Exists(globalPackageFolder))
            {
                packageSources.Add(new FeedTypePackageSource(globalPackageFolder, FeedType.FileSystemV3));
            }
            
            
            var availableSources = _sourceProvider.LoadPackageSources().Where(source => source.IsEnabled);
            packageSources.AddRange(availableSources);

            return packageSources;
        }
        
        private ISourceRepositoryProvider GetSourceRepositoryProvider()
        {
            var resourceProviders = new List<Lazy<INuGetResourceProvider>>();
            resourceProviders.AddRange(FactoryExtensionsV3.GetCoreV3(Repository.Provider));
            
            return new SourceRepositoryProvider(_sourceProvider, resourceProviders);
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

        public string GetInstalledPath(PackageIdentity nugetPackage)
        {
            if (nugetPackage == null) throw new ArgumentNullException(nameof(nugetPackage));

            return _nugetProject.GetInstalledPath(nugetPackage);
        }
    }
}