/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.Reflection;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with loaded shared libraries.
    /// </summary>
    public static class LibraryManager
    {
        /// <summary>
        /// Checks if required library version is equal to current library version.
        /// </summary>
        /// <param name="RequiredVersion">Required ABI version.</param>
        /// <returns>Check results.</returns>
        public static bool CheckLibraryVersion()
        {
            return Assembly.GetCallingAssembly().GetName().Version == Assembly.GetExecutingAssembly().GetName().Version;
        }

        /// <summary>
        /// Checks if required library version is equal to current library version.
        /// </summary>
        /// <param name="RequiredVersion">Required library version.</param>
        /// <returns>Check results.</returns>
        public static bool CheckLibraryVersion(string RequiredVersion)
        {
            return Assembly.GetCallingAssembly().GetName().Version == new Version(RequiredVersion);
        }
    }
}
