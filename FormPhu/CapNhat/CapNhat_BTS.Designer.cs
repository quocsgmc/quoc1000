namespace QLHTDT.FormPhu.CapNhat
{
    partial class CapNhat_BTS
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.comboPhuong = new System.Windows.Forms.ComboBox();
            this.comboQuan = new System.Windows.Forms.ComboBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Phường/Xã";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Quận/Huyện";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(384, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Cập nhật";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.UpdateBTS_Click);
            // 
            // comboPhuong
            // 
            this.comboPhuong.FormattingEnabled = true;
            this.comboPhuong.Items.AddRange(new object[] {
            "Hòa An"});
            this.comboPhuong.Location = new System.Drawing.Point(264, 39);
            this.comboPhuong.Name = "comboPhuong";
            this.comboPhuong.Size = new System.Drawing.Size(114, 21);
            this.comboPhuong.TabIndex = 22;
            // 
            // comboQuan
            // 
            this.comboQuan.FormattingEnabled = true;
            this.comboQuan.Location = new System.Drawing.Point(76, 39);
            this.comboQuan.Name = "comboQuan";
            this.comboQuan.Size = new System.Drawing.Size(121, 21);
            this.comboQuan.TabIndex = 21;
            this.comboQuan.SelectedIndexChanged += new System.EventHandler(this.comboQuan_SelectedIndexChanged);
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 66);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(366, 136);
            this.dgvData.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OpenExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Excel Path";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(302, 20);
            this.textBox1.TabIndex = 17;
            // 
            // CapNhat_BTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 233);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboPhuong);
            this.Controls.Add(this.comboQuan);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "CapNhat_BTS";
            this.Text = "Cập nhật BTS";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboPhuong;
        private System.Windows.Forms.ComboBox comboQuan;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}