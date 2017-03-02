/*
 * Micro Hosts Editor (standalone application).
 * 
 * Copyright 2011 - 2016 EasyCoding Team (ECTeam).
 * Copyright 2005 - 2016 EasyCoding Team.
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * EasyCoding Team's official site: https://www.easycoding.org/
 * Official project homepage: https://www.easycoding.org/projects/mhed
 * 
*/
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
