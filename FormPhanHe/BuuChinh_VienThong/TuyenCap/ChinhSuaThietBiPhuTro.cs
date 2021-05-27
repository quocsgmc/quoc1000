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
    public partial class ChinhSuaThietBiPhuTro : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        int IDThietBi = QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyThietBiPhuTro.IDThietBi;
        public ChinhSuaThietBiPhuTro()
        {
            InitializeComponent();
        }

        private void ChinhSuaThietBiPhuTro_Load(object sender, EventArgs e)
        {
            DataSet ds3 = new DataSet();
            SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_THIETBIPHUTRO_BY_ID] " + IDThietBi+"", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp3.Fill(ds3);
            txtTenThietBi.Text = ds3.Tables[0].Rows[0]["TenThietBi"].ToString();
            txtGhiChu.Text = ds3.Tables[0].Rows[0]["GhiChu"].ToString();
            comboLoaiThietrBi.Text = ds3.Tables[0].Rows[0]["MoTa"].ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (LoaiThietBi != 0)
            {
                if (MessageBox.Show("Bạn muốn chỉnh sửa thiết bị?", "Thêm mới thiết bị", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                        SqlConnection conn = new SqlConnection(str);
                        conn.Open();
                        string update = "[PRC_UPDATE_THIETBIPHUTRO_BY_ID] " + IDThietBi+",N'" + txtTenThietBi.Text + "'," + LoaiThietBi + ",N'" + txtGhiChu.Text + "'";
                        SqlCommand cmd1 = new SqlCommand(update, conn);
                        cmd1.ExecuteNonQuery();

                        QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyThietBiPhuTro frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyThietBiPhuTro();
                        frm.Show();
                        this.Close();

                        MessageBox.Show("Chỉnh sửa thiết bị thành công thành công", "Thông báo");
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông dữ liệu cần Chỉnh sửa", "Thông báo");
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
