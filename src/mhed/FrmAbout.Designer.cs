namespace mhed.gui
{
    partial class FrmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.AHE_AppIcon = new System.Windows.Forms.PictureBox();
            this.AHE_AppName = new System.Windows.Forms.Label();
            this.AHE_Version = new System.Windows.Forms.Label();
            this.AHE_CompanyName = new System.Windows.Forms.Label();
            this.AHE_Description = new System.Windows.Forms.TextBox();
            this.AHE_License = new System.Windows.Forms.Label();
            this.AHE_Copyright = new System.Windows.Forms.Label();
            this.AHE_Okay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AHE_AppIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // AHE_AppIcon
            // 
            this.AHE_AppIcon.Image = global::mhed.gui.Properties.Resources.ImageAppLogo;
            resources.ApplyResources(this.AHE_AppIcon, "AHE_AppIcon");
            this.AHE_AppIcon.Name = "AHE_AppIcon";
            this.AHE_AppIcon.TabStop = false;
            // 
            // AHE_AppName
            // 
            resources.ApplyResources(this.AHE_AppName, "AHE_AppName");
            this.AHE_AppName.Name = "AHE_AppName";
            // 
            // AHE_Version
            // 
            resources.ApplyResources(this.AHE_Version, "AHE_Version");
            this.AHE_Version.Name = "AHE_Version";
            // 
            // AHE_CompanyName
            // 
            resources.ApplyResources(this.AHE_CompanyName, "AHE_CompanyName");
            this.AHE_CompanyName.Name = "AHE_CompanyName";
            // 
            // AHE_Description
            // 
            resources.ApplyResources(this.AHE_Description, "AHE_Description");
            this.AHE_Description.Name = "AHE_Description";
            this.AHE_Description.ReadOnly = true;
            this.AHE_Description.TabStop = false;
            // 
            // AHE_License
            // 
            resources.ApplyResources(this.AHE_License, "AHE_License");
            this.AHE_License.Name = "AHE_License";
            // 
            // AHE_Copyright
            // 
            resources.ApplyResources(this.AHE_Copyright, "AHE_Copyright");
            this.AHE_Copyright.Name = "AHE_Copyright";
            // 
            // AHE_Okay
            // 
            this.AHE_Okay.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.AHE_Okay, "AHE_Okay");
            this.AHE_Okay.Name = "AHE_Okay";
            this.AHE_Okay.UseVisualStyleBackColor = true;
            this.AHE_Okay.Click += new System.EventHandler(this.AHE_Okay_Click);
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.AHE_Okay;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.AHE_Okay;
            this.Controls.Add(this.AHE_Okay);
            this.Controls.Add(this.AHE_Copyright);
            this.Controls.Add(this.AHE_License);
            this.Controls.Add(this.AHE_Description);
            this.Controls.Add(this.AHE_CompanyName);
            this.Controls.Add(this.AHE_Version);
            this.Controls.Add(this.AHE_AppName);
            this.Controls.Add(this.AHE_AppIcon);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AHE_AppIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AHE_AppIcon;
        private System.Windows.Forms.Label AHE_AppName;
        private System.Windows.Forms.Label AHE_Version;
        private System.Windows.Forms.Label AHE_CompanyName;
        private System.Windows.Forms.TextBox AHE_Description;
        private System.Windows.Forms.Label AHE_License;
        private System.Windows.Forms.Label AHE_Copyright;
        private System.Windows.Forms.Button AHE_Okay;

    }
}
