namespace QLHTDT.FormPhu.CapNhatQuyDat
{
    partial class FrmThemMoiQuyDatQH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThemMoiQuyDatQH));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CboChonShp2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btMo2 = new System.Windows.Forms.Button();
            this.treeList2 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 525);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 60);
            this.panel1.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(176, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 38);
            this.button4.TabIndex = 1;
            this.button4.Text = "Thêm mới";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.CboChonShp2);
            this.splitContainer2.Panel1.Controls.Add(this.label12);
            this.splitContainer2.Panel1.Controls.Add(this.btMo2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.treeList2);
            this.splitContainer2.Size = new System.Drawing.Size(760, 525);
            this.splitContainer2.SplitterDistance = 157;
            this.splitContainer2.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(316, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chọn dự án quy hoạch";
            // 
            // CboChonShp2
            // 
            this.CboChonShp2.FormattingEnabled = true;
            this.CboChonShp2.Location = new System.Drawing.Point(15, 24);
            this.CboChonShp2.Name = "CboChonShp2";
            this.CboChonShp2.Size = new System.Drawing.Size(313, 21);
            this.CboChonShp2.TabIndex = 3;
            this.CboChonShp2.SelectedIndexChanged += new System.EventHandler(this.CboChonShp2_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Chọn file Shapefile";
            // 
            // btMo2
            // 
            this.btMo2.Location = new System.Drawing.Point(348, 17);
            this.btMo2.Name = "btMo2";
            this.btMo2.Size = new System.Drawing.Size(56, 33);
            this.btMo2.TabIndex = 5;
            this.btMo2.Text = "Mở";
            this.btMo2.UseVisualStyleBackColor = true;
            this.btMo2.Click += new System.EventHandler(this.btMo2_Click_1);
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
            "Loại quỹ đất",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Phường/Xã",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Phân khu",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Số hiệu lô đất",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Số thứ tự lô đất",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Đường",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Diện tích",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Vị trí đặc điểm lô đất",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Ghi chú",
            null}, -1);
            this.treeList2.AppendNode(new object[] {
            "Đã có đất thực tế",
            null}, -1);
            this.treeList2.EndUnboundLoad();
            this.treeList2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox2});
            this.treeList2.Size = new System.Drawing.Size(760, 364);
            this.treeList2.TabIndex = 43;
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
            this.treeListColumn1.Width = 202;
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
            this.treeListColumn5.Width = 196;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // FrmThemMoiQuyDatQH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 585);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmThemMoiQuyDatQH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mới quỹ đất quy hoạch";
            this.Load += new System.EventHandler(this.FrmThemMoiQuyDatQH_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboChonShp2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btMo2;
        private DevExpress.XtraTreeList.TreeList treeList2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
    }
}