using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class CapNhatCayXanh : Form
    {
        SqlConnection sqlconn = new SqlConnection("Server=DESKTOP-GPII52C\\CAMLE;Database=DangNhap;User Id=sa;Password=quoc782442;");
        public CapNhatCayXanh()
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
        public void ImportDataFromExcel(string excelFilePath)//Test Cập nhật excel
        {

            string ssqltable = "CayXanh";
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string Quan = comboBox1.Text;
                string Phuong = comboBox2.Text;
                for (int i = 0; i < dgvData.RowCount - 1; i++)
                {
                    //Các trường thuộc tính có thể thay đổi
                    string Stt = dgvData.Rows[i].Cells[0].Value.ToString();
                    string MaCayXanh = dgvData.Rows[i].Cells[1].Value.ToString();
                    string LoaiCayXanh = dgvData.Rows[i].Cells[2].Value.ToString();
                    string ToaDoX = dgvData.Rows[i].Cells[3].Value.ToString();
                    string ToaDoY = dgvData.Rows[i].Cells[4].Value.ToString();

                    string str = "Server=DESKTOP-GPII52C\\CAMLE;Database=DangNhap;User Id=sa;Password=quoc782442;";
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();

                    //Delete nếu dữ liệu đã tồn tại để cập nhật lại
                    string Delelequery = "DELETE from CayXanh where MaCayXanh = " + MaCayXanh + "";
                    SqlCommand cmd1 = new SqlCommand(Delelequery, conn);
                    cmd1.Parameters.AddWithValue("@Quan", Quan);
                    cmd1.Parameters.AddWithValue("@Phuong", Phuong);
                    cmd1.Parameters.AddWithValue("@Stt", Stt);
                    cmd1.Parameters.AddWithValue("@MaCayXanh", MaCayXanh);
                    cmd1.Parameters.AddWithValue("@LoaiCayXanh", LoaiCayXanh);
                    cmd1.Parameters.AddWithValue("@ToaDoX", ToaDoX);
                    cmd1.Parameters.AddWithValue("@ToaDoY", ToaDoY);
                    cmd1.ExecuteNonQuery();

                    //Insert cập nhật dữ liệu mới
                    string Insertquery = "insert into CayXanh(Stt,MaCayXanh,LoaiCayXanh,ToaDoX,ToaDoY,Quan,Phuong) values(@Stt,@MaCayXanh,@LoaiCayXanh,@ToaDoX,@ToaDoY,@Quan,@Phuong)";
                    SqlCommand cmd = new SqlCommand(Insertquery, conn);
                    cmd.Parameters.AddWithValue("@Quan", Quan);
                    cmd.Parameters.AddWithValue("@Phuong", Phuong);
                    cmd.Parameters.AddWithValue("@Stt", Stt);
                    cmd.Parameters.AddWithValue("@MaCayXanh", MaCayXanh);
                    cmd.Parameters.AddWithValue("@LoaiCayXanh", LoaiCayXanh);
                    cmd.Parameters.AddWithValue("@ToaDoX", ToaDoX);
                    cmd.Parameters.AddWithValue("@ToaDoY", ToaDoY);

                    cmd.ExecuteNonQuery();

                    //string query = string.Empty;
                    //string KiemTra = "Select count (MaCayXanh) from CayXanh where MaCayXanh= " + MaCayXanh + "";
                    //SqlCommand sosanh = new SqlCommand(KiemTra, conn);
                    //SqlConnection connn = new SqlConnection(str);
                    //sosanh.CommandType = CommandType.Text;
                    //sosanh.CommandText = query;
                    //DbDataReader dr = sosanh.ExecuteReader();

                    //string KiemTra = "Select MaCayXanh from CayXanh";
                    //SqlCommand sosanh = new SqlCommand(KiemTra, conn);
                    //sosanh.CommandType = CommandType.Text;
                    //SqlDataAdapter dataAdapter = new SqlDataAdapter(sosanh);
                    //DataTable dt1 = new DataTable();
                    //dataAdapter.Fill(dt1);
                    //dataGridView1.DataSource = dt1;
                    //for (int i1 = 0; i1 < dataGridView1.RowCount - 1; i1++)
                    //{
                    //    if (MaCayXanh == dataGridView1.Rows[i1].Cells[0].Value.ToString())
                    //    {
                    //Update
                    //string Updatequery = "update CayXanh Set Stt = @Stt,LoaiCayXanh=@LoaiCayXanh,ToaDoX=@ToaDoX,Quan=@Quan,Phuong=@Phuong where MaCayXanh=@MaCayXanh";
                    //SqlCommand cmd1 = new SqlCommand(Updatequery, conn);
                    //cmd1.Parameters.AddWithValue("@Quan", Quan);
                    //cmd1.Parameters.AddWithValue("@Phuong", Phuong);
                    //cmd1.Parameters.AddWithValue("@Stt", Stt);
                    //cmd1.Parameters.AddWithValue("@MaCayXanh", MaCayXanh);
                    //cmd1.Parameters.AddWithValue("@LoaiCayXanh", LoaiCayXanh);
                    //cmd1.Parameters.AddWithValue("@ToaDoX", ToaDoX);

                    //cmd1.ExecuteNonQuery();

                    //string Delele = "DELETE from CayXanh where MaCayXanh = " + MaCayXanh + "";
                    //SqlCommand cmd1 = new SqlCommand(Delele, conn);
                    //cmd1.Parameters.AddWithValue("@Quan", Quan);
                    //cmd1.Parameters.AddWithValue("@Phuong", Phuong);
                    //cmd1.Parameters.AddWithValue("@Stt", Stt);
                    //cmd1.Parameters.AddWithValue("@MaCayXanh", MaCayXanh);
                    //cmd1.Parameters.AddWithValue("@LoaiCayXanh", LoaiCayXanh);
                    //cmd1.Parameters.AddWithValue("@ToaDoX", ToaDoX);
                    //cmd1.ExecuteNonQuery();
                    //}
                    //else
                    //{
                    //Insert
                    //string Insertquery = "insert into CayXanh(Stt,MaCayXanh,LoaiCayXanh,ToaDoX,Quan,Phuong) values(@Stt,@MaCayXanh,@LoaiCayXanh,@ToaDoX,@Quan,@Phuong)";
                    //SqlCommand cmd = new SqlCommand(Insertquery, conn);
                    //cmd.Parameters.AddWithValue("@Quan", Quan);
                    //cmd.Parameters.AddWithValue("@Phuong", Phuong);
                    //cmd.Parameters.AddWithValue("@Stt", Stt);
                    //cmd.Parameters.AddWithValue("@MaCayXanh", MaCayXanh);
                    //cmd.Parameters.AddWithValue("@LoaiCayXanh", LoaiCayXanh);
                    //cmd.Parameters.AddWithValue("@ToaDoX", ToaDoX);

                    //cmd.ExecuteNonQuery();

                    //}
                    //}

                }
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại, kiểm tra", "Thông báo");
            }
        }
    }
}