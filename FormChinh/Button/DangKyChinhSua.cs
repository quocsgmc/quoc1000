using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace QLHTDT.FormChinh.Button
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("255275e7-d487-4906-a911-827781322fbb")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("QLHTDT.FormChinh.Button.DangKyChinhSua")]
    public sealed class DangKyChinhSua : BaseCommand
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
        public DangKyChinhSua()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "Tool chỉnh sửa"; //localizable text
            base.m_caption = "Đăng ký lớp chỉnh sửa";  //localizable text 
            base.m_message = "Đăng ký lớp layer cần chỉnh sửa";  //localizable text
            base.m_toolTip = "Đăng ký chỉnh sửa";  //localizable text
            base.m_name = "Đăng ký chỉnh sửa";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

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
            //KienTruc.ActiveForm.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            //QLHTDT.FormChinh.KienTruc.operationStack.Undo();
            ILayer L = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(0);
            IFeatureLayer ftLayer = L as IFeatureLayer;
            IFeatureClass ftClass = ftLayer.FeatureClass;
            QLHTDT.FormChinh.KienTruc.DangKyChinhSua(ftClass.FeatureDataset);


            //ILayer pLayer = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(0); //获取图层
            //IFeatureLayer pFLayer = pLayer as IFeatureLayer; //转换为矢量图层
            //IFeatureClass pFClass = pFLayer.FeatureClass; //获取图层表格值
            //QLHTDT.FormChinh.KienTruc.DangKyChinhSua(pFClass.FeatureDataset);
            ////KienTruc.ActiveForm.Cursor = System.Windows.Forms.Cursors.Default;
        }

        #endregion
    }
}
