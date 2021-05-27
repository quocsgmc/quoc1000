namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS
{
    partial class ChinhSuaChuDauTu
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtTenChuDauTu = new System.Windows.Forms.TextBox();
            this.BtExcell = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtGhiChu);
            this.panel1.Controls.Add(this.txtTenChuDauTu);
            this.panel1.Controls.Add(this.BtExcell);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 132);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(8, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 93;
            this.label4.Text = "Ghi chú:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(5, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 92;
            this.label2.Text = "Tên Chủ đầu tư:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(99, 39);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(196, 20);
            this.txtGhiChu.TabIndex = 1;
            // 
            // txtTenChuDauTu
            // 
            this.txtTenChuDauTu.Location = new System.Drawing.Point(99, 12);
            this.txtTenChuDauTu.Name = "txtTenChuDauTu";
            this.txtTenChuDauTu.Size = new System.Drawing.Size(196, 20);
            this.txtTenChuDauTu.TabIndex = 0;
            // 
            // BtExcell
            // 
            this.BtExcell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtExcell.Image = global::QLHTDT.Properties.Resources.Exit_32x32;
            this.BtExcell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtExcell.Location = new System.Drawing.Point(166, 75);
            this.BtExcell.Name = "BtExcell";
            this.BtExcell.Size = new System.Drawing.Size(128, 44);
            this.BtExcell.TabIndex = 3;
            this.BtExcell.Text = "         Hủy";
            this.BtExcell.UseVisualStyleBackColor = true;
            this.BtExcell.Click += new System.EventHandler(this.BtExcell_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::QLHTDT.Properties.Resources.EditingSelectedGeodatabase32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(18, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 44);
            this.button2.TabIndex = 2;
            this.button2.Text = "Chỉnh sửa\r\n chủ đầu tư";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ChinhSuaChuDauTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 140);
            this.Controls.Add(this.panel1);
            this.Name = "ChinhSuaChuDauTu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa chủ đầu tư";
            this.Load += new System.EventHandler(this.ChinhSuaChuDauTu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button BtExcell;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtTenChuDauTu;
    }
}