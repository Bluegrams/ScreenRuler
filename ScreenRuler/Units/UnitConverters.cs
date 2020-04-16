using System;
using System.Collections.Generic;
using System.Drawing;

namespace ScreenRuler.Units
{
    /// <summary>
    /// A class that converts to and from pixel values.
    /// </summary>
    public class UnitConverter
    {
        private Func<float, int, int, float> toPixelConverter, fromPixelConverter;

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
        public int DPI { get; set; }
        /// <summary>
        /// The string symbol of the unit this converter converts to/ from.
        /// </summary>
        public string UnitString { get { return UnitStrings[Unit]; } }

        public UnitConverter(MeasuringUnit unit, Size screenSize, int dpi)
        {
            this.Unit = unit;
            this.ScreenSize = screenSize;
            this.DPI = dpi;
            toPixelConverter = getToPixelConverter(unit);
            fromPixelConverter = getFromPixelConverter(unit);
        }

        /// <summary>
        /// Converts the given value to a pixel value.
        /// </summary>
        /// <param name="value">A value in the unit this converter converts to/ from.</param>
        /// <returns>The value converted to pixels.</returns>
        public float ConvertToPixel(float value, bool vertical)
            => toPixelConverter.Invoke(value, vertical ? ScreenSize.Height : ScreenSize.Width, DPI);

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
            => fromPixelConverter.Invoke(value, vertical ? ScreenSize.Height : ScreenSize.Width, DPI);

        /// <summary>
        /// Converts a given marker from pixels to the defined unit.
        /// </summary>
        /// <param name="marker">The marker to be converted.</param>
        /// <returns>The value converted to the unit this converter converts to.</returns>
        public float ConvertFromPixel(Marker marker)
            => ConvertFromPixel(marker.Value, marker.Vertical);

        /// <summary>
        /// Returns a function that converts the given measuring unit into pixels.
        /// </summary>
        private static Func<float, int, int, float> getToPixelConverter(MeasuringUnit unit)
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
        private static Func<float, int, int, float> getFromPixelConverter(MeasuringUnit unit)
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
