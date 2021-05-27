using ESRI.ArcGIS.Carto;
//using ESRI.ArcGIS.ConversionTools;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.Export
{
    public partial class ExportToCAD : Form
    {
        int itemcbo = 0;
        OpenFileDialog openFileDialog1;
        string filename = "";
        MyObject a = new MyObject("", "");
        SaveFileDialog SaveFileDialogSave;
        string Save = "";
        //Object[] x = new Object[100];
        public ExportToCAD()
        {
            InitializeComponent();
            
        }

        private void ExportToCAD_Load(object sender, EventArgs e)
        {
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            //load layer to combobox1 danh sách layer
            
            LoadFeaturelayerToCombo(comboBox1, QLHTDT.FormChinh.KienTruc.axMapControl1.Map);
            openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog_ok);
        }
        private void LoadFeaturelayerToCombo(ComboBox cbo, IMap map)
        {
            for (int i = 0; i < map.LayerCount; i++)
            {
                ILayer pLayer = map.get_Layer(i);
                cbo.Items.Add(pLayer.Name);
            }
        }
        private void openFileDialog_ok(object sender, CancelEventArgs e)
        {
            //add object file to listbox1
            Cursor = Cursors.WaitCursor;
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
            string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
            listBox1.Items.Add(new MyObject(fileName, workspacePath + "\\" + fileName));
            Cursor = Cursors.Default;
        }
        public class MyObject
        {
            public string alias { get; set; }
            public string value { get; set; }
            public MyObject(string alias, string value)
            {
                this.alias = alias;
                this.value = value;
            }
            public override string ToString() { return this.alias; }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sự kiện khi chọn layer từ combobox1 danh sách layer

            if (comboBox1.Text != "System.Data.DataRowView" && comboBox1.Text != "System.__ComObject" && itemcbo < 1)
            { itemcbo = itemcbo + 1; }
            if (comboBox1.Text != "System.Data.DataRowView" && comboBox1.Text != "System.__ComObject" && itemcbo >= 1 && comboBox1.Text != "")
            {
                for (int i = 0; i < FormChinh.KienTruc.axMapControl1.LayerCount; i++)
                {
                    //List<string> layerInputList = new List<string>();
                    ILayer pLayer = FormChinh.KienTruc.axMapControl1.get_Layer(i);
                    if (pLayer.Name == comboBox1.Text)
                    {
                        if (pLayer is IGroupLayer)
                        {
                            ICompositeLayer compGroupLayer = pLayer as ICompositeLayer;
                            for (int k = 0; k < compGroupLayer.Count; k++)
                            {
                                ILayer featLayer = compGroupLayer.Layer[k];
                                if (featLayer is IGroupLayer)
                                {
                                    ICompositeLayer groupLayer2 = featLayer as ICompositeLayer;
                                    for (int o = 0; o < groupLayer2.Count; o++)
                                    {
                                        ILayer Layer = groupLayer2.Layer[o];
                                        //create a new LayerFile instance
                                        ILayerFile layerFile = new LayerFileClass();
                                        //create a new layer file
                                        layerFile.New(System.IO.Path.GetTempPath() + "\\" + comboBox1.Text + "." + Layer.Name + ".lyr");
                                        //attach the layer file with the actual layer
                                        layerFile.ReplaceContents(featLayer);
                                        //save the layer file
                                        layerFile.Save();
                                        listBox1.Items.Add(new MyObject(comboBox1.Text + "." + Layer.Name + ".lyr", System.IO.Path.GetTempPath() + comboBox1.Text + "." + Layer.Name + ".lyr"));
                                    }
                                }
                                else
                                {
                                    ILayerFile layerFile = new LayerFileClass();
                                    //create a new layer file
                                    layerFile.New(System.IO.Path.GetTempPath() + "\\" + comboBox1.Text + "." + featLayer.Name + ".lyr");
                                    //attach the layer file with the actual layer
                                    layerFile.ReplaceContents(featLayer);
                                    //save the layer file
                                    layerFile.Save();
                                    listBox1.Items.Add(new MyObject(comboBox1.Text + "." + featLayer.Name + ".lyr", System.IO.Path.GetTempPath() + comboBox1.Text + "." + featLayer.Name + ".lyr"));

                                }

                            }
                        }
                        else
                        {
                            ILayerFile layerFile = new LayerFileClass();
                            //create a new layer file
                            layerFile.New(System.IO.Path.GetTempPath() + "\\" + pLayer.Name + ".lyr");
                            //attach the layer file with the actual layer
                            layerFile.ReplaceContents(pLayer);
                            //save the layer file
                            layerFile.Save();
                            listBox1.Items.Add(new MyObject(pLayer.Name + ".lyr", System.IO.Path.GetTempPath() + pLayer.Name + ".lyr"));
                        }
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mở opendialog chọn file từ bên ngoài

            openFileDialog1.Filter = "Shapefile |*.shp|All Files|*.*";
            openFileDialog1.Title = "Chọn Shapefile cần mở";
            openFileDialog1.ShowDialog();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //Xóa layer đã chọn
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Chọn loại dữ liệu đầu ra
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Mở opendialog chọn đường dẫn lưu file
            SaveFileDialogSave = new System.Windows.Forms.SaveFileDialog();
            if (comboBox2.Text != "")
            { SaveFileDialogSave.Filter = "Autocad file|*." + comboBox2.Text.Substring(0, 3).ToLower() + "|All files (*.*)|*.*"; }
            else { SaveFileDialogSave.Filter = "Autocad file|*.dwg; *.dxf; *.dgn| All files (*.*)|*.*"; }
            //SaveFileDialogSave.CheckFileExists = true;
            SaveFileDialogSave.CheckPathExists = true;
            SaveFileDialogSave.FileOk += new System.ComponentModel.CancelEventHandler(SaveFileDialogSave1);
            SaveFileDialogSave.ShowDialog();
        }
        private void SaveFileDialogSave1(object sender, CancelEventArgs e)
        {
            //add object file to listbox1
            Cursor = Cursors.WaitCursor;
            Save = SaveFileDialogSave.FileName;
            textBox1.Text = SaveFileDialogSave.FileName;
            Cursor = Cursors.Default;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            //Button chuyển
            try
            {
                IVariantArray parameters = new VarArrayClass();
                Cursor = Cursors.WaitCursor;
                ITrackCancel tc = new TrackCancel();
                //IGeoProcessor2 gp = new GeoProcessorClass();
                Geoprocessor gp = new Geoprocessor();
                //ExportCAD exportCAD = new ExportCAD();
                string local = "";
                for (int j = 0; j < listBox1.Items.Count; j++)
                {
                    a = listBox1.Items[j] as MyObject;
                    if (j == 0)
                    { local = a.value; }
                    else
                    { local = local + ";" + a.value; }
                }
                //exportCAD.in_features = local;
                parameters.Add(local);
                parameters.Add(comboBox2.Text);
                parameters.Add(textBox1.Text);
                parameters.Add(false);
                parameters.Add(true);
                parameters.Add(null);
                if (Save != "")
                {
                    //exportCAD.Output_File = textBox1.Text;
                    //exportCAD.Output_Type = comboBox2.Text;
                    //exportCAD.Append_To_Existing = "true";
                    gp.Execute("ExportCAD_conversion", parameters, tc);
                    Cursor = Cursors.Default;
                    MessageBox.Show("Chuyển dữ liệu thành công", "Thông báo");
                }
                else { MessageBox.Show("Chưa chọn nơi lưu file", "Thông báo"); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.Source + "\n\n" + ex.StackTrace);
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
