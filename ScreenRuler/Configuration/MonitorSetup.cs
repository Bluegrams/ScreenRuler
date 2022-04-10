using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsDisplayAPI;
using WindowsDisplayAPI.DisplayConfig;

namespace ScreenRuler.Configuration
{
    /// <summary>
    /// Provides information on currently connected monitors.
    /// </summary>
    public class MonitorSetup
    {
        #region Singleton
        private static readonly MonitorSetup instance;

        static MonitorSetup()
        {
            instance = new MonitorSetup();
        }

        public static MonitorSetup Instance => instance;
        #endregion

        private Dictionary<string, string> displayMap = new Dictionary<string, string>();

        public PathDisplayTarget[] Displays { get; set; }

        private MonitorSetup()
        {
            Update();
        }

        /// <summary>
        /// Update list of currently connected monitors.
        /// </summary>
        public void Update()
        {
            Displays = PathDisplayTarget.GetDisplayTargets();
            displayMap.Clear();
            foreach (Display display in Display.GetDisplays())
            {
                displayMap.Add(display.DisplayName, display.DevicePath);
            }
        }

        /// <summary>
        /// Retrieves configured DPI values based on the given screen and settings.
        /// </summary>
        /// <param name="screen">Screen for which to retrieve DPI configuration.</param>
        /// <param name="settings">Settings to use.</param>
        /// <returns>Tuple of horizontal and vertical DPI.</returns>
        public (float horizontal, float vertical) Lookup(Screen screen, Settings settings)
        {
            string devicePath = displayMap[screen.DeviceName];
            if (settings.MonitorDpiConfigurations.ContainsKey(devicePath))
            {
                MonitorDpiConfiguration displayDpi = settings.MonitorDpiConfigurations[devicePath];
                return (displayDpi.HorizontalDpi, displayDpi.VerticalDpi);
            }
            else
            {
                return (settings.MonitorDpi, settings.VerticalMonitorDpi);
            }
        }
    }
}
