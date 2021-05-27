using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.ThongKe
{
    public partial class TK_DAQHPK_ChiTiet : Form
    {
        int AddQuan = 0;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        string ThongKe;
        string sqlQuan = "[PRC_Query_TenHuyen_By_MAHuyen] null";
        public static string MaHuyen = "null";
        public TK_DAQHPK_ChiTiet()
        {
            InitializeComponent();
        }


        private void btXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog openf = new SaveFileDialog();
            openf.Filter = "xls|*.xls";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                GridView1.ExportToXls(openf.FileName);
            }
        }

        private void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
            ColumnView view = GridView1;
                view.ActiveFilter.Add(view.Columns["LoaiDat"],
                new ColumnFilterInfo("[LoaiDat] like '%" + cboQuan.Text + "%'", ""));
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TK_DAQHPK_ChiTiet_Load(object sender, EventArgs e)
        {
            DataSet ds2 = new DataSet();
            SqlDataAdapter adp2 = new SqlDataAdapter("Select TenloaiPolygon from LoaiPolygonQH_PhanKhu", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp2.Fill(ds2);
            cboQuan.Items.Add("");
            for (int intCount = 0; intCount < ds2.Tables[0].Rows.Count; intCount++)
            {
                var val = ds2.Tables[0].Rows[intCount]["TenloaiPolygon"].ToString();

                if (!cboQuan.Items.Contains(val))
                {
                    cboQuan.Items.Add(val);
                }
            }
            cboQuan.Text = "";


            string sql = "[PRC_TK_DAQH_PhanKhu_ChiTiet]";
            tb = new DataTable(); SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
        }
    }
}
