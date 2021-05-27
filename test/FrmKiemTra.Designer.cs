namespace QLHTDT.test
{
    partial class FrmKiemTra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKiemTra));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHTHUA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHBanDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThayDoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chonshp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingSourceSHP = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.bindingSourceSDE = new System.Windows.Forms.BindingSource(this.components);
            this.btselectall = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoThua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoToBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThayDoiSDE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chonsde = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSHP)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSDE)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btselectall);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(610, 475);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.TabIndex = 1;
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
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(610, 392);
            this.splitContainer2.SplitterDistance = 191;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách thửa mới";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FID,
            this.SHTHUA,
            this.SHBanDo,
            this.ThayDoi,
            this.Chonshp});
            this.dataGridView1.DataSource = this.bindingSourceSHP;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(604, 172);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // FID
            // 
            this.FID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FID.DataPropertyName = "FID";
            this.FID.FillWeight = 20.9539F;
            this.FID.HeaderText = "Mã";
            this.FID.Name = "FID";
            // 
            // SHTHUA
            // 
            this.SHTHUA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SHTHUA.DataPropertyName = "SHTHUA";
            this.SHTHUA.FillWeight = 41.12204F;
            this.SHTHUA.HeaderText = "Số thửa";
            this.SHTHUA.Name = "SHTHUA";
            this.SHTHUA.ReadOnly = true;
            // 
            // SHBanDo
            // 
            this.SHBanDo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SHBanDo.DataPropertyName = "SHBANDO";
            this.SHBanDo.FillWeight = 41.12204F;
            this.SHBanDo.HeaderText = "Số tờ";
            this.SHBanDo.Name = "SHBanDo";
            this.SHBanDo.ReadOnly = true;
            // 
            // ThayDoi
            // 
            this.ThayDoi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ThayDoi.DataPropertyName = "ThayDoi";
            this.ThayDoi.FillWeight = 86.80203F;
            this.ThayDoi.HeaderText = "Thay đổi";
            this.ThayDoi.Name = "ThayDoi";
            // 
            // Chonshp
            // 
            this.Chonshp.HeaderText = "Chọn";
            this.Chonshp.Name = "Chonshp";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 197);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách thửa cũ";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma,
            this.SoThua,
            this.SoToBD,
            this.ThayDoiSDE,
            this.Chonsde});
            this.dataGridView2.DataSource = this.bindingSourceSDE;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 16);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(604, 178);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // btselectall
            // 
            this.btselectall.Location = new System.Drawing.Point(94, 13);
            this.btselectall.Name = "btselectall";
            this.btselectall.Size = new System.Drawing.Size(105, 40);
            this.btselectall.TabIndex = 2;
            this.btselectall.Text = "Chọn tất cả";
            this.btselectall.UseVisualStyleBackColor = true;
            this.btselectall.Click += new System.EventHandler(this.btselectall_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(366, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Ma
            // 
            this.Ma.DataPropertyName = "OBJECTID";
            this.Ma.FillWeight = 21F;
            this.Ma.HeaderText = "Mã";
            this.Ma.Name = "Ma";
            this.Ma.Width = 50;
            // 
            // SoThua
            // 
            this.SoThua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoThua.DataPropertyName = "Số thửa";
            this.SoThua.FillWeight = 36.96245F;
            this.SoThua.HeaderText = "Số thửa";
            this.SoThua.Name = "SoThua";
            this.SoThua.ReadOnly = true;
            // 
            // SoToBD
            // 
            this.SoToBD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoToBD.DataPropertyName = "Số tờ bản đồ";
            this.SoToBD.FillWeight = 32.76389F;
            this.SoToBD.HeaderText = "Số tờ";
            this.SoToBD.Name = "SoToBD";
            this.SoToBD.ReadOnly = true;
            // 
            // ThayDoiSDE
            // 
            this.ThayDoiSDE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ThayDoiSDE.DataPropertyName = "ThayDoiSDE";
            this.ThayDoiSDE.FillWeight = 71.25545F;
            this.ThayDoiSDE.HeaderText = "Thay đổi";
            this.ThayDoiSDE.Name = "ThayDoiSDE";
            // 
            // Chonsde
            // 
            this.Chonsde.HeaderText = "Chọn";
            this.Chonsde.Name = "Chonsde";
            // 
            // FrmKiemTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 475);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmKiemTra";
            this.Text = "Kiểm tra thay đổi";
            this.TopMost = true;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSHP)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSDE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHTHUA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHBanDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThayDoi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chonshp;
        public System.Windows.Forms.BindingSource bindingSourceSHP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        public System.Windows.Forms.BindingSource bindingSourceSDE;
        private System.Windows.Forms.Button btselectall;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoThua;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoToBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThayDoiSDE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chonsde;

    }
}