using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHTDT.test.FrmDangNhap
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        public String CreateSalt(int size) // tạo salt ngẫu nhiên
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public String GenerateSHA256Hash(String input) // tạo hash từ mật khẩu và salt
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            System.Security.Cryptography.HMACMD5 sha256hashstring =
                new System.Security.Cryptography.HMACMD5();
            byte[] hash = sha256hashstring.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Đăng ký tài khoản
            if (txtPass.Text == txtPassR.Text)//Nhập lại mật khẩu giống nhau
            {
                //if (txtPass.TextLength >= 6) // Mật khẩu phải dài hơn 6 kí tự
                //{
                    try // Không trùng lặp tài khoản
                    {
                        //String salt = CreateSalt(10);
                        String hash = GenerateSHA256Hash(txtPass.Text);

                        string TenDangNhap = txtUser.Text;
                        string MatKhau = txtPass.Text;
                        string str = "Server=DESKTOP-GPII52C\\CAMLE;Database=DangNhap;User Id=sa;Password=quoc782442;";
                        SqlConnection conn = new SqlConnection(str);
                        conn.Open();

                        string Insertquery = "insert into login([user],pass,hash) values(@user,@pass,@hash)";
                        SqlCommand cmd = new SqlCommand(Insertquery, conn);
                        cmd.Parameters.AddWithValue("@user", TenDangNhap);
                        cmd.Parameters.AddWithValue("@pass", MatKhau); //Chỗ này không cần lưu pass vào database

                        //cmd.Parameters.AddWithValue("@salt", salt);
                        cmd.Parameters.AddWithValue("@hash", hash);

                        cmd.ExecuteNonQuery();

                        conn.Close();
                        label1.Text = "Đăng ký thành công!";
                        label1.ForeColor = System.Drawing.Color.Green;
                    }
                    catch (Exception)
                    {
                        label1.Text = "Tên đăng nhập đã tồn tại!";
                        label1.ForeColor = System.Drawing.Color.Red;
                    }
                //}
                //else
                //{
                //        label1.Text = "Sử dụng 6 ký tự trở lên cho mật khẩu của bạn!";
                //        label1.ForeColor = System.Drawing.Color.Red;
                //}
            }
            else
            {
                label1.Text = "Mật khẩu không khớp, xin nhập lại!";
                label1.ForeColor = System.Drawing.Color.Red;
            }

        }

        public static bool VerifyPassword(string enteredPassword, string storedHash) //string storedSalt)// kiểm tra hash từ đăng nhập với DB
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(enteredPassword); //+ storedSalt);
            System.Security.Cryptography.HMACMD5 sha256hashstring =
               new System.Security.Cryptography.HMACMD5();
            byte[] hash = sha256hashstring.ComputeHash(bytes);
            return Convert.ToBase64String(hash) == storedHash;// nếu đúng true, sai false
        }


        private void button3_Click(object sender, EventArgs e)// Đăng nhập tài khoản
        {
            string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            SqlConnection conn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select MatKhau from [User] where [TenDangNhap]=@TenDangNhap", conn);
            cmd.Parameters.AddWithValue("@TenDangNhap", textBox3.Text);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Open();
            dataGridView1.DataSource = dt;
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            //string salt1 = dataGridView1.Rows[0].Cells[0].Value.ToString(); //Lấy salt từ DB
            string hash = dataGridView1.Rows[0].Cells[0].Value.ToString(); // Lấy hash từ DB
            bool isPasswordMatched = VerifyPassword(textBox1.Text, hash);// salt1); // lấy hash và salt để so sánh
            if (isPasswordMatched)
            {//Khúc này viết lại thành đăng nhập vào hệ thống
                label2.Text = "Đăng nhập thành công!";
                label2.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label2.Text = "Sai tên tài khoản hoặc mật khẩu!";
                label2.ForeColor = System.Drawing.Color.Red;
            }
        }


    }
}
