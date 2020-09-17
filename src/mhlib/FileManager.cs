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
using Microsoft.Win32;
using System;
using System.IO;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with files and directories.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Return platform-dependent path to Hosts file.
        /// </summary>
        /// <param name="OS">Running platform ID.</param>
        /// <returns>Full path to Hosts file.</returns>
        public static string GetHostsFileFullPath(CurrentPlatform.OSType OS)
        {
            // Creating an empty string...
            string Result = String.Empty;

            // Checking of running platform...
            if (OS == CurrentPlatform.OSType.Windows)
            {
                try
                {
                    // Getting full Hosts path from Windows Registry (can be overrided by some applications)...
                    RegistryKey ResKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", false);
                    if (ResKey != null) { Result = (string)ResKey.GetValue("DataBasePath"); }

                    // Checking result. If empty, using generic...
                    if (String.IsNullOrWhiteSpace(Result)) { Result = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "drivers", "etc"); }
                }
                catch
                {
                    // Exception occured. Generating Hosts file path using generic patterns...
                    Result = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "drivers", "etc");
                }
            }
            else
            {
                // Unix detected, returning standard POSIX path...
                Result = "/etc";
            }

            // Generating full file name...
            Result = Path.Combine(Result, "hosts");

            // Returning result...
            return Result;
        }
    }
}
