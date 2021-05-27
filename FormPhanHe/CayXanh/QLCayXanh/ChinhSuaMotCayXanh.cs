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
    public partial class ChinhSuaMotCayXanh : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua;
        //int IDChinhSua = QLHTDT.FormPhanHe.CayXanh.QuanLyCayXanh.QuanLyCayXanh.ID1;
        string IDPhuong = "null";
        public ChinhSuaMotCayXanh(int OBJECTID)
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
            IDChinhSua = OBJECTID;
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
        private void ChinhSuaMotCayXanh_Load(object sender, EventArgs e)
        {
            comboHeToaDo.Text = "VN2000";

            LoadDatabase("PRC_Query_TenHuyen_By_MAHuyen null", comboQuan, "TENHUYEN", "MAHUYEN");
            LoadDatabase("PRC_QUERY_DUONGCHINH",comboTenDuong,"TenDuong","OBJECTID");
            LoadDatabase("PRC_QUERYTABLE_ChungLoaiCayXanh", comboTenChungLoai, "TenChungLoaiCay", "IDChungLoaiCay");
            LoadDatabase("PRC_QUERYTABLE_DonViQLCX", comboDonViQL, "TenDonVi", "IDDVQLCX");
            LoadDatabase("PRC_QUERYTABLE_CONGVIEN", comboCongVien, "TenCongVien", "OBJECTID");

            //Thêm load thuộc tính vào bảng
            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp6 = new SqlDataAdapter("[PRC_QUERYCAYBONGMAT_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds6 = new DataSet();
                adp6.Fill(ds6);
                comboTenDuong.Text = ds6.Tables[0].Rows[0]["TenDuong"].ToString();
                comboQuan.Text = ds6.Tables[0].Rows[0]["QuanHuyen"].ToString();
                comboPhuong.Text = ds6.Tables[0].Rows[0]["TenPhuong"].ToString();
                comboCongVien.Text = ds6.Tables[0].Rows[0]["TenCongVien"].ToString();
                txtSoNha.Text = ds6.Tables[0].Rows[0]["SoNha"].ToString();
                txtMaCay.Text = ds6.Tables[0].Rows[0]["MaCay"].ToString();
                txtChieuCao.Text =ds6.Tables[0].Rows[0]["ChieuCao"].ToString().Replace(",", ".");
                txtDuongKinhThan.Text = ds6.Tables[0].Rows[0]["DuongKinhThan"].ToString().Replace(",", ".");
                txtNamTrong.Text = ds6.Tables[0].Rows[0]["NamTrong"].ToString();
                txtPhanLoai.Text = ds6.Tables[0].Rows[0]["PhanLoai"].ToString();
                txtHienTrang.Text = ds6.Tables[0].Rows[0]["HienTrang"].ToString();
                comboTenChungLoai.Text = ds6.Tables[0].Rows[0]["TenChungLoaiCay"].ToString();
                comboDonViQL.Text = ds6.Tables[0].Rows[0]["TenDonVi"].ToString();
                comboLoaiCay.Text = ds6.Tables[0].Rows[0]["LoaiCay"].ToString();
                txtGhiChu.Text = ds6.Tables[0].Rows[0]["GhiChu"].ToString();
                txtKinhDo.Text = ds6.Tables[0].Rows[0]["ToaDoY"].ToString().Replace(",", ".");
                txtViDo.Text = ds6.Tables[0].Rows[0]["ToaDoX"].ToString().Replace(",", ".");
                IDPhuong = ds6.Tables[0].Rows[0]["IDPhuong"].ToString();
            }
        }
        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn Chỉnh sửa Cây xanh bóng mát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                IFeature feature = null;
                int objectid;
                Cursor = Cursors.WaitCursor;
                bool check = true;
                double KDo; double VDo;
                string CCao = "null"; double ChieuCao;
                string NTrong = "null"; double NamTrong;
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
                if (comboPhuong.Text != "")
                {
                    Phuong = comboPhuong.SelectedValue.ToString();
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
                            string sql1 = "[PRC_UPDATE_CAYXANHBONGMAT_XY_BY_ID] " //update Cây xanh
                               + " '" + objectid
                               + "', " + TenDuong
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
                               + "', '" + txtKinhDo.Text
                               + "', '" + txtViDo.Text
                               + "','Point(" + txtViDo.Text + " " + txtKinhDo.Text + ")'";
                            SqlCommand command4 = new SqlCommand(sql1, conn);
                            command4.ExecuteScalar();
                            //Phần này là lưu nhật ký
                            KienTruc.TBNK = new DataTable();
                            SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                            SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                            KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                            KienTruc.ChinhSuathuoctinhToolQuanLy("Cây xanh bóng mát", objectid);
                            KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                            MessageBox.Show("Chỉnh sửa Cây xanh thành công", "Thông báo");
                            this.Hide(); Cursor = Cursors.Default;
                        }
                        else
                        {
                            objectid = IDChinhSua;
                            //cập nhật thuộc tính đối tượng
                            SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            conn.Open();
                            string sql1 = "[PRC_UPDATE_CAYXANHBONGMAT_BY_ID] " //update Cây xanh
                               + " '" + objectid
                               + "', " + TenDuong
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
                               + "', '" + txtKinhDo.Text
                               + "', '" + txtViDo + "'";
                            SqlCommand command4 = new SqlCommand(sql1, conn);
                            command4.ExecuteScalar();
                            //Phần này là lưu nhật ký
                            KienTruc.TBNK = new DataTable();
                            SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                            SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                            KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                            KienTruc.ChinhSuathuoctinhToolQuanLy("Cây xanh bóng mát", objectid);
                            KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                            MessageBox.Show("Chỉnh sửa Cây xanh thành công", "Thông báo");
                            this.Hide(); Cursor = Cursors.Default;
                        }
                    }
                    catch
                    {

                        MessageBox.Show("Chỉnh sửa Cây xanh thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                        Cursor = Cursors.Default;
                    }

                    QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                    Cursor = Cursors.Default;
                }
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

        private void comboLoaiCay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboTenDuong_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboTenDuong.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboTenDuong.Text = "";
            }
        }

        private void comboCongVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCongVien.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboCongVien.Text = "";
            }
        }

        private void comboDonViQL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDonViQL.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboDonViQL.Text = "";
            }
        }

        private void comboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDPhuong = comboPhuong.SelectedValue.ToString();
        }

        private void txtDuongKinhThan_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtDuongKinhThan.Text, "  ^ [0-9]"))
            {
                txtDuongKinhThan.Text = "";
            }
        }

        private void txtChieuCao_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtChieuCao.Text, "  ^ [0-9]"))
            {
                txtChieuCao.Text = "";
            }
        }
    }
}
