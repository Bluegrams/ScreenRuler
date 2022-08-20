using System;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;

namespace ScreenRuler
{
    public partial class HelpForm : Form
    {
        private string lang;
        private string HelpFileLocation { get { return Path.Combine(Application.StartupPath, $@"Help\Help.{lang}.html"); } }

        public HelpForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            // Set lang and check if there is a help file for it.
            // If not, fall back to English.
            lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            if (!File.Exists(HelpFileLocation))
                lang = "en";
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.DocumentText = File.ReadAllText(HelpFileLocation);
            }
            catch
            {
                webBrowser1.DocumentText = String.Format("<html>Error: Help document not found at {0}.</html>",
                                                    HelpFileLocation);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}
