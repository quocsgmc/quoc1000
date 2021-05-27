

using System;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Output;
using System.Collections;
using System.Drawing.Printing;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace QLHTDT.FormChinh
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class In : System.Windows.Forms.Form
    {
        public System.Windows.Forms.Button cmdLoadMxFile;
        public System.Windows.Forms.TextBox txbMxFilePath;
        public System.Windows.Forms.Label Line2;
        public System.Windows.Forms.GroupBox Frame2;
        public System.Windows.Forms.RadioButton optLandscape;
        public System.Windows.Forms.RadioButton optPortrait;
        public System.Windows.Forms.ComboBox cboPageToPrinterMapping;
        public System.Windows.Forms.ComboBox cboPageSize;
        public System.Windows.Forms.Label lblPageCount;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.GroupBox fraPrint;
        public System.Windows.Forms.TextBox txbOverlap;
        public System.Windows.Forms.Button cmdPrint;
        public System.Windows.Forms.TextBox txbStartPage;
        public System.Windows.Forms.TextBox txbEndPage;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.GroupBox fraPrinter;
        public System.Windows.Forms.Label lblPrinterOrientation;
        public System.Windows.Forms.Label Label10;
        public System.Windows.Forms.Label lblPrinterName;
        public System.Windows.Forms.Label Label7;
        public System.Windows.Forms.Label lblPrinterSize;
        public System.Windows.Forms.Label lblPdcdcrinter;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl2;
        private AxLicenseControl axLicenseControl1;
        private Label label3;
        private ComboBox listPrinter;
        internal PageSetupDialog pageSetupDialog1;
        private short m_CurrentPrintPage;
        public System.Windows.Forms.Button button1;
        internal PrintPreviewDialog printPreviewDialog1;
        private ITrackCancel m_TrackCancel = new CancelTrackerClass();
        private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();
        private ComboBox comboBox1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public In()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(In));
            this.cmdLoadMxFile = new System.Windows.Forms.Button();
            this.txbMxFilePath = new System.Windows.Forms.TextBox();
            this.Line2 = new System.Windows.Forms.Label();
            this.Frame2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.optLandscape = new System.Windows.Forms.RadioButton();
            this.optPortrait = new System.Windows.Forms.RadioButton();
            this.cboPageToPrinterMapping = new System.Windows.Forms.ComboBox();
            this.cboPageSize = new System.Windows.Forms.ComboBox();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.fraPrint = new System.Windows.Forms.GroupBox();
            this.txbOverlap = new System.Windows.Forms.TextBox();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.txbStartPage = new System.Windows.Forms.TextBox();
            this.txbEndPage = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.fraPrinter = new System.Windows.Forms.GroupBox();
            this.lblPrinterOrientation = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblPrinterSize = new System.Windows.Forms.Label();
            this.lblPdcdcrinter = new System.Windows.Forms.Label();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.axPageLayoutControl2 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.listPrinter = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Frame2.SuspendLayout();
            this.fraPrint.SuspendLayout();
            this.fraPrinter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdLoadMxFile
            // 
            this.cmdLoadMxFile.BackColor = System.Drawing.SystemColors.Control;
            this.cmdLoadMxFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdLoadMxFile.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLoadMxFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdLoadMxFile.Location = new System.Drawing.Point(381, 8);
            this.cmdLoadMxFile.Name = "cmdLoadMxFile";
            this.cmdLoadMxFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdLoadMxFile.Size = new System.Drawing.Size(113, 25);
            this.cmdLoadMxFile.TabIndex = 17;
            this.cmdLoadMxFile.Text = "Load Mx Document";
            this.cmdLoadMxFile.UseVisualStyleBackColor = false;
            this.cmdLoadMxFile.Click += new System.EventHandler(this.cmdLoadMxFile_Click);
            // 
            // txbMxFilePath
            // 
            this.txbMxFilePath.AcceptsReturn = true;
            this.txbMxFilePath.BackColor = System.Drawing.SystemColors.Window;
            this.txbMxFilePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMxFilePath.Enabled = false;
            this.txbMxFilePath.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMxFilePath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbMxFilePath.Location = new System.Drawing.Point(8, 8);
            this.txbMxFilePath.MaxLength = 0;
            this.txbMxFilePath.Name = "txbMxFilePath";
            this.txbMxFilePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbMxFilePath.Size = new System.Drawing.Size(368, 20);
            this.txbMxFilePath.TabIndex = 16;
            // 
            // Line2
            // 
            this.Line2.BackColor = System.Drawing.SystemColors.WindowText;
            this.Line2.Location = new System.Drawing.Point(8, 40);
            this.Line2.Name = "Line2";
            this.Line2.Size = new System.Drawing.Size(488, 1);
            this.Line2.TabIndex = 18;
            // 
            // Frame2
            // 
            this.Frame2.BackColor = System.Drawing.SystemColors.Control;
            this.Frame2.Controls.Add(this.label3);
            this.Frame2.Controls.Add(this.optLandscape);
            this.Frame2.Controls.Add(this.optPortrait);
            this.Frame2.Controls.Add(this.cboPageToPrinterMapping);
            this.Frame2.Controls.Add(this.cboPageSize);
            this.Frame2.Controls.Add(this.lblPageCount);
            this.Frame2.Controls.Add(this.Label9);
            this.Frame2.Controls.Add(this.Label8);
            this.Frame2.Controls.Add(this.Label6);
            this.Frame2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame2.Location = new System.Drawing.Point(421, 48);
            this.Frame2.Name = "Frame2";
            this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame2.Size = new System.Drawing.Size(227, 261);
            this.Frame2.TabIndex = 19;
            this.Frame2.TabStop = false;
            this.Frame2.Text = "Page";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 75);
            this.label3.TabIndex = 27;
            this.label3.Text = "Changing the page orientation or size may result in the map frame shrinking in re" +
    "lation to the page. This is dependant on the IPage::StretchGraphicsWithPage prop" +
    "erty.";
            // 
            // optLandscape
            // 
            this.optLandscape.BackColor = System.Drawing.SystemColors.Control;
            this.optLandscape.Cursor = System.Windows.Forms.Cursors.Default;
            this.optLandscape.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optLandscape.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optLandscape.Location = new System.Drawing.Point(74, 120);
            this.optLandscape.Name = "optLandscape";
            this.optLandscape.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.optLandscape.Size = new System.Drawing.Size(145, 25);
            this.optLandscape.TabIndex = 22;
            this.optLandscape.TabStop = true;
            this.optLandscape.Text = "Landscape";
            this.optLandscape.UseVisualStyleBackColor = false;
            this.optLandscape.Click += new System.EventHandler(this.optLandscape_Click);
            // 
            // optPortrait
            // 
            this.optPortrait.BackColor = System.Drawing.SystemColors.Control;
            this.optPortrait.Cursor = System.Windows.Forms.Cursors.Default;
            this.optPortrait.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPortrait.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optPortrait.Location = new System.Drawing.Point(8, 120);
            this.optPortrait.Name = "optPortrait";
            this.optPortrait.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.optPortrait.Size = new System.Drawing.Size(99, 25);
            this.optPortrait.TabIndex = 21;
            this.optPortrait.TabStop = true;
            this.optPortrait.Text = "Portrait";
            this.optPortrait.UseVisualStyleBackColor = false;
            this.optPortrait.Click += new System.EventHandler(this.optPortrait_Click);
            // 
            // cboPageToPrinterMapping
            // 
            this.cboPageToPrinterMapping.BackColor = System.Drawing.SystemColors.Window;
            this.cboPageToPrinterMapping.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboPageToPrinterMapping.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPageToPrinterMapping.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboPageToPrinterMapping.Location = new System.Drawing.Point(8, 88);
            this.cboPageToPrinterMapping.Name = "cboPageToPrinterMapping";
            this.cboPageToPrinterMapping.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboPageToPrinterMapping.Size = new System.Drawing.Size(209, 22);
            this.cboPageToPrinterMapping.TabIndex = 20;
            this.cboPageToPrinterMapping.SelectedIndexChanged += new System.EventHandler(this.cboPageToPrinterMapping_SelectedIndexChanged);
            this.cboPageToPrinterMapping.Click += new System.EventHandler(this.cboPageToPrinterMapping_Click);
            // 
            // cboPageSize
            // 
            this.cboPageSize.BackColor = System.Drawing.SystemColors.Window;
            this.cboPageSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboPageSize.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPageSize.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboPageSize.Location = new System.Drawing.Point(8, 40);
            this.cboPageSize.Name = "cboPageSize";
            this.cboPageSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboPageSize.Size = new System.Drawing.Size(209, 22);
            this.cboPageSize.TabIndex = 18;
            this.cboPageSize.SelectedIndexChanged += new System.EventHandler(this.cboPageSize_SelectedIndexChanged);
            // 
            // lblPageCount
            // 
            this.lblPageCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblPageCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPageCount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPageCount.Location = new System.Drawing.Point(97, 152);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPageCount.Size = new System.Drawing.Size(120, 17);
            this.lblPageCount.TabIndex = 26;
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.SystemColors.Control;
            this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label9.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label9.Location = new System.Drawing.Point(8, 152);
            this.Label9.Name = "Label9";
            this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label9.Size = new System.Drawing.Size(134, 17);
            this.Label9.TabIndex = 23;
            this.Label9.Text = "Page Count: ";
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.SystemColors.Control;
            this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label8.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label8.Location = new System.Drawing.Point(8, 72);
            this.Label8.Name = "Label8";
            this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label8.Size = new System.Drawing.Size(209, 25);
            this.Label8.TabIndex = 19;
            this.Label8.Text = "Page to Printer Mapping";
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.SystemColors.Control;
            this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label6.Location = new System.Drawing.Point(8, 24);
            this.Label6.Name = "Label6";
            this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label6.Size = new System.Drawing.Size(209, 33);
            this.Label6.TabIndex = 17;
            this.Label6.Text = "Page Size";
            // 
            // fraPrint
            // 
            this.fraPrint.BackColor = System.Drawing.SystemColors.Control;
            this.fraPrint.Controls.Add(this.txbOverlap);
            this.fraPrint.Controls.Add(this.cmdPrint);
            this.fraPrint.Controls.Add(this.txbStartPage);
            this.fraPrint.Controls.Add(this.txbEndPage);
            this.fraPrint.Controls.Add(this.Label5);
            this.fraPrint.Controls.Add(this.Label1);
            this.fraPrint.Controls.Add(this.Label2);
            this.fraPrint.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraPrint.Location = new System.Drawing.Point(421, 445);
            this.fraPrint.Name = "fraPrint";
            this.fraPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraPrint.Size = new System.Drawing.Size(227, 108);
            this.fraPrint.TabIndex = 21;
            this.fraPrint.TabStop = false;
            this.fraPrint.Text = "Print";
            // 
            // txbOverlap
            // 
            this.txbOverlap.AcceptsReturn = true;
            this.txbOverlap.BackColor = System.Drawing.SystemColors.Window;
            this.txbOverlap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbOverlap.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbOverlap.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbOverlap.Location = new System.Drawing.Point(160, 24);
            this.txbOverlap.MaxLength = 0;
            this.txbOverlap.Name = "txbOverlap";
            this.txbOverlap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbOverlap.Size = new System.Drawing.Size(57, 20);
            this.txbOverlap.TabIndex = 9;
            this.txbOverlap.Text = "0";
            this.txbOverlap.Leave += new System.EventHandler(this.txbOverlap_Leave);
            // 
            // cmdPrint
            // 
            this.cmdPrint.BackColor = System.Drawing.SystemColors.Control;
            this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdPrint.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdPrint.Location = new System.Drawing.Point(8, 72);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdPrint.Size = new System.Drawing.Size(209, 25);
            this.cmdPrint.TabIndex = 8;
            this.cmdPrint.Text = "Print Page Layout";
            this.cmdPrint.UseVisualStyleBackColor = false;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // txbStartPage
            // 
            this.txbStartPage.AcceptsReturn = true;
            this.txbStartPage.BackColor = System.Drawing.SystemColors.Window;
            this.txbStartPage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbStartPage.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbStartPage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbStartPage.Location = new System.Drawing.Point(59, 48);
            this.txbStartPage.MaxLength = 0;
            this.txbStartPage.Name = "txbStartPage";
            this.txbStartPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbStartPage.Size = new System.Drawing.Size(48, 20);
            this.txbStartPage.TabIndex = 7;
            this.txbStartPage.Text = "1";
            // 
            // txbEndPage
            // 
            this.txbEndPage.AcceptsReturn = true;
            this.txbEndPage.BackColor = System.Drawing.SystemColors.Window;
            this.txbEndPage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbEndPage.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEndPage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbEndPage.Location = new System.Drawing.Point(160, 48);
            this.txbEndPage.MaxLength = 0;
            this.txbEndPage.Name = "txbEndPage";
            this.txbEndPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbEndPage.Size = new System.Drawing.Size(57, 20);
            this.txbEndPage.TabIndex = 6;
            this.txbEndPage.Text = "0";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.SystemColors.Control;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label5.Location = new System.Drawing.Point(8, 48);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label5.Size = new System.Drawing.Size(51, 17);
            this.Label5.TabIndex = 12;
            this.Label5.Text = "Pages";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(117, 48);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(25, 17);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "To";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(8, 24);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(185, 33);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Overlap between pages";
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
            this.fraPrinter.Location = new System.Drawing.Point(421, 315);
            this.fraPrinter.Name = "fraPrinter";
            this.fraPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraPrinter.Size = new System.Drawing.Size(227, 93);
            this.fraPrinter.TabIndex = 20;
            this.fraPrinter.TabStop = false;
            this.fraPrinter.Text = "Printer";
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
            this.Label10.Text = "Paper Orientation:";
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
            this.Label7.Text = "Name:";
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
            this.lblPdcdcrinter.Location = new System.Drawing.Point(8, 46);
            this.lblPdcdcrinter.Name = "lblPdcdcrinter";
            this.lblPdcdcrinter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPdcdcrinter.Size = new System.Drawing.Size(209, 17);
            this.lblPdcdcrinter.TabIndex = 1;
            this.lblPdcdcrinter.Text = "Paper Size:";
            // 
            // axPageLayoutControl2
            // 
            this.axPageLayoutControl2.Location = new System.Drawing.Point(26, 59);
            this.axPageLayoutControl2.Name = "axPageLayoutControl2";
            this.axPageLayoutControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl2.OcxState")));
            this.axPageLayoutControl2.Size = new System.Drawing.Size(366, 494);
            this.axPageLayoutControl2.TabIndex = 25;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(212, 99);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 24;
            // 
            // listPrinter
            // 
            this.listPrinter.FormattingEnabled = true;
            this.listPrinter.Location = new System.Drawing.Point(496, 8);
            this.listPrinter.Name = "listPrinter";
            this.listPrinter.Size = new System.Drawing.Size(198, 21);
            this.listPrinter.TabIndex = 28;
            this.listPrinter.SelectedIndexChanged += new System.EventHandler(this.listPrinter_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(432, 414);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(209, 25);
            this.button1.TabIndex = 13;
            this.button1.Text = "Xem trước trang in";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(521, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 21);
            this.comboBox1.TabIndex = 29;
            // 
            // In
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(700, 568);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listPrinter);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axPageLayoutControl2);
            this.Controls.Add(this.fraPrint);
            this.Controls.Add(this.fraPrinter);
            this.Controls.Add(this.Frame2);
            this.Controls.Add(this.Line2);
            this.Controls.Add(this.cmdLoadMxFile);
            this.Controls.Add(this.txbMxFilePath);
            this.Name = "In";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Frame2.ResumeLayout(false);
            this.fraPrint.ResumeLayout(false);
            this.fraPrint.PerformLayout();
            this.fraPrinter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        

        private void cmdLoadMxFile_Click(object sender, System.EventArgs e)
        {
            //Open a file dialog for selecting map documents
            openFileDialog1.Title = "Browse Map Document";
            openFileDialog1.Filter = "Map Documents (*.mxd)|*.mxd";
            openFileDialog1.ShowDialog();

            //Exit if no map document is selected
            string sFilePath = openFileDialog1.FileName;
            if (sFilePath == "")
            {
                return;
            }

            //Validate and load the Mx document
            if (axPageLayoutControl2.CheckMxFile(sFilePath) == true)
            {
                axPageLayoutControl2.MousePointer = esriControlsMousePointer.esriPointerHourglass;
                axPageLayoutControl2.LoadMxFile(sFilePath, "");
                axPageLayoutControl2.MousePointer = esriControlsMousePointer.esriPointerDefault;
                txbMxFilePath.Text = sFilePath;
            }
            else
            {
                MessageBox.Show(sFilePath + " is not a valid ArcMap document");
            }

            //Update page display
            cboPageSize.SelectedIndex = (int)axPageLayoutControl2.Page.FormID;
            cboPageToPrinterMapping.SelectedIndex = (int)axPageLayoutControl2.Page.PageToPrinterMapping;
            if (axPageLayoutControl2.Page.Orientation == 1)
            {
                optPortrait.Checked = true;
            }
            else
            {
                optLandscape.Checked = true;
            }

            //Zoom to whole page
            axPageLayoutControl2.ZoomToWholePage();

            //Update printer page display
            UpdatePrintPageDisplay();




            //IObjectCopy pObjectCopy = new ObjectCopyClass();
            //object copyFromMap = QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView.FocusMap;
            //object copiedMap = pObjectCopy.Copy(copyFromMap);//copiedMap
            //object copyToMap = axPageLayoutControl2.ActiveView.FocusMap;
            //pObjectCopy.Overwrite(copiedMap, ref copyToMap);//
            //axPageLayoutControl2.ActiveView.Refresh();
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
        private void Form1_Load(object sender, System.EventArgs e)
        {
            InitializePrintPreviewDialog();
            foreach (string printera in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                listPrinter.Items.Add(printera);
            }
            //Add esriPageFormID constants to drop down
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
            cboPageSize.SelectedIndex = 7;
            listPrinter.SelectedIndex = 1;

            comboBox1.Items.Add("esriPageMappingTile");
            comboBox1.Items.Add("esriPageMappingCrop");
            comboBox1.Items.Add("esriPageMappingScale");
           // pageSetupDialog1 = new PageSetupDialog();
           // pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
           // pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
           // pageSetupDialog1.ShowNetwork = false;

           // pageSetupDialog1.PrinterSettings.PrinterName = listPrinter.SelectedItem.ToString();

           //// printDocument.PrinterSettings.PrinterName = "YOUR_PRINTER";
           // int i;
           // IEnumerator paperSizes = pageSetupDialog1.PrinterSettings.PaperSizes.GetEnumerator();
           // paperSizes.Reset();
           // for (i = 0; i < pageSetupDialog1.PrinterSettings.PaperSizes.Count; ++i)
           // {
           //     paperSizes.MoveNext();
           //     cboPageSize.Items.Add(pageSetupDialog1.PrinterSettings.PaperSizes[i].PaperName);
           // }


            //Add esriPageToPrinterMapping constants to drop down
            cboPageToPrinterMapping.Items.Add("0: Crop");
            cboPageToPrinterMapping.Items.Add("1: Scale");
            cboPageToPrinterMapping.Items.Add("2: Tile");
            cboPageToPrinterMapping.SelectedIndex = 1;
            optPortrait.Checked = true;
            EnableOrientation(false);

            //Display printer details
            UpdatePrintingDisplay();
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

        private void UpdatePrintingDisplay()
        {
            if (axPageLayoutControl2.Printer != null)
            {
                //Get IPrinter interface through the PageLayoutControl's printer
                IPrinter printer = axPageLayoutControl2.Printer;

                //Determine the orientation of the printer's paper
                if (printer.Paper.Orientation == 1)
                {
                    lblPrinterOrientation.Text = "Portrait";
                }
                else
                {
                    lblPrinterOrientation.Text = "Landscape";
                }

                //Determine the printer name
                lblPrinterName.Text = printer.Paper.PrinterName;

                //Determine the printer's paper size
                double dWidth;
                double dheight;
                printer.Paper.QueryPaperSize(out dWidth, out dheight);
                lblPrinterSize.Text = dWidth.ToString("###.000") + " by " + dheight.ToString("###.000") + " Inches";
            }
        }

        private void txbOverlap_Leave(object sender, System.EventArgs e)
        {
            //Update printer page display
            UpdatePrintPageDisplay();
        }

        private void cboPageToPrinterMapping_Click(object sender, System.EventArgs e)
        {
            //Set the printer to page mapping
            axPageLayoutControl2.Page.PageToPrinterMapping = (esriPageToPrinterMapping)cboPageToPrinterMapping.SelectedIndex;
            //Update printer page display
            UpdatePrintPageDisplay();
        }

        private void optLandscape_Click(object sender, System.EventArgs e)
        {
            if (optLandscape.Checked == true)
            {
                //Set the page orientation
                if (axPageLayoutControl2.Page.FormID != esriPageFormID.esriPageFormSameAsPrinter)
                {
                    axPageLayoutControl2.Page.Orientation = 2;
                }
                //Update printer page display
                UpdatePrintPageDisplay();
            }
        }

        private void optPortrait_Click(object sender, System.EventArgs e)
        {
            if (optPortrait.Checked == true)
            {
                //Set the page orientation
                if (axPageLayoutControl2.Page.FormID != esriPageFormID.esriPageFormSameAsPrinter)
                {
                    axPageLayoutControl2.Page.Orientation = 1;
                }
                //Update printer page display
                UpdatePrintPageDisplay();
            }
        }

        private void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Orientation cannot change if the page size is set to 'Same as Printer'
            if (cboPageSize.SelectedIndex == 13)
                EnableOrientation(false);
            else
                EnableOrientation(true);
            //Set the page size
            axPageLayoutControl2.Page.FormID = (esriPageFormID)cboPageSize.SelectedIndex;
            //Update printer page display
            UpdatePrintPageDisplay();

            double dWidth;
            double dheight;

            axPageLayoutControl2.Page.QuerySize(out dWidth, out dheight);
            lblPrinterSize.Text = dWidth.ToString("###.000") + " by " + dheight.ToString("###.000") + " mm";
        }

        private void EnableOrientation(bool b)
        {
            optPortrait.Enabled = b;
            optLandscape.Enabled = b;
        }
        private void cmdPrint_Click(object sender, System.EventArgs e)
        {
            if (axPageLayoutControl2.Printer != null) 
            {
        //Set mouse pointer
        axPageLayoutControl2.MousePointer = esriControlsMousePointer.esriPointerHourglass;

        //Get IPrinter interface through the PageLayoutControl's printer
        IPrinter printer = axPageLayoutControl2.Printer;

        //Determine whether printer paper's orientation needs changing
        if (printer.Paper.Orientation != axPageLayoutControl2.Page.Orientation)
        {
          printer.Paper.Orientation = axPageLayoutControl2.Page.Orientation;
          //Update the display
          UpdatePrintingDisplay();
        }

        //Print the page range with the specified overlap
        axPageLayoutControl2.PrintPageLayout(Convert.ToInt16(txbStartPage.Text), Convert.ToInt16(txbEndPage.Text), Convert.ToDouble(txbOverlap.Text));

        //Set the mouse pointer
        axPageLayoutControl2.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }
                
                //Print the page range with the specified overlap
                
                //if (axPageLayoutControl1.Printer == null)
                //{
                //    MessageBox.Show("Unable to print!", "No default printer");
                //    return;
                //}

                ////Set printer papers orientation to that of the page.
                //axPageLayoutControl1.Printer.Paper.Orientation = axPageLayoutControl1.Page.Orientation;
                ////Scale to the page.
                //axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingScale;
                ////Send the page layout to the printer.
                //axPageLayoutControl1.PrintPageLayout();
            
            {
                //MessageBox.Show("Lỗi!", "Không thể in");
                return;
            }
        }

        private void cboPageToPrinterMapping_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set the printer to page mapping
            axPageLayoutControl2.Page.PageToPrinterMapping = (esriPageToPrinterMapping)cboPageToPrinterMapping.SelectedIndex;
            //Update printer page display
            UpdatePrintPageDisplay();
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboPageSize.Items.Clear();
            IPrinter printer = axPageLayoutControl2.Printer;
            axPageLayoutControl2.Printer.Paper.PrinterName = listPrinter.SelectedItem.ToString();
            
            lblPrinterName.Text = printer.Paper.PrinterName;
            lblPrinterName.Refresh();
            lblPrinterSize.Refresh();
            pageSetupDialog1 = new PageSetupDialog();
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            pageSetupDialog1.ShowNetwork = false;

            pageSetupDialog1.PrinterSettings.PrinterName = listPrinter.SelectedItem.ToString();

            // printDocument.PrinterSettings.PrinterName = "YOUR_PRINTER";
            //int i;
            //IEnumerator paperSizes = pageSetupDialog1.PrinterSettings.PaperSizes.GetEnumerator();
            //paperSizes.Reset();
            //for (i = 0; i < pageSetupDialog1.PrinterSettings.PaperSizes.Count; ++i)
            //{
            //    paperSizes.MoveNext();
            //    cboPageSize.Items.Add(pageSetupDialog1.PrinterSettings.PaperSizes[i].PaperName);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_CurrentPrintPage = 0;

            //check if a document is loaded into PageLayout  control
            if (axPageLayoutControl2.DocumentFilename == null) return;
            //set the name of the print preview document to the name of the mxd doc
            document.DocumentName = axPageLayoutControl2.DocumentFilename;

            //set the PrintPreviewDialog.Document property to the PrintDocument object selected by the user
            printPreviewDialog1.Document = document;

            //show the dialog - this triggers the document's PrintPage event
            printPreviewDialog1.ShowDialog();
        }
    }
}
