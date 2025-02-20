/**
 * SPDX-FileCopyrightText: 2011-2025 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

namespace mhed.gui
{
    /// <summary>
    /// Class with helper methods for working with forms.
    /// </summary>
    public static class GuiHelpers
    {
        /// <summary>
        /// Open the file downloader module and download the specified URL
        /// to the specified location.
        /// </summary>
        /// <param name="URI">Full download URL.</param>
        /// <param name="FileName">Full path to the destination file.</param>
        public static void FormShowDownloader(string URI, string FileName)
        {
            using (FrmDnWrk DnWrkForm = new FrmDnWrk(URI, FileName))
            {
                DnWrkForm.ShowDialog();
            }
        }

        /// <summary>
        /// Open the about module.
        /// </summary>
        public static void FormShowAbout()
        {
            using (FrmAbout AboutForm = new FrmAbout())
            {
                AboutForm.ShowDialog();
            }
        }

        /// <summary>
        /// Open the update center module.
        /// </summary>
        /// <param name="UserAgent">User-Agent header for outgoing HTTP queries.</param>
        /// <param name="FullAppPath">Full path to the application installation directory.</param>
        /// <param name="AppUpdateDir">Full path to the local updates directory.</param>
        public static void FormShowUpdater(string UserAgent, string FullAppPath, string AppUpdateDir)
        {
            using (FrmUpdate UpdateForm = new FrmUpdate(UserAgent, FullAppPath, AppUpdateDir))
            {
                UpdateForm.ShowDialog();
            }
        }

        /// <summary>
        /// Open the options module.
        /// </summary>
        public static void FormShowOptions()
        {
            using (FrmOptions OptionsForm = new FrmOptions())
            {
                OptionsForm.ShowDialog();
            }
        }
    }
}
