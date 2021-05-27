using DevExpress.XtraGrid.Views.Base;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using QLHTDT.FormChinh;
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

namespace QLHTDT.FormPhanHe.Dat5PhanTram
{
    public partial class ChinhSuaDat5PhanTram : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int ID = QLHTDT.FormPhanHe.Dat5PhanTram.QuanlyDat5PhanTram.QuanlyDat5PhanTram.ID1;
        string IDPhuong = "null";
        public ChinhSuaDat5PhanTram()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ChinhSuaDat5PhanTram_Load(object sender, EventArgs e)
        {

            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            if (ID != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_TABLE_Dat5PhanTram_By_ID] " + ID + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                textBox1.Text = ds3.Tables[0].Rows[0]["SOTO"].ToString();
                textBox2.Text = ds3.Tables[0].Rows[0]["SOTHUA"].ToString();
                textBox3.Text = ds3.Tables[0].Rows[0]["SOHOPDONG"].ToString();
                textBox4.Text = ds3.Tables[0].Rows[0]["DIACHI"].ToString();
                textBox5.Text = ds3.Tables[0].Rows[0]["DIENTICH"].ToString();
                textBox6.Text = ds3.Tables[0].Rows[0]["THOIHAN"].ToString();
                textBox7.Text = ds3.Tables[0].Rows[0]["MDSD"].ToString();
                textBox8.Text = ds3.Tables[0].Rows[0]["GIATHUE"].ToString();
                textBox9.Text = ds3.Tables[0].Rows[0]["HINHTHUCNOPTIEN"].ToString();
                textBox10.Text = ds3.Tables[0].Rows[0]["NOINOPTIEN"].ToString();
                comboBox1.Text = ds3.Tables[0].Rows[0]["TINHTRANG"].ToString();
                dateTimeNgayKyHD.Text = ds3.Tables[0].Rows[0]["NGAYKYHD"].ToString();
                dateTimePickerTGTTT.Text = ds3.Tables[0].Rows[0]["THOIGIANTINHTIENTHUE"].ToString();
                comboQuan.Text = ds3.Tables[0].Rows[0]["QuanHuyen"].ToString();
                comboPhuong.Text = ds3.Tables[0].Rows[0]["TenPhuong"].ToString();
                IDPhuong = ds3.Tables[0].Rows[0]["MaXa"].ToString();
            }
        }
        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            bool check = true;
            string dateNgayKyHD = null;
            string dateTGTTT = null;
            double SoTo; double SoThua; double SoHD;
            //check dữ liệu nhập vào
            bool isNumeric;
            if (isNumeric = double.TryParse(textBox1.Text, out SoTo))
            { }
            else
            {
                MessageBox.Show("Sai định dạng dữ liệu Số tờ!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                check = false; Cursor = Cursors.Default; return;
            }

            isNumeric = true;
            if (isNumeric = double.TryParse(textBox2.Text, out SoThua))
            { }
            else
            {
                MessageBox.Show("Sai định dạng dữ liệu Số thửa!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                check = false; Cursor = Cursors.Default; return;
            }
            isNumeric = true;

            if (double.TryParse(textBox3.Text, out SoHD))
            { }
            else
            {
                MessageBox.Show("Sai định dạng dữ liệu Số hợp đồng!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                check = false; Cursor = Cursors.Default; return;
            }
            isNumeric = true;


            if (dateTimePickerTGTTT.Text == "01 Tháng Giêng 2000")
            {
                DialogResult dialogResult = MessageBox.Show("Chưa nhập ngày thời gian tính tiền thuế!\n" + "Có muốn tiếp tục hay không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dateTGTTT = null;
                }
                else if (dialogResult == DialogResult.No)
                {
                    check = false; Cursor = Cursors.Default; return;
                }
            }
            else { dateTGTTT = dateTimePickerTGTTT.Value.ToString("MM/dd/yyyy"); }


            if (dateTimeNgayKyHD.Text == "01 Tháng Giêng 2000")
            {

                DialogResult dialogResult = MessageBox.Show("Chưa nhập ngày cấp giấy giấy phép!\n" + "Có muốn tiếp tục hay không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dateTimeNgayKyHD = null;
                }
                else if (dialogResult == DialogResult.No)
                {
                    check = false; Cursor = Cursors.Default; return;
                }
            }
            else { dateNgayKyHD = dateTimeNgayKyHD.Value.ToString("MM/dd/yyyy"); }
            
            string Quan = "null";
            string TinhTrang = "null";
            if (comboQuan.Text != "")
            {
                Quan = comboQuan.SelectedValue.ToString();
            }
            if (comboBox1.Text != "")
            {
                if(comboBox1.Text == "Chưa cho thuê") { TinhTrang = "1"; }
                if (comboBox1.Text == "Đã cho thuê") { TinhTrang = "2"; }
                if (comboBox1.Text == "Chưa xác định") { TinhTrang = "null"; }

            }

            if (check != false)
            {
                try
                {
                    objectid = ID;
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    //cập nhật thuộc tính đối tượng
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_Dat5PhanTram] "
                           + " " + objectid
                           + ", " + SoTo
                           + ", " + SoThua
                           + ", " + SoHD
                           + ", N'" + textBox4.Text
                           + "', '" + dateNgayKyHD
                           + "', " + TinhTrang
                           + ", '" + textBox5.Text
                           + "', N'" + textBox6.Text
                           + "', N'" + textBox7.Text
                           + "', N'" + textBox8.Text
                           + "', '" + dateTGTTT
                           + "', N'" + textBox9.Text
                           + "', N'" + textBox10.Text
                           + "', " + IDPhuong + "";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        MessageBox.Show("Chỉnh sửa hồ sơ thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                    
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Chỉnh sửa hồ sơ thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }

                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }

        }



        private void comboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            comboPhuong.ResetText();
            if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                comboQuan.Text = "";
            }
            if (AddQuan == 1)
            {
                MaHuyen = comboQuan.SelectedValue.ToString();
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + " ";

                SqlDataAdapter adp = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds = new DataSet();
                adp.Fill(ds);
                comboPhuong.DataSource = ds.Tables[0];
                comboPhuong.DisplayMember = "TenPhuong";
                comboPhuong.ValueMember = "MaPhuong";

                if (comboPhuong.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    comboPhuong.Text = "";
                }
            }
        }

        private void comboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDPhuong = comboPhuong.SelectedValue.ToString();
        }
    }
}
