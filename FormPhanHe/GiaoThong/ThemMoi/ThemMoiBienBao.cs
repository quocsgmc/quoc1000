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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.GiaoThong.ThemMoi
{
    public partial class ThemMoiBienBao : Form
    {
        public static string AnhBienBao = null;
        public static string TenBienBao = null;
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.GiaoThong.QuanLyBienBao.QuanLyBienBao.ID1;
        public ThemMoiBienBao()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ThemMoiBienBao_Load(object sender, EventArgs e)
        {
            comboHeToaDo.Text = "VN2000";

            SqlDataAdapter adp2 = new SqlDataAdapter("select TENBIEN,ID from BIENBAOGT_TYPE", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            comboBox2.DataSource = ds2.Tables[0];
            comboBox2.DisplayMember = "TENBIEN";
            comboBox2.ValueMember = "ID";

            SqlDataAdapter adp1 = new SqlDataAdapter("select TenDuong,OBJECTID from DUONGCHINH", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboBox1.DataSource = ds1.Tables[0];
            comboBox1.DisplayMember = "TenDuong";
            comboBox1.ValueMember = "OBJECTID";

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
            string TenDuong = "null";
            //Check dữ liệu đầu vào 
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

            if (comboBox1.Text != "")
            {
                TenDuong = comboBox1.SelectedValue.ToString();
            }
            string LoaiBienBao = "null";
            if (comboBox2.Text != "")
            {
                LoaiBienBao = comboBox2.SelectedValue.ToString();
            }
            if (check != false)
            {
                try
                {
                    if (comboHeToaDo.Text == "VN2000")
                    {
                        //ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("BIENBAOGT");
                        //// tạo mới đối tượng
                        //feature = ftClassSDE.CreateFeature();
                        //objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_INSERT_BIENBAO] "
                            + " " + LoaiBienBao
                            + ", " + textBox1.Text
                            + ", N'" + textBox2.Text
                            + "', N'" + textBox3.Text
                            + "', " + TenDuong
                            + ", '" + VDo
                            + "', '" + KDo
                            + "','Point(" + VDo + " " + KDo + ")'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Biển báo", 0);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                        MessageBox.Show("Thêm mới Biển báo thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                    }
                    else
                    {
                        //ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("BIENBAOGT");
                        //// tạo mới đối tượng
                        //feature = ftClassSDE.CreateFeature();
                        //objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_INSERT_BIENBAO_WGS84] "
                            + " " + LoaiBienBao
                            + ", " + textBox1.Text
                            + ", N'" + textBox2.Text
                            + "', N'" + textBox3.Text
                            + "', " + TenDuong
                            + "', '" + VDo
                            + "', '" + KDo + "'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ThemMoiDoiTuong("Biển báo", 0);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                        MessageBox.Show("Thêm mới Biển báo thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                    }
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }
                    MessageBox.Show("Thêm mới Biển báo thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }
                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }
        }

        private void btMo1_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhanHe.GiaoThong.ChonBienBao frm = new QLHTDT.FormPhanHe.GiaoThong.ChonBienBao();
            frm.ShowDialog();
            frm.Close();
            //if (comboBox2.Text != "")
            //{
                Pic1.Image = Image.FromFile(@"" + AnhBienBao + "");
                Pic1.Visible = true;
                comboBox2.Text = System.IO.Path.GetFileNameWithoutExtension(AnhBienBao);
        
            //}
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            if (comboBox2.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                comboBox2.Text = "";
            }
            //if (AddQuan == 1)
            //{
            //    Pic1.Image = Image.FromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Giao thông\\Layer_BienBao\\" + comboBox2.SelectedValue.ToString() + "\\" + comboBox2.Text + ".png");
            //    Pic1.Visible = true;
            //}
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboBox1.Text = "";
            }
        }
    }
}
