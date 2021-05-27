namespace QLHTDT.FormPhu.ThongKe
{
    partial class TK_CayXanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TK_CayXanh));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Btloadlailop = new System.Windows.Forms.Button();
            this.GridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btXuatExcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPhuong = new System.Windows.Forms.ComboBox();
            this.cboQuan = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.Btloadlailop);
            this.panel1.Controls.Add(this.GridControl1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btXuatExcel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboPhuong);
            this.panel1.Controls.Add(this.cboQuan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 407);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(487, 361);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 43);
            this.button3.TabIndex = 17;
            this.button3.Text = " Xem đường \r\nkhông có cây";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(350, 361);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 43);
            this.button2.TabIndex = 16;
            this.button2.Text = " Xem đường \r\n   có cây";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Btloadlailop
            // 
            this.Btloadlailop.Image = ((System.Drawing.Image)(resources.GetObject("Btloadlailop.Image")));
            this.Btloadlailop.Location = new System.Drawing.Point(228, 4);
            this.Btloadlailop.Name = "Btloadlailop";
            this.Btloadlailop.Size = new System.Drawing.Size(47, 47);
            this.Btloadlailop.TabIndex = 15;
            this.Btloadlailop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btloadlailop.UseVisualStyleBackColor = true;
            this.Btloadlailop.Click += new System.EventHandler(this.Btloadlailop_Click);
            // 
            // GridControl1
            // 
            this.GridControl1.DataSource = this.bindingSource1;
            this.GridControl1.Location = new System.Drawing.Point(3, 57);
            this.GridControl1.MainView = this.GridView1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.Size = new System.Drawing.Size(636, 296);
            this.GridControl1.TabIndex = 14;
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
            this.GridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 6F);
            this.GridView1.Appearance.HorzLine.Options.UseFont = true;
            this.GridView1.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.GridView1.Appearance.Row.Options.UseBackColor = true;
            this.GridView1.Appearance.Row.Options.UseFont = true;
            this.GridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 6F);
            this.GridView1.Appearance.RowSeparator.Options.UseFont = true;
            this.GridView1.Appearance.ViewCaption.BackColor = System.Drawing.Color.White;
            this.GridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
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
            this.GridView1.ColumnPanelRowHeight = 25;
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
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
            this.GridView1.ViewCaption = "BẢNG THỐNG KÊ CÂY XANH";
            this.GridView1.ViewCaptionHeight = 25;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Phường";
            this.gridColumn1.FieldName = "TenPhuong";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Số lượng";
            this.gridColumn2.FieldName = "SoLuong";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 76;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Cây loại 1";
            this.gridColumn3.FieldName = "Loai1";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 69;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Cây loại 2";
            this.gridColumn4.FieldName = "Loai2";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 72;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Cây loại 3";
            this.gridColumn8.FieldName = "Loai3";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Cây mới trồng";
            this.gridColumn5.FieldName = "CayMoiTrong";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Đường có cây";
            this.gridColumn6.FieldName = "DuongCoCay";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Đường không có cây";
            this.gridColumn7.FieldName = "DuongKCoCay";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(211, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 43);
            this.button1.TabIndex = 9;
            this.button1.Text = "In";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btXuatExcel
            // 
            this.btXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXuatExcel.Location = new System.Drawing.Point(64, 361);
            this.btXuatExcel.Name = "btXuatExcel";
            this.btXuatExcel.Size = new System.Drawing.Size(97, 43);
            this.btXuatExcel.TabIndex = 8;
            this.btXuatExcel.Text = "Xuất Excel";
            this.btXuatExcel.UseVisualStyleBackColor = true;
            this.btXuatExcel.Click += new System.EventHandler(this.btXuatExcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(8, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Phường/Xã:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quận/Huyện:";
            // 
            // cboPhuong
            // 
            this.cboPhuong.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboPhuong.FormattingEnabled = true;
            this.cboPhuong.Location = new System.Drawing.Point(95, 30);
            this.cboPhuong.Name = "cboPhuong";
            this.cboPhuong.Size = new System.Drawing.Size(127, 21);
            this.cboPhuong.TabIndex = 3;
            this.cboPhuong.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cboQuan
            // 
            this.cboQuan.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboQuan.FormattingEnabled = true;
            this.cboQuan.Location = new System.Drawing.Point(95, 3);
            this.cboQuan.Name = "cboQuan";
            this.cboQuan.Size = new System.Drawing.Size(127, 21);
            this.cboQuan.TabIndex = 2;
            this.cboQuan.SelectedIndexChanged += new System.EventHandler(this.cboQuan_SelectedIndexChanged);
            // 
            // TK_CayXanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 407);
            this.Controls.Add(this.panel1);
            this.Name = "TK_CayXanh";
            this.Text = "Thống kê cây xanh";
            this.Load += new System.EventHandler(this.TK_CayXanh_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button Btloadlailop;
        internal DevExpress.XtraGrid.GridControl GridControl1;
        internal DevExpress.XtraGrid.Views.Grid.GridView GridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btXuatExcel;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPhuong;
        private System.Windows.Forms.ComboBox cboQuan;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}