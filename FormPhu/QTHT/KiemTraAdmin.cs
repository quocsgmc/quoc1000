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
using QLHTDT.FormChinh;
using System.Security.Cryptography;

namespace QLHTDT.FormPhu.QTHT
{
    public partial class KiemTraAdmin : Form
    {
        SqlConnection conn;
        SqlCommand command;
        public KiemTraAdmin()
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
            Cursor = Cursors.WaitCursor;
            try
            {
                conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                conn.Open();

                string sql = "select COUNT (*) From [User] where TenDangNhap = @TaiKhoan and MatKHau = @MatKhau";
                command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@TaiKhoan", txtTaiKhoan.Text));
                GetMD5(txtMatKhau.Text);
                command.Parameters.Add(new SqlParameter("@MatKhau", MD5_MatKhau));
                int x = (int)command.ExecuteScalar();
                if (x == 1)
                {//Đăng nhập thành công

                    //QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) = QLHTDT.Properties.Settings.Default.strConnection;
                    QLHTDT.Properties.Settings.Default.Save();
                    KienTruc.VersionedArcSdeWorkspace(SettingKetNoiCSDL.server, "sde:sqlserver:" + SettingKetNoiCSDL.server, SettingKetNoiCSDL.user, SettingKetNoiCSDL.pass, QLHTDT.Properties.Settings.Default.DatabaseConnect, "DBO.DEFAULT");
                    this.Close();
                }
                else { MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                button1_Click(sender, e);
            }
        }
    }
}
