using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            this.converter = UnitConverter.FromSettings(c, settings);
            this.drawWidth = settings.SlimMode ? RULER_WIDTH_SLIM : RULER_WIDTH_WIDE;
            this.drawWidth = (int)(this.drawWidth * (this.c.DeviceDpi / 96.0f));
        }

        /// <summary>
        /// Paints the ruler scale onto the given Graphics object.
        /// </summary>
        public void PaintRuler()
        {
            ApplyTransformation();
            // ----- Draw the ruler background -----
            PaintRulerCanvas();
            // ----- Draw the ruler scale -----
            if (!settings.HideRulerScale)
            {
                if (resizeMode.HasFlag(FormResizeMode.Horizontal))
                    PaintRulerScale(false);
                if (resizeMode.HasFlag(FormResizeMode.Vertical))
                    PaintRulerScale(true);
            }
            g.ResetTransform();
        }

        protected void PaintRulerCanvas()
        {
            using (Brush brush = new SolidBrush(settings.Theme.Background))
            {
                if (resizeMode.HasFlag(FormResizeMode.Horizontal))
                {
                    g.FillRectangle(brush, 0, 0, c.Width, drawWidth);

                }
                if (resizeMode.HasFlag(FormResizeMode.Vertical))
                {
                    g.FillRectangle(brush, 0, 0, drawWidth, c.Height);
                }
            }
        }

        protected void PaintRulerScale(bool vertical)
        {
            int max = vertical ? c.Height : c.Width;
            // ----- Draw the ruler scale -----
            UnitScale scale = Ticks[settings.MeasuringUnit];
            // valUnit: the current position in the chosen unit.
            // valPixel: the current position in pixels.
            float valUnit = 0, valPixel = 0;
            int i = 0;
            while (valPixel <= max)
            {
                valPixel = converter.ConvertToPixel(valUnit, vertical);
                paintTick(i, valPixel, valUnit, scale, vertical);
                valUnit += scale.StepSize;
                i += 1;
            }
            // ----- Optionally, draw total length bound to right border and start offset -----
            if (settings.ShowOffsetLengthLabels)
            {
                int roundingDigits = settings.SlimMode ? 1 : 2;
                string lblLength = converter.FormatFromPixel(max, vertical, roundingDigits);
                // The offset value depends on whether the ruler is flipped.
                int offset;
                if (vertical)
                {
                    if (settings.FlippedY) offset = converter.ScreenSize.Height - c.Bottom;
                    else offset = c.Top;
                }
                else
                {
                    if (settings.FlippedX) offset = converter.ScreenSize.Width - c.Right;
                    else offset = c.Left;
                }
                string lblOffset = converter.FormatFromPixel(offset, vertical, roundingDigits);
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
                        DrawString(lblLength, font, brush, max, y, format);
                        // only draw offset label if not in two-dimensional mode, otherwise it would look messy
                        if (resizeMode != FormResizeMode.TwoDimensional)
                            DrawString(lblOffset, font, brush, 0, y);
                    }
                    else
                    {
                        float x = drawWidth;
                        if (!settings.SlimMode) x *= (7.0f / 8.0f);
                        DrawString(lblLength, font, brush, x, max - 14, format);
                        // only draw offset label if not in two-dimensional mode, otherwise it would look messy
                        if (resizeMode != FormResizeMode.TwoDimensional)
                            DrawString(lblOffset, font, brush, x, 0, format);
                    }
                }
            }
        }

        private void paintTick(int i, float valPixel, float valUnit, UnitScale scale, bool vertical)
        {
            int length = i % scale.BTickSteps == 0 ? drawWidth / 4 : i % scale.MTickSteps == 0 ? drawWidth / 6 : drawWidth / 16;
            // Only draw one row of ticks in slim mode.
            bool drawUpper = true;
            bool drawLower = !settings.SlimMode;
            // In 2D mode, don't draw ticks at connection to other scale.
            if (resizeMode == FormResizeMode.TwoDimensional)
            {
                /*
                 * Check if we are within the area of a tick in the opposite direction
                 * or within the area of the opposite direction scale.
                 */
                drawUpper &= !(valPixel < length);
                drawLower &= !(valPixel < drawWidth);

            }
            using (Brush brush = new SolidBrush(settings.Theme.TickColor))
            using (Pen pen = new Pen(brush, 1))
            using (Font font = new Font("Arial", 9))
            {
                float pos = valPixel;
                if (!vertical)
                {
                    if (drawUpper)
                        g.DrawLine(pen, pos, 0, pos, length);
                    if (drawLower)
                        g.DrawLine(pen, pos, drawWidth - length, pos, drawWidth);
                    if (valUnit > 0 && i % scale.BTickSteps == 0)
                        DrawString(Math.Round(valUnit, 2).ToString(), font, brush, pos - 8, length + 3);
                }
                else
                {
                    if (drawUpper)
                        g.DrawLine(pen, 0, pos, length, pos);
                    if (drawLower)
                        g.DrawLine(pen, drawWidth - length, pos, drawWidth, pos);
                    if (valUnit > 0 && i % scale.BTickSteps == 0)
                        DrawString(Math.Round(valUnit, 2).ToString(), font, brush, length + 3, pos - 7);
                }
            }
        }

        /// <summary>
        /// Draws the markers onto the given Graphics object.
        /// </summary>
        public void PaintMarkers(MarkerCollection markers, Point mouse)
        {
            ApplyTransformation();
            if (resizeMode.HasFlag(FormResizeMode.Horizontal))
                PaintMarkers(false, markers.Horizontal, mouse.X);
            if (resizeMode.HasFlag(FormResizeMode.Vertical))
                PaintMarkers(true, markers.Vertical, mouse.Y);
            if (resizeMode == FormResizeMode.TwoDimensional && settings.HypotenuseMode != HypotenuseMode.None)
                draw2DHypotenuse(mouse);
            g.ResetTransform();
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
                // The marker value depends on whether the ruler is flipped.
                bool inverse = vertical && settings.FlippedY || !vertical && settings.FlippedX;
                if (inverse)
                    mouseLine = rulerLength - mouseLine;
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
            string numberFormat = settings.ShowMarkerSymbol ? $"'{symbol}'0.##" : "0.##";
            // Note: StringFormatFlags.DirectionRightToLeft won't work with some symbols since it's intended for right-to-left languages.
            // Symbols gets placed before or after depending on category of language it belong to. 
            StringFormat format = new StringFormat() { Alignment = StringAlignment.Far };
            if (marker.Vertical) format.LineAlignment = StringAlignment.Far;
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
                        DrawString(text, font, brush, pos, drawWidth / 2, format);
                }
                else
                {
                    g.DrawLine(pen, 0, pos, drawWidth, pos);
                    if (!settings.SlimMode)
                        DrawString(text, font, brush, drawWidth * (7.0f/8.0f), pos, format);
                }
            }
        }

        private void draw2DHypotenuse(Point mousePosition)
        {
            mousePosition = TransformPoints(mousePosition)[0];
            // Depending on the settings, we draw the hypotenuse at the mouse position or at the ruler ends.
            Point reference = settings.HypotenuseMode == HypotenuseMode.Moving ? mousePosition : new Point(c.Size);
            // calculate the length of the hypotenuse
            double hypotenuse = Math.Sqrt(reference.X * reference.X + reference.Y * reference.Y);
            // calculate the length of the angles
            double angleLeft = (180 / Math.PI) * Math.Acos(reference.Y / hypotenuse);
            double angleTop = (180 / Math.PI) * Math.Acos(reference.X / hypotenuse);
            Point startPoint = new Point(0, reference.Y);
            Point endPoint = new Point(reference.X, 0);
            // Show the hypotenuse of the triangle constructed by the cursor position in 2D mode
            using (Brush brush = new SolidBrush(settings.Theme.MouseLineColor))
            using (Pen pen = new Pen(brush, settings.MarkerThickness))
            {
                g.DrawLine(pen, startPoint, endPoint);
            }
            // Show additional information in a box
            StringFormat format = new StringFormat() { Alignment = StringAlignment.Far };
            using (Brush backgroundBrush = new SolidBrush(settings.Theme.Background))
            using (Brush penBrush = new SolidBrush(settings.Theme.TickColor))
            using (Font font = new Font("Arial", 9))
            {
                Size boxSize = new Size(80, 50);
                Point cornerPoint = new Point(reference.X / 2, reference.Y / 2);
                if (cornerPoint.X > boxSize.Width && cornerPoint.Y > boxSize.Height)
                    cornerPoint -= boxSize;
                g.FillRectangle(backgroundBrush, new Rectangle(cornerPoint, boxSize));
                string s = settings.FlippedX ? "\u21ff  \nR \u2220\nL \u2220" : "\u21ff  \nL \u2220\nR \u2220";
                DrawString(s, font, penBrush, cornerPoint + new Size(4, 4));
                DrawString(
                    String.Format("{0:0.##}\n{1:0.##}\n{2:0.##}", hypotenuse, angleLeft, angleTop),
                    font, penBrush, cornerPoint + new Size(boxSize.Width - 4, 4), format
                );
            }
        }

        /// <summary>
        /// Returns the graphics transformation matrix corresponding to the ruler flipping mode.
        /// </summary>
        public Matrix GetTransformationMatrix()
        {
            Matrix matrix = new Matrix();
            if (settings.FlippedX)
            {
                matrix.Translate(c.Width, 0);
                matrix.Scale(-1, 1);
            }
            if (settings.FlippedY)
            {
                matrix.Translate(0, c.Height);
                matrix.Scale(1, -1);
            }
            return matrix;
        }

        /// <summary>
        /// Applies coordinate system transformations on the graphics area depending on the ruler settings.
        /// </summary>
        protected void ApplyTransformation()
        {
            using (Matrix matrix = GetTransformationMatrix())
            {
                g.MultiplyTransform(matrix);
            }
        }

        /// <summary>
        /// Transforms an array of points from world to page coordinates.
        /// </summary>
        protected Point[] TransformPoints(params Point[] points)
        {
            g.TransformPoints(CoordinateSpace.Page, CoordinateSpace.World, points);
            return points;
        }

        /// <summary>
        /// Transforms an array of points from world to page coordinates.
        /// </summary>
        protected PointF[] TransformPoints(params PointF[] points)
        {
            g.TransformPoints(CoordinateSpace.Page, CoordinateSpace.World, points);
            return points;
        }

        /// <summary>
        /// Draws a string on the graphics canvas.
        /// This custom method is used instead of directly using Graphics.DrawString() to coordinate system transformations.
        /// If the ruler is flipped, the displayed string would normally also be flipped.
        /// To prevent this, we first only transform the string position and then reset all transformations while drawing the string.
        /// </summary>
        protected void DrawString(string s, Font font, Brush brush, PointF point, StringFormat format = null)
        {
            format = format ?? StringFormat.GenericDefault;
            Matrix transform = g.Transform;
            // Transform location where string will be drawn.
            PointF tPoint = TransformPoints(point)[0];
            /*
             * Transforming can flip the string direction horizontally or vertically.
             * Correct the occurring offset here.
             */
            SizeF size = g.MeasureString(s, font);
            if (transform.Elements[0] < 0)
            {
                if (format.Alignment == StringAlignment.Far)
                    tPoint.X += (int)size.Width;
                else
                    tPoint.X -= (int)size.Width;
            }
            if (transform.Elements[3] < 0)
                tPoint.Y -= (int)size.Height;
            // Reset all transformations while drawing the string.
            g.ResetTransform();
            g.DrawString(s, font, brush, tPoint, format);
            // Re-apply transformations.
            g.Transform = transform;
            transform.Dispose();
        }

        protected void DrawString(string s, Font font, Brush brush, float x, float y, StringFormat format = null)
            => DrawString(s, font, brush, new PointF(x, y), format);

    }
}
