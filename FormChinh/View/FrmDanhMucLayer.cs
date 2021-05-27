using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using QLHTDT.Properties;

namespace QLHTDT.View
{
    public partial class FrmDanhMucLayer : Form
    {
       private CORE.Geodatabase _Geodatabase;
        public IMap pMap;
        private AxMapControl mMapControl;
        public FrmDanhMucLayer(AxMapControl mapControl)
        {
            InitializeComponent();
            this.mMapControl = mapControl;
            pMap = this.mMapControl.Map;
            _Geodatabase = new CORE.Geodatabase();
            QLHTDT.CORE.LoadLayer.Getdataset(_Geodatabase.ConnectFile(Settings.Default.PathData + "\\connection.sde"), Cbodataset);
        }
        public FrmDanhMucLayer()
        {
            InitializeComponent();
            pMap = this.mMapControl.Map ;
            _Geodatabase = new CORE.Geodatabase();
            QLHTDT.CORE.LoadLayer.Getdataset(_Geodatabase.ConnectFile(Settings.Default.PathData + "\\connection.sde"), Cbodataset);
        }
        private ILayer GetLayerOnvisibe(string namef, IMap map)
        {
            string filename = QLHTDT.Properties.Settings.Default.PathData + "\\connection.sde\\" + Cbodataset.SelectedItem + "\\" + namef;
            ILayer layer = QLHTDT.CORE.LoadLayer.Checklayer(filename, map);
            return layer;
        }
        private void Raddlayer_ButtonClick(System.Object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                CORE.PropertyLayer dr = GridViewlayer.GetFocusedRow() as CORE.PropertyLayer;

                if (dr == null)
                {
                    return;
                }
                  
                ILayer layer = GetLayerOnvisibe(dr._Name, pMap);
                
                    if (layer == null)
                    {
                        _Geodatabase.Openlayer(_Geodatabase.FeatureWorkspace, dr._Name, pMap);
                    }
                    else
                    {
                        MessageBox.Show("Lớp bản đồ đang được mở",  "Thông báo");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }

        }
        private void Cbodataset_SelectionChangeCommitted(System.Object sender, System.EventArgs e)
        {
            if (Cbodataset.SelectedIndex == -1)
                return;
            MAP_CLASSGridControl.DataSource = _Geodatabase.ListFeatureclassFromFdataset(Cbodataset.SelectedItem.ToString());
        }


        private void Btloadlailop_Click(System.Object sender, System.EventArgs e)
        {
            QLHTDT.CORE.LoadLayer.Getdataset(_Geodatabase.ConnectFile(QLHTDT.Properties.Settings.Default.PathData + "/Data.mdb"), Cbodataset);
        }
    }
}
