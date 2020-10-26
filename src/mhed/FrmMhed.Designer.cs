namespace mhed.gui
{
    partial class FrmMhed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMhed));
            this.HE_MainToolbar = new System.Windows.Forms.ToolStrip();
            this.HE_ToolbarRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.HE_ToolbarSaveButton = new System.Windows.Forms.ToolStripButton();
            this.HE_ToolbarSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.HE_ToolbarCutButton = new System.Windows.Forms.ToolStripButton();
            this.HE_ToolbarCopyButton = new System.Windows.Forms.ToolStripButton();
            this.HE_ToolbarPasteButton = new System.Windows.Forms.ToolStripButton();
            this.HE_ToolbarSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.HE_ToolbarDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.HE_ToolbarSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.HE_ToolbarAboutButton = new System.Windows.Forms.ToolStripButton();
            this.HE_MainMenu = new System.Windows.Forms.MenuStrip();
            this.HE_MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuRefreshItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuSaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuSeparator1Item = new System.Windows.Forms.ToolStripSeparator();
            this.HE_MenuOptionsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuQuitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuAdvanced = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuRestoreDefaultsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuOpenNotepadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuShowHelpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuSeparator2Item = new System.Windows.Forms.ToolStripSeparator();
            this.HE_MenuCheckForUpdatesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuReportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuDebugLogItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuSeparator3Item = new System.Windows.Forms.ToolStripSeparator();
            this.HE_MenuAboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_StatusBar = new System.Windows.Forms.StatusStrip();
            this.HE_StatusBarHostsLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.HE_StatusBarAppMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.HE_ModelViewPanel = new System.Windows.Forms.Panel();
            this.HE_ModelView = new System.Windows.Forms.DataGridView();
            this.HE_ModelViewColumnIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HE_ModelViewColumnDomain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HE_MainToolbar.SuspendLayout();
            this.HE_MainMenu.SuspendLayout();
            this.HE_StatusBar.SuspendLayout();
            this.HE_ModelViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HE_ModelView)).BeginInit();
            this.SuspendLayout();
            // 
            // HE_MainToolbar
            // 
            this.HE_MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HE_ToolbarRefreshButton,
            this.HE_ToolbarSaveButton,
            this.HE_ToolbarSeparator1,
            this.HE_ToolbarCutButton,
            this.HE_ToolbarCopyButton,
            this.HE_ToolbarPasteButton,
            this.HE_ToolbarSeparator2,
            this.HE_ToolbarDeleteButton,
            this.HE_ToolbarSeparator3,
            this.HE_ToolbarAboutButton});
            resources.ApplyResources(this.HE_MainToolbar, "HE_MainToolbar");
            this.HE_MainToolbar.Name = "HE_MainToolbar";
            // 
            // HE_ToolbarRefreshButton
            // 
            this.HE_ToolbarRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HE_ToolbarRefreshButton.Image = global::mhed.gui.Properties.Resources.Refresh;
            resources.ApplyResources(this.HE_ToolbarRefreshButton, "HE_ToolbarRefreshButton");
            this.HE_ToolbarRefreshButton.Name = "HE_ToolbarRefreshButton";
            this.HE_ToolbarRefreshButton.Click += new System.EventHandler(this.HE_ToolbarRefreshButton_Click);
            // 
            // HE_ToolbarSaveButton
            // 
            this.HE_ToolbarSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HE_ToolbarSaveButton.Image = global::mhed.gui.Properties.Resources.Save;
            resources.ApplyResources(this.HE_ToolbarSaveButton, "HE_ToolbarSaveButton");
            this.HE_ToolbarSaveButton.Name = "HE_ToolbarSaveButton";
            this.HE_ToolbarSaveButton.Click += new System.EventHandler(this.HE_ToolbarSaveButton_Click);
            // 
            // HE_ToolbarSeparator1
            // 
            this.HE_ToolbarSeparator1.Name = "HE_ToolbarSeparator1";
            resources.ApplyResources(this.HE_ToolbarSeparator1, "HE_ToolbarSeparator1");
            // 
            // HE_ToolbarCutButton
            // 
            this.HE_ToolbarCutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HE_ToolbarCutButton.Image = global::mhed.gui.Properties.Resources.Cut;
            resources.ApplyResources(this.HE_ToolbarCutButton, "HE_ToolbarCutButton");
            this.HE_ToolbarCutButton.Name = "HE_ToolbarCutButton";
            this.HE_ToolbarCutButton.Click += new System.EventHandler(this.HE_ToolbarCutButton_Click);
            // 
            // HE_ToolbarCopyButton
            // 
            this.HE_ToolbarCopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HE_ToolbarCopyButton.Image = global::mhed.gui.Properties.Resources.Copy;
            resources.ApplyResources(this.HE_ToolbarCopyButton, "HE_ToolbarCopyButton");
            this.HE_ToolbarCopyButton.Name = "HE_ToolbarCopyButton";
            this.HE_ToolbarCopyButton.Click += new System.EventHandler(this.HE_ToolbarCopyButton_Click);
            // 
            // HE_ToolbarPasteButton
            // 
            this.HE_ToolbarPasteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HE_ToolbarPasteButton.Image = global::mhed.gui.Properties.Resources.Paste;
            resources.ApplyResources(this.HE_ToolbarPasteButton, "HE_ToolbarPasteButton");
            this.HE_ToolbarPasteButton.Name = "HE_ToolbarPasteButton";
            this.HE_ToolbarPasteButton.Click += new System.EventHandler(this.HE_ToolbarPasteButton_Click);
            // 
            // HE_ToolbarSeparator2
            // 
            this.HE_ToolbarSeparator2.Name = "HE_ToolbarSeparator2";
            resources.ApplyResources(this.HE_ToolbarSeparator2, "HE_ToolbarSeparator2");
            // 
            // HE_ToolbarDeleteButton
            // 
            this.HE_ToolbarDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HE_ToolbarDeleteButton.Image = global::mhed.gui.Properties.Resources.Delete;
            resources.ApplyResources(this.HE_ToolbarDeleteButton, "HE_ToolbarDeleteButton");
            this.HE_ToolbarDeleteButton.Name = "HE_ToolbarDeleteButton";
            this.HE_ToolbarDeleteButton.Click += new System.EventHandler(this.HE_ToolbarDeleteButton_Click);
            // 
            // HE_ToolbarSeparator3
            // 
            this.HE_ToolbarSeparator3.Name = "HE_ToolbarSeparator3";
            resources.ApplyResources(this.HE_ToolbarSeparator3, "HE_ToolbarSeparator3");
            // 
            // HE_ToolbarAboutButton
            // 
            this.HE_ToolbarAboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HE_ToolbarAboutButton.Image = global::mhed.gui.Properties.Resources.Info;
            resources.ApplyResources(this.HE_ToolbarAboutButton, "HE_ToolbarAboutButton");
            this.HE_ToolbarAboutButton.Name = "HE_ToolbarAboutButton";
            this.HE_ToolbarAboutButton.Click += new System.EventHandler(this.HE_ToolbarAboutButton_Click);
            // 
            // HE_MainMenu
            // 
            this.HE_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HE_MenuFile,
            this.HE_MenuAdvanced,
            this.HE_MenuHelp});
            resources.ApplyResources(this.HE_MainMenu, "HE_MainMenu");
            this.HE_MainMenu.Name = "HE_MainMenu";
            // 
            // HE_MenuFile
            // 
            this.HE_MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HE_MenuRefreshItem,
            this.HE_MenuSaveItem,
            this.HE_MenuSeparator1Item,
            this.HE_MenuOptionsItem,
            this.HE_MenuQuitItem});
            this.HE_MenuFile.Name = "HE_MenuFile";
            resources.ApplyResources(this.HE_MenuFile, "HE_MenuFile");
            // 
            // HE_MenuRefreshItem
            // 
            this.HE_MenuRefreshItem.Image = global::mhed.gui.Properties.Resources.Refresh;
            this.HE_MenuRefreshItem.Name = "HE_MenuRefreshItem";
            resources.ApplyResources(this.HE_MenuRefreshItem, "HE_MenuRefreshItem");
            this.HE_MenuRefreshItem.Click += new System.EventHandler(this.HE_MenuRefreshItem_Click);
            // 
            // HE_MenuSaveItem
            // 
            this.HE_MenuSaveItem.Image = global::mhed.gui.Properties.Resources.Save;
            this.HE_MenuSaveItem.Name = "HE_MenuSaveItem";
            resources.ApplyResources(this.HE_MenuSaveItem, "HE_MenuSaveItem");
            this.HE_MenuSaveItem.Click += new System.EventHandler(this.HE_MenuSaveItem_Click);
            // 
            // HE_MenuSeparator1Item
            // 
            this.HE_MenuSeparator1Item.Name = "HE_MenuSeparator1Item";
            resources.ApplyResources(this.HE_MenuSeparator1Item, "HE_MenuSeparator1Item");
            // 
            // HE_MenuOptionsItem
            // 
            this.HE_MenuOptionsItem.Image = global::mhed.gui.Properties.Resources.Options;
            this.HE_MenuOptionsItem.Name = "HE_MenuOptionsItem";
            resources.ApplyResources(this.HE_MenuOptionsItem, "HE_MenuOptionsItem");
            this.HE_MenuOptionsItem.Click += new System.EventHandler(this.HE_MenuOptionsItem_Click);
            // 
            // HE_MenuQuitItem
            // 
            this.HE_MenuQuitItem.Image = global::mhed.gui.Properties.Resources.Exit;
            this.HE_MenuQuitItem.Name = "HE_MenuQuitItem";
            resources.ApplyResources(this.HE_MenuQuitItem, "HE_MenuQuitItem");
            this.HE_MenuQuitItem.Click += new System.EventHandler(this.HE_MenuQuitItem_Click);
            // 
            // HE_MenuAdvanced
            // 
            this.HE_MenuAdvanced.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HE_MenuRestoreDefaultsItem,
            this.HE_MenuOpenNotepadItem});
            this.HE_MenuAdvanced.Name = "HE_MenuAdvanced";
            resources.ApplyResources(this.HE_MenuAdvanced, "HE_MenuAdvanced");
            // 
            // HE_MenuRestoreDefaultsItem
            // 
            this.HE_MenuRestoreDefaultsItem.Image = global::mhed.gui.Properties.Resources.Restore;
            this.HE_MenuRestoreDefaultsItem.Name = "HE_MenuRestoreDefaultsItem";
            resources.ApplyResources(this.HE_MenuRestoreDefaultsItem, "HE_MenuRestoreDefaultsItem");
            this.HE_MenuRestoreDefaultsItem.Click += new System.EventHandler(this.HE_MenuRestoreDefaultsItem_Click);
            // 
            // HE_MenuOpenNotepadItem
            // 
            this.HE_MenuOpenNotepadItem.Image = global::mhed.gui.Properties.Resources.TextEditor;
            this.HE_MenuOpenNotepadItem.Name = "HE_MenuOpenNotepadItem";
            resources.ApplyResources(this.HE_MenuOpenNotepadItem, "HE_MenuOpenNotepadItem");
            this.HE_MenuOpenNotepadItem.Click += new System.EventHandler(this.HE_MenuOpenNotepadItem_Click);
            // 
            // HE_MenuHelp
            // 
            this.HE_MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HE_MenuShowHelpItem,
            this.HE_MenuSeparator2Item,
            this.HE_MenuCheckForUpdatesItem,
            this.HE_MenuReportItem,
            this.HE_MenuDebugLogItem,
            this.HE_MenuSeparator3Item,
            this.HE_MenuAboutItem});
            this.HE_MenuHelp.Name = "HE_MenuHelp";
            resources.ApplyResources(this.HE_MenuHelp, "HE_MenuHelp");
            // 
            // HE_MenuShowHelpItem
            // 
            this.HE_MenuShowHelpItem.Image = global::mhed.gui.Properties.Resources.Help;
            this.HE_MenuShowHelpItem.Name = "HE_MenuShowHelpItem";
            resources.ApplyResources(this.HE_MenuShowHelpItem, "HE_MenuShowHelpItem");
            this.HE_MenuShowHelpItem.Click += new System.EventHandler(this.HE_MenuShowHelpItem_Click);
            // 
            // HE_MenuSeparator2Item
            // 
            this.HE_MenuSeparator2Item.Name = "HE_MenuSeparator2Item";
            resources.ApplyResources(this.HE_MenuSeparator2Item, "HE_MenuSeparator2Item");
            // 
            // HE_MenuCheckForUpdatesItem
            // 
            this.HE_MenuCheckForUpdatesItem.Image = global::mhed.gui.Properties.Resources.Globe;
            this.HE_MenuCheckForUpdatesItem.Name = "HE_MenuCheckForUpdatesItem";
            resources.ApplyResources(this.HE_MenuCheckForUpdatesItem, "HE_MenuCheckForUpdatesItem");
            this.HE_MenuCheckForUpdatesItem.Click += new System.EventHandler(this.HE_MenuCheckForUpdatesItem_Click);
            // 
            // HE_MenuReportItem
            // 
            this.HE_MenuReportItem.Image = global::mhed.gui.Properties.Resources.Bug;
            this.HE_MenuReportItem.Name = "HE_MenuReportItem";
            resources.ApplyResources(this.HE_MenuReportItem, "HE_MenuReportItem");
            this.HE_MenuReportItem.Click += new System.EventHandler(this.HE_MenuReportItem_Click);
            // 
            // HE_MenuDebugLogItem
            // 
            this.HE_MenuDebugLogItem.Image = global::mhed.gui.Properties.Resources.Logs;
            this.HE_MenuDebugLogItem.Name = "HE_MenuDebugLogItem";
            resources.ApplyResources(this.HE_MenuDebugLogItem, "HE_MenuDebugLogItem");
            this.HE_MenuDebugLogItem.Click += new System.EventHandler(this.HE_MenuDebugLogItem_Click);
            // 
            // HE_MenuSeparator3Item
            // 
            this.HE_MenuSeparator3Item.Name = "HE_MenuSeparator3Item";
            resources.ApplyResources(this.HE_MenuSeparator3Item, "HE_MenuSeparator3Item");
            // 
            // HE_MenuAboutItem
            // 
            this.HE_MenuAboutItem.Image = global::mhed.gui.Properties.Resources.Info;
            this.HE_MenuAboutItem.Name = "HE_MenuAboutItem";
            resources.ApplyResources(this.HE_MenuAboutItem, "HE_MenuAboutItem");
            this.HE_MenuAboutItem.Click += new System.EventHandler(this.HE_MenuAboutItem_Click);
            // 
            // HE_StatusBar
            // 
            this.HE_StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HE_StatusBarHostsLocation,
            this.HE_StatusBarAppMode});
            resources.ApplyResources(this.HE_StatusBar, "HE_StatusBar");
            this.HE_StatusBar.Name = "HE_StatusBar";
            // 
            // HE_StatusBarHostsLocation
            // 
            this.HE_StatusBarHostsLocation.Name = "HE_StatusBarHostsLocation";
            resources.ApplyResources(this.HE_StatusBarHostsLocation, "HE_StatusBarHostsLocation");
            this.HE_StatusBarHostsLocation.Click += new System.EventHandler(this.HE_StatusBarHostsLocation_Click);
            this.HE_StatusBarHostsLocation.MouseEnter += new System.EventHandler(this.HE_StatusBarHostsLocation_MouseEnter);
            this.HE_StatusBarHostsLocation.MouseLeave += new System.EventHandler(this.HE_StatusBarHostsLocation_MouseLeave);
            // 
            // HE_StatusBarAppMode
            // 
            this.HE_StatusBarAppMode.Image = global::mhed.gui.Properties.Resources.RedCircle;
            resources.ApplyResources(this.HE_StatusBarAppMode, "HE_StatusBarAppMode");
            this.HE_StatusBarAppMode.Name = "HE_StatusBarAppMode";
            this.HE_StatusBarAppMode.Spring = true;
            this.HE_StatusBarAppMode.Click += new System.EventHandler(this.HE_StatusBarAppMode_Click);
            // 
            // HE_ModelViewPanel
            // 
            resources.ApplyResources(this.HE_ModelViewPanel, "HE_ModelViewPanel");
            this.HE_ModelViewPanel.Controls.Add(this.HE_ModelView);
            this.HE_ModelViewPanel.Name = "HE_ModelViewPanel";
            // 
            // HE_ModelView
            // 
            this.HE_ModelView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.HE_ModelView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HE_ModelView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HE_ModelView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HE_ModelViewColumnIP,
            this.HE_ModelViewColumnDomain});
            resources.ApplyResources(this.HE_ModelView, "HE_ModelView");
            this.HE_ModelView.Name = "HE_ModelView";
            this.HE_ModelView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.HE_ModelView_CellValidating);
            this.HE_ModelView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.HE_ModelView_DataError);
            // 
            // HE_ModelViewColumnIP
            // 
            this.HE_ModelViewColumnIP.DataPropertyName = "IPAddress";
            this.HE_ModelViewColumnIP.FillWeight = 74.92796F;
            resources.ApplyResources(this.HE_ModelViewColumnIP, "HE_ModelViewColumnIP");
            this.HE_ModelViewColumnIP.Name = "HE_ModelViewColumnIP";
            // 
            // HE_ModelViewColumnDomain
            // 
            this.HE_ModelViewColumnDomain.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HE_ModelViewColumnDomain.DataPropertyName = "Hostname";
            this.HE_ModelViewColumnDomain.FillWeight = 125.072F;
            resources.ApplyResources(this.HE_ModelViewColumnDomain, "HE_ModelViewColumnDomain");
            this.HE_ModelViewColumnDomain.Name = "HE_ModelViewColumnDomain";
            // 
            // FrmMhed
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HE_ModelViewPanel);
            this.Controls.Add(this.HE_StatusBar);
            this.Controls.Add(this.HE_MainToolbar);
            this.Controls.Add(this.HE_MainMenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.HE_MainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMhed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMhed_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMhed_FormClosed);
            this.Load += new System.EventHandler(this.FrmMhed_Load);
            this.HE_MainToolbar.ResumeLayout(false);
            this.HE_MainToolbar.PerformLayout();
            this.HE_MainMenu.ResumeLayout(false);
            this.HE_MainMenu.PerformLayout();
            this.HE_StatusBar.ResumeLayout(false);
            this.HE_StatusBar.PerformLayout();
            this.HE_ModelViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HE_ModelView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip HE_MainToolbar;
        private System.Windows.Forms.ToolStripButton HE_ToolbarRefreshButton;
        private System.Windows.Forms.ToolStripButton HE_ToolbarSaveButton;
        private System.Windows.Forms.MenuStrip HE_MainMenu;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuFile;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuRefreshItem;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuSaveItem;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuAdvanced;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuRestoreDefaultsItem;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuShowHelpItem;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuAboutItem;
        private System.Windows.Forms.StatusStrip HE_StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel HE_StatusBarHostsLocation;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuQuitItem;
        private System.Windows.Forms.ToolStripSeparator HE_ToolbarSeparator1;
        private System.Windows.Forms.ToolStripButton HE_ToolbarDeleteButton;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuOpenNotepadItem;
        private System.Windows.Forms.ToolStripButton HE_ToolbarCutButton;
        private System.Windows.Forms.ToolStripButton HE_ToolbarCopyButton;
        private System.Windows.Forms.ToolStripButton HE_ToolbarPasteButton;
        private System.Windows.Forms.ToolStripSeparator HE_ToolbarSeparator2;
        private System.Windows.Forms.ToolStripSeparator HE_ToolbarSeparator3;
        private System.Windows.Forms.ToolStripButton HE_ToolbarAboutButton;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuReportItem;
        private System.Windows.Forms.Panel HE_ModelViewPanel;
        private System.Windows.Forms.DataGridView HE_ModelView;
        private System.Windows.Forms.DataGridViewTextBoxColumn HE_ModelViewColumnIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn HE_ModelViewColumnDomain;
        private System.Windows.Forms.ToolStripSeparator HE_MenuSeparator2Item;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuDebugLogItem;
        private System.Windows.Forms.ToolStripSeparator HE_MenuSeparator3Item;
        private System.Windows.Forms.ToolStripSeparator HE_MenuSeparator1Item;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuOptionsItem;
        private System.Windows.Forms.ToolStripStatusLabel HE_StatusBarAppMode;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuCheckForUpdatesItem;
    }
}