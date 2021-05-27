using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Catalog;

namespace QLHTDT.test
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("ec712a33-6032-4733-b8e3-d4c779a45bf0")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("QLHTDT.test.Command1")]
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
        #region Member Variables
        private GxSelection m_pSelection;
        private FrmTextView frmTextView = new FrmTextView();
        #endregion

        private void OnSelectionChanged(IGxSelection Selection, ref object initiator)
        {
            //Refresh view
            Refresh();
        }
        #region IGxView Implementations
        public void Activate(ESRI.ArcGIS.CatalogUI.IGxApplication Application, ESRI.ArcGIS.Catalog.IGxCatalog Catalog)
        {
            m_pSelection = (GxSelection)Application.Selection;
            m_pSelection.OnSelectionChanged += new IGxSelectionEvents_OnSelectionChangedEventHandler(OnSelectionChanged);
            Refresh();
        }

        public bool Applies(ESRI.ArcGIS.Catalog.IGxObject Selection)
        {
            //Set applies
            return (Selection != null) & (Selection is IGxTextFile);
        }

        public ESRI.ArcGIS.esriSystem.UID ClassID
        {
            get
            {
                //Set class ID
                UID pUID = new UID();
                pUID.Value = "TextTab2008_CS.TextView";
                return pUID;
            }
        }

        public void Deactivate()
        {
            //Prevent circular reference
            if (m_pSelection != null)
                m_pSelection = null;
        }

        public ESRI.ArcGIS.esriSystem.UID DefaultToolbarCLSID
        {
            get
            {
                return null;
            }
        }

        public void Refresh()
        {
            IGxSelection pGxSelection = null;
            IGxObject pLocation = null;
            pGxSelection = m_pSelection;
            pLocation = pGxSelection.Location;

            //Clean up
            frmTextView.txtContents.Clear();

            string fname = null;
            fname = pLocation.Name.ToLower();

            if (fname.IndexOf(".txt") != -1)
            {
                try
                {
                    frmTextView.txtContents.Text = System.IO.File.ReadAllText(pLocation.FullName);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
                finally
                {
                    pGxSelection = null;
                    pLocation = null;
                }
            }
        }

        public bool SupportsTools
        {
            get
            {
                return false;
            }
        }

        public void SystemSettingChanged(int flag, string section)
        {
            // TODO: Add TextView.SystemSettingChanged implementation
        }

        public int hWnd
        {
            get
            {
                int temphWnd = 0;
                try
                {
                    //Set view handle to be the control handle
                    temphWnd = frmTextView.txtContents.Handle.ToInt32();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
                return temphWnd;
            }
        }
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
            
        }


        #endregion
    }
}
