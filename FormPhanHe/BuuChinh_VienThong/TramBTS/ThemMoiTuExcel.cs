using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;
using ESRI.ArcGIS.Geodatabase;

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS
{

    public partial class ThemMoiTuExcel : Form
    {
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        public ThemMoiTuExcel()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)//Mở file excel
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Excell|*.xls;*.xlsx;";
            DialogResult dr = od.ShowDialog();
            if (dr == DialogResult.Abort)
                return;
            if (dr == DialogResult.Cancel)
                return;
            textBox1.Text = od.FileName.ToString();
            string sexcelconnectionstring = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + textBox1.Text + ";extended properties=" + "\"excel 12.0;hdr=yes;\"";
            string myexceldataquery = "Select * from [Sheet1$]";
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myexceldataquery, oledbconn);
            DataTable dt = new DataTable();
            myDataAdapter.Fill(dt);
            dgvData.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ImportDataFromExcel(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //showgridControl1();
        }
        private void button3_Click(object sender, EventArgs e)// Cập nhật Datagribview vào SQL Server
        {
            try
            {
                for (int i = 0; i < dgvData.RowCount - 1; i++)
                {
                    //Các trường thuộc tính có thể thay đổi
                    string Stt = dgvData.Rows[i].Cells[0].Value.ToString();
                    string ChuDauTu = dgvData.Rows[i].Cells[1].Value.ToString();
                    string DiaChi = dgvData.Rows[i].Cells[2].Value.ToString();
                    string KinhDo = dgvData.Rows[i].Cells[3].Value.ToString();
                    string ViDo = dgvData.Rows[i].Cells[4].Value.ToString();
                    string DoCao = dgvData.Rows[i].Cells[5].Value.ToString();
                    string LoaiTru = dgvData.Rows[i].Cells[6].Value.ToString();

                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();

                    //Delete nếu dữ liệu đã tồn tại để cập nhật lại
                    string Delelequery = "DELETE from TramBTS where Stt = " + Stt + "";
                    SqlCommand cmd1 = new SqlCommand(Delelequery, conn);
                    cmd1.Parameters.AddWithValue("@Stt", Stt);
                    cmd1.Parameters.AddWithValue("@ChuDauTu", ChuDauTu);
                    cmd1.Parameters.AddWithValue("@DiaChi", DiaChi);
                    cmd1.Parameters.AddWithValue("@KinhDo", KinhDo);
                    cmd1.Parameters.AddWithValue("@ViDo", ViDo);
                    cmd1.Parameters.AddWithValue("@DoCao", DoCao);
                    cmd1.Parameters.AddWithValue("@LoaiTru", LoaiTru);
                    cmd1.ExecuteNonQuery();

                    //Insert cập nhật dữ liệu mới
                    string Insertquery = "insert into TramBTS(Stt,ChuDauTu,DiaChi,KinhDo,ViDo,DoCao,LoaiTru,Quan,Phuong) values(@Stt,@ChuDauTu,@DiaChi,@KinhDo,@ViDo,@DoCao,@LoaiTru,@Quan,@Phuong)";
                    SqlCommand cmd = new SqlCommand(Insertquery, conn);
                    cmd1.Parameters.AddWithValue("@Stt", Stt);
                    cmd1.Parameters.AddWithValue("@ChuDauTu", ChuDauTu);
                    cmd1.Parameters.AddWithValue("@DiaChi", DiaChi);
                    cmd1.Parameters.AddWithValue("@KinhDo", KinhDo);
                    cmd1.Parameters.AddWithValue("@ViDo", ViDo);
                    cmd1.Parameters.AddWithValue("@DoCao", DoCao);
                    cmd1.Parameters.AddWithValue("@LoaiTru", LoaiTru);

                    cmd.ExecuteNonQuery();

                }
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại. Kiểm tra lại thông tin", "Thông báo");
            }
        }

        private void button4_Click(object sender, EventArgs e)//Load Excel vào datagirbview
        {
            string sexcelconnectionstring = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + textBox1.Text +
               ";extended properties=" + "\"excel 12.0;hdr=yes;\"";
            string myexceldataquery = "Select * from [Sheet1$]";
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myexceldataquery, oledbconn);
            DataTable dt = new DataTable();
            myDataAdapter.Fill(dt);
            dgvData.DataSource = dt;
        }
        public void ImportDataFromExcel(string excelFilePath)//Test Cập nhật excel
        {

            string ssqltable = "TramBTS";
            string myexceldataquery = "select * from [Sheet1$]";
            try
            {
                string sexcelconnectionstring = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + excelFilePath +
                ";extended properties=" + "\"excel 12.0;hdr=yes;\"";
                //string sexcelconnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFilePath + ";Extended Properties=Excel 8.0";
                sqlconn.Open();
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlconn);
                bulkcopy.DestinationTableName = ssqltable;
                while (dr.Read())
                {
                    bulkcopy.WriteToServer(dr);
                }
                dr.Close();
                oledbconn.Close();
                MessageBox.Show("Cập nhật dữ liệu thành công");

                dgvData.Refresh();
                dgvData.Update();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvData.RowCount - 1; i++)
                {
                    //Các trường thuộc tính có thể thay đổi
                    string KinhDo1 = dgvData.Rows[i].Cells[0].Value.ToString();
                    string ViDo1 = dgvData.Rows[i].Cells[1].Value.ToString();
                    string DoCao1 = dgvData.Rows[i].Cells[2].Value.ToString();
                    string ChuDauTu1 = dgvData.Rows[i].Cells[3].Value.ToString();
                    string Quan1 = dgvData.Rows[i].Cells[4].Value.ToString();
                    string Phuong1 = dgvData.Rows[i].Cells[5].Value.ToString();
                    string DiaChi1 = dgvData.Rows[i].Cells[6].Value.ToString();
                    string SoGP1 = dgvData.Rows[i].Cells[7].Value.ToString();
                    string NgayCapGP1 = dgvData.Rows[i].Cells[8].Value.ToString();
                    string NgayVaoSoCN1 = dgvData.Rows[i].Cells[9].Value.ToString();
                    string SoCN1 = dgvData.Rows[i].Cells[10].Value.ToString();
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();

                    ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("TRAMBTS");
                    IFeature feature = ftClassSDE.CreateFeature();

                    ISubtypes subtypes = (ISubtypes)ftClassSDE;
                    IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
                    if (subtypes.HasSubtype)
                    {
                        rowSubtypes.SubtypeCode = 3;
                    }
                    rowSubtypes.InitDefaultValues();
                    int KinhDo = ftClassSDE.FindField("KinhDo");
                    if (KinhDo1 != "")
                    {
                        feature.set_Value(KinhDo, KinhDo1);
                    }
                    else { feature.set_Value(KinhDo, null); }

                    int ViDo = ftClassSDE.FindField("ViDo");
                    if (ViDo1 != "")
                    {
                        feature.set_Value(ViDo, ViDo1);
                    }
                    else { feature.set_Value(ViDo, null); }

                    int DoCao = ftClassSDE.FindField("DoCao");
                    if (DoCao1 != "")
                    {
                        feature.set_Value(DoCao, DoCao1);
                    }
                    else { feature.set_Value(DoCao, null); }

                    int ChuDauTu = ftClassSDE.FindField("ChuDauTu");
                    if (ChuDauTu1 != "")
                    {
                        feature.set_Value(ChuDauTu, ChuDauTu1);
                    }
                    else { feature.set_Value(ChuDauTu, null); }

                    int Quan = ftClassSDE.FindField("Quan");
                    if (Quan1 != "")
                    {
                        feature.set_Value(Quan, Quan1);
                    }
                    else { feature.set_Value(Quan, null); }

                    int Phuong = ftClassSDE.FindField("Phuong");
                    if (Phuong1 != "")
                    {
                        feature.set_Value(Phuong, Phuong1);
                    }
                    else { feature.set_Value(Phuong, null); }

                    int DiaChi = ftClassSDE.FindField("DiaChi");
                    if (DiaChi1 != "")
                    {
                        feature.set_Value(DiaChi, DiaChi1);
                    }
                    else { feature.set_Value(DiaChi, null); }

                    int SoGP = ftClassSDE.FindField("SoGP");
                    if (SoGP1 != "")
                    {
                        feature.set_Value(SoGP, SoGP1);
                    }
                    else { feature.set_Value(SoGP, null); }

                    int NgayCapGP = ftClassSDE.FindField("NgayCapGP");
                    if (NgayCapGP1 != "")
                    {
                        feature.set_Value(NgayCapGP, NgayCapGP1);
                    }
                    else { feature.set_Value(NgayCapGP, null); }

                    int NgayVaoSoCN = ftClassSDE.FindField("NgayVaoSoCN");
                    if (NgayVaoSoCN1 != "")
                    {
                        feature.set_Value(NgayCapGP, NgayVaoSoCN1);
                    }
                    else { feature.set_Value(SoGP, null); }

                    int SoCN = ftClassSDE.FindField("SoCN");
                    if (SoCN1 != "")
                    {
                        feature.set_Value(SoCN, SoCN1);
                    }
                    else { feature.set_Value(SoGP, null); }

                    feature.Store();
                    //QuanTriHeThong.splashScreenManager1.CloseWaitForm();

                }
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại. Kiểm tra lại thông tin", "Thông báo");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
