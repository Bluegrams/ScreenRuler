using System;
using System.Windows.Forms;

namespace ScreenRuler
{
    static class Program
    {
        public const string UPDATE_URL = "https://screenruler.sourceforge.io/update.xml";

        public const string UPDATE_MODE = "portable";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RulerForm());
        }
    }
}
