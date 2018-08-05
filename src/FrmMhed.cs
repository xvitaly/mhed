/*
 * Micro Hosts Editor (standalone application).
 * 
 * Copyright 2011 - 2017 EasyCoding Team (ECTeam).
 * Copyright 2005 - 2017 EasyCoding Team.
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
 * 
 * EasyCoding Team's official site: https://www.easycoding.org/
 * Official project homepage: https://www.easycoding.org/projects/mhed
 * 
*/
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Security.Permissions;
using System.Net;

namespace mhed
{
    public partial class FrmHEd : Form
    {
        public FrmHEd()
        {
            InitializeComponent();
        }

        #region IV
        private string HostsFilePath { get; set; }
        #endregion

        #region IM
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        private void OpenWebPage(string URI)
        {
            try { Process.Start(URI); } catch (Exception Ex) { MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private bool IsCurrentUserAdmin()
        {
            bool Result; try { WindowsPrincipal UP = new WindowsPrincipal(WindowsIdentity.GetCurrent()); Result = UP.IsInRole(WindowsBuiltInRole.Administrator); } catch { Result = false; } return Result;
        }

        private string GetHostsFileFullPath(int PlatformID = 0)
        {
            string Result = String.Empty; if (PlatformID == 0) { try { RegistryKey ResKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", false); if (ResKey != null) { Result = (string)ResKey.GetValue("DataBasePath"); } if (String.IsNullOrWhiteSpace(Result)) { Result = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "drivers", "etc"); } } catch { Result = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "drivers", "etc"); } Result = Path.Combine(Result, "hosts"); } else { Result = Path.Combine("/etc", "hosts"); } return Result;
        }

        private string CleanStrWx(string RecvStr, bool CleanQuotes = false, bool CleanSlashes = false)
        {
            while (RecvStr.IndexOf("\t") != -1) { RecvStr = RecvStr.Replace("\t", " "); }
            while (RecvStr.IndexOf("  ") != -1) { RecvStr = RecvStr.Replace("  ", " "); }
            if (CleanQuotes) { while (RecvStr.IndexOf('"') != -1) { RecvStr = RecvStr.Replace(@"""", ""); } }
            if (CleanSlashes) { while (RecvStr.IndexOf(@"\\") != -1) { RecvStr = RecvStr.Replace(@"\\", @"\"); } }
            return RecvStr.Trim();
        }

        private void ReadHostsToTable(string FilePath)
        {
            HEd_Table.Rows.Clear();
            if (File.Exists(FilePath))
            {
                using (StreamReader OpenedHosts = new StreamReader(FilePath, Encoding.Default))
                {
                    while (OpenedHosts.Peek() >= 0) { string ImpStr = CleanStrWx(OpenedHosts.ReadLine()); if (!(String.IsNullOrEmpty(ImpStr))) { if (ImpStr[0] != '#') { int SpPos = ImpStr.IndexOf(" "); if (SpPos != -1) { HEd_Table.Rows.Add(ImpStr.Substring(0, SpPos), ImpStr.Remove(0, SpPos + 1)); } } } }
                }
            }
        }

        private int DetectRunningOS()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                    return (Directory.Exists("/Applications") & Directory.Exists("/System") & Directory.Exists("/Users") & Directory.Exists("/Volumes")) ? 1 : 2;
                case PlatformID.MacOSX:
                    return 1;
                default: return 0;
            }
        }

        private string GetTemplateFromResource(string FileName)
        {
            string Result = String.Empty; using (StreamReader Reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(FileName))) { Result = Reader.ReadToEnd(); } return Result;
        }

        private void WriteTableToHosts(string Path)
        {
            using (StreamWriter CFile = new StreamWriter(Path, false, Encoding.Default))
            {
                try { if (DetectRunningOS() == 0) { CFile.WriteLine(GetTemplateFromResource(Properties.Resources.TmplFileName)); } } catch { }
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
            if (IsCurrentUserAdmin()) { try { WriteTableToHosts(HostsFilePath); MessageBox.Show(AppStrings.AHE_Saved, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information); } catch { MessageBox.Show(String.Format(AppStrings.AHE_SaveException, HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); } } else { MessageBox.Show(String.Format(AppStrings.AHE_NoAdminRights, HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private string GetAppCompany()
        {
            object[] Attribs = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            return Attribs.Length != 0 ? ((AssemblyCompanyAttribute)Attribs[0]).Company : String.Empty;
        }

        private Version GetAppVersion()
        {
            return Assembly.GetEntryAssembly().GetName().Version;
        }
        
        private void FrmHEd_Load(object sender, EventArgs e)
        {
            if (!(IsCurrentUserAdmin())) { HEd_M_Save.Enabled = false; HEd_T_Save.Enabled = false; HEd_M_RestDef.Enabled = false; HEd_Table.ReadOnly = true; HEd_T_Cut.Enabled = false; HEd_T_Paste.Enabled = false; HEd_T_RemRw.Enabled = false; }
            Text = String.Format(Text, GetAppVersion());
            HostsFilePath = GetHostsFileFullPath(DetectRunningOS());
            if (File.Exists(HostsFilePath)) { HEd_St_Wrn.Text = HostsFilePath; try { ReadHostsToTable(HostsFilePath); } catch { MessageBox.Show(String.Format(AppStrings.AHE_ExceptionDetected, HostsFilePath, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)); } } else { MessageBox.Show(String.Format(AppStrings.AHE_NoFileDetected, HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); Close(); }
        }

        private void HEd_T_Refresh_Click(object sender, EventArgs e)
        {
            try { ReadHostsToTable(HostsFilePath); } catch { MessageBox.Show(String.Format(AppStrings.AHE_ExceptionDetected, HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
            OpenWebPage(Properties.Resources.AppHelpURL);
        }

        private void HEd_M_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("{0} by {1}. Version: {2}.", Properties.Resources.AppName, GetAppCompany(), GetAppVersion()), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (MessageBox.Show(String.Format(AppStrings.AHE_HMessg, HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try { Process.Start(Properties.Settings.Default.ShBin, String.Format("{0} \"{1}\"", Properties.Settings.Default.ShParam, HostsFilePath)); } catch (Exception Ex) { MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
            try { Process.Start(Properties.Settings.Default.EditorBin, String.Format("\"{0}\"", HostsFilePath)); } catch (Exception Ex) { MessageBox.Show(Ex.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void HEd_M_RepBug_Click(object sender, EventArgs e)
        {
            OpenWebPage(Properties.Resources.AppBtURL);
        }
        #endregion
    }
}
