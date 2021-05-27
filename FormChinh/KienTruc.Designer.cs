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
    partial class KienTruc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KienTruc));
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
            this.treeList2 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.axLicenseControl2 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.axToolbarControl2 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axToolbarControl3 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.axToolbarControl5 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axToolbarControl4 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
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
            this.bảnĐồNềnVệTinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ảnhVệTinhToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.thôngTinTàiKhoảnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậtKíLàmViệcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýPhòngBanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhCôngCụToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụCơBảnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụChỉnhSửaTrangInToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tùyChỉnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuThanhCôngCụToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bảnĐồNềnGoogleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ảnhVệTinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kếtNốiCơSởDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saoLưuCơSởDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phụcHồiCơSởDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhCôngCụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhCôngCụToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụCơBảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụChỉnhSửaTrangInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tùyChỉnhToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuThanhCôngCụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụCơBảnToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụChỉnhSửaTrangInToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tùyChỉnhToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuThanhCôngCụToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kiểmTraFileDGNMớiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtDữLiệuQuyHoạchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiDữLiệuĐườngSangVùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtDữLiệuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtBảnĐồGiấyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtDữLiệuQuỹĐấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiAnnotationSangShapfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuẩnHóaDữLiệuQuỹĐấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtDựÁnQuyHoạchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtDữLiệuToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiHệTọaĐộToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiTừHN72VN2000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiTừVN2000WGS84ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiTừWGS84VN2000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýQuyHoạchKiếnTrúcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýThôngTinQuyHoạchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýThôngTinQuyHoạchChiTiết1500ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýThôngTinQuyHoạchPhânKhuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýThôngTinQuyHoạchChungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýThôngTinKiếnTrúcXâyDựngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHồSơXácNhậnQuyHoạchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCơSởHTKTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giaoThôngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đườngGiaoThôngChínhToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.đườngKiệtHẻmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.biểnBáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýBiểnBáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLoạiBiểnBáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cầuĐườngBộToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vỉaHèToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.điệnChiếuSángToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.điệnChiếuSángChínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tuyếnDâyĐiệnChínhToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trụĐiệnChiếuSángChínhToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.điệnChiếuSángKiệtHẻmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tuyếnDâyĐiệnKiệtHẻmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trụĐiệnChiếuSángKiệtHẻmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.câyXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCâyXanhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.quảnLýĐơnVịChămSócToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCôngViênToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLoạiChămSócToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmUrlFileĐínhKèmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtTọaĐộCâyXanhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bưuChínhViễnThôngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trạmBTSToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.đạiLýInternetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mươngThoátNướcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mươngThoátNướcChinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mươngThoátNướcKiệtHẻmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hốGaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hốGaChínhKiệtHẻmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTàiNguyênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTàiNguyênNướcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHồChứaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTrạmBơmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐậpDângToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảngLýLoạiKênhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCấpPhépKhaiThácToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCấpPhépKhaiThácNướcNgầmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCấpPhépXảThảiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTàiNguyênĐấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTàiNguyênKhoángSảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýQuyHoạchKhoángSảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýQuyHoạchVùngCấmTạmCấmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHoạtĐộngKhaiThácToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHồSơToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traCứuThôngTinQuyHoạchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traCứuNhanhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tìmTheoTọaĐộĐiểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theoKhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.traCứuThôngTinThửaĐấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traCứuThôngTinKiếnTrúcToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnSửDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giớiThiệuSảnPhâprToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDiaChinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýQuyHoạchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêTraCứuKhuQuyHoạchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traCứuHồSơQuyHoạchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKiếnTrúcXâyDựngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHồSơKiếnTrúcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cấpGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.điềuChỉnhGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giaHạnGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cấpLạiGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cấpGiấyPhépXâyDựngCóThờiHạnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cấpGiấyPhépXâyDựngĐốiVớiTrườngHợpSửaChữaCảiTạoNhàỞRiêngLẻToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCSHTKýThuậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giaoThôngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.đườngGiaoThôngChínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đườngKiệtHẻmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.điệnChiếuSángToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tuyếnDâyĐiệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trụĐiệnChiếuSángToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.câyXanhToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCâyXanhBóngMátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýThảmCỏToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCâyTrangTríToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.quảnLýĐơnVịChămSócToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCôngViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLoạiChămSócToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátNướcToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.đườngMươngThoátNướcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lỗCốngThoátNướcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảmLýBTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTrạmBTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qảunLýTrạmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLoạiTrạmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýChủĐầuTưToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐạiLýInternetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐạiLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhàMạngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýChủĐạiLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCapViễnThôngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTuyếnCápNgầmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýTuyếnCápTreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýBểCápToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCộtCápTreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýDoanhNghiệpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýThiếtBịPhụTrợToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýCôngTrìnhHạTầngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHồSơQuyếtĐịnhPhêDuyệtDựÁnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
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
            this.tabNavigationPage1.Size = new System.Drawing.Size(198, 846);
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
            treeList1.Cursor = System.Windows.Forms.Cursors.Arrow;
            treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            treeList1.Location = new System.Drawing.Point(0, 0);
            treeList1.Name = "treeList1";
            treeList1.BeginUnboundLoad();
            treeList1.AppendNode(new object[] {
            "Quy hoạch chi tiết 1.500",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch chi tiết",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch chi tiết Polygon",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch chi tiết Line",
            false}, 0);
            treeList1.AppendNode(new object[] {
            "Quy hoạch phân khu 1.5000",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Ranh giới quy hoạch phân khu",
            false}, 4);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch phân khu Polygon",
            false}, 4);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch phân khu Line",
            false}, 4);
            treeList1.AppendNode(new object[] {
            "Quy hoạch Chung 1.10000",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch chung Polygon",
            false}, 8);
            treeList1.AppendNode(new object[] {
            "Mặt bằng quy hoạch chung Line",
            false}, 8);
            treeList1.AppendNode(new object[] {
            "Kiến trúc",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Kiến trúc",
            false}, 11);
            treeList1.AppendNode(new object[] {
            "Lớp nền",
            false}, -1);
            treeList1.AppendNode(new object[] {
            "Bản đồ nền Vệ tinh",
            false}, 13);
            treeList1.AppendNode(new object[] {
            "Bản đồ nền giao thông",
            false}, 13);
            treeList1.EndUnboundLoad();
            treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            treeList1.Size = new System.Drawing.Size(198, 846);
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
            this.tabPane1.RegularSize = new System.Drawing.Size(198, 638);
            this.tabPane1.SelectedPage = this.tabNavigationPage1;
            this.tabPane1.Size = new System.Drawing.Size(198, 638);
            this.tabPane1.TabIndex = 2;
            this.tabPane1.Text = "tabPane1";
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "Lớp layer";
            this.tabNavigationPage2.Controls.Add(axTOCControl1);
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(198, 846);
            // 
            // axTOCControl1
            // 
            axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            axTOCControl1.Location = new System.Drawing.Point(0, 0);
            axTOCControl1.Name = "axTOCControl1";
            axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            axTOCControl1.Size = new System.Drawing.Size(198, 846);
            axTOCControl1.TabIndex = 1;
            axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(axTOCControl1_OnMouseDown);
            axTOCControl1.OnDoubleClick += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnDoubleClickEventHandler(axTOCControl1_OnDoubleClick);
            axTOCControl1.OnBeginLabelEdit += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnBeginLabelEditEventHandler(axTOCControl1_OnBeginLabelEdit);
            axTOCControl1.OnEndLabelEdit += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnEndLabelEditEventHandler(axTOCControl1_OnEndLabelEdit);
            // 
            // tabNavigationPage3
            // 
            this.tabNavigationPage3.Caption = "Dữ liệu dùng chung";
            this.tabNavigationPage3.Controls.Add(this.treeList2);
            this.tabNavigationPage3.Name = "tabNavigationPage3";
            this.tabNavigationPage3.Size = new System.Drawing.Size(180, 801);
            // 
            // treeList2
            // 
            this.treeList2.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList2.Appearance.BandPanel.Options.UseFont = true;
            this.treeList2.Appearance.Caption.Font = new System.Drawing.Font("Tahoma", 9F);
            this.treeList2.Appearance.Caption.Options.UseFont = true;
            this.treeList2.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.treeList2.Appearance.FilterPanel.Options.UseFont = true;
            this.treeList2.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.treeList2.Appearance.FocusedCell.Options.UseFont = true;
            this.treeList2.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.treeList2.Appearance.FocusedRow.Options.UseFont = true;
            this.treeList2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.treeList2.Appearance.FooterPanel.Options.UseFont = true;
            this.treeList2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList2.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeList2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.treeList2.Appearance.Row.Options.UseFont = true;
            this.treeList2.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList2.Appearance.SelectedRow.Options.UseFont = true;
            this.treeList2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList2.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList2.Location = new System.Drawing.Point(0, 0);
            this.treeList2.Name = "treeList2";
            this.treeList2.BeginUnboundLoad();
            this.treeList2.AppendNode(new object[] {
            "Dữ liệu dùng chung",
            false}, -1);
            this.treeList2.AppendNode(new object[] {
            "Đường giao thông chính",
            false}, 0);
            this.treeList2.AppendNode(new object[] {
            "Mặt bằng quy hoạch",
            false}, 0);
            this.treeList2.AppendNode(new object[] {
            "Địa chính",
            false}, 0);
            this.treeList2.AppendNode(new object[] {
            "Ranh giới hành chính",
            false}, 0);
            this.treeList2.AppendNode(new object[] {
            "Nền Phường",
            false}, 0);
            this.treeList2.AppendNode(new object[] {
            "Bản đồ nền Vệ tinh",
            false}, 0);
            this.treeList2.EndUnboundLoad();
            this.treeList2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.treeList2.Size = new System.Drawing.Size(180, 801);
            this.treeList2.TabIndex = 42;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn1.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "Lớp dữ liệu";
            this.treeListColumn1.FieldName = "Tên lớp";
            this.treeListColumn1.MinWidth = 88;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 174;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn2.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn2.Caption = "Mở";
            this.treeListColumn2.ColumnEdit = this.repositoryItemCheckEdit2;
            this.treeListColumn2.FieldName = "Mở";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 42;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEdit2_Click);
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
            this.splitContainer2.Size = new System.Drawing.Size(1264, 638);
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
            this.tabControl1.Size = new System.Drawing.Size(1063, 638);
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
            this.tabPage1.Size = new System.Drawing.Size(1055, 612);
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
            axMapControl1.Size = new System.Drawing.Size(1049, 606);
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
            this.tabPage2.Size = new System.Drawing.Size(1055, 612);
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
            axPageLayoutControl1.Size = new System.Drawing.Size(1049, 606);
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
            this.splitContainer1.Size = new System.Drawing.Size(1264, 727);
            this.splitContainer1.SplitterDistance = 85;
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
            this.panelControl1.Size = new System.Drawing.Size(1264, 60);
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
            this.axToolbarControl4.Location = new System.Drawing.Point(2, 30);
            this.axToolbarControl4.Name = "axToolbarControl4";
            this.axToolbarControl4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl4.OcxState")));
            this.axToolbarControl4.Size = new System.Drawing.Size(1047, 28);
            this.axToolbarControl4.TabIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.comboBox3);
            this.panelControl2.Controls.Add(this.comboBox2);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.textBox1);
            this.panelControl2.Controls.Add(this.button2);
            this.panelControl2.Controls.Add(this.textBox2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(1049, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(213, 56);
            this.panelControl2.TabIndex = 8;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Hòa An",
            "Hòa Phát",
            "Hòa Thọ Tây",
            "Hòa Thọ Đông",
            "Khuê Trung",
            "Hòa Xuân"});
            this.comboBox3.Location = new System.Drawing.Point(6, 36);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(140, 21);
            this.comboBox3.TabIndex = 50;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 56);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(140, 21);
            this.comboBox2.TabIndex = 49;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.ChọnPhuongTraCuuQH_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Số thửa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Số tờ";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(58, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "a";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.TraCuuNhanhQH_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(62, 15);
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
            this.thanhCôngCụToolStripMenuItem,
            this.chuyểnĐổiDữLiệuToolStripMenuItem,
            this.toolStripMenuItem3,
            this.quảnLýQuyHoạchKiếnTrúcToolStripMenuItem,
            this.quảnLýCơSởHTKTToolStripMenuItem,
            this.quảnLýTàiNguyênToolStripMenuItem,
            this.traCứuThôngTinQuyHoạchToolStripMenuItem,
            this.trợGiúpToolStripMenuItem,
            this.quToolStripMenuItem});
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
            this.bảnĐồNềnVệTinhToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem2,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15,
            this.toolStripSeparator7,
            this.thôngTinTàiKhoảnToolStripMenuItem1,
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
            // bảnĐồNềnVệTinhToolStripMenuItem
            // 
            this.bảnĐồNềnVệTinhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ảnhVệTinhToolStripMenuItem2});
            this.bảnĐồNềnVệTinhToolStripMenuItem.Name = "bảnĐồNềnVệTinhToolStripMenuItem";
            this.bảnĐồNềnVệTinhToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.bảnĐồNềnVệTinhToolStripMenuItem.Text = "Bản đồ nền vệ tinh";
            // 
            // ảnhVệTinhToolStripMenuItem2
            // 
            this.ảnhVệTinhToolStripMenuItem2.Name = "ảnhVệTinhToolStripMenuItem2";
            this.ảnhVệTinhToolStripMenuItem2.Size = new System.Drawing.Size(147, 22);
            this.ảnhVệTinhToolStripMenuItem2.Text = "Ảnh vệ tinh";
            this.ảnhVệTinhToolStripMenuItem2.Click += new System.EventHandler(this.ảnhVệTinhToolStripMenuItem_CheckedChanged);
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
            // thôngTinTàiKhoảnToolStripMenuItem1
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem1.Name = "thôngTinTàiKhoảnToolStripMenuItem1";
            this.thôngTinTàiKhoảnToolStripMenuItem1.Size = new System.Drawing.Size(239, 22);
            this.thôngTinTàiKhoảnToolStripMenuItem1.Text = "Thông tin tài khoản";
            this.thôngTinTàiKhoảnToolStripMenuItem1.Click += new System.EventHandler(this.thôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.thoátToolStripMenuItem.Text = "Đăng xuất";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýNgườiDùngToolStripMenuItem,
            this.quảnLýPhòngBanToolStripMenuItem,
            this.côngCụToolStripMenuItem,
            this.kếtNốiCơSởDữLiệuToolStripMenuItem,
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem,
            this.saoLưuCơSởDữLiệuToolStripMenuItem,
            this.phụcHồiCơSởDữLiệuToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(78, 21);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // quảnLýNgườiDùngToolStripMenuItem
            // 
            this.quảnLýNgườiDùngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinNgườiDùngToolStripMenuItem,
            this.nhậtKíLàmViệcToolStripMenuItem});
            this.quảnLýNgườiDùngToolStripMenuItem.Name = "quảnLýNgườiDùngToolStripMenuItem";
            this.quảnLýNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.quảnLýNgườiDùngToolStripMenuItem.Text = "Quản lý người dùng";
            // 
            // thôngTinNgườiDùngToolStripMenuItem
            // 
            this.thôngTinNgườiDùngToolStripMenuItem.Name = "thôngTinNgườiDùngToolStripMenuItem";
            this.thôngTinNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.thôngTinNgườiDùngToolStripMenuItem.Text = "Thông tin người dùng";
            this.thôngTinNgườiDùngToolStripMenuItem.Click += new System.EventHandler(this.thôngTinNgườiDùngToolStripMenuItem_Click_1);
            // 
            // nhậtKíLàmViệcToolStripMenuItem
            // 
            this.nhậtKíLàmViệcToolStripMenuItem.Name = "nhậtKíLàmViệcToolStripMenuItem";
            this.nhậtKíLàmViệcToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.nhậtKíLàmViệcToolStripMenuItem.Text = "Nhật kí làm việc";
            this.nhậtKíLàmViệcToolStripMenuItem.Click += new System.EventHandler(this.nhậtKíLàmViệcToolStripMenuItem_Click_1);
            // 
            // quảnLýPhòngBanToolStripMenuItem
            // 
            this.quảnLýPhòngBanToolStripMenuItem.Name = "quảnLýPhòngBanToolStripMenuItem";
            this.quảnLýPhòngBanToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.quảnLýPhòngBanToolStripMenuItem.Text = "Quản lý phòng ban";
            this.quảnLýPhòngBanToolStripMenuItem.Click += new System.EventHandler(this.quảnLýPhòngBanToolStripMenuItem_Click);
            // 
            // côngCụToolStripMenuItem
            // 
            this.côngCụToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thanhCôngCụToolStripMenuItem2,
            this.bảnĐồNềnGoogleToolStripMenuItem});
            this.côngCụToolStripMenuItem.Name = "côngCụToolStripMenuItem";
            this.côngCụToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.côngCụToolStripMenuItem.Text = "Công cụ";
            this.côngCụToolStripMenuItem.Visible = false;
            // 
            // thanhCôngCụToolStripMenuItem2
            // 
            this.thanhCôngCụToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.côngCụCơBảnToolStripMenuItem1,
            this.côngCụChỉnhSửaTrangInToolStripMenuItem1,
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem1,
            this.tùyChỉnhToolStripMenuItem,
            this.lưuThanhCôngCụToolStripMenuItem1});
            this.thanhCôngCụToolStripMenuItem2.Name = "thanhCôngCụToolStripMenuItem2";
            this.thanhCôngCụToolStripMenuItem2.Size = new System.Drawing.Size(199, 22);
            this.thanhCôngCụToolStripMenuItem2.Text = "Thanh công cụ";
            // 
            // côngCụCơBảnToolStripMenuItem1
            // 
            this.côngCụCơBảnToolStripMenuItem1.Checked = true;
            this.côngCụCơBảnToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.côngCụCơBảnToolStripMenuItem1.Name = "côngCụCơBảnToolStripMenuItem1";
            this.côngCụCơBảnToolStripMenuItem1.Size = new System.Drawing.Size(245, 22);
            this.côngCụCơBảnToolStripMenuItem1.Text = "Công cụ cơ bản";
            this.côngCụCơBảnToolStripMenuItem1.CheckedChanged += new System.EventHandler(this.thanhCôngCụCơbảnToolStripMenuItem_CheckedChanged);
            // 
            // côngCụChỉnhSửaTrangInToolStripMenuItem1
            // 
            this.côngCụChỉnhSửaTrangInToolStripMenuItem1.Checked = true;
            this.côngCụChỉnhSửaTrangInToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.côngCụChỉnhSửaTrangInToolStripMenuItem1.Name = "côngCụChỉnhSửaTrangInToolStripMenuItem1";
            this.côngCụChỉnhSửaTrangInToolStripMenuItem1.Size = new System.Drawing.Size(245, 22);
            this.côngCụChỉnhSửaTrangInToolStripMenuItem1.Text = "Công cụ chỉnh sửa trang in";
            this.côngCụChỉnhSửaTrangInToolStripMenuItem1.CheckedChanged += new System.EventHandler(this.côngCụTrangInToolStripMenuItem_CheckedChanged);
            // 
            // côngCụChỉnhSửaDữLiệuToolStripMenuItem1
            // 
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem1.Checked = true;
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem1.Name = "côngCụChỉnhSửaDữLiệuToolStripMenuItem1";
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem1.Size = new System.Drawing.Size(245, 22);
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem1.Text = "Công cụ chỉnh sửa dữ liệu";
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem1.CheckedChanged += new System.EventHandler(this.côngCụCậpNhậtDữLiệuToolStripMenuItem_CheckedChanged);
            // 
            // tùyChỉnhToolStripMenuItem
            // 
            this.tùyChỉnhToolStripMenuItem.Name = "tùyChỉnhToolStripMenuItem";
            this.tùyChỉnhToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.tùyChỉnhToolStripMenuItem.Text = "Tùy chỉnh";
            this.tùyChỉnhToolStripMenuItem.Click += new System.EventHandler(this.tùyChỉnhToolStripMenuItem_Click);
            // 
            // lưuThanhCôngCụToolStripMenuItem1
            // 
            this.lưuThanhCôngCụToolStripMenuItem1.Name = "lưuThanhCôngCụToolStripMenuItem1";
            this.lưuThanhCôngCụToolStripMenuItem1.Size = new System.Drawing.Size(245, 22);
            this.lưuThanhCôngCụToolStripMenuItem1.Text = "Lưu thanh công cụ";
            this.lưuThanhCôngCụToolStripMenuItem1.Click += new System.EventHandler(this.lưuToolToolStripMenuItem_Click);
            // 
            // bảnĐồNềnGoogleToolStripMenuItem
            // 
            this.bảnĐồNềnGoogleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ảnhVệTinhToolStripMenuItem});
            this.bảnĐồNềnGoogleToolStripMenuItem.Name = "bảnĐồNềnGoogleToolStripMenuItem";
            this.bảnĐồNềnGoogleToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.bảnĐồNềnGoogleToolStripMenuItem.Text = "Bản đồ nền Google";
            // 
            // ảnhVệTinhToolStripMenuItem
            // 
            this.ảnhVệTinhToolStripMenuItem.Name = "ảnhVệTinhToolStripMenuItem";
            this.ảnhVệTinhToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.ảnhVệTinhToolStripMenuItem.Text = "Ảnh vệ tinh";
            this.ảnhVệTinhToolStripMenuItem.Click += new System.EventHandler(this.ảnhVệTinhToolStripMenuItem_CheckedChanged);
            // 
            // kếtNốiCơSởDữLiệuToolStripMenuItem
            // 
            this.kếtNốiCơSởDữLiệuToolStripMenuItem.Name = "kếtNốiCơSởDữLiệuToolStripMenuItem";
            this.kếtNốiCơSởDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.kếtNốiCơSởDữLiệuToolStripMenuItem.Text = "Kết nối cơ sở dữ liệu";
            this.kếtNốiCơSởDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.kếtNốiCơSởDữLiệuToolStripMenuItem2_Click_1);
            // 
            // thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem
            // 
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Name = "thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem";
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Text = "Thiết lập kết nối cơ sở dữ liệu";
            this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem_Click);
            // 
            // saoLưuCơSởDữLiệuToolStripMenuItem
            // 
            this.saoLưuCơSởDữLiệuToolStripMenuItem.Name = "saoLưuCơSởDữLiệuToolStripMenuItem";
            this.saoLưuCơSởDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.saoLưuCơSởDữLiệuToolStripMenuItem.Text = "Sao lưu cơ sở dữ liệu";
            this.saoLưuCơSởDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.saoLưuCơSởDữLiệuToolStripMenuItem_Click);
            // 
            // phụcHồiCơSởDữLiệuToolStripMenuItem
            // 
            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Name = "phụcHồiCơSởDữLiệuToolStripMenuItem";
            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Text = "Phục hồi cơ sở dữ liệu";
            this.phụcHồiCơSởDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.phụcHồiCơSởDữLiệuToolStripMenuItem_Click);
            // 
            // thanhCôngCụToolStripMenuItem
            // 
            this.thanhCôngCụToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thanhCôngCụToolStripMenuItem1,
            this.côngCụCơBảnToolStripMenuItem2,
            this.côngCụChỉnhSửaTrangInToolStripMenuItem2,
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem2,
            this.tùyChỉnhToolStripMenuItem2,
            this.lưuThanhCôngCụToolStripMenuItem2});
            this.thanhCôngCụToolStripMenuItem.Name = "thanhCôngCụToolStripMenuItem";
            this.thanhCôngCụToolStripMenuItem.Size = new System.Drawing.Size(115, 21);
            this.thanhCôngCụToolStripMenuItem.Text = "Thanh công cụ";
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
            this.thanhCôngCụToolStripMenuItem1.Size = new System.Drawing.Size(245, 22);
            this.thanhCôngCụToolStripMenuItem1.Text = "Thanh công cụ";
            this.thanhCôngCụToolStripMenuItem1.Visible = false;
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
            // côngCụCơBảnToolStripMenuItem2
            // 
            this.côngCụCơBảnToolStripMenuItem2.Checked = true;
            this.côngCụCơBảnToolStripMenuItem2.CheckOnClick = true;
            this.côngCụCơBảnToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.côngCụCơBảnToolStripMenuItem2.Name = "côngCụCơBảnToolStripMenuItem2";
            this.côngCụCơBảnToolStripMenuItem2.Size = new System.Drawing.Size(245, 22);
            this.côngCụCơBảnToolStripMenuItem2.Text = "Công cụ cơ bản";
            this.côngCụCơBảnToolStripMenuItem2.CheckedChanged += new System.EventHandler(this.thanhCôngCụCơbảnToolStripMenuItem_CheckedChanged);
            // 
            // côngCụChỉnhSửaTrangInToolStripMenuItem2
            // 
            this.côngCụChỉnhSửaTrangInToolStripMenuItem2.Checked = true;
            this.côngCụChỉnhSửaTrangInToolStripMenuItem2.CheckOnClick = true;
            this.côngCụChỉnhSửaTrangInToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.côngCụChỉnhSửaTrangInToolStripMenuItem2.Name = "côngCụChỉnhSửaTrangInToolStripMenuItem2";
            this.côngCụChỉnhSửaTrangInToolStripMenuItem2.Size = new System.Drawing.Size(245, 22);
            this.côngCụChỉnhSửaTrangInToolStripMenuItem2.Text = "Công cụ chỉnh sửa trang in";
            this.côngCụChỉnhSửaTrangInToolStripMenuItem2.CheckedChanged += new System.EventHandler(this.côngCụTrangInToolStripMenuItem_CheckedChanged);
            // 
            // côngCụChỉnhSửaDữLiệuToolStripMenuItem2
            // 
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem2.Checked = true;
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem2.CheckOnClick = true;
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem2.Name = "côngCụChỉnhSửaDữLiệuToolStripMenuItem2";
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem2.Size = new System.Drawing.Size(245, 22);
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem2.Text = "Công cụ chỉnh sửa dữ liệu";
            this.côngCụChỉnhSửaDữLiệuToolStripMenuItem2.CheckedChanged += new System.EventHandler(this.côngCụCậpNhậtDữLiệuToolStripMenuItem_CheckedChanged);
            // 
            // tùyChỉnhToolStripMenuItem2
            // 
            this.tùyChỉnhToolStripMenuItem2.Name = "tùyChỉnhToolStripMenuItem2";
            this.tùyChỉnhToolStripMenuItem2.Size = new System.Drawing.Size(245, 22);
            this.tùyChỉnhToolStripMenuItem2.Text = "Tùy chỉnh";
            this.tùyChỉnhToolStripMenuItem2.Click += new System.EventHandler(this.tùyChỉnhToolStripMenuItem_Click);
            // 
            // lưuThanhCôngCụToolStripMenuItem2
            // 
            this.lưuThanhCôngCụToolStripMenuItem2.Name = "lưuThanhCôngCụToolStripMenuItem2";
            this.lưuThanhCôngCụToolStripMenuItem2.Size = new System.Drawing.Size(245, 22);
            this.lưuThanhCôngCụToolStripMenuItem2.Text = "Lưu thanh công cụ";
            this.lưuThanhCôngCụToolStripMenuItem2.Click += new System.EventHandler(this.lưuToolToolStripMenuItem_Click);
            // 
            // chuyểnĐổiDữLiệuToolStripMenuItem
            // 
            this.chuyểnĐổiDữLiệuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem1,
            this.cậpNhậtDữLiệuQuyHoạchToolStripMenuItem,
            this.cậpNhậtDữLiệuQuỹĐấtToolStripMenuItem,
            this.chuyểnĐổiHệTọaĐộToolStripMenuItem});
            this.chuyểnĐổiDữLiệuToolStripMenuItem.Name = "chuyểnĐổiDữLiệuToolStripMenuItem";
            this.chuyểnĐổiDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(117, 21);
            this.chuyểnĐổiDữLiệuToolStripMenuItem.Text = "Cập nhật CSDL";
            // 
            // cậpNhậtDữLiệuĐịaChínhToolStripMenuItem1
            // 
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kiểmTraFileDGNMớiToolStripMenuItem1,
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem,
            this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem1,
            this.cậpNhậtDữLiệuToolStripMenuItem});
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem1.Name = "cậpNhậtDữLiệuĐịaChínhToolStripMenuItem1";
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem1.Size = new System.Drawing.Size(249, 22);
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem1.Text = "Cập nhật dữ liệu địa chính";
            this.cậpNhậtDữLiệuĐịaChínhToolStripMenuItem1.Visible = false;
            // 
            // kiểmTraFileDGNMớiToolStripMenuItem1
            // 
            this.kiểmTraFileDGNMớiToolStripMenuItem1.Name = "kiểmTraFileDGNMớiToolStripMenuItem1";
            this.kiểmTraFileDGNMớiToolStripMenuItem1.Size = new System.Drawing.Size(343, 22);
            this.kiểmTraFileDGNMớiToolStripMenuItem1.Text = "Kiểm tra dữ liệu mới";
            this.kiểmTraFileDGNMớiToolStripMenuItem1.Click += new System.EventHandler(this.kiểmTraFileDGNMớiToolStripMenuItem1_Click);
            // 
            // chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem
            // 
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem.Name = "chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem";
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem.Text = "Chuyển đổi dữ liệu sang *.shp";
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem.Click += new System.EventHandler(this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem_Click);
            // 
            // chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem1
            // 
            this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem1.Name = "chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem1";
            this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem1.Size = new System.Drawing.Size(343, 22);
            this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem1.Text = "Chuyển đổi dữ liệu dạng đường sang vùng";
            this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem1.Click += new System.EventHandler(this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem1_Click);
            // 
            // cậpNhậtDữLiệuToolStripMenuItem
            // 
            this.cậpNhậtDữLiệuToolStripMenuItem.Name = "cậpNhậtDữLiệuToolStripMenuItem";
            this.cậpNhậtDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.cậpNhậtDữLiệuToolStripMenuItem.Text = "Cập nhật dữ liệu";
            this.cậpNhậtDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtDữLiệuToolStripMenuItem_Click_1);
            // 
            // cậpNhậtDữLiệuQuyHoạchToolStripMenuItem
            // 
            this.cậpNhậtDữLiệuQuyHoạchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem,
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem1,
            this.chuyểnĐổiDữLiệuĐườngSangVùngToolStripMenuItem,
            this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem2,
            this.toolStripMenuItem1,
            this.cậpNhậtDữLiệuToolStripMenuItem1,
            this.cậpNhậtBảnĐồGiấyToolStripMenuItem});
            this.cậpNhậtDữLiệuQuyHoạchToolStripMenuItem.Name = "cậpNhậtDữLiệuQuyHoạchToolStripMenuItem";
            this.cậpNhậtDữLiệuQuyHoạchToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.cậpNhậtDữLiệuQuyHoạchToolStripMenuItem.Text = "Cập nhật dữ liệu quy hoạch";
            // 
            // kiểmTraFiledgncadshpMớiToolStripMenuItem
            // 
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem.Name = "kiểmTraFiledgncadshpMớiToolStripMenuItem";
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem.Text = "Kiểm tra dữ liệu mới";
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem.Visible = false;
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem.Click += new System.EventHandler(this.kiểmTraFiledgncadshpMớiToolStripMenuItem_Click);
            // 
            // chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem1
            // 
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem1.Name = "chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem1";
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem1.Size = new System.Drawing.Size(343, 22);
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem1.Text = "Chuyển đổi dữ liệu sang *.shp";
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem1.Click += new System.EventHandler(this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem1_Click);
            // 
            // chuyểnĐổiDữLiệuĐườngSangVùngToolStripMenuItem
            // 
            this.chuyểnĐổiDữLiệuĐườngSangVùngToolStripMenuItem.Name = "chuyểnĐổiDữLiệuĐườngSangVùngToolStripMenuItem";
            this.chuyểnĐổiDữLiệuĐườngSangVùngToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.chuyểnĐổiDữLiệuĐườngSangVùngToolStripMenuItem.Text = "Chuyển đổi dữ liệu dạng đường sang vùng";
            this.chuyểnĐổiDữLiệuĐườngSangVùngToolStripMenuItem.Click += new System.EventHandler(this.chuyểnĐổiDữLiệuĐườngSangVùngToolStripMenuItem_Click);
            // 
            // cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem2
            // 
            this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem2.Name = "cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem2";
            this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem2.Size = new System.Drawing.Size(343, 22);
            this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem2.Text = "Cập nhật ranh giới quy hoạch";
            this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem2.Click += new System.EventHandler(this.cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(343, 22);
            this.toolStripMenuItem1.Text = "Cập nhật mặt bằng quy hoạch";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_2);
            // 
            // cậpNhậtDữLiệuToolStripMenuItem1
            // 
            this.cậpNhậtDữLiệuToolStripMenuItem1.Name = "cậpNhậtDữLiệuToolStripMenuItem1";
            this.cậpNhậtDữLiệuToolStripMenuItem1.Size = new System.Drawing.Size(343, 22);
            this.cậpNhậtDữLiệuToolStripMenuItem1.Text = "Cập nhật dữ liệu";
            this.cậpNhậtDữLiệuToolStripMenuItem1.Click += new System.EventHandler(this.cậpNhậtDữLiệuToolStripMenuItem1_Click);
            // 
            // cậpNhậtBảnĐồGiấyToolStripMenuItem
            // 
            this.cậpNhậtBảnĐồGiấyToolStripMenuItem.Name = "cậpNhậtBảnĐồGiấyToolStripMenuItem";
            this.cậpNhậtBảnĐồGiấyToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.cậpNhậtBảnĐồGiấyToolStripMenuItem.Text = "Cập nhật bản đồ giấy";
            this.cậpNhậtBảnĐồGiấyToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtBảnĐồGiấyToolStripMenuItem_Click);
            // 
            // cậpNhậtDữLiệuQuỹĐấtToolStripMenuItem
            // 
            this.cậpNhậtDữLiệuQuỹĐấtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem1,
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem2,
            this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem,
            this.chuyểnĐổiAnnotationSangShapfileToolStripMenuItem,
            this.chuẩnHóaDữLiệuQuỹĐấtToolStripMenuItem,
            this.cậpNhậtDựÁnQuyHoạchToolStripMenuItem1,
            this.cậpNhậtDữLiệuToolStripMenuItem4});
            this.cậpNhậtDữLiệuQuỹĐấtToolStripMenuItem.Name = "cậpNhậtDữLiệuQuỹĐấtToolStripMenuItem";
            this.cậpNhậtDữLiệuQuỹĐấtToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.cậpNhậtDữLiệuQuỹĐấtToolStripMenuItem.Text = "Cập nhật dữ liệu quỹ đất";
            this.cậpNhậtDữLiệuQuỹĐấtToolStripMenuItem.Visible = false;
            // 
            // kiểmTraFiledgncadshpMớiToolStripMenuItem1
            // 
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem1.Name = "kiểmTraFiledgncadshpMớiToolStripMenuItem1";
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem1.Size = new System.Drawing.Size(343, 22);
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem1.Text = "Kiểm tra file *.dgn, *.cad, *.shp  mới";
            this.kiểmTraFiledgncadshpMớiToolStripMenuItem1.Click += new System.EventHandler(this.kiểmTraFiledgncadshpMớiToolStripMenuItem1_Click);
            // 
            // chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem2
            // 
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem2.Name = "chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem2";
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem2.Size = new System.Drawing.Size(343, 22);
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem2.Text = "Chuyển đổi dữ liệu *.dgn, *.cad sang *.shp";
            this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem2.Click += new System.EventHandler(this.chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem2_Click);
            // 
            // chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem
            // 
            this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem.Name = "chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem";
            this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem.Text = "Chuyển đổi dữ liệu dạng đường sang vùng";
            this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem.Click += new System.EventHandler(this.chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem_Click);
            // 
            // chuyểnĐổiAnnotationSangShapfileToolStripMenuItem
            // 
            this.chuyểnĐổiAnnotationSangShapfileToolStripMenuItem.Name = "chuyểnĐổiAnnotationSangShapfileToolStripMenuItem";
            this.chuyểnĐổiAnnotationSangShapfileToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.chuyểnĐổiAnnotationSangShapfileToolStripMenuItem.Text = "Chuyển đổi Annotation sang Shapfile";
            this.chuyểnĐổiAnnotationSangShapfileToolStripMenuItem.Click += new System.EventHandler(this.chuyểnĐổiAnnotationSangShapfileToolStripMenuItem_Click);
            // 
            // chuẩnHóaDữLiệuQuỹĐấtToolStripMenuItem
            // 
            this.chuẩnHóaDữLiệuQuỹĐấtToolStripMenuItem.Name = "chuẩnHóaDữLiệuQuỹĐấtToolStripMenuItem";
            this.chuẩnHóaDữLiệuQuỹĐấtToolStripMenuItem.Size = new System.Drawing.Size(343, 22);
            this.chuẩnHóaDữLiệuQuỹĐấtToolStripMenuItem.Text = "Chuẩn hóa dữ liệu quỹ đất";
            this.chuẩnHóaDữLiệuQuỹĐấtToolStripMenuItem.Click += new System.EventHandler(this.chuẩnHóaDữLiệuQuỹĐấtToolStripMenuItem_Click);
            // 
            // cậpNhậtDựÁnQuyHoạchToolStripMenuItem1
            // 
            this.cậpNhậtDựÁnQuyHoạchToolStripMenuItem1.Name = "cậpNhậtDựÁnQuyHoạchToolStripMenuItem1";
            this.cậpNhậtDựÁnQuyHoạchToolStripMenuItem1.Size = new System.Drawing.Size(343, 22);
            this.cậpNhậtDựÁnQuyHoạchToolStripMenuItem1.Text = "Cập nhật dự án";
            this.cậpNhậtDựÁnQuyHoạchToolStripMenuItem1.Click += new System.EventHandler(this.cậpNhậtDựÁnQuyHoạchToolStripMenuItem1_Click);
            // 
            // cậpNhậtDữLiệuToolStripMenuItem4
            // 
            this.cậpNhậtDữLiệuToolStripMenuItem4.Name = "cậpNhậtDữLiệuToolStripMenuItem4";
            this.cậpNhậtDữLiệuToolStripMenuItem4.Size = new System.Drawing.Size(343, 22);
            this.cậpNhậtDữLiệuToolStripMenuItem4.Text = "Cập nhật dữ liệu";
            this.cậpNhậtDữLiệuToolStripMenuItem4.Click += new System.EventHandler(this.cậpNhậtDữLiệuToolStripMenuItem4_Click);
            // 
            // chuyểnĐổiHệTọaĐộToolStripMenuItem
            // 
            this.chuyểnĐổiHệTọaĐộToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chuyểnĐổiTừHN72VN2000ToolStripMenuItem,
            this.chuyểnĐổiTừVN2000WGS84ToolStripMenuItem,
            this.chuyểnĐổiTừWGS84VN2000ToolStripMenuItem});
            this.chuyểnĐổiHệTọaĐộToolStripMenuItem.Name = "chuyểnĐổiHệTọaĐộToolStripMenuItem";
            this.chuyểnĐổiHệTọaĐộToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.chuyểnĐổiHệTọaĐộToolStripMenuItem.Text = "Chuyển đổi hệ tọa độ";
            // 
            // chuyểnĐổiTừHN72VN2000ToolStripMenuItem
            // 
            this.chuyểnĐổiTừHN72VN2000ToolStripMenuItem.Name = "chuyểnĐổiTừHN72VN2000ToolStripMenuItem";
            this.chuyểnĐổiTừHN72VN2000ToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.chuyểnĐổiTừHN72VN2000ToolStripMenuItem.Text = "Chuyển đổi từ HN72 - VN2000 ";
            this.chuyểnĐổiTừHN72VN2000ToolStripMenuItem.Click += new System.EventHandler(this.chuyểnĐổiHệTọaĐộToolStripMenuItem_Click);
            // 
            // chuyểnĐổiTừVN2000WGS84ToolStripMenuItem
            // 
            this.chuyểnĐổiTừVN2000WGS84ToolStripMenuItem.Name = "chuyểnĐổiTừVN2000WGS84ToolStripMenuItem";
            this.chuyểnĐổiTừVN2000WGS84ToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.chuyểnĐổiTừVN2000WGS84ToolStripMenuItem.Text = "Chuyển đổi từ VN2000 - WGS84";
            this.chuyểnĐổiTừVN2000WGS84ToolStripMenuItem.Click += new System.EventHandler(this.chuyểnĐổiTừVN2000WGS84ToolStripMenuItem_Click);
            // 
            // chuyểnĐổiTừWGS84VN2000ToolStripMenuItem
            // 
            this.chuyểnĐổiTừWGS84VN2000ToolStripMenuItem.Name = "chuyểnĐổiTừWGS84VN2000ToolStripMenuItem";
            this.chuyểnĐổiTừWGS84VN2000ToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.chuyểnĐổiTừWGS84VN2000ToolStripMenuItem.Text = "Chuyển đổi từ WGS84 - VN2000";
            this.chuyểnĐổiTừWGS84VN2000ToolStripMenuItem.Click += new System.EventHandler(this.chuyểnĐổiTừWGS84VN2000ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(12, 21);
            // 
            // quảnLýQuyHoạchKiếnTrúcToolStripMenuItem
            // 
            this.quảnLýQuyHoạchKiếnTrúcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýThôngTinQuyHoạchToolStripMenuItem,
            this.quảnLýThôngTinKiếnTrúcXâyDựngToolStripMenuItem,
            this.quảnLýHồSơXácNhậnQuyHoạchToolStripMenuItem,
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem2});
            this.quảnLýQuyHoạchKiếnTrúcToolStripMenuItem.Name = "quảnLýQuyHoạchKiếnTrúcToolStripMenuItem";
            this.quảnLýQuyHoạchKiếnTrúcToolStripMenuItem.Size = new System.Drawing.Size(211, 21);
            this.quảnLýQuyHoạchKiếnTrúcToolStripMenuItem.Text = "Quản lý Quy hoạch - Kiến trúc";
            // 
            // quảnLýThôngTinQuyHoạchToolStripMenuItem
            // 
            this.quảnLýThôngTinQuyHoạchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýThôngTinQuyHoạchChiTiết1500ToolStripMenuItem,
            this.quảnLýThôngTinQuyHoạchPhânKhuToolStripMenuItem,
            this.quảnLýThôngTinQuyHoạchChungToolStripMenuItem});
            this.quảnLýThôngTinQuyHoạchToolStripMenuItem.Name = "quảnLýThôngTinQuyHoạchToolStripMenuItem";
            this.quảnLýThôngTinQuyHoạchToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.quảnLýThôngTinQuyHoạchToolStripMenuItem.Text = "Quản lý thông tin Quy hoạch";
            // 
            // quảnLýThôngTinQuyHoạchChiTiết1500ToolStripMenuItem
            // 
            this.quảnLýThôngTinQuyHoạchChiTiết1500ToolStripMenuItem.Name = "quảnLýThôngTinQuyHoạchChiTiết1500ToolStripMenuItem";
            this.quảnLýThôngTinQuyHoạchChiTiết1500ToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.quảnLýThôngTinQuyHoạchChiTiết1500ToolStripMenuItem.Text = "Quản lý thông tin Quy hoạch chi tiết 1/500";
            this.quảnLýThôngTinQuyHoạchChiTiết1500ToolStripMenuItem.Click += new System.EventHandler(this.quảnLýQuyHoạchToolStripMenuItem_Click);
            // 
            // quảnLýThôngTinQuyHoạchPhânKhuToolStripMenuItem
            // 
            this.quảnLýThôngTinQuyHoạchPhânKhuToolStripMenuItem.Name = "quảnLýThôngTinQuyHoạchPhânKhuToolStripMenuItem";
            this.quảnLýThôngTinQuyHoạchPhânKhuToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.quảnLýThôngTinQuyHoạchPhânKhuToolStripMenuItem.Text = "Quản lý thông tin Quy hoạch phân khu";
            this.quảnLýThôngTinQuyHoạchPhânKhuToolStripMenuItem.Click += new System.EventHandler(this.quảnLýThôngTinQuyHoạchPhânKhuToolStripMenuItem_Click);
            // 
            // quảnLýThôngTinQuyHoạchChungToolStripMenuItem
            // 
            this.quảnLýThôngTinQuyHoạchChungToolStripMenuItem.Name = "quảnLýThôngTinQuyHoạchChungToolStripMenuItem";
            this.quảnLýThôngTinQuyHoạchChungToolStripMenuItem.Size = new System.Drawing.Size(342, 22);
            this.quảnLýThôngTinQuyHoạchChungToolStripMenuItem.Text = "Quản lý thông tin Quy hoạch chung";
            this.quảnLýThôngTinQuyHoạchChungToolStripMenuItem.Click += new System.EventHandler(this.quảnLýThôngTinQuyHoạchChungToolStripMenuItem_Click);
            // 
            // quảnLýThôngTinKiếnTrúcXâyDựngToolStripMenuItem
            // 
            this.quảnLýThôngTinKiếnTrúcXâyDựngToolStripMenuItem.Name = "quảnLýThôngTinKiếnTrúcXâyDựngToolStripMenuItem";
            this.quảnLýThôngTinKiếnTrúcXâyDựngToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.quảnLýThôngTinKiếnTrúcXâyDựngToolStripMenuItem.Text = "Quản lý thông tin Kiến trúc - Xây dựng";
            this.quảnLýThôngTinKiếnTrúcXâyDựngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKiếnTrúcXâyDựngToolStripMenuItem_Click);
            // 
            // quảnLýHồSơXácNhậnQuyHoạchToolStripMenuItem
            // 
            this.quảnLýHồSơXácNhậnQuyHoạchToolStripMenuItem.Name = "quảnLýHồSơXácNhậnQuyHoạchToolStripMenuItem";
            this.quảnLýHồSơXácNhậnQuyHoạchToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.quảnLýHồSơXácNhậnQuyHoạchToolStripMenuItem.Text = "Quản lý hồ sơ xác nhận quy hoạch";
            this.quảnLýHồSơXácNhậnQuyHoạchToolStripMenuItem.Visible = false;
            this.quảnLýHồSơXácNhậnQuyHoạchToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem_Click);
            // 
            // quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem2
            // 
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem2.Name = "quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem2";
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem2.Size = new System.Drawing.Size(317, 22);
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem2.Text = "Quản lý hồ sơ cấp phép xây dựng";
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem2.Visible = false;
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem2.Click += new System.EventHandler(this.cấpPhépXâyDựngNhaORiengLe_Click);
            // 
            // quảnLýCơSởHTKTToolStripMenuItem
            // 
            this.quảnLýCơSởHTKTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.giaoThôngToolStripMenuItem,
            this.điệnChiếuSángToolStripMenuItem,
            this.câyXToolStripMenuItem,
            this.bưuChínhViễnThôngToolStripMenuItem1,
            this.mươngThoátNướcToolStripMenuItem});
            this.quảnLýCơSởHTKTToolStripMenuItem.Name = "quảnLýCơSởHTKTToolStripMenuItem";
            this.quảnLýCơSởHTKTToolStripMenuItem.Size = new System.Drawing.Size(150, 21);
            this.quảnLýCơSởHTKTToolStripMenuItem.Text = "Quản lý Cơ sở HTKT";
            this.quảnLýCơSởHTKTToolStripMenuItem.Visible = false;
            // 
            // giaoThôngToolStripMenuItem
            // 
            this.giaoThôngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đườngGiaoThôngChínhToolStripMenuItem1,
            this.đườngKiệtHẻmToolStripMenuItem1,
            this.biểnBáoToolStripMenuItem,
            this.cầuĐườngBộToolStripMenuItem,
            this.vỉaHèToolStripMenuItem});
            this.giaoThôngToolStripMenuItem.Name = "giaoThôngToolStripMenuItem";
            this.giaoThôngToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.giaoThôngToolStripMenuItem.Text = "Giao thông";
            // 
            // đườngGiaoThôngChínhToolStripMenuItem1
            // 
            this.đườngGiaoThôngChínhToolStripMenuItem1.Name = "đườngGiaoThôngChínhToolStripMenuItem1";
            this.đườngGiaoThôngChínhToolStripMenuItem1.Size = new System.Drawing.Size(227, 22);
            this.đườngGiaoThôngChínhToolStripMenuItem1.Text = "Đường giao thông chính";
            this.đườngGiaoThôngChínhToolStripMenuItem1.Click += new System.EventHandler(this.đườngGiaoThôngChínhToolStripMenuItem_Click_1);
            // 
            // đườngKiệtHẻmToolStripMenuItem1
            // 
            this.đườngKiệtHẻmToolStripMenuItem1.Name = "đườngKiệtHẻmToolStripMenuItem1";
            this.đườngKiệtHẻmToolStripMenuItem1.Size = new System.Drawing.Size(227, 22);
            this.đườngKiệtHẻmToolStripMenuItem1.Text = "Đường kiệt hẻm";
            this.đườngKiệtHẻmToolStripMenuItem1.Click += new System.EventHandler(this.đườngKiệtHẻmToolStripMenuItem_Click);
            // 
            // biểnBáoToolStripMenuItem
            // 
            this.biểnBáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýBiểnBáoToolStripMenuItem,
            this.quảnLýLoạiBiểnBáoToolStripMenuItem});
            this.biểnBáoToolStripMenuItem.Name = "biểnBáoToolStripMenuItem";
            this.biểnBáoToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.biểnBáoToolStripMenuItem.Text = "Biển báo";
            // 
            // quảnLýBiểnBáoToolStripMenuItem
            // 
            this.quảnLýBiểnBáoToolStripMenuItem.Name = "quảnLýBiểnBáoToolStripMenuItem";
            this.quảnLýBiểnBáoToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.quảnLýBiểnBáoToolStripMenuItem.Text = "Quản lý Biển báo";
            this.quảnLýBiểnBáoToolStripMenuItem.Click += new System.EventHandler(this.biểnBáoToolStripMenuItem_Click);
            // 
            // quảnLýLoạiBiểnBáoToolStripMenuItem
            // 
            this.quảnLýLoạiBiểnBáoToolStripMenuItem.Name = "quảnLýLoạiBiểnBáoToolStripMenuItem";
            this.quảnLýLoạiBiểnBáoToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.quảnLýLoạiBiểnBáoToolStripMenuItem.Text = "Quản lý Loại biển báo";
            this.quảnLýLoạiBiểnBáoToolStripMenuItem.Click += new System.EventHandler(this.quảnLýLoạiBiểnBáoToolStripMenuItem_Click);
            // 
            // cầuĐườngBộToolStripMenuItem
            // 
            this.cầuĐườngBộToolStripMenuItem.Name = "cầuĐườngBộToolStripMenuItem";
            this.cầuĐườngBộToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.cầuĐườngBộToolStripMenuItem.Text = "Cầu đường bộ";
            this.cầuĐườngBộToolStripMenuItem.Click += new System.EventHandler(this.cầuĐườngBộToolStripMenuItem_Click);
            // 
            // vỉaHèToolStripMenuItem
            // 
            this.vỉaHèToolStripMenuItem.Name = "vỉaHèToolStripMenuItem";
            this.vỉaHèToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.vỉaHèToolStripMenuItem.Text = "Vỉa hè";
            this.vỉaHèToolStripMenuItem.Click += new System.EventHandler(this.vỉaHèToolStripMenuItem_Click);
            // 
            // điệnChiếuSángToolStripMenuItem
            // 
            this.điệnChiếuSángToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.điệnChiếuSángChínhToolStripMenuItem,
            this.điệnChiếuSángKiệtHẻmToolStripMenuItem});
            this.điệnChiếuSángToolStripMenuItem.Name = "điệnChiếuSángToolStripMenuItem";
            this.điệnChiếuSángToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.điệnChiếuSángToolStripMenuItem.Text = "Điện chiếu sáng";
            // 
            // điệnChiếuSángChínhToolStripMenuItem
            // 
            this.điệnChiếuSángChínhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tuyếnDâyĐiệnChínhToolStripMenuItem1,
            this.trụĐiệnChiếuSángChínhToolStripMenuItem1});
            this.điệnChiếuSángChínhToolStripMenuItem.Name = "điệnChiếuSángChínhToolStripMenuItem";
            this.điệnChiếuSángChínhToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.điệnChiếuSángChínhToolStripMenuItem.Text = "Điện chiếu sáng chính";
            // 
            // tuyếnDâyĐiệnChínhToolStripMenuItem1
            // 
            this.tuyếnDâyĐiệnChínhToolStripMenuItem1.Name = "tuyếnDâyĐiệnChínhToolStripMenuItem1";
            this.tuyếnDâyĐiệnChínhToolStripMenuItem1.Size = new System.Drawing.Size(240, 22);
            this.tuyếnDâyĐiệnChínhToolStripMenuItem1.Text = "Tuyến dây điện chính";
            this.tuyếnDâyĐiệnChínhToolStripMenuItem1.Click += new System.EventHandler(this.tuyếnDâyĐiệnChínhToolStripMenuItem1_Click);
            // 
            // trụĐiệnChiếuSángChínhToolStripMenuItem1
            // 
            this.trụĐiệnChiếuSángChínhToolStripMenuItem1.Name = "trụĐiệnChiếuSángChínhToolStripMenuItem1";
            this.trụĐiệnChiếuSángChínhToolStripMenuItem1.Size = new System.Drawing.Size(240, 22);
            this.trụĐiệnChiếuSángChínhToolStripMenuItem1.Text = "Trụ điện chiếu sáng chính";
            this.trụĐiệnChiếuSángChínhToolStripMenuItem1.Click += new System.EventHandler(this.trụĐiệnChiếuSángChínhToolStripMenuItem1_Click);
            // 
            // điệnChiếuSángKiệtHẻmToolStripMenuItem
            // 
            this.điệnChiếuSángKiệtHẻmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tuyếnDâyĐiệnKiệtHẻmToolStripMenuItem,
            this.trụĐiệnChiếuSángKiệtHẻmToolStripMenuItem});
            this.điệnChiếuSángKiệtHẻmToolStripMenuItem.Name = "điệnChiếuSángKiệtHẻmToolStripMenuItem";
            this.điệnChiếuSángKiệtHẻmToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.điệnChiếuSángKiệtHẻmToolStripMenuItem.Text = "Điện chiếu sáng kiệt hẻm";
            // 
            // tuyếnDâyĐiệnKiệtHẻmToolStripMenuItem
            // 
            this.tuyếnDâyĐiệnKiệtHẻmToolStripMenuItem.Name = "tuyếnDâyĐiệnKiệtHẻmToolStripMenuItem";
            this.tuyếnDâyĐiệnKiệtHẻmToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.tuyếnDâyĐiệnKiệtHẻmToolStripMenuItem.Text = "Tuyến dây điện kiệt hẻm";
            this.tuyếnDâyĐiệnKiệtHẻmToolStripMenuItem.Click += new System.EventHandler(this.tuyếnDâyĐiệnToolStripMenuItem_Click);
            // 
            // trụĐiệnChiếuSángKiệtHẻmToolStripMenuItem
            // 
            this.trụĐiệnChiếuSángKiệtHẻmToolStripMenuItem.Name = "trụĐiệnChiếuSángKiệtHẻmToolStripMenuItem";
            this.trụĐiệnChiếuSángKiệtHẻmToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.trụĐiệnChiếuSángKiệtHẻmToolStripMenuItem.Text = "Trụ điện chiếu sáng kiệt hẻm";
            this.trụĐiệnChiếuSángKiệtHẻmToolStripMenuItem.Click += new System.EventHandler(this.trụĐiệnChiếuSángToolStripMenuItem_Click);
            // 
            // câyXToolStripMenuItem
            // 
            this.câyXToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýCâyXanhToolStripMenuItem,
            this.toolStripSeparator3,
            this.quảnLýĐơnVịChămSócToolStripMenuItem1,
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem1,
            this.quảnLýCôngViênToolStripMenuItem1,
            this.quảnLýLoạiChămSócToolStripMenuItem1,
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem1,
            this.thêmUrlFileĐínhKèmToolStripMenuItem,
            this.cậpNhậtTọaĐộCâyXanhToolStripMenuItem});
            this.câyXToolStripMenuItem.Name = "câyXToolStripMenuItem";
            this.câyXToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.câyXToolStripMenuItem.Text = "Cây xanh";
            // 
            // quảnLýCâyXanhToolStripMenuItem
            // 
            this.quảnLýCâyXanhToolStripMenuItem.Name = "quảnLýCâyXanhToolStripMenuItem";
            this.quảnLýCâyXanhToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.quảnLýCâyXanhToolStripMenuItem.Text = "Quản lý cây xanh";
            this.quảnLýCâyXanhToolStripMenuItem.Click += new System.EventHandler(this.quảnLýCâyXanhBóngMátToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(274, 6);
            // 
            // quảnLýĐơnVịChămSócToolStripMenuItem1
            // 
            this.quảnLýĐơnVịChămSócToolStripMenuItem1.Name = "quảnLýĐơnVịChămSócToolStripMenuItem1";
            this.quảnLýĐơnVịChămSócToolStripMenuItem1.Size = new System.Drawing.Size(277, 22);
            this.quảnLýĐơnVịChămSócToolStripMenuItem1.Text = "Quản lý đơn vị chăm sóc";
            this.quảnLýĐơnVịChămSócToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýĐơnVịChămSócToolStripMenuItem_Click);
            // 
            // quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem1
            // 
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem1.Name = "quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem1";
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem1.Size = new System.Drawing.Size(277, 22);
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem1.Text = "Quản lý đơn vị quản lý cây xanh";
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem_Click);
            // 
            // quảnLýCôngViênToolStripMenuItem1
            // 
            this.quảnLýCôngViênToolStripMenuItem1.Name = "quảnLýCôngViênToolStripMenuItem1";
            this.quảnLýCôngViênToolStripMenuItem1.Size = new System.Drawing.Size(277, 22);
            this.quảnLýCôngViênToolStripMenuItem1.Text = "Quản lý công viên";
            this.quảnLýCôngViênToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýCôngViênToolStripMenuItem_Click);
            // 
            // quảnLýLoạiChămSócToolStripMenuItem1
            // 
            this.quảnLýLoạiChămSócToolStripMenuItem1.Name = "quảnLýLoạiChămSócToolStripMenuItem1";
            this.quảnLýLoạiChămSócToolStripMenuItem1.Size = new System.Drawing.Size(277, 22);
            this.quảnLýLoạiChămSócToolStripMenuItem1.Text = "Quản lý loại chăm sóc";
            this.quảnLýLoạiChămSócToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýLoạiChămSócToolStripMenuItem_Click);
            // 
            // quảnLýChủngLoạiCâyXanhToolStripMenuItem1
            // 
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem1.Name = "quảnLýChủngLoạiCâyXanhToolStripMenuItem1";
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem1.Size = new System.Drawing.Size(277, 22);
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem1.Text = "Quản lý chủng loại cây xanh";
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýChủngLoạiCâyXanhToolStripMenuItem_Click);
            // 
            // thêmUrlFileĐínhKèmToolStripMenuItem
            // 
            this.thêmUrlFileĐínhKèmToolStripMenuItem.Name = "thêmUrlFileĐínhKèmToolStripMenuItem";
            this.thêmUrlFileĐínhKèmToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.thêmUrlFileĐínhKèmToolStripMenuItem.Text = "Thêm Url File đính kèm";
            this.thêmUrlFileĐínhKèmToolStripMenuItem.Click += new System.EventHandler(this.thêmUrlFileĐínhKèmToolStripMenuItem_Click);
            // 
            // cậpNhậtTọaĐộCâyXanhToolStripMenuItem
            // 
            this.cậpNhậtTọaĐộCâyXanhToolStripMenuItem.Name = "cậpNhậtTọaĐộCâyXanhToolStripMenuItem";
            this.cậpNhậtTọaĐộCâyXanhToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.cậpNhậtTọaĐộCâyXanhToolStripMenuItem.Text = "Cập nhật tọa độ Cây xanh";
            this.cậpNhậtTọaĐộCâyXanhToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtTọaĐộCâyXanhToolStripMenuItem_Click);
            // 
            // bưuChínhViễnThôngToolStripMenuItem1
            // 
            this.bưuChínhViễnThôngToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trạmBTSToolStripMenuItem1,
            this.đạiLýInternetToolStripMenuItem1});
            this.bưuChínhViễnThôngToolStripMenuItem1.Name = "bưuChínhViễnThôngToolStripMenuItem1";
            this.bưuChínhViễnThôngToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
            this.bưuChínhViễnThôngToolStripMenuItem1.Text = "Bưu chính viễn thông";
            // 
            // trạmBTSToolStripMenuItem1
            // 
            this.trạmBTSToolStripMenuItem1.Name = "trạmBTSToolStripMenuItem1";
            this.trạmBTSToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.trạmBTSToolStripMenuItem1.Text = "Trạm BTS";
            this.trạmBTSToolStripMenuItem1.Click += new System.EventHandler(this.qảunLýTrạmToolStripMenuItem_Click);
            // 
            // đạiLýInternetToolStripMenuItem1
            // 
            this.đạiLýInternetToolStripMenuItem1.Name = "đạiLýInternetToolStripMenuItem1";
            this.đạiLýInternetToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.đạiLýInternetToolStripMenuItem1.Text = "Đại lý Internet";
            this.đạiLýInternetToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýĐạiLýToolStripMenuItem_Click);
            // 
            // mươngThoátNướcToolStripMenuItem
            // 
            this.mươngThoátNướcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mươngThoátNướcChinhToolStripMenuItem,
            this.mươngThoátNướcKiệtHẻmToolStripMenuItem,
            this.hốGaToolStripMenuItem,
            this.hốGaChínhKiệtHẻmToolStripMenuItem});
            this.mươngThoátNướcToolStripMenuItem.Name = "mươngThoátNướcToolStripMenuItem";
            this.mươngThoátNướcToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.mươngThoátNướcToolStripMenuItem.Text = "Mương thoát nước";
            this.mươngThoátNướcToolStripMenuItem.Click += new System.EventHandler(this.đườngMươngThoátNướcToolStripMenuItem_Click);
            // 
            // mươngThoátNướcChinhToolStripMenuItem
            // 
            this.mươngThoátNướcChinhToolStripMenuItem.Name = "mươngThoátNướcChinhToolStripMenuItem";
            this.mươngThoátNướcChinhToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.mươngThoátNướcChinhToolStripMenuItem.Text = "Mương thoát nước chính";
            this.mươngThoátNướcChinhToolStripMenuItem.Click += new System.EventHandler(this.mươngThoátNướcChinhToolStripMenuItem_Click);
            // 
            // mươngThoátNướcKiệtHẻmToolStripMenuItem
            // 
            this.mươngThoátNướcKiệtHẻmToolStripMenuItem.Name = "mươngThoátNướcKiệtHẻmToolStripMenuItem";
            this.mươngThoátNướcKiệtHẻmToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.mươngThoátNướcKiệtHẻmToolStripMenuItem.Text = "Mương thoát nước kiệt hẻm";
            this.mươngThoátNướcKiệtHẻmToolStripMenuItem.Click += new System.EventHandler(this.mươngThoátNướcKiệtHẻmToolStripMenuItem_Click);
            // 
            // hốGaToolStripMenuItem
            // 
            this.hốGaToolStripMenuItem.Name = "hốGaToolStripMenuItem";
            this.hốGaToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.hốGaToolStripMenuItem.Text = "Hố ga chính";
            this.hốGaToolStripMenuItem.Click += new System.EventHandler(this.hốGaToolStripMenuItem_Click);
            // 
            // hốGaChínhKiệtHẻmToolStripMenuItem
            // 
            this.hốGaChínhKiệtHẻmToolStripMenuItem.Name = "hốGaChínhKiệtHẻmToolStripMenuItem";
            this.hốGaChínhKiệtHẻmToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.hốGaChínhKiệtHẻmToolStripMenuItem.Text = "Hố ga chính kiệt hẻm";
            this.hốGaChínhKiệtHẻmToolStripMenuItem.Click += new System.EventHandler(this.hốGaChínhKiệtHẻmToolStripMenuItem_Click);
            // 
            // quảnLýTàiNguyênToolStripMenuItem
            // 
            this.quảnLýTàiNguyênToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýTàiNguyênNướcToolStripMenuItem,
            this.quảnLýTàiNguyênĐấtToolStripMenuItem,
            this.quảnLýTàiNguyênKhoángSảnToolStripMenuItem});
            this.quảnLýTàiNguyênToolStripMenuItem.Name = "quảnLýTàiNguyênToolStripMenuItem";
            this.quảnLýTàiNguyênToolStripMenuItem.Size = new System.Drawing.Size(139, 21);
            this.quảnLýTàiNguyênToolStripMenuItem.Text = "Quản lý tài nguyên";
            this.quảnLýTàiNguyênToolStripMenuItem.Visible = false;
            // 
            // quảnLýTàiNguyênNướcToolStripMenuItem
            // 
            this.quảnLýTàiNguyênNướcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýHồChứaToolStripMenuItem,
            this.quảnLýTrạmBơmToolStripMenuItem,
            this.quảnLýĐậpDângToolStripMenuItem,
            this.quảngLýLoạiKênhToolStripMenuItem,
            this.quảnLýCấpPhépKhaiThácToolStripMenuItem,
            this.quảnLýCấpPhépKhaiThácNướcNgầmToolStripMenuItem,
            this.quảnLýCấpPhépXảThảiToolStripMenuItem});
            this.quảnLýTàiNguyênNướcToolStripMenuItem.Name = "quảnLýTàiNguyênNướcToolStripMenuItem";
            this.quảnLýTàiNguyênNướcToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.quảnLýTàiNguyênNướcToolStripMenuItem.Text = "Quản lý tài nguyên nước";
            // 
            // quảnLýHồChứaToolStripMenuItem
            // 
            this.quảnLýHồChứaToolStripMenuItem.Name = "quảnLýHồChứaToolStripMenuItem";
            this.quảnLýHồChứaToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.quảnLýHồChứaToolStripMenuItem.Text = "Quản lý Hồ chứa";
            this.quảnLýHồChứaToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHồChứaToolStripMenuItem_Click);
            // 
            // quảnLýTrạmBơmToolStripMenuItem
            // 
            this.quảnLýTrạmBơmToolStripMenuItem.Name = "quảnLýTrạmBơmToolStripMenuItem";
            this.quảnLýTrạmBơmToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.quảnLýTrạmBơmToolStripMenuItem.Text = "Quản lý Trạm bơm";
            this.quảnLýTrạmBơmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýTrạmBơmToolStripMenuItem_Click);
            // 
            // quảnLýĐậpDângToolStripMenuItem
            // 
            this.quảnLýĐậpDângToolStripMenuItem.Name = "quảnLýĐậpDângToolStripMenuItem";
            this.quảnLýĐậpDângToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.quảnLýĐậpDângToolStripMenuItem.Text = "Quản lý Đập dâng";
            this.quảnLýĐậpDângToolStripMenuItem.Click += new System.EventHandler(this.quảnLýĐậpDângToolStripMenuItem_Click);
            // 
            // quảngLýLoạiKênhToolStripMenuItem
            // 
            this.quảngLýLoạiKênhToolStripMenuItem.Name = "quảngLýLoạiKênhToolStripMenuItem";
            this.quảngLýLoạiKênhToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.quảngLýLoạiKênhToolStripMenuItem.Text = "Quảng lý Loại kênh";
            this.quảngLýLoạiKênhToolStripMenuItem.Click += new System.EventHandler(this.quảngLýLoạiKênhToolStripMenuItem_Click);
            // 
            // quảnLýCấpPhépKhaiThácToolStripMenuItem
            // 
            this.quảnLýCấpPhépKhaiThácToolStripMenuItem.Name = "quảnLýCấpPhépKhaiThácToolStripMenuItem";
            this.quảnLýCấpPhépKhaiThácToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.quảnLýCấpPhépKhaiThácToolStripMenuItem.Text = "Quản lý Cấp phép khai thác nước mặt";
            this.quảnLýCấpPhépKhaiThácToolStripMenuItem.Click += new System.EventHandler(this.quảnLýCấpPhépKhaiThácToolStripMenuItem_Click);
            // 
            // quảnLýCấpPhépKhaiThácNướcNgầmToolStripMenuItem
            // 
            this.quảnLýCấpPhépKhaiThácNướcNgầmToolStripMenuItem.Name = "quảnLýCấpPhépKhaiThácNướcNgầmToolStripMenuItem";
            this.quảnLýCấpPhépKhaiThácNướcNgầmToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.quảnLýCấpPhépKhaiThácNướcNgầmToolStripMenuItem.Text = "Quản lý Cấp phép khai thác nước ngầm";
            this.quảnLýCấpPhépKhaiThácNướcNgầmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýCấpPhépKhaiThácNướcNgầmToolStripMenuItem_Click);
            // 
            // quảnLýCấpPhépXảThảiToolStripMenuItem
            // 
            this.quảnLýCấpPhépXảThảiToolStripMenuItem.Name = "quảnLýCấpPhépXảThảiToolStripMenuItem";
            this.quảnLýCấpPhépXảThảiToolStripMenuItem.Size = new System.Drawing.Size(325, 22);
            this.quảnLýCấpPhépXảThảiToolStripMenuItem.Text = "Quản lý Cấp phép xả thải";
            this.quảnLýCấpPhépXảThảiToolStripMenuItem.Click += new System.EventHandler(this.quảnLýCấpPhépXảThảiToolStripMenuItem_Click);
            // 
            // quảnLýTàiNguyênĐấtToolStripMenuItem
            // 
            this.quảnLýTàiNguyênĐấtToolStripMenuItem.Name = "quảnLýTàiNguyênĐấtToolStripMenuItem";
            this.quảnLýTàiNguyênĐấtToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.quảnLýTàiNguyênĐấtToolStripMenuItem.Text = "Quản lý tài nguyên đất";
            this.quảnLýTàiNguyênĐấtToolStripMenuItem.Click += new System.EventHandler(this.quảnLýTàiNguyênĐấtToolStripMenuItem_Click);
            // 
            // quảnLýTàiNguyênKhoángSảnToolStripMenuItem
            // 
            this.quảnLýTàiNguyênKhoángSảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýQuyHoạchKhoángSảnToolStripMenuItem,
            this.quảnLýQuyHoạchVùngCấmTạmCấmToolStripMenuItem,
            this.quảnLýHoạtĐộngKhaiThácToolStripMenuItem,
            this.quảnLýHồSơToolStripMenuItem});
            this.quảnLýTàiNguyênKhoángSảnToolStripMenuItem.Name = "quảnLýTàiNguyênKhoángSảnToolStripMenuItem";
            this.quảnLýTàiNguyênKhoángSảnToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.quảnLýTàiNguyênKhoángSảnToolStripMenuItem.Text = "Quản lý tài nguyên Khoáng sản";
            // 
            // quảnLýQuyHoạchKhoángSảnToolStripMenuItem
            // 
            this.quảnLýQuyHoạchKhoángSảnToolStripMenuItem.Name = "quảnLýQuyHoạchKhoángSảnToolStripMenuItem";
            this.quảnLýQuyHoạchKhoángSảnToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.quảnLýQuyHoạchKhoángSảnToolStripMenuItem.Text = "Quản lý quy hoạch khoáng sản";
            this.quảnLýQuyHoạchKhoángSảnToolStripMenuItem.Click += new System.EventHandler(this.quảnLýQuyHoạchKhoángSảnToolStripMenuItem_Click);
            // 
            // quảnLýQuyHoạchVùngCấmTạmCấmToolStripMenuItem
            // 
            this.quảnLýQuyHoạchVùngCấmTạmCấmToolStripMenuItem.Name = "quảnLýQuyHoạchVùngCấmTạmCấmToolStripMenuItem";
            this.quảnLýQuyHoạchVùngCấmTạmCấmToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.quảnLýQuyHoạchVùngCấmTạmCấmToolStripMenuItem.Text = "Quản lý quy hoạch vùng cấm, tạm cấm";
            this.quảnLýQuyHoạchVùngCấmTạmCấmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýQuyHoạchVùngCấmTạmCấmToolStripMenuItem_Click);
            // 
            // quảnLýHoạtĐộngKhaiThácToolStripMenuItem
            // 
            this.quảnLýHoạtĐộngKhaiThácToolStripMenuItem.Name = "quảnLýHoạtĐộngKhaiThácToolStripMenuItem";
            this.quảnLýHoạtĐộngKhaiThácToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.quảnLýHoạtĐộngKhaiThácToolStripMenuItem.Text = "Quản lý hoạt động khai thác";
            this.quảnLýHoạtĐộngKhaiThácToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHoạtĐộngKhaiThácToolStripMenuItem_Click);
            // 
            // quảnLýHồSơToolStripMenuItem
            // 
            this.quảnLýHồSơToolStripMenuItem.Name = "quảnLýHồSơToolStripMenuItem";
            this.quảnLýHồSơToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.quảnLýHồSơToolStripMenuItem.Text = "Quản lý hồ sơ";
            // 
            // traCứuThôngTinQuyHoạchToolStripMenuItem
            // 
            this.traCứuThôngTinQuyHoạchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.traCứuNhanhToolStripMenuItem,
            this.toolStripSeparator6,
            this.tìmTheoTọaĐộĐiểmToolStripMenuItem,
            this.theoKhToolStripMenuItem,
            this.toolStripSeparator4,
            this.traCứuThôngTinThửaĐấtToolStripMenuItem,
            this.traCứuThôngTinKiếnTrúcToolStripMenuItem1,
            this.toolStripSeparator5,
            this.thốngKêToolStripMenuItem});
            this.traCứuThôngTinQuyHoạchToolStripMenuItem.Name = "traCứuThôngTinQuyHoạchToolStripMenuItem";
            this.traCứuThôngTinQuyHoạchToolStripMenuItem.Size = new System.Drawing.Size(142, 21);
            this.traCứuThôngTinQuyHoạchToolStripMenuItem.Text = "Tra cứu - Thống kê";
            // 
            // traCứuNhanhToolStripMenuItem
            // 
            this.traCứuNhanhToolStripMenuItem.Name = "traCứuNhanhToolStripMenuItem";
            this.traCứuNhanhToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.traCứuNhanhToolStripMenuItem.Text = "Tra cứu nhanh";
            this.traCứuNhanhToolStripMenuItem.Visible = false;
            this.traCứuNhanhToolStripMenuItem.Click += new System.EventHandler(this.traCứuNhanhToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(307, 6);
            this.toolStripSeparator6.Visible = false;
            // 
            // tìmTheoTọaĐộĐiểmToolStripMenuItem
            // 
            this.tìmTheoTọaĐộĐiểmToolStripMenuItem.Name = "tìmTheoTọaĐộĐiểmToolStripMenuItem";
            this.tìmTheoTọaĐộĐiểmToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.tìmTheoTọaĐộĐiểmToolStripMenuItem.Text = "Theo tọa độ điểm";
            this.tìmTheoTọaĐộĐiểmToolStripMenuItem.Click += new System.EventHandler(this.tìmTheoTọaĐộĐiểmToolStripMenuItem_Click);
            // 
            // theoKhToolStripMenuItem
            // 
            this.theoKhToolStripMenuItem.Name = "theoKhToolStripMenuItem";
            this.theoKhToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.theoKhToolStripMenuItem.Text = "Theo không gian";
            this.theoKhToolStripMenuItem.Click += new System.EventHandler(this.theoKhToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(307, 6);
            // 
            // traCứuThôngTinThửaĐấtToolStripMenuItem
            // 
            this.traCứuThôngTinThửaĐấtToolStripMenuItem.Name = "traCứuThôngTinThửaĐấtToolStripMenuItem";
            this.traCứuThôngTinThửaĐấtToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.traCứuThôngTinThửaĐấtToolStripMenuItem.Text = "Tra cứu thông tin quy hoạch thửa đất";
            this.traCứuThôngTinThửaĐấtToolStripMenuItem.Click += new System.EventHandler(this.traCứuThôngTinThửaĐấtToolStripMenuItem_Click);
            // 
            // traCứuThôngTinKiếnTrúcToolStripMenuItem1
            // 
            this.traCứuThôngTinKiếnTrúcToolStripMenuItem1.Name = "traCứuThôngTinKiếnTrúcToolStripMenuItem1";
            this.traCứuThôngTinKiếnTrúcToolStripMenuItem1.Size = new System.Drawing.Size(310, 22);
            this.traCứuThôngTinKiếnTrúcToolStripMenuItem1.Text = "Tra cứu thông tin kiến trúc thửa đất";
            this.traCứuThôngTinKiếnTrúcToolStripMenuItem1.Visible = false;
            this.traCứuThôngTinKiếnTrúcToolStripMenuItem1.Click += new System.EventHandler(this.traCứuThôngTinKiếnTrúcToolStripMenuItem1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(307, 6);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.thốngKêToolStripMenuItem.Text = "Thống kê dữ liệu";
            this.thốngKêToolStripMenuItem.Click += new System.EventHandler(this.thToolStripMenuItem_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnSửDụngToolStripMenuItem,
            this.giớiThiệuSảnPhâprToolStripMenuItem,
            this.updateDiaChinhToolStripMenuItem});
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
            // updateDiaChinhToolStripMenuItem
            // 
            this.updateDiaChinhToolStripMenuItem.Name = "updateDiaChinhToolStripMenuItem";
            this.updateDiaChinhToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.updateDiaChinhToolStripMenuItem.Text = "Update DiaChinh";
            this.updateDiaChinhToolStripMenuItem.Click += new System.EventHandler(this.updateDiaChinhToolStripMenuItem_Click);
            // 
            // quToolStripMenuItem
            // 
            this.quToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýQuyHoạchToolStripMenuItem,
            this.quảnLýKiếnTrúcXâyDựngToolStripMenuItem,
            this.quảnLýCSHTKýThuậtToolStripMenuItem,
            this.quảmLýBTSToolStripMenuItem,
            this.quảnLýCapViễnThôngToolStripMenuItem,
            this.quảnLýHồSơQuyếtĐịnhPhêDuyệtDựÁnToolStripMenuItem,
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem1});
            this.quToolStripMenuItem.Name = "quToolStripMenuItem";
            this.quToolStripMenuItem.Size = new System.Drawing.Size(12, 21);
            this.quToolStripMenuItem.Visible = false;
            // 
            // quảnLýQuyHoạchToolStripMenuItem
            // 
            this.quảnLýQuyHoạchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thốngKêTraCứuKhuQuyHoạchToolStripMenuItem,
            this.traCứuHồSơQuyHoạchToolStripMenuItem,
            this.quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem});
            this.quảnLýQuyHoạchToolStripMenuItem.Name = "quảnLýQuyHoạchToolStripMenuItem";
            this.quảnLýQuyHoạchToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.quảnLýQuyHoạchToolStripMenuItem.Text = "Quản lý quy hoạch";
            this.quảnLýQuyHoạchToolStripMenuItem.Click += new System.EventHandler(this.quảnLýQuyHoạchToolStripMenuItem_Click);
            // 
            // thốngKêTraCứuKhuQuyHoạchToolStripMenuItem
            // 
            this.thốngKêTraCứuKhuQuyHoạchToolStripMenuItem.Name = "thốngKêTraCứuKhuQuyHoạchToolStripMenuItem";
            this.thốngKêTraCứuKhuQuyHoạchToolStripMenuItem.Size = new System.Drawing.Size(345, 22);
            this.thốngKêTraCứuKhuQuyHoạchToolStripMenuItem.Text = "Quản lý dự án quy hoạch";
            this.thốngKêTraCứuKhuQuyHoạchToolStripMenuItem.Visible = false;
            this.thốngKêTraCứuKhuQuyHoạchToolStripMenuItem.Click += new System.EventHandler(this.quảnLýQuyHoạchToolStripMenuItem_Click);
            // 
            // traCứuHồSơQuyHoạchToolStripMenuItem
            // 
            this.traCứuHồSơQuyHoạchToolStripMenuItem.Name = "traCứuHồSơQuyHoạchToolStripMenuItem";
            this.traCứuHồSơQuyHoạchToolStripMenuItem.Size = new System.Drawing.Size(345, 22);
            this.traCứuHồSơQuyHoạchToolStripMenuItem.Text = "Quản lý hồ sơ, quyết định phê duyệt dự án";
            this.traCứuHồSơQuyHoạchToolStripMenuItem.Visible = false;
            this.traCứuHồSơQuyHoạchToolStripMenuItem.Click += new System.EventHandler(this.traCứuHồSơQuyHoạchToolStripMenuItem_Click);
            // 
            // quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem
            // 
            this.quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem.Name = "quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem";
            this.quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem.Size = new System.Drawing.Size(345, 22);
            this.quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem.Text = "Quản lý hồ sơ xác nhận quy hoạch";
            this.quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem.Visible = false;
            this.quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem_Click);
            // 
            // quảnLýKiếnTrúcXâyDựngToolStripMenuItem
            // 
            this.quảnLýKiếnTrúcXâyDựngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýHồSơKiếnTrúcToolStripMenuItem,
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem});
            this.quảnLýKiếnTrúcXâyDựngToolStripMenuItem.Name = "quảnLýKiếnTrúcXâyDựngToolStripMenuItem";
            this.quảnLýKiếnTrúcXâyDựngToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.quảnLýKiếnTrúcXâyDựngToolStripMenuItem.Text = "Quản lý Kiến trúc - Xây dựng";
            this.quảnLýKiếnTrúcXâyDựngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKiếnTrúcXâyDựngToolStripMenuItem_Click);
            // 
            // quảnLýHồSơKiếnTrúcToolStripMenuItem
            // 
            this.quảnLýHồSơKiếnTrúcToolStripMenuItem.Name = "quảnLýHồSơKiếnTrúcToolStripMenuItem";
            this.quảnLýHồSơKiếnTrúcToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.quảnLýHồSơKiếnTrúcToolStripMenuItem.Text = "Quản lý hồ sơ kiến trúc";
            this.quảnLýHồSơKiếnTrúcToolStripMenuItem.Visible = false;
            this.quảnLýHồSơKiếnTrúcToolStripMenuItem.Click += new System.EventHandler(this.điềuLệQuảnLýKiếnTrúcToolStripMenuItem_Click);
            // 
            // quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem
            // 
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cấpGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem,
            this.điềuChỉnhGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem,
            this.giaHạnGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem,
            this.cấpLạiGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem,
            this.cấpGiấyPhépXâyDựngCóThờiHạnToolStripMenuItem,
            this.cấpGiấyPhépXâyDựngĐốiVớiTrườngHợpSửaChữaCảiTạoNhàỞRiêngLẻToolStripMenuItem});
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem.Name = "quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem";
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem.Text = "Quản lý hồ sơ cấp phép xây dựng";
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem.Visible = false;
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem.Click += new System.EventHandler(this.cấpPhépXâyDựngNhaORiengLe_Click);
            // 
            // cấpGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem
            // 
            this.cấpGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Name = "cấpGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem";
            this.cấpGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Size = new System.Drawing.Size(553, 22);
            this.cấpGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Text = "Cấp giấy phép xây dựng nhà ở riêng lẻ tại đô thị ";
            this.cấpGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Visible = false;
            this.cấpGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Click += new System.EventHandler(this.cấpPhépXâyDựngNhaORiengLe_Click);
            // 
            // điềuChỉnhGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem
            // 
            this.điềuChỉnhGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Enabled = false;
            this.điềuChỉnhGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Name = "điềuChỉnhGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem";
            this.điềuChỉnhGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Size = new System.Drawing.Size(553, 22);
            this.điềuChỉnhGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Text = "Điều chỉnh giấy phép xây dựng nhà ở riêng lẻ tại đô thị";
            this.điềuChỉnhGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Visible = false;
            // 
            // giaHạnGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem
            // 
            this.giaHạnGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Enabled = false;
            this.giaHạnGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Name = "giaHạnGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem";
            this.giaHạnGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Size = new System.Drawing.Size(553, 22);
            this.giaHạnGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Text = "Gia hạn giấy phép xây dựng nhà ở riêng lẻ tại đô thị ";
            this.giaHạnGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Visible = false;
            // 
            // cấpLạiGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem
            // 
            this.cấpLạiGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Enabled = false;
            this.cấpLạiGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Name = "cấpLạiGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem";
            this.cấpLạiGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Size = new System.Drawing.Size(553, 22);
            this.cấpLạiGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Text = "Cấp lại giấy phép xây dựng nhà ở riêng lẻ tại đô thị ";
            this.cấpLạiGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem.Visible = false;
            // 
            // cấpGiấyPhépXâyDựngCóThờiHạnToolStripMenuItem
            // 
            this.cấpGiấyPhépXâyDựngCóThờiHạnToolStripMenuItem.Enabled = false;
            this.cấpGiấyPhépXâyDựngCóThờiHạnToolStripMenuItem.Name = "cấpGiấyPhépXâyDựngCóThờiHạnToolStripMenuItem";
            this.cấpGiấyPhépXâyDựngCóThờiHạnToolStripMenuItem.Size = new System.Drawing.Size(553, 22);
            this.cấpGiấyPhépXâyDựngCóThờiHạnToolStripMenuItem.Text = "Cấp giấy phép xây dựng tạm công trình, nhà ở riêng lẻ";
            this.cấpGiấyPhépXâyDựngCóThờiHạnToolStripMenuItem.Visible = false;
            // 
            // cấpGiấyPhépXâyDựngĐốiVớiTrườngHợpSửaChữaCảiTạoNhàỞRiêngLẻToolStripMenuItem
            // 
            this.cấpGiấyPhépXâyDựngĐốiVớiTrườngHợpSửaChữaCảiTạoNhàỞRiêngLẻToolStripMenuItem.Enabled = false;
            this.cấpGiấyPhépXâyDựngĐốiVớiTrườngHợpSửaChữaCảiTạoNhàỞRiêngLẻToolStripMenuItem.Name = "cấpGiấyPhépXâyDựngĐốiVớiTrườngHợpSửaChữaCảiTạoNhàỞRiêngLẻToolStripMenuItem";
            this.cấpGiấyPhépXâyDựngĐốiVớiTrườngHợpSửaChữaCảiTạoNhàỞRiêngLẻToolStripMenuItem.Size = new System.Drawing.Size(553, 22);
            this.cấpGiấyPhépXâyDựngĐốiVớiTrườngHợpSửaChữaCảiTạoNhàỞRiêngLẻToolStripMenuItem.Text = "Cấp giấy phép xây dựng đối với trường hợp sửa chữa, cải tạo nhà ở riêng lẻ ";
            this.cấpGiấyPhépXâyDựngĐốiVớiTrườngHợpSửaChữaCảiTạoNhàỞRiêngLẻToolStripMenuItem.Visible = false;
            // 
            // quảnLýCSHTKýThuậtToolStripMenuItem
            // 
            this.quảnLýCSHTKýThuậtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.giaoThôngToolStripMenuItem1,
            this.điệnChiếuSángToolStripMenuItem1,
            this.câyXanhToolStripMenuItem1,
            this.thoátNướcToolStripMenuItem1});
            this.quảnLýCSHTKýThuậtToolStripMenuItem.Name = "quảnLýCSHTKýThuậtToolStripMenuItem";
            this.quảnLýCSHTKýThuậtToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.quảnLýCSHTKýThuậtToolStripMenuItem.Text = "Quản lý CSHT kỹ thuật";
            // 
            // giaoThôngToolStripMenuItem1
            // 
            this.giaoThôngToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đườngGiaoThôngChínhToolStripMenuItem,
            this.đườngKiệtHẻmToolStripMenuItem});
            this.giaoThôngToolStripMenuItem1.Name = "giaoThôngToolStripMenuItem1";
            this.giaoThôngToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.giaoThôngToolStripMenuItem1.Text = "Giao thông";
            // 
            // đườngGiaoThôngChínhToolStripMenuItem
            // 
            this.đườngGiaoThôngChínhToolStripMenuItem.Name = "đườngGiaoThôngChínhToolStripMenuItem";
            this.đườngGiaoThôngChínhToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.đườngGiaoThôngChínhToolStripMenuItem.Text = "Đường giao thông chính";
            this.đườngGiaoThôngChínhToolStripMenuItem.Click += new System.EventHandler(this.đườngGiaoThôngChínhToolStripMenuItem_Click_1);
            // 
            // đườngKiệtHẻmToolStripMenuItem
            // 
            this.đườngKiệtHẻmToolStripMenuItem.Name = "đườngKiệtHẻmToolStripMenuItem";
            this.đườngKiệtHẻmToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.đườngKiệtHẻmToolStripMenuItem.Text = "Đường kiệt hẻm";
            this.đườngKiệtHẻmToolStripMenuItem.Click += new System.EventHandler(this.đườngKiệtHẻmToolStripMenuItem_Click);
            // 
            // điệnChiếuSángToolStripMenuItem1
            // 
            this.điệnChiếuSángToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tuyếnDâyĐiệnToolStripMenuItem,
            this.trụĐiệnChiếuSángToolStripMenuItem});
            this.điệnChiếuSángToolStripMenuItem1.Name = "điệnChiếuSángToolStripMenuItem1";
            this.điệnChiếuSángToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.điệnChiếuSángToolStripMenuItem1.Text = "Điện chiếu sáng";
            // 
            // tuyếnDâyĐiệnToolStripMenuItem
            // 
            this.tuyếnDâyĐiệnToolStripMenuItem.Name = "tuyếnDâyĐiệnToolStripMenuItem";
            this.tuyếnDâyĐiệnToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.tuyếnDâyĐiệnToolStripMenuItem.Text = "Tuyến dây điện";
            this.tuyếnDâyĐiệnToolStripMenuItem.Click += new System.EventHandler(this.tuyếnDâyĐiệnToolStripMenuItem_Click);
            // 
            // trụĐiệnChiếuSángToolStripMenuItem
            // 
            this.trụĐiệnChiếuSángToolStripMenuItem.Name = "trụĐiệnChiếuSángToolStripMenuItem";
            this.trụĐiệnChiếuSángToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.trụĐiệnChiếuSángToolStripMenuItem.Text = "Trụ điện chiếu sáng";
            this.trụĐiệnChiếuSángToolStripMenuItem.Click += new System.EventHandler(this.trụĐiệnChiếuSángToolStripMenuItem_Click);
            // 
            // câyXanhToolStripMenuItem1
            // 
            this.câyXanhToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýCâyXanhBóngMátToolStripMenuItem,
            this.quảnLýThảmCỏToolStripMenuItem,
            this.quảnLýCâyTrangTríToolStripMenuItem,
            this.toolStripSeparator8,
            this.quảnLýĐơnVịChămSócToolStripMenuItem,
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem,
            this.quảnLýCôngViênToolStripMenuItem,
            this.quảnLýLoạiChămSócToolStripMenuItem,
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem});
            this.câyXanhToolStripMenuItem1.Name = "câyXanhToolStripMenuItem1";
            this.câyXanhToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.câyXanhToolStripMenuItem1.Text = "Cây xanh";
            this.câyXanhToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýCâyXanhBóngMátToolStripMenuItem_Click);
            // 
            // quảnLýCâyXanhBóngMátToolStripMenuItem
            // 
            this.quảnLýCâyXanhBóngMátToolStripMenuItem.Name = "quảnLýCâyXanhBóngMátToolStripMenuItem";
            this.quảnLýCâyXanhBóngMátToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.quảnLýCâyXanhBóngMátToolStripMenuItem.Text = "Quản lý cây xanh bóng mát";
            this.quảnLýCâyXanhBóngMátToolStripMenuItem.Visible = false;
            this.quảnLýCâyXanhBóngMátToolStripMenuItem.Click += new System.EventHandler(this.quảnLýCâyXanhBóngMátToolStripMenuItem_Click);
            // 
            // quảnLýThảmCỏToolStripMenuItem
            // 
            this.quảnLýThảmCỏToolStripMenuItem.Name = "quảnLýThảmCỏToolStripMenuItem";
            this.quảnLýThảmCỏToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.quảnLýThảmCỏToolStripMenuItem.Text = "Quản lý thảm cỏ";
            this.quảnLýThảmCỏToolStripMenuItem.Visible = false;
            this.quảnLýThảmCỏToolStripMenuItem.Click += new System.EventHandler(this.quảnLýThảmCỏToolStripMenuItem_Click);
            // 
            // quảnLýCâyTrangTríToolStripMenuItem
            // 
            this.quảnLýCâyTrangTríToolStripMenuItem.Name = "quảnLýCâyTrangTríToolStripMenuItem";
            this.quảnLýCâyTrangTríToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.quảnLýCâyTrangTríToolStripMenuItem.Text = "Quản lý cây trang trí";
            this.quảnLýCâyTrangTríToolStripMenuItem.Visible = false;
            this.quảnLýCâyTrangTríToolStripMenuItem.Click += new System.EventHandler(this.quảnLýCâyTrangTríToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(274, 6);
            this.toolStripSeparator8.Visible = false;
            // 
            // quảnLýĐơnVịChămSócToolStripMenuItem
            // 
            this.quảnLýĐơnVịChămSócToolStripMenuItem.Name = "quảnLýĐơnVịChămSócToolStripMenuItem";
            this.quảnLýĐơnVịChămSócToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.quảnLýĐơnVịChămSócToolStripMenuItem.Text = "Quản lý đơn vị chăm sóc";
            this.quảnLýĐơnVịChămSócToolStripMenuItem.Visible = false;
            this.quảnLýĐơnVịChămSócToolStripMenuItem.Click += new System.EventHandler(this.quảnLýĐơnVịChămSócToolStripMenuItem_Click);
            // 
            // quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem
            // 
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem.Name = "quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem";
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem.Text = "Quản lý đơn vị quản lý cây xanh";
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem.Visible = false;
            this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem.Click += new System.EventHandler(this.quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem_Click);
            // 
            // quảnLýCôngViênToolStripMenuItem
            // 
            this.quảnLýCôngViênToolStripMenuItem.Name = "quảnLýCôngViênToolStripMenuItem";
            this.quảnLýCôngViênToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.quảnLýCôngViênToolStripMenuItem.Text = "Quản lý công viên";
            this.quảnLýCôngViênToolStripMenuItem.Visible = false;
            this.quảnLýCôngViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýCôngViênToolStripMenuItem_Click);
            // 
            // quảnLýLoạiChămSócToolStripMenuItem
            // 
            this.quảnLýLoạiChămSócToolStripMenuItem.Name = "quảnLýLoạiChămSócToolStripMenuItem";
            this.quảnLýLoạiChămSócToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.quảnLýLoạiChămSócToolStripMenuItem.Text = "Quản lý loại chăm sóc";
            this.quảnLýLoạiChămSócToolStripMenuItem.Visible = false;
            this.quảnLýLoạiChămSócToolStripMenuItem.Click += new System.EventHandler(this.quảnLýLoạiChămSócToolStripMenuItem_Click);
            // 
            // quảnLýChủngLoạiCâyXanhToolStripMenuItem
            // 
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem.Name = "quảnLýChủngLoạiCâyXanhToolStripMenuItem";
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem.Text = "Quản lý chủng loại cây xanh";
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem.Visible = false;
            this.quảnLýChủngLoạiCâyXanhToolStripMenuItem.Click += new System.EventHandler(this.quảnLýChủngLoạiCâyXanhToolStripMenuItem_Click);
            // 
            // thoátNướcToolStripMenuItem1
            // 
            this.thoátNướcToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đườngMươngThoátNướcToolStripMenuItem,
            this.lỗCốngThoátNướcToolStripMenuItem});
            this.thoátNướcToolStripMenuItem1.Name = "thoátNướcToolStripMenuItem1";
            this.thoátNướcToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.thoátNướcToolStripMenuItem1.Text = "Mương thoát nước";
            this.thoátNướcToolStripMenuItem1.Click += new System.EventHandler(this.đườngMươngThoátNướcToolStripMenuItem_Click);
            // 
            // đườngMươngThoátNướcToolStripMenuItem
            // 
            this.đườngMươngThoátNướcToolStripMenuItem.Name = "đườngMươngThoátNướcToolStripMenuItem";
            this.đườngMươngThoátNướcToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.đườngMươngThoátNướcToolStripMenuItem.Text = "Đường mương thoát nước";
            this.đườngMươngThoátNướcToolStripMenuItem.Visible = false;
            this.đườngMươngThoátNướcToolStripMenuItem.Click += new System.EventHandler(this.đườngMươngThoátNướcToolStripMenuItem_Click);
            // 
            // lỗCốngThoátNướcToolStripMenuItem
            // 
            this.lỗCốngThoátNướcToolStripMenuItem.Name = "lỗCốngThoátNướcToolStripMenuItem";
            this.lỗCốngThoátNướcToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.lỗCốngThoátNướcToolStripMenuItem.Text = "Lỗ cống thoát nước";
            this.lỗCốngThoátNướcToolStripMenuItem.Visible = false;
            this.lỗCốngThoátNướcToolStripMenuItem.Click += new System.EventHandler(this.lỗCốngThoátNướcToolStripMenuItem_Click);
            // 
            // quảmLýBTSToolStripMenuItem
            // 
            this.quảmLýBTSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýTrạmBTSToolStripMenuItem,
            this.quảnLýĐạiLýInternetToolStripMenuItem});
            this.quảmLýBTSToolStripMenuItem.Name = "quảmLýBTSToolStripMenuItem";
            this.quảmLýBTSToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.quảmLýBTSToolStripMenuItem.Text = "Quảm lý BTS";
            // 
            // quảnLýTrạmBTSToolStripMenuItem
            // 
            this.quảnLýTrạmBTSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qảunLýTrạmToolStripMenuItem,
            this.quảnLýLoạiTrạmToolStripMenuItem,
            this.quảnLýChủĐầuTưToolStripMenuItem});
            this.quảnLýTrạmBTSToolStripMenuItem.Name = "quảnLýTrạmBTSToolStripMenuItem";
            this.quảnLýTrạmBTSToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.quảnLýTrạmBTSToolStripMenuItem.Text = "Quản lý trạm BTS";
            this.quảnLýTrạmBTSToolStripMenuItem.Click += new System.EventHandler(this.qảunLýTrạmToolStripMenuItem_Click);
            // 
            // qảunLýTrạmToolStripMenuItem
            // 
            this.qảunLýTrạmToolStripMenuItem.Name = "qảunLýTrạmToolStripMenuItem";
            this.qảunLýTrạmToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.qảunLýTrạmToolStripMenuItem.Text = "Quản lý Trạm";
            this.qảunLýTrạmToolStripMenuItem.Visible = false;
            this.qảunLýTrạmToolStripMenuItem.Click += new System.EventHandler(this.qảunLýTrạmToolStripMenuItem_Click);
            // 
            // quảnLýLoạiTrạmToolStripMenuItem
            // 
            this.quảnLýLoạiTrạmToolStripMenuItem.Name = "quảnLýLoạiTrạmToolStripMenuItem";
            this.quảnLýLoạiTrạmToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.quảnLýLoạiTrạmToolStripMenuItem.Text = "Quản lý Loại trạm";
            this.quảnLýLoạiTrạmToolStripMenuItem.Visible = false;
            this.quảnLýLoạiTrạmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýLoạiTrạmToolStripMenuItem_Click);
            // 
            // quảnLýChủĐầuTưToolStripMenuItem
            // 
            this.quảnLýChủĐầuTưToolStripMenuItem.Name = "quảnLýChủĐầuTưToolStripMenuItem";
            this.quảnLýChủĐầuTưToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.quảnLýChủĐầuTưToolStripMenuItem.Text = "Quản lý Chủ đầu tư";
            this.quảnLýChủĐầuTưToolStripMenuItem.Visible = false;
            this.quảnLýChủĐầuTưToolStripMenuItem.Click += new System.EventHandler(this.quảnLýChủĐầuTưToolStripMenuItem_Click);
            // 
            // quảnLýĐạiLýInternetToolStripMenuItem
            // 
            this.quảnLýĐạiLýInternetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýĐạiLýToolStripMenuItem,
            this.quảnLýNhàMạngToolStripMenuItem,
            this.quảnLýChủĐạiLýToolStripMenuItem});
            this.quảnLýĐạiLýInternetToolStripMenuItem.Name = "quảnLýĐạiLýInternetToolStripMenuItem";
            this.quảnLýĐạiLýInternetToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.quảnLýĐạiLýInternetToolStripMenuItem.Text = "Quản lý đại lý Internet";
            this.quảnLýĐạiLýInternetToolStripMenuItem.Click += new System.EventHandler(this.quảnLýĐạiLýToolStripMenuItem_Click);
            // 
            // quảnLýĐạiLýToolStripMenuItem
            // 
            this.quảnLýĐạiLýToolStripMenuItem.Name = "quảnLýĐạiLýToolStripMenuItem";
            this.quảnLýĐạiLýToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.quảnLýĐạiLýToolStripMenuItem.Text = "Quản lý đại lý";
            this.quảnLýĐạiLýToolStripMenuItem.Visible = false;
            this.quảnLýĐạiLýToolStripMenuItem.Click += new System.EventHandler(this.quảnLýĐạiLýToolStripMenuItem_Click);
            // 
            // quảnLýNhàMạngToolStripMenuItem
            // 
            this.quảnLýNhàMạngToolStripMenuItem.Name = "quảnLýNhàMạngToolStripMenuItem";
            this.quảnLýNhàMạngToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.quảnLýNhàMạngToolStripMenuItem.Text = "Quản lý nhà mạng";
            this.quảnLýNhàMạngToolStripMenuItem.Visible = false;
            this.quảnLýNhàMạngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhàMạngToolStripMenuItem_Click);
            // 
            // quảnLýChủĐạiLýToolStripMenuItem
            // 
            this.quảnLýChủĐạiLýToolStripMenuItem.Name = "quảnLýChủĐạiLýToolStripMenuItem";
            this.quảnLýChủĐạiLýToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.quảnLýChủĐạiLýToolStripMenuItem.Text = "Quản lý Chủ đại lý";
            this.quảnLýChủĐạiLýToolStripMenuItem.Visible = false;
            this.quảnLýChủĐạiLýToolStripMenuItem.Click += new System.EventHandler(this.quảnLýChủĐạiLýToolStripMenuItem_Click);
            // 
            // quảnLýCapViễnThôngToolStripMenuItem
            // 
            this.quảnLýCapViễnThôngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýTuyếnCápNgầmToolStripMenuItem,
            this.quảnLýTuyếnCápTreoToolStripMenuItem,
            this.quảnLýBểCápToolStripMenuItem,
            this.quảnLýCộtCápTreoToolStripMenuItem,
            this.quảnLýDoanhNghiệpToolStripMenuItem,
            this.quảnLýThiếtBịPhụTrợToolStripMenuItem,
            this.quảnLýCôngTrìnhHạTầngToolStripMenuItem});
            this.quảnLýCapViễnThôngToolStripMenuItem.Name = "quảnLýCapViễnThôngToolStripMenuItem";
            this.quảnLýCapViễnThôngToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.quảnLýCapViễnThôngToolStripMenuItem.Text = "Quản lý Cáp viễn thông";
            this.quảnLýCapViễnThôngToolStripMenuItem.Visible = false;
            // 
            // quảnLýTuyếnCápNgầmToolStripMenuItem
            // 
            this.quảnLýTuyếnCápNgầmToolStripMenuItem.Name = "quảnLýTuyếnCápNgầmToolStripMenuItem";
            this.quảnLýTuyếnCápNgầmToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.quảnLýTuyếnCápNgầmToolStripMenuItem.Text = "Quản lý Tuyến cáp ngầm";
            this.quảnLýTuyếnCápNgầmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýTuyếnCápNgầmToolStripMenuItem_Click);
            // 
            // quảnLýTuyếnCápTreoToolStripMenuItem
            // 
            this.quảnLýTuyếnCápTreoToolStripMenuItem.Name = "quảnLýTuyếnCápTreoToolStripMenuItem";
            this.quảnLýTuyếnCápTreoToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.quảnLýTuyếnCápTreoToolStripMenuItem.Text = "Quản lý Tuyến cáp treo";
            this.quảnLýTuyếnCápTreoToolStripMenuItem.Click += new System.EventHandler(this.quảnLýTuyếnCápTreoToolStripMenuItem_Click);
            // 
            // quảnLýBểCápToolStripMenuItem
            // 
            this.quảnLýBểCápToolStripMenuItem.Name = "quảnLýBểCápToolStripMenuItem";
            this.quảnLýBểCápToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.quảnLýBểCápToolStripMenuItem.Text = "Quản lý Bể cáp";
            this.quảnLýBểCápToolStripMenuItem.Click += new System.EventHandler(this.quảnLýBểCápToolStripMenuItem_Click);
            // 
            // quảnLýCộtCápTreoToolStripMenuItem
            // 
            this.quảnLýCộtCápTreoToolStripMenuItem.Name = "quảnLýCộtCápTreoToolStripMenuItem";
            this.quảnLýCộtCápTreoToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.quảnLýCộtCápTreoToolStripMenuItem.Text = "Quản lý Cột cáp treo";
            this.quảnLýCộtCápTreoToolStripMenuItem.Click += new System.EventHandler(this.quảnLýCộtCápTreoToolStripMenuItem_Click);
            // 
            // quảnLýDoanhNghiệpToolStripMenuItem
            // 
            this.quảnLýDoanhNghiệpToolStripMenuItem.Name = "quảnLýDoanhNghiệpToolStripMenuItem";
            this.quảnLýDoanhNghiệpToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.quảnLýDoanhNghiệpToolStripMenuItem.Text = "Quản lý Doanh nghiệp";
            this.quảnLýDoanhNghiệpToolStripMenuItem.Click += new System.EventHandler(this.quảnLýDoanhNghiệpToolStripMenuItem_Click);
            // 
            // quảnLýThiếtBịPhụTrợToolStripMenuItem
            // 
            this.quảnLýThiếtBịPhụTrợToolStripMenuItem.Name = "quảnLýThiếtBịPhụTrợToolStripMenuItem";
            this.quảnLýThiếtBịPhụTrợToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.quảnLýThiếtBịPhụTrợToolStripMenuItem.Text = "Quản lý Thiết bị phụ trợ";
            this.quảnLýThiếtBịPhụTrợToolStripMenuItem.Click += new System.EventHandler(this.quảnLýThiếtBịPhụTrợToolStripMenuItem_Click);
            // 
            // quảnLýCôngTrìnhHạTầngToolStripMenuItem
            // 
            this.quảnLýCôngTrìnhHạTầngToolStripMenuItem.Name = "quảnLýCôngTrìnhHạTầngToolStripMenuItem";
            this.quảnLýCôngTrìnhHạTầngToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.quảnLýCôngTrìnhHạTầngToolStripMenuItem.Text = "Quản lý Công trình hạ tầng";
            this.quảnLýCôngTrìnhHạTầngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýCôngTrìnhHạTầngToolStripMenuItem_Click);
            // 
            // quảnLýHồSơQuyếtĐịnhPhêDuyệtDựÁnToolStripMenuItem
            // 
            this.quảnLýHồSơQuyếtĐịnhPhêDuyệtDựÁnToolStripMenuItem.Name = "quảnLýHồSơQuyếtĐịnhPhêDuyệtDựÁnToolStripMenuItem";
            this.quảnLýHồSơQuyếtĐịnhPhêDuyệtDựÁnToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.quảnLýHồSơQuyếtĐịnhPhêDuyệtDựÁnToolStripMenuItem.Text = "Quản lý hồ sơ xác nhận quy hoạch";
            this.quảnLýHồSơQuyếtĐịnhPhêDuyệtDựÁnToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem_Click);
            // 
            // quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem1
            // 
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem1.Name = "quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem1";
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem1.Size = new System.Drawing.Size(295, 22);
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem1.Text = "Quản lý hồ sơ cấp phép xây dựng";
            this.quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem1.Click += new System.EventHandler(this.cấpPhépXâyDựngNhaORiengLe_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 727);
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
            // KienTruc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 749);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "KienTruc";
            this.Text = "Phần mềm Quản lý không gian và quy hoạch đô thị";
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
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
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
        private SplitContainer splitContainer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ảnhGiaoThôngToolStripMenuItem;
        private ToolStripMenuItem traCứuThôngTinQuyHoạchToolStripMenuItem;
        private ToolStripMenuItem tìmTheoTọaĐộĐiểmToolStripMenuItem;
        private ToolStripMenuItem thanhCôngCụToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit addlayer;
        private ToolStripStatusLabel statusBarXY;
        private StatusStrip statusStrip1;
        private BindingSource dataDataSet1BindingSource;
        private ToolStripMenuItem quToolStripMenuItem;
        private ToolStripMenuItem quảnLýQuyHoạchToolStripMenuItem;
        private ToolStripMenuItem quảnLýCSHTKýThuậtToolStripMenuItem;
        private ToolStripMenuItem giaoThôngToolStripMenuItem1;
        private ToolStripMenuItem điệnChiếuSángToolStripMenuItem1;
        private ToolStripMenuItem câyXanhToolStripMenuItem1;
        private ToolStripMenuItem thoátNướcToolStripMenuItem1;
        private ToolStripMenuItem theoKhToolStripMenuItem;
        private ToolStripMenuItem đườngGiaoThôngChínhToolStripMenuItem;
        private ToolStripMenuItem đườngKiệtHẻmToolStripMenuItem;
        private ToolStripMenuItem tuyếnDâyĐiệnToolStripMenuItem;
        private ToolStripMenuItem trụĐiệnChiếuSángToolStripMenuItem;
        private ToolStripMenuItem đườngMươngThoátNướcToolStripMenuItem;
        private ToolStripMenuItem lỗCốngThoátNướcToolStripMenuItem;
        private ToolStripMenuItem thốngKêTraCứuKhuQuyHoạchToolStripMenuItem;
        private ToolStripMenuItem traCứuHồSơQuyHoạchToolStripMenuItem;
        private ToolStripMenuItem traCứuNhanhToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl2;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl3;
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
        private ToolStripMenuItem thốngKêToolStripMenuItem;
        private ComboBox comboBox2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private ToolStripMenuItem thanhCôngCụToolStripMenuItem1;
        private ToolStripMenuItem côngCụCơBảnToolStripMenuItem;
        private ToolStripMenuItem côngCụChỉnhSửaTrangInToolStripMenuItem;
        private ToolStripMenuItem côngCụChỉnhSửaDữLiệuToolStripMenuItem;
        private ToolStripMenuItem tùyChỉnhToolStripMenuItem1;
        private ToolStripMenuItem lưuThanhCôngCụToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl2;
        private ToolStripMenuItem quảnLýHồSơCấpChứngChỉQuyHoạchToolStripMenuItem;
        private ToolStripMenuItem quảnLýKiếnTrúcXâyDựngToolStripMenuItem;
        private ToolStripMenuItem quảnLýHồSơKiếnTrúcToolStripMenuItem;
        private ToolStripMenuItem quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem;
        private ToolStripMenuItem trợGiúpToolStripMenuItem;
        private ToolStripMenuItem hướngDẫnSửDụngToolStripMenuItem;
        private ToolStripMenuItem giớiThiệuSảnPhâprToolStripMenuItem;
        private ToolStripMenuItem quảmLýBTSToolStripMenuItem;
        private ToolStripMenuItem quảnLýTrạmBTSToolStripMenuItem;
        private ToolStripMenuItem cấpGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem;
        private ToolStripMenuItem điềuChỉnhGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem;
        private ToolStripMenuItem giaHạnGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem;
        private ToolStripMenuItem cấpLạiGiấyPhépXâyDựngNhàỞRiêngLẻTạiĐôThịToolStripMenuItem;
        private ToolStripMenuItem cấpGiấyPhépXâyDựngCóThờiHạnToolStripMenuItem;
        private ToolStripMenuItem cấpGiấyPhépXâyDựngĐốiVớiTrườngHợpSửaChữaCảiTạoNhàỞRiêngLẻToolStripMenuItem;

        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem mởBảnĐồToolStripMenuItem2;
        private ToolStripMenuItem lưuBảnĐồToolStripMenuItem1;
        private ToolStripMenuItem thêmLớpLayerToolStripMenuItem;
        private ToolStripMenuItem mởFileAutoCadToolStripMenuItem;
        private ToolStripMenuItem mởFileMicrostationdngToolStripMenuItem;
        private ToolStripMenuItem exportToCadToolStripMenuItem1;
        private ToolStripMenuItem chuyểnĐổiDữLiệuToolStripMenuItem;
        private ToolStripMenuItem cậpNhậtDữLiệuĐịaChínhToolStripMenuItem1;
        private ToolStripMenuItem kiểmTraFileDGNMớiToolStripMenuItem1;
        private ToolStripMenuItem chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem;
        private ToolStripMenuItem cậpNhậtDữLiệuToolStripMenuItem;
        private ToolStripMenuItem cậpNhậtDữLiệuQuyHoạchToolStripMenuItem;
        private ToolStripMenuItem kiểmTraFiledgncadshpMớiToolStripMenuItem;
        private ToolStripMenuItem chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem1;
        private ToolStripMenuItem cậpNhậtDữLiệuToolStripMenuItem1;
        private ToolStripMenuItem traCứuThôngTinThửaĐấtToolStripMenuItem;
        private ToolStripMenuItem traCứuThôngTinKiếnTrúcToolStripMenuItem1;
        private ToolStripMenuItem chuyểnĐổiDữLiệuĐườngSangVùngToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem cậpNhậtDữLiệuQuỹĐấtToolStripMenuItem;
        private ToolStripMenuItem kiểmTraFiledgncadshpMớiToolStripMenuItem1;
        private ToolStripMenuItem chuyểnĐổiDữLiệudgncadSangshpToolStripMenuItem2;
        private ToolStripMenuItem chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem;
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
        private ToolStripMenuItem cậpNhậtBảnĐồGiấyToolStripMenuItem;
        private ToolStripMenuItem chuyểnĐổiDữLiệuDạngĐườngSangVùngToolStripMenuItem1;
        public static DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        public OpenFileDialog openFileDialog1;
        private ToolStripMenuItem quảnLýĐạiLýInternetToolStripMenuItem;
        private ToolStripMenuItem cậpNhậtRanhGiớiQuyHoạchToolStripMenuItem2;
        private ToolStripMenuItem chuyểnĐổiHệTọaĐộToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage3;
        public DevExpress.XtraTreeList.TreeList treeList2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private ToolStripMenuItem chuẩnHóaDữLiệuQuỹĐấtToolStripMenuItem;
        private ToolStripMenuItem cậpNhậtDựÁnQuyHoạchToolStripMenuItem1;
        private ToolStripMenuItem cậpNhậtDữLiệuToolStripMenuItem4;
        private ToolStripMenuItem chuyểnĐổiAnnotationSangShapfileToolStripMenuItem;
        private ToolStripMenuItem quảnLýCâyXanhBóngMátToolStripMenuItem;
        private ToolStripMenuItem quảnLýThảmCỏToolStripMenuItem;
        private ToolStripMenuItem quảnLýCâyTrangTríToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem quảnLýĐơnVịChămSócToolStripMenuItem;
        private ToolStripMenuItem quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem;
        private ToolStripMenuItem quảnLýCôngViênToolStripMenuItem;
        private ToolStripMenuItem quảnLýLoạiChămSócToolStripMenuItem;
        private ToolStripMenuItem quảnLýChủngLoạiCâyXanhToolStripMenuItem;
        private ToolStripMenuItem qảunLýTrạmToolStripMenuItem;
        private ToolStripMenuItem quảnLýLoạiTrạmToolStripMenuItem;
        private ToolStripMenuItem quảnLýChủĐầuTưToolStripMenuItem;
        private ToolStripMenuItem quảnLýĐạiLýToolStripMenuItem;
        private ToolStripMenuItem quảnLýNhàMạngToolStripMenuItem;
        private ToolStripMenuItem quảnLýChủĐạiLýToolStripMenuItem;
        private ToolStripMenuItem quảnLýCapViễnThôngToolStripMenuItem;
        private ToolStripMenuItem quảnLýTuyếnCápNgầmToolStripMenuItem;
        private ToolStripMenuItem quảnLýTuyếnCápTreoToolStripMenuItem;
        private ToolStripMenuItem quảnLýBểCápToolStripMenuItem;
        private ToolStripMenuItem quảnLýCộtCápTreoToolStripMenuItem;
        private ToolStripMenuItem quảnLýDoanhNghiệpToolStripMenuItem;
        private ToolStripMenuItem quảnLýThiếtBịPhụTrợToolStripMenuItem;
        private ToolStripMenuItem quảnLýCôngTrìnhHạTầngToolStripMenuItem;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem quảnLýNgườiDùngToolStripMenuItem;
        private ToolStripMenuItem kếtNốiCơSởDữLiệuToolStripMenuItem;
        private ToolStripMenuItem thiếtLậpKếtNốiCơSởDữLiệuToolStripMenuItem;
        private ToolStripMenuItem saoLưuCơSởDữLiệuToolStripMenuItem;
        private ToolStripMenuItem phụcHồiCơSởDữLiệuToolStripMenuItem;
        private ToolStripMenuItem quảnLýHồSơQuyếtĐịnhPhêDuyệtDựÁnToolStripMenuItem;
        private ToolStripMenuItem quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem1;
        private ToolStripMenuItem thôngTinNgườiDùngToolStripMenuItem;
        private ToolStripMenuItem nhậtKíLàmViệcToolStripMenuItem;
        private ToolStripMenuItem quảnLýQuyHoạchKiếnTrúcToolStripMenuItem;
        private ToolStripMenuItem quảnLýThôngTinQuyHoạchToolStripMenuItem;
        private ToolStripMenuItem quảnLýThôngTinKiếnTrúcXâyDựngToolStripMenuItem;
        private ToolStripMenuItem quảnLýCơSởHTKTToolStripMenuItem;
        private ToolStripMenuItem giaoThôngToolStripMenuItem;
        private ToolStripMenuItem đườngGiaoThôngChínhToolStripMenuItem1;
        private ToolStripMenuItem đườngKiệtHẻmToolStripMenuItem1;
        private ToolStripMenuItem điệnChiếuSángToolStripMenuItem;
        private ToolStripMenuItem câyXToolStripMenuItem;
        private ToolStripMenuItem mươngThoátNướcToolStripMenuItem;
        private ToolStripMenuItem côngCụToolStripMenuItem;
        private ToolStripMenuItem thanhCôngCụToolStripMenuItem2;
        private ToolStripMenuItem côngCụCơBảnToolStripMenuItem1;
        private ToolStripMenuItem côngCụChỉnhSửaTrangInToolStripMenuItem1;
        private ToolStripMenuItem côngCụChỉnhSửaDữLiệuToolStripMenuItem1;
        private ToolStripMenuItem tùyChỉnhToolStripMenuItem;
        private ToolStripMenuItem lưuThanhCôngCụToolStripMenuItem1;
        private ToolStripMenuItem bảnĐồNềnGoogleToolStripMenuItem;
        private ToolStripMenuItem ảnhVệTinhToolStripMenuItem;
        private ToolStripMenuItem bưuChínhViễnThôngToolStripMenuItem1;
        private ToolStripMenuItem trạmBTSToolStripMenuItem1;
        private ToolStripMenuItem đạiLýInternetToolStripMenuItem1;
        private ToolStripMenuItem quảnLýHồSơXácNhậnQuyHoạchToolStripMenuItem;
        private ToolStripMenuItem quảnLýHồSơCấpPhépXâyDựngToolStripMenuItem2;
        private ToolStripMenuItem quảnLýCâyXanhToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem quảnLýĐơnVịChămSócToolStripMenuItem1;
        private ToolStripMenuItem quảnLýĐơnVịQuảnLýCâyXanhToolStripMenuItem1;
        private ToolStripMenuItem quảnLýCôngViênToolStripMenuItem1;
        private ToolStripMenuItem quảnLýLoạiChămSócToolStripMenuItem1;
        private ToolStripMenuItem quảnLýChủngLoạiCâyXanhToolStripMenuItem1;
        private ToolStripMenuItem bảnĐồNềnVệTinhToolStripMenuItem;
        private ToolStripMenuItem ảnhVệTinhToolStripMenuItem2;
        private ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem1;
        private ToolStripMenuItem quảnLýThôngTinQuyHoạchChiTiết1500ToolStripMenuItem;
        private ToolStripMenuItem quảnLýThôngTinQuyHoạchPhânKhuToolStripMenuItem;
        private ToolStripMenuItem quảnLýThôngTinQuyHoạchChungToolStripMenuItem;
        private ToolStripMenuItem biểnBáoToolStripMenuItem;
        private ToolStripMenuItem cầuĐườngBộToolStripMenuItem;
        private ToolStripMenuItem vỉaHèToolStripMenuItem;
        private ToolStripMenuItem côngCụCơBảnToolStripMenuItem2;
        private ToolStripMenuItem côngCụChỉnhSửaTrangInToolStripMenuItem2;
        private ToolStripMenuItem côngCụChỉnhSửaDữLiệuToolStripMenuItem2;
        private ToolStripMenuItem tùyChỉnhToolStripMenuItem2;
        private ToolStripMenuItem lưuThanhCôngCụToolStripMenuItem2;
        private ToolStripMenuItem quảnLýTàiNguyênToolStripMenuItem;
        private ToolStripMenuItem quảnLýTàiNguyênNướcToolStripMenuItem;
        private ToolStripMenuItem quảnLýHồChứaToolStripMenuItem;
        private ToolStripMenuItem quảnLýTrạmBơmToolStripMenuItem;
        private ToolStripMenuItem quảnLýĐậpDângToolStripMenuItem;
        private ToolStripMenuItem quảngLýLoạiKênhToolStripMenuItem;
        private ToolStripMenuItem quảnLýCấpPhépKhaiThácToolStripMenuItem;
        private ToolStripMenuItem quảnLýCấpPhépXảThảiToolStripMenuItem;
        private ToolStripMenuItem quảnLýTàiNguyênĐấtToolStripMenuItem;
        private ToolStripMenuItem quảnLýTàiNguyênKhoángSảnToolStripMenuItem;
        private ToolStripMenuItem quảnLýCấpPhépKhaiThácNướcNgầmToolStripMenuItem;
        private ToolStripMenuItem quảnLýQuyHoạchKhoángSảnToolStripMenuItem;
        private ToolStripMenuItem quảnLýQuyHoạchVùngCấmTạmCấmToolStripMenuItem;
        private ToolStripMenuItem quảnLýHoạtĐộngKhaiThácToolStripMenuItem;
        private ToolStripMenuItem quảnLýHồSơToolStripMenuItem;
        private ToolStripMenuItem hốGaToolStripMenuItem;
        private ToolStripMenuItem mươngThoátNướcChinhToolStripMenuItem;
        private ToolStripMenuItem mươngThoátNướcKiệtHẻmToolStripMenuItem;
        private ToolStripMenuItem điệnChiếuSángChínhToolStripMenuItem;
        private ToolStripMenuItem tuyếnDâyĐiệnChínhToolStripMenuItem1;
        private ToolStripMenuItem trụĐiệnChiếuSángChínhToolStripMenuItem1;
        private ToolStripMenuItem điệnChiếuSángKiệtHẻmToolStripMenuItem;
        private ToolStripMenuItem tuyếnDâyĐiệnKiệtHẻmToolStripMenuItem;
        private ToolStripMenuItem trụĐiệnChiếuSángKiệtHẻmToolStripMenuItem;
        private ToolStripMenuItem hốGaChínhKiệtHẻmToolStripMenuItem;
        private ToolStripMenuItem quảnLýBiểnBáoToolStripMenuItem;
        private ToolStripMenuItem quảnLýLoạiBiểnBáoToolStripMenuItem;
        private ComboBox comboBox3;
        private ToolStripMenuItem chuyểnĐổiTừHN72VN2000ToolStripMenuItem;
        private ToolStripMenuItem chuyểnĐổiTừVN2000WGS84ToolStripMenuItem;
        private ToolStripMenuItem chuyểnĐổiTừWGS84VN2000ToolStripMenuItem;
        private ToolStripMenuItem thêmUrlFileĐínhKèmToolStripMenuItem;
        private ToolStripMenuItem updateDiaChinhToolStripMenuItem;
        private ToolStripMenuItem quảnLýPhòngBanToolStripMenuItem;
        private ToolStripMenuItem cậpNhậtTọaĐộCâyXanhToolStripMenuItem;
        public static DevExpress.XtraTreeList.TreeList treeList1;
        public static ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        public static ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        public static ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
    }
}
