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
using ESRI.ArcGIS;
using QLHTDT.FormChinh;

namespace QLHTDT.FormPhu.InAn
{
    public partial class ToolIn : Form
    {

        //declare the dialogs for print preview, print dialog, page setup
        internal PrintPreviewDialog printPreviewDialog1;
        internal PrintDialog printDialog1;
        internal PageSetupDialog pageSetupDialog1;
        internal PageSetupDialog pageSetupDialog2;
        //declare a PrintDocument object named document, to be displayed in the print preview
        private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();
        //cancel tracker which is passed to the output function when printing to the print preview
        private ITrackCancel m_TrackCancel = new CancelTrackerClass();
        private IPrinter printer1;
        //the page that is currently printed to the print preview
        private short m_CurrentPrintPage;
        public ToolIn()
        {
            InitializeComponent();
        }

        private void ToolIn_Load(object sender, EventArgs e)
        {
            InitializePrintPreviewDialog(); //initialize the print preview dialog
            printDialog1 = new PrintDialog(); //create a print dialog object
            InitializePageSetupDialog();
            comboBox1.SelectedIndex = 0;
            //axPageLayoutControl1.LoadMxFile(QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.DocumentFilename);
            //IObjectCopy pObjectCopy = new ObjectCopyClass();
            //object copyFromMap = QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView.FocusMap;
            //object copiedMap = pObjectCopy.Copy(copyFromMap);//copiedMap
            //object copyToMap = axPageLayoutControl1.ActiveView.FocusMap;
            //pObjectCopy.Overwrite(copiedMap, ref copyToMap);//
            //axPageLayoutControl1.Printer = QuanTriHeThong.axPageLayoutControl1.Printer;
            //axPageLayoutControl1.Page.FormID = QuanTriHeThong.axPageLayoutControl1.Page.FormID;
            ////axPageLayoutControl1.PageLayout = QuanTriHeThong.axPageLayoutControl1.PageLayout;
            //axPageLayoutControl1.Refresh();
            //axPageLayoutControl1.ActiveView.Refresh();
            printer1 = new EmfPrinterClass();
            m_CurrentPrintPage = 0;
            foreach (string printera in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                listPrinter.Items.Add(printera);
            }
            
            double dWidth;
            double dheight;
            KienTruc.axPageLayoutControl1.Printer.Paper.QueryPaperSize(out dWidth, out dheight);
            lblPrinterSize.Text = dWidth.ToString("####.000") + " by " + dheight.ToString("####.000") + " Inches";
            lblPrinterSize.Refresh();
            if (KienTruc.axPageLayoutControl1.Printer.Paper.Orientation == 1)
            {
                lblPrinterOrientation.Text = "Đứng";
            }
            else
            {
                lblPrinterOrientation.Text = "Ngang";
            }
            //pObjectCopy.Overwrite(copiedMap, ref copyToMap);
            //axPageLayoutControl1.Refresh();
            //axPageLayoutControl1.ActiveView.Refresh();


            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile(System.IO.Path.GetTempPath() + "TrangIn.jpg");
            
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
                    if (KienTruc.axPageLayoutControl1.CheckMxFile(fileName) == true)
                    {
                        //load the mxd file into PageLayout	control
                        axPageLayoutControl1.LoadMxFile(fileName, "");
                        txbMxFilePath.Text = fileName;
                        axPageLayoutControl1.Printer.Paper.Orientation = axPageLayoutControl1.Page.Orientation;
                        double dWidth;
                        double dheight;
                        axPageLayoutControl1.Printer.Paper.QueryPaperSize(out dWidth, out dheight);
                        lblPrinterSize.Text = dWidth.ToString("####.000") + " by " + dheight.ToString("####.000") + " Inches";
                        lblPrinterSize.Refresh();
                        if (axPageLayoutControl1.Printer.Paper.Orientation == 1)
                        {
                            lblPrinterOrientation.Text = "Đứng";
                        }
                        else
                        {
                            lblPrinterOrientation.Text = "Ngang";
                        }
                        lblPrinterOrientation.Refresh();
                    }
                    myStream.Close();

                }
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (listPrinter.Text != "")
            {
                pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
                pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                pageSetupDialog1.ShowNetwork = false;
                pageSetupDialog1.PrinterSettings.PrinterName = listPrinter.SelectedItem.ToString();
                pageSetupDialog1.PageSettings.PrinterSettings.PrinterName = listPrinter.SelectedItem.ToString();
                DialogResult result = pageSetupDialog1.ShowDialog();
                document.PrinterSettings = pageSetupDialog1.PrinterSettings;
                document.DefaultPageSettings = pageSetupDialog1.PageSettings;

                //int i;
                //IEnumerator paperSizes = pageSetupDialog1.PrinterSettings.PaperSizes.GetEnumerator();
                //paperSizes.Reset();

                //for (i = 0; i < pageSetupDialog1.PrinterSettings.PaperSizes.Count; ++i)
                //{
                //    paperSizes.MoveNext();
                //    if (((PaperSize)paperSizes.Current).Height == document.DefaultPageSettings.PaperSize.Height && ((PaperSize)paperSizes.Current).Width == document.DefaultPageSettings.PaperSize.Width)
                //    {
                //        document.DefaultPageSettings.PaperSize = ((PaperSize)paperSizes.Current);
                //    }
                //}

                IPaper paper;
                paper = new PaperClass(); //create a paper object
                IPrinter printer;
                printer = new EmfPrinterClass();
                paper.Attach(pageSetupDialog1.PrinterSettings.GetHdevmode(pageSetupDialog1.PageSettings).ToInt32(), pageSetupDialog1.PrinterSettings.GetHdevnames().ToInt32());
                printer.Paper = paper;
                double dWidth;
                double dheight;
                printer.Paper.QueryPaperSize(out dWidth, out dheight);
                lblPrinterSize.Text = dWidth.ToString("####.000") + " by " + dheight.ToString("####.000") + " Inches";
                lblPrinterSize.Refresh();
                if (printer.Paper.Orientation == 1)
                {
                    lblPrinterOrientation.Text = "Đứng";
                }
                else
                {
                    lblPrinterOrientation.Text = "Ngang";
                }
            }
            else { MessageBox.Show("Chưa chọn máy in", "Thông báo"); }
           
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //create a new PageSetupDialog using constructor
            pageSetupDialog2 = new PageSetupDialog();
            //initialize the dialog's PrinterSettings property to hold user defined printer settings
            pageSetupDialog2.PageSettings = new System.Drawing.Printing.PageSettings();
            //initialize dialog's PrinterSettings property to hold user set printer settings
            pageSetupDialog2.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            //do not show the network in the printer dialog
            pageSetupDialog2.ShowNetwork = false;
            pageSetupDialog2.PrinterSettings = document.PrinterSettings;

