using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using QLHTDT.axToccontrol.Table;
using QLHTDT.FormChinh;
using ESRI.ArcGIS.Display;
using stdole;

namespace QLHTDT.test
{
    public partial class FrmCapNhat : Form
    {

        public static IFeatureClass featureClassSHP;
        public static IFeatureClass featureClassSDE;
        IDataset pDatasetSDE;
        ESRI.ArcGIS.Carto.IActiveView activeView;
        IFeatureWorkspace featureWorkspaceSDE;
        IFeatureWorkspace featureWorkspaceSHP;
        public static DataTable dtSHP;
        public static DataRow drSHP;
        public static DataTable dtSDE;
        public static DataRow drSDE;
        DataGridViewRow rowSHP = new DataGridViewRow();
        DataGridViewRow rowSDE = new DataGridViewRow();
        DataTable ThemMoi; DataTable Xoa;
        string Quan = "";
        string phuong = "";
        FrmKiemTra frm;
        IMap pmap;
        public static ILayer layershp;
        public static ILayer layersde;
        public FrmCapNhat()
        {
            InitializeComponent();
            activeView = QuanTriHeThong.axMapControl1.ActiveView;
            this.TopMost = true;
            pmap = QuanTriHeThong.axMapControl1.Map;
            //activeView = ArcMap.Document.ActiveView;
        }
        private void btKiemTra_Click(object sender, EventArgs e)
        {
            if (featureClassSHP == null || featureClassSDE == null)
            { { MessageBox.Show("Chưa mở lớp dữ liệu", "Thông báo"); } }
            else
            {
                dtSHP = new DataTable();
                dtSHP.Columns.Add("FID", typeof(String));
                dtSHP.Columns.Add("SHBANDO", typeof(String));
                dtSHP.Columns.Add("SHTHUA", typeof(String));
                dtSHP.Columns.Add("ThayDoi", typeof(String));
                dtSDE = new DataTable();
                dtSDE.Columns.Add("OBJECTID", typeof(String));
                dtSDE.Columns.Add("Số tờ bản đồ", typeof(String));
                dtSDE.Columns.Add("Số thửa", typeof(String));
                dtSDE.Columns.Add("ThayDoiSDE", typeof(String));
                DataTable dtSDEselect;
                dtSDEselect = new DataTable();
                dtSDEselect.Columns.Add("OBJECTID", typeof(String));
                dtSDEselect.Columns.Add("Số tờ bản đồ", typeof(String));
                dtSDEselect.Columns.Add("Số thửa", typeof(String));
                dtSDEselect.Columns.Add("ThayDoiSDE", typeof(String));
                IFeatureLayer pFeatureLayer2 = new FeatureLayerClass();
                pFeatureLayer2.FeatureClass = featureClassSDE;
                IFeatureSelection featSelect = pFeatureLayer2 as IFeatureSelection;
                IQueryFilter pFilter = new QueryFilterClass();
                EnvelopeClass pEnvelope = new EnvelopeClass();
                if (CboSoTo.Text == "")
                {
                    MessageBox.Show("Chưa chọn số tờ bản đồ", "Thông báo");
                }
                else
                {
                    pFilter.WhereClause = "[SoToBD] = '" + CboSoTo.Text + "'";
                    featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                    IEnumIDs idList = featSelect.SelectionSet.IDs;
                    int index = idList.Next();
                    List<int> indexes = new List<int>();
                    while (index != -1)
                    {
                        indexes.Add(index);
                        index = idList.Next();
                    }
                    if (featSelect.SelectionSet.Count == 0) { MessageBox.Show("Không có thửa đất nào", "Thông báo"); }
                    for (int i2 = 0; i2 < featSelect.SelectionSet.Count; i2++)
                    {
                        DataRow dr;
                        IFeature feature = featureClassSDE.GetFeature(indexes[i2]);
                        dr = dtSDEselect.NewRow();
                        dr[0] = feature.get_Value(feature.Fields.FindField("OBJECTID")).ToString();

                        if (feature.get_Value(feature.Fields.FindField("SoToBD")) != DBNull.Value)
                        {
                            dr[1] = feature.get_Value(feature.Fields.FindField("SoToBD")).ToString();
                        }
                        if (feature.get_Value(feature.Fields.FindField("SoThua")) != DBNull.Value)
                        {
                            dr[2] = feature.get_Value(feature.Fields.FindField("SoThua")).ToString();
                        }
                        dtSDEselect.Rows.Add(dr);
                    }

                    ITable tbSHP = featureClassSHP as ITable;
                    TableWrapper wratbalSHP = new TableWrapper(tbSHP);
                    bindingSshp.DataSource = wratbalSHP;
                    //ITable tbSDE = featureClassSDE as ITable;
                    //TableWrapper wratbalSDE = new TableWrapper(tbSDE);
                    //bindingSsde.DataSource = wratbalSDE;
                    dataGridViewSHP.DataSource = bindingSshp;
                    dataGridViewSDE.DataSource = dtSDEselect;

                    int checksde; string KTshp = ""; int checkshp; string KTsde = "";
                    //for (int ii = 0; ii < dataGridViewSDE.RowCount - 1; ++ii)
                    //{
                    //    DataGridViewRow rowSDEKT = dataGridViewSDE.Rows[ii];
                    //    string SoTo = rowSDEKT.Cells[1].Value.ToString();
                    //    if (SoTo == CboSoTo.Text)
                    //    {
                    for (int i = 0; i < dataGridViewSHP.RowCount - 1; ++i)
                    {
                        checksde = 0;
                        DataGridViewRow rowSHP = dataGridViewSHP.Rows[i];
                        KTshp = rowSHP.Cells[2].Value.ToString();
                        for (int i2 = 0; i2 < dataGridViewSDE.RowCount - 1; ++i2)
                        {
                            DataGridViewRow rowSDE = dataGridViewSDE.Rows[i2];
                            KTsde = rowSDE.Cells[2].Value.ToString();
                            if (KTsde == KTshp)
                            {
                                checksde = checksde + 1;
                                int IDsde;
                                int.TryParse(rowSDE.Cells[0].Value.ToString(), out IDsde);
                                IFeature ifeSDEtest = featureClassSDE.GetFeature(IDsde);
                                int IDshp;
                                int.TryParse(rowSHP.Cells[0].Value.ToString(), out IDshp);
                                IFeature ifeshp = featureClassSHP.GetFeature(IDshp);
                                //ifeSDEtest.Shape = ifeshp.Shape;
                                //ifeSDEtest.Store();
                                //QuanTriHeThong.axMapControl1.Refresh();
                                //if (ifeSDEtest.Shape.Envelope.Height == ifeshp.Shape.Envelope.Height)
                                //{ MessageBox.Show("thửa số " + KTsde + " ở sde trùng với thửa số " + KTshp + " ở shp", "Thông báo"); }
                                double Heisde; double.TryParse(String.Format("{0:00}", double.Parse(ifeSDEtest.Shape.Envelope.Height.ToString())), out Heisde);
                                double Widsde; double.TryParse(String.Format("{0:00}", double.Parse(ifeSDEtest.Shape.Envelope.Width.ToString())), out Widsde);
                                double Heishp; double.TryParse(String.Format("{0:00}", double.Parse(ifeshp.Shape.Envelope.Height.ToString())), out Heishp);
                                double Widshp; double.TryParse(String.Format("{0:00}", double.Parse(ifeshp.Shape.Envelope.Width.ToString())), out Widshp);
                                double Xsde; double.TryParse(String.Format("{0:00.00}", double.Parse(ifeSDEtest.Extent.LowerLeft.X.ToString())), out Xsde);
                                double Ysde; double.TryParse(String.Format("{0:00.00}", double.Parse(ifeSDEtest.Extent.LowerLeft.Y.ToString())), out Ysde);
                                double Xshp; double.TryParse(String.Format("{0:00.00}", double.Parse(ifeshp.Extent.LowerLeft.X.ToString())), out Xshp);
                                double Yshp; double.TryParse(String.Format("{0:00.00}", double.Parse(ifeshp.Extent.LowerLeft.Y.ToString())), out Yshp);
                                if ((Heisde * Widsde) != (Heishp * Widshp) || Xsde != Xshp || Ysde != Yshp)
                                {
                                    //ifeSDEtest.Extent.
                                    drSHP = dtSHP.NewRow();
                                    drSHP[0] = ifeshp.get_Value(ifeshp.Fields.FindField("FID")).ToString();
                                    drSHP[1] = ifeshp.get_Value(ifeshp.Fields.FindField("SHBANDO")).ToString();
                                    drSHP[2] = ifeshp.get_Value(ifeshp.Fields.FindField("SHTHUA")).ToString();
                                    drSHP[3] = "Thửa thay đổi ranh giới";
                                    dtSHP.Rows.Add(drSHP);
                                }
                            }

                        }
                        if (checksde != 0) { }
                        else
                        {
                            int ID;
                            int.TryParse(rowSHP.Cells[0].Value.ToString(), out ID);
                            IFeature ifeSHP = featureClassSHP.GetFeature(ID);
                            drSHP = dtSHP.NewRow();
                            drSHP[0] = ifeSHP.get_Value(ifeSHP.Fields.FindField("FID")).ToString();
                            drSHP[1] = ifeSHP.get_Value(ifeSHP.Fields.FindField("SHBANDO")).ToString();
                            drSHP[2] = ifeSHP.get_Value(ifeSHP.Fields.FindField("SHTHUA")).ToString();
                            drSHP[3] = "Thửa mới";
                            dtSHP.Rows.Add(drSHP);
                            //MessageBox.Show("Không có thửa số " + KTshp + " ở sde(thửa mới)", "Thông báo");
                        }
                    }

                    for (int i = 0; i < dataGridViewSDE.RowCount - 1; ++i)
                    {
                        checkshp = 0;
                        DataGridViewRow rowSDE = dataGridViewSDE.Rows[i];
                        KTsde = rowSDE.Cells[2].Value.ToString();
                        for (int i2 = 0; i2 < dataGridViewSHP.RowCount - 1; ++i2)
                        {
                            DataGridViewRow rowSHP = dataGridViewSHP.Rows[i2];
                            KTshp = rowSHP.Cells[2].Value.ToString();
                            if (KTshp == KTsde)
                            {
                                checkshp = checkshp + 1;
                            }
                        }
                        if (checkshp != 0) { }
                        else
                        {
                            int ID;
                            int.TryParse(rowSDE.Cells[0].Value.ToString(), out ID);
                            IFeature ifeSDE = featureClassSDE.GetFeature(ID);
                            drSDE = dtSDE.NewRow();
                            drSDE[0] = ifeSDE.get_Value(ifeSDE.Fields.FindField("OBJECTID")).ToString();
                            drSDE[1] = ifeSDE.get_Value(ifeSDE.Fields.FindField("SoToBD")).ToString();
                            drSDE[2] = ifeSDE.get_Value(ifeSDE.Fields.FindField("SoThua")).ToString();
                            drSDE[3] = "Thửa cũ";
                            dtSDE.Rows.Add(drSDE);
                            //MessageBox.Show("Không có thửa số " + KTsde + " ở shp(thửa cũ)", "Thông báo");
                        }
                    }
                    frm = new FrmKiemTra(dtSHP, dtSDE);
                    frm.Show();
                }
                
                    //}
                        
                }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (activeView == null)
            {
                return;
            }

            // Use the OpenFileDialog Class to choose which shapefile to load.
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = Properties.Settings.Default.pathSHP;
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // The user chose a particular shapefile.

                // The returned string will be the full path, filename and file-extension for the chosen shapefile. Example: "C:\test\cities.shp"
                string shapefileLocation = openFileDialog.FileName;

                if (shapefileLocation != "")
                {
                    // Ensure the user chooses a shapefile

                    // Create a new ShapefileWorkspaceFactory CoClass to create a new workspace
                    ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();

                    // System.IO.Path.GetDirectoryName(shapefileLocation) returns the directory part of the string. Example: "C:\test\"
                    featureWorkspaceSHP = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(shapefileLocation), 0); // Explicit Cast
                    
                    // System.IO.Path.GetFileNameWithoutExtension(shapefileLocation) returns the base filename (without extension). Example: "cities"
                    featureClassSHP = featureWorkspaceSHP.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(shapefileLocation));

                    ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = new ESRI.ArcGIS.Carto.FeatureLayerClass();
                    featureLayer.FeatureClass = featureClassSHP;
                    featureLayer.Name = featureClassSHP.AliasName;
                    featureLayer.Visible = true;
                    if (featureClassSHP.ShapeType != esriGeometryType.esriGeometryPolygon)
                    {
                        MessageBox.Show("Shapefile không đúng dạng vùng", "Thông báo");
                    }
                    else
                    {
                        activeView.FocusMap.AddLayer(featureLayer);
                        activeView.Extent = activeView.FullExtent;
                        activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                        txtshp.Text = shapefileLocation;
                        QLHTDT.Properties.Settings.Default.pathSHP = System.IO.Path.GetDirectoryName(shapefileLocation);
                        QLHTDT.Properties.Settings.Default.Save();
                        layershp = QuanTriHeThong.axMapControl1.get_Layer(0);
                        IRgbColor color2 = new RgbColorClass();
                        color2.Red = 224;
                        color2.Green = 255;
                        color2.Blue = 255;
                        color2.UseWindowsDithering = true;
                        hienlabel(layershp, "SHTHUA", 255, color2);
                    }
                }
                else
                {
                }
            }
            else
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = Properties.Settings.Default.pathSDE;
            openFileDialog.Filter = "Geodatabase sde (*.sde)|*.sde";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string SDEfileLocation = openFileDialog.FileName;

                if (SDEfileLocation != "")
                {
                    txtsde.Text = SDEfileLocation;
                    QLHTDT.Properties.Settings.Default.pathSDE = System.IO.Path.GetDirectoryName(SDEfileLocation);
                    QLHTDT.Properties.Settings.Default.Save();
                    IWorkspaceFactory2 workspaceFactory = (IWorkspaceFactory2)new SdeWorkspaceFactoryClass();
                    featureWorkspaceSDE = (IFeatureWorkspace)workspaceFactory.OpenFromFile(SDEfileLocation, 0);
                    
                    //pDatasetSDE = null;
                    //pDatasetSDE = featureWorkspaceSDE.OpenFeatureDataset("HA13");
                }
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            DataTable add=new DataTable();
            add = QLHTDT.test.FrmKiemTra.dataADD;
            DataTable del = new DataTable();
            del = QLHTDT.test.FrmKiemTra.dataDEL;
            //FrmKiemTra.tableUpdate(add, del);
            //var cell = new object[add.Columns.Count];
            //string a = add.Rows[0][3].ToString();
            foreach (DataRow dataGridViewRow in add.Rows)
            {
                for (int i = 0; i < add.Rows.Count; i++)
                {
                    //string b = dataGridViewRow.ItemArray.GetValue(4).ToString();
                    //cell[3] = dataGridViewRow.Cells[3].Value;
                    if (dataGridViewRow[4].ToString() == "True")
                    {
                        string thaydoi = dataGridViewRow[3].ToString();
                    if (thaydoi == "Thửa mới")
                    {
                        int IDshp;
                        int.TryParse(dataGridViewRow[0].ToString(), out IDshp);
                        IFeature ifeshp = featureClassSHP.GetFeature(IDshp);
                        IFeature feature = featureClassSDE.CreateFeature();
                        feature.Shape = ifeshp.Shape;
                        ISubtypes subtypes = (ISubtypes)featureClassSDE;
                        IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
                        if (subtypes.HasSubtype)
                        {
                            rowSubtypes.SubtypeCode = 3;
                        }
                        rowSubtypes.InitDefaultValues();
                        int SoTo = featureClassSDE.FindField("SoToBD");
                        feature.set_Value(SoTo, dataGridViewRow[2].ToString());
                        int SoThua = featureClassSDE.FindField("SoThua");
                        feature.set_Value(SoThua, dataGridViewRow[1].ToString());
                        feature.Store();
                        QuanTriHeThong.axMapControl1.Refresh();
                    }
                    if (thaydoi == "Thửa thay đổi ranh giới")
                    {
                        int IDshp;
                        int.TryParse(dataGridViewRow[0].ToString(), out IDshp);
                        IFeature ifeshp = featureClassSHP.GetFeature(IDshp);
                        //for (int i2 = 0; i2 < dataGridViewSDE.RowCount - 1; ++i2)
                        //{
                        //    DataGridViewRow rowSDE = dataGridViewSDE.Rows[i2];
                        //   string SoThua = rowSDE.Cells[2].Value.ToString();
                        //   if (SoThua == dataGridViewRow[1].ToString())
                        //   {
                        //       int IDsde;
                        //       int.TryParse(rowSDE.Cells[0].Value.ToString(), out IDsde);
                        //       IFeature ifeSDEtest = featureClassSDE.GetFeature(IDsde);
                        //       ifeSDEtest.Shape = ifeshp.Shape;
                        //       ifeSDEtest.Store();
                        //   }
                        //}
                        IFeatureLayer pFeatureLayer2 = new FeatureLayerClass();
                        pFeatureLayer2.FeatureClass = featureClassSDE;
                        IFeatureSelection featSelect = pFeatureLayer2 as IFeatureSelection;
                        IQueryFilter pFilter = new QueryFilterClass();
                        EnvelopeClass pEnvelope = new EnvelopeClass();

                        pFilter.WhereClause = "[SoThua] = '" + dataGridViewRow[1].ToString() + "' AND [SoToBD] = '" + dataGridViewRow[2].ToString() + "'";
                        featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                        IEnumIDs idList = featSelect.SelectionSet.IDs;
                        int index = idList.Next();
                        List<int> indexes = new List<int>();
                        while (index != -1)
                        {
                            indexes.Add(index);
                            index = idList.Next();
                        }
                        if (featSelect.SelectionSet.Count != 0)
                        { //MessageBox.Show("Không có thửa đất nào" ,"Thông báo");
                            for (int i2 = 0; i2 < featSelect.SelectionSet.Count; i2++)
                            {
                                IFeature feature = featureClassSDE.GetFeature(indexes[i2]);
                                feature.Shape = ifeshp.Shape;
                                feature.Store();
                            }
                        }
                    }
                    }
                }
            }
            foreach (DataRow dataGridViewRow in del.Rows)
            {
                for (int i = 0; i < del.Rows.Count; i++)
                {
                    if (dataGridViewRow[4].ToString() == "True")
                    {
                        string thaydoi = dataGridViewRow[3].ToString();
                        if (thaydoi == "Thửa cũ")
                        {
                            //for (int i2 = 0; i2 < dataGridViewSDE.RowCount - 1; ++i2)
                            //{
                            //    IFeature ifeSDEtest = null;
                            //    DataGridViewRow rowSDE = dataGridViewSDE.Rows[i2];
                            //    string SoThua = rowSDE.Cells[2].Value.ToString();
                            //    if (SoThua == dataGridViewRow[1].ToString())
                            //    {
                            //        int IDsde;
                            //        int.TryParse(rowSDE.Cells[0].Value.ToString(), out IDsde);
                            //        ifeSDEtest = featureClassSDE.GetFeature(IDsde);
                            //        if (ifeSDEtest != null)
                            //        {
                            //            ifeSDEtest.Delete();
                            //            ifeSDEtest.Store();
                            //            dataGridViewSDE.Refresh();
                            //            QuanTriHeThong.axMapControl1.Refresh();
                            //        }
                            //    }
                            //}

                            IFeatureLayer pFeatureLayer2 = new FeatureLayerClass();
                            pFeatureLayer2.FeatureClass = featureClassSDE;
                            IFeatureSelection featSelect = pFeatureLayer2 as IFeatureSelection;
                            IQueryFilter pFilter = new QueryFilterClass();
                            EnvelopeClass pEnvelope = new EnvelopeClass();

                            pFilter.WhereClause = "[SoThua] = '" + dataGridViewRow[1].ToString() + "' AND [SoToBD] = '" + dataGridViewRow[2].ToString()+ "'";
                            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                            
                            IEnumIDs idList = featSelect.SelectionSet.IDs;
                            int index = idList.Next();
                            List<int> indexes = new List<int>();
                            while (index != -1)
                            {
                                indexes.Add(index);
                                index = idList.Next();
                            }
                            if (featSelect.SelectionSet.Count != 0)
                            { //MessageBox.Show("Không có thửa đất nào" ,"Thông báo");
                            for (int i2 = 0; i2 < featSelect.SelectionSet.Count; i2++)
                            {
                                IFeature feature = featureClassSDE.GetFeature(indexes[i2]);
                                feature.Delete();
                                feature.Store();
                            }
                            }
                            
                        }
                    }
                }
            }
            QuanTriHeThong.axMapControl1.Refresh();
            MessageBox.Show("Cập nhật thành công", "Thông báo");
        }

        private void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            phuong = "";
            if (cboQuan.Text == "Quận Cẩm Lệ")
            {
                this.CboPhuong.Items.AddRange(new object[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            }
            if (cboQuan.Text == "Quận Hải Châu")
            {
                this.CboPhuong.Items.AddRange(new object[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            }
            if (cboQuan.Text == "Quận Liêu Chiểu")
            {
                this.CboPhuong.Items.AddRange(new object[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            }
        }
        public static void CreateFeature(IFeatureClass featureClass, IFeature Polygon)
        {
            // featureClass là lớp sde; Polygon là đối tượng copy
            if (featureClass.ShapeType != esriGeometryType.esriGeometryPolygon)
            {
                return;
            }
            // Build the feature.
            IFeature feature = featureClass.CreateFeature();
            feature.Shape = Polygon.Shape;

            // Apply the appropriate subtype to the feature.
            ISubtypes subtypes = (ISubtypes)featureClass;
            IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
            if (subtypes.HasSubtype)
            {
                // In this example, the value of 3 represents the Cross subtype.
                rowSubtypes.SubtypeCode = 3;
            }

            // Initialize any default values the feature has.
            rowSubtypes.InitDefaultValues();

            // Update the value on a string field that indicates who installed the feature.
            int contractorFieldIndex = featureClass.FindField("SoToBD");
            feature.set_Value(contractorFieldIndex, "999");

            // Commit the new feature to the geodatabase.
            feature.Store();

        }

        private void CboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboPhuong.Text == "Hòa An")
            {
                phuong = "HA";
                this.CboSoTo.Items.AddRange(new object[] {
                "12",
                "13",
                "14",
                "15"});

                if (phuong == "")
                { MessageBox.Show("Chưa chọn phường", "Thông báo"); }
                else
                {
                    featureClassSDE = featureWorkspaceSDE.OpenFeatureClass("ChiaLo_" + phuong);
                    ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = new ESRI.ArcGIS.Carto.FeatureLayerClass();
                    featureLayer.FeatureClass = featureClassSDE;
                    featureLayer.Name = featureClassSDE.AliasName;
                    featureLayer.Visible = true;
                    activeView.FocusMap.AddLayer(featureLayer);
                    //hienlabel(featureClassSDE,"SoThua");
                    activeView.Extent = activeView.FullExtent;
                    activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                    layersde = QuanTriHeThong.axMapControl1.get_Layer(0);
                    IRgbColor color2 = new RgbColorClass();
                    color2.Red = 240;
                    color2.Green = 230;
                    color2.Blue = 140;
                    color2.UseWindowsDithering = true;
                    hienlabel(layersde, "SoThua", 0, color2);
                }
            }
        }

        private void FrmCapNhat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frm != null)
            {
                frm.Close();
            }
        }

        private void hienlabel(ILayer layera, string DisplayField,int col, IRgbColor icolor)
        {
            IConvertLabelsToAnnotation pConvertLabelsToAnnotation = new ConvertLabelsToAnnotationClass();
            ITrackCancel pTrackCancel = new CancelTrackerClass();
            pConvertLabelsToAnnotation.Initialize(pmap, esriAnnotationStorageType.esriMapAnnotation, esriLabelWhichFeatures.esriAllFeatures, true, pTrackCancel, null);
            ILayer layer = layera;
            IFeatureLayer featureLayer = (IFeatureLayer)layer;
            IGeoFeatureLayer pGeoFeatureLayer = (IGeoFeatureLayer)featureLayer;
            pGeoFeatureLayer.DisplayAnnotation = true;
            ISimpleRenderer simpleRenderer = (ISimpleRenderer)pGeoFeatureLayer.Renderer;
            ISimpleFillSymbol symbol = new SimpleFillSymbolClass();
            

            if (pGeoFeatureLayer != null)
            {
                IFeatureClass pFeatureClass = pGeoFeatureLayer.FeatureClass;
                IDataset pDataset = pFeatureClass as IDataset;
                IFeatureWorkspace pFeatureWorkspace = pDataset.Workspace as IFeatureWorkspace;
                IFeatureDataset pFeatureLayer4 = pFeatureClass.FeatureDataset;//Cbolop2.SelectedValue as IFeatureDataset;
                pGeoFeatureLayer.DisplayField = DisplayField;
                //pFeatureClass.FeatureDataset.PropertySet.
                AnnotateFeatureClass a = pFeatureClass as AnnotateFeatureClass;
                IAnnotateLayerPropertiesCollection annoProperties = pGeoFeatureLayer.AnnotationProperties;
                annoProperties.Clear();
                ILineLabelPosition position = new LineLabelPosition();
                position.Parallel = true;
                position.Perpendicular = false;
                ILineLabelPlacementPriorities placement = new LineLabelPlacementPriorities();
                IBasicOverposterLayerProperties basic = new BasicOverposterLayerProperties();
                basic.FeatureType = esriBasicOverposterFeatureType.esriOverposterPoint;
                basic.LineLabelPlacementPriorities = placement;
                basic.LineLabelPosition = position;
                ITextSymbol textSymbol = new TextSymbolClass();
                // Set Color
                IRgbColor color = new RgbColorClass();
                color.Blue = col;
                color.UseWindowsDithering = true;
                textSymbol.Color = color;

                
                symbol.Color = icolor;
                ILineSymbol lineSymbol = new SimpleLineSymbolClass();
                lineSymbol.Width = 1;
                lineSymbol.Color = color;
                symbol.Outline = lineSymbol;
            simpleRenderer.Symbol = (ISymbol)symbol;  //last line of your code
                IFeatureLayer AsFeatureLayer = (IFeatureLayer)layer;
                IGeoFeatureLayer AsGeoFeatureLayer = (IGeoFeatureLayer)AsFeatureLayer;
                AsGeoFeatureLayer.Renderer = (IFeatureRenderer)simpleRenderer; // set the renderer to the layer
                ILayerEffects AsLayerEffects = (ILayerEffects)AsFeatureLayer;
                AsLayerEffects.Transparency = 50;
                // Set Font 
                IFontDisp font = (IFontDisp)new stdole.StdFont();
                font.Name = "Arial";
                font.Size = Convert.ToInt32("10");
                textSymbol.Font = font;
                ILabelEngineLayerProperties labelProperties = new LabelEngineLayerProperties() as ILabelEngineLayerProperties;
                labelProperties.Symbol = textSymbol;
                labelProperties.BasicOverposterLayerProperties = basic;
                labelProperties.Expression = "[" + DisplayField + "]";
                IAnnotateLayerProperties annoLayerProperties = labelProperties as IAnnotateLayerProperties;
                pGeoFeatureLayer.AnnotationProperties.Add(annoLayerProperties);
                
                    pGeoFeatureLayer.DisplayAnnotation = true;
                
                IActiveView pActiveView = pmap as IActiveView;

                

                pActiveView.Refresh();
                QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Update();
                QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();

            }
        }
    }
}
