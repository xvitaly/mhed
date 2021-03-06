﻿/*
 * This file is a part of Micro Hosts Editor. For more information
 * visit official site: https://www.easycoding.org/projects/mhed
 *
 * Copyright (c) 2011 - 2021 EasyCoding Team (ECTeam).
 * Copyright (c) 2005 - 2021 EasyCoding Team.
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
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
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
        /// Save program settings.
        /// </summary>
        private void SaveSettings()
        {
            Properties.Settings.Default.FormLocation = WindowState == FormWindowState.Normal ? Location : RestoreBounds.Location;
            Properties.Settings.Default.FormSize = WindowState == FormWindowState.Normal ? Size : RestoreBounds.Size;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Different helper methods
        /// <summary>
        /// Change the state of the table editor.
        /// </summary>
        /// <param name="NewState">New state boolean.</param>
        private void ChangeTableEditorState(bool NewState)
        {
            HE_ModelView.ReadOnly = NewState;
        }

        /// <summary>
        /// Change the state of the main menu items.
        /// </summary>
        /// <param name="NewState">New state boolean.</param>
        private void ChangeMenuItemsState(bool NewState)
        {
            HE_MenuSaveItem.Enabled = NewState;
            HE_MenuCutItem.Enabled = NewState;
            HE_MenuPasteItem.Enabled = NewState;
            HE_MenuDeleteItem.Enabled = NewState;
            HE_MenuRestoreDefaultsItem.Enabled = NewState;
        }

        /// <summary>
        /// Change the state of the main toolbar items.
        /// </summary>
        /// <param name="NewState">New state boolean.</param>
        private void ChangeToolbarItemsState(bool NewState)
        {
            HE_ToolbarSaveButton.Enabled = NewState;
            HE_ToolbarCutButton.Enabled = NewState;
            HE_ToolbarPasteButton.Enabled = NewState;
            HE_ToolbarDeleteButton.Enabled = NewState;
        }

        /// <summary>
        /// Change the state of the context menu menu items.
        /// </summary>
        /// <param name="NewState">New state boolean.</param>
        private void ChangeContextMenuItemsState(bool NewState)
        {
            HE_ConextMenuCutItem.Enabled = NewState;
            HE_ConextMenuPasteItem.Enabled = NewState;
            HE_ConextMenuDeleteItem.Enabled = NewState;
        }

        /// <summary>
        /// Change status bar application mode indicator.
        /// </summary>
        /// <param name="NewState">New state boolean.</param>
        private void ChangeStatusBarAppMode()
        {
            HE_StatusBarAppMode.Image = Properties.Resources.GreenCircle;
            HE_StatusBarAppMode.Text = AppStrings.AHE_AppStatusRO;
        }
        /// <summary>
        /// Change state of some controls, depending on current running
        /// platform or access level.
        /// </summary>
        private void ChangePrvControlState()
        {
            if (!App.IsAdmin)
            {
                ChangeTableEditorState(false);
                ChangeMenuItemsState(false);
                ChangeToolbarItemsState(false);
                ChangeContextMenuItemsState(false);
                ChangeStatusBarAppMode();
            }
        }

        /// <summary>
        /// Check saved form position.
        /// </summary>
        /// <returns>Return True if saved position is above zero.</returns>
        private bool CheckFormPosition()
        {
            return (Properties.Settings.Default.FormLocation.X > 0) && (Properties.Settings.Default.FormLocation.Y > 0);
        }

        /// <summary>
        /// Check if the saved form position matches the current screen's resolution.
        /// </summary>
        /// <returns>Return True if the saved position can be placed on screen.</returns>
        private bool CheckScreenBounds()
        {
            return Screen.FromControl(this).Bounds.Contains(Properties.Settings.Default.FormLocation);
        }

        /// <summary>
        /// Set strings data on the main form.
        /// </summary>
        private void SetAppStrings()
        {
            // Add application version and platform name to form's title...
            Text = String.Format(Text, CurrentApp.AppVersion);

            // Add Hosts file path to the status bar...
            HE_StatusBarHostsLocation.Text = App.HostsFile.FilePath;
        }

        /// <summary>
        /// Set form size based on saved settings.
        /// </summary>
        private void SetFormSize()
        {
            try
            {
                if ((Properties.Settings.Default.FormSize.Width > 0) && (Properties.Settings.Default.FormSize.Height > 0))
                {
                    Size = Properties.Settings.Default.FormSize;
                }
                else
                {
                    Logger.Debug(DebugStrings.AppDbgIncorrectFormSize, Properties.Settings.Default.FormSize.Width, Properties.Settings.Default.FormSize.Height);
                }
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExSetFormSize);
            }
        }

        /// <summary>
        /// Set form location based on saved settings.
        /// </summary>
        private void SetFormLocation()
        {
            try
            {
                if (CheckFormPosition() && CheckScreenBounds())
                {
                    StartPosition = FormStartPosition.Manual;
                    Location = Properties.Settings.Default.FormLocation;
                }
                else
                {
                    Logger.Debug(DebugStrings.AppDbgIncorrectFormLocation, Properties.Settings.Default.FormLocation.X, Properties.Settings.Default.FormLocation.Y);
                }
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExSetFormLocation);
            }
        }

        /// <summary>
        /// Restore form state based on saved settings.
        /// </summary>
        private void RestoreFormState()
        {
            if (Properties.Settings.Default.PreserveFormState)
            {
                SetFormSize();
                SetFormLocation();
            }
        }

        /// <summary>
        /// Show specified file in default file manager.
        /// </summary>
        /// <param name="FileName">Fully qualified file name.</param>
        private void HelperShowFile(string FileName)
        {
            try
            {
                App.Platform.OpenExplorer(FileName);
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, String.Format(DebugStrings.AppDbgExOpenShell, FileName));
                MessageBox.Show(AppStrings.AHE_OpenShellError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Load specified file into the selected text editor.
        /// </summary>
        /// <param name="FileName">Fully qualified file name.</param>
        private void HelperTextEditor(string FileName)
        {
            try
            {
                App.Platform.OpenTextEditor(FileName, Properties.Settings.Default.EditorBin);
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, String.Format(DebugStrings.AppDbgExOpenNotepad, FileName));
                MessageBox.Show(AppStrings.AHE_OpenInNotepadError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Load specified URL in default Web browser.
        /// </summary>
        /// <param name="SourceUrl">Source URL.</param>
        private void HelperOpenUrl(string SourceUrl)
        {
            try
            {
                App.Platform.OpenWebPage(SourceUrl);
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExOpenUrl);
                MessageBox.Show(AppStrings.AHE_UrlOpenError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Restart the application with admin user rights.
        /// </summary>
        private void HelperRunAs()
        {
            try
            {
                App.Platform.RestartApplicationAsAdmin();
            }
            catch (PlatformNotSupportedException Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgRestartAsAdminNotImplemented);
                MessageBox.Show(AppStrings.AHE_RestartAsAdminNotImplemented, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgRestartAsAdminError);
                MessageBox.Show(AppStrings.AHE_RestartAsAdminError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cut the contents of the selected cell to the clipboard.
        /// </summary>
        private void HelperCut()
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
        /// Copy the contents of the selected cell to the clipboard.
        /// </summary>
        private void HelperCopy()
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
        /// Paste the contents of the clipboard to the selected cell.
        /// </summary>
        private void HelperPaste()
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
        /// Delete selected rows.
        /// </summary>
        private void HelperDelete()
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
        /// Show offline help.
        /// </summary>
        private void HelperShowHelp()
        {
            try
            {
                string CHMFile = Path.Combine(App.FullAppPath, Properties.Resources.AppHelpDirectory, String.Format(Properties.Resources.AppHelpFileName, AppStrings.AHE_LangPrefix));
                if (File.Exists(CHMFile))
                {
                    Help.ShowHelp(this, CHMFile);
                }
                else
                {
                    MessageBox.Show(AppStrings.AHE_ChmFileNotFound, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExHelpShow);
                MessageBox.Show(AppStrings.AHE_ShowHelpError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Show debug log.
        /// </summary>
        private void HelperShowLog()
        {
            try
            {
                string LogFileName = CurrentApp.LogFileName;
                if (File.Exists(LogFileName))
                {
                    if (ModifierKeys == Keys.Shift) HelperShowFile(LogFileName); else HelperTextEditor(LogFileName);
                }
                else
                {
                    MessageBox.Show(AppStrings.AHE_LogFileNotFound, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExShowLogFile);
                MessageBox.Show(AppStrings.AHE_ShowLogFileError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Form contructors and loaders
        /// <summary>
        /// FrmMhed class constructor.
        /// </summary>
        public FrmMhed()
        {
            InitializeComponent();
        }

        /// <summary>
        /// "Form create" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FrmMhed_Load(object sender, EventArgs e)
        {
            RestoreFormState();
            InitializeApp();
            InitializeModelView();
            ChangePrvControlState();
            SetAppStrings();
            LoadHostsFile();
        }
        #endregion

        #region Other form handlers
        /// <summary>
        /// "Form close" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FrmMhed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = Properties.Settings.Default.ConfirmExit && !(MessageBox.Show(String.Format(AppStrings.AHE_ExitConfirmation, Properties.Resources.AppName), Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
            }
        }

        /// <summary>
        /// "Form closed" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FrmMhed_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }
        #endregion

        #region Save and load methods
        /// <summary>
        /// Save Hosts file changes to disk.
        /// </summary>
        private void SaveToFile()
        {
            if (App.IsAdmin)
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
                Logger.Error(Ex, DebugStrings.AppDbgHostsFileDoesNotExists);
                MessageBox.Show(String.Format(AppStrings.AHE_NoFileDetected, App.HostsFile.FilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(ReturnCodes.HostsFileDoesNotExists);
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExHostsLoadParse);
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
                Logger.Warn(Ex, DebugStrings.AppDbgExHostsLoadParse);
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

            switch (e.ColumnIndex)
            {
                case 0: // Validating IP-address...
                    ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = HostsFileManager.ValidateIPAddress((string)e.FormattedValue) ? null : AppStrings.AHE_IncorrectIPAddress;
                    break;
                case 1: // Validating Hostname...
                    ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = HostsFileManager.ValidateHostname((string)e.FormattedValue) ? null : AppStrings.AHE_IncorrectHostname;
                    break;
                default: // Reporting an error...
                    Logger.Warn(DebugStrings.AppDbgModelViewColumnIndexOutOfRange);
                    break;
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
        /// "Options" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuOptionsItem_Click(object sender, EventArgs e)
        {
            GuiHelpers.FormShowOptions();
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
        /// "Cut" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuCutItem_Click(object sender, EventArgs e)
        {
            HelperCut();
        }

        /// <summary>
        /// "Copy" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuCopyItem_Click(object sender, EventArgs e)
        {
            HelperCopy();
        }

        /// <summary>
        /// "Paste" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuPasteItem_Click(object sender, EventArgs e)
        {
            HelperPaste();
        }

        /// <summary>
        /// "Delete" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuDeleteItem_Click(object sender, EventArgs e)
        {
            HelperDelete();
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
            HelperTextEditor(App.HostsFile.FilePath);
        }

        /// <summary>
        /// "Show help" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuShowHelpItem_Click(object sender, EventArgs e)
        {
            HelperShowHelp();
        }

        /// <summary>
        /// "Check for updates" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private async void HE_MenuCheckForUpdatesItem_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateManager Updater = await UpdateManager.Create(App.UserAgent);

                if (Updater.CheckAppUpdate())
                {
                    if (MessageBox.Show(String.Format(AppStrings.AHE_UpdateAvailable, Updater.AppUpdateVersion), Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        HelperOpenUrl(Updater.AppUpdateInfo);
                    }
                }
                else
                {
                    MessageBox.Show(AppStrings.AHE_NoUpdatesFound, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                Logger.Warn(Ex, DebugStrings.AppDbgExCheckForUpdates);
                MessageBox.Show(AppStrings.AHE_UpdateCheckError, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// "Report bug" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuReportItem_Click(object sender, EventArgs e)
        {
            HelperOpenUrl(Properties.Resources.AppBtURL);
        }

        /// <summary>
        /// "Show debug logs" menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_MenuDebugLogItem_Click(object sender, EventArgs e)
        {
            HelperShowLog();
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
            HelperCut();
        }

        /// <summary>
        /// "Copy" toolbar button event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ToolbarCopyButton_Click(object sender, EventArgs e)
        {
            HelperCopy();
        }

        /// <summary>
        /// "Paste" toolbar button event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ToolbarPasteButton_Click(object sender, EventArgs e)
        {
            HelperPaste();
        }

        /// <summary>
        /// "Delete row" toolbar button event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ToolbarDeleteButton_Click(object sender, EventArgs e)
        {
            HelperDelete();
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

        #region Context menu handlers
        /// <summary>
        /// "Cut" context menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ConextMenuCutItem_Click(object sender, EventArgs e)
        {
            HelperCut();
        }

        /// <summary>
        /// "Copy" context menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ConextMenuCopyItem_Click(object sender, EventArgs e)
        {
            HelperCopy();
        }

        /// <summary>
        /// "Paste" context menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ConextMenuPasteItem_Click(object sender, EventArgs e)
        {
            HelperPaste();
        }

        /// <summary>
        /// "Delete" context menu item event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_ConextMenuDeleteItem_Click(object sender, EventArgs e)
        {
            HelperDelete();
        }
        #endregion

        #region Status bar handlers
        /// <summary>
        /// "Mouse enter location" status bar event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_StatusBarHostsLocation_MouseEnter(object sender, EventArgs e)
        {
            HE_StatusBarHostsLocation.ForeColor = Color.Red;
        }

        /// <summary>
        /// "Mouse leave location" status bar event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_StatusBarHostsLocation_MouseLeave(object sender, EventArgs e)
        {
            HE_StatusBarHostsLocation.ForeColor = Color.Black;
        }

        /// <summary>
        /// "Status bar location click" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_StatusBarHostsLocation_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(String.Format(AppStrings.AHE_HMessg, App.HostsFile.FilePath), Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                HelperShowFile(App.HostsFile.FilePath);
            }
        }

        /// <summary>
        /// "Status bar application mode click" event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void HE_StatusBarAppMode_Click(object sender, EventArgs e)
        {
            if (!App.IsAdmin)
            {
                if (MessageBox.Show(AppStrings.AHE_RestartAsAdminQuestion, Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    HelperRunAs();
                }
            }
            else
            {
                MessageBox.Show(AppStrings.AHE_RestartAsAdminRunning, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
