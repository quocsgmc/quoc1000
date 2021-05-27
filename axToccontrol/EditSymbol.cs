using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Collections.Generic;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.ArcMapUI;

namespace QLHTDT.FormPhu
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("97775642-6a49-4be0-b3d5-e6d8e10c7ac0")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("QLKSHV.axToccontrol.EditSymbol")]
    public sealed class EditSymbol : BaseCommand
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
        public EditSymbol()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "Chỉnh sửa biểu tượng"; //localizable text
            base.m_caption = "Chỉnh sửa biểu tượng";  //localizable text 
            base.m_message = "This should work in ArcMap/MapControl/PageLayoutControl";  //localizable text
            base.m_toolTip = "Chỉnh sửa biểu tượng";  //localizable text
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

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
            //Exit if not right mouse button
            ILayer layer = new FeatureLayerClass();
            ESRI.ArcGIS.Geodatabase.IFeature a = QLHTDT.FormChinh.QuanTriHeThong.layer as ESRI.ArcGIS.Geodatabase.IFeature;
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            featureLayer = QLHTDT.FormChinh.QuanTriHeThong.featureLayer;
            //QI to IFeatureLayer and IGeoFeatuerLayer interface
            IGeoFeatureLayer geoFeatureLayer = (IGeoFeatureLayer)featureLayer;
            //QLHTDT.Global.DefineUniqueValueRenderer(geoFeatureLayer, "LoaiDat");
            IFeatureRenderer simpleRenderer = (IFeatureRenderer)geoFeatureLayer.Renderer;
            
            //Create the form with the SymbologyControl
            QLHTDT.SymbolForm symbolForm = new QLHTDT.SymbolForm();

            //Get the IStyleGalleryItem
            IStyleGalleryItem styleGalleryItem = null;
            //Select SymbologyStyleClass based upon feature type
            switch (QLHTDT.FormChinh.QuanTriHeThong.featureLayer.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassMarkerSymbols, simpleRenderer.get_SymbolByFeature(a));
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassLineSymbols, simpleRenderer.get_SymbolByFeature(a));
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassFillSymbols, simpleRenderer.get_SymbolByFeature(a));
                    break;
            }

            //Release the form
            symbolForm.Dispose();
            QLHTDT.FormChinh.QuanTriHeThong.ActiveForm.Activate();
           
            if (styleGalleryItem == null) return;

            //Create a new renderer
            simpleRenderer = new SimpleRendererClass();
            //Set its symbol from the styleGalleryItem
            //simpleRenderer.get_SymbolByFeature(a) = (ISymbol)styleGalleryItem.Item;
            //Set the renderer into the geoFeatureLayer
            geoFeatureLayer.Renderer = (IFeatureRenderer)simpleRenderer;
            QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.ActiveView.ContentsChanged();
            //Refresh the display
            QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
            //Fire contents changed event that the TOCControl listens to
            QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView.ContentsChanged();
            //Refresh the display
            QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
            
        }

        #endregion
    }
}
