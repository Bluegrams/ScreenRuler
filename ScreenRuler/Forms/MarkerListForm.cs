using ScreenRuler.Units;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ScreenRuler
{
    public partial class MarkerListForm : Form
    {
        private Settings settings;

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
            markerCollection.MarkerCollectionChanged += markerCollection_MarkerCollectionChanged;
            settings.SelectedThemeChanged += settings_SelectedThemeChanged;
        }

        private void setTheme()
        {
            lstMarkers.BackColor = settings.Theme.Background;
            lstMarkers.ForeColor = settings.Theme.TickColor;
        }
        private UnitConverter getUnitConverter()
        {
            var screenSize = Screen.FromControl(this.Owner).Bounds.Size;
            return new UnitConverter(settings.MeasuringUnit, screenSize, settings.MonitorDpi);
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
            CustomLineForm lineForm = new CustomLineForm(marker, getUnitConverter(), settings.Theme);
            if (lineForm.ShowDialog(this.Owner) == DialogResult.OK)
            {
                MarkerCollection.Markers.Remove(marker);
                lstMarkers.Items.Remove(marker);
                this.Owner.Invalidate();
            }
        }
    }
}
