using ScreenRuler.Units;
using System;
using System.Windows.Forms;

namespace ScreenRuler
{
    public partial class SetSizeForm : Form
    {
        /// <summary>
        /// The ruler length in pixels.
        /// </summary>
        public int RulerLength;

        private Settings settings;
        private UnitConverter converter;

        public SetSizeForm(int rulerLength, Settings settings)
        {
            InitializeComponent();
            RulerLength = rulerLength;
            this.settings = settings;
            this.converter = new UnitConverter(settings.MeasuringUnit, settings.MonitorDpi);
        }

        private void SetSizeForm_Load(object sender, EventArgs e)
        {
            foreach (Enum item in Enum.GetValues(typeof(MeasuringUnit)))
            {
                comUnits.Items.Add(item.GetDescription());
            }
            comUnits.SelectedIndex = (int)settings.MeasuringUnit;
            updateText();
        }

        private void comUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            var unit = (MeasuringUnit)comUnits.SelectedIndex;
            converter = new UnitConverter(unit, settings.MonitorDpi);
            updateText();
        }

        /// <summary>
        /// Updates the ruler length and unit symbol to the currently chosen unit.
        /// </summary>
        private void updateText()
        {
            txtLength.Text = converter.ConvertFromPixel(RulerLength).ToString();
            lblUnitString.Text = converter.UnitString;
        }

        private void butSubmit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            float result;
            if (float.TryParse(txtLength.Text, out result))
            {
                // Convert the specified length back to pixels.
                this.RulerLength = (int)Math.Round(converter.ConvertToPixel(result));
            }
            this.Close();
        }
    }
}
