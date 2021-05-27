using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.Controls;

namespace QLHTDT.View
{
    public partial class FrmDanhSachBanDo : Form

    {
        private AxMapControl mMapControl;
        private AxPageLayoutControl Pagecontrol;
        public FrmDanhSachBanDo(AxMapControl mapControl,AxPageLayoutControl Pagecontrol1)
        {
            InitializeComponent();
            this.mMapControl = mapControl;
            Pagecontrol = Pagecontrol1;
            List<string> list = getlistmxd(QLHTDT.Properties.Settings.Default.PathData + "\\mxd");
            foreach (string fileName in list)
            {
                listmxd.Items.Add(fileName);
            }
            
        }
        public FrmDanhSachBanDo()
        {
            InitializeComponent();


            List<string> list = getlistmxd(QLHTDT.Properties.Settings.Default.PathData + "\\mxd");
            foreach (string fileName in list)
            {
                listmxd.Items.Add(fileName);
            }
        }

        private void btopen_Click_1(object sender, EventArgs e)
        {
            if (listmxd.SelectedIndex > -1)
            {
                string filename = QLHTDT.Properties.Settings.Default.PathData + "\\mxd\\" + listmxd.SelectedItem + ".mxd";
                if (File.Exists(filename))
                { 
                    this.mMapControl.LoadMxFile(filename);
                    Pagecontrol.LoadMxFile(filename);
                }
            }


        }
        private List<string> getlistmxd(string namefolder)
        {
            List<string> list = new List<string>();
            DirectoryInfo d = new DirectoryInfo(namefolder);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.mxd"); //Getting Text files
            foreach (FileInfo file in Files)
            {
                list.Add(file.Name.Replace(".mxd", ""));

            }

            return list;
        }

        
    }
}
