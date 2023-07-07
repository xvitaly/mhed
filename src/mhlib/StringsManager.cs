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
        /// Remove tabulations from the source string.
        /// </summary>
        /// <param name="SrcStr">Source string for cleanup.</param>
        /// <returns>String with tabulations replaced with spaces.</returns>
        private static string RemoveTabs(string SrcStr)
        {
            while (SrcStr.IndexOf("\t", StringComparison.InvariantCulture) != -1)
            {
                SrcStr = SrcStr.Replace("\t", " ");
            }
            return SrcStr;
        }

        /// <summary>
        /// Remove NUL-bytes from the source string.
        /// </summary>
        /// <param name="SrcStr">Source string for cleanup.</param>
        /// <returns>String with NUL-bytes removed.</returns>
        private static string RemoveNullBytes(string SrcStr)
        {
            while (SrcStr.IndexOf("\0", StringComparison.InvariantCulture) != -1)
            {
                SrcStr = SrcStr.Replace("\0", " ");
            }
            return SrcStr;
        }

        /// <summary>
        /// Remove multiple spaces from the source string.
        /// </summary>
        /// <param name="SrcStr">Source string for cleanup.</param>
        /// <returns>String with multiple spaces removed.</returns>
        private static string RemoveMultipleSpaces(string SrcStr)
        {
            while (SrcStr.IndexOf("  ", StringComparison.InvariantCulture) != -1)
            {
                SrcStr = SrcStr.Replace("  ", " ");
            }
            return SrcStr;
        }

        /// <summary>
        /// Remove comments from the source string.
        /// </summary>
        /// <param name="SrcStr">Source string for cleanup.</param>
        /// <returns>String with comments removed.</returns>
        private static string RemoveComments(string SrcStr)
        {
            int CommentIndex = SrcStr.IndexOf("#", StringComparison.InvariantCulture);
            if (CommentIndex == 0)
            {
                SrcStr = string.Empty;
            }
            else if (CommentIndex > 1)
            {
                SrcStr = SrcStr.Substring(0, CommentIndex - 1);
            }
            return SrcStr;
        }

        /// <summary>
        /// Remove quotes from the source string.
        /// </summary>
        /// <param name="SrcStr">Source string for cleanup.</param>
        /// <returns>String with quotes removed.</returns>
        private static string RemoveQuotes(string SrcStr)
        {
            while (SrcStr.IndexOf(@"""", StringComparison.InvariantCulture) != -1)
            {
                SrcStr = SrcStr.Replace(@"""", string.Empty);
            }
            return SrcStr;
        }

        /// <summary>
        /// Remove double slashes from the source string.
        /// </summary>
        /// <param name="SrcStr">Source string for cleanup.</param>
        /// <returns>String with double slashes removed.</returns>
        private static string RemoveDoubleSlashes(string SrcStr)
        {
            while (SrcStr.IndexOf(@"\\", StringComparison.InvariantCulture) != -1)
            {
                SrcStr = SrcStr.Replace(@"\\", @"\");
            }
            return SrcStr;
        }
        
        /// <summary>
        /// Remove different special characters from specified string.
        /// </summary>
        /// <param name="RecvStr">Source string for cleanup.</param>
        /// <param name="CleanQuotes">Enable removal of quotes.</param>
        /// <param name="CleanSlashes">Enable removal of double slashes.</param>
        /// <returns>Clean string with removed special characters.</returns>
        public static string CleanString(string RecvStr, bool CleanQuotes, bool CleanSlashes)
        {
            RecvStr = RemoveTabs(RecvStr);
            RecvStr = RemoveNullBytes(RecvStr);
            RecvStr = RemoveMultipleSpaces(RecvStr);
            RecvStr = RemoveComments(RecvStr);
            if (CleanQuotes) { RecvStr = RemoveQuotes(RecvStr); }
            if (CleanSlashes) { RecvStr = RemoveDoubleSlashes(RecvStr); }
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
