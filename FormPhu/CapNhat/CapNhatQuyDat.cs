using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using QLHTDT.FormChinh;
using ESRI.ArcGIS.Display;
using stdole;
using System.Data.SqlClient;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Geoprocessor;
using System.ComponentModel;
using ESRI.ArcGIS.Geoprocessing;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class CapNhatQuyDat : Form
    {
        private static esriLicenseStatus pLicensestatus;
        private static IAoInitialize m_Aolnitialize;

        public static IFeatureClass featureClassSHP1;
        public static IFeatureClass featureClassSDE1;
        ESRI.ArcGIS.Carto.IActiveView activeView;
        IFeatureWorkspace featureWorkspaceSHP1;
        public static ILayer layershp1;
        public static ILayer layersde1;
        IMap pmap;
        SaveFileDialog SaveFileDialogSave;
        string save = "";
        string pathPhanKhuPoly = "";
        string pathPhanKhuText = "";
        string pathLeDuongLine = "";
        string pathChiaLoLine = "";
        string pathSTTLoDat = "";
        OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
        public CapNhatQuyDat()
        {
            InitializeComponent();
            activeView = KienTruc.axMapControl1.ActiveView;
            this.TopMost = true;
            pmap = KienTruc.axMapControl1.Map;

            m_Aolnitialize = new AoInitialize();
            pLicensestatus = esriLicenseStatus.esriLicenseUnavailable;
            pLicensestatus = m_Aolnitialize.Initialize(esriLicenseProductCode.esriLicenseProductCodeEngine);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (activeView == null)
            {
                return;
            }
            openFileDialog.InitialDirectory = Properties.Settings.Default.pathPhanKhuPolygon;
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string PhanKhuPolygon = openFileDialog.FileName;

                if (PhanKhuPolygon != "")
                {
                    pathPhanKhuPoly = PhanKhuPolygon;
                    ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
                    featureWorkspaceSHP1 = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(PhanKhuPolygon), 0);
                    featureClassSHP1 = featureWorkspaceSHP1.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(PhanKhuPolygon));
                    ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = new ESRI.ArcGIS.Carto.FeatureLayerClass();
                    featureLayer.FeatureClass = featureClassSHP1;
                    featureLayer.Name = featureClassSHP1.AliasName;
                    featureLayer.Visible = true;
                    if (featureClassSHP1.ShapeType != esriGeometryType.esriGeometryPolygon)
                    {
                        MessageBox.Show("Shapefile không đúng dạng Vùng", "Thông báo");
                    }
                    else
                    {
                        activeView.FocusMap.AddLayer(featureLayer);
                        activeView.Extent = activeView.FullExtent;
                        activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                        txt1.Text = PhanKhuPolygon;
                        QLHTDT.Properties.Settings.Default.pathPhanKhuPolygon = System.IO.Path.GetDirectoryName(PhanKhuPolygon);
                        QLHTDT.Properties.Settings.Default.Save();
                        layershp1 = KienTruc.axMapControl1.get_Layer(0);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (activeView == null)
            {
                return;
            }
            openFileDialog.InitialDirectory = Properties.Settings.Default.pathPhanKhuPolygon;
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string PhanKhuText = openFileDialog.FileName;

                if (PhanKhuText != "")
                {
                    pathPhanKhuText = PhanKhuText;
                    ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
                    featureWorkspaceSHP1 = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(PhanKhuText), 0);
                    featureClassSHP1 = featureWorkspaceSHP1.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(PhanKhuText));
                    ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = new ESRI.ArcGIS.Carto.FeatureLayerClass();
                    featureLayer.FeatureClass = featureClassSHP1;
                    featureLayer.Name = featureClassSHP1.AliasName;
                    featureLayer.Visible = true;
                    if (featureClassSHP1.ShapeType != esriGeometryType.esriGeometryPoint)
                    {
                        MessageBox.Show("Shapefile không đúng dạng Điểm", "Thông báo");
                    }
                    else
                    {
                        activeView.FocusMap.AddLayer(featureLayer);
                        activeView.Extent = activeView.FullExtent;
                        activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                        txt2.Text = PhanKhuText;
                        QLHTDT.Properties.Settings.Default.pathPhanKhuPolygon = System.IO.Path.GetDirectoryName(PhanKhuText);
                        QLHTDT.Properties.Settings.Default.Save();
                        layershp1 = KienTruc.axMapControl1.get_Layer(0);
                    }
                }
            }
        }
        private void SaveFileDialogSave1(object sender, CancelEventArgs e)
        {
            //add object file to listbox1
            Cursor = Cursors.WaitCursor;
            save = SaveFileDialogSave.FileName;
            txt6.Text = SaveFileDialogSave.FileName;
            Cursor = Cursors.Default;
        }

        private void btChuyen_Click(object sender, EventArgs e)
        {
            //this.Hide();
            string path = @"C:\Windows\Temp\convertplltoplg.py";
            string Shape1_ = @"C:\Windows\Temp\Shape1" + DateTime.Now.ToString("HHmmss") + ".shp";
            string Shape2_ = @"C:\Windows\Temp\Shape2" + DateTime.Now.ToString("HHmmss") + ".shp";
            string Shape10_ = @"C:\Windows\Temp\Shape10" + DateTime.Now.ToString("HHmmss") + ".shp";
            string Shape11_shp = @"C:\Windows\Temp\Shape11" + DateTime.Now.ToString("HHmmss") + ".shp";
            string Shape12 = @"C:\Windows\Temp\Shape12" + DateTime.Now.ToString("HHmmss") + ".shp";
            string Shape6_ = @"C:\Windows\Temp\Shape6" + DateTime.Now.ToString("HHmmss") + ".shp";
            string Shape7_ = @"C:\Windows\Temp\Shape7" + DateTime.Now.ToString("HHmmss") + ".shp";
            string Shape9_ = @"C:\Windows\Temp\Shape9" + DateTime.Now.ToString("HHmmss") + ".shp";
            string Shape3_ = @"C:\Windows\Temp\Shape3" + DateTime.Now.ToString("HHmmss") + ".shp";
            string Disabled = "Disabled";

            try
            {
                if (File.Exists(path))
                { File.Delete(path); }
                else { }
                using (System.IO.FileStream fs = File.Create(path))
                {
                    string py = "import arcpy  " + Environment.NewLine +
                        "PhanKhu_polygon = \"" + pathPhanKhuPoly + "\"  " + Environment.NewLine +
                        "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "PhanKhu_text = \"" + pathPhanKhuText + "\"  " + Environment.NewLine +
                        "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "LeDuong_line = \"" + pathLeDuongLine + "\"  " + Environment.NewLine +
                        "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "ChiaLo_line = \"" + pathChiaLoLine + "\"  " + Environment.NewLine +
                        "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "STTDat_text = \"" + pathSTTLoDat + "\"  " + Environment.NewLine +
                        "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "SanPham = \"" + save + "\"  " + Environment.NewLine +
                        "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "Shape1 = \"" + Shape1_ + "\"  " + Environment.NewLine +
                        "Shape2 = \"" + Shape2_ + "\"  " + Environment.NewLine +
                        "Shape10 = \"" + Shape10_ + "\"  " + Environment.NewLine +
                        "Shape11_shp = \"" + Shape11_shp + "\"  " + Environment.NewLine +
                        "Shape12 = \"" + Shape12 + "\"  " + Environment.NewLine +
                        "Shape6 = \"" + Shape6_ + "\"  " + Environment.NewLine +
                        "Shape7 = \"" + Shape7_ + "\"  " + Environment.NewLine +
                        "Shape9 = \"" + Shape9_ + "\"  " + Environment.NewLine +
                        "SanPham_shp = \"" + save + "\"  " + Environment.NewLine +
                        "LeDuong_line__2_ = \"" + pathLeDuongLine + "\"  " + Environment.NewLine +
                        "Shape3 = \"" + Shape3_ + "\"  " + Environment.NewLine +
                        "arcpy.Merge_management(\"" + pathChiaLoLine + "; " + pathLeDuongLine + "\", Shape6, \"\")" + Environment.NewLine +
                        "arcpy.FeatureToPolygon_management(\"" + Shape6_ + "\", Shape7, \"\", \"ATTRIBUTES\", \"\")" + Environment.NewLine +
                        "arcpy.FeatureToPolygon_management(\"" + Shape7_ + "\", Shape9, \"\", \"ATTRIBUTES\", STTDat_text)" + Environment.NewLine +
                        "arcpy.FeatureToPolygon_management(\"" + pathLeDuongLine + "\", Shape3, \"\", \"ATTRIBUTES\", \"\")" + Environment.NewLine +
                        "arcpy.FeatureToPolygon_management(\"" + pathPhanKhuPoly + "\", Shape1, \"\", \"ATTRIBUTES\", PhanKhu_text)" + Environment.NewLine +
                        "arcpy.FeatureToPoint_management(Shape1, Shape2, \"CENTROID\")" + Environment.NewLine +
                        "arcpy.FeatureToPolygon_management(\"" + Shape3_ + "\", Shape10, \"\", \"ATTRIBUTES\", Shape2)" + Environment.NewLine +
                        "arcpy.Union_analysis(\"" + Shape10_ + " #;" + Shape7_ + " #\", Shape11_shp, \"ALL\", \"\", \"GAPS\")"+ Environment.NewLine +
                        "arcpy.FeatureToPoint_management(Shape11_shp, Shape12, \"CENTROID\")" + Environment.NewLine +
                        "tempEnvironment0 = arcpy.env.outputZFlag" + Environment.NewLine +
                        "arcpy.env.outputZFlag = \"Disabled\"" + Environment.NewLine +
                        "tempEnvironment1 = arcpy.env.outputMFlag" + Environment.NewLine +
                        "arcpy.env.outputMFlag = \"Disabled\"" + Environment.NewLine +
                        "arcpy.FeatureToPolygon_management(\"" + Shape9_ + "\", SanPham, \"\", \"ATTRIBUTES\", Shape12)" + Environment.NewLine +
                        "arcpy.env.outputZFlag = tempEnvironment0" + Environment.NewLine +
                        "arcpy.env.outputMFlag = tempEnvironment1" + Environment.NewLine +
                        "arcpy.JoinField_management(SanPham, \"FID\", Shape9, \"FID\", \"TEXTSTRING\")" + Environment.NewLine +
                        "arcpy.DeleteField_management(\"" + save + "\", \"ORIG_FID;FID_Shape7;FID_Shape1;Join_Count;Entity;Handle;LyrFrzn;LyrLock;LyrOn;LyrVPFrzn;LyrHandle;Color;EntColor;LyrColor;BlkColor;Linetype;EntLinetyp;LyrLnType;BlkLinetyp;Elevation;Thickness;LineWt;EntLineWt;LyrLineWt;BlkLineWt;RefName;LTScale;ExtX;ExtY;ExtZ;DocName;DocPath;DocType;DocVer\")";
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (activeView == null)
            {
                return;
            }
            openFileDialog.InitialDirectory = Properties.Settings.Default.pathPhanKhuPolygon;
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string LeDuongLine = openFileDialog.FileName;

                if (LeDuongLine != "")
                {
                    pathLeDuongLine = LeDuongLine;
                    ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
                    featureWorkspaceSHP1 = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(LeDuongLine), 0);
                    featureClassSHP1 = featureWorkspaceSHP1.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(LeDuongLine));
                    ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = new ESRI.ArcGIS.Carto.FeatureLayerClass();
                    featureLayer.FeatureClass = featureClassSHP1;
                    featureLayer.Name = featureClassSHP1.AliasName;
                    featureLayer.Visible = true;
                    if (featureClassSHP1.ShapeType != esriGeometryType.esriGeometryPolyline)
                    {
                        MessageBox.Show("Shapefile không đúng dạng Đường", "Thông báo");
                    }
                    else
                    {
                        activeView.FocusMap.AddLayer(featureLayer);
                        activeView.Extent = activeView.FullExtent;
                        activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                        txt3.Text = LeDuongLine;
                        QLHTDT.Properties.Settings.Default.pathPhanKhuPolygon = System.IO.Path.GetDirectoryName(LeDuongLine);
                        QLHTDT.Properties.Settings.Default.Save();
                        layershp1 = KienTruc.axMapControl1.get_Layer(0);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (activeView == null)
            {
                return;
            }
            openFileDialog.InitialDirectory = Properties.Settings.Default.pathPhanKhuPolygon;
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ChiaLoLine = openFileDialog.FileName;

                if (ChiaLoLine != "")
                {
                    pathChiaLoLine = ChiaLoLine;
                    ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
                    featureWorkspaceSHP1 = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(ChiaLoLine), 0);
                    featureClassSHP1 = featureWorkspaceSHP1.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(ChiaLoLine));
                    ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = new ESRI.ArcGIS.Carto.FeatureLayerClass();
                    featureLayer.FeatureClass = featureClassSHP1;
                    featureLayer.Name = featureClassSHP1.AliasName;
                    featureLayer.Visible = true;
                    if (featureClassSHP1.ShapeType != esriGeometryType.esriGeometryPolyline)
                    {
                        MessageBox.Show("Shapefile không đúng dạng Đường", "Thông báo");
                    }
                    else
                    {
                        activeView.FocusMap.AddLayer(featureLayer);
                        activeView.Extent = activeView.FullExtent;
                        activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                        txt4.Text = ChiaLoLine;
                        QLHTDT.Properties.Settings.Default.pathPhanKhuPolygon = System.IO.Path.GetDirectoryName(ChiaLoLine);
                        QLHTDT.Properties.Settings.Default.Save();
                        layershp1 = KienTruc.axMapControl1.get_Layer(0);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (activeView == null)
            {
                return;
            }
            openFileDialog.InitialDirectory = Properties.Settings.Default.pathPhanKhuPolygon;
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string STTLoDat = openFileDialog.FileName;

                if (STTLoDat != "")
                {
                    pathSTTLoDat = STTLoDat;
                    ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
                    featureWorkspaceSHP1 = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(STTLoDat), 0);
                    featureClassSHP1 = featureWorkspaceSHP1.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(STTLoDat));
                    ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = new ESRI.ArcGIS.Carto.FeatureLayerClass();
                    featureLayer.FeatureClass = featureClassSHP1;
                    featureLayer.Name = featureClassSHP1.AliasName;
                    featureLayer.Visible = true;
                    if (featureClassSHP1.ShapeType != esriGeometryType.esriGeometryPoint)
                    {
                        MessageBox.Show("Shapefile không đúng dạng Điểm", "Thông báo");
                    }
                    else
                    {
                        activeView.FocusMap.AddLayer(featureLayer);
                        activeView.Extent = activeView.FullExtent;
                        activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                        txt5.Text = STTLoDat;
                        QLHTDT.Properties.Settings.Default.pathPhanKhuPolygon = System.IO.Path.GetDirectoryName(STTLoDat);
                        QLHTDT.Properties.Settings.Default.Save();
                        layershp1 = KienTruc.axMapControl1.get_Layer(0);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialogSave = new System.Windows.Forms.SaveFileDialog();
            SaveFileDialogSave.Filter = "Shape file|*.shp| All files (*.*)|*.*";
            SaveFileDialogSave.InitialDirectory = Properties.Settings.Default.pathPolygon;
            SaveFileDialogSave.FileOk += new System.ComponentModel.CancelEventHandler(SaveFileDialogSave1);
            SaveFileDialogSave.CheckPathExists = true;
            SaveFileDialogSave.ShowDialog();
        }

    }
}
