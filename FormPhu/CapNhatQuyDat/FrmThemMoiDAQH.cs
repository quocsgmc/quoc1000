using DevExpress.XtraTreeList.Nodes;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using QLHTDT.FormChinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.CapNhatQuyDat
{
    public partial class FrmThemMoiDAQH : Form
    {
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        OpenFileDialog openFileDialogFileShape = new System.Windows.Forms.OpenFileDialog();
        public FrmThemMoiDAQH()
        {
            InitializeComponent();
            //featureWorkspaceSDE = (IFeatureWorkspace)workspaceFactory.OpenFromFile(SDEfileLocation, 0);
            openFileDialogFileShape.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogFileShape_FileOk);
            openFileDialogFileShape.Filter = "Shapefile|*.shp";
            openFileDialogFileShape.Title = "Chọn file Shapefile cần mở";
            if (QuanTriHeThong.FeatureWorkspace != null)
            { featureWorkspaceSDE = QuanTriHeThong.FeatureWorkspace; }
            
        }

        private void FrmThemMoiDAQH_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < QuanTriHeThong.axMapControl1.LayerCount; i++)
            {
                CboChonShp1.Items.Add(QuanTriHeThong.axMapControl1.get_Layer(i).Name);
                CboChonShp2.Items.Add(QuanTriHeThong.axMapControl1.get_Layer(i).Name);
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < QuanTriHeThong.axMapControl1.LayerCount; i++)
            {

                if (QuanTriHeThong.axMapControl1.get_Layer(i).Name == CboChonShp2.Text)
                {
                    ILayer Li = QuanTriHeThong.axMapControl1.get_Layer(i);
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
            { getFieldFeatureClass();
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
            for (int i = 0; i < QuanTriHeThong.axMapControl1.LayerCount; i++)
            {
                if (QuanTriHeThong.axMapControl1.get_Layer(i).Name == CboChonShp2.Text)
                {
                    ILayer Li = QuanTriHeThong.axMapControl1.get_Layer(i);
                    IFeatureLayer ftLayer = Li as IFeatureLayer;
                    featureClass = ftLayer.FeatureClass;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuanTriHeThong.splashScreenManager1.ShowWaitForm();
            ftClassSDE = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("DUANQH");
            IFeature ifeshp = featureClass.GetFeature(0);
            IFeature feature = ftClassSDE.CreateFeature();
            feature.Shape = ifeshp.Shape;
            ISubtypes subtypes = (ISubtypes)ftClassSDE;
            IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
            if (subtypes.HasSubtype)
            {
                rowSubtypes.SubtypeCode = 3;
            }
            rowSubtypes.InitDefaultValues();
            int MaDuAn = ftClassSDE.FindField("maDuAn");
            if (tbMaDuAn.Text != "")
            { feature.set_Value(MaDuAn, tbMaDuAn.Text); }
            else { feature.set_Value(MaDuAn, null); }

            int tenDuAn = ftClassSDE.FindField("tenDuAn");
            if (tbTenDuAn.Text != "")
            {
                feature.set_Value(tenDuAn, tbTenDuAn.Text);
            }
            else { feature.set_Value(tenDuAn, null); }

            int soQuyetDinh = ftClassSDE.FindField("soQuyetDinh");
            if (tbSoQD.Text != "")
            {
                feature.set_Value(soQuyetDinh, tbSoQD.Text);
            }
            else { feature.set_Value(soQuyetDinh, null); }

            int ngayQuyetDinh = ftClassSDE.FindField("ngayQuyetDinh");
            if (tbNgayRaQD.Text != "")
            {
                feature.set_Value(ngayQuyetDinh, tbNgayRaQD.Text);
            }
            else { feature.set_Value(ngayQuyetDinh, null); }

            int noiRaQuyetDinh = ftClassSDE.FindField("noiRaQuyetDinh");
            if (tbNoiRaQD.Text != "")
            {
                feature.set_Value(noiRaQuyetDinh, tbNoiRaQD.Text);
            }
            else { feature.set_Value(noiRaQuyetDinh, null); }

            int TienDoTrienKhai = ftClassSDE.FindField("TienDoTrienKhai");
            if (tbTienDoTrienKhai.Text != "")
            {
                feature.set_Value(TienDoTrienKhai, tbTienDoTrienKhai.Text);
            }
            else { feature.set_Value(TienDoTrienKhai, null); }

            int TongMucDauTu = ftClassSDE.FindField("TongMucDauTu");
            if (tbTongMucDauTu.Text != "")
            {
                feature.set_Value(TongMucDauTu, tbTongMucDauTu.Text);
            }
            else { feature.set_Value(TongMucDauTu, null); }

            int GhiChu = ftClassSDE.FindField("GhiChu");
            if (tbGhiChu.Text != "")
            {
                feature.set_Value(GhiChu, tbGhiChu.Text);
            }
            else { feature.set_Value(GhiChu, null); }
            int dt;
            int DienTich = ftClassSDE.FindField("DienTich");
            if (tbDienTich.Text != "" & int.TryParse(tbDienTich.Text, out dt))
            {
                feature.set_Value(DienTich, tbDienTich.Text);
            }
            else { feature.set_Value(DienTich, null); }
            feature.Store();
            QuanTriHeThong.splashScreenManager1.CloseWaitForm();
            MessageBox.Show("Thêm mới dự án quy hoạch thành công", "Thông báo");
            QuanTriHeThong.axMapControl1.Refresh();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QuanTriHeThong.splashScreenManager1.ShowWaitForm();
            ftClassSDE = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("DUANQH");
            for (int i = 0; i < featureClass.FeatureCount(null); i++)
            {
                IFeature ifeshp = featureClass.GetFeature(i);
                IFeature feature = ftClassSDE.CreateFeature();
                feature.Shape = ifeshp.Shape;
                ISubtypes subtypes = (ISubtypes)ftClassSDE;
                IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
                if (subtypes.HasSubtype)
                {
                    rowSubtypes.SubtypeCode = 3;
                }
                rowSubtypes.InitDefaultValues();
                int MaDuAn = ftClassSDE.FindField("maDuAn");
                if (((TreeListNode)treeList2.Nodes[0]).GetDisplayText(treeList2.Columns[1]) != "")
                { feature.set_Value(MaDuAn, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[0]).GetDisplayText(treeList2.Columns[1]))).ToString()); }
                else { feature.set_Value(MaDuAn, null); }

                int tenDuAn = ftClassSDE.FindField("tenDuAn");
                if (((TreeListNode)treeList2.Nodes[1]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(tenDuAn, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[1]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(tenDuAn, null); }

                int soQuyetDinh = ftClassSDE.FindField("soQuyetDinh");
                if (((TreeListNode)treeList2.Nodes[2]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(soQuyetDinh, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[2]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(soQuyetDinh, null); }

                int ngayQuyetDinh = ftClassSDE.FindField("ngayQuyetDinh");
                if (((TreeListNode)treeList2.Nodes[4]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(ngayQuyetDinh, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[4]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(ngayQuyetDinh, null); }

                int noiRaQuyetDinh = ftClassSDE.FindField("noiRaQuyetDinh");
                if (((TreeListNode)treeList2.Nodes[3]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(noiRaQuyetDinh, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[3]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(noiRaQuyetDinh, null); }

                int TienDoTrienKhai = ftClassSDE.FindField("TienDoTrienKhai");
                if (((TreeListNode)treeList2.Nodes[5]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(TienDoTrienKhai, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[5]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(TienDoTrienKhai, null); }

                int TongMucDauTu = ftClassSDE.FindField("TongMucDauTu");
                if (((TreeListNode)treeList2.Nodes[6]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(TongMucDauTu, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[6]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(TongMucDauTu, null); }

                int GhiChu = ftClassSDE.FindField("GhiChu");
                if (((TreeListNode)treeList2.Nodes[8]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(GhiChu, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[8]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(GhiChu, null); }
                int dt;
                int DienTich = ftClassSDE.FindField("DienTich");
                if (((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]) != ""  )
                {
                    if (int.TryParse(ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]))).ToString(), out dt))
                    { feature.set_Value(DienTich, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]))).ToString()); }
                }
                else { feature.set_Value(DienTich, null); }
                feature.Store();
            }

            QuanTriHeThong.splashScreenManager1.CloseWaitForm();
            MessageBox.Show("Thêm mới dự án quy hoạch thành công", "Thông báo");
            QuanTriHeThong.axMapControl1.Refresh();
            this.Hide();
        }
    }
}
