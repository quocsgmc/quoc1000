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
    public partial class ThemHoSoCapCCQH : Form
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
        SqlCommandBuilder cmbl;
        public ThemHoSoCapCCQH()
        {
            InitializeComponent();
            LoaiHS = 1;

        }
        public ThemHoSoCapCCQH(string NguoiGui, string HoKhauTT,string NamS,string sdtcodinh,string sdtdidong,string vitrithuadat,string soto,string sothua,string to,string phuong,string mucdich, string mahs )
        {
            InitializeComponent();
            TenNguoiGui.Text = NguoiGui;
            NamSinh.Text = NamS;
            HoKhau.Text = HoKhauTT;
            SDTDiDong.Text = sdtdidong;
            ViTriThuaDat.Text = vitrithuadat;
            STo.Text = soto;
            SThua.Text = sothua;
            To.Text = to;
            if(phuong == "20306") { Phuong.Text = "Hòa An"; }
            else if(phuong == "20305") { Phuong.Text = "Hòa Phát"; }
            else if (phuong == "20312") { Phuong.Text = "Hòa Thọ Đông"; }
            else if (phuong == "20311") { Phuong.Text = "Hòa Thọ Tây"; }
            else if (phuong == "20314") { Phuong.Text = "Hòa Xuân"; }
            else if (phuong == "20260") { Phuong.Text = "Khuê Trung"; }
            Phuong.Text = phuong;
            MucDich.Text = mucdich;
            LoaiHS = 2;
            maHS = mahs;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ViTriTDat(true);
        }

        string IDPhuong;
        private void ViTriTDat(bool ThongTinThua)
        {
            string mbqh = "";
            int index;
            int intft = 0;
            List<int> indexes = new List<int>();
            
            if (STo.Text == "" && SThua.Text == "")
            { MessageBox.Show("Chưa nhập số tờ, số thửa", "Thông báo"); }
            else
            {
                Cursor = Cursors.WaitCursor;
                
                string txtDAQH = "";
                layerget = "";
                string layerGT = "";
                int KTMoLopGT = 0;
                string layerKH = "";
                int KTMoLopKH = 0;
                string layerRGQH = "";
                int KTMoLopDAQH = 0;
                int KTMoLopMBQH = 0;
                if (Phuong.Text == "Hòa An")
                { txtDAQH = Phuong.Text; layerget = "Địa chính";IDPhuong = "20306"; tableKT = "TTKIENTRUC"; layerGT = "Đường chính - HA"; layerKH = "Kiệt hẻm - HA"; layerRGQH = "Ranh giới quy hoạch - HA"; mbqh = "Mặt bằng quy hoạch - HA"; }
                else if (Phuong.Text == "Hòa Phát")
                { txtDAQH = Phuong.Text; layerget = "Địa chính"; IDPhuong = "20305"; tableKT = "TTKIENTRUC"; layerGT = "Đường chính - HP"; layerKH = "Kiệt hẻm - HP"; layerRGQH = "Ranh giới quy hoạch - HP"; mbqh = "Mặt bằng quy hoạch - HP"; }
                else if (Phuong.Text == "Hòa Thọ Tây")
                { txtDAQH = Phuong.Text; layerget = "Địa chính"; IDPhuong = "20311"; tableKT = "TTKIENTRUC"; layerGT = "Đường chính - HTT"; layerKH = "Kiệt hẻm - HTT"; layerRGQH = "Ranh giới quy hoạch - HTT"; mbqh = "Mặt bằng quy hoạch - HTT"; }
                else if (Phuong.Text == "Hòa Thọ Đông")
                { txtDAQH = Phuong.Text; layerget = "Địa chính"; IDPhuong = "20312"; tableKT = "TTKIENTRUC"; layerGT = "Đường chính - HTD"; layerKH = "Kiệt hẻm - HTD"; layerRGQH = "Ranh giới quy hoạch - HTD"; mbqh = "Mặt bằng quy hoạch - HTD"; }
                else if (Phuong.Text == "Hòa Xuân")
                { txtDAQH = Phuong.Text; layerget = "Địa chính"; IDPhuong = "20314"; tableKT = "TTKIENTRUC"; layerGT = "Đường chính - HX"; layerKH = "Kiệt hẻm - HX"; layerRGQH = "Ranh giới quy hoạch - HX"; mbqh = "Mặt bằng quy hoạch - HX"; }
                else if (Phuong.Text == "Khuê Trung")
                { txtDAQH = Phuong.Text; layerget = "Địa chính"; IDPhuong = "20260"; tableKT = "TTKIENTRUC"; layerGT = "Đường chính - KT"; layerKH = "Kiệt hẻm - KT"; layerRGQH = "Ranh giới quy hoạch - KT"; mbqh = "Mặt bằng quy hoạch - KT"; }
                int KTMoLop = 0;
                string PhuongKT = null;
                try
                {
                    PhuongKT = "Địa chính";
                    for (int i1 = 0; i1 < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i1++)
                    {
                        if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == Phuong.Text)
                        {
                            ICompositeLayer igroup1 = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.Layer[i1] as ICompositeLayer;
                            for (int i = 0; i < igroup1.Count; i++)
                            {
                                ILayer ilayer1 = igroup1.get_Layer(i) as ILayer;
                                if (ilayer1.Name == layerget)
                                {
                                    KTMoLop = KTMoLop + 1;
                                    layeredit = ilayer1;
                                    KienTruc.axMapControl1.Extent = layeredit.AreaOfInterest;
                                }
                                if (ilayer1.Name == layerGT)
                                {
                                    KTMoLopGT = KTMoLopGT + 1;
                                }
                                if (ilayer1.Name == layerKH)
                                {
                                    KTMoLopKH = KTMoLopKH + 1;
                                }
                                if (ilayer1.Name == mbqh)
                                {
                                    KTMoLopMBQH = KTMoLopMBQH + 1;
                                }
                                if (ilayer1.Name == layerRGQH)
                                {
                                    KTMoLopDAQH = KTMoLopDAQH + 1;
                                }
                            }
                        }
                        else
                        {
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                layeredit = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1);
                                KienTruc.axMapControl1.Extent = KienTruc.axMapControl1.get_Layer(i1).AreaOfInterest;
                            }
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == layerGT)
                            {
                                KTMoLopGT = KTMoLopGT + 1;
                            }
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == layerKH)
                            {
                                KTMoLopKH = KTMoLopKH + 1;
                            }
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == mbqh)
                            {
                                KTMoLopMBQH = KTMoLopMBQH + 1;
                            }
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == layerRGQH)
                            {
                                KTMoLopDAQH = KTMoLopDAQH + 1;
                            }
                        }
                    }
                    if (KTMoLop == 0)
                    {
                        QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + layerget + ".lyr");
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
                        //if (KTMoLopGT == 0)
                        //{
                        //    QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + layerGT + ".lyr");
                        //    QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        //}
                        //if (KTMoLopKH == 0)
                        //{
                        //    QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + layerKH + ".lyr");
                        //    QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        //}
                        //if (KTMoLopDAQH == 0)
                        //{
                        //    QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + layerRGQH + ".lyr");
                        //    QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        //}
                        //if (KTMoLopMBQH == 0)
                        //{
                        //    QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + mbqh + ".lyr");
                        //    QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Cursor = Cursors.Default;



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
                        MessageBox.Show("Chưa chọn phường cần tra cứu", "Thông báo");

                    }
                    else if (Phuong.Text != "")
                    {
                        if (STo.Text != "" && SThua.Text != "")
                        {
                            pFilter.WhereClause = "[SoToBD] = '" + STo.Text + "' AND [SoThua] = '" + SThua.Text + "' AND [IDPhuong] = '"+ IDPhuong + "'";
                            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                            ZoomToLayers();
                            QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale * 5;
                            QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView.Refresh();
                        }
                        else if (STo.Text != "" && SThua.Text == "")
                        {
                            pFilter.WhereClause = "[SoToBD] = '" + STo.Text + "' AND [Phuong] = '" + Phuong.Text + "'";
                            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                            ZoomToLayers();
                            QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale * 5;
                            QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView.Refresh();
                        }
                        else if (STo.Text == "" && SThua.Text != "")
                        {
                            pFilter.WhereClause = "[SoThua] = '" + SThua.Text + "' AND [Phuong] = '" + Phuong.Text + "'";
                            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                            ZoomToLayers();
                            QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale * 5;
                            QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Chưa chọn số tờ bản đồ hoặc số thửa đất cần tra cứu", "Thông báo");
                        }
                        
                    }
                   if (ThongTinThua == true)
                    {
                        IEnumIDs idList = featSelect.SelectionSet.IDs;
                        index = idList.Next();

                        while (index != -1)
                        {
                            indexes.Add(index);
                            index = idList.Next();
                        }
                        IFeatureClass featureClass = pFeatureLayer2.FeatureClass;

                        KienTruc.tt = new DataTable();
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
                            intft = i2;
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
                                string sql1 = "SELECT [TenKhuVuc] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                SqlCommand command1 = new SqlCommand(sql1, conn);
                                if (command1.ExecuteScalar() != DBNull.Value)
                                {
                                    KienTruc.dr[9] = (string)command1.ExecuteScalar();
                                }
                                string sql2 = "SELECT [TangCaoXD] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                SqlCommand command2 = new SqlCommand(sql2, conn);
                                if (command2.ExecuteScalar() != DBNull.Value)
                                {
                                    KienTruc.dr[10] = (string)command2.ExecuteScalar();
                                }
                                string sql3 = "SELECT [ChiGioiXD] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                SqlCommand command3 = new SqlCommand(sql3, conn);
                                if (command3.ExecuteScalar() != DBNull.Value)
                                {
                                    KienTruc.dr[11] = (string)command3.ExecuteScalar();
                                }
                                string sql4 = "SELECT [ChieuCaoTang] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                SqlCommand command4 = new SqlCommand(sql4, conn);
                                if (command4.ExecuteScalar() != DBNull.Value)
                                {
                                    KienTruc.dr[12] = (string)command4.ExecuteScalar();
                                }
                                string sql5 = "SELECT [CotNen] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                SqlCommand command5 = new SqlCommand(sql5, conn);
                                if (command5.ExecuteScalar() != DBNull.Value)
                                {
                                    KienTruc.dr[13] = (string)command5.ExecuteScalar();
                                }
                                string sql6 = "SELECT [QDKhac] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                SqlCommand command6 = new SqlCommand(sql6, conn);
                                if (command6.ExecuteScalar() != DBNull.Value)
                                {
                                    KienTruc.dr[14] = (string)command6.ExecuteScalar();
                                }
                            }
                            //string sql = "SELECT [SoQD] FROM CPXD WHERE [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "' and [Phuong] =N'" + feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString() + "' and ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "')";
                            string sql = "SELECT [SoQD] FROM CPXD WHERE [SoTo] ='" + STo.Text + "' and [SoThua] = '" + SThua.Text + "' and [IDPhuong] = '" + IDPhuong + "' and ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + STo.Text + "' and [SoThua] ='" + SThua.Text + "')";
                            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            SqlCommand commanCPXD = new SqlCommand(sql, connection);
                            commanCPXD.Connection.Open();
                            string SoGPXD = "";
                            if (commanCPXD.ExecuteScalar() != DBNull.Value)
                            {
                                SoGPXD = (string)commanCPXD.ExecuteScalar();
                                if (SoGPXD != "" & SoGPXD != null)
                                {
                                    SoGPXD = (string)commanCPXD.ExecuteScalar();
                                    KienTruc.dr[15] = SoGPXD;
                                    KienTruc.dr[16] = "Thửa đất đã được cấp phép xây dựng - GPXD số " + SoGPXD;
                                    SqlCommand commanMaHSCPXD = new SqlCommand("SELECT [MaHS] FROM [CPXD] WHERE [SoQD] = '" + SoGPXD + "'", connection);
                                    commanCPXD.Connection.Close();
                                    commanMaHSCPXD.Connection.Open();
                                    KienTruc.dr[17] = (string)commanMaHSCPXD.ExecuteScalar();
                                    commanMaHSCPXD.Connection.Close();
                                }
                                else { KienTruc.dr[16] = "Chưa có thông tin cấp phép xây dựng."; commanCPXD.Connection.Close(); }
                            }
                            else { KienTruc.dr[16] = "Chưa có thông tin cấp phép xây dựng."; commanCPXD.Connection.Close(); }

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
                        //QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale * 5;
                        //QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView.Refresh();
                    }
                   
                }
                else { MessageBox.Show("Chưa chọn phường cần tra cứu", "Thông báo"); }
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
            bool check = false;
            try
            {
                string cmdString = "INSERT INTO HoSoCapChungChiQH ([NguoiGui] ,[HoKhauThuongTru],[NamSinh],[SDT],[SoToBD],[SoThua],[MucDich],[DiaChiThuaDat],[PhoToGCN],[SoDoThuaDat],[NgayNopDon],[TinhTrang],[ToDanPho],[IDHuyen],[IDPhuong],[NgayCapGCN]) VALUES (@NguoiGui, @HoKhauThuongTru, @NamSinh,@SDT, @SoToBD, @SoThua,@MucDich, @DiaChiThuaDat,@PhoToGCN, @SoDoThuaDat,@NgayNopDon, @TinhTrang, @ToDanPho,@IDHuyen, @IDPhuong,@NgayCapGCN)";
                string connString = Settings.Default.strConnectionDAQH;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                      
                        //ViTriTDat(false);
                        var date = DateTime.Now;
                        comm.Connection = conn;
                        comm.CommandText = cmdString;
                        comm.Parameters.AddWithValue("@NguoiGui", TenNguoiGui.Text);
                        comm.Parameters.AddWithValue("@HoKhauThuongTru", HoKhau.Text);
                        comm.Parameters.AddWithValue("@NamSinh", int.Parse(NamSinh.Text));
                        comm.Parameters.AddWithValue("@SDT", SDTDiDong.Text);
                        comm.Parameters.AddWithValue("@SoToBD", int.Parse(STo.Text));
                        comm.Parameters.AddWithValue("@SoThua", int.Parse(SThua.Text));
                        comm.Parameters.AddWithValue("@MucDich", MucDich.Text);
                        comm.Parameters.AddWithValue("@DiaChiThuaDat", ViTriThuaDat.Text);
                        comm.Parameters.AddWithValue("@PhoToGCN", SoGCN.Text);
                        comm.Parameters.AddWithValue("@SoDoThuaDat", "");
                        comm.Parameters.AddWithValue("@NgayNopDon", date.ToString("MM-dd-yyyy"));
                        comm.Parameters.AddWithValue("@TinhTrang", "Chưa xử lý");
                        comm.Parameters.AddWithValue("@ToDanPho", To.Text);
                        comm.Parameters.AddWithValue("@IDHuyen", Quan.SelectedValue.ToString());
                        comm.Parameters.AddWithValue("@IDPhuong", Phuong.SelectedValue.ToString());
                        comm.Parameters.AddWithValue("@NgayCapGCN", NgayCapGCN.Value.ToString("MM-dd-yyyy"));
                        conn.Open();
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Thêm mới hồ sơ thành công", "Thông báo");
                        //Lấy ID Hồ sơ
                        SqlDataAdapter adp3 = new SqlDataAdapter("Select ID from CPXD where SoTo = '" + STo.Text + "' AND SoThua = '" + SThua.Text + "' AND IDPhuong = '" + Phuong.SelectedValue.ToString() + "'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        DataSet ds3 = new DataSet();
                        adp3.Fill(ds3);
                        string OBJECTID = ds3.Tables[0].Rows[0]["ID"].ToString();
                        int ID;
                        Int32.TryParse(OBJECTID, out ID);
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Hồ sơ chứng chỉ quy hoạch",ID);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                        this.Hide(); Cursor = Cursors.Default;
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

        private void Phuong_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemHoSoCapCCQH_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Quan.DataSource = ds.Tables[0];
            Quan.DisplayMember = "TENHUYEN";
            Quan.ValueMember = "MAHUYEN";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
