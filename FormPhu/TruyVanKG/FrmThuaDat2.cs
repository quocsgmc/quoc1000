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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace QLHTDT.FormPhu.FormChiTietLayer
{
    public partial class FrmThuaDat2 : Form
    {
        private ESRI.ArcGIS.Carto.IMap dmap;
        IFeatureLayer FeatureLayer;
        TTTD frm2;
        public FrmThuaDat2(DataTable dt,IFeatureLayer featureLayer)
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map;
            bindingSource1.DataSource = dt;
            gridControl1.DataSource = dt;
            FeatureLayer = featureLayer;
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            System.Drawing.Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            DoRowDoubleClick(view, pt);
        }
        public static DataTable tt;
        public static DataRow dr;
        public static System.Windows.Forms.Form frm;
        
        private void DoRowDoubleClick(GridView view, System.Drawing.Point pt)
        {
            frm.Close();
            try
            {
                            int ID;
                            int.TryParse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã").ToString(), out ID);
                            IFeature ife = FeatureLayer.FeatureClass.GetFeature(ID);
                            if (ife != null)
                            {
                                QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, dmap, FeatureLayer);
                                IActiveView ActiveView = dmap as IActiveView;
                                //Zoom.ZoomtoPoint();

                                //QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeatureife, dmap, FeatureLayer);
                                //IActiveView ActiveView = dmap as IActiveView;
                                IEnvelope pEnv = null;
                                pEnv = ife.ShapeCopy.Envelope;
                                ActiveView.Extent = pEnv;
                                dmap.MapScale = 500;
                                ActiveView.Refresh();

                                tt = new DataTable();
                                tt.Columns.Add("Mã", typeof(String));
                                tt.Columns.Add("Chủ sử dụng", typeof(String));
                                tt.Columns.Add("Số tờ bản đồ", typeof(String));
                                tt.Columns.Add("Số thửa", typeof(String));
                                tt.Columns.Add("Diện tích", typeof(String));
                                tt.Columns.Add("Địa chỉ", typeof(String));
                                tt.Columns.Add("Tình trạng pháp lý", typeof(String));
                                tt.Columns.Add("Thông tin quy hoạch", typeof(String));
                                tt.Columns.Add("Phường", typeof(String));
                                tt.Columns.Add("Loại đất", typeof(String));


                                dr = tt.NewRow();
                                dr[0] = ife.get_Value(ife.Fields.FindField("OBJECTID")).ToString();
                                if (ife.get_Value(ife.Fields.FindField("ChuSD")) != DBNull.Value)
                                {
                                    dr[1] = ife.get_Value(ife.Fields.FindField("ChuSD")).ToString();
                                }
                                if (ife.get_Value(ife.Fields.FindField("SoToBD")) != DBNull.Value)
                                {
                                    dr[2] = ife.get_Value(ife.Fields.FindField("SoToBD")).ToString();
                                }
                                if (ife.get_Value(ife.Fields.FindField("SoThua")) != DBNull.Value)
                                {
                                    dr[3] = ife.get_Value(ife.Fields.FindField("SoThua")).ToString();
                                }
                                if (ife.get_Value(ife.Fields.FindField("DienTich")) != DBNull.Value)
                                {
                                    dr[4] = ife.get_Value(ife.Fields.FindField("DienTich")).ToString();
                                }
                                if (ife.get_Value(ife.Fields.FindField("DiaChi")) != DBNull.Value)
                                {
                                    dr[5] = ife.get_Value(ife.Fields.FindField("DiaChi")).ToString();
                                }
                                if (ife.get_Value(ife.Fields.FindField("TTPL")) != DBNull.Value)
                                {
                                    dr[6] = ife.get_Value(ife.Fields.FindField("TTPL")).ToString();
                                }
                                if (ife.get_Value(ife.Fields.FindField("KhuQH")) != DBNull.Value)
                                {
                                    dr[7] = ife.get_Value(ife.Fields.FindField("KhuQH")).ToString();
                                }
                                if (ife.get_Value(ife.Fields.FindField("TenPhuong")) != DBNull.Value)
                                {
                                    dr[8] = ife.get_Value(ife.Fields.FindField("TenPhuong")).ToString();
                                }
                                if (ife.get_Value(ife.Fields.FindField("LoaiDat")) != DBNull.Value)
                                {
                                    dr[9] = ife.get_Value(ife.Fields.FindField("LoaiDat")).ToString();
                                }
                                tt.Rows.Add(dr);
                                //frm2 = new TTTD(tt);
                                //frm = frm2;
                                //frm.Show();
                                if (frm2 != null)
                                {
                                    frm2.Close();
                                    frm2 = new TTTD(tt);
                                    frm2.Show();
                                }
                                else
                                {
                                    frm2 = new TTTD(tt);
                                    frm2.Show();
                                }
                                //if (frm.ShowDialog() == DialogResult.OK)
                                //{
                                //    frm.Refresh();
                                //    frm.Close();
                                //    frm.Show();
                                //}
                                //else
                                //{
                                //    frm.Show();
                                //    frm.Refresh();
                                //}
                          

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void FrmThuaDat2_Load(object sender, EventArgs e)
        {
            frm = new System.Windows.Forms.Form();
        }

        private void btXuatEx_Click(object sender, EventArgs e)
        {
            SaveFileDialog openf = new SaveFileDialog();
            openf.Filter = "xls|*.xls";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(openf.FileName);
            }
        }
        

    }
}
