namespace QLHTDT.FormPhu.ThongKe
{
    partial class TK_TramBTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TK_TramBTS));
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
            this.label4 = new System.Windows.Forms.Label();
            this.cboCDT = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btChinhSua = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboCDT);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btChinhSua);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboQuan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 411);
            this.panel1.TabIndex = 1;
            // 
            // Btloadlailop
            // 
            this.Btloadlailop.Image = ((System.Drawing.Image)(resources.GetObject("Btloadlailop.Image")));
            this.Btloadlailop.Location = new System.Drawing.Point(228, 3);
            this.Btloadlailop.Name = "Btloadlailop";
            this.Btloadlailop.Size = new System.Drawing.Size(47, 47);
            this.Btloadlailop.TabIndex = 14;
            this.Btloadlailop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btloadlailop.UseVisualStyleBackColor = true;
            this.Btloadlailop.Click += new System.EventHandler(this.Btloadlailop_Click);
            // 
            // GridControl1
            // 
            this.GridControl1.DataSource = this.bindingSource1;
            this.GridControl1.Location = new System.Drawing.Point(7, 56);
            this.GridControl1.MainView = this.GridView1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.Size = new System.Drawing.Size(426, 294);
            this.GridControl1.TabIndex = 13;
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
            this.gridColumn5});
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
            this.GridView1.ViewCaption = "Bảng thống kê trạm BTS";
            this.GridView1.ViewCaptionHeight = 25;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Quận/Huyện";
            this.gridColumn1.FieldName = "TenQuan";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 92;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Phường/Xã";
            this.gridColumn2.FieldName = "TenPhuong";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Số trạm";
            this.gridColumn3.FieldName = "SoLuong";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 90;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Loại trạm";
            this.gridColumn4.FieldName = "LoaiTram";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 104;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Chủ đầu tư";
            this.gridColumn5.FieldName = "ChuDauTu";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 101;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(9, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Chủ đầu tư:";
            // 
            // cboCDT
            // 
            this.cboCDT.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboCDT.FormattingEnabled = true;
            this.cboCDT.Items.AddRange(new object[] {
            "Cẩm Lệ"});
            this.cboCDT.Location = new System.Drawing.Point(95, 29);
            this.cboCDT.Name = "cboCDT";
            this.cboCDT.Size = new System.Drawing.Size(127, 21);
            this.cboCDT.TabIndex = 11;
            this.cboCDT.SelectedIndexChanged += new System.EventHandler(this.cboCDT_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(263, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 34);
            this.button1.TabIndex = 9;
            this.button1.Text = "In";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btChinhSua
            // 
            this.btChinhSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChinhSua.Location = new System.Drawing.Point(94, 361);
            this.btChinhSua.Name = "btChinhSua";
            this.btChinhSua.Size = new System.Drawing.Size(97, 34);
            this.btChinhSua.TabIndex = 8;
            this.btChinhSua.Text = "Xuất Excel";
            this.btChinhSua.UseVisualStyleBackColor = true;
            this.btChinhSua.Click += new System.EventHandler(this.btChinhSua_Click);
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
            this.cboQuan.Items.AddRange(new object[] {
            "Cẩm Lệ"});
            this.cboQuan.Location = new System.Drawing.Point(95, 3);
            this.cboQuan.Name = "cboQuan";
            this.cboQuan.Size = new System.Drawing.Size(127, 21);
            this.cboQuan.TabIndex = 2;
            this.cboQuan.SelectedIndexChanged += new System.EventHandler(this.cboQuan_SelectedIndexChanged);
            // 
            // TK_TramBTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 411);
            this.Controls.Add(this.panel1);
            this.Name = "TK_TramBTS";
            this.Text = "Thống kê trạm BTS";
            this.Load += new System.EventHandler(this.TK_TramBTS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btChinhSua;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboQuan;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCDT;
        internal DevExpress.XtraGrid.GridControl GridControl1;
        internal DevExpress.XtraGrid.Views.Grid.GridView GridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        internal System.Windows.Forms.Button Btloadlailop;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}