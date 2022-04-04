using System;
using System.Drawing;
using System.Windows.Forms;
using ScreenRuler.Configuration;
using ScreenRuler.Units;

namespace ScreenRuler
{
    public partial class SetSizeForm : Form
    {
        public float RulerWidth { get; private set; }
        public float RulerHeight { get; private set; }

        private Settings settings;
        private UnitConverter converter;

        public SetSizeForm(Size rulerSize, Settings settings)
        {
            InitializeComponent();
            this.RulerWidth = rulerSize.Width;
            this.RulerHeight = rulerSize.Height;
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
            converter = UnitConverter.FromSettings(this, settings, unit);
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
            numWidth.Value = (decimal)converter.ConvertFromPixel(RulerWidth, false);
            numHeight.Value = (decimal)converter.ConvertFromPixel(RulerHeight, true);
            lblUnit1.Text = converter.UnitString;
            lblUnit2.Text = converter.UnitString;
        }

        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            this.RulerWidth = converter.ConvertToPixel((float)numWidth.Value, false);
        }

        private void numHeight_ValueChanged(object sender, EventArgs e)
        {
            this.RulerHeight = converter.ConvertToPixel((float)numHeight.Value, true);
        }

        private void butSubmit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
