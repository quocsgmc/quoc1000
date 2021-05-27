namespace QLHTDT.FormPhu.CapNhat
{
    partial class TestMBQH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestMBQH));
            this.btChuyen = new System.Windows.Forms.Button();
            this.txtpolygon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtline = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboLoaiDat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btChuyen
            // 
            this.btChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChuyen.Location = new System.Drawing.Point(116, 152);
            this.btChuyen.Name = "btChuyen";
            this.btChuyen.Size = new System.Drawing.Size(111, 41);
            this.btChuyen.TabIndex = 59;
            this.btChuyen.Text = "Xuất File";
            this.btChuyen.UseVisualStyleBackColor = true;
            this.btChuyen.Click += new System.EventHandler(this.btChuyen_Click);
            // 
            // txtpolygon
            // 
            this.txtpolygon.Location = new System.Drawing.Point(39, 71);
            this.txtpolygon.Name = "txtpolygon";
            this.txtpolygon.Size = new System.Drawing.Size(292, 20);
            this.txtpolygon.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Chọn đường dẫn lưu Polygon";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(9, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 56;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtline
            // 
            this.txtline.Location = new System.Drawing.Point(39, 25);
            this.txtline.Name = "txtline";
            this.txtline.Size = new System.Drawing.Size(292, 20);
            this.txtline.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Chọn dữ liệu Line";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(9, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 53;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboLoaiDat
            // 
            this.comboLoaiDat.FormattingEnabled = true;
            this.comboLoaiDat.Location = new System.Drawing.Point(39, 121);
            this.comboLoaiDat.Name = "comboLoaiDat";
            this.comboLoaiDat.Size = new System.Drawing.Size(291, 21);
            this.comboLoaiDat.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Chọn loại đất";
            // 
            // TestMBQH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 201);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboLoaiDat);
            this.Controls.Add(this.btChuyen);
            this.Controls.Add(this.txtpolygon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "TestMBQH";
            this.Text = "Chuyển dữ liệu Shapefile sang dạng vùng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btChuyen;
        private System.Windows.Forms.TextBox txtpolygon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboLoaiDat;
        private System.Windows.Forms.Label label3;
    }
}