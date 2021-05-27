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
    public partial class FrmChuyenHeToaDo : Form
    {
        System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
        System.Windows.Forms.SaveFileDialog SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
        public FrmChuyenHeToaDo()
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
                comboBox5.Text = openFileDialog.FileName;
                CoppyShape = openFileDialog.FileName;
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
        string CoppyShape;
        private void button3_Click(object sender, EventArgs e)
        {
             bool isNumeric;
            double KinhTuyenTruc1;
            double MuiChieu1;
            double KinhTuyenTruc2;
            string MuiChieu2;
            if (comboBox1.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                return;
            }
            if (isNumeric = double.TryParse(comboBox1.Text, out KinhTuyenTruc1))
            { }
            else
            {
                MessageBox.Show("Sai định dạng dữ liệu Kinh tuyến trục!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                Cursor = Cursors.Default;
                return;
            }
            if (isNumeric = double.TryParse(comboBox4.Text, out KinhTuyenTruc2))
            { }
            else
            {
                MessageBox.Show("Sai định dạng dữ liệu Kinh tuyến trục!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                Cursor = Cursors.Default;
                return;
            }
            if (comboBox3.Text == "3 độ")
            {
                MuiChieu2 = "0.9999";
            }
            else
            {
                MuiChieu2 = "0.9996";
            }
            QLHTDT.FormChinh.KienTruc.mapCooker.ClearAll();
            string path = @"C:\Windows\Temp\convertplltoplg.py";
            string filewwgs84 = @"C:\Windows\Temp\DiemWGS84" + DateTime.Now.ToString("HHmmss") + ".shp";
            string DiemHN72 = @"C:\Windows\Temp\DiemHN72" + DateTime.Now.ToString("HHmmss") + ".shp";
            string SHPVN2000 = SaveFileDialog.FileName;
            //string toolbox = ""+ QLHTDT.Properties.Settings.Default.PathData + "\\Toolbox.tbx"; //chỗ lưu trữ toolbox không được có số và việtkey
            string Disabled = "Disabled";
            Cursor = Cursors.WaitCursor;
            try
            {
                if (File.Exists(path))
                { File.Delete(path); }
                else { }
                using (System.IO.FileStream fs = File.Create(path))
                {
                    //string py = "import arcpy" + Environment.NewLine +
                    //    "arcpy.ImportToolbox(\"" + toolbox + "\")" + Environment.NewLine +
                    //    "DiemHN72 = \"" + DiemHN72 + "\"" + Environment.NewLine +
                    //    "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                    //    "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                    //    "wgs84shp = \"" + filewwgs84 + "\"" + Environment.NewLine +
                    //    "SHPVN2000 = \"" + SHPVN2000 + "\"" + Environment.NewLine +
                    //    "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                    //    "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                    //    "Output_Dataset_or_Feature_Class = \"" + DiemHN72 + "\"" + Environment.NewLine +
                    //    "Output_Geographic_Coordinate_System =  \"GEOGCS['GCS_WGS_1984', DATUM['D_WGS_1984', SPHEROID['WGS_1984', 6378137.0, 298.257223563]], PRIMEM['Greenwich', 0.0], UNIT['Degree', 0.0174532925199433]]\" " + Environment.NewLine +
                    //    "Output_Geographic_Coordinate_System__2_ = \"PROJCS['VN_2000_UTM_DaNang_Mui3', GEOGCS['GCS_VN_2000', DATUM['D_Vietnam_2000', SPHEROID['WGS_1984', 6378137.0, 298.257223563]], PRIMEM['Greenwich', 0.0], UNIT['Degree', 0.0174532925199433]], PROJECTION['Transverse_Mercator'], PARAMETER['False_Easting', 500000.0], PARAMETER['False_Northing', 0.0], PARAMETER['Central_Meridian', 107.75], PARAMETER['Scale_Factor', 0.9999], PARAMETER['Latitude_Of_Origin', 0.0], UNIT['Meter', 1.0]]\"" + Environment.NewLine +
                    //    "arcpy.DefineProjection_management(DiemHN72, \"PROJCS['hn72DN', GEOGCS['GCS_Hanoi_1972', DATUM['D_Hanoi_1972', SPHEROID['Krasovsky_1940', 6378245.0, 298.3]], PRIMEM['Greenwich', 0.0], UNIT['Degree', 0.0174532925199433]], PROJECTION['Transverse_Mercator'], PARAMETER['False_Easting', 500000.0], PARAMETER['False_Northing', 0.0], PARAMETER['Central_Meridian', 108.0], PARAMETER['Scale_Factor', 1.0], PARAMETER['Latitude_Of_Origin', 0.0], UNIT['Meter', 1.0]]\")" + Environment.NewLine +
                    //    "arcpy.Project_management(Output_Dataset_or_Feature_Class, wgs84shp, Output_Geographic_Coordinate_System, \"hn72towgs\", \"\")" + Environment.NewLine +
                    //    "arcpy.Project_management(wgs84shp, SHPVN2000, \"PROJCS['VN_2000_UTM_DaNang_Mui3',GEOGCS['GCS_VN_2000',DATUM['D_Vietnam_2000',SPHEROID['WGS_1984',6378137.0,298.257223563]],PRIMEM['Greenwich',0.0],UNIT['Degree',0.0174532925199433]],PROJECTION['Transverse_Mercator'],PARAMETER['False_Easting',500000.0],PARAMETER['False_Northing',0.0],PARAMETER['Central_Meridian',107.75],PARAMETER['Scale_Factor',0.9999],PARAMETER['Latitude_Of_Origin',0.0],UNIT['Meter',1.0]]\", \"WGS84ToVN2000\", Output_Geographic_Coordinate_System)" + Environment.NewLine +
                    //     "import arcpy" + Environment.NewLine +
                    //    "fc = r\"" + SHPVN2000 + "\"" + Environment.NewLine +
                    //    "xOffset = -10.54344418841" + Environment.NewLine +
                    //    "yOffset = -1.16767231885" + Environment.NewLine +
                    //    "with arcpy.da.UpdateCursor(fc, [\"SHAPE@XY\"]) as cursor:" + Environment.NewLine +
                    //    "     for row in cursor:cursor.updateRow([[row[0][0] + xOffset,row[0][1] + yOffset]])";
                    string py = "import arcpy" + Environment.NewLine +
                    "InShape = r\"" + CoppyShape + "\"" + Environment.NewLine +
                    "DiemHN72 = r\"" + DiemHN72 + "\"" + Environment.NewLine +
                    "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                    "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                    "wgs84shp = r\"" + filewwgs84 + "\"" + Environment.NewLine +
                    "SHPVN2000 = r\"" + SHPVN2000 + "\"" + Environment.NewLine +
                    "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                    "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                    "arcpy.CopyFeatures_management(InShape, DiemHN72, \"\", \"0\", \"0\", \"0\")" + Environment.NewLine +
                    "Output_Dataset_or_Feature_Class = r\"" + DiemHN72 + "\"" + Environment.NewLine +
                    "Output_Geographic_Coordinate_System =  \"GEOGCS['GCS_WGS_1984', DATUM['D_WGS_1984', SPHEROID['WGS_1984', 6378137.0, 298.257223563]], PRIMEM['Greenwich', 0.0], UNIT['Degree', 0.0174532925199433]]\" " + Environment.NewLine +
                    "Output_Geographic_Coordinate_System__2_ = \"PROJCS['VN_2000_UTM_DaNang_Mui3', GEOGCS['GCS_VN_2000', DATUM['D_Vietnam_2000', SPHEROID['WGS_1984', 6378137.0, 298.257223563]], PRIMEM['Greenwich', 0.0], UNIT['Degree', 0.0174532925199433]], PROJECTION['Transverse_Mercator'], PARAMETER['False_Easting', 500000.0], PARAMETER['False_Northing', 0.0], PARAMETER['Central_Meridian', " + comboBox4.Text + "], PARAMETER['Scale_Factor', " + MuiChieu2 + "], PARAMETER['Latitude_Of_Origin', 0.0], UNIT['Meter', 1.0]]\"" + Environment.NewLine +
                    "arcpy.DefineProjection_management(DiemHN72, \"PROJCS['hn72DN', GEOGCS['GCS_Hanoi_1972', DATUM['D_Hanoi_1972', SPHEROID['Krasovsky_1940', 6378245.0, 298.3]], PRIMEM['Greenwich', 0.0], UNIT['Degree', 0.0174532925199433]], PROJECTION['Transverse_Mercator'], PARAMETER['False_Easting', 500000.0], PARAMETER['False_Northing', 0.0], PARAMETER['Central_Meridian', " + comboBox1.Text + "], PARAMETER['Scale_Factor', 1.0], PARAMETER['Latitude_Of_Origin', 0.0], UNIT['Meter', 1.0]]\")" + Environment.NewLine +
                    "arcpy.Project_management(Output_Dataset_or_Feature_Class, wgs84shp, Output_Geographic_Coordinate_System, \"hn72towgs\", \"\")" + Environment.NewLine +
                    "arcpy.Project_management(wgs84shp, SHPVN2000, \"PROJCS['VN_2000_UTM_DaNang_Mui3',GEOGCS['GCS_VN_2000',DATUM['D_Vietnam_2000',SPHEROID['WGS_1984',6378137.0,298.257223563]],PRIMEM['Greenwich',0.0],UNIT['Degree',0.0174532925199433]],PROJECTION['Transverse_Mercator'],PARAMETER['False_Easting',500000.0],PARAMETER['False_Northing',0.0],PARAMETER['Central_Meridian'," + comboBox4.Text + "],PARAMETER['Scale_Factor'," + MuiChieu2 + "],PARAMETER['Latitude_Of_Origin',0.0],UNIT['Meter',1.0]]\", \"WGS84ToVN2000\", Output_Geographic_Coordinate_System)" + Environment.NewLine +
                     "import arcpy" + Environment.NewLine +
                    "fc = r\"" + SHPVN2000 + "\"" + Environment.NewLine +
                    "xOffset = -10.54344418841" + Environment.NewLine +
                    "yOffset = -1.16767231885" + Environment.NewLine +
                    "with arcpy.da.UpdateCursor(fc, [\"SHAPE@XY\"]) as cursor:" + Environment.NewLine +
                    "     for row in cursor:cursor.updateRow([[row[0][0] + xOffset,row[0][1] + yOffset]])";
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

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(comboBox3.Text, "  ^ [0-9]"))
            {
                comboBox4.Text = "";
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void FrmChuyenHeToaDo_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            {
                comboBox5.Items.Add(KienTruc.axMapControl1.get_Layer(i).Name);
            }
        }

        private void FrmChuyenHeToaDo_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < KienTruc.axMapControl1.LayerCount; i++)
            {
                if (KienTruc.axMapControl1.get_Layer(i).Name == comboBox5.Text)
                {
                    if (comboBox5.Text == KienTruc.axMapControl1.get_Layer(i).Name)
                    {
                        ILayer Li = KienTruc.axMapControl1.get_Layer(i);
                        IFeatureLayer ftLayer = Li as IFeatureLayer;
                        ESRI.ArcGIS.Geodatabase.IDataset dataset = (ESRI.ArcGIS.Geodatabase.IDataset)(Li); // Explicit Cast
                        CoppyShape = (dataset.Workspace.PathName + "\\" + dataset.Name + ".shp");
                    }
                    else
                    {
                        ILayer Li = KienTruc.axMapControl1.get_Layer(i);
                        IFeatureLayer ftLayer = Li as IFeatureLayer;
                        ESRI.ArcGIS.Geodatabase.IDataset dataset = (ESRI.ArcGIS.Geodatabase.IDataset)(Li); // Explicit Cast
                        CoppyShape = (dataset.Workspace.PathName + "\\" + dataset.Name + ".shp");
                    }
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
