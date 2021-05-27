using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class ConvertAnnotation : Form
    {
        public ConvertAnnotation()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
        SaveFileDialog SaveFileDialogSave;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Properties.Settings.Default.pathLine;
            openFileDialog.Filter = "Autocad (*.dwg)|*.DWG";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string shapefileLocation = openFileDialog.FileName;
                txt1.Text = shapefileLocation;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialogSave = new System.Windows.Forms.SaveFileDialog();
            SaveFileDialogSave.Filter = "Shape file|*.shp| All files (*.*)|*.*";
            SaveFileDialogSave.InitialDirectory = Properties.Settings.Default.pathPolygon;
            SaveFileDialogSave.FileOk += new System.ComponentModel.CancelEventHandler(SaveFileDialogSave1);
            SaveFileDialogSave.CheckPathExists = true;
            SaveFileDialogSave.ShowDialog();
        }
        private void SaveFileDialogSave1(object sender, CancelEventArgs e)
        {
            //add object file to listbox1
            Cursor = Cursors.WaitCursor;
            txt2.Text = SaveFileDialogSave.FileName;
            Cursor = Cursors.Default;
        }

        private void btChuyen_Click(object sender, EventArgs e)
        {
            //this.Hide();
            string path = @"C:\Windows\Temp\convertplltoplg.py";
            string Autocad = @""+ txt1.Text+ "" + "\\Annotation";
            string Annotation = @""+txt2.Text+"";
            string Disabled = "Disabled";
            
            try
            {
                if (File.Exists(path))
                { File.Delete(path); }
                else { }
                using (System.IO.FileStream fs = File.Create(path))
                {
                    string py = "import arcpy  " + Environment.NewLine +
                        "AutoCad = \"" + Autocad + "\"  " + Environment.NewLine +
                        "Annotation = \"" + Annotation + "\"  " + Environment.NewLine +
                        "Output_has_Z_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "Output_has_M_Values = \"" + Disabled + "\" " + Environment.NewLine +
                        "Annotation1 = \"" + Annotation + "\"  " + Environment.NewLine +
                        "Annotation2 = \"" + Annotation + "\"  " + Environment.NewLine +
                        "arcpy.FeatureToPoint_management(AutoCad, Annotation, \"CENTROID\")" + Environment.NewLine +
                        "arcpy.AddField_management(Annotation, \"TEXTSTRING\", \"TEXT\", \"\", \"\", \"50\", \"\", \"NULLABLE\", \"NON_REQUIRED\", \"\")" + Environment.NewLine +
                        "arcpy.CalculateField_management(Annotation1, \"TEXTSTRING\", \"!Text!\", \"PYTHON_9.3\", \"\")" + Environment.NewLine +
                        "arcpy.DeleteField_management(Annotation2, \"Entity;Handle;Owner;LyrFrzn;LyrLock;LyrOn;LyrVPFrzn;LyrHandle;Color;EntColor;LyrColor;BlkColor;Linetype;EntLinetyp;LyrLnType;BlkLinetyp;Elevation;Thickness;LineWt;EntLineWt;LyrLineWt;BlkLineWt;RefName;LTScale;ExtX;ExtY;ExtZ;DocName;DocPath;DocType;DocVer;ScaleX;ScaleY;ScaleZ;Style;FontID;Text;Height;TxtAngle;TxtWidth;TxtOblique;TxtGenType;TxtJust;VertAlign;TxtFont;TxtBoxHt;TxtBoxWd;TxtRefWd;TxtAttach;TxtDir;LnSpace;SpaceFct;TxtMemo;ORIG_FID;EntLinetype;BlkLinetype\")";
                    py = py.Replace("\\", "\\\\");
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

        }
    }
    
}
