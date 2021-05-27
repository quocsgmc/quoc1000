using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using QLHTDT.FormChinh;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using ESRI.ArcGIS.DataSourcesFile;
using QLHTDT.Properties;
using ESRI.ArcGIS.DataSourcesGDB;

namespace QLHTDT.FormPhu.CapNhat
{

    public partial class CapNhatShape : Form
    {

        ESRI.ArcGIS.Carto.IActiveView activeView;
        public static ILayer layershp;
        public static IFeatureClass featureClassSHP;
        IMap pmap;
        private FeatureLayer _myFeatureLayer;
        IFeatureWorkspace featureWorkspaceSDE;
        IFeatureWorkspace featureWorkspaceSHP;
        IFeatureClass ftClassSDE;
        IFeatureClass fcPolygonSDE;
        IFeatureClass fcLineSDE;
        IFeatureClass fcPolygonRGQHSDE;
        string typeSDE = "";
        string typeSHP = "";

        ArrayList listline = new ArrayList();
        ArrayList listpolygon = new ArrayList();
        ArrayList listLayerLine = new ArrayList();
        ArrayList listLayerPLGon = new ArrayList();
        ArrayList listData = new ArrayList();


        public CapNhatShape()
        {
            InitializeComponent();
            activeView = KienTruc.axMapControl1.ActiveView;
            this.TopMost = true;
            pmap = KienTruc.axMapControl1.Map;
            _Geodatabase = new CORE.Geodatabase();
            //activeView = ArcMap.Document.ActiveView;
            //treeList2.ClearNodes();
            conectsde();

        }
        private void conectsde()
        {
            if (QLHTDT.Properties.Settings.Default.checksavepathSDE == false && QLHTDT.Properties.Settings.Default.savepathSDE != "")
            {
                comboBox2.Items.Clear();
                QLHTDT.CORE.LoadLayer.Getdataset(_Geodatabase.ConnectFile(QLHTDT.Properties.Settings.Default.savepathSDE), comboBox2);
            }
            else if (QLHTDT.Properties.Settings.Default.checksavepathSDE == true && QLHTDT.Properties.Settings.Default.pathcauhinhSDE != null)
            {
                comboBox2.Items.Clear();
                IWorkspaceFactory2 workspaceFactory = (IWorkspaceFactory2)new SdeWorkspaceFactoryClass();
                featureWorkspaceSDE = (IFeatureWorkspace)workspaceFactory.Open(Properties.Settings.Default.pathcauhinhSDE, 0);
                QLHTDT.CORE.LoadLayer.Getdataset(featureWorkspaceSDE as IWorkspace, comboBox2);
            }
        }
        private void btShape_Click(object sender, EventArgs e)
        {
            if (activeView == null)
            {
                return;
            }
            // Use the OpenFileDialog Class to choose which shapefile to load.
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = Properties.Settings.Default.pathPolygon;
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                repositoryItemComboBox2.Items.Clear();
                // The user chose a particular shapefile.

                // The returned string will be the full path, filename and file-extension for the chosen shapefile. Example: "C:\test\cities.shp"
                string shapefileLocation = openFileDialog.FileName;

                if (shapefileLocation != "")
                {

                    ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
                    featureWorkspaceSHP = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(shapefileLocation), 0);
                    featureClassSHP = featureWorkspaceSHP.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(shapefileLocation));
                    typeSHP = featureClassSHP.ShapeType.ToString();
                    //getvaluefield(featureClassSHP, treeList2, "Layer");
                    if (typeSHP != typeSDE)
                    {
                        MessageBox.Show("Lớp dữ liệu không cùng định dạng với dữ liệu SDE đã chọn", "Thông báo");
                    }
                    else
                    {
                        for (int i = 0; i < featureClassSHP.Fields.FieldCount; i++)
                        {
                            if (!featureClassSHP.Fields.Field[i].Name.Contains("Shape") & !featureClassSHP.Fields.Field[i].Name.Contains(featureClassSHP.OIDFieldName))
                                //object myObject = enumerator.Current;
                                //treeList2.AppendNode(new object[] { featureClassSHP.Fields.Field[i].Name, "Chọn trường dữ liệu" }, -1);
                                repositoryItemComboBox2.Items.Add(featureClassSHP.Fields.Field[i].Name);
                        }
                    }

                }
            }

        }
        public void getvaluefield(IFeatureClass fc, DevExpress.XtraTreeList.TreeList Treelist, string field)
        {

            ICursor cursor = (ICursor)fc.Search(null, false);
            IDataStatistics dataStatistics = new DataStatisticsClass();
            dataStatistics.Field = field;
            dataStatistics.Cursor = cursor;
            System.Collections.IEnumerator enumerator = dataStatistics.UniqueValues;
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                object myObject = enumerator.Current;
                Treelist.AppendNode(new object[] { myObject.ToString(), "Chọn trường dữ liệu" }, -1);
            }
        }
        private CORE.Geodatabase _Geodatabase;
        private void btSDE_Click(object sender, EventArgs e)
        {
            //comboBox2.Items.Clear();
            //QLHTDT.CORE.LoadLayer.Getdataset(_Geodatabase.ConnectFile(@"C:\Users\sinhn\AppData\Roaming\ESRI\Desktop10.2\ArcCatalog\QuyDatTDC.sde"), comboBox2);
            this.Hide();
            CapNhatDGN.FrmCauHinhSDE frmcauhinh = new CapNhatDGN.FrmCauHinhSDE();
            frmcauhinh.ShowDialog();
            if (frmcauhinh.Visible == false)
            {
                this.Visible = true;
                conectsde();
            }
        }

        private void comboBox2_SelectedValueChanged_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (comboBox2.SelectedIndex == -1)
                return;
            else
            {
                List<CORE.PropertyLayer> list = new List<CORE.PropertyLayer>();
                list = _Geodatabase.ListFeatureclassFromFdataset(comboBox2.SelectedItem.ToString());
                for (int i = 0; i < list.Count; i++)
                {
                    comboBox1.Items.Add(list[i]._Name);
                }
            }
        }

        private void comboBox1_SelectedValueChanged_1(object sender, EventArgs e)
        {
            treeList2.Nodes.Clear();
            if (comboBox1.SelectedIndex == -1)
                return;
            else
            {
                //_Geodatabase.Openlayer(_Geodatabase.FeatureWorkspace, dr._Name, pMap);
                ftClassSDE = _Geodatabase.FeatureWorkspace.OpenFeatureClass(comboBox1.Text);
                typeSDE = ftClassSDE.ShapeType.ToString();
                getfield(ftClassSDE);
            }
        }
        public void getfield(IFeatureClass fc)
        {
            for (int i = 0; i < fc.Fields.FieldCount; i++)
            {
                if (!fc.Fields.Field[i].Name.Contains("Shape") & !fc.Fields.Field[i].Name.Contains(fc.OIDFieldName) & !fc.Fields.Field[i].Name.Contains("OBJECTID") & !fc.Fields.Field[i].Name.Contains("SHAPE"))
                    //repositoryItemComboBox2.Items.Add(fc.Fields.Field[i].Name);
                    treeList2.AppendNode(new object[] { fc.Fields.Field[i].Name, "Chọn trường dữ liệu" }, -1);
            }
        }

        private void btCapNhat_Click_1(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            ftClassSDE = _Geodatabase.FeatureWorkspace.OpenFeatureClass(comboBox1.Text);
            for (int i = 0; i < featureClassSHP.FeatureCount(null); i++)
            {
                IFeature ifeshp = featureClassSHP.GetFeature(i);
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
                for (int i2 = 0; i2 < treeList2.Nodes.Count; i2++)
                {
                    //int field = ftClassSDE.FindField(((TreeListNode)treeList2.Nodes[i2]).GetDisplayText(treeList2.Columns[0]));
                    int field = ftClassSDE.FindField(((TreeListNode)treeList2.Nodes[i2]).GetDisplayText(treeList2.Columns[0]));
                    if (((TreeListNode)treeList2.Nodes[i2]).GetDisplayText(treeList2.Columns[1]) != "Chọn trường dữ liệu")
                    {
                        //feature.set_Value(field, null);
                        feature.set_Value(field, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[i2]).GetDisplayText(treeList2.Columns[1]))).ToString());
                    }
                    else
                    {
                        feature.set_Value(field, null);
                    }
                }
                feature.Store();
            }
            splashScreenManager1.CloseWaitForm();
            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
            KienTruc.axMapControl1.Refresh();
            this.Hide();
        }
        private void CapNhat()
        {
            for (int i = 0; i < featureClassSHP.FeatureCount(null); i++)
            {
                IFeature ifeshp = featureClassSHP.GetFeature(i);
                IFeature feature = ftClassSDE.CreateFeature();
                feature.Shape = ifeshp.Shape;
                ISubtypes subtypes = (ISubtypes)ftClassSDE;
                IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
                if (subtypes.HasSubtype)
                {
                    rowSubtypes.SubtypeCode = 3;
                }
                rowSubtypes.InitDefaultValues();
                for (int i2 = 0; i2 < treeList2.Nodes.Count; i2++)
                {
                    int field = ftClassSDE.FindField(((TreeListNode)treeList2.Nodes[i2]).GetDisplayText(treeList2.Columns[0]));
                    if (((TreeListNode)treeList2.Nodes[i2]).GetDisplayText(treeList2.Columns[1]) != "")
                    {
                        feature.set_Value(field, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[i2]).GetDisplayText(treeList2.Columns[1]))).ToString());
                    }
                    else { feature.set_Value(field, null); }

                }
                feature.Store();
            }
        }

    }
}
