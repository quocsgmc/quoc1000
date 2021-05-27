namespace QLHTDT.FormPhu.ThongKe
{
    partial class TK_KietHemKhongCoTuyenCS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TK_KietHemKhongCoTuyenCS));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btloadlailop = new System.Windows.Forms.Button();
            this.GridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.panel1.Size = new System.Drawing.Size(451, 412);
            this.panel1.TabIndex = 1;
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
            this.GridControl1.Size = new System.Drawing.Size(438, 296);
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
            this.gridColumn5,
            this.gridColumn6});
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
            this.GridView1.ViewCaption = "BẢNG THÔNG TIN KIỆT HẺM KHÔNG CÓ TUYẾN CHIẾU SÁNG";
            this.GridView1.ViewCaptionHeight = 25;
            this.GridView1.DoubleClick += new System.EventHandler(this.GridView1_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Phường/Xã";
            this.gridColumn1.FieldName = "TenPhuong";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 95;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên kiệt hẻm";
            this.gridColumn2.FieldName = "TENKIETHEM";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Loại đường";
            this.gridColumn3.FieldName = "LOAIDUONG";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mặt cắt";
            this.gridColumn4.FieldName = "DuongDat";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Chiêu dài";
            this.gridColumn5.FieldName = "CHIEUDAI";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "OBJECTID";
            this.gridColumn6.FieldName = "OBJECTID";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(250, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 34);
            this.button1.TabIndex = 9;
            this.button1.Text = "In";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btXuatExcel
            // 
            this.btXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXuatExcel.Location = new System.Drawing.Point(81, 364);
            this.btXuatExcel.Name = "btXuatExcel";
            this.btXuatExcel.Size = new System.Drawing.Size(97, 34);
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
            this.cboPhuong.Items.AddRange(new object[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
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
            // TK_KietHemKhongCoTuyenCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 412);
            this.Controls.Add(this.panel1);
            this.Name = "TK_KietHemKhongCoTuyenCS";
            this.Text = "Kiệt hẻm không có tuyến chiếu sáng";
            this.Load += new System.EventHandler(this.TK_KietHemKhongCoTuyenCS_Load);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btXuatExcel;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPhuong;
        private System.Windows.Forms.ComboBox cboQuan;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}