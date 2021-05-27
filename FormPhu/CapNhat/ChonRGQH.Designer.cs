namespace QLHTDT.FormPhu.CapNhat
{
    partial class ChonRGQH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChonRGQH));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(treeList1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(561, 398);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 0;
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
            this.treeListColumn7,
            this.treeListColumn8});
            treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            treeList1.Location = new System.Drawing.Point(0, 0);
            treeList1.Name = "treeList1";
            treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2,
            this.repositoryItemComboBox3});
            treeList1.Size = new System.Drawing.Size(561, 325);
            treeList1.TabIndex = 44;
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn7.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn7.Caption = "Đối tượng";
            this.treeListColumn7.FieldName = "Tên lớp";
            this.treeListColumn7.MinWidth = 52;
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 0;
            this.treeListColumn7.Width = 140;
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn8.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn8.Caption = "Chọn";
            this.treeListColumn8.ColumnEdit = this.repositoryItemCheckEdit2;
            this.treeListColumn8.FieldName = "Mở";
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.Visible = true;
            this.treeListColumn8.VisibleIndex = 1;
            this.treeListColumn8.Width = 43;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 34);
            this.button1.TabIndex = 45;
            this.button1.Text = "Cập nhật";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ChonRGQH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 398);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChonRGQH";
            this.Text = "Chọn vùng RGQH";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
        private System.Windows.Forms.Button button1;
    }
}