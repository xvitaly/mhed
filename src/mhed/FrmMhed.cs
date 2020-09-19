/*
 * This file is a part of Micro Hosts Editor. For more information
 * visit official site: https://www.easycoding.org/projects/mhed
 *
 * Copyright (c) 2011 - 2020 EasyCoding Team (ECTeam).
 * Copyright (c) 2005 - 2020 EasyCoding Team.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using mhed.lib;
using NLog;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace mhed.gui
{
    public partial class FrmHEd : Form
    {
        public FrmHEd()
        {
            InitializeComponent();
            InitializeFormControls();
        }

        #region IV
        /// <summary>
        /// Logger instance for HUDManager class.
        /// </summary>
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets or sets instance of CurrentApp class.
        /// </summary>
        private CurrentApp App { get; set; }
        #endregion

        #region IH
        protected override void ScaleControl(SizeF ScalingFactor, BoundsSpecified Bounds)
        {
            base.ScaleControl(ScalingFactor, Bounds);
            DpiManager.ScaleColumnsInControl(HEd_Table, ScalingFactor);
        }
        #endregion

        #region IM
        private void SaveToFile()
        {
            if (ProcessManager.IsCurrentUserAdmin())
            {
                try
                {
                    App.HostsFile.Save();
                    MessageBox.Show(AppStrings.AHE_Saved, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception Ex)
                {
                    Logger.Error(Ex);
                    MessageBox.Show(String.Format(AppStrings.AHE_SaveException, App.HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(String.Format(AppStrings.AHE_NoAdminRights, App.HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Create an instance of the CurrentApp class.
        /// </summary>
        private void InitializeApp()
        {
            // Create a new instance of CurrentApp class...
            App = new CurrentApp(false, Properties.Resources.AppName);
        }

        /// <summary>
        /// Initializes some controls on form.
        /// </summary>
        private void InitializeFormControls()
        {
            // Disabling auto columns generating...
            HEd_Table.AutoGenerateColumns = false;
        }

        /// <summary>
        /// Change state of some controls, depending on current running
        /// platform or access level.
        /// </summary>
        private void ChangePrvControlState()
        {
            if (!ProcessManager.IsCurrentUserAdmin())
            {
                HEd_M_Save.Enabled = false;
                HEd_T_Save.Enabled = false;
                HEd_M_RestDef.Enabled = false;
                HEd_Table.ReadOnly = true;
                HEd_T_Cut.Enabled = false;
                HEd_T_Paste.Enabled = false;
                HEd_T_RemRw.Enabled = false;
            }
        }

        /// <summary>
        /// Set strings data on the main form.
        /// </summary>
        private void SetAppStrings()
        {
            // Add application version and platform name to form's title...
            Text = String.Format(Text, CurrentApp.AppVersion);

            // Add Hosts file path to the status bar...
            HEd_St_Wrn.Text = App.HostsFilePath;
        }

        /// <summary>
        /// Try to read Hosts file.
        /// </summary>
        private void LoadHostsFile()
        {
            try
            {
                App.HostsFile = new HostsFileManager(App.HostsFilePath, App.Platform.OS);
                HEd_Table.DataSource = App.HostsFile.Contents;
            }
            catch (FileNotFoundException Ex)
            {
                Logger.Error(Ex);
                MessageBox.Show(String.Format(AppStrings.AHE_NoFileDetected, App.HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex);
                MessageBox.Show(String.Format(AppStrings.AHE_ExceptionDetected, App.HostsFilePath, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning));
            }
        }

        private void FrmHEd_Load(object sender, EventArgs e)
        {
            InitializeApp();
            ChangePrvControlState();
            SetAppStrings();
            LoadHostsFile();
        }

        private void HEd_T_Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                App.HostsFile.Refresh();
                HEd_Table.Refresh();
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex);
                MessageBox.Show(String.Format(AppStrings.AHE_ExceptionDetected, App.HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HEd_T_Save_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void HEd_M_Quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HEd_M_RestDef_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppStrings.AHE_RestDef, Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                HEd_Table.Rows.Clear();
                HEd_Table.Rows.Add("127.0.0.1", "localhost");
                SaveToFile();
            }
        }

        private void HEd_M_OnlHelp_Click(object sender, EventArgs e)
        {
            ProcessManager.OpenWebPage(Properties.Resources.AppHelpURL);
        }

        private void HEd_M_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("{0} by {1}. Version: {2}.", Properties.Resources.AppName, CurrentApp.AppCompany, CurrentApp.AppVersion), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HEd_T_RemRw_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewCell Cell in HEd_Table.SelectedCells)
                {
                    if (Cell.Selected) { HEd_Table.Rows.RemoveAt(Cell.RowIndex); }
                }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void HEd_St_Wrn_MouseEnter(object sender, EventArgs e)
        {
            HEd_St_Wrn.ForeColor = Color.Red;
        }

        private void HEd_St_Wrn_MouseLeave(object sender, EventArgs e)
        {
            HEd_St_Wrn.ForeColor = Color.Black;
        }

        private void HEd_St_Wrn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(String.Format(AppStrings.AHE_HMessg, App.HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    ProcessManager.OpenExplorer(App.HostsFilePath, App.Platform.OS);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void HEd_T_Cut_Click(object sender, EventArgs e)
        {
            try
            {
                if (HEd_Table.Rows[HEd_Table.CurrentRow.Index].Cells[HEd_Table.CurrentCell.ColumnIndex].Value != null)
                {
                    Clipboard.SetText(HEd_Table.Rows[HEd_Table.CurrentRow.Index].Cells[HEd_Table.CurrentCell.ColumnIndex].Value.ToString());
                    HEd_Table.Rows[HEd_Table.CurrentRow.Index].Cells[HEd_Table.CurrentCell.ColumnIndex].Value = null;
                }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void HEd_T_Copy_Click(object sender, EventArgs e)
        {
            try
            {
                if (HEd_Table.Rows[HEd_Table.CurrentRow.Index].Cells[HEd_Table.CurrentCell.ColumnIndex].Value != null)
                {
                    Clipboard.SetText(HEd_Table.Rows[HEd_Table.CurrentRow.Index].Cells[HEd_Table.CurrentCell.ColumnIndex].Value.ToString());
                }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void HEd_T_Paste_Click(object sender, EventArgs e)
        {
            try { if (Clipboard.ContainsText()) { HEd_Table.Rows[HEd_Table.CurrentRow.Index].Cells[HEd_Table.CurrentCell.ColumnIndex].Value = Clipboard.GetText(); } } catch { }
        }

        private void HEd_M_Notepad_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessManager.OpenTextEditor(App.HostsFilePath, Properties.Settings.Default.EditorBin, App.Platform.OS);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HEd_M_RepBug_Click(object sender, EventArgs e)
        {
            ProcessManager.OpenWebPage(Properties.Resources.AppBtURL);
        }
        #endregion
    }
}
