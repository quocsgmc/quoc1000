using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using DevExpress.XtraBars;
using ESRI.ArcGIS.Controls;
using QLHTDT.FormChinh;
using QLHTDT.FormPhu.TruyVanKG;
using ESRI.ArcGIS.SystemUI;

namespace QLHTDT.FormPhu.QLyHaTang
{
    public partial class TestCapNhatCayXanh : Form
    {
        string TenLop;
        IFeature pFeature;
        private AxMapControl mMapControl;
        private ESRI.ArcGIS.Carto.IMap dmap;
        private IFeatureLayer fLayer;
        public static DataTable dt;
        public static DataRow dr;
        public static string CayXanh = "Cây xanh - HA";
        public TestCapNhatCayXanh()
        {
            InitializeComponent();
            dmap = QuanTriHeThong.axMapControl1.Map;
        }


        public void Show(IFeatureCursor pCu, IFeatureLayer alayer)
        {

            fLayer = alayer;
            dt = new DataTable();
            dt.Columns.Add("OBJECTID", typeof(Double));
            dt.Columns.Add("LoaiCay", typeof(String));
            dt.Columns.Add("MaCay", typeof(String));
            dt.Columns.Add("GhiChu", typeof(String));

            pFeature = pCu.NextFeature();

            int i = 0;
            bindingSource1.DataSource = dt;
            while (pFeature != null)
            {
                dr = dt.NewRow();
                dr[0] = pFeature.get_Value(pFeature.Fields.FindField(alayer.FeatureClass.OIDFieldName)).ToString();
                if (pFeature.get_Value(pFeature.Fields.FindField("LoaiCay")) != DBNull.Value)
                {
                    dr[1] = pFeature.get_Value(pFeature.Fields.FindField("LoaiCay")).ToString();
                }
                if (pFeature.get_Value(pFeature.Fields.FindField("MaCay")) != DBNull.Value)
                {
                    dr[2] = pFeature.get_Value(pFeature.Fields.FindField("MaCay")).ToString();
                }
                if (pFeature.get_Value(pFeature.Fields.FindField("GhiChu")) != DBNull.Value)
                {
                    dr[3] = pFeature.get_Value(pFeature.Fields.FindField("GhiChu")).ToString();
                }

                dt.Rows.Add(dr);
                gridControl2.DataSource = dt;
                i++;
                pFeature = pCu.NextFeature();
            }
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IActiveView pActiveView;
                pActiveView = QuanTriHeThong.axMapControl1.ActiveView;
                Global.pActiveView = pActiveView;
                ILayer pLayer = Global.getLayerbyName(Global.pActiveView.FocusMap, "Cây xanh - HA");
                if (pLayer == null)
                {
                    QuanTriHeThong.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + "Hòa An" + "\\" + "Cây xanh - HA" + ".lyr");
                    QuanTriHeThong.axMapControl1.Extent = QuanTriHeThong.axMapControl1.get_Layer(0).AreaOfInterest;
                }
                this.Visible = false;
               
            }
            catch
            {
                MessageBox.Show("Chưa chọn lớp dữ liệu, vui lòng thử lại", "Thông báo");
            }
        }

        private void TestCapNhatCayXanh_Load(object sender, EventArgs e)
        {
            dmap = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map;
        }
    }
}
