using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;

namespace QLHTDT.axToccontrol
{
    public partial class Symbology : Form
    {
        IFeatureLayer fLayer;
        ITable tb;
        IUniqueValueRenderer pUniqueValueR;
        public IStyleGalleryItem m_styleGalleryItem;
        public static DataTable dt;
        public static DataTable dt2;
        public static DataRow dr;
        IGeoFeatureLayer geoFeatureLayer;
        IRandomColorRamp pRandomColorRamp;
        ISimpleFillSymbol pSimpleFillSymbol;
        string classValue;
        public Symbology()
        {
            InitializeComponent();
            fLayer = QLHTDT.FormChinh.KienTruc.layer as IFeatureLayer;
            tb = fLayer.FeatureClass as ITable;
            QLHTDT.axToccontrol.Table.TableWrapper wratbal = new QLHTDT.axToccontrol.Table.TableWrapper(tb);
            comboBox3.Visible = false;
            label3.Visible = false;
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //string strNameField = comboBox3.SelectedValue.ToString();
            //pActiveView = QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView;
            //pMap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map; pMap.ReferenceScale = 0;
            //m_pGeoFeatureL = (IGeoFeatureLayer)QLHTDT.FormChinh.KienTruc.layer;
            //pUniqueValueR = new UniqueValueRendererClass();
            //pTable = (ITable)m_pGeoFeatureL;
            //lfieldNumber = pTable.FindField(strNameField); if (lfieldNumber == -1) { MessageBox.Show("Can't find field called " + strNameField); return; }

            //pUniqueValueR.FieldCount = 1;

            //pUniqueValueR.set_Field(0, strNameField);
            //pColorRamp = new RandomColorRampClass();
            //pColorRamp.StartHue = 0;
            //pColorRamp.MinValue = 0;
            //pColorRamp.MinSaturation = 15;
            //pColorRamp.EndHue = 360;
            //pColorRamp.MaxValue = 100;
            //pColorRamp.MaxSaturation = 30;
            //pColorRamp.Size = 100; bool ok = true;
            //pColorRamp.CreateRamp(out ok);
            //pEnumRamp = pColorRamp.Colors;
            //pNextUniqueColor = null;

            //pQueryFilter = new QueryFilterClass();
            //pQueryFilter.AddField(strNameField);

            //pCursor = pTable.Search(pQueryFilter, true);
            //pNextRow = pCursor.NextRow();

            //while (pNextRow != null)
            //{
            //    pNextRowBuffer = pNextRow;
            //    codeValue = (string)pNextRowBuffer.get_Value(lfieldNumber);
            //    pNextUniqueColor = pEnumRamp.Next();
            //    if (pNextUniqueColor == null)
            //    { pEnumRamp.Reset(); pNextUniqueColor = pEnumRamp.Next(); }
            //    pFillSymbol = new SimpleFillSymbolClass();
            //    pLineSymbol = new SimpleLineSymbolClass();
            //    pFillSymbol.Color = pNextUniqueColor;
            //    pLineSymbol.Color = pNextUniqueColor;
            //    pMarkerSymbol = new SimpleMarkerSymbolClass();
            //    pMarkerSymbol.Color = pNextUniqueColor;
            //    switch (QLHTDT.FormChinh.KienTruc.featureLayer.FeatureClass.ShapeType)
            //    {
            //        case esriGeometryType.esriGeometryPoint:
            //            pUniqueValueR.AddValue(codeValue, strNameField, (ISymbol)pMarkerSymbol);
            //            break;
            //        case esriGeometryType.esriGeometryPolyline:
            //            pUniqueValueR.AddValue(codeValue, strNameField, (ISymbol)pLineSymbol);
            //            break;
            //        case esriGeometryType.esriGeometryPolygon:
            //            pUniqueValueR.AddValue(codeValue, strNameField, (ISymbol)pFillSymbol);
            //            break;
            //    }
            //    pNextRow = pCursor.NextRow();
            //}
            //m_pGeoFeatureL.Renderer = (IFeatureRenderer)pUniqueValueR;
            //pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            //QLHTDT.FormChinh.KienTruc.axTOCControl1.Update();
            //QLHTDT.FormChinh.KienTruc.axMapControl1.Update();
            //QLHTDT.FormChinh.KienTruc.axTOCControl1.Refresh();
            //QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
            //object sende = new object(); EventArgs en = new EventArgs();
            //toolStripButton1_Click(sende, en);



            
            fLayer = QLHTDT.FormChinh.KienTruc.featureLayer;
            //QI to IFeatureLayer and IGeoFeatuerLayer interface
            geoFeatureLayer = (IGeoFeatureLayer)fLayer;
            pRandomColorRamp = new RandomColorRampClass();
            //Create the color ramp for Symbols in the renderer
            pRandomColorRamp.MinSaturation = 20;
            pRandomColorRamp.MaxSaturation = 40;
            pRandomColorRamp.MinValue = 85;
            pRandomColorRamp.MaxValue = 100;
            pRandomColorRamp.StartHue = 76;
            pRandomColorRamp.EndHue = 188;
            pRandomColorRamp.UseSeed = true;
            pRandomColorRamp.Seed = 43;

            //Create the renderer
            pUniqueValueR = new UniqueValueRendererClass();
            pSimpleFillSymbol = new SimpleFillSymbolClass();
            pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
            pSimpleFillSymbol.Outline.Width = 0.4;

            //These properties should be set prior to adding values
            pUniqueValueR.FieldCount = 1;
            pUniqueValueR.set_Field(0, comboBox3.SelectedValue.ToString());
            pUniqueValueR.DefaultSymbol = pSimpleFillSymbol as ISymbol;
            pUniqueValueR.UseDefaultSymbol = true;

            IDisplayTable pDisplayTable = geoFeatureLayer as IDisplayTable;
            IFeatureCursor pFeatureCursor = pDisplayTable.SearchDisplayTable(null, false) as IFeatureCursor;
            IFeature pFeature = pFeatureCursor.NextFeature();

            bool ValFound;
            int fieldIndex;

            IFields pFields = pFeatureCursor.Fields;
            fieldIndex = pFields.FindField(comboBox3.SelectedValue.ToString());
            while (pFeature != null)
            {
                ISimpleFillSymbol pClassSymbol = new SimpleFillSymbol();
                pClassSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
                pClassSymbol.Outline.Width = 0.4;

                
                classValue = pFeature.get_Value(fieldIndex) as string;

                //test to see if this value was added to renderer. If not, add it
                ValFound = false;
                for (int i = 0; i <= pUniqueValueR.ValueCount - 1; i++)
                {
                    if (pUniqueValueR.get_Value(i) == classValue)
                    {
                        ValFound = true;
                        break;
                    }
                }
                //if the value was not found, it's new and will be added
                if (ValFound == false)
                {
                    pUniqueValueR.AddValue(classValue, comboBox3.SelectedValue.ToString(), pClassSymbol as ISymbol);
                    pUniqueValueR.set_Label(classValue, classValue);
                    pUniqueValueR.set_Symbol(classValue, pClassSymbol as ISymbol);
                }
                pFeature = pFeatureCursor.NextFeature();
            }
        }
        public IStyleGalleryItem GetItem(esriSymbologyStyleClass styleClass, ISymbol symbol)
        {
            m_styleGalleryItem = null;

            //Get and set the style class
            axSymbologyControl1.StyleClass = styleClass;
            ISymbologyStyleClass symbologyStyleClass = axSymbologyControl1.GetStyleClass(styleClass);

            //Create a new server style gallery item with its style set
            IStyleGalleryItem styleGalleryItem = new ServerStyleGalleryItem();
            styleGalleryItem.Item = symbol;
            styleGalleryItem.Name = "mySymbol";

            //Add the item to the style class and select it
            symbologyStyleClass.AddItem(styleGalleryItem, 0);
            symbologyStyleClass.SelectItem(0);

            //Show the modal form
            this.ShowDialog();

            return m_styleGalleryItem;
        }
        //private void SetFeatureClassStyle(esriSymbologyStyleClass symbologyStyleClass)
        //{
        //    ILegendClass pLegendClass;
        //    axSymbologyControl1.StyleClass = symbologyStyleClass;
        //    ISymbologyStyleClass pSymbologyStyleClass = axSymbologyControl1.GetStyleClass(symbologyStyleClass);
        //    if (pLegendClass != null)
        //    {
        //        IStyleGalleryItem currentStyleGalleryItem = new ServerStyleGalleryItem();
        //        currentStyleGalleryItem.Name = "";
        //        currentStyleGalleryItem.Item = pLegendClass.Symbol;
        //        pSymbologyStyleClass.AddItem(currentStyleGalleryItem, 0);
        //        pStyleGalleryItem = currentStyleGalleryItem;
        //    }

