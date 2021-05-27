using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;

namespace QLHTDT //là 1 class,ko phải base tool hay command
{
    public static class Global
    {
        public static IMxDocument pMxDoc;
        public static IWorkspace pWorkspace;
        public static IFeatureWorkspace pFWorkspace;
        public static IActiveView pActiveView;
        public static IUniqueValueRenderer pUniqueValueR;
        //Đoạn này gúp hiển thị lớp dữ liệu, ko bị trùng, VD:bật lớp ThuyHe lên, sau đó bật bớp GiaoThong nữa thì ThuyHe ko hiện nữa
        public static bool ExistLayer(IMap pMap, String pName)
        {
            int i;
            /*
             * Nếu để trừ 1 theo trong sách thì khi click vào để hiển thị lớp DiaChinh xong, 
             * ta click vào lớp GiaoThong thì lớp DiaChinh hiện ra nữa
             * for (i = 0; i < pMap.LayerCount - 1; i++)
             */
            for (i = 0; i < pMap.LayerCount; i++)
                if (pMap.get_Layer(i).Name.ToUpper() == pName.ToUpper())
                    return true;
            return false;
        }
        //
        public static ILayer getLayerbyName(IMap pMap, String pName)
        {
            int i;
            ILayer pLayer = null;
            for (i = 0; i < pMap.LayerCount; i++)
            {
                ICompositeLayer igroup2 = pMap.get_Layer(i) as ICompositeLayer;
                if (igroup2 == null)
                {
                    //string name = pMap.get_Layer(i).Name;
                    if (pMap.get_Layer(i).Name == pName)
                        pLayer = pMap.get_Layer(i);
                }
                else
                {
                    for (int i2 = 0; i2 < igroup2.Count; i2++)
                    {
                        ICompositeLayer igroup = igroup2.get_Layer(i2) as ICompositeLayer;
                        if (igroup == null)
                        {
                            //string name = igroup2.get_Layer(i2).Name;
                            if (igroup2.get_Layer(i2).Name == pName)
                                pLayer = igroup2.get_Layer(i2);
                        }
                    }
                }
            }
               
            return pLayer;
        }
        //
        public static void DeleteLayer(IMap pMap, string pName)
        {
            int i;
            for (i = 0; i < pMap.LayerCount; i++)
                if (pMap.get_Layer(i).Name.ToUpper() == pName.ToUpper())
                    pMap.DeleteLayer(pMap.get_Layer(i));
            return;
        }
        public static void DefineUniqueValueRenderer(IGeoFeatureLayer pGeoFeatureLayer, string fieldName)
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
                    if (xv == "CAN")
                    {
                        pColor.Red = 255;
                        pColor.Green = 80;
                        pColor.Blue = 70;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "CQP")
                    {
                        pColor.Red = 255;
                        pColor.Green = 100;
                        pColor.Blue = 80;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DBV")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DGD")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DGT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 50;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DNL")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DRA")
                    {
                        pColor.Red = 205;
                        pColor.Green = 170;
                        pColor.Blue = 205;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DTL")
                    {
                        pColor.Red = 170;
                        pColor.Green = 250;
                        pColor.Blue = 250;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DVH")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DYT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNK")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNQ")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNQ")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LUK")
                    {
                        pColor.Red = 255;
                        pColor.Green = 252;
                        pColor.Blue = 150;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "NTD")
                    {
                        pColor.Red = 210;
                        pColor.Green = 210;
                        pColor.Blue = 210;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "SKC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "SKX")
                    {
                        pColor.Red = 205;
                        pColor.Green = 170;
                        pColor.Blue = 205;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "SON")
                    {
                        pColor.Red = 160;
                        pColor.Green = 255;
                        pColor.Blue = 255;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "TIN")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "TON")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "TSC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "ODT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 160;
                        pColor.Blue = 255;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "QHANQP")
                    {
                        pColor.Red = 38;
                        pColor.Green = 38;
                        pColor.Blue = 19;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHCCDT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 0;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHCN")
                    {
                        pColor.Red = 82;
                        pColor.Green = 0;
                        pColor.Blue = 165;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHCQ")
                    {
                        pColor.Red = 127;
                        pColor.Green = 63;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHCXCD")
                    {
                        pColor.Red = 0;
                        pColor.Green = 127;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color.Transparency = 50;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "QHCXCL")
                    {
                        pColor.Red = 0;
                        pColor.Green = 76;
                        pColor.Blue = 57;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHCXDT")
                    {
                        pColor.Red = 82;
                        pColor.Green = 165;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color.Transparency = 50;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "QHDL")
                    {
                        pColor.Red = 255;
                        pColor.Green = 0;
                        pColor.Blue = 255;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHDVO")
                    {
                        pColor.Red = 255;
                        pColor.Green = 127;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "QHMN")
                    {
                        pColor.Red = 0;
                        pColor.Green = 83;
                        pColor.Blue = 165;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHNN")
                    {
                        pColor.Red = 0;
                        pColor.Green = 255;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHNT")
                    {
                        pColor.Red = 101;
                        pColor.Green = 101;
                        pColor.Blue = 101;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHOBT")
                    {
                        pColor.Red = 76;
                        pColor.Green = 76;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHOCC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 191;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHOHH")
                    {
                        pColor.Red = 127;
                        pColor.Green = 95;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QTTG")
                    {
                        pColor.Red = 76;
                        pColor.Green = 0;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHTHCS")
                    {
                        pColor.Red = 127;
                        pColor.Green = 63;
                        pColor.Blue = 63;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHTHPT")
                    {
                        pColor.Red = 127;
                        pColor.Green = 31;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHTTYT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 0;
                        pColor.Blue = 191;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHXLNT")
                    {
                        pColor.Red = 212;
                        pColor.Green = 170;
                        pColor.Blue = 255;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
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
            pUniqueValueR = pUniqueValueRenderer;
        }
        public static void DefineUniqueValueRendererLine(IGeoFeatureLayer pGeoFeatureLayer, string fieldName)
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
            ISimpleLineSymbol pSimpleFillSymbol = new SimpleLineSymbolClass();
            pSimpleFillSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            pSimpleFillSymbol.Width = 1;

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
                ISimpleLineSymbol pClassSymbol = new SimpleLineSymbol();
                pClassSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
                pClassSymbol.Width = 0.4;

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

                    ICartographicLineSymbol pSimpleFillColor = pUniqueValueRenderer.get_Symbol(xv) as CartographicLineSymbolClass;
                    ICartographicLineSymbol pSimpleFillColor1 = new CartographicLineSymbolClass();
                    pSimpleFillColor1.Color = pEnumColors.Next();
                    ILineProperties lineProp = (ILineProperties)pSimpleFillColor1;
                    lineProp.Offset = 0;
                    ITemplate lineTemplate = new Template();
                    lineTemplate.Interval = 1;
                    lineTemplate.AddPatternElement(1, 0);
                    lineProp.Template = lineTemplate;
                    // Set the basic and cartographic line properties
                    pSimpleFillColor1.Width = 0.4;
                    pSimpleFillColor1.Cap = esriLineCapStyle.esriLCSButt;
                    pSimpleFillColor1.Join = esriLineJoinStyle.esriLJSRound;
                    IRgbColor pColor = new RgbColor();
                    pSimpleFillColor = pSimpleFillColor1;
                    if (xv.Contains("RG") || xv.Contains("RANHGIOI") || xv.Contains("RanhGioi"))
                    {
                        pColor.Red = 0;
                        pColor.Green = 0;
                        pColor.Blue = 255; 
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
                        HC.Red = 0;
                        HC.Green = 0;
                        HC.Blue = 255;
                        cartoLineSymbol.Color = HC;
                        pSimpleFillColor = cartoLineSymbol;
                    }
                    if (xv.Contains("LEDUONG") || xv.Contains("LeDuong") || xv.Contains("leduong"))
                    {
                        pColor.Red = 104;
                        pColor.Green = 104;
                        pColor.Blue = 104;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv.Contains("MUONGTHOATNUOC") || xv.Contains("MuongThoatNuoc") || xv.Contains("muongthoatnuoc"))
                    {
                        pColor.Red = 115;
                        pColor.Green = 255;
                        pColor.Blue = 223;

                        ICartographicLineSymbol cartoLineSymbol = new CartographicLineSymbolClass();
                        ILineProperties lineProp1 = (ILineProperties)cartoLineSymbol;
                        lineProp1.Offset = 0;
                        Template lineTemplate1 = new Template();
                        lineTemplate1.Interval = 1;
                        //lineTemplate1.AddPatternElement(5, 3);
                        //lineProp1.Template = lineTemplate1;

                        cartoLineSymbol.Width = 2;
                        cartoLineSymbol.Cap = esriLineCapStyle.esriLCSButt;
                        cartoLineSymbol.Join = esriLineJoinStyle.esriLJSRound;
                        IRgbColor HC = new RgbColor();
                        HC.Red = 115;
                        HC.Green = 255;
                        HC.Blue = 223;
                        cartoLineSymbol.Color = HC;
                        pSimpleFillColor = cartoLineSymbol;
                    }
                    if (xv.Contains("TIMDUONG") || xv.Contains("TimDuong") || xv.Contains("TIM") || xv.Contains("TimDuong"))
                    {
                        pColor.Red = 104;
                        pColor.Green = 104;
                        pColor.Blue = 104;

                        ICartographicLineSymbol cartoLineSymbol = new CartographicLineSymbolClass();
                        ILineProperties lineProp1 = (ILineProperties)cartoLineSymbol;
                        lineProp1.Offset = 0;
                        Template lineTemplate1 = new Template();
                        lineTemplate1.Interval = 1;
                        lineTemplate1.AddPatternElement(5, 3);
                        lineProp1.Template = lineTemplate1;

                        cartoLineSymbol.Width = 1;
                        cartoLineSymbol.Cap = esriLineCapStyle.esriLCSButt;
                        cartoLineSymbol.Join = esriLineJoinStyle.esriLJSRound;
                        IRgbColor HC = new RgbColor();
                        HC.Red = 104;
                        HC.Green = 104;
                        HC.Blue = 104;
                        cartoLineSymbol.Color = HC;
                        pSimpleFillColor = cartoLineSymbol;
                    }
                    if (xv.Contains("LONGDUONG") || xv.Contains("LongDuong") || xv.Contains("longduong") || xv.Contains("Long duong"))
                    {
                        pColor.Red = 250;
                        pColor.Green = 52;
                        pColor.Blue = 17;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv.Contains("CHIA LO") || xv.Contains("CHIALO") || xv.Contains("chia lo") || xv.Contains("ChiaLo"))
                    {
                        pColor.Red = 255;
                        pColor.Green = 140;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv.Contains("Cay") || xv.Contains("CAY") || xv.Contains("CX") || xv.Contains("thamco") || xv.Contains("CayCo") || xv.Contains("Cay Co") || xv.Contains("co")||xv == "TR")
                    {
                        pColor.Red = 0;
                        pColor.Green = 252;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "CONGTRINH" || xv.Contains("CTCC") || xv.Contains("CTRINH") || xv.Contains("TRINH") || xv.Contains("CONG"))
                    {
                        pColor.Red = 255;
                        pColor.Green = 0;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DGD")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DGT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 50;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DNL")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DRA")
                    {
                        pColor.Red = 205;
                        pColor.Green = 170;
                        pColor.Blue = 205;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DTL")
                    {
                        pColor.Red = 170;
                        pColor.Green = 250;
                        pColor.Blue = 250;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DVH")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DYT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNK")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNQ")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNQ")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LUK")
                    {
                        pColor.Red = 255;
                        pColor.Green = 252;
                        pColor.Blue = 150;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "NTD")
                    {
                        pColor.Red = 210;
                        pColor.Green = 210;
                        pColor.Blue = 210;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "SKC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "SKX")
                    {
                        pColor.Red = 205;
                        pColor.Green = 170;
                        pColor.Blue = 205;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "SON")
                    {
                        pColor.Red = 160;
                        pColor.Green = 255;
                        pColor.Blue = 255;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "TIN")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "TON")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "TSC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "ODT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 160;
                        pColor.Blue = 255;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "QHANQP")
                    {
                        pColor.Red = 38;
                        pColor.Green = 38;
                        pColor.Blue = 19;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHCCDT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 0;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHCN")
                    {
                        pColor.Red = 82;
                        pColor.Green = 0;
                        pColor.Blue = 165;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHCQ")
                    {
                        pColor.Red = 127;
                        pColor.Green = 63;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHCXCD")
                    {
                        pColor.Red = 0;
                        pColor.Green = 127;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHCXCL")
                    {
                        pColor.Red = 0;
                        pColor.Green = 76;
                        pColor.Blue = 57;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHCXDT")
                    {
                        pColor.Red = 82;
                        pColor.Green = 165;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHDL")
                    {
                        pColor.Red = 255;
                        pColor.Green = 0;
                        pColor.Blue = 255;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHDVO")
                    {
                        pColor.Red = 255;
                        pColor.Green = 127;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHMN")
                    {
                        pColor.Red = 0;
                        pColor.Green = 83;
                        pColor.Blue = 165;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHNN")
                    {
                        pColor.Red = 0;
                        pColor.Green = 255;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHNT")
                    {
                        pColor.Red = 101;
                        pColor.Green = 101;
                        pColor.Blue = 101;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHOBT")
                    {
                        pColor.Red = 76;
                        pColor.Green = 76;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHOCC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 191;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHOHH")
                    {
                        pColor.Red = 127;
                        pColor.Green = 95;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QTTG")
                    {
                        pColor.Red = 76;
                        pColor.Green = 0;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHTHCS")
                    {
                        pColor.Red = 127;
                        pColor.Green = 63;
                        pColor.Blue = 63;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHTHPT")
                    {
                        pColor.Red = 127;
                        pColor.Green = 31;
                        pColor.Blue = 0;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHTTYT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 0;
                        pColor.Blue = 191;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
                    }
                    if (xv == "QHXLNT")
                    {
                        pColor.Red = 212;
                        pColor.Green = 170;
                        pColor.Blue = 255;
                        pSimpleFillColor.Color = pColor;
                        pSimpleFillColor.Color.Transparency = 50;
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
            pUniqueValueR = pUniqueValueRenderer;
        }
        public static void DefineUniqueValueRendererPoint(IGeoFeatureLayer pGeoFeatureLayer, string fieldName)
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
            ISimpleMarkerSymbol pSimpleFillSymbol = new SimpleMarkerSymbol();
            pSimpleFillSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            pSimpleFillSymbol.Size = 1;
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
                ISimpleMarkerSymbol pClassSymbol = new SimpleMarkerSymbol();
                pClassSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
                pClassSymbol.Size = 1;

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

                    ISimpleMarkerSymbol pSimpleFillColor = pUniqueValueRenderer.get_Symbol(xv) as ISimpleMarkerSymbol;
                    pSimpleFillColor.Color = pEnumColors.Next();

                    IRgbColor pColor = new RgbColor();


                    if (xv == "RG" || xv == "RANHGIOI")
                    {
                        pColor.Red = 0;
                        pColor.Green = 0;
                        pColor.Blue = 255;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "CAN")
                    {
                        pColor.Red = 255;
                        pColor.Green = 80;
                        pColor.Blue = 70;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "CQP")
                    {
                        pColor.Red = 255;
                        pColor.Green = 100;
                        pColor.Blue = 80;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DBV")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DGD")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DGT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 50;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DNL")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DRA")
                    {
                        pColor.Red = 205;
                        pColor.Green = 170;
                        pColor.Blue = 205;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DTL")
                    {
                        pColor.Red = 170;
                        pColor.Green = 250;
                        pColor.Blue = 250;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DVH")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "DYT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNK")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNQ")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNQ")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LUK")
                    {
                        pColor.Red = 255;
                        pColor.Green = 252;
                        pColor.Blue = 150;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "NTD")
                    {
                        pColor.Red = 210;
                        pColor.Green = 210;
                        pColor.Blue = 210;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "SKC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "SKX")
                    {
                        pColor.Red = 205;
                        pColor.Green = 170;
                        pColor.Blue = 205;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "SON")
                    {
                        pColor.Red = 160;
                        pColor.Green = 255;
                        pColor.Blue = 255;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "TIN")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "TON")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "TSC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 170;
                        pColor.Blue = 160;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "LNC")
                    {
                        pColor.Red = 255;
                        pColor.Green = 215;
                        pColor.Blue = 170;
                        pSimpleFillColor.Color = pColor;
                    }
                    if (xv == "ODT")
                    {
                        pColor.Red = 255;
                        pColor.Green = 160;
                        pColor.Blue = 255;
                        pSimpleFillColor.Color = pColor;
                    }
                    pSimpleFillColor.Size = 5;
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
            pUniqueValueR = pUniqueValueRenderer;
        }
        public static void LabelLayer(IMap pMap, ILayer pLayer, String Field)
        {
            IGeoFeatureLayer pGFLayer;
            pGFLayer = (IGeoFeatureLayer)pLayer;
            //IAnnotateLayerPropertiesCollectionannoLayerPropsColl;
            IAnnotateLayerPropertiesCollection annoLayerPropsColl;
            annoLayerPropsColl = pGFLayer.AnnotationProperties;

            IAnnotateLayerProperties annoLayerProps;
            IElementCollection pElecol1;
            IElementCollection pElecol2;
            annoLayerPropsColl.QueryItem(0, out annoLayerProps, out pElecol1, out pElecol2);
            ILabelEngineLayerProperties labelELayerProps;
            labelELayerProps = (ILabelEngineLayerProperties)annoLayerProps;
            labelELayerProps.IsExpressionSimple = true;
            labelELayerProps.Expression = "[" + Field + "]";
            pGFLayer.DisplayAnnotation = true;
        }
    }
}
