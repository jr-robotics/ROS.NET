using System;
using System.IO;
using NuGet.Configuration;

namespace YAMLParser.NuGet
{
    public class NugetSettingsLoader
    {
        private readonly string _settingsDirectory;

        public NugetSettingsLoader(string settingsDirectory)
        {
            if (settingsDirectory == null) throw new ArgumentNullException(nameof(settingsDirectory));

            _settingsDirectory = settingsDirectory;
        }

        public ISettings CalculateEffectiveSettings()
        {
            // We use the YAML Parser directory as project level settings
            var fullPath = Path.GetFullPath(_settingsDirectory).TrimEnd(Path.DirectorySeparatorChar);

            var settings = Settings.LoadDefaultSettings(
                fullPath,
                configFileName: null,
                machineWideSettings: new MachineWideSettings());

            // Recreate the source provider and credential provider
//                SourceProvider = PackageSourceBuilder.CreateSourceProvider(Settings);
//                SetDefaultCredentialProvider();

            return settings;
        }
    }
}