using System;
using System.Windows.Forms;

namespace ScreenRuler.Configuration.Monitor
{
    public partial class MonitorIdForm : Form
    {
        public MonitorIdForm(string monitorId, string monitorName = null)
        {
            InitializeComponent();
            lblNum.Text = monitorId;
            lblName.Text = monitorName;
        }
    }
}
