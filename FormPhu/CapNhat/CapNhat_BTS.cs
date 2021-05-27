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


namespace QLHTDT.FormPhu.CapNhat
{
    public partial class CapNhat_BTS : Form
    {
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        string sql = "SELECT [OBJECTID],[STT],[ChuDauTu],[DiaChi],[PhuongXa],[QuanHuyen],[KinhDo] ,[ViDo] ,[LoaiTru] ,[DoCao] ,[Ngay] ,[SoGP] ,[NgayCapGP] ,[SoCN] ,[NgayVaoSoCN],[DungChung] ,[Khac] ,[ThongTinKh]  ,[XVN2000],[YVN2000] FROM  TRAMBTS";
        public CapNhat_BTS()
        {
            InitializeComponent();
        }
        private void OpenExcel_Click(object sender, EventArgs e)//Mở file excel
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Excell|*.xls;*.xlsx;";
            DialogResult dr = od.ShowDialog();
            if (dr == DialogResult.Abort)
                return;
            if (dr == DialogResult.Cancel)
                return;
            textBox1.Text = od.FileName.ToString();
            string sexcelconnectionstring = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + textBox1.Text +
         ";extended properties=" + "\"excel 12.0;hdr=yes;\"";
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
            showgridControl1();
        }
        void showgridControl1()//Load dữ liệu SQL vào datagribview
        {
            //dgvData.Refresh();
            //sqlconn.Open();
            //string sql = "select Stt,ChuDauTu,DiaChi,KinhDo,ViDo,DoCao,LoaiTru from TramBTS";
            //SqlCommand com = new SqlCommand(sql, sqlconn);
            //com.CommandType = CommandType.Text;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //sqlconn.Close();
            string sql = "SELECT [OBJECTID],[STT],[ChuDauTu],[DiaChi],[PhuongXa],[QuanHuyen],[KinhDo] ,[ViDo] ,[LoaiTru] ,[DoCao] ,[Ngay] ,[SoGP] ,[NgayCapGP] ,[SoCN] ,[NgayVaoSoCN],[DungChung] ,[Khac] ,[ThongTinKh]  ,[XVN2000],[YVN2000] FROM  TRAMBTS";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val2 = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                var val = ds.Tables[0].Rows[intCount]["QuanHuyen"].ToString();
                if (!comboQuan.Items.Contains(val))
                {
                    comboQuan.Items.Add(val);
                }
                if (!comboPhuong.Items.Contains(val2))
                {
                    comboPhuong.Items.Add(val2);
                }
            }
        }

        private void UpdateBTS_Click(object sender, EventArgs e)// Cập nhật Datagribview vào SQL Server
        {
            string Quan = comboQuan.Text;
            string Phuong = comboPhuong.Text;
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
                    cmd1.Parameters.AddWithValue("@Quan", Quan);
                    cmd1.Parameters.AddWithValue("@Phuong", Phuong);
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
                    cmd.Parameters.AddWithValue("@Quan", Quan);
                    cmd.Parameters.AddWithValue("@Phuong", Phuong);
                    cmd.Parameters.AddWithValue("@Stt", Stt);
                    cmd.Parameters.AddWithValue("@ChuDauTu", ChuDauTu);
                    cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                    cmd.Parameters.AddWithValue("@KinhDo", KinhDo);
                    cmd.Parameters.AddWithValue("@ViDo", ViDo);
                    cmd.Parameters.AddWithValue("@DoCao", DoCao);
                    cmd.Parameters.AddWithValue("@LoaiTru", LoaiTru);
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

        private void comboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql + " Where [QuanHuyen] = N'" + comboQuan.Text + "'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            comboPhuong.Items.Clear();
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                if (!comboPhuong.Items.Contains(val))
                {
                    comboPhuong.Items.Add(val);
                }
            }
        }
    }
}
