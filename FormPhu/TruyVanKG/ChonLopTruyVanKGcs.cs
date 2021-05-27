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

namespace QLHTDT.FormPhu.TruyVanKG
{
    public partial class ChonLopTruyVanKGcs : Form
    {
        string lop;
        string phuong;
        public static string TenLop;
        public static object a;
        public ChonLopTruyVanKGcs()
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
            //TenLop = comboBox1.GetItemText(comboBox1.SelectedItem);
            //a = comboBox1.SelectedValue;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Thửa đất")
            { lop = "Chia lô - "; }
            else if (comboBox1.SelectedItem.ToString() == "Khu quy hoạch")
            { lop = "Ranh giới quy hoạch - "; }
            else { lop = comboBox1.SelectedItem.ToString() + " - "; }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Hòa An")
            { phuong = "HA"; }
            else if (comboBox2.SelectedItem.ToString() == "Hòa Phát")
            { phuong = "HP"; }
            else if (comboBox2.SelectedItem.ToString() == "Hòa Thọ Tây")
            { phuong = "HTT"; }
            else if (comboBox2.SelectedItem.ToString() == "Hòa Thọ Đông")
            { phuong = "HTD"; }
            else if (comboBox2.SelectedItem.ToString() == "Hòa Xuân")
            { phuong = "HX"; }
            else if (comboBox2.SelectedItem.ToString() == "Khuê Trung")
            { phuong = "KT"; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IActiveView pActiveView;
                pActiveView = KienTruc.axMapControl1.ActiveView;
                Global.pActiveView = pActiveView;
                TenLop = lop + phuong;
                ILayer pLayer = Global.getLayerbyName(Global.pActiveView.FocusMap, ChonLopTruyVanKGcs.TenLop);
                if (pLayer == null)
                {
                    KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + comboBox2.SelectedItem.ToString() + "\\" + TenLop + ".lyr");
                    KienTruc.axMapControl1.Extent = KienTruc.axMapControl1.get_Layer(0).AreaOfInterest;
                }
                this.Visible = false;
            }
            catch
            {
                MessageBox.Show("Chưa chọn lớp dữ liệu, vui lòng thử lại", "Thông báo");
            }
        }

       
    }
}
