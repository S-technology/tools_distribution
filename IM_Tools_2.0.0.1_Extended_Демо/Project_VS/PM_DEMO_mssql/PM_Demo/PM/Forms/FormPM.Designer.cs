namespace PM.Forms
{
    partial class FormPM
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPM));
            this.tabControl_main.SuspendLayout();
            this.Panel_ToolBar.SuspendLayout();
            this.bd_Navigator.SuspendLayout();
            this.Panel_Middle.SuspendLayout();
            this.Panel_All.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage_card
            // 
//            this.tabPage_card.Size = new System.Drawing.Size(847, 482);
            // 
            // bd_Navigator
            // 
//            this.bd_Navigator.Size = new System.Drawing.Size(490, 25);
            // 
            // FormPM
            // 
            this.ClientSize = new System.Drawing.Size(855, 536);
            this.Name = "FormPM";
            this.Text = "Предок для  форм PM";
            this.tabControl_main.ResumeLayout(false);
            this.Panel_ToolBar.ResumeLayout(false);
            this.Panel_ToolBar.PerformLayout();
            this.bd_Navigator.ResumeLayout(false);
            this.Panel_Middle.ResumeLayout(false);
            this.Panel_Middle.PerformLayout();
            this.Panel_All.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
