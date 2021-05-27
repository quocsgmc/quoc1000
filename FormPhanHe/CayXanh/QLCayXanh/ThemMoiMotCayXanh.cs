using ESRI.ArcGIS.Geodatabase;
using QLHTDT.FormChinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.CayXanh.QLCayXanh
{
    public partial class ThemMoiMotCayXanh : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        public ThemMoiMotCayXanh()
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
        private void ThemMoiMotCayXanh_Load(object sender, EventArgs e)
        {
            comboHeToaDo.Text = "VN2000";

            LoadDatabase("PRC_Query_TenHuyen_By_MAHuyen null", comboQuan, "TENHUYEN", "MAHUYEN");
            LoadDatabase("PRC_QUERY_DUONGCHINH", comboTenDuong, "TenDuong", "OBJECTID");
            LoadDatabase("PRC_QUERYTABLE_ChungLoaiCayXanh", comboTenChungLoai, "TenChungLoaiCay", "IDChungLoaiCay");
            LoadDatabase("PRC_QUERYTABLE_DonViQLCX", comboDonViQL, "TenDonVi", "IDDVQLCX");
            LoadDatabase("PRC_QUERYTABLE_CONGVIEN", comboCongVien, "TenCongVien", "OBJECTID");
        }
        void NhanComBoBox(ComboBox Combobox, int? GiaTri)
        {
            if(Combobox.Text == ""){GiaTri = null;}
            else{GiaTri = Int32.Parse(Combobox.SelectedValue.ToString());return;}
        }


        void CheckComBoBox(ComboBox Combobox, string BaoLoi, int? GiaTri, bool CheckLoi)
        {
            if (Combobox.Text == "")
            {
                DialogResult dialogResult = MessageBox.Show("Chưa chọn "+BaoLoi+"!\n" + "Có muốn tiếp tục hay không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GiaTri = null;
                }
                else if (dialogResult == DialogResult.No)
                {
                    CheckLoi = false; Cursor = Cursors.Default; return ;
                }
            }
            else
            {
                GiaTri = Int32.Parse(Combobox.SelectedValue.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            bool check = true;
            double KDo; double VDo;
            string CCao = "null"; double ChieuCao;
            string NTrong = "null";  double NamTrong;
            string DKThan = "null"; double DuongKinhThan;
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
                MessageBox.Show("Sai định dạng dữ liệu Vi độ!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                check = false; Cursor = Cursors.Default; return;
            }
            isNumeric = true;
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
            if (txtNamTrong.Text != "")
            {
                NTrong = txtNamTrong.Text;
                if (double.TryParse(NTrong, out NamTrong))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Năm trồng!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    check = false; Cursor = Cursors.Default; return;
                }
                isNumeric = true;
            }
            if (txtDuongKinhThan.Text != "")
            {
                DKThan = txtDuongKinhThan.Text;
                if (double.TryParse(DKThan, out DuongKinhThan))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Đường kính thân!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
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
                        //ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("CAYBONGMAT");
                        ////tạo mới đối tượng
                        //feature = ftClassSDE.CreateFeature();
                        //objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_INSERT_CAYXANH] " //update Cây xanh
                       //+ " '" + objectid
                       //+ "', " + TenDuong
                       + " " + TenDuong
                       + ", " + Phuong
                       + ", " + CongVien
                       + ", N'" + txtSoNha.Text
                       + "', N'" + txtMaCay.Text
                       + "', " + CCao
                       + ", " + DKThan
                       + ", " + NTrong
                       + ", N'" + txtPhanLoai.Text
                       + "', N'" + txtHienTrang.Text
                       + "', " + ChungLoai
                       + ", " + DonViQL
                       + ", N'" + txtGhiChu.Text
                       + "', N'" + comboLoaiCay.Text
                       + "', '" + KDo
                       + "', '" + VDo
                       + "','Point(" + VDo + " " + KDo + ")'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        MessageBox.Show("Thêm mới Cây xanh thành công", "Thông báo");
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Cây xanh bóng mát", 0 ); //objectid
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                        this.Hide(); Cursor = Cursors.Default;
                        QLHTDT.FormPhanHe.CayXanh.QuanLyCayXanh.QuanLyCayXanh.LoadLaiForm = 1;
                    }
                    else
                    {
                        //ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("CAYBONGMAT");
                        //// tạo mới đối tượng
                        //feature = ftClassSDE.CreateFeature();
                        //objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_INSERT_CAYXANH_WGS84] " //update Cây xanh
                                                                      //+ " '" + objectid
                                                                      //+ "', " + TenDuong
                       + " " + TenDuong
                       + ", " + Phuong
                       + ", " + CongVien
                       + ", N'" + txtSoNha.Text
                       + "', N'" + txtMaCay.Text
                       + "', " + CCao
                       + ", " + DKThan
                       + ", " + NTrong
                       + ", N'" + txtPhanLoai.Text
                       + "', N'" + txtHienTrang.Text
                       + "', " + ChungLoai
                       + ", " + DonViQL
                       + ", N'" + txtGhiChu.Text
                       + "', N'" + comboLoaiCay.Text
                       + "', '" + KDo
                       + "', '" + VDo + "'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        MessageBox.Show("Thêm mới Cây xanh thành công", "Thông báo");
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Cây xanh bóng mát", 0);//objectid
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                        this.Hide(); Cursor = Cursors.Default;
                        QLHTDT.FormPhanHe.CayXanh.QuanLyCayXanh.QuanLyCayXanh.LoadLaiForm = 1;
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

        private void comboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
