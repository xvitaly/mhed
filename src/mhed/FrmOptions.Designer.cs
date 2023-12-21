namespace mhed.gui
{
    partial class FrmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptions));
            this.MO_Okay = new System.Windows.Forms.Button();
            this.MO_Cancel = new System.Windows.Forms.Button();
            this.MO_TC = new System.Windows.Forms.TabControl();
            this.MO_TP1 = new System.Windows.Forms.TabPage();
            this.MO_PreserveFormState = new System.Windows.Forms.CheckBox();
            this.MO_ConfirmExit = new System.Windows.Forms.CheckBox();
            this.MO_TP2 = new System.Windows.Forms.TabPage();
            this.MO_AutoCheckUpdates = new System.Windows.Forms.CheckBox();
            this.MO_FindTextEd = new System.Windows.Forms.Button();
            this.MO_TextEdBin = new System.Windows.Forms.TextBox();
            this.L_MO_TextEdBin = new System.Windows.Forms.Label();
            this.MO_SearchBin = new System.Windows.Forms.OpenFileDialog();
            this.MO_TC.SuspendLayout();
            this.MO_TP1.SuspendLayout();
            this.MO_TP2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MO_Okay
            // 
            resources.ApplyResources(this.MO_Okay, "MO_Okay");
            this.MO_Okay.Name = "MO_Okay";
            this.MO_Okay.UseVisualStyleBackColor = true;
            this.MO_Okay.Click += new System.EventHandler(this.MO_Okay_Click);
            // 
            // MO_Cancel
            // 
            this.MO_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.MO_Cancel, "MO_Cancel");
            this.MO_Cancel.Name = "MO_Cancel";
            this.MO_Cancel.UseVisualStyleBackColor = true;
            this.MO_Cancel.Click += new System.EventHandler(this.MO_Cancel_Click);
            // 
            // MO_TC
            // 
            this.MO_TC.Controls.Add(this.MO_TP1);
            this.MO_TC.Controls.Add(this.MO_TP2);
            resources.ApplyResources(this.MO_TC, "MO_TC");
            this.MO_TC.Name = "MO_TC";
            this.MO_TC.SelectedIndex = 0;
            // 
            // MO_TP1
            // 
            this.MO_TP1.Controls.Add(this.MO_PreserveFormState);
            this.MO_TP1.Controls.Add(this.MO_ConfirmExit);
            resources.ApplyResources(this.MO_TP1, "MO_TP1");
            this.MO_TP1.Name = "MO_TP1";
            this.MO_TP1.UseVisualStyleBackColor = true;
            // 
            // MO_PreserveFormState
            // 
            resources.ApplyResources(this.MO_PreserveFormState, "MO_PreserveFormState");
            this.MO_PreserveFormState.Name = "MO_PreserveFormState";
            this.MO_PreserveFormState.UseVisualStyleBackColor = true;
            // 
            // MO_ConfirmExit
            // 
            resources.ApplyResources(this.MO_ConfirmExit, "MO_ConfirmExit");
            this.MO_ConfirmExit.Name = "MO_ConfirmExit";
            this.MO_ConfirmExit.UseVisualStyleBackColor = true;
            // 
            // MO_TP2
            // 
            this.MO_TP2.Controls.Add(this.MO_AutoCheckUpdates);
            this.MO_TP2.Controls.Add(this.MO_FindTextEd);
            this.MO_TP2.Controls.Add(this.MO_TextEdBin);
            this.MO_TP2.Controls.Add(this.L_MO_TextEdBin);
            resources.ApplyResources(this.MO_TP2, "MO_TP2");
            this.MO_TP2.Name = "MO_TP2";
            this.MO_TP2.UseVisualStyleBackColor = true;
            // 
            // MO_AutoCheckUpdates
            // 
            resources.ApplyResources(this.MO_AutoCheckUpdates, "MO_AutoCheckUpdates");
            this.MO_AutoCheckUpdates.Name = "MO_AutoCheckUpdates";
            this.MO_AutoCheckUpdates.UseVisualStyleBackColor = true;
            // 
            // MO_FindTextEd
            // 
            resources.ApplyResources(this.MO_FindTextEd, "MO_FindTextEd");
            this.MO_FindTextEd.Name = "MO_FindTextEd";
            this.MO_FindTextEd.UseVisualStyleBackColor = true;
            this.MO_FindTextEd.Click += new System.EventHandler(this.MO_FindTextEd_Click);
            // 
            // MO_TextEdBin
            // 
            resources.ApplyResources(this.MO_TextEdBin, "MO_TextEdBin");
            this.MO_TextEdBin.Name = "MO_TextEdBin";
            // 
            // L_MO_TextEdBin
            // 
            resources.ApplyResources(this.L_MO_TextEdBin, "L_MO_TextEdBin");
            this.L_MO_TextEdBin.Name = "L_MO_TextEdBin";
            // 
            // MO_SearchBin
            // 
            resources.ApplyResources(this.MO_SearchBin, "MO_SearchBin");
            // 
            // FrmOptions
            // 
            this.AcceptButton = this.MO_Okay;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.MO_Cancel;
            this.ControlBox = false;
            this.Controls.Add(this.MO_TC);
            this.Controls.Add(this.MO_Cancel);
            this.Controls.Add(this.MO_Okay);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOptions";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmOptions_Load);
            this.MO_TC.ResumeLayout(false);
            this.MO_TP1.ResumeLayout(false);
            this.MO_TP2.ResumeLayout(false);
            this.MO_TP2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MO_Okay;
        private System.Windows.Forms.Button MO_Cancel;
        private System.Windows.Forms.TabControl MO_TC;
        private System.Windows.Forms.TabPage MO_TP1;
        private System.Windows.Forms.CheckBox MO_PreserveFormState;
        private System.Windows.Forms.CheckBox MO_ConfirmExit;
        private System.Windows.Forms.TabPage MO_TP2;
        private System.Windows.Forms.TextBox MO_TextEdBin;
        private System.Windows.Forms.Label L_MO_TextEdBin;
        private System.Windows.Forms.Button MO_FindTextEd;
        private System.Windows.Forms.OpenFileDialog MO_SearchBin;
        private System.Windows.Forms.CheckBox MO_AutoCheckUpdates;
    }
}