/**
 * SPDX-FileCopyrightText: 2011-2024 EasyCoding Team
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
        /// Open downloader window and download a specified file
        /// to a specified location.
        /// </summary>
        /// <param name="URI">Download URL.</param>
        /// <param name="FileName">Full path to destination file.</param>
        public static void FormShowDownloader(string URI, string FileName)
        {
            using (FrmDnWrk DnW = new FrmDnWrk(URI, FileName))
            {
                DnW.ShowDialog();
            }
        }

        /// <summary>
        /// Open "About applicaion" form window.
        /// </summary>
        public static void FormShowAboutApp()
        {
            using (FrmAbout AboutFrm = new FrmAbout())
            {
                AboutFrm.ShowDialog();
            }
        }

        /// <summary>
        /// Open updater window.
        /// </summary>
        /// <param name="UserAgent">User-Agent header for outgoing HTTP queries.</param>
        /// <param name="FullAppPath">App's installation directory.</param>
        /// <param name="AppUpdateDir">App's local updates directory.</param>
        public static void FormShowUpdater(string UserAgent, string FullAppPath, string AppUpdateDir)
        {
            using (FrmUpdate UpdFrm = new FrmUpdate(UserAgent, FullAppPath, AppUpdateDir))
            {
                UpdFrm.ShowDialog();
            }
        }

        /// <summary>
        /// Open "Program options" form window.
        /// </summary>
        public static void FormShowOptions()
        {
            using (FrmOptions OptsFrm = new FrmOptions())
            {
                OptsFrm.ShowDialog();
            }
        }
    }
}
