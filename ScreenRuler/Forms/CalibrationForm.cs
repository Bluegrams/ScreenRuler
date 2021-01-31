using System;
using System.Diagnostics;
using System.Windows.Forms;
using ScreenRuler.Units;

namespace ScreenRuler
{
    public partial class CalibrationForm : Form
    {
        private RulerPainter painter;
        private Settings previewSettings;

        public float MonitorDpi => previewSettings.MonitorDpi;
        public int MonitorScaling => previewSettings.MonitorScaling;

        public CalibrationForm(Settings settings)
        {
            InitializeComponent();
            painter = new RulerPainter(panPreview);
            // we only copy relevant settings
            previewSettings = new Settings()
            {
                MeasuringUnit = settings.MeasuringUnit,
                MonitorDpi = settings.MonitorDpi,
                MonitorScaling = settings.MonitorScaling
            };
        }

        private void CalibrationForm_Load(object sender, EventArgs e)
        {
            // Set initial states
            numDPI.Value = (decimal)previewSettings.MonitorDpi;
            numScaling.Value = previewSettings.MonitorScaling;
            foreach (Enum item in Enum.GetValues(typeof(MeasuringUnit)))
            {
                comUnits.Items.Add(item.GetDescription());
            }
            comUnits.SelectedIndex = (int)previewSettings.MeasuringUnit;
        }

        private void panPreview_Paint(object sender, PaintEventArgs e)
        {
            painter.Update(e.Graphics, previewSettings, FormResizeMode.Horizontal);
            painter.PaintRuler();
        }

        private void numDPI_ValueChanged(object sender, EventArgs e)
        {
            previewSettings.MonitorDpi = (float)Math.Round(numDPI.Value, 2);
            panPreview.Invalidate();
        }

        private void numScaling_ValueChanged(object sender, EventArgs e)
        {
            previewSettings.MonitorScaling = (int)numScaling.Value;
            panPreview.Invalidate();
        }

        private void comUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            previewSettings.MeasuringUnit = (MeasuringUnit)comUnits.SelectedIndex;
            panPreview.Invalidate();
        }

        private void butSubmit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lnkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://sourceforge.net/p/screenruler/discussion/howto/thread/22319514a3/");
        }
    }
}
