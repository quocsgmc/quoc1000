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

namespace QLHTDT.FormPhanHe.HoChua.ThemMoi
{
    public partial class ThemMoiTongHop : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.HoChua.QuanlyHoChua.QuanlyHoChua.ID1;
        public ThemMoiTongHop()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ChinhSuaDapChuaNuoc_Load(object sender, EventArgs e)
        {

            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            SqlDataAdapter adp2 = new SqlDataAdapter("Select TenCongTrinh,IDHo from HOCHUA", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            comboBox1.DataSource = ds2.Tables[0];
            comboBox1.DisplayMember = "TenCongTrinh";
            comboBox1.ValueMember = "IDHo";
            comboHoChua.DataSource = ds2.Tables[0];
            comboHoChua.DisplayMember = "TenCongTrinh";
            comboHoChua.ValueMember = "IDHo";
            comboBox2.DataSource = ds2.Tables[0];
            comboBox2.DisplayMember = "TenCongTrinh";
            comboBox2.ValueMember = "IDHo";

            SqlDataAdapter adp4 = new SqlDataAdapter("Select LoaiKenh,IDLoaiKenh from LOAIKENH", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds4 = new DataSet();
            adp4.Fill(ds4);
            comboLoaiKenh.DataSource = ds4.Tables[0];
            comboLoaiKenh.DisplayMember = "LoaiKenh";
            comboLoaiKenh.ValueMember = "IDLoaiKenh";
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
            //check dữ liệu nhập vào
            string Phuong = "null";
            if (comboPhuong.Text != "")
            {
                Phuong = comboPhuong.SelectedValue.ToString();
            }

            if (check != false)
            {
                //try
                //{
                        ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("HOCHUA");
                        feature = ftClassSDE.CreateFeature();
                        objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_HoChua] "
                           + " " + objectid
                           + ", N'" + textboxTenCongTrinh.Text
                           + "', N'" + textbox01.Text
                           + "', N'" + textbox02.Text
                           + "', N'" + textbox03.Text
                           + "', N'" + textbox04.Text
                           + "', N'" + textbox05.Text
                           + "', N'" + textbox06.Text
                           + "', N'" + textbox07.Text
                           + "', N'" + textbox08.Text
                           + "', " + Phuong + "";
                    SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();

                        MessageBox.Show("Chỉnh sửa Cống lấy nước thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                //}
                //catch
                //{
                //    //xóa đối tượng đã tạo nếu có lỗi
                //    if (feature != null)
                //    { feature.Delete(); }

                //    MessageBox.Show("Chỉnh sửa Cống lấy nước thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                //    Cursor = Cursors.Default;
                //}

                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }
        }

        private void comboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
   
        }
        private void comboQuan_SelectedIndexChanged_1(object sender, EventArgs e)
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

                if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    comboPhuong.Text = "";
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            bool check = true;
            string dateCP = null;
            string dateGCN = null;
            string HoChua = "null";
            if (comboHoChua.Text != "")
            {
                HoChua = comboHoChua.SelectedValue.ToString();
            }
            string LoaiKenh = "null";
            if (comboLoaiKenh.Text != "")
            {
                LoaiKenh = comboLoaiKenh.SelectedValue.ToString();
            }
            if (check != false)
            {
                try
                {
                    ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("KENHCHINH");
                    feature = ftClassSDE.CreateFeature();
                    objectid = feature.OID;
                    //cập nhật thuộc tính đối tượng
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sql1 = "[PRC_UPDATE_KenhChinh] "
                       + " '" + objectid
                       + "'," + HoChua
                       + ", N'" + textBox4.Text
                       + "', N'" + textBox5.Text
                       + "', N'" + textBox3.Text
                       + "', N'" + textBox1.Text
                       + "', N'" + textBox7.Text
                       + "', N'" + textBox6.Text
                       + "', N'" + textBox2.Text
                       + "', N'" + textbox09.Text
                       + "'," + LoaiKenh + "";
                    SqlCommand command4 = new SqlCommand(sql1, conn);
                    command4.ExecuteScalar();

                    MessageBox.Show("Chỉnh sửa Kênh chính thành công", "Thông báo");
                    this.Hide(); Cursor = Cursors.Default;
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Chỉnh sửa Kênh chính thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }

                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            bool check = true;
            //check dữ liệu nhập vào
            string HoChua = "null";
            if (comboBox1.Text != "")
            {
                HoChua = comboBox1.SelectedValue.ToString();
            }

            if (check != false)
            {
                try
                {
                    ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("DAPHOCHUA");
                    feature = ftClassSDE.CreateFeature();
                    objectid = feature.OID;
                    //cập nhật thuộc tính đối tượng
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sql1 = "[PRC_UPDATE_DapHoChua] "
                       + " '" + objectid
                       + "', " + HoChua
                       + ", N'" + textBox12.Text
                       + "', N'" + textBox11.Text
                       + "', N'" + textBox10.Text
                       + "', N'" + textBox14.Text
                       + "', N'" + textBox13.Text
                       + "', N'" + textBox9.Text
                       + "', N'" + textBox8.Text + "'";
                    SqlCommand command4 = new SqlCommand(sql1, conn);
                    command4.ExecuteScalar();

                    MessageBox.Show("Chỉnh sửa Đập hồ chứa thành công", "Thông báo");
                    this.Hide(); Cursor = Cursors.Default;
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Chỉnh sửa Đập hồ chứa thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }

                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            bool check = true;
            //check dữ liệu nhập vào
            string HoChua = "null";
            if (comboBox1.Text != "")
            {
                HoChua = comboBox1.SelectedValue.ToString();
            }

            if (check != false)
            {
                try
                {
                    ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("TRAN");
                    feature = ftClassSDE.CreateFeature();
                    objectid = feature.OID;
                    //cập nhật thuộc tính đối tượng
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sql1 = "[PRC_UPDATE_Tran] "
                       + " '" + objectid
                       + "', " + HoChua
                       + ", N'" + textBox15.Text
                       + "', N'" + textBox16.Text
                       + "', N'" + textBox17.Text
                       + "', N'" + textBox18.Text
                       + "', N'" + textBox19.Text + "'";
                    SqlCommand command4 = new SqlCommand(sql1, conn);
                    command4.ExecuteScalar();

                    MessageBox.Show("Chỉnh sửa Tràn chứa thành công", "Thông báo");
                    this.Hide(); Cursor = Cursors.Default;
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }
                    MessageBox.Show("Chỉnh sửa Tràn chứa thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }

                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }
        }
    }
}
