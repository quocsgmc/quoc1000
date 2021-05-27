using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using QLHTDT.FormChinh;
using QLHTDT.FormPhu.TruyVanKG;

namespace QLHTDT.FormPhu.FormChiTietLayer
{
    /// <summary>
    /// Summary description for ChiTietLayer.
    /// </summary>
    [Guid("c943ff5c-769a-4ab2-afac-6b7f1e2a5db8")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("QLHTDT.FormPhu.FormChiTietLayer.ChiTietLayer")]
    public sealed class ChiTietLayer : BaseTool
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

        public ChiTietLayer()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "Tra cứu"; //localizable text 
            base.m_caption = "Tra cứu thông tin chi tiết";  //localizable text 
            base.m_message = "Tra cứu thông tin theo vùng trên bản đồ";  //localizable text
            base.m_toolTip = "Tra cứu thông tin chi tiết";  //localizable text
            base.m_name = "Tra cứu thông tin chi tiết";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
            try
            {
                //
                // TODO: change resource name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                {
                    m_hookHelper = null;
                }
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
        /// Occurs when this tool is clicked
        /// </summary>
        public string tenlop;
        public Form frm;
        public override void OnClick()
        {
            frm = new ChonLopLayer();
            frm.Show();
            tenlop = ChonLopLayer.TenLop;

        }
        public static QLHTDT.FormPhu.FormChiTietLayer.ChiTietMBQH.ChiTietMBQH frmMBQH;
        public static QLHTDT.FormPhu.FormChiTietLayer.QLDAQH frmQLDA;
        public static QLHTDT.FormPhu.FormChiTietLayer.ChiTietDAQH_PK frnQLDAPK;
        public static QLHTDT.FormPhu.FormChiTietLayer.QuanLyGiaoThongChinh2 frmGiaoThong;
        public static QLHTDT.FormPhu.FormChiTietLayer.QuanLyKietHem2 frmKietHem;
        public static QLHTDT.FormPhu.FormChiTietLayer.ChiTietMuongThoatNuoc frmMuongThoatNuoc;
        public static QLHTDT.FormPhu.FormChiTietLayer.ChiTietMuongThoatNuoc_DC frmMuongThoatNuoc_DC;
        public static QLHTDT.FormPhu.FormChiTietLayer.ChiTietTruDienCS frmTruDienCS_KH;
        public static QLHTDT.FormPhu.FormChiTietLayer.ChiTietTruDienCS_DC frmTruDienCSDC_KH;
        public static QLHTDT.FormPhu.FormChiTietLayer.ChiTietTuyenDienChieuSang frm2TuyenDienCS_KH;
        public static QLHTDT.FormPhu.FormChiTietLayer.ChiTietTuyenDienChieuSang_DC frm2TuyenDienCSDC_KH;
        public static QLHTDT.FormPhu.FormChiTietLayer.ChiTietCayXanh.QuanLyCayXanh frmCayXanh;
        public static QLHTDT.FormPhu.FormChiTietLayer.ChiTietTramBTS.QuanLyTramBTS frmTramBTS;
        public static QLHTDT.FormPhu.FormChiTietLayer.ChiTietDaiLyInternet.QuanLyDaiLyInternet2 frmDaiLyInternet;
        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {

            // TODO:  Add ChiTietLayer.OnMouseDown implementation
            IActiveView pActiveView;
            pActiveView = KienTruc.axMapControl1.ActiveView;
            Global.pActiveView = pActiveView;
            IRubberBand pRubberBand;
            pRubberBand = new RubberRectangularPolygon();
            IPolycurve pPoint = (IPolycurve)pRubberBand.TrackNew(pActiveView.ScreenDisplay, null);
            /*
             * Sửa chữ true thành chữ để sáng hết thửa đất mình chọn nếu không nó chỉ sáng 1 thửa
                pActiveView.FocusMap.SelectByShape(pPoly, null, true);
             */

            pActiveView.FocusMap.SelectByShape(pPoint, null, false);

            ILayer dLayer;
            ILayer pLayer;
            IFeatureLayer pFlayer;
            IFeatureClass pFCLass;
            IFeatureCursor pCursor;
            ISpatialFilter pQuery;

            pLayer = Global.getLayerbyName(Global.pActiveView.FocusMap, ChonLopLayer.TenLop);
            if (pLayer == null)
            {
                MessageBox.Show("Chưa chọn lớp hoặc mở lớp cần truy vấn", "Thông báo");
                frm.BringToFront();
            }
            else
            {
                dLayer = pLayer;
            }
            pFlayer = (IFeatureLayer)pLayer;
            if (pFlayer != null)
            {
                pFCLass = pFlayer.FeatureClass;
                pQuery = new SpatialFilter();
                //pQuery.Geometry = pPoly;
                pQuery.Geometry = pPoint;
                //Trong sách thiếu dòng này, giúp chọn 6 thửa ra 6 thửa
                pQuery.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                pCursor = pFCLass.Search(pQuery, false);
                /*
                 * Bỏ thằng này, vì có nó mình kéo 6 thửa chỉ ra 5 thửa
                   pFeature = pCursor.NextFeature();
                 */
                pActiveView.Refresh();
                frm.Visible = true;
                frm.BringToFront();
                if (ChonLopLayer.TenLop == "Địa chính")
                {
                    //FrmThuaDat frm2 = new FrmThuaDat();
                    //frm2.Show(pCursor);
                }
                else if (ChonLopLayer.TenLop == "Ranh giới quy hoạch chi tiết")
                {
                    if (frmQLDA != null)
                    {
                        frmQLDA.Close();
                        frmQLDA = new QLHTDT.FormPhu.FormChiTietLayer.QLDAQH();
                        frmQLDA.Show(pCursor);
                    }
                    else
                    {
                        frmQLDA = new QLHTDT.FormPhu.FormChiTietLayer.QLDAQH();
                        frmQLDA.Show(pCursor);
                    }
                    try
                    {
                        if (frmQLDA != null)
                        {
                            frnQLDAPK.Close();
                            frnQLDAPK = new QLHTDT.FormPhu.FormChiTietLayer.ChiTietDAQH_PK();
                            frnQLDAPK.Show(pCursor);
                        }
                        else
                        {
                            frnQLDAPK = new QLHTDT.FormPhu.FormChiTietLayer.ChiTietDAQH_PK();
                            frnQLDAPK.Show(pCursor);
                        }
                    }
                    catch { }


                }
                else if (ChonLopLayer.TenLop == "Ranh giới quy hoạch phân khu")
                {
                    if (frmQLDA != null)
                    {
                        try
                        {
                            frnQLDAPK.Close();
                            frnQLDAPK = new QLHTDT.FormPhu.FormChiTietLayer.ChiTietDAQH_PK();
                            frnQLDAPK.Show(pCursor);
                        }
                        catch
                        {
                            frnQLDAPK = new QLHTDT.FormPhu.FormChiTietLayer.ChiTietDAQH_PK();
                            frnQLDAPK.Show(pCursor);
                        }
                    }
                    else
                    {
                        frnQLDAPK = new QLHTDT.FormPhu.FormChiTietLayer.ChiTietDAQH_PK();
                        frnQLDAPK.Show(pCursor);
                    }
                    try
                    {
                        if (frmQLDA != null)
                        {
                            frmQLDA.Close();
                            frmQLDA = new QLHTDT.FormPhu.FormChiTietLayer.QLDAQH();
                            frmQLDA.Show(pCursor);
                        }
                        else
                        {
                            frmQLDA = new QLHTDT.FormPhu.FormChiTietLayer.QLDAQH();
                            frmQLDA.Show(pCursor);
                        }
                    }
                    catch { }
                }

            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ChiTietLayer.OnMouseMove implementation
        }
         
        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ChiTietLayer.OnMouseUp implementation
        }
    
        #endregion
    }
}
