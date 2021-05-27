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
    public partial class ThemMoiNhaMang : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public ThemMoiNhaMang()
        {
            InitializeComponent();
        }

        private void ThemMoiNhaMang_Load(object sender, EventArgs e)
        {
            //showgridControl1();
        }
        private void button2_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("Bạn muốn thêm mới một nhà mạng?", "Thêm mới nhà mạng", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                        SqlConnection conn = new SqlConnection(str);
                        conn.Open();
                        string Insert = "[PRC_INSERT_NhaMang]N'" + txtTenNhaMang.Text + "',N'" + txtGhiChu.Text + "'";
                        SqlCommand cmd1 = new SqlCommand(Insert, conn);
                        cmd1.ExecuteNonQuery();

                        QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.QuanLyNhaMang frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.QuanLyNhaMang();
                        frm.Show();
                        this.Close();

                        MessageBox.Show("Thêm mới nhà mạng thành công thành công", "Thông báo");
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông dữ liệu cần thêm mới", "Thông báo");
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
