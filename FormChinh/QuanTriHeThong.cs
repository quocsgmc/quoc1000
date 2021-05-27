using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using QLHTDT.FormPhu;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Editor;
using System.Threading;
using DevExpress.XtraTreeList;
using QLHTDT.Properties;
using ESRI.ArcGIS.DataSourcesRaster;
using System.Diagnostics;
using System.Text;
using QLHTDT.FormPhu.CapNhatQuyDat;
//using Newtonsoft.Json;

namespace QLHTDT.FormChinh
{
    public partial class QuanTriHeThong : Form
    {
        #region class private members
        private IMapControl3 m_mapControl;
        private AxMapControl mMapControl;
        private ITOCControl2 m_tocControl;
        private IToolbarMenu m_menuMap;
        public IMap pMap;
        public string m_mapDocumentName = string.Empty;
        private ESRI.ArcGIS.Carto.IMap dmap;
        private IToolbarMenu m_menuLayer;
        public static ILayer layer;
        public static IFeatureLayer featureLayer;
        //private static List<WeakReference> __ENCList = new List<WeakReference>();
        //[AccessedThroughProperty("GooglemapFrm")]
        public string filePath1;
        //private IEditor m_editor;
        //private IEditEvents_Event m_editEvents;
        public static ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl2;
        public static ILayer layeredit;
        public static QLHTDT.FormPhu.FormChiTietLayer.TTTD frm1Thua;
        public static QLHTDT.FormPhu.FormChiTietLayer.FrmThuaDat2 frmNhieuThua;
        string tableKT = "";
        #endregion
        #region class constructor
        QLHTDT.FormPhu.QTHT.FrmLoading frmloading = new QLHTDT.FormPhu.QTHT.FrmLoading();
        public QuanTriHeThong(AxMapControl mapControl)
        {
            //Thread t = new Thread(new ThreadStart(Loading));
            //t.Start();
            //Thread.Sleep(0);

            InitializeComponent();
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Engine);
            this.mMapControl = mapControl;
            IMap pMap;
            pMap = axMapControl1.Map;
            LoadLayertoCbo2();
            active();

        }
        //private void Loading()
        //{
        //    frmloading.ShowDialog();
        //}

        public QuanTriHeThong()
        {
            InitializeComponent();
            //Thread t = new Thread(new ThreadStart(Loading));
            //t.Start();
            //Thread.Sleep(0);


            //ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Engine);
            IActiveView pActiveView;
            IMap pMap;
            IMapControlDefault pMapcontrol;
            pMapcontrol = axMapControl1.Object as IMapControlDefault;
            pMap = axMapControl1.Map;
            pActiveView = pMap as IActiveView;
            dmap = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map;
            LoadLayertoCbo2();
            active();
            ảnhVệTinhToolStripMenuItem.Checked = false;
            axPageLayoutControl2 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            axPageLayoutControl2 = axPageLayoutControl1;
            QLHTDT.Properties.Settings.Default.KTChinhSuaQLDAQH = false;
            //t.Abort();
        }
        #endregion
        private ICustomizeDialog m_CustomizeDialog;
        private ICustomizeDialogEvents_OnStartDialogEventHandler startDialogE;
        private ICustomizeDialogEvents_OnCloseDialogEventHandler closeDialogE;

