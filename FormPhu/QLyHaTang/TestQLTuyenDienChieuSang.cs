using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using QLHTDT.FormChinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLHTDT.FormPhu.TruyVanKG;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using WindowsApplication1;

namespace QLHTDT.FormPhu.QLyHaTang
{
    public partial class TestQLTuyenDienChieuSang : Form
    {
        bool ChinhSua = false;
        SqlCommandBuilder cmbl;
        SqlDataAdapter dataAdapter1;
        DataTable tb;
        DataTable tbcheck;
        private AxMapControl mMapControl;
        private ESRI.ArcGIS.Carto.IMap dmap;
        string layerget;
        public TestQLTuyenDienChieuSang()
        {
            InitializeComponent();
            dmap = QuanTriHeThong.axMapControl1.Map;
        }
        void ShowComBoBox()//Lấy dữ liệu Quận Huyện, Hiện tại lấy tạm của BTS
        {
            string sql = "SELECT [PhuongXa],[QuanHuyen] FROM  TRAMBTS";

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                var val2 = ds.Tables[0].Rows[intCount]["QuanHuyen"].ToString();
                var val3 = "";
                if (!cboPhuong.Items.Contains(val))
                {
                    cboPhuong.Items.Add(val);
                }
                if (!cboQuan.Items.Contains(val2))
                {
                    cboQuan.Items.Add(val2);
                }
                if (!cboQuan.Items.Contains(val3))
                {
                    cboQuan.Items.Add(val3);
                }
            }
        }

        private void TestQLTuyenDienChieuSang_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ShowComBoBox();
            showgridControl1();
            Cursor = Cursors.Default;
        }
        void showgridControl1()
        {
            tb = new DataTable();
            tbcheck = new DataTable();
            string sql = "SELECT [OBJECTID_1],[Ma],[Phuong] FROM TUYENDIEN_HA";
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
            //bingding();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            int KTMoLop = 0;
            string PhuongKT = null;
            try
            {
                string Phuong = "";
                Phuong = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Phuong").ToString();

                switch (Phuong)
                {
                    case "Hòa An": layerget = "Tuyến điện chiếu sáng - HA"; break;
                    case "Hòa Phát": layerget = "Tuyến điện chiếu sáng - HP"; break;
                    case "Hòa Thọ Đông": layerget = "Tuyến điện chiếu sáng - HTD"; break;
                    case "Hòa Thọ Tây": layerget = "Tuyến điện chiếu sáng - HTT"; break;
                    case "Hòa Xuân": layerget = "Tuyến điện chiếu sáng - HX"; break;
                    case "Khuê Trung": layerget = "Tuyến điện chiếu sáng - KT"; break;
                }
                PhuongKT = Phuong;
                for (int i1 = 0; i1 < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i1++)
                {
                    if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1).Name == Phuong)
                    {
                        ICompositeLayer igroup1 = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.Layer[i1] as ICompositeLayer;
                        for (int i = 0; i < igroup1.Count; i++)
                        {
                            if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                IFeatureLayer ilayer = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i) as IFeatureLayer;
                                int ID;
                                int.TryParse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OBJECTID_1").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Ranh giới quy hoạch này", "Thông báo"); }
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
                                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale * 2;
                                        ActiveView.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                IFeatureLayer ilayer = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i) as IFeatureLayer;
                                int ID;
                                int.TryParse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OBJECTID_1").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Ranh giới quy hoạch này", "Thông báo"); }
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
                                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale * 2;
                                        ActiveView.Refresh();
                                    }
                                }
                            }
                        }
                    }
                }
                if (KTMoLop == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa mở lớp dữ liệu không gian Trụ điện chiếu sáng " + PhuongKT + "\n" + "Có muốn mở lớp dữ liệu này hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + layerget + ".lyr");
                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();
                        for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                IFeatureLayer ilayer = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i) as IFeatureLayer;
                                int ID;
                                int.TryParse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OBJECTID_1").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Ranh giới quy hoạch này", "Thông báo"); }
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
                                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale * 2;
                                        ActiveView.Refresh();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
