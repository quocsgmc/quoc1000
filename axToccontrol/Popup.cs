using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace QLHTDT.FormPhu
{
    public partial class Popup : Form
    {
        public Popup()
        {
            InitializeComponent();
        }

        private void Popup_Load(object sender, EventArgs e)
        {
            ILayer layer = new FeatureLayerClass();
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            featureLayer = QLHTDT.FormChinh.KienTruc.featureLayer;
            ILayerFields layerFields = (ILayerFields)featureLayer;
            int j = 0;
            cboDataField.Items.Clear();
            cboDataField.Enabled = true;
            for (int i = 0; i <= layerFields.FieldCount - 1; i++)
            {
                //Get IField interface
                IField field = layerFields.get_Field(i);
                //If the field is not the shape field
                if (field.Type != esriFieldType.esriFieldTypeGeometry)
                {
                    //Add field name to the control
                    cboDataField.Items.Insert(j, field.Name);
                    //If the field name is the display field
                    if (field.Name == featureLayer.DisplayField)
                    {
                        //Select the field name in the control
                        cboDataField.SelectedIndex = j;
                    }
                    j = j + 1;
                }
            }
            ShowLayerTips();
        }

        private void chkShowTips_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkShowTips.CheckState == CheckState.Checked)
                QLHTDT.FormChinh.KienTruc.axMapControl1.ShowMapTips = true;
            else
                QLHTDT.FormChinh.KienTruc.axMapControl1.ShowMapTips = false;
        }

        private void cboDataField_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ILayer layer = new FeatureLayerClass();
            //Get IFeatureLayer interface 
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            featureLayer = QLHTDT.FormChinh.KienTruc.featureLayer;
            //Query interface for IlayerFields
            ILayerFields layerFields = (ILayerFields)featureLayer;

            //Loop through the fields
            for (int i = 0; i <= layerFields.FieldCount - 1; i++)
            {
                //Get IField interface
                IField field = layerFields.get_Field(i);
                //If the field name is the name selected in the control
                if (field.Name == cboDataField.Text)
                {
                    
                    //Set the field as the display field
                    featureLayer.DisplayField = field.Name;
                    break;
                }
            }
        }
        private void ShowLayerTips()
        {
            //Loop through the maps layers
            for (int i = 0; i <= QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount - 1; i++)
            {
                //Get ILayer interface
                ILayer layer = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i);
                //If is the layer selected in the control
                 //If want to show map tips
                    if (chkShowTips.CheckState == CheckState.Checked)
                    {
                        layer.ShowTips = true;
                    }
                    else
                    {
                        layer.ShowTips = false;
                        
                    }
                
            }
        }

        private void chkShowTips_CheckStateChanged(object sender, System.EventArgs e)
        {
            ShowLayerTips();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            this.Hide(); 
        }

       
    }
}
