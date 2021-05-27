using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using System.Data;

namespace QLHTDT.CORE
{
    class Layer
    {
        public ILayer Getlayer(IFeatureClass FeatureClass, string filename)
        {
            if (File.Exists(filename))
            {
                ILayerFile filelayer = new LayerFileClass();
                filelayer.Open(filename);
                ILayer player = filelayer.Layer;
                IGeoFeatureLayer objGeoFeatureLayer = (IGeoFeatureLayer)player;
                objGeoFeatureLayer.FeatureClass = FeatureClass;
                player.Name = FeatureClass.AliasName;
                filelayer.Close();
                return player;

            }
            else
            {
                IFeatureLayer pFlayer = default(IFeatureLayer);
                pFlayer = new FeatureLayer();
                pFlayer.FeatureClass = FeatureClass;
                pFlayer.Name = FeatureClass.AliasName;
                return pFlayer;
            }
        }

        //Load all layer from focus map into combox
        public DataTable GetlistLayerOnMap(IMap Map)
        {
            try
            {
                UID pUID = new UID();
                IEnumLayer pEnumLayer = default(IEnumLayer);
                IFeatureLayer pFeatureLayer = default(IFeatureLayer);
                pUID.Value = "{40A9E885-5533-11D0-98BE-00805F7CED21}";
                //IFeatureLayer
                pEnumLayer = Map.get_Layers(pUID, false) as IEnumLayer;
                pEnumLayer.Reset();
                //get the first layer in the map
                pFeatureLayer = pEnumLayer.Next() as IFeatureLayer;
                DataTable pdatatable = new DataTable();
                pdatatable.Columns.Add("value", typeof(object));
                pdatatable.Columns.Add("name");
                while ((pFeatureLayer != null))
                {
                    DataRow dr = pdatatable.NewRow();
                    dr[0] = pFeatureLayer;
                    dr[1] = pFeatureLayer.Name;
                    pdatatable.Rows.Add(dr);
                    pFeatureLayer = pEnumLayer.Next() as IFeatureLayer;
                }
                return pdatatable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        // load fiels into from layer

        public DataTable Getfields(IFeatureClass fc)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("alias");
            for (int i = 0; i < fc.Fields.FieldCount; i++)
            {
                DataRow r = dt.NewRow();
                r["name"] = fc.Fields.Field[i].Name;
                r["alias"] = fc.Fields.Field[i].AliasName;
                dt.Rows.Add(r);
            }

            return dt;
        }
        //get values in field 
        public List<string> Getvalues(IFeatureClass fc, string fieldname)
        {
            List<string> list = new List<string>();
            IQueryDef pQueryDef;
            ICursor pCursor;
            IFeatureWorkspace pFeatureWorkspace;
            IDataset pDataset = default(IDataset);
            IField pfield;
            IRow pRow;
            pDataset = fc as IDataset;
            pFeatureWorkspace = pDataset.Workspace as IFeatureWorkspace;
            pQueryDef = pFeatureWorkspace.CreateQueryDef();
            pQueryDef.Tables = pDataset.Name;
            pQueryDef.SubFields = "DISTINCT(" + fieldname + ")";
            pCursor = pQueryDef.Evaluate();
            pfield = fc.Fields.get_Field(fc.Fields.FindField(fieldname));
            pRow = pCursor.NextRow();
            while (pRow != null)
            {
                object ob = pRow.Value[0];
                if (ob.GetType() == typeof(string))
                {
                    list.Add("'" + ob.ToString() + "'");
                }
                else if (ob.GetType() == typeof(int))
                {
                    list.Add(ob.ToString());
                }
                else if (ob.GetType() == typeof(double))
                {
                    list.Add(ob.ToString());
                }
                else if (ob.GetType() == typeof(float))
                {
                    list.Add(ob.ToString());
                }
                else if (ob.GetType() == typeof(DateTime))
                {
                    list.Add("'" + ob.ToString() + "'");

                }
                pRow = pCursor.NextRow();
            }
            return list;
        }
    }



}