        //    pSymbologyStyleClass.SelectItem(0);

        //}
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Hiển thị tất cả cùng 1 ký hiệu")
            {
                button3.Visible = true;
                comboBox3.Visible = false;
                label3.Visible = false;
            }
            if (comboBox1.Text == "Hiển thị theo giá trị trong bảng thuộc tính")
            {
                button3.Visible = false;
                comboBox3.Visible = true;
                label3.Visible = true;
                QLHTDT.CORE.LoadLayer.Loadfieldtocombox(tb, comboBox3);
            }
        }

        private void all1Nhan_Click(object sender, EventArgs e)
        {
            IFeatureLayer featureLayer;
            featureLayer = QLHTDT.FormChinh.KienTruc.featureLayer;
            //QI to IFeatureLayer and IGeoFeatuerLayer interface
            IGeoFeatureLayer geoFeatureLayer = (IGeoFeatureLayer)featureLayer;
            ISimpleRenderer simpleRenderer = (ISimpleRenderer)geoFeatureLayer.Renderer;
            geoFeatureLayer.Renderer = (IFeatureRenderer)simpleRenderer;
            //C;eate the form with the SymbologyControl
            QLHTDT.SymbolForm symbolForm = new QLHTDT.SymbolForm();

            //Get the IStyleGalleryItem
            IStyleGalleryItem styleGalleryItem = null;
            //Select SymbologyStyleClass based upon feature type
            switch (QLHTDT.FormChinh.KienTruc.featureLayer.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassMarkerSymbols, simpleRenderer.Symbol);
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassLineSymbols, simpleRenderer.Symbol);
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassFillSymbols, simpleRenderer.Symbol);
                    break;
            }
            //Release the form
            symbolForm.Dispose();
            //QLHTDT.FormChinh.KienTruc.ActiveForm.Activate();

            if (styleGalleryItem == null) return;

            //Create a new renderer
            simpleRenderer = new SimpleRendererClass();
            //Set its symbol from the styleGalleryItem
            simpleRenderer.Symbol = (ISymbol)styleGalleryItem.Item;
            //Set the renderer into the geoFeatureLayer
            geoFeatureLayer.Renderer = (IFeatureRenderer)simpleRenderer;
            QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView.ContentsChanged();
            //Refresh the display
            QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
            //Fire contents changed event that the TOCControl listens to
            QLHTDT.FormChinh.KienTruc.axPageLayoutControl1.ActiveView.ContentsChanged();
            //Refresh the display
            QLHTDT.FormChinh.KienTruc.axPageLayoutControl1.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
        }
        private static Image pointsymboltoimage(ISymbol symbol, Size imagesize)
        {
            double x = imagesize.Width / 2;
            double y = (imagesize.Height - 1) / 2;
            IPoint point = new PointClass();
            point.PutCoords(x, y);
            Image image = new Bitmap(imagesize.Width, imagesize.Height) ;
            Graphics g = Graphics.FromImage(image);
            symbol.SetupDC(g.GetHdc().ToInt32(), null);
            try { symbol.Draw(point); }
            catch { }
            symbol.ResetDC();
            g.Dispose();
            return image;
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            QLHTDT.CORE.LoadLayer.Loadvaluestolistbox(tb, comboBox3.SelectedValue.ToString(), comboBox2);
            
        }
        private void ThemAll_Click(object sender, EventArgs e)
        {
            dt2.Clear();
            dt2.Rows.Clear();
            fLayer = QLHTDT.FormChinh.KienTruc.featureLayer;
            geoFeatureLayer = (IGeoFeatureLayer)fLayer;
            if (QLHTDT.FormChinh.KienTruc.featureLayer.FeatureClass.ShapeType.ToString().Contains("line"))
            {
                QLHTDT.Global.DefineUniqueValueRendererLine(geoFeatureLayer, comboBox3.SelectedValue.ToString());
            }
            else if (QLHTDT.FormChinh.KienTruc.featureLayer.FeatureClass.ShapeType.ToString().Contains("gon"))
            {
                QLHTDT.Global.DefineUniqueValueRenderer(geoFeatureLayer, comboBox3.SelectedValue.ToString());
            }
            else if (QLHTDT.FormChinh.KienTruc.featureLayer.FeatureClass.ShapeType.ToString().Contains("oint"))
            {
                QLHTDT.Global.DefineUniqueValueRendererPoint(geoFeatureLayer, comboBox3.SelectedValue.ToString());
            }
            pUniqueValueR = QLHTDT.Global.pUniqueValueR;
            IDisplayTable pDisplayTable = geoFeatureLayer as IDisplayTable;
            IFeatureCursor pFeatureCursor = pDisplayTable.SearchDisplayTable(null, false) as IFeatureCursor;
            IFeature pFeature = pFeatureCursor.NextFeature();
            IFields pFields = pFeatureCursor.Fields;
            int fieldIndex;
            fieldIndex = pFields.FindField(comboBox3.SelectedValue.ToString());
            for (int i = 0; i <= pUniqueValueR.ValueCount - 1; i++)
            {
                Size imagesize = new Size(100, 30);
                //Image AnhLop = pointsymboltoimage(pUniqueValueR.Symbol[pUniqueValueR.get_Value(i)], imagesize);
                dr = dt2.NewRow();
                dr[0] = dt2.Rows.Count;
                dr[1] = pUniqueValueR.get_Value(i);
                dr[3] = pUniqueValueR.get_Value(i);
                dt2.Rows.Add(dr);
                IStyleGalleryItem styleGalleryItem2 = new ServerStyleGalleryItem();
                styleGalleryItem2.Item = pUniqueValueR.get_Symbol(pUniqueValueR.get_Value(i));
                ISymbologyStyleClass symbologyStyleClass = axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass);
                stdole.IPictureDisp picture = symbologyStyleClass.PreviewItem(styleGalleryItem2, 100, 30);
                System.Drawing.Image image = System.Drawing.Image.FromHbitmap(new System.IntPtr(picture.Handle));
                dr[2] = image;
            }
                pFeature = pFeatureCursor.NextFeature();
            



            QLHTDT.FormChinh.KienTruc.axMapControl1.Update();
            QLHTDT.FormChinh.KienTruc.axTOCControl1.Update();
            QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
            gridControl1.DataSource = dt2;
            gridView1.RefreshData();

            ////QI to IFeatureLayer and IGeoFeatuerLayer interface

            //pRandomColorRamp = new RandomColorRampClass();
            ////Create the color ramp for Symbols in the renderer
            //pRandomColorRamp.MinSaturation = 20;
            //pRandomColorRamp.MaxSaturation = 40;
            //pRandomColorRamp.MinValue = 85;
            //pRandomColorRamp.MaxValue = 100;
            //pRandomColorRamp.StartHue = 76;
            //pRandomColorRamp.EndHue = 188;
            //pRandomColorRamp.UseSeed = true;
            //pRandomColorRamp.Seed = 43;

            ////Create the renderer
            //pUniqueValueR = new UniqueValueRendererClass();
            //pSimpleFillSymbol = new SimpleFillSymbolClass();
            //pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
            //pSimpleFillSymbol.Outline.Width = 0.4;

            //////These properties should be set prior to adding values
            //pUniqueValueR.FieldCount = 1;
            //pUniqueValueR.set_Field(0, comboBox3.SelectedValue.ToString());
            //pUniqueValueR.DefaultSymbol = pSimpleFillSymbol as ISymbol;
            //pUniqueValueR.UseDefaultSymbol = true;

            //IDisplayTable pDisplayTable = geoFeatureLayer as IDisplayTable;
            //IFeatureCursor pFeatureCursor = pDisplayTable.SearchDisplayTable(null, false) as IFeatureCursor;
            //IFeature pFeature = pFeatureCursor.NextFeature();

            //bool ValFound;
            //int fieldIndex;

            //IFields pFields = pFeatureCursor.Fields;
            //fieldIndex = pFields.FindField(comboBox3.SelectedValue.ToString());
            //while (pFeature != null)
            //{
            //    ISimpleFillSymbol pClassSymbol = new SimpleFillSymbol();
            //    pClassSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
            //    pClassSymbol.Outline.Width = 0.4;


            //    classValue = pFeature.get_Value(fieldIndex) as string;

            //    //test to see if this value was added to renderer. If not, add it
            //    ValFound = false;
            //    for (int i = 0; i <= pUniqueValueR.ValueCount - 1; i++)
            //    {
            //        if (pUniqueValueR.get_Value(i) == classValue)
            //        {
            //            ValFound = true;
            //            break;
            //        }
            //    }
            //    //if the value was not found, it's new and will be added
            //    if (ValFound == false)
            //    {
            //        pUniqueValueR.AddValue(classValue, comboBox3.SelectedValue.ToString(), pClassSymbol as ISymbol);
            //        pUniqueValueR.set_Label(classValue, classValue);
            //        pUniqueValueR.set_Symbol(classValue, pClassSymbol as ISymbol);
            //        //dr[0] = dt2.Rows.Count+1;
            //        //dr[2] = classValue;
            //        //dr[3] = pClassSymbol.ToString();
            //        //dt2.Rows.Add(dr);
            //            dr = dt2.NewRow();
            //            dr[0] = dt2.Rows.Count;
            //            dr[1] = classValue;
            //            //dr[2] = pClassSymbol.ToString();
            //            dr[3] = classValue;
            //            dt2.Rows.Add(dr);
            //    }
            //    pFeature = pFeatureCursor.NextFeature();
            //}


        }

        private void Symbology_Load(object sender, EventArgs e)
        {
            string sInstallPath = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;
            //Load the ESRI.ServerStyle file into the SymbologyControl
            axSymbologyControl1.LoadStyleFile(QLHTDT.Properties.Settings.Default.PathData + "\\SGMCHTDT.ServerStyle");
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassBackgrounds).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassBorders).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassShadows).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassMarkerSymbols).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassLineSymbols).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassFillSymbols).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassTextSymbols).Update();
            switch (QLHTDT.FormChinh.KienTruc.featureLayer.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
                    break;
            }
            dt2 = new DataTable();
            dt2.Columns.Add("STT", typeof(Double));
            dt2.Columns.Add("Giá trị", typeof(String));
            dt2.Columns.Add("Ký hiệu", typeof(Image));
            dt2.Columns.Add("Tên kí hiệu", typeof(String));
            gridControl1.DataSource = dt2;
            dt2.PrimaryKey = new DataColumn[] { dt2.Columns["Giá trị"] };
        }

        private void PreviewImage()
        {
            //Get and set the style class 
            ISymbologyStyleClass symbologyStyleClass = axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass);

            //Preview an image of the symbol
            stdole.IPictureDisp picture = symbologyStyleClass.PreviewItem(m_styleGalleryItem, pictureBox1.Width, pictureBox1.Height);
            System.Drawing.Image image = System.Drawing.Image.FromHbitmap(new System.IntPtr(picture.Handle));
            pictureBox1.Image = image;
        }
        private void axSymbologyControl1_OnItemSelected(object sender, ESRI.ArcGIS.Controls.ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            //Preview the selected item
            m_styleGalleryItem = (IStyleGalleryItem)e.styleGalleryItem;
            ISymbol a = m_styleGalleryItem as ISymbol;
            PreviewImage();
        }
        private void Them1_Click(object sender, EventArgs e)
        {
            QLHTDT.axToccontrol.ThemSymbol1lop frm = new ThemSymbol1lop();
            frm.ShowDialog();
            frm.Dispose();
            fLayer = QLHTDT.FormChinh.KienTruc.featureLayer;
            //QI to IFeatureLayer and IGeoFeatuerLayer interface
            geoFeatureLayer = (IGeoFeatureLayer)fLayer;
            pRandomColorRamp = new RandomColorRampClass();
            //Create the color ramp for Symbols in the renderer
            pRandomColorRamp.MinSaturation = 20;
            pRandomColorRamp.MaxSaturation = 40;
            pRandomColorRamp.MinValue = 85;
            pRandomColorRamp.MaxValue = 100;
            pRandomColorRamp.StartHue = 76;
            pRandomColorRamp.EndHue = 188;
            pRandomColorRamp.UseSeed = true;
            pRandomColorRamp.Seed = 43;

            if (pUniqueValueR == null)
            {
                pUniqueValueR = new UniqueValueRendererClass();
                pSimpleFillSymbol = new SimpleFillSymbolClass();
                pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
                pSimpleFillSymbol.Outline.Width = 0.4;
                pUniqueValueR.FieldCount = 1;
                pUniqueValueR.set_Field(0, comboBox3.SelectedValue.ToString());
                pUniqueValueR.DefaultSymbol = pSimpleFillSymbol as ISymbol;
                pUniqueValueR.UseDefaultSymbol = true;
            }

            IDisplayTable pDisplayTable = geoFeatureLayer as IDisplayTable;
            IFeatureCursor pFeatureCursor = pDisplayTable.SearchDisplayTable(null, false) as IFeatureCursor;
            IFeature pFeature = pFeatureCursor.NextFeature();

            bool ValFound;
            int fieldIndex;

            IFields pFields = pFeatureCursor.Fields;
            fieldIndex = pFields.FindField(comboBox3.SelectedValue.ToString());
            if (QLHTDT.axToccontrol.ThemSymbol1lop.TenLopThem != null)
            {
                while (pFeature != null)
                {
                    ISimpleFillSymbol pClassSymbol = new SimpleFillSymbol();
                    pClassSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
                    pClassSymbol.Outline.Width = 0.4;


                    classValue = pFeature.get_Value(fieldIndex) as string;

                    //test to see if this value was added to renderer. If not, add it
                    ValFound = false;
                    for (int i = 0; i <= pUniqueValueR.ValueCount - 1; i++)
                    {
                        if (pUniqueValueR.get_Value(i) == QLHTDT.axToccontrol.ThemSymbol1lop.TenLopThem)
                        {
                            ValFound = true;
                            break;
                        }
                    }
                    //if the value was not found, it's new and will be added
                    if (ValFound == false)
                    {
                        int a;
                        a = 0;
                        for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                        {
                            if (dt2.Rows[i]["Giá trị"].ToString() == QLHTDT.axToccontrol.ThemSymbol1lop.TenLopThem)
                            { a = a + 1; }
                        }
                        if (a < 1)
                        {
                            pUniqueValueR.AddValue(QLHTDT.axToccontrol.ThemSymbol1lop.TenLopThem, comboBox3.SelectedValue.ToString(), pClassSymbol as ISymbol);
                            pUniqueValueR.set_Label(QLHTDT.axToccontrol.ThemSymbol1lop.TenLopThem, QLHTDT.axToccontrol.ThemSymbol1lop.TenLopThem);
                            pUniqueValueR.set_Symbol(QLHTDT.axToccontrol.ThemSymbol1lop.TenLopThem, pClassSymbol as ISymbol);


                            dr = dt2.NewRow();
                            dr[0] = dt2.Rows.Count;
                            dr[1] = pUniqueValueR.get_Value(pUniqueValueR.ValueCount - 1);
                            dr[3] = pUniqueValueR.get_Value(pUniqueValueR.ValueCount - 1);
                            dt2.Rows.Add(dr);

                        }

                    }
                    pFeature = pFeatureCursor.NextFeature();
                }
            }
            
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            string ab = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Giá trị").ToString();
            for (int i = 0; i <= pUniqueValueR.ValueCount - 1; i++)
            {
                if (pUniqueValueR.get_Value(i) == ab)
                {
                    pUniqueValueR.get_Symbol(pUniqueValueR.get_Value(i));
                    IStyleGalleryItem styleGalleryItem2 = new ServerStyleGalleryItem();
                    styleGalleryItem2.Item = pUniqueValueR.get_Symbol(pUniqueValueR.get_Value(i));
                    ISymbologyStyleClass symbologyStyleClass = axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass);
                    stdole.IPictureDisp picture = symbologyStyleClass.PreviewItem(styleGalleryItem2, pictureBox1.Width, pictureBox1.Height);
                    System.Drawing.Image image = System.Drawing.Image.FromHbitmap(new System.IntPtr(picture.Handle));
                    pictureBox1.Image = image;
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            
            QLHTDT.SymbolForm2 frm2 = new QLHTDT.SymbolForm2();
            //Select SymbologyStyleClass based upon feature type
            switch (QLHTDT.FormChinh.KienTruc.featureLayer.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                SymbolForm2.axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    SymbolForm2.axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    SymbolForm2.axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
                    break;
            }
            frm2.ShowDialog();
            string ab = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Giá trị").ToString();
            frm2.Dispose();
            for (int i = 0; i <= pUniqueValueR.ValueCount - 1; i++)
            {
                if (QLHTDT.SymbolForm2.stylechon != null)
                {
                    if (pUniqueValueR.get_Value(i) == ab)
                    {
                        ISymbol moi = QLHTDT.SymbolForm2.stylechon.Item as ISymbol;
                        pUniqueValueR.set_Symbol(pUniqueValueR.get_Value(i), moi);
                        for (int i2 = 0; i2 <= dt2.Rows.Count-1; i2++)
                            if (dt2.Rows[i2]["Giá trị"].ToString() == ab)
                        {
                            dt2.Rows[i2]["Ký hiệu"] = QLHTDT.SymbolForm2.AnhLop;
                            dt2.Rows[i2]["Tên kí hiệu"] = QLHTDT.SymbolForm2.TenSymbol;
                            gridControl1.DataSource = dt2;
                            gridView1.RefreshData();
                        }
                    }
                }
            }
            geoFeatureLayer.Renderer = pUniqueValueR as IFeatureRenderer;
            QLHTDT.FormChinh.KienTruc.axMapControl1.Update();
            QLHTDT.FormChinh.KienTruc.axTOCControl1.Update();
            QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
        }

        private void XoaAll_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i <= dt2.Rows.Count; i++)
            //{
            //    dt2.Rows[i].Delete();
            //}
            dt2.Clear();
            dt2.Rows.Clear();
            gridControl1.DataSource = dt2;
            gridView1.RefreshData();
        }

        private void XoaLopChon_Click(object sender, EventArgs e)
        {

        }

       

        //void button1_Leave(object sender, System.EventArgs e)
        //{
        //    QLHTDT.FormChinh.KienTruc.axTOCControl1.Refresh();
        //    QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
        //    QLHTDT.FormChinh.KienTruc.axTOCControl1.Update();
        //    QLHTDT.FormChinh.KienTruc.axMapControl1.Update();
        //}
    }
}
