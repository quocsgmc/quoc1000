using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.CayXanh
{
    public partial class ChinhSuaChungLoai : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        int IDThietBi = QLHTDT.FormPhanHe.CayXanh.QuanLyChungLoaiCayXanh.IDThietBi;
        public ChinhSuaChungLoai()
        {
            InitializeComponent();
        }

        private void ChinhSuaChungLoai_Load(object sender, EventArgs e)
        {
            DataSet ds3 = new DataSet();
            SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_ChungLoaiCayXanh_BY_ID] " + IDThietBi+"", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp3.Fill(ds3);
            txtTenChungLoai.Text = ds3.Tables[0].Rows[0]["TenChungLoaiCay"].ToString();
            txtMoTa.Text = ds3.Tables[0].Rows[0]["MoTa"].ToString();
            txtPhanLoai.Text = ds3.Tables[0].Rows[0]["PhanLoai"].ToString();
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
                    string update = "[PRC_UPDATE_ChungLoaiCayXanh] " + IDThietBi + ",N'" + txtTenChungLoai.Text + "',N'" + txtMoTa.Text + "','" + txtPhanLoai.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(update, conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Chỉnh sửa dữ liệu thành công", "Thông báo");
                    QLHTDT.FormPhanHe.CayXanh.QuanLyChungLoaiCayXanh frm = new QLHTDT.FormPhanHe.CayXanh.QuanLyChungLoaiCayXanh();
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
            QLHTDT.FormPhanHe.CayXanh.QuanLyChungLoaiCayXanh frm = new QLHTDT.FormPhanHe.CayXanh.QuanLyChungLoaiCayXanh();
            frm.Show();
        }


    }
}
