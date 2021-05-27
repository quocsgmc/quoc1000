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
using System;

namespace QLHTDT.FormPhu.QLyHaTang
    {
        /// <summary>
        /// Summary description for CapNhatCayXanh.
        /// </summary>
        [Guid("c943ff5c-769a-4ab2-afac-6b7f1e2a5db8")]
        [ClassInterface(ClassInterfaceType.None)]
        [ProgId("QLHTDT.FormPhu.QLyHaTang.CapNhatCayXanh")]
        public sealed class CapNhatCayXanh : BaseTool
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

            public CapNhatCayXanh()
            {
                //
                // TODO: Define values for the public properties
                //
                base.m_category = "Tra cứu"; //localizable text 
                base.m_caption = "Truy vấn không gian";  //localizable text 
                base.m_message = "tra cứu thông tin theo vùng trên bản đồ";  //localizable text
                base.m_toolTip = "Truy vấn không gian";  //localizable text
                base.m_name = "Truy vấn không gian";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
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
                frm = new TestCapNhatCayXanh();
                frm.Show();
                tenlop = TestCapNhatCayXanh.CayXanh;

            }

            public override void OnMouseDown(int Button, int Shift, int X, int Y)
            {

                // TODO:  Add CapNhatCayXanh.OnMouseDown implementation
                IActiveView pActiveView;
                pActiveView = QuanTriHeThong.axMapControl1.ActiveView;
                Global.pActiveView = pActiveView;
                IRubberBand pRubberBand;
                pRubberBand = new RubberPoint();
                IPoint pPoint = (IPoint)pRubberBand.TrackNew(pActiveView.ScreenDisplay, null);
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

                IFeatureLayer ilayer;
                pLayer = Global.getLayerbyName(Global.pActiveView.FocusMap, TestCapNhatCayXanh.CayXanh);
                if (pLayer == null)
                {
                    MessageBox.Show("Chưa chọn lớp hoặc mở lớp cần truy vấn", "Thông báo");

                    frm.BringToFront();
                }
                else if (pLayer.Name == "Đường giao thông chính")
                {
                    for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
                    {


                        if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == "Đường giao thông chính")
                        {
                            ICompositeLayer igroup = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.Layer[i] as ICompositeLayer;

                            for (int j = 0; j < igroup.Count; j++)
                            {

                                ilayer = igroup.Layer[j] as IFeatureLayer;
                                if (ilayer.Name == "Đường giao thông chính")
                                {
                                    pLayer = ilayer;
                                }
                                // Do whatever you need.

                            }

                        }

                    }
                }
                else if (pLayer.Name == "Ranh giới khu quy hoạch")
                {
                    for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
                    {


                        if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == "Ranh giới khu quy hoạch")
                        {
                            ICompositeLayer igroup = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.Layer[i] as ICompositeLayer;

                            for (int j = 0; j < igroup.Count; j++)
                            {

                                ilayer = igroup.Layer[j] as IFeatureLayer;
                                if (ilayer.Name == "Ranh giới quy hoạch")
                                {
                                    pLayer = ilayer;
                                }
                                // Do whatever you need.

                            }

                        }

                    }
                }
            //else if (pLayer.Name == "Cây xanh - HA")
            //{
            //    for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
            //    {


            //        if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == "Cây xanh - HA")
            //        {
            //            ICompositeLayer igroup = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.Layer[i] as ICompositeLayer;

            //            for (int j = 0; j < igroup.Count; j++)
            //            {

            //                ilayer = igroup.Layer[j] as IFeatureLayer;
            //                if (ilayer.Name == "Cây xanh - HA")
            //                {
            //                    pLayer = ilayer;
            //                }
            //                // Do whatever you need.

            //            }

            //        }

            //    }
            //}
            else
                {
                    dLayer = pLayer;

                }
                pFlayer = (IFeatureLayer)pLayer;
                if (pFlayer != null)
                {
                    pFCLass = pFlayer.FeatureClass;
                    pQuery = new SpatialFilter();
                    pQuery.Geometry = pPoint;
                    //Trong sách thiếu dòng này, giúp chọn 6 thửa ra 6 thửa
                    pQuery.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;

                    pCursor = pFCLass.Search(pQuery, true);//sửa lại true xem thử thế nào
                    /*
                     * Bỏ thằng này, vì có nó mình kéo 6 thửa chỉ ra 5 thửa
                       pFeature = pCursor.NextFeature();
                     */
                    pActiveView.Refresh();
                    frm.Visible = true;
                    frm.BringToFront();
                    if (TestQLCayXanh.CayXanh == "Cây xanh - HA")
                    {
                        TestCapNhatCayXanh frm = new TestCapNhatCayXanh();
                        frm.Show(pCursor, pFlayer);
                }
                   

                }
                //else if (pFlayer != null)
                //{
                //    for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
                //    {


                //        if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == "Đường giao thông chính")
                //        {
                //            ICompositeLayer igroup = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.Layer[i] as ICompositeLayer;

                //            for (int j = 0; j < igroup.Count; j++)
                //            {
                //                IFeatureLayer ilayer = igroup.Layer[j] as IFeatureLayer;
                //                if (ilayer.Name == "Đường giao thông chính")
                //                {
                //                    pFCLass = ilayer.FeatureClass;
                //                    pQuery = new SpatialFilter();
                //                    pQuery.Geometry = pPoly;
                //                    //Trong sách thiếu dòng này, giúp chọn 6 thửa ra 6 thửa
                //                    pQuery.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;

                //                    pCursor = pFCLass.Search(pQuery, false);
                //                    frm.BringToFront();
                //                    if (ChonLopTruyVanKGcs.TenLop == "Đường giao thông chính")
                //                    {
                //                        FrmGTChinh frm2 = new FrmGTChinh();
                //                        frm2.Show(pCursor);

                //                    }
                //                }
                //            }
                //        }
                //        if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == "Ranh giới khu quy hoạch")
                //        {
                //            ICompositeLayer igroup = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.Layer[i] as ICompositeLayer;

                //            for (int j = 0; j < igroup.Count; j++)
                //            {
                //                IFeatureLayer ilayer = igroup.Layer[j] as IFeatureLayer;
                //                if (ilayer.Name == "Ranh giới quy hoạch")
                //                {
                //                    pFCLass = ilayer.FeatureClass;
                //                    pQuery = new SpatialFilter();
                //                    pQuery.Geometry = pPoly;
                //                    //Trong sách thiếu dòng này, giúp chọn 6 thửa ra 6 thửa
                //                    pQuery.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;

                //                    pCursor = pFCLass.Search(pQuery, false);
                //                    frm.BringToFront();
                //                    if (ChonLopTruyVanKGcs.TenLop == "Ranh giới quy hoạch")
                //                    {
                //                        FrmThuaDat frm2 = new FrmThuaDat();
                //                        frm2.Show(pCursor);

                //                    }
                //                }
                //            }
                //        }
                //    }
                //}


            }

            public override void OnMouseMove(int Button, int Shift, int X, int Y)
            {
                // TODO:  Add TruyVanKhongGian.OnMouseMove implementation
            }

            public override void OnMouseUp(int Button, int Shift, int X, int Y)
            {
                // TODO:  Add TruyVanKhongGian.OnMouseUp implementation
            }

            #endregion
        }
    }
