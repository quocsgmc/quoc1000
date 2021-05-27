namespace QLHTDT.axToccontrol
{
    partial class Symbology
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Symbology));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.ThemAll = new System.Windows.Forms.ToolStripButton();
            this.ThemLopTuyChon = new System.Windows.Forms.ToolStripButton();
            this.XoaAll = new System.Windows.Forms.ToolStripButton();
            this.XoaLopChon = new System.Windows.Forms.ToolStripButton();
            this.button3 = new System.Windows.Forms.Button();
            comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            comboBox2 = new System.Windows.Forms.ComboBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chế độ hiển thị";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Trường giá trị cần hiển thị";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Biểu tượng :";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ThemAll,
            this.ThemLopTuyChon,
            this.XoaAll,
            this.XoaLopChon});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(441, 25);
            this.bindingNavigator1.TabIndex = 7;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // ThemAll
            // 
            this.ThemAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ThemAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ThemAll.Image = ((System.Drawing.Image)(resources.GetObject("ThemAll.Image")));
            this.ThemAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ThemAll.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            this.ThemAll.Name = "ThemAll";
            this.ThemAll.Size = new System.Drawing.Size(74, 22);
            this.ThemAll.Text = "Thêm tất cả";
            this.ThemAll.Click += new System.EventHandler(this.ThemAll_Click);
            // 
            // ThemLopTuyChon
            // 
            this.ThemLopTuyChon.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ThemLopTuyChon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ThemLopTuyChon.Image = ((System.Drawing.Image)(resources.GetObject("ThemLopTuyChon.Image")));
            this.ThemLopTuyChon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ThemLopTuyChon.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            this.ThemLopTuyChon.Name = "ThemLopTuyChon";
            this.ThemLopTuyChon.Size = new System.Drawing.Size(112, 22);
            this.ThemLopTuyChon.Text = "Thêm lớp tùy chọn";
            this.ThemLopTuyChon.Click += new System.EventHandler(this.Them1_Click);
            // 
            // XoaAll
            // 
            this.XoaAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.XoaAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.XoaAll.Image = ((System.Drawing.Image)(resources.GetObject("XoaAll.Image")));
            this.XoaAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.XoaAll.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            this.XoaAll.Name = "XoaAll";
            this.XoaAll.Size = new System.Drawing.Size(63, 22);
            this.XoaAll.Text = "Xóa tất cả";
            this.XoaAll.Click += new System.EventHandler(this.XoaAll_Click);
            // 
            // XoaLopChon
            // 
            this.XoaLopChon.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.XoaLopChon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.XoaLopChon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.XoaLopChon.Image = ((System.Drawing.Image)(resources.GetObject("XoaLopChon.Image")));
            this.XoaLopChon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.XoaLopChon.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            this.XoaLopChon.Name = "XoaLopChon";
            this.XoaLopChon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.XoaLopChon.Size = new System.Drawing.Size(101, 22);
            this.XoaLopChon.Text = "Xóa lớp tùy chọn";
            this.XoaLopChon.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.XoaLopChon.Click += new System.EventHandler(this.XoaLopChon_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(68, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 26);
            this.button3.TabIndex = 12;
            this.button3.Text = "Chọn nhãn";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.all1Nhan_Click);
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(12, 109);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(197, 21);
            comboBox3.TabIndex = 11;
            comboBox3.SelectedIndexChanged += new System.EventHandler(comboBox3_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Hiển thị tất cả cùng 1 ký hiệu",
            "Hiển thị theo giá trị trong bảng thuộc tính"});
            this.comboBox1.Location = new System.Drawing.Point(12, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(268, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 93);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(301, 93);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(70, 21);
            comboBox2.TabIndex = 13;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 25);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(441, 303);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Location = new System.Drawing.Point(293, 197);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(26, 26);
            this.axSymbologyControl1.TabIndex = 13;
            this.axSymbologyControl1.Visible = false;
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.axSymbologyControl1);
            this.splitContainer3.Panel1.Controls.Add(this.button3);
            this.splitContainer3.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer3.Panel1.Controls.Add(comboBox3);
            this.splitContainer3.Panel1.Controls.Add(comboBox2);
            this.splitContainer3.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.label3);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer3.Panel2.Controls.Add(this.bindingNavigator1);
            this.splitContainer3.Size = new System.Drawing.Size(441, 474);
            this.splitContainer3.SplitterDistance = 142;
            this.splitContainer3.TabIndex = 10;
            // 
            // Symbology
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 474);
            this.Controls.Add(this.splitContainer3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Symbology";
            this.Text = "Tùy chỉnh biểu tượng ký hiệu";
            this.Load += new System.EventHandler(this.Symbology_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton ThemAll;
        private System.Windows.Forms.ToolStripButton ThemLopTuyChon;
        private System.Windows.Forms.ToolStripButton XoaAll;
        private System.Windows.Forms.ToolStripButton XoaLopChon;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        public static System.Windows.Forms.ComboBox comboBox3;
        public static System.Windows.Forms.ComboBox comboBox2;
    }
}