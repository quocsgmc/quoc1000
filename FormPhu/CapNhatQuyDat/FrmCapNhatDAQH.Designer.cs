namespace QLHTDT.FormPhu.CapNhatQuyDat
{
    partial class FrmCapNhatDAQH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCapNhatDAQH));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.CboChonShp = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btMo2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CboMaDuAn = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 66);
            this.panel1.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(128, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 41);
            this.button4.TabIndex = 6;
            this.button4.Text = "Cập nhật";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // CboChonShp
            // 
            this.CboChonShp.FormattingEnabled = true;
            this.CboChonShp.Location = new System.Drawing.Point(12, 23);
            this.CboChonShp.Name = "CboChonShp";
            this.CboChonShp.Size = new System.Drawing.Size(239, 21);
            this.CboChonShp.TabIndex = 7;
            this.CboChonShp.SelectedIndexChanged += new System.EventHandler(this.CboChonShp2_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Chọn file Shapefile";
            // 
            // btMo2
            // 
            this.btMo2.Location = new System.Drawing.Point(257, 12);
            this.btMo2.Name = "btMo2";
            this.btMo2.Size = new System.Drawing.Size(56, 33);
            this.btMo2.TabIndex = 9;
            this.btMo2.Text = "Mở";
            this.btMo2.UseVisualStyleBackColor = true;
            this.btMo2.Click += new System.EventHandler(this.btMo2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Chọn cột mã dự án";
            // 
            // CboMaDuAn
            // 
            this.CboMaDuAn.FormattingEnabled = true;
            this.CboMaDuAn.Location = new System.Drawing.Point(12, 70);
            this.CboMaDuAn.Name = "CboMaDuAn";
            this.CboMaDuAn.Size = new System.Drawing.Size(239, 21);
            this.CboMaDuAn.TabIndex = 11;
            this.CboMaDuAn.SelectedIndexChanged += new System.EventHandler(this.CboMaDuAn_SelectedIndexChanged);
            // 
            // FrmCapNhatDAQH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 181);
            this.Controls.Add(this.CboMaDuAn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CboChonShp);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btMo2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCapNhatDAQH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật ranh giới dự án quy hoạch";
            this.Load += new System.EventHandler(this.FrmCapNhatDAQH_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox CboChonShp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btMo2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CboMaDuAn;
    }
}