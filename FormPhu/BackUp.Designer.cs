namespace QLHTDT.FormPhu
{
    partial class BackUp
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
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtCSDL = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblPercent = new DevExpress.XtraEditors.LabelControl();
            this.lblThongTin = new DevExpress.XtraEditors.LabelControl();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDuongDan = new System.Windows.Forms.TextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(104, 188);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPass.Multiline = true;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(394, 30);
            this.txtPass.TabIndex = 10;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(104, 145);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUser.Multiline = true;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(394, 31);
            this.txtUser.TabIndex = 8;
            // 
            // txtCSDL
            // 
            this.txtCSDL.Location = new System.Drawing.Point(104, 56);
            this.txtCSDL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCSDL.Multiline = true;
            this.txtCSDL.Name = "txtCSDL";
            this.txtCSDL.Size = new System.Drawing.Size(394, 31);
            this.txtCSDL.TabIndex = 6;
            this.txtCSDL.Text = "GISDANANG";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(104, 12);
            this.txtServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtServer.Multiline = true;
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(394, 31);
            this.txtServer.TabIndex = 4;
            this.txtServer.Text = "sxd.sgmcvietnam.vn,1234";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(13, 195);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 18);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Mật khẩu";
            this.labelControl4.UseMnemonic = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(13, 153);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 18);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Tài khoản";
            this.labelControl3.UseMnemonic = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(15, 64);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 18);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Cơ sở dữ liệu";
            this.labelControl2.UseMnemonic = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(15, 21);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 18);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Máy chủ";
            this.labelControl1.UseMnemonic = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 237);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(485, 27);
            this.progressBar.TabIndex = 12;
            // 
            // lblPercent
            // 
            this.lblPercent.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Location = new System.Drawing.Point(235, 273);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(23, 18);
            this.lblPercent.TabIndex = 13;
            this.lblPercent.Text = "0%";
            this.lblPercent.UseMnemonic = false;
            // 
            // lblThongTin
            // 
            this.lblThongTin.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTin.Location = new System.Drawing.Point(16, 306);
            this.lblThongTin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(67, 18);
            this.lblThongTin.TabIndex = 14;
            this.lblThongTin.Text = "Thông tin:";
            this.lblThongTin.UseMnemonic = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 332);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 42);
            this.button1.TabIndex = 15;
            this.button1.Text = "Sao lưu dữ liệu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Location = new System.Drawing.Point(104, 100);
            this.txtDuongDan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDuongDan.Multiline = true;
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.Size = new System.Drawing.Size(394, 39);
            this.txtDuongDan.TabIndex = 55;
            this.txtDuongDan.Text = "C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQLEXPRESS\\MSSQL\\Backup\\GISDESKTOP." +
    "bak";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(15, 109);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 18);
            this.labelControl5.TabIndex = 56;
            this.labelControl5.Text = "Đường dẫn";
            this.labelControl5.UseMnemonic = false;
            // 
            // BackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 385);
            this.Controls.Add(this.txtDuongDan);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblThongTin);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtCSDL);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "BackUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sao lưu Cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.BackUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtCSDL;
        private System.Windows.Forms.TextBox txtServer;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ProgressBar progressBar;
        private DevExpress.XtraEditors.LabelControl lblPercent;
        private DevExpress.XtraEditors.LabelControl lblThongTin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDuongDan;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}