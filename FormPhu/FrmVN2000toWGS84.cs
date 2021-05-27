using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.AnalysisTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.Carto;
using QLHTDT.FormChinh;

namespace QLHTDT.FormPhu
{
    public partial class FrmVN2000toWGS84 : Form
    {
        System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
        System.Windows.Forms.SaveFileDialog SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
        public FrmVN2000toWGS84()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                comboBox3.Text = openFileDialog.FileName;
                InShape = openFileDialog.FileName;
                //FormChinh.KienTruc.axMapControl1.AddLayerFromFile(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            SaveFileDialog.FilterIndex = 2;
            SaveFileDialog.RestoreDirectory = true;


            if (SaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = SaveFileDialog.FileName;
            }
        }
        string InShape;
        private void button3_Click(object sender, EventArgs e)
        {
            bool isNumeric;
            double KinhTuyenTruc;
            string MuiChieu;
            if (comboBox1.Text == ""|| comboBox2.Text == "" || comboBox3.Text == ""|| textBox2.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin","Thông báo");
                return;
            }
            if (isNumeric = double.TryParse(comboBox1.Text, out KinhTuyenTruc))
            { }
            else
            {
                MessageBox.Show("Sai định dạng dữ liệu Kinh tuyến trục!\n" + "Vui lòng kiểm tra lại dữ liệu"
                    , "Thông báo");
                Cursor = Cursors.Default;
                return;
            }
            if(comboBox2.Text == "3 độ")
            {
                MuiChieu = "0.9999";
            }
            else
            {
                MuiChieu = "0.9996";
            }
            QLHTDT.FormChinh.KienTruc.mapCooker.ClearAll();
            string path = @"C:\Windows\Temp\convertplltoplg.py";
            string InShapeCoppy = @"C:\Windows\Temp\InShapeCoppy" + DateTime.Now.ToString("HHmmss") + ".shp";
            string Save = SaveFileDialog.FileName;
            Cursor = Cursors.WaitCursor;
            try
            {
                if (File.Exists(path))
                { File.Delete(path); }
                else { }
                using (System.IO.FileStream fs = File.Create(path))
                {
                    string py = "import arcpy" + Environment.NewLine +
                    "SanPham = r\"" + Save + "\"" + Environment.NewLine +
                    "InShape = r\"" + InShape + "\"" + Environment.NewLine +
                    "CoppyInShape = r\"" + InShapeCoppy + "\"" + Environment.NewLine +
                    "VN2000 = r\"" + InShapeCoppy + "\"" + Environment.NewLine +
                    "arcpy.CopyFeatures_management(InShape, CoppyInShape, \"\", \"0\", \"0\", \"0\")" + Environment.NewLine +
                    "arcpy.DefineProjection_management(CoppyInShape, \"PROJCS['VN_2000_UTM_DaNang_Mui3',GEOGCS['GCS_VN_2000',DATUM['D_Vietnam_2000',SPHEROID['WGS_1984',6378137.0,298.257223563]],PRIMEM['Greenwich',0.0],UNIT['Degree',0.0174532925199433]],PROJECTION['Transverse_Mercator'],PARAMETER['False_Easting',500000.0],PARAMETER['False_Northing',0.0],PARAMETER['Central_Meridian',"+comboBox1.Text+"],PARAMETER['Scale_Factor',"+MuiChieu+"],PARAMETER['Latitude_Of_Origin',0.0],UNIT['Meter',1.0]]\")" + Environment.NewLine +
                    "arcpy.Project_management(VN2000, SanPham, \"GEOGCS['GCS_WGS_1984',DATUM['D_WGS_1984',SPHEROID['WGS_1984',6378137.0,298.257223563]],PRIMEM['Greenwich',0.0],UNIT['Degree',0.0174532925199433]]\", \"WGS84ToVN2000\", \"\")";
                    Byte[] info = new UTF8Encoding(true).GetBytes(py);
                    fs.Write(info, 0, info.Length);
                }
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = path;
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                }   
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không thể chuyển đổi dữ liệu", "Thông báo");
                }
                MessageBox.Show("Chuyển đổi dữ liệu thành công", "Thông báo");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thiết lập dữ liệu", "Thông báo");
            }

            Cursor = Cursors.Default;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(comboBox1.Text, "  ^ [0-9]"))
            {
                comboBox1.Text = "";
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            {
                if (KienTruc.axMapControl1.get_Layer(i).Name == comboBox3.Text)
                {
                    ILayer Li = KienTruc.axMapControl1.get_Layer(i);
                    IFeatureLayer ftLayer = Li as IFeatureLayer;
                    ESRI.ArcGIS.Geodatabase.IDataset dataset = (ESRI.ArcGIS.Geodatabase.IDataset)(Li); // Explicit Cast
                    InShape = (dataset.Workspace.PathName + "\\" + dataset.Name + ".shp");
                }
            }
        }
    }
}
