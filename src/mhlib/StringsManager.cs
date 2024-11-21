/**
 * SPDX-FileCopyrightText: 2011-2024 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;

namespace mhed.lib
{
    /// <summary>
    /// Class for working with strings and strings stored in
    /// resource sections.
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
        /// Remove leading and trailing spaces from the source string.
        /// </summary>
        /// <param name="SrcStr">Source string for cleanup.</param>
        /// <returns>String with leading and trailing spaces removed.</returns>
        private static string RemoveStartEndSpaces(string SrcStr)
        {
            return string.IsNullOrEmpty(SrcStr) ? SrcStr : SrcStr.Trim();
        }

        /// <summary>
        /// Remove special characters from the source string.
        /// </summary>
        /// <param name="RecvStr">Source string for cleanup.</param>
        /// <param name="CleanQuotes">Enable removal of quotes.</param>
        /// <param name="CleanSlashes">Enable removal of double slashes.</param>
        /// <param name="CleanComments">Enable removal of comments.</param>
        /// <returns>Clean string with removed special characters.</returns>
        public static string CleanString(string RecvStr, bool CleanQuotes, bool CleanSlashes, bool CleanComments)
        {
            if (string.IsNullOrEmpty(RecvStr)) { return RecvStr; }
            RecvStr = RemoveTabs(RecvStr);
            RecvStr = RemoveNullBytes(RecvStr);
            RecvStr = RemoveMultipleSpaces(RecvStr);
            if (CleanQuotes) { RecvStr = RemoveQuotes(RecvStr); }
            if (CleanSlashes) { RecvStr = RemoveDoubleSlashes(RecvStr); }
            if (CleanComments) { RecvStr = RemoveComments(RecvStr); }
            return RemoveStartEndSpaces(RecvStr);
        }

        /// <summary>
        /// Remove special characters (tabulations, NUL-bytes, multiple spaces
        /// and comments) from the source string.
        /// </summary>
        /// <param name="RecvStr">Source string for cleanup.</param>
        /// <returns>Clean string with removed special characters.</returns>
        public static string CleanString(string RecvStr)
        {
            return CleanString(RecvStr, false, false, true);
        }

        /// <summary>
        /// Get the mutex name for internal purposes.
        /// </summary>
        /// <param name="AppNameInternal">Internal application name.</param>
        /// <returns>Mutex name.</returns>
        public static string GetMutexName(string AppNameInternal)
        {
            return string.Format(ProcessManager.IsCurrentUserAdmin() ? Properties.Resources.MutexAdmin : Properties.Resources.MutexRegular, AppNameInternal);
        }
    }
}
