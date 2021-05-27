using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS
{
    public partial class ChinhSuaChuDauTu : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        int IDThietBi = QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.QuanLyChuDauTu.IDTram;
        public ChinhSuaChuDauTu()
        {
            InitializeComponent();
        }

        private void ChinhSuaChuDauTu_Load(object sender, EventArgs e)
        {
            DataSet ds3 = new DataSet();
            SqlDataAdapter adp3 = new SqlDataAdapter("select * from CHUDAUTUBTS where IDCHUDAUTU = " + IDThietBi+"", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp3.Fill(ds3);
            txtTenChuDauTu.Text = ds3.Tables[0].Rows[0]["TENCHUDATU"].ToString();
            txtGhiChu.Text = ds3.Tables[0].Rows[0]["GHICHU"].ToString();
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
                    //Delete nếu dữ liệu đã tồn tại để cập nhật lại
                    string Delelequery = "[PRC_UPDATE_CHUDAUTUBTS] " + IDThietBi + ",N'" + txtTenChuDauTu.Text + "',N'" + txtGhiChu.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(Delelequery, conn);
                    cmd1.ExecuteNonQuery();
                    this.Close();
                    MessageBox.Show("Chỉnh sửa dữ liệu thành công", "Thông báo");
                    QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.QuanLyChuDauTu frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.QuanLyChuDauTu();
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
            QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.QuanLyChuDauTu frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.QuanLyChuDauTu();
            frm.Show();
        }
    }
}
