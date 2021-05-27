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
using Microsoft.Win32;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessing;
using System.Security.Cryptography;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using QLHTDT.FormPhanHe;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QLHTDT
{
    public partial class SGMC : Form
    {
        //string strConnection = @"Data Source=SINHNGUYEN\SQLEXPRESSHDT;Initial Catalog=HTDTCamLe;Integrated Security=True" ;
        SqlConnection conn;
        SqlCommand command;
        SqlCommand command2;
        SqlCommand command3;
        SqlCommand command4;
        SqlCommand command5;
        int NgayBatDau;
        int ThoiGianDaHoatDong;
        PictureBox pic1;
        private static DateTime GetDate()
        {
            var date = DateTime.Now;
            return date;
        }
        public SGMC()
        {
            this.InitializeComponent();
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.MaxLength = 15;
            AoInitialize init = new AoInitializeClass();
            init.Initialize(esriLicenseProductCode.esriLicenseProductCodeEngineGeoDB);
            init.Initialize(esriLicenseProductCode.esriLicenseProductCodeEngine);
        }
        private void SGMC_Load(object sender, EventArgs e)
        {
            QLHTDT.Properties.Settings.Default.TenTK = null;
            QLHTDT.Properties.Settings.Default.MaPhongBan = 0;
            QLHTDT.Properties.Settings.Default.PhongBan = null;
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
        public void BtDangNhap_Click(object sender, EventArgs e)
        {
            if (CboPhanHe.Text == "Quản trị hệ thống")
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sql = "select COUNT (*) From [User] where TenDangNhap = @TaiKhoan and MatKhau = @MatKhau";
                    command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@TaiKhoan", txtTaiKhoan.Text));
                    GetMD5(txtMatKhau.Text);
                    command.Parameters.Add(new SqlParameter("@MatKhau", MD5_MatKhau));
                    int x = (int)command.ExecuteScalar();
                    if (x == 1)
                    {//Đăng nhập thành công
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri(FormPhanHe.URLWeb.URL);
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", QLHTDT.Properties.Settings.Default.Token);

                        QLHTDT.Properties.Settings.Default.TenTK = txtTaiKhoan.Text;
                        string sql2 = "select HoVaTen  From [User] where TenDangNhap = '" + txtTaiKhoan.Text + "'";
                        command2 = new SqlCommand(sql2, conn);
                        QLHTDT.Properties.Settings.Default.HoVaTen = (string)command2.ExecuteScalar();
                        command2.Dispose();
                        string sql3 = "select MaPhongBan From [User] where TenDangNhap = '" + txtTaiKhoan.Text + "'";
                        command3 = new SqlCommand(sql3, conn);
                        QLHTDT.Properties.Settings.Default.MaPhongBan = (int)command3.ExecuteScalar();
                        command3.Dispose();
                        string sql4 = "select TenPhongBan  From [PhongBanWeb] where MaPhongBan = '" + QLHTDT.Properties.Settings.Default.MaPhongBan + "'";
                        command4 = new SqlCommand(sql4, conn);
                        QLHTDT.Properties.Settings.Default.PhongBan = (string)command4.ExecuteScalar();
                        string sql5 = "select LoaiNguoiDung  From [User] where TenDangNHap = '" + txtTaiKhoan.Text + "'";
                        command5 = new SqlCommand(sql5, conn);
                        QLHTDT.Properties.Settings.Default.LoaiNguoiDung = (int)command5.ExecuteScalar();
                        Read("firsttime");
                        if (QLHTDT.Properties.Settings.Default.CheckDangKy != true)
                        {
                            //DateTime date = GetDate();
                            //Write("firsttime", date.Year * 365 + date.Month * 30 + date.Day);
                            if (ThoiGianDaHoatDong <= 7)
                            {
                                this.Visible = false;
                                //pictureBox2.Visible = true;
                                //pic1 = new PictureBox();
                                //pic1 = pictureBox2;
                                //pic1.Visible = true;
                                QLHTDT.FormChinh.QuanTriHeThong frm = new QLHTDT.FormChinh.QuanTriHeThong();
                                frm.ShowDialog();
                                Cursor = Cursors.Default;
                                //pic1.Visible = false;
                                //this.Visible = false;
                                if (frm.Visible == false)
                                {
                                    frm.Close();
                                    this.Visible = true;
                                    txtMatKhau.Clear();
                                }
                            }
                            else if (ThoiGianDaHoatDong > 7)
                            {
                                //Cursor = Cursors.Default;
                                //DialogResult dialogResult = MessageBox.Show("Vui lòng đăng ký để tiếp tục sử dụng phần mềm", "Thông báo", MessageBoxButtons.OK);
                                //if (dialogResult == DialogResult.OK)
                                //{
                                //    QLHTDT.FormPhu.TTLienHeDKySD frm1 = new QLHTDT.FormPhu.TTLienHeDKySD();
                                //    frm1.ShowDialog();

                                //}
                                //else if (dialogResult != DialogResult.OK)
                                //{
                                //    this.Close();
                                //}
                                //Cursor = Cursors.Default;
                                this.Visible = false;
                                //pictureBox2.Visible = true;
                                //pic1 = new PictureBox();
                                //pic1 = pictureBox2;
                                //pic1.Visible = true;
                                QLHTDT.FormChinh.QuanTriHeThong frm = new QLHTDT.FormChinh.QuanTriHeThong();
                                frm.ShowDialog();
                                Cursor = Cursors.Default;
                                //pic1.Visible = false;
                                //this.Visible = false;
                                if (frm.Visible == false)
                                {
                                    frm.Close();
                                    this.Visible = true;
                                    txtMatKhau.Clear();
                                }
                            }
                        }
                        else
                        {
                            this.Visible = false;
                            QLHTDT.FormChinh.QuanTriHeThong frm = new QLHTDT.FormChinh.QuanTriHeThong();
                            frm.ShowDialog();
                            //this.Visible = false;
                            if (frm.Visible == false)
                            {
                                frm.Close();
                                this.Visible = true;
                                txtMatKhau.Clear();
                            }
                            Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        Cursor = Cursors.Default; MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Cursor = Cursors.Default;
            }
            
            if (CboPhanHe.Text == "Quản lý Quy hoạch - Kiến trúc")
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sql = "select COUNT (*) From [User] where TenDangNhap = @TaiKhoan and MatKhau = @MatKhau";
                    command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@TaiKhoan", txtTaiKhoan.Text));
                    GetMD5(txtMatKhau.Text);
                    command.Parameters.Add(new SqlParameter("@MatKhau", MD5_MatKhau));
                    int x = (int)command.ExecuteScalar();
                    if (x == 1)
                    {//Đăng nhập thành công\
                        var client = new RestClient("https://sxd.sgmcvietnam.vn/api/user/sign-in");
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Content-Type", "application/json");
                        request.AddParameter("application/json", "{\n\t\t\"username\": \""+ txtTaiKhoan.Text + "\",\n\t\t\"password\": \""+ txtMatKhau.Text + "\"\n}", ParameterType.RequestBody);
                        IRestResponse response = client.Execute(request);
                        dynamic stuff = JObject.Parse(response.Content);
                        QLHTDT.Properties.Settings.Default.Token = stuff.token;
                        Console.WriteLine(response.Content);

                        QLHTDT.Properties.Settings.Default.TenTK = txtTaiKhoan.Text;
                        string sql2 = "select HoVaTen  From[User] where TenDangNhap = '" + txtTaiKhoan.Text + "'";
                        command2 = new SqlCommand(sql2, conn);
                        QLHTDT.Properties.Settings.Default.HoVaTen = (string)command2.ExecuteScalar();
                        command2.Dispose();
                        string sql3 = "select MaPhongBan From [User] where TenDangNhap = '" + txtTaiKhoan.Text + "'";
                        command3 = new SqlCommand(sql3, conn);
                        if (command3 == null)
                        {
                            QLHTDT.Properties.Settings.Default.MaPhongBan = 1;
                            command3.Dispose();
                            string sql4 = "select TenPhongBan  From [PhongBanWeb] where MaPhongBan = '" + QLHTDT.Properties.Settings.Default.MaPhongBan + "'";
                            command4 = new SqlCommand(sql4, conn);
                            QLHTDT.Properties.Settings.Default.PhongBan = (string)command4.ExecuteScalar();
                        }
                        else
                        {
                            QLHTDT.Properties.Settings.Default.MaPhongBan = (int)command3.ExecuteScalar();
                            command3.Dispose();
                            string sql4 = "select TenPhongBan  From [PhongBanWeb] where MaPhongBan = '" + QLHTDT.Properties.Settings.Default.MaPhongBan + "'";
                            command4 = new SqlCommand(sql4, conn);
                            QLHTDT.Properties.Settings.Default.PhongBan = (string)command4.ExecuteScalar();
                        }
                        string sql5 = "select LoaiNguoiDung  From [User] where TenDangNhap = '" + txtTaiKhoan.Text + "'";
                        command5 = new SqlCommand(sql5, conn);
                        QLHTDT.Properties.Settings.Default.LoaiNguoiDung = (int)command5.ExecuteScalar();
                        Read("firsttime");
                        if (QLHTDT.Properties.Settings.Default.CheckDangKy != true)
                        {
                            //DateTime date = GetDate();
                            //Write("firsttime", date.Year * 365 + date.Month * 30 + date.Day);
                            if (ThoiGianDaHoatDong <= 7)
                            {
                                this.Visible = false;
                                //pictureBox2.Visible = true;
                                //pic1 = new PictureBox();
                                //pic1 = pictureBox2;
                                //pic1.Visible = true;
                                QLHTDT.FormChinh.KienTruc frm = new QLHTDT.FormChinh.KienTruc();
                                frm.ShowDialog();
                                Cursor = Cursors.Default;
                                //pic1.Visible = false;
                                //this.Visible = false;
                                if (frm.Visible == false)
                                {
                                    frm.Close();
                                    this.Visible = true;
                                    txtMatKhau.Clear();
                                }
                            }
                            else if (ThoiGianDaHoatDong > 7)
                            {
                                //Cursor = Cursors.Default;
                                //DialogResult dialogResult = MessageBox.Show("Vui lòng đăng ký để tiếp tục sử dụng phần mềm", "Thông báo", MessageBoxButtons.OK);
                                //if (dialogResult == DialogResult.OK)
                                //{
                                //    QLHTDT.FormPhu.TTLienHeDKySD frm1 = new QLHTDT.FormPhu.TTLienHeDKySD();
                                //    frm1.ShowDialog();

                                //}
                                //else if (dialogResult != DialogResult.OK)
                                //{ 
                                //    this.Close();
                                //}
                                //Cursor = Cursors.Default;
                                this.Visible = false;
                                //pictureBox2.Visible = true;
                                //pic1 = new PictureBox();
                                //pic1 = pictureBox2;
                                //pic1.Visible = true;
                                QLHTDT.FormChinh.KienTruc frm = new QLHTDT.FormChinh.KienTruc();
                                frm.ShowDialog();
                                Cursor = Cursors.Default;
                                //pic1.Visible = false;
                                //this.Visible = false;
                                if (frm.Visible == false)
                                {
                                    frm.Close();
                                    this.Visible = true;
                                    txtMatKhau.Clear();
                                }
                            }
                        }
                        else
                        {
                            this.Visible = false;
                            QLHTDT.FormChinh.KienTruc frm = new QLHTDT.FormChinh.KienTruc();
                            frm.ShowDialog();
                            //this.Visible = false;
                            if (frm.Visible == false)
                            {
                                frm.Close();
                                this.Visible = true;
                                txtMatKhau.Clear();
                            }
                            Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        Cursor = Cursors.Default; MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                 }
                Cursor = Cursors.Default;
            }
        }
        public string Read(string KeyName)
        {
            // Opening the registry key

            RegistryKey baseRegistryKey;
            baseRegistryKey = Registry.CurrentUser;
            RegistryKey rk = baseRegistryKey;
            // I have to use CreateSubKey 

            // (create or open it if already exits), 

            // 'cause OpenSubKey open a subKey as read-only
            string subKey;
            subKey = "Software\\Microsoft";

            RegistryKey sk1 = rk.OpenSubKey(subKey);
            // If the RegistrySubKey doesn't exist -> (null)

            if (sk1.ValueCount == 1)
            {

                DateTime date = GetDate();
                //Write("firsttime", date.Year * 365 + date.Month * 30 + date.Day);
                NgayBatDau = (int)sk1.GetValue(KeyName.ToUpper());
                ThoiGianDaHoatDong = date.Year * 365 + date.Month * 30 + date.Day - NgayBatDau;
                return (string)sk1.GetValue(KeyName.ToUpper()).ToString();
            }
            else
            {
                try
                {
                    //NgayBatDau = (int)sk1.GetValue(KeyName.ToUpper());
                    //DateTime date = GetDate();
                    //ThoiGianDaHoatDong = date.Year * 365 + date.Month * 30 + date.Day - NgayBatDau;
                    DateTime date = GetDate();
                    Write("firsttime", date.Year * 365 + date.Month * 30 + date.Day);
                    return (string)sk1.GetValue(KeyName.ToUpper()).ToString();
                }
                catch (Exception e)
                {
                    // AAAAAAAAAAARGH, an error!

                    MessageBox.Show(e.Message, "Writing registry " + KeyName.ToUpper());
                    return null;
                }
            }
        }
        public bool Write(string KeyName, object Value)
        {
            try
            {
                // Setting
                RegistryKey baseRegistryKey;
                baseRegistryKey = Registry.CurrentUser;
                RegistryKey rk = baseRegistryKey;
                // I have to use CreateSubKey 

                // (create or open it if already exits), 

                // 'cause OpenSubKey open a subKey as read-only
                string subKey;
                subKey = "Software\\Microsoft";
                RegistryKey sk1 = rk.CreateSubKey(subKey);
                // Save the value

                sk1.SetValue(KeyName.ToUpper(), Value);

                return true;
            }
            catch (Exception e)
            {
                // AAAAAAAAAAARGH, an error!

                MessageBox.Show(e.Message, "Writing registry " + KeyName.ToUpper());
                return false;
            }
        }

        private void CboPhanHe_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupControl1.Enabled = true;
        }

        private void txtMatKhau_MouseDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtDangNhap_Click(sender, e);
            }
        }

        private void txtTaiKhoan_MouseDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                BtDangNhap_Click(sender, e);
            }
        }

        private void BtSetting_Click(object sender, EventArgs e)
        {
            QLHTDT.FormChinh.SettingKetNoiCSDL frm = new QLHTDT.FormChinh.SettingKetNoiCSDL();
            frm.ShowDialog();
        }

        private void label3_DoubleClick(object sender, EventArgs e)
        {

        }

        private void BtThacmac_Click(object sender, EventArgs e)
        {
        }

    }
}