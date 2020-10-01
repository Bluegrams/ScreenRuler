using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ScreenRuler.Units;

namespace ScreenRuler
{
    class UnitScale
    {
        /// <summary>
        /// The size of one step in the corresponding unit.
        /// </summary>
        public float StepSize { get; set; }
        /// <summary>
        /// After how many steps to set a medium tick.
        /// </summary>
        public int MTickSteps { get; set; }
        /// <summary>
        /// After how many steps to set a big tick.
        /// </summary>
        public int BTickSteps { get; set; }
    }

    /// <summary>
    /// Holds methods for painting the ruler form.
    /// </summary>
    class RulerPainter
    {
        public const int RULER_WIDTH_WIDE = 80;
        public const int RULER_WIDTH_SLIM = 45;

        /// <summary>
        /// Defines the position where ticks should be drawn dependent on the chosen unit.
        /// (To deal with integers, all values are multiplied by 10 (e.g. 50 means 5px)).
        /// </summary>
        public static Dictionary<MeasuringUnit, UnitScale> Ticks = new Dictionary<MeasuringUnit, UnitScale>()
        {
            {MeasuringUnit.Pixels, new UnitScale { StepSize=5, MTickSteps=2, BTickSteps=10 } },
            {MeasuringUnit.Inches, new UnitScale { StepSize=0.0625f, MTickSteps=4, BTickSteps=16 } },
            {MeasuringUnit.Centimeters, new UnitScale { StepSize=0.1f, MTickSteps=5, BTickSteps=10 } },
            {MeasuringUnit.Points, new UnitScale { StepSize=5, MTickSteps=2, BTickSteps=10 } },
            {MeasuringUnit.Percent, new UnitScale { StepSize=0.5f, MTickSteps=2, BTickSteps=10 } },
        };

        private const string MarkerSymbolCenterLine = "\u00BD";
        private const string MarkerSymbolMouseLine  = "\u271C"; // u271B u271C
        private const string MarkerSymbolThirdLines = "\u2153"; 
        private const string MarkerSymbolGoldenLine = "\u03D5"; // u03C6 u03A6 u03D5
        private const int MarkerSymbolCustomLine1 = 0x2460-1; // Circled 1, add for up to 20 (-1 for correct behaviour post 20)

        private readonly Control c;
        private readonly float phi;
        private Settings settings;
        private UnitConverter converter;
        private Graphics g;
        private int drawWidth;
        private FormResizeMode resizeMode = FormResizeMode.Horizontal;
        
        public RulerPainter(Control control)
        {
            this.c = control;
            this.phi = (float)(2 / (1 + Math.Sqrt(5)));
        }

        /// <summary>
        /// Updates relevant properties before repainting the ruler.
        /// </summary>
        /// <param name="g">The graphics to be painted on.</param>
        /// <param name="settings">The settings.</param>
        public void Update(Graphics g, Settings settings, FormResizeMode resizeMode)
        {
            this.g = g;
            this.settings = settings;
            this.resizeMode = resizeMode;
            var screenSize = Screen.FromControl(c).Bounds.Size;
            int virtualDpi = (int)(settings.MonitorDpi / (settings.MonitorScaling / 100.0));
            this.converter = new UnitConverter(settings.MeasuringUnit, screenSize, virtualDpi);
            this.drawWidth = settings.SlimMode ? RULER_WIDTH_SLIM : RULER_WIDTH_WIDE;
        }

        /// <summary>
        /// Paints the ruler scale onto the given Graphics object.
        /// </summary>
        public void PaintRuler()
        {
            // ----- Draw the ruler background -----
            using (Brush brush = new SolidBrush(settings.Theme.Background))
            {
                if (resizeMode.HasFlag(FormResizeMode.Horizontal))
                    g.FillRectangle(brush, 0, 0, c.Width, drawWidth);
                if (resizeMode.HasFlag(FormResizeMode.Vertical))
                    g.FillRectangle(brush, 0, 0, drawWidth, c.Height);
            }
            // ----- Draw the ruler scale -----
            if (!settings.HideRulerScale)
            {
                if (resizeMode.HasFlag(FormResizeMode.Horizontal))
                    PaintRulerScale(false);
                if (resizeMode.HasFlag(FormResizeMode.Vertical))
                    PaintRulerScale(true);
            }
        }

