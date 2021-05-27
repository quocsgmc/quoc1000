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
    public partial class ChinhSuaMotDaiLy : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua;
        public ChinhSuaMotDaiLy(int OBJECTID)
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
            IDChinhSua = OBJECTID;
        }

        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ChinhSuaMotDaiLy_Load(object sender, EventArgs e)
        {
            comboHeToaDo.Text = "VN2000";

            SqlDataAdapter adp = new SqlDataAdapter("[PRC_QUERY_TABLE_CHUDAILYINTERNET]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboTenChuDaiLy.DataSource = ds.Tables[0];
            comboTenChuDaiLy.DisplayMember = "TenChuDaiLy";
            comboTenChuDaiLy.ValueMember = "ID";

            SqlDataAdapter adp2 = new SqlDataAdapter("[PRC_QUERY_TABLE_NhaMang]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            CboboxNhaMang.DataSource = ds2.Tables[0];
            CboboxNhaMang.DisplayMember = "TenNhaMang";
            CboboxNhaMang.ValueMember = "ID";


            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERYTABLEDaiLyINTERNET_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                txtTenDaiLy.Text = ds3.Tables[0].Rows[0]["TenDaiLy"].ToString();
                txtKinhDo.Text = ds3.Tables[0].Rows[0]["KinhDo"].ToString().Replace(",", ".");
                txtViDo.Text = ds3.Tables[0].Rows[0]["ViDo"].ToString().Replace(",", ".");
                comboTenChuDaiLy.Text = ds3.Tables[0].Rows[0]["TenChuDaiLy"].ToString();
                txtDiaChi.Text = ds3.Tables[0].Rows[0]["DiaChi"].ToString();
                comboQuan.Text = ds3.Tables[0].Rows[0]["QuanHuyen"].ToString();
                comboPhuong.Text = ds3.Tables[0].Rows[0]["TenPhuong"].ToString();
                dateTimePickerNgayCD.Text = ds3.Tables[0].Rows[0]["NgayCaiDat"].ToString();
                dateTPNgayCapGP.Text = ds3.Tables[0].Rows[0]["NgayCapGPKD"].ToString();
                txtPhienBan.Text = ds3.Tables[0].Rows[0]["PhienBan"].ToString();
                txtSoGPKD.Text = ds3.Tables[0].Rows[0]["SoGPKD"].ToString();
                txtSoMay.Text = ds3.Tables[0].Rows[0]["SoMay"].ToString();
                txtGhiChu.Text = ds3.Tables[0].Rows[0]["GhiChu"].ToString();
                CboboxNhaMang.Text = ds3.Tables[0].Rows[0]["TenNhaMang"].ToString();
                //CboboxTinhTrang.Text = ds3.Tables[0].Rows[0]["TinhTrang"].ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            bool check = true;
            string dateCP = null;
            string dateCD = null;
            double KDo; double VDo; int? TTrang;
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
                        objectid = IDChinhSua;
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_DaiLyInternet_XY_BY_ID] "
                           + " '" + objectid
                            + "', N'" + txtTenDaiLy.Text
                            + "', N'" + txtDiaChi.Text
                            + "', '" + txtKinhDo.Text
                            + "', '" + txtViDo.Text
                            + "', " + NhaMang
                            + ", " + SMay
                            + ", N'" + txtGhiChu.Text
                            + "', " + ChuDaiLy
                            + ", N'" + txtSoGPKD.Text
                            + "', '" + dateCP
                            + "', '" + dateCD
                            + "', N'" + txtPhienBan.Text
                            + "', " + Phuong
                            + ", 'Point(" + txtViDo.Text + " " + txtKinhDo.Text + ")'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        MessageBox.Show("Chỉnh sửa Đại lý Internet thành công", "Thông báo");
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ChinhSuathuoctinhToolQuanLy("Đại lý Internet", objectid);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                        this.Hide();
                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        objectid = IDChinhSua;
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_DaiLyInternet_BY_ID] "
                              + " '" + objectid
                            + "', N'" + txtTenDaiLy.Text
                            + "', N'" + txtDiaChi.Text
                            + "', '" + txtKinhDo.Text
                            + "', '" + txtViDo.Text
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
                        MessageBox.Show("Chỉnh sửa Đại lý Internet thành công", "Thông báo");
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ChinhSuathuoctinhToolQuanLy("Đại lý Internet", objectid);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                        this.Hide();
                        Cursor = Cursors.Default;
                    }

                }
                catch
                {
                    if (feature != null)
                    { feature.Delete(); }
                    MessageBox.Show("Chỉnh sửa Đại lý Internet thất bại. Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }
                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }
        }

        private void comboTenChuDaiLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTenChuDaiLy.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboTenChuDaiLy.Text = "";
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

        private void comboTenNhaMang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboboxNhaMang.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                CboboxNhaMang.Text = "";
            }
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
