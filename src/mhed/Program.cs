/*
 * This file is a part of Micro Hosts Editor. For more information
 * visit official site: https://www.easycoding.org/projects/mhed
 *
 * Copyright (c) 2011 - 2020 EasyCoding Team (ECTeam).
 * Copyright (c) 2005 - 2020 EasyCoding Team.
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
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
*/
using mhed.lib;
using System;
using System.Threading;
using System.Windows.Forms;

namespace mhed.gui
{
    /// <summary>
    /// The main class of the application.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Creating global mutex...
            using (Mutex Mtx = new Mutex(false, Properties.Resources.AppName))
            {
                // Locking mutex...
                if (Mtx.WaitOne(0, false))
                {
                    // Checking of core library version...
                    if (LibraryManager.CheckLibraryVersion())
                    {
                        // Enabling application visual styles...
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                        // Starting main form...
                        Application.Run(new FrmMhed());
                    }
                    else
                    {
                        // Version missmatch. Terminating...
                        MessageBox.Show(AppStrings.AppLibVersionMissmatch, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(ReturnCodes.CoreLibVersionMissmatch);
                    }
                    
                }
                else
                {
                    // Application is already running. Terminating...
                    MessageBox.Show(AppStrings.AppAlrLaunched, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(ReturnCodes.AppAlreadyRunning);
                }
            }
        }
    }
}
