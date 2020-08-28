using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ScreenRuler.Controls
{
    public class MarkerListBox : ListBox
    {
        protected override void Sort()
        {
            var sortedItems = Items.Cast<Marker>()
                .OrderBy(m => m, new MarkerComparer())
                .Cast<object>().ToArray();
            Items.Clear();
            Items.AddRange(sortedItems);
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
