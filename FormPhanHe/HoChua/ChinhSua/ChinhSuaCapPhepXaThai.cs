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
    public partial class ChinhSuaCapPhepXaThai : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.HoChua.QuanlyCapPhepXaThai.QuanlyCapPhepXaThai.ID1;
        public ChinhSuaCapPhepXaThai()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ChinhSuaCapPhepXaThai_Load(object sender, EventArgs e)
        {

            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";
  
            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_TABLE_CapPhepXaThai_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                textbox01.Text = ds3.Tables[0].Rows[0]["DVXinCP"].ToString();
                textbox04.Text = ds3.Tables[0].Rows[0]["NgNuocTNhanNThai"].ToString();
                textbox03.Text = ds3.Tables[0].Rows[0]["ViTriXa"].ToString();
                textbox06.Text = ds3.Tables[0].Rows[0]["PhuongThucXa"].ToString();
                textbox07.Text = ds3.Tables[0].Rows[0]["CheDoXT"].ToString();
                textbox08.Text = ds3.Tables[0].Rows[0]["LuuLuongTB"].ToString();
                textbox09.Text = ds3.Tables[0].Rows[0]["LuuLuongMax"].ToString();
                textbox13.Text = ds3.Tables[0].Rows[0]["ChatLuong"].ToString();
                textbox10.Text = ds3.Tables[0].Rows[0]["ThoiHan"].ToString();
                textbox12.Text = ds3.Tables[0].Rows[0]["TinhTrang"].ToString();
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
                        string sql1 = "[PRC_UPDATE_CapPhepXaThai] "
                           + " '" + objectid
                           + "', N'" + textbox01.Text
                           + "', N'" + textbox04.Text
                           + "', N'" + textbox03.Text
                           + "', N'" + textbox06.Text
                           + "', N'" + textbox07.Text
                           + "', N'" + textbox08.Text
                           + "', N'" + textbox09.Text
                           + "', N'" + textbox13.Text
                           + "', N'" + textbox10.Text
                           + "', N'" + textbox12.Text
                           + "', '" + dateCP
                           + "', " + Phuong + "";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();

                        MessageBox.Show("Chỉnh sửa Cấp phép xả thải thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Chỉnh sửa Cấp phép xả thải thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
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
