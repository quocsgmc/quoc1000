using DevExpress.XtraTreeList.Nodes;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using QLHTDT.FormChinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.CapNhatQuyDat
{
    public partial class FrmThemMoiQuyDatQH : Form
    {
        IFeatureClass featureClass;
        OpenFileDialog openFileDialogFileShape = new System.Windows.Forms.OpenFileDialog();
        IFeatureClass featureClassDA;
        IFeatureClass featureClassQD;
        string objectidDAQH = "";
        public FrmThemMoiQuyDatQH()
        {
            InitializeComponent();
            openFileDialogFileShape.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogFileShape_FileOk);
            openFileDialogFileShape.Filter = "Shapefile|*.shp";
            openFileDialogFileShape.Title = "Chọn file Shapefile cần mở";
            for (int i = 0; i < QuanTriHeThong.axMapControl1.LayerCount; i++)
            {
                CboChonShp2.Items.Add(QuanTriHeThong.axMapControl1.get_Layer(i).Name);
            }
        }
        private CORE.Geodatabase _Geodatabase;
        private void openFileDialogFileShape_FileOk(object sender, CancelEventArgs e)
        {
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialogFileShape.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialogFileShape.FileName);
            IFeatureWorkspace_OpenFeatureClass(workspacePath, fileName);
            getFieldFeatureClass();

        }
        public void IFeatureWorkspace_OpenFeatureClass(string dataPath, string nameOfShapefile)
        {
            IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(dataPath, 0);
            featureClass = featureWorkspace.OpenFeatureClass(nameOfShapefile);
            //Console.WriteLine("There are {0} features in the {1} feature class", featureClass.FeatureCount(new QueryFilterClass()), featureClass.AliasName);
        }
        private void CboChonShp2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < QuanTriHeThong.axMapControl1.LayerCount; i++)
            {

                if (QuanTriHeThong.axMapControl1.get_Layer(i).Name == CboChonShp2.Text)
                {
                    ILayer Li = QuanTriHeThong.axMapControl1.get_Layer(i);
                    IFeatureLayer ftLayer = Li as IFeatureLayer;
                    featureClass = ftLayer.FeatureClass;
                    getFieldFeatureClass();
                }
            }
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
        private void btMo2_Click_1(object sender, EventArgs e)
        {
            openFileDialogFileShape.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmThemMoiQuyDatQH_Load(object sender, EventArgs e)
        {
            _Geodatabase = new CORE.Geodatabase();
            _Geodatabase.ConnectFile(@"C:\Users\sinhn\AppData\Roaming\ESRI\Desktop10.2\ArcCatalog\LISTDCTTCNTT.sde");
            featureClassDA = _Geodatabase.FeatureWorkspace.OpenFeatureClass("DUANQH");
            featureClassQD = _Geodatabase.FeatureWorkspace.OpenFeatureClass("QUYDATQH");
            getvaluefield(featureClassDA, "tenDuAn");

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            IFeatureLayer pFeatureLayer2 = new FeatureLayerClass();
            pFeatureLayer2.FeatureClass = featureClassDA;
            IFeatureSelection featSelect = pFeatureLayer2 as IFeatureSelection;
            IQueryFilter pFilter = new QueryFilterClass();
            pFilter.WhereClause = "tenDuAn = N'" + comboBox1.Text + "'";
            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            IEnumIDs idList2 = featSelect.SelectionSet.IDs;
            int index2 = idList2.Next();
            List<int> indexes2 = new List<int>();
            while (index2 != -1)
            {
                indexes2.Add(index2);
                index2 = idList2.Next();
            }
            IFeature feature = featureClassDA.GetFeature(indexes2[0]);
            objectidDAQH = feature.get_Value(feature.Fields.FindField("OBJECTID")).ToString();
        }

        public void getvaluefield(IFeatureClass fc, string field)
        {
            ICursor cursor = (ICursor)fc.Search(null, false);
            IDataStatistics dataStatistics = new DataStatisticsClass();
            dataStatistics.Field = field;
            dataStatistics.Cursor = cursor;
            System.Collections.IEnumerator enumerator = dataStatistics.UniqueValues;
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                object myObject = enumerator.Current;
                comboBox1.Items.Add(myObject);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QuanTriHeThong.splashScreenManager1.ShowWaitForm();
            //ftClassSDE = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("DUANQH");
            for (int i = 0; i < featureClass.FeatureCount(null); i++)
            {
                IFeature ifeshp = featureClass.GetFeature(i);
                IFeature feature = featureClassQD.CreateFeature();
                feature.Shape = ifeshp.Shape;
                ISubtypes subtypes = (ISubtypes)featureClassQD;
                IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
                if (subtypes.HasSubtype)
                {
                    rowSubtypes.SubtypeCode = 3;
                }
                rowSubtypes.InitDefaultValues();
                int MaDuAn = featureClassQD.FindField("loaiQuyDatId");
                if (((TreeListNode)treeList2.Nodes[0]).GetDisplayText(treeList2.Columns[1]) != "")
                { feature.set_Value(MaDuAn, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[0]).GetDisplayText(treeList2.Columns[1]))).ToString()); }
                else { feature.set_Value(MaDuAn, null); }
                /////
                int maXa = featureClassQD.FindField("maXa");
                //if (((TreeListNode)treeList2.Nodes[1]).GetDisplayText(treeList2.Columns[1]) != "")
                //{
                    //feature.set_Value(maXa, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[1]).GetDisplayText(treeList2.Columns[1]))).ToString());
                    feature.set_Value(maXa, "20314");
                //}
                //else { feature.set_Value(maXa, null); }
                ////
                int phanKhu = featureClassQD.FindField("phanKhu");
                if (((TreeListNode)treeList2.Nodes[2]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(phanKhu, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[2]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(phanKhu, null); }

                int soHieuLoDat = featureClassQD.FindField("soHieuLoDat");
                if (((TreeListNode)treeList2.Nodes[3]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(soHieuLoDat, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[3]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(soHieuLoDat, null); }

                int soThuTuLoDat = featureClassQD.FindField("soThuTuLoDat");
                if (((TreeListNode)treeList2.Nodes[4]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(soThuTuLoDat, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[4]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(soThuTuLoDat, null); }

                int dienTich = featureClassQD.FindField("dienTich");
                if (((TreeListNode)treeList2.Nodes[6]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(dienTich, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[6]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(dienTich, null); }

                int viTriDacDiemLoDat = featureClassQD.FindField("viTriDacDiemLoDat");
                if (((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(viTriDacDiemLoDat, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(viTriDacDiemLoDat, null); }

                int duong = featureClassQD.FindField("duong");
                if (((TreeListNode)treeList2.Nodes[5]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(duong, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[5]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(duong, null); }

                int tinhTrang = featureClassQD.FindField("tinhTrang");
                feature.set_Value(tinhTrang, 0);

                int trangThai = featureClassQD.FindField("trangThai");
                feature.set_Value(trangThai, 1);

                int coDatThucTe = featureClassQD.FindField("coDatThucTe");
                if (((TreeListNode)treeList2.Nodes[9]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(coDatThucTe, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[9]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(coDatThucTe, null); }

                int moTa = featureClassQD.FindField("moTa");
                if (((TreeListNode)treeList2.Nodes[8]).GetDisplayText(treeList2.Columns[1]) != "")
                {
                    feature.set_Value(moTa, ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[8]).GetDisplayText(treeList2.Columns[1]))).ToString());
                }
                else { feature.set_Value(moTa, null); }

                int IDDuAnQH = featureClassQD.FindField("IDDuAnQH");
                //if (((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]) != "")
                //{
                    //if (int.TryParse(ifeshp.get_Value(ifeshp.Fields.FindField(((TreeListNode)treeList2.Nodes[7]).GetDisplayText(treeList2.Columns[1]))).ToString(), out dt))
                feature.set_Value(IDDuAnQH, objectidDAQH);

                int NgayChinhSua = featureClassQD.FindField("ngayChinhSua");
                feature.set_Value(NgayChinhSua, DateTime.Now.ToString("yy/MM/dd"));
                //}
                //else { feature.set_Value(IDDuAnQH, null); }

                feature.Store();
            }

            QuanTriHeThong.splashScreenManager1.CloseWaitForm();
            MessageBox.Show("Thêm mới Quỹ đất quy hoạch vào dự án "+ comboBox1.Text+ " thành công", "Thông báo");
            QuanTriHeThong.axMapControl1.Refresh();
            this.Hide();
        }
    }
}
