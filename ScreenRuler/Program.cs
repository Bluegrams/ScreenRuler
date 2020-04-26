using System;
using System.Windows.Forms;
using Bluegrams.Application;

namespace ScreenRuler
{
    static class Program
    {
        public const string UPDATE_URL = "https://screenruler.sourceforge.io/update.xml";

        public const string UPDATE_MODE = "portable";

        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RulerForm());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Default.Log("An unhandled exception caused the application to terminate unexpectedly.",
                (Exception)e.ExceptionObject);
        }
    }
}
