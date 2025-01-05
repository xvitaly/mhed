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
            this.AF_ProductIcon = new System.Windows.Forms.PictureBox();
            this.AF_ProductName = new System.Windows.Forms.Label();
            this.AF_ProductVersion = new System.Windows.Forms.Label();
            this.AF_CompanyName = new System.Windows.Forms.Label();
            this.AF_Description = new System.Windows.Forms.TextBox();
            this.AF_License = new System.Windows.Forms.Label();
            this.AF_Copyright = new System.Windows.Forms.Label();
            this.AF_Okay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AF_ProductIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // AF_ProductIcon
            // 
            this.AF_ProductIcon.Image = global::mhed.gui.Properties.Resources.ImageAppLogo;
            resources.ApplyResources(this.AF_ProductIcon, "AF_ProductIcon");
            this.AF_ProductIcon.Name = "AF_ProductIcon";
            this.AF_ProductIcon.TabStop = false;
            // 
            // AF_ProductName
            // 
            resources.ApplyResources(this.AF_ProductName, "AF_ProductName");
            this.AF_ProductName.Name = "AF_ProductName";
            // 
            // AF_ProductVersion
            // 
            resources.ApplyResources(this.AF_ProductVersion, "AF_ProductVersion");
            this.AF_ProductVersion.Name = "AF_ProductVersion";
            // 
            // AF_CompanyName
            // 
            resources.ApplyResources(this.AF_CompanyName, "AF_CompanyName");
            this.AF_CompanyName.Name = "AF_CompanyName";
            // 
            // AF_Description
            // 
            resources.ApplyResources(this.AF_Description, "AF_Description");
            this.AF_Description.Name = "AF_Description";
            this.AF_Description.ReadOnly = true;
            this.AF_Description.TabStop = false;
            // 
            // AF_License
            // 
            resources.ApplyResources(this.AF_License, "AF_License");
            this.AF_License.Name = "AF_License";
            // 
            // AF_Copyright
            // 
            resources.ApplyResources(this.AF_Copyright, "AF_Copyright");
            this.AF_Copyright.Name = "AF_Copyright";
            // 
            // AF_Okay
            // 
            this.AF_Okay.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.AF_Okay, "AF_Okay");
            this.AF_Okay.Name = "AF_Okay";
            this.AF_Okay.UseVisualStyleBackColor = true;
            this.AF_Okay.Click += new System.EventHandler(this.AF_Okay_Click);
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.AF_Okay;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.AF_Okay;
            this.Controls.Add(this.AF_Okay);
            this.Controls.Add(this.AF_Copyright);
            this.Controls.Add(this.AF_License);
            this.Controls.Add(this.AF_Description);
            this.Controls.Add(this.AF_CompanyName);
            this.Controls.Add(this.AF_ProductVersion);
            this.Controls.Add(this.AF_ProductName);
            this.Controls.Add(this.AF_ProductIcon);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AF_ProductIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AF_ProductIcon;
        private System.Windows.Forms.Label AF_ProductName;
        private System.Windows.Forms.Label AF_ProductVersion;
        private System.Windows.Forms.Label AF_CompanyName;
        private System.Windows.Forms.TextBox AF_Description;
        private System.Windows.Forms.Label AF_License;
        private System.Windows.Forms.Label AF_Copyright;
        private System.Windows.Forms.Button AF_Okay;

    }
}
