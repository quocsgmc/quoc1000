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
    public partial class TK_MuongThoatNuoc : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        string ThongKe;
        string Phuong = "";
        public TK_MuongThoatNuoc()
        {
            InitializeComponent();
        }
        void showgridControl1(string MaHuyen, string MaXa)
        {
            string sql = "[PRC_STATISTICAL_DRAINAGE_DITCH] " + MaHuyen + ", " + MaXa + "";
            tb = new DataTable(); SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AddPhuong = 1;
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
            cboPhuong.ResetText();
            ColumnView view = GridView1;

            if (cboPhuong.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddPhuong = 0;
                cboPhuong.Text = "";
            }
            if (AddPhuong == 1)
            {
                view.ActiveFilter.Add(view.Columns["TenPhuong"],
                new ColumnFilterInfo("[TenPhuong] like '%" + cboPhuong.Text + "%'", ""));
                showgridControl1(cboQuan.SelectedValue.ToString(), cboPhuong.SelectedValue.ToString());
            }
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
            int AddQuan = 1;
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
            cboPhuong.ResetText();
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
                string MaHuyen1 = cboQuan.SelectedValue.ToString();
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen1 + " ";
                DataSet ds2 = new DataSet();
                SqlDataAdapter adp2 = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                adp2.Fill(ds2);
                cboPhuong.DataSource = ds2.Tables[0];
                cboPhuong.DisplayMember = "TenPhuong";
                cboPhuong.ValueMember = "MaPhuong";
                showgridControl1(cboQuan.SelectedValue.ToString(), "null");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (System.IO.File.Exists(System.IO.Path.GetTempPath() + "\\TrangIn.jpg"))
            //{
            //    System.IO.File.Delete(System.IO.Path.GetTempPath() + "\\TrangIn.jpg");
            //}
            //CreateJPEGHiResolutionFromActiveView(FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView, System.IO.Path.GetTempPath() + "\\TrangIn.jpg");
            //QLHTDT.FormPhu.InAn.ToolIn frm = new QLHTDT.FormPhu.InAn.ToolIn();
            //frm.Show();
        }

        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            cboQuan.ResetText();
            cboPhuong.ResetText();
        }

        private void TK_MuongThoatNuoc_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cboQuan.Items.Add("");
            cboQuan.DataSource = ds.Tables[0];
            cboQuan.DisplayMember = "TENHUYEN";
            cboQuan.ValueMember = "MAHUYEN";
        }
        void showgridControl()
        {
            tb = new DataTable();
            tbcheck = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(ThongKe, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.ThongKe.TK_KietHemCoMTN frm = new QLHTDT.FormPhu.ThongKe.TK_KietHemCoMTN();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.ThongKe.TK_KietHemKhongCoMTN frm = new QLHTDT.FormPhu.ThongKe.TK_KietHemKhongCoMTN();
            frm.Show();
        }
    }
}
