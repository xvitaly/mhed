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
            this.HE_MainMenu = new System.Windows.Forms.MenuStrip();
            this.HE_MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuRefreshItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuSaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuSeparator1Item = new System.Windows.Forms.ToolStripSeparator();
            this.HE_MenuImportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuExportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuSeparator2Item = new System.Windows.Forms.ToolStripSeparator();
            this.HE_MenuOptionsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuQuitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuCutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuCopyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuPasteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuAdvanced = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuRestoreDefaultsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuOpenNotepadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuEncodingItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuEncodingDefaultItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuEncodingUnicodeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuShowHelpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuSeparator3Item = new System.Windows.Forms.ToolStripSeparator();
            this.HE_MenuCheckForUpdatesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuReportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuDebugLogItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_MenuSeparator4Item = new System.Windows.Forms.ToolStripSeparator();
            this.HE_MenuAboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_StatusBar = new System.Windows.Forms.StatusStrip();
            this.HE_StatusBarHostsLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.HE_StatusBarAppMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.HE_ModelViewPanel = new System.Windows.Forms.Panel();
            this.HE_ModelView = new System.Windows.Forms.DataGridView();
            this.HE_ModelViewColumnIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HE_ModelViewColumnDomain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HE_ModelViewColumnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HE_ContextMenu = new System.Windows.Forms.ContextMenuStrip();
            this.HE_ConextMenuCutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_ConextMenuCopyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_ConextMenuPasteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_ConextMenuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HE_ExportDialog = new System.Windows.Forms.SaveFileDialog();
            this.HE_ImportDialog = new System.Windows.Forms.OpenFileDialog();
            this.HE_MainToolbar.SuspendLayout();
            this.HE_MainMenu.SuspendLayout();
            this.HE_StatusBar.SuspendLayout();
            this.HE_ModelViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HE_ModelView)).BeginInit();
            this.HE_ContextMenu.SuspendLayout();
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
            this.HE_ToolbarDeleteButton});
            resources.ApplyResources(this.HE_MainToolbar, "HE_MainToolbar");
            this.HE_MainToolbar.Name = "HE_MainToolbar";
            // 
            // HE_ToolbarRefreshButton
            // 
            this.HE_ToolbarRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HE_ToolbarRefreshButton.Image = global::mhed.gui.Properties.Resources.IconRefresh;
            resources.ApplyResources(this.HE_ToolbarRefreshButton, "HE_ToolbarRefreshButton");
            this.HE_ToolbarRefreshButton.Name = "HE_ToolbarRefreshButton";
            this.HE_ToolbarRefreshButton.Click += new System.EventHandler(this.HE_ToolbarRefreshButton_Click);
            // 
            // HE_ToolbarSaveButton
            // 
            this.HE_ToolbarSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HE_ToolbarSaveButton.Image = global::mhed.gui.Properties.Resources.IconSave;
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
            this.HE_ToolbarCutButton.Image = global::mhed.gui.Properties.Resources.IconCut;
            resources.ApplyResources(this.HE_ToolbarCutButton, "HE_ToolbarCutButton");
            this.HE_ToolbarCutButton.Name = "HE_ToolbarCutButton";
            this.HE_ToolbarCutButton.Click += new System.EventHandler(this.HE_ToolbarCutButton_Click);
            // 
            // HE_ToolbarCopyButton
            // 
            this.HE_ToolbarCopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HE_ToolbarCopyButton.Image = global::mhed.gui.Properties.Resources.IconCopy;
            resources.ApplyResources(this.HE_ToolbarCopyButton, "HE_ToolbarCopyButton");
            this.HE_ToolbarCopyButton.Name = "HE_ToolbarCopyButton";
            this.HE_ToolbarCopyButton.Click += new System.EventHandler(this.HE_ToolbarCopyButton_Click);
            // 
            // HE_ToolbarPasteButton
            // 
            this.HE_ToolbarPasteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HE_ToolbarPasteButton.Image = global::mhed.gui.Properties.Resources.IconPaste;
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
            this.HE_ToolbarDeleteButton.Image = global::mhed.gui.Properties.Resources.IconDelete;
            resources.ApplyResources(this.HE_ToolbarDeleteButton, "HE_ToolbarDeleteButton");
            this.HE_ToolbarDeleteButton.Name = "HE_ToolbarDeleteButton";
            this.HE_ToolbarDeleteButton.Click += new System.EventHandler(this.HE_ToolbarDeleteButton_Click);
            // 
            // HE_MainMenu
            // 
            this.HE_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HE_MenuFile,
            this.HE_MenuEdit,
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
            this.HE_MenuImportItem,
            this.HE_MenuExportItem,
            this.HE_MenuSeparator2Item,
            this.HE_MenuOptionsItem,
            this.HE_MenuQuitItem});
            this.HE_MenuFile.Name = "HE_MenuFile";
            resources.ApplyResources(this.HE_MenuFile, "HE_MenuFile");
            // 
            // HE_MenuRefreshItem
            // 
            this.HE_MenuRefreshItem.Image = global::mhed.gui.Properties.Resources.IconRefresh;
            this.HE_MenuRefreshItem.Name = "HE_MenuRefreshItem";
            resources.ApplyResources(this.HE_MenuRefreshItem, "HE_MenuRefreshItem");
            this.HE_MenuRefreshItem.Click += new System.EventHandler(this.HE_MenuRefreshItem_Click);
            // 
            // HE_MenuSaveItem
            // 
            this.HE_MenuSaveItem.Image = global::mhed.gui.Properties.Resources.IconSave;
            this.HE_MenuSaveItem.Name = "HE_MenuSaveItem";
            resources.ApplyResources(this.HE_MenuSaveItem, "HE_MenuSaveItem");
            this.HE_MenuSaveItem.Click += new System.EventHandler(this.HE_MenuSaveItem_Click);
            // 
            // HE_MenuSeparator1Item
            // 
            this.HE_MenuSeparator1Item.Name = "HE_MenuSeparator1Item";
            resources.ApplyResources(this.HE_MenuSeparator1Item, "HE_MenuSeparator1Item");
            // 
            // HE_MenuImportItem
            // 
            this.HE_MenuImportItem.Name = "HE_MenuImportItem";
            resources.ApplyResources(this.HE_MenuImportItem, "HE_MenuImportItem");
            this.HE_MenuImportItem.Click += new System.EventHandler(this.HE_MenuImportItem_Click);
            // 
            // HE_MenuExportItem
            // 
            this.HE_MenuExportItem.Name = "HE_MenuExportItem";
            resources.ApplyResources(this.HE_MenuExportItem, "HE_MenuExportItem");
            this.HE_MenuExportItem.Click += new System.EventHandler(this.HE_MenuExportItem_Click);
            // 
            // HE_MenuSeparator2Item
            // 
            this.HE_MenuSeparator2Item.Name = "HE_MenuSeparator2Item";
            resources.ApplyResources(this.HE_MenuSeparator2Item, "HE_MenuSeparator2Item");
            // 
            // HE_MenuOptionsItem
            // 
            this.HE_MenuOptionsItem.Image = global::mhed.gui.Properties.Resources.IconOptions;
            this.HE_MenuOptionsItem.Name = "HE_MenuOptionsItem";
            resources.ApplyResources(this.HE_MenuOptionsItem, "HE_MenuOptionsItem");
            this.HE_MenuOptionsItem.Click += new System.EventHandler(this.HE_MenuOptionsItem_Click);
            // 
            // HE_MenuQuitItem
            // 
            this.HE_MenuQuitItem.Image = global::mhed.gui.Properties.Resources.IconExit;
            this.HE_MenuQuitItem.Name = "HE_MenuQuitItem";
            resources.ApplyResources(this.HE_MenuQuitItem, "HE_MenuQuitItem");
            this.HE_MenuQuitItem.Click += new System.EventHandler(this.HE_MenuQuitItem_Click);
            // 
            // HE_MenuEdit
            // 
            this.HE_MenuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HE_MenuCutItem,
            this.HE_MenuCopyItem,
            this.HE_MenuPasteItem,
            this.HE_MenuDeleteItem});
            this.HE_MenuEdit.Name = "HE_MenuEdit";
            resources.ApplyResources(this.HE_MenuEdit, "HE_MenuEdit");
            // 
            // HE_MenuCutItem
            // 
            this.HE_MenuCutItem.Image = global::mhed.gui.Properties.Resources.IconCut;
            this.HE_MenuCutItem.Name = "HE_MenuCutItem";
            resources.ApplyResources(this.HE_MenuCutItem, "HE_MenuCutItem");
            this.HE_MenuCutItem.Click += new System.EventHandler(this.HE_MenuCutItem_Click);
            // 
            // HE_MenuCopyItem
            // 
            this.HE_MenuCopyItem.Image = global::mhed.gui.Properties.Resources.IconCopy;
            this.HE_MenuCopyItem.Name = "HE_MenuCopyItem";
            resources.ApplyResources(this.HE_MenuCopyItem, "HE_MenuCopyItem");
            this.HE_MenuCopyItem.Click += new System.EventHandler(this.HE_MenuCopyItem_Click);
            // 
            // HE_MenuPasteItem
            // 
            this.HE_MenuPasteItem.Image = global::mhed.gui.Properties.Resources.IconPaste;
            this.HE_MenuPasteItem.Name = "HE_MenuPasteItem";
            resources.ApplyResources(this.HE_MenuPasteItem, "HE_MenuPasteItem");
            this.HE_MenuPasteItem.Click += new System.EventHandler(this.HE_MenuPasteItem_Click);
            // 
            // HE_MenuDeleteItem
            // 
            this.HE_MenuDeleteItem.Image = global::mhed.gui.Properties.Resources.IconDelete;
            this.HE_MenuDeleteItem.Name = "HE_MenuDeleteItem";
            resources.ApplyResources(this.HE_MenuDeleteItem, "HE_MenuDeleteItem");
            this.HE_MenuDeleteItem.Click += new System.EventHandler(this.HE_MenuDeleteItem_Click);
            // 
            // HE_MenuAdvanced
            // 
            this.HE_MenuAdvanced.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HE_MenuRestoreDefaultsItem,
            this.HE_MenuOpenNotepadItem,
            this.HE_MenuEncodingItem});
            this.HE_MenuAdvanced.Name = "HE_MenuAdvanced";
            resources.ApplyResources(this.HE_MenuAdvanced, "HE_MenuAdvanced");
            // 
            // HE_MenuRestoreDefaultsItem
            // 
            this.HE_MenuRestoreDefaultsItem.Image = global::mhed.gui.Properties.Resources.IconRestore;
            this.HE_MenuRestoreDefaultsItem.Name = "HE_MenuRestoreDefaultsItem";
            resources.ApplyResources(this.HE_MenuRestoreDefaultsItem, "HE_MenuRestoreDefaultsItem");
            this.HE_MenuRestoreDefaultsItem.Click += new System.EventHandler(this.HE_MenuRestoreDefaultsItem_Click);
            // 
            // HE_MenuOpenNotepadItem
            // 
            this.HE_MenuOpenNotepadItem.Image = global::mhed.gui.Properties.Resources.IconTextEditor;
            this.HE_MenuOpenNotepadItem.Name = "HE_MenuOpenNotepadItem";
            resources.ApplyResources(this.HE_MenuOpenNotepadItem, "HE_MenuOpenNotepadItem");
            this.HE_MenuOpenNotepadItem.Click += new System.EventHandler(this.HE_MenuOpenNotepadItem_Click);
            // 
            // HE_MenuEncodingItem
            // 
            this.HE_MenuEncodingItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HE_MenuEncodingDefaultItem,
            this.HE_MenuEncodingUnicodeItem});
            this.HE_MenuEncodingItem.Name = "HE_MenuEncodingItem";
            resources.ApplyResources(this.HE_MenuEncodingItem, "HE_MenuEncodingItem");
            // 
            // HE_MenuEncodingDefaultItem
            // 
            this.HE_MenuEncodingDefaultItem.Name = "HE_MenuEncodingDefaultItem";
            resources.ApplyResources(this.HE_MenuEncodingDefaultItem, "HE_MenuEncodingDefaultItem");
            this.HE_MenuEncodingDefaultItem.Click += new System.EventHandler(this.HE_MenuEncodingDefaultItem_Click);
            // 
            // HE_MenuEncodingUnicodeItem
            // 
            this.HE_MenuEncodingUnicodeItem.Name = "HE_MenuEncodingUnicodeItem";
            resources.ApplyResources(this.HE_MenuEncodingUnicodeItem, "HE_MenuEncodingUnicodeItem");
            this.HE_MenuEncodingUnicodeItem.Click += new System.EventHandler(this.HE_MenuEncodingUnicodeItem_Click);
            // 
            // HE_MenuHelp
            // 
            this.HE_MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HE_MenuShowHelpItem,
            this.HE_MenuSeparator3Item,
            this.HE_MenuCheckForUpdatesItem,
            this.HE_MenuReportItem,
            this.HE_MenuDebugLogItem,
            this.HE_MenuSeparator4Item,
            this.HE_MenuAboutItem});
            this.HE_MenuHelp.Name = "HE_MenuHelp";
            resources.ApplyResources(this.HE_MenuHelp, "HE_MenuHelp");
            // 
            // HE_MenuShowHelpItem
            // 
            this.HE_MenuShowHelpItem.Image = global::mhed.gui.Properties.Resources.IconHelp;
            this.HE_MenuShowHelpItem.Name = "HE_MenuShowHelpItem";
            resources.ApplyResources(this.HE_MenuShowHelpItem, "HE_MenuShowHelpItem");
            this.HE_MenuShowHelpItem.Click += new System.EventHandler(this.HE_MenuShowHelpItem_Click);
            // 
            // HE_MenuSeparator3Item
            // 
            this.HE_MenuSeparator3Item.Name = "HE_MenuSeparator3Item";
            resources.ApplyResources(this.HE_MenuSeparator3Item, "HE_MenuSeparator3Item");
            // 
            // HE_MenuCheckForUpdatesItem
            // 
            this.HE_MenuCheckForUpdatesItem.Image = global::mhed.gui.Properties.Resources.IconGlobe;
            this.HE_MenuCheckForUpdatesItem.Name = "HE_MenuCheckForUpdatesItem";
            resources.ApplyResources(this.HE_MenuCheckForUpdatesItem, "HE_MenuCheckForUpdatesItem");
            this.HE_MenuCheckForUpdatesItem.Click += new System.EventHandler(this.HE_MenuCheckForUpdatesItem_Click);
            // 
            // HE_MenuReportItem
            // 
            this.HE_MenuReportItem.Image = global::mhed.gui.Properties.Resources.IconBug;
            this.HE_MenuReportItem.Name = "HE_MenuReportItem";
            resources.ApplyResources(this.HE_MenuReportItem, "HE_MenuReportItem");
            this.HE_MenuReportItem.Click += new System.EventHandler(this.HE_MenuReportItem_Click);
            // 
            // HE_MenuDebugLogItem
            // 
            this.HE_MenuDebugLogItem.Image = global::mhed.gui.Properties.Resources.IconLogs;
            this.HE_MenuDebugLogItem.Name = "HE_MenuDebugLogItem";
            resources.ApplyResources(this.HE_MenuDebugLogItem, "HE_MenuDebugLogItem");
            this.HE_MenuDebugLogItem.Click += new System.EventHandler(this.HE_MenuDebugLogItem_Click);
            // 
            // HE_MenuSeparator4Item
            // 
            this.HE_MenuSeparator4Item.Name = "HE_MenuSeparator4Item";
            resources.ApplyResources(this.HE_MenuSeparator4Item, "HE_MenuSeparator4Item");
            // 
            // HE_MenuAboutItem
            // 
            this.HE_MenuAboutItem.Image = global::mhed.gui.Properties.Resources.IconInfo;
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
            this.HE_StatusBarAppMode.Image = global::mhed.gui.Properties.Resources.IconRedCircle;
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
            this.HE_ModelViewColumnDomain,
            this.HE_ModelViewColumnComment});
            this.HE_ModelView.ContextMenuStrip = this.HE_ContextMenu;
            resources.ApplyResources(this.HE_ModelView, "HE_ModelView");
            this.HE_ModelView.Name = "HE_ModelView";
            this.HE_ModelView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.HE_ModelView_DataError);
            // 
            // HE_ModelViewColumnIP
            // 
            this.HE_ModelViewColumnIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HE_ModelViewColumnIP.DataPropertyName = "IPAddr";
            this.HE_ModelViewColumnIP.FillWeight = 90F;
            resources.ApplyResources(this.HE_ModelViewColumnIP, "HE_ModelViewColumnIP");
            this.HE_ModelViewColumnIP.Name = "HE_ModelViewColumnIP";
            // 
            // HE_ModelViewColumnDomain
            // 
            this.HE_ModelViewColumnDomain.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HE_ModelViewColumnDomain.DataPropertyName = "Hostname";
            this.HE_ModelViewColumnDomain.FillWeight = 125F;
            resources.ApplyResources(this.HE_ModelViewColumnDomain, "HE_ModelViewColumnDomain");
            this.HE_ModelViewColumnDomain.Name = "HE_ModelViewColumnDomain";
            // 
            // HE_ModelViewColumnComment
            // 
            this.HE_ModelViewColumnComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HE_ModelViewColumnComment.DataPropertyName = "Comment";
            resources.ApplyResources(this.HE_ModelViewColumnComment, "HE_ModelViewColumnComment");
            this.HE_ModelViewColumnComment.Name = "HE_ModelViewColumnComment";
            // 
            // HE_ContextMenu
            // 
            this.HE_ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HE_ConextMenuCutItem,
            this.HE_ConextMenuCopyItem,
            this.HE_ConextMenuPasteItem,
            this.HE_ConextMenuDeleteItem});
            this.HE_ContextMenu.Name = "HE_ContextMenu";
            resources.ApplyResources(this.HE_ContextMenu, "HE_ContextMenu");
            // 
            // HE_ConextMenuCutItem
            // 
            this.HE_ConextMenuCutItem.Image = global::mhed.gui.Properties.Resources.IconCut;
            this.HE_ConextMenuCutItem.Name = "HE_ConextMenuCutItem";
            resources.ApplyResources(this.HE_ConextMenuCutItem, "HE_ConextMenuCutItem");
            this.HE_ConextMenuCutItem.Click += new System.EventHandler(this.HE_ConextMenuCutItem_Click);
            // 
            // HE_ConextMenuCopyItem
            // 
            this.HE_ConextMenuCopyItem.Image = global::mhed.gui.Properties.Resources.IconCopy;
            this.HE_ConextMenuCopyItem.Name = "HE_ConextMenuCopyItem";
            resources.ApplyResources(this.HE_ConextMenuCopyItem, "HE_ConextMenuCopyItem");
            this.HE_ConextMenuCopyItem.Click += new System.EventHandler(this.HE_ConextMenuCopyItem_Click);
            // 
            // HE_ConextMenuPasteItem
            // 
            this.HE_ConextMenuPasteItem.Image = global::mhed.gui.Properties.Resources.IconPaste;
            this.HE_ConextMenuPasteItem.Name = "HE_ConextMenuPasteItem";
            resources.ApplyResources(this.HE_ConextMenuPasteItem, "HE_ConextMenuPasteItem");
            this.HE_ConextMenuPasteItem.Click += new System.EventHandler(this.HE_ConextMenuPasteItem_Click);
            // 
            // HE_ConextMenuDeleteItem
            // 
            this.HE_ConextMenuDeleteItem.Image = global::mhed.gui.Properties.Resources.IconDelete;
            this.HE_ConextMenuDeleteItem.Name = "HE_ConextMenuDeleteItem";
            resources.ApplyResources(this.HE_ConextMenuDeleteItem, "HE_ConextMenuDeleteItem");
            this.HE_ConextMenuDeleteItem.Click += new System.EventHandler(this.HE_ConextMenuDeleteItem_Click);
            // 
            // HE_ExportDialog
            // 
            this.HE_ExportDialog.DefaultExt = "txt";
            resources.ApplyResources(this.HE_ExportDialog, "HE_ExportDialog");
            // 
            // HE_ImportDialog
            // 
            resources.ApplyResources(this.HE_ImportDialog, "HE_ImportDialog");
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
            this.HE_ContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem HE_MenuReportItem;
        private System.Windows.Forms.Panel HE_ModelViewPanel;
        private System.Windows.Forms.DataGridView HE_ModelView;
        private System.Windows.Forms.ToolStripSeparator HE_MenuSeparator3Item;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuDebugLogItem;
        private System.Windows.Forms.ToolStripSeparator HE_MenuSeparator4Item;
        private System.Windows.Forms.ToolStripSeparator HE_MenuSeparator1Item;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuOptionsItem;
        private System.Windows.Forms.ToolStripStatusLabel HE_StatusBarAppMode;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuCheckForUpdatesItem;
        private System.Windows.Forms.ContextMenuStrip HE_ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem HE_ConextMenuCutItem;
        private System.Windows.Forms.ToolStripMenuItem HE_ConextMenuCopyItem;
        private System.Windows.Forms.ToolStripMenuItem HE_ConextMenuPasteItem;
        private System.Windows.Forms.ToolStripMenuItem HE_ConextMenuDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuEdit;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuCutItem;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuCopyItem;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuPasteItem;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuDeleteItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn HE_ModelViewColumnIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn HE_ModelViewColumnDomain;
        private System.Windows.Forms.DataGridViewTextBoxColumn HE_ModelViewColumnComment;
        private System.Windows.Forms.SaveFileDialog HE_ExportDialog;
        private System.Windows.Forms.OpenFileDialog HE_ImportDialog;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuImportItem;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuExportItem;
        private System.Windows.Forms.ToolStripSeparator HE_MenuSeparator2Item;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuEncodingItem;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuEncodingDefaultItem;
        private System.Windows.Forms.ToolStripMenuItem HE_MenuEncodingUnicodeItem;
    }
}