using System;
using System.Collections.Generic;

namespace ScreenRuler.Units
{
    /// <summary>
    /// A class that converts to and from pixel values.
    /// </summary>
    public class UnitConverter
    {
        private Func<float, int, float> toPixelConverter, fromPixelConverter;

        /// <summary>
        /// The measuring unit this converter converts to/ from.
        /// </summary>
        public MeasuringUnit Unit { get; private set; }
        /// <summary>
        /// The screen DPI used for conversion.
        /// </summary>
        public int DPI { get; set; }
        /// <summary>
        /// The string symbol of the unit this converter converts to/ from.
        /// </summary>
        public string UnitString { get { return UnitStrings[Unit]; } }

        public UnitConverter(MeasuringUnit unit, int dpi)
        {
            this.Unit = unit;
            this.DPI = dpi;
            toPixelConverter = getToPixelConverter(unit);
            fromPixelConverter = getFromPixelConverter(unit);
        }

        /// <summary>
        /// Converts the given value to a pixel value.
        /// </summary>
        /// <param name="value">A value in the unit this converter converts to/ from.</param>
        /// <returns>The value converted to pixels.</returns>
        public float ConvertToPixel(float value) => toPixelConverter.Invoke(value, DPI);

        /// <summary>
        /// Converts a given pixel value to the defined unit.
        /// </summary>
        /// <param name="value">A pixel value.</param>
        /// <returns>The value converted to the unit this converter converts to.</returns>
        public float ConvertFromPixel(float value) => fromPixelConverter.Invoke(value, DPI);

        /// <summary>
        /// Returns a function that converts the given measuring unit into pixels.
        /// </summary>
        private static Func<float, int, float> getToPixelConverter(MeasuringUnit unit)
        {
            switch (unit)
            {
                case MeasuringUnit.Inches:
                    return (v, dpi) => v * dpi;
                case MeasuringUnit.Points:
                    return (v, dpi) => v / 72.0f * dpi;
                case MeasuringUnit.Centimeters:
                    return (v, dpi) => v / 2.54f * dpi;
                default:
                    return (v, dpi) => v;
            }
        }

        /// <summary>
        /// Returns a function that converts pixels into the given measuring unit.
        /// </summary>
        private static Func<float, int, float> getFromPixelConverter(MeasuringUnit unit)
        {
            switch (unit)
            {
                case MeasuringUnit.Inches:
                    return (v, dpi) => v / dpi;
                case MeasuringUnit.Points:
                    return (v, dpi) => v * 72.0f / dpi;
                case MeasuringUnit.Centimeters:
                    return (v, dpi) => v * 2.54f / dpi;
                default:
                    return (v, dpi) => v;
            }
        }

        public static Dictionary<MeasuringUnit, string> UnitStrings = new Dictionary<MeasuringUnit, string>()
        {
            {MeasuringUnit.Pixels, "px"},
            {MeasuringUnit.Centimeters, "cm"},
            {MeasuringUnit.Inches, "in"},
            {MeasuringUnit.Points, "pt"}
        };
    }
}
