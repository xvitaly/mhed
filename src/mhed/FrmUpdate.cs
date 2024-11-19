/**
 * SPDX-FileCopyrightText: 2011-2024 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using mhed.lib;

namespace mhed.gui
{
    /// <summary>
    /// Class of the update checker window.
    /// </summary>
    public partial class FrmUpdate : Form
    {
        /// <summary>
        /// Logger instance for FrmUpdate class.
        /// </summary>
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// CurrentPlatform instance for FrmMute class.
        /// </summary>
        private readonly CurrentPlatform Platform = CurrentPlatform.Create();

        /// <summary>
        /// Store User-Agent header for outgoing HTTP queries.
        /// </summary>
        private readonly string UserAgent;

        /// <summary>
        /// Store full path to the local updates directory.
        /// </summary>
        private readonly string AppUpdateDir;

        /// <summary>
        /// Store app's installation directory.
        /// </summary>
        private readonly string FullAppPath;

        /// <summary>
        /// Store an instance of UpdateManager class for working
        /// with updates.
        /// </summary>
        private UpdateManager UpMan;

        /// <summary>
        /// Store current state of the async tasks.
        /// </summary>
        private bool IsCompleted = false;

        /// <summary>
        /// FrmUpdate class constructor.
        /// </summary>
        /// <param name="UA">User-Agent header for outgoing HTTP queries.</param>
        /// <param name="A">App's installation directory.</param>
        /// <param name="U">App's local updates directory.</param>
        public FrmUpdate(string UA, string A, string U)
        {
            InitializeComponent();
            UserAgent = UA;
            FullAppPath = A;
            AppUpdateDir = U;
        }

        /// <summary>
        /// Launch a program update checker in a separate thread, waits for the
        /// result and returns a message if found.
        /// </summary>
        private async Task CheckForUpdates()
        {
            try
            {
                if (await IsUpdatesAvailable(UserAgent))
                {
                    UpdAppImg.Image = Properties.Resources.IconUpdateAvailable;
                    UpdAppStatus.Text = string.Format(AppStrings.AHE_UpdateAvailable, UpMan.AppUpdateVersion);
                }
                else
                {
                    UpdAppImg.Image = Properties.Resources.IconUpdateNotAvailable;
                    UpdAppStatus.Text = AppStrings.AHE_UpdateNotAvailable;
                }
                Properties.Settings.Default.LastUpdateTime = DateTime.Now;
            }
            catch (Exception Ex)
            {
                Logger.Error(Ex, DebugStrings.AppDbgExUpdChk);
                UpdAppImg.Image = Properties.Resources.IconUpdateError;
                UpdAppStatus.Text = AppStrings.AHE_UpdateCheckFailure;
            }
            IsCompleted = true;
        }

        /// <summary>
        /// Check for application updates in a separate thread.
        /// </summary>
        /// <param name="UA">User-Agent header for outgoing HTTP queries.</param>
        /// <returns>Returns True if updates were found.</returns>
        private async Task<bool> IsUpdatesAvailable(string UA)
        {
            UpMan = await UpdateManager.Create(UA);
            return UpMan.CheckAppUpdate();
        }

        /// <summary>
        /// Install standalone update.
        /// </summary>
        /// <param name="UpdateURL">Full download URL.</param>
        /// <returns>Result of operation.</returns>
        private bool InstallBinaryUpdate(string UpdateURL)
        {
            // Setting default value for result...
            bool Result = false;

            // Generating full paths to files...
            string UpdateFileName = UpdateManager.GenerateUpdateFileName(Path.Combine(AppUpdateDir, Path.GetFileName(UpdateURL)));

            // Downloading update from server...
            GuiHelpers.FormShowDownloader(UpMan.AppUpdateURL, UpdateFileName);

            // Checking if downloaded file exists...
            if (File.Exists(UpdateFileName))
            {
                // Checking hashes...
                if (UpMan.CheckAppHash(FileManager.CalculateFileSHA512(UpdateFileName)))
                {
                    // Showing message about successful download...
                    MessageBox.Show(AppStrings.AHE_UpdateSuccessful, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Installing standalone update...
                    try
                    {
                        // Checking if app's installation directory is writable...
                        if (FileManager.IsDirectoryWritable(FullAppPath))
                        {
                            // Running installer with current access rights...
                            Platform.StartRegularProcess(UpdateFileName);
                        }
                        else
                        {
                            // Running installer with UAC access rights elevation...
                            Platform.StartElevatedProcess(UpdateFileName);
                        }
                        Result = true;
                    }
                    catch (Exception Ex)
                    {
                        Logger.Error(Ex, DebugStrings.AppDbgExUpdBinInst);
                        MessageBox.Show(AppStrings.AHE_UpdateFailure, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Hash missmatch. File was damaged. Removing it...
                    try
                    {
                        File.Delete(UpdateFileName);
                    }
                    catch (Exception Ex)
                    {
                        Logger.Warn(Ex, DebugStrings.AppDbgExUpdBinRem);
                    }

                    // Showing message about hash missmatch...
                    MessageBox.Show(AppStrings.AHE_UpdateHashFailure, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Showing error about update failure...
                MessageBox.Show(AppStrings.AHE_UpdateFailure, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Returning result...
            return Result;
        }

        /// <summary>
        /// "Form create" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private async void FrmUpdate_Load(object sender, EventArgs e)
        {
            // Starting checking for updates...
            await CheckForUpdates();
        }

        /// <summary>
        /// "Form close" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FrmUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing) && !IsCompleted;
        }

        /// <summary>
        /// "Install app update" button click event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void UpdAppStatus_Click(object sender, EventArgs e)
        {
            if (IsCompleted)
            {
                if (UpMan.CheckAppUpdate())
                {
                    if (Platform.AutoUpdateSupported && !Properties.Settings.Default.IsPortable)
                    {
                        if (InstallBinaryUpdate(UpMan.AppUpdateURL))
                        {
                            Platform.Exit(ReturnCodes.AppUpdatePending);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show(string.Format(AppStrings.AHE_UpdateOtherPlatform, UpMan.AppUpdateVersion), Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Platform.OpenWebPage(UpMan.AppUpdateInfo);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(AppStrings.AHE_UpdateLatestInstalled, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(AppStrings.AHE_WrkInProgress, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// "Close" button click event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void UpdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
