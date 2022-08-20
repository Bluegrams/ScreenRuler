using System;
using System.Linq;
using System.Windows.Forms;

namespace ScreenRuler.Configuration.Monitor
{
    /// <summary>
    /// Provides a screen overlay that shows IDs on all connected monitors.
    /// </summary>
    public class MonitorSetupOverlay
    {
        private MonitorInfo[] monitors;
        private bool showMonitorNames;
        private Timer timer;
        private MonitorIdForm[] overlayForms;

        /// <summary>
        /// Creates a new instance of MonitorSetupOverlay.
        /// </summary>
        /// <param name="monitors">The used monitor info data.</param>
        /// <param name="showMonitorNames">Whether to show the friendly names of the monitors on the overlay windows.</param>
        public MonitorSetupOverlay(MonitorInfo[] monitors, bool showMonitorNames = true)
        {
            this.monitors = monitors;
            this.showMonitorNames = showMonitorNames;
            this.timer = new Timer();
            this.timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Show the monitor ID overlay for the specified number of seconds.
        /// </summary>
        /// <param name="seconds">The number of seconds the overlay should be visible. If <= 0, show until Close() is called.</param>
        public void Show(short seconds = -1)
        {
            Close();  // Make sure overlay is not shown twice.
            overlayForms = Screen.AllScreens.Select(s => createFormForScreen(s)).ToArray();
            overlayForms.ToList().ForEach(form => form.Show());
            if (seconds > 0)
            {
                timer.Interval = seconds * 1000;
                timer.Start();
            }
        }

        private MonitorIdForm createFormForScreen(Screen screen)
        {
            MonitorInfo monitorInfo = monitors.Where(d => d.DisplayName == screen.DeviceName).FirstOrDefault();
            if (monitorInfo != null)
            {
                MonitorIdForm form = new MonitorIdForm(
                    monitorInfo.Id.ToString(),
                    showMonitorNames ? monitorInfo.FriendlyName : String.Empty
                );
                form.Location = screen.WorkingArea.Location;
                return form;
            }
            else throw new InvalidOperationException($"Could not find valid monitor information for '{screen.DeviceName}'.");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Close()
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
            if (overlayForms != null)
            {
                foreach (var form in overlayForms)
                {
                    form.Close();
                }
                overlayForms = null;
            }
        }
    }
}
