using System;
using NuGet.Common;
using NuGet.Configuration;
using SettingsCLass = NuGet.Configuration.Settings;

namespace YAMLParser.NuGet
{
    public class MachineWideSettings : IMachineWideSettings
    {
        Lazy<ISettings> _settings;

        public MachineWideSettings()
        {
            var baseDirectory = NuGetEnvironment.GetFolderPath(NuGetFolderPath.MachineWideConfigDirectory);
            _settings = new Lazy<ISettings>(
                () => SettingsCLass.LoadMachineWideSettings(baseDirectory));
        }

        public ISettings Settings => _settings.Value;
    }
}