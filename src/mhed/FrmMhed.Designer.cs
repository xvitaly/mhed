namespace mhed.gui
{
    partial class FrmHEd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHEd));
            this.HEd_Table = new System.Windows.Forms.DataGridView();
            this.HDV_IPAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HDV_Domain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HEd_MTool = new System.Windows.Forms.ToolStrip();
            this.HEd_T_Refresh = new System.Windows.Forms.ToolStripButton();
            this.HEd_T_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.HEd_T_Cut = new System.Windows.Forms.ToolStripButton();
            this.HEd_T_Copy = new System.Windows.Forms.ToolStripButton();
            this.HEd_T_Paste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.HEd_T_RemRw = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.HEd_T_About = new System.Windows.Forms.ToolStripButton();
            this.HEd_MMenu = new System.Windows.Forms.MenuStrip();
            this.HEd_M_File = new System.Windows.Forms.ToolStripMenuItem();
            this.HEd_M_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.HEd_M_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.HEd_M_Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.HEd_M_Adv = new System.Windows.Forms.ToolStripMenuItem();
            this.HEd_M_RestDef = new System.Windows.Forms.ToolStripMenuItem();
            this.HEd_M_Notepad = new System.Windows.Forms.ToolStripMenuItem();
            this.HEd_M_Hlp = new System.Windows.Forms.ToolStripMenuItem();
            this.HEd_M_OnlHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.HEd_M_RepBug = new System.Windows.Forms.ToolStripMenuItem();
            this.HEd_M_About = new System.Windows.Forms.ToolStripMenuItem();
            this.HEd_MStatus = new System.Windows.Forms.StatusStrip();
            this.HEd_St_Wrn = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.HEd_Table)).BeginInit();
            this.HEd_MTool.SuspendLayout();
            this.HEd_MMenu.SuspendLayout();
            this.HEd_MStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // HEd_Table
            // 
            resources.ApplyResources(this.HEd_Table, "HEd_Table");
            this.HEd_Table.BackgroundColor = System.Drawing.SystemColors.Window;
            this.HEd_Table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HEd_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HEd_Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HDV_IPAddr,
            this.HDV_Domain});
            this.HEd_Table.Name = "HEd_Table";
            // 
            // HDV_IPAddr
            // 
            this.HDV_IPAddr.DataPropertyName = "IPAddress";
            resources.ApplyResources(this.HDV_IPAddr, "HDV_IPAddr");
            this.HDV_IPAddr.Name = "HDV_IPAddr";
            // 
            // HDV_Domain
            // 
            this.HDV_Domain.DataPropertyName = "Hostname";
            resources.ApplyResources(this.HDV_Domain, "HDV_Domain");
            this.HDV_Domain.Name = "HDV_Domain";
            // 
            // HEd_MTool
            // 
            this.HEd_MTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HEd_T_Refresh,
            this.HEd_T_Save,
            this.toolStripSeparator1,
            this.HEd_T_Cut,
            this.HEd_T_Copy,
            this.HEd_T_Paste,
            this.toolStripSeparator,
            this.HEd_T_RemRw,
            this.toolStripSeparator2,
            this.HEd_T_About});
            resources.ApplyResources(this.HEd_MTool, "HEd_MTool");
            this.HEd_MTool.Name = "HEd_MTool";
            // 
            // HEd_T_Refresh
            // 
            this.HEd_T_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HEd_T_Refresh.Image = global::mhed.gui.Properties.Resources.Refresh;
            resources.ApplyResources(this.HEd_T_Refresh, "HEd_T_Refresh");
            this.HEd_T_Refresh.Name = "HEd_T_Refresh";
            this.HEd_T_Refresh.Click += new System.EventHandler(this.HEd_T_Refresh_Click);
            // 
            // HEd_T_Save
            // 
            this.HEd_T_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HEd_T_Save.Image = global::mhed.gui.Properties.Resources.Save;
            resources.ApplyResources(this.HEd_T_Save, "HEd_T_Save");
            this.HEd_T_Save.Name = "HEd_T_Save";
            this.HEd_T_Save.Click += new System.EventHandler(this.HEd_T_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // HEd_T_Cut
            // 
            this.HEd_T_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.HEd_T_Cut, "HEd_T_Cut");
            this.HEd_T_Cut.Name = "HEd_T_Cut";
            this.HEd_T_Cut.Click += new System.EventHandler(this.HEd_T_Cut_Click);
            // 
            // HEd_T_Copy
            // 
            this.HEd_T_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.HEd_T_Copy, "HEd_T_Copy");
            this.HEd_T_Copy.Name = "HEd_T_Copy";
            this.HEd_T_Copy.Click += new System.EventHandler(this.HEd_T_Copy_Click);
            // 
            // HEd_T_Paste
            // 
            this.HEd_T_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.HEd_T_Paste, "HEd_T_Paste");
            this.HEd_T_Paste.Name = "HEd_T_Paste";
            this.HEd_T_Paste.Click += new System.EventHandler(this.HEd_T_Paste_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // HEd_T_RemRw
            // 
            this.HEd_T_RemRw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HEd_T_RemRw.Image = global::mhed.gui.Properties.Resources.Delete;
            resources.ApplyResources(this.HEd_T_RemRw, "HEd_T_RemRw");
            this.HEd_T_RemRw.Name = "HEd_T_RemRw";
            this.HEd_T_RemRw.Click += new System.EventHandler(this.HEd_T_RemRw_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // HEd_T_About
            // 
            this.HEd_T_About.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.HEd_T_About, "HEd_T_About");
            this.HEd_T_About.Name = "HEd_T_About";
            this.HEd_T_About.Click += new System.EventHandler(this.HEd_M_About_Click);
            // 
            // HEd_MMenu
            // 
            this.HEd_MMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HEd_M_File,
            this.HEd_M_Adv,
            this.HEd_M_Hlp});
            resources.ApplyResources(this.HEd_MMenu, "HEd_MMenu");
            this.HEd_MMenu.Name = "HEd_MMenu";
            // 
            // HEd_M_File
            // 
            this.HEd_M_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HEd_M_Refresh,
            this.HEd_M_Save,
            this.HEd_M_Quit});
            this.HEd_M_File.Name = "HEd_M_File";
            resources.ApplyResources(this.HEd_M_File, "HEd_M_File");
            // 
            // HEd_M_Refresh
            // 
            this.HEd_M_Refresh.Image = global::mhed.gui.Properties.Resources.Refresh;
            this.HEd_M_Refresh.Name = "HEd_M_Refresh";
            resources.ApplyResources(this.HEd_M_Refresh, "HEd_M_Refresh");
            this.HEd_M_Refresh.Click += new System.EventHandler(this.HEd_T_Refresh_Click);
            // 
            // HEd_M_Save
            // 
            this.HEd_M_Save.Image = global::mhed.gui.Properties.Resources.Save;
            this.HEd_M_Save.Name = "HEd_M_Save";
            resources.ApplyResources(this.HEd_M_Save, "HEd_M_Save");
            this.HEd_M_Save.Click += new System.EventHandler(this.HEd_T_Save_Click);
            // 
            // HEd_M_Quit
            // 
            this.HEd_M_Quit.Image = global::mhed.gui.Properties.Resources.Exit;
            this.HEd_M_Quit.Name = "HEd_M_Quit";
            resources.ApplyResources(this.HEd_M_Quit, "HEd_M_Quit");
            this.HEd_M_Quit.Click += new System.EventHandler(this.HEd_M_Quit_Click);
            // 
            // HEd_M_Adv
            // 
            this.HEd_M_Adv.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HEd_M_RestDef,
            this.HEd_M_Notepad});
            this.HEd_M_Adv.Name = "HEd_M_Adv";
            resources.ApplyResources(this.HEd_M_Adv, "HEd_M_Adv");
            // 
            // HEd_M_RestDef
            // 
            this.HEd_M_RestDef.Image = global::mhed.gui.Properties.Resources.Restore;
            this.HEd_M_RestDef.Name = "HEd_M_RestDef";
            resources.ApplyResources(this.HEd_M_RestDef, "HEd_M_RestDef");
            this.HEd_M_RestDef.Click += new System.EventHandler(this.HEd_M_RestDef_Click);
            // 
            // HEd_M_Notepad
            // 
            this.HEd_M_Notepad.Image = global::mhed.gui.Properties.Resources.TextEditor;
            this.HEd_M_Notepad.Name = "HEd_M_Notepad";
            resources.ApplyResources(this.HEd_M_Notepad, "HEd_M_Notepad");
            this.HEd_M_Notepad.Click += new System.EventHandler(this.HEd_M_Notepad_Click);
            // 
            // HEd_M_Hlp
            // 
            this.HEd_M_Hlp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HEd_M_OnlHelp,
            this.HEd_M_RepBug,
            this.HEd_M_About});
            this.HEd_M_Hlp.Name = "HEd_M_Hlp";
            resources.ApplyResources(this.HEd_M_Hlp, "HEd_M_Hlp");
            // 
            // HEd_M_OnlHelp
            // 
            this.HEd_M_OnlHelp.Image = global::mhed.gui.Properties.Resources.Help;
            this.HEd_M_OnlHelp.Name = "HEd_M_OnlHelp";
            resources.ApplyResources(this.HEd_M_OnlHelp, "HEd_M_OnlHelp");
            this.HEd_M_OnlHelp.Click += new System.EventHandler(this.HEd_M_OnlHelp_Click);
            // 
            // HEd_M_RepBug
            // 
            this.HEd_M_RepBug.Image = global::mhed.gui.Properties.Resources.bug;
            this.HEd_M_RepBug.Name = "HEd_M_RepBug";
            resources.ApplyResources(this.HEd_M_RepBug, "HEd_M_RepBug");
            this.HEd_M_RepBug.Click += new System.EventHandler(this.HEd_M_RepBug_Click);
            // 
            // HEd_M_About
            // 
            this.HEd_M_About.Image = global::mhed.gui.Properties.Resources.Info;
            this.HEd_M_About.Name = "HEd_M_About";
            resources.ApplyResources(this.HEd_M_About, "HEd_M_About");
            this.HEd_M_About.Click += new System.EventHandler(this.HEd_M_About_Click);
            // 
            // HEd_MStatus
            // 
            this.HEd_MStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HEd_St_Wrn});
            resources.ApplyResources(this.HEd_MStatus, "HEd_MStatus");
            this.HEd_MStatus.Name = "HEd_MStatus";
            // 
            // HEd_St_Wrn
            // 
            this.HEd_St_Wrn.Name = "HEd_St_Wrn";
            resources.ApplyResources(this.HEd_St_Wrn, "HEd_St_Wrn");
            this.HEd_St_Wrn.Click += new System.EventHandler(this.HEd_St_Wrn_Click);
            this.HEd_St_Wrn.MouseEnter += new System.EventHandler(this.HEd_St_Wrn_MouseEnter);
            this.HEd_St_Wrn.MouseLeave += new System.EventHandler(this.HEd_St_Wrn_MouseLeave);
            // 
            // FrmHEd
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HEd_MStatus);
            this.Controls.Add(this.HEd_MTool);
            this.Controls.Add(this.HEd_MMenu);
            this.Controls.Add(this.HEd_Table);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.HEd_MMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHEd";
            this.Load += new System.EventHandler(this.FrmHEd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HEd_Table)).EndInit();
            this.HEd_MTool.ResumeLayout(false);
            this.HEd_MTool.PerformLayout();
            this.HEd_MMenu.ResumeLayout(false);
            this.HEd_MMenu.PerformLayout();
            this.HEd_MStatus.ResumeLayout(false);
            this.HEd_MStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView HEd_Table;
        private System.Windows.Forms.ToolStrip HEd_MTool;
        private System.Windows.Forms.ToolStripButton HEd_T_Refresh;
        private System.Windows.Forms.ToolStripButton HEd_T_Save;
        private System.Windows.Forms.MenuStrip HEd_MMenu;
        private System.Windows.Forms.ToolStripMenuItem HEd_M_File;
        private System.Windows.Forms.ToolStripMenuItem HEd_M_Refresh;
        private System.Windows.Forms.ToolStripMenuItem HEd_M_Save;
        private System.Windows.Forms.ToolStripMenuItem HEd_M_Adv;
        private System.Windows.Forms.ToolStripMenuItem HEd_M_RestDef;
        private System.Windows.Forms.ToolStripMenuItem HEd_M_Hlp;
        private System.Windows.Forms.ToolStripMenuItem HEd_M_OnlHelp;
        private System.Windows.Forms.ToolStripMenuItem HEd_M_About;
        private System.Windows.Forms.StatusStrip HEd_MStatus;
        private System.Windows.Forms.ToolStripStatusLabel HEd_St_Wrn;
        private System.Windows.Forms.ToolStripMenuItem HEd_M_Quit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton HEd_T_RemRw;
        private System.Windows.Forms.ToolStripMenuItem HEd_M_Notepad;
        private System.Windows.Forms.ToolStripButton HEd_T_Cut;
        private System.Windows.Forms.ToolStripButton HEd_T_Copy;
        private System.Windows.Forms.ToolStripButton HEd_T_Paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton HEd_T_About;
        private System.Windows.Forms.ToolStripMenuItem HEd_M_RepBug;
        private System.Windows.Forms.DataGridViewTextBoxColumn HDV_IPAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn HDV_Domain;
    }
}