using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLHTDT.FormChinh;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using QLHTDT.FormPhu.QLKienTruc;
using QLHTDT.Properties;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;

namespace QLHTDT.FormPhu.QLQH
{
    public partial class DangKyCapCCQH : Form
    {
        int AddQuan = 0;
        public static string MaHuyen = "null";
        ILayer layeredit;
        string tableKT = "";
        int LoaiHS = 0;
        string layerget = "";
        string fileSodovitri = "SoDoViTri";
        int n = 0;
        string maHS;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhu.QLQH.QuanlyQuyHoach.ID1;
        public static string IDPhuong = "null";
        public DangKyCapCCQH()
        {
            InitializeComponent();
            LoaiHS = 1;
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void DangKyCapCCQH_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Quan.DataSource = ds.Tables[0];
            Quan.DisplayMember = "TENHUYEN";
            Quan.ValueMember = "MAHUYEN";

            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_HoSoChungChiQH_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                TenNguoiGui.Text = ds3.Tables[0].Rows[0]["NguoiGui"].ToString();
                NamSinh.Text = ds3.Tables[0].Rows[0]["NamSinh"].ToString();
                HoKhau.Text = ds3.Tables[0].Rows[0]["HoKhauThuongTru"].ToString();
                SDTDiDong.Text = ds3.Tables[0].Rows[0]["SDT"].ToString();
                ViTriThuaDat.Text = ds3.Tables[0].Rows[0]["DiaChiThuaDat"].ToString();
                STo.Text = ds3.Tables[0].Rows[0]["SoToBD"].ToString();
                SThua.Text = ds3.Tables[0].Rows[0]["SoThua"].ToString();
                To.Text = ds3.Tables[0].Rows[0]["ToDanPho"].ToString();
                Quan.Text = ds3.Tables[0].Rows[0]["QuanHuyen"].ToString();
                Phuong.Text = ds3.Tables[0].Rows[0]["TenPhuong"].ToString();
                MucDich.Text = ds3.Tables[0].Rows[0]["MucDich"].ToString();
                LoaiHS = 2;
                maHS = ds3.Tables[0].Rows[0]["MaHS"].ToString();
                NgayCapGCN.Text = ds3.Tables[0].Rows[0]["NgayCapGCN"].ToString();
                SoGCN.Text = ds3.Tables[0].Rows[0]["PhoToGCN"].ToString();
                IDPhuong = ds3.Tables[0].Rows[0]["IDPhuong"].ToString();
            }
        }
        public DangKyCapCCQH(string NguoiGui, string HoKhauTT,string NamS,string sdtcodinh,string sdtdidong,string vitrithuadat,string soto,string sothua,string to,string quan, string phuong,string mucdich, string mahs, string ngaycapGCN, string photoGCN)
        {
            InitializeComponent();

            SqlDataAdapter adp = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Quan.DataSource = ds.Tables[0];
            Quan.DisplayMember = "TENHUYEN";
            Quan.ValueMember = "MAHUYEN";

            TenNguoiGui.Text = NguoiGui;
            NamSinh.Text = NamS;
            HoKhau.Text = HoKhauTT;
            SDTDiDong.Text = sdtdidong;
            ViTriThuaDat.Text = vitrithuadat;
            STo.Text = soto;
            SThua.Text = sothua;
            To.Text = to;
            Quan.Text = quan;
            Phuong.Text = phuong;
            MucDich.Text = mucdich;
            LoaiHS = 2;
            maHS = mahs;
            NgayCapGCN.Text = ngaycapGCN;
            SoGCN.Text = photoGCN;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ViTriTDat(true);
        }
        private void ViTriTDat(bool ThongTinThua)
        {
            try
            {
                string layerget = "Địa chính";
                tableKT = "TTKIENTRUC";
                //if (Phuong.Text == "Hòa An")
                //{ layerget = "Địa chính"; IDPhuong = "20306"; tableKT = "TTKIENTRUC"; }
                //else if (Phuong.Text == "Hòa Phát")
                //{ layerget = "Địa chính"; IDPhuong = "20305"; tableKT = "TTKIENTRUC"; }
                //else if (Phuong.Text == "Hòa Thọ Tây")
                //{ layerget = "Địa chính"; IDPhuong = "20311"; tableKT = "TTKIENTRUC"; }
                //else if (Phuong.Text == "Hòa Thọ Đông")
                //{ layerget = "Địa chính"; IDPhuong = "20312"; tableKT = "TTKIENTRUC"; }
                //else if (Phuong.Text == "Hòa Xuân")
                //{ layerget = "Địa chính"; IDPhuong = "20314"; tableKT = "TTKIENTRUC"; }
                //else if (Phuong.Text == "Khuê Trung")
                //{ layerget = "Địa chính"; IDPhuong = "20260"; tableKT = "TTKIENTRUC"; }
                int KTMoLop = 0;
                string PhuongKT = "Địa chính";
                try
                {
                    PhuongKT = "Địa chính";
                    for (int i1 = 0; i1 < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i1++)
                    {
                        if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == "Địa chính")
                        {
                            IFeatureLayer ilayer1 = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1) as IFeatureLayer;
                            KTMoLop = KTMoLop + 1;
                            layeredit = ilayer1;
                            KienTruc.axMapControl1.Extent = layeredit.AreaOfInterest;
                        }
                        else
                        {
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                layeredit = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1);
                                KienTruc.axMapControl1.Extent = KienTruc.axMapControl1.get_Layer(i1).AreaOfInterest;
                            }
                        }
                    }
                    if (KTMoLop == 0)
                    {
                        QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Dữ liệu dùng chung\\Địa chính.lyr");
                        QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        for (int i = 0; i < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i).Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                layeredit = FormChinh.KienTruc.axMapControl1.get_Layer(i);
                                KienTruc.axMapControl1.Extent = KienTruc.axMapControl1.get_Layer(i).AreaOfInterest;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                ICommand command = new ControlsClearSelectionCommand();
                command.OnCreate(KienTruc.axMapControl1.Object);
                KienTruc.axMapControl1.CurrentTool = command as ITool;
                command.OnClick();

                if (layeredit != null)
                {
                    IFeatureLayer pFeatureLayer2 = (IFeatureLayer)layeredit;
                    IFeatureSelection featSelect = pFeatureLayer2 as IFeatureSelection;
                    IQueryFilter pFilter = new QueryFilterClass();
                    EnvelopeClass pEnvelope = new EnvelopeClass();
                    if (Phuong.Text == "")
                    {
                        MessageBox.Show("Thông báo", "Chưa chọn phường cần tra cứu");

                    }
                    else if (Phuong.Text != "")
                    {
                        if (STo.Text != "" && SThua.Text != "")
                        {
                            pFilter.WhereClause = "[SoToBD] = '" + STo.Text + "' AND [SoThua] = '" + SThua.Text + "' and IDPhuong = '" + IDPhuong + "'";
                            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);

                        }
                        else if (STo.Text != "" && SThua.Text == "")
                        {
                            pFilter.WhereClause = "[SoToBD] = '" + STo.Text + "'and IDPhuong = '" + IDPhuong + "'";
                            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                        }
                        else if (STo.Text == "" && SThua.Text != "")
                        {
                            pFilter.WhereClause = "[SoThua] = '" + SThua.Text + "'and IDPhuong = '" + IDPhuong + "'";
                            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                        }
                        else
                        {
                            MessageBox.Show("Chưa chọn số tờ bản đồ hoặc số thửa đất cần tra cứu", "Thông báo");
                        }
                        ZoomToLayers();
                    }
                    IEnumIDs idList = featSelect.SelectionSet.IDs;
                    int index = idList.Next();
                    List<int> indexes = new List<int>();
                    while (index != -1)
                    {
                        indexes.Add(index);
                        index = idList.Next();
                    }
                    IFeatureClass featureClass = pFeatureLayer2.FeatureClass;

                    KienTruc.tt = new DataTable();
                    //KienTruc.tt.Columns.Add("Mã", typeof(String));
                    //KienTruc.tt.Columns.Add("Chủ sử dụng", typeof(String));
                    //KienTruc.tt.Columns.Add("Số tờ bản đồ", typeof(String));
                    //KienTruc.tt.Columns.Add("Số thửa", typeof(String));
                    //KienTruc.tt.Columns.Add("Diện tích", typeof(String));
                    //KienTruc.tt.Columns.Add("Địa chỉ", typeof(String));
                    //KienTruc.tt.Columns.Add("Tình trạng pháp lý", typeof(String));
                    //KienTruc.tt.Columns.Add("Thông tin quy hoạch", typeof(String));
                    //KienTruc.tt.Columns.Add("Phường", typeof(String));
                    //KienTruc.tt.Columns.Add("Loại đất", typeof(String));
                    //KienTruc.tt.Columns.Add("TenKhuVuc", typeof(String));
                    //KienTruc.tt.Columns.Add("TangCaoXD", typeof(String));
                    //KienTruc.tt.Columns.Add("ChiGioiXD", typeof(String));
                    //KienTruc.tt.Columns.Add("ChieuCaoTang", typeof(String));
                    //KienTruc.tt.Columns.Add("CotNen", typeof(String));
                    //KienTruc.tt.Columns.Add("QDKhac", typeof(String));
                    //KienTruc.tt.Columns.Add("SoGPXD", typeof(String));
                    //KienTruc.tt.Columns.Add("TTCPXD", typeof(String));
                    //KienTruc.tt.Columns.Add("MaHSCPXD", typeof(String));
                    KienTruc.tt.Columns.Add("Mã", typeof(String));
                    KienTruc.tt.Columns.Add("Số tờ bản đồ", typeof(String));
                    KienTruc.tt.Columns.Add("Số thửa", typeof(String));
                    KienTruc.tt.Columns.Add("Diện tích", typeof(String));
                    KienTruc.tt.Columns.Add("Loại đất", typeof(String));
                    KienTruc.tt.Columns.Add("Phường", typeof(String));
                    KienTruc.tt.Columns.Add("Thông tin quy hoạch", typeof(String));
                    KienTruc.tt.Columns.Add("Phường1", typeof(String));
                    KienTruc.tt.Columns.Add("Loại đất1", typeof(String));
                    KienTruc.tt.Columns.Add("TenKhuVuc", typeof(String));
                    KienTruc.tt.Columns.Add("TangCaoXD", typeof(String));
                    KienTruc.tt.Columns.Add("ChiGioiXD", typeof(String));
                    KienTruc.tt.Columns.Add("ChieuCaoTang", typeof(String));
                    KienTruc.tt.Columns.Add("CotNen", typeof(String));
                    KienTruc.tt.Columns.Add("QDKhac", typeof(String));
                    KienTruc.tt.Columns.Add("SoGPXD", typeof(String));
                    KienTruc.tt.Columns.Add("TTCPXD", typeof(String));
                    KienTruc.tt.Columns.Add("MaHSCPXD", typeof(String));
                    if (featSelect.SelectionSet.Count == 0) { MessageBox.Show("Không có thửa đất nào", "Thông báo"); }
                    for (int i2 = 0; i2 < featSelect.SelectionSet.Count; i2++)
                    {
                        IFeature feature = featureClass.GetFeature(indexes[i2]);
                        KienTruc.dr = KienTruc.tt.NewRow();
                        KienTruc.dr[0] = feature.get_Value(feature.Fields.FindField("OBJECTID")).ToString();
                        if (feature.get_Value(feature.Fields.FindField("SoToBD")) != DBNull.Value)
                        {
                            KienTruc.dr[1] = feature.get_Value(feature.Fields.FindField("SoToBD")).ToString();
                        }
                        if (feature.get_Value(feature.Fields.FindField("SoThua")) != DBNull.Value)
                        {
                            KienTruc.dr[2] = feature.get_Value(feature.Fields.FindField("SoThua")).ToString();
                        }
                        if (feature.get_Value(feature.Fields.FindField("DienTich")) != DBNull.Value)
                        {
                            KienTruc.dr[3] = feature.get_Value(feature.Fields.FindField("DienTich")).ToString();
                        }
                        if (feature.get_Value(feature.Fields.FindField("LoaiDat")) != DBNull.Value)
                        {
                            KienTruc.dr[4] = feature.get_Value(feature.Fields.FindField("LoaiDat")).ToString();
                        }
                        if (feature.get_Value(feature.Fields.FindField("IDPhuong")) != DBNull.Value)
                        {
                            //KienTruc.dr[5] = feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString();
                            string IDPhuong1 = feature.get_Value(feature.Fields.FindField("IDPhuong")).ToString().Replace(" ", "");
                            SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            conn.Open();
                            string sql1 = "select TenPhuong from PhuongXa where PhuongXa.MaPhuong = '" + IDPhuong1 + "'";
                            SqlCommand command1 = new SqlCommand(sql1, conn);
                            if (command1.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[5] = (string)command1.ExecuteScalar();
                            }
                        }
                        if (feature.get_Value(feature.Fields.FindField("MaDuAnQH")) != DBNull.Value)
                        {
                            //KienTruc.dr[6] = feature.get_Value(feature.Fields.FindField("TenDuAn")).ToString();
                            string MaDuAnQH = feature.get_Value(feature.Fields.FindField("MaDuAnQH")).ToString().Replace(" ", "");
                            SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            conn.Open();
                            string sql1 = "select TenDuAn from RGDAQH where RGDAQH.MaDuAn = '" + MaDuAnQH + "'";
                            SqlCommand command1 = new SqlCommand(sql1, conn);
                            if (command1.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[6] = (string)command1.ExecuteScalar();
                            }
                        }
                        if (feature.get_Value(feature.Fields.FindField("MaKVKT")) != DBNull.Value)
                        {

                            string MaKT = feature.get_Value(feature.Fields.FindField("MaKVKT")).ToString().Replace(" ", "");
                            SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            conn.Open();
                            string sql1 = "SELECT [TenKhuVuc] FROM " + tableKT + " where MaKV = '" + MaKT + "'";
                            SqlCommand command1 = new SqlCommand(sql1, conn);
                            if (command1.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[9] = (string)command1.ExecuteScalar();
                            }
                            string sql2 = "SELECT [TangCaoXD] FROM " + tableKT + " where MaKV = '" + MaKT + "'";
                            SqlCommand command2 = new SqlCommand(sql2, conn);
                            if (command2.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[10] = (string)command2.ExecuteScalar();
                            }
                            string sql3 = "SELECT [ChiGioiXD] FROM " + tableKT + " where MaKV = '" + MaKT + "'";
                            SqlCommand command3 = new SqlCommand(sql3, conn);
                            if (command3.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[11] = (string)command3.ExecuteScalar();
                            }
                            string sql4 = "SELECT [ChieuCaoTang] FROM " + tableKT + " where MaKV = '" + MaKT + "'";
                            SqlCommand command4 = new SqlCommand(sql4, conn);
                            if (command4.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[12] = (string)command4.ExecuteScalar();
                            }
                            string sql5 = "SELECT [CotNen] FROM " + tableKT + " where MaKV = '" + MaKT + "'";
                            SqlCommand command5 = new SqlCommand(sql5, conn);
                            if (command5.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[13] = (string)command5.ExecuteScalar();
                            }
                            string sql6 = "SELECT [QDKhac] FROM " + tableKT + " where MaKV = '" + MaKT + "'";
                            SqlCommand command6 = new SqlCommand(sql6, conn);
                            if (command6.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[14] = (string)command6.ExecuteScalar();
                            }
                        }
                        //string sql = "SELECT [SoQD] FROM CPXD WHERE [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "' and [Phuong] =N'" + feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString() + "' and ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "')";
                        //string sql = "SELECT [SoQD] FROM CPXD WHERE [SoTo] ='" + STo.Text + "' and [SoThua] = '" + SThua.Text + "' and [IDPhuong] = '" + IDPhuong + "' and ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + STo.Text + "' and [SoThua] ='" + SThua.Text + "')";
                        //SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        //SqlCommand commanCPXD = new SqlCommand(sql, connection);
                        //commanCPXD.Connection.Open();
                        //string SoGPXD = "";
                        //if (commanCPXD.ExecuteScalar() != DBNull.Value)
                        //{
                        //    SoGPXD = (string)commanCPXD.ExecuteScalar();
                        //    if (SoGPXD != "" & SoGPXD != null)
                        //    {
                        //        SoGPXD = (string)commanCPXD.ExecuteScalar();
                        //        KienTruc.dr[15] = SoGPXD;
                        //        KienTruc.dr[16] = "Thửa đất đã được cấp phép xây dựng - GPXD số " + SoGPXD;
                        //        SqlCommand commanMaHSCPXD = new SqlCommand("SELECT [ID] FROM [CPXD] WHERE [SoQD] = '" + SoGPXD + "'", connection);
                        //        commanCPXD.Connection.Close();
                        //        commanMaHSCPXD.Connection.Open();
                        //        KienTruc.dr[17] = (string)commanMaHSCPXD.ExecuteScalar();
                        //        commanMaHSCPXD.Connection.Close();
                        //    }
                        //    else { KienTruc.dr[16] = "Chưa có thông tin cấp phép xây dựng."; commanCPXD.Connection.Close(); }
                        //}
                        //else { KienTruc.dr[16] = "Chưa có thông tin cấp phép xây dựng."; commanCPXD.Connection.Close(); }

                        KienTruc.tt.Rows.Add(KienTruc.dr);

                    }
                    if (featSelect.SelectionSet.Count > 1)
                    {
                        if (KienTruc.frm1Thua != null)
                        {
                            KienTruc.frm1Thua.Close();
                        }
                        if (KienTruc.frmNhieuThua != null)
                        {
                            KienTruc.frmNhieuThua.Close();
                            KienTruc.frmNhieuThua = new QLHTDT.FormPhu.FormChiTietLayer.FrmThuaDat2(KienTruc.tt, pFeatureLayer2);
                            KienTruc.frmNhieuThua.Show();
                        }
                        else
                        {
                            KienTruc.frmNhieuThua = new QLHTDT.FormPhu.FormChiTietLayer.FrmThuaDat2(KienTruc.tt, pFeatureLayer2);
                            KienTruc.frmNhieuThua.Show();
                        }
                    }
                    else if (featSelect.SelectionSet.Count == 1)
                    {
                        if (KienTruc.frmNhieuThua != null)
                        {
                            KienTruc.frmNhieuThua.Close();
                        }
                        if (KienTruc.frm1Thua != null)
                        {
                            KienTruc.frm1Thua.Close();
                            KienTruc.frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(KienTruc.tt);
                            KienTruc.frm1Thua.Show();
                        }
                        else
                        {
                            KienTruc.frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(KienTruc.tt);
                            KienTruc.frm1Thua.Show();
                        }

                    }
                    QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale * 4;
                    QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView.Refresh();

                }
                else { MessageBox.Show("Chưa chọn phường cần tra cứu", "Thông báo"); }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin", "Thông báo");
            }
        }
        private void ZoomToLayers()
        {
            ICommand command = new ControlsZoomToSelectedCommand();
            command.OnCreate(KienTruc.axMapControl1.Object);
            KienTruc.axMapControl1.CurrentTool = command as ITool;
            command.OnClick();
        }
        public System.Boolean CreateJPEGHiResolutionFromActiveView(ESRI.ArcGIS.Carto.IActiveView activeView, System.String pathFileName)
        {
            KienTruc.CopyToPageLayout();
            if (System.IO.File.Exists(pathFileName))
            {
                System.IO.File.Delete(pathFileName);
            }
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
        private void button2_Click(object sender, EventArgs e)
        {

            //ViTriTDat(false);
            bool check = false;
            var date = DateTime.Now;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Ngay", date.Day.ToString());
            dic.Add("Thang", date.Month.ToString());
            dic.Add("Nam", date.Year.ToString());
            dic.Add("ChuSuDung", TenNguoiGui.Text);
            dic.Add("MucDichXacNhan", MucDich.Text);
            dic.Add("SThua", SThua.Text);
            dic.Add("STo", STo.Text);
            dic.Add("To", To.Text);
            dic.Add("SoGCN", SoGCN.Text);
            dic.Add("NgayCapGCN", NgayCapGCN.Value.ToString("dd/MM/yyyy"));
            dic.Add("QĐQH", SoQD.Text);
            dic.Add("NgayPDQH", NgayPheDuyet.Text);
            dic.Add("Phuong", Phuong.Text);
            dic.Add("Quan", Quan.Text);
            if (DuAnQH.Text.Contains("Không nằm") || DuAnQH.Text == "")
            {
                int a = 0;
                while (a < 20)
                {

                    check = IsFileLocked(System.IO.Path.GetTempPath() + "\\" + fileSodovitri + ".jpg");
                    if (check == false)
                    {
                        WWord wd = new WWord(QLHTDT.Properties.Settings.Default.PathData + "\\MauXNKNTQH.dotx", true);
                        wd.WriteFields(dic);
                        CreateJPEGHiResolutionFromActiveView(KienTruc.axPageLayoutControl1.ActiveView, System.IO.Path.GetTempPath() + "\\" + fileSodovitri + ".jpg");
                        wd.Addpicture(System.IO.Path.GetTempPath() + "\\" + fileSodovitri + ".jpg");
                        break;
                    }
                    else
                    {
                        fileSodovitri = "SoDoViTri";
                    }

                }
            }
            else if (DuAnQH.Text.Contains("Một phần"))
            {
                string duan = DuAnQH.Text.Replace("Một phần nằm trong ", "");
                duan = duan.Replace("QH ", "");
                dic.Add("KhuQH", duan);
                dic.Add("VungQH", VungQH.Text);

                int a = 0;
                while (a < 20)
                {

                    check = IsFileLocked(System.IO.Path.GetTempPath() + "\\" + fileSodovitri + ".jpg");
                    if (check == false)
                    {
                        WWord wd = new WWord(QLHTDT.Properties.Settings.Default.PathData + "\\MauXNQH.dotx", true);
                        wd.WriteFields(dic);
                        CreateJPEGHiResolutionFromActiveView(KienTruc.axPageLayoutControl1.ActiveView, System.IO.Path.GetTempPath() + "\\" + fileSodovitri + ".jpg");
                        wd.Addpicture(System.IO.Path.GetTempPath() + "\\" + fileSodovitri + ".jpg");
                        break;
                    }
                    else
                    {
                        fileSodovitri = "SoDoViTri";
                    }

                }



            }
            else
            {
                dic.Add("KhuQH", DuAnQH.Text);
                dic.Add("VungQH", VungQH.Text);
                int a = 0;
                while (a < 20)
                {

                    check = IsFileLocked(System.IO.Path.GetTempPath() + "\\" + fileSodovitri + ".jpg");
                    if (check == false)
                    {
                        WWord wd = new WWord(QLHTDT.Properties.Settings.Default.PathData + "\\MauXNQH.dotx", true);
                        wd.WriteFields(dic);
                        CreateJPEGHiResolutionFromActiveView(KienTruc.axPageLayoutControl1.ActiveView, System.IO.Path.GetTempPath() + "\\" + fileSodovitri + ".jpg");
                        wd.Addpicture(System.IO.Path.GetTempPath() + "\\" + fileSodovitri + ".jpg");
                        break;
                    }
                    else
                    {
                        fileSodovitri = "SoDoViTri";
                    }

                }
            }
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SoQD.Text = "";
                VungQH.Text = "";
                NgayPheDuyet.Text = "";
                DuAnQH.Text = "";
                //if (Phuong.SelectedItem.ToString() == "Hòa An")
                //{ table = "DIACHINH"; IDPhuong = "20306"; tableRGQH = "RGDAQH"; tableMatBang = "MATBANGQH"; }
                //else if (Phuong.SelectedItem.ToString() == "Hòa Phát")
                //{ table = "DIACHINH"; IDPhuong = "20305"; tableRGQH = "RGDAQH"; tableMatBang = "MATBANGQH"; }
                //else if (Phuong.SelectedItem.ToString() == "Hòa Thọ Đông")
                //{ table = "DIACHINH"; IDPhuong = "20312"; tableRGQH = "RGDAQH"; tableMatBang = "MATBANGQH"; }
                //else if (Phuong.SelectedItem.ToString() == "Hòa Thọ Tây")
                //{ table = "DIACHINH"; IDPhuong = "20311"; tableRGQH = "RGDAQH"; tableMatBang = "MATBANGQH"; }
                //else if (Phuong.SelectedItem.ToString() == "Hòa Xuân")
                //{ table = "DIACHINH"; IDPhuong = "20314"; tableRGQH = "RGDAQH"; tableMatBang = "MATBANGQH"; }
                //else if (Phuong.SelectedItem.ToString() == "Khuê Trung")
                //{ table = "DIACHINH"; IDPhuong = "20260"; tableRGQH = "RGDAQH"; tableMatBang = "MATBANGQH"; }
                //else { MessageBox.Show("Chưa chọn phường cần tra cứu", "Thông báo"); }
                //IDPhuong = Phuong.SelectedValue.ToString();
                if ((SThua.Text.ToString() == "") || (STo.Text.ToString() == "") || (SThua.Text.ToString() == "" && STo.Text.ToString() == ""))
                { MessageBox.Show("Chưa nhập số tờ hoặc số thửa.", "Thông báo"); }
                SqlConnection conn;
                SqlCommand command;
                conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                conn.Open();

                //string sql = "SELECT [KhuQH] FROM " + table + " where SoThua = '" + SThua.Text.ToString() + "' and SoToBD = '"+STo.Text.ToString()+"'";
                string sql = "select TenDuAn from RGDAQH,DIACHINH where SoThua = '" + SThua.Text.ToString() + "' and SoToBD = '" + STo.Text.ToString() + "' and IDPhuong = '" + IDPhuong + "' and RGDAQH.MaDuAn = DIACHINH.MaDuAnQH";
                command = new SqlCommand(sql, conn);
                if (command.ExecuteScalar() != DBNull.Value)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DuAnQH.Text = "";
                        DuAnQH.Text = reader.GetString(0);
                        break;
                    }
                    conn.Close();
                }
                conn.Close();
                if (DuAnQH.Text != "")
                {
                    conn.Open();
                    string sqlQD = "SELECT [QDPL] FROM RGDAQH where [TenDuAn] = N'" + DuAnQH.Text + "'";
                    string sqlNamQD = "SELECT [NamQDPL] FROM RGDAQH where [TenDuAn] = N'" + DuAnQH.Text + "'";
                    SqlCommand commandQD = new SqlCommand(sqlQD, conn);
                    SqlCommand commandNamQD = new SqlCommand(sqlNamQD, conn);
                    if (commandQD.ExecuteScalar() != DBNull.Value)
                    {
                        SqlDataReader readerQD = commandQD.ExecuteReader();
                        while (readerQD.Read())
                        {
                            SoQD.Text = "";
                            SoQD.Text = readerQD.GetDecimal(0).ToString();
                            break;
                        }
                        conn.Close();
                    }
                    else conn.Close();
                    conn.Open();
                    if (commandNamQD.ExecuteScalar() != DBNull.Value)
                    {
                        SqlDataReader readerNamQD = commandNamQD.ExecuteReader();
                        while (readerNamQD.Read())
                        {
                            NgayPheDuyet.Text = "";
                            NgayPheDuyet.Text = readerNamQD.GetDecimal(0).ToString();
                            break;
                        }
                        conn.Close();
                    }
                    else conn.Close();
                    //Lấy shape thửa đất
                    conn.Open();
                    string shape = "";
                    string sqlPolygon = "select shape.STAsText() from DIACHINH where SoThua = '" + SThua.Text + "' and SoToBD = '" + STo.Text + "' and IDPhuong = '" + IDPhuong + "'";
                    SqlCommand commandPolygon = new SqlCommand(sqlPolygon, conn);
                    if (commandPolygon.ExecuteScalar() != DBNull.Value)
                    {
                        SqlDataReader readerPolygon = commandPolygon.ExecuteReader();
                        while (readerPolygon.Read())
                        {
                            shape = readerPolygon.GetString(0);
                            break;
                        }
                        conn.Close();
                    }

                    else conn.Close();
                    //LayThongTin Mat Bang QH từ thửa

                    conn.Open();
                    string sqlMatbang = "SELECT TOP 1 [TenLoaiDat] from MATBANGQH where Shape.STOverlaps(geometry::STGeomFromText('" + shape + "', 0)) = 1";
                    SqlCommand commandMatbang = new SqlCommand(sqlMatbang, conn);
                    if (commandMatbang.ExecuteScalar() != DBNull.Value)
                    {
                        SqlDataReader readerMatbang = commandMatbang.ExecuteReader();
                        while (readerMatbang.Read())
                        {
                            VungQH.Text = "";
                            VungQH.Text = readerMatbang.GetString(0);
                            break;
                        }
                    }
                    conn.Close();
                    if (VungQH.Text == "")
                    {
                        conn.Open();
                        sqlMatbang = "SELECT TOP 1 [TenLoaiDat] from MATBANGQH where Shape.STContains(geometry::STGeomFromText('" + shape + "', 0)) = 1";
                        commandMatbang = new SqlCommand(sqlMatbang, conn);
                        if (commandMatbang.ExecuteScalar() != DBNull.Value)
                        {
                            SqlDataReader readerMatbang = commandMatbang.ExecuteReader();
                            while (readerMatbang.Read())
                            {
                                VungQH.Text = "";
                                VungQH.Text = readerMatbang.GetString(0);
                                break;
                            }
                        }
                    }

                    conn.Close();
                    if (VungQH.Text == "Đất ở")
                    {
                        VungQH.Text = "Chỉnh trang";
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin","Thông báo");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            if (Settings.Default.pathPDF != null)
            {
                openFileDialog.InitialDirectory = Properties.Settings.Default.pathPDF;
            }
            else { openFileDialog.InitialDirectory = @"C:\"; }
            openFileDialog.Filter = "file pdf (*.pdf)|*.pdf";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.pathPDF = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoaiHS == 1)
            {
                System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                if (Settings.Default.pathPDF != null)
                {
                    openFileDialog.InitialDirectory = Properties.Settings.Default.pathPDF;
                }
                else { openFileDialog.InitialDirectory = @"C:\"; }
                openFileDialog.Filter = "file pdf (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Properties.Settings.Default.pathPDF = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                }
            }
            else
            {
                string path = Properties.Settings.Default.PathData + "\\FileDinhKemXNQH\\HS" + maHS;
                if (Directory.Exists(path))
                {
                    QLHTDT.FormPhu.QLQH.listfilefolder frm = new listfilefolder(path);
                    frm.Show();
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa có dữ liệu file đính kèm, Có cập nhật dữ liệu hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Directory.CreateDirectory(path);
                        System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                        openFileDialog.InitialDirectory = @"C:\";
                        openFileDialog.Filter = "All file (*.*)|*.*";
                        openFileDialog.FilterIndex = 2;
                        openFileDialog.RestoreDirectory = true;
                        openFileDialog.Multiselect = true;
                        openFileDialog.ShowDialog();
                    }
                }
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = false;
                if (LoaiHS == 2)
                {
                    if (STo.Text != "" | SThua.Text != "" | Phuong.Text != "")
                    {
                        //ViTriTDat(false);
                        var date = DateTime.Now;
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic.Add("Ngay", date.Day.ToString());
                        dic.Add("Thang", date.Month.ToString());
                        dic.Add("Nam", date.Year.ToString());
                        dic.Add("ChuSuDung", TenNguoiGui.Text);
                        dic.Add("MucDichXacNhan", MucDich.Text);
                        dic.Add("SThua", SThua.Text);
                        dic.Add("STo", STo.Text);
                        dic.Add("To", To.Text);
                        dic.Add("SoGCN", SoGCN.Text);
                        dic.Add("NgayCapGCN", NgayCapGCN.Value.ToString("dd/MM/yyyy"));
                        dic.Add("QĐQH", SoQD.Text);
                        dic.Add("NgayPDQH", NgayPheDuyet.Text);
                        dic.Add("Phuong", Phuong.Text);
                        dic.Add("KhuQH", DuAnQH.Text);
                        dic.Add("VungQH", VungQH.Text);
                        int a = 0;
                        while (a < 20)
                        {
                            check = IsFileLocked(System.IO.Path.GetTempPath() + "\\" + fileSodovitri + ".jpg");
                            if (check == false)
                            {
                                WWord wd = new WWord(QLHTDT.Properties.Settings.Default.PathData + "\\MauXNQH.dotx", true);
                                CreateJPEGHiResolutionFromActiveView(KienTruc.axPageLayoutControl1.ActiveView, System.IO.Path.GetTempPath() + "\\" + fileSodovitri + ".jpg");
                                wd.Addpicture(System.IO.Path.GetTempPath() + "\\" + fileSodovitri + ".jpg");
                                wd.print(dic);
                                string sql = "select * from HoSoCapChungChiQH";
                                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                SqlCommand command = new SqlCommand(sql, connection);
                                command.Connection.Open();
                                string querystr2 = "UPDATE HoSoCapChungChiQH SET [TinhTrang] =N'Đang trình phê duyệt' FROM HoSoCapChungChiQH WHERE [SoToBD] =" + STo.Text + " and [SoThua] =" + SThua.Text + " and [IDPhuong] = "+IDPhuong+"";
                                SqlCommand query2 = new SqlCommand(querystr2, connection);
                                query2.ExecuteNonQuery();
                                command.Connection.Close();
                                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                                break;
                            }
                            else
                            {
                                fileSodovitri = "SoDoViTri";
                            }

                        }
                    }
                    else MessageBox.Show("Chưa nhập đủ thông tin thửa đất!", "Thông báo");
                    this.Hide();
                }
                else if (LoaiHS == 1)
                {
                    try
                    {
                        string cmdString = "INSERT INTO HoSoCapChungChiQH ([NguoiGui] ,[HoKhauThuongTru],[NamSinh],[SDT],[SoToBD],[SoThua],[MucDich],[DiaChiThuaDat],[PhoToGCN],[SoDoThuaDat],[NgayNopDon],[TinhTrang],[SOGXNQH],[ToDanPho],[IDPhuong],[NgayCapGCN]) VALUES (@NguoiGui, @HoKhauThuongTru, @NamSinh,@SDT, @SoToBD, @SoThua,@MucDich, @DiaChiThuaDat,@PhoToGCN, @SoDoThuaDat,@NgayNopDon, @TinhTrang,  @SOGXNQH, @ToDanPho, @IDPhuong,@NgayCapGCN)";
                        string connString = Settings.Default.strConnectionDAQH;
                        using (SqlConnection conn = new SqlConnection(connString))
                        {
                            using (SqlCommand comm = new SqlCommand())
                            {
                                ViTriTDat(false);
                                var date = DateTime.Now;
                                comm.Connection = conn;
                                comm.CommandText = cmdString;
                                comm.Parameters.AddWithValue("@NguoiGui", TenNguoiGui.Text);
                                comm.Parameters.AddWithValue("@HoKhauThuongTru", HoKhau.Text);
                                comm.Parameters.AddWithValue("@NamSinh", int.Parse(NamSinh.Text));
                                comm.Parameters.AddWithValue("@SoToBD", int.Parse(STo.Text));
                                comm.Parameters.AddWithValue("@SoThua", int.Parse(SThua.Text));
                                comm.Parameters.AddWithValue("@MucDich", MucDich.Text);
                                comm.Parameters.AddWithValue("@DiaChiThuaDat", ViTriThuaDat.Text);
                                comm.Parameters.AddWithValue("@PhoToGCN", SoGCN.Text);
                                comm.Parameters.AddWithValue("@SoDoThuaDat", "");
                                comm.Parameters.AddWithValue("@NgayNopDon", date.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                                comm.Parameters.AddWithValue("@TinhTrang", "Đang trình phê duyệt");
                                comm.Parameters.AddWithValue("@SOGXNQH", SoQD.Text);
                                comm.Parameters.AddWithValue("@ToDanPho", To.Text);
                                comm.Parameters.AddWithValue("@IDPhuong", IDPhuong);
                                comm.Parameters.AddWithValue("@NgayCapGCN", NgayCapGCN.Value.ToString("MM-dd-yyyy"));
                                MessageBox.Show("Thêm mới hồ sơ thành công", "Thông báo");
                                this.Close();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ các thông tin", "Thông báo");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin", "Thông báo");
            }
        }
        protected virtual bool IsFileLocked(string pathfile)
        {
            
            FileInfo file = new FileInfo(pathfile);

            FileStream stream = null;

            try
            {
                fileSodovitri = fileSodovitri + n.ToString();
                stream = file.Open( FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                n = n + 1;
                
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

  

        private void Quan_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            Phuong.ResetText();
            if (Quan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                Quan.Text = "";
            }
            if (AddQuan == 1)
            {
                MaHuyen = Quan.SelectedValue.ToString();
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + " ";

                SqlDataAdapter adp = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds = new DataSet();
                adp.Fill(ds);
                Phuong.DataSource = ds.Tables[0];
                Phuong.DisplayMember = "TenPhuong";
                Phuong.ValueMember = "MaPhuong";

                if (Quan.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    Phuong.Text = "";
                }
            }
        }
    }
}
