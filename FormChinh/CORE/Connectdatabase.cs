using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;
using System.IO;

namespace QLHTDT.FormChinh.CORE
{
    class Connectdatabase
    {
        public static void ConnectFolder()
        {
            FolderBrowserDialog openfd = new FolderBrowserDialog();
            openfd.ShowNewFolderButton = true;
            openfd.SelectedPath = QLHTDT.Properties.Settings.Default.PathData;
            openfd.Description = "Chọn thư mục làm việc";
            if (openfd.ShowDialog() == DialogResult.OK)
            {

                QLHTDT.Properties.Settings.Default.PathData = @openfd.SelectedPath;
                QLHTDT.Properties.Settings.Default.Save();
            }
        }
        private string GetPath(IFeatureClass F)
        {
            return QLHTDT.Properties.Settings.Default.PathData + "\\Layer\\" + F.FeatureDataset.Name + "\\" + (F as IDataset).Name + ".lyr";
        }
    }
}
