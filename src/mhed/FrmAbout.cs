/**
 * SPDX-FileCopyrightText: 2011-2021 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using mhed.lib;
using System;
using System.Windows.Forms;

namespace mhed.gui
{
    /// <summary>
    /// "About" form class.
    /// </summary>
    partial class FrmAbout : Form
    {
        /// <summary>
        /// FrmAbout class constructor.
        /// </summary>
        public FrmAbout()
        {
            InitializeComponent();
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

        /// <summary>
        /// "Form create" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FrmAbout_Load(object sender, EventArgs e)
        {
            // Adding information about product version and copyrights...
            Text = String.Format(Text, CurrentApp.AppProduct);
            AHE_AppName.Text = CurrentApp.AppProduct;
            #if DEBUG
            AHE_AppName.Text += " DEBUG";
            #endif
            AHE_Version.Text = String.Format("Version: {0}", CurrentApp.AppVersion);
            AHE_Copyright.Text = CurrentApp.AppCopyright;
            AHE_CompanyName.Text = CurrentApp.AppCompany;
        }
    }
}
