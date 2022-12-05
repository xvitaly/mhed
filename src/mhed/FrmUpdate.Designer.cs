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
            this.UpdAppImg = new System.Windows.Forms.PictureBox();
            this.UpdAppStatus = new System.Windows.Forms.Label();
            this.UpdClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UpdAppImg)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdAppImg
            // 
            this.UpdAppImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdAppImg.Image = global::mhed.gui.Properties.Resources.IconUpdateAvailable;
            resources.ApplyResources(this.UpdAppImg, "UpdAppImg");
            this.UpdAppImg.Name = "UpdAppImg";
            this.UpdAppImg.TabStop = false;
            this.UpdAppImg.Click += new System.EventHandler(this.UpdAppStatus_Click);
            // 
            // UpdAppStatus
            // 
            this.UpdAppStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.UpdAppStatus, "UpdAppStatus");
            this.UpdAppStatus.Name = "UpdAppStatus";
            this.UpdAppStatus.Click += new System.EventHandler(this.UpdAppStatus_Click);
            // 
            // UpdClose
            // 
            this.UpdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.UpdClose, "UpdClose");
            this.UpdClose.Name = "UpdClose";
            this.UpdClose.UseVisualStyleBackColor = true;
            this.UpdClose.Click += new System.EventHandler(this.UpdClose_Click);
            // 
            // FrmUpdate
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.UpdClose;
            this.Controls.Add(this.UpdClose);
            this.Controls.Add(this.UpdAppStatus);
            this.Controls.Add(this.UpdAppImg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdate";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUpdate_FormClosing);
            this.Load += new System.EventHandler(this.FrmUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UpdAppImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox UpdAppImg;
        private System.Windows.Forms.Label UpdAppStatus;
        private System.Windows.Forms.Button UpdClose;
    }
}