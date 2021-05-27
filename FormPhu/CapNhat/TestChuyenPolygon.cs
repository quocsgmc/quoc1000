using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using System.Collections;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using QLHTDT.FormChinh;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geometry;
using DevExpress.XtraTreeList.Columns;
using System.ComponentModel;
using ESRI.ArcGIS.Controls;
using System.IO;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class TestChuyenPolygon : Form
    {
        SaveFileDialog SaveFileDialogSave;
        OpenFileDialog openFileDialog1;
        IFeatureClass FCPolygon;
        IFeatureClass fcpolygon;
        string ColumnQuery = "";
        string Phaycolumn = "";
        IGeoFeatureLayer GeoFeatureLayer = null;
        string filename;
        ArrayList listpolygon = new ArrayList();
        ArrayList listLayerPLGon = new ArrayList();
        ObjectThuocTinh a = new ObjectThuocTinh("", "");
        public static IWorkspace IWorkspace;
        string save = "";
        public TestChuyenPolygon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Shapefile|*.shp; *.dwg|Cad|*.dwg";
            openFileDialog1.Title = "Chọn file Shapefile cần mở";
            openFileDialog1.ShowDialog();
        }
        public TestChuyenPolygon(IFeatureClass Point, IFeatureClass Line, IFeatureClass Polygon, IFeatureClass Multi, string Name, IWorkspace sourceWorksp)
        {
            InitializeComponent();
            getvaluefield(Polygon, treeList3);
            FCPolygon = Polygon;
            filename = Name;
            IWorkspace = sourceWorksp;
        }
        public class ObjectThuocTinh
        {
            public string Column { get; set; }
            public string value { get; set; }
            public ObjectThuocTinh(string Column, string value)
            {
                this.Column = Column;
                this.value = value;
            }
            public override string ToString() { return this.Column; }
        }
        public void getvaluefield(IFeatureClass fc, DevExpress.XtraTreeList.TreeList Treelist)
        {
            //Treelist = new TreeList();
            Treelist.Nodes.Clear();
            ICursor cursor = (ICursor)fc.Search(null, false);
            IDataStatistics dataStatistics = new DataStatisticsClass();
            dataStatistics.Field = ColumnQuery;
            dataStatistics.Cursor = cursor;
            System.Collections.IEnumerator enumerator = dataStatistics.UniqueValues;
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                object myObject = enumerator.Current;
                Treelist.AppendNode(new object[] { myObject.ToString(), false, "Chọn lớp dữ liệu" }, -1);
            }
        }
        private void openFileDialog_Ok(object sender, CancelEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
            string typefile = System.IO.Path.GetExtension(openFileDialog1.FileName);
            if (typefile == ".shp")
            {
                ColumnQuery = "Layer";
                Phaycolumn = "'";
                treeListColumn3.Caption = "Lớp layer";
            }
            if (typefile == ".dwg")
            {
                ColumnQuery = "Layer";
                Phaycolumn = "'";
                treeListColumn3.Caption = "Lớp layer";
            }

            IWorkspaceFactory pCadWKSFact = new CadWorkspaceFactory();
            IWorkspace pWorkspace1 = pCadWKSFact.OpenFromFile(workspacePath, 0);
            IFeatureWorkspace pWorkspace2 = (IFeatureWorkspace)pWorkspace1;
            IFeatureClass pFeatureClass;
            IFeatureDataset pFeatureDataset = pWorkspace2.OpenFeatureDataset(fileName);
            IFeatureClassContainer pFeatureClassContainer = pFeatureDataset as IFeatureClassContainer;
            //chỉnh sửa từ đây
            //IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactory();
            //IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(workspacePath, 0);
            //IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(fileName);
            //IFeatureClassContainer pFeatureClassContainer1 = pFeatureDataset as IFeatureClassContainer;
            //kết thúc chỉnh sửa từ đây

            //CadAnnotationLayer pCadFeatureLayer1;
            //CadFeatureLayer pCadFeatureLayer2;
            for (int i = 0; i < pFeatureClassContainer.ClassCount - 1; i++)
            {
                pFeatureClass = pFeatureClassContainer.Class[i];
                IFeatureLayer fl = new FeatureLayer();
                fl.FeatureClass = pFeatureClass;
                var l = fl as ILayer;
                if (pFeatureClass.FeatureType == esriFeatureType.esriFTCoverageAnnotation)
                {
                    //pCadFeatureLayer1 = pFeatureClassContainer.Class[i] as CadAnnotationLayer;
                    l.Name = fileName + ". phụ chú";
                    //axMapControl1.AddLayer(l, 0);
                }
                else
                {
                    if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryMultipoint || pFeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                    {
                        l.Name = fileName + ". Điểm";
                        FCPolygon = pFeatureClass;
                    }
                    if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                    {
                        l.Name = fileName + ". Vùng";
                        FCPolygon = pFeatureClass;
                    }
                    if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline || pFeatureClass.ShapeType == esriGeometryType.esriGeometryLine)
                    {
                        l.Name = fileName + ". Đường";
                        FCPolygon = pFeatureClass;
                    }
                }
            }
            getvaluefield(FCPolygon, treeList3);
            filename = Name;
            IWorkspace = pWorkspace1;
            //QLHTDT.FormPhu.CapNhat.CapNhatCad frm = new QLHTDT.FormPhu.CapNhat.CapNhatCad(pFeatureClassPoint, pFeatureClassPolyline, pFeatureClassPolyGon, pFeatureClassMultipath, fileName, pWorkspace1);
            //frm.Show();
            Cursor = Cursors.Default;
        }

        private void TestChuyenPolygon_Load(object sender, EventArgs e)
        {
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog_Ok);
        }

        private void btLuuFile_Click(object sender, EventArgs e)
        {
            SaveFileDialogSave = new System.Windows.Forms.SaveFileDialog();
            SaveFileDialogSave.Filter = "Shape file|*.shp";
            SaveFileDialogSave.InitialDirectory = Properties.Settings.Default.pathPolygon;
            //SaveFileDialogSave.CheckFileExists = true;
            SaveFileDialogSave.FileOk += new System.ComponentModel.CancelEventHandler(SaveFileDialogSave1);
            SaveFileDialogSave.CheckPathExists = true;
            SaveFileDialogSave.ShowDialog();
        }
        string savepath = ""; string savename = "";
        private void SaveFileDialogSave1(object sender, CancelEventArgs e)
        {
            savepath = ""; savename = "";
            //add object file to listbox1
            Cursor = Cursors.WaitCursor;
            save = SaveFileDialogSave.FileName;
            txtpolygon.Text = SaveFileDialogSave.FileName;
            Cursor = Cursors.Default;
            savepath = System.IO.Path.GetDirectoryName(SaveFileDialogSave.FileName);
            savename = System.IO.Path.GetFileName(SaveFileDialogSave.FileName);
        }

        private void btXuatFile_Click(object sender, EventArgs e)
        {
            if (savepath == "" | savename == "")
            {
                MessageBox.Show("Chưa chọn nơi lưu file xuất ra", "Thông báo");
            }
            else
            {
                Cursor = Cursors.WaitCursor;

                if (tabControl1.SelectedIndex == 0)
                {
                    ConvertFeatureClassToShapefile(IWorkspace, FCPolygon, "Polygon", savepath, savename);
                }
                //chỉnh sửa từ đây
                IWorkspaceFactory pwsf = new ShapefileWorkspaceFactory();
                IWorkspace pws = pwsf.OpenFromFile(openFileDialog1.FileName, 0);
                IEnumDataset pEnumDs = pws.Datasets[esriDatasetType.esriDTAny];
                IDataset pds = pEnumDs.Next();
                ArrayList lst = new ArrayList();
                ShapeDetail shap = null;
                while (pds != null)
                {
                    string name = pds.Name;
                    string shapeGeomType = "Unknown";
                    IFeatureClass pfc = (IFeatureClass)pds;
                    esriGeometryType shp = pfc.ShapeType;
                    pfc.FindField("Layer");
                    if (shp == esriGeometryType.esriGeometryPolyline || shp == esriGeometryType.esriGeometryLine)
                    {
                        shapeGeomType = "Polyline";
                    }
                    if (shp == esriGeometryType.esriGeometryMultipoint || shp == esriGeometryType.esriGeometryPoint)
                    {
                        shapeGeomType = "Point";
                    }
                    if (shp == esriGeometryType.esriGeometryPolygon)
                    {
                        shapeGeomType = "Polygon";
                    }
                    int cntFeat = pfc.FeatureCount(null);
                    shap = new ShapeDetail(name, shapeGeomType, cntFeat);
                    lst.Add(shap);
                    pds = pEnumDs.Next();
                }
                dataGridView1.DataSource = lst;
                //Kết thúc tại đây
                QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Update();
                QLHTDT.FormChinh.QuanTriHeThong.axTOCControl1.Update();
                QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Update();
                QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Refresh();
                QLHTDT.FormChinh.QuanTriHeThong.axTOCControl1.Refresh();
                QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();

            }
            Cursor = Cursors.Default;
        }
        public static void DefineUniqueValueRenderer1(IGeoFeatureLayer pGeoFeatureLayer, string fieldName)
        {
            IRandomColorRamp pRandomColorRamp = new RandomColorRampClass();
            //Create the color ramp for Symbols in the renderer
            pRandomColorRamp.MinSaturation = 0;
            pRandomColorRamp.MaxSaturation = 100;
            pRandomColorRamp.MinValue = 0;
            pRandomColorRamp.MaxValue = 100;
            pRandomColorRamp.StartHue = 0;
            pRandomColorRamp.EndHue = 360;
            pRandomColorRamp.UseSeed = true;
            pRandomColorRamp.Seed = 43;

            //Create the renderer

            IUniqueValueRenderer pUniqueValueRenderer = new UniqueValueRendererClass();
            ISimpleFillSymbol pSimpleFillSymbol = new SimpleFillSymbolClass();
            pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
            pSimpleFillSymbol.Outline.Width = 0.4;

            //These properties should be set prior to adding values
            pUniqueValueRenderer.FieldCount = 1;
            pUniqueValueRenderer.set_Field(0, fieldName);
            pUniqueValueRenderer.DefaultSymbol = pSimpleFillSymbol as ISymbol;
            pUniqueValueRenderer.UseDefaultSymbol = true;

            IDisplayTable pDisplayTable = pGeoFeatureLayer as IDisplayTable;
            IFeatureCursor pFeatureCursor = pDisplayTable.SearchDisplayTable(null, false) as IFeatureCursor;
            IFeature pFeature = pFeatureCursor.NextFeature();

            bool ValFound;
            int fieldIndex;

            IFields pFields = pFeatureCursor.Fields;
            fieldIndex = pFields.FindField(fieldName);
            while (pFeature != null)
            {
                ISimpleFillSymbol pClassSymbol = new SimpleFillSymbol();
                pClassSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
                pClassSymbol.Outline.Width = 0.4;

                string classValue;
                classValue = pFeature.get_Value(fieldIndex) as string;

                //test to see if this value was added to renderer. If not, add it
                ValFound = false;
                for (int i = 0; i <= pUniqueValueRenderer.ValueCount - 1; i++)
                {
                    if (pUniqueValueRenderer.get_Value(i) == classValue)
                    {
                        ValFound = true;
                        break;
                    }
                }
                //if the value was not found, it's new and will be added
                if (ValFound == false)
                {
                    pUniqueValueRenderer.AddValue(classValue, fieldName, pClassSymbol as ISymbol);
                    pUniqueValueRenderer.set_Label(classValue, classValue);
                    pUniqueValueRenderer.set_Symbol(classValue, pClassSymbol as ISymbol);
                }
                pFeature = pFeatureCursor.NextFeature();
            }
            //Since the number of unique values is kown, the color ramp can be sized and the colors assigned
            pRandomColorRamp.Size = pUniqueValueRenderer.ValueCount;
            bool bOK;
            pRandomColorRamp.CreateRamp(out bOK);

            IEnumColors pEnumColors = pRandomColorRamp.Colors;
            pEnumColors.Reset();
            for (int j = 0; j <= pUniqueValueRenderer.ValueCount - 1; j++)
            {
                string xv;
                xv = pUniqueValueRenderer.get_Value(j);
                if (xv != "")
                {

                    ISimpleFillSymbol pSimpleFillColor = pUniqueValueRenderer.get_Symbol(xv) as ISimpleFillSymbol;
                    pSimpleFillColor.Color = pEnumColors.Next();
                    IRgbColor pColor = new RgbColor();
                    if (xv == "RG" || xv == "RANHGIOI" || xv == "RANH GIOI" || xv == "Ranh gioi do an" || xv.Contains("Ranh gioi"))
                    {
                        pColor.Red = 0;
                        pColor.Green = 0;
                        pColor.Blue = 255;
                        pSimpleFillColor.Style = ESRI.ArcGIS.Display.esriSimpleFillStyle.esriSFSNull;

                        ICartographicLineSymbol cartoLineSymbol = new CartographicLineSymbolClass();
                        ILineProperties lineProp = (ILineProperties)cartoLineSymbol;
                        lineProp.Offset = 0;
                        double[] hpe = new double[7];
                        hpe[0] = 0;
                        hpe[1] = 1;
                        hpe[2] = 2;
                        hpe[3] = 3;
                        hpe[4] = 4;
                        hpe[5] = 0;
                        ITemplate lineTemplate = new Template();
                        lineTemplate.Interval = 1;
                        int ix = 0;
                        int jx = 0;
                        jx = 0;
                        for (ix = 1; ix <= 3; ix++)
                        {
                            lineTemplate.AddPatternElement(hpe[jx], hpe[jx + 1]);
                            jx = jx + 2;
                        }
                        lineProp.Template = lineTemplate;
                        // Set the basic and cartographic line properties
                        cartoLineSymbol.Width = 2;
                        cartoLineSymbol.Cap = esriLineCapStyle.esriLCSButt;
                        cartoLineSymbol.Join = esriLineJoinStyle.esriLJSRound;
                        IRgbColor HC = new RgbColor();
                        HC.Red = 0;
                        HC.Green = 0;
                        HC.Blue = 255;
                        cartoLineSymbol.Color = HC;
                        pSimpleFillColor.Outline = cartoLineSymbol;

                        //pSimpleFillColor.Outline.Color = pColor;
                        //pSimpleFillColor.Outline.Width = 1;
                    }
                    if (xv == "Congtrinh" || xv == "CONGTRINH" || xv.Contains("CTCC") || xv.Contains("CTRINH") || xv.Contains("TRINH") || xv.Contains("CONG"))
                    {
                        pColor.Red = 255;
                        pColor.Green = 0;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv.Contains("cay") || xv.Contains("Cay") || xv.Contains("CAY") || xv.Contains("CX") || xv.Contains("thamco") || xv.Contains("THAMCO") || xv.Contains("CayCo") || xv.Contains("Cay Co") || xv.Contains("co") || xv == "TR")
                    {
                        pColor.Red = 0;
                        pColor.Green = 252;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                    }
                    pUniqueValueRenderer.set_Symbol(xv, pSimpleFillColor as ISymbol);
                }
            }
            pUniqueValueRenderer.ColorScheme = "Custom";
            ITable pTable = pDisplayTable as ITable;
            bool isString = pTable.Fields.get_Field(fieldIndex).Type == esriFieldType.esriFieldTypeString;
            pGeoFeatureLayer.Renderer = pUniqueValueRenderer as IFeatureRenderer;

            //this makes the layer properties symbology tab show the correct interface
            IUID pUID = new UIDClass();
            pUID.Value = "{683C994E-A17B-11D1-8816-080009EC732A}";
            pGeoFeatureLayer.RendererPropertyPageClassID = pUID as UIDClass;
            pUniqueValueR1 = pUniqueValueRenderer;
        }
        public static IUniqueValueRenderer pUniqueValueR1;
        public class ShapeDetail
        {
            public string ShapeName
            {
                get;
                set;
            }
            public string Shapetype
            {
                get;
                set;
            }
            public int featureCount
            {
                get;
                set;
            }
            public ShapeDetail(string name, string typeShp, int cnt)
            {
                ShapeName = name;
                Shapetype = typeShp;
                featureCount = cnt;
            }
        }
        public void ConvertFeatureClassToShapefile(IWorkspace sourceWorkspace, IFeatureClass sourceFeatureClass, string Loai, string path, string fname)
        {
            String targetWorkspacePath = path;
            IWorkspaceFactory targetWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
            IWorkspace targetWorkspace = (IWorkspace)targetWorkspaceFactory.OpenFromFile(targetWorkspacePath, 0);
            IDataset sourceWorkspaceDataset = (IDataset)sourceWorkspace;
            IDataset targetWorkspaceDataset = (IDataset)targetWorkspace;
            IName sourceWorkspaceDatasetName = sourceWorkspaceDataset.FullName;
            IName targetWorkspaceDatasetName = targetWorkspaceDataset.FullName;
            IWorkspaceName sourceWorkspaceName = (IWorkspaceName)sourceWorkspaceDatasetName;
            IWorkspaceName targetWorkspaceName = (IWorkspaceName)targetWorkspaceDatasetName;
            IDataset pDataset = (IDataset)sourceFeatureClass;

            IFeatureClassName sourceFeatureClassName = (IFeatureClassName)pDataset.FullName;
            IFeatureClassName targetFeatureClassName = new FeatureClassNameClass();
            IDatasetName targetDatasetName = (IDatasetName)targetFeatureClassName;
            IFeatureDatasetName trgFDN = (IFeatureDatasetName)targetFeatureClassName.FeatureDatasetName;
            if (fname == null || fname == "")
            { targetDatasetName.Name = filename + Loai + DateTime.Now.ToString("HHmmss"); }
            else
            { targetDatasetName.Name = fname; }
            targetDatasetName.WorkspaceName = targetWorkspaceName;
            IFieldChecker fieldChecker = new FieldCheckerClass();
            IFields sourceFields = sourceFeatureClass.Fields;
            IFields targetFields = null;
            IEnumFieldError enumFieldError = null;
            fieldChecker.InputWorkspace = sourceWorkspace;
            fieldChecker.ValidateWorkspace = targetWorkspace;
            fieldChecker.Validate(sourceFields, out enumFieldError, out targetFields);
            if (enumFieldError != null)
            {
                // Handle the errors in a way appropriate to your application.
                Console.WriteLine("Errors were encountered during field validation.");
            }

            // Find the shape field.
            String shapeFieldName = sourceFeatureClass.ShapeFieldName;
            int shapeFieldIndex = sourceFeatureClass.FindField(shapeFieldName);
            IField shapeField = sourceFields.get_Field(shapeFieldIndex);

            // Get the geometry definition from the shape field and clone it.
            IGeometryDef geometryDef = shapeField.GeometryDef;
            IClone geometryDefClone = (IClone)geometryDef;
            IClone targetGeometryDefClone = geometryDefClone.Clone();
            IGeometryDef targetGeometryDef = (IGeometryDef)targetGeometryDefClone;

            // Create a query filter to remove ramps, interstates and highways.
            string WhereClause = ColumnQuery + " = ";

            if (tabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < listpolygon.Count; i++)
                {
                    if (i != listpolygon.Count - 1)
                    {
                        WhereClause = WhereClause + Phaycolumn + listpolygon[i].ToString() + Phaycolumn + " OR " + ColumnQuery + " = ";
                    }
                    else { WhereClause = WhereClause + Phaycolumn + listpolygon[i].ToString() + Phaycolumn; }
                }


            }
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = WhereClause;

            // Create the converter and run the conversion.
            IFeatureDataConverter featureDataConverter = new FeatureDataConverterClass();
                IEnumInvalidObject enumInvalidObject = featureDataConverter.ConvertFeatureClass(sourceFeatureClassName, queryFilter, trgFDN, targetFeatureClassName, targetGeometryDef, targetFields, "", 1000, 0);

            // Check for errors.
            IInvalidObjectInfo invalidObjectInfo = null;
            enumInvalidObject.Reset();
            while ((invalidObjectInfo = enumInvalidObject.Next()) != null)
            {
                // Handle the errors in a way appropriate to the application.
                Console.WriteLine("Errors occurred for the following feature: {0}",
                  invalidObjectInfo.InvalidObjectID);
            }

            IFeatureLayer fl = new FeatureLayer();
            ILayer l = null;
            ShapefileWorkspaceFactoryClass pWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(targetWorkspacePath, 0);
            FeatureLayerClass pFeatureLayer = new FeatureLayerClass();
            pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(targetDatasetName.Name + ".shp");
            pFeatureLayer.Name = filename + Loai;
            fl.FeatureClass = pFeatureLayer.FeatureClass;
            l = fl as ILayer;
            l.Name = targetDatasetName.Name;
            QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.AddLayer(l, 0);
            GeoFeatureLayer = (IGeoFeatureLayer)fl;
            if (Loai == "Polygon")
            {
                DefineUniqueValueRenderer1(GeoFeatureLayer, ColumnQuery);
                fcpolygon = pFeatureLayer.FeatureClass;
            }
        }
        private void repositoryItemCheckEdit3_Click(object sender, EventArgs e)
        {
            TreeListMultiSelection selectedNodes3 = treeList3.Selection;
            if (selectedNodes3[0].Nodes != null)
            {
                if ((sender as DevExpress.XtraEditors.CheckEdit).Checked == false)
                {
                    listpolygon.Add(selectedNodes3[0].GetValue(treeList3.Columns[0]).ToString());

                }
                if ((sender as DevExpress.XtraEditors.CheckEdit).Checked == true)
                {
                    listpolygon.RemoveAt(listpolygon.IndexOf(selectedNodes3[0].GetValue(treeList3.Columns[0]).ToString()));

                }
            }
        }
        public class MyObject
        {
            public string alias { get; set; }
            public string value { get; set; }
            public MyObject(string alias, string value)
            {
                this.alias = alias;
                this.value = value;
            }
            public override string ToString() { return this.alias; }
        }

    }
}
