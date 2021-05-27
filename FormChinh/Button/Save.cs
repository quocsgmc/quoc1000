using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace QLHTDT.FormChinh.Button
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("075f5d8d-5f65-4ead-b43c-d2132cebb3b8")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("QLHTDT.FormChinh.Button.Save")]
    public sealed class Save : BaseCommand
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
        private string m_mapDocumentName = string.Empty;
        public Save()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "Quản lý cơ sở dữ liệu"; //localizable text
            base.m_caption = "Lưu";  //localizable text 
            base.m_message = "Lưu bản đồ Mxd";  //localizable text
            base.m_toolTip = "Lưu bản đồ Mxd";  //localizable text
            base.m_name = "Lưu bản đồ Mxd";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".png";
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
        //private IMapDocument m_MapDocument;
        public override void OnClick()
        {
            if (KienTruc.MoAxMap == true)
            {
                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                QLHTDT.FormChinh.KienTruc.CopyToPageLayout();
            }
            //m_MapDocument = new MapDocumentClass();
            KienTruc.axPageLayoutControl1.PageLayout = QLHTDT.FormChinh.Button.MoLop.m_MapDocument.PageLayout;
            if (QLHTDT.FormChinh.Button.MoLop.m_MapDocument.get_IsReadOnly(QLHTDT.FormChinh.Button.MoLop.m_MapDocument.DocumentFilename) == true) 
			{
				MessageBox.Show("Bản đồ này đang được sử dụng");
				return;
			}
			//Save with the current relative path setting
            QLHTDT.FormChinh.Button.MoLop.m_MapDocument.Save(QLHTDT.FormChinh.Button.MoLop.m_MapDocument.UsesRelativePaths, true);
			MessageBox.Show("Lưu bản đồ thành công");

            //m_mapControl = (IMapControl3)KienTruc.axMapControl1.GetOcx();
            //m_mapDocumentName = KienTruc.axMapControl1.DocumentFilename;
            //if (m_mapControl.CheckMxFile(m_mapDocumentName))
            //{
            //    create a new instance of a MapDocument
            //    IMapDocument mapDoc = new MapDocumentClass();
            //    mapDoc.Open(m_mapDocumentName, string.Empty);

            //    Make sure that the MapDocument is not readonly
            //    if (mapDoc.get_IsReadOnly(m_mapDocumentName))
            //    {
            //        MessageBox.Show("Map document is read only!");
            //        mapDoc.Close();
            //        return;
            //    }

            //    Replace its contents with the current map
            //    mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

            //    save the MapDocument in order to persist it
            //    mapDoc.Save(mapDoc.UsesRelativePaths, false);

            //    close the MapDocument
            //    mapDoc.Close();
            //}
        }

        #endregion
    }
}
