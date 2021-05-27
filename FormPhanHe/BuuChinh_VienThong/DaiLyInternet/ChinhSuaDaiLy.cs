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
    public partial class ChinhSuaDaiLy : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        int IDThietBi = QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.QuanLyChuDaiLy.IDTram;
        public ChinhSuaDaiLy()
        {
            InitializeComponent();
        }

        private void ChinhSuaDaiLy_Load(object sender, EventArgs e)
        {
            DataSet ds3 = new DataSet();
            SqlDataAdapter adp3 = new SqlDataAdapter("select * from ChuDaiLyInternet where ID = " + IDThietBi + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp3.Fill(ds3);
            txtTenChuDL.Text = ds3.Tables[0].Rows[0]["TenChuDaiLy"].ToString();
            txtDiaChi.Text = ds3.Tables[0].Rows[0]["DiaChi"].ToString();
            txtEmail.Text = ds3.Tables[0].Rows[0]["Email"].ToString();
            txtSDT.Text = ds3.Tables[0].Rows[0]["DienThoai"].ToString();
            txtSoCMND.Text = ds3.Tables[0].Rows[0]["SoCMND"].ToString();
            txtNgayCapCMND.Text = ds3.Tables[0].Rows[0]["NgayCapCMND"].ToString();
            txtNoiCapCMND.Text = ds3.Tables[0].Rows[0]["NoiCapCMND"].ToString();
            txtCSMID.Text = ds3.Tables[0].Rows[0]["CSMID"].ToString();
            txtGhiChu.Text = ds3.Tables[0].Rows[0]["GhiChu"].ToString();
        }
        DateTime dateValue;

        private void button2_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("Bạn muốn chỉnh sửa chủ đại lý?", "Chỉnh sửa chủ đại lý", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                        SqlConnection conn = new SqlConnection(str);
                        conn.Open();
                        string Update = "[PRC_UPDATE_CHUDAILYINTERNET] "+IDThietBi+", N'" + txtTenChuDL.Text+  "',N'" +txtDiaChi.Text+ "',N'" + txtEmail.Text + "',N'" + txtSDT.Text + "',N'" + txtSoCMND.Text + "','"+ null +"',N'" + txtNoiCapCMND.Text + "',N'" + txtCSMID.Text + "',N'" + txtGhiChu.Text + "'";
                        SqlCommand cmd1 = new SqlCommand(Update, conn);
                        cmd1.ExecuteNonQuery();

                        QuanLyChuDaiLy frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.QuanLyChuDaiLy();
                        frm.Show();
                        this.Close();

                        MessageBox.Show("Chỉnh sửa chủ đại lý thành công thành công", "Thông báo");
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông dữ liệu cần chỉnh sửa", "Thông báo");
                    }
                }
        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            this.Close();
            QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.QuanLyChuDaiLy frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.QuanLyChuDaiLy();
            frm.Show();
        }

    }
}
