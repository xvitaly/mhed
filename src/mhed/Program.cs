/*
 * This file is a part of Micro Hosts Editor. For more information
 * visit official site: https://www.easycoding.org/projects/mhed
 *
 * Copyright (c) 2011 - 2021 EasyCoding Team (ECTeam).
 * Copyright (c) 2005 - 2021 EasyCoding Team.
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
    internal static class Program
    {
        /// <summary>
        /// Import settings from the previous version of the application.
        /// </summary>
        private static void ImportSettings()
        {
            try
            {
                if (Properties.Settings.Default.CallUpgrade)
                {
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.CallUpgrade = false;
                }
            }
            catch
            {
                Properties.Settings.Default.CallUpgrade = false;
                MessageBox.Show(AppStrings.AHE_ImportSettingsError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Check if required library version is equal with current library version.
        /// </summary>
        private static void CheckLibrary()
        {
            if (!LibraryManager.CheckLibraryVersion())
            {
                MessageBox.Show(AppStrings.AHE_LibraryVersionMissmatch, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(ReturnCodes.CoreLibVersionMissmatch);
            }
        }

        /// <summary>
        /// Initialize and show the main form of the application.
        /// </summary>
        private static void ShowMainForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMhed());
        }

        /// <summary>
        /// Show message about already running application and exit.
        /// </summary>
        private static void HandleRunning()
        {
            MessageBox.Show(AppStrings.AHE_AlreadyRunning, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(ReturnCodes.AppAlreadyRunning);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            using (Mutex Mtx = new Mutex(false, StringsManager.GetMutexName(Properties.Resources.AppInternalName)))
            {
                if (Mtx.WaitOne(0, false))
                {
                    ImportSettings();
                    CheckLibrary();
                    ShowMainForm();
                }
                else
                {
                    HandleRunning();
                }
            }
        }
    }
}
