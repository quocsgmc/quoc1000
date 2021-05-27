namespace QLHTDT.FormPhu.QTHT
{
    partial class EditPhongBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPhongBan));
            this.label4 = new System.Windows.Forms.Label();
            this.cbbPhuongXa = new System.Windows.Forms.ComboBox();
            this.TbMOTA = new System.Windows.Forms.TextBox();
            this.tbTenpb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CbbLOAI = new System.Windows.Forms.ComboBox();
            this.cbbDVHC = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Phường Xã:";
            // 
            // cbbPhuongXa
            // 
            this.cbbPhuongXa.FormattingEnabled = true;
            this.cbbPhuongXa.Location = new System.Drawing.Point(12, 210);
            this.cbbPhuongXa.Name = "cbbPhuongXa";
            this.cbbPhuongXa.Size = new System.Drawing.Size(215, 21);
            this.cbbPhuongXa.TabIndex = 66;
            // 
            // TbMOTA
            // 
            this.TbMOTA.Location = new System.Drawing.Point(12, 71);
            this.TbMOTA.Name = "TbMOTA";
            this.TbMOTA.Size = new System.Drawing.Size(215, 20);
            this.TbMOTA.TabIndex = 65;
            // 
            // tbTenpb
            // 
            this.tbTenpb.Location = new System.Drawing.Point(12, 29);
            this.tbTenpb.Name = "tbTenpb";
            this.tbTenpb.Size = new System.Drawing.Size(215, 20);
            this.tbTenpb.TabIndex = 64;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Quận Huyện:";
            // 
            // CbbLOAI
            // 
            this.CbbLOAI.FormattingEnabled = true;
            this.CbbLOAI.Location = new System.Drawing.Point(12, 116);
            this.CbbLOAI.Name = "CbbLOAI";
            this.CbbLOAI.Size = new System.Drawing.Size(215, 21);
            this.CbbLOAI.TabIndex = 62;
            this.CbbLOAI.SelectedIndexChanged += new System.EventHandler(this.CbbLOAI_SelectedIndexChanged);
            // 
            // cbbDVHC
            // 
            this.cbbDVHC.FormattingEnabled = true;
            this.cbbDVHC.Location = new System.Drawing.Point(12, 162);
            this.cbbDVHC.Name = "cbbDVHC";
            this.cbbDVHC.Size = new System.Drawing.Size(215, 21);
            this.cbbDVHC.TabIndex = 61;
            this.cbbDVHC.SelectedIndexChanged += new System.EventHandler(this.cbbDVHC_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(38, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 35);
            this.button1.TabIndex = 60;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Loại phòng ban:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Mô tả:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Tên phòng ban:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(130, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 35);
            this.button2.TabIndex = 68;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 284);
            this.Controls.Add(this.CbbLOAI);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbPhuongXa);
            this.Controls.Add(this.TbMOTA);
            this.Controls.Add(this.tbTenpb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbbDVHC);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditPhongBan";
            this.Text = "Chỉnh sửa thông tin phòng ban";
            this.Load += new System.EventHandler(this.EditPhongBan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbPhuongXa;
        private System.Windows.Forms.TextBox TbMOTA;
        private System.Windows.Forms.TextBox tbTenpb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbbLOAI;
        private System.Windows.Forms.ComboBox cbbDVHC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}