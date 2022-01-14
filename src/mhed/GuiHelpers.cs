/**
 * SPDX-FileCopyrightText: 2011-2022 EasyCoding Team
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
