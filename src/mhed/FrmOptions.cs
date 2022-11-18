/**
 * SPDX-FileCopyrightText: 2011-2022 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.Windows.Forms;

namespace mhed.gui
{
    /// <summary>
    /// Class of settings editor window.
    /// </summary>
    public partial class FrmOptions : Form
    {
        /// <summary>
        /// FrmOptions class constructor.
        /// </summary>
        public FrmOptions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// "Form create" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FrmOptions_Load(object sender, EventArgs e)
        {
            // Reading current settings from configuration file...
            MO_ConfirmExit.Checked = Properties.Settings.Default.ConfirmExit;
            MO_PreserveFormState.Checked = Properties.Settings.Default.PreserveFormState;
            MO_TextEdBin.Text = Properties.Settings.Default.EditorBin;

            // Settig application name in window title...
            Text = string.Format(Text, Properties.Resources.AppName);
        }

        /// <summary>
        /// "OK" button click event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void MO_Okay_Click(object sender, EventArgs e)
        {
            // Storing settings...
            Properties.Settings.Default.ConfirmExit = MO_ConfirmExit.Checked;
            Properties.Settings.Default.PreserveFormState = MO_PreserveFormState.Checked;
            Properties.Settings.Default.EditorBin = MO_TextEdBin.Text;

            // Saving settings to disk...
            Properties.Settings.Default.Save();

            // Showing message and closing form...
            MessageBox.Show(AppStrings.AHE_OptionsSaved, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        /// <summary>
        /// "Cancel" button click event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void MO_Cancel_Click(object sender, EventArgs e)
        {
            // Closing form without saving anything...
            Close();
        }

        /// <summary>
        /// "Browse" button click event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void MO_FindTextEd_Click(object sender, EventArgs e)
        {
            if (MO_SearchBin.ShowDialog() == DialogResult.OK)
            {
                MO_TextEdBin.Text = MO_SearchBin.FileName;
            }
        }
    }
}
