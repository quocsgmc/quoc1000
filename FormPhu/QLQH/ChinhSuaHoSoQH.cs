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
    public partial class ChinhSuaHoSoQH : Form
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
        int IDChinhSua = QLHTDT.FormPhu.QLQH.QuanlyQuyHoach.ID1;
        public ChinhSuaHoSoQH()
        {
            InitializeComponent();
            LoaiHS = 1;

        }
        public ChinhSuaHoSoQH(string NguoiGui, string HoKhauTT,string NamS,string sdtcodinh,string sdtdidong,string vitrithuadat,string soto,string sothua,string to,string phuong,string mucdich, string mahs, string ngaycapGCN, string photoGCN)
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
            NgayCapGCN.Text = ngaycapGCN;
            SoGCN.Text = photoGCN;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ViTriTDat(true);
        }

        string IDPhuong;
        private void ViTriTDat(bool ThongTinThua)
        {
            try
            {
                string layerget = "Địa chính";
                string tableKT = "TTKIENTRUC";
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
                    if (IDPhuong == "")
                    {
                        MessageBox.Show("Thông báo", "Chưa chọn phường cần tra cứu");

                    }
                    else if (IDPhuong != "")
                    {
                        if (STo.Text != "" && SThua.Text != "")
                        {
                            pFilter.WhereClause = "[SoToBD] = '" + STo.Text + "' AND [SoThua] = '" + STo.Text + "' and IDPhuong = '" + IDPhuong + "'";
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

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoaiHS == 2)
                {
                    //cập nhật thuộc tính đối tượng
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sql1 = "[PRC_UPDATE_HoSoQuyHoach_ID] "
                         + " '" + maHS
                       + "', N'" + TenNguoiGui.Text
                       + "', N'" + HoKhau.Text
                       + "', '" + NamSinh.Text
                       + "', N'" + SDTDiDong.Text
                       + "', '" + STo.Text
                       + "', '" + SThua.Text
                       + "', N'" + MucDich.Text
                       + "', N'" + ViTriThuaDat.Text
                       + "', '" + SoGCN.Text
                       + "', '" + NgayCapGCN.Value.ToString("MM-dd-yyyy")
                       + "', '" + To.Text
                       + "', '" + Quan.SelectedValue.ToString()
                       + "', '" + IDPhuong + "'";
                    SqlCommand command4 = new SqlCommand(sql1, conn);
                    command4.ExecuteScalar();

                    MessageBox.Show("Chỉnh sửa Hồ sơ chứng chỉ quy hoạch thành công", "Thông báo");
                    //Phần này là lưu nhật ký
                    KienTruc.TBNK = new DataTable();
                    SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                    cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                    KienTruc.dataAdapterNK.Fill(KienTruc.TBNK); 
                    KienTruc.ChinhSuathuoctinhToolQuanLy("Hồ sơ chứng chỉ quy hoạch", IDChinhSua);
                    KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                    this.Hide(); Cursor = Cursors.Default;
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

        private void ChinhSuaHoSoQH_Load(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

        private void Phuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Phuong.Text != "") { IDPhuong = Phuong.SelectedValue.ToString(); }
        }
    }
}
