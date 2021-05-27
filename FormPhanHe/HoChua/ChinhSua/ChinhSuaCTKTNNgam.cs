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

namespace QLHTDT.FormPhanHe.HoChua.ChinhSua
{
    public partial class ChinhSuaCTKTNNgam : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.HoChua.QuanlyCapPhepKTNNgam.QuanlyCapPhepKTNNgam.ID1;
        public ChinhSuaCTKTNNgam()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ChinhSuaCTKTNNgam_Load(object sender, EventArgs e)
        {
            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_TABLE_CTKTNNuocNgam_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                textBox1.Text = ds3.Tables[0].Rows[0]["SoGP"].ToString();
                textBox2.Text = ds3.Tables[0].Rows[0]["SoHieuCT"].ToString();
                textBox3.Text = ds3.Tables[0].Rows[0]["ChieuSau"].ToString();
                textBox4.Text = ds3.Tables[0].Rows[0]["LuuLuongKT"].ToString();
                textBox5.Text = ds3.Tables[0].Rows[0]["CheDoKT"].ToString();
                textBox6.Text = ds3.Tables[0].Rows[0]["ChieuSauMNTinh"].ToString();
                textBox7.Text = ds3.Tables[0].Rows[0]["CSMNDong"].ToString();
                textBox8.Text = ds3.Tables[0].Rows[0]["TangChuaNuoc"].ToString();
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
            //check dữ liệu nhập vào
            if (check != false)
            {
                try
                {
                        objectid = IDChinhSua;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_CTKTNNgam] "
                           + " " + objectid
                           + ", N'" + textBox1.Text
                           + "', N'" + textBox2.Text
                           + "', N'" + textBox3.Text
                           + "', N'" + textBox4.Text
                           + "', N'" + textBox5.Text
                           + "', N'" + textBox6.Text
                           + "', N'" + textBox7.Text
                           + "', N'" + textBox8.Text + "'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();

                        MessageBox.Show("Chỉnh sửa Công trình KTNM thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Chỉnh sửa Công trình KTNM thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }

                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }
        }
    }
}
