using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
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
            {MeasuringUnit.Points, new int[] {50, 100, 500} },
            {MeasuringUnit.Percent, new int[] {5, 10, 50 } },
        };

        private const string MarkerSymbolCenterLine = "\u00BD";
        private const string MarkerSymbolMouseLine  = "\u271C"; // u271B u271C
        private const string MarkerSymbolThirdLines = "\u2153"; 
        private const string MarkerSymbolGoldenLine = "\u03D5"; // u03C6 u03A6 u03D5
        private const int MarkerSymbolCustomLine1 = 0x2460-1; // Circled 1, add for up to 20 (-1 for correct behaviour post 20)

        private Graphics g;
        private Size size;
        private Point position;
        private Settings settings;
        private UnitConverter converter;
        private float phi;
        
        public RulerPainter(Graphics graphics, Form form, Settings settings)
        {
            this.g = graphics;
            this.size = form.Size;
            this.position = form.Location;
            this.settings = settings;
            var screenRect = Screen.FromControl(form).Bounds;
            var screenSize = settings.Vertical ? screenRect.Height : screenRect.Width;
            this.converter = new UnitConverter(settings.MeasuringUnit, screenSize, settings.MonitorDpi);
            this.phi = (float)(2 / (1 + Math.Sqrt(5)));
        }

        /// <summary>
        /// Paints the ruler scale onto the given Graphics object.
        /// </summary>
        public void PaintRuler()
        {
            int max = settings.Vertical ? size.Height : size.Width;
            int height = settings.Vertical ? size.Width : size.Height;
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
            if (settings.ShowOffsetLengthLabels)
            {
                string lblLength = String.Format("{0}{1}",
                    Math.Round(converter.ConvertFromPixel(max), 2), converter.UnitString);
                int offset = settings.Vertical ? position.Y : position.X;
                string lblOffset = String.Format("{0}{1}",
                    Math.Round(converter.ConvertFromPixel(offset), 2), converter.UnitString);
                using (Brush brush = new SolidBrush(settings.Theme.LengthLabelColor))
                using (Font font = new Font("Arial", 9))
                {
                    // Draw total length bound to right border (& optionally start offset).
                    StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                    if (!settings.Vertical)
                    {
                        float y = size.Height / 2.0f;
                        g.DrawString(lblLength, font, brush, max, y, format);
                        g.DrawString(lblOffset, font, brush, 0, y);
                    }
                    else
                    {
                        float x = size.Width * (7.0f / 8.0f);
                        g.DrawString(lblLength, font, brush, x, max - 13, format);
                        g.DrawString(lblOffset, font, brush, x, 0, format);
                    }
                }
            }
        }

        /// <summary>
        /// Draws the markers onto the given Graphics object.
        /// </summary>
        public void PaintMarkers(float mouseLine, LinkedList<int> customLines)
        {
            int rulerLength = settings.Vertical ? size.Height : size.Width;
            // Draw line showing the ruler's center
            if (settings.ShowCenterLine)
            {
                float pos = (float)rulerLength / 2;
                Color col = settings.Theme.CenterLineColor;
                drawLine(MarkerSymbolCenterLine, pos, col);
            }
            // Draw line showing the position of the cursor
            if (settings.ShowMouseLine)
            {
                Color col = settings.Theme.MouseLineColor;
                drawLine(MarkerSymbolMouseLine, mouseLine, col);
            }
            // Draw the lines showing the thirds of the ruler
            if (settings.ShowThirdLines)
            {
                float third = (float)rulerLength / 3;
                Color col = settings.Theme.ThirdsLinesColor;
                drawLine(MarkerSymbolThirdLines, third, col);
                drawLine(MarkerSymbolThirdLines, 2 * third, col);
            }
            // Draw the line showing the Golden Ratio  
            // Golden Ratio: A/B = (A+B)/A, where A > B > 0
            // The marker | shows A of Golden ratio: <---A---|-B->
            // Add a second marker showing same thing but from right/bottom instead, called B
            if (settings.ShowGoldenLine)
            {
                float goldenA = phi * rulerLength;
                float goldenB = rulerLength - goldenA;
                Color col = settings.Theme.GoldenLineColor;
                drawLine(MarkerSymbolGoldenLine, goldenB, col);
                drawLine(MarkerSymbolGoldenLine, goldenA, col);
            }
            // Draw all given custom markers
            int x = 0;
            foreach (int line in customLines)
            {
                // Symbols for 1-20 using unicode. More than 20 - skip symbol
                var symbol = x < 20 ? char.ConvertFromUtf32(MarkerSymbolCustomLine1 + ++x) : $"({++x}) ";
                Color col = settings.Theme.CustomLinesColor;
                drawLine(symbol, line, col);
            }
        }

        private void drawLine(string symbol, float pos, Color col)
        {
            // Number format with or without symbol depending on settings
            string numberFormat = settings.ShowMarkerSymbol ? $"'{symbol}'.##" : ".##";
            StringFormat format = new StringFormat() { Alignment = StringAlignment.Far };  // Note: StringFormatFlags.DirectionRightToLeft won't work with some symbols since it's intended for right-to-left languages. Symbols gets placed before or after depending on category of language it belong to. 
            var text = converter.ConvertFromPixel(pos).ToString(numberFormat);

            using (Brush brush = new SolidBrush(col))
            using (Pen pen = new Pen(brush, settings.MarkerThickness))
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
                    g.DrawString(text, font, brush, size.Width * (7.0f/8.0f), pos - 13, format);
                }
            }
        }
    }
}
