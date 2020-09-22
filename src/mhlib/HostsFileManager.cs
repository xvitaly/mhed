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
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with Hosts file.
    /// </summary>
    public sealed class HostsFileManager
    {
        /// <summary>
        /// Get or set full Hosts file path.
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// Store information about current running platform.
        /// </summary>
        private readonly CurrentPlatform.OSType Platform;

        /// <summary>
        /// Get or set Hosts file contents.
        /// </summary>
        public List<HostsFileEntry> Contents { get; private set; }

        /// <summary>
        /// Get or set current modification state of Hosts file
        /// data object.
        /// </summary>
        public bool IsModified { get; private set; }

        /// <summary>
        /// Reset current modification state of Hosts file
        /// data object.
        /// </summary>
        private void ResetState()
        {
            IsModified = false;
        }

        /// <summary>
        /// Clear Hosts file data object.
        /// </summary>
        private void ClearHostsContents()
        {
            Contents.Clear();
        }

        /// <summary>
        /// Read contents of Hosts file to the data object.
        /// </summary>
        private void ReadHostsFile()
        {
            using (StreamReader OpenedHosts = new StreamReader(FilePath, Encoding.Default))
            {
                while (OpenedHosts.Peek() >= 0)
                {
                    string ImpStr = StringsManager.CleanString(OpenedHosts.ReadLine());
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
        /// Write contents of the data object to the Hosts file.
        /// </summary>
        private void WriteHostsFile()
        {
            using (StreamWriter CFile = new StreamWriter(FilePath, false, Encoding.Default))
            {
                if (Platform == CurrentPlatform.OSType.Windows)
                {
                    CFile.WriteLine(Properties.Resources.HtTemplate);
                }

                foreach (HostsFileEntry Entry in Contents)
                {
                    if (!String.IsNullOrEmpty(Entry.IPAddress) && !String.IsNullOrEmpty(Entry.Hostname))
                    {
                        if (IPAddress.TryParse(Entry.IPAddress, out IPAddress IPAddr))
                        {
                            CFile.WriteLine("{0} {1}", IPAddr, Entry.Hostname);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Read Hosts file from disk.
        /// </summary>
        public void Load()
        {
            ReadHostsFile();
            ResetState();
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
        /// Write Hosts file changes to disk.
        /// </summary>
        public void Save()
        {
            if (IsModified)
            {
                WriteHostsFile();
                ResetState();
            }
        }

        /// <summary>
        /// HostsFileManager class constructor.
        /// </summary>
        /// <param name="OS">Current running platform.</param>
        /// <param name="AutoLoad">Read Hosts file automatically.</param>
        public HostsFileManager(CurrentPlatform.OSType OS, bool AutoLoad = false)
        {
            FilePath = FileManager.GetHostsFileFullPath(OS);
            Platform = OS;
            Contents = new List<HostsFileEntry>();
            if (AutoLoad) Load();
        }
    }
}
