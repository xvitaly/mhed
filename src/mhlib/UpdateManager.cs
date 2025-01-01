/**
 * SPDX-FileCopyrightText: 2011-2025 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with application updates.
    /// </summary>
    public sealed class UpdateManager
    {
        /// <summary>
        /// Get or set the latest version of the application.
        /// </summary>
        public Version AppUpdateVersion { get; private set; }

        /// <summary>
        /// Get or set the application changelog page URL.
        /// </summary>
        public string AppUpdateInfo { get; private set; }

        /// <summary>
        /// Get or set the application download URL.
        /// </summary>
        public string AppUpdateURL { get; private set; }

        /// <summary>
        /// Get or set hash of the update executable.
        /// </summary>
        public string AppUpdateHash { get; private set; }

        /// <summary>
        /// Store HTTP UserAgent header, used during updates check.
        /// </summary>
        private readonly string UserAgent;

        /// <summary>
        /// Store downloaded from server XML file with information
        /// about the latest updates.
        /// </summary>
        private string UpdateXML;

        /// <summary>
        /// Asyncronically download XML file with imformation about latest updates
        /// from the server and store it in the field.
        /// </summary>
        private async Task DownloadXML()
        {
            using (WebClient Downloader = new WebClient())
            {
                Downloader.Headers.Add("User-Agent", UserAgent);
                UpdateXML = await Downloader.DownloadStringTaskAsync(Properties.Resources.UpdateDatabaseURL);
            }
        }

        /// <summary>
        /// Parse downloaded XML file with information about
        /// the latest updates and fill properties.
        /// </summary>
        private void ParseXML()
        {
            // Loading XML from variable...
            XmlDocument XMLD = new XmlDocument();
            XMLD.LoadXml(UpdateXML);

            // Extracting information about application update...
            XmlNode AppNode = XMLD.SelectSingleNode("Updates/Application");
            AppUpdateVersion = new Version(AppNode.SelectSingleNode("Version").InnerText);
            AppUpdateInfo = AppNode.SelectSingleNode("Info").InnerText;
            AppUpdateURL = AppNode.SelectSingleNode("URL").InnerText;
            AppUpdateHash = AppNode.SelectSingleNode("Hash2").InnerText;
        }

        /// <summary>
        /// Check if the application need to be updated.
        /// </summary>
        /// <returns>Return True if application update available.</returns>
        public bool CheckAppUpdate()
        {
            return AppUpdateVersion > CurrentApp.AppVersion;
        }

        /// <summary>
        /// Check hash of the downloaded application update.
        /// </summary>
        /// <param name="Hash">Hash of downloaded file.</param>
        /// <returns>Returns True if hashes are equal.</returns>
        public bool CheckAppHash(string Hash)
        {
            return AppUpdateHash == Hash;
        }

        /// <summary>
        /// Asyncronically fetch and parse XML file with updates information.
        /// </summary>
        private async Task CheckForUpdates()
        {
            await Task.Run(() => DownloadXML());
            await Task.Run(() => ParseXML());
        }

        /// <summary>
        /// Get local application update file name.
        /// </summary>
        /// <param name="Url">Download URL.</param>
        /// <returns>Local file name.</returns>
        public static string GenerateUpdateFileName(string Url)
        {
            return Path.HasExtension(Url) ? Url : Path.ChangeExtension(Url, "exe");
        }

        /// <summary>
        /// Create an instance of the UpdateManager class. Factory method.
        /// </summary>
        /// <param name="UA">User-Agent header for outgoing HTTP queries.</param>
        /// <returns>Return an instance of the UpdateManager class.</returns>
        public static async Task<UpdateManager> Create(string UA)
        {
            UpdateManager UpdaterInstance = new UpdateManager(UA);
            await UpdaterInstance.CheckForUpdates();
            return UpdaterInstance;
        }

        /// <summary>
        /// UpdateManager class constructor. Cannot be called directly.
        /// </summary>
        /// <param name="UA">User-Agent header for outgoing HTTP queries.</param>
        private UpdateManager(string UA)
        {
            UserAgent = UA;
        }
    }
}