        protected void PaintRulerScale(bool vertical)
        {
            int max = vertical ? c.Size.Height : c.Size.Width;
            // ----- Draw the ruler scale -----
            UnitScale scale = Ticks[settings.MeasuringUnit];
            // valUnit: the current position in the chosen unit.
            // valPixel: the current position in pixels.
            float valUnit = 0, valPixel = 0, i = 0;
            while (valPixel <= max)
            {
                valPixel = converter.ConvertToPixel(valUnit, vertical);
                int length = i % scale.BTickSteps == 0 ? drawWidth / 4 : i % scale.MTickSteps == 0 ? drawWidth / 6 : drawWidth / 16;
                using (Brush brush = new SolidBrush(settings.Theme.TickColor))
                using (Pen pen = new Pen(brush, 1))
                using (Font font = new Font("Arial", 9))
                {
                    float pos = valPixel;
                    if (!vertical)
                    {
                        if (resizeMode == FormResizeMode.Horizontal || pos > length)
                            g.DrawLine(pen, pos, 0, pos, length);
                        if (!settings.SlimMode && (resizeMode == FormResizeMode.Horizontal || valPixel > drawWidth))
                            g.DrawLine(pen, pos, drawWidth - length, pos, drawWidth);
                        if (valPixel > 0 && i % scale.BTickSteps == 0)
                            g.DrawString(Math.Round(valUnit, 2).ToString(), font, brush, pos - 8, length + 3);
                    }
                    else
                    {
                        if (resizeMode == FormResizeMode.Vertical || pos > length)
                            g.DrawLine(pen, 0, pos, length, pos);
                        if (!settings.SlimMode && (resizeMode == FormResizeMode.Vertical || valPixel > drawWidth))
                            g.DrawLine(pen, drawWidth - length, pos, drawWidth, pos);
                        if (valPixel > 0 && i % scale.BTickSteps == 0)
                            g.DrawString(Math.Round(valUnit, 2).ToString(), font, brush, length + 3, pos - 7);
                    }
                }
                valUnit += scale.StepSize;
                i += 1;
            }
            // ----- Optionally, draw total length bound to right border and start offset -----
            if (settings.ShowOffsetLengthLabels)
            {
                int roundingDigits = settings.SlimMode ? 1 : 2;
                string lblLength = String.Format("{0}{1}",
                    Math.Round(converter.ConvertFromPixel(max, vertical), roundingDigits), converter.UnitString);
                int offset = vertical ? c.Location.Y : c.Location.X;
                string lblOffset = String.Format("{0}{1}",
                    Math.Round(converter.ConvertFromPixel(offset, vertical), roundingDigits), converter.UnitString);
                using (Brush brush = new SolidBrush(settings.Theme.LengthLabelColor))
                using (Font font = new Font("Arial", 9))
                {
                    StringFormat format = new StringFormat() { Alignment = StringAlignment.Far };
                    if (!vertical)
                    {
                        float y = drawWidth;
                        // adjust the label text based on ruler width
                        if (settings.SlimMode) y -= 14;
                        else y /= 2.0f;
                        g.DrawString(lblLength, font, brush, max, y, format);
                        // only draw offset label if not in two-dimensional mode, otherwise it would look messy
                        if (resizeMode != FormResizeMode.TwoDimensional)
                            g.DrawString(lblOffset, font, brush, 0, y);
                    }
                    else
                    {
                        float x = drawWidth;
                        if (!settings.SlimMode) x *= (7.0f / 8.0f);
                        g.DrawString(lblLength, font, brush, x, max - 14, format);
                        // only draw offset label if not in two-dimensional mode, otherwise it would look messy
                        if (resizeMode != FormResizeMode.TwoDimensional)
                            g.DrawString(lblOffset, font, brush, x, 0, format);
                    }
                }
            }
        }

