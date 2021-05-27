//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Collections;
//using System.Data;
//using System.Diagnostics;
//using ESRI.ArcGIS.esriSystem;
//using ESRI.ArcGIS.Geodatabase;
//using ESRI.ArcGIS.Geometry;
//using ESRI.ArcGIS.Display;
//using ESRI.ArcGIS.Carto;
//using System.Windows.Forms;


//namespace QLHTDT.FormChinh
//{
//    partial class QuanTriHeThong
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Engine);
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanTriHeThong));
//            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
//            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
//            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
//            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.quảnLýNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.thôngTinCơQuanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.nhậtKíLàmViệcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.thôngTinNgườiDungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.thayĐổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.saoLưuCơSởDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.phụcHồiCơSởDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.thiếtLậpVịTríSaoLưuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
//            this.quảnLýCơSởDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.kếtNốiCơSởDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.cơSởDữLiệuGISToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
//            this.quảnLýDanhMụcCơSởDữLiệuGISToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
//            this.thêmDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.bảnĐồToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.mởBảnĐồToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
//            this.mởBảnĐồTừTậpTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.lưuBảnĐồToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.lưuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.lưuĐếnFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.mởLớpLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.mởLớpTừTậpTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.mởBảngTừTậpTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.thêmLớpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.bảnĐồNềnGoogleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.ảnhVệTinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.ảnhGiaoThôngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.traCứuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.traCứuTheoThuộcTínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.đườngGiaoThôngChínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.kiệtHẻmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.traCứuTheoKhôngGianToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
//            this.xemThôngTinĐốiTượngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.thanhCôngCụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.côngCụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.thanhTrạngTháiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.côngCụCơBảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.côngCụCậpNhậtDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.lưuToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.tùyChỉnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.trangInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.xuấtẢnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.xuấtBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.inToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.hướngDẫnSửDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.giớiThiệuSảnPhâprToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
//            this.axToolbarControl5 = new ESRI.ArcGIS.Controls.AxToolbarControl();
//            this.chkCustomize = new System.Windows.Forms.CheckBox();
//            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
//            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
//            axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
//            this.tabControl1 = new System.Windows.Forms.TabControl();
//            this.tabPage1 = new System.Windows.Forms.TabPage();
//            axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
//            this.tabPage2 = new System.Windows.Forms.TabPage();
//            axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
//            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
//            this.axToolbarControl2 = new ESRI.ArcGIS.Controls.AxToolbarControl();
//            this.axToolbarControl3 = new ESRI.ArcGIS.Controls.AxToolbarControl();
//            this.chọnCỡGiấyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.statusStrip1.SuspendLayout();
//            this.menuStrip1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
//            this.splitContainer1.Panel1.SuspendLayout();
//            this.splitContainer1.Panel2.SuspendLayout();
//            this.splitContainer1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl5)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
//            this.splitContainer2.Panel1.SuspendLayout();
//            this.splitContainer2.Panel2.SuspendLayout();
//            this.splitContainer2.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(axTOCControl1)).BeginInit();
//            this.tabControl1.SuspendLayout();
//            this.tabPage1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(axMapControl1)).BeginInit();
//            this.tabPage2.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(axPageLayoutControl1)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl2)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl3)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // statusStrip1
//            // 
//            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.statusBarXY});
//            this.statusStrip1.Location = new System.Drawing.Point(0, 959);
//            this.statusStrip1.Name = "statusStrip1";
//            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
//            this.statusStrip1.Size = new System.Drawing.Size(1904, 22);
//            this.statusStrip1.Stretch = false;
//            this.statusStrip1.TabIndex = 7;
//            this.statusStrip1.Text = "statusBar1";
//            // 
//            // statusBarXY
//            // 
//            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
//            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
//            this.statusBarXY.Name = "statusBarXY";
//            this.statusBarXY.Size = new System.Drawing.Size(49, 17);
//            this.statusBarXY.Text = "Test 123";
//            // 
//            // menuStrip1
//            // 
//            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.hệThốngToolStripMenuItem,
//            this.quảnLýCơSởDữLiệuToolStripMenuItem,
//            this.bảnĐồToolStripMenuItem,
//            this.traCứuToolStripMenuItem,
//            this.thanhCôngCụToolStripMenuItem,
//            this.trangInToolStripMenuItem,
//            this.trợGiúpToolStripMenuItem});
//            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
//            this.menuStrip1.Name = "menuStrip1";
//            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
//            this.menuStrip1.Size = new System.Drawing.Size(1904, 24);
//            this.menuStrip1.TabIndex = 0;
//            this.menuStrip1.Text = "menuStrip1";
//            // 
//            // hệThốngToolStripMenuItem
//            // 
//            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.quảnLýNgườiDùngToolStripMenuItem,
//            this.thôngTinCơQuanToolStripMenuItem,
//            this.nhậtKíLàmViệcToolStripMenuItem,
//            this.thôngTinNgườiDungToolStripMenuItem,
//            this.thayĐổiMậtKhẩuToolStripMenuItem,
//            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem,
//            this.saoLưuCơSởDữLiệuToolStripMenuItem,
//            this.phụcHồiCơSởDữLiệuToolStripMenuItem,
//            this.thiếtLậpVịTríSaoLưuToolStripMenuItem,
//            this.toolStripMenuItem1});
//            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
//            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
//            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
//            // 
//            // quảnLýNgườiDùngToolStripMenuItem
//            // 
//            this.quảnLýNgườiDùngToolStripMenuItem.Name = "quảnLýNgườiDùngToolStripMenuItem";
//            this.quảnLýNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
//            this.quảnLýNgườiDùngToolStripMenuItem.Text = "Quản lý người dùng";
//            this.quảnLýNgườiDùngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNgườiDùngToolStripMenuItem_Click);
//            // 
//            // thôngTinCơQuanToolStripMenuItem
//            // 
//            this.thôngTinCơQuanToolStripMenuItem.Name = "thôngTinCơQuanToolStripMenuItem";
//            this.thôngTinCơQuanToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
//            this.thôngTinCơQuanToolStripMenuItem.Text = "Thông tin cơ quan";
//            // 
//            // nhậtKíLàmViệcToolStripMenuItem
//            // 
//            this.nhậtKíLàmViệcToolStripMenuItem.Name = "nhậtKíLàmViệcToolStripMenuItem";
//            this.nhậtKíLàmViệcToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
//            this.nhậtKíLàmViệcToolStripMenuItem.Text = "Nhật kí làm việc";
//            this.nhậtKíLàmViệcToolStripMenuItem.Click += new System.EventHandler(this.nhậtKíLàmViệcToolStripMenuItem_Click);
//            // 
//            // thôngTinNgườiDungToolStripMenuItem
//            // 
//            this.thôngTinNgườiDungToolStripMenuItem.Name = "thôngTinNgườiDungToolStripMenuItem";
//            this.thôngTinNgườiDungToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
//            this.thôngTinNgườiDungToolStripMenuItem.Text = "Thông tin người dùng";
//            this.thôngTinNgườiDungToolStripMenuItem.Click += new System.EventHandler(this.thôngTinNgườiDungToolStripMenuItem_Click);
//            // 
//            // thayĐổiMậtKhẩuToolStripMenuItem
//            // 
//            this.thayĐổiMậtKhẩuToolStripMenuItem.Name = "thayĐổiMậtKhẩuToolStripMenuItem";
//            this.thayĐổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
//            this.thayĐổiMậtKhẩuToolStripMenuItem.Text = "Thay đổi mật khẩu";
//            this.thayĐổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.thayĐổiMậtKhẩuToolStripMenuItem_Click);
//            // 
//            // thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem
//            // 
//            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Name = "thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem";
//            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
//            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Text = "Thiết lập kết nối cơ sở dữ liệu";
//            // 
//            // saoLưuCơSởDữLiệuToolStripMenuItem
//            // 
//            this.saoLưuCơSởDữLiệuToolStripMenuItem.Name = "saoLưuCơSởDữLiệuToolStripMenuItem";
//            this.saoLưuCơSởDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
//            this.saoLưuCơSởDữLiệuToolStripMenuItem.Text = "Sao lưu cơ sở dữ liệu";
//            // 
//            // phụcHồiCơSởDữLiệuToolStripMenuItem
//            // 
//            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Name = "phụcHồiCơSởDữLiệuToolStripMenuItem";
//            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
//            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Text = "Phục hồi cơ sở dữ liệu";
//            // 
//            // thiếtLậpVịTríSaoLưuToolStripMenuItem
//            // 
//            this.thiếtLậpVịTríSaoLưuToolStripMenuItem.Name = "thiếtLậpVịTríSaoLưuToolStripMenuItem";
//            this.thiếtLậpVịTríSaoLưuToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
//            this.thiếtLậpVịTríSaoLưuToolStripMenuItem.Text = "Thiết lập vị trí sao lưu";
//            // 
//            // toolStripMenuItem1
//            // 
//            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
//            this.toolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
//            this.toolStripMenuItem1.Text = "Đăng xuất";
//            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
//            // 
//            // quảnLýCơSởDữLiệuToolStripMenuItem
//            // 
//            this.quảnLýCơSởDữLiệuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.kếtNốiCơSởDữLiệuToolStripMenuItem,
//            this.cơSởDữLiệuGISToolStripMenuItem1,
//            this.quảnLýDanhMụcCơSởDữLiệuGISToolStripMenuItem1,
//            this.thêmDữLiệuToolStripMenuItem});
//            this.quảnLýCơSởDữLiệuToolStripMenuItem.Name = "quảnLýCơSởDữLiệuToolStripMenuItem";
//            this.quảnLýCơSởDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
//            this.quảnLýCơSởDữLiệuToolStripMenuItem.Text = "Quản lý cơ sở dữ liệu";
//            // 
//            // kếtNốiCơSởDữLiệuToolStripMenuItem
//            // 
//            this.kếtNốiCơSởDữLiệuToolStripMenuItem.Name = "kếtNốiCơSởDữLiệuToolStripMenuItem";
//            this.kếtNốiCơSởDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
//            this.kếtNốiCơSởDữLiệuToolStripMenuItem.Text = "Kết nối cơ sở dữ liệu";
//            this.kếtNốiCơSởDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.kếtNốiCơSởDữLiệuToolStripMenuItem_Click);
//            // 
//            // cơSởDữLiệuGISToolStripMenuItem1
//            // 
//            this.cơSởDữLiệuGISToolStripMenuItem1.Name = "cơSởDữLiệuGISToolStripMenuItem1";
//            this.cơSởDữLiệuGISToolStripMenuItem1.Size = new System.Drawing.Size(262, 22);
//            this.cơSởDữLiệuGISToolStripMenuItem1.Text = "Cơ sở dữ liệu GIS";
//            // 
//            // quảnLýDanhMụcCơSởDữLiệuGISToolStripMenuItem1
//            // 
//            this.quảnLýDanhMụcCơSởDữLiệuGISToolStripMenuItem1.Name = "quảnLýDanhMụcCơSởDữLiệuGISToolStripMenuItem1";
//            this.quảnLýDanhMụcCơSởDữLiệuGISToolStripMenuItem1.Size = new System.Drawing.Size(262, 22);
//            this.quảnLýDanhMụcCơSởDữLiệuGISToolStripMenuItem1.Text = "Quản lý danh mục cơ sở dữ liệu GIS";
//            // 
//            // thêmDữLiệuToolStripMenuItem
//            // 
//            this.thêmDữLiệuToolStripMenuItem.Name = "thêmDữLiệuToolStripMenuItem";
//            this.thêmDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
//            this.thêmDữLiệuToolStripMenuItem.Text = "Thêm dữ liệu";
//            // 
//            // bảnĐồToolStripMenuItem
//            // 
//            this.bảnĐồToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.mởBảnĐồToolStripMenuItem1,
//            this.mởBảnĐồTừTậpTinToolStripMenuItem,
//            this.lưuBảnĐồToolStripMenuItem,
//            this.mởLớpLayerToolStripMenuItem,
//            this.mởLớpTừTậpTinToolStripMenuItem,
//            this.mởBảngTừTậpTinToolStripMenuItem,
//            this.thêmLớpToolStripMenuItem,
//            this.bảnĐồNềnGoogleToolStripMenuItem});
//            this.bảnĐồToolStripMenuItem.Name = "bảnĐồToolStripMenuItem";
//            this.bảnĐồToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
//            this.bảnĐồToolStripMenuItem.Text = "Bản đồ";
//            // 
//            // mởBảnĐồToolStripMenuItem1
//            // 
//            this.mởBảnĐồToolStripMenuItem1.Name = "mởBảnĐồToolStripMenuItem1";
//            this.mởBảnĐồToolStripMenuItem1.Size = new System.Drawing.Size(253, 22);
//            this.mởBảnĐồToolStripMenuItem1.Text = "Mở bản đồ";
//            this.mởBảnĐồToolStripMenuItem1.Click += new System.EventHandler(this.mởBảnĐồToolStripMenuItem1_Click);
//            // 
//            // mởBảnĐồTừTậpTinToolStripMenuItem
//            // 
//            this.mởBảnĐồTừTậpTinToolStripMenuItem.Name = "mởBảnĐồTừTậpTinToolStripMenuItem";
//            this.mởBảnĐồTừTậpTinToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
//            this.mởBảnĐồTừTậpTinToolStripMenuItem.Text = "Mở bản đồ từ tập tin";
//            // 
//            // lưuBảnĐồToolStripMenuItem
//            // 
//            this.lưuBảnĐồToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.lưuToolStripMenuItem,
//            this.lưuĐếnFolderToolStripMenuItem});
//            this.lưuBảnĐồToolStripMenuItem.Name = "lưuBảnĐồToolStripMenuItem";
//            this.lưuBảnĐồToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
//            this.lưuBảnĐồToolStripMenuItem.Text = "Lưu bản đồ";
//            // 
//            // lưuToolStripMenuItem
//            // 
//            this.lưuToolStripMenuItem.Name = "lưuToolStripMenuItem";
//            this.lưuToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
//            this.lưuToolStripMenuItem.Text = "Lưu";
//            this.lưuToolStripMenuItem.Click += new System.EventHandler(this.lưuToolStripMenuItem_Click);
//            // 
//            // lưuĐếnFolderToolStripMenuItem
//            // 
//            this.lưuĐếnFolderToolStripMenuItem.Name = "lưuĐếnFolderToolStripMenuItem";
//            this.lưuĐếnFolderToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
//            this.lưuĐếnFolderToolStripMenuItem.Text = "Lưu đến folder";
//            this.lưuĐếnFolderToolStripMenuItem.Click += new System.EventHandler(this.lưuĐếnFolderToolStripMenuItem_Click);
//            // 
//            // mởLớpLayerToolStripMenuItem
//            // 
//            this.mởLớpLayerToolStripMenuItem.Name = "mởLớpLayerToolStripMenuItem";
//            this.mởLớpLayerToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
//            this.mởLớpLayerToolStripMenuItem.Text = "Mở lớp layer bản đồ";
//            this.mởLớpLayerToolStripMenuItem.Click += new System.EventHandler(this.mởLớpLayerToolStripMenuItem_Click);
//            // 
//            // mởLớpTừTậpTinToolStripMenuItem
//            // 
//            this.mởLớpTừTậpTinToolStripMenuItem.Name = "mởLớpTừTậpTinToolStripMenuItem";
//            this.mởLớpTừTậpTinToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
//            this.mởLớpTừTậpTinToolStripMenuItem.Text = "Mở lớp layer từ tập tin";
//            // 
//            // mởBảngTừTậpTinToolStripMenuItem
//            // 
//            this.mởBảngTừTậpTinToolStripMenuItem.Name = "mởBảngTừTậpTinToolStripMenuItem";
//            this.mởBảngTừTậpTinToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
//            this.mởBảngTừTậpTinToolStripMenuItem.Text = "Mở bảng từ tập tin";
//            // 
//            // thêmLớpToolStripMenuItem
//            // 
//            this.thêmLớpToolStripMenuItem.Name = "thêmLớpToolStripMenuItem";
//            this.thêmLớpToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
//            this.thêmLớpToolStripMenuItem.Text = "Thêm lớp theo tọa độ X Y từ bảng";
//            // 
//            // bảnĐồNềnGoogleToolStripMenuItem
//            // 
//            this.bảnĐồNềnGoogleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.ảnhVệTinhToolStripMenuItem,
//            this.ảnhGiaoThôngToolStripMenuItem});
//            this.bảnĐồNềnGoogleToolStripMenuItem.Name = "bảnĐồNềnGoogleToolStripMenuItem";
//            this.bảnĐồNềnGoogleToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
//            this.bảnĐồNềnGoogleToolStripMenuItem.Text = "Bản đồ nền Google";
//            // 
//            // ảnhVệTinhToolStripMenuItem
//            // 
//            this.ảnhVệTinhToolStripMenuItem.Name = "ảnhVệTinhToolStripMenuItem";
//            this.ảnhVệTinhToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
//            this.ảnhVệTinhToolStripMenuItem.Text = "Ảnh vệ tinh";
//            this.ảnhVệTinhToolStripMenuItem.Click += new System.EventHandler(this.ảnhVệTinhToolStripMenuItem_Click);
//            // 
//            // ảnhGiaoThôngToolStripMenuItem
//            // 
//            this.ảnhGiaoThôngToolStripMenuItem.Name = "ảnhGiaoThôngToolStripMenuItem";
//            this.ảnhGiaoThôngToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
//            this.ảnhGiaoThôngToolStripMenuItem.Text = "Ảnh Giao thông";
//            this.ảnhGiaoThôngToolStripMenuItem.Click += new System.EventHandler(this.ảnhGiaoThôngToolStripMenuItem_Click);
//            // 
//            // traCứuToolStripMenuItem
//            // 
//            this.traCứuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.traCứuTheoThuộcTínhToolStripMenuItem,
//            this.traCứuTheoKhôngGianToolStripMenuItem1,
//            this.xemThôngTinĐốiTượngToolStripMenuItem});
//            this.traCứuToolStripMenuItem.Name = "traCứuToolStripMenuItem";
//            this.traCứuToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
//            this.traCứuToolStripMenuItem.Text = "Tra cứu";
//            // 
//            // traCứuTheoThuộcTínhToolStripMenuItem
//            // 
//            this.traCứuTheoThuộcTínhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.đườngGiaoThôngChínhToolStripMenuItem,
//            this.kiệtHẻmToolStripMenuItem});
//            this.traCứuTheoThuộcTínhToolStripMenuItem.Name = "traCứuTheoThuộcTínhToolStripMenuItem";
//            this.traCứuTheoThuộcTínhToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
//            this.traCứuTheoThuộcTínhToolStripMenuItem.Text = "Tra cứu theo thuộc tính";
//            // 
//            // đườngGiaoThôngChínhToolStripMenuItem
//            // 
//            this.đườngGiaoThôngChínhToolStripMenuItem.Name = "đườngGiaoThôngChínhToolStripMenuItem";
//            this.đườngGiaoThôngChínhToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
//            this.đườngGiaoThôngChínhToolStripMenuItem.Text = "Đường giao thông chính";
//            this.đườngGiaoThôngChínhToolStripMenuItem.Click += new System.EventHandler(this.đườngGiaoThôngChínhToolStripMenuItem_Click);
//            // 
//            // kiệtHẻmToolStripMenuItem
//            // 
//            this.kiệtHẻmToolStripMenuItem.Name = "kiệtHẻmToolStripMenuItem";
//            this.kiệtHẻmToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
//            this.kiệtHẻmToolStripMenuItem.Text = "Kiệt hẻm";
//            this.kiệtHẻmToolStripMenuItem.Click += new System.EventHandler(this.kiệtHẻmToolStripMenuItem_Click);
//            // 
//            // traCứuTheoKhôngGianToolStripMenuItem1
//            // 
//            this.traCứuTheoKhôngGianToolStripMenuItem1.Name = "traCứuTheoKhôngGianToolStripMenuItem1";
//            this.traCứuTheoKhôngGianToolStripMenuItem1.Size = new System.Drawing.Size(205, 22);
//            this.traCứuTheoKhôngGianToolStripMenuItem1.Text = "Tra cứu theo không gian";
//            // 
//            // xemThôngTinĐốiTượngToolStripMenuItem
//            // 
//            this.xemThôngTinĐốiTượngToolStripMenuItem.Name = "xemThôngTinĐốiTượngToolStripMenuItem";
//            this.xemThôngTinĐốiTượngToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
//            this.xemThôngTinĐốiTượngToolStripMenuItem.Text = "Xem thông tin đối tượng";
//            this.xemThôngTinĐốiTượngToolStripMenuItem.Click += new System.EventHandler(this.xemThôngTinĐốiTượngToolStripMenuItem_Click);
//            // 
//            // thanhCôngCụToolStripMenuItem
//            // 
//            this.thanhCôngCụToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.côngCụToolStripMenuItem,
//            this.thanhTrạngTháiToolStripMenuItem,
//            this.côngCụCơBảnToolStripMenuItem,
//            this.côngCụCậpNhậtDữLiệuToolStripMenuItem,
//            this.lưuToolToolStripMenuItem,
//            this.tùyChỉnhToolStripMenuItem});
//            this.thanhCôngCụToolStripMenuItem.Name = "thanhCôngCụToolStripMenuItem";
//            this.thanhCôngCụToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
//            this.thanhCôngCụToolStripMenuItem.Text = "Thanh công cụ";
//            // 
//            // côngCụToolStripMenuItem
//            // 
//            this.côngCụToolStripMenuItem.Name = "côngCụToolStripMenuItem";
//            this.côngCụToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
//            this.côngCụToolStripMenuItem.Text = "Công cụ";
//            // 
//            // thanhTrạngTháiToolStripMenuItem
//            // 
//            this.thanhTrạngTháiToolStripMenuItem.Name = "thanhTrạngTháiToolStripMenuItem";
//            this.thanhTrạngTháiToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
//            this.thanhTrạngTháiToolStripMenuItem.Text = "Thanh trạng thái";
//            // 
//            // côngCụCơBảnToolStripMenuItem
//            // 
//            this.côngCụCơBảnToolStripMenuItem.Name = "côngCụCơBảnToolStripMenuItem";
//            this.côngCụCơBảnToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
//            this.côngCụCơBảnToolStripMenuItem.Text = "Công cụ cơ bản";
//            // 
//            // côngCụCậpNhậtDữLiệuToolStripMenuItem
//            // 
//            this.côngCụCậpNhậtDữLiệuToolStripMenuItem.Name = "côngCụCậpNhậtDữLiệuToolStripMenuItem";
//            this.côngCụCậpNhậtDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
//            this.côngCụCậpNhậtDữLiệuToolStripMenuItem.Text = "Công cụ cập nhật dữ liệu";
//            // 
//            // lưuToolToolStripMenuItem
//            // 
//            this.lưuToolToolStripMenuItem.Name = "lưuToolToolStripMenuItem";
//            this.lưuToolToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
//            this.lưuToolToolStripMenuItem.Text = "Lưu tool";
//            // 
//            // tùyChỉnhToolStripMenuItem
//            // 
//            this.tùyChỉnhToolStripMenuItem.Name = "tùyChỉnhToolStripMenuItem";
//            this.tùyChỉnhToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
//            this.tùyChỉnhToolStripMenuItem.Text = "Tùy chỉnh";
//            // 
//            // trangInToolStripMenuItem
//            // 
//            this.trangInToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.xuấtẢnhToolStripMenuItem,
//            this.xuấtBáoCáoToolStripMenuItem,
//            this.inToolStripMenuItem,
//            this.chọnCỡGiấyToolStripMenuItem});
//            this.trangInToolStripMenuItem.Name = "trangInToolStripMenuItem";
//            this.trangInToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
//            this.trangInToolStripMenuItem.Text = "Trang in";
//            // 
//            // xuấtẢnhToolStripMenuItem
//            // 
//            this.xuấtẢnhToolStripMenuItem.Name = "xuấtẢnhToolStripMenuItem";
//            this.xuấtẢnhToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
//            this.xuấtẢnhToolStripMenuItem.Text = "Xuất ảnh";
//            this.xuấtẢnhToolStripMenuItem.Click += new System.EventHandler(this.xuấtẢnhToolStripMenuItem_Click);
//            // 
//            // xuấtBáoCáoToolStripMenuItem
//            // 
//            this.xuấtBáoCáoToolStripMenuItem.Name = "xuấtBáoCáoToolStripMenuItem";
//            this.xuấtBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
//            this.xuấtBáoCáoToolStripMenuItem.Text = "Xuất báo cáo";
//            // 
//            // inToolStripMenuItem
//            // 
//            this.inToolStripMenuItem.Name = "inToolStripMenuItem";
//            this.inToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
//            this.inToolStripMenuItem.Text = "In";
//            this.inToolStripMenuItem.Click += new System.EventHandler(this.inToolStripMenuItem_Click);
//            // 
//            // trợGiúpToolStripMenuItem
//            // 
//            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.hướngDẫnSửDụngToolStripMenuItem,
//            this.giớiThiệuSảnPhâprToolStripMenuItem});
//            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
//            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
//            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
//            // 
//            // hướngDẫnSửDụngToolStripMenuItem
//            // 
//            this.hướngDẫnSửDụngToolStripMenuItem.Name = "hướngDẫnSửDụngToolStripMenuItem";
//            this.hướngDẫnSửDụngToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
//            this.hướngDẫnSửDụngToolStripMenuItem.Text = "Hướng dẫn sử dụng";
//            // 
//            // giớiThiệuSảnPhâprToolStripMenuItem
//            // 
//            this.giớiThiệuSảnPhâprToolStripMenuItem.Name = "giớiThiệuSảnPhâprToolStripMenuItem";
//            this.giớiThiệuSảnPhâprToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
//            this.giớiThiệuSảnPhâprToolStripMenuItem.Text = "Giới thiệu sản phẩm";
//            this.giớiThiệuSảnPhâprToolStripMenuItem.Click += new System.EventHandler(this.giớiThiệuSảnPhâprToolStripMenuItem_Click);
//            // 
//            // splitContainer1
//            // 
//            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
//            this.splitContainer1.Name = "splitContainer1";
//            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
//            // 
//            // splitContainer1.Panel1
//            // 
//            this.splitContainer1.Panel1.Controls.Add(this.axToolbarControl5);
//            this.splitContainer1.Panel1.Controls.Add(this.chkCustomize);
//            this.splitContainer1.Panel1.Controls.Add(this.axToolbarControl1);
//            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
//            // 
//            // splitContainer1.Panel2
//            // 
//            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
//            this.splitContainer1.Size = new System.Drawing.Size(1904, 959);
//            this.splitContainer1.SplitterDistance = 79;
//            this.splitContainer1.TabIndex = 8;
//            // 
//            // axToolbarControl5
//            // 
//            this.axToolbarControl5.Dock = System.Windows.Forms.DockStyle.Bottom;
//            this.axToolbarControl5.Location = new System.Drawing.Point(0, 51);
//            this.axToolbarControl5.Name = "axToolbarControl5";
//            this.axToolbarControl5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl5.OcxState")));
//            this.axToolbarControl5.Size = new System.Drawing.Size(1830, 28);
//            this.axToolbarControl5.TabIndex = 4;
//            // 
//            // chkCustomize
//            // 
//            this.chkCustomize.AutoSize = true;
//            this.chkCustomize.Dock = System.Windows.Forms.DockStyle.Right;
//            this.chkCustomize.Location = new System.Drawing.Point(1830, 24);
//            this.chkCustomize.Name = "chkCustomize";
//            this.chkCustomize.Size = new System.Drawing.Size(74, 55);
//            this.chkCustomize.TabIndex = 2;
//            this.chkCustomize.Text = "Customize";
//            this.chkCustomize.UseVisualStyleBackColor = true;
//            this.chkCustomize.CheckedChanged += new System.EventHandler(this.chkCustomize_CheckedChanged_1);
//            // 
//            // axToolbarControl1
//            // 
//            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.axToolbarControl1.Location = new System.Drawing.Point(0, 24);
//            this.axToolbarControl1.Name = "axToolbarControl1";
//            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
//            this.axToolbarControl1.Size = new System.Drawing.Size(1904, 28);
//            this.axToolbarControl1.TabIndex = 1;
//            // 
//            // splitContainer2
//            // 
//            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
//            this.splitContainer2.Name = "splitContainer2";
//            // 
//            // splitContainer2.Panel1
//            // 
//            this.splitContainer2.Panel1.Controls.Add(axTOCControl1);
//            // 
//            // splitContainer2.Panel2
//            // 
//            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
//            this.splitContainer2.Size = new System.Drawing.Size(1904, 876);
//            this.splitContainer2.SplitterDistance = 222;
//            this.splitContainer2.SplitterWidth = 3;
//            this.splitContainer2.TabIndex = 0;
//            // 
//            // axTOCControl1
//            // 
//            axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
//            axTOCControl1.Location = new System.Drawing.Point(0, 0);
//            axTOCControl1.Name = "axTOCControl1";
//            axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
//            axTOCControl1.Size = new System.Drawing.Size(222, 876);
//            axTOCControl1.TabIndex = 0;
//            axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(axTOCControl1_OnMouseDown);
//            axTOCControl1.OnBeginLabelEdit += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnBeginLabelEditEventHandler(axTOCControl1_OnBeginLabelEdit);
//            axTOCControl1.OnEndLabelEdit += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnEndLabelEditEventHandler(axTOCControl1_OnEndLabelEdit);
//            // 
//            // tabControl1
//            // 
//            this.tabControl1.Controls.Add(this.tabPage1);
//            this.tabControl1.Controls.Add(this.tabPage2);
//            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.tabControl1.Location = new System.Drawing.Point(0, 0);
//            this.tabControl1.Name = "tabControl1";
//            this.tabControl1.SelectedIndex = 0;
//            this.tabControl1.Size = new System.Drawing.Size(1679, 876);
//            this.tabControl1.TabIndex = 0;
//            this.tabControl1.Click += new System.EventHandler(this.TabControl1_Click);
//            // 
//            // tabPage1
//            // 
//            this.tabPage1.Controls.Add(axMapControl1);
//            this.tabPage1.Location = new System.Drawing.Point(4, 22);
//            this.tabPage1.Name = "tabPage1";
//            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
//            this.tabPage1.Size = new System.Drawing.Size(1671, 850);
//            this.tabPage1.TabIndex = 0;
//            this.tabPage1.Text = "Bản đồ";
//            this.tabPage1.UseVisualStyleBackColor = true;
//            // 
//            // axMapControl1
//            // 
//            axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
//            axMapControl1.Location = new System.Drawing.Point(3, 3);
//            axMapControl1.Name = "axMapControl1";
//            axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
//            axMapControl1.Size = new System.Drawing.Size(1665, 844);
//            axMapControl1.TabIndex = 0;
//            axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.b);
//            axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(axMapControl1_OnMouseMove);
//            axMapControl1.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(axMapControl1_OnAfterScreenDraw);
//            axMapControl1.OnAfterDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterDrawEventHandler(axMapControl1_OnAfterDraw);
//            axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(axMapControl1_OnMapReplaced);
//            // 
//            // tabPage2
//            // 
//            this.tabPage2.Controls.Add(axPageLayoutControl1);
//            this.tabPage2.Controls.Add(this.axLicenseControl1);
//            this.tabPage2.Controls.Add(this.axToolbarControl2);
//            this.tabPage2.Controls.Add(this.axToolbarControl3);
//            this.tabPage2.Location = new System.Drawing.Point(4, 22);
//            this.tabPage2.Name = "tabPage2";
//            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
//            this.tabPage2.Size = new System.Drawing.Size(1671, 850);
//            this.tabPage2.TabIndex = 1;
//            this.tabPage2.Text = "Trang in";
//            this.tabPage2.UseVisualStyleBackColor = true;
//            // 
//            // axPageLayoutControl1
//            // 
//            axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
//            axPageLayoutControl1.Location = new System.Drawing.Point(3, 3);
//            axPageLayoutControl1.Name = "axPageLayoutControl1";
//            axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
//            axPageLayoutControl1.Size = new System.Drawing.Size(1665, 844);
//            axPageLayoutControl1.TabIndex = 0;
//            axPageLayoutControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.a);
//            axPageLayoutControl1.OnPageLayoutReplaced += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnPageLayoutReplacedEventHandler(axPageLayoutControl1_OnPageLayoutReplaced);
//            axPageLayoutControl1.Resize += new System.EventHandler(axPageLayoutControl1_Resize);
//            // 
//            // axLicenseControl1
//            // 
//            this.axLicenseControl1.Enabled = true;
//            this.axLicenseControl1.Location = new System.Drawing.Point(414, 229);
//            this.axLicenseControl1.Name = "axLicenseControl1";
//            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
//            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
//            this.axLicenseControl1.TabIndex = 1;
//            // 
//            // axToolbarControl2
//            // 
//            this.axToolbarControl2.Location = new System.Drawing.Point(339, 143);
//            this.axToolbarControl2.Name = "axToolbarControl2";
//            this.axToolbarControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl2.OcxState")));
//            this.axToolbarControl2.Size = new System.Drawing.Size(59, 28);
//            this.axToolbarControl2.TabIndex = 2;
//            // 
//            // axToolbarControl3
//            // 
//            this.axToolbarControl3.Location = new System.Drawing.Point(764, 345);
//            this.axToolbarControl3.Name = "axToolbarControl3";
//            this.axToolbarControl3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl3.OcxState")));
//            this.axToolbarControl3.Size = new System.Drawing.Size(10, 28);
//            this.axToolbarControl3.TabIndex = 3;
//            // 
//            // chọnCỡGiấyToolStripMenuItem
//            // 
//            this.chọnCỡGiấyToolStripMenuItem.Name = "chọnCỡGiấyToolStripMenuItem";
//            this.chọnCỡGiấyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
//            this.chọnCỡGiấyToolStripMenuItem.Text = "Chọn cỡ giấy";
//            this.chọnCỡGiấyToolStripMenuItem.Click += new System.EventHandler(this.chọnCỡGiấyToolStripMenuItem_Click);
//            // 
//            // QuanTriHeThong
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(1904, 981);
//            this.Controls.Add(this.splitContainer1);
//            this.Controls.Add(this.statusStrip1);
//            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
//            this.MainMenuStrip = this.menuStrip1;
//            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
//            this.Name = "QuanTriHeThong";
//            this.Text = "SGMC - CSDLTNMT - Quản trị hệ thống";
//            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
//            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapViewer_FormClosing);
//            this.Load += new System.EventHandler(this.MainForm_Load);
//            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
//            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
//            this.statusStrip1.ResumeLayout(false);
//            this.statusStrip1.PerformLayout();
//            this.menuStrip1.ResumeLayout(false);
//            this.menuStrip1.PerformLayout();
//            this.splitContainer1.Panel1.ResumeLayout(false);
//            this.splitContainer1.Panel1.PerformLayout();
//            this.splitContainer1.Panel2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
//            this.splitContainer1.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl5)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
//            this.splitContainer2.Panel1.ResumeLayout(false);
//            this.splitContainer2.Panel2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
//            this.splitContainer2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(axTOCControl1)).EndInit();
//            this.tabControl1.ResumeLayout(false);
//            this.tabPage1.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(axMapControl1)).EndInit();
//            this.tabPage2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(axPageLayoutControl1)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl2)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl3)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.StatusStrip statusStrip1;
//        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
//        private MenuStrip menuStrip1;
//        private ToolStripMenuItem hệThốngToolStripMenuItem;
//        private ToolStripMenuItem quảnLýCơSởDữLiệuToolStripMenuItem;
//        private ToolStripMenuItem kếtNốiCơSởDữLiệuToolStripMenuItem;
//        private ToolStripMenuItem thêmDữLiệuToolStripMenuItem;
//        private ToolStripMenuItem traCứuToolStripMenuItem;
//        private ToolStripMenuItem xemThôngTinĐốiTượngToolStripMenuItem;
//        private SplitContainer splitContainer1;
//        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
//        private SplitContainer splitContainer2;
//        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
//        private TabControl tabControl1;
//        private TabPage tabPage1;
//        private TabPage tabPage2;
//        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
//        public static ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
//        private CheckBox chkCustomize;
//        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl2;
//        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl3;
//        public static ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
//        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl5;
//        private ToolStripMenuItem quảnLýNgườiDùngToolStripMenuItem;
//        private ToolStripMenuItem nhậtKíLàmViệcToolStripMenuItem;
//        private ToolStripMenuItem thôngTinNgườiDungToolStripMenuItem;
//        private ToolStripMenuItem thayĐổiMậtKhẩuToolStripMenuItem;
//        private ToolStripMenuItem thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem;
//        private ToolStripMenuItem saoLưuCơSởDữLiệuToolStripMenuItem;
//        private ToolStripMenuItem phụcHồiCơSởDữLiệuToolStripMenuItem;
//        private ToolStripMenuItem thiếtLậpVịTríSaoLưuToolStripMenuItem;
//        private ToolStripMenuItem bảnĐồToolStripMenuItem;
//        private ToolStripMenuItem mởBảnĐồToolStripMenuItem1;
//        private ToolStripMenuItem mởBảnĐồTừTậpTinToolStripMenuItem;
//        private ToolStripMenuItem lưuBảnĐồToolStripMenuItem;
//        private ToolStripMenuItem mởLớpLayerToolStripMenuItem;
//        private ToolStripMenuItem mởLớpTừTậpTinToolStripMenuItem;
//        private ToolStripMenuItem mởBảngTừTậpTinToolStripMenuItem;
//        private ToolStripMenuItem thêmLớpToolStripMenuItem;
//        private ToolStripMenuItem toolStripMenuItem1;
//        private ToolStripMenuItem traCứuTheoThuộcTínhToolStripMenuItem;
//        private ToolStripMenuItem traCứuTheoKhôngGianToolStripMenuItem1;
//        private ToolStripMenuItem đườngGiaoThôngChínhToolStripMenuItem;
//        private ToolStripMenuItem kiệtHẻmToolStripMenuItem;
//        private ToolStripMenuItem thanhCôngCụToolStripMenuItem;
//        private ToolStripMenuItem côngCụToolStripMenuItem;
//        private ToolStripMenuItem thanhTrạngTháiToolStripMenuItem;
//        private ToolStripMenuItem côngCụCơBảnToolStripMenuItem;
//        private ToolStripMenuItem côngCụCậpNhậtDữLiệuToolStripMenuItem;
//        private ToolStripMenuItem tùyChỉnhToolStripMenuItem;
//        private ToolStripMenuItem trangInToolStripMenuItem;
//        private ToolStripMenuItem xuấtẢnhToolStripMenuItem;
//        private ToolStripMenuItem xuấtBáoCáoToolStripMenuItem;
//        private ToolStripMenuItem inToolStripMenuItem;
//        private ToolStripMenuItem trợGiúpToolStripMenuItem;
//        private ToolStripMenuItem lưuToolStripMenuItem;
//        private ToolStripMenuItem lưuĐếnFolderToolStripMenuItem;
//        private ToolStripMenuItem cơSởDữLiệuGISToolStripMenuItem1;
//        private ToolStripMenuItem quảnLýDanhMụcCơSởDữLiệuGISToolStripMenuItem1;
//        private ToolStripMenuItem thôngTinCơQuanToolStripMenuItem;
//        private ToolStripMenuItem hướngDẫnSửDụngToolStripMenuItem;
//        private ToolStripMenuItem giớiThiệuSảnPhâprToolStripMenuItem;
//        private ToolStripMenuItem bảnĐồNềnGoogleToolStripMenuItem;
//        private ToolStripMenuItem ảnhVệTinhToolStripMenuItem;
//        private ToolStripMenuItem ảnhGiaoThôngToolStripMenuItem;
//        private ToolStripMenuItem lưuToolToolStripMenuItem;
//        private ToolStripMenuItem chọnCỡGiấyToolStripMenuItem;
//    }
//}
