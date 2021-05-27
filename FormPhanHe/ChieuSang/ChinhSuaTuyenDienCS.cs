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

namespace QLHTDT.FormPhanHe.ChieuSang
{
    public partial class ChinhSuaTuyenDienCS : Form
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
        int IDChinhSua;
        string IDPhuong;
        public ChinhSuaTuyenDienCS(int OBJECTID)
        {
            InitializeComponent();
            openFileDialogFileShape.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogFileShape_FileOk);
            openFileDialogFileShape.Filter = "Shapefile|*.shp";
            openFileDialogFileShape.Title = "Chọn file Shapefile cần mở";
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
            IDChinhSua = OBJECTID;
        }
        private void ChinhSuaTuyenDienCS_Load(object sender, EventArgs e)
        {
            ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("TUYENDIENCS");
            typeSDE = ftClassSDE.ShapeType.ToString();

            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";


            if (IDChinhSua != 0)
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERYTuyenDienCS_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                //txtIDTuyen.Text = ds3.Tables[0].Rows[0]["IDTuyen"].ToString();
                txtToaDoX.Text = ds3.Tables[0].Rows[0]["DIEMDAU"].ToString();
                txtToaDoY.Text = ds3.Tables[0].Rows[0]["DIEMCUOI"].ToString();
                txtTenTuyen.Text = ds3.Tables[0].Rows[0]["TENTUYEN"].ToString();
                txtDiaChi.Text = ds3.Tables[0].Rows[0]["DIACHI"].ToString();
                txtChieuDai.Text = ds3.Tables[0].Rows[0]["CHIEUDAI"].ToString().Replace(",", "."); ;
                txtLoaiDay.Text = ds3.Tables[0].Rows[0]["LOAIDAY"].ToString();
                txtGhiChu.Text = ds3.Tables[0].Rows[0]["GHICHU"].ToString();
                comboQuan.Text = ds3.Tables[0].Rows[0]["QuanHuyen"].ToString();
                comboPhuong.Text = ds3.Tables[0].Rows[0]["TenPhuong"].ToString();
                IDPhuong = ds3.Tables[0].Rows[0]["MaXa"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn Chỉnh sửa Tuyến điện CS kiệt hẻm không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            bool check = true;
            double ChieuDai;
            bool isNumeric;
            if (isNumeric = double.TryParse(txtChieuDai.Text, out ChieuDai))
            { }
            else
            {
                MessageBox.Show("Sai định dạng dữ liệu Chiều dài!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                check = false; Cursor = Cursors.Default; return;
            }

                if (check != false)
                {
                    try
                    {
                        if (CboChonShp1.Text != "")
                        {
                            //Kiểm tra có cập nhật Không gian hay không
                            ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("TUYENDIENCS");
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

                        string sql1 = "[PRC_UPDATE_TUYENDIENCHIEUSANG_BY_ID] "
                            + " '" + objectid
                            + "', N'" + txtTenTuyen.Text
                            + "', N'" + txtDiaChi.Text
                            + "', '" + ChieuDai
                            + "', N'" + txtToaDoX.Text
                            + "', N'" + txtToaDoY.Text
                            + "', N'" + txtLoaiDay.Text
                            + "', '" + txtGhiChu.Text
                            + "', " + IDPhuong + "";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        MessageBox.Show("Chỉnh sửa Tuyến điện chiếu sáng thành công", "Thông báo");
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ChinhSuathuoctinhToolQuanLy("Tuyến điện chiếu sáng kiệt hẻm", objectid);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                        this.Hide(); Cursor = Cursors.Default;
                        ChieuSang.QuanLyTuyenDienChieuSang.LoadLaiForm = 1;
                    }
                    catch
                    {
                        //xóa đối tượng đã tạo nếu có lỗi
                        if (feature != null)
                        { feature.Delete(); }

                        MessageBox.Show("Chỉnh sửa Trụ điện chiếu sáng thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                        Cursor = Cursors.Default;
                    }
                    QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                    Cursor = Cursors.Default;
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
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + " ";
                DataSet ds2 = new DataSet();
                SqlDataAdapter adp2 = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                adp2.Fill(ds2);
                comboPhuong.DataSource = ds2.Tables[0];
                comboPhuong.DisplayMember = "TenPhuong";
                comboPhuong.ValueMember = "MaPhuong";
            }
        }

        private void comboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDPhuong = comboPhuong.SelectedValue.ToString();
        }

        private void txtChieuDai_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtChieuDai.Text, "  ^ [0-9]"))
            {
                txtChieuDai.Text = "";
            }
        }

        private void txtChieuDai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
