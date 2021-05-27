using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using ESRI.ArcGIS.Geodatabase;
using QLHTDT.FormChinh;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class FrmChonDoiTuong : Form
    {
        object[] lop = new string[] { "Chọn lớp dữ liệu" };
        ArrayList list = new ArrayList();
        ArrayList list2 = new ArrayList();
        int dangdt = 0;
        public FrmChonDoiTuong()
        {
            InitializeComponent();
            
        }
        public FrmChonDoiTuong(ArrayList l, int lopdt)
        {
            InitializeComponent();
            list = l;
            for (int i = 0; i < list.Count; i++)
            {
                treeList1.AppendNode(new object[] {
            list[i].ToString(),
            "Chọn lớp dữ liệu"}, -1);

            }
            dangdt = lopdt;
            //Dictionary<string, string> test = new Dictionary<string, string>();
            //test.Add("1", "dfdfdf");
            //test.Add("2", "dfdfdf");
            //test.Add("3", "dfdfdf");
            //comboBox1.DataSource = new BindingSource(test, null);
            //comboBox1.DisplayMember = "Value";
            //comboBox1.ValueMember = "Key";

            //QLHTDT.FormPhu.TruyVanKG.ChonLopTruyVanKGcs.ComboboxItem item = new QLHTDT.FormPhu.TruyVanKG.ChonLopTruyVanKGcs.ComboboxItem();
            //item.Text = "Item text1";
            //item.Value = 12;
            repositoryItemComboBox1.Items.Clear();
            repositoryItemComboBox1.Items.AddRange(lop);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            repositoryItemComboBox1.Items.Clear();
            list2.Clear();
            if (comboBox1.SelectedItem.ToString() == "Hòa An")
            {
                if (dangdt == 1)
                {
                    IFeatureClass featureClass = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("MBQH_HA_Line");
                    getvaluefield(featureClass, list2,"layer");
                    for (int i =0; i < list2.Count; i++)
                    { repositoryItemComboBox1.Items.Add(list2[i]); }
                    //lop = new string[] { "Lề đường", "Lòng đường", "Mương thoát nước", "Tim đường" };
                }
                else if (dangdt == 2)
                {
                    IFeatureClass featureClass = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("MatBangQHHoaAn");
                    getvaluefield(featureClass, list2,"LoaiDat");
                    for (int i = 0; i < list2.Count; i++)
                    { repositoryItemComboBox1.Items.Add(list2[i]); }
                    //lop = new string[] { "Cây xanh", "Chia lô", "Chỉnh trang", "Công trình", "Công viên", "Giáo dục", "Nghĩa trang", "Biệt thự", "Mặt nước", "Chung cư", "Công nghiệp", "An ninh quốc phòng", "Hành lang an toàn" };
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Hòa Phát")
            {
                if (dangdt == 1)
                {
                    IFeatureClass featureClass = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("MBQH_HP_Line");
                    getvaluefield(featureClass, list2, "layer");
                    for (int i = 0; i < list2.Count; i++)
                    { repositoryItemComboBox1.Items.Add(list2[i]); }
                }
                else if (dangdt == 2)
                {
                    IFeatureClass featureClass = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("MatBangQHHoaPhat");
                    getvaluefield(featureClass, list2, "LoaiDat");
                    for (int i = 0; i < list2.Count; i++)
                    { repositoryItemComboBox1.Items.Add(list2[i]); }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Hòa Thọ Tây")
            {
                if (dangdt == 1)
                {
                    IFeatureClass featureClass = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("MBQH_HTT_Line");
                    getvaluefield(featureClass, list2, "layer");
                    for (int i = 0; i < list2.Count; i++)
                    { repositoryItemComboBox1.Items.Add(list2[i]); }
                }
                else if (dangdt == 2)
                {
                    IFeatureClass featureClass = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("MatBangQHHoaThoTay");
                    getvaluefield(featureClass, list2, "LoaiDat");
                    for (int i = 0; i < list2.Count; i++)
                    { repositoryItemComboBox1.Items.Add(list2[i]); }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Hòa Thọ Đông")
            {
                if (dangdt == 1)
                {
                    IFeatureClass featureClass = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("MBQH_HTD_Line");
                    getvaluefield(featureClass, list2, "layer");
                    for (int i = 0; i < list2.Count; i++)
                    { repositoryItemComboBox1.Items.Add(list2[i]); }
                }
                else if (dangdt == 2)
                {
                    IFeatureClass featureClass = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("MatBangQHHoaThoDong");
                    getvaluefield(featureClass, list2, "LoaiDat");
                    for (int i = 0; i < list2.Count; i++)
                    { repositoryItemComboBox1.Items.Add(list2[i]); }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Hòa Xuân")
            {
                if (dangdt == 1)
                {
                    IFeatureClass featureClass = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("MBQH_HX_Line");
                    getvaluefield(featureClass, list2, "layer");
                    for (int i = 0; i < list2.Count; i++)
                    { repositoryItemComboBox1.Items.Add(list2[i]); }
                }
                else if (dangdt == 2)
                {
                    IFeatureClass featureClass = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("MatBangQHHoaXuan");
                    getvaluefield(featureClass, list2, "LoaiDat");
                    for (int i = 0; i < list2.Count; i++)
                    { repositoryItemComboBox1.Items.Add(list2[i]); }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Khuê Trung")
            {
                if (dangdt == 1)
                {
                    IFeatureClass featureClass = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("MBQH_KT_Line");
                    getvaluefield(featureClass, list2, "layer");
                    for (int i = 0; i < list2.Count; i++)
                    { repositoryItemComboBox1.Items.Add(list2[i]); }
                }
                else if (dangdt == 2)
                {
                    IFeatureClass featureClass = QuanTriHeThong.FeatureWorkspace.OpenFeatureClass("MatBangQHKhueTrung");
                    getvaluefield(featureClass, list2, "LoaiDat");
                    for (int i = 0; i < list2.Count; i++)
                    { repositoryItemComboBox1.Items.Add(list2[i]); }
                }
            } 
            //repositoryItemComboBox1.Items.Clear();
            //repositoryItemComboBox1.Items.AddRange(lop);
        }
        public void getvaluefield(IFeatureClass fc, ArrayList Treelist, string field)
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
                Treelist.Add(myObject);
            }
        }

    }
}
