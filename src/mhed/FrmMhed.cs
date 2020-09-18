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
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace mhed.gui
{
    public partial class FrmHEd : Form
    {
        public FrmHEd()
        {
            InitializeComponent();
        }

        #region IV
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
        private void ReadHostsToTable(string FilePath)
        {
            HEd_Table.Rows.Clear();
            if (File.Exists(FilePath))
            {
                using (StreamReader OpenedHosts = new StreamReader(FilePath, Encoding.Default))
                {
                    while (OpenedHosts.Peek() >= 0) { string ImpStr = StringsManager.CleanString(OpenedHosts.ReadLine()); if (!(String.IsNullOrEmpty(ImpStr))) { if (ImpStr[0] != '#') { int SpPos = ImpStr.IndexOf(" "); if (SpPos != -1) { HEd_Table.Rows.Add(ImpStr.Substring(0, SpPos), ImpStr.Remove(0, SpPos + 1)); } } } }
                }
            }
        }

        private void WriteTableToHosts(string Path)
        {
            using (StreamWriter CFile = new StreamWriter(Path, false, Encoding.Default))
            {
                try { if (App.Platform.OS == CurrentPlatform.OSType.Windows) { CFile.WriteLine(StringsManager.GetTemplateFromResource(Properties.Resources.TmplFileName)); } } catch { }
                foreach (DataGridViewRow Row in HEd_Table.Rows)
                {
                    if ((Row.Cells[0].Value != null) && (Row.Cells[1].Value != null))
                    {
                        if (IPAddress.TryParse(Row.Cells[0].Value.ToString(), out IPAddress IPAddr))
                        {
                            CFile.WriteLine("{0} {1}", IPAddr, Row.Cells[1].Value);
                        }
                    }
                }
            }
        }

        private void SaveToFile()
        {
            if (ProcessManager.IsCurrentUserAdmin()) { try { WriteTableToHosts(App.HostsFilePath); MessageBox.Show(AppStrings.AHE_Saved, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information); } catch { MessageBox.Show(String.Format(AppStrings.AHE_SaveException, App.HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); } } else { MessageBox.Show(String.Format(AppStrings.AHE_NoAdminRights, App.HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        
        private void FrmHEd_Load(object sender, EventArgs e)
        {
            // Create a new instance of CurrentApp class...
            App = new CurrentApp(false, Properties.Resources.AppName);

            if (!ProcessManager.IsCurrentUserAdmin()) { HEd_M_Save.Enabled = false; HEd_T_Save.Enabled = false; HEd_M_RestDef.Enabled = false; HEd_Table.ReadOnly = true; HEd_T_Cut.Enabled = false; HEd_T_Paste.Enabled = false; HEd_T_RemRw.Enabled = false; }
            Text = String.Format(Text, CurrentApp.AppVersion);
            if (File.Exists(App.HostsFilePath)) { HEd_St_Wrn.Text = App.HostsFilePath; try { ReadHostsToTable(App.HostsFilePath); } catch { MessageBox.Show(String.Format(AppStrings.AHE_ExceptionDetected, App.HostsFilePath, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)); } } else { MessageBox.Show(String.Format(AppStrings.AHE_NoFileDetected, App.HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); Close(); }
        }

        private void HEd_T_Refresh_Click(object sender, EventArgs e)
        {
            try { ReadHostsToTable(App.HostsFilePath); } catch { MessageBox.Show(String.Format(AppStrings.AHE_ExceptionDetected, App.HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
                try { Process.Start(Properties.Settings.Default.ShBin, String.Format("{0} \"{1}\"", Properties.Settings.Default.ShParam, App.HostsFilePath)); } catch (Exception Ex) { MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
            try { Process.Start(Properties.Settings.Default.EditorBin, String.Format("\"{0}\"", App.HostsFilePath)); } catch (Exception Ex) { MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void HEd_M_RepBug_Click(object sender, EventArgs e)
        {
            ProcessManager.OpenWebPage(Properties.Resources.AppBtURL);
        }
        #endregion
    }
}
