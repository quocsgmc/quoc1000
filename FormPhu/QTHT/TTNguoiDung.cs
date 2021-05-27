using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace QLHTDT.FormPhu.QTHT
{
    public partial class TTNguoiDung : Form
    {
        SqlConnection conn;
        SqlCommand command;
        DataTable tb;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public TTNguoiDung()
        {
            InitializeComponent();
        }
        string MD5_MatKhau = "";
        public string GetMD5(string chuoi)
        {
            MD5_MatKhau = "";
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
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thay đổi mật khẩu", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();

                    string sql = "SELECT HoVaTen FROM [User] where [MatKhau] = @MatKhau and [TenDangNhap] = @TaiKhoan";
                    command = new SqlCommand(sql, conn);
                    GetMD5(textBox1.Text);
                    command.Parameters.Add(new SqlParameter("@MatKhau", MD5_MatKhau));
                    command.Parameters.Add(new SqlParameter("@TaiKhoan", QLHTDT.Properties.Settings.Default.TenTK));
                    string x = (string)command.ExecuteScalar();
                    command.Dispose();
                    conn.Close();
                    if (x == QLHTDT.Properties.Settings.Default.HoVaTen)
                    {
                        if (textBox3.Text == textBox2.Text)
                        {
                            conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            conn.Open();

                            string sql2 = "UPDATE [User] SET [MatKhau] = @MatKhauMoi WHERE [TenDangNhap] = @TaiKhoan";
                            command = new SqlCommand(sql2, conn);
                            command.Parameters.Add(new SqlParameter("@TaiKhoan", QLHTDT.Properties.Settings.Default.TenTK));
                            GetMD5(textBox2.Text);
                            command.Parameters.Add(new SqlParameter("@MatKhauMoi", MD5_MatKhau));
                            command.ExecuteScalar();
                            MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                            textBox1.ResetText();
                            textBox2.ResetText();
                            textBox3.ResetText();
                        }
                        else { MessageBox.Show("Xác nhận mật khẩu không đúng, mời nhập lại", "Thông báo"); }
                    }
                    else { MessageBox.Show("Nhập sai mật khẩu", "Thông báo"); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        public static DataTable dt;
        public static DataRow dr;
        private void TTNguoiDung_Load(object sender, EventArgs e)
        {

            tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand("SELECT * FROM [User] where [TenDangNhap] = '" + QLHTDT.Properties.Settings.Default.TenTK + "'", connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            dt = new DataTable();
            dt.Columns.Add("TenDangNhap", typeof(String));
            dt.Columns.Add("HoVaTen", typeof(String));
            dt.Columns.Add("MaPhongBan", typeof(String));
            dr = dt.NewRow();
            dr[0] = tb.Rows[0]["TenDangNhap"].ToString();
            dr[1] = tb.Rows[0]["HoVaTen"].ToString();
            dr[2] = tb.Rows[0]["MaPhongBan"].ToString();
           
            dt.Rows.Add(dr);
            this.bindingSource1.DataSource = dt;
        }
    }
}
