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
    public partial class TK_DAQH : Form
    {
        int AddQuan = 0;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        string ThongKe;
        string sqlQuan = "[PRC_Query_TenHuyen_By_MAHuyen] null";
        public static string MaHuyen = "null";
        public TK_DAQH()
        {
            InitializeComponent();
        }
        void showgridControl1(string MaHuyen)
        {
            string sql = "[PRC_STATISTICAL_DOANQH_CHART_PHUONG] " + MaHuyen + "";
            tb = new DataTable(); SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
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
            AddQuan = 1;
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
            ColumnView view = GridView1;

            if (cboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                cboQuan.Text = "";
            }
            if (AddQuan == 1)
            {
                view.ActiveFilter.Add(view.Columns["TenQuan"],
                new ColumnFilterInfo("[TenQuan] like '%" + cboQuan.Text + "%'", ""));
                showgridControl1(cboQuan.SelectedValue.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            cboQuan.ResetText();
            bindingSource1.ResetBindings(true);
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
         
        }

        private void TK_DAQH_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cboQuan.Items.Add("");
            cboQuan.DataSource = ds.Tables[0];
            cboQuan.DisplayMember = "TENHUYEN";
            cboQuan.ValueMember = "MAHUYEN";

            string sql = "[PRC_STATISTICAL_DOANQH_CHART] null ";
            tb = new DataTable(); SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
        }
        void showgridControl()
        {
            try
            {
                GridView1.ClearColumnsFilter();
                tb = new DataTable();
                tbcheck = new DataTable();
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand(ThongKe, connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);
                dataAdapter1.Fill(tb);
                this.bindingSource1.DataSource = tb;
                GridView1.RefreshData();
            }
            catch
            {
                MessageBox.Show("Chưa có thông tin quy hoạch", "Thông báo");
            }
        }

    }
}
