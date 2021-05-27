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

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet
{
    public partial class ThemMoiMotDaiLy : Form
    {
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureWorkspace featureWorkspaceSDE;
        public ThemMoiMotDaiLy()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }

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
            string dateCD = null;
            double KDo; double VDo;
            bool isNumeric;
            if (isNumeric = double.TryParse(txtKinhDo.Text, out KDo))
            { }
            else
            {
                check = false;
                MessageBox.Show("Sai định dạng dữ liệu Kinh độ!\n" + "Vui lòng kiểm tra lại dữ liệu"
                    , "Thông báo");
                Cursor = Cursors.Default;
                return;
            }

            isNumeric = true;
            if (isNumeric = double.TryParse(txtViDo.Text, out VDo))
            { }
            else
            {
                check = false;
                MessageBox.Show("Sai định dạng dữ liệu Vĩ độ!\n" + "Vui lòng kiểm tra lại dữ liệu"
                    , "Thông báo");
                Cursor = Cursors.Default;
                return;
            }
            if (dateTimePickerNgayCD.Text == "01 Tháng Giêng 2000")
            {
                DialogResult dialogResult = MessageBox.Show("Chưa nhập ngày cài đặt đại lý!\n" + "Có muốn tiếp tục hay không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dateCD = null;
                }
                else if (dialogResult == DialogResult.No)
                {
                    check = false; Cursor = Cursors.Default; return;
                }
            }
            else { dateCD = dateTimePickerNgayCD.Value.ToString("MM/dd/yyyy"); }

            if (dateTPNgayCapGP.Text == "01 Tháng Giêng 2000")
            {
                DialogResult dialogResult = MessageBox.Show("Chưa nhập ngày cấp phép xây dựng!\n" + "Có muốn tiếp tục hay không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                { dateCP = null; }
                else if (dialogResult == DialogResult.No)
                { check = false; Cursor = Cursors.Default; return; }
            }
            else { dateCP = dateTPNgayCapGP.Value.ToString("MM/dd/yyyy"); }

            string NhaMang = "null";
            string ChuDaiLy = "null";
            string SMay = "null"; double SoMay;
            string Phuong = "null";

            if (txtSoMay.Text != "")
            {
                SMay = txtSoMay.Text;
                if (double.TryParse(SMay, out SoMay))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Số máy!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    check = false; Cursor = Cursors.Default; return;
                }
                isNumeric = true;
            }
            if (CboboxNhaMang.Text != "")
            {
                NhaMang = CboboxNhaMang.SelectedValue.ToString();
            }
            if (comboTenChuDaiLy.Text != "")
            {
                ChuDaiLy = comboTenChuDaiLy.SelectedValue.ToString();
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
                        ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("DaiLyInternet");
                        feature = ftClassSDE.CreateFeature();
                        objectid = feature.OID;

                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_DaiLyInternet_XY_BY_ID] "
                            + " '" + objectid
                            + "', N'" + txtTenDaiLy.Text
                            + "', N'" + txtDiaChi.Text
                            + "', '" + KDo
                            + "', '" + VDo
                            + "', " + NhaMang
                            + ", " + SMay
                            + ", N'" + txtGhiChu.Text
                            + "', " + ChuDaiLy
                            + ", N'" + txtSoGPKD.Text
                            + "', '" + dateCP
                            + "', '" + dateCD
                            + "', N'" + txtPhienBan.Text
                            + "', " + Phuong
                            + ", 'Point("+ VDo + " "+ KDo + ")'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        this.Close();
                        BuuChinh_VienThong.QuanLyDaiLyInternet2.QuanLyDaiLyInternet2.LoadLaiForm = 1;
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Đại lý Internet", objectid);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);


                        MessageBox.Show("Thêm mới Đại lý Internet thành công", "Thông báo");

                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("DaiLyInternet");
                        feature = ftClassSDE.CreateFeature();
                        objectid = feature.OID;

                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_DaiLyInternet_BY_ID] "
                              + " '" + objectid
                            + "', N'" + txtTenDaiLy.Text
                            + "', N'" + txtDiaChi.Text
                            + "', '" + KDo
                            + "', '" + VDo
                            + "', " + NhaMang
                            + ", " + SMay
                            + ", N'" + txtGhiChu.Text
                            + "', " + ChuDaiLy
                            + ", N'" + txtSoGPKD.Text
                            + "', '" + dateCP
                            + "', '" + dateCD
                            + "', N'" + txtPhienBan.Text
                            + "', " + Phuong + "";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        this.Close();
                        BuuChinh_VienThong.QuanLyDaiLyInternet2.QuanLyDaiLyInternet2.LoadLaiForm = 1;
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Đại lý Internet", objectid);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);


                        MessageBox.Show("Thêm mới Đại lý Internet thành công", "Thông báo");

                        Cursor = Cursors.Default;
                    }

                }
                catch
                {
                    if (feature != null)
                    { feature.Delete(); }
                    MessageBox.Show("Thêm mới Đại lý Internet thất bại. Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }
                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }
        }

        private void ThemMoiMotDaiLy_Load(object sender, EventArgs e)
        {
            comboHeToaDo.Text = "VN2000";

            SqlDataAdapter adp = new SqlDataAdapter("[PRC_QUERY_TABLE_CHUDAILYINTERNET]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboTenChuDaiLy.DataSource = ds.Tables[0];
            comboTenChuDaiLy.DisplayMember = "TenChuDaiLy";
            comboTenChuDaiLy.ValueMember = "ID";


            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            SqlDataAdapter adp2 = new SqlDataAdapter("[PRC_QUERY_TABLE_NhaMang]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            CboboxNhaMang.DataSource = ds2.Tables[0];
            CboboxNhaMang.DisplayMember = "TenNhaMang";
            CboboxNhaMang.ValueMember = "ID";
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
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + comboQuan.SelectedValue.ToString() + " ";

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

        private void comboTenChuDaiLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTenChuDaiLy.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboTenChuDaiLy.Text = "";
            }
        }

        private void CboboxNhaMang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboboxNhaMang.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                CboboxNhaMang.Text = "";
            }
        }
    }
}
