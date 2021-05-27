namespace QLHTDT.FormPhu.CapNhat
{
    partial class FrmChonDoiTuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChonDoiTuong));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(treeList1);
            this.splitContainer1.Size = new System.Drawing.Size(508, 474);
            this.splitContainer1.SplitterDistance = 87;
            this.splitContainer1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Xuân",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Khuê Trung"});
            this.comboBox1.Location = new System.Drawing.Point(69, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Phường/Xã :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(371, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cập nhật";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // treeList1
            // 
            treeList1.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            treeList1.Appearance.BandPanel.Options.UseFont = true;
            treeList1.Appearance.Caption.Font = new System.Drawing.Font("Tahoma", 9F);
            treeList1.Appearance.Caption.Options.UseFont = true;
            treeList1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            treeList1.Appearance.FilterPanel.Options.UseFont = true;
            treeList1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9F);
            treeList1.Appearance.FocusedCell.Options.UseFont = true;
            treeList1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9F);
            treeList1.Appearance.FocusedRow.Options.UseFont = true;
            treeList1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            treeList1.Appearance.FooterPanel.Options.UseFont = true;
            treeList1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            treeList1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.5F);
            treeList1.Appearance.Row.Options.UseFont = true;
            treeList1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            treeList1.Appearance.SelectedRow.Options.UseFont = true;
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn4,
            this.treeListColumn5});
            treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            treeList1.Location = new System.Drawing.Point(0, 0);
            treeList1.Name = "treeList1";
            treeList1.BeginUnboundLoad();
            treeList1.EndUnboundLoad();
            treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            treeList1.Size = new System.Drawing.Size(508, 383);
            treeList1.TabIndex = 43;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn4.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn4.Caption = "Lớp layer";
            this.treeListColumn4.FieldName = "Tên lớp";
            this.treeListColumn4.MinWidth = 52;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 0;
            this.treeListColumn4.Width = 342;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn5.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn5.Caption = "Tên layer";
            this.treeListColumn5.ColumnEdit = this.repositoryItemComboBox1;
            this.treeListColumn5.FieldName = "Tên layer";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 1;
            this.treeListColumn5.Width = 274;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // FrmChonDoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 474);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChonDoiTuong";
            this.Text = "Chọn lớp layer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}