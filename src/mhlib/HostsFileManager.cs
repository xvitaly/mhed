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
    public sealed class HostsFileManager
    {
        private readonly List<HostsFileEntry> HostsFileContents;
        private readonly string HostsFilePath;
        private readonly CurrentPlatform.OSType Platform;

        private void CheckHostsFileExists()
        {
            if (!File.Exists(HostsFilePath))
            {
                throw new FileNotFoundException("Hosts file not found.", HostsFilePath);
            }
        }

        private void ClearHostsContents()
        {
            HostsFileContents.Clear();
        }

        private void ReadHostsFile()
        {
            using (StreamReader OpenedHosts = new StreamReader(HostsFilePath, Encoding.Default))
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
                                HostsFileContents.Add(new HostsFileEntry(ImpStr.Substring(0, SpPos), ImpStr.Remove(0, SpPos + 1)));
                            }
                        }
                    }
                }
            }
        }

        private void WriteHostsFile()
        {
            using (StreamWriter CFile = new StreamWriter(HostsFilePath, false, Encoding.Default))
            {
                if (Platform == CurrentPlatform.OSType.Windows)
                {
                    CFile.WriteLine(StringsManager.GetTemplateFromResource(Properties.Resources.TmplFileName));
                }

                foreach (HostsFileEntry Entry in HostsFileContents)
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

        public void Refresh()
        {
            ClearHostsContents();
            ReadHostsFile();
        }

        public void Save()
        {
            WriteHostsFile();
        }

        public HostsFileManager(string FileName, CurrentPlatform.OSType OS)
        {
            HostsFilePath = FileName;
            Platform = OS;
            HostsFileContents = new List<HostsFileEntry>();
            CheckHostsFileExists();
            ReadHostsFile();
        }
    }
}
