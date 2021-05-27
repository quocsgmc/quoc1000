using DevExpress.XtraTreeList.Nodes;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using QLHTDT.FormChinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class CapNhat_RGQuyDat : Form
    {
        string phuong;
        public CapNhat_RGQuyDat()
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
        private void CapNhat_RGQuyDat_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            {
                CboChonShp1.Items.Add(KienTruc.axMapControl1.get_Layer(i).Name);
                CboChonShp2.Items.Add(KienTruc.axMapControl1.get_Layer(i).Name);
            }
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
            repositoryItemComboBox2.Items.Clear();
            if (featureClass != null)
            {
                for (int i = 0; i < featureClass.Fields.FieldCount; i++)
                { repositoryItemComboBox2.Items.Add(featureClass.Fields.Field[i].Name); }

            }
        }

        private void CboChonShp1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            {
                if (KienTruc.axMapControl1.get_Layer(i).Name == CboChonShp2.Text)
                {
                    ILayer Li = KienTruc.axMapControl1.get_Layer(i);
                    IFeatureLayer ftLayer = Li as IFeatureLayer;
                    featureClass = ftLayer.FeatureClass;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //KienTruc.splashScreenManager1.ShowWaitForm();
            try
            {
                ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("DUANQH");
                IFeature ifeshp = featureClass.GetFeature(0);
                IFeature feature = ftClassSDE.CreateFeature();

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
                int TongMucDauTu = ftClassSDE.FindField("TongMucDauTu");
                if (tbTongMucDauTu.Text != "")
                { feature.set_Value(TongMucDauTu, tbTongMucDauTu.Text); }
                else { feature.set_Value(TongMucDauTu, null); }

                int TenDuAn = ftClassSDE.FindField("TenDuAn");
                if (tbTenDuAn.Text != "")
                {
                    feature.set_Value(TenDuAn, tbTenDuAn.Text);
                }
                else { feature.set_Value(TenDuAn, null); }

                int SoQD = ftClassSDE.FindField("SoQuyetDinh");
                if (tbQDPL.Text != "")
                {
                    feature.set_Value(SoQD, tbQDPL.Text);
                }
                else { feature.set_Value(SoQD, null); }

                int NamQDPL = ftClassSDE.FindField("NamQDPL");
                if (tbNamQDPL.Text != "")
                {
                    feature.set_Value(NamQDPL, tbNamQDPL.Text);
                }
                else { feature.set_Value(NamQDPL, null); }

                int ChuDauTu = ftClassSDE.FindField("NgayRaQuyetDinh");
                if (tbChuDauTu.Text != "")
                {
                    feature.set_Value(ChuDauTu, tbChuDauTu.Text);
                }
                else { feature.set_Value(ChuDauTu, null); }

                int DieuHanhDuAn = ftClassSDE.FindField("DieuHanhDuAn");
                if (tbDieuHanhDuAn.Text != "")
                {
                    feature.set_Value(DieuHanhDuAn, tbDieuHanhDuAn.Text);
                }
                else { feature.set_Value(DieuHanhDuAn, null); }

                int GhiChu = ftClassSDE.FindField("GhiChu");
                if (tbGhiChu.Text != "")
                {
                    feature.set_Value(GhiChu, tbGhiChu.Text);
                }
                else { feature.set_Value(GhiChu, null); }

                int TienDoTrienKhai = ftClassSDE.FindField("tbTienDoTrienKhai");
                if (tbTienDoTrienKhai.Text != "")
                {
                    feature.set_Value(TienDoTrienKhai, tbTienDoTrienKhai.Text);
                }
                else { feature.set_Value(TienDoTrienKhai, null); }

                int dt;
                int DienTich = ftClassSDE.FindField("DienTich");
                if (tbDienTich.Text != "" & int.TryParse(tbDienTich.Text, out dt))
                {
                    feature.set_Value(DienTich, tbDienTich.Text);
                }
                else { feature.set_Value(DienTich, null); }
                feature.Store();
                //KienTruc.splashScreenManager1.CloseWaitForm();
                MessageBox.Show("Cập nhật ranh giới dự án quy hoạch thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Cập nhật ranh giới dự án quy hoạch thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
            }
            KienTruc.axMapControl1.Refresh();
            //this.Hide();
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            //KienTruc.splashScreenManager1.ShowWaitForm();
            ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("DuAnQH");
            for (int i = 0; i < featureClass.FeatureCount(null); i++)
            {
                IFeature ifeshp = featureClass.GetFeature(i);
                IFeature feature = ftClassSDE.CreateFeature();
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
                int MaDuAn = ftClassSDE.FindField("MaDuAn");
                if (((TreeListNode)treeList2.Nodes[0]).GetDisplayText(treeList2.Columns[1]) != "")
                { feature.set_Value(MaDuAn, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[0]).GetDisplayText(treeList2.Columns[1]))).ToString()); }
                else { feature.set_Value(MaDuAn, null); }

                int TenDuAn = ftClassSDE.FindField("TenDuAn");
                if (((TreeListNode)treeList2.Nodes[1]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(TenDuAn, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[1]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(TenDuAn, null); }

                int QDPL = ftClassSDE.FindField("SoQuyetDinh");
                if (((TreeListNode)treeList2.Nodes[2]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(QDPL, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[2]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(QDPL, null); }

                int NamQDPL = ftClassSDE.FindField("NgayRaQuyetDinh");
                if (((TreeListNode)treeList2.Nodes[3]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(NamQDPL, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[4]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(NamQDPL, null); }

                int TienDoTrienKhai = ftClassSDE.FindField("TienDoTrienKhai");
                if (((TreeListNode)treeList2.Nodes[4]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(TienDoTrienKhai, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[3]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(TienDoTrienKhai, null); }

                int DieuHanhDuAn = ftClassSDE.FindField("DieuHanhDuAn");
                if (((TreeListNode)treeList2.Nodes[5]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(DieuHanhDuAn, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[5]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(DieuHanhDuAn, null); }

                int ChuDauTu = ftClassSDE.FindField("ChuDauTu");
                if (((TreeListNode)treeList2.Nodes[6]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(ChuDauTu, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[8]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(ChuDauTu, null); }
                int dt;
                int DienTich = ftClassSDE.FindField("DienTich");
                if (((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    if (int.TryParse(ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]))).ToString(), out dt))
                    { feature.set_Value(DienTich, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]))).ToString()); }
                }
                else { feature.set_Value(DienTich, null); }

                int TongMucDauTu = ftClassSDE.FindField("TongMucDauTu");
                if (((TreeListNode)treeList2.Nodes[8]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(TongMucDauTu, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[9]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(TongMucDauTu, null); }

                int GhiChu = ftClassSDE.FindField("GhiChu");
                if (((TreeListNode)treeList2.Nodes[9]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(GhiChu, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[9]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(GhiChu, null); }
                feature.Store();

            }

            //KienTruc.splashScreenManager1.CloseWaitForm();
            MessageBox.Show("Thêm mới dự án quy hoạch thành công", "Thông báo");
            KienTruc.axMapControl1.Refresh();
            this.Hide();
        }


    }
}
