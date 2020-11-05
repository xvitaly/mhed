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
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Security.Principal;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with processes.
    /// </summary>
    public static class ProcessManager
    {
        /// <summary>
        /// Check if the current user has local adminstrators access rights
        /// (permissions).
        /// </summary>
        /// <returns>Returns True if the current user has admin rights.</returns>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static bool IsCurrentUserAdmin()
        {
            bool Result;
            try
            {
                // Checking access rights of currently logged-in user...
                WindowsPrincipal UP = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                // Checking if current user is in Administrators group...
                Result = UP.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                // Exception detected. User has no admin rights.
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// Run an external executable with UAC-elevated access rights
        /// (run as admininstrator).
        /// </summary>
        /// <param name="FileName">Full path to the executable.</param>
        /// <returns>Return PID of newly created process.</returns>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static int StartWithUAC(string FileName)
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
        /// Run an external executable with Polkit-elevated access rights
        /// (run as admininstrator).
        /// </summary>
        /// <param name="FileName">Full path to the executable.</param>
        /// <returns>Return PID of newly created process.</returns>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static int StartWithPolkit(string FileName)
        {
            // Setting advanced properties...
            ProcessStartInfo ST = new ProcessStartInfo()
            {
                FileName = FileName,
                Verb = "pkexec",
                WindowStyle = ProcessWindowStyle.Normal,
                UseShellExecute = true
            };

            // Starting process...
            Process NewProcess = Process.Start(ST);

            // Returning PID of created process...
            return NewProcess.Id;
        }

        /// <summary>
        /// Open the specified URL in default Web browser.
        /// </summary>
        /// <param name="URI">Full URL.</param>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static void OpenWebPage(string URI)
        {
            Process.Start(URI);
        }

        /// <summary>
        /// Add quotes to the path.
        /// </summary>
        /// <param name="Source">Source string with path.</param>
        /// <returns>Quoted string with path.</returns>
        public static string AddQuotesToPath(string Source)
        {
            return String.Format(Properties.Resources.AppOpenHandlerEscapeTemplate, Source);
        }

        /// <summary>
        /// Open the specified text file in default (or overrided in application's
        /// settings (only on Windows platform)) text editor.
        /// </summary>
        /// <param name="FileName">Full path to text file.</param>
        /// <param name="EditorBin">External text editor (Windows only).</param>
        /// <param name="OS">Operating system type.</param>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static void OpenTextEditor(string FileName, string EditorBin, CurrentPlatform.OSType OS)
        {
            switch (OS)
            {
                case CurrentPlatform.OSType.Windows:
                    Process.Start(EditorBin, AddQuotesToPath(FileName));
                    break;
                case CurrentPlatform.OSType.Linux:
                    Process.Start(Properties.Resources.AppOpenHandlerLin, AddQuotesToPath(FileName));
                    break;
                case CurrentPlatform.OSType.MacOSX:
                    Process.Start(Properties.Resources.AppOpenHandlerMac, String.Format("{0} \"{1}\"", "-t", FileName));
                    break;
            }
        }

        /// <summary>
        /// Show the specified file in default file manager.
        /// </summary>
        /// <param name="FileName">Full path to file.</param>
        /// <param name="OS">Operating system type.</param>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static void OpenExplorer(string FileName, CurrentPlatform.OSType OS)
        {
            switch (OS)
            {
                case CurrentPlatform.OSType.Windows:
                    Process.Start(Properties.Resources.ShBinWin, String.Format("{0} \"{1}\"", Properties.Resources.ShParamWin, FileName));
                    break;
                case CurrentPlatform.OSType.Linux:
                    Process.Start(Properties.Resources.AppOpenHandlerLin, String.Format("\"{0}\"", Path.GetDirectoryName(FileName)));
                    break;
                case CurrentPlatform.OSType.MacOSX:
                    Process.Start(Properties.Resources.AppOpenHandlerMac, String.Format("\"{0}\"", Path.GetDirectoryName(FileName)));
                    break;
            }
        }

        /// <summary>
        /// Restart current application with admin user rights.
        /// </summary>
        /// <param name="OS">Operating system type.</param>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public static void RestartApplicationAsAdmin(CurrentPlatform.OSType OS)
        {
            switch (OS)
            {
                case CurrentPlatform.OSType.Windows:
                    StartWithUAC(CurrentApp.AssemblyLocation);
                    Environment.Exit(ReturnCodes.Success);
                    break;
                case CurrentPlatform.OSType.Linux:
                    StartWithPolkit(Path.GetFileNameWithoutExtension(CurrentApp.AssemblyLocation));
                    Environment.Exit(ReturnCodes.Success);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
