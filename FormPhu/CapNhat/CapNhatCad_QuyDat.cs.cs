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
using System.Text;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class CapNhatCad_QuyDat : Form
    {
        int itemcbo = 0;
        SaveFileDialog SaveFileDialogSave;
        OpenFileDialog openFileDialog1;

        IFeatureClass FCPoint;
        IFeatureClass FCLine;
        IFeatureClass FCPolygon;
        IFeatureClass FCAnnotation;
        IFeatureClass FCmulti;

        IFeatureClass fcpoint;
        IFeatureClass fcRGQH;
        IFeatureClass fcline;
        IFeatureClass fcpolygon;
        IFeatureClass fcannotation;

        string ColumnQuery = "";
        string Phaycolumn = "";
        IGeoFeatureLayer GeoFeatureLayer = null;
        string filename;
        //List<TreeListNode> list = new List<TreeListNode>() ;
        ArrayList listpoint = new ArrayList();
        ArrayList listline = new ArrayList();
        ArrayList listpolygon = new ArrayList();
        ArrayList listmulti = new ArrayList();
        ArrayList listannotation = new ArrayList();

        ArrayList pointselect = new ArrayList();
        ArrayList lineselect = new ArrayList();
        ArrayList polygonselect = new ArrayList();
        ArrayList multiselect = new ArrayList();
        ArrayList annotationselect = new ArrayList();

        ArrayList listLayerPoint = new ArrayList();
        ArrayList listLayerLine = new ArrayList();
        ArrayList listLayerPLGon = new ArrayList();
        ArrayList listLayerMulti = new ArrayList();
        ArrayList listAnnotation = new ArrayList();
        ObjectThuocTinh a = new ObjectThuocTinh("", "");
        public static IWorkspace IWorkspace;
        string save = "";



        public CapNhatCad_QuyDat()
        {
            InitializeComponent();
        }
        private void CapNhatCad_QuyDat_Load(object sender, EventArgs e)
        {
            //LoadFeaturelayerToCombo(comboBox1, QLHTDT.FormChinh.KienTruc.axMapControl1.Map);
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog_Ok);
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
        private void btMoLop_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (tabControl1.SelectedIndex == 1)
            {
                if (listline.Count != 0)
                { ConvertFeatureClassToShapefile(IWorkspace, FCLine, "Line", @"C:\Windows\Temp", null); }
                else
                {
                    MessageBox.Show("Chưa chọn lớp", "Thông báo");
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (listpolygon.Count != 0)
                { ConvertFeatureClassToShapefile(IWorkspace, FCPolygon, "Polygon", @"C:\Windows\Temp", null); }
                else
                {
                    MessageBox.Show("Chưa chọn lớp", "Thông báo");
                }
            }
            else if (tabControl1.SelectedIndex == 0)
            {
                if (listpoint.Count != 0)
                { ConvertFeatureClassToShapefile(IWorkspace, FCPoint, "Point", @"C:\Windows\Temp", null); }
                else
                {
                    MessageBox.Show("Chưa chọn lớp", "Thông báo");
                }
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                    MessageBox.Show("Lớp Annotation không thể xem trực tiếp được. Vui lòng Xuất file", "Thông báo");
            }
            QLHTDT.FormChinh.KienTruc.axMapControl1.Update();
            QLHTDT.FormChinh.KienTruc.axTOCControl1.Update();
            QLHTDT.FormChinh.KienTruc.axPageLayoutControl1.Update();
            QLHTDT.FormChinh.KienTruc.axPageLayoutControl1.Refresh();
            QLHTDT.FormChinh.KienTruc.axTOCControl1.Refresh();
            QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();


            Cursor = Cursors.Default;
        }
        private void repositoryItemCheckEdit1_Click(object sender, EventArgs e)
        {
            TreeListMultiSelection selectedNodes2 = treeList2.Selection;
            if (selectedNodes2[0].Nodes != null)
            {
                if ((sender as DevExpress.XtraEditors.CheckEdit).Checked == false)
                {
                    listline.Add(selectedNodes2[0].GetValue(treeList2.Columns[0]).ToString());
                }
                if ((sender as DevExpress.XtraEditors.CheckEdit).Checked == true)
                {
                    listline.RemoveAt(listline.IndexOf(selectedNodes2[0].GetValue(treeList2.Columns[0]).ToString()));
                }
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

        private void repositoryItemCheckEdit4_Click(object sender, EventArgs e)
        {
            TreeListMultiSelection selectedNodes4 = treeList4.Selection;
            if (selectedNodes4[0].Nodes != null)
            {
                if ((sender as DevExpress.XtraEditors.CheckEdit).Checked == false)
                {
                    listpoint.Add(selectedNodes4[0].GetValue(treeList4.Columns[0]).ToString());
                }
                if ((sender as DevExpress.XtraEditors.CheckEdit).Checked == true)
                {
                    listpoint.RemoveAt(listpoint.IndexOf(selectedNodes4[0].GetValue(treeList4.Columns[0]).ToString()));
                }
            }
        }
        private void repositoryItemCheckEdit5_Click(object sender, EventArgs e)
        {
            TreeListMultiSelection selectedNodes1 = treeList1.Selection;
            if (selectedNodes1[0].Nodes != null)
            {
                if ((sender as DevExpress.XtraEditors.CheckEdit).Checked == false)
                {
                    listannotation.Add(selectedNodes1[0].GetValue(treeList1.Columns[0]).ToString());
                }
                if ((sender as DevExpress.XtraEditors.CheckEdit).Checked == true)
                {
                    listannotation.RemoveAt(listannotation.IndexOf(selectedNodes1[0].GetValue(treeList1.Columns[0]).ToString()));
                }
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
            if (tabControl1.SelectedIndex == 1)
            {
                for (int i = 0; i < listline.Count; i++)
                {
                    if (i != listline.Count - 1)
                    {
                        WhereClause = WhereClause + Phaycolumn + listline[i].ToString() + Phaycolumn + " OR " + ColumnQuery + " = ";
                    }
                    else { WhereClause = WhereClause + Phaycolumn + listline[i].ToString() + Phaycolumn; }
                }
            }
            else if (tabControl1.SelectedIndex == 2)
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
            else if (tabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < listpoint.Count; i++)
                {
                    if (i != listpoint.Count - 1)
                    {
                        WhereClause = WhereClause + Phaycolumn + listpoint[i].ToString() + Phaycolumn + " OR " + ColumnQuery + " = ";
                    }
                    else { WhereClause = WhereClause + Phaycolumn + listpoint[i].ToString() + Phaycolumn; }
                }
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                for (int i = 0; i < listannotation.Count; i++)
                {
                    if (i != listannotation.Count - 1)
                    {
                        WhereClause = WhereClause + Phaycolumn + listannotation[i].ToString() + Phaycolumn + " OR " + ColumnQuery + " = ";
                    }
                    else { WhereClause = WhereClause + Phaycolumn + listannotation[i].ToString() + Phaycolumn; }
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
            QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayer(l, 0);
            GeoFeatureLayer = (IGeoFeatureLayer)fl;
            if (Loai == "Line")
            {
                QLHTDT.Global.DefineUniqueValueRendererLine(GeoFeatureLayer, ColumnQuery);
                fcline = pFeatureLayer.FeatureClass;
            }
            else if (Loai == "Polygon")
            {
                QLHTDT.Global.DefineUniqueValueRenderer(GeoFeatureLayer, ColumnQuery);
                fcpolygon = pFeatureLayer.FeatureClass;
            }
            if (Loai == "Point")
            {
                QLHTDT.Global.DefineUniqueValueRendererPoint(GeoFeatureLayer, ColumnQuery);
                fcpoint = pFeatureLayer.FeatureClass;
            }
            if (Loai == "Annotation")
            {
                QLHTDT.Global.DefineUniqueValueRendererPoint(GeoFeatureLayer, ColumnQuery);
                fcannotation = pFeatureLayer.FeatureClass;
            }

        }
        public void convertfeature(IWorkspace sourceWorkspace, IFeatureClass sourceFeatureClass, string Loai)
        {
            String targetWorkspacePath = @"C:\Windows\Temp";
            IWorkspaceFactory targetWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
            IWorkspace targetWorkspace = (IWorkspace)targetWorkspaceFactory.OpenFromFile(targetWorkspacePath, 0);
            IDataset sourceWorkspaceDataset = (IDataset)sourceWorkspace;
            IDataset targetWorkspaceDataset = (IDataset)targetWorkspace;
            IName sourceWorkspaceDatasetName = sourceWorkspaceDataset.FullName;
            IName targetWorkspaceDatasetName = targetWorkspaceDataset.FullName;
            IWorkspaceName sourceWorkspaceName = (IWorkspaceName)
              sourceWorkspaceDatasetName;
            IWorkspaceName targetWorkspaceName = (IWorkspaceName)
              targetWorkspaceDatasetName;
            IDataset pDataset = (IDataset)sourceFeatureClass;
            IFeatureClassName sourceFeatureClassName = (IFeatureClassName)pDataset.FullName;
            IFeatureClassName targetFeatureClassName = new FeatureClassNameClass();
            IDatasetName targetDatasetName = (IDatasetName)targetFeatureClassName;
            IFeatureDatasetName trgFDN = (IFeatureDatasetName)targetFeatureClassName.FeatureDatasetName;
            targetDatasetName.Name = filename + Loai + DateTime.Now.ToString("HHmmss");
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
            string WhereClause = "Layer = ";
            if (tabControl1.SelectedIndex == 1)
            {
                for (int i = 0; i < listline.Count; i++)
                {
                    if (i != listline.Count - 1)
                    {
                        WhereClause = WhereClause + Phaycolumn + listline[i].ToString() + Phaycolumn + " OR Layer = ";
                    }
                    else { WhereClause = WhereClause + Phaycolumn + listline[i].ToString() + Phaycolumn; }
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                for (int i = 0; i < listpolygon.Count; i++)
                {
                    if (i != listpolygon.Count - 1)
                    {
                        WhereClause = WhereClause + Phaycolumn + listpolygon[i].ToString() + Phaycolumn + " OR Layer = ";
                    }
                    else { WhereClause = WhereClause + Phaycolumn + listpolygon[i].ToString() + Phaycolumn; }
                }

            }
            else if (tabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < listpoint.Count; i++)
                {
                    if (i != listpoint.Count - 1)
                    {
                        WhereClause = WhereClause + Phaycolumn + listpoint[i].ToString() + Phaycolumn + " OR Layer = ";
                    }
                    else { WhereClause = WhereClause + Phaycolumn + listpoint[i].ToString() + Phaycolumn; }
                }
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                for (int i = 0; i < listannotation.Count; i++)
                {
                    if (i != listannotation.Count - 1)
                    {
                        WhereClause = WhereClause + Phaycolumn + listannotation[i].ToString() + Phaycolumn + " OR Layer = ";
                    }
                    else { WhereClause = WhereClause + Phaycolumn + listannotation[i].ToString() + Phaycolumn; }
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
            if (tabControl1.SelectedIndex == 0)
            {
                fcpoint = pFeatureLayer.FeatureClass;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                fcline = pFeatureLayer.FeatureClass;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                fcpolygon = pFeatureLayer.FeatureClass;
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                fcannotation = pFeatureLayer.FeatureClass;
            }
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

        string savepath = ""; string savename = "";
        private void btXuatFile_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (savepath == "" | savename == "")
                {
                    MessageBox.Show("Chưa chọn nơi lưu file xuất ra", "Thông báo");
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                     splashScreenManager1.ShowWaitForm();
                    if (tabControl1.SelectedIndex == 1)
                    {
                        ConvertFeatureClassToShapefile(IWorkspace, FCLine, "Line", savepath, savename);
                    }
                    else if (tabControl1.SelectedIndex == 2)
                    {
                        ConvertFeatureClassToShapefile(IWorkspace, FCPolygon, "Polygon", savepath, savename);
                    }
                    //else if ( tabControl1.SelectedIndex == 0)
                    //{
                    //    ConvertFeatureClassToShapefile(IWorkspace, FCPolygon, "PolygonRGQH");

                    //}
                    else if (tabControl1.SelectedIndex == 0)
                    {
                        ConvertFeatureClassToShapefile(IWorkspace, FCPoint, "Point", savepath, savename);
                    }
                    else if (tabControl1.SelectedIndex == 3)
                    {
                        string path = @"C:\Windows\Temp\convertplltoplg.py";
                        string Autocad = @"" + openFileDialog1.FileName + "" + "\\Annotation";
                        string Annotation = @"" + txtpolygon.Text + "";
                        string Disabled = "Disabled";

                        try
                        {
                            if (File.Exists(path))
                            { File.Delete(path); }
                            else { }
                            using (System.IO.FileStream fs = File.Create(path))
                            {
                                string py = "import arcpy  " + Environment.NewLine +
                                    "AutoCad = \"" + Autocad + "\"  " + Environment.NewLine +
                                    "Annotation = \"" + Annotation + "\"  " + Environment.NewLine +
                                    "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                                    "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                                    "Annotation1 = \"" + Annotation + "\"  " + Environment.NewLine +
                                    "Annotation2 = \"" + Annotation + "\"  " + Environment.NewLine +
                                    "arcpy.FeatureToPoint_management(AutoCad, Annotation, \"CENTROID\")" + Environment.NewLine +
                                    "arcpy.AddField_management(Annotation, \"TEXTSTRING\", \"TEXT\", \"\", \"\", \"50\", \"\", \"NULLABLE\", \"NON_REQUIRED\", \"\")" + Environment.NewLine +
                                    "arcpy.CalculateField_management(Annotation1, \"TEXTSTRING\", \"!Text!\", \"PYTHON_9.3\", \"\")" + Environment.NewLine +
                                    "arcpy.DeleteField_management(Annotation2, \"Entity;Handle;Owner;LyrFrzn;LyrLock;LyrOn;LyrVPFrzn;LyrHandle;Color;EntColor;LyrColor;BlkColor;Linetype;EntLinetyp;LyrLnType;BlkLinetyp;Elevation;Thickness;LineWt;EntLineWt;LyrLineWt;BlkLineWt;RefName;LTScale;ExtX;ExtY;ExtZ;DocName;DocPath;DocType;DocVer;ScaleX;ScaleY;ScaleZ;Style;FontID;Text;Height;TxtAngle;TxtWidth;TxtOblique;TxtGenType;TxtJust;VertAlign;TxtFont;TxtBoxHt;TxtBoxWd;TxtRefWd;TxtAttach;TxtDir;LnSpace;SpaceFct;TxtMemo;ORIG_FID;EntLinetype;BlkLinetype\")";
                                py = py.Replace("\\", "\\\\");
                                Byte[] info = new UTF8Encoding(true).GetBytes(py);
                                fs.Write(info, 0, info.Length);
                            }
                            try
                            {
                                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                                proc.StartInfo.FileName = path;
                                proc.StartInfo.UseShellExecute = true;
                                proc.Start();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi không thể chuyển đổi dữ liệu", "Thông báo");
                            }
                            MessageBox.Show("Chuyển đổi dữ liệu thành công", "Thông báo");
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi thiết lập dữ liệu", "Thông báo");
                        }

                    }
                    QLHTDT.FormChinh.KienTruc.axMapControl1.Update();
                    QLHTDT.FormChinh.KienTruc.axTOCControl1.Update();
                    QLHTDT.FormChinh.KienTruc.axPageLayoutControl1.Update();
                    QLHTDT.FormChinh.KienTruc.axPageLayoutControl1.Refresh();
                    QLHTDT.FormChinh.KienTruc.axTOCControl1.Refresh();
                    QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Tên lưu dữ liệu bị trùng, vui lòng thay đổi tên khác","Thông báo");
            }
            splashScreenManager1.CloseWaitForm();
            Cursor = Cursors.Default;
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
        private void LoadFeaturelayerToCombo(ComboBox cbo, IMap map)
        {
            for (int i = 0; i < map.LayerCount; i++)
            {
                ILayer pLayer = map.get_Layer(i);
                cbo.Items.Add(pLayer.Name);
            }
        }


        public void gettablelayer(IFeatureClass fc, ArrayList Treelist)
        {
            ICursor cursor = (ICursor)fc.Search(null, false);
            IDataStatistics dataStatistics = new DataStatisticsClass();
            dataStatistics.Field = "Layer";
            dataStatistics.Cursor = cursor;
            System.Collections.IEnumerator enumerator = dataStatistics.UniqueValues;
            enumerator.Reset();
        }
        private OpenFileDialog openFileDialog;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "AutoCad Files|*.dwg; *.dxf|MicroStation file|*.dgn";
            openFileDialog1.Title = "Chọn file Autocad hoặc MicrostationSE cần mở";
            openFileDialog1.ShowDialog();
        }
        private void openFileDialog_Ok(object sender, CancelEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
            string typefile = System.IO.Path.GetExtension(openFileDialog1.FileName);
            if (typefile == ".dwg")
            {
                ColumnQuery = "Layer";
                Phaycolumn = "'";
                treeListColumn1.Caption = "Lớp layer";
                treeListColumn3.Caption = "Lớp layer";
                treeListColumn4.Caption = "Lớp layer";
                treeListColumn8.Caption = "Lớp layer";
            }
            else if (typefile == ".dgn")
            {
                ColumnQuery = "Level"; Phaycolumn = "";
                treeListColumn1.Caption = "Lớp Level";
                treeListColumn3.Caption = "Lớp Level";
                treeListColumn4.Caption = "Lớp Level";
                treeListColumn8.Caption = "Lớp Level";
            }
            IWorkspaceFactory pCadWKSFact = new CadWorkspaceFactory();
            IWorkspace pWorkspace1 = pCadWKSFact.OpenFromFile(workspacePath, 0);
            IFeatureWorkspace pWorkspace2 = (IFeatureWorkspace)pWorkspace1;
            IFeatureClass pFeatureClass;
            IFeatureDataset pFeatureDataset = pWorkspace2.OpenFeatureDataset(fileName);
            IFeatureClassContainer pFeatureClassContainer = pFeatureDataset as IFeatureClassContainer;



            CadAnnotationLayer pCadFeatureLayer1;
            for (int i = 0; i < pFeatureClassContainer.ClassCount - 1; i++)
            {
                pFeatureClass = pFeatureClassContainer.Class[i];
                IFeatureLayer fl = new FeatureLayer();
                fl.FeatureClass = pFeatureClass;
                var l = fl as ILayer;
                if (pFeatureClass.FeatureType == esriFeatureType.esriFTCoverageAnnotation)
                {
                    pCadFeatureLayer1 = pFeatureClassContainer.Class[i] as CadAnnotationLayer;
                    l.Name = fileName + ". phụ chú";
                    FCAnnotation = pFeatureClass;
                }
                else if (pFeatureClass.FeatureType == esriFeatureType.esriFTAnnotation)
                {
                    l.Name = fileName + ". phụ chú";
                    FCAnnotation = pFeatureClass;
                }
                else
                {
                    if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                    {
                        l.Name = fileName + ". Điểm";
                        FCPoint = pFeatureClass;
                    }
                    else if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                    {
                        l.Name = fileName + ". Vùng";
                        FCPolygon = pFeatureClass;
                    }
                    else if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                    {
                        l.Name = fileName + ". Đường";
                        FCLine = pFeatureClass;
                    }
                    else if (pFeatureClass.FeatureType == esriFeatureType.esriFTCoverageAnnotation)
                    {
                        l.Name = fileName + ". Annotation";
                        FCAnnotation = pFeatureClass;
                    }
                    else
                    {
                        l.Name = fileName + " . " + pFeatureClass.ShapeType.ToString();
                        FCmulti = pFeatureClass;
                    }
                    //axMapControl1.AddLayer(l, 0);

                }
            }
            getvaluefield(FCLine, treeList2);
            getvaluefield(FCPolygon, treeList3);
            getvaluefield(FCPoint, treeList4);
            getvaluefield(FCmulti, treeList1);
            //getvaluefield(FCAnnotation, treeList1);
            filename = Name;

            IWorkspace = pWorkspace1;
            Cursor = Cursors.Default;
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
        public void getvaluefield1(IFeatureClass fc, DevExpress.XtraTreeList.TreeList Treelist)
        {
            //Treelist = new TreeList();
            Treelist.Nodes.Clear();
            //ICursor cursor = (ICursor)fc.Search(null, false);
            IDataStatistics dataStatistics = new DataStatisticsClass();
            dataStatistics.Field = ColumnQuery;
            //dataStatistics.Cursor = cursor;
            System.Collections.IEnumerator enumerator = dataStatistics.UniqueValues;
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                object myObject = enumerator.Current;
                Treelist.AppendNode(new object[] { myObject.ToString(), false, "Chọn lớp dữ liệu" }, -1);
            }
        }

    }
}
