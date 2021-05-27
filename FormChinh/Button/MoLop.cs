using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace QLHTDT.FormChinh.Button
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("a14d234b-9db4-4cd0-b2f1-cb53d0e913ca")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("QLHTDT.FormChinh.Button.MoLop")]
    public sealed class MoLop : BaseCommand
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

        public static IMapDocument m_MapDocument;
        private IHookHelper m_hookHelper = null;
        public MoLop()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "Quản lý cơ sở dữ liệu"; //localizable text
            base.m_caption = "Mở bản đồ";  //localizable text 
            base.m_message = "Mở bản đồ";  //localizable text
            base.m_toolTip = "Mở bản đồ Mxd";  //localizable text
            base.m_name = "Mở bản đồ Mxd";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

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
            //Stream myStream;

            ////create an open file dialog
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            ////set the file extension filter, filter index and restore directory flag
            //openFileDialog1.Filter = "template files (*.mxt)|*.mxt|mxd files (*.mxd)|*.mxd";
            //openFileDialog1.FilterIndex = 2;
            //openFileDialog1.RestoreDirectory = true;

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    //check if a file was selected
            //    if ((myStream = openFileDialog1.OpenFile()) != null)
            //    {
            //        //get the selected filename and path
            //        string fileName = openFileDialog1.FileName;

            //        //check if selected file is mxd file
            //        if ( KienTruc.axMapControl1.CheckMxFile(fileName) == true)
            //        {
            //            //load the mxd file into PageLayout	control
            //            KienTruc.axMapControl1.LoadMxFile(fileName);
            //            KienTruc.axPageLayoutControl1.LoadMxFile(fileName);
            //        }
            //    }
            //}
            //Open a file dialog for opening map documents
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Open Map Document";
            openFileDialog1.Filter = "Map Documents (*.mxd)|*.mxd";
            openFileDialog1.ShowDialog();

            // Exit if no map document is selected
            string sFilePath = openFileDialog1.FileName;
            if (sFilePath == "")
            {
                return;
            }

            //Open document
            OpenDocument((sFilePath));
            QLHTDT.FormChinh.KienTruc.axPageLayoutControl1.DocumentFilename = m_MapDocument.DocumentFilename;
            QLHTDT.FormChinh.KienTruc.axPageLayoutControl1.Refresh();
            QLHTDT.FormChinh.KienTruc.CopyToMap();
        }
        private void OpenDocument(string sFilePath)
        {
            if (m_MapDocument != null) m_MapDocument.Close();

            //Create a new map document
            m_MapDocument = new MapDocumentClass();
            //Open the map document selected
            m_MapDocument.Open(sFilePath, "");
            //Set the PageLayoutControl page layout to the map document page layout

            QLHTDT.FormChinh.KienTruc.axPageLayoutControl1.PageLayout = m_MapDocument.PageLayout;
            //txtMapDocument.Text = m_MapDocument.DocumentFilename;
        }
        #endregion
    }
}
