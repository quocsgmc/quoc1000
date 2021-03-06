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

namespace QLHTDT.FormPhanHe.CayXanh.QLThamCo
{
    public partial class ChinhSuaThamCo : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.CayXanh.QuanLyThamCo.QuanLyThamCo.ID1;
        public ChinhSuaThamCo()
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
        private void ChinhSuaThamCo_Load(object sender, EventArgs e)
        {

            LoadDatabase("PRC_Query_TenHuyen_By_MAHuyen null", comboQuan, "TENHUYEN", "MAHUYEN");
            LoadDatabase("PRC_QUERY_DUONGCHINH",comboTenDuong,"TenDuong","OBJECTID");
            LoadDatabase("PRC_QUERYTABLE_ChungLoaiCayXanh", comboTenChungLoai, "TenChungLoaiCay", "IDChungLoaiCay");
            LoadDatabase("PRC_QUERYTABLE_DonViQLCX", comboDonViQL, "TenDonVi", "IDDVQLCX");
            LoadDatabase("PRC_QUERYTABLE_CONGVIEN", comboCongVien, "TenCongVien", "OBJECTID");

            //Thêm load thuộc tính vào bảng
            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp6 = new SqlDataAdapter("[PRC_QUERYThamCo_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds6 = new DataSet();
                adp6.Fill(ds6);
                comboTenDuong.Text = ds6.Tables[0].Rows[0]["TenDuong"].ToString();
                comboQuan.Text = ds6.Tables[0].Rows[0]["QuanHuyen"].ToString();
                comboPhuong.Text = ds6.Tables[0].Rows[0]["TenPhuong"].ToString();
                comboCongVien.Text = ds6.Tables[0].Rows[0]["TenCongVien"].ToString();
                txtMaCay.Text = ds6.Tables[0].Rows[0]["MaThamCo"].ToString();
                txtDienTich.Text = ds6.Tables[0].Rows[0]["DienTich"].ToString();
                txtHienTrang.Text = ds6.Tables[0].Rows[0]["HienTrang"].ToString();
                comboTenChungLoai.Text = ds6.Tables[0].Rows[0]["TenChungLoaiCay"].ToString();
                comboDonViQL.Text = ds6.Tables[0].Rows[0]["TenDonVi"].ToString();
                //comboLoaiCay.Text = ds6.Tables[0].Rows[0]["LoaiCay"].ToString();
            }
        }
        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            bool check = true;
            string DTich = "null"; double DienTich;
            double KDo; double VDo; double Dcao;
            //check dữ liệu nhập vào
            bool isNumeric;
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
                        objectid = IDChinhSua;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_THAMCO_BY_ID] " //update Cây trang trí
                            + " '" + objectid
                            + "', " + Phuong
                            + ", " + CongVien
                            + ", N'" + txtMaCay.Text
                            + "', " + DTich
                            + ", " + TenDuong
                            + ", N'" + txtHienTrang.Text
                            + "', " + ChungLoai
                            + ", " + DonViQL+ "";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        MessageBox.Show("Chỉnh sửa Thảm cỏ thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                        QLHTDT.FormPhanHe.CayXanh.QuanLyTrangTri.QuanLyTrangTri.LoadLaiForm = 1;
                }
                catch
                {

                    MessageBox.Show("Chỉnh sửa Thảm cỏ thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
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

        private void comboTenChungLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTenChungLoai.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboTenChungLoai.Text = "";
            }
        }
    }
}
