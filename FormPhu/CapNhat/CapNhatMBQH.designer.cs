namespace QLHTDT.FormPhu.CapNhat
{
    partial class CapNhatMBQH
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
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btCapNhat = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btShape = new System.Windows.Forms.Button();
            this.btSDE = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboMaLoaiDat = new System.Windows.Forms.ComboBox();
            this.ComboTenLoaiDat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::QLHTDT.FormPhu.CapNhat.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBox2);
            this.splitContainer1.Panel1.Controls.Add(this.btCapNhat);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btShape);
            this.splitContainer1.Panel1.Controls.Add(this.btSDE);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.comboMaLoaiDat);
            this.splitContainer1.Panel2.Controls.Add(this.ComboTenLoaiDat);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(530, 176);
            this.splitContainer1.SplitterDistance = 70;
            this.splitContainer1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(114, 10);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(240, 21);
            this.comboBox2.TabIndex = 60;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged_1);
            // 
            // btCapNhat
            // 
            this.btCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCapNhat.Location = new System.Drawing.Point(436, 10);
            this.btCapNhat.Name = "btCapNhat";
            this.btCapNhat.Size = new System.Drawing.Size(87, 51);
            this.btCapNhat.TabIndex = 59;
            this.btCapNhat.Text = "Cập nhật";
            this.btCapNhat.UseVisualStyleBackColor = true;
            this.btCapNhat.Click += new System.EventHandler(this.btCapNhat_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(114, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(240, 21);
            this.comboBox1.TabIndex = 56;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged_1);
            // 
            // btShape
            // 
            this.btShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShape.Location = new System.Drawing.Point(360, 10);
            this.btShape.Name = "btShape";
            this.btShape.Size = new System.Drawing.Size(63, 48);
            this.btShape.TabIndex = 57;
            this.btShape.Text = "Mở File shp";
            this.btShape.UseVisualStyleBackColor = true;
            this.btShape.Click += new System.EventHandler(this.btShape_Click);
            // 
            // btSDE
            // 
            this.btSDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSDE.Location = new System.Drawing.Point(8, 10);
            this.btSDE.Name = "btSDE";
            this.btSDE.Size = new System.Drawing.Size(100, 48);
            this.btSDE.TabIndex = 58;
            this.btSDE.Text = "Mở Database";
            this.btSDE.UseVisualStyleBackColor = true;
            this.btSDE.Click += new System.EventHandler(this.btSDE_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(161, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Trường dữ liệu";
            // 
            // comboMaLoaiDat
            // 
            this.comboMaLoaiDat.FormattingEnabled = true;
            this.comboMaLoaiDat.Location = new System.Drawing.Point(157, 67);
            this.comboMaLoaiDat.Name = "comboMaLoaiDat";
            this.comboMaLoaiDat.Size = new System.Drawing.Size(366, 21);
            this.comboMaLoaiDat.TabIndex = 4;
            // 
            // ComboTenLoaiDat
            // 
            this.ComboTenLoaiDat.FormattingEnabled = true;
            this.ComboTenLoaiDat.Location = new System.Drawing.Point(157, 34);
            this.ComboTenLoaiDat.Name = "ComboTenLoaiDat";
            this.ComboTenLoaiDat.Size = new System.Drawing.Size(366, 21);
            this.ComboTenLoaiDat.TabIndex = 3;
            this.ComboTenLoaiDat.Text = "Chọn trường dữ liệu";
            this.ComboTenLoaiDat.SelectedIndexChanged += new System.EventHandler(this.ComboTenLoaiDat_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã loại đất:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên loại đất:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thuộc tính";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // CapNhatMBQH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 186);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CapNhatMBQH";
            this.Text = "Cập nhật dữ liệu";
            this.Load += new System.EventHandler(this.CapNhatMBQH_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btCapNhat;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btShape;
        private System.Windows.Forms.Button btSDE;
        public DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.ComboBox comboMaLoaiDat;
        private System.Windows.Forms.ComboBox ComboTenLoaiDat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}