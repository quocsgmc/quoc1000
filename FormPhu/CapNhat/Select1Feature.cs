using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class Select1Feature : Form
    {
        IFeatureClass fclass ;
       public static int obj = 0;
       public static bool check = false;
        public Select1Feature()
        {
            InitializeComponent();
        }
        public Select1Feature(IFeatureClass fc)
        {
            InitializeComponent();
            fclass = fc;
        }

        private void Select1Feature_Load(object sender, EventArgs e)
        {
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = "";
            for (int i = 0; i < fclass.FeatureCount(queryFilter); i++)
            {
                IFeature ifeshp = fclass.GetFeature(i);
                string obj = ifeshp.get_Value(ifeshp.Fields.FindField(fclass.OIDFieldName)).ToString();
                dataGridView1.Rows.Add(obj, false);
                
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool check = false;
            if (e.RowIndex != -1)
            {
                for (int i1 = 0; i1 < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i1++)
                {
                    if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1).Name == fclass.AliasName)
                    {
                        check = true;
                        int ID;
                        int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().ToString(), out ID);
                        IFeature ife = fclass.GetFeature(ID);
                        if (ife != null)
                        {
                            QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map, QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1));
                            IActiveView ActiveView = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map as IActiveView;
                            IEnvelope pEnv = null;
                            pEnv = ife.ShapeCopy.Envelope;
                            ActiveView.Extent = ife.Extent;
                            QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale * 3;
                            //QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = 500;
                            ActiveView.Refresh();
                        }
                    }
                }
                if (check == false)
                {

                    IFeatureLayer fl = new FeatureLayer();
                    ILayer l = null;
                    FeatureLayerClass pFeatureLayer = new FeatureLayerClass();
                    pFeatureLayer.FeatureClass = fclass;
                    fl.FeatureClass = pFeatureLayer.FeatureClass;
                    l = fl as ILayer;
                    l.Name = fclass.AliasName;
                    QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.AddLayer(l, 0);
                    for (int i1 = 0; i1 < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i1++)
                    {
                        if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1).Name == fclass.AliasName)
                        {
                            check = true;
                            int ID;
                            int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().ToString(), out ID);
                            IFeature ife = fclass.GetFeature(ID);
                            if (ife != null)
                            {
                                QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map, QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1));
                                IActiveView ActiveView = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map as IActiveView;
                                IEnvelope pEnv = null;
                                pEnv = ife.ShapeCopy.Envelope;
                                ActiveView.Extent = pEnv;
                                QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale * 3;
                                //QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = 500;
                                ActiveView.Refresh();
                            }
                        }
                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int SoCheck = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "True")
                {
                    SoCheck = SoCheck + 1;
                }
            }
            if (SoCheck == 1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[1].Value != null)
                    {
                        int.TryParse(dataGridView1.Rows[i].Cells[0].Value.ToString(), out obj);
                        check = true;
                        this.Hide();
                        //QLHTDT.FormPhu.CapNhat.CapNhatCad.listBox1.Items.Add(new QLHTDT.FormPhu.CapNhat.CapNhatCad.ObjectThuocTinh(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString()));
                    }
                }
            }
            else
            {
                MessageBox.Show("Chỉ chọn một đối tượng !", "Thông báo");
            }
            
        }
    }
}
