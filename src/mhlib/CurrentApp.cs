/**
 * SPDX-FileCopyrightText: 2011-2024 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using NLog;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with running application instance.
    /// </summary>
    public sealed class CurrentApp
    {
        /// <summary>
        /// Get User-Agent header for outgoing HTTP queries.
        /// </summary>
        public string UserAgent { get; private set; }

        /// <summary>
        /// Get application's installation directory.
        /// </summary>
        public string FullAppPath { get; private set; }

        /// <summary>
        /// Get path to application's user directory.
        /// </summary>
        public string AppUserDir { get; private set; }

        /// <summary>
        /// Get full path to the active log file.
        /// </summary>
        public string AppLogFile { get; private set; }

        /// <summary>
        /// Get full path to the local updates directory.
        /// </summary>
        public string AppUpdateDir { get; private set; }

        /// <summary>
        /// Get information about running operating system.
        /// </summary>
        public CurrentPlatform Platform { get; private set; }

        /// <summary>
        /// Works with Hosts file contents.
        /// </summary>
        public HostsFileManager HostsFile { get; private set; }

        /// <summary>
        /// Returns if the application is launched with administrator rights.
        /// </summary>
        public bool IsAdmin { get; private set; }

        /// <summary>
        /// Get application name from the resource section of calling assembly.
        /// </summary>
        public static string AppProduct
        {
            get
            {
                object[] Attribs = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return Attribs.Length != 0 ? ((AssemblyProductAttribute)Attribs[0]).Product : string.Empty;
            }
        }

        /// <summary>
        /// Get application version from the resource section of calling assembly.
        /// </summary>
        public static Version AppVersion => Assembly.GetCallingAssembly().GetName().Version;

        /// <summary>
        /// Get the library version from the resource section of current assembly.
        /// </summary>
        public static Version LibVersion => Assembly.GetExecutingAssembly().GetName().Version;

        /// <summary>
        /// Get application developer name from the resource section of calling assembly.
        /// </summary>
        public static string AppCompany
        {
            get
            {
                object[] Attribs = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return Attribs.Length != 0 ? ((AssemblyCompanyAttribute)Attribs[0]).Company : string.Empty;
            }
        }

        /// <summary>
        /// Get application copyright from the resource section of calling assembly.
        /// </summary>
        public static string AppCopyright
        {
            get
            {
                object[] Attribs = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return Attribs.Length != 0 ? ((AssemblyCopyrightAttribute)Attribs[0]).Copyright : string.Empty;
            }
        }

        /// <summary>
        /// Get the full path to the running assembly.
        /// </summary>
        public static string AppLocation => Assembly.GetEntryAssembly().Location;

        /// <summary>
        /// Get the full path to the active application's log file.
        /// </summary>
        /// <returns>Full path to the active log file.</returns>
        private string GetLogFileName()
        {
            try
            {
                NLog.Targets.FileTarget LogTarget = (NLog.Targets.FileTarget)LogManager.Configuration.FindTargetByName("logfile");
                return Path.GetFullPath(LogTarget.FileName.Render(new LogEventInfo()));
            }
            catch
            {
                return Path.Combine(AppUserDir, Properties.Resources.LogLocalDir, Properties.Resources.LogMainFile);
            }
        }

        /// <summary>
        /// CurrentApp class constructor.
        /// </summary>
        /// <param name="IsPortable">Enable portable mode (with settings in the same directory as executable).</param>
        /// <param name="AppName">Application name.</param>
        public CurrentApp(bool IsPortable, string AppName)
        {
            // Getting information about operating system and platform...
            Platform = CurrentPlatform.Create();

            // Checking for local administrator rights...
            IsAdmin = ProcessManager.IsCurrentUserAdmin();

            // Getting full path to application installation directory...
            FullAppPath = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);

            // Getting full to application user directory...
            AppUserDir = IsPortable ? Path.Combine(FullAppPath, Properties.Resources.PortableLocalDir) : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppName);

            // Getting full paths to local application directories...
            AppLogFile = GetLogFileName();
            AppUpdateDir = Path.Combine(AppUserDir, Properties.Resources.UpdateLocalDir);

            // Checking if user directory exists. If not - creating it...
            if (!Directory.Exists(AppUserDir))
            {
                Directory.CreateDirectory(AppUserDir);
            }

            // Initializing class for working with Hosts file...
            HostsFile = new HostsFileManager(Platform);

            // Generating User-Agent header for outgoing HTTP queries...
            UserAgent = string.Format(Properties.Resources.AppUserAgentTemplate, Platform.OSFriendlyName, Platform.OSVersion, Platform.OSArchitecture, CultureInfo.CurrentCulture.Name, AppName, AppVersion);
        }
    }
}
