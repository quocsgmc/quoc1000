using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu
{
    public partial class ViewPDF : Form
    {
        public ViewPDF(string path)
        {
            InitializeComponent();
            pdfViewer1.LoadDocument(path);
            pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible;
        }
    }
}
