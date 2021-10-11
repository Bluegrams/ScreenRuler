using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScreenRuler.Units;

namespace ScreenRuler.Controls
{
    public class MarkerListBox : ListBox
    {
        private UnitConverter unitConverter;

        public UnitConverter UnitConverter
        {
            get => unitConverter;
            set
            {
                unitConverter = value;
                Refresh();
            }
        }

        public MarkerListBox()
        {
            // Use pixels as default if nothing else is given
            UnitConverter = new UnitConverter(MeasuringUnit.Pixels, Size.Empty, 0);
            // We draw the items ourself
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void Sort()
        {
            var sortedItems = Items.Cast<Marker>()
                .OrderBy(m => m, new MarkerComparer())
                .Cast<object>().ToArray();
            Items.Clear();
            Items.AddRange(sortedItems);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0 && e.Index < Items.Count)
            {
                // Get the total number of horizontal markers for correct index
                int nHorizontal = Items.Cast<Marker>().Where(m => !m.Vertical).Count();
                // Draw marker
                Marker marker = (Marker)Items[e.Index];
                string valueString = UnitConverter.FormatFromPixel(marker);
                string directionString = marker.Vertical ? "⇅" : "⇄";
                int index = marker.Vertical ? e.Index + 1 - nHorizontal : e.Index + 1;
                string fullString = String.Format("{0} ({1}) {2,12}", directionString, index, valueString);
                e.Graphics.DrawString(fullString, e.Font, new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            }

            e.DrawFocusRectangle();
            base.OnDrawItem(e);
        }
    }

    class MarkerComparer : Comparer<Marker>
    {
        public override int Compare(Marker x, Marker y)
        {
            if (x.Vertical != y.Vertical)
            {
                return Convert.ToInt32(x.Vertical) - Convert.ToInt32(y.Vertical);
            }
            else
            {
                return (int)x.Value - (int)y.Value;
            }
        }
    }
}
