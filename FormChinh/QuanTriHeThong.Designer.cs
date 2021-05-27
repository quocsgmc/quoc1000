using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;
using System.ComponentModel;


namespace QLHTDT.FormChinh
{
    partial class QuanTriHeThong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanTriHeThong));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Cbolop2 = new System.Windows.Forms.ComboBox();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.tabNavigationPage3 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cboLoaiCay = new System.Windows.Forms.ComboBox();
            this.cboDuong = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPhuong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboQuan = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.lbPhuong = new System.Windows.Forms.Label();
            this.txtMaCay = new System.Windows.Forms.TextBox();
            this.Btloadlailop = new System.Windows.Forms.Button();
            this.BtTracuu = new System.Windows.Forms.Button();
            this.lbTenDA = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OBJECTID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.button9 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.btChinhSua = new System.Windows.Forms.Button();
            this.BtExcell = new System.Windows.Forms.Button();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboLoaiCay1 = new System.Windows.Forms.ComboBox();
            this.cboDuong1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboPhuong1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboQuan1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaCay1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.button5 = new System.Windows.Forms.Button();
            this.btChinhSua1 = new System.Windows.Forms.Button();
            this.BtExcell1 = new System.Windows.Forms.Button();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboLoaiCay2 = new System.Windows.Forms.ComboBox();
            this.cboDuong2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboPhuong2 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboQuan2 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMaCay2 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bindingNavigator3 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton17 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton18 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton19 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton20 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton21 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton22 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton23 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton24 = new System.Windows.Forms.ToolStripButton();
            this.button10 = new System.Windows.Forms.Button();
            this.btChinhSua2 = new System.Windows.Forms.Button();
            this.btXExcel2 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.axLicenseControl2 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.axToolbarControl2 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axToolbarControl3 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.chọnCỡGiấyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtẢnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmChúGiảiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmChúThíchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaChúThíchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thayĐổiĐốiTượngVùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thayĐổiĐốiTượngĐườngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmTiêuĐềToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmTỷLệToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmThướcTỷLệToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmChỉHướngBắcNamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmDataFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmLướiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.axToolbarControl5 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axToolbarControl4 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mởBảnĐồToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuBảnĐồToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmLớpLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mởFileAutoCadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mởFileMicrostationdngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToCadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmChúThíchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmChúThíchToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaChúThíchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thayĐổiChúThíchĐốiTượngVùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thayĐổiChúThíchĐốiTượngĐườngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậtKíLàmViệcToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kếtNốiCơSởDữLiệuToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saoLưuCơSởDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phụcHồiCơSởDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bảnĐồToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mởBảnĐồToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuBảnĐồToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuĐếnFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mởLớpLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mởBảngTừTậpTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmLớpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bảnĐồNềnGoogleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ảnhVệTinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trangInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhCôngCụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhCôngCụToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụCơBảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụChỉnhSửaTrangInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tùyChỉnhToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuThanhCôngCụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bảnĐồNềnGoogleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ảnhVệTinhToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kiểmTraFileDGNMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolChuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolHỗTrợĐóngVùngchuyểnLineSangPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtDữLiệuTừFileShapefileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtQuyĐấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmMớiDựÁnQuyHoạchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmMớiQuỹĐấtQuyHoạchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnSửDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giớiThiệuSảnPhâprToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ảnhGiaoThôngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addlayer = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dataDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabNavigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNavigationPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(axTOCControl1)).BeginInit();
            this.tabNavigationPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.bindingNavigator2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator3)).BeginInit();
            this.bindingNavigator3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(axMapControl1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(axPageLayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addlayer)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabNavigationPage1
            // 
            this.tabNavigationPage1.Caption = "CSDL GIS";
            this.tabNavigationPage1.Controls.Add(treeList1);
            this.tabNavigationPage1.Controls.Add(this.comboBox1);
            this.tabNavigationPage1.Controls.Add(this.Cbolop2);
            this.tabNavigationPage1.Name = "tabNavigationPage1";
            this.tabNavigationPage1.Size = new System.Drawing.Size(180, 801);
            // 
            // treeList1
            // 
            treeList1.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            treeList1.Appearance.BandPanel.Options.UseFont = true;
            treeList1.Appearance.Caption.Font = new System.Drawing.Font("Tahoma", 9F);
            treeList1.Appearance.Caption.Options.UseFont = true;
            treeList1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            treeList1.Appearance.FilterPanel.Options.UseFont = true;
            treeList1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9F);
            treeList1.Appearance.FocusedCell.Options.UseFont = true;
            treeList1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9F);
            treeList1.Appearance.FocusedRow.Options.UseFont = true;
            treeList1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            treeList1.Appearance.FooterPanel.Options.UseFont = true;
            treeList1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            treeList1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.5F);
            treeList1.Appearance.Row.Options.UseFont = true;
            treeList1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            treeList1.Appearance.SelectedRow.Options.UseFont = true;
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn4,
            this.treeListColumn5});
            treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            treeList1.Location = new System.Drawing.Point(0, 0);
            treeList1.Name = "treeList1";
            treeList1.BeginUnboundLoad();
            treeList1.AppendNode(new object[] {
            "Hòa Phú",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Đường chính - HP",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Kiệt hẻm - HP",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Mương thoát nước - HP",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Trụ điện chiếu sáng - HP",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Tuyến điện chiếu sáng - HP",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Cây xanh - HP",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch - HP",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Chia lô - HP",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch - HP",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Kiến trúc - HP",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Hòa Phước",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Đường chính - HP",
            false}, 11);
            treeList1.AppendNode(new object[] {
            "Kiệt hẻm - HP",
            false}, 11);
            treeList1.AppendNode(new object[] {
            "Mương thoát nước - HP",
            false}, 11);
            treeList1.AppendNode(new object[] {
            "Trụ điện chiếu sáng - HP",
            false}, 11);
            treeList1.AppendNode(new object[] {
            "Tuyến điện chiếu sáng - HP",
            false}, 11);
            treeList1.AppendNode(new object[] {
            "Cây xanh - HP",
            false}, 11);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch - HP",
            false}, 11);
            treeList1.AppendNode(new object[] {
            "Chia lô - HP",
            false}, 11);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch - HP",
            false}, 11);
            treeList1.AppendNode(new object[] {
            "Kiến trúc - HP",
            false}, 11);
            treeList1.AppendNode(new object[] {
            "Hòa Bắc",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Đường chính - HB",
            false}, 22);
            treeList1.AppendNode(new object[] {
            "Kiệt hẻm - HB",
            false}, 22);
            treeList1.AppendNode(new object[] {
            "Mương thoát nước - HB",
            false}, 22);
            treeList1.AppendNode(new object[] {
            "Trụ điện chiếu sáng - HB",
            false}, 22);
            treeList1.AppendNode(new object[] {
            "Tuyến điện chiếu sáng - HB",
            false}, 22);
            treeList1.AppendNode(new object[] {
            "Cây xanh - HB",
            false}, 22);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch - HB",
            false}, 22);
            treeList1.AppendNode(new object[] {
            "Chia lô - HB",
            false}, 22);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch - HB",
            false}, 22);
            treeList1.AppendNode(new object[] {
            "Kiến trúc - HB",
            false}, 22);
            treeList1.AppendNode(new object[] {
            "Hòa Châu",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Đường chính - HC",
            false}, 33);
            treeList1.AppendNode(new object[] {
            "Kiệt hẻm - HC",
            false}, 33);
            treeList1.AppendNode(new object[] {
            "Mương thoát nước - HC",
            false}, 33);
            treeList1.AppendNode(new object[] {
            "Trụ điện chiếu sáng - HC",
            false}, 33);
            treeList1.AppendNode(new object[] {
            "Tuyến điện chiếu sáng - HC",
            false}, 33);
            treeList1.AppendNode(new object[] {
            "Cây xanh - HC",
            false}, 33);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch - HC",
            false}, 33);
            treeList1.AppendNode(new object[] {
            "Chia lô - HC",
            false}, 33);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch - HC",
            false}, 33);
            treeList1.AppendNode(new object[] {
            "Kiến trúc - HC",
            false}, 33);
            treeList1.AppendNode(new object[] {
            "Hòa Khương",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Đường chính - HK",
            false}, 44);
            treeList1.AppendNode(new object[] {
            "Kiệt hẻm - HK",
            false}, 44);
            treeList1.AppendNode(new object[] {
            "Mương thoát nước - HK",
            false}, 44);
            treeList1.AppendNode(new object[] {
            "Trụ điện chiếu sáng - HK",
            false}, 44);
            treeList1.AppendNode(new object[] {
            "Tuyến điện chiếu sáng - HK",
            false}, 44);
            treeList1.AppendNode(new object[] {
            "Cây xanh - HK",
            false}, 44);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch - HK",
            false}, 44);
            treeList1.AppendNode(new object[] {
            "Chia lô - HK",
            false}, 44);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch - HK",
            false}, 44);
            treeList1.AppendNode(new object[] {
            "Ranh giới vùng Kiến trúc - HK",
            false}, 44);
            treeList1.AppendNode(new object[] {
            "Kiến trúc - HK",
            false}, 44);
            treeList1.AppendNode(new object[] {
            "Hòa Liên",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Đường chính - HL",
            false}, 56);
            treeList1.AppendNode(new object[] {
            "Kiệt hẻm - HL",
            false}, 56);
            treeList1.AppendNode(new object[] {
            "Mương thoát nước - HL",
            false}, 56);
            treeList1.AppendNode(new object[] {
            "Trụ điện chiếu sáng - HL",
            false}, 56);
            treeList1.AppendNode(new object[] {
            "Tuyến điện chiếu sáng - HL",
            false}, 56);
            treeList1.AppendNode(new object[] {
            "Cây xanh - HL",
            false}, 56);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch - HL",
            false}, 56);
            treeList1.AppendNode(new object[] {
            "Chia lô - HL",
            false}, 56);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch - HL",
            false}, 56);
            treeList1.AppendNode(new object[] {
            "Kiến trúc - HL",
            false}, 56);
            treeList1.AppendNode(new object[] {
            "Hòa Nhơn",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Đường chính - HN",
            false}, 67);
            treeList1.AppendNode(new object[] {
            "Kiệt hẻm - HN",
            false}, 67);
            treeList1.AppendNode(new object[] {
            "Mương thoát nước - HN",
            false}, 67);
            treeList1.AppendNode(new object[] {
            "Trụ điện chiếu sáng - HN",
            false}, 67);
            treeList1.AppendNode(new object[] {
            "Tuyến điện chiếu sáng - HN",
            false}, 67);
            treeList1.AppendNode(new object[] {
            "Cây xanh - HN",
            false}, 67);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch - HN",
            false}, 67);
            treeList1.AppendNode(new object[] {
            "Chia lô - HN",
            false}, 67);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch - HN",
            false}, 67);
            treeList1.AppendNode(new object[] {
            "Kiến trúc - HN",
            false}, 67);
            treeList1.AppendNode(new object[] {
            "Hòa Phong",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Đường chính - HP",
            false}, 78);
            treeList1.AppendNode(new object[] {
            "Kiệt hẻm - HP",
            false}, 78);
            treeList1.AppendNode(new object[] {
            "Mương thoát nước - HP",
            false}, 78);
            treeList1.AppendNode(new object[] {
            "Trụ điện chiếu sáng - HP",
            false}, 78);
            treeList1.AppendNode(new object[] {
            "Tuyến điện chiếu sáng - HP",
            false}, 78);
            treeList1.AppendNode(new object[] {
            "Cây xanh - HP",
            false}, 78);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch - HP",
            false}, 78);
            treeList1.AppendNode(new object[] {
            "Chia lô - HP",
            false}, 78);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch - HP",
            false}, 78);
            treeList1.AppendNode(new object[] {
            "Kiến trúc - HN",
            false}, 78);
            treeList1.AppendNode(new object[] {
            "Hòa Tiến",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Đường chính - HT",
            false}, 89);
            treeList1.AppendNode(new object[] {
            "Kiệt hẻm - HT",
            false}, 89);
            treeList1.AppendNode(new object[] {
            "Mương thoát nước - HT",
            false}, 89);
            treeList1.AppendNode(new object[] {
            "Trụ điện chiếu sáng - HT",
            false}, 89);
            treeList1.AppendNode(new object[] {
            "Tuyến điện chiếu sáng - HT",
            false}, 89);
            treeList1.AppendNode(new object[] {
            "Cây xanh - HT",
            false}, 89);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch - HT",
            false}, 89);
            treeList1.AppendNode(new object[] {
            "Chia lô - HT",
            false}, 89);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch - HT",
            false}, 89);
            treeList1.AppendNode(new object[] {
            "Kiến trúc - HT",
            false}, 89);
            treeList1.AppendNode(new object[] {
            "Hòa Sơn",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Đường chính - HS",
            false}, 100);
            treeList1.AppendNode(new object[] {
            "Kiệt hẻm - HS",
            false}, 100);
            treeList1.AppendNode(new object[] {
            "Mương thoát nước - HS",
            false}, 100);
            treeList1.AppendNode(new object[] {
            "Trụ điện chiếu sáng - HS",
            false}, 100);
            treeList1.AppendNode(new object[] {
            "Tuyến điện chiếu sáng - HS",
            false}, 100);
            treeList1.AppendNode(new object[] {
            "Cây xanh - HS",
            false}, 100);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch - HS",
            false}, 100);
            treeList1.AppendNode(new object[] {
            "Chia lô - HS",
            false}, 100);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch - HS",
            false}, 100);
            treeList1.AppendNode(new object[] {
            "Kiến trúc - HS",
            false}, 100);
            treeList1.AppendNode(new object[] {
            "Hòa Ninh",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Đường chính - HN",
            false}, 111);
            treeList1.AppendNode(new object[] {
            "Kiệt hẻm - HN",
            false}, 111);
            treeList1.AppendNode(new object[] {
            "Mương thoát nước - HN",
            false}, 111);
            treeList1.AppendNode(new object[] {
            "Trụ điện chiếu sáng - HN",
            false}, 111);
            treeList1.AppendNode(new object[] {
            "Tuyến điện chiếu sáng - HN",
            false}, 111);
            treeList1.AppendNode(new object[] {
            "Cây xanh - HN",
            false}, 111);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch - HN",
            false}, 111);
            treeList1.AppendNode(new object[] {
            "Chia lô - HN",
            false}, 111);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch - HN",
            false}, 111);
            treeList1.AppendNode(new object[] {
            "Kiến trúc - HN",
            false}, 111);
            treeList1.AppendNode(new object[] {
            "Lớp khác",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Vùng ngập úng",
            false}, 122);
            treeList1.AppendNode(new object[] {
            "Ranh giới hành chính",
            false}, 122);
            treeList1.AppendNode(new object[] {
            "Nền Phường",
            false}, 122);
            treeList1.AppendNode(new object[] {
            "Bản đồ nền Vệ tinh",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Bản đồ nền giao thông",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Theo lớp dữ liệu",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Đường giao thông chính",
            false}, 128);
            treeList1.AppendNode(new object[] {
            "Đường kiệt hẻm",
            false}, 128);
            treeList1.AppendNode(new object[] {
            "Trụ điện chiếu sáng",
            false}, 128);
            treeList1.AppendNode(new object[] {
            "Tuyến điện chiếu sáng",
            false}, 128);
            treeList1.AppendNode(new object[] {
            "Mương thoát nước",
            false}, 128);
            treeList1.AppendNode(new object[] {
            "Cây xanh",
            false}, 128);
            treeList1.AppendNode(new object[] {
            "Chia lô",
            false}, 128);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch",
            false}, 128);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch",
            false}, 128);
            treeList1.AppendNode(new object[] {
            "Kiến trúc",
            false}, 128);
            treeList1.EndUnboundLoad();
            treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            treeList1.Size = new System.Drawing.Size(180, 801);
            treeList1.TabIndex = 40;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn4.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn4.Caption = "Lớp dữ liệu";
            this.treeListColumn4.FieldName = "Tên lớp";
            this.treeListColumn4.MinWidth = 70;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 0;
            this.treeListColumn4.Width = 174;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn5.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn5.Caption = "Mở";
            this.treeListColumn5.ColumnEdit = this.repositoryItemCheckEdit1;
            this.treeListColumn5.FieldName = "Mở";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 1;
            this.treeListColumn5.Width = 42;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEdit1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "QuyHoachKS",
            "HoatDongKS",
            "Ban Do Nen",
            "Anh Ve Tinh"});
            this.comboBox1.Location = new System.Drawing.Point(242, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(16, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.Visible = false;
            // 
            // Cbolop2
            // 
            this.Cbolop2.FormattingEnabled = true;
            this.Cbolop2.Location = new System.Drawing.Point(308, 9);
            this.Cbolop2.Name = "Cbolop2";
            this.Cbolop2.Size = new System.Drawing.Size(23, 21);
            this.Cbolop2.TabIndex = 24;
            // 
            // tabPane1
            // 
            this.tabPane1.AllowResize = false;
            this.tabPane1.Controls.Add(this.tabNavigationPage1);
            this.tabPane1.Controls.Add(this.tabNavigationPage2);
            this.tabPane1.Controls.Add(this.tabNavigationPage3);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 0);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage3,
            this.tabNavigationPage2,
            this.tabNavigationPage1});
            this.tabPane1.RegularSize = new System.Drawing.Size(198, 846);
            this.tabPane1.SelectedPage = this.tabNavigationPage1;
            this.tabPane1.Size = new System.Drawing.Size(198, 846);
            this.tabPane1.TabIndex = 2;
            this.tabPane1.Text = "tabPane1";
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "Lớp layer";
            this.tabNavigationPage2.Controls.Add(axTOCControl1);
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(180, 801);
            // 
            // axTOCControl1
            // 
            axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            axTOCControl1.Location = new System.Drawing.Point(0, 0);
            axTOCControl1.Name = "axTOCControl1";
            axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            axTOCControl1.Size = new System.Drawing.Size(180, 801);
            axTOCControl1.TabIndex = 1;
            axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(axTOCControl1_OnMouseDown);
            axTOCControl1.OnDoubleClick += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnDoubleClickEventHandler(axTOCControl1_OnDoubleClick);
            axTOCControl1.OnBeginLabelEdit += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnBeginLabelEditEventHandler(axTOCControl1_OnBeginLabelEdit);
            axTOCControl1.OnEndLabelEdit += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnEndLabelEditEventHandler(axTOCControl1_OnEndLabelEdit);
            // 
            // tabNavigationPage3
            // 
            this.tabNavigationPage3.Caption = "Quản lý cây xanh";
            this.tabNavigationPage3.Controls.Add(this.xtraTabControl1);
            this.tabNavigationPage3.Name = "tabNavigationPage3";
            this.tabNavigationPage3.PageVisible = false;
            this.tabNavigationPage3.Size = new System.Drawing.Size(180, 801);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(180, 801);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.splitContainerControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(174, 773);
            this.xtraTabPage1.Text = "Thông tin cây xanh";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.GroupBox1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.GroupBox2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(174, 773);
            this.splitContainerControl1.SplitterPosition = 192;
            this.splitContainerControl1.TabIndex = 8;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cboLoaiCay);
            this.GroupBox1.Controls.Add(this.cboDuong);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.cboPhuong);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.cboQuan);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.comboBox3);
            this.GroupBox1.Controls.Add(this.lbPhuong);
            this.GroupBox1.Controls.Add(this.txtMaCay);
            this.GroupBox1.Controls.Add(this.Btloadlailop);
            this.GroupBox1.Controls.Add(this.BtTracuu);
            this.GroupBox1.Controls.Add(this.lbTenDA);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(174, 192);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            // 
            // cboLoaiCay
            // 
            this.cboLoaiCay.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboLoaiCay.FormattingEnabled = true;
            this.cboLoaiCay.Items.AddRange(new object[] {
            "",
            "Tầng cao",
            "Tầng trung",
            "Cây bụi",
            "Thảm"});
            this.cboLoaiCay.Location = new System.Drawing.Point(150, 112);
            this.cboLoaiCay.Name = "cboLoaiCay";
            this.cboLoaiCay.Size = new System.Drawing.Size(117, 23);
            this.cboLoaiCay.TabIndex = 59;
            // 
            // cboDuong
            // 
            this.cboDuong.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboDuong.FormattingEnabled = true;
            this.cboDuong.Items.AddRange(new object[] {
            ""});
            this.cboDuong.Location = new System.Drawing.Point(9, 71);
            this.cboDuong.Name = "cboDuong";
            this.cboDuong.Size = new System.Drawing.Size(258, 23);
            this.cboDuong.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(8, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 57;
            this.label4.Text = "Đường:";
            // 
            // cboPhuong
            // 
            this.cboPhuong.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboPhuong.FormattingEnabled = true;
            this.cboPhuong.Items.AddRange(new object[] {
            ""});
            this.cboPhuong.Location = new System.Drawing.Point(140, 30);
            this.cboPhuong.Name = "cboPhuong";
            this.cboPhuong.Size = new System.Drawing.Size(127, 23);
            this.cboPhuong.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(147, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 55;
            this.label5.Text = "Phường/Xã :";
            // 
            // cboQuan
            // 
            this.cboQuan.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboQuan.FormattingEnabled = true;
            this.cboQuan.Items.AddRange(new object[] {
            ""});
            this.cboQuan.Location = new System.Drawing.Point(9, 30);
            this.cboQuan.Name = "cboQuan";
            this.cboQuan.Size = new System.Drawing.Size(125, 23);
            this.cboQuan.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(6, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 53;
            this.label6.Text = "Quận/Huyện:";
            // 
            // comboBox3
            // 
            this.comboBox3.AllowDrop = true;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(199, 71);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(10, 23);
            this.comboBox3.TabIndex = 41;
            // 
            // lbPhuong
            // 
            this.lbPhuong.AutoSize = true;
            this.lbPhuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbPhuong.Location = new System.Drawing.Point(151, 94);
            this.lbPhuong.Name = "lbPhuong";
            this.lbPhuong.Size = new System.Drawing.Size(58, 15);
            this.lbPhuong.TabIndex = 26;
            this.lbPhuong.Text = "Loại cây :";
            // 
            // txtMaCay
            // 
            this.txtMaCay.Location = new System.Drawing.Point(9, 113);
            this.txtMaCay.Name = "txtMaCay";
            this.txtMaCay.Size = new System.Drawing.Size(135, 21);
            this.txtMaCay.TabIndex = 25;
            // 
            // Btloadlailop
            // 
            this.Btloadlailop.Image = ((System.Drawing.Image)(resources.GetObject("Btloadlailop.Image")));
            this.Btloadlailop.Location = new System.Drawing.Point(169, 141);
            this.Btloadlailop.Name = "Btloadlailop";
            this.Btloadlailop.Size = new System.Drawing.Size(50, 45);
            this.Btloadlailop.TabIndex = 4;
            this.Btloadlailop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btloadlailop.UseVisualStyleBackColor = true;
            // 
            // BtTracuu
            // 
            this.BtTracuu.Image = ((System.Drawing.Image)(resources.GetObject("BtTracuu.Image")));
            this.BtTracuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtTracuu.Location = new System.Drawing.Point(9, 141);
            this.BtTracuu.Name = "BtTracuu";
            this.BtTracuu.Size = new System.Drawing.Size(154, 47);
            this.BtTracuu.TabIndex = 3;
            this.BtTracuu.Text = "Tra cứu";
            this.BtTracuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtTracuu.UseVisualStyleBackColor = true;
            // 
            // lbTenDA
            // 
            this.lbTenDA.AutoSize = true;
            this.lbTenDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTenDA.Location = new System.Drawing.Point(8, 95);
            this.lbTenDA.Name = "lbTenDA";
            this.lbTenDA.Size = new System.Drawing.Size(52, 15);
            this.lbTenDA.TabIndex = 0;
            this.lbTenDA.Text = "Mã cây :";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.splitContainer3);
            this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.GroupBox2.Location = new System.Drawing.Point(0, 0);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(174, 576);
            this.GroupBox2.TabIndex = 4;
            this.GroupBox2.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 17);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gridControl1);
            this.splitContainer3.Panel1.Controls.Add(this.bindingNavigator1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.button9);
            this.splitContainer3.Panel2.Controls.Add(this.button12);
            this.splitContainer3.Panel2.Controls.Add(this.btChinhSua);
            this.splitContainer3.Panel2.Controls.Add(this.BtExcell);
            this.splitContainer3.Size = new System.Drawing.Size(168, 556);
            this.splitContainer3.SplitterDistance = 439;
            this.splitContainer3.TabIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(168, 439);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupButton.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.GroupButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.GroupButton.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.ViewCaption.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ViewCaption.Options.UseBackColor = true;
            this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView1.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.White;
            this.gridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
            this.gridView1.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            this.gridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.gridView1.AppearancePrint.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.AppearancePrint.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.AppearancePrint.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White;
            this.gridView1.AppearancePrint.GroupFooter.Options.UseBackColor = true;
            this.gridView1.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridView1.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn22,
            this.gridColumn23,
            this.OBJECTID,
            this.gridColumn7});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.RowHeight = 27;
            this.gridView1.ViewCaption = "KẾT QUẢ TRA CỨU";
            this.gridView1.ViewCaptionHeight = 30;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Loại cây";
            this.gridColumn1.FieldName = "LoaiCay";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã cây";
            this.gridColumn2.FieldName = "MaCay";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên thông thường";
            this.gridColumn3.FieldName = "TenThongThuong";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 113;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Chiều cao";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Đường kính thân";
            this.gridColumn5.FieldName = "DuongKinhThan";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Đường kính tán";
            this.gridColumn6.FieldName = "DuongKinhTan";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Độ tuổi";
            this.gridColumn8.FieldName = "DoTuoi";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Tọa độ";
            this.gridColumn9.FieldName = "ToaDo";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 10;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Trạng thái";
            this.gridColumn10.FieldName = "TrangThai";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 11;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Ghi chú";
            this.gridColumn11.FieldName = "GhiChu";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 12;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Phường";
            this.gridColumn22.FieldName = "Phuong";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 2;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Đường";
            this.gridColumn23.FieldName = "Duong";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 3;
            this.gridColumn23.Width = 107;
            // 
            // OBJECTID
            // 
            this.OBJECTID.Caption = "OBJECTID";
            this.OBJECTID.FieldName = "OBJECTID";
            this.OBJECTID.Name = "OBJECTID";
            this.OBJECTID.Visible = true;
            this.OBJECTID.VisibleIndex = 13;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Năm trồng";
            this.gridColumn7.FieldName = "NamTrong";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.toolStripButton1;
            this.bindingNavigator1.CountItem = this.toolStripLabel1;
            this.bindingNavigator1.DeleteItem = this.toolStripButton2;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator8,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator9,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator10,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton7,
            this.toolStripButton8});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 381);
            this.bindingNavigator1.MoveFirstItem = this.toolStripButton3;
            this.bindingNavigator1.MoveLastItem = this.toolStripButton6;
            this.bindingNavigator1.MoveNextItem = this.toolStripButton5;
            this.bindingNavigator1.MovePreviousItem = this.toolStripButton4;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.toolStripTextBox1;
            this.bindingNavigator1.Size = new System.Drawing.Size(168, 25);
            this.bindingNavigator1.TabIndex = 9;
            this.bindingNavigator1.Text = "bindingNavigator1";
            this.bindingNavigator1.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton1.Text = "Thêm đối tượng";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel1.Text = "of {0}";
            this.toolStripLabel1.ToolTipText = "Total number of items";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton2.Text = "Xóa đối tượng";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Move first";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Move previous";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Position";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 20);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Current position";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton5.Text = "Move next";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton6.Text = "Move last";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::QLHTDT.Properties.Resources.Save_32x32;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton7.Text = "Lưu chỉnh sửa";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::QLHTDT.Properties.Resources.reset;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton8.Text = "Tải lại";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(144, 59);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(106, 48);
            this.button9.TabIndex = 65;
            this.button9.Text = "Thoát";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(144, 5);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(106, 48);
            this.button12.TabIndex = 64;
            this.button12.Text = "Cập nhật";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // btChinhSua
            // 
            this.btChinhSua.Location = new System.Drawing.Point(14, 5);
            this.btChinhSua.Name = "btChinhSua";
            this.btChinhSua.Size = new System.Drawing.Size(109, 48);
            this.btChinhSua.TabIndex = 63;
            this.btChinhSua.Text = "Chỉnh sửa";
            this.btChinhSua.UseVisualStyleBackColor = true;
            // 
            // BtExcell
            // 
            this.BtExcell.Image = ((System.Drawing.Image)(resources.GetObject("BtExcell.Image")));
            this.BtExcell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtExcell.Location = new System.Drawing.Point(14, 59);
            this.BtExcell.Name = "BtExcell";
            this.BtExcell.Size = new System.Drawing.Size(109, 48);
            this.BtExcell.TabIndex = 62;
            this.BtExcell.Text = "Xuất Excel";
            this.BtExcell.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtExcell.UseVisualStyleBackColor = true;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.splitContainerControl2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(174, 773);
            this.xtraTabPage2.Text = "Quản lý chăm sóc";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.groupBox3);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(174, 773);
            this.splitContainerControl2.SplitterPosition = 192;
            this.splitContainerControl2.TabIndex = 9;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboLoaiCay1);
            this.groupBox3.Controls.Add(this.cboDuong1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cboPhuong1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cboQuan1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.comboBox5);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtMaCay1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 192);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // cboLoaiCay1
            // 
            this.cboLoaiCay1.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboLoaiCay1.FormattingEnabled = true;
            this.cboLoaiCay1.Items.AddRange(new object[] {
            "",
            "Tầng cao",
            "Tầng trung",
            "Cây bụi",
            "Thảm"});
            this.cboLoaiCay1.Location = new System.Drawing.Point(151, 113);
            this.cboLoaiCay1.Name = "cboLoaiCay1";
            this.cboLoaiCay1.Size = new System.Drawing.Size(117, 23);
            this.cboLoaiCay1.TabIndex = 73;
            // 
            // cboDuong1
            // 
            this.cboDuong1.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboDuong1.FormattingEnabled = true;
            this.cboDuong1.Items.AddRange(new object[] {
            ""});
            this.cboDuong1.Location = new System.Drawing.Point(10, 72);
            this.cboDuong1.Name = "cboDuong1";
            this.cboDuong1.Size = new System.Drawing.Size(258, 23);
            this.cboDuong1.TabIndex = 71;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(9, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 72;
            this.label7.Text = "Đường:";
            // 
            // cboPhuong1
            // 
            this.cboPhuong1.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboPhuong1.FormattingEnabled = true;
            this.cboPhuong1.Items.AddRange(new object[] {
            ""});
            this.cboPhuong1.Location = new System.Drawing.Point(141, 31);
            this.cboPhuong1.Name = "cboPhuong1";
            this.cboPhuong1.Size = new System.Drawing.Size(127, 23);
            this.cboPhuong1.TabIndex = 69;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(148, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 70;
            this.label8.Text = "Phường/Xã :";
            // 
            // cboQuan1
            // 
            this.cboQuan1.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboQuan1.FormattingEnabled = true;
            this.cboQuan1.Items.AddRange(new object[] {
            ""});
            this.cboQuan1.Location = new System.Drawing.Point(10, 31);
            this.cboQuan1.Name = "cboQuan1";
            this.cboQuan1.Size = new System.Drawing.Size(125, 23);
            this.cboQuan1.TabIndex = 67;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(7, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 15);
            this.label9.TabIndex = 68;
            this.label9.Text = "Quận/Huyện:";
            // 
            // comboBox5
            // 
            this.comboBox5.AllowDrop = true;
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(200, 72);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(10, 23);
            this.comboBox5.TabIndex = 66;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(152, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 15);
            this.label10.TabIndex = 65;
            this.label10.Text = "Loại cây :";
            // 
            // txtMaCay1
            // 
            this.txtMaCay1.Location = new System.Drawing.Point(10, 114);
            this.txtMaCay1.Name = "txtMaCay1";
            this.txtMaCay1.Size = new System.Drawing.Size(135, 21);
            this.txtMaCay1.TabIndex = 64;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(170, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 47);
            this.button1.TabIndex = 63;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(10, 142);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 47);
            this.button3.TabIndex = 62;
            this.button3.Text = "Tra cứu";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.Location = new System.Drawing.Point(9, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 61;
            this.label11.Text = "Mã cây :";
            // 
            // button4
            // 
            this.button4.Image = global::QLHTDT.Properties.Resources.next_32x32;
            this.button4.Location = new System.Drawing.Point(163, 526);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 28);
            this.button4.TabIndex = 60;
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.splitContainer4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(174, 576);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 17);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.gridControl2);
            this.splitContainer4.Panel1.Controls.Add(this.bindingNavigator2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.button5);
            this.splitContainer4.Panel2.Controls.Add(this.btChinhSua1);
            this.splitContainer4.Panel2.Controls.Add(this.BtExcell1);
            this.splitContainer4.Size = new System.Drawing.Size(168, 556);
            this.splitContainer4.SplitterDistance = 484;
            this.splitContainer4.TabIndex = 4;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.bandedGridView1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(168, 459);
            this.gridControl2.TabIndex = 10;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.GroupButton.Options.UseTextOptions = true;
            this.bandedGridView1.Appearance.GroupButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView1.Appearance.GroupButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridView1.Appearance.GroupButton.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bandedGridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bandedGridView1.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.Row.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.ViewCaption.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black;
            this.bandedGridView1.Appearance.ViewCaption.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.ViewCaption.Options.UseFont = true;
            this.bandedGridView1.Appearance.ViewCaption.Options.UseForeColor = true;
            this.bandedGridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
            this.bandedGridView1.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            this.bandedGridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.bandedGridView1.AppearancePrint.FooterPanel.Options.UseTextOptions = true;
            this.bandedGridView1.AppearancePrint.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.bandedGridView1.AppearancePrint.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridView1.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.AppearancePrint.GroupFooter.Options.UseBackColor = true;
            this.bandedGridView1.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.bandedGridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.bandedGridView1.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.bandedGridView1.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView1.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand7,
            this.gridBand3,
            this.gridBand6,
            this.gridBand4,
            this.gridBand5});
            this.bandedGridView1.ColumnPanelRowHeight = 30;
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4,
            this.bandedGridColumn5,
            this.bandedGridColumn6,
            this.bandedGridColumn7,
            this.bandedGridColumn8,
            this.bandedGridColumn9,
            this.bandedGridColumn10,
            this.bandedGridColumn11,
            this.bandedGridColumn12,
            this.bandedGridColumn13,
            this.bandedGridColumn14,
            this.bandedGridColumn15,
            this.bandedGridColumn16,
            this.bandedGridColumn17});
            this.bandedGridView1.CustomizationFormBounds = new System.Drawing.Rectangle(1546, 188, 216, 502);
            this.bandedGridView1.GridControl = this.gridControl2;
            this.bandedGridView1.IndicatorWidth = 40;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridView1.OptionsPrint.EnableAppearanceEvenRow = true;
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView1.OptionsView.RowAutoHeight = true;
            this.bandedGridView1.OptionsView.ShowFooter = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.OptionsView.ShowViewCaption = true;
            this.bandedGridView1.RowHeight = 27;
            this.bandedGridView1.ViewCaption = "KẾT QUẢ TRA CỨU";
            this.bandedGridView1.ViewCaptionHeight = 30;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Thông tin cây xanh";
            this.gridBand2.Columns.Add(this.bandedGridColumn2);
            this.gridBand2.Columns.Add(this.bandedGridColumn3);
            this.gridBand2.Columns.Add(this.bandedGridColumn15);
            this.gridBand2.Columns.Add(this.bandedGridColumn16);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.RowCount = 2;
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 279;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn2.Caption = "Loại Cây";
            this.bandedGridColumn2.FieldName = "LoaiCay";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 70;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn3.Caption = "Mã cây";
            this.bandedGridColumn3.FieldName = "MaCay";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.Width = 59;
            // 
            // bandedGridColumn15
            // 
            this.bandedGridColumn15.Caption = "Phường";
            this.bandedGridColumn15.FieldName = "Phuong";
            this.bandedGridColumn15.Name = "bandedGridColumn15";
            this.bandedGridColumn15.Visible = true;
            // 
            // bandedGridColumn16
            // 
            this.bandedGridColumn16.Caption = "Đường";
            this.bandedGridColumn16.FieldName = "Duong";
            this.bandedGridColumn16.Name = "bandedGridColumn16";
            this.bandedGridColumn16.Visible = true;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridBand7.AppearanceHeader.Options.UseFont = true;
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "Thông tin vận hành chăm sóc";
            this.gridBand7.Columns.Add(this.bandedGridColumn12);
            this.gridBand7.Columns.Add(this.bandedGridColumn13);
            this.gridBand7.Columns.Add(this.bandedGridColumn14);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 1;
            this.gridBand7.Width = 212;
            // 
            // bandedGridColumn12
            // 
            this.bandedGridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn12.Caption = "Mật độ";
            this.bandedGridColumn12.Name = "bandedGridColumn12";
            this.bandedGridColumn12.Visible = true;
            this.bandedGridColumn12.Width = 62;
            // 
            // bandedGridColumn13
            // 
            this.bandedGridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn13.Caption = "Chế độ chăm sóc";
            this.bandedGridColumn13.Name = "bandedGridColumn13";
            this.bandedGridColumn13.Visible = true;
            // 
            // bandedGridColumn14
            // 
            this.bandedGridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn14.Caption = "Thời gian chăm sóc cắt tỉa";
            this.bandedGridColumn14.Name = "bandedGridColumn14";
            this.bandedGridColumn14.Visible = true;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Thông tin tưới cây";
            this.gridBand3.Columns.Add(this.bandedGridColumn4);
            this.gridBand3.Columns.Add(this.bandedGridColumn5);
            this.gridBand3.Columns.Add(this.bandedGridColumn6);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 155;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn4.Caption = "Diện tích";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn4.Width = 62;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn5.Caption = "Phương tiện/Thiết bị";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Visible = true;
            this.bandedGridColumn5.Width = 93;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.Caption = "Ngày cập nhật";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Width = 67;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridBand6.AppearanceHeader.Options.UseFont = true;
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "Chặt hạ di chuyển";
            this.gridBand6.Columns.Add(this.bandedGridColumn9);
            this.gridBand6.Columns.Add(this.bandedGridColumn10);
            this.gridBand6.Columns.Add(this.bandedGridColumn11);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 3;
            this.gridBand6.Width = 294;
            // 
            // bandedGridColumn9
            // 
            this.bandedGridColumn9.Caption = "Chết gãy đỗ";
            this.bandedGridColumn9.Name = "bandedGridColumn9";
            this.bandedGridColumn9.Visible = true;
            this.bandedGridColumn9.Width = 82;
            // 
            // bandedGridColumn10
            // 
            this.bandedGridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn10.Caption = "Bệnh tuổi già không an toàn";
            this.bandedGridColumn10.Name = "bandedGridColumn10";
            this.bandedGridColumn10.Visible = true;
            this.bandedGridColumn10.Width = 116;
            // 
            // bandedGridColumn11
            // 
            this.bandedGridColumn11.Caption = "Thuộc dự án XDCT đang thực hiện";
            this.bandedGridColumn11.Name = "bandedGridColumn11";
            this.bandedGridColumn11.Visible = true;
            this.bandedGridColumn11.Width = 96;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "Thông tin bảo vệ";
            this.gridBand4.Columns.Add(this.bandedGridColumn7);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 4;
            this.gridBand4.Width = 81;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn7.Caption = "Mô tả";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Visible = true;
            this.bandedGridColumn7.Width = 81;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "Thông tin cây bệnh";
            this.gridBand5.Columns.Add(this.bandedGridColumn8);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 5;
            this.gridBand5.Width = 75;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.Caption = "Mô tả";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.Visible = true;
            // 
            // bandedGridColumn17
            // 
            this.bandedGridColumn17.Caption = "OBJECTID";
            this.bandedGridColumn17.FieldName = "OBJECTID";
            this.bandedGridColumn17.Name = "bandedGridColumn17";
            // 
            // bindingNavigator2
            // 
            this.bindingNavigator2.AddNewItem = this.toolStripButton9;
            this.bindingNavigator2.CountItem = this.toolStripLabel2;
            this.bindingNavigator2.DeleteItem = this.toolStripButton10;
            this.bindingNavigator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton11,
            this.toolStripButton12,
            this.toolStripSeparator11,
            this.toolStripTextBox2,
            this.toolStripLabel2,
            this.toolStripSeparator12,
            this.toolStripButton13,
            this.toolStripButton14,
            this.toolStripSeparator13,
            this.toolStripButton9,
            this.toolStripButton10,
            this.toolStripButton15,
            this.toolStripButton16});
            this.bindingNavigator2.Location = new System.Drawing.Point(0, 459);
            this.bindingNavigator2.MoveFirstItem = this.toolStripButton11;
            this.bindingNavigator2.MoveLastItem = this.toolStripButton14;
            this.bindingNavigator2.MoveNextItem = this.toolStripButton13;
            this.bindingNavigator2.MovePreviousItem = this.toolStripButton12;
            this.bindingNavigator2.Name = "bindingNavigator2";
            this.bindingNavigator2.PositionItem = this.toolStripTextBox2;
            this.bindingNavigator2.Size = new System.Drawing.Size(168, 25);
            this.bindingNavigator2.TabIndex = 9;
            this.bindingNavigator2.Text = "bindingNavigator2";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.RightToLeftAutoMirrorImage = true;
            this.toolStripButton9.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton9.Text = "Thêm đối tượng";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel2.Text = "of {0}";
            this.toolStripLabel2.ToolTipText = "Total number of items";
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.RightToLeftAutoMirrorImage = true;
            this.toolStripButton10.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton10.Text = "Xóa đối tượng";
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.RightToLeftAutoMirrorImage = true;
            this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton11.Text = "Move first";
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.RightToLeftAutoMirrorImage = true;
            this.toolStripButton12.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton12.Text = "Move previous";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.AccessibleName = "Position";
            this.toolStripTextBox2.AutoSize = false;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(50, 20);
            this.toolStripTextBox2.Text = "0";
            this.toolStripTextBox2.ToolTipText = "Current position";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.RightToLeftAutoMirrorImage = true;
            this.toolStripButton13.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton13.Text = "Move next";
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.RightToLeftAutoMirrorImage = true;
            this.toolStripButton14.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton14.Text = "Move last";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton15.Image = global::QLHTDT.Properties.Resources.Save_32x32;
            this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton15.Text = "Lưu chỉnh sửa";
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton16.Image = global::QLHTDT.Properties.Resources.reset;
            this.toolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton16.Text = "Tải lại";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(133, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 48);
            this.button5.TabIndex = 64;
            this.button5.Text = "Cập nhật";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btChinhSua1
            // 
            this.btChinhSua1.Location = new System.Drawing.Point(8, 5);
            this.btChinhSua1.Name = "btChinhSua1";
            this.btChinhSua1.Size = new System.Drawing.Size(109, 48);
            this.btChinhSua1.TabIndex = 63;
            this.btChinhSua1.Text = "Chỉnh sửa";
            this.btChinhSua1.UseVisualStyleBackColor = true;
            // 
            // BtExcell1
            // 
            this.BtExcell1.Image = ((System.Drawing.Image)(resources.GetObject("BtExcell1.Image")));
            this.BtExcell1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtExcell1.Location = new System.Drawing.Point(253, 5);
            this.BtExcell1.Name = "BtExcell1";
            this.BtExcell1.Size = new System.Drawing.Size(116, 48);
            this.BtExcell1.TabIndex = 62;
            this.BtExcell1.Text = "Xuất Excel";
            this.BtExcell1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtExcell1.UseVisualStyleBackColor = true;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.splitContainerControl3);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(174, 773);
            this.xtraTabPage3.Text = "Quản lý chi phí";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Horizontal = false;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.groupBox5);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            this.splitContainerControl3.Panel2.Controls.Add(this.groupBox6);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(174, 773);
            this.splitContainerControl3.SplitterPosition = 190;
            this.splitContainerControl3.TabIndex = 10;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboLoaiCay2);
            this.groupBox5.Controls.Add(this.cboDuong2);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.cboPhuong2);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.cboQuan2);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.comboBox10);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtMaCay2);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.button8);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(174, 190);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // cboLoaiCay2
            // 
            this.cboLoaiCay2.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboLoaiCay2.FormattingEnabled = true;
            this.cboLoaiCay2.Items.AddRange(new object[] {
            "",
            "Tầng cao",
            "Tầng trung",
            "Cây bụi",
            "Thảm"});
            this.cboLoaiCay2.Location = new System.Drawing.Point(152, 111);
            this.cboLoaiCay2.Name = "cboLoaiCay2";
            this.cboLoaiCay2.Size = new System.Drawing.Size(117, 23);
            this.cboLoaiCay2.TabIndex = 73;
            // 
            // cboDuong2
            // 
            this.cboDuong2.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboDuong2.FormattingEnabled = true;
            this.cboDuong2.Items.AddRange(new object[] {
            ""});
            this.cboDuong2.Location = new System.Drawing.Point(11, 70);
            this.cboDuong2.Name = "cboDuong2";
            this.cboDuong2.Size = new System.Drawing.Size(258, 23);
            this.cboDuong2.TabIndex = 71;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.Location = new System.Drawing.Point(10, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 15);
            this.label12.TabIndex = 72;
            this.label12.Text = "Đường:";
            // 
            // cboPhuong2
            // 
            this.cboPhuong2.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboPhuong2.FormattingEnabled = true;
            this.cboPhuong2.Items.AddRange(new object[] {
            ""});
            this.cboPhuong2.Location = new System.Drawing.Point(142, 29);
            this.cboPhuong2.Name = "cboPhuong2";
            this.cboPhuong2.Size = new System.Drawing.Size(127, 23);
            this.cboPhuong2.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.Location = new System.Drawing.Point(149, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 15);
            this.label13.TabIndex = 70;
            this.label13.Text = "Phường/Xã :";
            // 
            // cboQuan2
            // 
            this.cboQuan2.AutoCompleteCustomSource.AddRange(new string[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Đông",
            "Hòa Thọ Tây",
            "Hòa Xuân",
            "Khuê Trung"});
            this.cboQuan2.FormattingEnabled = true;
            this.cboQuan2.Items.AddRange(new object[] {
            ""});
            this.cboQuan2.Location = new System.Drawing.Point(11, 29);
            this.cboQuan2.Name = "cboQuan2";
            this.cboQuan2.Size = new System.Drawing.Size(125, 23);
            this.cboQuan2.TabIndex = 67;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label14.Location = new System.Drawing.Point(8, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 15);
            this.label14.TabIndex = 68;
            this.label14.Text = "Quận/Huyện:";
            // 
            // comboBox10
            // 
            this.comboBox10.AllowDrop = true;
            this.comboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Location = new System.Drawing.Point(201, 70);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(10, 23);
            this.comboBox10.TabIndex = 66;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label15.Location = new System.Drawing.Point(153, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 15);
            this.label15.TabIndex = 65;
            this.label15.Text = "Loại cây :";
            // 
            // txtMaCay2
            // 
            this.txtMaCay2.Location = new System.Drawing.Point(11, 112);
            this.txtMaCay2.Name = "txtMaCay2";
            this.txtMaCay2.Size = new System.Drawing.Size(135, 21);
            this.txtMaCay2.TabIndex = 64;
            // 
            // button6
            // 
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(171, 140);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 47);
            this.button6.TabIndex = 63;
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(11, 140);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(154, 47);
            this.button7.TabIndex = 62;
            this.button7.Text = "Tra cứu";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label16.Location = new System.Drawing.Point(10, 94);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 15);
            this.label16.TabIndex = 61;
            this.label16.Text = "Mã cây :";
            // 
            // button8
            // 
            this.button8.Image = global::QLHTDT.Properties.Resources.next_32x32;
            this.button8.Location = new System.Drawing.Point(163, 526);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(28, 28);
            this.button8.TabIndex = 60;
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.splitContainer5);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(174, 578);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(3, 17);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.gridControl3);
            this.splitContainer5.Panel1.Controls.Add(this.bindingNavigator3);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.button10);
            this.splitContainer5.Panel2.Controls.Add(this.btChinhSua2);
            this.splitContainer5.Panel2.Controls.Add(this.btXExcel2);
            this.splitContainer5.Size = new System.Drawing.Size(168, 558);
            this.splitContainer5.SplitterDistance = 487;
            this.splitContainer5.TabIndex = 4;
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(0, 0);
            this.gridControl3.MainView = this.gridView2;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(168, 462);
            this.gridControl3.TabIndex = 10;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.FooterPanel.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView2.Appearance.GroupButton.Options.UseTextOptions = true;
            this.gridView2.Appearance.GroupButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.GroupButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView2.Appearance.GroupButton.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView2.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.ViewCaption.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.ViewCaption.Options.UseBackColor = true;
            this.gridView2.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView2.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gridView2.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.White;
            this.gridView2.AppearancePrint.EvenRow.Options.UseBackColor = true;
            this.gridView2.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White;
            this.gridView2.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView2.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            this.gridView2.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.gridView2.AppearancePrint.FooterPanel.Options.UseTextOptions = true;
            this.gridView2.AppearancePrint.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView2.AppearancePrint.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView2.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White;
            this.gridView2.AppearancePrint.GroupFooter.Options.UseBackColor = true;
            this.gridView2.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.gridView2.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView2.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridView2.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridView2.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView2.ColumnPanelRowHeight = 30;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26});
            this.gridView2.GridControl = this.gridControl3;
            this.gridView2.IndicatorWidth = 40;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView2.OptionsView.RowAutoHeight = true;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowViewCaption = true;
            this.gridView2.RowHeight = 27;
            this.gridView2.ViewCaption = "KẾT QUẢ TRA CỨU";
            this.gridView2.ViewCaptionHeight = 30;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Loại cây";
            this.gridColumn17.FieldName = "LoaiCay";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 1;
            this.gridColumn17.Width = 58;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Mã cây";
            this.gridColumn18.FieldName = "MaCay";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 0;
            this.gridColumn18.Width = 56;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Thời gian phát sinh";
            this.gridColumn12.FieldName = "ThoiGianPhatSinh";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            this.gridColumn12.Width = 90;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Nhân công";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            this.gridColumn13.Width = 135;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Số lượng";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 6;
            this.gridColumn14.Width = 85;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Mô tả";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 8;
            this.gridColumn15.Width = 160;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Chi Phí";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 7;
            this.gridColumn16.Width = 164;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Phường";
            this.gridColumn24.FieldName = "Phuong";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 2;
            this.gridColumn24.Width = 85;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Đường";
            this.gridColumn25.FieldName = "Duong";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 3;
            this.gridColumn25.Width = 135;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "OBJECTID";
            this.gridColumn26.FieldName = "OBJECTID";
            this.gridColumn26.Name = "gridColumn26";
            // 
            // bindingNavigator3
            // 
            this.bindingNavigator3.AddNewItem = this.toolStripButton17;
            this.bindingNavigator3.CountItem = this.toolStripLabel3;
            this.bindingNavigator3.DeleteItem = this.toolStripButton18;
            this.bindingNavigator3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton19,
            this.toolStripButton20,
            this.toolStripSeparator14,
            this.toolStripTextBox3,
            this.toolStripLabel3,
            this.toolStripSeparator15,
            this.toolStripButton21,
            this.toolStripButton22,
            this.toolStripSeparator16,
            this.toolStripButton17,
            this.toolStripButton18,
            this.toolStripButton23,
            this.toolStripButton24});
            this.bindingNavigator3.Location = new System.Drawing.Point(0, 462);
            this.bindingNavigator3.MoveFirstItem = this.toolStripButton19;
            this.bindingNavigator3.MoveLastItem = this.toolStripButton22;
            this.bindingNavigator3.MoveNextItem = this.toolStripButton21;
            this.bindingNavigator3.MovePreviousItem = this.toolStripButton20;
            this.bindingNavigator3.Name = "bindingNavigator3";
            this.bindingNavigator3.PositionItem = this.toolStripTextBox3;
            this.bindingNavigator3.Size = new System.Drawing.Size(168, 25);
            this.bindingNavigator3.TabIndex = 9;
            this.bindingNavigator3.Text = "bindingNavigator3";
            // 
            // toolStripButton17
            // 
            this.toolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton17.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton17.Image")));
            this.toolStripButton17.Name = "toolStripButton17";
            this.toolStripButton17.RightToLeftAutoMirrorImage = true;
            this.toolStripButton17.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton17.Text = "Thêm đối tượng";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel3.Text = "of {0}";
            this.toolStripLabel3.ToolTipText = "Total number of items";
            // 
            // toolStripButton18
            // 
            this.toolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton18.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton18.Image")));
            this.toolStripButton18.Name = "toolStripButton18";
            this.toolStripButton18.RightToLeftAutoMirrorImage = true;
            this.toolStripButton18.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton18.Text = "Xóa đối tượng";
            // 
            // toolStripButton19
            // 
            this.toolStripButton19.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton19.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton19.Image")));
            this.toolStripButton19.Name = "toolStripButton19";
            this.toolStripButton19.RightToLeftAutoMirrorImage = true;
            this.toolStripButton19.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton19.Text = "Move first";
            // 
            // toolStripButton20
            // 
            this.toolStripButton20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton20.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton20.Image")));
            this.toolStripButton20.Name = "toolStripButton20";
            this.toolStripButton20.RightToLeftAutoMirrorImage = true;
            this.toolStripButton20.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton20.Text = "Move previous";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.AccessibleName = "Position";
            this.toolStripTextBox3.AutoSize = false;
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(50, 20);
            this.toolStripTextBox3.Text = "0";
            this.toolStripTextBox3.ToolTipText = "Current position";
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton21
            // 
            this.toolStripButton21.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton21.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton21.Image")));
            this.toolStripButton21.Name = "toolStripButton21";
            this.toolStripButton21.RightToLeftAutoMirrorImage = true;
            this.toolStripButton21.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton21.Text = "Move next";
            // 
            // toolStripButton22
            // 
            this.toolStripButton22.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton22.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton22.Image")));
            this.toolStripButton22.Name = "toolStripButton22";
            this.toolStripButton22.RightToLeftAutoMirrorImage = true;
            this.toolStripButton22.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton22.Text = "Move last";
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton23
            // 
            this.toolStripButton23.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton23.Image = global::QLHTDT.Properties.Resources.Save_32x32;
            this.toolStripButton23.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton23.Name = "toolStripButton23";
            this.toolStripButton23.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton23.Text = "Lưu chỉnh sửa";
            // 
            // toolStripButton24
            // 
            this.toolStripButton24.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton24.Image = global::QLHTDT.Properties.Resources.reset;
            this.toolStripButton24.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton24.Name = "toolStripButton24";
            this.toolStripButton24.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton24.Text = "Tải lại";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(133, 5);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(106, 48);
            this.button10.TabIndex = 64;
            this.button10.Text = "Cập nhật";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // btChinhSua2
            // 
            this.btChinhSua2.Location = new System.Drawing.Point(8, 5);
            this.btChinhSua2.Name = "btChinhSua2";
            this.btChinhSua2.Size = new System.Drawing.Size(109, 48);
            this.btChinhSua2.TabIndex = 63;
            this.btChinhSua2.Text = "Chỉnh sửa";
            this.btChinhSua2.UseVisualStyleBackColor = true;
            // 
            // btXExcel2
            // 
            this.btXExcel2.Image = ((System.Drawing.Image)(resources.GetObject("btXExcel2.Image")));
            this.btXExcel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btXExcel2.Location = new System.Drawing.Point(253, 5);
            this.btXExcel2.Name = "btXExcel2";
            this.btXExcel2.Size = new System.Drawing.Size(116, 48);
            this.btXExcel2.TabIndex = 62;
            this.btXExcel2.Text = "Xuất Excel";
            this.btXExcel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btXExcel2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabPane1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1264, 846);
            this.splitContainer2.SplitterDistance = 198;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1063, 846);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.TabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.axLicenseControl2);
            this.tabPage1.Controls.Add(axMapControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1055, 820);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bản đồ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // axLicenseControl2
            // 
            this.axLicenseControl2.Enabled = true;
            this.axLicenseControl2.Location = new System.Drawing.Point(397, 229);
            this.axLicenseControl2.Name = "axLicenseControl2";
            this.axLicenseControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl2.OcxState")));
            this.axLicenseControl2.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl2.TabIndex = 3;
            // 
            // axMapControl1
            // 
            axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            axMapControl1.Location = new System.Drawing.Point(3, 3);
            axMapControl1.Name = "axMapControl1";
            axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            axMapControl1.Size = new System.Drawing.Size(1049, 814);
            axMapControl1.TabIndex = 2;
            axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.HienMenuMap);
            axMapControl1.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.onmouseup);
            axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(axMapControl1_OnMouseMove);
            axMapControl1.OnDoubleClick += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnDoubleClickEventHandler(axMapControl1_OnDoubleClick);
            axMapControl1.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(axMapControl1_OnAfterScreenDraw);
            axMapControl1.OnAfterDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterDrawEventHandler(axMapControl1_OnAfterDraw);
            axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(axMapControl1_OnMapReplaced);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(axPageLayoutControl1);
            this.tabPage2.Controls.Add(this.axToolbarControl2);
            this.tabPage2.Controls.Add(this.axToolbarControl3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1055, 820);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trang in";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // axPageLayoutControl1
            // 
            axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            axPageLayoutControl1.Location = new System.Drawing.Point(3, 3);
            axPageLayoutControl1.Name = "axPageLayoutControl1";
            axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            axPageLayoutControl1.Size = new System.Drawing.Size(1049, 814);
            axPageLayoutControl1.TabIndex = 0;
            axPageLayoutControl1.OnMouseUp += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseUpEventHandler(this.onmouseupPage);
            axPageLayoutControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseMoveEventHandler(this.axPageControl1_OnMouseMove);
            axPageLayoutControl1.OnAfterDraw += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnAfterDrawEventHandler(axPageLayoutControl1_OnAfterDraw);
            axPageLayoutControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnExtentUpdatedEventHandler(axPageLayoutControl1_OnExtentUpdated);
            axPageLayoutControl1.OnFocusMapChanged += new System.EventHandler(axPageLayoutControl1_OnFocusMapChanged);
            axPageLayoutControl1.OnPageLayoutReplaced += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnPageLayoutReplacedEventHandler(axPageLayoutControl1_OnPageLayoutReplaced);
            axPageLayoutControl1.Resize += new System.EventHandler(axPageLayoutControl1_Resize);
            // 
            // axToolbarControl2
            // 
            this.axToolbarControl2.Location = new System.Drawing.Point(339, 143);
            this.axToolbarControl2.Name = "axToolbarControl2";
            this.axToolbarControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl2.OcxState")));
            this.axToolbarControl2.Size = new System.Drawing.Size(59, 28);
            this.axToolbarControl2.TabIndex = 2;
            // 
            // axToolbarControl3
            // 
            this.axToolbarControl3.Location = new System.Drawing.Point(764, 345);
            this.axToolbarControl3.Name = "axToolbarControl3";
            this.axToolbarControl3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl3.OcxState")));
            this.axToolbarControl3.Size = new System.Drawing.Size(74, 28);
            this.axToolbarControl3.TabIndex = 3;
            // 
            // chọnCỡGiấyToolStripMenuItem
            // 
            this.chọnCỡGiấyToolStripMenuItem.Image = global::QLHTDT.Properties.Resources.GenericDocument24;
            this.chọnCỡGiấyToolStripMenuItem.Name = "chọnCỡGiấyToolStripMenuItem";
            this.chọnCỡGiấyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.chọnCỡGiấyToolStripMenuItem.Text = "Chọn cỡ giấy";
            this.chọnCỡGiấyToolStripMenuItem.Click += new System.EventHandler(this.chọnCỡGiấyToolStripMenuItem_Click);
            // 
            // inToolStripMenuItem
            // 
            this.inToolStripMenuItem.Image = global::QLHTDT.Properties.Resources.PrinterNetwork_32x32;
            this.inToolStripMenuItem.Name = "inToolStripMenuItem";
            this.inToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inToolStripMenuItem.Text = "In";
            this.inToolStripMenuItem.Click += new System.EventHandler(this.inToolStripMenuItem_Click);
            // 
            // xuấtẢnhToolStripMenuItem
            // 
            this.xuấtẢnhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmChúGiảiToolStripMenuItem,
            this.thêmTiêuĐềToolStripMenuItem,
            this.thêmTỷLệToolStripMenuItem,
            this.thêmThướcTỷLệToolStripMenuItem,
            this.thêmChỉHướngBắcNamToolStripMenuItem,
            this.thêmDataFrameToolStripMenuItem,
            this.thêmLướiToolStripMenuItem});
            this.xuấtẢnhToolStripMenuItem.Image = global::QLHTDT.Properties.Resources.PrintPreview16;
            this.xuấtẢnhToolStripMenuItem.Name = "xuấtẢnhToolStripMenuItem";
            this.xuấtẢnhToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xuấtẢnhToolStripMenuItem.Text = "Biên tập trang in";
            // 
            // thêmChúGiảiToolStripMenuItem
            // 
            this.thêmChúGiảiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmChúThíchToolStripMenuItem,
            this.xóaChúThíchToolStripMenuItem,
            this.thayĐổiĐốiTượngVùngToolStripMenuItem,
            this.thayĐổiĐốiTượngĐườngToolStripMenuItem});
            this.thêmChúGiảiToolStripMenuItem.Name = "thêmChúGiảiToolStripMenuItem";
            this.thêmChúGiảiToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.thêmChúGiảiToolStripMenuItem.Text = "Thêm chú thích";
            this.thêmChúGiảiToolStripMenuItem.Click += new System.EventHandler(this.thêmChúGiảiToolStripMenuItem_Click);
            // 
            // thêmChúThíchToolStripMenuItem
            // 
            this.thêmChúThíchToolStripMenuItem.Name = "thêmChúThíchToolStripMenuItem";
            this.thêmChúThíchToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.thêmChúThíchToolStripMenuItem.Text = "Thêm chú thích";
            this.thêmChúThíchToolStripMenuItem.Visible = false;
            this.thêmChúThíchToolStripMenuItem.Click += new System.EventHandler(this.thêmChúGiảiToolStripMenuItem_Click);
            // 
            // xóaChúThíchToolStripMenuItem
            // 
            this.xóaChúThíchToolStripMenuItem.Name = "xóaChúThíchToolStripMenuItem";
            this.xóaChúThíchToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.xóaChúThíchToolStripMenuItem.Text = "Xóa chú thích";
            this.xóaChúThíchToolStripMenuItem.Visible = false;
            this.xóaChúThíchToolStripMenuItem.Click += new System.EventHandler(this.xóaChúThíchToolStripMenuItem_Click);
            // 
            // thayĐổiĐốiTượngVùngToolStripMenuItem
            // 
            this.thayĐổiĐốiTượngVùngToolStripMenuItem.Name = "thayĐổiĐốiTượngVùngToolStripMenuItem";
            this.thayĐổiĐốiTượngVùngToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.thayĐổiĐốiTượngVùngToolStripMenuItem.Text = "Thay đổi chú thích đối tượng vùng";
            this.thayĐổiĐốiTượngVùngToolStripMenuItem.Visible = false;
            this.thayĐổiĐốiTượngVùngToolStripMenuItem.Click += new System.EventHandler(this.thayĐổiĐốiTượngVùngToolStripMenuItem_Click);
            // 
            // thayĐổiĐốiTượngĐườngToolStripMenuItem
            // 
            this.thayĐổiĐốiTượngĐườngToolStripMenuItem.Name = "thayĐổiĐốiTượngĐườngToolStripMenuItem";
            this.thayĐổiĐốiTượngĐườngToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.thayĐổiĐốiTượngĐườngToolStripMenuItem.Text = "Thay đổi chú thích đối tượng đường";
            this.thayĐổiĐốiTượngĐườngToolStripMenuItem.Visible = false;
            this.thayĐổiĐốiTượngĐườngToolStripMenuItem.Click += new System.EventHandler(this.thayĐổiĐốiTượngĐườngToolStripMenuItem_Click);
            // 
            // thêmTiêuĐềToolStripMenuItem
            // 
            this.thêmTiêuĐềToolStripMenuItem.Name = "thêmTiêuĐềToolStripMenuItem";
            this.thêmTiêuĐềToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.thêmTiêuĐềToolStripMenuItem.Text = "Thêm tiêu đề";
            this.thêmTiêuĐềToolStripMenuItem.Click += new System.EventHandler(this.thêmTiêuĐềToolStripMenuItem_Click);
            // 
            // thêmTỷLệToolStripMenuItem
            // 
            this.thêmTỷLệToolStripMenuItem.Name = "thêmTỷLệToolStripMenuItem";
            this.thêmTỷLệToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.thêmTỷLệToolStripMenuItem.Text = "Thêm tỷ lệ";
            this.thêmTỷLệToolStripMenuItem.Click += new System.EventHandler(this.thêmTỷLệToolStripMenuItem_Click);
            // 
            // thêmThướcTỷLệToolStripMenuItem
            // 
            this.thêmThướcTỷLệToolStripMenuItem.Name = "thêmThướcTỷLệToolStripMenuItem";
            this.thêmThướcTỷLệToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.thêmThướcTỷLệToolStripMenuItem.Text = "Thêm thước tỷ lệ";
            this.thêmThướcTỷLệToolStripMenuItem.Click += new System.EventHandler(this.thêmThướcTỷLệToolStripMenuItem_Click);
            // 
            // thêmChỉHướngBắcNamToolStripMenuItem
            // 
            this.thêmChỉHướngBắcNamToolStripMenuItem.Name = "thêmChỉHướngBắcNamToolStripMenuItem";
            this.thêmChỉHướngBắcNamToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.thêmChỉHướngBắcNamToolStripMenuItem.Text = "Thêm chỉ hướng Bắc nam";
            this.thêmChỉHướngBắcNamToolStripMenuItem.Click += new System.EventHandler(this.thêmChỉHướngBắcNamToolStripMenuItem_Click);
            // 
            // thêmDataFrameToolStripMenuItem
            // 
            this.thêmDataFrameToolStripMenuItem.Name = "thêmDataFrameToolStripMenuItem";
            this.thêmDataFrameToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.thêmDataFrameToolStripMenuItem.Text = "Thêm data Frame";
            this.thêmDataFrameToolStripMenuItem.Click += new System.EventHandler(this.thêmDataFrameToolStripMenuItem_Click);
            // 
            // thêmLướiToolStripMenuItem
            // 
            this.thêmLướiToolStripMenuItem.Name = "thêmLướiToolStripMenuItem";
            this.thêmLướiToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.thêmLướiToolStripMenuItem.Text = "Thêm lưới";
            this.thêmLướiToolStripMenuItem.Click += new System.EventHandler(this.thêmLướiToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelControl1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 963);
            this.splitContainer1.SplitterDistance = 113;
            this.splitContainer1.TabIndex = 10;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.axToolbarControl5);
            this.panelControl1.Controls.Add(this.axToolbarControl1);
            this.panelControl1.Controls.Add(this.axToolbarControl4);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 25);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1264, 88);
            this.panelControl1.TabIndex = 7;
            // 
            // axToolbarControl5
            // 
            this.axToolbarControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axToolbarControl5.Location = new System.Drawing.Point(2, 30);
            this.axToolbarControl5.Name = "axToolbarControl5";
            this.axToolbarControl5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl5.OcxState")));
            this.axToolbarControl5.Size = new System.Drawing.Size(1047, 28);
            this.axToolbarControl5.TabIndex = 2;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(2, 2);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1047, 28);
            this.axToolbarControl1.TabIndex = 0;
            // 
            // axToolbarControl4
            // 
            this.axToolbarControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.axToolbarControl4.Location = new System.Drawing.Point(2, 58);
            this.axToolbarControl4.Name = "axToolbarControl4";
            this.axToolbarControl4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl4.OcxState")));
            this.axToolbarControl4.Size = new System.Drawing.Size(1047, 28);
            this.axToolbarControl4.TabIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.comboBox2);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.textBox1);
            this.panelControl2.Controls.Add(this.button2);
            this.panelControl2.Controls.Add(this.textBox2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(1049, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(213, 84);
            this.panelControl2.TabIndex = 8;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Tây",
            "Hòa Thọ Đông",
            "Khuê Trung",
            "Hòa Xuân"});
            this.comboBox2.Location = new System.Drawing.Point(5, 50);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(140, 21);
            this.comboBox2.TabIndex = 49;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.ChọnPhuongTraCuuQH_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Xác nhận Quy hoạch";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Số thửa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Số tờ";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(5, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(58, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "a";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.TraCuuNhanhQH_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(61, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(84, 21);
            this.textBox2.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.hệThốngToolStripMenuItem,
            this.bảnĐồToolStripMenuItem,
            this.trangInToolStripMenuItem,
            this.thanhCôngCụToolStripMenuItem,
            this.trợGiúpToolStripMenuItem,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1264, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mởBảnĐồToolStripMenuItem2,
            this.lưuBảnĐồToolStripMenuItem1,
            this.thêmLớpLayerToolStripMenuItem,
            this.toolStripSeparator1,
            this.mởFileAutoCadToolStripMenuItem,
            this.mởFileMicrostationdngToolStripMenuItem,
            this.exportToCadToolStripMenuItem1,
            this.toolStripSeparator2,
            this.toolStripMenuItem2,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15,
            this.toolStripSeparator7,
            this.thoátToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mởBảnĐồToolStripMenuItem2
            // 
            this.mởBảnĐồToolStripMenuItem2.Image = global::QLHTDT.Properties.Resources.Article_32x32;
            this.mởBảnĐồToolStripMenuItem2.Name = "mởBảnĐồToolStripMenuItem2";
            this.mởBảnĐồToolStripMenuItem2.Size = new System.Drawing.Size(239, 22);
            this.mởBảnĐồToolStripMenuItem2.Text = "Mở bản đồ";
            this.mởBảnĐồToolStripMenuItem2.Click += new System.EventHandler(this.mởBảnĐồToolStripMenuItem2_Click);
            // 
            // lưuBảnĐồToolStripMenuItem1
            // 
            this.lưuBảnĐồToolStripMenuItem1.Image = global::QLHTDT.Properties.Resources.Save_32x32;
            this.lưuBảnĐồToolStripMenuItem1.Name = "lưuBảnĐồToolStripMenuItem1";
            this.lưuBảnĐồToolStripMenuItem1.Size = new System.Drawing.Size(239, 22);
            this.lưuBảnĐồToolStripMenuItem1.Text = "Lưu bản đồ";
            this.lưuBảnĐồToolStripMenuItem1.Click += new System.EventHandler(this.lưuBảnĐồToolStripMenuItem1_Click);
            // 
            // thêmLớpLayerToolStripMenuItem
            // 
            this.thêmLớpLayerToolStripMenuItem.Image = global::QLHTDT.Properties.Resources.DataAdd_B_16;
            this.thêmLớpLayerToolStripMenuItem.Name = "thêmLớpLayerToolStripMenuItem";
            this.thêmLớpLayerToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.thêmLớpLayerToolStripMenuItem.Text = "Thêm lớp layer";
            this.thêmLớpLayerToolStripMenuItem.Click += new System.EventHandler(this.thêmLớpLayerToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(236, 6);
            // 
            // mởFileAutoCadToolStripMenuItem
            // 
            this.mởFileAutoCadToolStripMenuItem.Name = "mởFileAutoCadToolStripMenuItem";
            this.mởFileAutoCadToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.mởFileAutoCadToolStripMenuItem.Text = "Mở file AutoCad (.dwg)";
            this.mởFileAutoCadToolStripMenuItem.Click += new System.EventHandler(this.mởFileAutoCadToolStripMenuItem_Click);
            // 
            // mởFileMicrostationdngToolStripMenuItem
            // 
            this.mởFileMicrostationdngToolStripMenuItem.Name = "mởFileMicrostationdngToolStripMenuItem";
            this.mởFileMicrostationdngToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.mởFileMicrostationdngToolStripMenuItem.Text = "Mở file Microstation (.dng)";
            this.mởFileMicrostationdngToolStripMenuItem.Click += new System.EventHandler(this.mởFileMicrostationdngToolStripMenuItem_Click);
            // 
            // exportToCadToolStripMenuItem1
            // 
            this.exportToCadToolStripMenuItem1.Name = "exportToCadToolStripMenuItem1";
            this.exportToCadToolStripMenuItem1.Size = new System.Drawing.Size(239, 22);
            this.exportToCadToolStripMenuItem1.Text = "Xuất file AutoCad";
            this.exportToCadToolStripMenuItem1.Click += new System.EventHandler(this.exportToCadToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(236, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmChúThíchToolStripMenuItem1,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.toolStripMenuItem13});
            this.toolStripMenuItem2.Image = global::QLHTDT.Properties.Resources.PrintPreview16;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem2.Text = "Biên tập trang in";
            // 
            // thêmChúThíchToolStripMenuItem1
            // 
            this.thêmChúThíchToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmChúThíchToolStripMenuItem2,
            this.xóaChúThíchToolStripMenuItem1,
            this.thayĐổiChúThíchĐốiTượngVùngToolStripMenuItem,
            this.thayĐổiChúThíchĐốiTượngĐườngToolStripMenuItem});
            this.thêmChúThíchToolStripMenuItem1.Name = "thêmChúThíchToolStripMenuItem1";
            this.thêmChúThíchToolStripMenuItem1.Size = new System.Drawing.Size(237, 22);
            this.thêmChúThíchToolStripMenuItem1.Text = "Thêm chú thích";
            // 
            // thêmChúThíchToolStripMenuItem2
            // 
            this.thêmChúThíchToolStripMenuItem2.Name = "thêmChúThíchToolStripMenuItem2";
            this.thêmChúThíchToolStripMenuItem2.Size = new System.Drawing.Size(299, 22);
            this.thêmChúThíchToolStripMenuItem2.Text = "Thêm chú thích";
            this.thêmChúThíchToolStripMenuItem2.Click += new System.EventHandler(this.thêmChúThíchToolStripMenuItem2_Click);
            // 
            // xóaChúThíchToolStripMenuItem1
            // 
            this.xóaChúThíchToolStripMenuItem1.Name = "xóaChúThíchToolStripMenuItem1";
            this.xóaChúThíchToolStripMenuItem1.Size = new System.Drawing.Size(299, 22);
            this.xóaChúThíchToolStripMenuItem1.Text = "Xóa chú thích";
            this.xóaChúThíchToolStripMenuItem1.Click += new System.EventHandler(this.xóaChúThíchToolStripMenuItem1_Click);
            // 
            // thayĐổiChúThíchĐốiTượngVùngToolStripMenuItem
            // 
            this.thayĐổiChúThíchĐốiTượngVùngToolStripMenuItem.Name = "thayĐổiChúThíchĐốiTượngVùngToolStripMenuItem";
            this.thayĐổiChúThíchĐốiTượngVùngToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.thayĐổiChúThíchĐốiTượngVùngToolStripMenuItem.Text = "Thay đổi chú thích đối tượng vùng";
            this.thayĐổiChúThíchĐốiTượngVùngToolStripMenuItem.Click += new System.EventHandler(this.thayĐổiChúThíchĐốiTượngVùngToolStripMenuItem_Click);
            // 
            // thayĐổiChúThíchĐốiTượngĐườngToolStripMenuItem
            // 
            this.thayĐổiChúThíchĐốiTượngĐườngToolStripMenuItem.Name = "thayĐổiChúThíchĐốiTượngĐườngToolStripMenuItem";
            this.thayĐổiChúThíchĐốiTượngĐườngToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.thayĐổiChúThíchĐốiTượngĐườngToolStripMenuItem.Text = "Thay đổi chú thích đối tượng đường";
            this.thayĐổiChúThíchĐốiTượngĐườngToolStripMenuItem.Click += new System.EventHandler(this.thayĐổiChúThíchĐốiTượngĐườngToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(237, 22);
            this.toolStripMenuItem8.Text = "Thêm tiêu đề";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(237, 22);
            this.toolStripMenuItem9.Text = "Thêm tỷ lệ";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(237, 22);
            this.toolStripMenuItem10.Text = "Thêm thước tỷ lệ";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(237, 22);
            this.toolStripMenuItem11.Text = "Thêm chỉ hướng Bắc nam";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(237, 22);
            this.toolStripMenuItem12.Text = "Thêm data Frame";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItem12_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(237, 22);
            this.toolStripMenuItem13.Text = "Thêm lưới";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItem13_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Image = global::QLHTDT.Properties.Resources.PrinterNetwork_32x32;
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem14.Text = "In";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItem14_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Image = global::QLHTDT.Properties.Resources.GenericDocument24;
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem15.Text = "Chọn cỡ giấy";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.toolStripMenuItem15_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(236, 6);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýNgườiDùngToolStripMenuItem,
            this.kếtNốiCơSởDữLiệuToolStripMenuItem2,
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem,
            this.saoLưuCơSởDữLiệuToolStripMenuItem,
            this.phụcHồiCơSởDữLiệuToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem1});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(78, 21);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // quảnLýNgườiDùngToolStripMenuItem
            // 
            this.quảnLýNgườiDùngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinNgườiDùngToolStripMenuItem,
            this.nhậtKíLàmViệcToolStripMenuItem1});
            this.quảnLýNgườiDùngToolStripMenuItem.Enabled = false;
            this.quảnLýNgườiDùngToolStripMenuItem.Name = "quảnLýNgườiDùngToolStripMenuItem";
            this.quảnLýNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.quảnLýNgườiDùngToolStripMenuItem.Text = "Quản lý người dùng";
            this.quảnLýNgườiDùngToolStripMenuItem.Visible = false;
            // 
            // thôngTinNgườiDùngToolStripMenuItem
            // 
            this.thôngTinNgườiDùngToolStripMenuItem.Name = "thôngTinNgườiDùngToolStripMenuItem";
            this.thôngTinNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.thôngTinNgườiDùngToolStripMenuItem.Text = "Thông tin người dùng";
            this.thôngTinNgườiDùngToolStripMenuItem.Click += new System.EventHandler(this.thôngTinNgườiDùngToolStripMenuItem_Click);
            // 
            // nhậtKíLàmViệcToolStripMenuItem1
            // 
            this.nhậtKíLàmViệcToolStripMenuItem1.Name = "nhậtKíLàmViệcToolStripMenuItem1";
            this.nhậtKíLàmViệcToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.nhậtKíLàmViệcToolStripMenuItem1.Text = "Nhật kí làm việc";
            this.nhậtKíLàmViệcToolStripMenuItem1.Click += new System.EventHandler(this.nhậtKíLàmViệcToolStripMenuItem1_Click);
            // 
            // kếtNốiCơSởDữLiệuToolStripMenuItem2
            // 
            this.kếtNốiCơSởDữLiệuToolStripMenuItem2.Name = "kếtNốiCơSởDữLiệuToolStripMenuItem2";
            this.kếtNốiCơSởDữLiệuToolStripMenuItem2.Size = new System.Drawing.Size(261, 22);
            this.kếtNốiCơSởDữLiệuToolStripMenuItem2.Text = "Kết nối cơ sở dữ liệu";
            this.kếtNốiCơSởDữLiệuToolStripMenuItem2.Click += new System.EventHandler(this.kếtNốiCơSởDữLiệuToolStripMenuItem2_Click_1);
            // 
            // thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem
            // 
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Enabled = false;
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Name = "thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem";
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Text = "Thiết lập kết nối cơ sở dữ liệu";
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Visible = false;
            // 
            // saoLưuCơSởDữLiệuToolStripMenuItem
            // 
            this.saoLưuCơSởDữLiệuToolStripMenuItem.Enabled = false;
            this.saoLưuCơSởDữLiệuToolStripMenuItem.Name = "saoLưuCơSởDữLiệuToolStripMenuItem";
            this.saoLưuCơSởDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.saoLưuCơSởDữLiệuToolStripMenuItem.Text = "Sao lưu cơ sở dữ liệu";
            this.saoLưuCơSởDữLiệuToolStripMenuItem.Visible = false;
            this.saoLưuCơSởDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.saoLưuCơSởDữLiệuToolStripMenuItem_Click);
            // 
            // phụcHồiCơSởDữLiệuToolStripMenuItem
            // 
            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Enabled = false;
            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Name = "phụcHồiCơSởDữLiệuToolStripMenuItem";
            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Text = "Phục hồi cơ sở dữ liệu";
            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Visible = false;
            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.phụcHồiCơSởDữLiệuToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            this.thôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(258, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuItem1.Text = "Đăng xuất";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // bảnĐồToolStripMenuItem
            // 
            this.bảnĐồToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mởBảnĐồToolStripMenuItem1,
            this.lưuBảnĐồToolStripMenuItem,
            this.lưuĐếnFolderToolStripMenuItem1,
            this.mởLớpLayerToolStripMenuItem,
            this.mởBảngTừTậpTinToolStripMenuItem,
            this.thêmLớpToolStripMenuItem,
            this.bảnĐồNềnGoogleToolStripMenuItem});
            this.bảnĐồToolStripMenuItem.Name = "bảnĐồToolStripMenuItem";
            this.bảnĐồToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.bảnĐồToolStripMenuItem.Text = "Bản đồ";
            this.bảnĐồToolStripMenuItem.Visible = false;
            // 
            // mởBảnĐồToolStripMenuItem1
            // 
            this.mởBảnĐồToolStripMenuItem1.Name = "mởBảnĐồToolStripMenuItem1";
            this.mởBảnĐồToolStripMenuItem1.Size = new System.Drawing.Size(289, 22);
            this.mởBảnĐồToolStripMenuItem1.Text = "Mở bản đồ";
            this.mởBảnĐồToolStripMenuItem1.Click += new System.EventHandler(this.mởBảnĐồToolStripMenuItem1_Click);
            // 
            // lưuBảnĐồToolStripMenuItem
            // 
            this.lưuBảnĐồToolStripMenuItem.Enabled = false;
            this.lưuBảnĐồToolStripMenuItem.Name = "lưuBảnĐồToolStripMenuItem";
            this.lưuBảnĐồToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.lưuBảnĐồToolStripMenuItem.Text = "Lưu bản đồ";
            this.lưuBảnĐồToolStripMenuItem.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // lưuĐếnFolderToolStripMenuItem1
            // 
            this.lưuĐếnFolderToolStripMenuItem1.Name = "lưuĐếnFolderToolStripMenuItem1";
            this.lưuĐếnFolderToolStripMenuItem1.Size = new System.Drawing.Size(289, 22);
            this.lưuĐếnFolderToolStripMenuItem1.Text = "Lưu đến folder";
            this.lưuĐếnFolderToolStripMenuItem1.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // mởLớpLayerToolStripMenuItem
            // 
            this.mởLớpLayerToolStripMenuItem.Name = "mởLớpLayerToolStripMenuItem";
            this.mởLớpLayerToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.mởLớpLayerToolStripMenuItem.Text = "Mở lớp layer bản đồ";
            this.mởLớpLayerToolStripMenuItem.Visible = false;
            this.mởLớpLayerToolStripMenuItem.Click += new System.EventHandler(this.mởLớpLayerToolStripMenuItem_Click);
            // 
            // mởBảngTừTậpTinToolStripMenuItem
            // 
            this.mởBảngTừTậpTinToolStripMenuItem.Name = "mởBảngTừTậpTinToolStripMenuItem";
            this.mởBảngTừTậpTinToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.mởBảngTừTậpTinToolStripMenuItem.Text = "Mở bảng từ tập tin";
            this.mởBảngTừTậpTinToolStripMenuItem.Visible = false;
            // 
            // thêmLớpToolStripMenuItem
            // 
            this.thêmLớpToolStripMenuItem.Name = "thêmLớpToolStripMenuItem";
            this.thêmLớpToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.thêmLớpToolStripMenuItem.Text = "Thêm lớp theo tọa độ X Y từ bảng";
            this.thêmLớpToolStripMenuItem.Visible = false;
            this.thêmLớpToolStripMenuItem.Click += new System.EventHandler(this.thêmLớpToolStripMenuItem_Click);
            // 
            // bảnĐồNềnGoogleToolStripMenuItem
            // 
            this.bảnĐồNềnGoogleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ảnhVệTinhToolStripMenuItem});
            this.bảnĐồNềnGoogleToolStripMenuItem.Name = "bảnĐồNềnGoogleToolStripMenuItem";
            this.bảnĐồNềnGoogleToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.bảnĐồNềnGoogleToolStripMenuItem.Text = "Bản đồ nền Google";
            // 
            // ảnhVệTinhToolStripMenuItem
            // 
            this.ảnhVệTinhToolStripMenuItem.CheckOnClick = true;
            this.ảnhVệTinhToolStripMenuItem.Name = "ảnhVệTinhToolStripMenuItem";
            this.ảnhVệTinhToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.ảnhVệTinhToolStripMenuItem.Text = "Ảnh vệ tinh";
            this.ảnhVệTinhToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ảnhVệTinhToolStripMenuItem_CheckedChanged);
            // 
            // trangInToolStripMenuItem
            // 
            this.trangInToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xuấtẢnhToolStripMenuItem,
            this.inToolStripMenuItem,
            this.chọnCỡGiấyToolStripMenuItem});
            this.trangInToolStripMenuItem.Name = "trangInToolStripMenuItem";
            this.trangInToolStripMenuItem.Size = new System.Drawing.Size(51, 21);
            this.trangInToolStripMenuItem.Text = "In ấn";
            this.trangInToolStripMenuItem.Visible = false;
            // 
            // thanhCôngCụToolStripMenuItem
            // 
            this.thanhCôngCụToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thanhCôngCụToolStripMenuItem1,
            this.bảnĐồNềnGoogleToolStripMenuItem1,
            this.cậpNhậtToolStripMenuItem});
            this.thanhCôngCụToolStripMenuItem.Name = "thanhCôngCụToolStripMenuItem";
            this.thanhCôngCụToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.thanhCôngCụToolStripMenuItem.Text = "Công cụ";
            // 
            // thanhCôngCụToolStripMenuItem1
            // 
            this.thanhCôngCụToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.côngCụCơBảnToolStripMenuItem,
            this.côngCụChỉnhSửaTrangInToolStripMenuItem,
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem,
            this.tùyChỉnhToolStripMenuItem1,
            this.lưuThanhCôngCụToolStripMenuItem});
            this.thanhCôngCụToolStripMenuItem1.Name = "thanhCôngCụToolStripMenuItem1";
            this.thanhCôngCụToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.thanhCôngCụToolStripMenuItem1.Text = "Thanh công cụ";
            // 
            // côngCụCơBảnToolStripMenuItem
            // 
            this.côngCụCơBảnToolStripMenuItem.Checked = true;
            this.côngCụCơBảnToolStripMenuItem.CheckOnClick = true;
            this.côngCụCơBảnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.côngCụCơBảnToolStripMenuItem.Name = "côngCụCơBảnToolStripMenuItem";
            this.côngCụCơBảnToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.côngCụCơBảnToolStripMenuItem.Text = "Công cụ cơ bản";
            this.côngCụCơBảnToolStripMenuItem.CheckedChanged += new System.EventHandler(this.thanhCôngCụCơbảnToolStripMenuItem_CheckedChanged);
            // 
            // côngCụChỉnhSửaTrangInToolStripMenuItem
            // 
            this.côngCụChỉnhSửaTrangInToolStripMenuItem.Checked = true;
            this.côngCụChỉnhSửaTrangInToolStripMenuItem.CheckOnClick = true;
            this.côngCụChỉnhSửaTrangInToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.côngCụChỉnhSửaTrangInToolStripMenuItem.Name = "côngCụChỉnhSửaTrangInToolStripMenuItem";
            this.côngCụChỉnhSửaTrangInToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.côngCụChỉnhSửaTrangInToolStripMenuItem.Text = "Công cụ chỉnh sửa trang in";
            this.côngCụChỉnhSửaTrangInToolStripMenuItem.CheckedChanged += new System.EventHandler(this.côngCụTrangInToolStripMenuItem_CheckedChanged);
            // 
            // côngCụChỉnhSửaDữLiệuToolStripMenuItem
            // 
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem.Checked = true;
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem.CheckOnClick = true;
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem.Name = "côngCụChỉnhSửaDữLiệuToolStripMenuItem";
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem.Text = "Công cụ chỉnh sửa dữ liệu";
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem.CheckedChanged += new System.EventHandler(this.côngCụCậpNhậtDữLiệuToolStripMenuItem_CheckedChanged);
            // 
            // tùyChỉnhToolStripMenuItem1
            // 
            this.tùyChỉnhToolStripMenuItem1.Name = "tùyChỉnhToolStripMenuItem1";
            this.tùyChỉnhToolStripMenuItem1.Size = new System.Drawing.Size(245, 22);
            this.tùyChỉnhToolStripMenuItem1.Text = "Tùy chỉnh";
            this.tùyChỉnhToolStripMenuItem1.Click += new System.EventHandler(this.tùyChỉnhToolStripMenuItem_Click);
            // 
            // lưuThanhCôngCụToolStripMenuItem
            // 
            this.lưuThanhCôngCụToolStripMenuItem.Name = "lưuThanhCôngCụToolStripMenuItem";
            this.lưuThanhCôngCụToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.lưuThanhCôngCụToolStripMenuItem.Text = "Lưu thanh công cụ";
            this.lưuThanhCôngCụToolStripMenuItem.Click += new System.EventHandler(this.lưuToolToolStripMenuItem_Click);
            // 
            // bảnĐồNềnGoogleToolStripMenuItem1
            // 
            this.bảnĐồNềnGoogleToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ảnhVệTinhToolStripMenuItem1});
            this.bảnĐồNềnGoogleToolStripMenuItem1.Name = "bảnĐồNềnGoogleToolStripMenuItem1";
            this.bảnĐồNềnGoogleToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.bảnĐồNềnGoogleToolStripMenuItem1.Text = "Bản đồ nền Google";
            this.bảnĐồNềnGoogleToolStripMenuItem1.Click += new System.EventHandler(this.ảnhVệTinhToolStripMenuItem_CheckedChanged);
            // 
            // ảnhVệTinhToolStripMenuItem1
            // 
            this.ảnhVệTinhToolStripMenuItem1.CheckOnClick = true;
            this.ảnhVệTinhToolStripMenuItem1.Name = "ảnhVệTinhToolStripMenuItem1";
            this.ảnhVệTinhToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.ảnhVệTinhToolStripMenuItem1.Text = "Ảnh vệ tinh";
            this.ảnhVệTinhToolStripMenuItem1.Click += new System.EventHandler(this.ảnhVệTinhToolStripMenuItem_CheckedChanged);
            // 
            // cậpNhậtToolStripMenuItem
            // 
            this.cậpNhậtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kiểmTraFileDGNMớiToolStripMenuItem,
            this.toolChuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem,
            this.toolHỗTrợĐóngVùngchuyểnLineSangPolygonToolStripMenuItem,
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem,
            this.cậpNhậtDữLiệuTừFileShapefileToolStripMenuItem,
            this.cậpNhậtQuyĐấtToolStripMenuItem});
            this.cậpNhậtToolStripMenuItem.Name = "cậpNhậtToolStripMenuItem";
            this.cậpNhậtToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.cậpNhậtToolStripMenuItem.Text = "Cập nhật";
            this.cậpNhậtToolStripMenuItem.Visible = false;
            // 
            // kiểmTraFileDGNMớiToolStripMenuItem
            // 
            this.kiểmTraFileDGNMớiToolStripMenuItem.Name = "kiểmTraFileDGNMớiToolStripMenuItem";
            this.kiểmTraFileDGNMớiToolStripMenuItem.Size = new System.Drawing.Size(391, 22);
            this.kiểmTraFileDGNMớiToolStripMenuItem.Text = "Kiểm tra file DGN mới";
            this.kiểmTraFileDGNMớiToolStripMenuItem.Click += new System.EventHandler(this.KiemTraDGNmoi);
            // 
            // toolChuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem
            // 
            this.toolChuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem.Name = "toolChuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem";
            this.toolChuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem.Size = new System.Drawing.Size(391, 22);
            this.toolChuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem.Text = "Tool chuyển đổi dữ liệu *.dgn, *.cad sang *.shp";
            this.toolChuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem.Click += new System.EventHandler(this.toolChuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem_Click);
            // 
            // toolHỗTrợĐóngVùngchuyểnLineSangPolygonToolStripMenuItem
            // 
            this.toolHỗTrợĐóngVùngchuyểnLineSangPolygonToolStripMenuItem.Name = "toolHỗTrợĐóngVùngchuyểnLineSangPolygonToolStripMenuItem";
            this.toolHỗTrợĐóngVùngchuyểnLineSangPolygonToolStripMenuItem.Size = new System.Drawing.Size(391, 22);
            this.toolHỗTrợĐóngVùngchuyểnLineSangPolygonToolStripMenuItem.Text = "Tool hỗ trợ đóng vùng (chuyển line sang polygon)";
            this.toolHỗTrợĐóngVùngchuyểnLineSangPolygonToolStripMenuItem.Click += new System.EventHandler(this.toolHỗTrợĐóngVùngchuyểnLineSangPolygonToolStripMenuItem_Click);
            // 
            // cậpNhậtDữLiệuĐịaChínhToolStripMenuItem
            // 
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem.Name = "cậpNhậtDữLiệuĐịaChínhToolStripMenuItem";
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem.Size = new System.Drawing.Size(391, 22);
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem.Text = "Cập nhật dữ liệu địa chính";
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem.Click += new System.EventHandler(this.CpNhatDGNMoi_Click);
            // 
            // cậpNhậtDữLiệuTừFileShapefileToolStripMenuItem
            // 
            this.cậpNhậtDữLiệuTừFileShapefileToolStripMenuItem.Name = "cậpNhậtDữLiệuTừFileShapefileToolStripMenuItem";
            this.cậpNhậtDữLiệuTừFileShapefileToolStripMenuItem.Size = new System.Drawing.Size(391, 22);
            this.cậpNhậtDữLiệuTừFileShapefileToolStripMenuItem.Text = "Cập nhật dữ liệu từ file shapefile";
            this.cậpNhậtDữLiệuTừFileShapefileToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtDữLiệuTừFileShapefileToolStripMenuItem_Click);
            // 
            // cậpNhậtQuyĐấtToolStripMenuItem
            // 
            this.cậpNhậtQuyĐấtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmMớiDựÁnQuyHoạchToolStripMenuItem,
            this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem,
            this.thêmMớiQuỹĐấtQuyHoạchToolStripMenuItem});
            this.cậpNhậtQuyĐấtToolStripMenuItem.Name = "cậpNhậtQuyĐấtToolStripMenuItem";
            this.cậpNhậtQuyĐấtToolStripMenuItem.Size = new System.Drawing.Size(391, 22);
            this.cậpNhậtQuyĐấtToolStripMenuItem.Text = "Cập nhật quỹ đất";
            // 
            // thêmMớiDựÁnQuyHoạchToolStripMenuItem
            // 
            this.thêmMớiDựÁnQuyHoạchToolStripMenuItem.Name = "thêmMớiDựÁnQuyHoạchToolStripMenuItem";
            this.thêmMớiDựÁnQuyHoạchToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.thêmMớiDựÁnQuyHoạchToolStripMenuItem.Text = "Thêm mới dự án quy hoạch";
            this.thêmMớiDựÁnQuyHoạchToolStripMenuItem.Click += new System.EventHandler(this.thêmMớiDựÁnQuyHoạchToolStripMenuItem_Click);
            // 
            // cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem
            // 
            this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem.Name = "cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem";
            this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem.Text = "Cập nhật ranh giới quy hoạch";
            this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem_Click);
            // 
            // thêmMớiQuỹĐấtQuyHoạchToolStripMenuItem
            // 
            this.thêmMớiQuỹĐấtQuyHoạchToolStripMenuItem.Name = "thêmMớiQuỹĐấtQuyHoạchToolStripMenuItem";
            this.thêmMớiQuỹĐấtQuyHoạchToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.thêmMớiQuỹĐấtQuyHoạchToolStripMenuItem.Text = "Thêm mới quỹ đất quy hoạch";
            this.thêmMớiQuỹĐấtQuyHoạchToolStripMenuItem.Click += new System.EventHandler(this.thêmMớiQuỹĐấtQuyHoạchToolStripMenuItem_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnSửDụngToolStripMenuItem,
            this.giớiThiệuSảnPhâprToolStripMenuItem});
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // hướngDẫnSửDụngToolStripMenuItem
            // 
            this.hướngDẫnSửDụngToolStripMenuItem.Image = global::QLHTDT.Properties.Resources.HelpSystem_C_16;
            this.hướngDẫnSửDụngToolStripMenuItem.Name = "hướngDẫnSửDụngToolStripMenuItem";
            this.hướngDẫnSửDụngToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.hướngDẫnSửDụngToolStripMenuItem.Text = "Hướng dẫn sử dụng";
            this.hướngDẫnSửDụngToolStripMenuItem.Click += new System.EventHandler(this.hướngDẫnSửDụngToolStripMenuItem_Click);
            // 
            // giớiThiệuSảnPhâprToolStripMenuItem
            // 
            this.giớiThiệuSảnPhâprToolStripMenuItem.Name = "giớiThiệuSảnPhâprToolStripMenuItem";
            this.giớiThiệuSảnPhâprToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.giớiThiệuSảnPhâprToolStripMenuItem.Text = "Giới thiệu sản phẩm";
            this.giớiThiệuSảnPhâprToolStripMenuItem.Click += new System.EventHandler(this.giớiThiệuSảnPhâprToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(12, 21);
            // 
            // ảnhGiaoThôngToolStripMenuItem
            // 
            this.ảnhGiaoThôngToolStripMenuItem.CheckOnClick = true;
            this.ảnhGiaoThôngToolStripMenuItem.Name = "ảnhGiaoThôngToolStripMenuItem";
            this.ảnhGiaoThôngToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ảnhGiaoThôngToolStripMenuItem.Text = "Ảnh Giao thông";
            this.ảnhGiaoThôngToolStripMenuItem.Visible = false;
            this.ảnhGiaoThôngToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ảnhGiaoThôngToolStripMenuItem_CheckedChanged);
            // 
            // addlayer
            // 
            this.addlayer.AutoHeight = false;
            this.addlayer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Mở lớp", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("addlayer.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Mở lớp", null, null, true)});
            this.addlayer.Name = "addlayer";
            this.addlayer.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(48, 17);
            this.statusBarXY.Text = "Test 123";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(0, 963);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusBar1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // QuanTriHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QuanTriHeThong";
            this.Text = "Phần mềm quản lý Hạ tầng đô thị Hòa Vang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.tabNavigationPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNavigationPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(axTOCControl1)).EndInit();
            this.tabNavigationPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.bindingNavigator2.ResumeLayout(false);
            this.bindingNavigator2.PerformLayout();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator3)).EndInit();
            this.bindingNavigator3.ResumeLayout(false);
            this.bindingNavigator3.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(axMapControl1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(axPageLayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl3)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addlayer)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        

        

        #endregion

        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
        private ComboBox comboBox1;
        private ComboBox Cbolop2;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private SplitContainer splitContainer2;
        private ToolStripMenuItem chọnCỡGiấyToolStripMenuItem;
        private ToolStripMenuItem inToolStripMenuItem;
        private ToolStripMenuItem xuấtẢnhToolStripMenuItem;
        private SplitContainer splitContainer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem quảnLýNgườiDùngToolStripMenuItem;
        private ToolStripMenuItem kếtNốiCơSởDữLiệuToolStripMenuItem2;
        private ToolStripMenuItem thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem;
        private ToolStripMenuItem saoLưuCơSởDữLiệuToolStripMenuItem;
        private ToolStripMenuItem phụcHồiCơSởDữLiệuToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem bảnĐồToolStripMenuItem;
        private ToolStripMenuItem mởBảnĐồToolStripMenuItem1;
        private ToolStripMenuItem lưuBảnĐồToolStripMenuItem;
        private ToolStripMenuItem mởLớpLayerToolStripMenuItem;
        private ToolStripMenuItem mởBảngTừTậpTinToolStripMenuItem;
        private ToolStripMenuItem thêmLớpToolStripMenuItem;
        private ToolStripMenuItem bảnĐồNềnGoogleToolStripMenuItem;
        private ToolStripMenuItem ảnhVệTinhToolStripMenuItem;
        private ToolStripMenuItem ảnhGiaoThôngToolStripMenuItem;
        private ToolStripMenuItem thanhCôngCụToolStripMenuItem;
        private ToolStripMenuItem trangInToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit addlayer;
        private ToolStripStatusLabel statusBarXY;
        private StatusStrip statusStrip1;
        private BindingSource dataDataSet1BindingSource;
        private ToolStripMenuItem thôngTinNgườiDùngToolStripMenuItem;
        private ToolStripMenuItem nhậtKíLàmViệcToolStripMenuItem1;
        private ToolStripMenuItem thêmTiêuĐềToolStripMenuItem;
        private ToolStripMenuItem thêmTỷLệToolStripMenuItem;
        private ToolStripMenuItem thêmThướcTỷLệToolStripMenuItem;
        private ToolStripMenuItem thêmChúGiảiToolStripMenuItem;
        private ToolStripMenuItem thêmChỉHướngBắcNamToolStripMenuItem;
        private ToolStripMenuItem thêmChúThíchToolStripMenuItem;
        private ToolStripMenuItem xóaChúThíchToolStripMenuItem;
        private ToolStripMenuItem thayĐổiĐốiTượngVùngToolStripMenuItem;
        private ToolStripMenuItem thayĐổiĐốiTượngĐườngToolStripMenuItem;
        private ToolStripMenuItem thêmDataFrameToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl2;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl3;
        private ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl5;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl4;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private Label label3;
        private ComboBox comboBox2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private ToolStripMenuItem lưuĐếnFolderToolStripMenuItem1;
        private ToolStripMenuItem thanhCôngCụToolStripMenuItem1;
        private ToolStripMenuItem côngCụCơBảnToolStripMenuItem;
        private ToolStripMenuItem côngCụChỉnhSửaTrangInToolStripMenuItem;
        private ToolStripMenuItem côngCụChỉnhSửaDữLiệuToolStripMenuItem;
        private ToolStripMenuItem tùyChỉnhToolStripMenuItem1;
        private ToolStripMenuItem lưuThanhCôngCụToolStripMenuItem;
        private ToolStripMenuItem bảnĐồNềnGoogleToolStripMenuItem1;
        private ToolStripMenuItem ảnhVệTinhToolStripMenuItem1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl2;
        private ToolStripMenuItem trợGiúpToolStripMenuItem;
        private ToolStripMenuItem hướngDẫnSửDụngToolStripMenuItem;
        private ToolStripMenuItem giớiThiệuSảnPhâprToolStripMenuItem;
        private ToolStripMenuItem thêmLướiToolStripMenuItem;
        private ToolStripMenuItem cậpNhậtToolStripMenuItem;
        private ToolStripMenuItem kiểmTraFileDGNMớiToolStripMenuItem;
        private ToolStripMenuItem cậpNhậtDữLiệuĐịaChínhToolStripMenuItem;
        private ToolStripMenuItem cậpNhậtDữLiệuTừFileShapefileToolStripMenuItem;
        private ToolStripMenuItem cậpNhậtQuyĐấtToolStripMenuItem;
        private ToolStripMenuItem thêmMớiDựÁnQuyHoạchToolStripMenuItem;
        private ToolStripMenuItem cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem;
        private ToolStripMenuItem thêmMớiQuỹĐấtQuyHoạchToolStripMenuItem;
        private ToolStripMenuItem toolChuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem;
        private ToolStripMenuItem toolHỗTrợĐóngVùngchuyểnLineSangPolygonToolStripMenuItem;
        
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem mởBảnĐồToolStripMenuItem2;
        private ToolStripMenuItem lưuBảnĐồToolStripMenuItem1;
        private ToolStripMenuItem thêmLớpLayerToolStripMenuItem;
        private ToolStripMenuItem mởFileAutoCadToolStripMenuItem;
        private ToolStripMenuItem mởFileMicrostationdngToolStripMenuItem;
        private ToolStripMenuItem exportToCadToolStripMenuItem1;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripMenuItem toolStripMenuItem15;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem thêmChúThíchToolStripMenuItem1;
        private ToolStripMenuItem thêmChúThíchToolStripMenuItem2;
        private ToolStripMenuItem xóaChúThíchToolStripMenuItem1;
        private ToolStripMenuItem thayĐổiChúThíchĐốiTượngVùngToolStripMenuItem;
        private ToolStripMenuItem thayĐổiChúThíchĐốiTượngĐườngToolStripMenuItem;
        public static DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        public OpenFileDialog openFileDialog1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage3;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        internal GroupBox GroupBox1;
        private ComboBox cboLoaiCay;
        private ComboBox cboDuong;
        internal Label label4;
        private ComboBox cboPhuong;
        internal Label label5;
        private ComboBox cboQuan;
        internal Label label6;
        internal ComboBox comboBox3;
        internal Label lbPhuong;
        private TextBox txtMaCay;
        internal System.Windows.Forms.Button Btloadlailop;
        internal System.Windows.Forms.Button BtTracuu;
        internal Label lbTenDA;
        internal GroupBox GroupBox2;
        private SplitContainer splitContainer3;
        internal DevExpress.XtraGrid.GridControl gridControl1;
        internal DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn OBJECTID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private BindingNavigator bindingNavigator1;
        private ToolStripButton toolStripButton1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripButton toolStripButton7;
        private ToolStripButton toolStripButton8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button btChinhSua;
        internal System.Windows.Forms.Button BtExcell;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        internal GroupBox groupBox3;
        private ComboBox cboLoaiCay1;
        private ComboBox cboDuong1;
        internal Label label7;
        private ComboBox cboPhuong1;
        internal Label label8;
        private ComboBox cboQuan1;
        internal Label label9;
        internal ComboBox comboBox5;
        internal Label label10;
        private TextBox txtMaCay1;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button button3;
        internal Label label11;
        internal System.Windows.Forms.Button button4;
        internal GroupBox groupBox4;
        private SplitContainer splitContainer4;
        internal DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn15;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn16;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn14;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn11;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn17;
        private BindingNavigator bindingNavigator2;
        private ToolStripButton toolStripButton9;
        private ToolStripLabel toolStripLabel2;
        private ToolStripButton toolStripButton10;
        private ToolStripButton toolStripButton11;
        private ToolStripButton toolStripButton12;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripTextBox toolStripTextBox2;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton toolStripButton13;
        private ToolStripButton toolStripButton14;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripButton toolStripButton15;
        private ToolStripButton toolStripButton16;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btChinhSua1;
        internal System.Windows.Forms.Button BtExcell1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        internal GroupBox groupBox5;
        private ComboBox cboLoaiCay2;
        private ComboBox cboDuong2;
        internal Label label12;
        private ComboBox cboPhuong2;
        internal Label label13;
        private ComboBox cboQuan2;
        internal Label label14;
        internal ComboBox comboBox10;
        internal Label label15;
        private TextBox txtMaCay2;
        internal System.Windows.Forms.Button button6;
        internal System.Windows.Forms.Button button7;
        internal Label label16;
        internal System.Windows.Forms.Button button8;
        internal GroupBox groupBox6;
        private SplitContainer splitContainer5;
        internal DevExpress.XtraGrid.GridControl gridControl3;
        internal DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private BindingNavigator bindingNavigator3;
        private ToolStripButton toolStripButton17;
        private ToolStripLabel toolStripLabel3;
        private ToolStripButton toolStripButton18;
        private ToolStripButton toolStripButton19;
        private ToolStripButton toolStripButton20;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripTextBox toolStripTextBox3;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripButton toolStripButton21;
        private ToolStripButton toolStripButton22;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripButton toolStripButton23;
        private ToolStripButton toolStripButton24;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btChinhSua2;
        internal System.Windows.Forms.Button btXExcel2;
        private ToolStripMenuItem toolStripMenuItem3;
        public static DevExpress.XtraTreeList.TreeList treeList1;
        public static ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        public static ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        public static ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
    }
}
