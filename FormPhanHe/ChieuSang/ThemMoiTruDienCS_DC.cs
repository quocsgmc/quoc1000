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

namespace QLHTDT.FormPhanHe.ChieuSang
{
    public partial class ThemMoiTruDienCS_DC : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.ChieuSang.QuanLyTruDienCS_DC.ID1;
        string dateTGT = "null";
        public ThemMoiTruDienCS_DC()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ThemMoiTruDienCS_DC_Load(object sender, EventArgs e)
        {
            comboHeToaDo.Text = "VN2000";


            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

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
            bool isNumeric;
            double KDo; double VDo;
          

            if (isNumeric = double.TryParse(txtToaDoY.Text, out KDo))
            { }
            else
            {
                MessageBox.Show("Sai định dạng dữ liệu Kinh độ!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                check = false; Cursor = Cursors.Default; return;
            }

            isNumeric = true;
            if (isNumeric = double.TryParse(txtToaDoX.Text, out VDo))
            { }
            else
            {
                MessageBox.Show("Sai định dạng dữ liệu Vi độ!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                check = false; Cursor = Cursors.Default; return;
            }
            if (dateTimePickerTGT.Text == "01 Tháng Giêng 2000")
            {

                DialogResult dialogResult = MessageBox.Show("Chưa nhập Thời gian thay!\n" + "Có muốn tiếp tục hay không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dateTGT = "null";
                }
                else if (dialogResult == DialogResult.No)
                {
                    check = false; Cursor = Cursors.Default; return;
                }
            }
            else { dateTGT = dateTimePickerTGT.Value.ToString("MM/dd/yyyy"); }
            string Phuong = "null";
            string TuyenDay = "null";
            if (comboPhuong.Text != "")
            {
                Phuong = comboPhuong.SelectedValue.ToString();
            }
            if (comboTuyenDay.Text != "")
            {
                TuyenDay = comboTuyenDay.SelectedValue.ToString();
            }
            if (check != false)
            {
                try
                {
                    if (comboHeToaDo.Text == "VN2000")
                    {
                        //ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("TRUDIENCSDC");
                        //// tạo mới đối tượng
                        //feature = ftClassSDE.CreateFeature();
                        //objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();

                        string sql1 = "[PRC_INSERT_TRUDIENCSDC] "
                            + " N'" + txtTenTru.Text
                            + "', N'" + txtDiaChi.Text
                            + "', N'" + txtLoaiTru.Text
                            + "', N'" + txtLoaiBong.Text
                            + "', " + dateTGT
                               + ", '" + VDo
                               + "', '" + KDo
                            + "', N'" + txtGhiChu.Text
                            + "', " + TuyenDay
                            + ", " + Phuong
                            + ", 'Point(" + VDo + " " + KDo + ")'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        MessageBox.Show("Thêm mới Trụ điện chiếu sáng thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                    }
                    else
                    {
                        //ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("TRUDIENCSDC");
                        //// tạo mới đối tượng
                        //feature = ftClassSDE.CreateFeature();
                        //objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();

                        string sql1 = "[PRC_INSERT_TRUDIENCSDC_WGS84] "
                            + " N'" + txtTenTru.Text
                            + "', N'" + txtDiaChi.Text
                            + "', N'" + txtLoaiTru.Text
                            + "', N'" + txtLoaiBong.Text
                            + "', " + dateTGT
                               + "', '" + VDo
                               + "', '" + KDo
                            + ", N'" + txtGhiChu
                            + "', " + TuyenDay
                            + "', " + Phuong+ "'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();

                        MessageBox.Show("Thêm mới Trụ điện chiếu sáng thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                        QLHTDT.FormPhanHe.ChieuSang.QuanLyTruDienCS2.LoadLaiForm = 1;
                    }
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Chỉnh sửa Trụ điện chiếu sáng thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
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
                comboPhuong.DataSource = ds2.Tables[0];
                comboPhuong.DisplayMember = "TenPhuong";
                comboPhuong.ValueMember = "MaPhuong";
            }
        }
        
    }
}
