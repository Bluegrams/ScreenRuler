using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ScreenRuler.Configuration;

namespace ScreenRuler.Units
{
    /// <summary>
    /// A class that converts to and from pixel values.
    /// </summary>
    public class UnitConverter
    {
        private readonly Func<float, int, float, float> toPixelConverter, fromPixelConverter;
        private readonly Func<float, float, float> toDpiConverter;

        /// <summary>
        /// The measuring unit this converter converts to/ from.
        /// </summary>
        public MeasuringUnit Unit { get; private set; }
        /// <summary>
        /// The size of the screen.
        /// </summary>
        public Size ScreenSize { get; set; }

        /// <summary>
        /// The screen DPI used for conversion.
        /// </summary>
        public float DPI { get; set; }
        public float? VerticalDPI { get; set; }

        /// <summary>
        /// The string symbol of the unit this converter converts to/ from.
        /// </summary>
        public string UnitString { get { return UnitStrings[Unit]; } }

        public UnitConverter(MeasuringUnit unit, Size screenSize, float dpi, float? verticalDpi = null)
        {
            this.Unit = unit;
            this.ScreenSize = screenSize;
            this.DPI = dpi;
            this.VerticalDPI = verticalDpi;
            toPixelConverter = getToPixelConverter(unit);
            fromPixelConverter = getFromPixelConverter(unit);
            toDpiConverter = getToDpiConverter(unit);
        }

        /// <summary>
        /// Determine active monitor DPI based on the specified settings.
        /// </summary>
        /// <param name="control">The control for which to determine monitor DPI.</param>
        /// <param name="settings">The settings to be used.</param>
        /// <returns>A tuple containing horizontal and vertical DPI.</returns>
        public static (float horizontal, float? vertical) GetDpiFromSettings(Control control, Settings settings)
        {
            float horizontalDpi;
            float? verticalDpi = null;
            switch (settings.DpiScalingMode)
            {
                case DpiScalingMode.Unaware:
                    horizontalDpi = control.DeviceDpi;
                    break;
                case DpiScalingMode.Auto:
                    horizontalDpi = WinApi.GetMonitorDpiFromWindow(control.Handle, MonitorDpiType.RAW_DPI);
                    break;
                case DpiScalingMode.Manual:
                    horizontalDpi = settings.MonitorDpi;
                    verticalDpi = settings.VerticalMonitorDpi;
                    break;
                case DpiScalingMode.ManualPerMonitor:
                    (horizontalDpi, verticalDpi) = MonitorSetup.Instance.Lookup(Screen.FromControl(control), settings);
                    break;
                default:
                    horizontalDpi = 96;
                    break;
            }
            return (horizontalDpi, verticalDpi);
        }

        public static UnitConverter FromSettings(Control control, Settings settings, MeasuringUnit? unit = null)
        {
            var screenSize = Screen.FromControl(control).Bounds.Size;
            (float horizontalDpi, float? verticalDpi) = GetDpiFromSettings(control, settings);
            return new UnitConverter(unit ?? settings.MeasuringUnit, screenSize, horizontalDpi, verticalDpi);
        }

        private float getDpi(bool vertical) => vertical ? VerticalDPI ?? DPI : DPI;

        /// <summary>
        /// Converts the given value to a pixel value.
        /// </summary>
        /// <param name="value">A value in the unit this converter converts to/ from.</param>
        /// <returns>The value converted to pixels.</returns>
        public float ConvertToPixel(float value, bool vertical)
            => toPixelConverter.Invoke(value, vertical ? ScreenSize.Height : ScreenSize.Width, getDpi(vertical));

        /// <summary>
        /// Converts the given marker to a pixel value.
        /// </summary>
        /// <param name="marker">The marker to be converted.</param>
        /// <returns>The value converted to pixels.</returns>
        public float ConvertToPixel(Marker marker)
            => ConvertToPixel(marker.Value, marker.Vertical);

        /// <summary>
        /// Converts a given pixel value to the defined unit.
        /// </summary>
        /// <param name="value">A pixel value.</param>
        /// <returns>The value converted to the unit this converter converts to.</returns>
        public float ConvertFromPixel(float value, bool vertical)
            => fromPixelConverter.Invoke(value, vertical ? ScreenSize.Height : ScreenSize.Width, getDpi(vertical));

