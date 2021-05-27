using DevExpress.XtraTreeList.Nodes;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
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
    public partial class CapNhat_GiaoThong : Form
    {
        string pathline;
        public static IFeatureClass featureClassSHP1;
        IFeatureWorkspace featureWorkspaceSHP1;
        ESRI.ArcGIS.Carto.IActiveView activeView;
        public static ILayer layershp1;
        IMap pmap;

        string phuong;
        public CapNhat_GiaoThong()
        {
            InitializeComponent();
            openFileDialogFileShape.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogFileShape_FileOk);
            openFileDialogFileShape.Filter = "Shapefile|*.shp";
            openFileDialogFileShape.Title = "Chọn file Shapefile cần mở";
            if (KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = KienTruc.FeatureWorkspace; }

            activeView = KienTruc.axMapControl1.ActiveView;
            this.TopMost = true;
            pmap = KienTruc.axMapControl1.Map;


        }
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        OpenFileDialog openFileDialogFileShape = new System.Windows.Forms.OpenFileDialog();
        private void btMo2_Click(object sender, EventArgs e)
        {
            openFileDialogFileShape.ShowDialog();
        }
        private void openFileDialogFileShape_FileOk(object sender, CancelEventArgs e)
        {
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialogFileShape.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialogFileShape.FileName);
            IFeatureWorkspace_OpenFeatureClass(workspacePath, fileName);
            getFieldFeatureClass();
            filename.Text = openFileDialogFileShape.FileName;

            string shapefileLocation = openFileDialogFileShape.FileName;

            if (shapefileLocation != "")
            {
                pathline = shapefileLocation;
                ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
                featureWorkspaceSHP1 = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(shapefileLocation), 0);
                featureClassSHP1 = featureWorkspaceSHP1.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(shapefileLocation));
                ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = new ESRI.ArcGIS.Carto.FeatureLayerClass();
                featureLayer.FeatureClass = featureClassSHP1;
                featureLayer.Name = featureClassSHP1.AliasName;
                featureLayer.Visible = true;
                if (featureClassSHP1.ShapeType != esriGeometryType.esriGeometryPolygon)
                {
                    MessageBox.Show("Shapefile không đúng dạng vùng", "Thông báo");
                }
                else
                {
                    activeView.FocusMap.AddLayer(featureLayer);
                    activeView.Extent = activeView.FullExtent;
                    activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                    QLHTDT.Properties.Settings.Default.pathLine = System.IO.Path.GetDirectoryName(shapefileLocation);
                    QLHTDT.Properties.Settings.Default.Save();
                    layershp1 = KienTruc.axMapControl1.get_Layer(0);
                    //IRgbColor color2 = new RgbColorClass();
                    //color2.Red = 237;
                    //color2.Green = 171;
                    //color2.Blue = 37;
                    //color2.UseWindowsDithering = true;



                    ICartographicLineSymbol pSimpleFillColor1 = new CartographicLineSymbolClass();
                    ICartographicLineSymbol cartoLineSymbol = new CartographicLineSymbolClass();
                    ILineProperties lineProp1 = (ILineProperties)cartoLineSymbol;
                    lineProp1.Offset = 0;
                    ITemplate lineTemplate1 = new Template();
                    lineTemplate1.Interval = 1;
                    lineTemplate1.AddPatternElement(5, 3);
                    lineProp1.Template = lineTemplate1;
                    cartoLineSymbol.Width = 2;
                    cartoLineSymbol.Cap = esriLineCapStyle.esriLCSButt;
                    cartoLineSymbol.Join = esriLineJoinStyle.esriLJSRound;
                    IRgbColor HC = new RgbColor();
                    HC.Red = 237;
                    HC.Green = 171;
                    HC.Blue = 37;
                    cartoLineSymbol.Color = HC;
                    pSimpleFillColor1 = cartoLineSymbol;
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
        private void getFieldFeatureClass()
        {
            repositoryItemComboBox2.Items.Clear();
            if (featureClass != null)
            {
                for (int i = 0; i < featureClass.Fields.FieldCount; i++)
                { repositoryItemComboBox2.Items.Add(featureClass.Fields.Field[i].Name); }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Hòa An") { phuong = "HA"; }
            if (comboBox1.Text == "Hòa Phát") { phuong = "HP"; }
            if (comboBox1.Text == "Hòa Thọ Đông") { phuong = "HTD"; }
            if (comboBox1.Text == "Hòa Thọ Tây") { phuong = "HTT"; }
            if (comboBox1.Text == "Hòa Xuân") { phuong = "HX"; }
            if (comboBox1.Text == "Khuê Trung") { phuong = "KT"; }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("DuongChinh_" + phuong + "");
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

                int Phuong = ftClassSDE.FindField("Phuong");
                if (comboBox1.Text != "")
                { feature.set_Value(Phuong, comboBox1.Text); }
                else { feature.set_Value(Phuong, null); }

                int TenDuong = ftClassSDE.FindField("TenDuong");
                if (((TreeListNode)treeList2.Nodes[0]).GetDisplayText(treeList2.Columns[1]) != "")
                { feature.set_Value(TenDuong, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[0]).GetDisplayText(treeList2.Columns[1]))).ToString()); }
                else { feature.set_Value(TenDuong, null); }
                int cd;
                int ChieuDai = ftClassSDE.FindField("ChieuDai");
                if (((TreeListNode)treeList2.Nodes[1]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    if (int.TryParse(ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[1]).GetDisplayText(treeList2.Columns[1]))).ToString(), out cd))
                    { feature.set_Value(ChieuDai, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[1]).GetDisplayText(treeList2.Columns[1]))).ToString()); }
                }
                else { feature.set_Value(ChieuDai, null); }

                //int md;
                //int MaDuong = ftClassSDE.FindField("MaDuong");
                //if (((TreeListNode)treeList2.Nodes[1]).GetDisplayText(treeList2.Columns[1]) != "")
                //{
                //    if (int.TryParse(ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[2]).GetDisplayText(treeList2.Columns[1]))).ToString(), out md))
                //    { feature.set_Value(MaDuong, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[2]).GetDisplayText(treeList2.Columns[1]))).ToString()); }
                //}
                //else { feature.set_Value(MaDuong, null); }

                int DauTuyen = ftClassSDE.FindField("DauTuyen");
                if (((TreeListNode)treeList2.Nodes[3]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(DauTuyen, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[3]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(DauTuyen, null); }

                int CuoiTuyen = ftClassSDE.FindField("CuoiTuyen");
                if (((TreeListNode)treeList2.Nodes[4]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(CuoiTuyen, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[4]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(CuoiTuyen, null); }

                int MatCat = ftClassSDE.FindField("MatCat");
                if (((TreeListNode)treeList2.Nodes[5]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(MatCat, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[5]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(MatCat, null); }

                int CapHangDuong = ftClassSDE.FindField("CapHangDuo");
                if (((TreeListNode)treeList2.Nodes[6]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(CapHangDuong, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[6]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(CapHangDuong, null); }

                int LoaiDuong = ftClassSDE.FindField("LoaiDuong");
                if (((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(LoaiDuong, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(LoaiDuong, null); }
                //int TrangThai = ftClassSDE.FindField("TrangThai");
                //if (((TreeListNode)treeList2.Nodes[8]).GetDisplayText(treeList2.Columns[1]) != "")
                //{
                //    feature.set_Value(TrangThai, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[8]).GetDisplayText(treeList2.Columns[1]))).ToString());
                //}
                //else { feature.set_Value(TrangThai, null); }
                //int GhiChu = ftClassSDE.FindField("GhiChu");
                //if (((TreeListNode)treeList2.Nodes[9]).GetDisplayText(treeList2.Columns[1]) != "")
                //{
                //    feature.set_Value(GhiChu, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[9]).GetDisplayText(treeList2.Columns[1]))).ToString());
                //}
                //else { feature.set_Value(GhiChu, null); }
                //int dt;
                //int DienTich = ftClassSDE.FindField("DienTich");
                //if (((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]) != "")
                //{
                //    if (int.TryParse(ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]))).ToString(), out dt))
                //    { feature.set_Value(DienTich, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]))).ToString()); }
                //}
                //else { feature.set_Value(DienTich, null); }
                //feature.Store();
                //int GhiChu = ftClassSDE.FindField("GhiChu");
                //if (((TreeListNode)treeList2.Nodes[9]).GetDisplayText(treeList2.Columns[1]) != "")
                //{
                //    feature.set_Value(GhiChu, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[9]).GetDisplayText(treeList2.Columns[1]))).ToString());
                //}
                //else { feature.set_Value(GhiChu, null); }
                feature.Store();
            }

            //KienTruc.splashScreenManager1.CloseWaitForm();
            MessageBox.Show("Cập nhật dữ liệu giao thông chính thành công", "Thông báo");
            KienTruc.axMapControl1.Refresh();
            this.Hide();
        }

        private void CapNhat_GiaoThong_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            {
                filename.Items.Add(KienTruc.axMapControl1.get_Layer(i).Name);
            }
        }

        private void filename_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            {

                if (KienTruc.axMapControl1.get_Layer(i).Name == filename.Text)
                {
                    ILayer Li = KienTruc.axMapControl1.get_Layer(i);
                    IFeatureLayer ftLayer = Li as IFeatureLayer;
                    featureClass = ftLayer.FeatureClass;
                    getFieldFeatureClass();
                }
            }
        }
    }
}
