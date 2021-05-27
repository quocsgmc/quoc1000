using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.Dat5PhanTram
{
    public partial class ChinhSuaBenThueDat : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        int IDChinhSua = QLHTDT.FormPhanHe.Dat5PhanTram.QuanlyBenThueDat.QuanlyBenThueDat.IDThueDat;
        public ChinhSuaBenThueDat()
        {
            InitializeComponent();
        }
        int ID = QLHTDT.FormPhanHe.Dat5PhanTram.QuanlyDat5PhanTram.QuanlyDat5PhanTram.ID1;
        private void ChinhSuaBenThueDat_Load(object sender, EventArgs e)
        {
            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_TABLE_BenThueDat] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                textBox1.Text = ds3.Tables[0].Rows[0]["HOVATEN"].ToString();
                textBox2.Text = ds3.Tables[0].Rows[0]["NAMSINH"].ToString();
                textBox3.Text = ds3.Tables[0].Rows[0]["CMND"].ToString();
                textBox4.Text = ds3.Tables[0].Rows[0]["SDT"].ToString();
                textBox5.Text = ds3.Tables[0].Rows[0]["GHICHU"].ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn Chỉnh sửa Bên thuê đất?", "Chỉnh sửa bên thuê đất", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                IFeature feature = null;
                int objectid;
                Cursor = Cursors.WaitCursor;
                bool check = true;
                bool isNumeric;
                double NamSinh;
                double CMND;
                double SDT;

                if (isNumeric = double.TryParse(textBox2.Text, out NamSinh)) { }
                else { MessageBox.Show("Sai định dạng dữ liệu Năm sinh!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo"); check = false; Cursor = Cursors.Default; return; }

                if (isNumeric = double.TryParse(textBox3.Text, out CMND)) { }
                else { MessageBox.Show("Sai định dạng dữ liệu CMND!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo"); check = false; Cursor = Cursors.Default; return; }

                if (isNumeric = double.TryParse(textBox4.Text, out SDT)) { }
                else { MessageBox.Show("Sai định dạng dữ liệu SĐT!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo"); check = false; Cursor = Cursors.Default; return; }

                isNumeric = true;

                if (check != false)
                {
                    try
                    {
                        objectid = IDChinhSua;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_CapPhepKTNM] "
                           + " '" + objectid
                           + "', N'" + textBox1.Text
                           + "', N'" + textBox2.Text
                           + "', N'" + textBox3.Text
                           + "', N'" + textBox4.Text
                           + "', N'" + textBox5.Text +"'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();

                        MessageBox.Show("Chỉnh sửa Bên thuê đất thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                    }
                    catch
                    {
                        MessageBox.Show("Chỉnh sửa Bên thuê đất thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                        Cursor = Cursors.Default;
                    }
                }

            }
        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
