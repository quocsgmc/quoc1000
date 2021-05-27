namespace QLHTDT.test
{
    partial class FrmCapNhat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCapNhat));
            this.dataGridViewSHP = new System.Windows.Forms.DataGridView();
            this.FID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHBANDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHTHUA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSshp = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSsde = new System.Windows.Forms.BindingSource(this.components);
            btCapNhat = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewSDE = new System.Windows.Forms.DataGridView();
            this.Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoToBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoThua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btKiemTra = new System.Windows.Forms.Button();
            this.CboSoTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CboPhuong = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboQuan = new System.Windows.Forms.ComboBox();
            this.txtsde = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtshp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSshp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSsde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSDE)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSHP
            // 
            this.dataGridViewSHP.AutoGenerateColumns = false;
            this.dataGridViewSHP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSHP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FID,
            this.SHBANDO,
            this.SHTHUA});
            this.dataGridViewSHP.DataSource = this.bindingSshp;
            this.dataGridViewSHP.Location = new System.Drawing.Point(268, 169);
            this.dataGridViewSHP.Name = "dataGridViewSHP";
            this.dataGridViewSHP.Size = new System.Drawing.Size(10, 14);
            this.dataGridViewSHP.TabIndex = 30;
            // 
            // FID
            // 
            this.FID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FID.DataPropertyName = "FID";
            this.FID.HeaderText = "Mã";
            this.FID.Name = "FID";
            // 
            // SHBANDO
            // 
            this.SHBANDO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SHBANDO.DataPropertyName = "SHBANDO";
            this.SHBANDO.HeaderText = "Số tờ";
            this.SHBANDO.Name = "SHBANDO";
            // 
            // SHTHUA
            // 
            this.SHTHUA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SHTHUA.DataPropertyName = "SHTHUA";
            this.SHTHUA.HeaderText = "Số thửa";
            this.SHTHUA.Name = "SHTHUA";
            // 
            // btCapNhat
            // 
            btCapNhat.Enabled = false;
            btCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btCapNhat.Location = new System.Drawing.Point(177, 160);
            btCapNhat.Name = "btCapNhat";
            btCapNhat.Size = new System.Drawing.Size(111, 41);
            btCapNhat.TabIndex = 29;
            btCapNhat.Text = "Cập nhật";
            btCapNhat.UseVisualStyleBackColor = true;
            btCapNhat.Click += new System.EventHandler(btCapNhat_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Tờ bản đồ";
            // 
            // dataGridViewSDE
            // 
            this.dataGridViewSDE.AutoGenerateColumns = false;
            this.dataGridViewSDE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSDE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma,
            this.SoToBD,
            this.SoThua});
            this.dataGridViewSDE.DataSource = this.bindingSsde;
            this.dataGridViewSDE.Location = new System.Drawing.Point(239, 169);
            this.dataGridViewSDE.Name = "dataGridViewSDE";
            this.dataGridViewSDE.Size = new System.Drawing.Size(11, 10);
            this.dataGridViewSDE.TabIndex = 31;
            // 
            // Ma
            // 
            this.Ma.DataPropertyName = "OBJECTID";
            this.Ma.HeaderText = "Mã";
            this.Ma.Name = "Ma";
            // 
            // SoToBD
            // 
            this.SoToBD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoToBD.DataPropertyName = "Số tờ bản đồ";
            this.SoToBD.HeaderText = "Số tờ";
            this.SoToBD.Name = "SoToBD";
            // 
            // SoThua
            // 
            this.SoThua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoThua.DataPropertyName = "Số thửa";
            this.SoThua.HeaderText = "Số thửa";
            this.SoThua.Name = "SoThua";
            // 
            // btKiemTra
            // 
            this.btKiemTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btKiemTra.Location = new System.Drawing.Point(42, 160);
            this.btKiemTra.Name = "btKiemTra";
            this.btKiemTra.Size = new System.Drawing.Size(111, 41);
            this.btKiemTra.TabIndex = 28;
            this.btKiemTra.Text = "Kiểm tra";
            this.btKiemTra.UseVisualStyleBackColor = true;
            this.btKiemTra.Click += new System.EventHandler(this.btKiemTra_Click);
            // 
            // CboSoTo
            // 
            this.CboSoTo.FormattingEnabled = true;
            this.CboSoTo.Location = new System.Drawing.Point(256, 123);
            this.CboSoTo.Name = "CboSoTo";
            this.CboSoTo.Size = new System.Drawing.Size(78, 21);
            this.CboSoTo.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Phường/Xã";
            // 
            // CboPhuong
            // 
            this.CboPhuong.FormattingEnabled = true;
            this.CboPhuong.Location = new System.Drawing.Point(134, 123);
            this.CboPhuong.Name = "CboPhuong";
            this.CboPhuong.Size = new System.Drawing.Size(116, 21);
            this.CboPhuong.TabIndex = 24;
            this.CboPhuong.SelectedValueChanged += new System.EventHandler(this.CboPhuong_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Quận/Huyện";
            // 
            // cboQuan
            // 
            this.cboQuan.FormattingEnabled = true;
            this.cboQuan.Items.AddRange(new object[] {
            "Quận Cẩm Lệ",
            "Quận Hải Châu",
            "Quận Liêu Chiểu",
            "Quận Ngũ Hành Sơn",
            "Quận Sơn Trà",
            "Quận Thanh Khê",
            "Huyện Hòa Vang",
            "Huyện Hoàng Sa"});
            this.cboQuan.Location = new System.Drawing.Point(12, 123);
            this.cboQuan.Name = "cboQuan";
            this.cboQuan.Size = new System.Drawing.Size(116, 21);
            this.cboQuan.TabIndex = 22;
            this.cboQuan.SelectedValueChanged += new System.EventHandler(this.cboQuan_SelectedIndexChanged);
            // 
            // txtsde
            // 
            this.txtsde.Location = new System.Drawing.Point(42, 76);
            this.txtsde.Name = "txtsde";
            this.txtsde.Size = new System.Drawing.Size(292, 20);
            this.txtsde.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Chọn đường dẫn cấu hình sde";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(12, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 19;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtshp
            // 
            this.txtshp.Location = new System.Drawing.Point(42, 30);
            this.txtshp.Name = "txtshp";
            this.txtshp.Size = new System.Drawing.Size(292, 20);
            this.txtshp.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Chọn file shapefile(shp)";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(12, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCapNhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 222);
            this.Controls.Add(btCapNhat);
            this.Controls.Add(this.dataGridViewSHP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridViewSDE);
            this.Controls.Add(this.btKiemTra);
            this.Controls.Add(this.CboSoTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CboPhuong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboQuan);
            this.Controls.Add(this.txtsde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtshp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCapNhat";
            this.Text = "Cập nhật thửa đất";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCapNhat_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSshp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSsde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSDE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn FID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHBANDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHTHUA;
        private System.Windows.Forms.BindingSource bindingSshp;
        private System.Windows.Forms.BindingSource bindingSsde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBJECTID;
        private System.Windows.Forms.DataGridView dataGridViewSDE;
        private System.Windows.Forms.Button btKiemTra;
        private System.Windows.Forms.ComboBox CboSoTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CboPhuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboQuan;
        private System.Windows.Forms.TextBox txtsde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtshp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoToBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoThua;
        public static System.Windows.Forms.Button btCapNhat;
    }
}