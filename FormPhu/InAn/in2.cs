using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing.Printing;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Output;

namespace QLHTDT.FormChinh
{

    public class In2 : System.Windows.Forms.Form
    {
        private System.ComponentModel.Container components = null;
        //buttons for open file, print preview, print dialog, page setup
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;

        //declare the dialogs for print preview, print dialog, page setup
        internal PrintPreviewDialog printPreviewDialog1;
        internal PrintDialog printDialog1;
        internal PageSetupDialog pageSetupDialog1;
        //declare a PrintDocument object named document, to be displayed in the print preview
        private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();
        //cancel tracker which is passed to the output function when printing to the print preview
        private ITrackCancel m_TrackCancel = new CancelTrackerClass();
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl2;
        public GroupBox fraPrinter;
        public Label lblPrinterName;
        public Label Label7;
        public Label lblPrinterSize;
        public Label lblPdcdcrinter;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private PictureBox pictureBox1;
        private ComboBox listPrinter;
        public ComboBox cboPageSize;
        public Label Label6;
        public RadioButton optLandscape;
        public RadioButton optPortrait;
        public TextBox txbOverlap;
        public TextBox txbStartPage;
        public TextBox txbEndPage;
        public Label Label5;
        public Label Label1;
        public Label Label2;
        public Label lblPageCount;
        public Label Label9;
        //the page that is currently printed to the print preview
        private short m_CurrentPrintPage;

