namespace QLHTDT.FormPhu.InAn
{
    partial class ToolIn
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
            //Release COM objects
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolIn));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPrinterOrientation = new System.Windows.Forms.Label();
            this.fraPrinter = new System.Windows.Forms.GroupBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblPrinterSize = new System.Windows.Forms.Label();
            this.lblPdcdcrinter = new System.Windows.Forms.Label();
            this.listPrinter = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbMxFilePath = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(axPageLayoutControl1)).BeginInit();
            this.fraPrinter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(207, 268);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 17;
            // 
            // axPageLayoutControl1
            // 
            axPageLayoutControl1.Location = new System.Drawing.Point(153, 260);
            axPageLayoutControl1.Name = "axPageLayoutControl1";
            axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            axPageLayoutControl1.Size = new System.Drawing.Size(86, 40);
            axPageLayoutControl1.TabIndex = 16;
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
            "Crop - Theo tỉ lệ (xuất 1 trang)",
            "Tile - Theo tỉ lệ (xuất toàn bộ)",
            "Scale - Phi tỉ lệ (chỉnh trang in vừa với khung giấy in)"});
            this.comboBox1.Location = new System.Drawing.Point(345, 236);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(396, 334);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 49);
            this.button4.TabIndex = 14;
            this.button4.Text = "In";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(396, 268);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 48);
            this.button3.TabIndex = 13;
            this.button3.Text = "Xem trước trang in";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(396, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 44);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cài đặt trang";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 21);
            this.button1.TabIndex = 11;
            this.button1.Text = "Open File";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPrinterOrientation
            // 
            this.lblPrinterOrientation.BackColor = System.Drawing.SystemColors.Control;
            this.lblPrinterOrientation.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPrinterOrientation.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinterOrientation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrinterOrientation.Location = new System.Drawing.Point(117, 68);
            this.lblPrinterOrientation.Name = "lblPrinterOrientation";
            this.lblPrinterOrientation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrinterOrientation.Size = new System.Drawing.Size(102, 16);
            this.lblPrinterOrientation.TabIndex = 25;
            // 
            // fraPrinter
            // 
            this.fraPrinter.BackColor = System.Drawing.SystemColors.Control;
            this.fraPrinter.Controls.Add(this.lblPrinterOrientation);
            this.fraPrinter.Controls.Add(this.Label10);
            this.fraPrinter.Controls.Add(this.lblPrinterName);
            this.fraPrinter.Controls.Add(this.Label7);
            this.fraPrinter.Controls.Add(this.lblPrinterSize);
            this.fraPrinter.Controls.Add(this.lblPdcdcrinter);
            this.fraPrinter.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraPrinter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraPrinter.Location = new System.Drawing.Point(345, 62);
            this.fraPrinter.Name = "fraPrinter";
            this.fraPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraPrinter.Size = new System.Drawing.Size(227, 93);
            this.fraPrinter.TabIndex = 21;
            this.fraPrinter.TabStop = false;
            this.fraPrinter.Text = "Máy in";
            // 
            // Label10
            // 
            this.Label10.BackColor = System.Drawing.SystemColors.Control;
            this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label10.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label10.Location = new System.Drawing.Point(8, 68);
            this.Label10.Name = "Label10";
            this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label10.Size = new System.Drawing.Size(209, 16);
            this.Label10.TabIndex = 24;
            this.Label10.Text = "Chiều khổ giấy:";
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.BackColor = System.Drawing.SystemColors.Control;
            this.lblPrinterName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPrinterName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinterName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrinterName.Location = new System.Drawing.Point(48, 18);
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrinterName.Size = new System.Drawing.Size(174, 26);
            this.lblPrinterName.TabIndex = 4;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.SystemColors.Control;
            this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label7.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label7.Location = new System.Drawing.Point(8, 19);
            this.Label7.Name = "Label7";
            this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label7.Size = new System.Drawing.Size(209, 17);
            this.Label7.TabIndex = 3;
            this.Label7.Text = "Tên:";
            // 
            // lblPrinterSize
            // 
            this.lblPrinterSize.BackColor = System.Drawing.SystemColors.Control;
            this.lblPrinterSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPrinterSize.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinterSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrinterSize.Location = new System.Drawing.Point(72, 46);
            this.lblPrinterSize.Name = "lblPrinterSize";
            this.lblPrinterSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrinterSize.Size = new System.Drawing.Size(150, 17);
            this.lblPrinterSize.TabIndex = 2;
            // 
            // lblPdcdcrinter
            // 
            this.lblPdcdcrinter.BackColor = System.Drawing.SystemColors.Control;
            this.lblPdcdcrinter.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPdcdcrinter.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPdcdcrinter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPdcdcrinter.Location = new System.Drawing.Point(8, 44);
            this.lblPdcdcrinter.Name = "lblPdcdcrinter";
            this.lblPdcdcrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPdcdcrinter.Size = new System.Drawing.Size(209, 17);
            this.lblPdcdcrinter.TabIndex = 1;
            this.lblPdcdcrinter.Text = "Khổ giấy:";
            // 
            // listPrinter
            // 
            this.listPrinter.FormattingEnabled = true;
            this.listPrinter.Location = new System.Drawing.Point(345, 26);
            this.listPrinter.Name = "listPrinter";
            this.listPrinter.Size = new System.Drawing.Size(227, 21);
            this.listPrinter.TabIndex = 29;
            this.listPrinter.SelectedIndexChanged += new System.EventHandler(this.listPrinter_SelectedIndexChanged);
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.SystemColors.Control;
            this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label8.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label8.Location = new System.Drawing.Point(344, 9);
            this.Label8.Name = "Label8";
            this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label8.Size = new System.Drawing.Size(209, 25);
            this.Label8.TabIndex = 30;
            this.Label8.Text = "Chọn Máy in";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(344, 219);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(209, 58);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tùy chọn tỉ lệ";
            // 
            // txbMxFilePath
            // 
            this.txbMxFilePath.AcceptsReturn = true;
            this.txbMxFilePath.BackColor = System.Drawing.SystemColors.Window;
            this.txbMxFilePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMxFilePath.Enabled = false;
            this.txbMxFilePath.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMxFilePath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbMxFilePath.Location = new System.Drawing.Point(203, 241);
            this.txbMxFilePath.MaxLength = 0;
            this.txbMxFilePath.Name = "txbMxFilePath";
            this.txbMxFilePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbMxFilePath.Size = new System.Drawing.Size(117, 20);
            this.txbMxFilePath.TabIndex = 33;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 396);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // ToolIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 420);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txbMxFilePath);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listPrinter);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.fraPrinter);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(axPageLayoutControl1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ToolIn";
            this.Text = "In ấn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ToolIn_FormClosed);
            this.Load += new System.EventHandler(this.ToolIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(axPageLayoutControl1)).EndInit();
            this.fraPrinter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label lblPrinterOrientation;
        public System.Windows.Forms.GroupBox fraPrinter;
        public System.Windows.Forms.Label Label10;
        public System.Windows.Forms.Label lblPrinterName;
        public System.Windows.Forms.Label Label7;
        public System.Windows.Forms.Label lblPrinterSize;
        public System.Windows.Forms.Label lblPdcdcrinter;
        private System.Windows.Forms.ComboBox listPrinter;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txbMxFilePath;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}