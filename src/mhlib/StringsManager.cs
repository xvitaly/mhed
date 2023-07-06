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
        private static string RemoveTabulations(string SrcStr)
        {
            while (SrcStr.IndexOf("\t", StringComparison.InvariantCulture) != -1)
            {
                SrcStr = SrcStr.Replace("\t", " ");
            }
            return SrcStr;
        }

        private static string RemoveNullBytes(string SrcStr)
        {
            while (SrcStr.IndexOf("\0", StringComparison.InvariantCulture) != -1)
            {
                SrcStr = SrcStr.Replace("\0", " ");
            }
            return SrcStr;
        }

        private static string RemoveMultipleSpaces(string SrcStr)
        {
            while (SrcStr.IndexOf("  ", StringComparison.InvariantCulture) != -1)
            {
                SrcStr = SrcStr.Replace("  ", " ");
            }
            return SrcStr;
        }
        
        /// <summary>
        /// Remove different special characters from specified string.
        /// </summary>
        /// <param name="RecvStr">Source string for cleanup.</param>
        /// <param name="CleanComments">Enable removal of inline comments.</param>
        /// <param name="CleanQuotes">Enable removal of quotes.</param>
        /// <param name="CleanSlashes">Enable removal of double slashes.</param>
        /// <returns>Clean string with removed special characters.</returns>
        public static string CleanString(string RecvStr, bool CleanComments, bool CleanQuotes, bool CleanSlashes)
        {
            // Removing tabulations...
            RecvStr = RemoveTabulations(RecvStr);

            // Replacing all NUL symbols with spaces...
            RecvStr = RemoveNullBytes(RecvStr);

            // Removing multiple spaces...
            RecvStr = RemoveMultipleSpaces(RecvStr);

            // Removing inline comments if enabled...
            if (CleanComments)
            {
                int CommentIndex = RecvStr.IndexOf("#", StringComparison.InvariantCulture);
                if (CommentIndex > 1)
                {
                    RecvStr = RecvStr.Substring(0, CommentIndex - 1);
                }
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
            return CleanString(RecvStr, true, false, false);
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
