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
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with Microsoft Windows specific functions.
    /// </summary>
    public class PlatformWindows : CurrentPlatform
    {
        /// <summary>
        /// Open the specified text file in default (or overrided in application's
        /// settings (only on Windows platform)) text editor.
        /// </summary>
        /// <param name="FileName">Full path to text file.</param>
        /// <param name="EditorBin">External text editor (Windows only).</param>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void OpenTextEditor(string FileName, string EditorBin)
        {
            Process.Start(EditorBin, AddQuotesToPath(FileName));
        }

        /// <summary>
        /// Show the specified file in default file manager.
        /// </summary>
        /// <param name="FileName">Full path to file.</param>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void OpenExplorer(string FileName)
        {
            Process.Start(Properties.Resources.ShBinWin, String.Format("{0} \"{1}\"", Properties.Resources.ShParamWin, FileName));
        }

        /// <summary>
        /// Start the required application from administrator.
        /// </summary>
        /// <param name="FileName">Full path to the executable.</param>
        /// <returns>PID of the newly created process.</returns>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override int StartElevatedProcess(string FileName)
        {
            // Setting advanced properties...
            ProcessStartInfo ST = new ProcessStartInfo()
            {
                FileName = FileName,
                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Normal,
                UseShellExecute = true
            };

            // Starting process...
            Process NewProcess = Process.Start(ST);

            // Returning PID of created process...
            return NewProcess.Id;
        }

        /// <summary>
        /// Get platform-dependent suffix for HTTP_USER_AGENT header.
        /// </summary>
        public override string UASuffix => Properties.Resources.AppUASuffixWin;

        /// <summary>
        /// Get current operating system ID.
        /// </summary>
        public override OSType OS => OSType.Windows;

        /// <summary>
        /// Return platform-dependent location of the Hosts file.
        /// </summary>
        public override string HostsFileLocation
        {
            get
            {
                string HostsDirectory;

                try
                {
                    using (RegistryKey ResKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", false))
                    {
                        HostsDirectory = (string)ResKey.GetValue("DataBasePath");
                    }
                }
                catch
                {
                    HostsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "drivers", "etc");
                }

                return HostsDirectory;
            }
        }
    }
}
