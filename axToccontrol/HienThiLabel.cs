using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

namespace QLHTDT.FormPhu
{

    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("a73fece9-cc65-4456-abb7-52e11823868e")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("QLKSHV.axToccontrol.Hiển_thị_nhãn")]
    public sealed class HienThiLabel : BaseCommand
    {
        
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Register(regKey);
            ControlsCommands.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);
            ControlsCommands.Unregister(regKey);
        }

        #endregion
        #endregion

        private IHookHelper m_hookHelper = null;
        public HienThiLabel()
        {

            //
            // TODO: Define values for the public properties
            //
            base.m_category = "Hiển thị nhãn"; //localizable text
            base.m_caption = "Hiển thị nhãn";  //localizable text 
            base.m_message = "Hiển thị thông tin thuộc tính theo trường lên bản đồ";  //localizable text
            base.m_toolTip = "Hiển thị nhãn";  //localizable text
            base.m_name = "Hiển thị nhãn";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                    m_hookHelper = null;
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add Hiển_thị_nhãn.OnClick implementation
            QLHTDT.axToccontrol.Label frm = new QLHTDT.axToccontrol.Label();
            //frm.show();
            frm.Show();
            
        }
        ////public void annotateLayer(ILayer thisLayer, String geocode, double minScale, double maxScale, bool annotationsOn, bool showMapTips, RgbColor annotationLabelColor)
        ////{
        ////    IGeoFeatureLayer geoLayer = thisLayer as IGeoFeatureLayer;
        ////    if (geoLayer != null)
        ////    {
        ////        geoLayer.DisplayAnnotation = annotationsOn;
        ////        IAnnotateLayerPropertiesCollection propertiesColl = geoLayer.AnnotationProperties;
        ////        IAnnotateLayerProperties labelEngineProperties = new LabelEngineLayerProperties() as IAnnotateLayerProperties;
        ////        IElementCollection placedElements = new ElementCollectionClass();
        ////        IElementCollection unplacedElements = new ElementCollectionClass();
        ////        propertiesColl.QueryItem(0, out labelEngineProperties, out placedElements, out unplacedElements);
        ////        ILabelEngineLayerProperties lpLabelEngine = labelEngineProperties as ILabelEngineLayerProperties;
        ////        lpLabelEngine.Expression = geocode;
        ////        lpLabelEngine.Symbol.Color = annotationLabelColor;
        ////        labelEngineProperties.AnnotationMinimumScale = minScale;
        ////        labelEngineProperties.AnnotationMaximumScale = maxScale;
        ////        IFeatureLayer thisFeatureLayer = thisLayer as IFeatureLayer;
        ////        IDisplayString displayString = thisFeatureLayer as IDisplayString;
        ////        IDisplayExpressionProperties properties = displayString.ExpressionProperties;
        ////        properties.Expression = geocode; //example: "[OWNER_NAME] & vbnewline & \"$\" & [TAX_VALUE]";
        ////        thisFeatureLayer.ShowTips = showMapTips;
        ////    }
        ////}

        public IFeatureClass IFeatureWorkspaceAnno_Example(IFeatureClass featureClass)
        {
            
            IDataset dataset = (IDataset)featureClass;
            //cast for the feature workspace from the workspace
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)dataset.Workspace;
            IFeatureWorkspaceAnno featureWorkspaceAnno = (IFeatureWorkspaceAnno)dataset.Workspace;
            //set up the reference scale
            ESRI.ArcGIS.Carto.IGraphicsLayerScale graphicLayerScale = new ESRI.ArcGIS.Carto.GraphicsLayerScaleClass();
            IGeoDataset geoDataset = (IGeoDataset)dataset;
            graphicLayerScale.Units = ESRI.ArcGIS.esriSystem.esriUnits.esriFeet;
            graphicLayerScale.ReferenceScale = 2000;
            //set up symbol collection
            ESRI.ArcGIS.Display.ISymbolCollection symbolCollection = new ESRI.ArcGIS.Display.SymbolCollectionClass();


            #region "MakeText"
            ESRI.ArcGIS.Display.IFormattedTextSymbol myTextSymbol = new ESRI.ArcGIS.Display.TextSymbolClass();
            //set the font for myTextSymbol
            stdole.IFontDisp myFont = new stdole.StdFont() as stdole.IFontDisp;
            myFont.Name = "Courier New";
            myFont.Size = 9;
            myTextSymbol.Font = myFont;
            //set the Color for myTextSymbol to be Dark Red
            ESRI.ArcGIS.Display.IRgbColor rgbColor = new ESRI.ArcGIS.Display.RgbColorClass();
            rgbColor.Red = 150;
            rgbColor.Green = 0;
            rgbColor.Blue = 0;
            myTextSymbol.Color = (ESRI.ArcGIS.Display.IColor)rgbColor;
            //Set other properties for myTextSymbol
            myTextSymbol.Angle = 0;
            myTextSymbol.RightToLeft = false;
            myTextSymbol.VerticalAlignment = ESRI.ArcGIS.Display.esriTextVerticalAlignment.esriTVABaseline;
            myTextSymbol.HorizontalAlignment = ESRI.ArcGIS.Display.esriTextHorizontalAlignment.esriTHAFull;
            myTextSymbol.CharacterSpacing = 200;
            myTextSymbol.Case = ESRI.ArcGIS.Display.esriTextCase.esriTCNormal;
            #endregion


            symbolCollection.set_Symbol(0, (ESRI.ArcGIS.Display.ISymbol)myTextSymbol);
            //set up the annotation labeling properties including the expression
            ESRI.ArcGIS.Carto.IAnnotateLayerProperties annoProps = new ESRI.ArcGIS.Carto.LabelEngineLayerPropertiesClass();
            annoProps.FeatureLinked = true;
            annoProps.AddUnplacedToGraphicsContainer = false;
            annoProps.CreateUnplacedElements = true;
            annoProps.DisplayAnnotation = true;
            annoProps.UseOutput = true;


            ESRI.ArcGIS.Carto.ILabelEngineLayerProperties layerEngineLayerProps = (ESRI.ArcGIS.Carto.ILabelEngineLayerProperties)annoProps;
            ESRI.ArcGIS.Carto.IAnnotationExpressionEngine annoExpressionEngine = new ESRI.ArcGIS.Carto.AnnotationVBScriptEngineClass();
            layerEngineLayerProps.ExpressionParser = annoExpressionEngine;
            layerEngineLayerProps.Expression = "[DESCRIPTION]";
            layerEngineLayerProps.IsExpressionSimple = true;
            layerEngineLayerProps.Offset = 0;
            layerEngineLayerProps.SymbolID = 0;
            layerEngineLayerProps.Symbol = myTextSymbol;


            ESRI.ArcGIS.Carto.IAnnotateLayerTransformationProperties annoLayerTransProp = (ESRI.ArcGIS.Carto.IAnnotateLayerTransformationProperties)annoProps;
            annoLayerTransProp.ReferenceScale = graphicLayerScale.ReferenceScale;
            annoLayerTransProp.Units = graphicLayerScale.Units;
            annoLayerTransProp.ScaleRatio = 1;


            ESRI.ArcGIS.Carto.IAnnotateLayerPropertiesCollection annoPropsColl = new ESRI.ArcGIS.Carto.AnnotateLayerPropertiesCollectionClass();
            annoPropsColl.Add(annoProps);
            //use the AnnotationFeatureClassDescription to get the list of required
            //fields and the default name of the shape field
            IObjectClassDescription oCDesc = new ESRI.ArcGIS.Carto.AnnotationFeatureClassDescriptionClass();
            IFeatureClassDescription fCDesc = (IFeatureClassDescription)oCDesc;

            //create the new class
            return featureWorkspaceAnno.CreateAnnotationClass("AnnoTest", oCDesc.RequiredFields, oCDesc.InstanceCLSID, oCDesc.ClassExtensionCLSID,
                fCDesc.ShapeFieldName, "", featureClass.FeatureDataset, featureClass,
                annoPropsColl, graphicLayerScale, symbolCollection, true);
        }
        #endregion
    }
}
