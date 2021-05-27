using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.LocationUI;
using System.Windows.Forms;
using ESRI.ArcGIS.CartoUI;
using System.Runtime.InteropServices;

namespace QLHTDT.FormChinh.Button
{
    class AddXY
    {
        void AddXYEventLayer()
        {
            IMxDocument mxdoc = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map as IMxDocument;
            IMap map = mxdoc.FocusMap;

            // Get the table named XYSample.txt
            IStandaloneTableCollection stTableCollection = map as IStandaloneTableCollection;
            IStandaloneTable standaloneTable = null;
            ITable table = null;




            for (int i = 0; i < stTableCollection.StandaloneTableCount; i++)
            {
                standaloneTable = stTableCollection.StandaloneTable[i];
                if (standaloneTable.Name == "XYSample.txt")
                {
                    table = standaloneTable.Table;
                    break;
                }
            }

            if (table == null)
            {
                MessageBox.Show("XYSample.txt table was not found in this map.");
                return;
            }

            // Get the table name object
            IDataset dataset = table as IDataset;
            IName tableName = dataset.FullName;

            // Specify the X and Y fields
            IXYEvent2FieldsProperties xyEvent2FieldsProperties = new XYEvent2FieldsProperties() as IXYEvent2FieldsProperties;
            xyEvent2FieldsProperties.XFieldName = "x";
            xyEvent2FieldsProperties.YFieldName = "y";
            xyEvent2FieldsProperties.ZFieldName = "";

            // Specify the projection
            ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironment() as ISpatialReferenceFactory;
            IProjectedCoordinateSystem projectedCoordinateSystem = spatialReferenceFactory.CreateProjectedCoordinateSystem((int)esriSRProjCSType.esriSRProjCS_NAD1983UTM_11N);

            // Create the XY name object as set it's properties
            IXYEventSourceName xyEventSourceName = new XYEventSourceName() as IXYEventSourceName;
            xyEventSourceName.EventProperties = xyEvent2FieldsProperties;
            xyEventSourceName.SpatialReference = projectedCoordinateSystem;
            xyEventSourceName.EventTableName = tableName;

            IName xyName = xyEventSourceName as IName;
            IXYEventSource xyEventSource = xyName.Open() as IXYEventSource;

            // Create a new Map Layer
            IFeatureLayer featureLayer = new FeatureLayer() as IFeatureLayer;
            featureLayer.FeatureClass = xyEventSource as IFeatureClass;
            featureLayer.Name = "Sample XY Event Layer";

            // Add the layer extension (this is done so that when you edit
            // the layer's Source properties and click the Set Data Source
            // button, the Add XY Events Dialog appears)
            ILayerExtensions layerExtensions = featureLayer as ILayerExtensions;
            XYDataSourcePageExtension resPageExtension = new XYDataSourcePageExtension();
            layerExtensions.AddExtension(resPageExtension);

            map.AddLayer(featureLayer);
        }

            public void CreateXYLayer()

                  {
                      try
                      {
                        IMxDocument pMxDoc;
                        IMap pMap;
                        pMxDoc = (IMxDocument)QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map;
                        pMap = pMxDoc.FocusMap;

                        // Get the table named XYSample.txt
                        IStandaloneTableCollection pStTabCol;
                        IStandaloneTable pStandaloneTable;        
                        ITable pTable = null;
                        pStTabCol = (IStandaloneTableCollection) pMap;
                        for (int intCount = 0; intCount < pStTabCol.StandaloneTableCount; intCount++)
                        {
                          pStandaloneTable = (IStandaloneTable) pStTabCol.get_StandaloneTable(intCount);
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
                        pDataSet = (IDataset) pTable;
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
                        pXYName = (IName) pXYEventSourceName;
                        pXYEventSource = (IXYEventSource) pXYName.Open();

                        // Create a new Map Layer 
                        IFeatureLayer pFLayer = new FeatureLayerClass();
                        pFLayer.FeatureClass = (IFeatureClass) pXYEventSource;
                        pFLayer.Name = "Sample XY Event layer";

                        // Add the layer extension (this is done so that when you edit
                        //   the layer's Source properties and click the Set Data Source
                        //   button, the Add XY Events Dialog appears)
                        ILayerExtensions pLayerExt;
                        IFeatureLayerSourcePageExtension pRESPageExt = new XYDataSourcePageExtensionClass();
                        pLayerExt = (ILayerExtensions) pFLayer;
                        pLayerExt.AddExtension(pRESPageExt);

                        pMap.AddLayer(pFLayer);
                      }
                      catch (COMException COMEx)
                      {
                        MessageBox.Show(COMEx.Message,"COM Error: " + COMEx.ErrorCode.ToString(),MessageBoxButtons.OK,MessageBoxIcon.Warning); 
                      }
                      catch (System.Exception SysEx)
                      {
                        MessageBox.Show(SysEx.Message,".NET Error: ",MessageBoxButtons.OK,MessageBoxIcon.Warning); 
                      }
                    }  
    }
}
