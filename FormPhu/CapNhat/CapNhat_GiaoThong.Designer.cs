namespace QLHTDT.FormPhu.CapNhat
{
    partial class CapNhat_GiaoThong
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label14 = new System.Windows.Forms.Label();
            this.btMo2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.filename = new System.Windows.Forms.ComboBox();
            this.btCapNhat = new System.Windows.Forms.Button();
            this.treeList2 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.btMo2);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.filename);
            this.splitContainer1.Panel1.Controls.Add(this.btCapNhat);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeList2);
            this.splitContainer1.Size = new System.Drawing.Size(410, 369);
            this.splitContainer1.SplitterDistance = 64;
            this.splitContainer1.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(251, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 63;
            this.label14.Text = "Phường";
            // 
            // btMo2
            // 
            this.btMo2.Location = new System.Drawing.Point(251, 8);
            this.btMo2.Name = "btMo2";
            this.btMo2.Size = new System.Drawing.Size(31, 23);
            this.btMo2.TabIndex = 62;
            this.btMo2.Text = "Mở";
            this.btMo2.UseVisualStyleBackColor = true;
            this.btMo2.Click += new System.EventHandler(this.btMo2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Khuê Trung",
            "Hòa Xuân"});
            this.comboBox1.Location = new System.Drawing.Point(12, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(233, 21);
            this.comboBox1.TabIndex = 61;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // filename
            // 
            this.filename.FormattingEnabled = true;
            this.filename.Location = new System.Drawing.Point(12, 8);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(233, 21);
            this.filename.TabIndex = 60;
            this.filename.SelectedIndexChanged += new System.EventHandler(this.filename_SelectedIndexChanged);
            // 
            // btCapNhat
            // 
            this.btCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCapNhat.Location = new System.Drawing.Point(301, 6);
            this.btCapNhat.Name = "btCapNhat";
            this.btCapNhat.Size = new System.Drawing.Size(97, 48);
            this.btCapNhat.TabIndex = 59;
            this.btCapNhat.Text = "Cập nhật";
            this.btCapNhat.UseVisualStyleBackColor = true;
            this.btCapNhat.Click += new System.EventHandler(this.btCapNhat_Click);
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
            this.treeList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList2.Location = new System.Drawing.Point(0, 0);
            this.treeList2.Name = "treeList2";
            this.treeList2.BeginUnboundLoad();
            this.treeList2.AppendNode(new object[] {
            "Tên đường",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Chiều dài",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Mã đường",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Đầu tuyến",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Cuối tuyến",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Mặt cắt",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Cấp hạng đường",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Loại đường",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Trạng thái",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Ghi chú",
            null}, -1);
            this.treeList2.EndUnboundLoad();
            this.treeList2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox2});
            this.treeList2.Size = new System.Drawing.Size(410, 301);
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
            // CapNhat_GiaoThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 369);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CapNhat_GiaoThong";
            this.Text = "Cập nhật đường giao thông chính";
            this.Load += new System.EventHandler(this.CapNhat_GiaoThong_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btCapNhat;
        private DevExpress.XtraTreeList.TreeList treeList2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private System.Windows.Forms.ComboBox filename;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btMo2;
        private System.Windows.Forms.Label label14;
    }
}