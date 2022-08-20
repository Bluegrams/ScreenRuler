using System;
using System.Linq;
using System.Windows.Forms;

namespace ScreenRuler.Configuration.Monitor
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

        public MonitorInfo[] Monitors { get; set; }

        private MonitorSetup()
        {
            Update();
        }

        /// <summary>
        /// Update list of currently connected monitors.
        /// </summary>
        public void Update()
        {
            Monitors = MonitorInfo.GetMonitorInfos();
        }

        public string GetDevicePath(Screen screen)
            => Monitors.Where(m => m.DisplayName == screen.DeviceName).FirstOrDefault()?.DevicePath;

        /// <summary>
        /// Show a screen overlay that identifies the connected monitors for the specified number of seconds.
        /// </summary>
        /// <param name="seconds">The number of seconds the overlay should be visible. If <= 0, show until Close() is called.</param>
        /// <param name="showMonitorNames">Whether to show the friendly names of the monitors on the overlay windows.</param>
        public MonitorSetupOverlay ShowOverlay(short seconds = -1, bool showMonitorNames = true)
        {
            MonitorSetupOverlay overlay = new MonitorSetupOverlay(Monitors, showMonitorNames);
            overlay.Show(seconds);
            return overlay;
        }
    }
}
