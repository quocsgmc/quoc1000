using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.CartoUI;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.LocationUI;

namespace QLHTDT.FormPhu
{
    public partial class AddpointFromXY : Form
    {
        string fileName;
        public AddpointFromXY()
        {
            InitializeComponent();
            
        }
        private void a()
        {
            try
            {
                //IMxDocument pMxDoc;
                //IMap pMap;
                //pMxDoc = axMapControl1.DocumentMap;
                //pMap = pMxDoc.FocusMap;

                // Get the table named XYSample.txt
                IStandaloneTableCollection pStTabCol;
                IStandaloneTable pStandaloneTable;
                ITable pTable = null;
                pStTabCol = (IStandaloneTableCollection)QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map;
                for (int intCount = 0; intCount < pStTabCol.StandaloneTableCount; intCount++)
                {
                    pStandaloneTable = (IStandaloneTable)pStTabCol.get_StandaloneTable(intCount);
                    if (pStandaloneTable.Name == "XYSample.txt")
                    {
                        pTable = pStandaloneTable.Table;
                        break;
                    }
                }
                if (pTable == null)
                {
                    MessageBox.Show("The table was not found");
                    return;
                }

                // Get the table name object
                IDataset pDataSet;
                IName pTableName;
                pDataSet = (IDataset)pTable;
                pTableName = pDataSet.FullName;

                // Specify the X and Y fields
                IXYEvent2FieldsProperties pXYEvent2FieldsProperties;
                pXYEvent2FieldsProperties = new XYEvent2FieldsPropertiesClass();
                pXYEvent2FieldsProperties.XFieldName = "x";
                pXYEvent2FieldsProperties.YFieldName = "y";
                pXYEvent2FieldsProperties.ZFieldName = "";

                // Specify the projection
                ISpatialReferenceFactory pSpatialReferenceFactory;
                pSpatialReferenceFactory = new SpatialReferenceEnvironmentClass();
                IProjectedCoordinateSystem pProjectedCoordinateSystem;
                pProjectedCoordinateSystem = pSpatialReferenceFactory.CreateProjectedCoordinateSystem(26911);
                // esriSRProjCS_NAD1983UTM_11N

                // Create the XY name object and set it's properties 
                IXYEventSourceName pXYEventSourceName = new XYEventSourceNameClass();
                IName pXYName;
                IXYEventSource pXYEventSource;
                pXYEventSourceName.EventProperties = pXYEvent2FieldsProperties;
                pXYEventSourceName.SpatialReference = pProjectedCoordinateSystem;
                pXYEventSourceName.EventTableName = pTableName;
                pXYName = (IName)pXYEventSourceName;
                pXYEventSource = (IXYEventSource)pXYName.Open();

                // Create a new Map Layer 
                IFeatureLayer pFLayer = new FeatureLayerClass();
                pFLayer.FeatureClass = (IFeatureClass)pXYEventSource;
                pFLayer.Name = "Sample XY Event layer";

                // Add the layer extension (this is done so that when you edit
                //   the layer's Source properties and click the Set Data Source
                //   button, the Add XY Events Dialog appears)
                ILayerExtensions pLayerExt;
                IFeatureLayerSourcePageExtension pRESPageExt = new XYDataSourcePageExtensionClass();
                pLayerExt = (ILayerExtensions)pFLayer;
                pLayerExt.AddExtension(pRESPageExt);

                QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.AddLayer(pFLayer);
            }
            catch (COMException COMEx)
            {
                MessageBox.Show(COMEx.Message, "COM Error: " + COMEx.ErrorCode.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (System.Exception SysEx)
            {
                MessageBox.Show(SysEx.Message, ".NET Error: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "File Excel 97- 2003|*.xls|File Excel 2007 và 2010|*.xlsx|All Files|*.*";
            openFileDialog1.Title = "Chọn file Excel";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string workspacePath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
            fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
