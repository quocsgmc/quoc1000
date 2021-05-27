using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.Dat5PhanTram
{
    public partial class ThemMoiBenThueDat : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public ThemMoiBenThueDat()
        {
            InitializeComponent();
        }
        int ID = QLHTDT.FormPhanHe.Dat5PhanTram.QuanlyDat5PhanTram.QuanlyDat5PhanTram.ID1;
        private void ThemMoiBenThueDat_Load(object sender, EventArgs e)
        {
            //showgridControl1();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thêm mới Bên thuê đất?", "Thêm mới loại chăm sóc", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool check = true;
                bool isNumeric;
                double NamSinh;
                double CMND;
                double SDT;

                if (isNumeric = double.TryParse(textBox2.Text, out NamSinh)) { }
                else { MessageBox.Show("Sai định dạng dữ liệu Năm sinh!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo"); check = false; Cursor = Cursors.Default; return; }

                if (isNumeric = double.TryParse(textBox3.Text, out CMND)) { }
                else { MessageBox.Show("Sai định dạng dữ liệu CMND!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo"); check = false; Cursor = Cursors.Default; return; }

                if (isNumeric = double.TryParse(textBox4.Text, out SDT)) { }
                else { MessageBox.Show("Sai định dạng dữ liệu SĐT!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo"); check = false; Cursor = Cursors.Default; return; }

                isNumeric = true;

                if (check != false)
                {
                    try
                    {
                        string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                        SqlConnection conn = new SqlConnection(str);
                        conn.Open();
                        string Insert = "[PRC_INSERT_BenThueDat] N'" + textBox1.Text + "',N'" + NamSinh + "','" + CMND + "','" + SDT + "','" + textBox5.Text + "',N'" + ID + "'";
                        SqlCommand cmd1 = new SqlCommand(Insert, conn);
                        cmd1.ExecuteNonQuery();

                        QLHTDT.FormPhanHe.Dat5PhanTram.QuanlyBenThueDat.QuanlyBenThueDat frm = new QLHTDT.FormPhanHe.Dat5PhanTram.QuanlyBenThueDat.QuanlyBenThueDat();
                        frm.Show();
                        this.Close();

                        MessageBox.Show("Thêm mới Bên thuê đất thành công", "Thông báo");
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông dữ liệu cần thêm mới", "Thông báo");
                    }
                }

            }
        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            this.Close();
            QLHTDT.FormPhanHe.Dat5PhanTram.QuanlyBenThueDat.QuanlyBenThueDat frm = new QLHTDT.FormPhanHe.Dat5PhanTram.QuanlyBenThueDat.QuanlyBenThueDat();
            frm.Show();
        }
    }
}
