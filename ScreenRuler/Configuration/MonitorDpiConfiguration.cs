using System;

namespace ScreenRuler.Configuration
{
    /// <summary>
    /// Represents the DPI configuration of one monitor.
    /// </summary>
    [Serializable]
    public class MonitorDpiConfiguration
    {
        /// <summary>
        /// Monitor ID string.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Manual setting for the monitor's DPI.
        /// </summary>
        public float HorizontalDpi { get; set; } = 96;
        /// <summary>
        /// Manual setting for the monitor's vertical DPI.
        /// </summary>
        public float VerticalDpi { get; set; } = 96;

        public MonitorDpiConfiguration() { }

        public MonitorDpiConfiguration(string id)
        {
            Id = id;
        }
    }
}
