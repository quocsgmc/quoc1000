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
    public partial class ChinhSuaDAQH : Form
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
        int IDChinhSua ;
        public ChinhSuaDAQH(int OBJECTID)
        {
            InitializeComponent();
            openFileDialogFileShape.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogFileShape_FileOk);
            openFileDialogFileShape.Filter = "Shapefile|*.shp";
            openFileDialogFileShape.Title = "Chọn file Shapefile cần mở";
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
            IDChinhSua = OBJECTID;
        }
        private void ChinhSuaDAQH_Load(object sender, EventArgs e)
        {
            ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("DOANQUYHOACH");
            typeSDE = ftClassSDE.ShapeType.ToString();

            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERYRGDAQH_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                //txtIDTuyen.Text = ds3.Tables[0].Rows[0]["IDTuyen"].ToString();
                txtMaDuAn.Text = ds3.Tables[0].Rows[0]["Madoan"].ToString();
                txtTenDuAn.Text = ds3.Tables[0].Rows[0]["Tendoan"].ToString();
                comboQuan.Text = ds3.Tables[0].Rows[0]["QuanHuyen"].ToString();
                comboPhuong.Text = ds3.Tables[0].Rows[0]["TenPhuong"].ToString();
                txtDienTich.Text = ds3.Tables[0].Rows[0]["DienTich"].ToString();
                txtChuDauTu.Text = ds3.Tables[0].Rows[0]["Chudautu"].ToString();
                txtDieuHanhDuAn.Text = ds3.Tables[0].Rows[0]["Dieuhanhduan"].ToString();
                txtGhiChu.Text = ds3.Tables[0].Rows[0]["GhiChu"].ToString();
                txtNamQDPL.Text = ds3.Tables[0].Rows[0]["NamraQDphaply"].ToString();
                txtQDPL.Text = ds3.Tables[0].Rows[0]["Quyetdinhphaply"].ToString();
                cboTienDo.Text = ds3.Tables[0].Rows[0]["TienDo"].ToString();
                txtNamQH.Text = ds3.Tables[0].Rows[0]["NamQH"].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn Chỉnh sửa Dự án quy hoạch 1/500 không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                IFeature feature = null;
                int objectid;
                Cursor = Cursors.WaitCursor;
                bool check = true;
                string DTich = "null"; double DienTich;
                string QDPL = "null"; double NamQDPL;
                string NQDPL = "null"; double NaQDPL;
                string NaQH = "null"; double NamQH;
                string MaKhuQH = "null";
                string TDo = "null"; ; string TienDo = "null";

                bool isNumeric;
                isNumeric = true;
                if (txtDienTich.Text != "")
                {
                    DTich = txtDienTich.Text;
                    if (double.TryParse(DTich, out DienTich))
                    { }
                    else
                    {
                        MessageBox.Show("Sai định dạng dữ liệu Diện tích!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                        check = false; Cursor = Cursors.Default; return;
                    }
                    isNumeric = true;
                }
                isNumeric = true;
                if (txtQDPL.Text != "")
                {
                    QDPL = txtQDPL.Text;
                    if (double.TryParse(QDPL, out NamQDPL))
                    { }
                    else
                    {
                        MessageBox.Show("Sai định dạng dữ liệu QDPL!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                        check = false; Cursor = Cursors.Default; return;
                    }
                    isNumeric = true;
                }
                if (txtNamQDPL.Text != "")
                {
                    NQDPL = txtNamQDPL.Text;
                    if (double.TryParse(NQDPL, out NaQDPL))
                    { }
                    else
                    {
                        MessageBox.Show("Sai định dạng dữ liệu Năm QDPL!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                        check = false; Cursor = Cursors.Default; return;
                    }
                    isNumeric = true;
                }
                if (txtNamQH.Text != "")
                {
                    NaQH = txtNamQH.Text;
                    if (double.TryParse(NaQH, out NamQH))
                    { }
                    else
                    {
                        MessageBox.Show("Sai định dạng dữ liệu Năm QDPL!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                        check = false; Cursor = Cursors.Default; return;
                    }
                    isNumeric = true;
                }
                if (cboTienDo.Text != "")
                {
                    TDo = cboTienDo.Text;
                    switch (TDo)
                    {
                        case "Cơ bản hoàn thành": TienDo = "1"; break;
                        case "Đang triển khai": TienDo = "2"; break;
                        case "Chưa triển khai": TienDo = "3"; break;
                        case "Chậm triển khai": TienDo = "4"; break;
                        default: TienDo = "null"; break;
                    }
                }

                if (check != false)
                {
                    try
                    {
                        if (CboChonShp1.Text != "")
                        {
                            //Kiểm tra có cập nhật Không gian hay không
                            ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("DOANQUYHOACH");
                            feature = ftClassSDE.GetFeature(IDChinhSua);
                            objectid = feature.OID;
                            IFeature ifeshp = featureClass.GetFeature(0);

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
                        }

                        objectid = IDChinhSua;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();

                        string sql1 = "[PRC_UPDATE_RGDAQH_BY_ID] "
                            + " " + objectid
                            + ", N'" + txtMaDuAn.Text
                            + "', N'" + txtTenDuAn.Text
                            + "', N'" + comboPhuong.SelectedValue.ToString()
                            + "', " + DTich
                            + ", N'" + txtChuDauTu.Text
                            + "', N'" + txtDieuHanhDuAn.Text
                            + "', N'" + txtGhiChu.Text
                            + "', " + NQDPL
                            + ", " + QDPL
                            + ", " + TienDo
                            + ", " + NaQH + " ";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ChinhSuathuoctinhToolQuanLy("Đồ án quy hoạch 1/500", objectid);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                        MessageBox.Show("Chỉnh sửa Đồ án quy hoạch 1/500 thành công", "Thông báo");
                        this.Hide(); Cursor = Cursors.Default;
                    }
                    catch
                    {
                        //xóa đối tượng đã tạo nếu có lỗi
                        if (feature != null)
                        { feature.Delete(); }

                        MessageBox.Show("Chỉnh sửa Đồ án quy hoạch thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                        Cursor = Cursors.Default;
                    }

                    QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                    Cursor = Cursors.Default;
                }
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
