/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

namespace mhed.lib
{
    /// <summary>
    /// Interface for working with platform-dependent functions.
    /// </summary>
    public interface IPlatform
    {
        /// <summary>
        /// Codes and IDs of available platforms.
        /// </summary>
        CurrentPlatform.OSType OS { get; }

        /// <summary>
        /// Get current operating system friendly name.
        /// </summary>
        string OSFriendlyName { get; }

        /// <summary>
        /// Get platform-dependent suffix for HTTP_USER_AGENT header.
        /// </summary>
        string UASuffix { get; }

        /// <summary>
        /// Return platform-dependent location of the Hosts file.
        /// </summary>
        string HostsFileLocation { get; }

        /// <summary>
        /// Return platform-dependent path to Hosts file.
        /// </summary>
        string HostsFileFullPath { get; }

        /// <summary>
        /// Return whether automatic updates are supported on this platform.
        /// </summary>
        bool AutoUpdateSupported { get; }

        /// <summary>
        /// Immediately shut down application and return exit code.
        /// </summary>
        /// <param name="ReturnCode">Exit code.</param>
        void Exit(int ReturnCode);

        /// <summary>
        /// Show the specified file in default file manager.
        /// </summary>
        /// <param name="FileName">Full path to file.</param>
        void OpenExplorer(string FileName);

        /// <summary>
        /// Open the specified text file in default (or overrided in application's
        /// settings (only on Windows platform)) text editor.
        /// </summary>
        /// <param name="FileName">Full path to text file.</param>
        /// <param name="EditorBin">External text editor (Windows only).</param>
        void OpenTextEditor(string FileName, string EditorBin);

        /// <summary>
        /// Open the specified URL in default Web browser.
        /// </summary>
        /// <param name="URI">Full URL.</param>
        void OpenWebPage(string URI);

        /// <summary>
        /// Restart current application with admin user rights.
        /// </summary>
        /// <param name="OS">Operating system type.</param>
        void RestartApplicationAsAdmin();

        /// <summary>
        /// Start the required application as the current user.
        /// </summary>
        /// <param name="FileName">Full path to the executable.</param>
        /// <returns>PID of the newly created process.</returns>
        int StartRegularProcess(string FileName);

        /// <summary>
        /// Start the required application from administrator.
        /// </summary>
        /// <param name="FileName">Full path to the executable.</param>
        /// <returns>PID of the newly created process.</returns>
        int StartElevatedProcess(string FileName);
    }
}
