using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace mhed
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex Mtx = new Mutex(false, Properties.Resources.AppNameTkX))
            {
                if (Mtx.WaitOne(0, false))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    string[] CMDLineA = Environment.GetCommandLineArgs();
                    if (CMDLineA.Length > 2)
                    {
                        if (CMDLineA[1] == "/lang")
                        {
                            try
                            {
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo(CMDLineA[2]);
                            }
                            catch
                            {
                                MessageBox.Show(Properties.Resources.AppUnsupportedLanguage, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    Application.Run(new frmHEd());
                }
                else
                {
                    MessageBox.Show(Properties.Resources.AppAlrLaunched, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(16);
                }
            }
        }
    }
}
