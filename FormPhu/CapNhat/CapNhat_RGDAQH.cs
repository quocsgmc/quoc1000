using DevExpress.XtraTreeList.Nodes;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using QLHTDT.FormChinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class CapNhat_RGDAQH : Form
    {
        string phuong;
        int AddQuan = 0;
        public static string MaHuyen = "null";
        public CapNhat_RGDAQH()
        {
            InitializeComponent();
            //featureWorkspaceSDE = (IFeatureWorkspace)workspaceFactory.OpenFromFile(SDEfileLocation, 0);
            openFileDialogFileShape.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogFileShape_FileOk);
            openFileDialogFileShape.Filter = "Shapefile|*.shp";
            openFileDialogFileShape.Title = "Chọn file Shapefile cần mở";
            if (KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = KienTruc.FeatureWorkspace; }
        }
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        OpenFileDialog openFileDialogFileShape = new System.Windows.Forms.OpenFileDialog();
        private void CapNhat_RGDAQH_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            {
                CboChonShp1.Items.Add(KienTruc.axMapControl1.get_Layer(i).Name);
                CboChonShp2.Items.Add(KienTruc.axMapControl1.get_Layer(i).Name);
            }

            SqlDataAdapter adp = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboQuan.DataSource = ds.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";
        }
        void LoadDatabase(string Query, ComboBox Combobox, string DisplayMember, string ValueMember)
        {
            SqlDataAdapter adp = new SqlDataAdapter(Query, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Combobox.DataSource = ds.Tables[0];
            Combobox.DisplayMember = DisplayMember;
            Combobox.ValueMember = ValueMember;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            {

                if (KienTruc.axMapControl1.get_Layer(i).Name == CboChonShp2.Text)
                {
                    ILayer Li = KienTruc.axMapControl1.get_Layer(i);
                    IFeatureLayer ftLayer = Li as IFeatureLayer;
                    featureClass = ftLayer.FeatureClass;
                    getFieldFeatureClass();
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

        private void btMo2_Click(object sender, EventArgs e)
        {

            openFileDialogFileShape.ShowDialog();

        }
        private void btMo1_Click(object sender, EventArgs e)
        {
            openFileDialogFileShape.ShowDialog();
        }
        private void openFileDialogFileShape_FileOk(object sender, CancelEventArgs e)
        {
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialogFileShape.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialogFileShape.FileName);
            IFeatureWorkspace_OpenFeatureClass(workspacePath, fileName);
            if (tabControl1.SelectedIndex == 1)
            {
                getFieldFeatureClass();
                CboChonShp2.Text = openFileDialogFileShape.FileName;
            }
            else { CboChonShp1.Text = openFileDialogFileShape.FileName; }


        }
        private void getFieldFeatureClass()
        {
            //repositoryItemComboBox2.Items.Clear();
            //if (featureClass != null)
            //{
            //    for (int i = 0; i < featureClass.Fields.FieldCount; i++)
            //    { repositoryItemComboBox2.Items.Add(featureClass.Fields.Field[i].Name); }

            //}
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

        private void button2_Click(object sender, EventArgs e)
        {
            string TDo = "null"; ; string TienDo = "null";
            //KienTruc.splashScreenManager1.ShowWaitForm();
            //try
            //{
                int objectid;
                ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("DOANQUYHOACH");
                IFeature ifeshp = featureClass.GetFeature(0);
                IFeature feature = ftClassSDE.CreateFeature();
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
                //rowSubtypes.InitDefaultValues();
                int MaKhuQH = ftClassSDE.FindField("Madoan");
                if (txtMaDuAn.Text != "")
                { feature.set_Value(MaKhuQH, txtMaDuAn.Text); }
                else { feature.set_Value(MaKhuQH, null); }

                int TenDuAn = ftClassSDE.FindField("Tendoan");
                if (txtTenDuAn.Text != "")
                {
                    feature.set_Value(TenDuAn, txtTenDuAn.Text);
                }
                else { feature.set_Value(TenDuAn, null); }

                int QDPL = ftClassSDE.FindField("Quyetdinhphaply");
                if (txtNamQDPL.Text != "")
                {
                    feature.set_Value(QDPL, txtNamQDPL.Text);
                }
                else { feature.set_Value(QDPL, null); }

                int NamQDPL = ftClassSDE.FindField("NamraQDphaply");
                if (txtNamQDPL.Text != "")
                {
                    feature.set_Value(NamQDPL, txtNamQDPL.Text);
                }
                else { feature.set_Value(NamQDPL, null); }

                int ChuDauTu = ftClassSDE.FindField("Chudautu");
                if (txtChuDauTu.Text != "")
                {
                    feature.set_Value(ChuDauTu, txtChuDauTu.Text);
                }
                else { feature.set_Value(ChuDauTu, null); }

                int DieuHanhDuAn = ftClassSDE.FindField("Dieuhanhduan");
                if (txtDieuHanhDuAn.Text != "")
                {
                    feature.set_Value(DieuHanhDuAn, txtDieuHanhDuAn.Text);
                }
                else { feature.set_Value(DieuHanhDuAn, null); }

                int Phuong = ftClassSDE.FindField("Maphuong");
                if (comboPhuong.Text != "")
                {
                    feature.set_Value(Phuong, comboPhuong.SelectedValue.ToString());
                }
                else { feature.set_Value(Phuong, null); }

                int GhiChu = ftClassSDE.FindField("GhiChu");
                if (txtGhiChu.Text != "")
                {
                    feature.set_Value(GhiChu, txtGhiChu.Text);
                }
                int NamQH = ftClassSDE.FindField("NamQH");
                if (txtNamQH.Text != "")
                {
                    feature.set_Value(NamQH, txtNamQH.Text);
                }
                else { feature.set_Value(GhiChu, null); }
                int dt;
                int DienTich = ftClassSDE.FindField("DienTich");
                if (txtDienTich.Text != "" & int.TryParse(txtDienTich.Text, out dt))
                {
                    feature.set_Value(DienTich, txtDienTich.Text);
                }
                else { feature.set_Value(DienTich, null); }

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
                int TinhTrang = ftClassSDE.FindField("TinhTrang");
                if (cboTienDo.Text != "")
                {
                    feature.set_Value(TinhTrang, TienDo);
                }
                else { feature.set_Value(DienTich, null); }

                feature.Store();
                ////Update Bảng RGDAQH_Phuong
                //SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                //conn.Open();
                //string sql1 = "[PRC_INSERT_RGDAQH_Phuong] "
                //+ " " + objectid
                //+ ", " + cboPhuong.SelectedValue.ToString() + "";
                //SqlCommand command4 = new SqlCommand(sql1, conn);
                //command4.ExecuteScalar();
                //Phần này là lưu nhật ký
                KienTruc.TBNK = new DataTable();
                SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                KienTruc.ThemMoiDoiTuong("Ranh giới dự án quy hoạch chi tiết 1/500", objectid);
                KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                
                //KienTruc.splashScreenManager1.CloseWaitForm();
                MessageBox.Show("Cập nhật ranh giới dự án quy hoạch thành công", "Thông báo");
                this.Hide();
            //}
            //catch
            //{
            //    MessageBox.Show("Cập nhật ranh giới dự án quy hoạch thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
            //}
            KienTruc.axMapControl1.Refresh();
            
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            string TDo = "null"; ; string TienDo = "null";
            //KienTruc.splashScreenManager1.ShowWaitForm();
            try
            {
                int objectid;
                ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("QUYHOACHPHANKHU");
                IFeature ifeshp = featureClass.GetFeature(0);
                IFeature feature = ftClassSDE.CreateFeature();
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
                int MaPhanKhu = ftClassSDE.FindField("MaPhanKhu");
                if (txtMaPhanKhu.Text != "")
                { feature.set_Value(MaPhanKhu, txtMaPhanKhu.Text); }
                else { feature.set_Value(MaPhanKhu, null); }

                int TenPhanKhu = ftClassSDE.FindField("TenPhanKhu");
                if (txtTenPhanKhu.Text != "")
                {
                    feature.set_Value(TenPhanKhu, txtTenPhanKhu.Text);
                }
                else { feature.set_Value(TenPhanKhu, null); }

                int MaQHChung = ftClassSDE.FindField("MaQHChung");
                if (txtMaQHChung.Text != "")
                {
                    feature.set_Value(MaQHChung, txtMaQHChung.Text);
                }
                else { feature.set_Value(MaQHChung, null); }

                int QuyetDinhPhapLy = ftClassSDE.FindField("QuyetDinhPhapLy");
                if (txtQDPL1.Text != "")
                {
                    feature.set_Value(QuyetDinhPhapLy, txtQDPL1.Text);
                }
                else { feature.set_Value(QuyetDinhPhapLy, null); }

                int NamRaQDPL = ftClassSDE.FindField("NamRaQDPL");
                if (dateTimePicker1.Text != "")
                {
                    feature.set_Value(NamRaQDPL, dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                }
                else { feature.set_Value(NamRaQDPL, null); }

                int CoQuanpheDuyet = ftClassSDE.FindField("CoQuanpheDuyet");
                if (txtCoQuanPheDuyet.Text != "")
                {
                    feature.set_Value(CoQuanpheDuyet, txtCoQuanPheDuyet.Text);
                }
                else { feature.set_Value(CoQuanpheDuyet, null); }

                int ViTri = ftClassSDE.FindField("ViTri");
                if (txtViTri.Text != "")
                {
                    feature.set_Value(ViTri, txtViTri.Text);
                }
                else { feature.set_Value(ViTri, null); }

                int GhiChu = ftClassSDE.FindField("GhiChu");
                if (txtGhiChu.Text != "")
                {
                    feature.set_Value(GhiChu, txtGhiChu.Text);
                }
                int NamQH = ftClassSDE.FindField("NamQH");
                if (textBox1.Text != "")
                {
                    feature.set_Value(NamQH, textBox1.Text);
                }
                else { feature.set_Value(GhiChu, null); }
                int dt;
                int DienTich = ftClassSDE.FindField("DienTich");
                if (textBox2.Text != "" & int.TryParse(txtDienTich1.Text, out dt))
                {
                    feature.set_Value(DienTich, textBox2.Text);
                }
                else { feature.set_Value(DienTich, null); }

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
                int TinhTrang = ftClassSDE.FindField("TinhTrang");
                if (cboTienDo.Text != "")
                {
                    feature.set_Value(TinhTrang, TienDo);
                }
                else { feature.set_Value(DienTich, null); }

                feature.Store();
                ////Update Bảng RGDAQH_Phuong
                //SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                //conn.Open();
                //string sql1 = "[PRC_INSERT_RGDAQH_Phuong] "
                //+ " " + objectid
                //+ ", " + cboPhuong.SelectedValue.ToString() + "";
                //SqlCommand command4 = new SqlCommand(sql1, conn);
                //command4.ExecuteScalar();
                //Phần này là lưu nhật ký
                KienTruc.TBNK = new DataTable();
                SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                KienTruc.ThemMoiDoiTuong("Ranh giới dự án quy hoạch phân khu 1/5000", objectid);
                KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                //KienTruc.splashScreenManager1.CloseWaitForm();
                MessageBox.Show("Cập nhật ranh giới dự án quy hoạch phân khu thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Cập nhật ranh giới dự án quy hoạch phân khu thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
            }
            KienTruc.axMapControl1.Refresh();
            this.Hide();
        }

        private void cboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
                LoadDatabase("[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + "", comboPhuong, "TenPhuong", "MaPhuong");
                if (comboPhuong.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    comboPhuong.Text = "";
                }
            }
        }
    }
}
