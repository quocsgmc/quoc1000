namespace QLHTDT.FormPhu.CapNhat
{
    partial class FrmCapNhatSoNha
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.GridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.txtKhongCoNha = new System.Windows.Forms.TextBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.txtHem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtNhaCuoi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNhaDau = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKiet = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPhuong = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboQuan = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboDuong = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox7);
            this.panel1.Controls.Add(this.checkBox6);
            this.panel1.Controls.Add(this.GridControl1);
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.txtKhongCoNha);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.txtHem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.dgvData);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.txtNhaCuoi);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtNhaDau);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtKiet);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboPhuong);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cboQuan);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cboDuong);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 434);
            this.panel1.TabIndex = 7;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(295, 103);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(93, 17);
            this.checkBox7.TabIndex = 51;
            this.checkBox7.Text = "Đánh giả định";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(295, 126);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(88, 17);
            this.checkBox6.TabIndex = 50;
            this.checkBox6.Text = "Đánh thực tế";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // GridControl1
            // 
            this.GridControl1.DataSource = this.bindingSource1;
            this.GridControl1.Location = new System.Drawing.Point(8, 219);
            this.GridControl1.MainView = this.GridView1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.Size = new System.Drawing.Size(378, 202);
            this.GridControl1.TabIndex = 49;
            this.GridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            // 
            // GridView1
            // 
            this.GridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.White;
            this.GridView1.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.White;
            this.GridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.GridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.GridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.GridView1.Appearance.GroupButton.Options.UseTextOptions = true;
            this.GridView1.Appearance.GroupButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridView1.Appearance.GroupButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GridView1.Appearance.GroupButton.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.GridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.White;
            this.GridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.GridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.GridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.GridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.GridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.GridView1.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.GridView1.Appearance.Row.Options.UseBackColor = true;
            this.GridView1.Appearance.ViewCaption.BackColor = System.Drawing.Color.White;
            this.GridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.GridView1.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black;
            this.GridView1.Appearance.ViewCaption.Options.UseBackColor = true;
            this.GridView1.Appearance.ViewCaption.Options.UseFont = true;
            this.GridView1.Appearance.ViewCaption.Options.UseForeColor = true;
            this.GridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.White;
            this.GridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
            this.GridView1.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White;
            this.GridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GridView1.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            this.GridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.GridView1.AppearancePrint.FooterPanel.Options.UseTextOptions = true;
            this.GridView1.AppearancePrint.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.GridView1.AppearancePrint.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GridView1.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White;
            this.GridView1.AppearancePrint.GroupFooter.Options.UseBackColor = true;
            this.GridView1.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.GridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GridView1.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.GridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.GridView1.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.GridView1.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridView1.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.GridView1.ColumnPanelRowHeight = 20;
            this.GridView1.GridControl = this.GridControl1;
            this.GridView1.IndicatorWidth = 30;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridView1.OptionsPrint.EnableAppearanceEvenRow = true;
            this.GridView1.OptionsView.ColumnAutoWidth = false;
            this.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.GridView1.OptionsView.RowAutoHeight = true;
            this.GridView1.OptionsView.ShowFooter = true;
            this.GridView1.OptionsView.ShowGroupPanel = false;
            this.GridView1.OptionsView.ShowViewCaption = true;
            this.GridView1.RowHeight = 20;
            this.GridView1.ViewCaption = "BẢNG THÔNG TIN CẬP NHẬT";
            this.GridView1.ViewCaptionHeight = 20;
            this.GridView1.DoubleClick += new System.EventHandler(this.GridView1_DoubleClick);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(295, 153);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 48;
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // txtKhongCoNha
            // 
            this.txtKhongCoNha.Location = new System.Drawing.Point(322, 150);
            this.txtKhongCoNha.Name = "txtKhongCoNha";
            this.txtKhongCoNha.ReadOnly = true;
            this.txtKhongCoNha.Size = new System.Drawing.Size(57, 20);
            this.txtKhongCoNha.TabIndex = 47;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(201, 127);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 46;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(201, 101);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 45;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // txtHem
            // 
            this.txtHem.Location = new System.Drawing.Point(129, 124);
            this.txtHem.Name = "txtHem";
            this.txtHem.ReadOnly = true;
            this.txtHem.Size = new System.Drawing.Size(57, 20);
            this.txtHem.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Hẻm:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(27, 176);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 37);
            this.button6.TabIndex = 42;
            this.button6.Text = "Chọn tuyến nhà cần cập nhật";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(10, 218);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(372, 181);
            this.dgvData.TabIndex = 41;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(154, 175);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 37);
            this.button5.TabIndex = 40;
            this.button5.Text = "Cập nhật";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.CapNhat_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 37);
            this.button2.TabIndex = 39;
            this.button2.Text = "Tiếp  tục \r\ncập nhật";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ReLoad_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(161, 152);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(122, 17);
            this.checkBox2.TabIndex = 34;
            this.checkBox2.Text = "Không có số nhà 13";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(27, 153);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(116, 17);
            this.checkBox1.TabIndex = 33;
            this.checkBox1.Text = "Không có số nhà 4";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtNhaCuoi
            // 
            this.txtNhaCuoi.Location = new System.Drawing.Point(253, 72);
            this.txtNhaCuoi.Name = "txtNhaCuoi";
            this.txtNhaCuoi.Size = new System.Drawing.Size(57, 20);
            this.txtNhaCuoi.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 26);
            this.label6.TabIndex = 30;
            this.label6.Text = " Số nhà\r\ncuối tuyến";
            // 
            // txtNhaDau
            // 
            this.txtNhaDau.Location = new System.Drawing.Point(130, 72);
            this.txtNhaDau.Name = "txtNhaDau";
            this.txtNhaDau.Size = new System.Drawing.Size(57, 20);
            this.txtNhaDau.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 26);
            this.label7.TabIndex = 27;
            this.label7.Text = " Số nhà\r\nđầu tuyến";
            // 
            // txtKiet
            // 
            this.txtKiet.Location = new System.Drawing.Point(129, 98);
            this.txtKiet.Name = "txtKiet";
            this.txtKiet.ReadOnly = true;
            this.txtKiet.Size = new System.Drawing.Size(57, 20);
            this.txtKiet.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Kiệt:";
            // 
            // cboPhuong
            // 
            this.cboPhuong.FormattingEnabled = true;
            this.cboPhuong.Items.AddRange(new object[] {
            "Hòa An"});
            this.cboPhuong.Location = new System.Drawing.Point(287, 12);
            this.cboPhuong.Name = "cboPhuong";
            this.cboPhuong.Size = new System.Drawing.Size(95, 21);
            this.cboPhuong.TabIndex = 23;
            this.cboPhuong.SelectedIndexChanged += new System.EventHandler(this.cboPhuong_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Phường/Xã:";
            // 
            // cboQuan
            // 
            this.cboQuan.FormattingEnabled = true;
            this.cboQuan.Location = new System.Drawing.Point(77, 12);
            this.cboQuan.Name = "cboQuan";
            this.cboQuan.Size = new System.Drawing.Size(135, 21);
            this.cboQuan.TabIndex = 21;
            this.cboQuan.SelectedIndexChanged += new System.EventHandler(this.cboQuan_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Quận/Huyện:";
            // 
            // cboDuong
            // 
            this.cboDuong.FormattingEnabled = true;
            this.cboDuong.Location = new System.Drawing.Point(77, 40);
            this.cboDuong.Name = "cboDuong";
            this.cboDuong.Size = new System.Drawing.Size(162, 21);
            this.cboDuong.TabIndex = 19;
            this.cboDuong.SelectedIndexChanged += new System.EventHandler(this.cboDuong_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Tên đường:";
            // 
            // FrmCapNhatSoNha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 434);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCapNhatSoNha";
            this.Text = "Cập nhật số nhà";
            this.Load += new System.EventHandler(this.FrmCapNhatSoNha_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNhaCuoi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNhaDau;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKiet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboPhuong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboQuan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboDuong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHem;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox txtKhongCoNha;
        private System.Windows.Forms.CheckBox checkBox5;
        internal DevExpress.XtraGrid.GridControl GridControl1;
        private System.Windows.Forms.BindingSource bindingSource1;
        internal DevExpress.XtraGrid.Views.Grid.GridView GridView1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
    }
}