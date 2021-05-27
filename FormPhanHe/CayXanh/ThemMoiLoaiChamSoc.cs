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
    public partial class ThemMoiLoaiChamSoc : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public ThemMoiLoaiChamSoc()
        {
            InitializeComponent();
        }

        private void ThemMoiLoaiChamSoc_Load(object sender, EventArgs e)
        {
            //showgridControl1();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thêm mới một Loại chăm sóc?", "Thêm mới loại chăm sóc", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool check = true;
                bool isNumeric;
                double NhanCong;
                double MayThiCong;
                double DonGia;

                if (isNumeric = double.TryParse(txtNhanCong.Text, out NhanCong)) { }
                else { MessageBox.Show("Sai định dạng dữ liệu Nhân công!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo"); check = false; Cursor = Cursors.Default; return; }

                if (isNumeric = double.TryParse(txtMayThiCong.Text, out MayThiCong)) { }
                else { MessageBox.Show("Sai định dạng dữ liệu Máy thi công!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo"); check = false; Cursor = Cursors.Default; return; }

                if (isNumeric = double.TryParse(txtDonVi.Text, out DonGia)) { }
                else { MessageBox.Show("Sai định dạng dữ liệu Đơn giá!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo"); check = false; Cursor = Cursors.Default; return; }

                isNumeric = true;

                if (check != false)
                {
                    try
                    {
                        string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                        SqlConnection conn = new SqlConnection(str);
                        conn.Open();
                        string Insert = "[PRC_INSERT_LoaiChamSoc] N'" + txtTenLoaiCS.Text + "',N'" + txtVatLieu.Text + "','" + NhanCong + "','" + MayThiCong + "','" + DonGia + "',N'" + txtHanMuc.Text + "','" + txtPhanLoai.Text + "',N'" + txtMaHieu.Text + "',N'" + txtDonVi.Text + "'";
                        SqlCommand cmd1 = new SqlCommand(Insert, conn);
                        cmd1.ExecuteNonQuery();

                        QLHTDT.FormPhanHe.CayXanh.QuanLyLoaiChamSoc frm = new QLHTDT.FormPhanHe.CayXanh.QuanLyLoaiChamSoc();
                        frm.Show();
                        this.Close();

                        MessageBox.Show("Thêm mới loại chăm sóc thành công thành công", "Thông báo");
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
            QLHTDT.FormPhanHe.CayXanh.QuanLyLoaiChamSoc frm = new QLHTDT.FormPhanHe.CayXanh.QuanLyLoaiChamSoc();
            frm.Show();
        }

    }
}
