using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.ThongKe
{
    public partial class TK_TramBTS : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        string ThongKe;
        double TongTram;
        string sqlQuan = "[PRC_Query_TenHuyen_By_MAHuyen] null";
        public TK_TramBTS()
        {
            InitializeComponent();
        }
        
        private void TK_TramBTS_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sqlQuan, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cboQuan.DataSource = ds.Tables[0];
            cboQuan.DisplayMember = "TENHUYEN";
            cboQuan.ValueMember = "MAHUYEN";

            showgridControl();
        }

        void showgridControl()
        {
            tb = new DataTable();
            tbcheck = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand("[PRC_TK_TramBTS_ThanhPho]", connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
        }


        private void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                cboQuan.Text = "";
            }
            if (cboQuan.Text != "")
            {
                GridView1.ViewCaption = "Bảng thống kê trạm BTS quận " + cboQuan.Text;
                if (GridView1.ViewCaption == "Bảng thống kê trạm BTS quận Hoà Vang")
                {
                    GridView1.ViewCaption = "Bảng thống kê trạm BTS huyện Hòa Vang";
                }
            }
            if (cboQuan.Text != "")
            {
                tb = new DataTable();
                tbcheck = new DataTable();
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand("[PRC_TK_TramBTS_MaHuyen_" + cboQuan.SelectedValue.ToString() + "]", connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);
                dataAdapter1.Fill(tb);
                this.bindingSource1.DataSource = tb;
                GridView1.RefreshData();
                gridColumn1.Visible = false;
                gridColumn2.Visible = true;
                gridColumn2.VisibleIndex = 0;
            }


        }
        void ShowData()
        {
            
            tb = new DataTable();
            tbcheck = new DataTable();
            string sql = "select ChuDauTu from TramBTS";
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
         
        }

        private void btChinhSua_Click(object sender, EventArgs e)
        {
            SaveFileDialog openf = new SaveFileDialog();
            openf.Filter = "xls|*.xls";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                GridView1.ExportToXls(openf.FileName);
            }
        }

        private void cboCDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboCDT.Text != "")
            //{
            //    if (cboQuan.Text != "")
            //    {
            //        if (cboPhuong.Text != "")
            //        {
            //            GridView1.ViewCaption = "Bảng thống kê trạm BTS chủ đầu tư " + cboCDT.Text + " phường " + cboPhuong.Text;
            //        }
            //        else { GridView1.ViewCaption = "Bảng thống kê trạm BTS quận " + cboQuan.Text; }
            //    }
            //    else { GridView1.ViewCaption = "Bảng thống kê trạm BTS chủ đầu tư " + cboCDT.Text; }
            //}
            //else { GridView1.ViewCaption = "Bảng thống kê trạm BTS chủ đầu tư " + cboCDT.Text ; }

            //if (cboPhuong.Text == "")
            //{
            //    if (cboQuan.Text == "")
            //    {
            //        ThongKe = "select ChuDauTu, count(ChuDauTu) as SoLuong from TRAMBTS where ChuDauTu = N'"+cboCDT.Text+"'  GROUP BY ChuDauTu";
            //    }
            //    else
            //    {
            //        ThongKe = "select ChuDauTu, count(ChuDauTu) as SoLuong from TRAMBTS where QuanHuyen = N'"+cboQuan.Text+"' and ChuDauTu = N'"+cboCDT.Text+"'  GROUP BY ChuDauTu";
            //        GridView1.ViewCaption = "Bảng thống kê trạm BTS chủ đầu tư " + cboCDT.Text + " quận " + cboQuan.Text;
            //        if(cboQuan.Text == "Hòa Vang")
            //        {
            //            GridView1.ViewCaption = "Bảng thống kê trạm BTS chủ đầu tư " + cboCDT.Text + " huyện " + cboQuan.Text;
            //        }
            //    }
            //}
            //else
            //{
            //    ThongKe = "select ChuDauTu, count(ChuDauTu) as SoLuong from TRAMBTS where PhuongXa = N'"+cboPhuong.Text+"' and ChuDauTu = N'"+cboCDT.Text+"'  GROUP BY ChuDauTu";
            //}

            showgridControl();
            GridView1.RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (System.IO.File.Exists(System.IO.Path.GetTempPath() + "\\TrangIn.jpg"))
            //{
            //    System.IO.File.Delete(System.IO.Path.GetTempPath() + "\\TrangIn.jpg");
            //}
            //CreateJPEGHiResolutionFromActiveView(FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView, System.IO.Path.GetTempPath() + "\\TrangIn.jpg");
            //QLHTDT.FormPhu.InAn.ToolIn frm = new QLHTDT.FormPhu.InAn.ToolIn();
            //frm.Show();
        }
        public System.Boolean CreateJPEGHiResolutionFromActiveView(ESRI.ArcGIS.Carto.IActiveView activeView, System.String pathFileName)
        {
            //parameter check
            if (activeView == null || !(pathFileName.EndsWith(".jpg")))
            { return false; }
            ESRI.ArcGIS.Output.IExport export = new ESRI.ArcGIS.Output.ExportJPEGClass();
            export.ExportFileName = pathFileName;
            //System.Int32 screenResolution = 48;
            System.Int32 outputResolution = 50;

            export.Resolution = outputResolution;

            ESRI.ArcGIS.esriSystem.tagRECT exportRECT; // This is a structure
            exportRECT.left = 0;
            exportRECT.top = 0;
            exportRECT.right = activeView.ExportFrame.right * 1 / 2;
            exportRECT.bottom = activeView.ExportFrame.bottom * 1 / 2;

            // Set up the PixelBounds envelope to match the exportRECT
            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            envelope.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);
            export.PixelBounds = envelope;

            System.Int32 hDC = export.StartExporting();

            activeView.Output(hDC, (System.Int16)export.Resolution, ref exportRECT, null, null); // Explicit Cast and 'ref' keyword needed 
            export.FinishExporting();
            export.Cleanup();

            return true;
        }

        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            cboQuan.ResetText(); 
            cboCDT.ResetText();
            showgridControl();
            gridColumn1.Visible = true;
            gridColumn2.Visible = false;
            GridView1.ViewCaption = "Bảng thống kê trạm BTS thành phố Đà Nẵng";
        }
    }
}
