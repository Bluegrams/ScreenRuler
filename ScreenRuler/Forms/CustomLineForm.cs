using System;
using System.Windows.Forms;
using ScreenRuler.Colors;
using ScreenRuler.Units;

namespace ScreenRuler
{
    public partial class CustomLineForm : Form
    {
        public CustomLineForm(Marker marker, UnitConverter converter, Theme theme)
        {
            InitializeComponent();
            this.BackColor = theme.Background;
            lblLine.ForeColor = theme.TickColor;
            butDelete.ForeColor = theme.TickColor;
            butCancel.ForeColor = theme.TickColor;
            lblLine.Text = String.Format("{0} px\n{1:N2} {2}", marker.Value,
                converter.ConvertFromPixel(marker), converter.UnitString);
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