        /// <summary>
        /// Draws the markers onto the given Graphics object.
        /// </summary>
        public void PaintMarkers(MarkerCollection markers, Point mouse)
        {
            if (resizeMode.HasFlag(FormResizeMode.Horizontal))
                PaintMarkers(false, markers.Horizontal, mouse.X);
            if (resizeMode.HasFlag(FormResizeMode.Vertical))
                PaintMarkers(true, markers.Vertical, mouse.Y);
        }

        protected void PaintMarkers(bool vertical, IEnumerable<Marker> markers, float mouseLine)
        {
            int rulerLength = vertical ? c.Size.Height : c.Size.Width;
            // Draw line showing the ruler's center
            if (settings.ShowCenterLine)
            {
                float pos = (float)rulerLength / 2;
                Color col = settings.Theme.CenterLineColor;
                drawMarker(new Marker(pos, vertical), MarkerSymbolCenterLine, col);
            }
            // Draw line showing the position of the cursor
            if (settings.ShowMouseLine)
            {
                Color col = settings.Theme.MouseLineColor;
                drawMarker(new Marker(mouseLine, vertical), MarkerSymbolMouseLine, col, moveToRight: true);
            }
            // Draw the lines showing the thirds of the ruler
            if (settings.ShowThirdLines)
            {
                float third = (float)rulerLength / 3;
                Color col = settings.Theme.ThirdsLinesColor;
                drawMarker(new Marker(third, vertical), MarkerSymbolThirdLines, col);
                drawMarker(new Marker(2 * third, vertical), MarkerSymbolThirdLines, col);
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
                drawMarker(new Marker(goldenA, vertical), MarkerSymbolGoldenLine, col);
                drawMarker(new Marker(goldenB, vertical), MarkerSymbolGoldenLine, col);
            }
            // Draw all given custom markers
            if (!settings.HideRulerScale)
            {
                int x = 0;
                foreach (Marker marker in markers)
                {
                    // Symbols for 1-20 using unicode. More than 20 - skip symbol
                    var symbol = x < 20 ? char.ConvertFromUtf32(MarkerSymbolCustomLine1 + ++x) : $"({++x}) ";
                    Color col = settings.Theme.CustomLinesColor;
                    drawMarker(marker, symbol, col);
                }
            }
        }

        private void drawMarker(Marker marker, string symbol, Color col, bool moveToRight = false)
        {
            // Number format with or without symbol depending on settings
            string numberFormat = settings.ShowMarkerSymbol ? $"'{symbol}'.##" : ".##";
            // Note: StringFormatFlags.DirectionRightToLeft won't work with some symbols since it's intended for right-to-left languages.
            // Symbols gets placed before or after depending on category of language it belong to. 
            StringFormat format = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far };
            var text = converter.ConvertFromPixel(marker).ToString(numberFormat);

            using (Brush brush = new SolidBrush(col))
            using (Pen pen = new Pen(brush, settings.MarkerThickness))
            using (Font font = new Font("Arial", 9))
            {
                // If the marker is too far to the left/ top, the label would be cut. Therefore, move it to the right/ bottom.
                if (moveToRight)
                {
                    SizeF size = g.MeasureString(text, font);
                    if (marker.Vertical && marker.Value < size.Height) format.LineAlignment = StringAlignment.Near;
                    else if (!marker.Vertical && marker.Value < size.Width) format.Alignment = StringAlignment.Near;
                }
                float pos = marker.Value;
                if (!marker.Vertical)
                {
                    g.DrawLine(pen, pos, 0, pos, drawWidth);
                    // only draw labels if we have enough space
                    if (!settings.SlimMode)
                        g.DrawString(text, font, brush, pos, drawWidth / 2, format);
                }
                else
                {
                    g.DrawLine(pen, 0, pos, drawWidth, pos);
                    if (!settings.SlimMode)
                        g.DrawString(text, font, brush, drawWidth * (7.0f/8.0f), pos, format);
                }
            }
        }
    }
}
