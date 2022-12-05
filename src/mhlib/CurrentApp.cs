/**
 * SPDX-FileCopyrightText: 2011-2022 EasyCoding Team
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
        /// Get information about hardware architecture.
        /// </summary>
        private string SystemArch => Environment.Is64BitOperatingSystem ? "Amd64" : "x86";

        /// <summary>
        /// Get full path to Nlog active log file.
        /// </summary>
        public static string LogFileName
        {
            get
            {
                NLog.Targets.FileTarget LogTarget = (NLog.Targets.FileTarget)LogManager.Configuration.FindTargetByName("logfile");
                return Path.GetFullPath(LogTarget.FileName.Render(new LogEventInfo()));
            }
        }

        /// <summary>
        /// Get full path to Nlog's directory for storing log files.
        /// </summary>
        public static string LogDirectoryPath => Path.GetDirectoryName(LogFileName);

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
        public static string AppVersion => Assembly.GetCallingAssembly().GetName().Version.ToString();

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
        public static string AssemblyLocation { get => Assembly.GetEntryAssembly().Location; }

        /// <summary>
        /// CurrentApp class constructor.
        /// </summary>
        /// <param name="IsPortable">Enable portable mode (with settings in the same directory as executable).</param>
        /// <param name="AppName">Application name.</param>
        public CurrentApp(bool IsPortable, string AppName)
        {
            // Getting information about operating system and platform...
            Platform = CurrentPlatform.Create();

            // Getting full path to application installation directory...
            FullAppPath = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);

            // Getting full to application user directory...
            AppUserDir = IsPortable ? Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "portable") : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppName);

            // Checking admininstrator rights...
            IsAdmin = ProcessManager.IsCurrentUserAdmin();

            // Getting full path to application local updates directory...
            AppUpdateDir = Path.Combine(AppUserDir, Properties.Resources.UpdateLocalDir);

            // Checking if user directory exists. If not - creating it...
            if (!Directory.Exists(AppUserDir))
            {
                Directory.CreateDirectory(AppUserDir);
            }

            // Initializing class for working with Hosts file...
            HostsFile = new HostsFileManager(Platform);

            // Generating User-Agent header for outgoing HTTP queries...
            UserAgent = string.Format(Properties.Resources.AppDefUA, Platform.OSFriendlyName, Platform.UASuffix, Environment.OSVersion.Version.Major, Environment.OSVersion.Version.Minor, CultureInfo.CurrentCulture.Name, AppVersion, AppName, SystemArch);
        }
    }
}
