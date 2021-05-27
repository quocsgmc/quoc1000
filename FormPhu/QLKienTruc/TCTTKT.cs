using System;
using System.Data;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using System.Data.SqlClient;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ESRI.ArcGIS.Geometry;

namespace QLHTDT.FormPhu.QLKienTruc
{
    public partial class TCTTKT : Form
    {
        private AxMapControl mMapControl;
        private ESRI.ArcGIS.Carto.IMap dmap;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        //ILayer layerchk;
        //ILayer layeredit;
        //IWorkspaceEdit workspaceEdit;
        SqlCommandBuilder cmbl;
        //QLHTDT.axToccontrol.Table.TableWrapper wratbal;
        //int TongDuAn;
        string layerget;
        //string txtChiaLo;
        string tablesql = "";
        string tableKT = "";
        public TCTTKT()
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map;
        }
        public TCTTKT(AxMapControl mapControl)
        {
            InitializeComponent();
            mMapControl = mapControl;
            dmap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map;
            //LoadLayertoCbo2();
            //caption = "Xác nhận thông tin quy hoạch";
        }
        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            System.Drawing.Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            DoRowDoubleClick(view, pt); 
        }
        public static DataTable tt; public static DataRow dr;
        public static QLHTDT.FormPhu.FormChiTietLayer.TTTD frm1Thua;
        private void DoRowDoubleClick(GridView view, System.Drawing.Point pt)
        {
            string tableKT = "TTKIENTRUC";
            int KTMoLop = 0;
            string PhuongKT = null;
            try
            {
                string Phuong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenPhuong").ToString();

                layerget = "Địa chính"; tableKT = "TTKIENTRUC";

                for (int i1 = 0; i1 < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i1++)
                {
                    if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == Phuong)
                    {
                        ICompositeLayer igroup1 = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.Layer[i1] as ICompositeLayer;
                        for (int i = 0; i < igroup1.Count; i++)
                        {
                            IFeatureLayer ilayer1 = igroup1.get_Layer(i) as IFeatureLayer;
                            if (ilayer1.Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                int ID;
                                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian thửa đất này", "Thông báo"); }
                                else
                                {
                                    IFeatureLayer ilayer = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1) as IFeatureLayer;
                                    IFeature ife = ilayer.FeatureClass.GetFeature(ID);
                                    if (ife != null)
                                    {
                                        QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, dmap, ilayer);
                                        IActiveView ActiveView = dmap as IActiveView;
                                        IEnvelope pEnv = null;
                                        pEnv = ife.ShapeCopy.Envelope;
                                        ActiveView.Extent = pEnv;
                                        dmap.MapScale = 500;
                                        ActiveView.Refresh();

                                        tt = new DataTable();
                                        tt.Columns.Add("Mã", typeof(String));
                                        tt.Columns.Add("Số tờ bản đồ", typeof(String));
                                        tt.Columns.Add("Số thửa", typeof(String));
                                        tt.Columns.Add("Diện tích", typeof(String));
                                        tt.Columns.Add("Loại đất", typeof(String));
                                        tt.Columns.Add("Phường", typeof(String));
                                        tt.Columns.Add("Thông tin quy hoạch", typeof(String));
                                        tt.Columns.Add("Phường1", typeof(String));
                                        tt.Columns.Add("Loại đất1", typeof(String));
                                        tt.Columns.Add("TenKhuVuc", typeof(String));
                                        tt.Columns.Add("TangCaoXD", typeof(String));
                                        tt.Columns.Add("ChiGioiXD", typeof(String));
                                        tt.Columns.Add("ChieuCaoTang", typeof(String));
                                        tt.Columns.Add("CotNen", typeof(String));
                                        tt.Columns.Add("QDKhac", typeof(String));
                                        tt.Columns.Add("SoGPXD", typeof(String));
                                        tt.Columns.Add("TTCPXD", typeof(String));
                                        tt.Columns.Add("MaHSCPXD", typeof(String));
                                        IFeature feature = ife;
                                        dr = tt.NewRow();
                                        dr[0] = feature.get_Value(feature.Fields.FindField("OBJECTID")).ToString();
                                        if (feature.get_Value(feature.Fields.FindField("SoToBD")) != DBNull.Value)
                                        {
                                            dr[1] = feature.get_Value(feature.Fields.FindField("SoToBD")).ToString();
                                        }
                                        if (feature.get_Value(feature.Fields.FindField("SoThua")) != DBNull.Value)
                                        {
                                            dr[2] = feature.get_Value(feature.Fields.FindField("SoThua")).ToString();
                                        }
                                        if (feature.get_Value(feature.Fields.FindField("DienTich")) != DBNull.Value)
                                        {
                                            dr[3] = feature.get_Value(feature.Fields.FindField("DienTich")).ToString();
                                        }
                                        if (feature.get_Value(feature.Fields.FindField("LoaiDat")) != DBNull.Value)
                                        {
                                            dr[4] = feature.get_Value(feature.Fields.FindField("LoaiDat")).ToString();
                                        }
                                        if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenPhuong").ToString() != "")
                                        {
                                            dr[5] = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenPhuong").ToString();
                                        }
                                        if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaDuAnQH").ToString() != "")
                                        {
                                            string MaDuAnQH = feature.get_Value(feature.Fields.FindField("MaDuAnQH")).ToString().Replace(" ", "");
                                            SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                            conn.Open();
                                            string sql1 = "SELECT [TenDuAn] FROM [GISCAMLE].[dbo].RGDAQH where MaKV = '" + MaDuAnQH + "'";
                                            SqlCommand command1 = new SqlCommand(sql1, conn);
                                            if (command1.ExecuteScalar() != DBNull.Value)
                                            {
                                                dr[6] = (string)command1.ExecuteScalar();
                                            }
                                        }
                                        //if (feature.get_Value(feature.Fields.FindField("TenPhuong")) != DBNull.Value)
                                        //{
                                        //    dr[7] = feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString();
                                        //}
                                        //if (feature.get_Value(feature.Fields.FindField("LoaiDat")) != DBNull.Value)
                                        //{
                                        //    dr[8] = feature.get_Value(feature.Fields.FindField("LoaiDat")).ToString();
                                        //}
                                        if (feature.get_Value(feature.Fields.FindField("MaKVKT")) != DBNull.Value)
                                        {

                                            string MaKT = feature.get_Value(feature.Fields.FindField("MaKVKT")).ToString().Replace(" ", "");
                                            SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                            conn.Open();
                                            string sql1 = "SELECT [TenKhuVuc] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                            SqlCommand command1 = new SqlCommand(sql1, conn);
                                            if (command1.ExecuteScalar() != DBNull.Value)
                                            {
                                                dr[9] = (string)command1.ExecuteScalar();
                                            }
                                            string sql2 = "SELECT [TangCaoXD] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                            SqlCommand command2 = new SqlCommand(sql2, conn);
                                            if (command2.ExecuteScalar() != DBNull.Value)
                                            {
                                                dr[10] = (string)command2.ExecuteScalar();
                                            }
                                            string sql3 = "SELECT [ChiGioiXD] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                            SqlCommand command3 = new SqlCommand(sql3, conn);
                                            if (command3.ExecuteScalar() != DBNull.Value)
                                            {
                                                dr[11] = (string)command3.ExecuteScalar();
                                            }
                                            string sql4 = "SELECT [ChieuCaoTang] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                            SqlCommand command4 = new SqlCommand(sql4, conn);
                                            if (command4.ExecuteScalar() != DBNull.Value)
                                            {
                                                dr[12] = (string)command4.ExecuteScalar();
                                            }
                                            string sql5 = "SELECT [CotNen] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                            SqlCommand command5 = new SqlCommand(sql5, conn);
                                            if (command5.ExecuteScalar() != DBNull.Value)
                                            {
                                                dr[13] = (string)command5.ExecuteScalar();
                                            }
                                            string sql6 = "SELECT [QDKhac] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                            SqlCommand command6 = new SqlCommand(sql6, conn);
                                            if (command6.ExecuteScalar() != DBNull.Value)
                                            {
                                                dr[14] = (string)command6.ExecuteScalar();
                                            }
                                        }

                                        //string sql = "SELECT [SoQD] FROM CPXD WHERE [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "' and [Phuong] =N'" + feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString() + "' and ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "')";
                                        string sql = "SELECT [SoQD] FROM CPXD WHERE [SoTo] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] = '" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "' and [IDPhuong] = '" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDPhuong").ToString() + "' and ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "')";
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
                                                dr[15] = SoGPXD;
                                                dr[16] = "Thửa đất đã được cấp phép xây dựng - GPXD số " + SoGPXD;
                                                SqlCommand commanMaHSCPXD = new SqlCommand("SELECT [MaHS] FROM [CPXD] WHERE [SoQD] = '" + SoGPXD + "'", connection);
                                                commanCPXD.Connection.Close();
                                                commanMaHSCPXD.Connection.Open();
                                                dr[17] = (string)commanMaHSCPXD.ExecuteScalar();
                                                commanMaHSCPXD.Connection.Close();
                                            }
                                            else { dr[16] = "Chưa có thông tin cấp phép xây dựng."; commanCPXD.Connection.Close(); }
                                        }
                                        else { dr[16] = "Chưa có thông tin cấp phép xây dựng."; commanCPXD.Connection.Close(); }

                                        tt.Rows.Add(dr);
                                        if (frm1Thua != null)
                                        {
                                            frm1Thua.Close();
                                            frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(tt);
                                            frm1Thua.Show();
                                        }
                                        else
                                        {
                                            frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(tt);
                                            frm1Thua.Show();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == layerget)
                        {
                            IFeatureLayer ilayer = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1) as IFeatureLayer;
                            KTMoLop = KTMoLop + 1;
                            int ID;
                            int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                            if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian thửa đất này", "Thông báo"); }
                            else
                            {
                                IFeature ife = ilayer.FeatureClass.GetFeature(ID);
                                if (ife != null)
                                {
                                    QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, dmap, ilayer);
                                    IActiveView ActiveView = dmap as IActiveView;
                                    IEnvelope pEnv = null;
                                    pEnv = ife.ShapeCopy.Envelope;
                                    ActiveView.Extent = pEnv;
                                    dmap.MapScale = 500;
                                    ActiveView.Refresh();

                                    tt = new DataTable();
                                    tt.Columns.Add("Mã", typeof(String));
                                    tt.Columns.Add("Số tờ bản đồ", typeof(String));
                                    tt.Columns.Add("Số thửa", typeof(String));
                                    tt.Columns.Add("Diện tích", typeof(String));
                                    tt.Columns.Add("Loại đất", typeof(String));
                                    tt.Columns.Add("Phường", typeof(String));
                                    tt.Columns.Add("Thông tin quy hoạch", typeof(String));
                                    tt.Columns.Add("Phường1", typeof(String));
                                    tt.Columns.Add("Loại đất1", typeof(String));
                                    tt.Columns.Add("TenKhuVuc", typeof(String));
                                    tt.Columns.Add("TangCaoXD", typeof(String));
                                    tt.Columns.Add("ChiGioiXD", typeof(String));
                                    tt.Columns.Add("ChieuCaoTang", typeof(String));
                                    tt.Columns.Add("CotNen", typeof(String));
                                    tt.Columns.Add("QDKhac", typeof(String));
                                    tt.Columns.Add("SoGPXD", typeof(String));
                                    tt.Columns.Add("TTCPXD", typeof(String));
                                    tt.Columns.Add("MaHSCPXD", typeof(String));
                                    IFeature feature = ife;
                                    dr = tt.NewRow();
                                    dr[0] = feature.get_Value(feature.Fields.FindField("OBJECTID")).ToString();
                                    if (feature.get_Value(feature.Fields.FindField("SoToBD")) != DBNull.Value)
                                    {
                                        dr[1] = feature.get_Value(feature.Fields.FindField("SoToBD")).ToString();
                                    }
                                    if (feature.get_Value(feature.Fields.FindField("SoThua")) != DBNull.Value)
                                    {
                                        dr[2] = feature.get_Value(feature.Fields.FindField("SoThua")).ToString();
                                    }
                                    if (feature.get_Value(feature.Fields.FindField("DienTich")) != DBNull.Value)
                                    {
                                        dr[3] = feature.get_Value(feature.Fields.FindField("DienTich")).ToString();
                                    }
                                    if (feature.get_Value(feature.Fields.FindField("LoaiDat")) != DBNull.Value)
                                    {
                                        dr[4] = feature.get_Value(feature.Fields.FindField("LoaiDat")).ToString();
                                    }
                                    if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenPhuong").ToString() != "")
                                    {
                                        dr[5] = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenPhuong").ToString();
                                    }
                                    if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaDuAnQH").ToString() != "")
                                    {
                                        string MaDuAnQH = feature.get_Value(feature.Fields.FindField("MaDuAnQH")).ToString().Replace(" ", "");
                                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                        conn.Open();
                                        string sql1 = "SELECT [TenDuAn] FROM [GISCAMLE].[dbo].RGDAQH where MaDuAn = '" + MaDuAnQH + "'";
                                        SqlCommand command1 = new SqlCommand(sql1, conn);
                                        if (command1.ExecuteScalar() != DBNull.Value)
                                        {
                                            dr[6] = (string)command1.ExecuteScalar();
                                        }
                                    }
                                    //if (feature.get_Value(feature.Fields.FindField("TenPhuong")) != DBNull.Value)
                                    //{
                                    //    dr[7] = feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString();
                                    //}
                                    //if (feature.get_Value(feature.Fields.FindField("LoaiDat")) != DBNull.Value)
                                    //{
                                    //    dr[8] = feature.get_Value(feature.Fields.FindField("LoaiDat")).ToString();
                                    //}
                                    if (feature.get_Value(feature.Fields.FindField("MaKVKT")) != DBNull.Value)
                                    {

                                        string MaKT = feature.get_Value(feature.Fields.FindField("MaKVKT")).ToString().Replace(" ", "");
                                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                        conn.Open();
                                        string sql1 = "SELECT [TenKhuVuc] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                        SqlCommand command1 = new SqlCommand(sql1, conn);
                                        if (command1.ExecuteScalar() != DBNull.Value)
                                        {
                                            dr[9] = (string)command1.ExecuteScalar();
                                        }
                                        string sql2 = "SELECT [TangCaoXD] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                        SqlCommand command2 = new SqlCommand(sql2, conn);
                                        if (command2.ExecuteScalar() != DBNull.Value)
                                        {
                                            dr[10] = (string)command2.ExecuteScalar();
                                        }
                                        string sql3 = "SELECT [ChiGioiXD] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                        SqlCommand command3 = new SqlCommand(sql3, conn);
                                        if (command3.ExecuteScalar() != DBNull.Value)
                                        {
                                            dr[11] = (string)command3.ExecuteScalar();
                                        }
                                        string sql4 = "SELECT [ChieuCaoTang] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                        SqlCommand command4 = new SqlCommand(sql4, conn);
                                        if (command4.ExecuteScalar() != DBNull.Value)
                                        {
                                            dr[12] = (string)command4.ExecuteScalar();
                                        }
                                        string sql5 = "SELECT [CotNen] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                        SqlCommand command5 = new SqlCommand(sql5, conn);
                                        if (command5.ExecuteScalar() != DBNull.Value)
                                        {
                                            dr[13] = (string)command5.ExecuteScalar();
                                        }
                                        string sql6 = "SELECT [QDKhac] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                        SqlCommand command6 = new SqlCommand(sql6, conn);
                                        if (command6.ExecuteScalar() != DBNull.Value)
                                        {
                                            dr[14] = (string)command6.ExecuteScalar();
                                        }
                                    }
                                    //string sql = "SELECT [SoQD] FROM CPXD WHERE [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "' and [Phuong] =N'" + feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString() + "' and ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "')";
                                    string sql = "SELECT [SoQD] FROM CPXD WHERE [SoTo] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] = '" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "' and [IDPhuong] = '" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDPhuong").ToString() + "' and ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "')";
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
                                            dr[15] = SoGPXD;
                                            dr[16] = "Thửa đất đã được cấp phép xây dựng - GPXD số " + SoGPXD;
                                            SqlCommand commanMaHSCPXD = new SqlCommand("SELECT [MaHS] FROM [CPXD] WHERE [SoQD] = '" + SoGPXD + "'", connection);
                                            commanCPXD.Connection.Close();
                                            commanMaHSCPXD.Connection.Open();
                                            dr[17] = (string)commanMaHSCPXD.ExecuteScalar();
                                            commanMaHSCPXD.Connection.Close();
                                        }
                                        else { dr[16] = "Chưa có thông tin cấp phép xây dựng."; commanCPXD.Connection.Close(); }
                                    }
                                    else { dr[16] = "Chưa có thông tin cấp phép xây dựng."; commanCPXD.Connection.Close(); }

                                    tt.Rows.Add(dr);
                                    if (frm1Thua != null)
                                    {
                                        frm1Thua.Close();
                                        frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(tt);
                                        frm1Thua.Show();
                                    }
                                    else
                                    {
                                        frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(tt);
                                        frm1Thua.Show();
                                    }
                                }
                            }
                        }
                    }
                }
                if (KTMoLop == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa mở lớp dữ liệu không gian địa chính" + PhuongKT + "\n" + "Có muốn mở lớp dữ liệu này hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Địa chính\\" + layerget + ".lyr");
                        QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        IFeatureLayer ilayer = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(0) as IFeatureLayer;
                        KTMoLop = KTMoLop + 1;
                        int ID;
                        int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                        if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian thửa đất này", "Thông báo"); }
                        else
                        {
                            IFeature ife = ilayer.FeatureClass.GetFeature(ID);
                            if (ife != null)
                            {
                                QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, dmap, ilayer);
                                IActiveView ActiveView = dmap as IActiveView;
                                IEnvelope pEnv = null;
                                pEnv = ife.ShapeCopy.Envelope;
                                ActiveView.Extent = pEnv;
                                dmap.MapScale = 500;
                                ActiveView.Refresh();

                                tt = new DataTable();
                                tt.Columns.Add("Mã", typeof(String));
                                tt.Columns.Add("Số tờ bản đồ", typeof(String));
                                tt.Columns.Add("Số thửa", typeof(String));
                                tt.Columns.Add("Diện tích", typeof(String));
                                tt.Columns.Add("Loại đất", typeof(String));
                                tt.Columns.Add("Phường", typeof(String));
                                tt.Columns.Add("Thông tin quy hoạch", typeof(String));
                                tt.Columns.Add("Phường1", typeof(String));
                                tt.Columns.Add("Loại đất1", typeof(String));
                                tt.Columns.Add("TenKhuVuc", typeof(String));
                                tt.Columns.Add("TangCaoXD", typeof(String));
                                tt.Columns.Add("ChiGioiXD", typeof(String));
                                tt.Columns.Add("ChieuCaoTang", typeof(String));
                                tt.Columns.Add("CotNen", typeof(String));
                                tt.Columns.Add("QDKhac", typeof(String));
                                tt.Columns.Add("SoGPXD", typeof(String));
                                tt.Columns.Add("TTCPXD", typeof(String));
                                tt.Columns.Add("MaHSCPXD", typeof(String));
                                IFeature feature = ife;
                                dr = tt.NewRow();
                                dr[0] = feature.get_Value(feature.Fields.FindField("OBJECTID")).ToString();
                                if (feature.get_Value(feature.Fields.FindField("SoToBD")) != DBNull.Value)
                                {
                                    dr[1] = feature.get_Value(feature.Fields.FindField("SoToBD")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("SoThua")) != DBNull.Value)
                                {
                                    dr[2] = feature.get_Value(feature.Fields.FindField("SoThua")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("DienTich")) != DBNull.Value)
                                {
                                    dr[3] = feature.get_Value(feature.Fields.FindField("DienTich")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("LoaiDat")) != DBNull.Value)
                                {
                                    dr[4] = feature.get_Value(feature.Fields.FindField("LoaiDat")).ToString();
                                }
                                if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenPhuong").ToString() != "")
                                {
                                    dr[5] = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenPhuong").ToString();
                                }
                                if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaDuAnQH").ToString() != "")
                                {
                                    string MaDuAnQH = feature.get_Value(feature.Fields.FindField("MaDuAnQH")).ToString().Replace(" ", "");
                                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                    conn.Open();
                                    string sql1 = "SELECT [TenDuAn] FROM [GISCAMLE].[dbo].RGDAQH where MaKV = '" + MaDuAnQH + "'";
                                    SqlCommand command1 = new SqlCommand(sql1, conn);
                                    if (command1.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[6] = (string)command1.ExecuteScalar();
                                    }
                                }
                                //if (feature.get_Value(feature.Fields.FindField("TenPhuong")) != DBNull.Value)
                                //{
                                //    dr[7] = feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString();
                                //}
                                //if (feature.get_Value(feature.Fields.FindField("LoaiDat")) != DBNull.Value)
                                //{
                                //    dr[8] = feature.get_Value(feature.Fields.FindField("LoaiDat")).ToString();
                                //}
                                if (feature.get_Value(feature.Fields.FindField("MaKVKT")) != DBNull.Value)
                                {

                                    string MaKT = feature.get_Value(feature.Fields.FindField("MaKVKT")).ToString().Replace(" ", "");
                                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                    conn.Open();
                                    string sql1 = "SELECT [TenKhuVuc] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                    SqlCommand command1 = new SqlCommand(sql1, conn);
                                    if (command1.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[9] = (string)command1.ExecuteScalar();
                                    }
                                    string sql2 = "SELECT [TangCaoXD] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                    SqlCommand command2 = new SqlCommand(sql2, conn);
                                    if (command2.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[10] = (string)command2.ExecuteScalar();
                                    }
                                    string sql3 = "SELECT [ChiGioiXD] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                    SqlCommand command3 = new SqlCommand(sql3, conn);
                                    if (command3.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[11] = (string)command3.ExecuteScalar();
                                    }
                                    string sql4 = "SELECT [ChieuCaoTang] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                    SqlCommand command4 = new SqlCommand(sql4, conn);
                                    if (command4.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[12] = (string)command4.ExecuteScalar();
                                    }
                                    string sql5 = "SELECT [CotNen] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                    SqlCommand command5 = new SqlCommand(sql5, conn);
                                    if (command5.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[13] = (string)command5.ExecuteScalar();
                                    }
                                    string sql6 = "SELECT [QDKhac] FROM [GISCAMLE].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                    SqlCommand command6 = new SqlCommand(sql6, conn);
                                    if (command6.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[14] = (string)command6.ExecuteScalar();
                                    }
                                }
                                //string sql = "SELECT [SoQD] FROM CPXD WHERE [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "' and [Phuong] =N'" + feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString() + "' and ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "')";
                                //SqlConnection connection = new SqlConnection(QLHTDT.Properties.Settings.Default.strConnection);
                                //SqlCommand commanCPXD = new SqlCommand(sql, connection);
                                //commanCPXD.Connection.Open();
                                //string SoGPXD = "";
                                //if (commanCPXD.ExecuteScalar() != DBNull.Value)
                                //{
                                //    SoGPXD = (string)commanCPXD.ExecuteScalar();
                                //    if (SoGPXD != "" & SoGPXD != null)
                                //    {
                                //        SoGPXD = (string)commanCPXD.ExecuteScalar();
                                //        dr[15] = SoGPXD;
                                //        dr[16] = "Thửa đất đã được cấp phép xây dựng - GPXD số " + SoGPXD;
                                //        SqlCommand commanMaHSCPXD = new SqlCommand("SELECT [MaHS] FROM [CPXD] WHERE [SoQD] = '" + SoGPXD + "'", connection);
                                //        commanCPXD.Connection.Close();
                                //        commanMaHSCPXD.Connection.Open();
                                //        dr[17] = (string)commanMaHSCPXD.ExecuteScalar();
                                //        commanMaHSCPXD.Connection.Close();
                                //    }
                                //    else { dr[16] = "Chưa có thông tin cấp phép xây dựng."; commanCPXD.Connection.Close(); }
                                //}
                                //else { dr[16] = "Chưa có thông tin cấp phép xây dựng."; commanCPXD.Connection.Close(); }

                                tt.Rows.Add(dr);
                                if (frm1Thua != null)
                                {
                                    frm1Thua.Close();
                                    frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(tt);
                                    frm1Thua.Show();
                                }
                                else
                                {
                                    frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(tt);
                                    frm1Thua.Show();
                                }
                            }
                        }
                    }
                    //MessageBox.Show("Chưa mở lớp dữ liệu không gian phường " + PhuongKT); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TCTTKT_Load(object sender, EventArgs e)
        {
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            bindingNavigator1.Visible = false;
            button1.Text = "Chỉnh sửa";
            bindingNavigator1.Visible = false;
            GridView1.OptionsBehavior.Editable = false;
            if (QLHTDT.Properties.Settings.Default.QuyenSuaDT == true) { button1.Visible = true; } else { button1.Visible = false; }

            tb = new DataTable();
            tbcheck = new DataTable();
            //string sql = "select * from DIACHINHCAMLE,TTKIENTRUC where MaKVKT = MaKV and LoaiDat <> 'DGT'";
            string sql = "[PRC_QUERYTABLE_TCTTKT]";
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
            GridView1.RefreshData();

            DataSet ds2 = new DataSet();
            SqlDataAdapter adp2 = new SqlDataAdapter("select TenDuong from DUONGCHINH", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp2.Fill(ds2);
            comboTenDuong.Items.Clear();
            comboTenDuong.Items.Add("");
            for (int intCount = 0; intCount < ds2.Tables[0].Rows.Count; intCount++)
            {
                var val = ds2.Tables[0].Rows[intCount]["TenDuong"].ToString();

                if (!comboTenDuong.Items.Contains(val))
                {
                    comboTenDuong.Items.Add(val);
                }
            }
        }

        private void comboBoxPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["TenPhuong"],
               new ColumnFilterInfo("[TenPhuong] like '%" + comboBoxPhuong.Text + "%'", ""));
        }

        private void BtTracuu_Click(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            if (txtSoToBD.Text == "" && txtSoThua.Text != "")
            {
                view.ActiveFilter.Add(view.Columns["SoThua"],
              new ColumnFilterInfo("[SoThua] = '" + txtSoThua.Text + "'", ""));

            }
            else if (txtSoToBD.Text != "" && txtSoThua.Text == "")
            {
                view.ActiveFilter.Add(view.Columns["SoToBD"],
              new ColumnFilterInfo("SoToBD = '" + txtSoToBD.Text + "'", ""));
            }
            else if (txtSoToBD.Text == "" && txtSoThua.Text == "")
            {
            }
            else
            {
                view.ActiveFilter.Add(view.Columns["SoToBD"],
                  new ColumnFilterInfo("SoToBD ='" + txtSoToBD.Text + "'", ""));

                view.ActiveFilter.Add(view.Columns["SoThua"],
                  new ColumnFilterInfo("[SoThua] = '" + txtSoThua.Text + "'", ""));
            }
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {

        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            SaveFileDialog openf = new SaveFileDialog();
            openf.Filter = "xls|*.xls";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                GridView1.ExportToXls(openf.FileName);
            }
        }

        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            comboBoxPhuong.ResetText();
            txtSoToBD.ResetText();
            txtSoThua.ResetText();
            txtHem.ResetText();
            txtKiet.ResetText();
            txtSoNha.ResetText();
            comboTenDuong.ResetText();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Chỉnh sửa")
            {
                GridView1.OptionsBehavior.Editable = true;
                bindingNavigator1.Visible = true;
                button1.Text = "Tắt";
            }
            else
            {
                button1.Text = "Chỉnh sửa";
                bindingNavigator1.Visible = false;
                GridView1.OptionsBehavior.Editable = false;
                GridView1.ClearColumnsFilter();
                GridView1.RefreshData();
            }
        }
        private void comboTenDuong_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["TenDuong"],
              new ColumnFilterInfo("[TenDuong] like '%" + comboTenDuong.Text + "%'", ""));
        }

        private void txtSoNha_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["SoNha"],
              new ColumnFilterInfo("[SoNha] like '%" + txtSoNha.Text + "%'", ""));
        }

        private void txtHem_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["Hem"],
              new ColumnFilterInfo("[Hem] like '%" + txtHem.Text + "%'", ""));
        }

        private void txtKiet_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["Kiet"],
              new ColumnFilterInfo("[Kiet] like '%" + txtKiet.Text + "%'", ""));
        }
    }
}
