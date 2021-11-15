/**
 * SPDX-FileCopyrightText: 2011-2021 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
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
