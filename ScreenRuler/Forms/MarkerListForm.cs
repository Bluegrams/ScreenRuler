using ScreenRuler.Units;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ScreenRuler
{
    public partial class MarkerListForm : Form
    {
        private Settings settings;
        private UnitConverter unitConverter;

        public MarkerCollection MarkerCollection { get; }

        public MarkerListForm(MarkerCollection markerCollection, Settings settings)
        {
            this.MarkerCollection = markerCollection;
            this.settings = settings;
            InitializeComponent();
            this.ClientSize = lstMarkers.Size;
            setTheme();
            foreach (var marker in markerCollection.Markers)
            {
                lstMarkers.Items.Add(marker);
            }
            foreach (Enum item in Enum.GetValues(typeof(MeasuringUnit)))
            {
                conUnits.DropDownItems.Add(new ToolStripMenuItem(item.GetDescription(), null, conUnitsItem_Clicked) { Tag = item });
            }
            updateUnitConverter();
            markerCollection.MarkerCollectionChanged += markerCollection_MarkerCollectionChanged;
            settings.Changed += settings_Changed;
            settings.SelectedThemeChanged += settings_SelectedThemeChanged;
        }

        private void conUnitsItem_Clicked(object sender, EventArgs e)
        {
            var unit = (MeasuringUnit)((ToolStripMenuItem)sender).Tag;
            updateUnitConverter(unit);
        }

        private void updateUnitConverter(MeasuringUnit? unit = null)
        {
            unitConverter = UnitConverter.FromSettings(this, settings, unit);
            lstMarkers.UnitConverter = unitConverter;
            // Set checkmark in dropdown
            foreach (var item in conUnits.DropDownItems.Cast<ToolStripMenuItem>())
            {
                item.Checked = (MeasuringUnit)item.Tag == unitConverter.Unit;
            }
        }

        private void settings_Changed(object sender, EventArgs e) => updateUnitConverter();

        private void setTheme()
        {
            lstMarkers.BackColor = settings.Theme.Background;
            lstMarkers.ForeColor = settings.Theme.TickColor;
        }

        private void settings_SelectedThemeChanged(object sender, EventArgs e) => setTheme();

        private void markerCollection_MarkerCollectionChanged(object sender, MarkerCollectionEventArgs e)
        {
            if (e.AddedMarkers != null)
            {
                lstMarkers.Items.AddRange(e.AddedMarkers.Cast<object>().ToArray());
            }
            if (e.RemovedMarkers != null)
            {
                foreach (var marker in e.RemovedMarkers)
                {
                    lstMarkers.Items.Remove(marker);
                }
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            conDelete.PerformClick();
        }

        private void conDelete_Click(object sender, EventArgs e)
        {
            foreach (var marker in lstMarkers.SelectedItems.Cast<Marker>())
            {
                MarkerCollection.Markers.Remove(marker);
            }
            foreach (int index in lstMarkers.SelectedIndices)
            {
                lstMarkers.Items.RemoveAt(index);
            }
            this.Owner.Invalidate();
        }

        private void lstMarkers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Marker marker = (Marker)lstMarkers.SelectedItem;
            CustomLineForm lineForm = new CustomLineForm(marker, unitConverter, settings.Theme);
            if (lineForm.ShowDialog(this.Owner) == DialogResult.OK)
            {
                MarkerCollection.Markers.Remove(marker);
                lstMarkers.Items.Remove(marker);
                this.Owner.Invalidate();
            }
        }
    }
}
