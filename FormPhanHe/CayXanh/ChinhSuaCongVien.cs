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
    public partial class ChinhSuaCongVien : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        int IDThietBi = QLHTDT.FormPhanHe.CayXanh.QuanLyCongVien.IDThietBi;
        public ChinhSuaCongVien()
        {
            InitializeComponent();
        }

        private void ChinhSuaCongVien_Load(object sender, EventArgs e)
        {
            DataSet ds3 = new DataSet();
            SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_CONGVIEN_BY_ID] " + IDThietBi+"", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp3.Fill(ds3);
            txtTenCV.Text = ds3.Tables[0].Rows[0]["TenCongVien"].ToString();
            txtBanQLDA.Text = ds3.Tables[0].Rows[0]["BanQLDA"].ToString();
            dateTimePicker1.Text = ds3.Tables[0].Rows[0]["TGDuyTuGanNhat"].ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn sửa dữ liệu được chọn " + " không?", "Chỉnh sửa dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    string update = "[PRC_UPDATE_CONGVIEN] " + IDThietBi + ",N'" + txtTenCV.Text + "',N'" + txtBanQLDA.Text + "','" + dateGCN + "'";
                    SqlCommand cmd1 = new SqlCommand(update, conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Chỉnh sửa dữ liệu thành công", "Thông báo");
                    this.Close();
                    QLHTDT.FormPhanHe.CayXanh.QuanLyCongVien frm = new QLHTDT.FormPhanHe.CayXanh.QuanLyCongVien();
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
            QLHTDT.FormPhanHe.CayXanh.QuanLyCongVien frm = new QLHTDT.FormPhanHe.CayXanh.QuanLyCongVien();
            frm.Show();
        }


    }
}
