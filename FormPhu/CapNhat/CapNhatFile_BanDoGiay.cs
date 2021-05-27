using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using QLHTDT.FormChinh;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class CapNhatFile_BanDoGiay : Form
    {
        int AddQuan = 0;
        public static string MaHuyen = "null";
        IRasterDataset rasterDataset;
        IRaster raster;
        IRasterGeometryProc rasterPropc;
        IWorkspaceFactory wsFactory = new RasterWorkspaceFactory(); IRasterWorkspace rasterWS; IRasterDataset2 rasterDataset2;
        IRasterLayer rasterLayer1;
        IRasterLayer rasterLayer2;
        OpenFileDialog openFileDialogAnhFull = new System.Windows.Forms.OpenFileDialog();
        OpenFileDialog openFileDialogAnhCat = new System.Windows.Forms.OpenFileDialog();
        string XVN2000 = "";
        string YVN2000 = "";
        string LoaiQH = "";
        string API = "";
        public CapNhatFile_BanDoGiay()
        {
            openFileDialogAnhFull.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogAnhFull_FileOk);
            openFileDialogAnhCat.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogAnhCat_FileOk);
            InitializeComponent();
        }

        private void CapNhatFile_BanDoGiay_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";
        }

        private void comboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            comboPhuong.ResetText();
            if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                comboQuan.Text = "";
            }
            if (AddQuan == 1)
            {
                MaHuyen = comboQuan.SelectedValue.ToString();
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + " ";

                SqlDataAdapter adp = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds = new DataSet();
                adp.Fill(ds);
                comboPhuong.DataSource = ds.Tables[0];
                comboPhuong.DisplayMember = "TenPhuong";
                comboPhuong.ValueMember = "MaPhuong";
                if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    comboPhuong.Text = "";
                }
            }
        }

        private void btMo1_Click(object sender, EventArgs e)
        {
            openFileDialogAnhFull.ShowDialog();
            textBox1.Text = openFileDialogAnhFull.FileName;
        }
        private void openFileDialogAnhFull_FileOk(object sender, CancelEventArgs e)
        {
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialogAnhFull.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialogAnhFull.FileName);

            rasterLayer1 = new RasterLayer();
            rasterLayer1.CreateFromFilePath(openFileDialogAnhFull.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialogAnhCat.ShowDialog();
            textBox2.Text = openFileDialogAnhCat.FileName;
        }
        private void openFileDialogAnhCat_FileOk(object sender, CancelEventArgs e)
        {
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialogAnhCat.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialogAnhCat.FileName);

            rasterLayer2 = new RasterLayer();
            rasterLayer2.CreateFromFilePath(openFileDialogAnhCat.FileName);
        }
        private void VN2000TOWGS84(string KinhDo, string ViDo)
        {
            double[] z = new double[1];
            double[] xy = new double[2];
            xy[0] = Convert.ToDouble(KinhDo);
            xy[1] = Convert.ToDouble(ViDo);
            z[0] = 0;
            double[] xy_geometry = new double[xy.Length];
            Array.Copy(xy, xy_geometry, xy.Length);
            DotSpatial.Projections.ProjectionInfo trg =
                DotSpatial.Projections.ProjectionInfo.FromProj4String("+proj=longlat +datum=WGS84 +no_defs");
            DotSpatial.Projections.ProjectionInfo src =
                DotSpatial.Projections.ProjectionInfo.FromProj4String("+proj = tmerc + lat_0 = 0 + lon_0 = 107.75 + k = 0.9999 + x_0 = 500000 + y_0 = 0 + ellps = WGS84 + towgs84 = -191.90441429, -39.30318279, -111.45032835, 0.00928836, -0.01975479, 0.00427372, 0.252906278 + units = m + no_defs");
            DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, src, trg, 0, 1);

            XVN2000 = Math.Round(double.Parse(xy[0].ToString()), 8).ToString();
            YVN2000 = Math.Round(double.Parse(xy[1].ToString()), 8).ToString();

        }
        string Left;
        string Right;
        string Top;
        string Bot;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Quy hoạch Chi tiết 1/500")
                {
                    if (openFileDialogAnhCat.FileName != "")
                    {
                        var client = new RestClient(QLHTDT.FormPhanHe.URLWeb.URL + API);
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Authorization", "JWT" + QLHTDT.Properties.Settings.Default.Token);
                        request.AddFile("file", openFileDialogAnhCat.FileName);
                        request.AddParameter("filesDelete", "[]");
                        request.AddParameter("IDPhuong", comboPhuong.SelectedValue.ToString());
                        request.AddParameter("MaBDGiay", txtMaBanDo.Text);
                        IRestResponse response = client.Execute(request);


                        Left = Math.Round(double.Parse(rasterLayer2.VisibleExtent.XMin.ToString()), 8).ToString();
                        Right = Math.Round(double.Parse(rasterLayer2.VisibleExtent.XMax.ToString()), 8).ToString();
                        Top = Math.Round(double.Parse(rasterLayer2.VisibleExtent.YMax.ToString()), 8).ToString();
                        Bot = Math.Round(double.Parse(rasterLayer2.VisibleExtent.YMin.ToString()), 8).ToString();
                        VN2000TOWGS84(Left, Top);
                        string Left1 = XVN2000; string Top1 = YVN2000;
                        Left1 = Left1.Replace(',', '.'); Top1 = Top1.Replace(',', '.');
                        VN2000TOWGS84(Right, Bot);
                        string Right1 = XVN2000; string Bot1 = YVN2000;
                        Right1 = Right1.Replace(',', '.'); Bot1 = Bot1.Replace(',', '.');
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string nul = "null";
                        string sql1 = "" + LoaiQH + " "
                            + " N'" + txtMaBanDo.Text
                            + "', " + Top1
                            + ", " + Right1
                            + ", " + Left1
                            + ", " + Bot1 + " ";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();

                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Bản đồ giấy 1/500 Cắt", 0);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                    }
                    if(openFileDialogAnhFull.FileName != "")
                    {
                        var client = new RestClient(QLHTDT.FormPhanHe.URLWeb.URL + API);
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Authorization", "JWT" + QLHTDT.Properties.Settings.Default.Token);
                        request.AddFile("file", openFileDialogAnhFull.FileName);
                        request.AddParameter("filesDelete", "[]");
                        request.AddParameter("IDPhuong", comboPhuong.SelectedValue.ToString());
                        request.AddParameter("MaBDGiay", txtMaBanDo.Text + "A");
                        IRestResponse response = client.Execute(request);
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Bản đồ giấy 1/500 Full", 0);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                    }    
                }
                if (comboBox1.Text == "Quy hoạch Phân khu")
                {
                    if (openFileDialogAnhCat.FileName != "")
                    {
                        var client = new RestClient(QLHTDT.FormPhanHe.URLWeb.URL + API);
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Authorization", "JWT" + QLHTDT.Properties.Settings.Default.Token);
                        request.AddFile("file", openFileDialogAnhCat.FileName);
                        request.AddParameter("filesDelete", "[]");
                        request.AddParameter("IDPhuong", "20314");
                        request.AddParameter("MaBDGiay", txtMaBanDo.Text);
                        IRestResponse response = client.Execute(request);


                        Left = Math.Round(double.Parse(rasterLayer2.VisibleExtent.XMin.ToString()), 8).ToString();
                        Right = Math.Round(double.Parse(rasterLayer2.VisibleExtent.XMax.ToString()), 8).ToString();
                        Top = Math.Round(double.Parse(rasterLayer2.VisibleExtent.YMax.ToString()), 8).ToString();
                        Bot = Math.Round(double.Parse(rasterLayer2.VisibleExtent.YMin.ToString()), 8).ToString();
                        VN2000TOWGS84(Left, Top);
                        string Left1 = XVN2000; string Top1 = YVN2000;
                        Left1 = Left1.Replace(',', '.'); Top1 = Top1.Replace(',', '.');
                        VN2000TOWGS84(Right, Bot);
                        string Right1 = XVN2000; string Bot1 = YVN2000;
                        Right1 = Right1.Replace(',', '.'); Bot1 = Bot1.Replace(',', '.');
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string nul = "null";
                        string sql1 = "" + LoaiQH + " "
                            + " N'" + txtMaBanDo.Text
                            + "', " + Top1
                            + ", " + Right1
                            + ", " + Left1
                            + ", " + Bot1 + " ";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Bản đồ giấy 1/5000 Cắt", 0);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                    }
                    if (openFileDialogAnhFull.FileName != "")
                    {
                        var client = new RestClient(QLHTDT.FormPhanHe.URLWeb.URL + API);
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Authorization", "JWT" + QLHTDT.Properties.Settings.Default.Token);
                        request.AddFile("file", openFileDialogAnhFull.FileName);
                        request.AddParameter("filesDelete", "[]");
                        request.AddParameter("IDPhuong", "20314");
                        request.AddParameter("MaBDGiay", txtMaBanDo.Text + "A");
                        IRestResponse response = client.Execute(request);
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Bản đồ giấy 1/5000 Full", 0);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                    }
                }
                if (comboBox1.Text == "Quy hoạch Chung")
                {
                    if (openFileDialogAnhCat.FileName != "")
                    {
                        var client = new RestClient(QLHTDT.FormPhanHe.URLWeb.URL + API);
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Authorization", "JWT" + QLHTDT.Properties.Settings.Default.Token);
                        request.AddFile("file", openFileDialogAnhCat.FileName);
                        request.AddParameter("filesDelete", "[]");
                        request.AddParameter("IDPhuong", "20314");
                        request.AddParameter("MaBDGiay", txtMaBanDo.Text);
                        IRestResponse response = client.Execute(request);


                        Left = Math.Round(double.Parse(rasterLayer2.VisibleExtent.XMin.ToString()), 8).ToString();
                        Right = Math.Round(double.Parse(rasterLayer2.VisibleExtent.XMax.ToString()), 8).ToString();
                        Top = Math.Round(double.Parse(rasterLayer2.VisibleExtent.YMax.ToString()), 8).ToString();
                        Bot = Math.Round(double.Parse(rasterLayer2.VisibleExtent.YMin.ToString()), 8).ToString();
                        VN2000TOWGS84(Left, Top);
                        string Left1 = XVN2000; string Top1 = YVN2000;
                        Left1 = Left1.Replace(',', '.'); Top1 = Top1.Replace(',', '.');
                        VN2000TOWGS84(Right, Bot);
                        string Right1 = XVN2000; string Bot1 = YVN2000;
                        Right1 = Right1.Replace(',', '.'); Bot1 = Bot1.Replace(',', '.');
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string nul = "null";
                        string sql1 = "" + LoaiQH + " "
                            + " N'" + txtMaBanDo.Text
                            + "', " + Top1
                            + ", " + Right1
                            + ", " + Left1
                            + ", " + Bot1 + " ";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Bản đồ giấy 1/10000 Cắt", 0);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                    }
                    if (openFileDialogAnhFull.FileName != "")
                    {
                        var client = new RestClient(QLHTDT.FormPhanHe.URLWeb.URL + API);
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Authorization", "JWT" + QLHTDT.Properties.Settings.Default.Token);
                        request.AddFile("file", openFileDialogAnhFull.FileName);
                        request.AddParameter("filesDelete", "[]");
                        request.AddParameter("IDPhuong", "20314");
                        request.AddParameter("MaBDGiay", txtMaBanDo.Text + "A");
                        IRestResponse response = client.Execute(request);
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Bản đồ giấy 1/10000 Full", 0);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                    }
                }
                MessageBox.Show("Cập nhật bản đồ giấy thành công", "Thông báo");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Cập nhật bản đồ giấy thất bại. Vui lòng kiểm tra lại thông tin", "Thông báo");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Quy hoạch Chi tiết 1/500")
            {
                LoaiQH = "[PRC_UPDATE_DSBanDoGiay]";
                API = "api/duanqh/update-file-ban-do-giay";
                comboQuan.Enabled = true;
                comboPhuong.Enabled = true;
            }
            else if (comboBox1.Text == "Quy hoạch Phân khu")
            {
                LoaiQH = "[PRC_UPDATE_DSBanDoGiay_PhanKhu]";
                API = "api/qh-phan-khu/update-file-ban-do-giay";
                comboQuan.Enabled = false;
                comboPhuong.Enabled = false;
            }
            else if(comboBox1.Text == "Quy hoạch Chung")
            {
                LoaiQH = "[PRC_UPDATE_DSBanDoGiay_Chung]";
                API = "api/qh-chung/update-file-ban-do-giay";
                comboQuan.Enabled = false;
                comboPhuong.Enabled = false;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn loại Quy hoạch cần cập nhật","Thông báo");
            }
        }
    }
}
