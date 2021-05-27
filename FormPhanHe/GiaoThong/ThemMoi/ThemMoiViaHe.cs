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

namespace QLHTDT.FormPhanHe.GiaoThong.ThemMoi
{
    public partial class ThemMoiViaHe : Form
    {
        string typeSDE = "";
        string typeSHP = "";
        IFeatureWorkspace featureWorkspaceSHP;
        public static IFeatureClass featureClassSHP;
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        public ThemMoiViaHe()
        {
            InitializeComponent();
            openFileDialogFileShape.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogFileShape_FileOk);
            openFileDialogFileShape.Filter = "Shapefile|*.shp";
            openFileDialogFileShape.Title = "Chọn file Shapefile cần mở";
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ThemMoiViaHe_Load(object sender, EventArgs e)
        {
            ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("VIAHE");
            typeSDE = ftClassSDE.ShapeType.ToString();

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
            string TenDuong = "null";
            if (comboBox1.Text != "")
            {
                TenDuong = comboBox1.SelectedValue.ToString();
            }
            if (check != false)
            {
                try
                {

                    //Kiểm tra có cập nhật Không gian hay không
                    ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("VIAHE");
                    typeSDE = ftClassSDE.ShapeType.ToString();
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
                    string sql1 = "[PRC_UPDATE_ViaHe] "
                        + " '" + objectid
                        + "', N'" + textBox1.Text
                        + "', N'" + textBox2.Text
                        + "', N'" + textBox3.Text
                        + "', N'" + textBox4.Text
                        + "', " + TenDuong + "";
                    SqlCommand command4 = new SqlCommand(sql1, conn);
                    command4.ExecuteScalar();
                    MessageBox.Show("Thêm mới Vỉa hè thành công", "Thông báo");
                    //Phần này là lưu nhật ký
                    KienTruc.TBNK = new DataTable();
                    SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                    SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                    KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                    KienTruc.ThemMoiDoiTuong("Vỉa hè", objectid);
                    KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                    this.Hide(); Cursor = Cursors.Default;
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }
                    MessageBox.Show("Thêm mới Vỉa hè thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }

                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;
            }
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

            //Kiểm tra định dạng file, số dữ liệu có nhiều hơn 1 đối tượng k
            string shapefileLocation = openFileDialogFileShape.FileName;

            if (shapefileLocation != "")
            {

                ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
                featureWorkspaceSHP = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(shapefileLocation), 0);
                featureClassSHP = featureWorkspaceSHP.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(shapefileLocation));
                typeSHP = featureClassSHP.ShapeType.ToString();
                //getvaluefield(featureClassSHP, treeList2, "Layer");
                if (typeSHP != typeSDE) // Kiểm tra lớp dữ liệu có cùng định dạng lớp cần cập nhật
                {
                    MessageBox.Show("Lớp dữ liệu không cùng định dạng với dữ liệu SDE đã chọn", "Thông báo");
                    CboChonShp1.Text = "";
                }
                else
                {
                    if (featureClassSHP.FeatureCount(null) > 1) // Kiểm tra dữ liệu có nhiều hơn 1 đối tượng hay không
                    {
                        MessageBox.Show("Lớp dữ liệu nhiều hơn 1 đối tượng, vui lòng kiểm tra lại file", "Thông báo");
                        CboChonShp1.Text = "";
                    }
                }

            }
        }
        public void IFeatureWorkspace_OpenFeatureClass(string dataPath, string nameOfShapefile)
        {
            IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(dataPath, 0);
            featureClass = featureWorkspace.OpenFeatureClass(nameOfShapefile);
            //Console.WriteLine("There are {0} features in the {1} feature class", featureClass.FeatureCount(new QueryFilterClass()), featureClass.AliasName);
        }
    }
}
