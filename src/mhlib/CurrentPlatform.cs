/**
 * SPDX-FileCopyrightText: 2011-2024 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with platform-dependent functions.
    /// </summary>
    public abstract class CurrentPlatform : IPlatform
    {
        /// <summary>
        /// Create a platform-dependent instance. Factory method.
        /// </summary>
        public static CurrentPlatform Create()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) { return new PlatformWindows(); }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) { return new PlatformLinux(); }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) { return new PlatformMac(); }
            throw new PlatformNotSupportedException(DebugStrings.AppDbgCorePlatformNotSupported);
        }

        /// <summary>
        /// Codes and IDs of available platforms.
        /// </summary>
        public enum OSType
        {
            Windows = 0,
            MacOSX = 1,
            Linux = 2
        }

        /// <summary>
        /// Add quotes to the path.
        /// </summary>
        /// <param name="Source">Source string with path.</param>
        /// <returns>Quoted string with path.</returns>
        protected static string AddQuotesToPath(string Source)
        {
            return string.Format(Properties.Resources.AppOpenHandlerEscapeTemplate, Source);
        }

        /// <summary>
        /// Return whether automatic updates are supported on this platform.
        /// </summary>
        public virtual bool AutoUpdateSupported => false;

        /// <summary>
        /// Return whether Hosts file header is required on this platform.
        /// </summary>
        public virtual bool HostsFileHeader => false;

        /// <summary>
        /// Return whether localhost entry is required on this platform.
        /// </summary>
        public virtual bool LocalHostEntry => true;

        /// <summary>
        /// Return whether Hosts file in Unicode requires BOM on this
        /// platform.
        /// </summary>
        public virtual bool HostsFileBOM => false;

        /// <summary>
        /// Immediately shut down application and return exit code.
        /// </summary>
        /// <param name="ReturnCode">Exit code.</param>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public virtual void Exit(int ReturnCode)
        {
            if (Application.MessageLoop)
            {
                Environment.ExitCode = ReturnCode;
                Application.Exit();
            }
            else
            {
                Environment.Exit(ReturnCode);
            }
        }

        /// <summary>
        /// Open the specified URL in default Web browser.
        /// </summary>
        /// <param name="URI">Full URL.</param>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public virtual void OpenWebPage(string URI)
        {
            Process.Start(URI);
        }

        /// <summary>
        /// Restart current application with admin user rights.
        /// </summary>
        /// <param name="OS">Operating system type.</param>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public virtual void RestartApplicationAsAdmin()
        {
            StartElevatedProcess(CurrentApp.AssemblyLocation);
            Environment.Exit(ReturnCodes.Success);
        }

        /// <summary>
        /// Start the required application as the current user.
        /// </summary>
        /// <param name="FileName">Full path to the executable.</param>
        /// <returns>PID of the newly created process.</returns>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public virtual int StartRegularProcess(string FileName)
        {
            return Process.Start(FileName).Id;
        }

        /// <summary>
        /// Start the required application as the current user with the specified
        /// command-line arguments.
        /// </summary>
        /// <param name="FileName">Full path to the executable.</param>
        /// <param name="Arguments">Command-line arguments.</param>
        /// <returns>PID of the newly created process.</returns>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public virtual int StartRegularProcess(string FileName, string Arguments)
        {
            ProcessStartInfo ST = new ProcessStartInfo
            {
                FileName = FileName,
                Arguments = Arguments
            };
            return Process.Start(ST).Id;
        }

        /// <summary>
        /// Start the required application as an administrator.
        /// </summary>
        /// <param name="FileName">Full path to the executable.</param>
        /// <returns>PID of the newly created process.</returns>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public virtual int StartElevatedProcess(string FileName)
        {
            return StartElevatedProcess(FileName, string.Empty);
        }

        /// <summary>
        /// Start the required application as an administrator with the specified
        /// command-line arguments and external helper tool.
        /// </summary>
        /// <param name="FileName">Full path to the executable.</param>
        /// <param name="Arguments">Command-line arguments.</param>
        /// <param name="ExternalHelper">External helper application for elevating permissions.</param>
        /// <returns>PID of the newly created process.</returns>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        protected virtual int StartElevatedProcess(string FileName, string Arguments, string ExternalHelper)
        {
            // Setting advanced properties...
            ProcessStartInfo ST = new ProcessStartInfo
            {
                FileName = FileName,
                Arguments = Arguments,
                Verb = ExternalHelper,
                WindowStyle = ProcessWindowStyle.Normal,
                UseShellExecute = true
            };

            // Starting process...
            Process NewProcess = Process.Start(ST);

            // Returning PID of created process...
            return NewProcess.Id;
        }

        /// <summary>
        /// Get current operating system ID.
        /// </summary>
        public abstract OSType OS { get; }

        /// <summary>
        /// Get information about operating system architecture for the HTTP_USER_AGENT header.
        /// </summary>
        public virtual string OSArchitecture => RuntimeInformation.OSArchitecture.ToString().ToLower(CultureInfo.InvariantCulture);

        /// <summary>
        /// Get current operating system friendly name for the HTTP_USER_AGENT header.
        /// </summary>
        public virtual string OSFriendlyName => OS.ToString();

        /// <summary>
        /// Get operating system version number for the HTTP_USER_AGENT header.
        /// </summary>
        public virtual string OSVersion
        {
            get
            {
                Version OSVer = Environment.OSVersion.Version;
                return string.Format(Properties.Resources.OSVersionTemplate, OSVer.Major, OSVer.Minor);
            }
        }

        /// <summary>
        /// Return platform-dependent location of the Hosts file.
        /// </summary>
        public virtual string HostsFileLocation => "/etc";

        /// <summary>
        /// Return platform-dependent path to Hosts file.
        /// </summary>
        public virtual string HostsFileFullPath => Path.Combine(HostsFileLocation, "hosts");

        /// <summary>
        /// Open the specified text file in default (or overrided in application's
        /// settings (only on Windows platform)) text editor.
        /// </summary>
        /// <param name="FileName">Full path to text file.</param>
        /// <param name="EditorBin">External text editor (Windows only).</param>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public abstract void OpenTextEditor(string FileName, string EditorBin);

        /// <summary>
        /// Show the specified file in default file manager.
        /// </summary>
        /// <param name="FileName">Full path to file.</param>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public abstract void OpenExplorer(string FileName);

        /// <summary>
        /// Start the required application as an administrator with the specified
        /// command-line arguments.
        /// </summary>
        /// <param name="FileName">Full path to the executable.</param>
        /// <param name="Arguments">Command-line arguments.</param>
        /// <returns>PID of the newly created process.</returns>
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public abstract int StartElevatedProcess(string FileName, string Arguments);
    }
}
