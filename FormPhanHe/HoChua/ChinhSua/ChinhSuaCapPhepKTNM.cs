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

namespace QLHTDT.FormPhanHe.HoChua.ChinhSua
{
    public partial class ChinhSuaCapPhepKTNM : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.HoChua.QuanlyCapPhepKTNM.QuanlyCapPhepKTNM.ID1;
        public ChinhSuaCapPhepKTNM()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ChinhSuaCapPhepKTNM_Load(object sender, EventArgs e)
        {

            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";
  
            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_TABLE_CapPhepKTNM_By_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                textbox01.Text = ds3.Tables[0].Rows[0]["DonViXinCP"].ToString();
                textbox02.Text = ds3.Tables[0].Rows[0]["TenCT"].ToString();
                textbox03.Text = ds3.Tables[0].Rows[0]["ViTri"].ToString();
                textbox04.Text = ds3.Tables[0].Rows[0]["NguonNuocSD"].ToString();
                textbox05.Text = ds3.Tables[0].Rows[0]["CheDoKT"].ToString();
                textbox06.Text = ds3.Tables[0].Rows[0]["LuongKTNgay"].ToString();
                textbox07.Text = ds3.Tables[0].Rows[0]["LuongKTNam"].ToString();
                textbox08.Text = ds3.Tables[0].Rows[0]["PhuongThucKT"].ToString();
                textbox09.Text = ds3.Tables[0].Rows[0]["ThoiHan"].ToString();
                textbox10.Text = ds3.Tables[0].Rows[0]["MDKT"].ToString();
                dateTimePickerCapGP.Text = ds3.Tables[0].Rows[0]["NgayCP"].ToString();
                comboQuan.Text = ds3.Tables[0].Rows[0]["QuanHuyen"].ToString();
                comboPhuong.Text = ds3.Tables[0].Rows[0]["TenPhuong"].ToString();
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
            string dateCP = null;
            string dateGCN = null;
            //check dữ liệu nhập vào

            if (dateTimePickerCapGP.Text == "01 Tháng Giêng 2000")
            {

                DialogResult dialogResult = MessageBox.Show("Chưa nhập ngày cấp giấy giấy phép!\n" + "Có muốn tiếp tục hay không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dateCP = null;
                }
                else if (dialogResult == DialogResult.No)
                {
                    check = false; Cursor = Cursors.Default; return;
                }
            }
            else { dateCP = dateTimePickerCapGP.Value.ToString("MM/dd/yyyy"); }
            string Phuong = "null";
            if (comboPhuong.Text != "")
            {
                Phuong = comboPhuong.SelectedValue.ToString();
            }

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
                           + "', '" + dateCP
                           + "', N'" + textBox1.Text
                           + "', N'" + textbox01.Text
                           + "', N'" + textbox02.Text
                           + "', N'" + textbox10.Text
                           + "', N'" + textbox04.Text
                           + "', N'" + textbox03.Text
                           + "', N'" + textbox05.Text
                           + "', N'" + textbox06.Text
                           + "', N'" + textbox07.Text
                           + "', N'" + textbox08.Text
                            + "', N'" + textbox09.Text
                           + "', " + Phuong + "";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();

                        MessageBox.Show("Chỉnh sửa Cấp phép khai thác nước mặt thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Chỉnh sửa Cấp phép khai thác nước mặt thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
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

                if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    comboPhuong.Text = "";
                }
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
    }
}
