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
    public partial class ThemMoiCongVien : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public ThemMoiCongVien()
        {
            InitializeComponent();
        }

        private void ThemMoiCongVien_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thêm mới dữ liệu" + " không?", "Thêm dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string dateGCN = null;
                    bool check = true;
                    if (dateTimePicker1.Text == "01 Tháng Giêng 2000")
                    {
                        DialogResult dialogResult = MessageBox.Show("Chưa nhập ngày cấp giấy chứng nhận!\n" + "Có muốn tiếp tục hay không?", "Thông báo", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            dateGCN = null;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            check = false; Cursor = Cursors.Default; return;
                        }
                    }
                    else { dateGCN = dateTimePicker1.Value.ToString("MM/dd/yyyy"); }
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string INSERT = "[PRC_INSERT_CONGVIEN] N'" + txtTenCV.Text + "',N'" + txtBanQLDA.Text + "','" + dateGCN + "'";
                    SqlCommand cmd1 = new SqlCommand(INSERT, conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới dữ liệu thành công", "Thông báo");
                    this.Close();
                    QLHTDT.FormPhanHe.CayXanh.QuanLyCongVien frm = new QLHTDT.FormPhanHe.CayXanh.QuanLyCongVien();
                    frm.Show();
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu đầy đủ", "Thông báo");
                }
            }
        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            this.Close();
            QLHTDT.FormPhanHe.CayXanh.QuanLyCongVien frm = new QLHTDT.FormPhanHe.CayXanh.QuanLyCongVien();
            frm.Show();
        }

    }
}
