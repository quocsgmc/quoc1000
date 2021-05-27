using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using System.Collections.Generic;

namespace QLHTDT.axToccontrol
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("0a37f812-a769-4975-9720-5f037a23fbae")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("QLHTDT.axToccontrol.Command1")]
    public sealed class Command1 : BaseCommand
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
        public Command1()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text
            base.m_caption = "";  //localizable text 
            base.m_message = "This should work in ArcMap/MapControl/PageLayoutControl";  //localizable text
            base.m_toolTip = "";  //localizable text
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
            const string CodeField = "SMUcode";
            const string DescriptionField = "SMUdetails";

            IGeoFeatureLayer layer = QLHTDT.FormChinh.QuanTriHeThong.layer as IGeoFeatureLayer;
            IUniqueValueRenderer renderer = layer.Renderer as IUniqueValueRenderer;
            IDisplayTable table = layer as IDisplayTable;
            IFeatureCursor cursor = table.SearchDisplayTable(null, false) as IFeatureCursor;
            int indexCodeField = cursor.Fields.FindField(CodeField);
            int indexDescriptionField = cursor.Fields.FindField(DescriptionField);
            //loop through each feature creating a dictionary mapping codes to descriptions
            //code and descriptions should match 1 for 1, but if not, the last description
            //for a code value will be used.
            var descriptions = new Dictionary<string, string>();
            IFeature feature = cursor.NextFeature();
            //while (feature != null)
            //{
            //    string code = feature.Value[indexCodeField] as string;
            //    string description = feature.Value[indexDescriptionField] as string;
            //    descriptions[code] = description;
            //    feature = cursor.NextFeature();
            //}

            //loop through the renderer changing each value
            //Assumes descriptions are unique
            renderer.Field[0] = DescriptionField;
            for (int i = 0; i < renderer.ValueCount; i++)
            {
                string code = renderer.Value[i];
                // change the label
                renderer.Label[code] = descriptions[code];
                //Change the value of the renderer item.  
                renderer.Value[i] = descriptions[code];
            }
        }

        #endregion
    }
}
