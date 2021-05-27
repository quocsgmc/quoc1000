namespace QLHTDT.FormPhu.CapNhat
{
    partial class FrmMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessage));
            this.label1 = new System.Windows.Forms.Label();
            this.btMoLopMoi = new System.Windows.Forms.Button();
            this.btLayLopDaMo = new System.Windows.Forms.Button();
            this.btHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đã có lớp dữ liệu trên bản đồ, có muốn mở lớp mới hay không ?";
            // 
            // btMoLopMoi
            // 
            this.btMoLopMoi.Location = new System.Drawing.Point(44, 59);
            this.btMoLopMoi.Name = "btMoLopMoi";
            this.btMoLopMoi.Size = new System.Drawing.Size(79, 45);
            this.btMoLopMoi.TabIndex = 1;
            this.btMoLopMoi.Text = "Mở lớp mới";
            this.btMoLopMoi.UseVisualStyleBackColor = true;
            this.btMoLopMoi.Click += new System.EventHandler(this.btMoLopMoi_Click);
            // 
            // btLayLopDaMo
            // 
            this.btLayLopDaMo.Location = new System.Drawing.Point(172, 59);
            this.btLayLopDaMo.Name = "btLayLopDaMo";
            this.btLayLopDaMo.Size = new System.Drawing.Size(81, 45);
            this.btLayLopDaMo.TabIndex = 2;
            this.btLayLopDaMo.Text = "Lấy lớp đã mở";
            this.btLayLopDaMo.UseVisualStyleBackColor = true;
            this.btLayLopDaMo.Click += new System.EventHandler(this.btLayLopDaMo_Click);
            // 
            // btHuy
            // 
            this.btHuy.Location = new System.Drawing.Point(307, 59);
            this.btHuy.Name = "btHuy";
            this.btHuy.Size = new System.Drawing.Size(76, 45);
            this.btHuy.TabIndex = 3;
            this.btHuy.Text = "Hủy";
            this.btHuy.UseVisualStyleBackColor = true;
            this.btHuy.Click += new System.EventHandler(this.btHuy_Click);
            // 
            // FrmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 118);
            this.Controls.Add(this.btHuy);
            this.Controls.Add(this.btLayLopDaMo);
            this.Controls.Add(this.btMoLopMoi);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMessage";
            this.Text = "Thông báo";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btMoLopMoi;
        private System.Windows.Forms.Button btLayLopDaMo;
        private System.Windows.Forms.Button btHuy;
    }
}