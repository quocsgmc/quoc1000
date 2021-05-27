namespace QLHTDT
{
    partial class SGMC
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
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Engine);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SGMC));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.axLicenseControl2 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.chkNhoTaiKhoan = new DevExpress.XtraEditors.CheckEdit();
            this.BtDangNhap = new DevExpress.XtraEditors.SimpleButton();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtSetting = new DevExpress.XtraEditors.SimpleButton();
            this.BtThacmac = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.CboPhanHe = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNhoTaiKhoan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboPhanHe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageUri.Uri = "Forward";
            this.groupControl1.Controls.Add(this.axLicenseControl2);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txtMatKhau);
            this.groupControl1.Controls.Add(this.chkNhoTaiKhoan);
            this.groupControl1.Controls.Add(this.BtDangNhap);
            this.groupControl1.Controls.Add(this.txtTaiKhoan);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.Name = "groupControl1";
            // 
            // axLicenseControl2
            // 
            resources.ApplyResources(this.axLicenseControl2, "axLicenseControl2");
            this.axLicenseControl2.Name = "axLicenseControl2";
            this.axLicenseControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl2.OcxState")));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Name = "label3";
            this.label3.DoubleClick += new System.EventHandler(this.label3_DoubleClick);
            // 
            // txtMatKhau
            // 
            resources.ApplyResources(this.txtMatKhau, "txtMatKhau");
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_MouseDown);
            // 
            // chkNhoTaiKhoan
            // 
            resources.ApplyResources(this.chkNhoTaiKhoan, "chkNhoTaiKhoan");
            this.chkNhoTaiKhoan.Name = "chkNhoTaiKhoan";
            this.chkNhoTaiKhoan.Properties.Caption = resources.GetString("chkNhoTaiKhoan.Properties.Caption");
            // 
            // BtDangNhap
            // 
            this.BtDangNhap.Image = global::QLHTDT.Properties.Resources.next_32x32;
            this.BtDangNhap.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtDangNhap.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            resources.ApplyResources(this.BtDangNhap, "BtDangNhap");
            this.BtDangNhap.Name = "BtDangNhap";
            this.BtDangNhap.Click += new System.EventHandler(this.BtDangNhap_Click);
            // 
            // txtTaiKhoan
            // 
            resources.ApplyResources(this.txtTaiKhoan, "txtTaiKhoan");
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaiKhoan_MouseDown);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // BtSetting
            // 
            this.BtSetting.Image = ((System.Drawing.Image)(resources.GetObject("BtSetting.Image")));
            this.BtSetting.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            resources.ApplyResources(this.BtSetting, "BtSetting");
            this.BtSetting.Name = "BtSetting";
            this.BtSetting.Click += new System.EventHandler(this.BtSetting_Click);
            // 
            // BtThacmac
            // 
            this.BtThacmac.Image = ((System.Drawing.Image)(resources.GetObject("BtThacmac.Image")));
            this.BtThacmac.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            resources.ApplyResources(this.BtThacmac, "BtThacmac");
            this.BtThacmac.Name = "BtThacmac";
            this.BtThacmac.Click += new System.EventHandler(this.BtThacmac_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // groupControl3
            // 
            this.groupControl3.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl3.CaptionImage")));
            this.groupControl3.CaptionImageUri.Uri = "Forward";
            this.groupControl3.Controls.Add(this.pictureBox1);
            this.groupControl3.Controls.Add(this.BtThacmac);
            this.groupControl3.Controls.Add(this.BtSetting);
            resources.ApplyResources(this.groupControl3, "groupControl3");
            this.groupControl3.Name = "groupControl3";
            // 
            // CboPhanHe
            // 
            resources.ApplyResources(this.CboPhanHe, "CboPhanHe");
            this.CboPhanHe.Name = "CboPhanHe";
            this.CboPhanHe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("CboPhanHe.Properties.Buttons"))))});
            this.CboPhanHe.Properties.Items.AddRange(new object[] {
            resources.GetString("CboPhanHe.Properties.Items")});
            // 
            // groupControl2
            // 
            this.groupControl2.CaptionImageUri.Uri = "Forward";
            this.groupControl2.Controls.Add(this.CboPhanHe);
            resources.ApplyResources(this.groupControl2, "groupControl2");
            this.groupControl2.Name = "groupControl2";
            // 
            // SGMC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Name = "SGMC";
            this.Load += new System.EventHandler(this.SGMC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNhoTaiKhoan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CboPhanHe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton BtDangNhap;
        private DevExpress.XtraEditors.CheckEdit chkNhoTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton BtSetting;
        private DevExpress.XtraEditors.SimpleButton BtThacmac;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.Label label3;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl2;
        private DevExpress.XtraEditors.ComboBoxEdit CboPhanHe;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}

