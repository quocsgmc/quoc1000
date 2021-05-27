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

namespace QLHTDT.FormPhanHe.MuongThoatNuoc
{
    public partial class ChinhSuaHoGa : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.MuongThoatNuoc.QuanLyHoGa.QuanLyHoGa.ID1;
        public ChinhSuaHoGa()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ChinhSuaHoGa_Load(object sender, EventArgs e)
        {
            comboHeToaDo.Text = "VN2000";

            SqlDataAdapter adp2 = new SqlDataAdapter("Select TENMUONG,OBJECTID from MUONGTHOATNUOC", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            comboBox2.DataSource = ds2.Tables[0];
            comboBox2.DisplayMember = "TENMUONG";
            comboBox2.ValueMember = "OBJECTID";

            SqlDataAdapter adp1 = new SqlDataAdapter("Select LOAIHOGA,ID from HOGA_TYPE", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboBox1.DataSource = ds1.Tables[0];
            comboBox1.DisplayMember = "LOAIHOGA";
            comboBox1.ValueMember = "ID";

            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_TABLE_HoGa_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                //txtIDTuyen.Text = ds3.Tables[0].Rows[0]["IDTuyen"].ToString();
                textBox1.Text = ds3.Tables[0].Rows[0]["DuongKinh"].ToString();
                textBox2.Text = ds3.Tables[0].Rows[0]["ChieuSau"].ToString();
                comboBox1.Text = ds3.Tables[0].Rows[0]["LOAIHOGA"].ToString();
                comboBox2.Text = ds3.Tables[0].Rows[0]["TENMUONG"].ToString();
                txtKinhDo.Text = ds3.Tables[0].Rows[0]["ToaDoY"].ToString();
                txtViDo.Text = ds3.Tables[0].Rows[0]["ToaDoX"].ToString();
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
            double KDo; double VDo;
            string DKinh = "null"; double DK;
            string CSau = "null"; double CS;
            string LoaiHoGa = "null";
            //Check dữ liệu nhập vào 
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
            if (textBox1.Text != "")
            {
                DKinh = textBox1.Text;
                if (double.TryParse(DKinh, out DK))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Đường kính!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    check = false; Cursor = Cursors.Default; return;
                }
                isNumeric = true;
            }
            if (textBox2.Text != "")
            {
                CSau = textBox2.Text;
                if (double.TryParse(CSau, out CS))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Đường kính!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    check = false; Cursor = Cursors.Default; return;
                }
                isNumeric = true;
            }


            if (comboBox1.Text != "")
            {
                LoaiHoGa = comboBox1.SelectedValue.ToString();
            }
            string TenMuong = "null";
            if (comboBox2.Text != "")
            {
                TenMuong = comboBox2.SelectedValue.ToString();
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
                        string sql1 = "[PRC_UPDATE_HoGa] "
                            + " '" + objectid
                            + "', " + TenMuong
                            + ", " + LoaiHoGa
                            + ", " + DKinh
                            + ", " + CSau
                            + ", '" + KDo
                            + "', '" + VDo
                            + "','Point(" + VDo + " " + KDo + ")'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ChinhSuathuoctinhToolQuanLy("Hố ga", objectid);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                        MessageBox.Show("Chỉnh sửa Hố ga thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                    }
                    else
                    {
                        objectid = IDChinhSua;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_HoGa_WGS] "
                            + " '" + objectid
                            + "', " + TenMuong
                            + ", " + LoaiHoGa
                            + ", " + DKinh
                            + ", " + CSau
                            + ", '" + KDo
                            + "', '" + VDo + "'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ChinhSuathuoctinhToolQuanLy("Hố ga", objectid);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                        MessageBox.Show("Chỉnh sửa Hố ga thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                    }
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }
                    MessageBox.Show("Chỉnh sửa Hố ga thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }
                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }
        }

        
    }
}
