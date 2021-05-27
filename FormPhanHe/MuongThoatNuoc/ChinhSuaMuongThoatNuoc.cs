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
    public partial class ChinhSuaMuongThoatNuoc : Form
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
        int IDChinhSua = QLHTDT.FormPhanHe.MuongThoatNuoc.QuanLyMuongThoatNuoc2.QuanLyMuongThoatNuoc2.ID1;
        string IDPhuong;
        public ChinhSuaMuongThoatNuoc(int OBJECTID)
        {
            InitializeComponent();
            openFileDialogFileShape.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogFileShape_FileOk);
            openFileDialogFileShape.Filter = "Shapefile|*.shp";
            openFileDialogFileShape.Title = "Chọn file Shapefile cần mở";
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
            IDChinhSua = OBJECTID;
        }

        private void ChinhSuaMuongThoatNuoc_Load(object sender, EventArgs e)
        {
            ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("MUONGTHOATNUOC");
            typeSDE = ftClassSDE.ShapeType.ToString();

            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERYMuongThoatNuoc_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                //txtIDTuyen.Text = ds3.Tables[0].Rows[0]["IDTuyen"].ToString();
                txtDiemDau.Text = ds3.Tables[0].Rows[0]["DIEMDAU"].ToString();
                txtDiemCuoi.Text = ds3.Tables[0].Rows[0]["DIEMCUOI"].ToString();
                txtTenMuong.Text = ds3.Tables[0].Rows[0]["TENMUONG"].ToString();
                txtDiaChi.Text = ds3.Tables[0].Rows[0]["DIACHI"].ToString();
                comboDonViQuanLy.Text = ds3.Tables[0].Rows[0]["DVQL"].ToString();
                comboHuongChay.Text = ds3.Tables[0].Rows[0]["HUONGCHAY"].ToString();
                txtChieuRong.Text = ds3.Tables[0].Rows[0]["CHIEURONG"].ToString().Replace(",", ".");
                txtChieuCao.Text = ds3.Tables[0].Rows[0]["CHIEUCAO"].ToString().Replace(",", ".");
                txtChieuDai.Text = ds3.Tables[0].Rows[0]["CHIEUDAI"].ToString().Replace(",", ".");
                txtGhiChu.Text = ds3.Tables[0].Rows[0]["GHICHU"].ToString();
                comboQuan.Text = ds3.Tables[0].Rows[0]["QuanHuyen"].ToString();
                comboPhuong.Text = ds3.Tables[0].Rows[0]["TenPhuong"].ToString();
                IDPhuong = ds3.Tables[0].Rows[0]["MaXa"].ToString();
            }
        }

        private void comboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                comboQuan.Text = "";
            }
            if (AddQuan == 1)
            {
                MaHuyen = comboQuan.SelectedValue.ToString();
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null," + MaHuyen + "";
                DataSet ds2 = new DataSet();
                SqlDataAdapter adp2 = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                adp2.Fill(ds2);
                //comboPhuong.Items.Clear();
                comboPhuong.DataSource = ds2.Tables[0];
                comboPhuong.DisplayMember = "TenPhuong";
                comboPhuong.ValueMember = "MaPhuong";
            }
        }

        private void comboDoanhNghiep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDonViQuanLy.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboDonViQuanLy.Text = "";
            }
        }
        
 

        private void button2_Click(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            bool check = true;
            string ChieuRong = "null"; string ChieuCao = "null"; string ChieuDai = "null";
            double CRong; double CCao; double CDai;
            bool isNumeric;
            if (txtChieuRong.Text != "")
            {
                ChieuRong = txtChieuRong.Text;
                if (double.TryParse(ChieuRong, out CRong))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Chiều rộng!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    check = false; Cursor = Cursors.Default; return;
                }
                isNumeric = true;
            }
            if (txtChieuCao.Text != "")
            {
                ChieuCao = txtChieuCao.Text;
                if (double.TryParse(ChieuCao, out CCao))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Chiều cao!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    check = false; Cursor = Cursors.Default; return;
                }
                isNumeric = true;
            }
            if (txtChieuDai.Text != "")
            {
                ChieuDai = txtChieuDai.Text;
                if (double.TryParse(ChieuDai, out CDai))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Chiều dài!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    check = false; Cursor = Cursors.Default; return;
                }
                isNumeric = true;
            }

            if (check != false)
            {
                try
                {
                    if (CboChonShp1.Text != "")
                    {
                        try
                        {
                            //Kiểm tra có cập nhật Không gian hay không
                            ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("MUONGTHOATNUOC");
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
                        catch
                        {
                            MessageBox.Show("Vui lòng chọn lại dữ liệu Shapefile", "Thông báo");
                        }
                    }
                    objectid = IDChinhSua;
                    //cập nhật thuộc tính đối tượng
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();

                    string sql1 = "[PRC_UPDATE_MuongThoatNuoc] "
                        + " '" + objectid
                        + "', N'" + txtTenMuong.Text
                        + "', N'" + txtDiaChi.Text
                        + "', N'" + comboDonViQuanLy.Text
                        + "', N'" + txtDiemDau.Text
                        + "', N'" + txtDiemCuoi.Text
                        + "', '" + HuongChay
                        + "', " + ChieuRong
                        + ", " + ChieuCao
                        + ", " + ChieuDai
                        + ", N'" + txtGhiChu.Text
                        + "', " + IDPhuong + "";
                    SqlCommand command5 = new SqlCommand(sql1, conn);
                    command5.ExecuteScalar();
                    //Phần này là lưu nhật ký
                    KienTruc.TBNK = new DataTable();
                    SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                    SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                    KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                    KienTruc.ChinhSuathuoctinhToolQuanLy("Mương thoát nước kiệt hẻm", objectid);
                    KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                    MessageBox.Show("Chỉnh sửa Mương thoát nước thành công", "Thông báo");
                    this.Hide(); Cursor = Cursors.Default;
                    MuongThoatNuoc.QuanLyMuongThoatNuoc2.QuanLyMuongThoatNuoc2.LoadLaiForm = 1;
                }
                catch
                {
                    //xóa đối tượng đã tạo nếu có lỗi
                    if (feature != null)
                    { feature.Delete(); }

                    MessageBox.Show("Chỉnh sửa mương thoát nước thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                    Cursor = Cursors.Default;
                }

                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                Cursor = Cursors.Default;

            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string HuongChay = "null";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboHuongChay.Text == "Trái") { HuongChay = "2"; }
            if (comboHuongChay.Text == "Phải") { HuongChay = "1"; }
            if (comboHuongChay.Text == "Chưa xác định") { HuongChay = "0"; }
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

        private void comboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDPhuong = comboPhuong.SelectedValue.ToString();
        }

        private void CboChonShp1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtChieuDai_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtChieuDai.Text, "  ^ [0-9]"))
            {
                txtChieuDai.Text = "";
            }
        }
    }
}
