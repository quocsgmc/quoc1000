using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap
{
    public partial class ChinhSuaDoanhNghiep : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        int IDThietBi = QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyDoanhNghiep.IDTram;
        public ChinhSuaDoanhNghiep()
        {
            InitializeComponent();
        }

        private void ChinhSuaDoanhNghiep_Load(object sender, EventArgs e)
        {
            DataSet ds3 = new DataSet();
            SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_DOANHNGHIEP_BY_ID] " + IDThietBi+"", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp3.Fill(ds3);
             txtTenDoanhNghiep.Text = ds3.Tables[0].Rows[0]["TenDoanhNghiep"].ToString();
            txtTenVietTat.Text = ds3.Tables[0].Rows[0]["TenVietTat"].ToString();
            txtMoTa.Text = ds3.Tables[0].Rows[0]["MoTa"].ToString();
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
                    string update = "[PRC_UPDATE_DOANHNGHIEP_BY_ID] " + IDThietBi + ",N'" + txtTenDoanhNghiep.Text + "',N'" + txtTenVietTat.Text + "',N'" + txtMoTa.Text + "',N'" + txtGhiChu.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(update, conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Chỉnh sửa dữ liệu thành công", "Thông báo");
                    QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyDoanhNghiep frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyDoanhNghiep();
                    frm.Show();
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu cần chỉnh sửa", "Thông báo");
                }
            }
        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            this.Close();
            QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyDoanhNghiep frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyDoanhNghiep();
            frm.Show();
        }


    }
}
