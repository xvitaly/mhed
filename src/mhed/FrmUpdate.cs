/**
 * SPDX-FileCopyrightText: 2011-2025 EasyCoding Team
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
    /// Class of the Update center module.
    /// </summary>
    public partial class FrmUpdate : Form
    {
        /// <summary>
        /// Logger instance for the FrmUpdate class.
        /// </summary>
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// CurrentPlatform instance for the FrmUpdate class.
        /// </summary>
        private readonly CurrentPlatform Platform = CurrentPlatform.Create();

        /// <summary>
        /// Stores the User-Agent header for outgoing HTTP queries.
        /// </summary>
        private readonly string UserAgent;

        /// <summary>
        /// Stores full path to the application installation directory.
        /// </summary>
        private readonly string FullAppPath;

        /// <summary>
        /// Stores the full path to the local updates directory.
        /// </summary>
        private readonly string AppUpdateDir;

        /// <summary>
        /// Stores an instance of the UpdateManager class for working
        /// with updates.
        /// </summary>
        private UpdateManager UpMan;

        /// <summary>
        /// Stores the status of the currently running process.
        /// </summary>
        private bool IsCompleted = false;

        /// <summary>
        /// FrmUpdate class constructor.
        /// </summary>
        /// <param name="Agent">User-Agent header for outgoing HTTP queries.</param>
        /// <param name="AppDir">Full path to the application installation directory.</param>
        /// <param name="UpdateDir">Full path to the local updates directory.</param>
        public FrmUpdate(string Agent, string AppDir, string UpdateDir)
        {
            InitializeComponent();
            UserAgent = Agent;
            FullAppPath = AppDir;
            AppUpdateDir = UpdateDir;
        }

        /// <summary>
        /// Launches the update checker in a separate thread, waits for the
        /// result and then updates the form.
        /// </summary>
        private async Task CheckForUpdates()
        {
            try
            {
                if (await IsUpdateAvailable())
                {
                    UP_Icon.Image = Properties.Resources.IconUpdateAvailable;
                    UP_Status.Text = string.Format(AppStrings.UP_UpdateAvailable, UpMan.AppUpdateVersion);
                }
                else
                {
                    UP_Icon.Image = Properties.Resources.IconUpdateNotAvailable;
                    UP_Status.Text = AppStrings.UP_UpdateNotAvailable;
                }
                Properties.Settings.Default.LastUpdateTime = DateTime.Now;
            }
            catch (Exception Ex)
            {
                Logger.Error(Ex, DebugStrings.AppDbgExUpCheckForUpdates);
                UP_Icon.Image = Properties.Resources.IconUpdateError;
                UP_Status.Text = AppStrings.UP_UpdateCheckFailure;
            }
            IsCompleted = true;
        }

        /// <summary>
        /// Checks for the updates in a separate thread.
        /// </summary>
        /// <returns>Returns True if the updates were found.</returns>
        private async Task<bool> IsUpdateAvailable()
        {
            UpMan = await UpdateManager.Create(UserAgent);
            return UpMan.CheckAppUpdate();
        }

        /// <summary>
        /// Retries checking for updates.
        /// </summary>
        private async Task RetryUpdateCheck()
        {
            if (MessageBox.Show(AppStrings.UP_RetryUpdateCheckQuestion, Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IsCompleted = false;
                UP_Icon.Image = Properties.Resources.IconUpdateChecking;
                UP_Status.Text = AppStrings.UP_RetryUpdateCheck;
                await CheckForUpdates();
            }
        }

        /// <summary>
        /// Installs the downloaded update file.
        /// </summary>
        /// <param name="UpdateFileName">Full path to the downloaded update file.</param>
        private void StartUpdateInstaller(string UpdateFileName)
        {
            // Checking if the application installation directory is writable...
            if (FileManager.IsDirectoryWritable(FullAppPath))
            {
                // Running the installer with current access rights...
                Platform.StartRegularProcess(UpdateFileName);
            }
            else
            {
                // Running the installer with UAC access rights elevation...
                Platform.StartElevatedProcess(UpdateFileName);
            }
        }

        /// <summary>
        /// Downloads and installs the standalone update.
        /// </summary>
        /// <returns>The result of the operation.</returns>
        private bool InstallBinaryUpdate()
        {
            // Setting the default value for the result...
            bool Result = false;

            // Generating full path to the update file...
            string UpdateFileName = UpdateManager.GenerateUpdateFileName(Path.Combine(AppUpdateDir, Path.GetFileName(UpMan.AppUpdateURL)));

            // Downloading the update from the server...
            GuiHelpers.FormShowDownloader(UpMan.AppUpdateURL, UpdateFileName);

            // Checking if the downloaded file is exists...
            if (File.Exists(UpdateFileName))
            {
                // Checking the downloaded file hash...
                if (UpMan.CheckAppHash(FileManager.CalculateFileSHA512(UpdateFileName)))
                {
                    // Showing a message about the successful download...
                    MessageBox.Show(AppStrings.UP_DownloadSuccessful, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Installing the standalone update...
                    try
                    {
                        StartUpdateInstaller(UpdateFileName);
                        Result = true;
                    }
                    catch (Exception Ex)
                    {
                        Logger.Error(Ex, DebugStrings.AppDbgExUpInstallBinaryUpdate);
                        MessageBox.Show(AppStrings.UP_UpdateFailure, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Hash missmatch. Writing to the log...
                    Logger.Error(DebugStrings.AppDbgUpHashMissmatch);

                    // Removing the downloaded file...
                    try
                    {
                        File.Delete(UpdateFileName);
                    }
                    catch (Exception Ex)
                    {
                        Logger.Warn(Ex, DebugStrings.AppDbgExUpDeleteFile);
                    }

                    // Showing a message about the hash missmatch...
                    MessageBox.Show(AppStrings.UP_HashMissmatch, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Writing to the log and showing an error message about the download failure...
                Logger.Error(DebugStrings.AppDbgUpDownloadFailure);
                MessageBox.Show(AppStrings.UP_DownloadFailure, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Returning result...
            return Result;
        }

        /// <summary>
        /// Installs an update or displays an update notification depending on
        /// the currently running platform.
        /// </summary>
        private void InstallUpdate()
        {
            if (Platform.AutoUpdateSupported && !Properties.Settings.Default.IsPortable)
            {
                if (InstallBinaryUpdate())
                {
                    Platform.Exit(ReturnCodes.AppUpdatePending);
                }
            }
            else
            {
                if (MessageBox.Show(string.Format(AppStrings.UP_OtherPlatform, UpMan.AppUpdateVersion), Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Platform.OpenWebPage(UpMan.AppUpdateInfo);
                }
            }
        }

        /// <summary>
        /// Checks whether the update is available and attempts to install it.
        /// </summary>
        private void CheckAndInstallUpdate()
        {
            if (UpMan.CheckAppUpdate())
            {
                InstallUpdate();
            }
            else
            {
                MessageBox.Show(AppStrings.UP_LatestInstalled, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// "Form create" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private async void FrmUpdate_Load(object sender, EventArgs e)
        {
            await CheckForUpdates();
        }

        /// <summary>
        /// "Install update" button click event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private async void UP_Status_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsCompleted && (UpMan == null))
                {
                    await RetryUpdateCheck();
                }
                else if (IsCompleted)
                {
                    CheckAndInstallUpdate();
                }
                else
                {
                    MessageBox.Show(AppStrings.UP_WorkInProgress, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                Logger.Error(Ex, DebugStrings.AppDbgExUpInstallUpdate);
                MessageBox.Show(AppStrings.UP_InstallUpdateError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// "Close" button click event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void UP_Close_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
