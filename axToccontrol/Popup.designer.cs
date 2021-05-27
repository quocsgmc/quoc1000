namespace QLHTDT.FormPhu
{
    partial class Popup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Popup));
            this.chkShowTips = new System.Windows.Forms.CheckBox();
            this.cboDataField = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkShowTips
            // 
            this.chkShowTips.BackColor = System.Drawing.SystemColors.Control;
            this.chkShowTips.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkShowTips.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowTips.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkShowTips.Location = new System.Drawing.Point(87, 40);
            this.chkShowTips.Name = "chkShowTips";
            this.chkShowTips.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkShowTips.Size = new System.Drawing.Size(129, 25);
            this.chkShowTips.TabIndex = 15;
            this.chkShowTips.Text = "Hiện thông tin";
            this.chkShowTips.UseVisualStyleBackColor = false;
            this.chkShowTips.CheckedChanged += new System.EventHandler(this.chkShowTips_CheckedChanged);
            this.chkShowTips.CheckStateChanged += new System.EventHandler(this.chkShowTips_CheckStateChanged);
            // 
            // cboDataField
            // 
            this.cboDataField.BackColor = System.Drawing.SystemColors.Window;
            this.cboDataField.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboDataField.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDataField.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboDataField.Location = new System.Drawing.Point(87, 12);
            this.cboDataField.Name = "cboDataField";
            this.cboDataField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboDataField.Size = new System.Drawing.Size(161, 22);
            this.cboDataField.TabIndex = 14;
            this.cboDataField.SelectedIndexChanged += new System.EventHandler(this.cboDataField_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(12, 15);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(60, 17);
            this.Label2.TabIndex = 17;
            this.Label2.Text = "Trường:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 28);
            this.button1.TabIndex = 20;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 28);
            this.button2.TabIndex = 21;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 129);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkShowTips);
            this.Controls.Add(this.cboDataField);
            this.Controls.Add(this.Label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Popup";
            this.Text = "Hiễn thị Tips thông tin nhanh";
            this.Load += new System.EventHandler(this.Popup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckBox chkShowTips;
        public System.Windows.Forms.ComboBox cboDataField;
        public System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}