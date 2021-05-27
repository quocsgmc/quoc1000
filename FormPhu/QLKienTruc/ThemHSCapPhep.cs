using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ESRI.ArcGIS.SystemUI;
using QLHTDT.FormChinh;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using QLHTDT.Properties;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace QLHTDT.FormPhu.QLKienTruc
{
    public partial class ThemHSCapPhep : Form
    {
        int AddQuan = 0;
        public static string MaHuyen = "null";
        ILayer layeredit;
        string tableKT = "";
        int LoaiHS = 0;
        string SoSeri = "";
        DateTime NgayCapGiayCN;
        public ThemHSCapPhep(string Day, string month, string year)
        {
            InitializeComponent();
            textBox4.Text = Day;
            textBox3.Text = month;
            textBox2.Text = year;
            LoaiHS = 1;
            //btFileDinhKem.Enabled = false;
        }
        string ID;
        public ThemHSCapPhep(string ID1,string cdt, string diachi, string congtrinh, string thietke, string soto, string sothua, string duong, string viahe, string khuqh, string phuong, string dientich, string dientichxaydung, string tongdtsd, string mdxd, string hesosdd, string chieucaoct, string sotang, string chieucaocactang, string cotnenct, string khoanglui, string dovuon, string serigcn, string ngaycapgcn, string qdkhac)
        {
            InitializeComponent();
            ID = ID1;
            ChuDauTu.Text = cdt;
            DiaChiCDT.Text = diachi;
            LoaiCT.Text = congtrinh;
            ThietKe.Text = thietke;
            SThua.Text = sothua;
            STo.Text = soto;
            Duong.Text = duong;
            ViaHe.Text = viahe;
            Khu.Text = khuqh;
            Phuong.Text = phuong;
            DienTich.Text = dientich;
            DTXD.Text = dientichxaydung;
            TongDTSD.Text = tongdtsd;
            MatDoXD.Text = mdxd;
            HeSoSDD.Text = hesosdd;
            ChieuCaoCacTang.Text = chieucaocactang;
            SoTang.Text = sotang;
            NenCongTrinh.Text = cotnenct;
            KLui.Text = khoanglui;
            DoVuon.Text = dovuon;
            SoSeri = serigcn;
            NgayCapGiayCN = DateTime.Parse(ngaycapgcn);
            
            //GiayToLienQuan.Text = "Giấy chứng nhận QSDĐ số seri "+serigcn +" do Sở Tài nguyên & Môi trường TP Đà Nẵng cấp ngày "+ NgayCapGiayCN.Day +"/"+ NgayCapGiayCN.Month + "/" + NgayCapGiayCN.Year+ ".";
            //NoiDung.Text = qdkhac;
            var date = DateTime.Now;
            textBox4.Text = date.Day.ToString();
            textBox3.Text = date.Month.ToString();
            textBox2.Text = date.Year.ToString();
            LoaiHS = 2;

        }
        private void btXemBanIn_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Ngay", textBox4.Text);
            dic.Add("Thang", textBox3.Text);
            dic.Add("Nam", textBox2.Text);
            dic.Add("ChuDauTu", ChuDauTu.Text);
            dic.Add("DiaChiCDT", DiaChiCDT.Text);
            dic.Add("LoaiCT", LoaiCT.Text);
            dic.Add("ThietKe", ThietKe.Text);
            dic.Add("SThua", SThua.Text);
            dic.Add("STo", STo.Text);
            dic.Add("Duong", Duong.Text);
            dic.Add("ViaHe", ViaHe.Text);
            dic.Add("Khu", Khu.Text);
            dic.Add("Phuong", IDPhuong);
            dic.Add("DTThua", DienTich.Text);
            dic.Add("DTXDT1", DTXD.Text);
            dic.Add("TongDTXD", TongDTSD.Text);
            dic.Add("MatDoXD", MatDoXD.Text);
            dic.Add("HeSoSDD", HeSoSDD.Text);
            dic.Add("ChieuCao", ChieuCaoCT.Text);
            dic.Add("SoTang", SoTang.Text);
            dic.Add("CaoCacTang", ChieuCaoCacTang.Text);
            dic.Add("CotNen", NenCongTrinh.Text);
            dic.Add("DonViLienHe", txtGhiChu.Text);
            //dic.Add("GiayToLienQuan", GiayToLienQuan.Text);
            //dic.Add("NDCapPhep", NoiDung.Text);
            dic.Add("KhoangLui", KLui.Text);
            dic.Add("DoVuon", DoVuon.Text);
            dic.Add("SoQD", SoQD.Text);
            dic.Add("Phuong2", Phuong.Text);
            WWord wd = new WWord(QLHTDT.Properties.Settings.Default.PathData + "\\MauCPXD.dotx", true);
            wd.WriteFields(dic);
        }
        private void ZoomToLayers()
        {
            ICommand command = new ControlsZoomToSelectedCommand();
            command.OnCreate(KienTruc.axMapControl1.Object);
            KienTruc.axMapControl1.CurrentTool = command as ITool;
            command.OnClick();
        }
       
        private void btInGP_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (LoaiHS == 2)
                {
                    if (STo.Text != "" | SThua.Text != "" | Phuong.Text != "")
                    {
                        var date = DateTime.Now;
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic.Add("Ngay", textBox4.Text);
                        dic.Add("Thang", textBox3.Text);
                        dic.Add("Nam", textBox2.Text);
                        dic.Add("ChuDauTu", ChuDauTu.Text);
                        dic.Add("DiaChiCDT", DiaChiCDT.Text);
                        dic.Add("LoaiCT", LoaiCT.Text);
                        dic.Add("ThietKe", ThietKe.Text);
                        dic.Add("SThua", SThua.Text);
                        dic.Add("STo", STo.Text);
                        dic.Add("Duong", Duong.Text);
                        dic.Add("ViaHe", ViaHe.Text);
                        dic.Add("Khu", Khu.Text);
                        dic.Add("Phuong", Phuong.Text);
                        dic.Add("DTThua", DienTich.Text);
                        dic.Add("DTXDT1", DTXD.Text);
                        dic.Add("TongDTXD", TongDTSD.Text);
                        dic.Add("MatDoXD", MatDoXD.Text);
                        dic.Add("HeSoSDD", HeSoSDD.Text);
                        dic.Add("ChieuCao", ChieuCaoCT.Text);
                        dic.Add("SoTang", SoTang.Text);
                        dic.Add("CaoCacTang", ChieuCaoCacTang.Text);
                        dic.Add("CotNen", NenCongTrinh.Text);
                        dic.Add("DonViLienHe", txtGhiChu.Text);
                        //dic.Add("GiayToLienQuan", GiayToLienQuan.Text);
                        //dic.Add("NDCapPhep", NoiDung.Text);
                        dic.Add("KhoangLui", KLui.Text);
                        dic.Add("DoVuon", DoVuon.Text);
                        dic.Add("SoQD", SoQD.Text);
                        dic.Add("Phuong2", Phuong.Text);
                        WWord wd = new WWord(QLHTDT.Properties.Settings.Default.PathData + "\\MauCPXD.dotx", true);
                        wd.print(dic);

                        string sql = "select * from CPXD";
                        SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        SqlCommand command = new SqlCommand(sql, connection);
                        command.Connection.Open();
                        string querystr2 = "UPDATE CPXD SET [TinhTrang] =N'Chưa xử lý' FROM CPXD WHERE [SoTo] =" + STo.Text + " and [SoThua] =" + SThua.Text + " and [IDPhuong] = N'" + IDPhuong + "'";
                        SqlCommand query2 = new SqlCommand(querystr2, connection);
                        query2.ExecuteNonQuery();
                        command.Connection.Close();
                        MessageBox.Show("Thêm mới hồ sơ thành công", "Thông báo");
                        //Lấy ID Hồ sơ
                        SqlDataAdapter adp3 = new SqlDataAdapter("Select ID from CPXD where SoTo = '" + STo.Text + "' AND SoThua = '" + SThua.Text + "' AND IDPhuong = '" + Phuong.SelectedValue.ToString() + "'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        DataSet ds3 = new DataSet();
                        adp3.Fill(ds3);
                        string OBJECTID = ds3.Tables[0].Rows[0]["ID"].ToString();
                        int ID;
                        Int32.TryParse(OBJECTID, out ID);
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Hồ sơ cấp phép xây dựng", ID);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                        this.Hide();
                    }
                    else MessageBox.Show("Chưa nhập đủ thông tin thửa đất!", "Thông báo");
                }
                else if (LoaiHS == 1)
                {
                    string cmdString = "INSERT INTO CPXD ([TenHS] ,[TenCDT],[DiaChi],[SoThua],[SoTo],[DT],[DTXD],[LoaiCT],[ThietKe],[ChieuCao],[SoTang],[TinhTrang],[SoQD],[IDHuyen],[IDPhuong],[Duong],[ViaHe] ,[MDXD],[HESOSDD],[ChieuCaoCacTang],[CotNen],[KhoangLui],[DoVuon],[seriGCN],[TongDTSDD],[FileQD],[NgayCapGCN],[NgayThemHS],[GhiChu]) VALUES (@TenHS, @TenCDT, @DiaChi,@SoThua, @SoTo, @DT,@DTXD, @LoaiCT,@ThietKe, @ChieuCao, @SoTang,  @TinhTrang, @SoQD,@IDHuyen, @IDPhuong,@Duong, @ViaHe, @MDXD  , @HESOSDD,  @ChieuCaoCacTang, @CotNen, @KhoangLui,@DoVuon, @seriGCN, @TongDTSDD   ,@FileQD, @NgayCapGCN, @NgayThemHS,@GhiChu)";
                    string connString = Settings.Default.strConnectionDAQH;
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = conn;
                            comm.CommandText = cmdString;
                            comm.Parameters.AddWithValue("@TenHS", "Hồ sơ cấp phép xây dựng ");
                            comm.Parameters.AddWithValue("@TenCDT", ChuDauTu.Text);
                            comm.Parameters.AddWithValue("@DiaChi", DiaChiCDT.Text);
                            comm.Parameters.AddWithValue("@SoThua", int.Parse(SThua.Text));
                            comm.Parameters.AddWithValue("@SoTo", int.Parse(STo.Text));
                            comm.Parameters.AddWithValue("@DT", double.Parse(DienTich.Text));
                            comm.Parameters.AddWithValue("@DTXD", double.Parse(DTXD.Text));
                            comm.Parameters.AddWithValue("@LoaiCT", LoaiCT.Text);
                            comm.Parameters.AddWithValue("@ThietKe", ThietKe.Text);
                            comm.Parameters.AddWithValue("@ChieuCao", double.Parse(ChieuCaoCT.Text));
                            comm.Parameters.AddWithValue("@SoTang", int.Parse(SoTang.Text));
                            comm.Parameters.AddWithValue("@TinhTrang", "Chưa xử lý");
                            comm.Parameters.AddWithValue("@SoQD", SoQD.Text);
                            comm.Parameters.AddWithValue("@IDHuyen", Quan.SelectedValue.ToString());
                            comm.Parameters.AddWithValue("@IDPhuong", Phuong.SelectedValue.ToString());
                            comm.Parameters.AddWithValue("@Duong", Duong.Text);
                            comm.Parameters.AddWithValue("@ViaHe", ViaHe.Text);
                            comm.Parameters.AddWithValue("@MDXD", MatDoXD.Text);
                            comm.Parameters.AddWithValue("@HESOSDD", HeSoSDD.Text);
                            comm.Parameters.AddWithValue("@ChieuCaoCacTang", ChieuCaoCacTang.Text);
                            comm.Parameters.AddWithValue("@CotNen", NenCongTrinh.Text);
                            comm.Parameters.AddWithValue("@KhoangLui", KLui.Text);
                            comm.Parameters.AddWithValue("@DoVuon", DoVuon.Text);
                            comm.Parameters.AddWithValue("@seriGCN", txtSeriGCN.Text);
                            comm.Parameters.AddWithValue("@TongDTSDD", TongDTSD.Text);
                            comm.Parameters.AddWithValue("@FileQD", "");
                            comm.Parameters.AddWithValue("@NgayCapGCN", dateTimePickerCapGP.Value.ToString("MM-dd-yyyy"));
                            comm.Parameters.AddWithValue("@NgayThemHS", DateTime.Parse(textBox2.Text + "-" + textBox3.Text + "-" + textBox4.Text).ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                            comm.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                            conn.Open();
                            comm.ExecuteNonQuery();
                            try
                            {

                                Dictionary<string, string> dic = new Dictionary<string, string>();
                                dic.Add("Ngay", textBox4.Text);
                                dic.Add("Thang", textBox3.Text);
                                dic.Add("Nam", textBox2.Text);
                                dic.Add("ChuDauTu", ChuDauTu.Text);
                                dic.Add("DiaChiCDT", DiaChiCDT.Text);
                                dic.Add("LoaiCT", LoaiCT.Text);
                                dic.Add("ThietKe", ThietKe.Text);
                                dic.Add("SThua", SThua.Text);
                                dic.Add("STo", STo.Text);
                                dic.Add("Duong", Duong.Text);
                                dic.Add("ViaHe", ViaHe.Text);
                                dic.Add("Khu", Khu.Text);
                                dic.Add("Phuong", Phuong.Text);
                                dic.Add("DTThua", DienTich.Text);
                                dic.Add("DTXDT1", DTXD.Text);
                                dic.Add("TongDTXD", TongDTSD.Text);
                                dic.Add("MatDoXD", MatDoXD.Text);
                                dic.Add("HeSoSDD", HeSoSDD.Text);
                                dic.Add("ChieuCao", ChieuCaoCT.Text);
                                dic.Add("SoTang", SoTang.Text);
                                dic.Add("CaoCacTang", ChieuCaoCacTang.Text);
                                dic.Add("CotNen", NenCongTrinh.Text);
                                dic.Add("DonViLienHe", txtGhiChu.Text);
                                //dic.Add("GiayToLienQuan", GiayToLienQuan.Text);
                                //dic.Add("NDCapPhep", NoiDung.Text);
                                dic.Add("KhoangLui", KLui.Text);
                                dic.Add("DoVuon", DoVuon.Text);
                                dic.Add("SoQD", SoQD.Text);
                                dic.Add("Phuong2", Phuong.Text);
                                //WWord wd = new WWord(QLHTDT.Properties.Settings.Default.PathData + "\\MauCPXD.dotx", true);
                                //wd.print(dic);
                                conn.Close();
                                this.Hide();
                                MessageBox.Show("Thêm mới hồ sơ thành công", "Thông báo");

                                SqlDataAdapter adp3 = new SqlDataAdapter("Select ID from CPXD where SoTo = '" + STo.Text + "' AND SoThua = '" + SThua.Text + "' AND IDPhuong = '" + Phuong.SelectedValue.ToString() + "'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                DataSet ds3 = new DataSet();
                                adp3.Fill(ds3);
                                string OBJECTID = ds3.Tables[0].Rows[0]["ID"].ToString();
                                int ID;
                                Int32.TryParse(OBJECTID, out ID);

                                KienTruc.TBNK = new DataTable();
                                SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                                SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                                KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                                KienTruc.ThemMoiDoiTuong("Hồ sơ cấp phép xây dựng", ID);
                                KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                                this.Hide();
                            }
                            catch (SqlException ex)
                            {
                                // do something with the exception
                                // don't hide it
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin", "Thông báo");
            }
        }

        private void btFileDinhKem_Click(object sender, System.EventArgs e)
        {
            if (LoaiHS == 1)
            {
                if (STo.Text != "" && SThua.Text != "" && STo.Text != null & SThua.Text != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa có dữ liệu hồ sơ cấp phép, Có tạo dữ liệu hồ sơ cấp phép không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string sql = "select MaHS from CPXD where ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + STo.Text + "' and [SoThua] ='" + SThua.Text + "')";
                        SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        SqlCommand commanCPXD = new SqlCommand(sql, connection);
                        commanCPXD.Connection.Open();
                        string pathMaHS = "";
                        string pathcheck = "";
                        if (commanCPXD.ExecuteScalar() != DBNull.Value)
                        {
                            pathcheck = (string)commanCPXD.ExecuteScalar();
                            if (pathcheck != "" & pathcheck != null)
                            {
                                pathMaHS = pathcheck;
                            }
                        }

                        WebRequest ftpRequest = WebRequest.Create("ftp://117.2.120.9/FileDinhKemCPXD/" + pathMaHS.Replace(" ", "").ToString());
                        ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                        ftpRequest.Credentials = new NetworkCredential("sinhnv", "Abc#1234");
                        using (var resp = (FtpWebResponse)ftpRequest.GetResponse())
                        {
                            Console.WriteLine(resp.StatusCode);
                        }

                        QLHTDT.FormPhu.QLQH.listfilefolder frm = new QLQH.listfilefolder("ftp://117.2.120.9/FileDinhKemCPXD/" + pathMaHS.Replace(" ", "").ToString(), "sinhnv", "Abc#1234");
                        frm.Show();
                    }
                    
                }
                else { MessageBox.Show("Chưa có thông tin thửa đất (số tờ, số thửa, Phường)", "Thông báo"); }
            }
            else if (LoaiHS == 2)
            {
                string sql = "select MaHS from CPXD where ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + STo.Text + "' and [SoThua] ='" + SThua.Text + "')";
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                SqlCommand commanCPXD = new SqlCommand(sql, connection);
                commanCPXD.Connection.Open();
                string pathMaHS = "";
                string pathcheck = "";
                if (commanCPXD.ExecuteScalar() != DBNull.Value)
                {
                    pathcheck = (string)commanCPXD.ExecuteScalar();
                    if (pathcheck != "" & pathcheck != null)
                    {
                        pathMaHS = pathcheck;
                    }
                }
                QLHTDT.FormPhu.QLQH.listfilefolder frm = new QLQH.listfilefolder("ftp://117.2.120.9/FileDinhKemCPXD/" + pathMaHS.Replace(" ", "").ToString(), "sinhnv", "Abc#1234");
                frm.Show();

            }
        }
        string IDPhuong = "null";
        private void Phuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void ThemHSCapPhep_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Quan.DataSource = ds.Tables[0];
            Quan.DisplayMember = "TENHUYEN";
            Quan.ValueMember = "MAHUYEN";
        }

        private void Quan_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            Phuong.ResetText();
            if (Quan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                Quan.Text = "";
            }
            if (AddQuan == 1)
            {
                MaHuyen = Quan.SelectedValue.ToString();
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + " ";

                SqlDataAdapter adp = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds = new DataSet();
                adp.Fill(ds);
                Phuong.DataSource = ds.Tables[0];
                Phuong.DisplayMember = "TenPhuong";
                Phuong.ValueMember = "MaPhuong";

                if (Quan.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    Phuong.Text = "";
                }
            }
        }
    }
}
