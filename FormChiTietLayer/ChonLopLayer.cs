using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using QLHTDT.FormChinh;
using ESRI.ArcGIS.Geodatabase;

namespace QLHTDT.FormPhu.FormChiTietLayer
{
    public partial class ChonLopLayer : Form
    {
        string phuong;
        public static string TenLop = "Ranh giới quy hoạch chi tiết";
        string Folder = "Quy hoạch chi tiết 1.500";
        public static object a;
        public ChonLopLayer()
        {
            InitializeComponent();
            LoadLayertoCbo2();
        }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        private void LoadLayertoCbo2()
        {
            //QLHTDT.CORE.LoadLayer.LoadFeaturelayerToCombo(comboBox1, QLHTDT.FormChinh.KienTruc.axMapControl1.Map);
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
        }
  
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Ranh giới quy hoạch chi tiết":
                    TenLop = "Ranh giới quy hoạch chi tiết";
                    Folder = "Quy hoạch chi tiết 1.500";
                    break;
                case "Ranh giới quy hoạch phân khu":
                    TenLop = "Ranh giới quy hoạch phân khu";
                    Folder = "Quy hoạch phân khu 1.5000";
                    break;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IActiveView pActiveView;
                pActiveView = KienTruc.axMapControl1.ActiveView;
                Global.pActiveView = pActiveView;
                ILayer pLayer = Global.getLayerbyName(Global.pActiveView.FocusMap, ChonLopLayer.TenLop);
                if (pLayer == null)
                {
                    KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + Folder + "\\" + TenLop + ".lyr");
                    //KienTruc.axMapControl1.Extent = KienTruc.axMapControl1.get_Layer(0).AreaOfInterest;
                }
                this.Visible = false; 
            }
            catch
            {
                MessageBox.Show("Không có lớp dữ liệu nào, vui lòng thử lại", "Thông báo");
            }
        }

        private void ChonLopLayer_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            //    {
            //        comboBox1.Items.Add(KienTruc.axMapControl1.get_Layer(i).Name);
            //    }
            //    comboBox1.Text = KienTruc.axMapControl1.get_Layer(0).Name;
            //}
            //catch { }

        }
    }
}
