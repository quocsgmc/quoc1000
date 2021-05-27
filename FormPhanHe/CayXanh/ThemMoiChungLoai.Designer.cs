namespace QLHTDT.FormPhanHe.CayXanh
{
    partial class ThemMoiChungLoai
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtPhanLoai = new System.Windows.Forms.TextBox();
            this.txtTenChungLoai = new System.Windows.Forms.TextBox();
            this.BtExcell = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMoTa);
            this.panel1.Controls.Add(this.txtPhanLoai);
            this.panel1.Controls.Add(this.txtTenChungLoai);
            this.panel1.Controls.Add(this.BtExcell);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 154);
            this.panel1.TabIndex = 0;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(108, 38);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(236, 20);
            this.txtMoTa.TabIndex = 2;
            // 
            // txtPhanLoai
            // 
            this.txtPhanLoai.Location = new System.Drawing.Point(108, 65);
            this.txtPhanLoai.Name = "txtPhanLoai";
            this.txtPhanLoai.Size = new System.Drawing.Size(236, 20);
            this.txtPhanLoai.TabIndex = 3;
            // 
            // txtTenChungLoai
            // 
            this.txtTenChungLoai.Location = new System.Drawing.Point(108, 11);
            this.txtTenChungLoai.Name = "txtTenChungLoai";
            this.txtTenChungLoai.Size = new System.Drawing.Size(236, 20);
            this.txtTenChungLoai.TabIndex = 1;
            // 
            // BtExcell
            // 
            this.BtExcell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtExcell.Image = global::QLHTDT.Properties.Resources.Exit_32x32;
            this.BtExcell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtExcell.Location = new System.Drawing.Point(190, 103);
            this.BtExcell.Name = "BtExcell";
            this.BtExcell.Size = new System.Drawing.Size(128, 44);
            this.BtExcell.TabIndex = 5;
            this.BtExcell.Text = "         Hủy";
            this.BtExcell.UseVisualStyleBackColor = true;
            this.BtExcell.Click += new System.EventHandler(this.BtExcell_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::QLHTDT.Properties.Resources.TrackingDataAdd32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(37, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 44);
            this.button2.TabIndex = 4;
            this.button2.Text = "Chấp nhận";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(13, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 108;
            this.label5.Text = "Mô tả:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(14, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 107;
            this.label4.Text = "Phân loại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(11, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 106;
            this.label2.Text = "Tên chủng loại:";
            // 
            // ThemMoiChungLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 158);
            this.Controls.Add(this.panel1);
            this.Name = "ThemMoiChungLoai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mới Chủng loại cây xanh";
            this.Load += new System.EventHandler(this.ThemMoiChungLoai_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button BtExcell;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtPhanLoai;
        private System.Windows.Forms.TextBox txtTenChungLoai;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label2;
    }
}