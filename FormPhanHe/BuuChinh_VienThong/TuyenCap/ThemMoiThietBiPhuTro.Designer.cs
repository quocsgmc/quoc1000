namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap
{
    partial class ThemMoiThietBiPhuTro
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
            this.BtExcell = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboLoaiThietrBi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenThietBi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtExcell);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboLoaiThietrBi);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTenThietBi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtGhiChu);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 164);
            this.panel1.TabIndex = 0;
            // 
            // BtExcell
            // 
            this.BtExcell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtExcell.Image = global::QLHTDT.Properties.Resources.Exit_32x32;
            this.BtExcell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtExcell.Location = new System.Drawing.Point(163, 105);
            this.BtExcell.Name = "BtExcell";
            this.BtExcell.Size = new System.Drawing.Size(128, 44);
            this.BtExcell.TabIndex = 4;
            this.BtExcell.Text = "         Hủy";
            this.BtExcell.UseVisualStyleBackColor = true;
            this.BtExcell.Click += new System.EventHandler(this.BtExcell_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::QLHTDT.Properties.Resources.TrackingDataAdd32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(15, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Chấp nhận";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboLoaiThietrBi
            // 
            this.comboLoaiThietrBi.FormattingEnabled = true;
            this.comboLoaiThietrBi.Items.AddRange(new object[] {
            "",
            "Bể cáp",
            "Cột cáp treo",
            "Tuyến cáp treo",
            "Tuyến cáp ngầm"});
            this.comboLoaiThietrBi.Location = new System.Drawing.Point(88, 12);
            this.comboLoaiThietrBi.Name = "comboLoaiThietrBi";
            this.comboLoaiThietrBi.Size = new System.Drawing.Size(203, 21);
            this.comboLoaiThietrBi.TabIndex = 0;
            this.comboLoaiThietrBi.SelectedIndexChanged += new System.EventHandler(this.comboLoaiThietrBi_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(11, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 86;
            this.label4.Text = "Loại thiết bị:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 85;
            this.label1.Text = "Tên thiết bị:";
            // 
            // txtTenThietBi
            // 
            this.txtTenThietBi.Location = new System.Drawing.Point(88, 39);
            this.txtTenThietBi.Name = "txtTenThietBi";
            this.txtTenThietBi.Size = new System.Drawing.Size(203, 20);
            this.txtTenThietBi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(11, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 83;
            this.label2.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(88, 66);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(203, 20);
            this.txtGhiChu.TabIndex = 2;
            // 
            // ThemMoiThietBiPhuTro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 170);
            this.Controls.Add(this.panel1);
            this.Name = "ThemMoiThietBiPhuTro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mới thiết bị phụ trợ";
            this.Load += new System.EventHandler(this.ThemMoiThietBiPhuTro_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboLoaiThietrBi;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenThietBi;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button BtExcell;
    }
}