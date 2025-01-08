/**
 * SPDX-FileCopyrightText: 2011-2025 EasyCoding Team
 *
 * SPDX-License-Identifier: GPL-3.0-or-later
*/

using System;
using System.Windows.Forms;

namespace mhed.gui
{
    /// <summary>
    /// Class of the Options module.
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
        /// Loads the application options from the configuration file.
        /// </summary>
        private void LoadOptions()
        {
            MO_ConfirmExit.Checked = Properties.Settings.Default.ConfirmExit;
            MO_PreserveFormState.Checked = Properties.Settings.Default.PreserveFormState;
            MO_AutoCheckUpdates.Checked = Properties.Settings.Default.AutoUpdateCheck;
            MO_TextEdBin.Text = Properties.Settings.Default.EditorBin;
        }

        /// <summary>
        /// Writes the application settings to the configuration file.
        /// </summary>
        private void WriteSettings()
        {
            Properties.Settings.Default.ConfirmExit = MO_ConfirmExit.Checked;
            Properties.Settings.Default.PreserveFormState = MO_PreserveFormState.Checked;
            Properties.Settings.Default.AutoUpdateCheck = MO_AutoCheckUpdates.Checked;
            Properties.Settings.Default.EditorBin = MO_TextEdBin.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// "Form create" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FrmOptions_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }

        /// <summary>
        /// "OK" button click event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void MO_Okay_Click(object sender, EventArgs e)
        {
            // Writing application settings to the configuration file...
            WriteSettings();

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
