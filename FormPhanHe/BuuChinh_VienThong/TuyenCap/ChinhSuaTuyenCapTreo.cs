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

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap
{
    public partial class ChinhSuaTuyenCapTreo : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyTuyenCapTreo.ID1;
        public ChinhSuaTuyenCapTreo()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ChinhSuaTuyenCapTreo_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("[PRC_QUERY_TABLE_DOANHNGHIEP]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboDoanhNghiep.DataSource = ds.Tables[0];
            comboDoanhNghiep.DisplayMember = "TenDoanhNghiep";
            comboDoanhNghiep.ValueMember = "IDDoanhNghiep";

            DataSet ds4 = new DataSet();
            SqlDataAdapter adp4 = new SqlDataAdapter("[PRC_QUERY_THIETBIPHUTRO_BY_LOAITB] 3", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp4.Fill(ds4);
            comboThietBiPhuTro.DataSource = ds4.Tables[0];
            comboThietBiPhuTro.DisplayMember = "TenThietBi";
            comboThietBiPhuTro.ValueMember = "IDThietBi";

            DataSet ds5 = new DataSet();
            SqlDataAdapter adp5 = new SqlDataAdapter("[PRC_QUERY_TABLE_LOAICTVT] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp5.Fill(ds5);
            comboCTHT.DataSource = ds5.Tables[0];
            comboCTHT.DisplayMember = "TenLoaiCT";
            comboCTHT.ValueMember = "IDLoaiCT";

            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_TuyenCapTreo_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                //txtIDTuyen.Text = ds3.Tables[0].Rows[0]["IDTuyen"].ToString();
                txtDiemDau.Text = ds3.Tables[0].Rows[0]["DiemDau"].ToString();
                txtDiemCuoi.Text = ds3.Tables[0].Rows[0]["DiemCuoi"].ToString();
                txtHuongTuyen.Text = ds3.Tables[0].Rows[0]["HuongTuyen"].ToString();
                comboDoanhNghiep.Text = ds3.Tables[0].Rows[0]["TenDoanhNghiep"].ToString();
                txtDungLuongCap.Text = ds3.Tables[0].Rows[0]["DungLuongCap"].ToString();
                cboxTinhTrang.Text = ds3.Tables[0].Rows[0]["TrangThai"].ToString();
                txtCongVanPD.Text = ds3.Tables[0].Rows[0]["CongVanPheDuyet"].ToString();
                comboThietBiPhuTro.Text = ds3.Tables[0].Rows[0]["ThietBiPhuTro"].ToString();
                txtLoaiCap.Text = ds3.Tables[0].Rows[0]["LoaiCap"].ToString();
                txtGhiChu.Text = ds3.Tables[0].Rows[0]["GhiChu"].ToString();
                comboCTHT.Text = ds3.Tables[0].Rows[0]["LoaiCTHT"].ToString();
                comboQuan.Text = ds3.Tables[0].Rows[0]["QuanHuyen"].ToString();
                comboPhuong.Text = ds3.Tables[0].Rows[0]["TenPhuong"].ToString();
            }

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
            string dateTDLD = null;
            double KDo; double VDo;string TTrang = "null";


            if (cboxTinhTrang.Text == "Hư hỏng")
            { TTrang = "1"; }
            else if (cboxTinhTrang.Text == "Bình thường")
            { TTrang = "0"; }
            else TTrang = "null";

            string Phuong = "null";
            string LoaiCTHT = "null";
            string TBPT = "null";
            string DoanhNghiep = "null";
            if (comboPhuong.Text != "")
            {
                Phuong = comboPhuong.SelectedValue.ToString();
            }
            if (comboCTHT.Text != "")
            {
                LoaiCTHT = comboCTHT.SelectedValue.ToString();
            }
            if (comboThietBiPhuTro.Text != "")
            {
                TBPT = comboThietBiPhuTro.SelectedValue.ToString();
            }
            if (comboDoanhNghiep.Text != "")
            {
                DoanhNghiep = comboDoanhNghiep.SelectedValue.ToString();
            }

            if (check != false)
            {
                try
                {
                    objectid = IDChinhSua;
                    //cập nhật thuộc tính đối tượng
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();

                    string sql1 = "[PRC_UPDATE_TUYENCAPTREO] "
                       + " '" + objectid
                        + "', N'" + txtDiemDau.Text
                        + "', N'" + txtDiemCuoi.Text
                        + "', N'" + txtHuongTuyen.Text
                        + "', " + DoanhNghiep
                        + ", N'" + txtDungLuongCap.Text
                        + "', " + TTrang
                        + ", N'" + txtCongVanPD.Text
                        + "', " + TBPT
                        + ", N'" + txtLoaiCap.Text
                        + "', " + Phuong
                        + ", N'" + txtGhiChu.Text
                        + "', " + LoaiCTHT + "";
                    SqlCommand command4 = new SqlCommand(sql1, conn);
                    command4.ExecuteScalar();

                    MessageBox.Show("Chỉnh sửa Tuyến cáp ngầm thành công", "Thông báo");
                    this.Hide(); Cursor = Cursors.Default;
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Chỉnh sửa Tuyến cáp ngầm thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }

                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;

            }
        }

        private void comboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                comboQuan.Text = "";
            }
            if (AddQuan == 1)
            {
                MaHuyen = comboQuan.SelectedValue.ToString();
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + " ";
                DataSet ds2 = new DataSet();
                SqlDataAdapter adp2 = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                adp2.Fill(ds2);
                comboPhuong.Items.Add("");
                comboPhuong.DataSource = ds2.Tables[0];
                comboPhuong.DisplayMember = "TenPhuong";
                comboPhuong.ValueMember = "MaPhuong";
            }
        }
        int LoaiThietBi = 0;

        private void comboCTHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCTHT.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboCTHT.Text = "";
            }
        }

        private void comboDoanhNghiep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDoanhNghiep.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboDoanhNghiep.Text = "";
            }
        }

        private void cboxTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
