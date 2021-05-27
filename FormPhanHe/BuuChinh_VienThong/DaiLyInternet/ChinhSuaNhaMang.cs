using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet
{
    public partial class ChinhSuaNhaMang : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        int IDThietBi = QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.QuanLyNhaMang.IDTram;
        public ChinhSuaNhaMang()
        {
            InitializeComponent();
        }

        private void ChinhSuaNhaMang_Load(object sender, EventArgs e)
        {
            DataSet ds3 = new DataSet();
            SqlDataAdapter adp3 = new SqlDataAdapter("select * from NhaMang where ID = " + IDThietBi+"", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp3.Fill(ds3);
            txtTenNhaMang.Text = ds3.Tables[0].Rows[0]["TenNhaMang"].ToString();
            txtGhiChu.Text = ds3.Tables[0].Rows[0]["GhiChu"].ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn sửa dữ liệu được chọn " + " không?", "Chỉnh sửa dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string Update = "[PRC_UPDATE_NhaMang] " + IDThietBi + ",N'" + txtTenNhaMang.Text + "',N'" + txtGhiChu.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(Update, conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Chỉnh sửa dữ liệu thành công", "Thông báo");
                    this.Close();
                    QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.QuanLyNhaMang frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.QuanLyNhaMang();
                    frm.Show();

                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn dữ liệu cần xóa", "Thông báo");
                }
            }
        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            this.Close();
            QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.QuanLyNhaMang frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.QuanLyNhaMang();
            frm.Show();
        }
    }
}
