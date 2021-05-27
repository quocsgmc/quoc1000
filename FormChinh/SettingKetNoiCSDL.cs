using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLHTDT.FormPhu.QTHT;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace QLHTDT.FormChinh
{
    public partial class SettingKetNoiCSDL : Form
    {
        public static string strConnection;
        public static string server;
        public static string user;
        public static string pass;
        //SqlConnection conn;
        //SqlCommand command;
        public SettingKetNoiCSDL()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.QTHT.KiemTraAdmin frm = new QLHTDT.FormPhu.QTHT.KiemTraAdmin();
            frm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string GetMD5(string chuoi)
        {
            // Getting the bytes of Input String.
            byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(chuoi);

            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes("sgmc"));
            //De-allocatinng the memory after doing the Job.
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;
            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;


            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objTripleDESCryptoService.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Rot13(string input)
        {
            StringBuilder result = new StringBuilder();
            Regex regex = new Regex("[A-Za-z]");
            foreach (char c in input)
            {
                if (regex.IsMatch(c.ToString()))
                {
                    int charCode = ((c & 223) - 52) % 26 + (c & 32) + 65;
                    result.Append((char)charCode);
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
        private void Btsave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.Properties.Settings.Default.strConnectionDAQH = GetMD5("Server=" + textBox1.Text + ";Database=" + textBox2.Text + ";User Id=" + textBox3.Text + ";Password=" + textBox4.Text + "; Encrypt = true; TrustServerCertificate = true;");
            string a = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            //QLHTDT.Properties.Settings.Default.strConnectionDAQH = Rot13("Server=" + textBox1.Text + ";Database=" + textBox2.Text + ";User Id=" + textBox3.Text + ";Password=" + textBox4.Text + "; Encrypt = true; TrustServerCertificate = true;");
            QLHTDT.FormChinh.KienTruc.KetNoiDB = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            //QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) = GetMD5("Server=" + textBox1.Text + ";Database=" + textBox2.Text + ";User Id=" + textBox3.Text + ";Password=" + textBox4.Text + "; Encrypt = true; TrustServerCertificate = true;");
            //QLHTDT.Properties.Settings.Default.strConnection = "Server=" + textBox1.Text + ";Database=" + textBox2.Text + ";User Id=" + textBox3.Text + ";Password=" + textBox4.Text + "; Encrypt = true; TrustServerCertificate = true;";
            //QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) = "Server=" + textBox1.Text + ";Database= " + textBox2.Text + "" + ";User Id=" + textBox3.Text + ";Password=" + textBox4.Text + "; Encrypt = true; TrustServerCertificate = true;";


            SqlConnection conn = new SqlConnection("Server=" + textBox1.Text + ";Database=" + textBox2.Text + ";User Id=" + textBox3.Text + ";Password=" + textBox4.Text + "; Encrypt = true; TrustServerCertificate = true;");
            try {
                conn.Open();
                MessageBox.Show("Kết nối thành công");
                server = textBox1.Text;
                user = textBox3.Text;
                pass = textBox4.Text;
                button1.Enabled = true;

                QLHTDT.Properties.Settings.Default.DatabaseConnect = textBox2.Text;
            }
            catch (Exception)
            { MessageBox.Show("Kết nối không thành công, xin kiểm tra lại!"); }
            conn.Close();
            Cursor = Cursors.Default;
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btsave_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLHTDT.FormChinh.CORE.Connectdatabase.ConnectFolder();
        }
    }
}
