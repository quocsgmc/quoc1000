using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Base;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Collections;
using QLHTDT.FormChinh;
using System.Security.Cryptography;

namespace QLHTDT.FormPhu.QTHT
{
    public partial class EditUser : Form
    {
        DataTable tb;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        int IDUser;
        string sqlQuan = "PRC_QUERY_PHONGBAN null";
        public EditUser()
        {
            InitializeComponent();
        }
        public EditUser(int ID)
        {
            InitializeComponent();
            IDUser = ID;
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
            SqlDataAdapter adp = new SqlDataAdapter(sqlQuan, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cbbPhongBan.DataSource = ds.Tables[0];
            cbbPhongBan.DisplayMember = "MoTa";
            cbbPhongBan.ValueMember = "MaPhongBan";
            ArrayList LoaiNguoiDung = new ArrayList();
            LoaiNguoiDung.Add(new typeUser(0, "Quản trị hệ thống"));
            LoaiNguoiDung.Add(new typeUser(1, "Chuyên viên"));
            LoaiNguoiDung.Add(new typeUser(2, "Lãnh đạo"));
            LoaiNguoiDung.Add(new typeUser(3, "khác"));
            CbbTaiKhoan.DataSource = LoaiNguoiDung;
            CbbTaiKhoan.DisplayMember = "tenloai";
            CbbTaiKhoan.ValueMember = "idloai";

            tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand("PRC_QUERY_USER "+ IDUser, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            tbTenDangNhap.Text= tb.Rows[0][1].ToString();
            cbbPhongBan.SelectedValue = tb.Rows[0][5];
            CbbTaiKhoan.SelectedValue = tb.Rows[0][6];
            TbHoTen.Text = tb.Rows[0][3].ToString();
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
            string permistion = "";
            //check input
            if (cbbPhongBan.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn Phòng ban!", "Thông báo");
            }
            else
            {
                switch (CbbTaiKhoan.Text)
                {
                    case "Quản trị hệ thống": permistion = "QuanTri"; break;
                    case "Chuyên viên": permistion = "ChuyenVien"; break;
                    case "Lãnh đạo": permistion = "LanhDao"; break;
                    case "Khác": permistion = "Khac"; break;
                }
                if (CbbTaiKhoan.SelectedItem == null)
                {
                    MessageBox.Show("Chưa chọn loại tài khoản!", "Thông báo");
                }
                else
                {
                    //trường hợp đổi pass
                    if (GetMD5(tbPassnew.Text) != GetMD5(textBox4.Text) )
                    {
                        MessageBox.Show("Xác nhận mật khẩu mới không đúng!", "Thông báo");
                    }
                    else if (GetMD5(tbPassnew.Text) == GetMD5(textBox4.Text) && tbPassnew.Text != "")
                    {
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_USER_Desktop] "
                           + " N'" + tbTenDangNhap.Text
                                + "', N'" + TbHoTen.Text
                                + "', " + cbbPhongBan.SelectedValue
                                + ", " + IDUser
                                + ", N'" + permistion
                                + "', " + CbbTaiKhoan.SelectedValue
                                + ", '" + GetMD5(tbPassnew.Text) + "'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ChinhSuathuoctinhToolQuanLy("Người dùng", IDUser);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                        MessageBox.Show("Chỉnh sửa thông tin người dùng thành công", "Thông báo");
                        this.Hide();
                    }
                    //Trường hợp không đổi pass
                    else if (GetMD5(tbPassnew.Text) == GetMD5(textBox4.Text) && tbPassnew.Text == "")
                    {
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_USER_NONPASS] "
                           + " " + IDUser
                                + ", N'" + TbHoTen.Text
                                + "', " + cbbPhongBan.SelectedValue
                                + ", " + CbbTaiKhoan.SelectedValue
                                + ", '" + permistion + "'"; ;
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ChinhSuathuoctinhToolQuanLy("Người dùng", IDUser);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                        MessageBox.Show("Chỉnh sửa thông tin người dùng thành công", "Thông báo");
                        this.Hide();
                    }
                }
            }
        }

        private void EditUser_Load(object sender, EventArgs e)
        {

        }
    }
}
