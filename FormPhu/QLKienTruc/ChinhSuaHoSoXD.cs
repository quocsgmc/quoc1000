using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ESRI.ArcGIS.SystemUI;
using QLHTDT.FormChinh;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using QLHTDT.Properties;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace QLHTDT.FormPhu.QLKienTruc
{
    public partial class ChinhSuaHoSoXD : Form
    {
        int AddQuan = 0;
        public static string MaHuyen = "null";
        ILayer layeredit;
        string tableKT = "";
        int LoaiHS = 0;
        string SoSeri = "";
        string NgayCapGiayCN;
        SqlCommandBuilder cmbl;
        int IDChinhSua = QLHTDT.FormPhu.QLKienTruc.QuanlyCapPhepXD.ID1;
        public ChinhSuaHoSoXD()
        {
            InitializeComponent();
            //textBox4.Text = Day;
            //textBox3.Text = month;
            //textBox2.Text = year;
            LoaiHS = 1;
        }
        string ID1;
        public ChinhSuaHoSoXD(string soqd, string ID,string cdt, string diachi, string congtrinh, string thietke, string soto, string sothua, string duong, string viahe, string khuqh, string phuong, string dientich, string dientichxaydung, string tongdtsd, string mdxd, string hesosdd, string chieucaoct, string sotang, string chieucaocactang, string cotnenct, string khoanglui, string dovuon, string serigcn, string ngaycapgcn, string qdkhac,string chieucao, string ghichu)
        {
            InitializeComponent();
            ID1 = ID;
            ChuDauTu.Text = cdt;
            DiaChiCDT.Text = diachi;
            LoaiCT.Text = congtrinh;
            ThietKe.Text = thietke;
            SThua.Text = sothua;
            STo.Text = soto;
            Duong.Text = duong;
            ViaHe.Text = viahe;
            Khu.Text = khuqh;
            Phuong.Text = phuong;
            DienTich.Text = dientich;
            DTXD.Text = dientichxaydung;
            TongDTSD.Text = tongdtsd;
            MatDoXD.Text = mdxd;
            HeSoSDD.Text = hesosdd;
            ChieuCaoCacTang.Text = chieucaocactang;
            SoTang.Text = sotang;
            NenCongTrinh.Text = cotnenct;
            KLui.Text = khoanglui;
            DoVuon.Text = dovuon;
            txtSeriGCN.Text = serigcn;
            SoSeri = serigcn;
            NgayCapGiayCN = ngaycapgcn;
            dateTimePickerCapGP.Text = ngaycapgcn;
            ChieuCaoCT.Text = chieucao;
            SoQD.Text = soqd;
            txtGhiChu.Text = ghichu;
            //GiayToLienQuan.Text = "Giấy chứng nhận QSDĐ số seri "+serigcn +" do Sở Tài nguyên & Môi trường TP Đà Nẵng cấp ngày "+ NgayCapGiayCN.Day +"/"+ NgayCapGiayCN.Month + "/" + NgayCapGiayCN.Year+ ".";
            //NoiDung.Text = qdkhac;
            var date = DateTime.Now;
            textBox4.Text = date.Day.ToString();
            textBox3.Text = date.Month.ToString();
            textBox2.Text = date.Year.ToString();
            LoaiHS = 2;

        }
        private void btXemBanIn_Click(object sender, EventArgs e)
        {
            
            var date = DateTime.Now;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Ngay", textBox4.Text);
            dic.Add("Thang", textBox3.Text);
            dic.Add("Nam", textBox2.Text);
            dic.Add("ChuDauTu", ChuDauTu.Text);
            dic.Add("DiaChiCDT", DiaChiCDT.Text);
            dic.Add("LoaiCT", LoaiCT.Text);
            dic.Add("ThietKe", ThietKe.Text);
            dic.Add("SThua", SThua.Text);
            dic.Add("STo", STo.Text);
            dic.Add("Duong", Duong.Text);
            dic.Add("ViaHe", ViaHe.Text);
            dic.Add("Khu", Khu.Text);
            dic.Add("Phuong", IDPhuong);
            dic.Add("DTThua", DienTich.Text);
            dic.Add("DTXDT1", DTXD.Text);
            dic.Add("TongDTXD", TongDTSD.Text);
            dic.Add("MatDoXD", MatDoXD.Text);
            dic.Add("HeSoSDD", HeSoSDD.Text);
            dic.Add("ChieuCao", ChieuCaoCT.Text);
            dic.Add("SoTang", SoTang.Text);
            dic.Add("CaoCacTang", ChieuCaoCacTang.Text);
            dic.Add("CotNen", NenCongTrinh.Text);
            dic.Add("DonViLienHe", txtGhiChu.Text);
            //dic.Add("GiayToLienQuan", GiayToLienQuan.Text);
            //dic.Add("NDCapPhep", NoiDung.Text);
            dic.Add("KhoangLui", KLui.Text);
            dic.Add("DoVuon", DoVuon.Text);
            dic.Add("SoQD", SoQD.Text);
            dic.Add("Phuong2", Phuong.Text);
            WWord wd = new WWord(QLHTDT.Properties.Settings.Default.PathData + "\\MauCPXD.dotx", true);
            wd.WriteFields(dic);
        }
        private void ZoomToLayers()
        {
            ICommand command = new ControlsZoomToSelectedCommand();
            command.OnCreate(KienTruc.axMapControl1.Object);
            KienTruc.axMapControl1.CurrentTool = command as ITool;
            command.OnClick();
        }
        private void btViTriBD_Click(object sender, System.EventArgs e)
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
        private void button5_Click(object sender, System.EventArgs e)
        {
            //QLHTDT.FormPhu.QLKienTruc.Quetfile frm = new QLHTDT.FormPhu.QLKienTruc.Quetfile();
            //frm.Show();
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
        private void btInGP_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (LoaiHS == 2)
                {
                    //cập nhật thuộc tính đối tượng
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sql1 = "[PRC_UPDATE_HoSoXayDung_ID] "
                         + " '" + IDChinhSua
                       + "', N'" + ChuDauTu.Text
                       + "', N'" + DiaChiCDT.Text
                       + "', '" + SThua.Text
                       + "', '" + STo.Text
                       + "', N'" + LoaiCT.Text
                       + "', '" + ThietKe.Text
                       + "', '" + ChieuCaoCT.Text
                       + "', '" + SoTang.Text
                       + "', N'" + Duong.Text
                       + "', N'" + ViaHe.Text
                       + "', N'" + MatDoXD.Text
                       + "', N'" + HeSoSDD.Text
                       + "', N'" + ChieuCaoCacTang.Text
                       + "', N'" + KLui.Text
                       + "', N'" + DoVuon.Text
                       + "', N'" + txtSeriGCN.Text
                       + "', N'" + TongDTSD.Text
                       + "', N'" + DienTich.Text
                       + "', N'" + TongDTSD.Text
                       + "', '" + Quan.SelectedValue.ToString()
                       + "', '" + IDPhuong
                       + "', '" + dateTimePickerCapGP.Value.ToString("MM-dd-yyyy")
                       + "', N'" + txtGhiChu.Text
                       + "', '" + SoQD.Text + "'";
                    SqlCommand command4 = new SqlCommand(sql1, conn);
                    command4.ExecuteScalar();

                    MessageBox.Show("Chỉnh sửa Hồ sơ cấp phép xây dựng thành công", "Thông báo");
                    //Phần này là lưu nhật ký
                    KienTruc.TBNK = new DataTable();
                    SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                    cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                    KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                    KienTruc.ChinhSuathuoctinhToolQuanLy("Hồ sơ Cấp phép xây dựng", IDChinhSua);
                    KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                    this.Hide(); Cursor = Cursors.Default;
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin", "Thông báo");
            }
        }

        private void btFileDinhKem_Click(object sender, System.EventArgs e)
        {
            if (LoaiHS == 1)
            {
                if (STo.Text != "" && SThua.Text != "" && STo.Text != null & SThua.Text != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa có dữ liệu hồ sơ cấp phép, Có tạo dữ liệu hồ sơ cấp phép không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string sql = "select MaHS from CPXD where ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + STo.Text + "' and [SoThua] ='" + SThua.Text + "')";
                        SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        SqlCommand commanCPXD = new SqlCommand(sql, connection);
                        commanCPXD.Connection.Open();
                        string pathMaHS = "";
                        string pathcheck = "";
                        if (commanCPXD.ExecuteScalar() != DBNull.Value)
                        {
                            pathcheck = (string)commanCPXD.ExecuteScalar();
                            if (pathcheck != "" & pathcheck != null)
                            {
                                pathMaHS = pathcheck;
                            }
                        }

                        WebRequest ftpRequest = WebRequest.Create("ftp://117.2.120.9/FileDinhKemCPXD/" + pathMaHS.Replace(" ", "").ToString());
                        ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                        ftpRequest.Credentials = new NetworkCredential("sinhnv", "Abc#1234");
                        using (var resp = (FtpWebResponse)ftpRequest.GetResponse())
                        {
                            Console.WriteLine(resp.StatusCode);
                        }

                        QLHTDT.FormPhu.QLQH.listfilefolder frm = new QLQH.listfilefolder("ftp://117.2.120.9/FileDinhKemCPXD/" + pathMaHS.Replace(" ", "").ToString(), "sinhnv", "Abc#1234");
                        frm.Show();
                    }
                    
                }
                else { MessageBox.Show("Chưa có thông tin thửa đất (số tờ, số thửa, Phường)", "Thông báo"); }
            }
            else if (LoaiHS == 2)
            {
                string sql = "select MaHS from CPXD where ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + STo.Text + "' and [SoThua] ='" + SThua.Text + "')";
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                SqlCommand commanCPXD = new SqlCommand(sql, connection);
                commanCPXD.Connection.Open();
                string pathMaHS = "";
                string pathcheck = "";
                if (commanCPXD.ExecuteScalar() != DBNull.Value)
                {
                    pathcheck = (string)commanCPXD.ExecuteScalar();
                    if (pathcheck != "" & pathcheck != null)
                    {
                        pathMaHS = pathcheck;
                    }
                }
                QLHTDT.FormPhu.QLQH.listfilefolder frm = new QLQH.listfilefolder("ftp://117.2.120.9/FileDinhKemCPXD/" + pathMaHS.Replace(" ", "").ToString(), "sinhnv", "Abc#1234");
                frm.Show();

            }
        }
        string IDPhuong = "null";
        private void Phuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Phuong.Text != "") { IDPhuong = Phuong.SelectedValue.ToString(); }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChinhSuaHoSoXD_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Quan.DataSource = ds.Tables[0];
            Quan.DisplayMember = "TENHUYEN";
            Quan.ValueMember = "MAHUYEN";

            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_DangKyCapPhepXD_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                ChuDauTu.Text = ds3.Tables[0].Rows[0]["TenCDT"].ToString();
                DiaChiCDT.Text = ds3.Tables[0].Rows[0]["DiaChi"].ToString();
                LoaiCT.Text = ds3.Tables[0].Rows[0]["LoaiCT"].ToString();
                ThietKe.Text = ds3.Tables[0].Rows[0]["ThietKe"].ToString();
                SThua.Text = ds3.Tables[0].Rows[0]["SoThua"].ToString();
                STo.Text = ds3.Tables[0].Rows[0]["SoTo"].ToString();
                Duong.Text = ds3.Tables[0].Rows[0]["Duong"].ToString();
                ViaHe.Text = ds3.Tables[0].Rows[0]["ViaHe"].ToString();
                Quan.Text = ds3.Tables[0].Rows[0]["QuanHuyen"].ToString(); ;
                Phuong.Text = ds3.Tables[0].Rows[0]["TenPhuong"].ToString();
                if (ds3.Tables[0].Rows[0]["SoTo"].ToString() != "" & ds3.Tables[0].Rows[0]["SoThua"].ToString() != "" & ds3.Tables[0].Rows[0]["TenPhuong"].ToString() != "")
                {
                    IDPhuong = ds3.Tables[0].Rows[0]["IDPhuong"].ToString();
                    string table = "DIACHINH";
                    if ((ds3.Tables[0].Rows[0]["SoThua"].ToString() == "") || (ds3.Tables[0].Rows[0]["SoTo"].ToString() == "") || (ds3.Tables[0].Rows[0]["SoThua"].ToString() == "" && ds3.Tables[0].Rows[0]["SoTo"].ToString() == ""))
                    { MessageBox.Show("Chưa có thông tin số tờ hoặc số thửa.", "Thông báo"); }
                    SqlConnection conn;
                    SqlCommand command;
                    conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    //string sql = "SELECT [MaDuAnQH] FROM " + table + " where SoThua = '" + sothua + "' and SoToBD = '" + soto + "' and IDPhuong = '" + IDPhuong + "'";
                    string sql = "Select TenDuAn from RGDAQH where MaDuAn =  (SELECT [MaDuAnQH] FROM DIACHINH where SoThua = '" + ds3.Tables[0].Rows[0]["SoThua"].ToString() + "' and SoToBD = '" + ds3.Tables[0].Rows[0]["SoTo"].ToString() + "' and IDPhuong = '" + IDPhuong + "')";
                    command = new SqlCommand(sql, conn);
                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Khu.Text = reader.GetString(0);
                            break;
                        }
                    }
                    conn.Close();
                }
                DienTich.Text = ds3.Tables[0].Rows[0]["DT"].ToString();
                DTXD.Text = ds3.Tables[0].Rows[0]["DTXD"].ToString();
                TongDTSD.Text = ds3.Tables[0].Rows[0]["TongDTSDD"].ToString();
                MatDoXD.Text = ds3.Tables[0].Rows[0]["MDXD"].ToString();
                HeSoSDD.Text = ds3.Tables[0].Rows[0]["HESOSDD"].ToString();
                ChieuCaoCacTang.Text = ds3.Tables[0].Rows[0]["ChieuCaoCacTang"].ToString();
                ChieuCaoCT.Text = ds3.Tables[0].Rows[0]["ChieuCao"].ToString();
                SoTang.Text = ds3.Tables[0].Rows[0]["SoTang"].ToString();
                NenCongTrinh.Text = ds3.Tables[0].Rows[0]["CotNen"].ToString();
                KLui.Text = ds3.Tables[0].Rows[0]["KhoangLui"].ToString();
                DoVuon.Text = ds3.Tables[0].Rows[0]["DoVuon"].ToString();
                txtSeriGCN.Text = ds3.Tables[0].Rows[0]["seriGCN"].ToString();
                txtGhiChu.Text = ds3.Tables[0].Rows[0]["GhiChu"].ToString();
                //NoiDung.Text = qdkhac;
                var date = DateTime.Now;
                textBox4.Text = date.Day.ToString();
                textBox3.Text = date.Month.ToString();
                textBox2.Text = date.Year.ToString();
                LoaiHS = 2;
            }
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