            //set the page settings of the preview document to the selected page settings
            pageSetupDialog2.PageSettings = document.DefaultPageSettings;
            m_CurrentPrintPage = 0;

            //check if a document is loaded into PageLayout	control
            if (KienTruc.axPageLayoutControl1.DocumentFilename == null) return;
            //set the name of the print preview document to the name of the mxd doc

            IEnumerator paperSizes = pageSetupDialog2.PrinterSettings.PaperSizes.GetEnumerator();
            if (KienTruc.axPageLayoutControl1.Page.FormID == esriPageFormID.esriPageFormA0)
            {
                int i;
                paperSizes.Reset();

                for (i = 0; i < pageSetupDialog2.PrinterSettings.PaperSizes.Count; ++i)
                {
                    paperSizes.MoveNext();
                    if (((PaperSize)paperSizes.Current).Height == 4681 && ((PaperSize)paperSizes.Current).Width == 3311)
                    {
                        pageSetupDialog2.PageSettings.PaperSize = document.DefaultPageSettings.PaperSize;
                        i = pageSetupDialog2.PrinterSettings.PaperSizes.Count;
                    }
                }
            }
            else if (KienTruc.axPageLayoutControl1.Page.FormID == esriPageFormID.esriPageFormA1)
            {
                int i;
                paperSizes.Reset();

                for (i = 0; i < pageSetupDialog2.PrinterSettings.PaperSizes.Count; ++i)
                {
                    paperSizes.MoveNext();
                    if (((PaperSize)paperSizes.Current).Height == 4681 && ((PaperSize)paperSizes.Current).Width == 3311)
                    {
                        pageSetupDialog2.PageSettings.PaperSize = document.DefaultPageSettings.PaperSize;
                        i = pageSetupDialog2.PrinterSettings.PaperSizes.Count;
                    }
                }
            }
            else if (KienTruc.axPageLayoutControl1.Page.FormID == esriPageFormID.esriPageFormA2)
            {
                int i;
                paperSizes.Reset();

                for (i = 0; i < pageSetupDialog2.PrinterSettings.PaperSizes.Count; ++i)
                {
                    paperSizes.MoveNext();
                    if (((PaperSize)paperSizes.Current).Height == 4681 && ((PaperSize)paperSizes.Current).Width == 3311)
                    {
                        pageSetupDialog2.PageSettings.PaperSize = document.DefaultPageSettings.PaperSize;
                        i = pageSetupDialog2.PrinterSettings.PaperSizes.Count;
                    }
                }
            }
            else if (KienTruc.axPageLayoutControl1.Page.FormID == esriPageFormID.esriPageFormA3)
            {
                int i;
                paperSizes.Reset();

                for (i = 0; i < pageSetupDialog2.PrinterSettings.PaperSizes.Count; ++i)
                {
                    paperSizes.MoveNext();
                    if (((PaperSize)paperSizes.Current).Height == 4681 && ((PaperSize)paperSizes.Current).Width == 3311)
                    {
                        pageSetupDialog2.PageSettings.PaperSize = document.DefaultPageSettings.PaperSize;
                        i = pageSetupDialog2.PrinterSettings.PaperSizes.Count;
                    }
                }
            }
            else if (KienTruc.axPageLayoutControl1.Page.FormID == esriPageFormID.esriPageFormA4)
            {
                int i;
                paperSizes.Reset();

                for (i = 0; i < pageSetupDialog2.PrinterSettings.PaperSizes.Count; ++i)
                {
                    paperSizes.MoveNext();
                    if (((PaperSize)paperSizes.Current).Height == 4681 && ((PaperSize)paperSizes.Current).Width == 3311)
                    {
                        pageSetupDialog2.PageSettings.PaperSize = document.DefaultPageSettings.PaperSize;
                        i = pageSetupDialog2.PrinterSettings.PaperSizes.Count;
                    }
                }
                
            }
            else if (KienTruc.axPageLayoutControl1.Page.FormID == esriPageFormID.esriPageFormA5)
            {
                int i;
                paperSizes.Reset();
                for (i = 0; i < pageSetupDialog2.PrinterSettings.PaperSizes.Count; ++i)
                {
                    paperSizes.MoveNext();
                    if (((PaperSize)paperSizes.Current).Height == 4681 && ((PaperSize)paperSizes.Current).Width == 3311)
                    {
                        pageSetupDialog2.PageSettings.PaperSize = document.DefaultPageSettings.PaperSize;
                    }
                }
            }
            IPaper paper;
            paper = new PaperClass();
            IPrinter printer1;
            printer1 = new EmfPrinterClass();
            paper.Attach(pageSetupDialog2.PrinterSettings.GetHdevmode(pageSetupDialog2.PageSettings).ToInt32(), pageSetupDialog2.PrinterSettings.GetHdevnames().ToInt32());
            printer1.Paper = paper;
            KienTruc.axPageLayoutControl1.Printer = printer1;
            document.DocumentName = KienTruc.axPageLayoutControl1.DocumentFilename;
            printPreviewDialog1.Document = document;
            printPreviewDialog1.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            //allow the user to choose the page range to be printed
            printDialog1.AllowSomePages = true;
            //show the help button.
            printDialog1.ShowHelp = true;
            printDialog1.Document = document;
            printDialog1.PrinterSettings = document.DefaultPageSettings.PrinterSettings;
            //show the print dialog and wait for user input
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK) document.Print();
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string sPageToPrinterMapping = (string)this.comboBox1.SelectedItem;
            if (sPageToPrinterMapping == null)
                //if no selection has been made the default is tiling
                KienTruc.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
            else if (sPageToPrinterMapping.Equals("Tile - Theo tỉ lệ (xuất toàn bộ)"))
                KienTruc.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
            else if (sPageToPrinterMapping.Equals("Crop - Theo tỉ lệ (xuất 1 trang)"))
                KienTruc.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingCrop;
            else if (sPageToPrinterMapping.Equals("Scale - Phi tỉ lệ (chỉnh trang in vừa với khung giấy in)"))
                KienTruc.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingScale;
            else
                KienTruc.axPageLayoutControl1.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;

