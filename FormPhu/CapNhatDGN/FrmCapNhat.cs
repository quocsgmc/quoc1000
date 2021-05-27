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
using System.Data.SqlClient;

namespace QLHTDT.CapNhatDGN
{
    public partial class FrmCapNhat : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        public static IFeatureClass featureClassSHP;
        public static IFeatureClass featureClassSDE;
        IDataset pDatasetSDE;
        ESRI.ArcGIS.Carto.IActiveView activeView;
        public static IFeatureWorkspace featureWorkspaceSDE;
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
            activeView = KienTruc.axMapControl1.ActiveView;
            this.TopMost = true;
            pmap = KienTruc.axMapControl1.Map;
            //activeView = ArcMap.Document.ActiveView;
            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            cboQuan.DataSource = ds1.Tables[0];
            cboQuan.DisplayMember = "TENHUYEN";
            cboQuan.ValueMember = "MAHUYEN";
        }
        private void btKiemTra_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Cursor = Cursors.WaitCursor;
            string sotocheck = "";
            if (featureClassSHP == null || featureClassSDE == null)
            { MessageBox.Show("Chưa mở lớp dữ liệu", "Thông báo"); }
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
                dtSDEselect.Columns.Add("SoToBD", typeof(String));
                dtSDEselect.Columns.Add("SoThua", typeof(String));
                dtSDEselect.Columns.Add("ThayDoiSDE", typeof(String));
                IFeatureLayer pFeatureLayerSDE = new FeatureLayerClass();
                pFeatureLayerSDE.FeatureClass = featureClassSDE;
                IFeatureLayer pFeatureLayerSHP = new FeatureLayerClass();
                pFeatureLayerSHP.FeatureClass = featureClassSHP;
                IFeatureSelection featSelectSDE = pFeatureLayerSDE as IFeatureSelection;
                IFeatureSelection featSelectSDE1thua = pFeatureLayerSDE as IFeatureSelection;
                IFeatureSelection featSelectSHP = pFeatureLayerSHP as IFeatureSelection;
                IFeatureSelection featSelectSHP1thua = pFeatureLayerSHP as IFeatureSelection;
                IQueryFilter pFilterSDE = new QueryFilterClass();
                IQueryFilter pFilterSDE1thua = new QueryFilterClass();
                IQueryFilter pFilterSHP = new QueryFilterClass();
                IQueryFilter pFilterSHP1thua = new QueryFilterClass();
                EnvelopeClass pEnvelope = new EnvelopeClass();
                //if (CboSoTo.Text == "")
                //{
                //    MessageBox.Show("Chưa chọn số tờ bản đồ", "Thông báo");
                //}
                //else


                ITable tbSHP = featureClassSHP as ITable;
                TableWrapper wratbalSHP = new TableWrapper(tbSHP);
                bindingSshp.DataSource = wratbalSHP;
                //ITable tbSDE = featureClassSDE as ITable;
                //TableWrapper wratbalSDE = new TableWrapper(tbSDE);
                //bindingSsde.DataSource = wratbalSDE;
                dataGridViewSHP.DataSource = bindingSshp;
                dataGridViewSDE.DataSource = dtSDEselect;

                //int checksde; string KTshp = ""; int checkshp; string KTsde = "";
                //for (int ii = 0; ii < dataGridViewSDE.RowCount - 1; ++ii)
                //{
                //    DataGridViewRow rowSDEKT = dataGridViewSDE.Rows[ii];
                //    string SoTo = rowSDEKT.Cells[1].Value.ToString();
                //    if (SoTo == CboSoTo.Text)
                //    {
                for (int i = 0; i < dataGridViewSHP.RowCount - 1; ++i)
                {
                    int ID;
                    DataGridViewRow rowSHP = dataGridViewSHP.Rows[i];
                    int.TryParse(rowSHP.Cells[0].Value.ToString(), out ID);
                    IFeature ifeSHP = featureClassSHP.GetFeature(ID);
                    string soto = ifeSHP.get_Value(ifeSHP.Fields.FindField("SHBANDO")).ToString();
                    string sothua = ifeSHP.get_Value(ifeSHP.Fields.FindField("SHTHUA")).ToString();
                    string IDPhuong = CboPhuong.SelectedValue.ToString();
                    pFilterSDE1thua.WhereClause = "[SoToBD] = '" + soto + "' and [SoThua] = '" + sothua + "' and IDPhuong = '"+ IDPhuong+"' ";
                    featSelectSDE1thua.SelectFeatures(pFilterSDE1thua, esriSelectionResultEnum.esriSelectionResultNew, false);
                    if (featSelectSDE1thua.SelectionSet.Count == 0)
                    {
                        drSHP = dtSHP.NewRow();
                        drSHP[0] = ifeSHP.get_Value(ifeSHP.Fields.FindField("FID")).ToString();
                        drSHP[1] = ifeSHP.get_Value(ifeSHP.Fields.FindField("SHBANDO")).ToString();
                        drSHP[2] = ifeSHP.get_Value(ifeSHP.Fields.FindField("SHTHUA")).ToString();
                        drSHP[3] = "Thửa mới";
                        dtSHP.Rows.Add(drSHP);
                    }
                    else
                    {
                        IEnumIDs idList = featSelectSDE1thua.SelectionSet.IDs;
                        int index = idList.Next();
                        List<int> indexes = new List<int>();
                        while (index != -1)
                        {
                            indexes.Add(index);
                            index = idList.Next();
                        }
                        IFeature ifeSDEtest = featureClassSDE.GetFeature(indexes[0]);
                        double Heisde; double.TryParse(String.Format("{0:00}", double.Parse(ifeSDEtest.Shape.Envelope.Height.ToString())), out Heisde);
                        double Widsde; double.TryParse(String.Format("{0:00}", double.Parse(ifeSDEtest.Shape.Envelope.Width.ToString())), out Widsde);
                        double Heishp; double.TryParse(String.Format("{0:00}", double.Parse(ifeSHP.Shape.Envelope.Height.ToString())), out Heishp);
                        double Widshp; double.TryParse(String.Format("{0:00}", double.Parse(ifeSHP.Shape.Envelope.Width.ToString())), out Widshp);
                        double Xsde; double.TryParse(String.Format("{0:00.00}", double.Parse(ifeSDEtest.Extent.LowerLeft.X.ToString())), out Xsde);
                        double Ysde; double.TryParse(String.Format("{0:00.00}", double.Parse(ifeSDEtest.Extent.LowerLeft.Y.ToString())), out Ysde);
                        double Xshp; double.TryParse(String.Format("{0:00.00}", double.Parse(ifeSHP.Extent.LowerLeft.X.ToString())), out Xshp);
                        double Yshp; double.TryParse(String.Format("{0:00.00}", double.Parse(ifeSHP.Extent.LowerLeft.Y.ToString())), out Yshp);
                        if ((Heisde * Widsde) != (Heishp * Widshp) || Xsde != Xshp || Ysde != Yshp)
                        {
                            //ifeSDEtest.Extent.
                            drSHP = dtSHP.NewRow();
                            drSHP[0] = ifeSHP.get_Value(ifeSHP.Fields.FindField("FID")).ToString();
                            drSHP[1] = ifeSHP.get_Value(ifeSHP.Fields.FindField("SHBANDO")).ToString();
                            drSHP[2] = ifeSHP.get_Value(ifeSHP.Fields.FindField("SHTHUA")).ToString();
                            drSHP[3] = "Thửa thay đổi ranh giới";
                            dtSHP.Rows.Add(drSHP);
                        }
                    }


                    //get thửa cũ + tờ mới
                    if (soto != null && soto != sotocheck)
                    {
                        sotocheck = soto;
                        pFilterSDE.WhereClause = "[SoToBD] = '" + soto + "'";
                        featSelectSDE.SelectFeatures(pFilterSDE, esriSelectionResultEnum.esriSelectionResultNew, false);
                        IEnumIDs idList2 = featSelectSDE.SelectionSet.IDs;
                        int index2 = idList2.Next();
                        List<int> indexes2 = new List<int>();
                        while (index2 != -1)
                        {
                            indexes2.Add(index2);
                            index2 = idList2.Next();
                        }
                        if (indexes2.Count == 0)
                        {
                            // thêm cả tờ (chưa sửa)

                        }
                        else
                        {
                            for (int i2 = 0; i2 < indexes2.Count; i2++)
                            {
                                IFeature feature = featureClassSDE.GetFeature(indexes2[i2]);
                                if (feature.get_Value(feature.Fields.FindField("SoToBD")) != DBNull.Value & feature.get_Value(feature.Fields.FindField("SoThua")) != DBNull.Value)
                                {
                                    pFilterSHP1thua.WhereClause = "SHBANDO = " + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + " and SHTHUA = " + feature.get_Value(feature.Fields.FindField("SoThua")).ToString();
                                    featSelectSHP1thua.SelectFeatures(pFilterSHP1thua, esriSelectionResultEnum.esriSelectionResultNew, false);
                                    if (featSelectSHP1thua.SelectionSet.Count == 0)
                                    {
                                        drSDE = dtSDE.NewRow();
                                        drSDE[0] = feature.get_Value(feature.Fields.FindField("OBJECTID")).ToString();
                                        drSDE[1] = feature.get_Value(feature.Fields.FindField("SoToBD")).ToString();
                                        drSDE[2] = feature.get_Value(feature.Fields.FindField("SoThua")).ToString();
                                        drSDE[3] = "Thửa cũ";
                                        dtSDE.Rows.Add(drSDE);
                                    }
                                }
                            }
                        }
                    }
                }
                frm = new FrmKiemTra(dtSHP, dtSDE);
                Cursor = Cursors.Default;
                frm.Show();
            }
           splashScreenManager1.CloseWaitForm();
            Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
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
                    else if (featureClassSHP.FindField("SHTHUA") == -1)
                    { MessageBox.Show("Shapefile không đúng thông tin cột số thửa", "Thông báo"); }
                    else
                    {
                        activeView.FocusMap.AddLayer(featureLayer);
                        activeView.Extent = activeView.FullExtent;
                        activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                        txtshp.Text = shapefileLocation;
                        QLHTDT.Properties.Settings.Default.pathSHP = System.IO.Path.GetDirectoryName(shapefileLocation);
                        QLHTDT.Properties.Settings.Default.Save();
                        layershp = KienTruc.axMapControl1.get_Layer(0);
                        IRgbColor color2 = new RgbColorClass();
                        color2.Red = 224;
                        color2.Green = 255;
                        color2.Blue = 255;
                        color2.UseWindowsDithering = true;
                        hienlabel(layershp, "SHTHUA", 255, color2);
                    }
                }

            }
            Cursor = Cursors.Default;
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
            splashScreenManager1.ShowWaitForm();
            DataTable add = new DataTable();
            add = FrmKiemTra.dataADD;
            DataTable del = new DataTable();
            del = FrmKiemTra.dataDEL;
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
                            KienTruc.axMapControl1.Refresh();
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
                            //            KienTruc.axMapControl1.Refresh();
                            //        }
                            //    }
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
                                    feature.Delete();
                                    feature.Store();
                                }
                            }

                        }
                    }
                }
            }
            splashScreenManager1.CloseWaitForm();
            KienTruc.axMapControl1.Refresh();
            MessageBox.Show("Cập nhật thành công", "Thông báo");
        }

        private void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (QLHTDT.Properties.Settings.Default.checksavepathSDE == false)
            {
                IWorkspaceFactory2 workspaceFactory = (IWorkspaceFactory2)new SdeWorkspaceFactoryClass();
                featureWorkspaceSDE = (IFeatureWorkspace)workspaceFactory.OpenFromFile(QLHTDT.Properties.Settings.Default.savepathSDE, 0);
            }
            else
            {
                IWorkspaceFactory2 workspaceFactory = (IWorkspaceFactory2)new SdeWorkspaceFactoryClass();
                featureWorkspaceSDE = (IFeatureWorkspace)workspaceFactory.Open(Properties.Settings.Default.pathcauhinhSDE, 0);
            }

            AddQuan = 1;
            CboPhuong.ResetText();
            if (cboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                cboQuan.Text = "";
            }
            if (AddQuan == 1)
            {
                MaHuyen = cboQuan.SelectedValue.ToString();
                LoadDatabase("[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + "", CboPhuong, "TenPhuong", "MaPhuong");
                if (CboPhuong.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    CboPhuong.Text = "";
                }
            }

        }
        void LoadDatabase(string Query, ComboBox Combobox, string DisplayMember, string ValueMember)
        {
            SqlDataAdapter adp = new SqlDataAdapter(Query, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Combobox.DataSource = ds.Tables[0];
            Combobox.DisplayMember = DisplayMember;
            Combobox.ValueMember = ValueMember;
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
            if (CboPhuong.SelectedValue.ToString() != "" || CboPhuong.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                phuong = CboPhuong.Text;
                //this.CboSoTo.Items.AddRange(new object[] {
                //"12",
                //"13",
                //"14",
                //"15"});

                if (phuong == "")
                { MessageBox.Show("Chưa chọn phường", "Thông báo"); }
                else
                {
                    featureClassSDE = featureWorkspaceSDE.OpenFeatureClass("DIACHINH");
                    ESRI.ArcGIS.Carto.IFeatureLayer featureLayer = new ESRI.ArcGIS.Carto.FeatureLayerClass();
                    featureLayer.FeatureClass = featureClassSDE;
                    featureLayer.Name = featureClassSDE.AliasName;
                    featureLayer.Visible = true;
                    //activeView.FocusMap.AddLayer(featureLayer);
                    //hienlabel(featureClassSDE,"SoThua");
                    //activeView.Extent = activeView.FullExtent;
                    activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
                    layersde = KienTruc.axMapControl1.get_Layer(0);
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

        private void hienlabel(ILayer layera, string DisplayField, int col, IRgbColor icolor)
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
                QLHTDT.FormChinh.KienTruc.axMapControl1.Update();
                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCauHinhSDE frmcauhinh = new FrmCauHinhSDE();
            frmcauhinh.ShowDialog();
            if (frmcauhinh.Visible == false)
            {
                this.Visible = true;
            }
        }

        private void cboQuan_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (QLHTDT.Properties.Settings.Default.checksavepathSDE == false)
            {

                IWorkspaceFactory2 workspaceFactory = (IWorkspaceFactory2)new SdeWorkspaceFactoryClass();
                featureWorkspaceSDE = (IFeatureWorkspace)workspaceFactory.OpenFromFile(QLHTDT.Properties.Settings.Default.savepathSDE, 0);
            }
            else
            {

                IWorkspaceFactory2 workspaceFactory = (IWorkspaceFactory2)new SdeWorkspaceFactoryClass();
                featureWorkspaceSDE = (IFeatureWorkspace)workspaceFactory.Open(Properties.Settings.Default.pathcauhinhSDE, 0);
            }
        }
    }
}
