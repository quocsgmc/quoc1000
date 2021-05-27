namespace QLHTDT.FormPhu.QTHT
{
    partial class InsertPhongban
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertPhongban));
            this.TbMOTA = new System.Windows.Forms.TextBox();
            this.tbTenpb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CbbLOAI = new System.Windows.Forms.ComboBox();
            this.cbbDVHC = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbPhuongXa = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TbMOTA
            // 
            this.TbMOTA.Location = new System.Drawing.Point(12, 66);
            this.TbMOTA.Name = "TbMOTA";
            this.TbMOTA.Size = new System.Drawing.Size(215, 20);
            this.TbMOTA.TabIndex = 54;
            // 
            // tbTenpb
            // 
            this.tbTenpb.Location = new System.Drawing.Point(12, 24);
            this.tbTenpb.Name = "tbTenpb";
            this.tbTenpb.Size = new System.Drawing.Size(215, 20);
            this.tbTenpb.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Quận Huyện:";
            // 
            // CbbLOAI
            // 
            this.CbbLOAI.FormattingEnabled = true;
            this.CbbLOAI.Location = new System.Drawing.Point(12, 111);
            this.CbbLOAI.Name = "CbbLOAI";
            this.CbbLOAI.Size = new System.Drawing.Size(215, 21);
            this.CbbLOAI.TabIndex = 51;
            this.CbbLOAI.SelectedIndexChanged += new System.EventHandler(this.CbbLOAI_SelectedIndexChanged);
            // 
            // cbbDVHC
            // 
            this.cbbDVHC.FormattingEnabled = true;
            this.cbbDVHC.Location = new System.Drawing.Point(12, 157);
            this.cbbDVHC.Name = "cbbDVHC";
            this.cbbDVHC.Size = new System.Drawing.Size(215, 21);
            this.cbbDVHC.TabIndex = 50;
            this.cbbDVHC.SelectedIndexChanged += new System.EventHandler(this.cbbDVHC_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(80, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 43);
            this.button1.TabIndex = 45;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Loại phòng ban:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Mô tả:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Tên phòng ban:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Phường Xã:";
            // 
            // cbbPhuongXa
            // 
            this.cbbPhuongXa.FormattingEnabled = true;
            this.cbbPhuongXa.Location = new System.Drawing.Point(12, 205);
            this.cbbPhuongXa.Name = "cbbPhuongXa";
            this.cbbPhuongXa.Size = new System.Drawing.Size(215, 21);
            this.cbbPhuongXa.TabIndex = 55;
            // 
            // InsertPhongban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 287);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbPhuongXa);
            this.Controls.Add(this.TbMOTA);
            this.Controls.Add(this.tbTenpb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CbbLOAI);
            this.Controls.Add(this.cbbDVHC);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InsertPhongban";
            this.Text = "Thêm mới phòng ban";
            this.Load += new System.EventHandler(this.InsertPhongban_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbMOTA;
        private System.Windows.Forms.TextBox tbTenpb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbbLOAI;
        private System.Windows.Forms.ComboBox cbbDVHC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbPhuongXa;
    }
}