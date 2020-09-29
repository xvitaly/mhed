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
    /// <summary>
    /// Main form's class.
    /// </summary>
    public partial class FrmMhed : Form
    {
        #region Properties and fields
        /// <summary>
        /// Logger instance for HUDManager class.
        /// </summary>
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets or sets instance of CurrentApp class.
        /// </summary>
        private CurrentApp App { get; set; }
        #endregion

        #region Form overrides for HiDPI compatibility
        protected override void ScaleControl(SizeF ScalingFactor, BoundsSpecified Bounds)
        {
            base.ScaleControl(ScalingFactor, Bounds);
            DpiManager.ScaleColumnsInControl(HE_ModelView, ScalingFactor);
        }
        #endregion

        #region Initialization methods
        /// <summary>
        /// Create an instance of the CurrentApp class.
        /// </summary>
        private void InitializeApp()
        {
            // Create a new instance of CurrentApp class...
            App = new CurrentApp(Properties.Settings.Default.IsPortable, Properties.Resources.AppName);
        }

        /// <summary>
        /// Initializes model view on form.
        /// </summary>
        private void InitializeModelView()
        {
            // Disabling auto columns generating...
            HE_ModelView.AutoGenerateColumns = false;

            // Binding to an object...
            HE_ModelView.DataSource = App.HostsFile.Contents;
        }

        /// <summary>
        /// Imports settings from previous versions of application.
        /// </summary>
        private void ImportSettings()
        {
            try
            {
                if (Properties.Settings.Default.CallUpgrade)
                {
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.CallUpgrade = false;
                }
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExSettingsLoad);
            }
        }

        /// <summary>
        /// Change state of some controls, depending on current running
        /// platform or access level.
        /// </summary>
        private void ChangePrvControlState()
        {
            if (!ProcessManager.IsCurrentUserAdmin())
            {
                HE_MenuSaveItem.Enabled = false;
                HE_ToolbarSaveButton.Enabled = false;
                HE_MenuRestoreDefaultsItem.Enabled = false;
                HE_ModelView.ReadOnly = true;
                HE_ToolbarCutButton.Enabled = false;
                HE_ToolbarPasteButton.Enabled = false;
                HE_ToolbarDeleteButton.Enabled = false;
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
            HE_StatusBarText.Text = App.HostsFile.FilePath;
        }
        #endregion

        #region Form contructors and loaders
        /// <summary>
        /// FrmMhed class constructor.
        /// </summary>
        public FrmMhed()
        {
            InitializeComponent();
            ImportSettings();
        }

        /// <summary>
        /// "Form create" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FrmMhed_Load(object sender, EventArgs e)
        {
            InitializeApp();
            InitializeModelView();
            ChangePrvControlState();
            SetAppStrings();
            LoadHostsFile();
        }
        #endregion

        #region Save and load methods
        /// <summary>
        /// Save Hosts file changes to disk.
        /// </summary>
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
                    MessageBox.Show(String.Format(AppStrings.AHE_SaveException, App.HostsFile.FilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(String.Format(AppStrings.AHE_NoAdminRights, App.HostsFile.FilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Try to read Hosts file.
        /// </summary>
        private void LoadHostsFile()
        {
            try
            {
                App.HostsFile.Load();
            }
            catch (FileNotFoundException Ex)
            {
                Logger.Error(Ex);
                MessageBox.Show(String.Format(AppStrings.AHE_NoFileDetected, App.HostsFile.FilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex);
                MessageBox.Show(String.Format(AppStrings.AHE_ExceptionDetected, App.HostsFile.FilePath, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning));
            }
        }

        /// <summary>
        /// Reload Hosts file contents from disk.
        /// </summary>
        private void ReloadHostsFile()
        {
            try
            {
                App.HostsFile.Refresh();
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex);
                MessageBox.Show(String.Format(AppStrings.AHE_ExceptionDetected, App.HostsFile.FilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region DataGridView handlers
        /// <summary>
        /// "Data error" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ModelView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Logger.Warn(e.Exception, DebugStrings.AppDbgExModelView);
        }

        /// <summary>
        /// "Validate cell" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ModelView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Skip validation of the new rows...
            if (((DataGridView)sender).Rows[e.RowIndex].IsNewRow) return;

            // Validating only IP-address field...
            if (e.ColumnIndex == 0)
            {
                ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = HostsFileManager.ValidateIPAddress((string)e.FormattedValue) ? null : AppStrings.AHE_IncorrectIPAddress;
            }
        }
        #endregion

        #region Menu items handlers
        /// <summary>
        /// "Refresh" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuRefreshItem_Click(object sender, EventArgs e)
        {
            ReloadHostsFile();
        }

        /// <summary>
        /// "Save" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuSaveItem_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        /// <summary>
        /// "Quit" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuQuitItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// "Restore defaults" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuRestoreDefaultsItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(AppStrings.AHE_RestDef, Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                App.HostsFile.Restore();
                SaveToFile();
            }
        }

        /// <summary>
        /// "Open in Notepad" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuOpenNotepadItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessManager.OpenTextEditor(App.HostsFile.FilePath, Properties.Settings.Default.EditorBin, App.Platform.OS);
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExOpenNotepad);
                MessageBox.Show(AppStrings.AHE_OpenInNotepadError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// "Show help" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuShowHelpItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessManager.OpenWebPage(Properties.Resources.AppHelpURL);
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex);
                MessageBox.Show(AppStrings.AHE_UrlOpenError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// "Report bug" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuReportItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessManager.OpenWebPage(Properties.Resources.AppBtURL);
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex);
                MessageBox.Show(AppStrings.AHE_UrlOpenError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// "About" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuAboutItem_Click(object sender, EventArgs e)
        {
            GuiHelpers.FormShowAboutApp();
        }
        #endregion

        #region Toolbar buttons handlers
        /// <summary>
        /// "Refresh" toolbar button event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ToolbarRefreshButton_Click(object sender, EventArgs e)
        {
            ReloadHostsFile();
        }

        /// <summary>
        /// "Save" toolbar button event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ToolbarSaveButton_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        /// <summary>
        /// "Cut" toolbar button event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ToolbarCutButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (HE_ModelView.Rows[HE_ModelView.CurrentRow.Index].Cells[HE_ModelView.CurrentCell.ColumnIndex].Value != null)
                {
                    Clipboard.SetText((string)HE_ModelView.Rows[HE_ModelView.CurrentRow.Index].Cells[HE_ModelView.CurrentCell.ColumnIndex].Value);
                    HE_ModelView.Rows[HE_ModelView.CurrentRow.Index].Cells[HE_ModelView.CurrentCell.ColumnIndex].Value = null;
                }
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExClipboardCut);
                MessageBox.Show(AppStrings.AHE_ClipboardCutError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// "Copy" toolbar button event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ToolbarCopyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (HE_ModelView.Rows[HE_ModelView.CurrentRow.Index].Cells[HE_ModelView.CurrentCell.ColumnIndex].Value != null)
                {
                    Clipboard.SetText((string)HE_ModelView.Rows[HE_ModelView.CurrentRow.Index].Cells[HE_ModelView.CurrentCell.ColumnIndex].Value);
                }
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExClipboardCopy);
                MessageBox.Show(AppStrings.AHE_ClipboardCopyError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// "Paste" toolbar button event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ToolbarPasteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    HE_ModelView.Rows[HE_ModelView.CurrentRow.Index].Cells[HE_ModelView.CurrentCell.ColumnIndex].Value = Clipboard.GetText();
                }
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExClipboardPaste);
                MessageBox.Show(AppStrings.AHE_ClipboardPasteError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// "Delete row" toolbar button event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ToolbarDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewCell Cell in HE_ModelView.SelectedCells)
                {
                    HE_ModelView.Rows.RemoveAt(Cell.RowIndex);
                }
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExDeleteRow);
                MessageBox.Show(AppStrings.AHE_DeleteRowError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// "About" toolbar button event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ToolbarAboutButton_Click(object sender, EventArgs e)
        {
            GuiHelpers.FormShowAboutApp();
        }
        #endregion

        #region Status bar handlers
        /// <summary>
        /// "Mouse enter" status bar event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_StatusBarText_MouseEnter(object sender, EventArgs e)
        {
            HE_StatusBarText.ForeColor = Color.Red;
        }

        /// <summary>
        /// "Mouse leave" status bar event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_StatusBarText_MouseLeave(object sender, EventArgs e)
        {
            HE_StatusBarText.ForeColor = Color.Black;
        }

        /// <summary>
        /// "Status bar click" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_StatusBarText_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(String.Format(AppStrings.AHE_HMessg, App.HostsFile.FilePath), Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    ProcessManager.OpenExplorer(App.HostsFile.FilePath, App.Platform.OS);
                }
                catch (Exception Ex)
                {
                    Logger.Warn(Ex, DebugStrings.AppDbgExOpenShell);
                    MessageBox.Show(AppStrings.AHE_OpenShellError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion
    }
}
