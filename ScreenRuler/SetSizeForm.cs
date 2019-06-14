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
            setConverter(settings.MeasuringUnit);
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

        private void setConverter(MeasuringUnit unit)
        {
            var screenRect = Screen.FromControl(this).Bounds;
            var screenSize = settings.Vertical ? screenRect.Height : screenRect.Width;
            converter = new UnitConverter(unit, screenSize, settings.MonitorDpi);
        }

        private void comUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            var unit = (MeasuringUnit)comUnits.SelectedIndex;
            setConverter(unit);
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
