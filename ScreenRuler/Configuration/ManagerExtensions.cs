using System;
using System.IO;
using Bluegrams.Application;

namespace ScreenRuler.Configuration
{
    public static class ManagerExtensions
    {
        /// <summary>
        /// Loads managed settings from a specified configuration file.
        /// </summary>
        public static void LoadSettingsFromFile(this WinFormsWindowManager manager, string configPath)
        {
            if (!String.IsNullOrEmpty(configPath))
            {
                string directory = Path.GetDirectoryName(configPath);
                string file = Path.GetFileName(configPath);
                PortableSettingsProvider.SettingsDirectory = directory;
                PortableSettingsProvider.SettingsFileName = file;
                // We only really care about the custom settings object, so only reload that.
                var provider = new PortableSettingsProvider();
                manager.CustomSettings.Providers.Clear();
                manager.CustomSettings.Providers.Add(provider);
                foreach (System.Configuration.SettingsProperty prop in manager.CustomSettings.Properties)
                    prop.Provider = provider;
                manager.CustomSettings.Reload();
            }
        }
    }
}
