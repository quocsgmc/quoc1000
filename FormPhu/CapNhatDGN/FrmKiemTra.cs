using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using QLHTDT.FormChinh;

namespace QLHTDT.CapNhatDGN
{
    public partial class FrmKiemTra : Form
    {
        public static DataTable dataADD;
        public static DataTable dataDEL;
        public FrmKiemTra()
        {
            InitializeComponent();
        }
        public FrmKiemTra(DataTable dt1, DataTable dt2)
        {
            InitializeComponent();
            bindingSourceSHP.DataSource = dt1;
            bindingSourceSDE.DataSource = dt2;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.Columns[0].ReadOnly = true;
            dataGridView3.Columns[1].ReadOnly = true;
            dataGridView3.Columns[2].ReadOnly = true;
            dataGridView3.Columns[3].ReadOnly = true;
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.Columns[0].ReadOnly = true;
            dataGridView4.Columns[1].ReadOnly = true;
            dataGridView4.Columns[2].ReadOnly = true;
            dataGridView4.Columns[3].ReadOnly = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //FrmCapNhat.btCapNhat.Enabled = true;
            //this.Hide();
            dataADD = new DataTable();
            dataDEL = new DataTable();
            //dataADD = dataGridView1.DataSource as DataTable;
            //dataDEL = dataGridView2.DataSource as DataTable;
            ToDataTable(dataGridView3, dataADD);
            ToDataTable(dataGridView4, dataDEL);
            FrmCapNhat.btCapNhat.Enabled = true;
            this.Hide();
        }

        private void FrmKiemTra_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < dataGridView1.RowCount; ++i)
            //{ 
            //    DataGridViewRow row = dataGridView1.Rows[i];
            //    string a = row.Cells[i].Value.ToString();
            //}

            //int n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "1";
            //dataGridView1.Rows[n].Cells[1].Value = "1";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowSHP = dataGridView3.Rows[e.RowIndex];
            //string a = rowSHP.Cells[0].Value.ToString();
            int ID;
            int.TryParse(rowSHP.Cells[0].Value.ToString(), out ID);
            IFeatureLayer featureLayer = (IFeatureLayer)FrmCapNhat.layershp;

            IFeature ife = featureLayer.FeatureClass.GetFeature(ID);
            if (ife != null)
            {
                //IFeatureLayer featureLayer = new FeatureLayerClass();
                //featureLayer.FeatureClass = FrmCapNhat.featureClassSHP;
                //ILayer layer = (ILayer)featureLayer;
                QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, QLHTDT.FormChinh.KienTruc.axMapControl1.Map, FrmCapNhat.layershp);
                IActiveView ActiveView = QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView;
                IEnvelope pEnv = null;
                pEnv = ife.ShapeCopy.Envelope;
                pEnv.Expand(1.2, 1.2, true);
                ActiveView.Extent = pEnv;
                ActiveView.Refresh();
            }

        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowSDE = dataGridView4.Rows[e.RowIndex];
            int ID;
            int.TryParse(rowSDE.Cells[0].Value.ToString(), out ID);
            IFeatureLayer featureLayer = (IFeatureLayer)FrmCapNhat.layersde;
            IFeature ife = featureLayer.FeatureClass.GetFeature(ID);
            if (ife != null)
            {
                //IFeatureLayer featureLayer = new FeatureLayerClass();
                //featureLayer.FeatureClass = FrmCapNhat.featureClassSDE;
                //ILayer layer = (ILayer)featureLayer;
                QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, QLHTDT.FormChinh.KienTruc.axMapControl1.Map, FrmCapNhat.layersde);
                IActiveView ActiveView = QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView;
                IEnvelope pEnv = null;
                pEnv = ife.ShapeCopy.Envelope;
                pEnv.Expand(1.2, 1.2, true);
                ActiveView.Extent = pEnv;
                ActiveView.Refresh();
            }
        }

        private void btselectall_Click(object sender, EventArgs e)
        {
            if (btselectall.Text == "Chọn tất cả")
            {
                for (int i = 0; i <= dataGridView3.RowCount - 1; i++)
                {
                    dataGridView3.Rows[i].Cells[4].Value = true;
                }
                for (int i = 0; i <= dataGridView4.RowCount - 1; i++)
                {
                    dataGridView4.Rows[i].Cells[4].Value = true;
                }
                btselectall.Text = "Bỏ chọn";
            }
            else if (btselectall.Text == "Bỏ chọn")
            {
                for (int i = 0; i <= dataGridView3.RowCount - 1; i++)
                {
                    dataGridView3.Rows[i].Cells[4].Value = false;
                }
                for (int i = 0; i <= dataGridView4.RowCount - 1; i++)
                {
                    dataGridView4.Rows[i].Cells[4].Value = false;
                }
                btselectall.Text = "Chọn tất cả";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        public static void tableUpdate(DataTable add, DataTable del)
        {
            add = dataADD;
            del = dataDEL;
        }
        private DataTable ToDataTable(DataGridView dataGridView, DataTable dt)
        {
            //dt = new DataTable();
            foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns)
            {
                if (dataGridViewColumn.Visible)
                {
                    dt.Columns.Add(dataGridViewColumn.Name);
                }
            }
            var cell = new object[dataGridView.Columns.Count];
            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
            {
                for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
                {
                    cell[i] = dataGridViewRow.Cells[i].Value;
                }
                dt.Rows.Add(cell);
            }
            return dt;
        }




    }
}
