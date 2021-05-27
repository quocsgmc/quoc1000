namespace QLHTDT.FormChinh
{
    partial class ChonKhoGiay
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ISO A0 ngang\t (841mm   x   1189mm)",
            "ISO A0 đứng \t (1189mm x   841mm)",
            "ISO A1 ngang\t (594mm   x   841mm)",
            "ISO A1 đứng\t (841mm   x   594mm)",
            "ISO A2 ngang\t (420mm   x   594mm)",
            "ISO A2 đứng \t (594mm   x   420mm)",
            "ISO A3 ngang\t (297mm   x   420mm)",
            "ISO A3 đứng \t (420mm   x   297mm)",
            "ISO A4 ngang\t (210mm   x   297mm)",
            "ISO A4 đứng\t (297mm   x   210mm)",
            "ISO A5 ngang\t (148mm   x   210mm)",
            "ISO A5 đứng\t (210mm   x  148 mm)"});
            this.comboBox1.Location = new System.Drawing.Point(27, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(229, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Chọn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChonKhoGiay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 115);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "ChonKhoGiay";
            this.Text = "Chọn khổ giấy";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}