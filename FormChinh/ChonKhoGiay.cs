using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;

namespace QLHTDT.FormChinh
{
    public partial class ChonKhoGiay : Form
    {
        public ChonKhoGiay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "ISO A0 ngang	 (841mm   x   1189mm)")
            {
                //QuanTriHeThong.axPageLayoutControl1.LoadMxFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\KhoGiay\\ISO A0 Landscape.mxd");
                QuanTriHeThong.axPageLayoutControl1.Page.FormID = esriPageFormID.esriPageFormA0;
                QuanTriHeThong.axPageLayoutControl1.Page.Orientation = 2;
                QuanTriHeThong.axPageLayoutControl1.Printer.Paper.Orientation = 2;
                QuanTriHeThong.axPageLayoutControl1.Refresh();
                QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();

            }
            else if (comboBox1.Text == "ISO A0 đứng 	 (1189mm x   841mm)")
            {
                //QuanTriHeThong.axPageLayoutControl1.LoadMxFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\KhoGiay\\ISO A0 Portrait.mxd");
                QuanTriHeThong.axPageLayoutControl1.Page.FormID = esriPageFormID.esriPageFormA0;
                QuanTriHeThong.axPageLayoutControl1.Page.Orientation = 1;
                QuanTriHeThong.axPageLayoutControl1.Printer.Paper.Orientation = 1;
                QuanTriHeThong.axPageLayoutControl1.Refresh();
                QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            }
            else if (comboBox1.Text == "ISO A1 ngang	 (594mm   x   841mm)")
            {
                //QuanTriHeThong.axPageLayoutControl1.LoadMxFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\KhoGiay\\ISO A1 Landscape.mxd");
                QuanTriHeThong.axPageLayoutControl1.Page.FormID = esriPageFormID.esriPageFormA1;
                QuanTriHeThong.axPageLayoutControl1.Page.Orientation = 2;
                QuanTriHeThong.axPageLayoutControl1.Printer.Paper.Orientation = 2;
                QuanTriHeThong.axPageLayoutControl1.Refresh();
                QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            }
            else if (comboBox1.Text == "ISO A1 đứng	 (841mm   x   594mm)")
            {
                //QuanTriHeThong.axPageLayoutControl1.LoadMxFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\KhoGiay\\ISO A1 Portrait.mxd");
                QuanTriHeThong.axPageLayoutControl1.Page.FormID = esriPageFormID.esriPageFormA1;
                QuanTriHeThong.axPageLayoutControl1.Page.Orientation = 1;
                QuanTriHeThong.axPageLayoutControl1.Printer.Paper.Orientation = 1;
                QuanTriHeThong.axPageLayoutControl1.Refresh();
                QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            }
            else if (comboBox1.Text == "ISO A2 ngang	 (420mm   x   594mm)")
            {
                //QuanTriHeThong.axPageLayoutControl1.LoadMxFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\KhoGiay\\ISO A2 Landscape.mxd");
                QuanTriHeThong.axPageLayoutControl1.Page.FormID = esriPageFormID.esriPageFormA2;
                QuanTriHeThong.axPageLayoutControl1.Page.Orientation = 2;
                QuanTriHeThong.axPageLayoutControl1.Printer.Paper.Orientation = 2;
                QuanTriHeThong.axPageLayoutControl1.Refresh();
                QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            }
            else if (comboBox1.Text == "ISO A2 đứng 	 (594mm   x   420mm)")
            {
                //QuanTriHeThong.axPageLayoutControl1.LoadMxFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\KhoGiay\\ISO A2 Portrait.mxd");
                QuanTriHeThong.axPageLayoutControl1.Page.FormID = esriPageFormID.esriPageFormA2;
                QuanTriHeThong.axPageLayoutControl1.Page.Orientation = 1;
                QuanTriHeThong.axPageLayoutControl1.Printer.Paper.Orientation = 1;
                QuanTriHeThong.axPageLayoutControl1.Refresh();
                QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            }
            else if (comboBox1.Text == "ISO A3 ngang	 (297mm   x   420mm)")
            {
                //QuanTriHeThong.axPageLayoutControl1.LoadMxFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\KhoGiay\\ISO A3 Landscape.mxd");
                QuanTriHeThong.axPageLayoutControl1.Page.FormID = esriPageFormID.esriPageFormA3;
                QuanTriHeThong.axPageLayoutControl1.Page.Orientation = 2;
                QuanTriHeThong.axPageLayoutControl1.Printer.Paper.Orientation = 2;
                QuanTriHeThong.axPageLayoutControl1.Refresh();
                QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            }
            else if (comboBox1.Text == "ISO A3 đứng 	 (420mm   x   297mm)")
            {
                //QuanTriHeThong.axPageLayoutControl1.LoadMxFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\KhoGiay\\ISO A3 Portrait.mxd");
                QuanTriHeThong.axPageLayoutControl1.Page.FormID = esriPageFormID.esriPageFormA3;
                QuanTriHeThong.axPageLayoutControl1.Page.Orientation = 1;
                QuanTriHeThong.axPageLayoutControl1.Printer.Paper.Orientation = 1;
                QuanTriHeThong.axPageLayoutControl1.Refresh();
                QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            }
            else if (comboBox1.Text == "ISO A4 ngang	 (210mm   x   297mm)")
            {
                //QuanTriHeThong.axPageLayoutControl1.LoadMxFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\KhoGiay\\ISO A4 Landscape.mxd");
                QuanTriHeThong.axPageLayoutControl1.Page.FormID = esriPageFormID.esriPageFormA4;
                QuanTriHeThong.axPageLayoutControl1.Page.Orientation = 2;
                QuanTriHeThong.axPageLayoutControl1.Printer.Paper.Orientation = 2;
                QuanTriHeThong.axPageLayoutControl1.Refresh();
                QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            }
            else if (comboBox1.Text == "ISO A4 đứng	 (297mm   x   210mm)")
            {
                //QuanTriHeThong.axPageLayoutControl1.LoadMxFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\KhoGiay\\ISO A4 Portrait.mxd");
                QuanTriHeThong.axPageLayoutControl1.Page.FormID = esriPageFormID.esriPageFormA4;
                QuanTriHeThong.axPageLayoutControl1.Page.Orientation = 1;
                QuanTriHeThong.axPageLayoutControl1.Printer.Paper.Orientation = 1;
                QuanTriHeThong.axPageLayoutControl1.Refresh();
                QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            }
            else if (comboBox1.Text == "ISO A5 ngang	 (148mm   x   210mm)")
            {
                //QuanTriHeThong.axPageLayoutControl1.LoadMxFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\KhoGiay\\ISO A5 Landscape.mxd");
                QuanTriHeThong.axPageLayoutControl1.Page.FormID = esriPageFormID.esriPageFormA5;
                QuanTriHeThong.axPageLayoutControl1.Page.Orientation = 2;
                QuanTriHeThong.axPageLayoutControl1.Printer.Paper.Orientation = 2;
                QuanTriHeThong.axPageLayoutControl1.Refresh();
                QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            }
            else if (comboBox1.Text == "ISO A5 đứng	 (210mm   x  148 mm)")
            {
                //QuanTriHeThong.axPageLayoutControl1.LoadMxFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\KhoGiay\\ISO A5 Portrait.mxd");
                QuanTriHeThong.axPageLayoutControl1.Page.FormID = esriPageFormID.esriPageFormA5;
                QuanTriHeThong.axPageLayoutControl1.Page.Orientation = 1;
                QuanTriHeThong.axPageLayoutControl1.Printer.Paper.Orientation = 1;
                QuanTriHeThong.axPageLayoutControl1.Refresh();
                QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            }
            else
            {
                MessageBox.Show("Chưa chọn khổ giấy", "Thông báo");
            }
            QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView.Refresh();
            //QLHTDT.FormChinh.QuanTriHeThong.CopyToPageLayout();
            this.Close();
        }
    }
}
