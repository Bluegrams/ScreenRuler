using System;
using System.Windows.Forms;
using ScreenRuler.Colors;
using ScreenRuler.Units;

namespace ScreenRuler
{
    public partial class CustomLineForm : Form
    {
        public CustomLineForm(int line, UnitConverter converter, Theme theme)
        {
            InitializeComponent();
            this.BackColor = theme.Background;
            lblLine.ForeColor = theme.TickColor;
            butDelete.ForeColor = theme.TickColor;
            butCancel.ForeColor = theme.TickColor;
            lblLine.Text = String.Format("{0} px\n{1:N2} {2}", line,
                converter.ConvertFromPixel(line), converter.UnitString);
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
