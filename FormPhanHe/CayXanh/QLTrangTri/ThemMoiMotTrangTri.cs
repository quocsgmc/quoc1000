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

namespace QLHTDT.FormPhanHe.CayXanh.QLTrangTri
{
    public partial class ThemMoiMotTrangTri : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        public ThemMoiMotTrangTri()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        void LoadDatabase(string Query, ComboBox Combobox, string DisplayMember, string ValueMember)
        {
            SqlDataAdapter adp = new SqlDataAdapter(Query, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Combobox.DataSource = ds.Tables[0];
            Combobox.DisplayMember = DisplayMember;
            Combobox.ValueMember = ValueMember;
        }
        private void ThemMoiMotTrangTri_Load(object sender, EventArgs e)
        {
            comboHeToaDo.Text = "VN2000";

            LoadDatabase("PRC_Query_TenHuyen_By_MAHuyen null", comboQuan, "TENHUYEN", "MAHUYEN");
            LoadDatabase("PRC_QUERY_DUONGCHINH", comboTenDuong, "TenDuong", "OBJECTID");
            LoadDatabase("PRC_QUERYTABLE_ChungLoaiCayXanh", comboTenChungLoai, "TenChungLoaiCay", "IDChungLoaiCay");
            LoadDatabase("PRC_QUERYTABLE_DonViQLCX", comboDonViQL, "TenDonVi", "IDDVQLCX");
            LoadDatabase("PRC_QUERYTABLE_CONGVIEN", comboCongVien, "TenCongVien", "OBJECTID");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            bool check = true;
            string DTich = "null"; double DienTich;
            double KDo; double VDo;
            //check dữ liệu nhập vào
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
                MessageBox.Show("Sai định dạng dữ liệu Vĩ độ!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                check = false; Cursor = Cursors.Default; return;
            }
            isNumeric = true;

            if (txtDienTich.Text != "")
            {
                DTich = txtDienTich.Text;
                if (double.TryParse(DTich, out DienTich))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Chiều cao!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    check = false; Cursor = Cursors.Default; return;
                }
                isNumeric = true;
            }

            string TenDuong = "null";
            string Phuong = "null";
            string CongVien = "null";
            string ChungLoai = "null";
            string DonViQL = "null";
            if (comboTenDuong.Text != "")
            {
                TenDuong = comboTenDuong.SelectedValue.ToString();
            }
            if (comboPhuong.Text != "")
            {
                Phuong = comboPhuong.SelectedValue.ToString();
            }
            if (comboCongVien.Text != "")
            {
                CongVien = comboCongVien.SelectedValue.ToString();
            }
            if (comboTenChungLoai.Text != "")
            {
                ChungLoai = comboTenChungLoai.SelectedValue.ToString();
            }
            if (comboDonViQL.Text != "")
            {
                DonViQL = comboDonViQL.SelectedValue.ToString();
            }
            if (check != false)
            {
                try
                {
                    if (comboHeToaDo.Text == "VN2000")
                    {
                        ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("CAYTRANGTRI");
                        // tạo mới đối tượng
                        feature = ftClassSDE.CreateFeature();
                        objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_CAYTRANGTRI_XY_BY_ID] " //update Cây trang trí
                             + " '" + objectid
                             + "', N'" + txtMaCay.Text
                             + "', " + DTich
                             + ", N'" + txtHienTrang.Text
                             + "', N'" + comboLoaiCay.Text
                             + "', " + TenDuong
                             + ", " + Phuong
                             + ", " + CongVien
                             + ", " + ChungLoai
                             + ", " + DonViQL
                             + ", '" + KDo
                             + "', '" + VDo
                             + "','Point(" + VDo + " " + KDo + ")'";

                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        MessageBox.Show("Thêm mới Cây trang trí thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                        QLHTDT.FormPhanHe.CayXanh.QuanLyTrangTri.QuanLyTrangTri.LoadLaiForm = 1;
                    }
                    else
                    {
                        ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("CAYTRANGTRI");
                        // tạo mới đối tượng
                        feature = ftClassSDE.CreateFeature();
                        objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_CAYTRANGTRI_BY_ID] " //update Cây trang trí
                            + " '" + objectid
                            + "', N'" + txtMaCay.Text
                            + "', " + DTich
                            + ", N'" + txtHienTrang.Text
                            + "', N'" + comboLoaiCay.Text
                            + "', " + TenDuong
                            + ", " + Phuong
                            + ", " + CongVien
                            + ", " + ChungLoai
                            + ", " + DonViQL
                            + ", '" + KDo
                            + "','" + VDo + "'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        MessageBox.Show("Thêm mới Cây trang trí thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                        QLHTDT.FormPhanHe.CayXanh.QuanLyTrangTri.QuanLyTrangTri.LoadLaiForm = 1;
                    }
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Thêm mới Cây xanh thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
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
                LoadDatabase("[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + "", comboPhuong, "TenPhuong", "MaPhuong");
                if (comboPhuong.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    comboPhuong.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboTenDuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTenDuong.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboTenDuong.Text = "";
            }
        }

        private void comboDonViQL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDonViQL.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboDonViQL.Text = "";
            }
        }

        private void comboTenChungLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTenChungLoai.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboTenChungLoai.Text = "";
            }
        }

        private void comboCongVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCongVien.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboCongVien.Text = "";
            }
        }
    }
}
