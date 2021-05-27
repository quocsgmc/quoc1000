namespace QLHTDT.FormPhanHe.GiaoThong.ThemMoi
{
    partial class KietHemShapefile
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
            this.CboChonShp2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btMo2 = new System.Windows.Forms.Button();
            this.treeList2 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // CboChonShp2
            // 
            this.CboChonShp2.FormattingEnabled = true;
            this.CboChonShp2.Location = new System.Drawing.Point(12, 28);
            this.CboChonShp2.Name = "CboChonShp2";
            this.CboChonShp2.Size = new System.Drawing.Size(255, 21);
            this.CboChonShp2.TabIndex = 6;
            this.CboChonShp2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(9, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Chọn file Shapefile";
            // 
            // btMo2
            // 
            this.btMo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btMo2.Location = new System.Drawing.Point(273, 26);
            this.btMo2.Name = "btMo2";
            this.btMo2.Size = new System.Drawing.Size(38, 23);
            this.btMo2.TabIndex = 8;
            this.btMo2.Text = "Mở";
            this.btMo2.UseVisualStyleBackColor = true;
            this.btMo2.Click += new System.EventHandler(this.btMo2_Click);
            // 
            // treeList2
            // 
            this.treeList2.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList2.Appearance.BandPanel.Options.UseFont = true;
            this.treeList2.Appearance.Caption.Font = new System.Drawing.Font("Tahoma", 9F);
            this.treeList2.Appearance.Caption.Options.UseFont = true;
            this.treeList2.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.treeList2.Appearance.FilterPanel.Options.UseFont = true;
            this.treeList2.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.treeList2.Appearance.FocusedCell.Options.UseFont = true;
            this.treeList2.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.treeList2.Appearance.FocusedRow.Options.UseFont = true;
            this.treeList2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.treeList2.Appearance.FooterPanel.Options.UseFont = true;
            this.treeList2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList2.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeList2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.treeList2.Appearance.Row.Options.UseFont = true;
            this.treeList2.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList2.Appearance.SelectedRow.Options.UseFont = true;
            this.treeList2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn5});
            this.treeList2.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList2.Location = new System.Drawing.Point(12, 55);
            this.treeList2.Name = "treeList2";
            this.treeList2.BeginUnboundLoad();
            this.treeList2.AppendNode(new object[] {
            "Tên kiệt hẻm",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Loại đường",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Mặt cắt",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Chiều dài",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Điểm đầu",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Điểm cuối",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Phường/Xã",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Ghi chú",
            null}, -1);
            this.treeList2.EndUnboundLoad();
            this.treeList2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox2});
            this.treeList2.Size = new System.Drawing.Size(379, 233);
            this.treeList2.TabIndex = 44;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn1.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "Thuộc tính";
            this.treeListColumn1.FieldName = "Thuoctinh";
            this.treeListColumn1.MinWidth = 52;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 138;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.treeListColumn5.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn5.Caption = "Trường dữ liệu";
            this.treeListColumn5.ColumnEdit = this.repositoryItemComboBox2;
            this.treeListColumn5.FieldName = "TruongDuLieu";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 1;
            this.treeListColumn5.Width = 132;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(169, 294);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 34);
            this.button4.TabIndex = 45;
            this.button4.Text = "Cập nhật";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // KietHemShapefile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 338);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.treeList2);
            this.Controls.Add(this.CboChonShp2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btMo2);
            this.Name = "KietHemShapefile";
            this.Text = "Cập nhật Kiệt hẻm";
            this.Load += new System.EventHandler(this.KietHemShapefile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboChonShp2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btMo2;
        private DevExpress.XtraTreeList.TreeList treeList2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private System.Windows.Forms.Button button4;
    }
}