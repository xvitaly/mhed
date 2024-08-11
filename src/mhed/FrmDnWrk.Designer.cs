namespace mhed.gui
{
    partial class FrmDnWrk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDnWrk));
            this.DN_WlcMsg = new System.Windows.Forms.Label();
            this.DN_PrgBr = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // DN_WlcMsg
            // 
            resources.ApplyResources(this.DN_WlcMsg, "DN_WlcMsg");
            this.DN_WlcMsg.Name = "DN_WlcMsg";
            // 
            // DN_PrgBr
            // 
            resources.ApplyResources(this.DN_PrgBr, "DN_PrgBr");
            this.DN_PrgBr.Name = "DN_PrgBr";
            // 
            // FrmDnWrk
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.DN_PrgBr);
            this.Controls.Add(this.DN_WlcMsg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDnWrk";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDnWrk_FormClosing);
            this.Load += new System.EventHandler(this.FrmDnWrk_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label DN_WlcMsg;
        private System.Windows.Forms.ProgressBar DN_PrgBr;
    }
}