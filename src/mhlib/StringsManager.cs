/**
 * SPDX-FileCopyrightText: 2011-2023 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with strings and strings, stored in
    /// resource section of this shared library.
    /// </summary>
    public static class StringsManager
    {
        /// <summary>
        /// Remove different special characters from specified string.
        /// </summary>
        /// <param name="RecvStr">Source string for cleanup.</param>
        /// <param name="CleanQuotes">Enable removal of quotes.</param>
        /// <param name="CleanSlashes">Enable removal of double slashes.</param>
        /// <returns>Clean string with removed special characters.</returns>
        public static string CleanString(string RecvStr, bool CleanQuotes, bool CleanSlashes)
        {
            // Removing tabulations...
            while (RecvStr.IndexOf("\t", StringComparison.InvariantCulture) != -1)
            {
                RecvStr = RecvStr.Replace("\t", " ");
            }

            // Replacing all NUL symbols with spaces...
            while (RecvStr.IndexOf("\0", StringComparison.InvariantCulture) != -1)
            {
                RecvStr = RecvStr.Replace("\0", " ");
            }

            // Removing multiple spaces...
            while (RecvStr.IndexOf("  ", StringComparison.InvariantCulture) != -1)
            {
                RecvStr = RecvStr.Replace("  ", " ");
            }

            // Removing quotes if enabled...
            if (CleanQuotes)
            {
                while (RecvStr.IndexOf(@"""", StringComparison.InvariantCulture) != -1)
                {
                    RecvStr = RecvStr.Replace(@"""", string.Empty);
                }
            }

            // Removing double slashes if enabled...
            if (CleanSlashes)
            {
                while (RecvStr.IndexOf(@"\\", StringComparison.InvariantCulture) != -1)
                {
                    RecvStr = RecvStr.Replace(@"\\", @"\");
                }
            }

            // Return result with removal of leading and trailing white-spaces...
            return RecvStr.Trim();
        }

        /// <summary>
        /// Remove different special characters from specified string.
        /// </summary>
        /// <param name="RecvStr">Source string for cleanup.</param>
        /// <returns>Clean string with removed special characters.</returns>
        public static string CleanString(string RecvStr)
        {
            return CleanString(RecvStr, false, false);
        }

        /// <summary>
        /// Get mutex name for the internal purposes.
        /// </summary>
        /// <param name="AppNameInternal">Internal application name.</param>
        /// <returns>Mutex name.</returns>
        public static string GetMutexName(string AppNameInternal)
        {
            return string.Format(ProcessManager.IsCurrentUserAdmin() ? Properties.Resources.MutexAdmin : Properties.Resources.MutexRegular, AppNameInternal);
        }
    }
}
