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

namespace QLHTDT.FormPhanHe.GiaoThong.ChinhSua
{
    public partial class ChinhSuaLoaiBienBao : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.GiaoThong.QuanLyLoaiBienBao.IDTram;
        public ChinhSuaLoaiBienBao()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ChinhSuaLoaiBienBao_Load(object sender, EventArgs e)
        {


            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_TABLE_LoaiBienBao_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                //txtIDTuyen.Text = ds3.Tables[0].Rows[0]["IDTuyen"].ToString();
                comboBox1.Text = ds3.Tables[0].Rows[0]["LOAIBIEN"].ToString();
                textBox2.Text = ds3.Tables[0].Rows[0]["TENBIEN"].ToString();
                textBox3.Text = ds3.Tables[0].Rows[0]["HINHANH"].ToString();
                textBox4.Text = ds3.Tables[0].Rows[0]["GHICHU"].ToString();
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
            string LBien = "null"; ; string LoaiBien = "null";
            if (comboBox1.Text != "")
            {
                LBien = comboBox1.Text;
                switch (LBien)
                {
                    case "Biển báo cấm": LoaiBien = "1"; break;
                    case "Biển báo chỉ dẫn": LoaiBien = "2"; break;
                    case "Biển báo hiệu lệnh": LoaiBien = "3"; break;
                    case "Biển báo nguy hiểm": LoaiBien = "4"; break;
                    case "Biển phụ": LoaiBien = "5"; break;
                    case "Danh sách vạch": LoaiBien = "6"; break;
                    default: LoaiBien = "null"; break;
                }
            }
            if (check != false)
            {
                try
                {
                    objectid = IDChinhSua;
                    //cập nhật thuộc tính đối tượng
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sql1 = "[PRC_UPDATE_LoaiBienBao] "
                        + " '" + objectid
                        + "', " + LoaiBien
                        + ", N'" + textBox2.Text
                        + "', N'" + textBox3.Text
                        + "', N'" + textBox4.Text + "'";
                    SqlCommand command4 = new SqlCommand(sql1, conn);
                    command4.ExecuteScalar();
                    MessageBox.Show("Chỉnh sửa Loại biển báo thành công", "Thông báo");
                    this.Hide(); Cursor = Cursors.Default;
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }
                    MessageBox.Show("Chỉnh sửa Loại biển báo thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }
                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }
        }

        
    }
}
