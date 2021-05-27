﻿using DevExpress.XtraTreeList.Nodes;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using QLHTDT.FormChinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.GiaoThong.ThemMoi
{
    public partial class KietHemShapefile : Form
    {
        string typeSDE = "";
        string typeSHP = "";
        IFeatureWorkspace featureWorkspaceSHP;
        public static IFeatureClass featureClassSHP;
        int AddQuan = 0;
        public static string MaHuyen = "null";
        public KietHemShapefile()
        {
            InitializeComponent();
            //featureWorkspaceSDE = (IFeatureWorkspace)workspaceFactory.OpenFromFile(SDEfileLocation, 0);
            openFileDialogFileShape.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogFileShape_FileOk);
            openFileDialogFileShape.Filter = "Shapefile|*.shp";
            openFileDialogFileShape.Title = "Chọn file Shapefile cần mở";
            if (KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = KienTruc.FeatureWorkspace; }
        }
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        OpenFileDialog openFileDialogFileShape = new System.Windows.Forms.OpenFileDialog();
        private void KietHemShapefile_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            {
                CboChonShp2.Items.Add(KienTruc.axMapControl1.get_Layer(i).Name);
            }
            ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("KIETHEM");
            typeSDE = ftClassSDE.ShapeType.ToString();
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            {

                if (KienTruc.axMapControl1.get_Layer(i).Name == CboChonShp2.Text)
                {
                    ILayer Li = KienTruc.axMapControl1.get_Layer(i);
                    IFeatureLayer ftLayer = Li as IFeatureLayer;
                    featureClass = ftLayer.FeatureClass;
                    getFieldFeatureClass();
                }
            }
        }
        private void btMo2_Click(object sender, EventArgs e)
        {
            openFileDialogFileShape.ShowDialog();

        }
        private void openFileDialogFileShape_FileOk(object sender, CancelEventArgs e)
        {
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialogFileShape.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialogFileShape.FileName);
            IFeatureWorkspace_OpenFeatureClass(workspacePath, fileName);
            getFieldFeatureClass();
            CboChonShp2.Text = openFileDialogFileShape.FileName;

            string shapefileLocation = openFileDialogFileShape.FileName;

            if (shapefileLocation != "")
            {

                ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
                featureWorkspaceSHP = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(shapefileLocation), 0);
                featureClassSHP = featureWorkspaceSHP.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(shapefileLocation));
                typeSHP = featureClassSHP.ShapeType.ToString();
                //getvaluefield(featureClassSHP, treeList2, "Layer");
                if (typeSHP != typeSDE) // Kiểm tra lớp dữ liệu có cùng định dạng lớp cần cập nhật
                {
                    MessageBox.Show("Lớp dữ liệu không cùng định dạng với dữ liệu SDE đã chọn", "Thông báo");
                    CboChonShp2.Text = "";
                }
                else
                {
                }

            }

        }
        public void IFeatureWorkspace_OpenFeatureClass(string dataPath, string nameOfShapefile)
        {
            IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(dataPath, 0);
            featureClass = featureWorkspace.OpenFeatureClass(nameOfShapefile);
            //Console.WriteLine("There are {0} features in the {1} feature class", featureClass.FeatureCount(new QueryFilterClass()), featureClass.AliasName);
        }
        private void getFieldFeatureClass()
        {
            repositoryItemComboBox2.Items.Clear();
            if (featureClass != null)
            {
                for (int i = 0; i < featureClass.Fields.FieldCount; i++)
                { repositoryItemComboBox2.Items.Add(featureClass.Fields.Field[i].Name); }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //KienTruc.splashScreenManager1.ShowWaitForm();
            ftClassSDE = KienTruc.FeatureWorkspace.OpenFeatureClass("KIETHEM");
            for (int i = 0; i < featureClass.FeatureCount(null); i++)
            {
                IFeature ifeshp = featureClass.GetFeature(i);
                IFeature feature = ftClassSDE.CreateFeature();
                //chỉnh sửa từ đây
                int index = ifeshp.Fields.FindField("Shape");
                IGeometryDef pGeometryDef;
                pGeometryDef = ifeshp.Fields.get_Field(index).GeometryDef as IGeometryDef;
                bool hasZ = pGeometryDef.HasZ;
                IGeometry b = ifeshp.Shape;
                //HasZ Xóa thuộc tính Z của ifeshp
                if (hasZ)
                {
                    IZAware za = (IZAware)b;
                    za.ZAware = false;
                    za.DropZs();
                }
                //HasM  Xóa thuộc tính M của ifeshp
                bool hasM = pGeometryDef.HasM;
                if (hasM)
                {
                    IMAware zm = (IMAware)b;
                    zm.MAware = false;
                    zm.DropMs();
                }
                //kết thúc ở đây
                feature.Shape = ifeshp.Shape;
                ISubtypes subtypes = (ISubtypes)ftClassSDE;
                IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
                if (subtypes.HasSubtype)
                {
                    rowSubtypes.SubtypeCode = 3;
                }
                rowSubtypes.InitDefaultValues();

                int MaKhuQH = ftClassSDE.FindField("TENKIETHEM");
                if (((TreeListNode)treeList2.Nodes[0]).GetDisplayText(treeList2.Columns[1]) != "")
                { feature.set_Value(MaKhuQH, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[0]).GetDisplayText(treeList2.Columns[1]))).ToString()); }
                else { feature.set_Value(MaKhuQH, null); }

                int TenDuAn = ftClassSDE.FindField("LOAIDUONG");
                if (((TreeListNode)treeList2.Nodes[1]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(TenDuAn, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[1]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(TenDuAn, null); }

                int QDPL = ftClassSDE.FindField("MATCAT");
                if (((TreeListNode)treeList2.Nodes[2]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(QDPL, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[2]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(QDPL, null); }

                int ChuDauTU = ftClassSDE.FindField("CHIEUDAI");
                if (((TreeListNode)treeList2.Nodes[3]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(ChuDauTU, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[3]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(ChuDauTU, null); }

                int NamQDPL = ftClassSDE.FindField("DIEMDAU");
                if (((TreeListNode)treeList2.Nodes[4]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(NamQDPL, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[4]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(NamQDPL, null); }

                int DieuHanhDuAn = ftClassSDE.FindField("DIEMCUOI");
                if (((TreeListNode)treeList2.Nodes[5]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(DieuHanhDuAn, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[5]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(DieuHanhDuAn, null); }

                int Phuong = ftClassSDE.FindField("MaXa");
                if (((TreeListNode)treeList2.Nodes[6]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(Phuong, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[6]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(Phuong, null); }

                int MaDuAn = ftClassSDE.FindField("GhiChu");
                if (((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(MaDuAn, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(MaDuAn, null); }

                feature.Store();
            }

            //KienTruc.splashScreenManager1.CloseWaitForm();
            MessageBox.Show("Thêm mới Kiệt hẻm thành công", "Thông báo");
            KienTruc.axMapControl1.Refresh();
            this.Hide();
        }
    }
}