        public In2()
        {
            InitializeComponent(); 
            
        }


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(In2));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.axPageLayoutControl2 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.fraPrinter = new System.Windows.Forms.GroupBox();
            this.cboPageSize = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.listPrinter = new System.Windows.Forms.ComboBox();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblPrinterSize = new System.Windows.Forms.Label();
            this.lblPdcdcrinter = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.optLandscape = new System.Windows.Forms.RadioButton();
            this.optPortrait = new System.Windows.Forms.RadioButton();
            this.txbOverlap = new System.Windows.Forms.TextBox();
            this.txbStartPage = new System.Windows.Forms.TextBox();
            this.txbEndPage = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl2)).BeginInit();
            this.fraPrinter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open File";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 50);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cài đặt trang";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(40, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 51);
            this.button3.TabIndex = 5;
            this.button3.Text = "Xem trước trang in";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(15, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // axPageLayoutControl2
            // 
            this.axPageLayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.axPageLayoutControl2.Name = "axPageLayoutControl2";
            this.axPageLayoutControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl2.OcxState")));
            this.axPageLayoutControl2.Size = new System.Drawing.Size(265, 265);
            this.axPageLayoutControl2.TabIndex = 0;
            // 
            // fraPrinter
            // 
            this.fraPrinter.BackColor = System.Drawing.SystemColors.Control;
            this.fraPrinter.Controls.Add(this.cboPageSize);
            this.fraPrinter.Controls.Add(this.Label6);
            this.fraPrinter.Controls.Add(this.listPrinter);
            this.fraPrinter.Controls.Add(this.lblPrinterName);
            this.fraPrinter.Controls.Add(this.Label7);
            this.fraPrinter.Controls.Add(this.lblPrinterSize);
            this.fraPrinter.Controls.Add(this.lblPdcdcrinter);
            this.fraPrinter.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraPrinter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraPrinter.Location = new System.Drawing.Point(3, 3);
            this.fraPrinter.Name = "fraPrinter";
            this.fraPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraPrinter.Size = new System.Drawing.Size(432, 88);
            this.fraPrinter.TabIndex = 21;
            this.fraPrinter.TabStop = false;
            this.fraPrinter.Text = "Máy in";
            // 
            // cboPageSize
            // 
            this.cboPageSize.BackColor = System.Drawing.SystemColors.Window;
            this.cboPageSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboPageSize.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPageSize.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboPageSize.Location = new System.Drawing.Point(228, 52);
            this.cboPageSize.Name = "cboPageSize";
            this.cboPageSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboPageSize.Size = new System.Drawing.Size(198, 22);
            this.cboPageSize.TabIndex = 20;
            this.cboPageSize.SelectedIndexChanged += new System.EventHandler(this.cboPageSize_SelectedIndexChanged);
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.SystemColors.Control;
            this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label6.Location = new System.Drawing.Point(228, 36);
            this.Label6.Name = "Label6";
            this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label6.Size = new System.Drawing.Size(198, 33);
            this.Label6.TabIndex = 19;
            this.Label6.Text = "Page Size";
            // 
            // listPrinter
            // 
            this.listPrinter.FormattingEnabled = true;
            this.listPrinter.Location = new System.Drawing.Point(228, 14);
            this.listPrinter.Name = "listPrinter";
            this.listPrinter.Size = new System.Drawing.Size(198, 22);
            this.listPrinter.TabIndex = 9;
            this.listPrinter.SelectedIndexChanged += new System.EventHandler(this.listPrinter_SelectedIndexChanged);
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.BackColor = System.Drawing.SystemColors.Control;
            this.lblPrinterName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPrinterName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinterName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrinterName.Location = new System.Drawing.Point(48, 16);
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
            this.Label7.Location = new System.Drawing.Point(8, 17);
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
            this.lblPrinterSize.Location = new System.Drawing.Point(72, 52);
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
            this.lblPdcdcrinter.Location = new System.Drawing.Point(8, 52);
            this.lblPdcdcrinter.Name = "lblPdcdcrinter";
            this.lblPdcdcrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPdcdcrinter.Size = new System.Drawing.Size(209, 17);
            this.lblPdcdcrinter.TabIndex = 1;
            this.lblPdcdcrinter.Text = "Khổ giấy:";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::QLHTDT.Properties.Resources.PrinterNetwork_32x32;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(40, 224);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 70);
            this.button4.TabIndex = 6;
            this.button4.Text = "IN       ";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.fraPrinter);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(530, 620);
            this.splitContainerControl1.SplitterPosition = 99;
            this.splitContainerControl1.TabIndex = 30;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.lblPageCount);
            this.splitContainerControl2.Panel2.Controls.Add(this.Label9);
            this.splitContainerControl2.Panel2.Controls.Add(this.txbOverlap);
            this.splitContainerControl2.Panel2.Controls.Add(this.txbStartPage);
            this.splitContainerControl2.Panel2.Controls.Add(this.txbEndPage);
            this.splitContainerControl2.Panel2.Controls.Add(this.Label5);
            this.splitContainerControl2.Panel2.Controls.Add(this.Label1);
            this.splitContainerControl2.Panel2.Controls.Add(this.Label2);
            this.splitContainerControl2.Panel2.Controls.Add(this.optLandscape);
            this.splitContainerControl2.Panel2.Controls.Add(this.optPortrait);
            this.splitContainerControl2.Panel2.Controls.Add(this.button1);
            this.splitContainerControl2.Panel2.Controls.Add(this.button3);
            this.splitContainerControl2.Panel2.Controls.Add(this.comboBox1);
            this.splitContainerControl2.Panel2.Controls.Add(this.button4);
            this.splitContainerControl2.Panel2.Controls.Add(this.button2);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(530, 516);
            this.splitContainerControl2.SplitterPosition = 251;
            this.splitContainerControl2.TabIndex = 22;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 361);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // optLandscape
            // 
            this.optLandscape.BackColor = System.Drawing.SystemColors.Control;
            this.optLandscape.Cursor = System.Windows.Forms.Cursors.Default;
            this.optLandscape.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optLandscape.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optLandscape.Location = new System.Drawing.Point(14, 331);
            this.optLandscape.Name = "optLandscape";
            this.optLandscape.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.optLandscape.Size = new System.Drawing.Size(145, 25);
            this.optLandscape.TabIndex = 24;
            this.optLandscape.TabStop = true;
            this.optLandscape.Text = "Landscape";
            this.optLandscape.UseVisualStyleBackColor = false;
            // 
            // optPortrait
            // 
            this.optPortrait.BackColor = System.Drawing.SystemColors.Control;
            this.optPortrait.Cursor = System.Windows.Forms.Cursors.Default;
            this.optPortrait.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPortrait.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optPortrait.Location = new System.Drawing.Point(15, 300);
            this.optPortrait.Name = "optPortrait";
            this.optPortrait.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.optPortrait.Size = new System.Drawing.Size(99, 25);
            this.optPortrait.TabIndex = 23;
            this.optPortrait.TabStop = true;
            this.optPortrait.Text = "Portrait";
            this.optPortrait.UseVisualStyleBackColor = false;
            // 
            // txbOverlap
            // 
            this.txbOverlap.AcceptsReturn = true;
            this.txbOverlap.BackColor = System.Drawing.SystemColors.Window;
            this.txbOverlap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbOverlap.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbOverlap.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbOverlap.Location = new System.Drawing.Point(164, 379);
            this.txbOverlap.MaxLength = 0;
            this.txbOverlap.Name = "txbOverlap";
            this.txbOverlap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbOverlap.Size = new System.Drawing.Size(57, 20);
            this.txbOverlap.TabIndex = 27;
            this.txbOverlap.Text = "0";
            // 
            // txbStartPage
            // 
            this.txbStartPage.AcceptsReturn = true;
            this.txbStartPage.BackColor = System.Drawing.SystemColors.Window;
            this.txbStartPage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbStartPage.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbStartPage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbStartPage.Location = new System.Drawing.Point(63, 403);
            this.txbStartPage.MaxLength = 0;
            this.txbStartPage.Name = "txbStartPage";
            this.txbStartPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbStartPage.Size = new System.Drawing.Size(48, 20);
            this.txbStartPage.TabIndex = 26;
            this.txbStartPage.Text = "1";
            // 
            // txbEndPage
            // 
            this.txbEndPage.AcceptsReturn = true;
            this.txbEndPage.BackColor = System.Drawing.SystemColors.Window;
            this.txbEndPage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbEndPage.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEndPage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbEndPage.Location = new System.Drawing.Point(164, 403);
            this.txbEndPage.MaxLength = 0;
            this.txbEndPage.Name = "txbEndPage";
            this.txbEndPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbEndPage.Size = new System.Drawing.Size(57, 20);
            this.txbEndPage.TabIndex = 25;
            this.txbEndPage.Text = "0";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.SystemColors.Control;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label5.Location = new System.Drawing.Point(12, 403);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label5.Size = new System.Drawing.Size(51, 17);
            this.Label5.TabIndex = 30;
            this.Label5.Text = "Pages";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(121, 403);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(25, 17);
            this.Label1.TabIndex = 29;
            this.Label1.Text = "To";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(12, 379);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(185, 33);
            this.Label2.TabIndex = 28;
            this.Label2.Text = "Overlap between pages";
            // 
            // lblPageCount
            // 
            this.lblPageCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblPageCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPageCount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPageCount.Location = new System.Drawing.Point(101, 426);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPageCount.Size = new System.Drawing.Size(120, 17);
            this.lblPageCount.TabIndex = 32;
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.SystemColors.Control;
            this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label9.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label9.Location = new System.Drawing.Point(12, 426);
            this.Label9.Name = "Label9";
            this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label9.Size = new System.Drawing.Size(134, 17);
            this.Label9.TabIndex = 31;
            this.Label9.Text = "Page Count: ";
            // 
            // In2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(530, 620);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "In2";
            this.Text = "Print Preview / Print dialog Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.In2_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.In2_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl2)).EndInit();
            this.fraPrinter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion



        private void Form1_Load(object sender, System.EventArgs e)
        {
            InitializePrintPreviewDialog(); //initialize the print preview dialog
            printDialog1 = new PrintDialog(); //create a print dialog object
            InitializePageSetupDialog();
            cboPageSize.Items.Clear();
            cboPageSize.Items.Add("Letter - 8.5in x 11in.");
            cboPageSize.Items.Add("Legal - 8.5in x 14in.");
            cboPageSize.Items.Add("Tabloid - 11in x 17in.");
            cboPageSize.Items.Add("C - 17in x 22in.");
            cboPageSize.Items.Add("D - 22in x 34in.");
            cboPageSize.Items.Add("E - 34in x 44in.");
            cboPageSize.Items.Add("A5 - 148mm x 210mm.");
            cboPageSize.Items.Add("A4 - 210mm x 297mm.");
            cboPageSize.Items.Add("A3 - 297mm x 420mm.");
            cboPageSize.Items.Add("A2 - 420mm x 594mm.");
            cboPageSize.Items.Add("A1 - 594mm x 841mm.");
            cboPageSize.Items.Add("A0 - 841mm x 1189mm.");
            cboPageSize.Items.Add("Custom Page Size.");
            cboPageSize.Items.Add("Same as Printer Form.");
            comboBox1.Items.Add("esriPageMappingTile");
            comboBox1.Items.Add("esriPageMappingCrop");
            comboBox1.Items.Add("esriPageMappingScale");
            comboBox1.SelectedIndex = 0;
            IPrinter printer = QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Printer;
            string a = QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Printer.Paper.PrinterName;
            
            lblPrinterName.Text = printer.Paper.PrinterName;
            double dWidth;
            double dheight;
            printer.Paper.QueryPaperSize(out dWidth, out dheight);
            lblPrinterSize.Text = dWidth.ToString("###.000") + " by " + dheight.ToString("###.000") + " Inches";

            QLHTDT.FormPhu.InAn.CoreXuatFile.ExportActiveViewParameterized(100, 1, "JPEG", System.IO.Path.GetDirectoryName(Application.ExecutablePath), false);
            pictureBox1.Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Review.jpg");
            //Load the same pre-authored map document into the MapControl.
            //QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.LoadMxFile(QuanTriHeThong.axMapControl1.DocumentFilename, null);
            //IObjectCopy pObjectCopy = new ObjectCopyClass();
            //object copyFromMap = QLHTDT.FormChinh.QuanTriHeThong.QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView.FocusMap;
            //object copiedMap = pObjectCopy.Copy(copyFromMap);//copiedMap
            //object copyToMap = QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView.FocusMap;
            //pObjectCopy.Overwrite(copiedMap, ref copyToMap);//
            //QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            //Set the extent of the MapControl to the full extent of the data.
            //QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Extent = QuanTriHeThong.QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Extent;
            //axToolbarControl1.SetBuddyControl(QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1);
            //QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            foreach (string printera in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                listPrinter.Items.Add(printera);
            }
        }

        private void InitializePrintPreviewDialog()
        {
            // create a new PrintPreviewDialog using constructor
            printPreviewDialog1 = new PrintPreviewDialog();
            //set the size, location, name and the minimum size the dialog can be resized to
            printPreviewDialog1.ClientSize = new System.Drawing.Size(800, 600);
            printPreviewDialog1.Location = new System.Drawing.Point(29, 29);
            printPreviewDialog1.Name = "PrintPreviewDialog1";
            printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
            //set UseAntiAlias to true to allow the operating system to smooth fonts
            printPreviewDialog1.UseAntiAlias = true;

            //associate the event-handling method with the document's PrintPage event
            this.document.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_PrintPage);
        }

        private void InitializePageSetupDialog()
        {
            //create a new PageSetupDialog using constructor
            pageSetupDialog1 = new PageSetupDialog();
            //initialize the dialog's PrinterSettings property to hold user defined printer settings
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            //initialize dialog's PrinterSettings property to hold user set printer settings
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            //do not show the network in the printer dialog
            pageSetupDialog1.ShowNetwork = false;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Stream myStream;

            //create an open file dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //set the file extension filter, filter index and restore directory flag
            openFileDialog1.Filter = "template files (*.mxt)|*.mxt|mxd files (*.mxd)|*.mxd";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            //display open file dialog and check if user clicked ok button
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //check if a file was selected
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    //get the selected filename and path
                    string fileName = openFileDialog1.FileName;

                    //check if selected file is mxd file
                    if (QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.CheckMxFile(fileName))
                    {
                        //load the mxd file into PageLayout  control
                        QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.LoadMxFile(fileName, "");
                    }
                    myStream.Close();
                }
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (listPrinter.SelectedItem != null)
            {
                pageSetupDialog1.PrinterSettings.PrinterName = listPrinter.SelectedItem.ToString();
            }
            //Show the page setup dialog storing the result.
            DialogResult result = pageSetupDialog1.ShowDialog();

            //set the printer settings of the preview document to the selected printer settings
            //document.PrinterSettings = pageSetupDialog1.PrinterSettings;

            //set the page settings of the preview document to the selected page settings
            //document.DefaultPageSettings = pageSetupDialog1.PageSettings;

            //due to a bug in PageSetupDialog the PaperSize has to be set explicitly by iterating through the
            //available PaperSizes in the PageSetupDialog finding the selected PaperSize
            int i;
            IEnumerator paperSizes = pageSetupDialog1.PrinterSettings.PaperSizes.GetEnumerator();
            paperSizes.Reset();

            for (i = 0; i < pageSetupDialog1.PrinterSettings.PaperSizes.Count; ++i)
            {
                paperSizes.MoveNext();
                if (((PaperSize)paperSizes.Current).Kind == document.DefaultPageSettings.PaperSize.Kind)
                {
                    document.DefaultPageSettings.PaperSize = ((PaperSize)paperSizes.Current);
                }
            }

            /////////////////////////////////////////////////////////////
            ///initialize the current printer from the printer settings selected
            ///in the page setup dialog
            /////////////////////////////////////////////////////////////
            IPaper paper;
            paper = new PaperClass(); //create a paper object

            IPrinter printer;
            printer = new EmfPrinterClass(); //create a printer object
            //in this case an EMF printer, alternatively a PS printer could be used

            //initialize the paper with the DEVMODE and DEVNAMES structures from the windows GDI
            //these structures specify information about the initialization and environment of a printer as well as
            //driver, device, and output port names for a printer
            paper.Attach(pageSetupDialog1.PrinterSettings.GetHdevmode(pageSetupDialog1.PageSettings).ToInt32(), pageSetupDialog1.PrinterSettings.GetHdevnames().ToInt32());

            //pass the paper to the emf printer
            printer.Paper = paper;

            //set the page layout control's printer to the currently selected printer
            QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Printer = printer;
            double dWidth;
            double dheight;
            printer.Paper.QueryPaperSize(out dWidth, out dheight);
            lblPrinterName.Refresh();
            lblPrinterSize.Refresh();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            //initialize the currently printed page number
            m_CurrentPrintPage = 0;

            //check if a document is loaded into PageLayout  control
            if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.DocumentFilename == null) return;
            //set the name of the print preview document to the name of the mxd doc
            document.DocumentName = QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.DocumentFilename;

            //set the PrintPreviewDialog.Document property to the PrintDocument object selected by the user
            printPreviewDialog1.Document = document;

            //show the dialog - this triggers the document's PrintPage event
            printPreviewDialog1.ShowDialog();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            //allow the user to choose the page range to be printed
            printDialog1.AllowSomePages = true;
            //show the help button.
            printDialog1.ShowHelp = true;

            //set the Document property to the PrintDocument for which the PrintPage Event 
            //has been handled. To display the dialog, either this property or the 
            //PrinterSettings property must be set 
            printDialog1.Document = document;

            //show the print dialog and wait for user input
            DialogResult result = printDialog1.ShowDialog();

            // If the result is OK then print the document.
            if (result == DialogResult.OK) document.Print();
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //this code will be called when the PrintPreviewDialog.Show method is called
            //set the PageToPrinterMapping property of the Page. This specifies how the page 
            //is mapped onto the printer page. By default the page will be tiled 
            //get the selected mapping option
            string sPageToPrinterMapping = (string)this.comboBox1.SelectedItem;
            if (sPageToPrinterMapping == null)
                //if no selection has been made the default is tiling
                QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
            else if (sPageToPrinterMapping.Equals("esriPageMappingTile"))
                QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
            else if (sPageToPrinterMapping.Equals("esriPageMappingCrop"))
                QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingCrop;
            else if (sPageToPrinterMapping.Equals("esriPageMappingScale"))
                QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingScale;
            else
                QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;

            //get the resolution of the graphics device used by the print preview (including the graphics device)
            short dpi = (short)e.Graphics.DpiX;
            //envelope for the device boundaries
            IEnvelope devBounds = new EnvelopeClass();
            //get page
            IPage page = QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Page;

            //the number of printer pages the page will be printed on
            short printPageCount;
            printPageCount = QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.get_PrinterPageCount(0);
            m_CurrentPrintPage++;

            //the currently selected printer
            IPrinter printer = QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Printer;
            //get the device bounds of the currently selected printer
            page.GetDeviceBounds(printer, m_CurrentPrintPage, 0, dpi, devBounds);

            //structure for the device boundaries
            tagRECT deviceRect;
            //Returns the coordinates of lower, left and upper, right corners
            double xmin, ymin, xmax, ymax;
            devBounds.QueryCoords(out xmin, out ymin, out xmax, out ymax);
            //initialize the structure for the device boundaries
            deviceRect.bottom = (int)ymax;
            deviceRect.left = (int)xmin;
            deviceRect.top = (int)ymin;
            deviceRect.right = (int)xmax;

            //determine the visible bounds of the currently printed page
            IEnvelope visBounds = new EnvelopeClass();
            page.GetPageBounds(printer, m_CurrentPrintPage, 0, visBounds);

            //get a handle to the graphics device that the print preview will be drawn to
            IntPtr hdc = e.Graphics.GetHdc();

            //print the page to the graphics device using the specified boundaries 
            QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView.Output(hdc.ToInt32(), dpi, ref deviceRect, visBounds, m_TrackCancel);

            //release the graphics device handle
            e.Graphics.ReleaseHdc(hdc);

            //check if further pages have to be printed
            if (m_CurrentPrintPage < printPageCount)
                e.HasMorePages = true; //document_PrintPage event will be called again
            else
                e.HasMorePages = false;

        }
        private void In2_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pictureBox1.Image = null;
        this.Refresh();
        }



        private void In2_FormClosed(object sender, System.EventArgs e)
        {
            //File.Delete(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "Review.jpg");
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPrinter printer = QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Printer;
            QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Printer.Paper.PrinterName = listPrinter.SelectedItem.ToString();
            lblPrinterName.Text = printer.Paper.PrinterName;
            pageSetupDialog1.PrinterSettings.PrinterName = listPrinter.SelectedItem.ToString();
            
            double dWidth;
            double dheight;
            printer.Paper.QueryPaperSize(out dWidth, out dheight);
            lblPrinterName.Refresh();
            lblPrinterSize.Refresh();
        }

        private void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {

            QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Page.FormID = (esriPageFormID)cboPageSize.SelectedIndex;
            IPrinter printer = QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Printer;
            double dWidth;
            double dheight;
            printer.Paper.QueryPaperSize(out dWidth, out dheight);
            QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Printer.Paper.PrinterName = listPrinter.SelectedItem.ToString();
            lblPrinterSize.Text = dWidth.ToString("###.000") + " by " + dheight.ToString("###.000") + " mm";
            UpdatePrintPageDisplay();
        }
        private void EnableOrientation(bool b)
        {
            optPortrait.Enabled = b;
            optLandscape.Enabled = b;
        }

        private void UpdatePrintPageDisplay()
        {
            //Determine the number of pages
            short iPageCount = axPageLayoutControl2.get_PrinterPageCount(Convert.ToDouble(txbOverlap.Text));
            lblPageCount.Text = iPageCount.ToString();

            //Validate start and end pages
            int iPageStart = Convert.ToInt32(txbStartPage.Text);
            int iPageEnd = Convert.ToInt32(txbEndPage.Text);
            if ((iPageStart < 1) | (iPageStart > iPageCount))
            {
                txbStartPage.Text = "1";
            }
            if ((iPageEnd < 1) | (iPageEnd > iPageCount))
            {
                txbEndPage.Text = iPageCount.ToString();
            }
        }
    }
}