        /// <summary>
        /// Converts a given marker from pixels to the defined unit.
        /// </summary>
        /// <param name="marker">The marker to be converted.</param>
        /// <returns>The value converted to the unit this converter converts to.</returns>
        public float ConvertFromPixel(Marker marker)
            => ConvertFromPixel(marker.Value, marker.Vertical);

        /// <summary>
        /// Computes a DPI value from the given measuring unit and pixels values.
        /// </summary>
        /// <param name="unitValue">The value in the unit of this converter.</param>
        /// <param name="pixelValue">The value in pixels.</param>
        /// <returns>The computed DPI value.</returns>
        public float ConvertToDpi(float unitValue, float pixelValue)
            => toDpiConverter.Invoke(unitValue, pixelValue);

        /// <summary>
        /// Converts a given pixel value to the defined unit and formats it as a string.
        /// </summary>
        /// <param name="value">The pixel value to convert.</param>
        /// <param name="vertical">Whether the value is in vertical or horizontal direction.</param>
        /// <param name="roundingDigits">Round the formatted string to this number of digits.</param>
        /// <returns>The converted value, formatted as string.</returns>
        public string FormatFromPixel(float value, bool vertical, int roundingDigits = 2)
            => String.Format("{0}{1}", Math.Round(ConvertFromPixel(value, vertical), roundingDigits), UnitString);

        /// <summary>
        /// Converts a given marker from pixels to the defined unit and formats it as a string.
        /// </summary>
        /// <param name="marker">The marker to convert.</param>
        /// <param name="roundingDigits">Round the formatted string to this number of digits.</param>
        /// <returns>The converted value, formatted as string.</returns>
        public string FormatFromPixel(Marker marker, int roundingDigits = 2)
            => String.Format("{0}{1}", Math.Round(ConvertFromPixel(marker), roundingDigits), UnitString);

        /// <summary>
        /// Returns a function that converts the given measuring unit into pixels.
        /// </summary>
        private static Func<float, int, float, float> getToPixelConverter(MeasuringUnit unit)
        {
            switch (unit)
            {
                case MeasuringUnit.Inches:
                    return (v, _, dpi) => v * dpi;
                case MeasuringUnit.Points:
                    return (v, _, dpi) => v / 72.0f * dpi;
                case MeasuringUnit.Centimeters:
                    return (v, _, dpi) => v / 2.54f * dpi;
                case MeasuringUnit.Percent:
                    return (v, total, _) => v / 100.0f * total;
                default:
                    return (v, _, dpi) => v;
            }
        }

        /// <summary>
        /// Returns a function that converts pixels into the given measuring unit.
        /// </summary>
        private static Func<float, int, float, float> getFromPixelConverter(MeasuringUnit unit)
        {
            switch (unit)
            {
                case MeasuringUnit.Inches:
                    return (v, _, dpi) => v / dpi;
                case MeasuringUnit.Points:
                    return (v, _, dpi) => v * 72.0f / dpi;
                case MeasuringUnit.Centimeters:
                    return (v, _, dpi) => v * 2.54f / dpi;
                case MeasuringUnit.Percent:
                    return (v, total, _) => v / total * 100.0f;
                default:
                    return (v, _, dpi) => v;
            }
        }

        /// <summary>
        /// Returns a function that computes a DPI value from the given measuring unit and pixels values.
        /// </summary>
        private static Func<float, float, float> getToDpiConverter(MeasuringUnit unit)
        {
            switch (unit)
            {
                case MeasuringUnit.Inches:
                    return (v, pxs) => pxs / v;
                case MeasuringUnit.Points:
                    return (v, pxs) => pxs / v * 72.0f;
                case MeasuringUnit.Centimeters:
                    return (v, pxs) => pxs / v * 2.54f;
                default:
                    return (v, pxs) => float.NaN;
            }
        }

        public static Dictionary<MeasuringUnit, string> UnitStrings = new Dictionary<MeasuringUnit, string>()
        {
            {MeasuringUnit.Pixels, "px"},
            {MeasuringUnit.Centimeters, "cm"},
            {MeasuringUnit.Inches, "in"},
            {MeasuringUnit.Points, "pt"},
            {MeasuringUnit.Percent, "%"}
        };
    }
}
