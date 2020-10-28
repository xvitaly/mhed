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
using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace mhed.lib
{
    public sealed class UpdateManager
    {
        /// <summary>
        /// Get or set the latest version of the application.
        /// </summary>
        public Version AppUpdateVersion { get; private set; }

        /// <summary>
        /// Get or set the application download URL.
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
            return AppUpdateVersion > Assembly.GetCallingAssembly().GetName().Version;
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
            await DownloadXML();
            ParseXML();
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
