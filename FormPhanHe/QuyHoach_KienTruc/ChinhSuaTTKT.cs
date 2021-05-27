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

namespace QLHTDT.FormPhanHe.QuyHoach_KienTruc
{
    public partial class ChinhSuaTTKT : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlDataAdapter dataAdapter2;
        SqlCommandBuilder cmbl;
        IFeatureWorkspace featureWorkspaceSHP;
        public static IFeatureClass featureClassSHP;
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua ;
        int objectid;
        public ChinhSuaTTKT(int OBJECTID)
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
            IDChinhSua = OBJECTID;
        }
        private void ChinhSuaTTKT_Load(object sender, EventArgs e)
        {
            if (IDChinhSua != 0)
            {
                tb = new DataTable();
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand("[PRC_QUERYTTKIENTRUC_BY_ID] " + IDChinhSua + "", connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);
                dataAdapter1.Fill(tb);
                this.bindingSource2.DataSource = tb;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn Chỉnh sửa Thông tin kiến trúc không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string TenKhuVuc = vGridControl1.GetCellValue(vGridControl1.Rows[0].ChildRows[0], 0).ToString();
                string TangCaoXD = vGridControl1.GetCellValue(vGridControl1.Rows[0].ChildRows[1], 0).ToString();
                string ChieuCaoTang = vGridControl1.GetCellValue(vGridControl1.Rows[0].ChildRows[2], 0).ToString();
                string CotNen = vGridControl1.GetCellValue(vGridControl1.Rows[0].ChildRows[3], 0).ToString();
                string QDKhac = vGridControl1.GetCellValue(vGridControl1.Rows[0].ChildRows[4], 0).ToString();
                string ChiGioiXD = vGridControl1.GetCellValue(vGridControl1.Rows[0].ChildRows[5], 0).ToString();

                objectid = IDChinhSua;
                SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                conn.Open();
                string sql1 = "[PRC_UPDATE_TTKIENTRUC] "
                    + " " + objectid
                    + ", N'" + TenKhuVuc
                    + "', N'" + TangCaoXD
                    + "', N'" + ChieuCaoTang
                    + "', N'" + CotNen
                    + "', N'" + QDKhac
                    + "', N'" + ChiGioiXD + "' ";
                SqlCommand command4 = new SqlCommand(sql1, conn);
                command4.ExecuteScalar();
                //Phần này là lưu nhật ký
                KienTruc.TBNK = new DataTable();
                SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                KienTruc.ChinhSuathuoctinhToolQuanLy("Thông tin kiến trúc", IDChinhSua);
                KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                MessageBox.Show("Chỉnh sửa Thông tin kiến trúc thành công", "Thông báo");
                this.Hide(); Cursor = Cursors.Default;
            }
        }

      

    }
}
