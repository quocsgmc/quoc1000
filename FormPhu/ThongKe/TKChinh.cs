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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraVerticalGrid;
using System.Data.SqlClient;

namespace QLHTDT.FormPhu.ThongKe
{
    public partial class TKChinh : Form
    {
        DataTable tb;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        private IFeatureLayer fLayer;
        
        public TKChinh()
        {
            InitializeComponent();
            ILayer player = QLHTDT.FormChinh.KienTruc.layer;
            fLayer = player as IFeatureLayer;
            fLayer = QLHTDT.FormChinh.KienTruc.featureLayer;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.ThongKe.TK_DAQHChung frm = new QLHTDT.FormPhu.ThongKe.TK_DAQHChung();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.ThongKe.TK_DAQHPK frm = new QLHTDT.FormPhu.ThongKe.TK_DAQHPK();
            frm.Show();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.ThongKe.TK_DAQH_TienDo frm = new QLHTDT.FormPhu.ThongKe.TK_DAQH_TienDo();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.ThongKe.TK_DAQH frm = new QLHTDT.FormPhu.ThongKe.TK_DAQH();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.ThongKe.TK_DAQHPK_ChiTiet frm = new QLHTDT.FormPhu.ThongKe.TK_DAQHPK_ChiTiet();
            frm.Show();
        }
    }
}
