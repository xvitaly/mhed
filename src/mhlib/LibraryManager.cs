/**
 * SPDX-FileCopyrightText: 2011-2025 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with loaded shared libraries.
    /// </summary>
    public static class LibraryManager
    {
        /// <summary>
        /// Checks if the library version matches the application version.
        /// </summary>
        /// <returns>Check results.</returns>
        public static bool CheckLibraryVersion()
        {
            return CurrentApp.AppVersion == CurrentApp.LibVersion;
        }

        /// <summary>
        /// Checks if the required library version is equal with the specified library version.
        /// </summary>
        /// <param name="RequiredVersion">Required library version.</param>
        /// <returns>Check results.</returns>
        public static bool CheckLibraryVersion(string RequiredVersion)
        {
            return CurrentApp.AppVersion == new Version(RequiredVersion);
        }
    }
}
