/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;
using NLog;

namespace mhed.gui
{
    /// <summary>
    /// Class of Internet downloader window.
    /// </summary>
    public partial class FrmDnWrk : Form
    {
        /// <summary>
        /// Logger instance for FrmDnWrk class.
        /// </summary>
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Stores URL of download.
        /// </summary>
        private readonly string RemoteURI;

        /// <summary>
        /// Stores full path of local destination file.
        /// </summary>
        private readonly string LocalFile;

        /// <summary>
        /// Stores full path to the destination directory.
        /// </summary>
        private readonly string LocalDirectory;

        /// <summary>
        /// Stores status of currently running process.
        /// </summary>
        private bool IsRunning = true;

        /// <summary>
        /// FrmDnWrk class constructor.
        /// </summary>
        /// <param name="R">Download URL.</param>
        /// <param name="L">Full path to destination file.</param>
        public FrmDnWrk(string R, string L)
        {
            InitializeComponent();
            RemoteURI = R;
            LocalFile = L;
            LocalDirectory = Path.GetDirectoryName(L);
        }

        /// <summary>
        /// Reports progress to progress bar on form.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void DownloaderProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                DN_PrgBr.Value = e.ProgressPercentage;
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExDnProgressChanged);
            }
        }

        /// <summary>
        /// Finalizes download sequence.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Completion arguments and results.</param>
        private void DownloaderCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Download task completed. Checking for errors...
            if (e.Error != null)
            {
                Logger.Error(e.Error, DebugStrings.AppDbgExDnWrkDownloadFile, RemoteURI, LocalFile);
            }

            // Performing additional actions...
            DownloaderVerifyResult();
            DownloaderFinalize();
        }

        /// <summary>
        /// Checks if the destination directory exists. If not - creates it.
        /// </summary>
        private void DownloaderCheckLocalDirectory()
        {
            if (!Directory.Exists(LocalDirectory))
            {
                Directory.CreateDirectory(LocalDirectory);
            }
        }

        /// <summary>
        /// Checks if the destination file exists. If so - deletes it.
        /// </summary>
        private void DownloaderCheckLocalFile()
        {
            if (File.Exists(LocalFile))
            {
                File.Delete(LocalFile);
            }
        }

        /// <summary>
        /// Performs preliminary checks.
        /// </summary>
        private void DownloaderRunChecks()
        {
            DownloaderCheckLocalDirectory();
            DownloaderCheckLocalFile();
        }

        /// <summary>
        /// Asynchronously downloads file from the Internet in a separate thread.
        /// </summary>
        private void DownloaderStart()
        {
            try
            {
                DownloaderRunChecks();
                using (WebClient FileDownloader = new WebClient())
                {
                    FileDownloader.Headers.Add("User-Agent", Properties.Resources.AppDownloadUserAgent);
                    FileDownloader.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloaderCompleted);
                    FileDownloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloaderProgressChanged);
                    FileDownloader.DownloadFileAsync(new Uri(RemoteURI), LocalFile);
                }
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExDnWrkTask, RemoteURI, LocalFile);
            }
        }

        /// <summary>
        /// Checks if the downloaded file exists and is not empty.
        /// </summary>
        private void DownloaderVerifyResult()
        {
            try
            {
                FileInfo Fi = new FileInfo(LocalFile);
                if (Fi.Exists && Fi.Length == 0)
                {
                    Fi.Delete();
                }
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExDnResultVerify, LocalFile);
            }
        }

        /// <summary>
        /// Performs finalizing actions and closes the form.
        /// </summary>
        private void DownloaderFinalize()
        {
            IsRunning = false;
            Close();
        }

        /// <summary>
        /// "Form create" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FrmDnWrk_Load(object sender, EventArgs e)
        {
            DownloaderStart();
        }

        /// <summary>
        /// "Form close" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FrmDnWrk_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing) && IsRunning;
        }
    }
}
