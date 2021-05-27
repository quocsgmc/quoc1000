using QLHTDT.FormChinh;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.QTHT
{
    public partial class InsertUSER : Form
    {
        string SqlPhongban = "PRC_QUERY_PHONGBAN null";
        public InsertUSER()
        {
            InitializeComponent();
            showgridControl1();
        }
        public class typeUser
        {
            private int idloai;
            private string tenloai;
            public int IDLoai
            {
                get { return idloai; }
                set { idloai = value; }
            }
            public string TENLOAI
            {
                get { return tenloai; }
                set { tenloai = value; }
            }
            public typeUser(int IDLoai, string TENLOAI)
            {
                this.IDLoai = IDLoai;
                this.TENLOAI = TENLOAI;
            }
            public override string ToString()
            {
                return "ID: " + idloai + " | Age: " + tenloai;
            }
        }
        void showgridControl1()
        {
            SqlDataAdapter adp = new SqlDataAdapter(SqlPhongban, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cbbPhongBan.DataSource = ds.Tables[0];
            cbbPhongBan.DisplayMember = "MoTa";
            cbbPhongBan.ValueMember = "MaPhongBan";
            ArrayList LoaiNguoiDung = new ArrayList();
            LoaiNguoiDung.Add(new typeUser(0, "Quản trị hệ thống"));
            LoaiNguoiDung.Add(new typeUser(1, "Chuyên viên"));
            LoaiNguoiDung.Add(new typeUser(2, "Lãnh đạo"));
            LoaiNguoiDung.Add(new typeUser(3, "Khác"));
            CbbTaiKhoan.DataSource = LoaiNguoiDung;
            CbbTaiKhoan.DisplayMember = "tenloai";
            CbbTaiKhoan.ValueMember = "idloai";
        }
        public string GetMD5(string chuoi)
        {
            string MD5_MatKhau = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);
            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                MD5_MatKhau += b.ToString("X2");
            }

            return MD5_MatKhau;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //check input
            string permistion = "";
            SqlConnection conn1 = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            conn1.Open();
            string sql = "select COUNT (*) From [User] where TenDangNhap = '"+ tbTenDangNhap.Text + "'";
            SqlCommand command = new SqlCommand(sql, conn1);
            int x = (int)command.ExecuteScalar();
            if (x == 0)
            {
                if (cbbPhongBan.SelectedItem == null)
                {
                    MessageBox.Show("Chưa chọn Phòng ban!", "Thông báo");
                }
                else
                {
                    if (CbbTaiKhoan.SelectedItem == null)
                    {
                        MessageBox.Show("Chưa chọn loại tài khoản!", "Thông báo");
                    }
                    else
                    {
                        switch(CbbTaiKhoan.Text)
                        {
                            case "Quản trị hệ thống": permistion = "QuanTri";break;
                            case "Chuyên viên": permistion = "ChuyenVien"; break;
                            case "Lãnh đạo": permistion = "LanhDao"; break;
                            case "Khác": permistion = "Khac"; break;
                        }

                        if (GetMD5(tbPassnew.Text) != GetMD5(textBox4.Text))
                        {
                            MessageBox.Show("Xác nhận mật khẩu mới không đúng!", "Thông báo");
                        }
                        else if (tbPassnew.Text == textBox4.Text && tbPassnew.Text == "")

                        {
                            MessageBox.Show("Chưa nhập mật khẩu !", "Thông báo");
                        }
                        else if (GetMD5(tbPassnew.Text) == GetMD5(textBox4.Text) && tbPassnew.Text != "")
                        {
                            SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            conn.Open();
                            string sql1 = "[PRC_INSERT_USER] N'"
                                    + tbTenDangNhap.Text
                                    + "', " + cbbPhongBan.SelectedValue
                                    + ", " + CbbTaiKhoan.SelectedValue
                                    + ", N'" + permistion
                                    + "', N'" + TbHoTen.Text
                                    + "', '" + GetMD5(textBox4.Text) + "'";
                            SqlCommand command4 = new SqlCommand(sql1, conn);
                            command4.ExecuteScalar();
                            //Phần này là lưu nhật ký
                            KienTruc.TBNK = new DataTable();
                            SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                            SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                            KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                            KienTruc.ThemMoiDoiTuong("Người dùng", 0);
                            KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                            MessageBox.Show("Thêm mới người dùng thành công", "Thông báo");
                            this.Hide();
                        }

                    }
                }
            }
            else { MessageBox.Show("Tài khoản đã tồn tại, vui lòng nhập tên tài khoản khác.", "Thông báo"); }
               
        }
    }
}
