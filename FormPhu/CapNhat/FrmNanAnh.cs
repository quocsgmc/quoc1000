using DevExpress.XtraGrid.Views.Grid;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
//using ESRI.ArcGIS.GeoAnalyst;
//using ESRI.ArcGIS.SpatialAnalyst;
using System.IO;
using System.Net;
using System.Data.SqlClient;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class FrmNanAnh : Form
    {
        private ESRI.ArcGIS.Carto.IMap dmap;

        public static DataTable dtNanAnh; public static DataRow drNanAnh;
        IRasterGeometryProc rasterPropc;
        SaveFileDialog saveFile;
        IRaster raster;
        public int ele;
        public List<int> list = new List<int>();
        IRasterDataset rasterDataset;
        IRasterLayer rasterLayer;
        IWorkspaceFactory wsFactory = new RasterWorkspaceFactory(); IRasterWorkspace rasterWS; IRasterDataset2 rasterDataset2;
        public FrmNanAnh(string path)
        {
            rasterLayer = new RasterLayer();
            rasterLayer.CreateFromFilePath(path);
            rasterWS = (IRasterWorkspace)wsFactory.OpenFromFile(System.IO.Path.GetDirectoryName(FormChinh.KienTruc.AnhBDNan), 0);
            rasterDataset = rasterWS.OpenRasterDataset(System.IO.Path.GetFileName(FormChinh.KienTruc.AnhBDNan));
            rasterDataset2 = rasterDataset as IRasterDataset2;
            rasterPropc = new RasterGeometryProc();
            raster = rasterDataset.CreateDefaultRaster();
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
            gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);

          
        }
        void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void FrmNanAnh_Load(object sender, EventArgs e)
        {
               dtNanAnh = new DataTable();
            dtNanAnh.Columns.Add("STT", typeof(string));
            dtNanAnh.Columns.Add("x1", typeof(double));
            dtNanAnh.Columns.Add("y1", typeof(double));
            dtNanAnh.Columns.Add("x2", typeof(double));
            dtNanAnh.Columns.Add("y2", typeof(double));

            gridView1.OptionsBehavior.Editable = true;
            bindingNavigator1.Visible = true;

            this.bindingSource1.DataSource = dtNanAnh;



        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            gridView1.RefreshData();
        }
        private void btNanAnh_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (gridView1.DataRowCount > 2 | gridView1.DataRowCount == 0)
            {
                for (int i = 0; i < dtNanAnh.Rows.Count; i++)
                {
                    for (int i2 = 0; i2 < dtNanAnh.Columns.Count; i2++)
                    {
                        double d;
                        if (dtNanAnh.Rows[i][i2].ToString() == "" | !((double.TryParse(dtNanAnh.Rows[i][i2].ToString(), out d) && !Double.IsNaN(d) && !Double.IsInfinity(d))))
                        {
                            check = false;
                        }
                    }
                }
                if (check != false)
                {
                    object missing = Type.Missing;
                    IPointCollection sourcePoints = new MultipointClass();
                    IPointCollection targetPoints = new MultipointClass();
                    for (int i = 0; i < dtNanAnh.Rows.Count; i++)
                    {
                        double x1 = Convert.ToDouble(dtNanAnh.Rows[i][1].ToString());
                        double y1 = Convert.ToDouble(dtNanAnh.Rows[i][2].ToString());
                        double x2 = Convert.ToDouble(dtNanAnh.Rows[i][3].ToString());
                        double y2 = Convert.ToDouble(dtNanAnh.Rows[i][4].ToString());
                        IPoint pointSource = new PointClass();
                        pointSource.PutCoords(x1, y1);
                        sourcePoints.AddPoint(pointSource, ref missing, ref missing);
                        IPoint pointTarget = new PointClass();
                        pointTarget.PutCoords(x2, y2);
                        targetPoints.AddPoint(pointTarget, ref missing, ref missing);
                    }
                    rasterPropc.Warp(sourcePoints, targetPoints, esriGeoTransTypeEnum.esriGeoTransPolyOrder1, raster);
                    rasterPropc.Register(raster);
                    FormChinh.KienTruc.axMapControl1.Refresh();
                    //clip the raster to a TIFF file
                    //ClipRasterWithPolygon(path, rasterFile, shapeFile, outputFolder, "PNG", outputFile);
                }
                else { MessageBox.Show("Dữ liệu nhập vào chưa đúng. Xin kiểm tra lại!", "Thông báo"); }
            }
            else { MessageBox.Show( "Xin nhập ít nhất 3 điểm", "Thông báo"); }
        }

        private void btXuatAnh_Click(object sender, EventArgs e)
        {
            saveFile = new SaveFileDialog();
            saveFile.FileOk += new System.ComponentModel.CancelEventHandler(saveFile_FileOk);
            saveFile.Filter = "PNG|*.png|JPG| *.jpg|TIFF| *.tiff|BMP| *.bmp|IMAGINE Image| *.img";
            saveFile.Title = "Chọn file ảnh bản đồ giấy cần cập nhật";
            saveFile.ShowDialog();
            
        }
        private void saveFile_FileOk(object sender, CancelEventArgs e)
        {
            string typefile = System.IO.Path.GetExtension(saveFile.FileName);
            typefile = typefile.Replace(".", "");
            if (typefile == "img")
            { rasterPropc.Rectify(saveFile.FileName, "IMAGINE Image", raster); }
            else
            {
                rasterPropc.Rectify(saveFile.FileName, typefile, raster);
            }
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            IGraphicsContainer map = FormChinh.KienTruc.axMapControl1.Map as IGraphicsContainer;
            //gridView1.RefreshData();
            //ele = 0; list = new List<int>();
            //gridView1.RefreshData();
            //int x = 0;
            //
            //map.Reset();
            //IElementProperties Elementproperties = null;
            //while ((Elementproperties = (IElementProperties)map.Next()) != null)
            //{
            //    //string ttt = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STT").ToString();
            //    ele = ele + 1;
            //    x = gridView1.FocusedRowHandle + 1;
            //    if (x == ((ele + 1) / 2))
            //    {
            //        list.Add(ele);
            //    }
            //}
            map.Reset();
            IElementProperties Elementproperties2 = null;
            for (int i = ele; i > 0; i--)
            {
                Elementproperties2 = (IElementProperties)map.Next();
                if (list.Contains(i) && Elementproperties2 != null)
                {
                    IElement element = (IElement)Elementproperties2;
                    map.DeleteElement(element);
                }
            }
            FormChinh.KienTruc.axMapControl1.Refresh();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            ele = 0; list = new List<int>();
            gridView1.RefreshData();
            int x = 0;
            IGraphicsContainer map = FormChinh.KienTruc.axMapControl1.Map as IGraphicsContainer;
            map.Reset();
            IElementProperties Elementproperties = null;
            while ((Elementproperties = (IElementProperties)map.Next()) != null)
            {
                ele = ele + 1;
                x = gridView1.GetSelectedRows()[0] + 1;
                if (x == ((ele + 1) / 2))
                {
                    list.Add(ele);
                }
              
            }
           
        }

        //clip raster cách 1
        //public IRasterAnalysisEnvironment SetNewDefaultEnvironment(IEnvelope envelope_Extent, double nCellSize, IGeoDataset geoDataset_Mask, IWorkspace workspace, ISpatialReference spatialReference)
        //{
        //    // Creates a new RasterAnalysis object and sets it as a new default setting.
        //    // Create a RasterAnalysis object.
        //    IRasterAnalysisEnvironment rasterAnalysisEnvironment = new RasterAnalysisClass();
        //    try
        //    {
        //        // Set the new default extent.
        //        if (envelope_Extent != null)
        //        {
        //            object extentProvider = (object)envelope_Extent;
        //            object snapRasterData = Type.Missing;
        //            rasterAnalysisEnvironment.SetExtent
        //                (esriRasterEnvSettingEnum.esriRasterEnvValue, ref extentProvider,
        //                ref snapRasterData);
        //        }
        //        // Set the new default cell size.
        //        if (nCellSize > 0)
        //        {
        //            object cellSizeProvider = (object)nCellSize;
        //            rasterAnalysisEnvironment.SetCellSize
        //                (esriRasterEnvSettingEnum.esriRasterEnvValue, ref cellSizeProvider);
        //        }
        //        // Set the new default mask for analysis.
        //        if (geoDataset_Mask != null)
        //        {
        //            rasterAnalysisEnvironment.Mask = geoDataset_Mask;
        //        }
        //        // Set the new default output workspace.
        //        if (workspace != null)
        //        {
        //            rasterAnalysisEnvironment.OutWorkspace = workspace;
        //        }
        //        // Set the new default output spatial reference.
        //        if (spatialReference != null)
        //        {
        //            rasterAnalysisEnvironment.OutSpatialReference = spatialReference;
        //        }
        //        // Set it as the default settings.
        //        rasterAnalysisEnvironment.SetAsNewDefaultEnvironment();
        //    }
        //    catch (Exception ex)
        //    {
        //        rasterAnalysisEnvironment = null;
        //    }
        //    return rasterAnalysisEnvironment;
        //}

        //public void SetOpEnvironment()
        //{
        //    // Set tool level analysis environment.
        //    // Create an Op (RasterMaker operator).
        //    IRasterMakerOp rasterMakerOp = new RasterMakerOpClass();
        //    // Query Op for IRasterAnalysisEnvironment.
        //    IRasterAnalysisEnvironment rasterAnalysisEnvironment =
        //        (IRasterAnalysisEnvironment)rasterMakerOp;
        //    // Set output workspace for the Op.
        //    IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactoryClass();
        //    IWorkspace workspace = workspaceFactory.OpenFromFile("c:\\temp", 0);
        //    rasterAnalysisEnvironment.OutWorkspace = workspace;
        //    // Set cell size for the Op.
        //    object object_cellSize = (System.Object)30;
        //    rasterAnalysisEnvironment.SetCellSize
        //        (esriRasterEnvSettingEnum.esriRasterEnvValue, ref object_cellSize);
        //    // Set output extent for the Op.
        //    IEnvelope envelope = new EnvelopeClass();
        //    envelope.XMin = 0;
        //    envelope.YMin = 0;
        //    envelope.XMax = 3000;
        //    envelope.YMax = 3000;
        //    object extentProvider = (System.Object)envelope;
        //    object object_Missing = System.Type.Missing;
        //    rasterAnalysisEnvironment.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue,
        //        ref extentProvider, ref object_Missing);
        //    // Perform spatial operation.
        //    IRaster outRas = null;
        //    outRas = (IRaster)(rasterMakerOp.MakeConstant(10, true));
        //}

        /// <summary>
        /// //clip raster cách 2
        /// </summary>
        /// <param name="RT"></param> -----------raster cần cắt 
        /// <param name="featureS"></param> -----vùng cắt (đối tượng vùng)
        /// <param name="outputFolder"></param> -folder xuất file (C:\folder
        /// <param name="Format"></param>   -----loại ảnh xuất (png, tiff, ...)
        /// <param name="outputFile"></param>----tên file ảnh xuất ra (vd test.png)
        public static void ClipRasterbyPolygon( IRaster RT, IFeature featureS, string outputFolder, string Format, string outputFile)
        {
            IRaster raster = RT;
            IClipFilter clipRaster = new ClipFilterClass();
            IGeometry clipGeometry;
            clipGeometry = (IGeometry)featureS.Shape;
            clipRaster.Add(clipGeometry);
            IPixelOperation pixelOp = (IPixelOperation)RT;
            pixelOp.PixelFilter = (IPixelFilter)clipRaster;
            IWorkspace workSpace = openWorkspace(outputFolder);
            IRasterProps rasterProps = (IRasterProps)RT;
            if (workSpace.PathName.Contains(".gdb") == false)
            {
                rasterProps.NoDataValue = 255;
                rasterProps.PixelType = rstPixelType.PT_UCHAR;
            }
            ISaveAs saveas = (ISaveAs)RT;
            saveas.SaveAs(outputFile, workSpace, Format);
        }
        //public static void ClipRasterWithPolygon(string path, string rasterfileName, string shapefileName, string outputFolder, string Format, string outputFile)
        //{
        //    //This function takes the geometry from a shape file and clip a raster based on the geometry.
        //    //Although the clipping geometry is not limited to a polygon geometry type and there is not a hard code
        //    //limit of number of geometics in the shape file, it is recommened that the shape file contains 
        //    //one clipping polygon or a few polygons that you defined as you clipping
        //    //area.

        //    //Open the raster to be clipped
        //    IRasterDataset2 rasterDS = (IRasterDataset2)openRasterDataset(path, rasterfileName);
        //    IRaster raster = rasterDS.CreateFullRaster();

        //    //Open the shape file
        //    IFeatureClass featureClass = openFeatureclassFromShapefile(path, shapefileName);

        //    //Create clip filter
        //    IClipFilter clipRaster = new ClipFilterClass();
        //    //Add the polygons from the shapefile to the clip filer
        //    IGeometry clipGeometry;
        //    IFeature feature;
        //    for (int i = 0; i <= featureClass.FeatureCount(null) - 1; i++)
        //    {
        //        // lấy feature khung cắt
        //        feature = featureClass.GetFeature(i);
        //        clipGeometry = (IGeometry)feature.Shape;
        //        clipRaster.Add(clipGeometry);
        //    }

        //    //Set the filter to the raster
        //    IPixelOperation pixelOp = (IPixelOperation)raster;
        //    pixelOp.PixelFilter = (IPixelFilter)clipRaster;

        //    //Now we need to specify properties for the output. The output can
        //    //be a file format or a geodatabase. This sample supports output 
        //    //to File geodatabase and Personal Geodatabase.
        //    //If the output is a file format and input raster does not contain NoData and the max value 
        //    //of the pixel depth is being used. (For example 255 is used for 
        //    //8 bit unsigned case), output pixel depth needs to be promoted and NoData
        //    //value need to set up properly.

        //    IWorkspace workSpace = openWorkspace(outputFolder);
        //    IRasterProps rasterProps = (IRasterProps)raster;
            
        //    if (workSpace.PathName.Contains(".gdb") == false)
        //    {
        //        rasterProps.NoDataValue = 256;
        //        rasterProps.PixelType = rstPixelType.PT_USHORT;
                
        //    }

        //    //Save the result out
        //    ISaveAs saveas = (ISaveAs)raster;
        //    saveas.SaveAs(outputFile, workSpace, Format);
        //}

        public static IRasterDataset2 openRasterDataset(string path, string name)
        {
            //This function opens a raster dataset from a file raster format.
            try
            {
                IWorkspaceFactory wsFactory1 = new RasterWorkspaceFactory();
                IRasterWorkspace workSpace = (IRasterWorkspace)wsFactory1.OpenFromFile(path, 0);
                IRasterDataset rasterDataset = workSpace.OpenRasterDataset(name);
                return (IRasterDataset2)rasterDataset;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Can not open file");
                return null;
            }
        }
        public static IWorkspace openWorkspace(string path)
        {
            //This function opens a raster workspace or a File geodatabase workspace 
            //or an Access workspace.
            try
            {
                IWorkspaceFactory WsFactory;
                IWorkspace workSpace;
                if (path.Contains(".gdb") == true)
                {
                    WsFactory = new FileGDBWorkspaceFactoryClass();
                }
                else if (path.Contains(".mdb") == true)
                {
                    WsFactory = new AccessWorkspaceFactoryClass();
                }
                else
                {
                    WsFactory = new RasterWorkspaceFactory();
                }
                workSpace = WsFactory.OpenFromFile(path, 0);
                return workSpace;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Can not open workspace");
                return null;
            }
        }
        public static IFeatureClass openFeatureclassFromShapefile(string path, string fileName)
        {
            //This function opens a feature class from a shapefile.
            try
            {
                IWorkspaceFactory wsf = new ShapefileWorkspaceFactoryClass();
                IWorkspace ws = wsf.OpenFromFile(path, 0);
                IFeatureWorkspace fws = (IFeatureWorkspace)ws;
                IFeatureClass fClass = fws.OpenFeatureClass(fileName);
                return fClass;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Can not open file");
                return null;
            }

        }


        //clip raster cách 3
        //public static void RasterClip(IRasterLayer pRasterLayer, IPolygon clipGeo, string FileName)
        //{
        //    IRaster pRaster = pRasterLayer.Raster;
        //    IRasterProps pProps = pRaster as IRasterProps;
        //    object cellSizeProvider = pProps.MeanCellSize().X;
        //    IGeoDataset pInputDataset = pRaster as IGeoDataset;
        //    IExtractionOp pExtractionOp = new RasterExtractionOpClass();
        //    IRasterAnalysisEnvironment pRasterAnaEnvir = pExtractionOp as IRasterAnalysisEnvironment;
        //    pRasterAnaEnvir.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref cellSizeProvider);
        //    object extentProvider = clipGeo.Envelope;
        //    object snapRasterData = Type.Missing;
        //    pRasterAnaEnvir.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref extentProvider, ref snapRasterData);
        //    IGeoDataset pOutputDataset = pExtractionOp.Polygon(pInputDataset, clipGeo as IPolygon, true);
        //    IRaster clipRaster; 
        //    if (pOutputDataset is IRasterLayer)
        //    {
        //        IRasterLayer rasterLayer = pOutputDataset as IRasterLayer;
        //        clipRaster = rasterLayer.Raster;
        //    }
        //    else if (pOutputDataset is IRasterDataset)
        //    {
        //        IRasterDataset rasterDataset = pOutputDataset as IRasterDataset;
        //        clipRaster = rasterDataset.CreateDefaultRaster();
        //    }
        //    else if (pOutputDataset is IRaster)
        //    {
        //        clipRaster = pOutputDataset as IRaster;
        //    }
        //    else
        //    {
        //        return;
        //    }
            
        //    IWorkspaceFactory pWKSF = new RasterWorkspaceFactory();
        //    IWorkspace pWorkspace = pWKSF.OpenFromFile(System.IO.Path.GetDirectoryName(FileName), 0);
        //    ISaveAs pSaveAs = clipRaster as ISaveAs;
        //    pSaveAs.SaveAs(System.IO.Path.GetFileName(FileName), pWorkspace, "IMAGINE Image");
        //}

        private void btCatAnh_Click(object sender, EventArgs e)
        {
            CatAnh();
        }
        private void CatAnh()
        {
            FrmChonRGClip frmChonRG = new FrmChonRGClip();
            frmChonRG.ShowDialog();
            if (frmChonRG.Visible == false & FrmChonRGClip.ife != null)
            {
                SaveFileDialog saveFileClip = new SaveFileDialog();
                saveFileClip.Filter = "PNG|*.png|JPG| *.jpg|TIFF| *.tiff|BMP| *.bmp|IMAGINE Image| *.img";
                saveFileClip.Title = "Lưu ảnh đã cắt";
                if (saveFileClip.ShowDialog() == DialogResult.OK)
                {
                    if (!System.IO.File.Exists(saveFileClip.FileName))
                    {
                        splashScreenManager1.ShowWaitForm();
                        string format = System.IO.Path.GetExtension(saveFileClip.FileName).Replace(".", "");
                        string outputFolder = System.IO.Path.GetDirectoryName(saveFileClip.FileName);
                        string outputFile = System.IO.Path.GetFileName(saveFileClip.FileName);
                        ClipRasterbyPolygon(raster, FrmChonRGClip.ife, outputFolder, format, outputFile);//cắt ảnh theo polygon
                        string pathsave = saveFileClip.FileName;

                        //Mở file vừa clip
                        string workspacePath = System.IO.Path.GetDirectoryName(pathsave);
                        string fileName = System.IO.Path.GetFileName(pathsave);
                        IRasterLayer rasterLayer = new RasterLayer();
                        rasterLayer.CreateFromFilePath(pathsave);
                        FormChinh.KienTruc.axMapControl1.AddLayer(rasterLayer);

                        splashScreenManager1.CloseWaitForm();

                    }
                    else { MessageBox.Show("File đã tồn tại"); }
                }
            }
        }
        string XVN2000 = "";
        string YVN2000 = "";
        private void VN2000TOWGS84(string KinhDo, string ViDo)
        {

            double[] z = new double[1];
            double[] xy = new double[2];
            xy[0] = Convert.ToDouble(KinhDo);
            xy[1] = Convert.ToDouble(ViDo);
            z[0] = 0;
            double[] xy_geometry = new double[xy.Length];
            Array.Copy(xy, xy_geometry, xy.Length);
            DotSpatial.Projections.ProjectionInfo trg =
                DotSpatial.Projections.ProjectionInfo.FromProj4String("+proj=longlat +datum=WGS84 +no_defs");
            DotSpatial.Projections.ProjectionInfo src =
                DotSpatial.Projections.ProjectionInfo.FromProj4String("+proj = tmerc + lat_0 = 0 + lon_0 = 107.75 + k = 0.9999 + x_0 = 500000 + y_0 = 0 + ellps = WGS84 + towgs84 = -191.90441429, -39.30318279, -111.45032835, 0.00928836, -0.01975479, 0.00427372, 0.252906278 + units = m + no_defs");
            DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, src, trg, 0, 1);

            XVN2000 = Math.Round(double.Parse(xy[0].ToString()), 8).ToString();
            YVN2000 = Math.Round(double.Parse(xy[1].ToString()), 8).ToString();

        }
        private void btCapNhat_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.CapNhat.CapNhatFile_BanDoGiay frm = new QLHTDT.FormPhu.CapNhat.CapNhatFile_BanDoGiay();
            frm.ShowDialog();
            frm.TopMost = true;
        }
        public static void UploadFileToFtp(string url, string filePath, string username, string password)
        {
            var fileName = System.IO.Path.GetFileName(filePath);
            var request = (FtpWebRequest)WebRequest.Create(url + fileName);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = true;

            using (var fileStream = File.OpenRead(filePath))
            {
                using (var requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                    requestStream.Close();
                }
            }

            var response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Upload done: {0}", response.StatusDescription);
            response.Close();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            gridView1.RefreshData();
        }
    }
}

