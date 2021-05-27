using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;

namespace QLHTDT.axToccontrol
{
    public partial class ThemSymbol1lop : Form
    {
        public static string TenLopThem;
        IFeatureLayer fLayer;
        ITable tb;
        public ThemSymbol1lop()
        {
            InitializeComponent();
            fLayer = QLHTDT.FormChinh.KienTruc.layer as IFeatureLayer;
            tb = fLayer.FeatureClass as ITable;
            QLHTDT.axToccontrol.Table.TableWrapper wratbal = new QLHTDT.axToccontrol.Table.TableWrapper(tb);
        }

        private void ThemSymbol1lop_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < QLHTDT.axToccontrol.Symbology.comboBox2.Items.Count; i++)
            //{
            //    Symbology.comboBox2.SelectedIndex = i;
                
            //    listBox1.Items.Add(Symbology.comboBox2.SelectedText);
                
            //}
            QLHTDT.CORE.LoadLayer.Loadvaluestolistbox2(tb, Symbology.comboBox3.SelectedValue.ToString(), listBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TenLopThem = QLHTDT.axToccontrol.ThemSymbol1lop.listBox1.SelectedItem.ToString();
                this.Hide();
            }
            catch
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
