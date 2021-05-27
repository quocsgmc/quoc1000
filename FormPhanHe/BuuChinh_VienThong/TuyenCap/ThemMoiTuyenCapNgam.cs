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
    public partial class ThemMoiTuyenCapNgam : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        public ThemMoiTuyenCapNgam()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }

        private void ThemMoiTuyenCapNgam_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("[PRC_QUERY_TABLE_DOANHNGHIEP]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboDoanhNghiep.DataSource = ds.Tables[0];
            comboDoanhNghiep.DisplayMember = "TenDoanhNghiep";
            comboDoanhNghiep.ValueMember = "IDDoanhNghiep";

            DataSet ds4 = new DataSet();
            SqlDataAdapter adp4 = new SqlDataAdapter("[PRC_QUERY_THIETBIPHUTRO_BY_LOAITB] 4", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
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
                comboPhuong.DataSource = ds2.Tables[0];
                comboPhuong.DisplayMember = "TenPhuong";
                comboPhuong.ValueMember = "MaPhuong";
            }
        }

        private void comboDoanhNghiep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDoanhNghiep.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboDoanhNghiep.Text = "";
            }
        }

        private void comboThietBiPhuTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboThietBiPhuTro.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboThietBiPhuTro.Text = "";
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

        private void button2_Click(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            bool check = true;
            string dateTDLD = null;
            double KDo; double VDo; string TTrang = "null";


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
                    ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("TuyenCapNgam");
                    // tạo mới đối tượng
                    feature = ftClassSDE.CreateFeature();
                    objectid = feature.OID;
                    //cập nhật thuộc tính đối tượng
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sqlShape = "[PRC_UPDATE_SHAPE_TUYENCAPNGAM] '" + objectid + "', 'LINESTRING(";
                    for (int i = 0; i < dgvData.RowCount - 1; i++)
                    {
                        string KinhDo = dgvData.Rows[i].Cells[0].Value.ToString();
                        string ViDo = dgvData.Rows[i].Cells[1].Value.ToString();
                        if (i == dgvData.RowCount - 2)
                        {
                            sqlShape = sqlShape + KinhDo + " " + ViDo +")'";
                        }
                        else
                        {
                            sqlShape = sqlShape + KinhDo + " " + ViDo + ",";
                        }
                    }
                    SqlCommand command4 = new SqlCommand(sqlShape, conn);
                    command4.ExecuteScalar();

                    string sql1 = "[PRC_UPDATE_TUYENCAPNGAM] "
                       + " '" + objectid
                        + "', N'" + txtDiemDau.Text
                        + "', N'" + txtDiemCuoi.Text
                        + "', N'" + txtHuongTuyen.Text
                        + "', " + DoanhNghiep
                        + ", N'" + txtDungLuongCap.Text
                        + "', N'" + txtGhiChu.Text
                        + "', " + TTrang
                        + ", N'" + txtCongVanPD.Text
                        + "', N'" + txtLoaiCap.Text
                        + "'," + Phuong
                        + ", " + TBPT
                        + ", " + LoaiCTHT + "";
                    SqlCommand command5 = new SqlCommand(sql1, conn);
                    command5.ExecuteScalar();
                    BuuChinh_VienThong.TuyenCap.QuanLyTuyenCapNgam.LoadLaiForm = 1;
                    MessageBox.Show("Thêm mới Tuyến cáp ngầm thành công", "Thông báo");
                    this.Hide(); Cursor = Cursors.Default;
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Thêm mới Tuyến cáp ngầm thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }

                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;

            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
