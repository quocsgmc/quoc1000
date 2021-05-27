using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
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

namespace QLHTDT.FormPhanHe.CayXanh.QLThamCo.NhatKyCSThamCo
{
    public partial class NhatKyCSThamCo : Form
    {
        private ESRI.ArcGIS.Carto.IMap dmap;
        bool ChinhSua = false;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public static int IDCayXanh;
        string sql = "[PRC_QUERYTABLE_NhatKyCSThamCo]";

        public NhatKyCSThamCo()
        {
            InitializeComponent();
        }


        private void NhatKyCSThamCo_Load(object sender, EventArgs e)
        {
            showgridControl1();
            bool ChinhSua = false;
        }
        void showgridControl1()
        {
            tb = new DataTable();SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
           
        }
        private void BtExcell_Click(object sender, EventArgs e)
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
