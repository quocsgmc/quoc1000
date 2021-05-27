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
    public partial class FrmCapNhatDAQH : Form
    {
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        OpenFileDialog openFileDialogFileShape = new System.Windows.Forms.OpenFileDialog();
        IFeatureClass featureClassDA;
        //IFeatureClass featureClassQD;
        public FrmCapNhatDAQH()
        {
            InitializeComponent();
            openFileDialogFileShape.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogFileShape_FileOk);
            openFileDialogFileShape.Filter = "Shapefile|*.shp";
            openFileDialogFileShape.Title = "Chọn file Shapefile cần mở";
            for (int i = 0; i < QuanTriHeThong.axMapControl1.LayerCount; i++)
            {
                CboChonShp.Items.Add(QuanTriHeThong.axMapControl1.get_Layer(i).Name);
            }
        }
        private void openFileDialogFileShape_FileOk(object sender, CancelEventArgs e)
        {
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialogFileShape.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialogFileShape.FileName);
            IFeatureWorkspace_OpenFeatureClass(workspacePath, fileName);
             getFieldFeatureClass();

        }
        private void getFieldFeatureClass()
        {
            CboMaDuAn.Items.Clear();
            if (featureClass != null)
            {
                for (int i = 0; i < featureClass.Fields.FieldCount; i++)
                { CboMaDuAn.Items.Add(featureClass.Fields.Field[i].Name); }

            }
        }
        public void IFeatureWorkspace_OpenFeatureClass(string dataPath, string nameOfShapefile)
        {
            IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesFile.ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(dataPath, 0);
            featureClass = featureWorkspace.OpenFeatureClass(nameOfShapefile);
        }
        private void CboChonShp2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < QuanTriHeThong.axMapControl1.LayerCount; i++)
            {
                if (QuanTriHeThong.axMapControl1.get_Layer(i).Name == CboChonShp.Text)
                {
                    ILayer Li = QuanTriHeThong.axMapControl1.get_Layer(i);
                    IFeatureLayer ftLayer = Li as IFeatureLayer;
                    featureClass = ftLayer.FeatureClass;
                    getFieldFeatureClass();
                }
            }
        }

        private void CboMaDuAn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btMo2_Click(object sender, EventArgs e)
        {
            openFileDialogFileShape.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CboMaDuAn.Text != "")
            {
                //ftClassSDE = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("DUANQH");
                for (int i = 0; i < featureClass.FeatureCount(null); i++)
                {
                    IFeature featureSDE;
                    IFeature ifeshp = featureClass.GetFeature(i);
                    string MDAShp = ifeshp.get_Value(ifeshp.Fields.FindField(CboMaDuAn.Text)).ToString();
                    if (MDAShp != null)
                    {
                        IQueryFilter queryFilter = new QueryFilterClass();
                        queryFilter.WhereClause = "maDuAn =  '"+MDAShp+"'";
                        ISelectionSet selectionSet = featureClassDA.Select(queryFilter, esriSelectionType.esriSelectionTypeIDSet, esriSelectionOption.esriSelectionOptionNormal, null);
                            IEnumIDs idList = selectionSet.IDs;
                            int index = idList.Next();
                            List<int> indexes = new List<int>();
                            while (index != -1)
                            {
                                indexes.Add(index);
                                index = idList.Next();
                            }
                            for (int i3 = 0; i3 < selectionSet.Count; i3++)
                            {
                                featureSDE = featureClassDA.GetFeature(indexes[i3]);
                                featureSDE.Shape = ifeshp.Shape;
                                featureSDE.Store();
                            }
                    }
                    
                }
            }
            else
            { MessageBox.Show("Chưa chọn trường thuộc tính Mã dự án!", "Thông báo!"); }
            MessageBox.Show("Thêm mới dự án quy hoạch thành công", "Thông báo");
            QuanTriHeThong.axMapControl1.Refresh();
            this.Hide();
        }
        //public void getvaluefield(IFeatureClass fc, string field)
        //{
        //    ICursor cursor = (ICursor)fc.Search(null, false);
        //    IDataStatistics dataStatistics = new DataStatisticsClass();
        //    dataStatistics.Field = field;
        //    dataStatistics.Cursor = cursor;
        //    System.Collections.IEnumerator enumerator = dataStatistics.UniqueValues;
        //    enumerator.Reset();
        //    while (enumerator.MoveNext())
        //    {
        //        object myObject = enumerator.Current;
        //        CboMaDuAn.Items.Add(myObject);
        //    }
        //}
        private CORE.Geodatabase _Geodatabase;
        private void FrmCapNhatDAQH_Load(object sender, EventArgs e)
        {
            _Geodatabase = new CORE.Geodatabase();
            _Geodatabase.ConnectFile(@"C:\Users\sinhn\AppData\Roaming\ESRI\Desktop10.2\ArcCatalog\LISTDCTTCNTT.sde");
            featureClassDA = _Geodatabase.FeatureWorkspace.OpenFeatureClass("DUANQH");
            //featureClassQD = _Geodatabase.FeatureWorkspace.OpenFeatureClass("QUYDATQH");
            
        }
    }
}
