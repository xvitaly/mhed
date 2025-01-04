/**
 * SPDX-FileCopyrightText: 2011-2025 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using mhed.lib;
using System;
using System.Windows.Forms;

namespace mhed.gui
{
    /// <summary>
    /// Class of the About module.
    /// </summary>
    public partial class FrmAbout : Form
    {
        /// <summary>
        /// FrmAbout class constructor.
        /// </summary>
        public FrmAbout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// "Form create" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FrmAbout_Load(object sender, EventArgs e)
        {
            // Adding information about product version and copyrights...
            AHE_AppName.Text = CurrentApp.AppProduct;
            AHE_Version.Text = string.Format(AppStrings.AHE_Version, CurrentApp.AppVersion);
            AHE_Copyright.Text = CurrentApp.AppCopyright;
            AHE_CompanyName.Text = CurrentApp.AppCompany;
        }

        /// <summary>
        /// "OK" button click event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void AHE_Okay_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
