using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace QLHTDT.FormPhu.QLKienTruc
{
    public partial class FrmTTKVQH : Form
    {
        SqlCommandBuilder cmbl;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        private ESRI.ArcGIS.Carto.IMap dmap;
        string layerget;
        string Phuong;
        public FrmTTKVQH()
        {
            InitializeComponent();
        }
        public FrmTTKVQH(string KVKienTruc,string phuong)
        {
            InitializeComponent();
            tb = new DataTable();
            tbcheck = new DataTable();
            string sql = "select * from KienTruc_HX where MaKV = '" + KVKienTruc +"'";
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            //string sql = "Select * From DoAnQuyHoach";
            //SqlConnection connection = new SqlConnection(QLHTDT.Properties.Settings.Default.strConnection);
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
            GridView1.OptionsBehavior.Editable = false;
            Phuong = phuong;
            dmap = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map;
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            int KTMoLop = 0;
            string PhuongKT = null;
            try
            {
                //string Phuong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Phuong").ToString();
                if (Phuong == "Hòa An")
                { layerget = "Ranh giới vùng Kiến trúc - HA"; }
                if (Phuong == "Hòa Phát")
                { layerget = "Ranh giới vùng Kiến trúc - HP"; }
                if (Phuong == "Hòa Thọ Đông")
                { layerget = "Ranh giới vùng Kiến trúc - HTD"; }
                if (Phuong == "Hòa Thọ Tây")
                { layerget = "Ranh giới vùng Kiến trúc - HTT"; }
                if (Phuong == "Hòa Xuân")
                { layerget = "Ranh giới vùng Kiến trúc - HX"; }
                if (Phuong == "Khuê Trung")
                { layerget = "Ranh giới vùng Kiến trúc - KT"; }
                PhuongKT = Phuong;
                for (int i1 = 0; i1 < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i1++)
                {
                    if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1).Name == Phuong)
                    {


                        ICompositeLayer igroup1 = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.Layer[i1] as ICompositeLayer;
                        for (int i = 0; i < igroup1.Count; i++)
                        {
                            IFeatureLayer ilayer1 = igroup1.get_Layer(i) as IFeatureLayer;
                            if (ilayer1.Name == layerget)
                            {

                                KTMoLop = KTMoLop + 1;
                                int ID;
                                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Kiến trúc này", "Thông báo"); }
                                else
                                {
                                    IFeature ife = ilayer1.FeatureClass.GetFeature(ID);
                                    if (ife != null)
                                    {
                                        QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, dmap, ilayer1);
                                        IActiveView ActiveView = dmap as IActiveView;
                                        IEnvelope pEnv = null;
                                        pEnv = ife.ShapeCopy.Envelope;
                                        ActiveView.Extent = pEnv;
                                        dmap.MapScale = 5000;
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
                                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Kiến trúc này", "Thông báo"); }
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
                                        //dmap.MapScale = 5000;
                                        ActiveView.Refresh();
                                    }
                                }
                            }
                        }
                    }
                }
                if (KTMoLop == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa mở lớp dữ liệu không gian Kiến trúc " + PhuongKT + "\n" + "Có muốn mở lớp dữ liệu này hay không ?", "Thông báo", MessageBoxButtons.YesNo);
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
                                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Kiến trúc này", "Thông báo"); }
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
                                        dmap.MapScale = 5000;
                                        ActiveView.Refresh();

                                    }
                                }


                            }
                        }
                    }
                    //MessageBox.Show("Chưa mở lớp dữ liệu không gian phường " + PhuongKT); 
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
