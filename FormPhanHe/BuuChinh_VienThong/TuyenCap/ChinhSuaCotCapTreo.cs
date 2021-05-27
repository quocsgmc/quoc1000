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
    public partial class ChinhSuaCotCapTreo : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyCotCapTreo.ID1;
        public ChinhSuaCotCapTreo()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ChinhSuaCotCapTreo_Load(object sender, EventArgs e)
        {
            comboHeToaDo.Text = "VN2000";

            SqlDataAdapter adp = new SqlDataAdapter("[PRC_QUERY_TABLE_DOANHNGHIEP]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboDonViSoHuu.DataSource = ds.Tables[0];
            comboDonViSoHuu.DisplayMember = "TenDoanhNghiep";
            comboDonViSoHuu.ValueMember = "IDDoanhNghiep";

            DataSet ds2 = new DataSet();
            SqlDataAdapter adp2 = new SqlDataAdapter("[PRC_QUERY_DUONGCHINH]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp2.Fill(ds2);
            comboTenDuong.DataSource = ds2.Tables[0];
            comboTenDuong.DisplayMember = "TenDuong";
            comboTenDuong.ValueMember = "OBJECTID";

            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            DataSet ds5 = new DataSet();
            SqlDataAdapter adp5 = new SqlDataAdapter("[PRC_QUERY_TABLE_LOAICTVT] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp5.Fill(ds5);
            comboCTHT.DataSource = ds5.Tables[0];
            comboCTHT.DisplayMember = "TenLoaiCT";
            comboCTHT.ValueMember = "IDLoaiCT";

            DataSet ds4 = new DataSet();
            SqlDataAdapter adp4 = new SqlDataAdapter("[PRC_QUERY_THIETBIPHUTRO_BY_LOAITB] 2", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp4.Fill(ds4);
            comboThietBiPhuTro.DataSource = ds4.Tables[0];
            comboThietBiPhuTro.DisplayMember = "TenThietBi";
            comboThietBiPhuTro.ValueMember = "IDThietBi";

            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_COTCAP_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                comboTenDuong.Text = ds3.Tables[0].Rows[0]["TenDuong"].ToString();
                txtSoNha.Text = ds3.Tables[0].Rows[0]["SoNha"].ToString();
                txtMaSoCot.Text = ds3.Tables[0].Rows[0]["MaSoCot"].ToString();
                txtLoaiCot.Text = ds3.Tables[0].Rows[0]["LoaiCot"].ToString();
                comboCTHT.Text = ds3.Tables[0].Rows[0]["LoaiCTHT"].ToString();
                comboDonViSoHuu.Text = ds3.Tables[0].Rows[0]["TenDonViSoHuu"].ToString();
                txtGhiChu.Text = ds3.Tables[0].Rows[0]["GhiChu"].ToString();
                comboTrangThai.Text = ds3.Tables[0].Rows[0]["TinhTrang"].ToString();
                comboQuan.Text = ds3.Tables[0].Rows[0]["QuanHuyen"].ToString();
                comboPhuong.Text = ds3.Tables[0].Rows[0]["TenPhuong"].ToString();
                txtChieuCao.Text = ds3.Tables[0].Rows[0]["ChieuCao"].ToString();
                dateTimePickerThoiDiemLapDat.Text = ds3.Tables[0].Rows[0]["ThoiDiemLapDat"].ToString();
                comboThietBiPhuTro.Text = ds3.Tables[0].Rows[0]["TenThietBi"].ToString();
                txtKhaNangChiuLuc.Text = ds3.Tables[0].Rows[0]["KhaNangChiuLuc"].ToString();
                txtKinhDo.Text = ds3.Tables[0].Rows[0]["KinhDo"].ToString();
                txtViDo.Text = ds3.Tables[0].Rows[0]["ViDo"].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
        
        private void comboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboDonViSoHuu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDonViSoHuu.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboDonViSoHuu.Text = "";
            }
        }

        private void comboTenDuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTenDuong.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboTenDuong.Text = "";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            bool check = true;
            string dateTDLD = null;
            double KDo; double VDo; string TTrang = "null";
            string CCao = "null"; double ChieuCao;
            string LCot = "null"; double LoaiCot;
            bool isNumeric;
            if (isNumeric = double.TryParse(txtKinhDo.Text, out KDo))
            { }
            else
            {
                MessageBox.Show("Sai định dạng dữ liệu Kinh độ!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                check = false; Cursor = Cursors.Default; return;
            }
            isNumeric = true;
            if (isNumeric = double.TryParse(txtViDo.Text, out VDo))
            { }
            else
            {
                MessageBox.Show("Sai định dạng dữ liệu Vi độ!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                check = false; Cursor = Cursors.Default; return;
            }

            if (txtLoaiCot.Text != "")
            {
                LCot = txtLoaiCot.Text;
                if (double.TryParse(LCot, out LoaiCot))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Loại cột!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    check = false; Cursor = Cursors.Default; return;
                }
                isNumeric = true;
            }
            if (txtChieuCao.Text != "")
            {
                CCao = txtChieuCao.Text;
                if (double.TryParse(CCao, out ChieuCao))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Chiều cao!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    check = false; Cursor = Cursors.Default; return;
                }
                isNumeric = true;
            }

            if (comboTrangThai.Text == "Hư hỏng")
            { TTrang = "1"; }
            else if (comboTrangThai.Text == "Bình thường")
            { TTrang = "0"; }
            else TTrang = "null";

            if (dateTimePickerThoiDiemLapDat.Text == "01 Tháng Giêng 2000")
            {
                DialogResult dialogResult = MessageBox.Show("Chưa nhập ngày cấp giấy chứng nhận!\n" + "Có muốn tiếp tục hay không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dateTDLD = null;
                }
                else if (dialogResult == DialogResult.No)
                {
                    check = false; Cursor = Cursors.Default; return;
                }
            }
            else { dateTDLD = dateTimePickerThoiDiemLapDat.Value.ToString("MM/dd/yyyy"); }

            string DVSH = "null";
            string TenDuong = "null";
            string Phuong = "null";
            string LoaiCTHT = "null";
            string TBPT = "null";

            if (comboDonViSoHuu.Text != "")
            {
                DVSH = comboDonViSoHuu.SelectedValue.ToString();
            }
            if (comboTenDuong.Text != "")
            {
                TenDuong = comboTenDuong.SelectedValue.ToString();
            }
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

            if (check != false)
            {
                try
                {
                    if (comboHeToaDo.Text == "VN2000")
                    {
                        objectid = IDChinhSua;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_COTCAPTREO_XY] "
                                + " '" + objectid
                                + "', " + TenDuong
                                + ", N'" + txtSoNha.Text
                                + "', N'" + txtMaSoCot.Text
                                + "', " + LCot
                                + ", " + DVSH
                                + ", N'" + txtGhiChu.Text
                                + "', " + TTrang
                                + ", " + Phuong
                                + ", " + CCao
                                + ", '" + dateTDLD
                                + "', " + TBPT
                                + ", N'" + txtKhaNangChiuLuc.Text
                                + "', '" + KDo
                                + "', '" + VDo
                                + "','Point(" + VDo + " " + KDo + ")'";
                        SqlCommand command5 = new SqlCommand(sql1, conn);
                        command5.ExecuteScalar();

                        MessageBox.Show("Cập nhật Cột cáp treo thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                    }
                    else
                    {
                        objectid = IDChinhSua;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_COTCAPTREO] "
                            + " '" + objectid
                             + "', " + TenDuong
                             + ", N'" + txtSoNha.Text
                             + "', N'" + txtMaSoCot.Text
                             + "', " + LCot
                             + ", '" + DVSH
                             + "', N'" + txtGhiChu.Text
                             + "', " + TTrang
                             + ", " + Phuong
                             + ", " + CCao
                             + ", '" + dateTDLD
                             + "', " + TBPT
                             + ", N'" + txtKhaNangChiuLuc.Text
                             + "', '" + KDo
                             + "', '" + VDo + "'";
                        SqlCommand command5 = new SqlCommand(sql1, conn);
                        command5.ExecuteScalar();

                        MessageBox.Show("Cập nhật Cột cáp treo thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                    }
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Cập nhật Cột cáp treo thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }

                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;

            }
        }

        private void comboQuan_SelectedIndexChanged_1(object sender, EventArgs e)
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
        private void comboCTHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCTHT.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboCTHT.Text = "";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboTrangThai_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void comboDonViSoHuu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboDonViSoHuu.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboDonViSoHuu.Text = "";
            }
        }
    }
}
