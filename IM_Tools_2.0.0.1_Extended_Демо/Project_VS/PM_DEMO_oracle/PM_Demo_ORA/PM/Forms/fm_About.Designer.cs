namespace PM.Forms
{
    partial class fm_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_About));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.lbFax = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lbCopyR_end = new System.Windows.Forms.Label();
            this.lURL = new System.Windows.Forms.LinkLabel();
            this.lbCopyR = new System.Windows.Forms.Label();
            this.lbeMail = new System.Windows.Forms.Label();
            this.lEmail = new System.Windows.Forms.LinkLabel();
            this.bt_modules = new System.Windows.Forms.Button();
            this.lbCopyR_03 = new System.Windows.Forms.Label();
            this.lbDBVer = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.MainModulVersion = new System.Windows.Forms.Label();
            this.lProductVersion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Title);
            this.panel1.Controls.Add(this.lbFax);
            this.panel1.Controls.Add(this.lbPhone);
            this.panel1.Controls.Add(this.picBox);
            this.panel1.Controls.Add(this.lbCopyR_end);
            this.panel1.Controls.Add(this.lURL);
            this.panel1.Controls.Add(this.lbCopyR);
            this.panel1.Controls.Add(this.lbeMail);
            this.panel1.Controls.Add(this.lEmail);
            this.panel1.Controls.Add(this.bt_modules);
            this.panel1.Controls.Add(this.lbCopyR_03);
            this.panel1.Controls.Add(this.lbDBVer);
            this.panel1.Controls.Add(this.Description);
            this.panel1.Controls.Add(this.MainModulVersion);
            this.panel1.Controls.Add(this.lProductVersion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 281);
            this.panel1.TabIndex = 1;
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(533, 80);
            this.Title.TabIndex = 0;
            this.Title.Text = "Система управления проектами";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFax
            // 
            this.lbFax.AutoSize = true;
            this.lbFax.Location = new System.Drawing.Point(85, 251);
            this.lbFax.Name = "lbFax";
            this.lbFax.Size = new System.Drawing.Size(114, 13);
            this.lbFax.TabIndex = 28;
            this.lbFax.Text = "факс 8-473-252-68-90";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(85, 235);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(108, 13);
            this.lbPhone.TabIndex = 27;
            this.lbPhone.Text = "тел. 8-473-252-15-73";
            // 
            // picBox
            // 
            this.picBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBox.ErrorImage = null;
            this.picBox.Image = ((System.Drawing.Image)(resources.GetObject("picBox.Image")));
            this.picBox.InitialImage = null;
            this.picBox.Location = new System.Drawing.Point(14, 186);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(64, 78);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 26;
            this.picBox.TabStop = false;
            // 
            // lbCopyR_end
            // 
            this.lbCopyR_end.AutoSize = true;
            this.lbCopyR_end.Location = new System.Drawing.Point(338, 203);
            this.lbCopyR_end.Name = "lbCopyR_end";
            this.lbCopyR_end.Size = new System.Drawing.Size(64, 13);
            this.lbCopyR_end.TabIndex = 25;
            this.lbCopyR_end.Text = "),1997-2016";
            // 
            // lURL
            // 
            this.lURL.AutoSize = true;
            this.lURL.Location = new System.Drawing.Point(280, 203);
            this.lURL.Name = "lURL";
            this.lURL.Size = new System.Drawing.Size(62, 13);
            this.lURL.TabIndex = 24;
            this.lURL.TabStop = true;
            this.lURL.Text = "www.inu.su";
            this.lURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_website_LinkClicked);
            // 
            // lbCopyR
            // 
            this.lbCopyR.AutoSize = true;
            this.lbCopyR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCopyR.Location = new System.Drawing.Point(85, 203);
            this.lbCopyR.Name = "lbCopyR";
            this.lbCopyR.Size = new System.Drawing.Size(198, 13);
            this.lbCopyR.TabIndex = 23;
            this.lbCopyR.Text = "© ООО «Информация и управление»(";
            // 
            // lbeMail
            // 
            this.lbeMail.AutoSize = true;
            this.lbeMail.Location = new System.Drawing.Point(85, 219);
            this.lbeMail.Name = "lbeMail";
            this.lbeMail.Size = new System.Drawing.Size(77, 13);
            this.lbeMail.TabIndex = 21;
            this.lbeMail.Text = "написать нам";
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(161, 219);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(64, 13);
            this.lEmail.TabIndex = 20;
            this.lEmail.TabStop = true;
            this.lEmail.Text = "mail@inu.su";
            this.lEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_website_LinkClicked);
            // 
            // bt_modules
            // 
            this.bt_modules.Location = new System.Drawing.Point(446, 246);
            this.bt_modules.Name = "bt_modules";
            this.bt_modules.Size = new System.Drawing.Size(75, 23);
            this.bt_modules.TabIndex = 19;
            this.bt_modules.Text = "Модули";
            this.bt_modules.UseVisualStyleBackColor = true;
            this.bt_modules.Click += new System.EventHandler(this.bt_modules_Click);
            // 
            // lbCopyR_03
            // 
            this.lbCopyR_03.AutoSize = true;
            this.lbCopyR_03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCopyR_03.Location = new System.Drawing.Point(85, 187);
            this.lbCopyR_03.Name = "lbCopyR_03";
            this.lbCopyR_03.Size = new System.Drawing.Size(75, 13);
            this.lbCopyR_03.TabIndex = 10;
            this.lbCopyR_03.Text = "Разработчик:";
            // 
            // lbDBVer
            // 
            this.lbDBVer.AutoSize = true;
            this.lbDBVer.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDBVer.Location = new System.Drawing.Point(12, 143);
            this.lbDBVer.Name = "lbDBVer";
            this.lbDBVer.Size = new System.Drawing.Size(105, 21);
            this.lbDBVer.TabIndex = 6;
            this.lbDBVer.Text = "Версия БД: ";
            this.lbDBVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Description.Location = new System.Drawing.Point(12, 122);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(114, 21);
            this.Description.TabIndex = 5;
            this.Description.Text = "Дата сборки:";
            this.Description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainModulVersion
            // 
            this.MainModulVersion.AutoSize = true;
            this.MainModulVersion.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainModulVersion.Location = new System.Drawing.Point(12, 101);
            this.MainModulVersion.Name = "MainModulVersion";
            this.MainModulVersion.Size = new System.Drawing.Size(233, 21);
            this.MainModulVersion.TabIndex = 2;
            this.MainModulVersion.Text = "Главный модуль версия: 1.0";
            // 
            // lProductVersion
            // 
            this.lProductVersion.AutoSize = true;
            this.lProductVersion.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lProductVersion.Location = new System.Drawing.Point(12, 80);
            this.lProductVersion.Name = "lProductVersion";
            this.lProductVersion.Size = new System.Drawing.Size(178, 21);
            this.lProductVersion.TabIndex = 1;
            this.lProductVersion.Text = "Версия продукта: 1.0";
            // 
            // fm_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(533, 281);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fm_About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label lbFax;
        private System.Windows.Forms.Label lbPhone;
        public System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label lbCopyR_end;
        private System.Windows.Forms.LinkLabel lURL;
        private System.Windows.Forms.Label lbCopyR;
        private System.Windows.Forms.Label lbeMail;
        private System.Windows.Forms.LinkLabel lEmail;
        private System.Windows.Forms.Button bt_modules;
        private System.Windows.Forms.Label lbCopyR_03;
        private System.Windows.Forms.Label lbDBVer;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label MainModulVersion;
        private System.Windows.Forms.Label lProductVersion;


    }
}