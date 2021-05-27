using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using stdole;
using ESRI.ArcGIS.Framework;

namespace QLHTDT.axToccontrol
{
    public partial class Label : Form
    {
        IColor pColor;
        
        public Label()
        {
            //button5.Visible = true;
            InitializeComponent(); 
            Loadfields();
            pmap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map;
        }
        private ESRI.ArcGIS.Carto.IMap pmap;
        private void Loadfields()
        {
            IFeatureLayer ft = QLHTDT.FormChinh.KienTruc.layer as IFeatureLayer;
            if (ft != null)
            {
                QLHTDT.CORE.Layer Layer = new QLHTDT.CORE.Layer();
                DataTable dt = Layer.Getfields(ft.FeatureClass);
                Cbolop2.DataSource = dt;
                Cbolop2.ValueMember = "name";
                Cbolop2.DisplayMember = "alias";
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            IConvertLabelsToAnnotation pConvertLabelsToAnnotation = new ConvertLabelsToAnnotationClass();
            ITrackCancel pTrackCancel = new CancelTrackerClass();
            //esriLabelWhichFeatures.esriSelectedFeatures = Cbolop2.SelectedItem;
            //Change global level options for the conversion by sending in different parameters to the next line.
            pConvertLabelsToAnnotation.Initialize(pmap, esriAnnotationStorageType.esriMapAnnotation, esriLabelWhichFeatures.esriAllFeatures, true, pTrackCancel, null);
            ILayer layer =QLHTDT.FormChinh.KienTruc.layer;
            IFeatureLayer featureLayer = layer as IFeatureLayer;

            featureLayer = QLHTDT.FormChinh.KienTruc.featureLayer;
            //QI to IFeatureLayer and IGeoFeatuerLayer interface
            IGeoFeatureLayer pGeoFeatureLayer = (IGeoFeatureLayer)featureLayer;
            pGeoFeatureLayer.DisplayAnnotation = true;
            if (pGeoFeatureLayer != null)
            {
                IFeatureClass pFeatureClass = pGeoFeatureLayer.FeatureClass;
                IDataset pDataset = pFeatureClass as IDataset;
                IFeatureWorkspace pFeatureWorkspace = pDataset.Workspace as IFeatureWorkspace;
                IFeatureDataset pFeatureLayer4 = pFeatureClass.FeatureDataset;//Cbolop2.SelectedValue as IFeatureDataset;
                pGeoFeatureLayer.DisplayField = Cbolop2.SelectedValue.ToString();
                //pFeatureClass.FeatureDataset.PropertySet.
                AnnotateFeatureClass a = pFeatureClass as AnnotateFeatureClass;
                ////pConvertLabelsToAnnotation.AddFeatureLayer(pGeoFeatureLayer, pGeoFeatureLayer.Name + "_Anno", pFeatureWorkspace, pFeatureLayer4, true, true, false, false, true, "");
                ////pConvertLabelsToAnnotation.ConvertLabels();

                //pGeoFeatureLayer.DisplayAnnotation = true;
                IAnnotateLayerPropertiesCollection annoProperties = pGeoFeatureLayer.AnnotationProperties;
                annoProperties.Clear();
                ILineLabelPosition position = new LineLabelPosition();
                position.Parallel = true;
                position.Perpendicular = false;
                ILineLabelPlacementPriorities placement = new LineLabelPlacementPriorities();
                IBasicOverposterLayerProperties basic = new BasicOverposterLayerProperties();
                basic.FeatureType = esriBasicOverposterFeatureType.esriOverposterPoint;
                basic.LineLabelPlacementPriorities = placement;
                basic.LineLabelPosition = position;
                ITextSymbol textSymbol = new TextSymbolClass();
                // Set Color
                if (pColor != null)
                { textSymbol.Color = pColor; }
                else
                {
                    IRgbColor color = new RgbColorClass();
                    color.Blue = 255;
                    color.UseWindowsDithering = true;
                    textSymbol.Color = color;
                }
                
                
                // Set Font 
                IFontDisp font = (IFontDisp)new stdole.StdFont();
                font.Name = comboBox1.SelectedItem.ToString();
                font.Size = Convert.ToInt32(comboBox2.SelectedItem);
                textSymbol.Font = font;
                ILabelEngineLayerProperties labelProperties = new LabelEngineLayerProperties() as ILabelEngineLayerProperties;
                labelProperties.Symbol = textSymbol;
                labelProperties.BasicOverposterLayerProperties = basic;
                labelProperties.Expression = "[" + Cbolop2.SelectedValue + "]";
                IAnnotateLayerProperties annoLayerProperties = labelProperties as IAnnotateLayerProperties;
                pGeoFeatureLayer.AnnotationProperties.Add(annoLayerProperties);
                if (button1.Text == "Bật")
                {
                    button1.Text = "Tắt";
                    pGeoFeatureLayer.DisplayAnnotation = true;
                }
                else
                {
                    button1.Text = "Bật";
                    pGeoFeatureLayer.DisplayAnnotation = false;
                }
                IActiveView pActiveView = pmap as IActiveView;
                pActiveView.Refresh();
                QLHTDT.FormChinh.KienTruc.axMapControl1.Update();
                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
            }

           
        }

        private void Label_Load(object sender, System.EventArgs e)
        {
            List<string> fonts = new List<string>();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add(font.Name);
                comboBox1.Items.Add(font.Name);
            }

            //foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            //{
            //    if (prop.PropertyType.FullName == "System.Drawing.Color")
            //        comboBox3.Items.Add(prop.Name);
                   
            //}

        }

        private void button2_Click(object sender, System.EventArgs e)
        {

        }

        private void button3_Click(object sender, System.EventArgs e)
        {

        }

        private void button4_Click(object sender, System.EventArgs e)
        {

        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    IColor pColor = new RgbColor();
        //    pColor.RGB = 255;
        //    tagRECT pTag = new tagRECT();
        //    pTag.left = this.Left + button5.Left + button5.Width;
        //    pTag.bottom = this.Top + button5.Top + button5.Height;
        //    IColorPalette pColorPalette = new ColorPalette();
        //    pColorPalette.TrackPopupMenu(ref pTag, pColor, false, 0);
        //    pColor = pColorPalette.Color;
        //}
        public ESRI.ArcGIS.Display.IRgbColor CreateRGBColor(System.Byte myRed, System.Byte myGreen, System.Byte myBlue)
        {
            ESRI.ArcGIS.Display.IRgbColor rgbColor = new ESRI.ArcGIS.Display.RgbColorClass();
            rgbColor.Red = myRed;
            rgbColor.Green = myGreen;
            rgbColor.Blue = myBlue;
            rgbColor.UseWindowsDithering = true;
            return rgbColor;
        }
        private void colorEdit1_EditValueChanged(object sender, EventArgs e)
        {
            pColor = new RgbColor();
            pColor.RGB = 255;
            pColor = CreateRGBColor(colorEdit1.Color.R, colorEdit1.Color.G, colorEdit1.Color.B);
            //pColor.RGB = Color.FromArgb(colorEdit1.Color.A, colorEdit1.Color.R, colorEdit1.Color.G, colorEdit1.Color.B);

        }
    }
}
