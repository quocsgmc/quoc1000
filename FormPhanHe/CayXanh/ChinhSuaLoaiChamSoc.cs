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
    public partial class ChinhSuaLoaiChamSoc : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        int IDThietBi = QLHTDT.FormPhanHe.CayXanh.QuanLyLoaiChamSoc.IDThietBi;
        public ChinhSuaLoaiChamSoc()
        {
            InitializeComponent();
        }

        private void ChinhSuaLoaiChamSoc_Load(object sender, EventArgs e)
        {
            DataSet ds3 = new DataSet();
            SqlDataAdapter adp3 = new SqlDataAdapter("PRC_QUERY_LoaiChamSoc_BY_ID " + IDThietBi + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp3.Fill(ds3);
            txtTenLoaiCS.Text = ds3.Tables[0].Rows[0]["TenLoaiChamSoc"].ToString();
            txtVatLieu.Text = ds3.Tables[0].Rows[0]["VatLieu"].ToString();
            txtNhanCong.Text = ds3.Tables[0].Rows[0]["NhanCong"].ToString();
            txtMayThiCong.Text = ds3.Tables[0].Rows[0]["MayThiCong"].ToString();
            txtDonGia.Text = ds3.Tables[0].Rows[0]["DonGia"].ToString();
            txtHanMuc.Text = ds3.Tables[0].Rows[0]["HangMuc"].ToString();
            txtPhanLoai.Text = ds3.Tables[0].Rows[0]["PhanLoai"].ToString();
            txtMaHieu.Text = ds3.Tables[0].Rows[0]["MaHieu"].ToString();
            txtDonVi.Text = ds3.Tables[0].Rows[0]["DonVi"].ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn chỉnh sửa một Loại chăm sóc?", "Thêm mới loại chăm sóc", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

                if (isNumeric = double.TryParse(txtDonGia.Text, out DonGia)) { }
                else { MessageBox.Show("Sai định dạng dữ liệu Đơn giá!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo"); check = false; Cursor = Cursors.Default; return; }

                isNumeric = true;

                if (check != false)
                {
                    try
                    {
                        string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                        SqlConnection conn = new SqlConnection(str);
                        conn.Open();
                        string Insert = "[PRC_UPDATE_LoaiChamSoc] "+IDThietBi+", N'" + txtTenLoaiCS.Text + "',N'" + txtVatLieu.Text + "','" + NhanCong + "','" + MayThiCong + "','" + DonGia + "',N'" + txtHanMuc.Text + "','" + txtPhanLoai.Text + "',N'" + txtMaHieu.Text + "',N'" + txtDonVi.Text + "'";
                        SqlCommand cmd1 = new SqlCommand(Insert, conn);
                        cmd1.ExecuteNonQuery();

                        QLHTDT.FormPhanHe.CayXanh.QuanLyLoaiChamSoc frm = new QLHTDT.FormPhanHe.CayXanh.QuanLyLoaiChamSoc();
                        frm.Show();
                        this.Close();

                        MessageBox.Show("Chỉnh sửa loại chăm sóc thành công thành công", "Thông báo");
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
