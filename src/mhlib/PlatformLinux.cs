/**
 * SPDX-FileCopyrightText: 2011-2024 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with GNU/Linux specific functions.
    /// </summary>
    public class PlatformLinux : CurrentPlatform
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
            Process.Start(Properties.Resources.AppOpenHandlerLin, AddQuotesToPath(FileName));
        }

        /// <summary>
        /// Show the specified file in default file manager.
        /// </summary>
        /// <param name="FileName">Full path to file.</param>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void OpenExplorer(string FileName)
        {
            Process.Start(Properties.Resources.AppOpenHandlerLin, string.Format("\"{0}\"", Path.GetDirectoryName(FileName)));
        }

        /// <summary>
        /// Start the required application as an administrator with the specified
        /// command-line arguments.
        /// </summary>
        /// <param name="FileName">Full path to the executable.</param>
        /// <param name="Arguments">Command-line arguments.</param>
        /// <returns>PID of the newly created process.</returns>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override int StartElevatedProcess(string FileName, string Arguments)
        {
            return StartElevatedProcess(FileName, Arguments, "pkexec");
        }

        /// <summary>
        /// Restart current application with admin user rights.
        /// </summary>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void RestartApplicationAsAdmin()
        {
            StartElevatedProcess(Path.GetFileNameWithoutExtension(CurrentApp.AppLocation));
            Environment.Exit(ReturnCodes.Success);
        }

        /// <summary>
        /// Get current operating system ID.
        /// </summary>
        public override OSType OS => OSType.Linux;
    }
}
