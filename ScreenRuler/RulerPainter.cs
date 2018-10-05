using System;
using System.Collections.Generic;
using System.Drawing;
using ScreenRuler.Units;

namespace ScreenRuler
{
    /// <summary>
    /// Holds methods for painting the ruler form.
    /// </summary>
    class RulerPainter
    {

        /// <summary>
        /// Defines the position where ticks should be drawn dependent on the chosen unit.
        /// (To deal with integers, all values are multiplied by 10 (e.g. 50 means 5px)).
        /// </summary>
        public static Dictionary<MeasuringUnit, int[]> Ticks = new Dictionary<MeasuringUnit, int[]>()
        {
            {MeasuringUnit.Pixels, new int[] {50, 100, 500} },
            {MeasuringUnit.Inches, new int[] {1, 5, 10} },
            {MeasuringUnit.Centimeters, new int[] {1, 5, 10} },
            {MeasuringUnit.Points, new int[] {50, 100, 500} }
        };

        /// <summary>
        /// Paints the ruler scale onto the given Graphics object.
        /// </summary>
        public static void Paint(Graphics g, Size size, Settings settings)
        {
            int max = settings.Vertical ? size.Height : size.Width;
            int height = settings.Vertical ? size.Width : size.Height;
            var converter = new UnitConverter(settings.MeasuringUnit, settings.MonitorDpi);
            // ----- Draw the ruler scale -----
            int[] ticks = Ticks[settings.MeasuringUnit];
            // valUnit: the current position in the chosen unit.
            // valPixel: the current position in pixels.
            float valUnit = 0, valPixel = 0, i = 0;
            while (valPixel <= max)
            {
                valUnit = i / 10;
                valPixel = converter.ConvertToPixel(valUnit);
                int length = i % ticks[2] == 0 ? height/4 : i % ticks[1] == 0 ? height/6 : height/16;
                using (Brush brush = new SolidBrush(settings.Theme.TickColor))
                using (Pen pen = new Pen(brush, 1))
                using (Font font = new Font("Arial", 9))
                {
                    if (!settings.Vertical)
                    {
                        g.DrawLine(pen, valPixel, 0, valPixel, length);
                        g.DrawLine(pen, valPixel, size.Height - length, valPixel, size.Height);
                        if (valPixel > 0 && i % ticks[2] == 0)
                            g.DrawString(valUnit.ToString(), font, brush, valPixel - 8, length + 3);
                    }
                    else
                    {
                        g.DrawLine(pen, 0, valPixel, length, valPixel);
                        g.DrawLine(pen, size.Width - length, valPixel, size.Width, valPixel);
                        if (valPixel > 0 && i % ticks[2] == 0)
                            g.DrawString(valUnit.ToString(), font, brush, length + 3, valPixel - 7);
                    }
                }
                i += ticks[0];
            }
            // ----- Draw additional labels -----
            string label = String.Format("{0}{1}", 
                Math.Round(converter.ConvertFromPixel(max), 2), converter.UnitString);
            var sc = g.DpiY / 96.0f; // adjust some text according to dpi scaling.
            using (Brush brush = new SolidBrush(settings.Theme.LengthLabelColor))
            using (Font font = new Font("Arial", 9))
            {
                // Draw total length bound to right border.
                StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                if (!settings.Vertical)
                {
                    g.DrawString(label, font, brush, max, size.Height / 2, format);
                }
                else
                {
                    g.DrawString(label, font, brush, size.Width * (7.0f / 8.0f), max - 13 * sc, format);
                }
            }
        }

        /// <summary>
        /// Draws the markers onto the given Graphics object.
        /// </summary>
        public static void PaintMarkers(Graphics g, Size size, Settings settings, float mouseLine, LinkedList<int> customLines)
        {
            var converter = new UnitConverter(settings.MeasuringUnit, settings.MonitorDpi);
            int rulerLength = settings.Vertical ? size.Height : size.Width;
            // Draw line showing the ruler's center
            if (settings.ShowCenterLine)
            {
                float pos = (float)rulerLength / 2;
                drawLine(g, size, settings, pos,
                    settings.Theme.CenterLineColor, converter);
            }
            // Draw line showing the position of the cursor
            if (settings.ShowMouseLine)
            {
                drawLine(g, size, settings, mouseLine,
                    settings.Theme.MouseLineColor, converter);
            }
            // Draw the lines showing the thirds of the ruler
            if (settings.ShowThirdLines)
            {
                float third = (float)rulerLength / 3;
                Color col = settings.Theme.ThirdsLinesColor;
                drawLine(g, size, settings, third, col, converter);
                drawLine(g, size, settings, 2 * third, col, converter);
            }
            // Draw all given custom markers
            foreach (int line in customLines)
            {
                drawLine(g,size, settings, line, settings.Theme.CustomLinesColor, converter);
            }
        }

        private static void drawLine(Graphics g, Size size, Settings settings, float pos, Color col, UnitConverter converter)
        {
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            var text = converter.ConvertFromPixel(pos).ToString(".##");
            var sc = g.DpiY / 96.0f; // adjust some text according to dpi scaling.
            using (Brush brush = new SolidBrush(col))
            using (Pen pen = new Pen(brush, 2))
            using (Font font = new Font("Arial", 9))
            {
                if (!settings.Vertical)
                {
                    g.DrawLine(pen, pos, 0, pos, size.Height);
                    g.DrawString(text, font, brush, pos, size.Height/2, format);
                }
                else
                {
                    g.DrawLine(pen, 0, pos, size.Width, pos);
                    g.DrawString(text, font, brush, size.Width * (7.0f/8.0f), pos - 13 * sc, format);
                }
            }
        }
    }
}