        public static IToolbarMenu m_ToolbarMenuPage;
        private IToolbarMenu m_ToolbarMenuMap;
        private IToolbarMenu m_ToolbarChinhSua;
        private IToolbarMenu m_ToolbarMenuToc;
        private IToolbarMenu ToolChinhSua;
        private ToolbarPalette TrinhBayTrangIn;
        private IToolbarMenu ChonDoiTuong;
        private IEnvelope m_Envelope;
        private System.Object m_FillSymbol;
        private ITransformEvents_Event m_transformEvents;
        private ITransformEvents_VisibleBoundsUpdatedEventHandler visBoundsUpdatedE;
        public static ESRI.ArcGIS.Geodatabase.IWorkspace pWorkspace;
        public static ESRI.ArcGIS.Geodatabase.IFeatureWorkspace pFWorkspace;
        public static IActiveView pActiveView;
        public static AxMapControl pMxDoc;
        public static IMxDocument pMxDoc2;
        public static DataTable TBNK;
        public static SqlDataAdapter dataAdapterNK;
        public static SqlCommandBuilder cmbl;
        ICommandItem _previousCommand;
        ITool ToolPrevious; ITool ToolPrevious2;
        ITool toool2;
        public static ITool ToolPreviousPage; public static ITool ToolPreviousPage2;
        public static ITool toool2Page;
        int x;
        int y;
        public static int xPage;
        public static int yPage;
        IMapControlEvents2_OnMouseDownEvent ee;
        public static IPageLayoutControlEvents_OnMouseDownEvent eePage;
        public static IExtension engineEditorExt;
        public static IOperationStack operationStack;
        int refreshpage = 0;
        OpenFileDialog openFileDialogAnhBDGiay;
        private void active()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Engine);
        }
        private void CreateOverviewSymbol()
        {
            //Get the IRGBColor interface.
            IRgbColor color = new RgbColorClass();
            //Set the color properties.
            color.RGB = 255;
            //Get the ILine symbol interface.
            ILineSymbol outline = new SimpleLineSymbolClass();
            //Set the line symbol properties.
            outline.Width = 1.5;
            outline.Color = color;
            //Get the IFillSymbol interface.
            ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
            //Set the fill symbol properties.
            simpleFillSymbol.Outline = outline;
            simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSHollow;
            m_FillSymbol = simpleFillSymbol;
        }

        private void OnVisibleBoundsUpdated(IDisplayTransformation sender, bool sizeChanged)
        {
            m_Envelope = sender.VisibleBounds;
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
        }


        public static EngineEditor m_EngineEditor = new EngineEditorClass();
        private IEngineEditEvents_Event m_EngineEditEvents;

        private void SaveChinhSua()
        {
            MoAxMap = true;
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connection));
            cmbl = new SqlCommandBuilder(dataAdapterNK);
            if (QLHTDT.Properties.Settings.Default.KTChinhSuaQLDAQH == false)
            {
                dataAdapterNK.Update(TBNK);
            }
        }
        private void BatDauChinhSua()
        {
            TBNK = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connection));
            cmbl = new SqlCommandBuilder(dataAdapterNK);
            dataAdapterNK.Fill(TBNK);

            QLHTDT.Properties.Settings.Default.ChinhSuaTable = true;
            QLHTDT.Properties.Settings.Default.Save();
            //QLHTDT.Properties.Settings.Default.LopChinhSua = ((IEngineEditLayers)m_EngineEditor).TargetLayer.Name;


            m_ToolbarChinhSua = new ToolbarMenuClass();
            m_ToolbarChinhSua.CommandPool = axToolbarControl3.CommandPool;
            //Set the hook to the PageLayoutControl.
            m_ToolbarChinhSua.SetHook(axMapControl1);
            m_ToolbarChinhSua.Caption = "Menu Chỉnh sửa";
            //Add commands to the ToolbarMenu.
            m_ToolbarChinhSua.AddItem("esriControls.ControlsEditingEditTool", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsMapPanTool", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem(new QLHTDT.FormChinh.Button.Undo(), -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem(new QLHTDT.FormChinh.Button.Redo(), -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsEditingCopyCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsEditingCutCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsEditingPasteCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsEditingClearCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsEditingAttributeCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsMapIdentifyTool", -1, -1, true, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsZoomToSelectedCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsClearSelectionCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsEditingSketchDeleteCommand", -1, -1, true, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsEditingSketchFinishCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsEditingSketchFinishPartCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarChinhSua.AddItem("esriControls.ControlsEditingSketchFinishSquareCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            axMapControl1.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(c);
            axMapControl1.OnMouseDown -= new IMapControlEvents2_Ax_OnMouseDownEventHandler(HienMenuMap);
        }
        private void ketThucChinhSua(bool saveChanges)
        {
            QLHTDT.Properties.Settings.Default.ChinhSuaTable = false;
            QLHTDT.Properties.Settings.Default.Save();
            axMapControl1.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(HienMenuMap);
            axMapControl1.OnMouseDown -= new IMapControlEvents2_Ax_OnMouseDownEventHandler(c);

            if (saveChanges == true)
            { SaveChinhSua(); }
        }

        private void ThemMoi(IObject Object)
        {
            var date = DateTime.Now;
            DataRow hangmoi = TBNK.NewRow();
            hangmoi[1] = QLHTDT.Properties.Settings.Default.HoVaTen;
            hangmoi[2] = QLHTDT.Properties.Settings.Default.PhongBan;
            hangmoi[3] = "Thêm mới";
            hangmoi[4] = date.Day + "/" + date.Month + "/" + date.Year;
            hangmoi[5] = date.Hour + ":" + date.Minute + ":" + date.Second;
            hangmoi[6] = "Thêm mới đối tượng không gian Lớp :" + ((IEngineEditLayers)m_EngineEditor).TargetLayer.Name;
            hangmoi[7] = "Cập nhật thành công";
            TBNK.Rows.Add(hangmoi);
        }

        private void Xoa(IObject Object)
        {
            var date = DateTime.Now;
            DataRow hangmoi = TBNK.NewRow();
            //hangmoi[0] = "";//TBNK.Rows.Count + 1
            hangmoi[1] = QLHTDT.Properties.Settings.Default.HoVaTen;
            hangmoi[2] = QLHTDT.Properties.Settings.Default.PhongBan;
            hangmoi[3] = "Xóa";
            hangmoi[4] = date.Day + "/" + date.Month + "/" + date.Year;
            hangmoi[5] = date.Hour + ":" + date.Minute + ":" + date.Second;
            hangmoi[6] = "Xóa đối tượng không gian Lớp :" + ((IEngineEditLayers)m_EngineEditor).TargetLayer.Name;
            hangmoi[7] = "Cập nhật thành công";
            TBNK.Rows.Add(hangmoi);
        }
        private void ChinhSuaKhongGian(IObject Object)
        {
            if (QLHTDT.Properties.Settings.Default.KTThayDoiTable == true)
            {
                QLHTDT.Properties.Settings.Default.KTThayDoiTable = false;
                var date = DateTime.Now;
                DataRow hangmoi = TBNK.NewRow();

                hangmoi[1] = QLHTDT.Properties.Settings.Default.HoVaTen;
                hangmoi[2] = QLHTDT.Properties.Settings.Default.PhongBan;
                hangmoi[3] = "Chỉnh sửa thuộc tính";
                hangmoi[4] = date.Day + "/" + date.Month + "/" + date.Year;
                hangmoi[5] = date.Hour + ":" + date.Minute + ":" + date.Second;
                hangmoi[6] = "Chỉnh sửa thuộc tính lớp: " + ((IEngineEditLayers)m_EngineEditor).TargetLayer.Name;
                hangmoi[7] = "Cập nhật thành công";
                TBNK.Rows.Add(hangmoi);
            }
            else
            {
                var date = DateTime.Now;
                DataRow hangmoi = TBNK.NewRow();

                hangmoi[1] = QLHTDT.Properties.Settings.Default.HoVaTen;
                hangmoi[2] = QLHTDT.Properties.Settings.Default.PhongBan;
                hangmoi[3] = "Chỉnh sửa không gian";
                hangmoi[4] = date.Day + "/" + date.Month + "/" + date.Year;
                hangmoi[5] = date.Hour + ":" + date.Minute + ":" + date.Second;
                hangmoi[6] = "Chỉnh sửa không gian Lớp: " + ((IEngineEditLayers)m_EngineEditor).TargetLayer.Name;
                hangmoi[7] = "Cập nhật thành công";
                TBNK.Rows.Add(hangmoi);
            }


        }
        private void OnTargetLayerChanged()
        {
            QLHTDT.Properties.Settings.Default.LopChinhSua = "";
            if (((IEngineEditLayers)m_EngineEditor).TargetLayer != null)
            {
                QLHTDT.Properties.Settings.Default.LopChinhSua = ((IEngineEditLayers)m_EngineEditor).TargetLayer.Name;
            }
        }
        private void ChinhSuathuoctinh()
        {

        }
        public static void ChinhSuathuoctinhToolQuanLy(string LopCSua)
        {
            var date = DateTime.Now;
            DataRow hangmoi = TBNK.NewRow();

            hangmoi[1] = QLHTDT.Properties.Settings.Default.HoVaTen;
            hangmoi[2] = QLHTDT.Properties.Settings.Default.PhongBan;
            hangmoi[3] = "Chỉnh sửa thuộc tính";
            hangmoi[4] = date.Day + "/" + date.Month + "/" + date.Year;
            hangmoi[5] = date.Hour + ":" + date.Minute + ":" + date.Second;
            hangmoi[6] = "Lớp: " + LopCSua;
            hangmoi[7] = "Cập nhật thành công";
            TBNK.Rows.Add(hangmoi);

        }
        public void IWorkspaceEdit_Example(IWorkspace workspace, string nameOfFeatureClass)
        {

            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace;
            IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(nameOfFeatureClass);
            IWorkspaceEdit workspaceEdit = (IWorkspaceEdit)workspace;
            //start editing with undo redo functionality
            workspaceEdit.StartEditing(true);
            workspaceEdit.StartEditOperation();
            IFeature feature = featureClass.GetFeature(1);
            feature.Delete();
            workspaceEdit.StopEditOperation();
            Console.WriteLine("Would you like to undo your operation? Y or N");
            string response = Console.ReadLine();
            if (response.ToUpper() == "Y")
            {
                workspaceEdit.UndoEditOperation();
            }
            bool hasEdits = false;
            workspaceEdit.HasEdits(ref hasEdits);
            if (hasEdits)
            {
                Console.WriteLine("Would you like to save your edits? Y or N");
                response = Console.ReadLine();
                if (response.ToUpper() == "Y")
                {
                    workspaceEdit.StopEditing(true);
                }
                else
                {
                    workspaceEdit.StopEditing(false);
                }
            }
        }
        public delegate void OnSketchModifiedEventHandler();
        private string m_filePath;
        IWorkspaceFactory2 workspaceFactory;
        public static IFeatureWorkspace FeatureWorkspace;
        public static void DangKyChinhSua(IDataset pDataset)
        {

            IVersionedObject3 versionedObject = (IVersionedObject3)pDataset;


            bool IsRegistered;
            bool IsMovingEditsToBase;

            versionedObject.GetVersionRegistrationInfo(out IsRegistered, out IsMovingEditsToBase);


            if (IsRegistered)
            {
                //IsMovingEditsToBase : Tùy chọn di chuyển edits vào csdl
                //if (IsMovingEditsToBase)
                //{
                //Hủy đăng ký, lưu chỉnh sửa
                versionedObject.UnRegisterAsVersioned3(true);

                //then register as fully versioned
                versionedObject.RegisterAsVersioned3(false);
                //}
            }
            else
            {
                //registering as fully versioned
                versionedObject.RegisterAsVersioned3(false);
            }
        }
        public static void HuyDangKyChinhSua(IDataset pDataset)
        {
            IVersionedObject3 versionedObject = (IVersionedObject3)pDataset;


            bool IsRegistered;
            bool IsMovingEditsToBase;
            versionedObject.GetVersionRegistrationInfo(out IsRegistered, out IsMovingEditsToBase);
            if (IsRegistered)
            {
                //if (IsMovingEditsToBase)
                //{
                //    //Hủy đăng ký, Không lưu chỉnh sửa
                //    versionedObject.UnRegisterAsVersioned3(false);
                //}
                ////Hủy đăng ký, Lưu chỉnh sửa
                versionedObject.UnRegisterAsVersioned3(true);
            }
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            MoAxMap = true;
            workspaceFactory = (IWorkspaceFactory2)new SdeWorkspaceFactoryClass();
            if (Settings.Default.PathData != null & Settings.Default.PathData != "")
            {
                try
                {
                    FeatureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(Settings.Default.PathData + "\\connection.sde", 0);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("", "Thông báo");
                }
            }

            //treeList1.OptionsBehavior.Editable = false;
            treeList1.Columns[0].OptionsColumn.AllowEdit = false;
            m_EngineEditor.EnableUndoRedo(true);
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            connection.Open();
            //SqlCommand command1 = new SqlCommand("DECLARE @result BIT SELECT @result = [Quyền Tra cứu thông tin] FROM [HTDTCamLe].[dbo].[PhanQuyen] WHERE [Tài Khoản] = '" + QLHTDT.Properties.Settings.Default.TenTK + "' DECLARE @TenTK BIT Set @TenTK = '' SET @TenTK=(SELECT @result FROM [HTDTCamLe].[dbo].[PhanQuyen] WHERE [Tài Khoản] = '" + QLHTDT.Properties.Settings.Default.TenTK + "') SELECT @TenTK", connection);
            //bool a = (bool)command1.ExecuteScalar();
            //QLHTDT.Properties.Settings.Default.QuyenTraCuu = a;

            //SqlCommand command2 = new SqlCommand("DECLARE @result BIT SELECT @result = [Quyền sửa đối tượng] FROM [HTDTCamLe].[dbo].[PhanQuyen] WHERE [Tài Khoản] = '" + QLHTDT.Properties.Settings.Default.TenTK + "' DECLARE @TenTK BIT Set @TenTK = '' SET @TenTK=(SELECT @result FROM [HTDTCamLe].[dbo].[PhanQuyen] WHERE [Tài Khoản] = '" + QLHTDT.Properties.Settings.Default.TenTK + "') SELECT @TenTK", connection);
            //bool b = (bool)command2.ExecuteScalar();
            //QLHTDT.Properties.Settings.Default.QuyenSuaDT = b;

            //SqlCommand command4 = new SqlCommand("DECLARE @result BIT SELECT @result = [Quyền quản trị hệ thống] FROM [HTDTCamLe].[dbo].[PhanQuyen] WHERE [Tài Khoản] = '" + QLHTDT.Properties.Settings.Default.TenTK + "' DECLARE @TenTK BIT Set @TenTK = '' SET @TenTK=(SELECT @result FROM [HTDTCamLe].[dbo].[PhanQuyen] WHERE [Tài Khoản] = '" + QLHTDT.Properties.Settings.Default.TenTK + "') SELECT @TenTK", connection);
            //bool d = (bool)command4.ExecuteScalar();
            //QLHTDT.Properties.Settings.Default.QuyenQTHT = d;
            axPageLayoutControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(QLHTDT.FormChinh.QuanTriHeThong.MenuPage);
            _previousCommand = null;
            ToolPrevious = null;
            ToolPrevious2 = null;
            toool2 = null;
            ToolPreviousPage = null; ToolPreviousPage2 = null;
            toool2Page = null;
            m_EngineEditEvents = (IEngineEditEvents_Event)m_EngineEditor;

            m_EngineEditEvents.OnStartEditing += new IEngineEditEvents_OnStartEditingEventHandler(BatDauChinhSua);
            m_EngineEditEvents.OnStopEditing += new IEngineEditEvents_OnStopEditingEventHandler(ketThucChinhSua);
            m_EngineEditEvents.OnSaveEdits += new IEngineEditEvents_OnSaveEditsEventHandler(SaveChinhSua);
            m_EngineEditEvents.OnDeleteFeature += new IEngineEditEvents_OnDeleteFeatureEventHandler(Xoa);
            m_EngineEditEvents.OnCreateFeature += new IEngineEditEvents_OnCreateFeatureEventHandler(ThemMoi);
            m_EngineEditEvents.OnChangeFeature += new IEngineEditEvents_OnChangeFeatureEventHandler(ChinhSuaKhongGian);
            m_EngineEditEvents.OnTargetLayerChanged += new IEngineEditEvents_OnTargetLayerChangedEventHandler(OnTargetLayerChanged);

            //m_EngineEditEvents.OnSketchModified += new IEngineEditEvents_OnSketchModifiedEventHandler(ChinhSuaKhongGian);  
            operationStack = new ControlsOperationStackClass();
            axToolbarControl1.OperationStack = operationStack;
            object tbr = (object)axToolbarControl1.Object;
            engineEditorExt = m_EngineEditor as IExtension;
            engineEditorExt.Startup(ref tbr);




            ToolChinhSua = new ToolbarMenuClass();
            ToolChinhSua.CommandPool = axToolbarControl1.CommandPool;
            //Set the hook to the PageLayoutControl.
            ToolChinhSua.SetHook(axMapControl1);
            ToolChinhSua.Caption = "Edit";
            //Add commands to the ToolbarMenu.

            ToolChinhSua.AddItem(new QLHTDT.FormChinh.Button.DangKyChinhSua(), -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem(new QLHTDT.FormChinh.Button.KetThucDangKyChinhSua(), -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem("esriControls.ControlsEditingStartCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem("esriControls.ControlsEditingStopCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem("esriControls.ControlsEditingSaveCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem(new QLHTDT.FormChinh.Button.Undo(), -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem(new QLHTDT.FormChinh.Button.Redo(), -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem("esriControls.ControlsEditingEditTool", -1, -1, true, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem("esriControls.ControlsEditingCopyCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem("esriControls.ControlsEditingCutCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem("esriControls.ControlsEditingPasteCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem("esriControls.ControlsEditingClearCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem("esriControls.ControlsEditingSketchTool", -1, -1, true, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem("esriControls.ControlsEditingSketchPropertiesCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem("esriControls.ControlsEditingAttributeCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddItem("esriControls.ControlsEditingSnappingCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            //ToolChinhSua.AddItem("esriControls.ControlsMapZoomToLastExtentForwardCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            //ToolChinhSua.AddItem("esriControls.ControlsMapMeasureTool", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ToolChinhSua.AddSubMenu("esriControls.ControlsEditingSketchContextMenu", -1, false);


            TrinhBayTrangIn = new ToolbarPalette();
            TrinhBayTrangIn.Caption = "Trình bày trang in";
            TrinhBayTrangIn.AddItem(new QLHTDT.Trangin.CreateNorthArrow(), -1, -1);
            TrinhBayTrangIn.AddItem(new QLHTDT.Trangin.CreateScaleBar(), -1, -1);
            TrinhBayTrangIn.AddItem(new QLHTDT.Trangin.CreateScaleText(), -1, -1);
            TrinhBayTrangIn.AddItem(new QLHTDT.Trangin.CreateText(), -1, -1);


            ChonDoiTuong = new ToolbarMenuClass();
            ChonDoiTuong.CommandPool = axToolbarControl1.CommandPool;
            //Set the hook to the PageLayoutControl.
            ChonDoiTuong.SetHook(axMapControl1);
            ChonDoiTuong.Caption = "Select";
            ChonDoiTuong.AddItem("esriControls.ControlsSelectAllCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ChonDoiTuong.AddItem("esriControls.ControlsSelectByGraphicsCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ChonDoiTuong.AddItem("esriControls.ControlsSelectFeaturesTool", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ChonDoiTuong.AddItem("esriControls.ControlsSelectScreenCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ChonDoiTuong.AddItem("esriControls.ControlsSwitchSelectionCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ChonDoiTuong.AddItem("esriControls.ControlsZoomToSelectedCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            ChonDoiTuong.AddItem("esriControls.ControlsClearSelectionCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);



            m_ToolbarMenuMap = new ToolbarMenuClass();
            m_ToolbarMenuMap.CommandPool = axToolbarControl3.CommandPool;
            //Set the hook to the PageLayoutControl.
            m_ToolbarMenuMap.SetHook(axMapControl1);
            m_ToolbarMenuMap.Caption = "Menu chuột phải";
            //Add commands to the ToolbarMenu.
            m_ToolbarMenuMap.AddItem("esriControls.ControlsSelectTool", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuMap.AddItem("esriControls.ControlsMapZoomInTool", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuMap.AddItem("esriControls.ControlsMapZoomOutTool", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuMap.AddItem("esriControls.ControlsMapPanTool", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuMap.AddItem("esriControls.ControlsMapFullExtentCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuMap.AddItem("esriControls.ControlsMapRefreshViewCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuMap.AddItem("esriControls.ControlsMapZoomToLastExtentBackCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuMap.AddItem("esriControls.ControlsMapZoomToLastExtentForwardCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuMap.AddItem("esriControls.ControlsMapGoToCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            //Add map inquiry commands.
            m_ToolbarMenuMap.AddItem("esriControls.ControlsMapIdentifyTool", -1, -1, true, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuMap.AddItem("esriControls.ControlsMapFindCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuMap.AddItem("esriControls.ControlsMapMeasureTool", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuMap.AddItem("esriControls.ControlsEditingCutCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuMap.AddItem("esriControls.ControlsEditingPasteCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);

            m_mapControl = (IMapControl3)axMapControl1.Object;
            axTOCControl1.SetBuddyControl(axMapControl1);
            axToolbarControl1.SetBuddyControl(axMapControl1);
            m_TOCControl = (ITOCControl)axTOCControl1.Object;
            m_TOCControl.SetBuddyControl(axMapControl1);
            m_tocControl = (ITOCControl2)axTOCControl1.Object;
            m_tocControl.SetBuddyControl(m_mapControl);
            m_ToolbarMenuPage = new ToolbarMenuClass();
            m_ToolbarMenuToc = new ToolbarMenuClass();
            m_ToolbarMenuPage.CommandPool = axToolbarControl2.CommandPool;
            m_ToolbarMenuPage.SetHook(axPageLayoutControl1);
            m_ToolbarMenuPage.AddItem("esriControls.ControlsPageZoomInFixedCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuPage.AddItem("esriControls.ControlsPageZoomOutFixedCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuPage.AddItem("esriControls.ControlsPageZoomWholePageCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuPage.AddItem("esriControls.ControlsPageZoomPageToLastExtentBackCommand", -1, -1, true, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuPage.AddItem("esriControls.ControlsPageZoomPageToLastExtentForwardCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuPage.AddItem("esriControls.ControlsMapZoomInTool", -1, -1, true, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuPage.AddItem("esriControls.ControlsMapZoomOutTool", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuPage.AddItem("esriControls.ControlsMapPanTool", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuPage.AddItem("esriControls.ControlsMapFullExtentCommand", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_ToolbarMenuPage.AddItem("esriControls.ControlsSelectTool", -1, -1, false, esriCommandStyles.esriCommandStyleIconAndText);

            //add menu to axtoolbar :
            //

            m_menuMap = new ToolbarMenuClass();
            m_menuMap.AddItem("esriControls.ControlsAddDataCommand", 1, 0, false, esriCommandStyles.esriCommandStyleIconOnly);
            m_menuMap.AddItem(new LayerVisibility(), 1, 1, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuMap.AddItem(new LayerVisibility(), 2, 2, false, esriCommandStyles.esriCommandStyleTextOnly);
            //Add pre-defined menu to the map menu as a sub menu 
            //m_menuMap.AddSubMenu("esriControls.ControlsFeatureSelectionMenu", 2, true);
            m_menuLayer = new ToolbarMenuClass();

            m_menuLayer.AddItem(new QLHTDT.FormPhu.RemoveLayer(), -1, -1, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new QLHTDT.FormPhu.ShowTip(), -1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new QLHTDT.FormPhu.BangThuocTinh(), -1, 1, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new QLHTDT.FormPhu.HienThiLabel(), -1, 2, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new QLHTDT.FormPhu.ScaleThresholds(), 1, 3, true, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new QLHTDT.FormPhu.ScaleThresholds(), 2, 4, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new QLHTDT.FormPhu.ScaleThresholds(), 3, 5, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new QLHTDT.FormPhu.LayerSelectable(), 1, 6, true, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new QLHTDT.FormPhu.LayerSelectable(), 2, 7, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddSubMenu("esriControls.ControlsFeatureSelectionMenu", 8, true);
            m_menuLayer.AddItem(new QLHTDT.FormPhu.ZoomToLayer(), -1, 9, true, esriCommandStyles.esriCommandStyleTextOnly);
            //m_menuLayer.AddItem(new QLHTDT.FormPhu.EditSymbol(), -1, 10, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new QLHTDT.FormPhu.SaveLayerFileCmd(), -1, 10, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new QLHTDT.axToccontrol.UniqueValueRenderer(), -1, 11, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.SetHook(m_mapControl);
            m_menuMap.SetHook(m_mapControl);
            CreateCustomizeDialog();
            //gọi hàm symbol
            CreateOverviewSymbol();


            axToolbarControl1.AddItem(new CreateNewDocument(), 1, 0, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem(new QLHTDT.FormChinh.Button.Save(), -1, 1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //axToolbarControl1.AddItem("esriControls.ControlsOpenDocCommand", -1, 2, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem(new QLHTDT.FormChinh.Button.MoLop(), -1, 2, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsAddDataCommand", -1, 3, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapZoomToolControl", -1, 4, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsSelectTool", -1, 5, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapGoToCommand", -1, 6, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapZoomInTool", -1, 7, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapZoomOutTool", -1, 8, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapPanTool", -1, 9, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapFullExtentCommand", -1, 10, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapZoomToLastExtentBackCommand", -1, 11, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapZoomToLastExtentForwardCommand", -1, 12, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapIdentifyTool", -1, 13, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapFindCommand", -1, 14, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapMeasureTool", -1, 15, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //axToolbarControl1.AddItem(new TruyVanKhongGian(), -1, 16, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //axToolbarControl1.AddMenuItem(ChonDoiTuong, 17, true, 1);
            //axToolbarControl1.AddItem(new QLHTDT.FormChinh.Button.Undo(), -1, 18, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //axToolbarControl1.AddItem(new QLHTDT.FormChinh.Button.Redo(), -1, 19, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //axToolbarControl1.AddItem(new QLHTDT.FormChinh.Button.Save(), -1, 20, true, 0, esriCommandStyles.esriCommandStyleIconOnly);


            axToolbarControl5.Enabled = false;

            if (QLHTDT.Properties.Settings.Default.QuyenTraCuu == true)
            {
                //quToolStripMenuItem.Enabled = true;
                //quToolStripMenuItem.Visible = true;
                ////axToolbarControl1.AddItem("esriControls.ControlsMapGoToXYCommand", -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                //traCứuThôngTinQuyHoạchToolStripMenuItem.Enabled = true;
                //traCứuThôngTinQuyHoạchToolStripMenuItem.Visible = true;

            }

            if (QLHTDT.Properties.Settings.Default.QuyenSuaDT == true)
            {
                axToolbarControl1.AddMenuItem(ToolChinhSua, -1, true, 1);
                axToolbarControl5.AddItem(TrinhBayTrangIn, -1, -1, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                //chkCustomize.Enabled = true;
                lưuBảnĐồToolStripMenuItem.Enabled = true;
                //chkCustomize.Visible = true;
                lưuBảnĐồToolStripMenuItem.Visible = true;
                axToolbarControl1.AddItem("esriControls.ControlsEditingTargetToolControl", -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                côngCụChỉnhSửaDữLiệuToolStripMenuItem.Enabled = true;
            }


            if (QLHTDT.Properties.Settings.Default.QuyenQTHT == true)
            {
                quảnLýNgườiDùngToolStripMenuItem.Enabled = true;
                //thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Enabled = true;Ranh giới Ranh giới quy hoạch
                saoLưuCơSởDữLiệuToolStripMenuItem.Enabled = true;
                phụcHồiCơSởDữLiệuToolStripMenuItem.Enabled = true;

                quảnLýNgườiDùngToolStripMenuItem.Visible = true;
                //thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Visible = true;
                saoLưuCơSởDữLiệuToolStripMenuItem.Visible = true;
                phụcHồiCơSởDữLiệuToolStripMenuItem.Visible = true;
            }

            //axMapControl1.LoadMxFile("E:\\sinh\\ChuongTrinh\\QLHTDT-CamLe\\QLCSDL\\QLCSDL\\FormChinh\\MapVN2000.mxd");



            m_mapControl = (IMapControl3)axMapControl1.GetOcx();

            // TODO: This line of code loads data into the 'dataDataSet1.GDB_Items' table. You can move, or remove it, as needed.
            axTOCControl1.EnableLayerDragDrop = true;


            axTOCControl1.LabelEdit = esriTOCControlEdit.esriTOCControlManual;



            dmap.Name = "Bản đồ";
            if (System.IO.File.Exists(QLHTDT.Properties.Settings.Default.PathData + "\\MapVN2000.mxd"))
            {
                axMapControl1.LoadMxFile(QLHTDT.Properties.Settings.Default.PathData + "\\MapVN2000.mxd");
            }
            //frmloading.Hide();
            //frmloading.Close();
            //QLHTDT.FormPhu.QTHT.FrmLoading.a();

            ///////save tool bar
            //m_CustomizeDialog = new CustomizeDialogClass();
            //m_CustomizeDialog.DialogTitle = "Customize ToolbarControl Items";
            //m_CustomizeDialog.ShowAddFromFile = true;
            //m_CustomizeDialog.SetDoubleClickDestination(axToolbarControl1);
            //startDialogE = new ICustomizeDialogEvents_OnStartDialogEventHandler(OnStartDialog);
            //((ICustomizeDialogEvents_Event)m_CustomizeDialog).OnStartDialog += startDialogE;
            //closeDialogE = new ICustomizeDialogEvents_OnCloseDialogEventHandler(OnCloseDialog);
            //((ICustomizeDialogEvents_Event)m_CustomizeDialog).OnCloseDialog += closeDialogE;
            //m_filePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            //m_filePath = m_filePath.Replace("LoadAndSaveToolbar.exe", "");
            //m_filePath = m_filePath + @"\SampleSettings.txt";
            //if (System.IO.File.Exists(m_filePath) == true)
            //{
            //    DialogResult result = System.Windows.Forms.MessageBox.Show("Có muốn phục hồi thanh công cụ đã lưu trước đó hay không?", "Load Settings", MessageBoxButtons.YesNo);
            //    if (result == DialogResult.Yes) LoadToolbarControl();
            //}

            ICommand commandPage = new ControlsMapPanTool();
            commandPage.OnCreate(axMapControl1.Object);
            ITool toolPage = commandPage as ITool;
            axMapControl1.CurrentTool = toolPage;
            Cursor = Cursors.Default;
            treeList1.BestFitColumns();
            treeList1.BestFitVisibleOnly = true;
            splitContainer1.Panel1MinSize = 105;
            splitContainer2.Panel1MinSize = 200;

        }
        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ////Clear variables
            //m_TOCControl.SetBuddyControl(null);
            ////String filePath = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("QLHTDT.exe", "") + @"\PersistedItems.txt";
            //DialogResult result = System.Windows.Forms.MessageBox.Show("Tùy chọn sao lưu tùy chỉnh thanh công cụ: " + System.Environment.NewLine +
            //    "Yes: Lưu thanh công cụ (có thể phục hồi lại thanh công cụ ở lần mở sau)." + System.Environment.NewLine +
            //    "No: Không lưu tùy chỉnh thanh công cụ" + System.Environment.NewLine +
            //    "Cancel: Hủy lệnh tắt.", "Lưu cài đặt thanh công cụ", MessageBoxButtons.YesNoCancel);

            ////Save state
            //if (result == DialogResult.Yes) SaveToolbarControl1();
            ////Delete file
            //if (result == DialogResult.No) DeleteFile();
            //Environment.Exit(1);
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "QuanTriHeThong" & Application.OpenForms[i].Name != "SGMC")
                    Application.OpenForms[i].Close();
            }
        }



        private void RecordingCache()
        {
            //if ((m_pScreenDisplay.IsCacheDirty((short)esriScreenCache.esriScreenRecording)))
            //{
            //    m_pScreenDisplay.StartRecording();
            //    m_pDraw.StartDrawing(hDC, (short)esriScreenCache.esriNoScreenCache);

            //    DrawContents();

            //    m_pDraw.FinishDrawing();
            //    m_pScreenDisplay.StopRecording();
            //}

            //else
            //{
            //    m_pScreenDisplay.DrawCache(Picture1.hDC, (short)
            //      esriScreenCache.esriScreenRecording, 0, 0);
            //}
            //if ((m_pScreenDisplay.IsCacheDirty(esriScreenRecording)))
            //{
            //    m_pScreenDisplay.StartRecording();
            //    m_pDraw.StartDrawing(hDC, esriScreenCache.esriNoScreenCache);
            //    DrawContents();
            //    m_pDraw.FinishDrawing();
            //    m_pScreenDisplay.StopRecording();
            //}
            //else
            //{

            //    m_pScreenDisplay.DrawCache(Picture1.hDC, esriScreenCache.esriScreenRecording, 0, 0);

            //}
        }

        private void EnableLayerCaches()
        {
            try
            {

                for (int i = 0; i < pMap.LayerCount; i++)
                {
                    axMapControl1.get_Layer(i).Cached = (true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("", "Thông báo");
            }
        }
        public static bool MoAxMap;

        private void TabControl1_Click(object sender, System.EventArgs e)
        {

            //Toggle control visiblity and set the buddy
            if (tabControl1.SelectedIndex == 0)
            {
                MoAxMap = true;
                //axPageLayoutControl1.Visible = false;
                //axMapControl1.Visible = true;
                m_TOCControl.SetBuddyControl(axMapControl1);
                axTOCControl1.SetBuddyControl(axMapControl1);
                axToolbarControl1.SetBuddyControl(axMapControl1);
                axToolbarControl4.SetBuddyControl(axMapControl1);
                m_tocControl.SetBuddyControl(m_mapControl); 
                m_menuLayer.SetHook(m_mapControl);
                m_menuMap.SetHook(m_mapControl);
                CopyToMap();
                axMapControl1.ActiveView.Refresh();
                axToolbarControl5.Enabled = false;
                ICommand commandPage = new ControlsMapPanTool();
                commandPage.OnCreate(axMapControl1.Object);
                ITool toolPage = commandPage as ITool;
                axMapControl1.CurrentTool = toolPage;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                MoAxMap = false;
                //axPageLayoutControl1.Visible = true;
                //axMapControl1.Visible = false;
                m_TOCControl.SetBuddyControl(axPageLayoutControl1);
                axTOCControl1.SetBuddyControl(axPageLayoutControl1);
                //axToolbarControl1.SetBuddyControl(axPageLayoutControl1);
                axToolbarControl4.SetBuddyControl(axPageLayoutControl1);
                m_tocControl.SetBuddyControl(axPageLayoutControl1);
                CopyToPageLayout();
                axPageLayoutControl1.ActiveView.Refresh();
                axToolbarControl5.Enabled = true;
                ICommand commandPage = new ControlsSelectTool();
                commandPage.OnCreate(axPageLayoutControl1.Object);
                ITool toolPage = commandPage as ITool;
                axPageLayoutControl1.CurrentTool = toolPage;
            }

        }
        private void axTOCControl1_OnEndLabelEdit(object sender, ITOCControlEvents_OnEndLabelEditEvent e)
        {
            //If the new label is an empty string, prevent the edit.
            string newLabel = e.newLabel;
            if (e.newLabel.Trim() == "")
                e.canEdit = false;
        }
        private ITOCControl m_TOCControl;

        private void axTOCControl1_OnBeginLabelEdit(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnBeginLabelEditEvent e)
        {
            IBasicMap map = null;
            ILayer layer = null;
            object other = null;
            object index = null;
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;

            //Determine what kind of item has been clicked on
            m_TOCControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            //Only layer items can have their labels edited
            if (item != esriTOCControlItem.esriTOCControlItemLayer)
            {
                e.canEdit = true;
            }
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {

            //Suppress data redraw and draw bitmap instead.
            axMapControl1.SuppressResizeDrawing(true, 0);
            axPageLayoutControl1.SuppressResizeDrawing(true, 0);
        }
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            //Stop bitmap draw and draw data.
            axMapControl1.SuppressResizeDrawing(false, 0);
            axPageLayoutControl1.SuppressResizeDrawing(false, 0);
        }
        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open Document command
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }

        private void CreateCustomizeDialog()
        {
            //Create a new Customize dialog box.
            m_CustomizeDialog = new CustomizeDialogClass();
            //Set the title.
            m_CustomizeDialog.DialogTitle = "Customize ToolbarControl Items";
            //Show the Add from File button.
            m_CustomizeDialog.ShowAddFromFile = true;
            //Set the ToolbarControl that new items will be added to.
            m_CustomizeDialog.SetDoubleClickDestination(axToolbarControl1);
            m_CustomizeDialog.SetDoubleClickDestination(axToolbarControl4);
            m_CustomizeDialog.SetDoubleClickDestination(axToolbarControl5);

            //Set the Customize dialog box events. 
            startDialogE = new ICustomizeDialogEvents_OnStartDialogEventHandler
              (OnStartDialog);
            ((ICustomizeDialogEvents_Event)m_CustomizeDialog).OnStartDialog +=
              startDialogE;
            closeDialogE = new ICustomizeDialogEvents_OnCloseDialogEventHandler
              (OnCloseDialog);
            ((ICustomizeDialogEvents_Event)m_CustomizeDialog).OnCloseDialog +=
              closeDialogE;
        }
        #endregion



        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {

            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }
        private void axPageControl1_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {

            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.pageX.ToString("#######.##"), e.pageY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }



        private void HienMenuMap(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {

                ICommand command = new ControlsMapPanTool();
                command.OnCreate(axMapControl1.Object);
                ITool toool = command as ITool;
                if (ToolPrevious != null)
                {
                    if (axMapControl1.CurrentTool == toool2 && toool != ToolPrevious)
                    { axMapControl1.CurrentTool = ToolPrevious; ToolPrevious = null; }
                    else { m_ToolbarMenuMap.PopupMenu(e.x, e.y, axMapControl1.hWnd); }
                }
                else { m_ToolbarMenuMap.PopupMenu(e.x, e.y, axMapControl1.hWnd); }
            }
            if (e.button == 4)
            {
                if (axMapControl1.CurrentTool != null)
                {
                    x = 0; y = 0; ee = null;
                    ToolPrevious = axMapControl1.CurrentTool;
                    ICommand command = new ControlsMapPanTool();
                    command.OnCreate(axMapControl1.Object);
                    axMapControl1.CurrentTool = command as ITool;
                    //command.OnClick();
                    toool2 = axMapControl1.CurrentTool;
                    x = e.x; y = e.y; ee = e;
                    //axMapControl1.CurrentTool.OnMouseDown(1, e.shift, axMapControl1.Width / 2, axMapControl1.Height / 2);
                }
                else
                {
                    x = 0; y = 0; ee = null;
                    ICommand command = new ControlsMapPanTool();
                    command.OnCreate(axMapControl1.Object);
                    axMapControl1.CurrentTool = command as ITool;
                    //command.OnClick();
                    //HienMenuMap(sender, e);
                    x = e.x; y = e.y;
                    ee = e;
                    //axMapControl1.CurrentTool.OnMouseDown(1, e.shift, axMapControl1.Width / 2, axMapControl1.Height / 2);
                }
            }
        }
        public static void MenuPage(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                ICommand commandPage = new ControlsPagePanTool();
                commandPage.OnCreate(axPageLayoutControl1.Object);
                ITool tooolPage = commandPage as ITool;
                if (ToolPreviousPage != null)
                {
                    if (axPageLayoutControl1.CurrentTool == toool2Page && tooolPage != ToolPreviousPage)
                    { axPageLayoutControl1.CurrentTool = ToolPreviousPage; ToolPreviousPage = null; }
                    else { m_ToolbarMenuPage.PopupMenu(e.x, e.y, axPageLayoutControl1.hWnd); }
                }
                else { m_ToolbarMenuPage.PopupMenu(e.x, e.y, axPageLayoutControl1.hWnd); }
            }
            if (e.button == 4)
            {
                if (axPageLayoutControl1.CurrentTool != null)
                {
                    xPage = 0; yPage = 0; eePage = null;
                    ToolPreviousPage = axPageLayoutControl1.CurrentTool;
                    ICommand command = new ControlsPagePanTool();
                    command.OnCreate(axPageLayoutControl1.Object);
                    axPageLayoutControl1.CurrentTool = command as ITool;
                    command.OnClick();
                    toool2Page = axPageLayoutControl1.CurrentTool;
                    xPage = e.x; yPage = e.y; eePage = e;
                }
                else
                {
                    xPage = 0; yPage = 0; eePage = null;
                    ICommand command = new ControlsPagePanTool();
                    command.OnCreate(axPageLayoutControl1.Object);
                    axPageLayoutControl1.CurrentTool = command as ITool;
                    command.OnClick();
                    //HienMenuMap(sender, e);
                    xPage = e.x; yPage = e.y;
                    eePage = e;
                }
            }
        }

        private void onmouseup(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            ICommand command = new ControlsMapPanTool();
            command.OnCreate(axMapControl1.Object);
            ITool toool = command as ITool;

            ICommand commandThongtin = new ControlsMapIdentifyTool();
            commandThongtin.OnCreate(axMapControl1.Object);
            //ITool tooolThongTin = commandThongtin as ITool;
            //ITool toolcurent = axMapControl1.CurrentTool;

            //if (tabControl1.SelectedIndex == 0)
            //{
            //}
            if (e.button == 4)
            {
                if (ToolPrevious != null)
                {
                    int xcenter = axMapControl1.Width / 2;
                    int ycenter = axMapControl1.Height / 2;
                    if (tabControl1.SelectedIndex == 0)
                        axMapControl1.CurrentTool = toool;
                    axMapControl1.CurrentTool.OnMouseDown(1, e.shift, xcenter - (e.x - ee.x), ycenter - (e.y - ee.y));
                    axMapControl1.CurrentTool.OnMouseUp(1, e.shift, xcenter - (e.x - ee.x), ycenter - (e.y - ee.y));
                    axMapControl1.CurrentTool = ToolPrevious;
                }
                else
                {
                    int xcenter = axMapControl1.Width / 2;
                    int ycenter = axMapControl1.Height / 2;
                    axMapControl1.CurrentTool = toool;
                    axMapControl1.CurrentTool.OnMouseDown(1, e.shift, xcenter - (e.x - ee.x), ycenter - (e.y - ee.y));
                    axMapControl1.CurrentTool.OnMouseUp(1, e.shift, xcenter - (e.x - ee.x), ycenter - (e.y - ee.y));
                }
            }


        }
        private void axMapControl1_OnDoubleClick(object sender, IMapControlEvents2_OnDoubleClickEvent e)
        {
            if (e.button == 1)
            {
                if (tabControl1.SelectedIndex == 0)//& toolcurent == tooolThongTin)
                {
                    // TODO:  Add TruyVanKhongGian.OnMouseDown implementation
                    IActiveView pActiveView;
                    pActiveView = QuanTriHeThong.axMapControl1.ActiveView;
                    Global.pActiveView = pActiveView;
                    string tenlop = "";
                    double xp = Convert.ToDouble(e.mapX.ToString("#######.##"));
                    double yp = Convert.ToDouble(e.mapY.ToString("#######.##"));

                    string sqltenlop = "SELECT TOP 1 [ChiaLo] from NENPHUONG where Shape.STContains(geometry::STGeomFromText('POINT(" + xp.ToString() + " " + yp.ToString() + ")', 0)) = 1";
                    SqlConnection connec = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    connec.Open();
                    SqlCommand commandTenLop = new SqlCommand(sqltenlop, connec);
                    if (commandTenLop.ExecuteScalar() != DBNull.Value)
                    {
                        tenlop = (string)commandTenLop.ExecuteScalar();
                    }
                    connec.Close();
                    if (tenlop != "" & tenlop != null)
                    {
                        tenlop = tenlop.Replace("ChiaLo_", "Chia lô - ");
                        IPoint pPoly = new PointClass();
                        pPoly.X = xp;
                        pPoly.Y = yp;
                        ILayer pLayer;
                        IFeatureLayer pFlayer;
                        IFeatureClass pFCLass;
                        IFeatureCursor pCursor;
                        ISpatialFilter pQuery;
                        pLayer = Global.getLayerbyName(Global.pActiveView.FocusMap, tenlop);
                        if (pLayer != null)
                        {
                            pFlayer = (IFeatureLayer)pLayer;
                            if (pFlayer != null)
                            {
                                pActiveView.FocusMap.SelectByShape(pPoly, null, false);
                                //axMapControl1.Refresh();
                                pFCLass = pFlayer.FeatureClass;
                                pQuery = new SpatialFilter();
                                pQuery.Geometry = pPoly;
                                pQuery.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                                pCursor = pFCLass.Search(pQuery, false);
                                pActiveView.Refresh();
                                IFeature feature = pCursor.NextFeature();
                                //IFeatureSelection featSelect = feature as IFeatureSelection;
                                tt = new DataTable();
                                tt.Columns.Add("Mã", typeof(String));
                                tt.Columns.Add("Chủ sử dụng", typeof(String));
                                tt.Columns.Add("Số tờ bản đồ", typeof(String));
                                tt.Columns.Add("Số thửa", typeof(String));
                                tt.Columns.Add("Diện tích", typeof(String));
                                tt.Columns.Add("Địa chỉ", typeof(String));
                                tt.Columns.Add("Tình trạng pháp lý", typeof(String));
                                tt.Columns.Add("Thông tin quy hoạch", typeof(String));
                                tt.Columns.Add("Phường", typeof(String));
                                tt.Columns.Add("Loại đất", typeof(String));
                                tt.Columns.Add("TenKhuVuc", typeof(String));
                                tt.Columns.Add("TangCaoXD", typeof(String));
                                tt.Columns.Add("ChiGioiXD", typeof(String));
                                tt.Columns.Add("ChieuCaoTang", typeof(String));
                                tt.Columns.Add("CotNen", typeof(String));
                                tt.Columns.Add("QDKhac", typeof(String));
                                tt.Columns.Add("SoGPXD", typeof(String));
                                tt.Columns.Add("TTCPXD", typeof(String));
                                tt.Columns.Add("MaHSCPXD", typeof(String));
                                dr = tt.NewRow();
                                dr[0] = feature.get_Value(feature.Fields.FindField("OBJECTID")).ToString();
                                if (feature.get_Value(feature.Fields.FindField("ChuSD")) != DBNull.Value)
                                {
                                    dr[1] = feature.get_Value(feature.Fields.FindField("ChuSD")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("SoToBD")) != DBNull.Value)
                                {
                                    dr[2] = feature.get_Value(feature.Fields.FindField("SoToBD")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("SoThua")) != DBNull.Value)
                                {
                                    dr[3] = feature.get_Value(feature.Fields.FindField("SoThua")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("DienTich")) != DBNull.Value)
                                {
                                    dr[4] = feature.get_Value(feature.Fields.FindField("DienTich")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("DiaChi")) != DBNull.Value)
                                {
                                    dr[5] = feature.get_Value(feature.Fields.FindField("DiaChi")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("TTPL")) != DBNull.Value)
                                {
                                    dr[6] = feature.get_Value(feature.Fields.FindField("TTPL")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("KhuQH")) != DBNull.Value)
                                {
                                    dr[7] = feature.get_Value(feature.Fields.FindField("KhuQH")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("TenPhuong")) != DBNull.Value)
                                {
                                    dr[8] = feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("LoaiDat")) != DBNull.Value)
                                {
                                    dr[9] = feature.get_Value(feature.Fields.FindField("LoaiDat")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("MaKVKT")) != DBNull.Value)
                                {
                                    getKienTruc(tenlop);
                                    string MaKT = feature.get_Value(feature.Fields.FindField("MaKVKT")).ToString().Replace(" ", "");
                                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                    conn.Open();
                                    string sql1 = "SELECT [TenKhuVuc] FROM [GIS].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                    SqlCommand command1 = new SqlCommand(sql1, conn);
                                    if (command1.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[10] = (string)command1.ExecuteScalar();
                                    }
                                    string sql2 = "SELECT [TangCaoXD] FROM [GIS].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                    SqlCommand command2 = new SqlCommand(sql2, conn);
                                    if (command2.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[11] = (string)command2.ExecuteScalar();
                                    }
                                    string sql3 = "SELECT [ChiGioiXD] FROM [GIS].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                    SqlCommand command3 = new SqlCommand(sql3, conn);
                                    if (command3.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[12] = (string)command3.ExecuteScalar();
                                    }
                                    string sql4 = "SELECT [ChieuCaoTang] FROM [GIS].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                    SqlCommand command4 = new SqlCommand(sql4, conn);
                                    if (command4.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[13] = (string)command4.ExecuteScalar();
                                    }
                                    string sql5 = "SELECT [CotNen] FROM [GIS].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                    SqlCommand command5 = new SqlCommand(sql5, conn);
                                    if (command5.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[14] = (string)command5.ExecuteScalar();
                                    }
                                    string sql6 = "SELECT [QDKhac] FROM [GIS].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                                    SqlCommand command6 = new SqlCommand(sql6, conn);
                                    if (command6.ExecuteScalar() != DBNull.Value)
                                    {
                                        dr[15] = (string)command6.ExecuteScalar();
                                    }

                                    string sql = "SELECT [SoQD] FROM CPXD WHERE [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "' and [Phuong] =N'" + feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString() + "' and ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "')";
                                    SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                    SqlCommand commanCPXD = new SqlCommand(sql, connection);
                                    commanCPXD.Connection.Open();
                                    string SoGPXD = "";
                                    if (commanCPXD.ExecuteScalar() != DBNull.Value)
                                    {
                                        SoGPXD = (string)commanCPXD.ExecuteScalar();
                                        if (SoGPXD != "" & SoGPXD != null)
                                        {
                                            SoGPXD = (string)commanCPXD.ExecuteScalar();
                                            dr[16] = SoGPXD;
                                            dr[17] = "Thửa đất đã được cấp phép xây dựng - GPXD số " + SoGPXD;
                                            SqlCommand commanMaHSCPXD = new SqlCommand("SELECT [MaHS] FROM [HTDTCAMLE].[dbo].[CPXD] WHERE [SoQD] = '" + SoGPXD + "'", connection);
                                            commanCPXD.Connection.Close();
                                            commanMaHSCPXD.Connection.Open();
                                            dr[18] = (string)commanMaHSCPXD.ExecuteScalar();
                                            commanMaHSCPXD.Connection.Close();
                                        }
                                        else { dr[17] = "Chưa có thông tin cấp phép xây dựng"; commanCPXD.Connection.Close(); }
                                    }
                                    else { dr[17] = "Chưa có thông tin cấp phép xây dựng"; commanCPXD.Connection.Close(); }
                                }
                                tt.Rows.Add(dr);
                                if (frm1Thua != null)
                                {
                                    frm1Thua.Close();
                                    frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(tt);
                                    frm1Thua.Show();
                                    Cursor = Cursors.Default;
                                }
                                else
                                {
                                    frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(tt);
                                    frm1Thua.Show();
                                    Cursor = Cursors.Default;
                                }
                            }


                        }
                    }
                }
            }
        }
        private void getKienTruc(string lopchialo)
        {
            if (lopchialo == "Chia lô - HA")
            { tableKT = "KienTruc_HA"; }
            else if (lopchialo == "Chia lô - HP")
            { tableKT = "KienTruc_HP"; }
            else if (lopchialo == "Chia lô - HTT")
            { tableKT = "KienTruc_HTT"; }
            else if (lopchialo == "Chia lô - HTD")
            { tableKT = "KienTruc_HTD"; }
            else if (lopchialo == "Chia lô - HX")
            { tableKT = "KienTruc_HX"; }
            else if (lopchialo == "Chia lô - KT")
            { tableKT = "KienTruc_KT"; }

        }
        private void onmouseupPage(object sender, IPageLayoutControlEvents_OnMouseUpEvent e)
        {
            ICommand commandselect = new ControlsSelectTool();
            commandselect.OnCreate(axPageLayoutControl1.Object);
            ITool tooolPageselect = commandselect as ITool;

            ICommand commandPage = new ControlsPagePanTool();
            commandPage.OnCreate(axPageLayoutControl1.Object);
            ITool tooolPage = commandPage as ITool;

            if (e.button == 4)
            {
                int xcenter = axPageLayoutControl1.Width / 2;
                int ycenter = axPageLayoutControl1.Height / 2;
                if (ToolPreviousPage != null)
                {
                    axPageLayoutControl1.CurrentTool = tooolPage;
                    axPageLayoutControl1.CurrentTool.OnMouseDown(1, e.shift, xcenter - (e.x - eePage.x), ycenter - (e.y - eePage.y));
                    axPageLayoutControl1.CurrentTool.OnMouseUp(1, e.shift, xcenter - (e.x - eePage.x), ycenter - (e.y - eePage.y));
                    ICommand commands = ToolPreviousPage as ICommand;
                    if (commands.Caption != "Select Elements")
                        axPageLayoutControl1.CurrentTool = ToolPreviousPage;
                }
                else
                {

                    axPageLayoutControl1.CurrentTool = tooolPage;
                    axPageLayoutControl1.CurrentTool.OnMouseDown(1, e.shift, xcenter - (e.x - eePage.x), ycenter - (e.y - eePage.y));
                    axPageLayoutControl1.CurrentTool.OnMouseUp(1, e.shift, xcenter - (e.x - eePage.x), ycenter - (e.y - eePage.y));
                }

            }
        }
        private void c(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 2)
                m_ToolbarChinhSua.PopupMenu(e.x, e.y, axMapControl1.hWnd);
        }
        //private void axMapControl1_OnViewRefreshed(object sender, IMapControlEvents2_OnViewRefreshedEvent e)
        //{
        //    //QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();
        //    //QLHTDT.FormChinh.QuanTriHeThong.CopyToPageLayout();
        //}
        private void axPageLayoutControl1_OnViewRefreshed(object sender, IPageLayoutControlEvents_OnViewRefreshedEvent e)
        {
        }
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            IActiveView activeView = axMapControl1.ActiveView.FocusMap as
              IActiveView;
            //Trap the ITranformEvents of the PageLayoutControl's focus map. 
            visBoundsUpdatedE = new ITransformEvents_VisibleBoundsUpdatedEventHandler
              (OnVisibleBoundsUpdated);
            IDisplayTransformation displayTransformation =
              activeView.ScreenDisplay.DisplayTransformation;
            //Start listening to the transform events interface.
            m_transformEvents = (ITransformEvents_Event)displayTransformation;
            //Start listening to the VisibleBoundsUpdated method on ITransformEvents interface.
            m_transformEvents.VisibleBoundsUpdated += visBoundsUpdatedE;
            //Get the extent of the focus map.
            m_Envelope = activeView.Extent;
        }

        private void axMapControl1_OnAfterDraw(object sender, IMapControlEvents2_OnAfterDrawEvent e)
        {

            //if (axMapControl1.LayerCount > axPageLayoutControl1.ActiveView.FocusMap.LayerCount)
            //{ CopyToPageLayout(); }
            if (m_Envelope == null)
                return;

            //If the foreground phase has drawn. 
            esriViewDrawPhase viewDrawPhase = (esriViewDrawPhase)e.viewDrawPhase;
            if (viewDrawPhase == esriViewDrawPhase.esriViewForeground)
            {
                IGeometry geometry = m_Envelope;
                axMapControl1.DrawShape(geometry, ref m_FillSymbol);
            }
        }
        private void axPageLayoutControl1_OnAfterDraw(object sender, IPageLayoutControlEvents_OnAfterDrawEvent e)
        {

        }


        private void axPageLayoutControl1_OnPageLayoutReplaced(object sender, IPageLayoutControlEvents_OnPageLayoutReplacedEvent e)
        {
        }
        private void axPageLayoutControl1_OnExtentUpdated(object sender, ESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnExtentUpdatedEvent e)
        {
            //if (refreshpage % 2 == 0)
            //{
            //    refreshpage = refreshpage + 1;
            axPageLayoutControl1.Refresh();
            //}
        }
        void axPageLayoutControl1_OnFocusMapChanged(object sender, EventArgs e)
        {
            if (refreshpage % 2 == 0)
            {
                refreshpage = refreshpage + 1;
                axPageLayoutControl1.Refresh();
            }
        }


        private void OnStartDialog()
        {
            axToolbarControl1.Customize = true;
            axToolbarControl4.Customize = true;
            axToolbarControl5.Customize = true;
        }

        private void OnCloseDialog()
        {
            axToolbarControl1.Customize = false;
            axToolbarControl4.Customize = false;
            axToolbarControl5.Customize = false;
        }

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            if (axMapControl1.LayerCount > axPageLayoutControl1.ActiveView.FocusMap.LayerCount)
            { CopyToPageLayout(); }
        }

        public static void CopyToPageLayout()
        {
            if (axMapControl1.DocumentFilename != null)
            {
                if (axPageLayoutControl1.DocumentFilename == axMapControl1.DocumentFilename)
                {

                    IObjectCopy pObjectCopy = new ObjectCopyClass();
                    object copyFromMap = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map;
                    object copiedMap = pObjectCopy.Copy(copyFromMap);//copiedMap
                    object copyToMap = axPageLayoutControl1.ActiveView.FocusMap;
                    pObjectCopy.Overwrite(copiedMap, ref copyToMap);
                }
                else { axPageLayoutControl1.LoadMxFile(axMapControl1.DocumentFilename); }
            }

        }
        public static void CopyToMap()
        {
            if (axPageLayoutControl1.DocumentFilename != null)
            {
                if (axPageLayoutControl1.DocumentFilename == axMapControl1.DocumentFilename)
                {
                    IObjectCopy pObjectCopy = new ObjectCopyClass();
                    object copyFromMap = QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView.FocusMap;
                    object copiedMap = pObjectCopy.Copy(copyFromMap);//copiedMap
                    object copyToMap = axMapControl1.ActiveView.FocusMap;
                    pObjectCopy.Overwrite(copiedMap, ref copyToMap);
                }
                else { axMapControl1.LoadMxFile(axPageLayoutControl1.DocumentFilename); }
            }

        }
        private void xemThôngTinĐốiTượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void kếtNốiCơSởDữLiệuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QLHTDT.FormChinh.CORE.Connectdatabase.ConnectFolder();
        }

        private void mởBảnĐồToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //QLHTDT.View.FrmDanhSachBanDo frm = new QLHTDT.View.FrmDanhSachBanDo(axMapControl1,axPageLayoutControl1);
            //frm.ShowDialog();
            ICommand command = new ControlsOpenDocCommand();
            if (tabControl1.SelectedIndex == 0)
            {
                command.OnCreate(axMapControl1.Object);
                axMapControl1.CurrentTool = command as ITool;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                command.OnCreate(axPageLayoutControl1.Object);
                axPageLayoutControl1.CurrentTool = command as ITool;
            }

            command.OnClick();
        }

        private void mởLớpLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ICommand command = new ControlsAddDataCommand();
            if (tabControl1.SelectedIndex == 0)
            {
                command.OnCreate(axMapControl1.Object);
                axMapControl1.CurrentTool = command as ITool;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                command.OnCreate(axPageLayoutControl1.Object);
                axPageLayoutControl1.CurrentTool = command as ITool;
            }

            command.OnClick();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var image = Image.FromFile(System.IO.Path.GetTempPath() + "\\TrangIn.jpg");

            if (System.IO.File.Exists(System.IO.Path.GetTempPath() + "\\TrangIn.jpg"))
            {
                System.IO.File.Delete(System.IO.Path.GetTempPath() + "\\TrangIn.jpg");
            }
            CreateJPEGHiResolutionFromActiveView(axPageLayoutControl1.ActiveView, System.IO.Path.GetTempPath() + "\\TrangIn.jpg");
            QLHTDT.FormPhu.InAn.ToolIn frm = new QLHTDT.FormPhu.InAn.ToolIn();
            frm.Show();
        }
        private void lưuĐếnFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        public static void comboBox1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
        }

        private void nhậtKíLàmViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QTHT.NhatKi frm = new QLHTDT.FormPhu.QTHT.NhatKi();
            frm.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QTHT.QLNguoiDung frm = new QLHTDT.FormPhu.QTHT.QLNguoiDung();
            frm.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void thayĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QTHT.ThayDoiMK frm = new QLHTDT.FormPhu.QTHT.ThayDoiMK();
            //frm.show();
            frm.ShowDialog();
            Cursor = Cursors.Default;
        }




        private void ảnhVệTinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axMapControl1.AddLayerFromFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\Layer\\AnhGoogle\\GoogleMap.lyr");
            EnableLayerCaches();
        }


        private void ảnhGiaoThôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //axMapControl1.AddLayerFromFile(@"" + QLHTDT.Properties.Settings.Default.PathData + "\\Layer\\AnhGoogle\\GoogleMap.lyr");
            EnableLayerCaches();
        }

        private void thôngTinNgườiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QTHT.TTNguoiDung frm = new QLHTDT.FormPhu.QTHT.TTNguoiDung();
            //frm.show();
            frm.ShowDialog();
            Cursor = Cursors.Default;
        }
        private void axTOCControl1_OnDoubleClick(object sender, ITOCControlEvents_OnDoubleClickEvent e)
        {
            if (e.button != 1) return;
            ILayer layer = new FeatureLayerClass();
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = new MapClass();
            object other = new ESRI.ArcGIS.Geodatabase.Object();
            object index = new ESRI.ArcGIS.Geodatabase.Object();
            m_tocControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            if (item == esriTOCControlItem.esriTOCControlItemLegendClass)
            {
                ILegendGroup legendGroup;
                ILegendClass legendClass;
                legendGroup = other as ILegendGroup;
                Debug.Assert(legendGroup != null);
                legendClass = legendGroup.get_Class(Convert.ToInt32(index.ToString()));
                Debug.Assert(legendClass != null);
                ISymbol pSymbol = legendClass.Symbol;

                m_tocControl.SelectItem(layer, null);
                m_mapControl.CustomProperty = layer;
                QLHTDT.FormChinh.QuanTriHeThong.layer = layer;
                QLHTDT.FormChinh.QuanTriHeThong.featureLayer = layer as IFeatureLayer;
                IGeoFeatureLayer geoFeatureLayer = (IGeoFeatureLayer)featureLayer;
                //ISimpleRenderer simpleRenderer = (ISimpleRenderer)geoFeatureLayer.Renderer;
                //IUniqueValueRenderer pUniqueValueRenderer = (IUniqueValueRenderer)geoFeatureLayer.Renderer;
                //geoFeatureLayer.Renderer = (IFeatureRenderer)simpleRenderer;
                QLHTDT.SymbolForm symbolForm = new QLHTDT.SymbolForm();

                //Get the IStyleGalleryItem
                IStyleGalleryItem styleGalleryItem = null;
                //Select SymbologyStyleClass based upon feature type
                switch (QLHTDT.FormChinh.QuanTriHeThong.featureLayer.FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassMarkerSymbols, legendClass.Symbol);
                        break;
                    case esriGeometryType.esriGeometryPolyline:
                        styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassLineSymbols, legendClass.Symbol);
                        break;
                    case esriGeometryType.esriGeometryPolygon:
                        styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassFillSymbols, legendClass.Symbol);
                        break;
                }
                //Release the form
                symbolForm.Dispose();
                //QLHTDT.FormChinh.QuanTriHeThong.ActiveForm.Activate();

                if (styleGalleryItem == null) return;

                //Create a new renderer
                //simpleRenderer = new SimpleRendererClass();
                //Set its symbol from the styleGalleryItem
                legendClass.Symbol = (ISymbol)styleGalleryItem.Item;
                //Set the renderer into the geoFeatureLayer
                //geoFeatureLayer.Renderer = (IFeatureRenderer)simpleRenderer;
                QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.ActiveView.ContentsChanged();
                //Refresh the display
                QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
                //Fire contents changed event that the TOCControl listens to
                QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.ActiveView.ContentsChanged();
                //Refresh the display
                QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
        }
        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button != 2) return;
            ILayer layer = new FeatureLayerClass();
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = new MapClass();
            object other = new ESRI.ArcGIS.Geodatabase.Object();
            object index = new ESRI.ArcGIS.Geodatabase.Object();

            //Determine what kind of item is selected
            m_tocControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            if (layer != null)
            {
                ICompositeLayer igroup2 = layer as ICompositeLayer;
                if (igroup2 == null)
                {
                    if (item == esriTOCControlItem.esriTOCControlItemLayer)
                    {
                        m_tocControl.SelectItem(layer, null);
                        //Set the layer into the CustomProperty (this is used by the custom layer commands)			
                        m_mapControl.CustomProperty = layer;
                        QLHTDT.FormChinh.QuanTriHeThong.layer = layer;
                        QLHTDT.FormChinh.QuanTriHeThong.featureLayer = layer as IFeatureLayer;
                        //Popup the correct context menu
                        //if (item == esriTOCControlItem.esriTOCControlItemMap) m_menuMap.PopupMenu(e.x, e.y, m_tocControl.hWnd);
                        if (item == esriTOCControlItem.esriTOCControlItemLayer) m_menuLayer.PopupMenu(e.x, e.y, m_tocControl.hWnd);
                    }

                }
                else
                {
                    if (item == esriTOCControlItem.esriTOCControlItemMap)
                        m_tocControl.SelectItem(map, null);
                    else
                        m_tocControl.SelectItem(layer, null);

                    //Set the layer into the CustomProperty (this is used by the custom layer commands)			
                    m_mapControl.CustomProperty = layer;
                    QLHTDT.FormChinh.QuanTriHeThong.layer = layer;
                    QLHTDT.FormChinh.QuanTriHeThong.featureLayer = layer as IFeatureLayer;
                    //Popup the correct context menu
                    if (item == esriTOCControlItem.esriTOCControlItemMap) m_menuMap.PopupMenu(e.x, e.y, m_tocControl.hWnd);
                    if (item == esriTOCControlItem.esriTOCControlItemLayer) m_menuLayer.PopupMenu(e.x, e.y, m_tocControl.hWnd);
                }
            }
            else
            {
                if (item == esriTOCControlItem.esriTOCControlItemMap)
                {
                    m_tocControl.SelectItem(map, null);
                    m_menuMap.PopupMenu(e.x, e.y, m_tocControl.hWnd);
                }
            }
            //Ensure the item gets selected 

        }



        private void axPageLayoutControl1_Resize(object sender, EventArgs e)
        {
            axPageLayoutControl1.ActiveView.Refresh();
        }



        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void giớiThiệuSảnPhâprToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xuấtẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chọnCỡGiấyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChonKhoGiay frm = new ChonKhoGiay();
            frm.ShowDialog();
        }

        private void kếtNốiCơSởDữLiệuToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            QLHTDT.FormChinh.CORE.Connectdatabase.ConnectFolder();
        }
        public static void Getdataset(IWorkspace workspace, ComboBox cbo)
        {

            cbo.Items.Clear();
            IEnumDataset Emun = workspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            Emun.Reset();
            IDataset idatase = Emun.Next();
            while ((idatase != null))
            {
                cbo.Items.Add(idatase.Name);
                idatase = Emun.Next();
            }
        }
        public class _featureclass
        {
            public string name;
            public string alias;
            public IFeatureClass featureclass;
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    _Geodatabase = new QLHTDT.CORE.Geodatabase();

        //}

        private ILayer GetLayerOnvisibe1(string namef, IMap map)
        {
            string filename = QLHTDT.Properties.Settings.Default.PathData + "\\" + "Data.gdb\\" + comboBox1.SelectedItem + "\\" + namef;
            ILayer layer = QLHTDT.CORE.LoadLayer.Checklayer(filename, map);
            return layer;
        }
        private void LoadLayertoCbo2()
        {
            QLHTDT.CORE.LoadLayer.LoadFeaturelayerToCombo(Cbolop2, axMapControl1.Map);

        }

        private void kếtNốiCơSởDữLiệuToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            QLHTDT.FormChinh.CORE.Connectdatabase.ConnectFolder();
        }
        private void thôngTinNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QTHT.QLNguoiDung frm = new QLHTDT.FormPhu.QTHT.QLNguoiDung();
            //frm.show();
            frm.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void thayĐổiMậtKhẩuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QTHT.ThayDoiMK frm = new QLHTDT.FormPhu.QTHT.ThayDoiMK();
            //frm.show();
            frm.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void nhậtKíLàmViệcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QTHT.NhatKi frm = new QLHTDT.FormPhu.QTHT.NhatKi();
            //frm.show();
            frm.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tìmTheoTọaĐộĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsMapGoToCommand();
            command.OnCreate(axMapControl1.Object);
            //axMapControl1.CurrentTool = (ITool)command;
            //command.OnClick();
            axMapControl1.CurrentTool = command as ITool;
            command.OnClick();
        }

      
        private IGeographicCoordinateSystem m_GeographicCoordinateSystem;
        private IProjectedCoordinateSystem m_ProjectedCoordinateSystem;
        

        private void theoKhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ICommand command = new TruyVanKhongGian();
            //command.OnCreate(axMapControl1.Object);
            //axMapControl1.CurrentTool = command as ITool;
            //command.OnClick();
        }
        private void ảnhVệTinhToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int SoBDNen1;
            SoBDNen1 = 0;
            if (ảnhVệTinhToolStripMenuItem1.Checked == true)
            {
                for (int i = 0; i < axMapControl1.Map.LayerCount; i++)
                {
                    if (axMapControl1.Map.Layer[i].Name == "Bản đồ nền Vệ tinh")
                    {
                        SoBDNen1 = SoBDNen1 + 1;
                    }
                }
                if (SoBDNen1 == 0)
                {
                    axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Bản đồ nền Vệ tinh.lyr", axMapControl1.Map.LayerCount);
                    axMapControl1.Refresh();
                    axTOCControl1.Refresh();
                    axPageLayoutControl1.Refresh();
                }
            }
            else if (ảnhVệTinhToolStripMenuItem1.Checked == false)
            {
                for (int i = 0; i < axMapControl1.Map.LayerCount; i++)
                {
                    if (axMapControl1.Map.Layer[i].Name == "Bản đồ nền Vệ tinh")
                    {
                        axMapControl1.DeleteLayer(i);
                        axMapControl1.Refresh();

                    }
                }
            }
            Cursor = Cursors.Default;
        }

        private void ảnhGiaoThôngToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            int SoBDNen2;
            SoBDNen2 = 0;
            if (ảnhGiaoThôngToolStripMenuItem.Checked == true)
            {
                for (int i = 0; i < axMapControl1.Map.LayerCount; i++)
                {
                    if (axMapControl1.Map.Layer[i].Name == "Ảnh đường phố")
                    {
                        SoBDNen2 = SoBDNen2 + 1;
                    }
                }
                if (SoBDNen2 == 0)
                {
                    axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Nền Google\\Ảnh đường phố.lyr", axMapControl1.Map.LayerCount);
                }
            }
            if (ảnhGiaoThôngToolStripMenuItem.Checked == false)
            {
                for (int i = 0; i < axMapControl1.Map.LayerCount; i++)
                {
                    if (axMapControl1.Map.Layer[i].Name == "Ảnh đường phố")
                    {
                        axMapControl1.DeleteLayer(i);
                        axMapControl1.Refresh();

                    }
                }
            }
        }



        private void thêmTiêuĐềToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //axPageLayoutControl1.OnMouseDown -= new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(MenuPage);
            axPageLayoutControl1.CurrentTool = null;
            ICommand command = new QLHTDT.Trangin.CreateText();
            command.OnCreate(axPageLayoutControl1.Object);
            axPageLayoutControl1.CurrentTool = command as ITool;
            //command.OnClick();
        }

        private void thêmTỷLệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axPageLayoutControl1.CurrentTool = null;
            ICommand command = new QLHTDT.Trangin.CreateScaleText();
            command.OnCreate(axPageLayoutControl1.Object);
            axPageLayoutControl1.CurrentTool = command as ITool;
            //command.OnClick();
        }

        private void thêmThướcTỷLệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axPageLayoutControl1.CurrentTool = null;
            ICommand command = new QLHTDT.Trangin.CreateScaleBar();
            command.OnCreate(axPageLayoutControl1.Object);
            axPageLayoutControl1.CurrentTool = command as ITool;
            //command.OnClick();
        }

        private void thêmChúGiảiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axPageLayoutControl1.CurrentTool = null;
            IGraphicsContainer graphicsContainer = axPageLayoutControl1.GraphicsContainer;

            //Get the MapFrame
            IMapFrame mapFrame = (IMapFrame)graphicsContainer.FindFrame(axPageLayoutControl1.ActiveView.FocusMap);

            if (mapFrame == null) return;

            //Create a legend
            UID uID = new UIDClass();
            uID.Value = "esriCarto.Legend";

            //Create a MapSurroundFrame from the MapFrame
            IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uID, null);
            if (mapSurroundFrame == null) return;
            if (mapSurroundFrame.MapSurround == null) return;
            //Set the name 
            mapSurroundFrame.MapSurround.Name = "Chú thích";
            mapSurroundFrame.MapSurround.Map.Name = "Chú thích";
            ILegend legend;

            legend = mapSurroundFrame.MapSurround as ILegend;
            if (legend.ItemCount != 0)
            {
                ILegendItem legendItem = legend.get_Item(legend.ItemCount - 1);
                legend.RemoveItem(legend.ItemCount - 1);
                legend.AddItem(legendItem);
                legend.Title = "Chú thích";

                //Envelope for the legend
                IEnvelope envelope = new EnvelopeClass();
                envelope.PutCoords(1, 1, 3.4, 2.4);
                //Set the geometry of the MapSurroundFrame 
                IElement element = (IElement)mapSurroundFrame;
                //IElement element = legend as IElement;
                element.Geometry = envelope as IGeometry;

                //Add the legend to the PageLayout
                axPageLayoutControl1.AddElement(element, Type.Missing, Type.Missing, "Chú thích", 0);
                //Refresh the PageLayoutControl
                axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            //disable/enable buttons


        }

        private void thêmChỉHướngBắcNamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axPageLayoutControl1.CurrentTool = null;
            //axPageLayoutControl1.OnMouseDown -= new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(MenuPage);
            //axPageLayoutControl1.OnKeyDown += new IPageLayoutControlEvents_Ax_OnKeyDownEventHandler(ThemChiHuongBacNam);  
            ICommand command = new QLHTDT.Trangin.CreateNorthArrow();

            command.OnCreate(axPageLayoutControl1.Object);
            axPageLayoutControl1.CurrentTool = command as ITool;
            //command.OnClick();

        }
        private void ThemChiHuongBacNam(object sender, ESRI.ArcGIS.Controls.IPageLayoutControlEvents_OnKeyDownEvent e)
        {
            axPageLayoutControl1.CurrentTool = null;
            ICommand command = new QLHTDT.Trangin.CreateNorthArrow();
            command.OnCreate(axPageLayoutControl1.Object);
            axPageLayoutControl1.CurrentTool = command as ITool;
            //command.OnClick();
        }
        private void xóaChúThíchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IElement element = axPageLayoutControl1.FindElementByName("Chú thích", 1);

            if (element != null)
            {
                //Delete the legend
                IGraphicsContainer graphicsContainer = axPageLayoutControl1.GraphicsContainer;
                graphicsContainer.DeleteElement(element);
                //Refresh the display
                axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
        }

        private void thayĐổiĐốiTượngVùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 symbolForm = new Form2();

            //Get the IStyleGalleryItem that has been selected in the SymbologyControl
            IStyleGalleryItem styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassAreaPatches);

            //release the form
            symbolForm.Dispose();
            if (styleGalleryItem == null) return;

            //Find the legend
            IElement element = axPageLayoutControl1.FindElementByName("Chú thích", 1);
            if (element == null) return;

            //Get the IMapSurroundFrame
            IMapSurroundFrame mapSurroundFrame = (IMapSurroundFrame)element;
            if (mapSurroundFrame == null) return;

            //If a legend exists change the default area patch
            ILegend legend = (ILegend)mapSurroundFrame.MapSurround;
            legend.Format.DefaultAreaPatch = (IAreaPatch)styleGalleryItem.Item;

            //Update the legend
            legend.Refresh();
            //Refresh the display
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void thayĐổiĐốiTượngĐườngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 symbolForm = new Form2();

            //Get the IStyleGalleryItem that has been selected in the SymbologyControl
            IStyleGalleryItem styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassLinePatches);

            //release the form
            symbolForm.Dispose();
            if (styleGalleryItem == null) return;

            //Find the legend
            IElement element = axPageLayoutControl1.FindElementByName("Chú thích", 1);
            if (element == null) return;

            //Get the IMapSurroundFrame
            IMapSurroundFrame mapSurroundFrame = (IMapSurroundFrame)element;
            if (mapSurroundFrame == null) return;

            //If a legend exists change the default area patch
            ILegend legend = (ILegend)mapSurroundFrame.MapSurround;
            legend.Format.DefaultLinePatch = (ILinePatch)styleGalleryItem.Item;

            //Update the legend
            legend.Refresh();
            //Refresh the display
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void CpNhatDGNMoi_Click(object sender, EventArgs e)
        {
            //        ILabelEngineLayerProperties labelEngineLayerProperties = new LabelEngineLayerPropertiesClass();
            //        IAnnotateLayerProperties annotateLayerProperties = (IAnnotateLayerProperties)
            //            labelEngineLayerProperties;
            //        annotateLayerProperties.Class = "Annotation Class 1";

            //        // Get the symbol from the annotation class. Make any changes to its properties
            //        // here.
            //        ITextSymbol annotationTextSymbol = labelEngineLayerProperties.Symbol;
            //        ISymbol annotationSymbol = (ISymbol)annotationTextSymbol;

            //        // Create a symbol collection and add the default symbol from the
            //        // annotation class to the collection. Assign the resulting symbol ID
            //        // to the annotation class.
            //        ISymbolCollection symbolCollection = new SymbolCollectionClass();
            //        ISymbolCollection2 symbolCollection2 = (ISymbolCollection2)symbolCollection;
            //        ISymbolIdentifier2 symbolIdentifier2 = null;
            //        symbolCollection2.AddSymbol(annotationSymbol, "Annotation Class 1", out
            //symbolIdentifier2);
            //        labelEngineLayerProperties.SymbolID = symbolIdentifier2.ID;

            //        // Add the annotation class to a collection.
            //        IAnnotateLayerPropertiesCollection annotateLayerPropsCollection = new
            //            AnnotateLayerPropertiesCollectionClass();
            //        annotateLayerPropsCollection.Add(annotateLayerProperties);
            QLHTDT.CapNhatDGN.FrmCapNhat frm = new QLHTDT.CapNhatDGN.FrmCapNhat();
            frm.Show();
        }

        private void thêmDataFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnvelope envelope = axPageLayoutControl1.TrackRectangle();

            //Create a map frame element with a new map
            IMapFrame mapFrame = new MapFrameClass();
            mapFrame.Map = new MapClass();

            //Add the map frame to the PageLayoutControl with specified geometry
            axPageLayoutControl1.AddElement((IElement)mapFrame, envelope, null, null, 0);

            //Refresh the PageLayoutControl
            axPageLayoutControl1.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }


        private void cấpPhépXâyDựngNhaORiengLe_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QLKienTruc.CapPhepXD frm = new QLHTDT.FormPhu.QLKienTruc.CapPhepXD();
            frm.Show();
            Cursor = Cursors.Default;
        }
        private void saoLưuCơSởDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.BackUp frm = new QLHTDT.FormPhu.BackUp();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void phụcHồiCơSởDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.RestoreCSDL frm = new QLHTDT.FormPhu.RestoreCSDL();
            frm.Show();
            Cursor = Cursors.Default;
        }
        private ILayer Addlayer(IFeatureClass FeatureClass, string filename, IMap Map)
        {

            ILayer featureselectLayer;
            if (File.Exists(filename))
            {

                IWorkspaceFactory2 workspaceFactory = (IWorkspaceFactory2)new SdeWorkspaceFactoryClass();
                IFeatureWorkspace FeatureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(Settings.Default.PathData + "\\connection.sde", 0);
                ILayerFile filelayer = new LayerFileClass();
                filelayer.Open("chialo_ha");
                ILayer player = filelayer.Layer;
                IGeoFeatureLayer objGeoFeatureLayer = (IGeoFeatureLayer)player;
                objGeoFeatureLayer.FeatureClass = FeatureClass;
                player.Name = FeatureClass.AliasName;
                filelayer.Close();
                featureselectLayer = player;
                Map.AddLayer(player);
                return player;

            }
            else
            {
                IFeatureLayer pFlayer = default(IFeatureLayer);
                pFlayer = new FeatureLayer();
                pFlayer.FeatureClass = FeatureClass;
                pFlayer.Name = FeatureClass.AliasName;
                featureselectLayer = pFlayer;
                //LoadFeature(listf)
                Map.AddLayer(pFlayer);
                return pFlayer;
            }
        }


        public static void VersionedArcSdeWorkspace(string server, string instance, string user, string password, string database, string version)
        {
            //if (QLHTDT.Properties.Settings.Default.PathData == null)
            //{ QLHTDT.Properties.Settings.Default.PathData = System.IO.Directory.GetCurrentDirectory() + "\\";  }
            if (Settings.Default.PathData != null)
            {
                IPropertySet propertySet = new PropertySetClass();
                propertySet.SetProperty("SERVER", server);
                propertySet.SetProperty("INSTANCE", instance);
                propertySet.SetProperty("DATABASE", database);
                propertySet.SetProperty("USER", user);
                propertySet.SetProperty("PASSWORD", password);
                propertySet.SetProperty("VERSION", version);
                IWorkspaceFactory workspaceFactory = new SdeWorkspaceFactoryClass();
                if (System.IO.File.Exists(Settings.Default.PathData + "\\connection.bak"))
                { System.IO.File.Delete(Settings.Default.PathData + "\\connection.bak"); }
                if (System.IO.File.Exists(Settings.Default.PathData + "\\connection.sde"))
                { System.IO.File.Move((Settings.Default.PathData + "\\connection.sde"), (Settings.Default.PathData + "\\connection.bak")); }
                workspaceFactory.Create(Settings.Default.PathData, "connection.sde", propertySet, 0);
            }
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.QTHT.TTNguoiDung frm = new QLHTDT.FormPhu.QTHT.TTNguoiDung();
            frm.Show();

        }
        private void mởFileCADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog_CapNhatCAD);
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog1_FileDGNOk);
            openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
            openFileDialog1.Filter = "AutoCad Files|*.dwg; *.dxf";
            openFileDialog1.Title = "Chọn file Autocad cần mở";
            openFileDialog1.ShowDialog();


        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
            IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.CadWorkspaceFactoryClass();
            IWorkspace workspace = workspaceFactory.OpenFromFile(workspacePath, 0);
            ESRI.ArcGIS.DataSourcesFile.ICadDrawingWorkspace cadDrawingWorkspace = (ESRI.ArcGIS.DataSourcesFile.ICadDrawingWorkspace)workspace;
            ESRI.ArcGIS.DataSourcesFile.ICadDrawingDataset cadDrawingDataset = cadDrawingWorkspace.OpenCadDrawingDataset(fileName);
            ESRI.ArcGIS.Carto.ICadLayer cadLayer = new ESRI.ArcGIS.Carto.CadLayerClass();
            cadLayer.CadDrawingDataset = cadDrawingDataset;
            cadLayer.Name = fileName;
            axMapControl1.AddLayer(cadLayer, 0);
            Cursor = Cursors.Default;


            //string workspacePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
            //string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
            //IWorkspaceFactory pCadWKSFact = new CadWorkspaceFactory();
            //IWorkspace pWorkspace1 = pCadWKSFact.OpenFromFile(workspacePath, 0);
            //IFeatureWorkspace pWorkspace2 = (IFeatureWorkspace)pWorkspace1;
            //IFeatureClass pFeatureClass;
            //IFeatureDataset pFeatureDataset = pWorkspace2.OpenFeatureDataset(fileName);
            //IFeatureClassContainer pFeatureClassContainer = pFeatureDataset as IFeatureClassContainer;
            ////CadAnnotationLayer pCadFeatureLayer1;
            ////CadFeatureLayer pCadFeatureLayer2;
            //for (int i = 0; i < pFeatureClassContainer.ClassCount - 1; i++)
            //{
            //    pFeatureClass = pFeatureClassContainer.Class[i];
            //    IFeatureLayer fl = new FeatureLayer();
            //    fl.FeatureClass = pFeatureClass;
            //    var l = fl as ILayer;
            //    if (pFeatureClass.FeatureType == esriFeatureType.esriFTCoverageAnnotation)
            //    {
            //        //pCadFeatureLayer1 = pFeatureClassContainer.Class[i] as CadAnnotationLayer;
            //        l.Name = fileName + ". phụ chú";
            //        axMapControl1.AddLayer(l, 0);
            //    }
            //    else
            //    {
            //        //pCadFeatureLayer2 = pFeatureClassContainer.Class[i] as CadFeatureLayer;
            //        if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
            //        {
            //            l.Name = fileName + ". Điểm";
            //            pFeatureClassPoint = pFeatureClass;
            //            axMapControl1.AddLayer(l, 0);
            //        }
            //        else if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
            //        {
            //            l.Name = fileName + ". Vùng";
            //            pFeatureClassPolyGon = pFeatureClass;
            //            axMapControl1.AddLayer(l, 0);
            //        }
            //        else if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
            //        {
            //            l.Name = fileName + ". Đường";
            //            pFeatureClassPolyline = pFeatureClass;
            //        axMapControl1.AddLayer(l, 0);
            //        }
            //        //else
            //        //{
            //        //    l.Name = fileName + " . " + pFeatureClass.ShapeType.ToString();
            //        //    pFeatureClassMultipath = pFeatureClass;
            //        //}
            //    }
            //}
        }


        //private ICadDrawingDataset GetCadDataset(string cadWorkspacePath, string cadFileName)
        //{
        //    //Create a WorkspaceName object
        //    IWorkspaceName workspaceName = new WorkspaceNameClass();
        //    workspaceName.WorkspaceFactoryProgID = "esriDataSourcesFile.CadWorkspaceFactory";
        //    workspaceName.PathName = cadWorkspacePath;

        //    //Create a CadDrawingName object
        //    IDatasetName cadDatasetName = new CadDrawingNameClass();
        //    cadDatasetName.Name = cadFileName;
        //    cadDatasetName.WorkspaceName = workspaceName;

        //    //Open the CAD drawing
        //    IName name = (IName)cadDatasetName;
        //    return (ICadDrawingDataset)name.Open();
        //}
        private void ZoomToLayers()
        {
            ICommand command = new ControlsZoomToSelectedCommand();
            command.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = command as ITool;
            command.OnClick();
        }

        public static DataTable tt;
        public static DataRow dr;
        private void TraCuuNhanhQH_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ICommand command = new ControlsClearSelectionCommand();
            command.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = command as ITool;
            command.OnClick();

            if (layeredit != null)
            {
                IFeatureLayer pFeatureLayer2 = (IFeatureLayer)layeredit;
                IFeatureSelection featSelect = pFeatureLayer2 as IFeatureSelection;
                IQueryFilter pFilter = new QueryFilterClass();
                EnvelopeClass pEnvelope = new EnvelopeClass();
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("Thông báo", "Chưa chọn phường cần tra cứu");

                }
                else if (comboBox2.Text != "")
                {
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        pFilter.WhereClause = "[SoToBD] = '" + textBox1.Text + "' AND [SoThua] = '" + textBox2.Text + "'";
                        featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);

                    }
                    else if (textBox1.Text != "" && textBox2.Text == "")
                    {
                        pFilter.WhereClause = "[SoToBD] = '" + textBox1.Text + "'";
                        featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                    }
                    else if (textBox1.Text == "" && textBox2.Text != "")
                    {
                        pFilter.WhereClause = "[SoThua] = '" + textBox2.Text + "'";
                        featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn số tờ bản đồ hoặc số thửa đất cần tra cứu", "Thông báo");
                    }
                    ZoomToLayers();
                }
                IEnumIDs idList = featSelect.SelectionSet.IDs;
                int index = idList.Next();
                List<int> indexes = new List<int>();
                while (index != -1)
                {
                    indexes.Add(index);
                    index = idList.Next();
                }
                IFeatureClass featureClass = pFeatureLayer2.FeatureClass;
                tt = new DataTable();
                tt.Columns.Add("Mã", typeof(String));
                tt.Columns.Add("Chủ sử dụng", typeof(String));
                tt.Columns.Add("Số tờ bản đồ", typeof(String));
                tt.Columns.Add("Số thửa", typeof(String));
                tt.Columns.Add("Diện tích", typeof(String));
                tt.Columns.Add("Địa chỉ", typeof(String));
                tt.Columns.Add("Tình trạng pháp lý", typeof(String));
                tt.Columns.Add("Thông tin quy hoạch", typeof(String));
                tt.Columns.Add("Phường", typeof(String));
                tt.Columns.Add("Loại đất", typeof(String));
                tt.Columns.Add("TenKhuVuc", typeof(String));
                tt.Columns.Add("TangCaoXD", typeof(String));
                tt.Columns.Add("ChiGioiXD", typeof(String));
                tt.Columns.Add("ChieuCaoTang", typeof(String));
                tt.Columns.Add("CotNen", typeof(String));
                tt.Columns.Add("QDKhac", typeof(String));
                tt.Columns.Add("SoGPXD", typeof(String));
                tt.Columns.Add("TTCPXD", typeof(String));
                tt.Columns.Add("MaHSCPXD", typeof(String));
                if (featSelect.SelectionSet.Count == 0) { MessageBox.Show("Không có thửa đất nào", "Thông báo"); }
                for (int i2 = 0; i2 < featSelect.SelectionSet.Count; i2++)
                {
                    IFeature feature = featureClass.GetFeature(indexes[i2]);
                    dr = tt.NewRow();
                    dr[0] = feature.get_Value(feature.Fields.FindField("OBJECTID")).ToString();
                    if (feature.get_Value(feature.Fields.FindField("ChuSD")) != DBNull.Value)
                    {
                        dr[1] = feature.get_Value(feature.Fields.FindField("ChuSD")).ToString();
                    }
                    if (feature.get_Value(feature.Fields.FindField("SoToBD")) != DBNull.Value)
                    {
                        dr[2] = feature.get_Value(feature.Fields.FindField("SoToBD")).ToString();
                    }
                    if (feature.get_Value(feature.Fields.FindField("SoThua")) != DBNull.Value)
                    {
                        dr[3] = feature.get_Value(feature.Fields.FindField("SoThua")).ToString();
                    }
                    if (feature.get_Value(feature.Fields.FindField("DienTich")) != DBNull.Value)
                    {
                        dr[4] = feature.get_Value(feature.Fields.FindField("DienTich")).ToString();
                    }
                    if (feature.get_Value(feature.Fields.FindField("DiaChi")) != DBNull.Value)
                    {
                        dr[5] = feature.get_Value(feature.Fields.FindField("DiaChi")).ToString();
                    }
                    if (feature.get_Value(feature.Fields.FindField("TTPL")) != DBNull.Value)
                    {
                        dr[6] = feature.get_Value(feature.Fields.FindField("TTPL")).ToString();
                    }
                    if (feature.get_Value(feature.Fields.FindField("KhuQH")) != DBNull.Value)
                    {
                        dr[7] = feature.get_Value(feature.Fields.FindField("KhuQH")).ToString();
                    }
                    if (feature.get_Value(feature.Fields.FindField("TenPhuong")) != DBNull.Value)
                    {
                        dr[8] = feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString();
                    }
                    if (feature.get_Value(feature.Fields.FindField("LoaiDat")) != DBNull.Value)
                    {
                        dr[9] = feature.get_Value(feature.Fields.FindField("LoaiDat")).ToString();
                    }
                    if (feature.get_Value(feature.Fields.FindField("MaKVKT")) != DBNull.Value)
                    {

                        string MaKT = feature.get_Value(feature.Fields.FindField("MaKVKT")).ToString().Replace(" ", "");
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "SELECT [TenKhuVuc] FROM [GIS].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                        SqlCommand command1 = new SqlCommand(sql1, conn);
                        if (command1.ExecuteScalar() != DBNull.Value)
                        {
                            dr[10] = (string)command1.ExecuteScalar();
                        }
                        string sql2 = "SELECT [TangCaoXD] FROM [GIS].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                        SqlCommand command2 = new SqlCommand(sql2, conn);
                        if (command2.ExecuteScalar() != DBNull.Value)
                        {
                            dr[11] = (string)command2.ExecuteScalar();
                        }
                        string sql3 = "SELECT [ChiGioiXD] FROM [GIS].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                        SqlCommand command3 = new SqlCommand(sql3, conn);
                        if (command3.ExecuteScalar() != DBNull.Value)
                        {
                            dr[12] = (string)command3.ExecuteScalar();
                        }
                        string sql4 = "SELECT [ChieuCaoTang] FROM [GIS].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                        SqlCommand command4 = new SqlCommand(sql4, conn);
                        if (command4.ExecuteScalar() != DBNull.Value)
                        {
                            dr[13] = (string)command4.ExecuteScalar();
                        }
                        string sql5 = "SELECT [CotNen] FROM [GIS].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                        SqlCommand command5 = new SqlCommand(sql5, conn);
                        if (command5.ExecuteScalar() != DBNull.Value)
                        {
                            dr[14] = (string)command5.ExecuteScalar();
                        }
                        string sql6 = "SELECT [QDKhac] FROM [GIS].[dbo]." + tableKT + " where MaKV = '" + MaKT + "'";
                        SqlCommand command6 = new SqlCommand(sql6, conn);
                        if (command6.ExecuteScalar() != DBNull.Value)
                        {
                            dr[15] = (string)command6.ExecuteScalar();
                        }
                    }
                    string sql = "SELECT [SoQD] FROM CPXD WHERE [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "' and [Phuong] =N'" + feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString() + "' and ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + feature.get_Value(feature.Fields.FindField("SoToBD")).ToString() + "' and [SoThua] ='" + feature.get_Value(feature.Fields.FindField("SoThua")).ToString() + "')";
                    SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    SqlCommand commanCPXD = new SqlCommand(sql, connection);
                    commanCPXD.Connection.Open();
                    string SoGPXD = "";
                    if (commanCPXD.ExecuteScalar() != DBNull.Value)
                    {
                        SoGPXD = (string)commanCPXD.ExecuteScalar();
                        if (SoGPXD != "" & SoGPXD != null)
                        {
                            SoGPXD = (string)commanCPXD.ExecuteScalar();
                            dr[16] = SoGPXD;
                            dr[17] = "Thửa đất đã được cấp phép xây dựng - GPXD số " + SoGPXD;
                            SqlCommand commanMaHSCPXD = new SqlCommand("SELECT [MaHS] FROM [HTDTCAMLE].[dbo].[CPXD] WHERE [SoQD] = '" + SoGPXD + "'", connection);
                            commanCPXD.Connection.Close();
                            commanMaHSCPXD.Connection.Open();
                            dr[18] = (string)commanMaHSCPXD.ExecuteScalar();
                            commanMaHSCPXD.Connection.Close();
                        }
                        else { dr[17] = "Chưa có thông tin cấp phép xây dựng."; commanCPXD.Connection.Close(); }
                    }
                    else { dr[17] = "Chưa có thông tin cấp phép xây dựng."; commanCPXD.Connection.Close(); }





                    tt.Rows.Add(dr);
                    //IField field = feature.Fields.Field[feature.Fields.FindField("Shape")];
                    //IGeometryDef geometryDef = field.GeometryDef;

                    //IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;

                    //geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
                }


                if (featSelect.SelectionSet.Count > 1)
                {
                    if (frm1Thua != null)
                    {
                        frm1Thua.Close();
                    }
                    if (frmNhieuThua != null)
                    {
                        frmNhieuThua.Close();
                        frmNhieuThua = new QLHTDT.FormPhu.FormChiTietLayer.FrmThuaDat2(tt, pFeatureLayer2);
                        frmNhieuThua.Show();
                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        frmNhieuThua = new QLHTDT.FormPhu.FormChiTietLayer.FrmThuaDat2(tt, pFeatureLayer2);
                        frmNhieuThua.Show();
                        Cursor = Cursors.Default;
                    }
                }
                else if (featSelect.SelectionSet.Count == 1)
                {
                    if (frmNhieuThua != null)
                    {
                        frmNhieuThua.Close();
                    }
                    if (frm1Thua != null)
                    {
                        frm1Thua.Close();
                        frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(tt);
                        frm1Thua.Show();
                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(tt);
                        frm1Thua.Show();
                        Cursor = Cursors.Default;
                    }

                }

            }
            else { MessageBox.Show("Chưa chọn phường cần tra cứu", "Thông báo"); }
            Cursor = Cursors.Default;
            axMapControl1.Map.MapScale = axMapControl1.Map.MapScale * 4;
            axMapControl1.ActiveView.Refresh();
        }

        private void tùyChỉnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_CustomizeDialog.StartDialog(axToolbarControl1.hWnd);
        }
        private void thanhCôngCụCơbảnToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (côngCụCơBảnToolStripMenuItem.Checked == false)
            //axToolbarControl1.Visible = false;
            {
                for (int i = axToolbarControl1.Count - 1; i >= 0; i--)
                {
                    IToolbarItem toolbarItem = axToolbarControl1.GetItem(i);
                    IToolbarMenu toolbarMenu = toolbarItem.Menu;
                    if (toolbarMenu == null)
                    {
                        string c = toolbarItem.Command.Caption;
                        if (c == "Mở bản đồ" || c == "Mở trang mới" || c == "Lưu" || c == "Open" || c == "Add Data..." || c == "Map Scale" || c == "Select Elements" || c == "Go To &XY..." || c == "Zoom In" || c == "Zoom Out" || c == "Pan" || c == "Full Extent" || c == "Go Back To Previous Extent" || c == "Go To Next Extent" || c == "Identify" || c == "&Find..." || c == "Measure" || c == "Truy vấn không gian")
                        {
                            axToolbarControl1.Remove(i);
                        }
                    }

                }
            }
            else
            {
                axToolbarControl1.AddItem(new CreateNewDocument(), 1, 0, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem(new QLHTDT.FormChinh.Button.Save(), -1, 1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem(new QLHTDT.FormChinh.Button.MoLop(), -1, 2, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsAddDataCommand", -1, 3, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsMapZoomToolControl", -1, 4, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsSelectTool", -1, 5, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsMapGoToCommand", -1, 6, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsMapZoomInTool", -1, 7, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsMapZoomOutTool", -1, 8, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsMapPanTool", -1, 9, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsMapFullExtentCommand", -1, 10, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsMapZoomToLastExtentBackCommand", -1, 11, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsMapZoomToLastExtentForwardCommand", -1, 12, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsMapIdentifyTool", -1, 13, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsMapFindCommand", -1, 14, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem("esriControls.ControlsMapMeasureTool", -1, 15, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                //axToolbarControl1.AddItem(new TruyVanKhongGian(), -1, 16, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            }
        }
        private void côngCụTrangInToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (côngCụChỉnhSửaTrangInToolStripMenuItem.Checked == false)
                axToolbarControl5.Visible = false;
            else
            {
                axToolbarControl5.Visible = true;
                if (axToolbarControl1.Visible == true)
                {
                    axToolbarControl5.Location = new System.Drawing.Point(0, 49);
                }
            }
        }
        private void côngCụCậpNhậtDữLiệuToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (côngCụChỉnhSửaDữLiệuToolStripMenuItem.Checked == false)
            {
                for (int i = axToolbarControl1.Count - 1; i >= 0; i--)
                {
                    IToolbarItem toolbarItem = axToolbarControl1.GetItem(i);
                    IToolbarMenu toolbarMenu = toolbarItem.Menu;
                    if (toolbarMenu == null)
                    {
                        string c = toolbarItem.Command.Caption;
                        if (c == "Target Layer" || c == "Undo" || c == "Redo")
                        {
                            axToolbarControl1.Remove(i);
                        }
                    }
                    else
                    {
                        if (toolbarMenu.Caption == "Edit" || toolbarMenu.Caption == "Select")
                        { axToolbarControl1.Remove(i); }
                    }
                }

            }
            else
            {
                axToolbarControl1.AddMenuItem(ChonDoiTuong, 17, true, 1);
                axToolbarControl1.AddItem(new QLHTDT.FormChinh.Button.Undo(), -1, 18, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddItem(new QLHTDT.FormChinh.Button.Redo(), -1, 19, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
                axToolbarControl1.AddMenuItem(ToolChinhSua, -1, true, 1);
                axToolbarControl1.AddItem("esriControls.ControlsEditingTargetToolControl", -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            }
        }
        private void thêmLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.AddpointFromXY frm = new QLHTDT.FormPhu.AddpointFromXY();
            frm.ShowDialog();
        }
        private void thToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.ThongKe.TKChinh frm = new QLHTDT.FormPhu.ThongKe.TKChinh();
            frm.Show();

        }
        private void lưuToolToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void SaveToolbarControl1()
        {
            //Create a MemoryBlobStream 
            IBlobStream blobStream = new MemoryBlobStreamClass();
            //Get the IStream interface
            IStream stream = (IStream)blobStream;
            //Get the IToolbarControl2 interface
            IToolbarControl2 toolbarControl = (IToolbarControl2)axToolbarControl1.Object;

            //Save the ToolbarControl into the stream
            toolbarControl.SaveItems(stream);
            //Save the stream to a file
            blobStream.SaveToFile(m_filePath);
        }
        private void LoadToolbarControl()
        {
            if (System.IO.File.Exists(m_filePath) == true)
            {
                //Create a MemoryBlobStream
                IBlobStream blobStream = new MemoryBlobStreamClass();
                //Get the IStream interface
                IStream stream = (IStream)blobStream;
                //Get the IToolbarControl2 interface;
                IToolbarControl2 toolbarControl = (IToolbarControl2)axToolbarControl1.Object;

                //Load the stream from the file
                blobStream.LoadFromFile(m_filePath);
                //Load the stream into the ToolbarControl
                toolbarControl.LoadItems(stream);
            }
        }
        private void repositoryItemCheckEdit1_Click(object sender, EventArgs e)
        {
            {
                Cursor = Cursors.WaitCursor;
                int DaMo;
                DaMo = 0;
                string pathlayer = "";
                string Namelayer = "";
                TreeListMultiSelection selectedNodes = treeList1.Selection;

                if ((sender as DevExpress.XtraEditors.CheckEdit).Checked == true)
                {
                    for (int i = 0; i < axMapControl1.LayerCount; i++)
                    {

                        if (axMapControl1.get_Layer(i).Name == selectedNodes[0].GetValue(treeList1.Columns[0]).ToString())
                        {
                            DaMo = DaMo + 1;
                            axMapControl1.Extent = axMapControl1.get_Layer(i).AreaOfInterest;
                        }
                    }
                    if (DaMo == 0)
                    {
                        bool thaydoi = false;
                        int Level = selectedNodes[0].Level;

                        //tạo theo số lớp con (selectedNodes[0] là node đã chọn, lever 0 là layer đầu tiên, 1 nằm trong con, 2 nằm trong 1, ... thêm 1 lớp con là thêm 1 parentNode, e 1 folder.
                        if (Level == 0) { } // k tạo sự kiện mở lớp tổng ở ngoài
                        else if (Level == 1)
                        {
                            pathlayer = Settings.Default.PathData + "\\" + selectedNodes[0].ParentNode.GetValue(treeList1.Columns[0]).ToString() + "\\" + selectedNodes[0].GetValue(treeList1.Columns[0]).ToString() + ".lyr";
                            Namelayer = selectedNodes[0].GetValue(treeList1.Columns[0]).ToString();
                        }
                        else if (Level == 2)
                        {
                            pathlayer = Settings.Default.PathData + "\\" + selectedNodes[0].ParentNode.ParentNode.GetValue(treeList1.Columns[0]).ToString() + "\\" + selectedNodes[0].ParentNode.GetValue(treeList1.Columns[0]).ToString() + "\\" + selectedNodes[0].GetValue(treeList1.Columns[0]).ToString() + ".lyr";
                            Namelayer = selectedNodes[0].GetValue(treeList1.Columns[0]).ToString();
                        }
                        else if (Level == 3)
                        {
                            pathlayer = Settings.Default.PathData + "\\" + selectedNodes[0].ParentNode.ParentNode.ParentNode.GetValue(treeList1.Columns[0]).ToString() + "\\" + selectedNodes[0].ParentNode.ParentNode.GetValue(treeList1.Columns[0]).ToString() + "\\" + selectedNodes[0].ParentNode.GetValue(treeList1.Columns[0]).ToString() + "\\" + selectedNodes[0].GetValue(treeList1.Columns[0]).ToString() + ".lyr";
                            Namelayer = selectedNodes[0].GetValue(treeList1.Columns[0]).ToString();
                        }
                        if (System.IO.File.Exists(pathlayer)) //Kiểm tra có file theo đường dẫn trong folder CSDL.
                        {
                            if (Namelayer == "Bản đồ nền Vệ tinh" || Namelayer == "Bản đồ nền giao thông") //Phân biệt lớp ảnh vệ tinh, giao thông với lớp featureClass
                            {
                                axMapControl1.AddLayerFromFile(pathlayer, axMapControl1.Map.LayerCount);
                                axMapControl1.get_Layer(axMapControl1.LayerCount - 1).Cached = (true);
                                axMapControl1.Refresh();
                                if (tabControl1.SelectedIndex == 1)
                                {
                                    CopyToPageLayout();
                                    axPageLayoutControl1.ActiveView.Refresh();
                                }
                            }
                            else
                            {
                                axMapControl1.AddLayerFromFile(pathlayer);
                                axMapControl1.Extent = axMapControl1.get_Layer(0).AreaOfInterest;
                                axMapControl1.get_Layer(0).Cached = (true);
                                axMapControl1.Refresh();
                                ICompositeLayer igroupLayer = axMapControl1.get_Layer(0) as ICompositeLayer;
                                var newWorkspaceName = (IWorkspaceName)((IDataset)(FeatureWorkspace as IWorkspace)).FullName;
                                IPropertySet props2 = newWorkspaceName.ConnectionProperties;
                                if (igroupLayer == null)
                                {
                                    ILayer L = axMapControl1.get_Layer(0);
                                    IFeatureLayer ftLayer = L as IFeatureLayer;
                                    IFeatureClass ftClass = ftLayer.FeatureClass;
                                    try
                                    {
                                        if (ftClass == null) // kiểm tra xem featureClass có bị null. sai kết nối db không
                                        {
                                            var dataLayer = (ESRI.ArcGIS.Carto.IDataLayer)L;
                                            var datasetName = (IDatasetName)dataLayer.DataSourceName;
                                            thaydoi = true;
                                            datasetName.WorkspaceName = newWorkspaceName;
                                            dataLayer.DataSourceName = (IName)datasetName;
                                            L = (ESRI.ArcGIS.Carto.ILayer)dataLayer;
                                        }
                                    }
                                    catch
                                    {
                                        //MessageBox.Show(ex.Message);
                                    }

                                }
                                else
                                {
                                    for (int i1 = 0; i1 < igroupLayer.Count; i1++)
                                    {
                                        ICompositeLayer igroup1 = igroupLayer.get_Layer(i1) as ICompositeLayer;
                                        if (igroup1 == null)
                                        {
                                            ILayer Li = igroup1.get_Layer(i1);
                                            IFeatureLayer ftLayer = Li as IFeatureLayer;
                                            IFeatureClass ftClass = ftLayer.FeatureClass;
                                            if (ftClass == null)
                                            {
                                                var dataLayer1 = (ESRI.ArcGIS.Carto.IDataLayer)Li;
                                                var datasetName1 = (IDatasetName)dataLayer1.DataSourceName;
                                                thaydoi = true;
                                                datasetName1.WorkspaceName = newWorkspaceName;
                                                dataLayer1.DataSourceName = (IName)datasetName1;
                                                Li = (ESRI.ArcGIS.Carto.ILayer)dataLayer1;

                                            }
                                        }
                                        else
                                        {
                                            for (int i2 = 0; i2 < igroup1.Count; i2++)
                                            {
                                                ICompositeLayer igroup2 = igroup1.get_Layer(i2) as ICompositeLayer;
                                                if (igroup2 == null)
                                                {
                                                    ILayer Li = igroup2.get_Layer(i2);
                                                    IFeatureLayer ftLayer = Li as IFeatureLayer;
                                                    IFeatureClass ftClass = ftLayer.FeatureClass;
                                                    if (ftClass == null)
                                                    {
                                                        var dataLayer1 = (ESRI.ArcGIS.Carto.IDataLayer)Li;
                                                        var datasetName1 = (IDatasetName)dataLayer1.DataSourceName;
                                                        thaydoi = true;
                                                        datasetName1.WorkspaceName = newWorkspaceName;
                                                        dataLayer1.DataSourceName = (IName)datasetName1;
                                                        Li = (ESRI.ArcGIS.Carto.ILayer)dataLayer1;

                                                    }
                                                }
                                                else
                                                {
                                                    for (int i3 = 0; i3 < igroup2.Count; i3++)
                                                    {
                                                        ILayer Li = igroup2.get_Layer(i3);
                                                        IFeatureLayer ftLayer = Li as IFeatureLayer;
                                                        IFeatureClass ftClass = ftLayer.FeatureClass;
                                                        if (ftClass == null)
                                                        {
                                                            var dataLayer1 = (ESRI.ArcGIS.Carto.IDataLayer)Li;
                                                            var datasetName1 = (IDatasetName)dataLayer1.DataSourceName;
                                                            thaydoi = true;
                                                            datasetName1.WorkspaceName = newWorkspaceName;
                                                            dataLayer1.DataSourceName = (IName)datasetName1;
                                                            Li = (ESRI.ArcGIS.Carto.ILayer)dataLayer1;

                                                        }
                                                    }

                                                }
                                            }

                                        }
                                    }
                                }
                                if (thaydoi == true)
                                {
                                    if (System.IO.File.Exists(pathlayer))
                                    {
                                        System.IO.File.Delete(pathlayer);
                                    }
                                    ILayerFile layerFile = new LayerFileClass();
                                    layerFile.New(pathlayer);
                                    object customProperty = null;
                                    m_mapControl.CustomProperty = igroupLayer;
                                    customProperty = m_mapControl.CustomProperty;
                                    layerFile.ReplaceContents((ILayer)customProperty);
                                    layerFile.Save();
                                }
                            }

                        }
                        else if (pathlayer != "") { MessageBox.Show("Chưa có dữ liệu, xin vui lòng cập nhật CSDL", "Thông báo"); }
                    }



                }
                else
                {
                    int x = axMapControl1.LayerCount;
                    for (int i = x - 1; i >= 0; i--)
                    {
                        if (axMapControl1.get_Layer(i).Name == selectedNodes[0].GetValue(treeList1.Columns[0]).ToString())
                        {
                            axMapControl1.Map.DeleteLayer(axMapControl1.get_Layer(i));
                            axMapControl1.Refresh();
                            if (tabControl1.SelectedIndex == 1)
                            { CopyToPageLayout(); axPageLayoutControl1.ActiveView.Refresh(); }
                            LoadLayertoCbo2();
                        }
                    }
                }
                Cursor = Cursors.Default;
            }
        }
        private void ChọnPhuongTraCuuQH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string txtDAQH = "";
            string layerget = "";
            string layerGT = "";
            int KTMoLopGT = 0;
            string layerKH = "";
            int KTMoLopKH = 0;
            string layerRGQH = "";
            int KTMoLopDAQH = 0;
            string layerRGHC = "";
            int KTMoLopRGHC = 0;
            if (comboBox2.Text == "Hòa An")
            { txtDAQH = comboBox2.Text; layerget = "Chia lô - HA"; layerGT = "Đường chính - HA"; layerKH = "Kiệt hẻm - HA"; layerRGQH = "Ranh giới quy hoạch - HA"; layerRGHC = "Ranh giới hành chính"; tableKT = "KienTruc_HA"; }
            else if (comboBox2.Text == "Hòa Phát")
            { txtDAQH = comboBox2.Text; layerget = "Chia lô - HP"; layerGT = "Đường chính - HP"; layerKH = "Kiệt hẻm - HP"; layerRGQH = "Ranh giới quy hoạch - HP"; layerRGHC = "Ranh giới hành chính"; tableKT = "KienTruc_HP"; }
            else if (comboBox2.Text == "Hòa Thọ Tây")
            { txtDAQH = comboBox2.Text; layerget = "Chia lô - HTT"; layerGT = "Đường chính - HTT"; layerKH = "Kiệt hẻm - HTT"; layerRGQH = "Ranh giới quy hoạch - HTT"; layerRGHC = "Ranh giới hành chính"; tableKT = "KienTruc_HTT"; }
            else if (comboBox2.Text == "Hòa Thọ Đông")
            { txtDAQH = comboBox2.Text; layerget = "Chia lô - HTD"; layerGT = "Đường chính - HTD"; layerKH = "Kiệt hẻm - HTD"; layerRGQH = "Ranh giới quy hoạch - HTD"; layerRGHC = "Ranh giới hành chính"; tableKT = "KienTruc_HTD"; }
            else if (comboBox2.Text == "Hòa Xuân")
            { txtDAQH = comboBox2.Text; layerget = "Chia lô - HX"; layerGT = "Đường chính - HX"; layerKH = "Kiệt hẻm - HX"; layerRGQH = "Ranh giới quy hoạch - HX"; layerRGHC = "Ranh giới hành chính"; tableKT = "KienTruc_HX"; }
            else if (comboBox2.Text == "Khuê Trung")
            { txtDAQH = comboBox2.Text; layerget = "Chia lô - KT"; layerGT = "Đường chính - KT"; layerKH = "Kiệt hẻm - KT"; layerRGQH = "Ranh giới quy hoạch - KT"; layerRGHC = "Ranh giới hành chính"; tableKT = "KienTruc_KT"; }
            int KTMoLop = 0;
            string PhuongKT = null;
            try
            {
                PhuongKT = comboBox2.Text;
                for (int i1 = 0; i1 < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i1++)
                {
                    if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1).Name == comboBox2.Text)
                    {
                        ICompositeLayer igroup1 = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.Layer[i1] as ICompositeLayer;
                        for (int i = 0; i < igroup1.Count; i++)
                        {
                            ILayer ilayer1 = igroup1.get_Layer(i) as ILayer;
                            if (ilayer1.Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                layeredit = ilayer1;
                                axMapControl1.Extent = layeredit.AreaOfInterest;
                            }
                            if (ilayer1.Name == layerGT)
                            {
                                KTMoLopGT = KTMoLopGT + 1;
                            }
                            if (ilayer1.Name == layerKH)
                            {
                                KTMoLopKH = KTMoLopKH + 1;
                            }
                            if (ilayer1.Name == layerRGHC)
                            {
                                KTMoLopRGHC = KTMoLopRGHC + 1;
                            }
                            if (ilayer1.Name == layerRGQH)
                            {
                                KTMoLopDAQH = KTMoLopDAQH + 1;
                            }
                        }
                    }
                    else
                    {
                        if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1).Name == layerget)
                        {
                            KTMoLop = KTMoLop + 1;
                            layeredit = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1);
                            axMapControl1.Extent = axMapControl1.get_Layer(i1).AreaOfInterest;
                        }
                        else if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1).Name == layerGT)
                        {
                            KTMoLopGT = KTMoLopGT + 1;
                        }
                        else if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1).Name == layerKH)
                        {
                            KTMoLopKH = KTMoLopKH + 1;
                        }
                        else if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1).Name == layerRGHC)
                        {
                            KTMoLopRGHC = KTMoLopRGHC + 1;
                        }
                        else if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1).Name == layerRGQH)
                        {
                            KTMoLopDAQH = KTMoLopDAQH + 1;
                        }
                        //if (tabControl1.SelectedIndex == 1)
                        //{ CopyToPageLayout(); axPageLayoutControl1.ActiveView.Refresh(); }
                    }
                }
                if (KTMoLop == 0)
                {
                    QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + layerget + ".lyr");
                    QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();


                    for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
                    {
                        if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == layerget)
                        {
                            KTMoLop = KTMoLop + 1;
                            layeredit = FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i);
                            axMapControl1.Extent = axMapControl1.get_Layer(i).AreaOfInterest;
                        }
                    }
                    if (KTMoLopGT == 0)
                    {
                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + layerGT + ".lyr");
                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();
                    }
                    if (KTMoLopKH == 0)
                    {
                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + layerKH + ".lyr");
                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();
                    }
                    if (KTMoLopRGHC == 0)
                    {
                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Lớp khác\\" + layerRGHC + ".lyr");
                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();
                    }
                    if (KTMoLopDAQH == 0)
                    {
                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + layerRGQH + ".lyr");
                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();
                    }
                    //if (tabControl1.SelectedIndex == 1)
                    //{ CopyToPageLayout(); axPageLayoutControl1.ActiveView.Refresh(); }
                }
                CopyToPageLayout(); axPageLayoutControl1.ActiveView.Refresh();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            Cursor = Cursors.Default;
        }


        private void traCứuHồSơQuyHoạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QLQH.QLHS frm = new QLHTDT.FormPhu.QLQH.QLHS();
            frm.Show();
            Cursor = Cursors.Default;
        }
        private void xuấtBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public static void CreateFeature(IFeatureClass featureClass, IFeature Polygon)
        {
            if (featureClass.ShapeType != esriGeometryType.esriGeometryPolygon)
            {
                return;
            }
            IFeature feature = featureClass.CreateFeature();
            feature.Shape = Polygon.Shape;
            ISubtypes subtypes = (ISubtypes)featureClass;
            IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
            if (subtypes.HasSubtype)
            {
                rowSubtypes.SubtypeCode = 3;
            }
            rowSubtypes.InitDefaultValues();
            int contractorFieldIndex = featureClass.FindField("SoToBD");
            feature.set_Value(contractorFieldIndex, "999");
            feature.Store();

        }


        private void KiemTraDGNmoi(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (Settings.Default.pathDGN != "")
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Settings.Default.pathDGN);
                // Một mảng các thư mục con.
                DirectoryInfo[] childDirs = dirInfo.GetDirectories();
                // Mảng các file nằm trong thư mục.
                DataTable dtDGNmoi = new DataTable();
                dtDGNmoi = new DataTable();
                dtDGNmoi.Columns.Add("STT", typeof(int));
                dtDGNmoi.Columns.Add("TenFile", typeof(String));
                dtDGNmoi.Columns.Add("NgayCN", typeof(String));
                dtDGNmoi.Columns.Add("NgayTao", typeof(String));
                DataRow drDGNmoi;
                int i = 1;
                foreach (DirectoryInfo childDir in childDirs)
                {
                    FileInfo[] childFiles = childDir.GetFiles("*.dgn");
                    //MessageBox.Show(" - Directory: " + childDir.FullName, "Thông báo");
                    foreach (FileInfo childFile in childFiles)
                    {
                        var date = DateTime.Now;
                        if (childFile.LastWriteTime.Day == date.Day && childFile.LastWriteTime.Month == date.Month && childFile.LastWriteTime.Year == date.Year)
                        {
                            //MessageBox.Show("File: " + childFile.Name + " Thời gian chỉnh sửa cuối cùng " + childFile.LastWriteTime, "Thông báo");
                            drDGNmoi = dtDGNmoi.NewRow();
                            drDGNmoi[0] = i;
                            drDGNmoi[1] = childFile.FullName;
                            drDGNmoi[2] = childFile.LastWriteTime;
                            drDGNmoi[3] = childFile.CreationTime;
                            dtDGNmoi.Rows.Add(drDGNmoi);
                            i = i + 1;
                        }
                    }
                }
                QLHTDT.test.TableDGNmoi frm = new QLHTDT.test.TableDGNmoi(dtDGNmoi);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Chọn thư mục lưu file DGN", "Thông báo");
                FolderBrowserDialog openfd = new FolderBrowserDialog();
                openfd.ShowNewFolderButton = true;
                openfd.SelectedPath = QLHTDT.Properties.Settings.Default.pathDGN;
                openfd.Description = "Chọn thư mục lưu file DGN";
                if (openfd.ShowDialog() == DialogResult.OK)
                {

                    QLHTDT.Properties.Settings.Default.pathDGN = @openfd.SelectedPath;
                    QLHTDT.Properties.Settings.Default.Save();
                    DirectoryInfo dirInfo = new DirectoryInfo(Settings.Default.pathDGN);
                    // Một mảng các thư mục con.
                    DirectoryInfo[] childDirs = dirInfo.GetDirectories();
                    // Mảng các file nằm trong thư mục.
                    DataTable dtDGNmoi = new DataTable();
                    dtDGNmoi = new DataTable();
                    dtDGNmoi.Columns.Add("STT", typeof(int));
                    dtDGNmoi.Columns.Add("TenFile", typeof(String));
                    dtDGNmoi.Columns.Add("NgayCN", typeof(String));
                    dtDGNmoi.Columns.Add("NgayTao", typeof(String));
                    DataRow drDGNmoi;
                    int i = 1;
                    foreach (DirectoryInfo childDir in childDirs)
                    {
                        FileInfo[] childFiles = childDir.GetFiles("*.dgn");
                        //MessageBox.Show(" - Directory: " + childDir.FullName, "Thông báo");
                        foreach (FileInfo childFile in childFiles)
                        {
                            var date = DateTime.Now;
                            if (childFile.LastWriteTime.Day == date.Day && childFile.LastWriteTime.Month == date.Month && childFile.LastWriteTime.Year == date.Year)
                            {
                                //MessageBox.Show("File: " + childFile.Name + " Thời gian chỉnh sửa cuối cùng " + childFile.LastWriteTime, "Thông báo");
                                drDGNmoi = dtDGNmoi.NewRow();
                                drDGNmoi[0] = i;
                                drDGNmoi[1] = childFile.FullName;
                                drDGNmoi[2] = childFile.LastWriteTime;
                                drDGNmoi[3] = childFile.CreationTime;
                                dtDGNmoi.Rows.Add(drDGNmoi);
                                i = i + 1;
                            }
                        }
                    }
                    QLHTDT.test.TableDGNmoi frm = new QLHTDT.test.TableDGNmoi(dtDGNmoi);
                    frm.Show();
                }
            }
            Cursor = Cursors.Default;
        }
        private void myWatcher_Changed(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.test.FrmCapNhat frm = new test.FrmCapNhat();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QLQH.QLCapCCQH frm = new QLHTDT.FormPhu.QLQH.QLCapCCQH();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void traCứuThôngTinKiếnTrúcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QLKienTruc.TCTTKT frm = new QLHTDT.FormPhu.QLKienTruc.TCTTKT();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void cậpNhậtToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void chuyểnHệTọaĐộFileDWGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(QLHTDT.Properties.Settings.Default.PathData + "\\Maptrans.exe");
        }

        private void cậpNhậtDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog_CapNhatCAD);
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
            openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog_CapNhatCAD);
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog1_FileDGNOk);
            openFileDialog1.Filter = "AutoCad Files, DGN file|*.dwg; *.dxf; *.dgn|All Files|*.*";
            openFileDialog1.Title = "Chọn file Autocad cần mở";
            openFileDialog1.ShowDialog();
        }
        IFeatureClass pFeatureClassPoint;
        IFeatureClass pFeatureClassPolyline;
        IFeatureClass pFeatureClassPolyGon;
        IFeatureClass pFeatureClassMultipath;
        private void openFileDialog_CapNhatCAD(object sender, CancelEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
            IWorkspaceFactory pCadWKSFact = new CadWorkspaceFactory();
            IWorkspace pWorkspace1 = pCadWKSFact.OpenFromFile(workspacePath, 0);
            IFeatureWorkspace pWorkspace2 = (IFeatureWorkspace)pWorkspace1;
            IFeatureClass pFeatureClass;
            IFeatureDataset pFeatureDataset = pWorkspace2.OpenFeatureDataset(fileName);
            IFeatureClassContainer pFeatureClassContainer = pFeatureDataset as IFeatureClassContainer;
            //CadAnnotationLayer pCadFeatureLayer1;
            //CadFeatureLayer pCadFeatureLayer2;
            for (int i = 0; i < pFeatureClassContainer.ClassCount - 1; i++)
            {
                pFeatureClass = pFeatureClassContainer.Class[i];
                IFeatureLayer fl = new FeatureLayer();
                fl.FeatureClass = pFeatureClass;
                var l = fl as ILayer;
                if (pFeatureClass.FeatureType == esriFeatureType.esriFTCoverageAnnotation)
                {
                    //pCadFeatureLayer1 = pFeatureClassContainer.Class[i] as CadAnnotationLayer;
                    l.Name = fileName + ". phụ chú";
                    //axMapControl1.AddLayer(l, 0);
                }
                else
                {
                    //pCadFeatureLayer2 = pFeatureClassContainer.Class[i] as CadFeatureLayer;
                    if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                    {
                        l.Name = fileName + ". Điểm";
                        pFeatureClassPoint = pFeatureClass;
                    }
                    else if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                    {
                        l.Name = fileName + ". Vùng";
                        pFeatureClassPolyGon = pFeatureClass;
                    }
                    else if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                    {
                        l.Name = fileName + ". Đường";
                        pFeatureClassPolyline = pFeatureClass;
                    }
                    else
                    {
                        l.Name = fileName + " . " + pFeatureClass.ShapeType.ToString();
                        pFeatureClassMultipath = pFeatureClass;
                    }
                    //axMapControl1.AddLayer(l, 0);

                }
            }
            QLHTDT.FormPhu.CapNhat.CapNhatCad frm = new QLHTDT.FormPhu.CapNhat.CapNhatCad(pFeatureClassPoint, pFeatureClassPolyline, pFeatureClassPolyGon, pFeatureClassMultipath, fileName, pWorkspace1);
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void mởFileMicrostationdgnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog_CapNhatCAD);
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
            openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog1_FileDGNOk);
            openFileDialog1.Filter = "MicroStation file| *.dgn";
            openFileDialog1.Title = "Chọn file MicroStation cần mở";
            openFileDialog1.ShowDialog();
        }
        private void openFileDialog1_FileDGNOk(object sender, CancelEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
            IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.CadWorkspaceFactoryClass();
            IWorkspace workspace = workspaceFactory.OpenFromFile(workspacePath, 0);
            ESRI.ArcGIS.DataSourcesFile.ICadDrawingWorkspace cadDrawingWorkspace = (ESRI.ArcGIS.DataSourcesFile.ICadDrawingWorkspace)workspace;
            ESRI.ArcGIS.DataSourcesFile.ICadDrawingDataset cadDrawingDataset = cadDrawingWorkspace.OpenCadDrawingDataset(fileName);
            ESRI.ArcGIS.Carto.ICadLayer cadLayer = new ESRI.ArcGIS.Carto.CadLayerClass();
            cadLayer.CadDrawingDataset = cadDrawingDataset;
            cadLayer.Name = fileName;
            axMapControl1.AddLayer(cadLayer, 0);
            Cursor = Cursors.Default;

            //string workspacePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
            //string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
            //IWorkspaceFactory pCadWKSFact = new CadWorkspaceFactory();
            //IWorkspace pWorkspace1 = pCadWKSFact.OpenFromFile(workspacePath, 0);
            //IFeatureWorkspace pWorkspace2 = (IFeatureWorkspace)pWorkspace1;
            //IFeatureClass pFeatureClass;
            //IFeatureDataset pFeatureDataset = pWorkspace2.OpenFeatureDataset(fileName);
            //IFeatureClassContainer pFeatureClassContainer = pFeatureDataset as IFeatureClassContainer;
            ////CadAnnotationLayer pCadFeatureLayer1;
            ////CadFeatureLayer pCadFeatureLayer2;
            //for (int i = 0; i < pFeatureClassContainer.ClassCount - 1; i++)
            //{
            //    pFeatureClass = pFeatureClassContainer.Class[i];
            //    IFeatureLayer fl = new FeatureLayer();
            //    fl.FeatureClass = pFeatureClass;
            //    var l = fl as ILayer;
            //    if (pFeatureClass.FeatureType == esriFeatureType.esriFTCoverageAnnotation)
            //    {
            //        //pCadFeatureLayer1 = pFeatureClassContainer.Class[i] as CadAnnotationLayer;
            //        l.Name = fileName + ". phụ chú";
            //        axMapControl1.AddLayer(l, 0);
            //    }
            //    else
            //    {
            //        //pCadFeatureLayer2 = pFeatureClassContainer.Class[i] as CadFeatureLayer;
            //        if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
            //        {
            //            l.Name = fileName + ". Điểm";
            //            pFeatureClassPoint = pFeatureClass;
            //            axMapControl1.AddLayer(l, 0);
            //        }
            //        else if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
            //        {
            //            l.Name = fileName + ". Vùng";
            //            pFeatureClassPolyGon = pFeatureClass;
            //            axMapControl1.AddLayer(l, 0);
            //        }
            //        else if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
            //        {
            //            l.Name = fileName + ". Đường";
            //            pFeatureClassPolyline = pFeatureClass;
            //            axMapControl1.AddLayer(l, 0);
            //        }
            //    }
            //}
        }

        private void exportToCADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.Export.ExportToCAD frmExportCAD = new QLHTDT.FormPhu.Export.ExportToCAD();
            frmExportCAD.Show();
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //ChangeCoordinateSystem1();

        }
        public void SnapGrid(IActiveView activeView)
        {
            IPageLayout pageLayout = activeView as IPageLayout;
            IMap map = activeView.FocusMap;
            IMeasuredGrid measuredGrid = new MeasuredGridClass();
            IMapGrid mapGrid = measuredGrid as IMapGrid;

            //Set the IMeasuredGrid properties.
            //Origin coordinates and interval sizes are in map units.
            measuredGrid.FixedOrigin = true;
            measuredGrid.Units = map.MapUnits;
            measuredGrid.XIntervalSize = 500; //Meridian interval.
            measuredGrid.XOrigin = 0;
            measuredGrid.YIntervalSize = 500; //Parallel interval.
            measuredGrid.YOrigin = 0;

            //Set the IProjectedGrid properties.
            IProjectedGrid projectedGrid = measuredGrid as IProjectedGrid;
            projectedGrid.SpatialReference = map.SpatialReference;
            IGraphicsContainer graphicsContainer = pageLayout as IGraphicsContainer;
            IFrameElement frameElement = graphicsContainer.FindFrame(map);
            IMapFrame mapFrame = frameElement as IMapFrame;
            IMapGrids mapGrids = null;
            mapGrids = mapFrame as IMapGrids;
            mapGrids.AddMapGrid(mapGrid);


            //label
            stdole.StdFont standardFont = new stdole.StdFont();
            stdole.IFontDisp fontDisp = standardFont as stdole.IFontDisp;
            fontDisp.Bold = false;
            fontDisp.Name = "Arial";
            fontDisp.Italic = false;
            fontDisp.Underline = false;
            fontDisp.Size = 5;
            // Create grid label.
            IGridLabel gridLabel = new FormattedGridLabelClass();

            gridLabel.Font = fontDisp;
            gridLabel.Color = BuildRGB(0, 0, 0);
            //Specify vertical labels.


            gridLabel.set_LabelAlignment(esriGridAxisEnum.esriGridAxisLeft, false);
            gridLabel.set_LabelAlignment(esriGridAxisEnum.esriGridAxisRight, false);
            gridLabel.LabelOffset = 3;


            mapGrid.LabelFormat = gridLabel as IGridLabel;
            activeView.PartialRefresh(esriViewDrawPhase.esriViewBackground, null, null);

        }

        public void CreateRoundBoxTabStyleGridLabel()
        {
            IIndexGridTabStyle indexGridTabStyle = new BackgroundTabStyleClass();

            //Set IBackgroundTabStyle properties.
            IBackgroundTabStyle backgroundTabStyle = indexGridTabStyle as
              IBackgroundTabStyle;
            backgroundTabStyle.BackgroundType =
              esriBackgroundTabType.esriBackgroundTabRound;
        }
        public IColor BuildRGB(Int32 red, Int32 green, Int32 blue)
        {
            IRgbColor rgbColor = new RgbColorClass();
            rgbColor.Red = red;
            rgbColor.Green = green;
            rgbColor.Blue = blue;
            rgbColor.UseWindowsDithering = true;
            return rgbColor;
        }
        //private static IPolygon GeoJsonToEsriPolygon(string geoJson)
        //{
        //       var poly = JsonConvert.DeserializeObject<PolygonGeoJson>(geoJson);
        //    var convertedPoly = GeojsonToEsriJson(poly);

        //    var jsonReader = new JSONReaderClass();
        //    jsonReader.ReadFromString(convertedPoly);
        //    var jsonDeserializer = new JSONDeserializerGdbClass();
        //    jsonDeserializer.InitDeserializer(jsonReader, null);
        //    IGeometry geometry = ((IExternalDeserializerGdb)jsonDeserializer).ReadGeometry(esriGeometryType.esriGeometryPolygon);
        //    IPolygon newPolygon = (IPolygon)geometry;
        //    return newPolygon;
        //}
        //private static string GeojsonToEsriJson(PolygonGeoJson poly)
        //{
        //    var convertedPoly = ConvertGeoJsonCoordsToEsriCoords(poly);

        //    var esriJsonObject = new EsriPolygonJsonObject
        //    {
        //        spatialReference = new SpatialReference(4326),
        //        rings = convertedPoly.coordinates
        //    };

        //    var outputString = JsonConvert.SerializeObject(esriJsonObject);

        //    return outputString;
        //}
        private static bool IsClockwise(List<List<double>> ringToTest)
        {
            var output = false;

            double total = 0;
            int i = 0;
            List<double> pt1 = ringToTest[i];
            List<double> pt2;

            for (i = 0; i < ringToTest.Count - 1; i++)
            {
                pt2 = ringToTest[i + 1];
                total += (pt2[0] - pt1[0]) * (pt2[1] + pt1[1]);
                pt1 = pt2;
            }
            return (total >= 0);
        }
        //private static PolygonGeoJson ConvertGeoJsonCoordsToEsriCoords(PolygonGeoJson poly)
        //{
        //    for (int i = 0; i <= poly.coordinates.Count - 1; i++)
        //    {
        //        // if the outer polygon isn't clock wise reverse the order of the coordinates.
        //        if (i == 0 && !IsClockwise(poly.coordinates[i]))
        //        {
        //            poly.coordinates[i].Reverse();
        //            continue;
        //        }
        //        // if the holes in the polygon are not counter-clockwise then revese the order.
        //        if (i > 0 && IsClockwise(poly.coordinates[i]))
        //        {
        //            poly.coordinates[i].Reverse();
        //        }

        //    }
        //    return poly;
        //}
        public class SpatialReference
        {
            public SpatialReference(int id)
            {
                this.wkid = id;
            }
            public int wkid { get; set; }
        }
        //public class EsriPolygonJsonObject
        //{
        //    public SpatialReference spatialReference { get; set; }
        //    public List<List<List<double>>> rings { get; set; }
        //}
        //public class MultiPolygonGeoJson
        //{
        //    public string type { get; set; }
        //    public List<List<List<List<double>>>> coordinates { get; set; }
        //}
        //public class PolygonGeoJson : GeoJsonBaseObject
        //{
        //    public string type { get; set; }
        //    public List<List<List<double>>> coordinates { get; set; }
        //}
        //public class GeoJsonBaseObject
        //{
        //    public string type { get; set; }

        //    public List<object> coordinates;
        //}
        //private static IPolygon EsriJsonToEsriPolygon(string esriJson)
        //{
        //    var jsonReader = new JSONReaderClass();
        //    jsonReader.ReadFromString(esriJson);
        //    var jsonDeserializer = new JSONDeserializerGdbClass();
        //    jsonDeserializer.InitDeserializer(jsonReader, null);
        //    IGeometry geometry = ((IExternalDeserializerGdb)jsonDeserializer).ReadGeometry(esriGeometryType.esriGeometryPolygon);
        //    IPolygon newPolygon = (IPolygon)geometry;


        //    ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = axMapControl1.ActiveView.ScreenDisplay;

        //    // Ve
        //    screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache); // Explicit Cast
        //    ESRI.ArcGIS.Display.IRgbColor rgbColor = new ESRI.ArcGIS.Display.RgbColorClass();
        //    rgbColor.Red = 255;
        //    ESRI.ArcGIS.Display.IColor color = rgbColor; // Implicit cast.
        //    ESRI.ArcGIS.Display.ISimpleFillSymbol simpleFillSymbol = new ESRI.ArcGIS.Display.SimpleFillSymbolClass();
        //    simpleFillSymbol.Color = color;
        //    ESRI.ArcGIS.Display.ISymbol symbol = simpleFillSymbol as ESRI.ArcGIS.Display.ISymbol;
        //    screenDisplay.SetSymbol(symbol);
        //    screenDisplay.DrawPolygon(geometry);
        //    screenDisplay.FinishDrawing();
        //    //
        //    ISpatialReferenceFactory3 pSRgen = new SpatialReferenceEnvironmentClass();
        //   var pSR = pSRgen.CreateESRISpatialReferenceFromPRJFile(@"D:\sinh\file HTD vn2000 prj\DaNang.prj");
        //    newPolygon.SpatialReference = pSR;

        //    string strFolder = @"C:\Users\sinhn\Desktop\New Folder (2)\New folder (2)";
        //    string strName = "MyShapeFile";
        //    string strShapeFieldName  = "Shape";
        //    IFeatureWorkspace pFWS ;
        //    IWorkspaceFactory pWorkspaceFactory ;
        //     pWorkspaceFactory = new ShapefileWorkspaceFactory();
        //    pFWS = pWorkspaceFactory.OpenFromFile(strFolder, 0) as IFeatureWorkspace;

        //    IFields pFields ;
        //    IFieldsEdit pFieldsEdit ;
        //    pFields = new ESRI.ArcGIS.Geodatabase.Fields();
        //    pFieldsEdit = pFields as IFieldsEdit;


        //    IField pField ;
        //    IFieldEdit pFieldEdit ;

        //    pField = new ESRI.ArcGIS.Geodatabase.Field();
        //    pFieldEdit = pField as IFieldEdit;
        //    //pFieldEdit.Name = strShapeFieldName;
        //    //pFieldEdit.Type = esriFieldTypeGeometry;


        //    IGeometryDef pGeomDef  ;
        //    IGeometryDefEdit pGeomDefEdit ;
        //    pGeomDef = new GeometryDef();
        //    pGeomDefEdit = pGeomDef as IGeometryDefEdit;
        //    //pGeomDefEdit.GeometryfType = esriGeometryPolygon;
        //    //pGeomDefEdit.SpatialReference = new UnknownCoordinateSystem();
        //    pFieldEdit.GeometryDef_2 = pGeomDef;
        //    pFieldsEdit.AddField(pField);
        //    pField = new ESRI.ArcGIS.Geodatabase.Field();
        //    pFieldEdit = pField as IFieldEdit;
        //    //pFieldEdit.Length = 30;
        //    //pFieldEdit.Name = "MiscText";
        //    //pFieldEdit.Type = ESRI.ArcGIS.Geodatabase.esriFieldType.esriFieldTypeString;
        //    pFieldsEdit.AddField(pField);
        //    IFeatureClass pFeatClass;
        //    pFeatClass = pFWS.CreateFeatureClass(strName, pFields, null , null, ESRI.ArcGIS.Geodatabase.esriFeatureType.esriFTSimple, strShapeFieldName, "");



        //    return newPolygon;

        //}

        private void giớiThiệuSảnPhâprToolStripMenuItem_Click_1(object sender, EventArgs e)
        {



            //var josnData = File.ReadAllText(@"C:\Users\sinhn\Desktop\New Folder (2)\t1.json");
            //string jsonGeometryPoint = "{\"x\" : -118.15, \"y\" : 33.80, \"spatialReference\" : {\"wkid\" : 4326}}";
            //IJSONReader jsonReader = new JSONReaderClass();
            //jsonReader.ReadFromString(jsonGeometryPoint);
            //IJSONDeserializer jsonDeserializer = new JSONDeserializerGdbClass();
            //jsonDeserializer.InitDeserializer(jsonReader, null);
            //IGeometry geometry = ((IExternalDeserializerGdb)jsonDeserializer).ReadGeometry(esriGeometryType.esriGeometryPoint);
            //IPoint pointt = (IPoint)geometry;
            //string a = geometry.SpatialReference.Name.ToString(); double aa = pointt.X;
            //string b = a;
            //EsriJsonToEsriPolygon(josnData);
            //BtnDownload_Click("http://117.2.120.9:4000/BanDoGiay/HP/DAHP25.png", System.IO.Path.GetTempPath(), "TrangIn.png");


        }


        private void BtnDownload_Click(string link, string path, string name)
        {
            //Cursor = Cursors.WaitCursor;
            //WebClient webClient = new WebClient();
            //webClient.DownloadFile(link, path + "\\"+name);
            //Cursor = Cursors.Default;
        }
        public System.Boolean CreateJPEGHiResolutionFromActiveView(ESRI.ArcGIS.Carto.IActiveView activeView, System.String pathFileName)
        {
            //parameter check
            if (activeView == null || !(pathFileName.EndsWith(".jpg")))
            { return false; }
            ESRI.ArcGIS.Output.IExport export = new ESRI.ArcGIS.Output.ExportJPEGClass();
            export.ExportFileName = pathFileName;
            //System.Int32 screenResolution = 48;
            System.Int32 outputResolution = 50;

            export.Resolution = outputResolution;

            ESRI.ArcGIS.esriSystem.tagRECT exportRECT; // This is a structure
            exportRECT.left = 0;
            exportRECT.top = 0;
            exportRECT.right = activeView.ExportFrame.right * 1 / 2;
            exportRECT.bottom = activeView.ExportFrame.bottom * 1 / 2;

            // Set up the PixelBounds envelope to match the exportRECT
            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            envelope.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);
            export.PixelBounds = envelope;

            System.Int32 hDC = export.StartExporting();

            activeView.Output(hDC, (System.Int16)export.Resolution, ref exportRECT, null, null); // Explicit Cast and 'ref' keyword needed 
            export.FinishExporting();
            export.Cleanup();

            return true;
        }


        //public static void ChuyenDoiProjectRaster(IRasterDataset2 rasterDataset, ISpatialReference outSR, esriSRGeoTransformation2Type geoTrans)
        //{
        //    //This example shows how to specify a datum transformation when projecting raster data.
        //    //rasterDataset—Represents input of a raster dataset that has a known spatial reference.
        //    //outSR—Represents the spatial reference of the output raster dataset.
        //    //geoTrans—Represents the geotransformation between the input and output spatial reference.
        //    //Set output spatial reference.
        //    IRaster raster = rasterDataset.CreateFullRaster();
        //    IRasterProps rasterProps = (IRasterProps)raster;
        //    rasterProps.SpatialReference = outSR;
        //    //Specify the geotransformation.
        //    ISpatialReferenceFactory2 srFactory = new SpatialReferenceEnvironmentClass();
        //    IGeoTransformation geoTransformation = (IGeoTransformation)srFactory.CreateGeoTransformation((int)geoTrans);
        //    //Add to the geotransformation operation set.
        //    IGeoTransformationOperationSet operationSet = new GeoTransformationOperationSetClass();
        //    operationSet.Set(esriTransformDirection.esriTransformForward, geoTransformation);
        //    operationSet.Set(esriTransformDirection.esriTransformReverse, geoTransformation);
        //    //Set the geotransformation on the raster.
        //    IRaster2 raster2 = (IRaster2)raster;
        //    raster2.GeoTransformations = operationSet;
        //    //Save the result.
        //    ISaveAs saveas = (ISaveAs)raster;
        //    saveas.SaveAs(@"c:\temp\outputRaster.img", null, "IMAGINE Image");
        //}

        //public void ChangeCoordinateSystem1()
        //{

        //    Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
        //    System.Object obj = Activator.CreateInstance(factoryType);
        //    ISpatialReferenceFactory2 pSRF = obj as ISpatialReferenceFactory2;
        //    IProjectedCoordinateSystem2 pPCSout = new ESRI.ArcGIS.Geometry.ProjectedCoordinateSystemClass();
        //    IProjectedCoordinateSystem pPCSin = new ESRI.ArcGIS.Geometry.ProjectedCoordinateSystemClass();
        //    //pPCSin = (IProjectedCoordinateSystem2)pSRF.CreateProjectedCoordinateSystem((int)esriSRProjCS2Type.esriSRProjCS_VN2000_UTMZone48N);
        //    pPCSin = CreateProjectedCoordinateSystem();
        //    pPCSout = (IProjectedCoordinateSystem2)pSRF.CreateProjectedCoordinateSystem((int)esriSRProjCS2Type.esriSRProjCS_WGS1984WorldMercator);
        //    IGeographicCoordinateSystem2 pGCSfrom = (IGeographicCoordinateSystem2)pPCSout.GeographicCoordinateSystem;
        //    IGeographicCoordinateSystem2 pGCSto = (IGeographicCoordinateSystem2)pPCSin.GeographicCoordinateSystem;
        //    ICoordinateFrameTransformation pCFT = new CoordinateFrameTransformationClass();
        //    pCFT.PutParameters(191.90441429, 39.30318279, 111.45032835, -0.00928836, 0.01975479, -0.00427372, -0.252906278);
        //    pCFT.PutSpatialReferences(pGCSfrom, pGCSto);
        //    pCFT.Name = "Custom GeoTran";
        //    IGeoTransformationOperationSet pGTSet = pSRF.GeoTransformationDefaults;
        //    pGTSet.Set(esriTransformDirection.esriTransformForward, pCFT);
        //    pGTSet.Set(esriTransformDirection.esriTransformReverse, pCFT);
        //}

        //private IProjectedCoordinateSystem CreateProjectedCoordinateSystem()
        //{
        //    Type factoryType2 = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
        //    System.Object obj2 = Activator.CreateInstance(factoryType2);
        //    ISpatialReferenceFactory2 spatialReferenceFactory = obj2 as ISpatialReferenceFactory2;
        //    //Create a projection, GeographicCoordinateSystem, and unit using the factory.
        //    IProjectionGEN projection = spatialReferenceFactory.CreateProjection((int)esriSRProjectionType.esriSRProjection_GaussKruger) as IProjectionGEN;
        //    IGeographicCoordinateSystem geographicCoordinateSystem = spatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCS2Type.esriSRGeoCS_VN2000);
        //    ILinearUnit unit = spatialReferenceFactory.CreateUnit((int)esriSRUnitType.esriSRUnit_Meter) as ILinearUnit;

        //    //Get the default parameters from the projection.
        //    IParameter[] parameters = projection.GetDefaultParameters();
        //    IParameter centralMeridian = parameters[2];
        //    centralMeridian.Value = 107.75;
        //    //IParameter falseEasting = parameters[0];
        //    parameters[0].Value = 500000;
        //    parameters[1].Value = 0;
        //    parameters[3].Value = 0.9999;
        //    parameters[4].Value = 0;
        //    //projectedCoordinateSystem.Changed();
        //    IProjectedCoordinateSystemEdit projectedCoordinateSystemEdit = new ProjectedCoordinateSystemClass();
        //    object name = "Vn2000 107.75 3 Do";
        //    object alias = "Vn2000 107.75 3 Do";
        //    object abbreviation = "NF";
        //    object remarks = "VN2000 Đà Nẵng múi 3";
        //    object usage = "Sử dụng cho bản đồ Đà Nẵng";
        //    object geographicCoordinateSystemObject = geographicCoordinateSystem as object;
        //    object unitObject = unit as object;
        //    object projectionObject = projection as object;
        //    object parametersObject = parameters as object;

        //    projectedCoordinateSystemEdit.Define(ref name,
        //                                      ref alias,
        //                                      ref abbreviation,
        //                                      ref remarks,
        //                                      ref usage,
        //                                      ref geographicCoordinateSystemObject,
        //                                      ref unitObject,
        //                                      ref projectionObject,
        //                                      ref parametersObject);
        //    axMapControl1.ActiveView.FocusMap.SpatialReference = (projectedCoordinateSystemEdit as IProjectedCoordinateSystem) as ISpatialReference;
        //    return projectedCoordinateSystemEdit as IProjectedCoordinateSystem;
        //}
        //public static void setHeToaDo(string HTD,string MuiChieu,string Do,string DonVi,string coordinate)
        //{
        //    Type factoryType2 = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
        //    System.Object obj2 = Activator.CreateInstance(factoryType2);
        //    ISpatialReferenceFactory2 spatialReferenceFactory = obj2 as ISpatialReferenceFactory2;
        //    //Create a projection, GeographicCoordinateSystem, and unit using the factory.
        //    IProjectionGEN projection = spatialReferenceFactory.CreateProjection((int)esriSRProjectionType.esriSRProjection_TransverseMercator) as IProjectionGEN;
        //    IGeographicCoordinateSystem geographicCoordinateSystem = spatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCS2Type.esriSRGeoCS_VN2000);
        //    if (HTD == "VN2000")
        //    {
        //        projection = spatialReferenceFactory.CreateProjection((int)esriSRProjectionType.esriSRProjection_TransverseMercator) as IProjectionGEN;
        //        geographicCoordinateSystem = spatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCS2Type.esriSRGeoCS_VN2000);
        //    }
        //    else if (HTD == "UTM-INDIAN75")
        //    {
        //        projection = spatialReferenceFactory.CreateProjection((int)esriSRProjectionType.esriSRProjection_TransverseMercator) as IProjectionGEN;
        //        geographicCoordinateSystem = spatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_Indian1975);
        //    }
        //    else if (HTD == "UTM-INDIAN75")
        //    {

        //    }
        //        //Đơn vị hiển thị
        //        ILinearUnit unit = spatialReferenceFactory.CreateUnit((int)esriSRUnitType.esriSRUnit_Meter) as ILinearUnit;
        //    //Get the default parameters from the projection.
        //    IParameter[] parameters = projection.GetDefaultParameters();
        //    IParameter centralMeridian = parameters[2];
        //    centralMeridian.Value = int.Parse(MuiChieu);
        //    parameters[0].Value = 500000;
        //    parameters[1].Value = 0;
        //    parameters[3].Value = int.Parse(Do);
        //    parameters[4].Value = 0;
        //    //projectedCoordinateSystem.Changed();
        //    IProjectedCoordinateSystemEdit projectedCoordinateSystemEdit = new ProjectedCoordinateSystemClass();
        //    object name = HTD +" "+ MuiChieu + " " + Do;
        //    object alias = HTD + " " + MuiChieu + " " + Do;
        //    object abbreviation = "NF";
        //    object remarks = "VN2000 Đà Nẵng múi 3";
        //    object usage = "Sử dụng cho bản đồ "+ HTD + " " + MuiChieu + " " + Do; ;
        //    object geographicCoordinateSystemObject = geographicCoordinateSystem as object;
        //    object unitObject = unit as object;
        //    object projectionObject = projection as object;
        //    object parametersObject = parameters as object;

        //    projectedCoordinateSystemEdit.Define(ref name, ref alias, ref abbreviation,  ref remarks, ref usage,  ref geographicCoordinateSystemObject,  ref unitObject, ref projectionObject, ref parametersObject);
        //    QuanTriHeThong.axMapControl1.ActiveView.FocusMap.SpatialReference = (projectedCoordinateSystemEdit as IProjectedCoordinateSystem) as ISpatialReference;


        //}

        private void thêmLướiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SnapGrid(axPageLayoutControl1.ActiveView);
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogAnhBDGiay = new System.Windows.Forms.OpenFileDialog();
            openFileDialogAnhBDGiay.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogAnhBDGiay_FileOk);
            openFileDialogAnhBDGiay.Filter = "Ảnh|*.png; *.jpg; *.tif; *.tiff; *.bmp; *.img";
            openFileDialogAnhBDGiay.Title = "Chọn file ảnh bản đồ giấy cần cập nhật";
            openFileDialogAnhBDGiay.ShowDialog();

        }
        int DiemNanAnh; double x1 = 0; double y1 = 0; double x2 = 0; double y2 = 0;
        IPointCollection sourcePoints;
        IPointCollection targetPoints;
        public static string AnhBDNan;
        private void openFileDialogAnhBDGiay_FileOk(object sender, CancelEventArgs e)
        {
            sourcePoints = new MultipointClass();
            targetPoints = new MultipointClass();
            Cursor = Cursors.WaitCursor;
            DiemNanAnh = 0;
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialogAnhBDGiay.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialogAnhBDGiay.FileName);
            IRasterLayer rasterLayer = new RasterLayer();
            rasterLayer.CreateFromFilePath(openFileDialogAnhBDGiay.FileName);
            axMapControl1.AddLayer(rasterLayer);
            string pathRaster = openFileDialogAnhBDGiay.FileName;
            AnhBDNan = openFileDialogAnhBDGiay.FileName;
            QLHTDT.FormPhu.CapNhat.FrmNanAnh frmNanAnh = new FormPhu.CapNhat.FrmNanAnh(pathRaster);
            Cursor = Cursors.Default;
            axMapControl1.OnMouseDown -= new IMapControlEvents2_Ax_OnMouseDownEventHandler(HienMenuMap);
            axMapControl1.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(MousedownNanAnh);
            ICommand command = new ControlsSelectTool();
            command.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = command as ITool;
            frmNanAnh.Show();
            //e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##")
        }
        private void MousedownNanAnh(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                //ICommand command = new ControlsSelectTool();
                //command.OnCreate(axMapControl1.Object);
                //ITool toool = command as ITool;
                //ITool TX = axMapControl1.CurrentTool;
                //Type a = axMapControl1.CurrentTool.GetType();
                //Type a2 = toool.GetType();
                //if (TX.GetType() == toool.GetType())
                //{
                if (DiemNanAnh == 0 | DiemNanAnh % 2 == 0)
                {
                    if (x2 != Convert.ToDouble(e.mapX.ToString("#######.##")))
                    {
                        x1 = Convert.ToDouble(e.mapX.ToString("#######.##"));
                        y1 = Convert.ToDouble(e.mapY.ToString("#######.##"));
                        DiemNanAnh = DiemNanAnh + 1;
                    }

                }
                else if (x1 != Convert.ToDouble(e.mapX.ToString("#######.##")))
                {
                    x2 = Convert.ToDouble(e.mapX.ToString("#######.##"));
                    y2 = Convert.ToDouble(e.mapY.ToString("#######.##"));
                    DiemNanAnh = DiemNanAnh + 1;
                    QLHTDT.FormPhu.CapNhat.FrmNanAnh.drNanAnh = QLHTDT.FormPhu.CapNhat.FrmNanAnh.dtNanAnh.NewRow();
                    QLHTDT.FormPhu.CapNhat.FrmNanAnh.drNanAnh[0] = QLHTDT.FormPhu.CapNhat.FrmNanAnh.dtNanAnh.Rows.Count + 1;
                    QLHTDT.FormPhu.CapNhat.FrmNanAnh.drNanAnh[1] = x1;
                    QLHTDT.FormPhu.CapNhat.FrmNanAnh.drNanAnh[2] = y1;
                    QLHTDT.FormPhu.CapNhat.FrmNanAnh.drNanAnh[3] = x2;
                    QLHTDT.FormPhu.CapNhat.FrmNanAnh.drNanAnh[4] = y2;
                    QLHTDT.FormPhu.CapNhat.FrmNanAnh.dtNanAnh.Rows.Add(QLHTDT.FormPhu.CapNhat.FrmNanAnh.drNanAnh);

                    IGraphicsContainer graphicsContainer = axMapControl1.ActiveView.FocusMap as IGraphicsContainer;
                    IElement element = new MarkerElementClass();
                    IElement element2 = new TextElementClass();
                    IMarkerElement CircleElement = element as IMarkerElement;
                    ITextElement textElement = element2 as ITextElement;
                    IPoint point = new PointClass();
                    point.X = x2;
                    point.Y = y2;
                    IPoint point2 = new PointClass();
                    point2.X = x2 + 1;
                    point2.Y = y2 + 1;
                    element.Geometry = point;
                    element2.Geometry = point2;
                    textElement.Symbol.Size = 5;
                    ISimpleMarkerSymbol smpMrk = new SimpleMarkerSymbol();
                    smpMrk.Size = 10;
                    smpMrk.Style = esriSimpleMarkerStyle.esriSMSCross;
                    //Create a Color for the Mask -Red 
                    IRgbColor rgbClr = new RgbColor();
                    rgbClr.Red = 255;
                    rgbClr.Green = 0;
                    rgbClr.Blue = 0;
                    //Create a Fill Symbol for the Mask 
                    ISimpleFillSymbol smpFill = new SimpleFillSymbol();
                    smpFill.Color = rgbClr;
                    smpFill.Style = esriSimpleFillStyle.esriSFSSolid;
                    //Create a MultiLayerMarkerSymbol
                    IMultiLayerMarkerSymbol multiLyrMrk = new MultiLayerMarkerSymbol();
                    //Add the simple marker to the MultiLayer 
                    multiLyrMrk.AddLayer(smpMrk);
                    //Create a Mask for the MultiLayerMarkerSymbol 
                    IMask mrkMask = (IMask)multiLyrMrk;
                    mrkMask.MaskSymbol = smpFill;
                    mrkMask.MaskStyle = esriMaskStyle.esriMSHalo;
                    CircleElement.Symbol = multiLyrMrk;
                    textElement.Text = QLHTDT.FormPhu.CapNhat.FrmNanAnh.dtNanAnh.Rows.Count.ToString();
                    graphicsContainer.AddElement(element, 0);
                    graphicsContainer.AddElement(element2, 0);
                    IActiveView activeView = axMapControl1.ActiveView.FocusMap as IActiveView;
                    activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                }
                //}
            }

            if (e.button == 2)
            {

                ICommand command = new ControlsMapPanTool();
                command.OnCreate(axMapControl1.Object);
                ITool toool = command as ITool;
                if (ToolPrevious != null)
                {
                    if (axMapControl1.CurrentTool == toool2 && toool != ToolPrevious)
                    { axMapControl1.CurrentTool = ToolPrevious; ToolPrevious = null; }
                    else { m_ToolbarMenuMap.PopupMenu(e.x, e.y, axMapControl1.hWnd); }
                }
                else { m_ToolbarMenuMap.PopupMenu(e.x, e.y, axMapControl1.hWnd); }
            }
            if (e.button == 4)
            {
                if (axMapControl1.CurrentTool != null)
                {
                    x = 0; y = 0; ee = null;
                    ToolPrevious = axMapControl1.CurrentTool;
                    ICommand command = new ControlsMapPanTool();
                    command.OnCreate(axMapControl1.Object);
                    axMapControl1.CurrentTool = command as ITool;
                    //command.OnClick();
                    toool2 = axMapControl1.CurrentTool;
                    x = e.x; y = e.y; ee = e;
                    //axMapControl1.CurrentTool.OnMouseDown(1, e.shift, axMapControl1.Width / 2, axMapControl1.Height / 2);
                }
                else
                {
                    x = 0; y = 0; ee = null;
                    ICommand command = new ControlsMapPanTool();
                    command.OnCreate(axMapControl1.Object);
                    axMapControl1.CurrentTool = command as ITool;
                    //command.OnClick();
                    //HienMenuMap(sender, e);
                    x = e.x; y = e.y;
                    ee = e;
                    //axMapControl1.CurrentTool.OnMouseDown(1, e.shift, axMapControl1.Width / 2, axMapControl1.Height / 2);
                }
            }
            //object missing = Type.Missing;
            ////thêm điểm nắn tại ảnh
            //IPoint point = new PointClass();
            //IPoint point1 = new PointClass();
            //IPoint point11 = new PointClass();
            //IPoint point111 = new PointClass();
            //point.PutCoords(13.837990, -902.603237);
            //point1.PutCoords(1576.744003, -2.806707);
            //point11.PutCoords(1580.270888, -895.071729);
            //point111.PutCoords(7.280188, 4.222903);
            //sourcePoints.AddPoint(point, ref missing, ref missing);
            //sourcePoints.AddPoint(point1, ref missing, ref missing);
            //sourcePoints.AddPoint(point11, ref missing, ref missing);
            //sourcePoints.AddPoint(point111, ref missing, ref missing);
            ////Thêm điểm nắn tại vị trí thực (vị trí bản đồ)
            //IPoint point2 = new PointClass();
            //IPoint point22 = new PointClass();
            //IPoint point222 = new PointClass();
            //IPoint point2222 = new PointClass();
            //point2.PutCoords(545252, 1778243);
            //point22.PutCoords(546814.906013, 1779149.850300);
            //point222.PutCoords(546818.432898, 1778257.548401);
            //point2222.PutCoords(545245.442198, 1779149.850300);
            //targetPoints.AddPoint(point2, ref missing, ref missing);
            //targetPoints.AddPoint(point22, ref missing, ref missing);
            //targetPoints.AddPoint(point222, ref missing, ref missing);
            //targetPoints.AddPoint(point2222, ref missing, ref missing);
            //NanAnhRaster(sourcePoints, targetPoints, @"C:\Users\sinhn\Desktop\HinhAnh\10.1.PNG", @"C:\Users\sinhn\Desktop", "output", "jpg");
        }
        public static void NanAnhRaster(IPointCollection sourcePoints, IPointCollection targetPoints, string pathfile, string pathOuput, string filenameOutput, string formatAnh)
        {
            //Lấy ảnh
            IRasterDataset rasterDataset;
            IWorkspaceFactory wsFactory = new RasterWorkspaceFactory();
            IRasterWorkspace rasterWS = (IRasterWorkspace)wsFactory.OpenFromFile(System.IO.Path.GetDirectoryName(pathfile), 0);
            rasterDataset = rasterWS.OpenRasterDataset(System.IO.Path.GetFileName(pathfile));
            IRasterDataset2 rasterDataset2 = rasterDataset as IRasterDataset2;
            //IPointCollection sourcePoints = new MultipointClass();
            //IPointCollection targetPoints = new MultipointClass();
            //object missing = Type.Missing;
            ////thêm điểm nắn tại ảnh
            //IPoint point = new PointClass();
            //IPoint point1 = new PointClass();
            //IPoint point11 = new PointClass();
            //IPoint point111 = new PointClass();
            //point.PutCoords(13.837990, -902.603237);
            //point1.PutCoords(1576.744003, -2.806707);
            //point11.PutCoords(1580.270888, -895.071729);
            //point111.PutCoords(7.280188, 4.222903);
            //sourcePoints.AddPoint(point, ref missing, ref missing);
            //sourcePoints.AddPoint(point1, ref missing, ref missing);
            //sourcePoints.AddPoint(point11, ref missing, ref missing);
            //sourcePoints.AddPoint(point111, ref missing, ref missing);
            ////Thêm điểm nắn tại vị trí thực (vị trí bản đồ)
            //IPoint point2 = new PointClass();
            //IPoint point22 = new PointClass();
            //IPoint point222 = new PointClass();
            //IPoint point2222 = new PointClass();
            //point2.PutCoords(545252, 1778243);
            //point22.PutCoords(546814.906013, 1779149.850300);
            //point222.PutCoords(546818.432898, 1778257.548401);
            //point2222.PutCoords(545245.442198, 1779149.850300);
            //targetPoints.AddPoint(point2, ref missing, ref missing);
            //targetPoints.AddPoint(point22, ref missing, ref missing);
            //targetPoints.AddPoint(point222, ref missing, ref missing);
            //targetPoints.AddPoint(point2222, ref missing, ref missing);
            IRasterGeometryProc rasterPropc = new RasterGeometryProc();
            IRaster raster = rasterDataset.CreateDefaultRaster();
            //Nắn ảnh
            rasterPropc.Warp(sourcePoints, targetPoints, esriGeoTransTypeEnum.esriGeoTransPolyOrderUndefined, raster);
            //Lưu nắn
            rasterPropc.Register(raster);
            //Lưu ra file khác
            rasterPropc.Rectify(pathOuput + "//" + filenameOutput + "." + formatAnh, formatAnh, raster);
        }
        public static TreeList treelist
        {
            get { return treeList1; }
        }

        private void cậpNhậtDữLiệuTừFileShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.CapNhat.CapNhatShape frm = new QLHTDT.FormPhu.CapNhat.CapNhatShape();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void thêmMớiDựÁnQuyHoạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FrmThemMoiDAQH frmThemMoiDaQH = new FrmThemMoiDAQH();
            frmThemMoiDaQH.Show();
            Cursor = Cursors.Default;
        }

        private void toolChuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.CapNhat.CapNhatCad frm = new QLHTDT.FormPhu.CapNhat.CapNhatCad();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void toolHỗTrợĐóngVùngchuyểnLineSangPolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.CapNhat.PolylineToPolygon frm = new QLHTDT.FormPhu.CapNhat.PolylineToPolygon();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FrmCapNhatDAQH FrmCapNhatDAQH = new FrmCapNhatDAQH();
            FrmCapNhatDAQH.Show();
            Cursor = Cursors.Default;
        }

        private void thêmMớiQuỹĐấtQuyHoạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FrmThemMoiQuyDatQH FrmThemMoiQuyDatQH = new FrmThemMoiQuyDatQH();
            FrmThemMoiQuyDatQH.Show();
            Cursor = Cursors.Default;
        }

        private void mởBảnĐồToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsOpenDocCommand();
            if (tabControl1.SelectedIndex == 0)
            {
                command.OnCreate(axMapControl1.Object);
                axMapControl1.CurrentTool = command as ITool;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                command.OnCreate(axPageLayoutControl1.Object);
                axPageLayoutControl1.CurrentTool = command as ITool;
            }

            command.OnClick();
        }

        private void lưuBảnĐồToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void thêmLớpLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsAddDataCommand();
            if (tabControl1.SelectedIndex == 0)
            {
                command.OnCreate(axMapControl1.Object);
                axMapControl1.CurrentTool = command as ITool;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                command.OnCreate(axPageLayoutControl1.Object);
                axPageLayoutControl1.CurrentTool = command as ITool;
            }

            command.OnClick();
        }

        private void mởFileAutoCadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog_CapNhatCAD);
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog1_FileDGNOk);
            openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
            openFileDialog1.Filter = "AutoCad Files|*.dwg; *.dxf";
            openFileDialog1.Title = "Chọn file Autocad cần mở";
            openFileDialog1.ShowDialog();
        }

        private void mởFileMicrostationdngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog_CapNhatCAD);
            openFileDialog1.FileOk -= new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
            openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog1_FileDGNOk);
            openFileDialog1.Filter = "MicroStation file| *.dgn";
            openFileDialog1.Title = "Chọn file MicroStation cần mở";
            openFileDialog1.ShowDialog();
        }

        private void exportToCadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.Export.ExportToCAD frmExportCAD = new QLHTDT.FormPhu.Export.ExportToCAD();
            frmExportCAD.Show();
        }

        private void kiểmTraFileDGNMớiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (Settings.Default.pathDGN != "")
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Settings.Default.pathDGN);
                // Một mảng các thư mục con.
                DirectoryInfo[] childDirs = dirInfo.GetDirectories();
                // Mảng các file nằm trong thư mục.
                DataTable dtDGNmoi = new DataTable();
                dtDGNmoi = new DataTable();
                dtDGNmoi.Columns.Add("STT", typeof(int));
                dtDGNmoi.Columns.Add("TenFile", typeof(String));
                dtDGNmoi.Columns.Add("NgayCN", typeof(String));
                dtDGNmoi.Columns.Add("NgayTao", typeof(String));
                DataRow drDGNmoi;
                int i = 1;
                foreach (DirectoryInfo childDir in childDirs)
                {
                    FileInfo[] childFiles = childDir.GetFiles("*.dgn");
                    //MessageBox.Show(" - Directory: " + childDir.FullName, "Thông báo");
                    foreach (FileInfo childFile in childFiles)
                    {
                        var date = DateTime.Now;
                        if (childFile.LastWriteTime.Day == date.Day && childFile.LastWriteTime.Month == date.Month && childFile.LastWriteTime.Year == date.Year)
                        {
                            //MessageBox.Show("File: " + childFile.Name + " Thời gian chỉnh sửa cuối cùng " + childFile.LastWriteTime, "Thông báo");
                            drDGNmoi = dtDGNmoi.NewRow();
                            drDGNmoi[0] = i;
                            drDGNmoi[1] = childFile.FullName;
                            drDGNmoi[2] = childFile.LastWriteTime;
                            drDGNmoi[3] = childFile.CreationTime;
                            dtDGNmoi.Rows.Add(drDGNmoi);
                            i = i + 1;
                        }
                    }
                }
                QLHTDT.test.TableDGNmoi frm = new QLHTDT.test.TableDGNmoi(dtDGNmoi);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Chọn thư mục lưu file DGN", "Thông báo");
                FolderBrowserDialog openfd = new FolderBrowserDialog();
                openfd.ShowNewFolderButton = true;
                openfd.SelectedPath = QLHTDT.Properties.Settings.Default.pathDGN;
                openfd.Description = "Chọn thư mục lưu file DGN";
                if (openfd.ShowDialog() == DialogResult.OK)
                {

                    QLHTDT.Properties.Settings.Default.pathDGN = @openfd.SelectedPath;
                    QLHTDT.Properties.Settings.Default.Save();
                    DirectoryInfo dirInfo = new DirectoryInfo(Settings.Default.pathDGN);
                    // Một mảng các thư mục con.
                    DirectoryInfo[] childDirs = dirInfo.GetDirectories();
                    // Mảng các file nằm trong thư mục.
                    DataTable dtDGNmoi = new DataTable();
                    dtDGNmoi = new DataTable();
                    dtDGNmoi.Columns.Add("STT", typeof(int));
                    dtDGNmoi.Columns.Add("TenFile", typeof(String));
                    dtDGNmoi.Columns.Add("NgayCN", typeof(String));
                    dtDGNmoi.Columns.Add("NgayTao", typeof(String));
                    DataRow drDGNmoi;
                    int i = 1;
                    foreach (DirectoryInfo childDir in childDirs)
                    {
                        FileInfo[] childFiles = childDir.GetFiles("*.dgn");
                        //MessageBox.Show(" - Directory: " + childDir.FullName, "Thông báo");
                        foreach (FileInfo childFile in childFiles)
                        {
                            var date = DateTime.Now;
                            if (childFile.LastWriteTime.Day == date.Day && childFile.LastWriteTime.Month == date.Month && childFile.LastWriteTime.Year == date.Year)
                            {
                                //MessageBox.Show("File: " + childFile.Name + " Thời gian chỉnh sửa cuối cùng " + childFile.LastWriteTime, "Thông báo");
                                drDGNmoi = dtDGNmoi.NewRow();
                                drDGNmoi[0] = i;
                                drDGNmoi[1] = childFile.FullName;
                                drDGNmoi[2] = childFile.LastWriteTime;
                                drDGNmoi[3] = childFile.CreationTime;
                                dtDGNmoi.Rows.Add(drDGNmoi);
                                i = i + 1;
                            }
                        }
                    }
                    QLHTDT.test.TableDGNmoi frm = new QLHTDT.test.TableDGNmoi(dtDGNmoi);
                    frm.Show();
                }
            }
            Cursor = Cursors.Default;
        }

        private void chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.CapNhat.CapNhatCad frm = new QLHTDT.FormPhu.CapNhat.CapNhatCad();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void cậpNhậtDữLiệuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            QLHTDT.CapNhatDGN.FrmCapNhat frm = new QLHTDT.CapNhatDGN.FrmCapNhat();
            frm.Show();
        }

        private void chuyểnĐổiDữLiệuĐườngSangVùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.CapNhat.PolylineToPolygon frm = new QLHTDT.FormPhu.CapNhat.PolylineToPolygon();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void kiểmTraFiledgncadshpMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (Settings.Default.pathDGN != "")
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Settings.Default.pathDGN);
                // Một mảng các thư mục con.
                DirectoryInfo[] childDirs = dirInfo.GetDirectories();
                // Mảng các file nằm trong thư mục.
                DataTable dtDGNmoi = new DataTable();
                dtDGNmoi = new DataTable();
                dtDGNmoi.Columns.Add("STT", typeof(int));
                dtDGNmoi.Columns.Add("TenFile", typeof(String));
                dtDGNmoi.Columns.Add("NgayCN", typeof(String));
                dtDGNmoi.Columns.Add("NgayTao", typeof(String));
                DataRow drDGNmoi;
                int i = 1;
                foreach (DirectoryInfo childDir in childDirs)
                {
                    FileInfo[] childFiles = childDir.GetFiles("*.dgn");
                    //MessageBox.Show(" - Directory: " + childDir.FullName, "Thông báo");
                    foreach (FileInfo childFile in childFiles)
                    {
                        var date = DateTime.Now;
                        if (childFile.LastWriteTime.Day == date.Day && childFile.LastWriteTime.Month == date.Month && childFile.LastWriteTime.Year == date.Year)
                        {
                            //MessageBox.Show("File: " + childFile.Name + " Thời gian chỉnh sửa cuối cùng " + childFile.LastWriteTime, "Thông báo");
                            drDGNmoi = dtDGNmoi.NewRow();
                            drDGNmoi[0] = i;
                            drDGNmoi[1] = childFile.FullName;
                            drDGNmoi[2] = childFile.LastWriteTime;
                            drDGNmoi[3] = childFile.CreationTime;
                            dtDGNmoi.Rows.Add(drDGNmoi);
                            i = i + 1;
                        }
                    }
                }
                QLHTDT.test.TableDGNmoi frm = new QLHTDT.test.TableDGNmoi(dtDGNmoi);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Chọn thư mục lưu file DGN", "Thông báo");
                FolderBrowserDialog openfd = new FolderBrowserDialog();
                openfd.ShowNewFolderButton = true;
                openfd.SelectedPath = QLHTDT.Properties.Settings.Default.pathDGN;
                openfd.Description = "Chọn thư mục lưu file DGN";
                if (openfd.ShowDialog() == DialogResult.OK)
                {

                    QLHTDT.Properties.Settings.Default.pathDGN = @openfd.SelectedPath;
                    QLHTDT.Properties.Settings.Default.Save();
                    DirectoryInfo dirInfo = new DirectoryInfo(Settings.Default.pathDGN);
                    // Một mảng các thư mục con.
                    DirectoryInfo[] childDirs = dirInfo.GetDirectories();
                    // Mảng các file nằm trong thư mục.
                    DataTable dtDGNmoi = new DataTable();
                    dtDGNmoi = new DataTable();
                    dtDGNmoi.Columns.Add("STT", typeof(int));
                    dtDGNmoi.Columns.Add("TenFile", typeof(String));
                    dtDGNmoi.Columns.Add("NgayCN", typeof(String));
                    dtDGNmoi.Columns.Add("NgayTao", typeof(String));
                    DataRow drDGNmoi;
                    int i = 1;
                    foreach (DirectoryInfo childDir in childDirs)
                    {
                        FileInfo[] childFiles = childDir.GetFiles("*.dgn");
                        //MessageBox.Show(" - Directory: " + childDir.FullName, "Thông báo");
                        foreach (FileInfo childFile in childFiles)
                        {
                            var date = DateTime.Now;
                            if (childFile.LastWriteTime.Day == date.Day && childFile.LastWriteTime.Month == date.Month && childFile.LastWriteTime.Year == date.Year)
                            {
                                //MessageBox.Show("File: " + childFile.Name + " Thời gian chỉnh sửa cuối cùng " + childFile.LastWriteTime, "Thông báo");
                                drDGNmoi = dtDGNmoi.NewRow();
                                drDGNmoi[0] = i;
                                drDGNmoi[1] = childFile.FullName;
                                drDGNmoi[2] = childFile.LastWriteTime;
                                drDGNmoi[3] = childFile.CreationTime;
                                dtDGNmoi.Rows.Add(drDGNmoi);
                                i = i + 1;
                            }
                        }
                    }
                    QLHTDT.test.TableDGNmoi frm = new QLHTDT.test.TableDGNmoi(dtDGNmoi);
                    frm.Show();
                }
            }
            Cursor = Cursors.Default;
        }

        private void chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.CapNhat.CapNhatCad frm = new QLHTDT.FormPhu.CapNhat.CapNhatCad();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void thêmMớiDựÁnQuyHoạchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FrmThemMoiDAQH frmThemMoiDaQH = new FrmThemMoiDAQH();
            frmThemMoiDaQH.Show();
            Cursor = Cursors.Default;
        }

        private void thêmMớiQuỹĐấtQuyHoạchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FrmCapNhatDAQH FrmCapNhatDAQH = new FrmCapNhatDAQH();
            FrmCapNhatDAQH.Show();
            Cursor = Cursors.Default;
        }

        private void cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FrmThemMoiQuyDatQH FrmThemMoiQuyDatQH = new FrmThemMoiQuyDatQH();
            FrmThemMoiQuyDatQH.Show();
            Cursor = Cursors.Default;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cậpNhậtDữLiệuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.CapNhat.CapNhatShape frm = new QLHTDT.FormPhu.CapNhat.CapNhatShape();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            axPageLayoutControl1.CurrentTool = null;
            IGraphicsContainer graphicsContainer = axPageLayoutControl1.GraphicsContainer;

            //Get the MapFrame
            IMapFrame mapFrame = (IMapFrame)graphicsContainer.FindFrame(axPageLayoutControl1.ActiveView.FocusMap);

            if (mapFrame == null) return;

            //Create a legend
            UID uID = new UIDClass();
            uID.Value = "esriCarto.Legend";

            //Create a MapSurroundFrame from the MapFrame
            IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uID, null);
            if (mapSurroundFrame == null) return;
            if (mapSurroundFrame.MapSurround == null) return;
            //Set the name 
            mapSurroundFrame.MapSurround.Name = "Chú thích";
            mapSurroundFrame.MapSurround.Map.Name = "Chú thích";
            ILegend legend;

            legend = mapSurroundFrame.MapSurround as ILegend;
            if (legend.ItemCount != 0)
            {
                ILegendItem legendItem = legend.get_Item(legend.ItemCount - 1);
                legend.RemoveItem(legend.ItemCount - 1);
                legend.AddItem(legendItem);
                legend.Title = "Chú thích";

                //Envelope for the legend
                IEnvelope envelope = new EnvelopeClass();
                envelope.PutCoords(1, 1, 3.4, 2.4);
                //Set the geometry of the MapSurroundFrame 
                IElement element = (IElement)mapSurroundFrame;
                //IElement element = legend as IElement;
                element.Geometry = envelope as IGeometry;

                //Add the legend to the PageLayout
                axPageLayoutControl1.AddElement(element, Type.Missing, Type.Missing, "Chú thích", 0);
                //Refresh the PageLayoutControl
                axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            //disable/enable buttons

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            IElement element = axPageLayoutControl1.FindElementByName("Chú thích", 1);

            if (element != null)
            {
                //Delete the legend
                IGraphicsContainer graphicsContainer = axPageLayoutControl1.GraphicsContainer;
                graphicsContainer.DeleteElement(element);
                //Refresh the display
                axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form2 symbolForm = new Form2();

            //Get the IStyleGalleryItem that has been selected in the SymbologyControl
            IStyleGalleryItem styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassAreaPatches);

            //release the form
            symbolForm.Dispose();
            if (styleGalleryItem == null) return;

            //Find the legend
            IElement element = axPageLayoutControl1.FindElementByName("Chú thích", 1);
            if (element == null) return;

            //Get the IMapSurroundFrame
            IMapSurroundFrame mapSurroundFrame = (IMapSurroundFrame)element;
            if (mapSurroundFrame == null) return;

            //If a legend exists change the default area patch
            ILegend legend = (ILegend)mapSurroundFrame.MapSurround;
            legend.Format.DefaultAreaPatch = (IAreaPatch)styleGalleryItem.Item;

            //Update the legend
            legend.Refresh();
            //Refresh the display
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form2 symbolForm = new Form2();

            //Get the IStyleGalleryItem that has been selected in the SymbologyControl
            IStyleGalleryItem styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassLinePatches);

            //release the form
            symbolForm.Dispose();
            if (styleGalleryItem == null) return;

            //Find the legend
            IElement element = axPageLayoutControl1.FindElementByName("Chú thích", 1);
            if (element == null) return;

            //Get the IMapSurroundFrame
            IMapSurroundFrame mapSurroundFrame = (IMapSurroundFrame)element;
            if (mapSurroundFrame == null) return;

            //If a legend exists change the default area patch
            ILegend legend = (ILegend)mapSurroundFrame.MapSurround;
            legend.Format.DefaultLinePatch = (ILinePatch)styleGalleryItem.Item;

            //Update the legend
            legend.Refresh();
            //Refresh the display
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            //axPageLayoutControl1.OnMouseDown -= new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(MenuPage);
            axPageLayoutControl1.CurrentTool = null;
            ICommand command = new QLHTDT.Trangin.CreateText();
            command.OnCreate(axPageLayoutControl1.Object);
            axPageLayoutControl1.CurrentTool = command as ITool;
            //command.OnClick();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            axPageLayoutControl1.CurrentTool = null;
            ICommand command = new QLHTDT.Trangin.CreateScaleText();
            command.OnCreate(axPageLayoutControl1.Object);
            axPageLayoutControl1.CurrentTool = command as ITool;
            //command.OnClick();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            axPageLayoutControl1.CurrentTool = null;
            ICommand command = new QLHTDT.Trangin.CreateScaleBar();
            command.OnCreate(axPageLayoutControl1.Object);
            axPageLayoutControl1.CurrentTool = command as ITool;
            //command.OnClick();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            axPageLayoutControl1.CurrentTool = null;
            //axPageLayoutControl1.OnMouseDown -= new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(MenuPage);
            //axPageLayoutControl1.OnKeyDown += new IPageLayoutControlEvents_Ax_OnKeyDownEventHandler(ThemChiHuongBacNam);  
            ICommand command = new QLHTDT.Trangin.CreateNorthArrow();

            command.OnCreate(axPageLayoutControl1.Object);
            axPageLayoutControl1.CurrentTool = command as ITool;
            //command.OnClick();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            IEnvelope envelope = axPageLayoutControl1.TrackRectangle();

            //Create a map frame element with a new map
            IMapFrame mapFrame = new MapFrameClass();
            mapFrame.Map = new MapClass();

            //Add the map frame to the PageLayoutControl with specified geometry
            axPageLayoutControl1.AddElement((IElement)mapFrame, envelope, null, null, 0);

            //Refresh the PageLayoutControl
            axPageLayoutControl1.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            SnapGrid(axPageLayoutControl1.ActiveView);
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            //var image = Image.FromFile(System.IO.Path.GetTempPath() + "\\TrangIn.jpg");

            if (System.IO.File.Exists(System.IO.Path.GetTempPath() + "\\TrangIn.jpg"))
            {
                System.IO.File.Delete(System.IO.Path.GetTempPath() + "\\TrangIn.jpg");
            }
            CreateJPEGHiResolutionFromActiveView(axPageLayoutControl1.ActiveView, System.IO.Path.GetTempPath() + "\\TrangIn.jpg");
            QLHTDT.FormPhu.InAn.ToolIn frm = new QLHTDT.FormPhu.InAn.ToolIn();
            frm.Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            ChonKhoGiay frm = new ChonKhoGiay();
            frm.ShowDialog();
        }

        private void thêmChúThíchToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            axPageLayoutControl1.CurrentTool = null;
            IGraphicsContainer graphicsContainer = axPageLayoutControl1.GraphicsContainer;

            //Get the MapFrame
            IMapFrame mapFrame = (IMapFrame)graphicsContainer.FindFrame(axPageLayoutControl1.ActiveView.FocusMap);

            if (mapFrame == null) return;

            //Create a legend
            UID uID = new UIDClass();
            uID.Value = "esriCarto.Legend";

            //Create a MapSurroundFrame from the MapFrame
            IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uID, null);
            if (mapSurroundFrame == null) return;
            if (mapSurroundFrame.MapSurround == null) return;
            //Set the name 
            mapSurroundFrame.MapSurround.Name = "Chú thích";
            mapSurroundFrame.MapSurround.Map.Name = "Chú thích";
            ILegend legend;

            legend = mapSurroundFrame.MapSurround as ILegend;
            if (legend.ItemCount != 0)
            {
                ILegendItem legendItem = legend.get_Item(legend.ItemCount - 1);
                legend.RemoveItem(legend.ItemCount - 1);
                legend.AddItem(legendItem);
                legend.Title = "Chú thích";

                //Envelope for the legend
                IEnvelope envelope = new EnvelopeClass();
                envelope.PutCoords(1, 1, 3.4, 2.4);
                //Set the geometry of the MapSurroundFrame 
                IElement element = (IElement)mapSurroundFrame;
                //IElement element = legend as IElement;
                element.Geometry = envelope as IGeometry;

                //Add the legend to the PageLayout
                axPageLayoutControl1.AddElement(element, Type.Missing, Type.Missing, "Chú thích", 0);
                //Refresh the PageLayoutControl
                axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            //disable/enable buttons
        }

        private void xóaChúThíchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IElement element = axPageLayoutControl1.FindElementByName("Chú thích", 1);

            if (element != null)
            {
                //Delete the legend
                IGraphicsContainer graphicsContainer = axPageLayoutControl1.GraphicsContainer;
                graphicsContainer.DeleteElement(element);
                //Refresh the display
                axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
        }

        private void thayĐổiChúThíchĐốiTượngVùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 symbolForm = new Form2();

            //Get the IStyleGalleryItem that has been selected in the SymbologyControl
            IStyleGalleryItem styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassAreaPatches);

            //release the form
            symbolForm.Dispose();
            if (styleGalleryItem == null) return;

            //Find the legend
            IElement element = axPageLayoutControl1.FindElementByName("Chú thích", 1);
            if (element == null) return;

            //Get the IMapSurroundFrame
            IMapSurroundFrame mapSurroundFrame = (IMapSurroundFrame)element;
            if (mapSurroundFrame == null) return;

            //If a legend exists change the default area patch
            ILegend legend = (ILegend)mapSurroundFrame.MapSurround;
            legend.Format.DefaultAreaPatch = (IAreaPatch)styleGalleryItem.Item;

            //Update the legend
            legend.Refresh();
            //Refresh the display
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void thayĐổiChúThíchĐốiTượngĐườngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 symbolForm = new Form2();

            //Get the IStyleGalleryItem that has been selected in the SymbologyControl
            IStyleGalleryItem styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassLinePatches);

            //release the form
            symbolForm.Dispose();
            if (styleGalleryItem == null) return;

            //Find the legend
            IElement element = axPageLayoutControl1.FindElementByName("Chú thích", 1);
            if (element == null) return;

            //Get the IMapSurroundFrame
            IMapSurroundFrame mapSurroundFrame = (IMapSurroundFrame)element;
            if (mapSurroundFrame == null) return;

            //If a legend exists change the default area patch
            ILegend legend = (ILegend)mapSurroundFrame.MapSurround;
            legend.Format.DefaultLinePatch = (ILinePatch)styleGalleryItem.Item;

            //Update the legend
            legend.Refresh();
            //Refresh the display
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        private void cậpNhậtBảnĐồGiấyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogAnhBDGiay = new System.Windows.Forms.OpenFileDialog();
            openFileDialogAnhBDGiay.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogAnhBDGiay_FileOk);
            openFileDialogAnhBDGiay.Filter = "Ảnh|*.png; *.jpg; *.tif; *.tiff; *.bmp; *.img";
            openFileDialogAnhBDGiay.Title = "Chọn file ảnh bản đồ giấy cần cập nhật";
            openFileDialogAnhBDGiay.ShowDialog();
        }

        private void chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.CapNhat.PolylineToPolygon frm = new QLHTDT.FormPhu.CapNhat.PolylineToPolygon();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.CapNhat.FrmCapNhatSoNha frm = new QLHTDT.FormPhu.CapNhat.FrmCapNhatSoNha();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            tabNavigationPage3.PageVisible = false;
            tabPane1.SelectPrevPage();
            Cursor = Cursors.Default;
        }

        private void chuyểnĐổiHệTọaĐộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.FrmChuyenHeToaDo frmConvert = new QLHTDT.FormPhu.FrmChuyenHeToaDo();
            frmConvert.Show();
            Cursor = Cursors.Default;
        }

        private void testDangNhapToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.test.FrmDangNhap.FrmDangNhap frmConvert = new QLHTDT.test.FrmDangNhap.FrmDangNhap();
            frmConvert.Show();
            Cursor = Cursors.Default;
        }

        private void testMBQHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.CapNhat.TestMBQH frmConvert = new QLHTDT.FormPhu.CapNhat.TestMBQH();
            frmConvert.Show();
            Cursor = Cursors.Default;
        }

        private IGeometry unionAndBuffer(IEnumGeometry inputGeometries, double bufferSize)
        {
            IBufferConstruction bufferConstructor = new BufferConstructionClass();
            IBufferConstructionProperties2 bufferOptions = bufferConstructor as IBufferConstructionProperties2;

            bufferOptions.EndOption = esriBufferConstructionEndEnum.esriBufferFlat;
            bufferOptions.ExplodeBuffers = false;
            bufferOptions.GenerateCurves = false;
            bufferOptions.OutsideOnly = false;
            bufferOptions.SideOption = esriBufferConstructionSideEnum.esriBufferFull;
            //this does the union and ensures a single geometry in the result
            bufferOptions.UnionOverlappingBuffers = true;
            bufferOptions.UseGeodesicBuffering = false;

            IGeometryCollection outputBuffers = new GeometryBagClass() as IGeometryCollection;

            bufferConstructor.ConstructBuffers(inputGeometries, bufferSize, outputBuffers);

            if (outputBuffers.GeometryCount <= 0)
                return null;

            IGeometry g = outputBuffers.get_Geometry(0);
            return g;
        }
    }

}