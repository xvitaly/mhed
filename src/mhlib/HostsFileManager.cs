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
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with Hosts file.
    /// </summary>
    public sealed class HostsFileManager
    {
        /// <summary>
        /// Store information about current running platform.
        /// </summary>
        private readonly CurrentPlatform Platform;

        /// <summary>
        /// Get or set full Hosts file path.
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// Get or set Hosts file contents.
        /// </summary>
        public SortableBindingList<HostsFileEntry> Contents { get; private set; }

        /// <summary>
        /// Validate IP-address.
        /// </summary>
        /// <param name="SrcIPAddress">Source IP-address for validation.</param>
        /// <returns>Return True if the source IP-address is correct.</returns>
        public static bool ValidateIPAddress(string SrcIPAddress)
        {
            return IPAddress.TryParse(SrcIPAddress, out _);
        }

        /// <summary>
        /// Validate hostname.
        /// </summary>
        /// <param name="SrcHostname">Source hostname for validation.</param>
        /// <returns>Return True if the source hostname is correct.</returns>
        public static bool ValidateHostname(string SrcHostname)
        {
            return Uri.CheckHostName(SrcHostname) == UriHostNameType.Dns;
        }

        /// <summary>
        /// Clear Hosts file data object.
        /// </summary>
        private void ClearHostsContents()
        {
            Contents.Clear();
        }

        /// <summary>
        /// Add localhost entry for other than Windows operating systems.
        /// Windows since NT 6.0 (Vista) don't need it.
        /// </summary>
        private void AddLocalhostEntry()
        {
            if (Platform.OS != CurrentPlatform.OSType.Windows)
            {
                Contents.Add(new HostsFileEntry("127.0.0.1", "localhost")); // IPv4
                Contents.Add(new HostsFileEntry("::1", "localhost")); // IPv6
            }
        }

        /// <summary>
        /// Asynchronically read contents of Hosts file to the data object.
        /// </summary>
        private async Task ReadHostsFile()
        {
            using (StreamReader OpenedHosts = new StreamReader(FilePath, Encoding.Default))
            {
                while (OpenedHosts.Peek() >= 0)
                {
                    string ImpStr = StringsManager.CleanString(await OpenedHosts.ReadLineAsync());
                    if (!String.IsNullOrEmpty(ImpStr))
                    {
                        if (ImpStr[0] != '#')
                        {
                            int SpPos = ImpStr.IndexOf(" ");
                            if (SpPos != -1)
                            {
                                Contents.Add(new HostsFileEntry(ImpStr.Substring(0, SpPos), ImpStr.Remove(0, SpPos + 1)));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Asynchronically write contents of the data object to the Hosts file.
        /// </summary>
        private async Task WriteHostsFile()
        {
            using (StreamWriter CFile = new StreamWriter(FilePath, false, Encoding.Default))
            {
                if (Platform.OS == CurrentPlatform.OSType.Windows)
                {
                    await CFile.WriteLineAsync(Properties.Resources.HtTemplate);
                }

                foreach (HostsFileEntry Entry in Contents)
                {
                    if (!String.IsNullOrEmpty(Entry.IPAddress) && !String.IsNullOrEmpty(Entry.Hostname))
                    {
                        if (ValidateIPAddress(Entry.IPAddress))
                        {
                            await CFile.WriteLineAsync(String.Format("{0} {1}", Entry.IPAddress, Entry.Hostname));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Read Hosts file from disk.
        /// </summary>
        public async void Load()
        {
            await ReadHostsFile();
        }

        /// <summary>
        /// Re-read (refresh) Hosts file from disk.
        /// </summary>
        public void Refresh()
        {
            ClearHostsContents();
            Load();
        }

        /// <summary>
        /// Restore default contents of the Hosts file.
        /// </summary>
        public void Restore()
        {
            ClearHostsContents();
            AddLocalhostEntry();
        }

        /// <summary>
        /// Write Hosts file changes to disk.
        /// </summary>
        public async void Save()
        {
            await WriteHostsFile();
        }

        /// <summary>
        /// HostsFileManager class constructor.
        /// </summary>
        /// <param name="RunningPlatform">Current running platform.</param>
        public HostsFileManager(CurrentPlatform RunningPlatform)
        {
            Platform = RunningPlatform;
            FilePath = Platform.HostsFileFullPath;
            Contents = new SortableBindingList<HostsFileEntry>();
        }
    }
}
