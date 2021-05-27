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
    public partial class ThemMoiCongTrinhHaTang : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        string sql = "[PRC_QUERY_TABLE_LOAICTVT] null";
        public ThemMoiCongTrinhHaTang()
        {
            InitializeComponent();
        }

        private void ThemMoiCongTrinhHaTang_Load(object sender, EventArgs e)
        {
            //showgridControl1();
        }
        void showgridControl1()
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboLoaiThietrBi.DataSource = ds.Tables[0];
            comboLoaiThietrBi.DisplayMember = "MoTa";
            comboLoaiThietrBi.ValueMember = "LoaiThietBi";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (LoaiThietBi != 0)
            {
                if (MessageBox.Show("Bạn muốn thêm mới một thiết bị?", "Thêm mới thiết bị", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                        SqlConnection conn = new SqlConnection(str);
                        conn.Open();
                        string Insert = "[PRC_INSERT_LOAICTHTVT] N'" + txtTenThietBi.Text + "','" + LoaiThietBi + "',N'" + txtGhiChu.Text + "'";
                        SqlCommand cmd1 = new SqlCommand(Insert, conn);
                        cmd1.ExecuteNonQuery();

                        QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyCongTrinhHaTang frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyCongTrinhHaTang();
                        frm.Show();
                        this.Close();

                        MessageBox.Show("Thêm mới thiết bị thành công thành công", "Thông báo");
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông dữ liệu cần thêm mới", "Thông báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Loại thiết bị.","Thông báo");
            }
        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            this.Close();
            QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyThietBiPhuTro frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyThietBiPhuTro();
            frm.Show();
        }
        int LoaiThietBi = 0;
        private void comboLoaiThietrBi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboLoaiThietrBi.SelectedValue.ToString() == "System.Data.DataRowView")
            //{
            //    comboLoaiThietrBi.Text = "";
            //}
            switch(comboLoaiThietrBi.Text)
            {
                case "":
                    LoaiThietBi = 0;
                    break;
                case "Bể cáp": LoaiThietBi = 1;
                    break;
                case "Cột cáp treo": LoaiThietBi = 2;
                    break;
                case "Tuyến cáp treo": LoaiThietBi = 3;
                    break;
                case "Tuyến cáp ngầm": LoaiThietBi = 4;
                    break;
                    return;
            }
        }
    }
}
