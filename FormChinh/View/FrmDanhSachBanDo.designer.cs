namespace QLHTDT.View
{
    partial class FrmDanhSachBanDo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDanhSachBanDo));
            this.listmxd = new System.Windows.Forms.ListBox();
            this.btopen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listmxd
            // 
            this.listmxd.DisplayMember = "alias";
            this.listmxd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listmxd.FormattingEnabled = true;
            this.listmxd.ItemHeight = 24;
            this.listmxd.Location = new System.Drawing.Point(12, 13);
            this.listmxd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listmxd.Name = "listmxd";
            this.listmxd.Size = new System.Drawing.Size(317, 316);
            this.listmxd.TabIndex = 9;
            this.listmxd.ValueMember = "name";
            // 
            // btopen
            // 
            this.btopen.Location = new System.Drawing.Point(115, 350);
            this.btopen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btopen.Name = "btopen";
            this.btopen.Size = new System.Drawing.Size(105, 55);
            this.btopen.TabIndex = 8;
            this.btopen.Text = "Open";
            this.btopen.UseVisualStyleBackColor = true;
            this.btopen.Click += new System.EventHandler(this.btopen_Click_1);
            // 
            // FrmDanhSachBanDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 418);
            this.Controls.Add(this.listmxd);
            this.Controls.Add(this.btopen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDanhSachBanDo";
            this.Text = "Danh sách bản đồ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listmxd;
        private System.Windows.Forms.Button btopen;
    }
}