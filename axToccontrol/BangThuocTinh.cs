using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;

namespace QLHTDT.FormPhu
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("0bd27b6d-effd-4b03-8b14-7ec434c360f3")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("QLKSHV.axToccontrol.Bảng_thuộc_tính")]
    public sealed class BangThuocTinh : BaseCommand
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
        public BangThuocTinh()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "Mở bảng thuộc tính"; //localizable text
            base.m_caption = "Mở bảng thuộc tính";  //localizable text 
            base.m_message = "Mở bảng thuộc tính đối tượng";  //localizable text
            base.m_toolTip = "Mở bảng thuộc tính";  //localizable text
            base.m_name = "Mở bảng thuộc tính";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

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
        ///
        public static string FormChinh = "";
        public override void OnClick()
        {
            if (QLHTDT.FormChinh.KienTruc.featureLayer != null)
            {
                QLHTDT.axToccontrol.Table.BangThuocTinh frm = new QLHTDT.axToccontrol.Table.BangThuocTinh();
                FormChinh = "KienTruc";
                frm.Show();
            }
            if (QLHTDT.FormChinh.QuanTriHeThong.featureLayer != null)
            {
                QLHTDT.axToccontrol.Table.BangThuocTinh frm = new QLHTDT.axToccontrol.Table.BangThuocTinh();
                FormChinh = "QuanTriHeThong";
                frm.Show();
            }
            // TODO: Add Bảng_thuộc_tính.OnClick implementation

        }

        #endregion
    }
}
