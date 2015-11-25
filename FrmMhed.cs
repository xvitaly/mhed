/*
 * Micro Hosts Editor (standalone application).
 * 
 * Copyright 2011 EasyCoding Team (ECTeam).
 * Copyright 2005 - 2013 EasyCoding Team.
 * 
 * Лицензия: GPL v3 (см. файл GPL.txt).
 * Лицензия контента: Creative Commons 3.0 BY.
 * 
 * Запрещается использовать этот файл при использовании любой
 * лицензии, отличной от GNU GPL версии 3 и с ней совместимой.
 * 
 * Официальный блог EasyCoding Team: http://www.easycoding.org/
 * Официальная страница проекта: http://www.easycoding.org/projects/mhed
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
using System.Resources;
using System.Net;

namespace mhed
{
    public partial class frmHEd : Form
    {
        public frmHEd()
        {
            InitializeComponent();
        }

        #region IV
        private string HostsFilePath = "";
        ResourceManager RM = new ResourceManager("mhed.AppStrings", typeof(frmHEd).Assembly);
        #endregion

        #region IM
        private bool IsCurrentUserAdmin()
        {
            bool Result;
            try { WindowsPrincipal UP = new WindowsPrincipal(WindowsIdentity.GetCurrent()); Result = UP.IsInRole(WindowsBuiltInRole.Administrator); } catch { Result = false; }
            return Result;
        }

        private string GetHostsFileFullPath(int PlatformID = 0)
        {
            string Result = "";
            if (PlatformID == 0) { try { RegistryKey ResKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", false); if (ResKey != null) { Result = (string)ResKey.GetValue("DataBasePath"); } if (String.IsNullOrWhiteSpace(Result)) { Result = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "drivers", "etc"); } } catch { Result = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "drivers", "etc"); } Result = Path.Combine(Result, "hosts"); } else { Result = Path.Combine("/etc", "hosts"); }
            return Result;
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
            string result = "";
            using (Stream Strm = Assembly.GetExecutingAssembly().GetManifestResourceStream(FileName))
            {
                using (StreamReader Reader = new StreamReader(Strm))
                {
                    result = Reader.ReadToEnd();
                }
            }
            return result;
        }

        private void WriteTableToHosts(string Path)
        {
            using (StreamWriter CFile = new StreamWriter(Path, false, Encoding.Default))
            {
                try { if (DetectRunningOS() == 0) { CFile.WriteLine(GetTemplateFromResource(Properties.Resources.TmplFileName)); } } catch { }
                for (int i = 0; i < HEd_Table.Rows.Count - 1; i++)
                {
                    if ((HEd_Table.Rows[i].Cells[0].Value != null) && (HEd_Table.Rows[i].Cells[1].Value != null))
                    {
                        IPAddress IPAddr;
                        if (IPAddress.TryParse(HEd_Table.Rows[i].Cells[0].Value.ToString(), out IPAddr))
                        {
                            CFile.WriteLine("{0} {1}", IPAddr, HEd_Table.Rows[i].Cells[1].Value);
                        }
                    }
                }
                CFile.Close();
            }
        }
        
        private void frmHEd_Load(object sender, EventArgs e)
        {
            if (!(IsCurrentUserAdmin())) { HEd_M_Save.Enabled = false; HEd_T_Save.Enabled = false; HEd_M_RestDef.Enabled = false; HEd_Table.ReadOnly = true; HEd_T_Cut.Enabled = false; HEd_T_Paste.Enabled = false; HEd_T_RemRw.Enabled = false; }
            Text = String.Format(Text, Assembly.GetEntryAssembly().GetName().Version.ToString());
            HostsFilePath = GetHostsFileFullPath(DetectRunningOS());
            if (File.Exists(HostsFilePath)) { HEd_St_Wrn.Text = HostsFilePath; try { ReadHostsToTable(HostsFilePath); } catch { MessageBox.Show(String.Format(RM.GetString("AHE_ExceptionDetected"), HostsFilePath, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)); } } else { MessageBox.Show(String.Format(RM.GetString("AHE_NoFileDetected"), HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); Close(); }
        }

        private void HEd_T_Refresh_Click(object sender, EventArgs e)
        {
            try { ReadHostsToTable(HostsFilePath); } catch { MessageBox.Show(String.Format(RM.GetString("AHE_ExceptionDetected"), HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void HEd_T_Save_Click(object sender, EventArgs e)
        {
            if (IsCurrentUserAdmin()) { try { WriteTableToHosts(HostsFilePath); MessageBox.Show(RM.GetString("AHE_Saved"), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information); } catch { MessageBox.Show(String.Format(RM.GetString("AHE_SaveException"), HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning); } } else { MessageBox.Show(String.Format(RM.GetString("AHE_NoAdminRights"), HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void HEd_M_Quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HEd_M_RestDef_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(RM.GetString("AHE_RestDef"), Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                HEd_Table.Rows.Clear();
                HEd_Table.Rows.Add("127.0.0.1", "localhost");
                HEd_T_Save.PerformClick();
            }
        }

        private void HEd_M_OnlHelp_Click(object sender, EventArgs e)
        {
            Process.Start(String.Format("http://code.google.com/p/srcrepair/wiki/HostsEditorPlugin_{0}", RM.GetString("AppLangPrefix")));
        }

        private void HEd_M_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("{0} by {1}. Version: {2}.", Properties.Resources.AppName, "V1TSK", Assembly.GetEntryAssembly().GetName().Version.ToString()), Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HEd_T_RemRw_Click(object sender, EventArgs e)
        {
            try { if (HEd_Table.Rows.Count > 0) { HEd_Table.Rows.Remove(HEd_Table.CurrentRow); } } catch { }
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
            if (MessageBox.Show(String.Format(RM.GetString("AHE_HMessg"), HostsFilePath), Properties.Resources.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Process.Start(Properties.Settings.Default.ShBin, String.Format("{0} \"{1}\"", Properties.Settings.Default.ShParam, HostsFilePath));
            }
        }

        private void HEd_T_Cut_Click(object sender, EventArgs e)
        {
            if (HEd_Table.Rows[HEd_Table.CurrentRow.Index].Cells[HEd_Table.CurrentCell.ColumnIndex].Value != null)
            {
                Clipboard.SetText(HEd_Table.Rows[HEd_Table.CurrentRow.Index].Cells[HEd_Table.CurrentCell.ColumnIndex].Value.ToString());
                HEd_Table.Rows[HEd_Table.CurrentRow.Index].Cells[HEd_Table.CurrentCell.ColumnIndex].Value = null;
            }
        }

        private void HEd_T_Copy_Click(object sender, EventArgs e)
        {
            if (HEd_Table.Rows[HEd_Table.CurrentRow.Index].Cells[HEd_Table.CurrentCell.ColumnIndex].Value != null)
            {
                Clipboard.SetText(HEd_Table.Rows[HEd_Table.CurrentRow.Index].Cells[HEd_Table.CurrentCell.ColumnIndex].Value.ToString());
            }
        }

        private void HEd_T_Paste_Click(object sender, EventArgs e)
        {
            try { if (Clipboard.ContainsText()) { HEd_Table.Rows[HEd_Table.CurrentRow.Index].Cells[HEd_Table.CurrentCell.ColumnIndex].Value = Clipboard.GetText(); } } catch { }
        }

        private void HEd_M_Notepad_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.EditorBin, String.Format("\"{0}\"", HostsFilePath));
        }

        private void HEd_M_RepBug_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.AppBtURL);
        }
        #endregion
    }
}
