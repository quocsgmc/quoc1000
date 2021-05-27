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
    public partial class TestMBQH : Form
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
        string pathline = "";
        OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
        public TestMBQH()
        {
            InitializeComponent();
            activeView = QuanTriHeThong.axMapControl1.ActiveView;
            this.TopMost = true;
            pmap = QuanTriHeThong.axMapControl1.Map;

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
            openFileDialog.InitialDirectory = Properties.Settings.Default.pathLine;
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string shapefileLocation = openFileDialog.FileName;

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
                    if (featureClassSHP1.ShapeType != esriGeometryType.esriGeometryPolyline)
                    {
                        MessageBox.Show("Shapefile không đúng dạng đường", "Thông báo");
                    }
                    else
                    {
                        activeView.FocusMap.AddLayer(featureLayer);
                        activeView.Extent = activeView.FullExtent;
                        activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                        txtline.Text = shapefileLocation;
                        QLHTDT.Properties.Settings.Default.pathLine = System.IO.Path.GetDirectoryName(shapefileLocation);
                        QLHTDT.Properties.Settings.Default.Save();
                        layershp1 = QuanTriHeThong.axMapControl1.get_Layer(0);
                        IRgbColor color2 = new RgbColorClass();
                        color2.Red = 224;
                        color2.Green = 255;
                        color2.Blue = 255;
                        color2.UseWindowsDithering = true;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SaveFileDialogSave = new System.Windows.Forms.SaveFileDialog();
            SaveFileDialogSave.Filter = "Shape file|*.shp| All files (*.*)|*.*";
            SaveFileDialogSave.InitialDirectory = Properties.Settings.Default.pathPolygon;
            SaveFileDialogSave.FileOk += new System.ComponentModel.CancelEventHandler(SaveFileDialogSave1);
            SaveFileDialogSave.CheckPathExists = true;
            SaveFileDialogSave.ShowDialog();
        }
        private void SaveFileDialogSave1(object sender, CancelEventArgs e)
        {
            //add object file to listbox1
            Cursor = Cursors.WaitCursor;
            save = SaveFileDialogSave.FileName;
            txtpolygon.Text = SaveFileDialogSave.FileName;
            Cursor = Cursors.Default;
        }

        private void btChuyen_Click(object sender, EventArgs e)
        {
            this.Hide();
            string path = @"C:\Windows\Temp\convertplltoplg.py";
            string Disabled = "Disabled";
            string TenLoaiDat = comboLoaiDat.Text;

            try
            {
                if (File.Exists(path))
                { File.Delete(path); }
                else { }
                using (System.IO.FileStream fs = File.Create(path))
                {
                    string py = "import arcpy  " + Environment.NewLine +
                        "line_shp = \"" + pathline + "\"  " + Environment.NewLine +
                        "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "Polygon_shp = \"" + save + "\"  " + Environment.NewLine +
                        "tempEnvironment0 = arcpy.env.outputZFlag" + Environment.NewLine +
                        "arcpy.env.outputZFlag = \"" + Disabled + "\" " + Environment.NewLine +
                        "tempEnvironment0 = arcpy.env.outputMFlag" + Environment.NewLine +
                        "arcpy.env.outputMFlag  = \"" + Disabled + "\" " + Environment.NewLine +

                        "arcpy.FeatureToPolygon_management(\"'" + pathline + "'\", Polygon_shp, \"\", \"NO_ATTRIBUTES\", \"\")" + Environment.NewLine +
                        "arcpy.env.outputZFlag = tempEnvironment0" + Environment.NewLine +
                        "arcpy.env.outputMFlag = tempEnvironment1" + Environment.NewLine +
                        "arcpy.AddField_management(\"'" + save + "'\", \"TenLoaiDat\", \"TEXT\", \"\", \"\",\"50\",\"\", \"NULLABLE\",\"NON_REQUIRED\",\"\")" + Environment.NewLine +
                        "arcpy.CalculateField_management(\"'" + save + "'\", \"'" + TenLoaiDat + "'\", Expression, \"VB\", \"\")";

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





            //IVariantArray parameters = new VarArrayClass();
            //parameters.Add(@"F:\SGMC\BanDoQuyHoach\HTDT.gdb\HoaAn_MuongThoatNuoc_HA");
            //parameters.Add("DWG_R2007");
            //parameters.Add(@"C:\Users\PC\Desktop\LineToPolygon\ExportCAD.DWG");
            //Geoprocessor gp = new Geoprocessor();
            //bool response = RunTool("ExportCAD_conversion", parameters, null, false);
        }
        //public static bool RunTool(string toolName, IVariantArray parameters, ITrackCancel TC, bool showResultDialog)
        //{
        //    Geoprocessor gp = new Geoprocessor();
        //    IGeoProcessorResult result = null;
        //    // Execute the tool            
        //    try
        //    {
        //        result = (IGeoProcessorResult)gp.Execute(toolName, parameters, TC);
        //        string re = result.GetOutput(0).GetAsText();
        //        if (showResultDialog)
        //            ReturnMessages(gp);
        //        if (result.MaxSeverity == 2) //error
        //            return false;
        //        else
        //            return true;
        //    }
        //    catch (COMException err)
        //    {
        //        MessageBox.Show(err.Message + " in RunTool");
        //        ReturnMessages(gp);
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message + " in RunTool");
        //        ReturnMessages(gp);
        //    }
        //    return false;
        //}
        //public static void RunTool1(Geoprocessor geoprocessor, IGPProcess process, ITrackCancel tc)
        //{
        //    // set overwrite option to true
        //    geoprocessor.OverwriteOutput = true;

        //    // execute tool
        //    try
        //    {
        //        geoprocessor.Execute(process, null);
        //        ReturnMessages(geoprocessor);
        //    }
        //    catch (Exception err)
        //    {
        //        Console.WriteLine(err.Message);
        //        ReturnMessages(geoprocessor);
        //    }
        //}

        //private static void ReturnMessages(Geoprocessor gp)
        //{
        //    if (gp.MessageCount > 0)
        //    {
        //        for (int i = 0; i <= gp.MessageCount - 1; i++)
        //        {
        //            Console.WriteLine(gp.GetMessage(i));
        //        }
        //    }
        //}
    }
}
