using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.CayXanh
{
    public partial class UploadLoaiChamSoc : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        public static DataRow dr;
        public UploadLoaiChamSoc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Excell|*.xls;*.xlsx;";
            DialogResult dr1 = od.ShowDialog();
            if (dr1 == DialogResult.Abort)
                return;
            if (dr1 == DialogResult.Cancel)
                return;
            textBox1.Text = od.FileName.ToString();
            string sexcelconnectionstring = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + textBox1.Text + ";extended properties=" + "\"excel 12.0;hdr=yes;\"";
            string myexceldataquery = "Select * from [tong hop$]";
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myexceldataquery, oledbconn);
            myDataAdapter.Fill(dt1);
            dgvData.DataSource = dt1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int[] arrNumber = { 546, 564, 594, 272, 632, 212, 214, 302, 44, 46, 92, 94, 117, 119, 507, 579 };
            //int[] arrNumber = {24,26,36,46,48,56,58,74,78,94,96,104,106,119,121,133,146,148,163,177,195,197,206,214,216,230,232,243,259,274,276,289,291,304,321,323,331,339,341
            //,358,371,386,401,403,412,420,422,437,452,459,466,483,509,530,548,566,581,594,596,598,610,612,622,634,636,638,651,653,655,670,672,674,688,708
            //,710,712,721,723,725,735,745,764,778,780,782,784,794,804,806,814,816,826,828,835,843,845,855,857,859,861,863,870,877,885,892,894,896,906,908
            //,927,929,931,941,943,945,959,961,968,970,982,991,1010,1012,1014,1016,1018,1020,1022,1041,1043,1060,1077,1092,1094,1110,1127,1138,1140,1142
            //,1155,1157,1164,1171,1173,1183,1185,1192,1200,1202,1227,1229,1231,1233,1251,1253,1255,1257,1259,1267,1269,1271,1283,1286,1288,1290,1292
            //,1300,1302,1304,1306,1308,1334,1360,1379,1401,1420,1437,1456,1473,1489,1508,1510,1512,1529,1531,1533,1551,1570,1594,1611,1621};
            foreach (int i in arrNumber)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sql1 = "[PRC_UPDATE_LoaiChamSoc_Excel] " //update Cây xanh
                    + "'" + dgvData.Rows[i].Cells[0].Value.ToString()
                    + "', " + dgvData.Rows[i].Cells[3].Value.ToString()
                    + ", " + dgvData.Rows[i].Cells[4].Value.ToString()
                    + ", " + dgvData.Rows[i].Cells[5].Value.ToString()
                    + ", " + dgvData.Rows[i].Cells[6].Value.ToString() + "";
                    SqlCommand command4 = new SqlCommand(sql1, conn);
                    command4.ExecuteScalar();

                }
                catch
                {

                }
            }
            MessageBox.Show("Cập nhật dữ liệu chăm sóc thành công", "Thông báo");
            this.Close();
            QLHTDT.FormPhanHe.CayXanh.QuanLyLoaiChamSoc frm = new QLHTDT.FormPhanHe.CayXanh.QuanLyLoaiChamSoc();
            frm.Show();
            Cursor = Cursors.Default;
        }
    }
}
