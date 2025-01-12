namespace mhed.gui
{
    partial class FrmUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdate));
            this.UP_Icon = new System.Windows.Forms.PictureBox();
            this.UP_Status = new System.Windows.Forms.Label();
            this.UP_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UP_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // UP_Icon
            // 
            this.UP_Icon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UP_Icon.Image = global::mhed.gui.Properties.Resources.IconUpdateChecking;
            resources.ApplyResources(this.UP_Icon, "UP_Icon");
            this.UP_Icon.Name = "UP_Icon";
            this.UP_Icon.TabStop = false;
            this.UP_Icon.Click += new System.EventHandler(this.UP_Status_Click);
            // 
            // UP_Status
            // 
            this.UP_Status.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.UP_Status, "UP_Status");
            this.UP_Status.Name = "UP_Status";
            this.UP_Status.Click += new System.EventHandler(this.UP_Status_Click);
            // 
            // UP_Close
            // 
            this.UP_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.UP_Close, "UP_Close");
            this.UP_Close.Name = "UP_Close";
            this.UP_Close.UseVisualStyleBackColor = true;
            this.UP_Close.Click += new System.EventHandler(this.UP_Close_Click);
            // 
            // FrmUpdate
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.UP_Close;
            this.Controls.Add(this.UP_Close);
            this.Controls.Add(this.UP_Status);
            this.Controls.Add(this.UP_Icon);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUpdate_FormClosing);
            this.Load += new System.EventHandler(this.FrmUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UP_Icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox UP_Icon;
        private System.Windows.Forms.Label UP_Status;
        private System.Windows.Forms.Button UP_Close;
    }
}