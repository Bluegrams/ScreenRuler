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
        private string HelpFileLocation { get { return String.Format(@"Help\Help.{0}.html", lang); } }

        public HelpForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            // Choose right help file.
            var current = CultureInfo.CurrentUICulture;
            if (Bluegrams.Application.AppInfo.SupportedCultures
                    .Where(c => c.TwoLetterISOLanguageName == current.TwoLetterISOLanguageName)
                    .Count() > 0)
                lang = current.TwoLetterISOLanguageName;
            else lang = "en";
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

        private void HelpForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
