using System;
using System.Linq;
using System.Text.RegularExpressions;
using WindowsDisplayAPI.DisplayConfig;

namespace ScreenRuler.Configuration.Monitor
{
    /// <summary>
    /// Represents information on a monitor device.
    /// </summary>
    public class MonitorInfo
    {
        /// <summary>
        /// Gets the monitor ID from the display name.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Gets the display friendly name.
        /// </summary>
        public string FriendlyName { get; }
        /// <summary>
        /// Gets the display device source name.
        /// </summary>
        public string DisplayName { get; }
        /// <summary>
        /// Gets the display device path.
        /// </summary>
        public string DevicePath { get; }

        public MonitorInfo(PathDisplayTarget pathDisplayTarget)
        {
            if (int.TryParse(Regex.Match(pathDisplayTarget.ToDisplayDevice().DisplayName, @"\d+").Value, out int result))
                Id = result;
            else Id = 0;
            FriendlyName = pathDisplayTarget.FriendlyName;
            DisplayName = pathDisplayTarget.ToDisplayDevice().DisplayName;
            DevicePath = pathDisplayTarget.DevicePath;
        }

        public override string ToString()
        {
            string name = !String.IsNullOrEmpty(FriendlyName) ? FriendlyName : DevicePath;
            return $"[{Id}] {name}";
        }

        /// <summary>
        /// Retrieves a list of currently attached monitor devices.
        /// </summary>
        /// <returns>An array of MonitorInfo instances.</returns>
        public static MonitorInfo[] GetMonitorInfos()
        {
            return PathDisplayTarget.GetDisplayTargets().Select(d => new MonitorInfo(d)).ToArray();
        }
    }
}
