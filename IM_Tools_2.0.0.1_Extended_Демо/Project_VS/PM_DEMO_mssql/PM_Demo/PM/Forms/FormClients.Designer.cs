namespace PM.Forms
{
    partial class FormClients
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
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.tabControl_main.SuspendLayout();
            this.tabPage_card.SuspendLayout();
            this.Panel_ToolBar.SuspendLayout();
            this.Panel_Middle.SuspendLayout();
            this.Panel_All.SuspendLayout();
            this.Panel_Low.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_main
            // 
            this.tabControl_main.Size = new System.Drawing.Size(854, 506);
            // 
            // tabPage_list
            // 
            this.tabPage_list.Size = new System.Drawing.Size(846, 482);
            // 
            // tabPage_card
            // 
            this.tabPage_card.Controls.Add(this.textBox_Name);
            this.tabPage_card.Size = new System.Drawing.Size(847, 482);
            // 
            // Panel_ToolBar
            // 
            this.Panel_ToolBar.Size = new System.Drawing.Size(854, 30);
            // 
            // Panel_Middle
            // 
            this.Panel_Middle.Size = new System.Drawing.Size(854, 506);
            // 
            // Panel_All
            // 
            this.Panel_All.Size = new System.Drawing.Size(854, 536);
            // 
            // Panel_Top
            // 
            this.Panel_Top.Location = new System.Drawing.Point(0, 30);
            this.Panel_Top.Size = new System.Drawing.Size(854, 0);
            // 
            // Panel_Low
            // 
            this.Panel_Low.Size = new System.Drawing.Size(854, 506);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(12, 43);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(207, 20);
            this.textBox_Name.TabIndex = 0;
            // 
            // fm_XXXX
            // 
            this.ClientSize = new System.Drawing.Size(854, 536);
            this.Name = "fm_XXXX";
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_card.ResumeLayout(false);
            this.tabPage_card.PerformLayout();
            this.Panel_ToolBar.ResumeLayout(false);
            this.Panel_ToolBar.PerformLayout();
            this.Panel_Middle.ResumeLayout(false);
            this.Panel_Middle.PerformLayout();
            this.Panel_All.ResumeLayout(false);
            this.Panel_Low.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Name;
    }
}
