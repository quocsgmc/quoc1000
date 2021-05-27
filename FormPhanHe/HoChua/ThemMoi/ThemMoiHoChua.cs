using DevExpress.XtraGrid.Views.Base;
using ESRI.ArcGIS.Carto;
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

namespace QLHTDT.FormPhanHe.HoChua.ThemMoi
{
    public partial class ThemMoiHoChua : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.HoChua.QuanlyHoChua.QuanlyHoChua.ID1;
        public ThemMoiHoChua()
        {
            InitializeComponent();

            openFileDialogFileShape.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogFileShape_FileOk);
            openFileDialogFileShape.Filter = "Shapefile|*.shp";
            openFileDialogFileShape.Title = "Chọn file Shapefile cần mở";
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ChinhSuaDapChuaNuoc_Load(object sender, EventArgs e)
        {

            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERY_TABLE_HoChua_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                textbox01.Text = ds3.Tables[0].Rows[0]["LuuVuc"].ToString();
                textbox02.Text = ds3.Tables[0].Rows[0]["NamXDSuaChua"].ToString();
                textbox03.Text = ds3.Tables[0].Rows[0]["Wtb"].ToString();
                textbox04.Text = ds3.Tables[0].Rows[0]["Wc"].ToString();
                textbox05.Text = ds3.Tables[0].Rows[0]["Whi"].ToString();
                textbox06.Text = ds3.Tables[0].Rows[0]["FTuoiTK"].ToString();
                textbox07.Text = ds3.Tables[0].Rows[0]["FtuoiTT"].ToString();
                textbox08.Text = ds3.Tables[0].Rows[0]["GhiChu"].ToString();
                comboQuan.Text = ds3.Tables[0].Rows[0]["QuanHuyen"].ToString();
                comboPhuong.Text = ds3.Tables[0].Rows[0]["TenPhuong"].ToString();
                textboxTenCongTrinh.Text = ds3.Tables[0].Rows[0]["TenCongTrinh"].ToString();
            }

        }

        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

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
            string Phuong = "null";
            if (comboPhuong.Text != "")
            {
                Phuong = comboPhuong.SelectedValue.ToString();
            }

            if (check != false)
            {
                try
                {
                    ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("HOCHUA");
                    IFeature ifeshp = featureClass.GetFeature(0);
                    feature = ftClassSDE.CreateFeature();
                    objectid = feature.OID;

                    //chỉnh sửa từ đây
                    int index = ifeshp.Fields.FindField("Shape");
                    IGeometryDef pGeometryDef;
                    pGeometryDef = ifeshp.Fields.get_Field(index).GeometryDef as IGeometryDef;
                    bool hasZ = pGeometryDef.HasZ;
                    IGeometry b = ifeshp.Shape;
                    //HasZ Xóa thuộc tính Z của ifeshp
                    if (hasZ)
                    {
                        IZAware za = (IZAware)b;
                        za.ZAware = false;
                        za.DropZs();
                    }
                    //HasM  Xóa thuộc tính M của ifeshp
                    bool hasM = pGeometryDef.HasM;
                    if (hasM)
                    {
                        IMAware zm = (IMAware)b;
                        zm.MAware = false;
                        zm.DropMs();
                    }
                    //kết thúc ở đây

                    feature.Shape = ifeshp.Shape;
                    ISubtypes subtypes = (ISubtypes)ftClassSDE;
                    IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
                    if (subtypes.HasSubtype)
                    {
                        rowSubtypes.SubtypeCode = 3;
                    }
                    rowSubtypes.InitDefaultValues();
                    feature.Store();
                    //cập nhật thuộc tính đối tượng
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_HoChua] "
                           + " " + objectid
                           + ", N'" + textboxTenCongTrinh.Text
                           + "', N'" + textbox01.Text
                           + "', N'" + textbox02.Text
                           + "', N'" + textbox03.Text
                           + "', N'" + textbox04.Text
                           + "', N'" + textbox05.Text
                           + "', N'" + textbox06.Text
                           + "', N'" + textbox07.Text
                           + "', N'" + textbox08.Text
                           + "', " + Phuong + "";
                    SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();

                        MessageBox.Show("Thêm mới Hồ chứa thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Thêm mới Hồ chứa thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }

                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }
        }

        private void comboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
   
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

        private void label8_Click(object sender, EventArgs e)
        {

        }
        OpenFileDialog openFileDialogFileShape = new System.Windows.Forms.OpenFileDialog();
        private void btMo1_Click(object sender, EventArgs e)
        {
            openFileDialogFileShape.ShowDialog();
        }
        private void openFileDialogFileShape_FileOk(object sender, CancelEventArgs e)
        {
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialogFileShape.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialogFileShape.FileName);
            IFeatureWorkspace_OpenFeatureClass(workspacePath, fileName);
            CboChonShp1.Text = openFileDialogFileShape.FileName; 
        }
        public void IFeatureWorkspace_OpenFeatureClass(string dataPath, string nameOfShapefile)
        {
            IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(dataPath, 0);
            featureClass = featureWorkspace.OpenFeatureClass(nameOfShapefile);
            //Console.WriteLine("There are {0} features in the {1} feature class", featureClass.FeatureCount(new QueryFilterClass()), featureClass.AliasName);
        }

        private void CboChonShp1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            {
                if (KienTruc.axMapControl1.get_Layer(i).Name == CboChonShp1.Text)
                {
                    ILayer Li = KienTruc.axMapControl1.get_Layer(i);
                    IFeatureLayer ftLayer = Li as IFeatureLayer;
                    featureClass = ftLayer.FeatureClass;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