            //get the resolution of the graphics device used by the print preview (including the graphics device)
            short dpi = (short)e.Graphics.DpiX;
            //envelope for the device boundaries
            IEnvelope devBounds = new EnvelopeClass();
            //get page
            IPage page = KienTruc.axPageLayoutControl1.Page;

            //the number of printer pages the page will be printed on
            short printPageCount;
            printPageCount = KienTruc.axPageLayoutControl1.get_PrinterPageCount(0);
            //m_CurrentPrintPage++;

            //the currently selected printer
            IPrinter printer = KienTruc.axPageLayoutControl1.Printer;
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
            KienTruc.axPageLayoutControl1.ActiveView.Output(hdc.ToInt32(), dpi, ref deviceRect, visBounds, m_TrackCancel);

            //release the graphics device handle
            e.Graphics.ReleaseHdc(hdc);
            if (m_CurrentPrintPage <= printPageCount)
            {
                m_CurrentPrintPage++;
            }
            //check if further pages have to be printed
            if (m_CurrentPrintPage < printPageCount)
                e.HasMorePages = true; //document_PrintPage event will be called again
            else
                e.HasMorePages = false;
            
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPrinter printer = KienTruc.axPageLayoutControl1.Printer;
            KienTruc.axPageLayoutControl1.Printer.Paper.PrinterName = listPrinter.SelectedItem.ToString();
            
            lblPrinterName.Text = printer.Paper.PrinterName;
            lblPrinterName.Refresh();
            lblPrinterSize.Refresh();
            
        }

        private void ToolIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            pictureBox1.Image.Dispose();
        }
    }
}
