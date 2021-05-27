using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Diagnostics;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;

namespace QLHTDT.CORE
{
    class LoadLayer
    {

        public static void Getdataset(IWorkspace workspace, ComboBox cbo)
        {
            cbo.Items.Clear();
           if (workspace == null){
                return;
            }
            IEnumDataset Emun = workspace.get_Datasets(esriDatasetType.esriDTFeatureDataset) as IEnumDataset;
            Emun.Reset();
            IDataset idatase = Emun.Next();
            while ((idatase != null))
            {
                cbo.Items.Add(idatase.Name);
                idatase = Emun.Next();
            }
        }
        public static void LoadFeaturelayerToCombo(ComboBox cbo, IMap map)
        {
            cbo.DataSource = CORE.LoadLayer.GetlistLayerOnMap(map);
            cbo.ValueMember = "Value";
            cbo.DisplayMember = "Tenlop"; 
            
        }
        
        public static DataTable GetlistLayerOnMap(IMap Map)
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
                pdatatable.Columns.Add("Value", typeof(object));
                pdatatable.Columns.Add("Tenlop");
                //for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
                //{


                //    if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == "Đường giao thông chính")
                //    {

                //        DataRow dr = pdatatable.NewRow();
                //        dr[0] = "Đường giao thông chính";
                //        dr[1] = "Đường giao thông chính";
                //        pdatatable.Rows.Add(dr);
                //    }
                //    if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == "Ranh giới khu quy hoạch")
                //    {
                //        DataRow dr = pdatatable.NewRow();
                //        dr[0] = "Ranh giới khu quy hoạch";
                //        dr[1] = "Ranh giới khu quy hoạch";
                //        pdatatable.Rows.Add(dr);
                //    }
                //}
                while ((pFeatureLayer != null))
                {
                    DataRow dr = pdatatable.NewRow();
                    dr[0] = pFeatureLayer ;
                    dr[1] = pFeatureLayer.Name;
                    pdatatable.Rows.Add(dr);
                    pFeatureLayer = pEnumLayer.Next() as IFeatureLayer ;
                }
                
                return pdatatable;
                
            }
            catch (Exception ex)
            {
                return null;
            }

        }
      
        public static ILayer Checklayer(string filename, IMap map)
        {
            try
            {
                UID pUID = new UID();
                IEnumLayer pEnumLayer = default(IEnumLayer);
                IFeatureLayer pFeatureLayer = default(IFeatureLayer);
                
                pUID.Value = "{40A9E885-5533-11D0-98BE-00805F7CED21}";
                //IFeatureLayer
                pEnumLayer = map.get_Layers(pUID, false);
                pEnumLayer.Reset();
                //get the first layer in the map
                pFeatureLayer = pEnumLayer.Next() as IFeatureLayer;

                while ((pFeatureLayer != null))
                {
                    if (pFeatureLayer.FeatureClass.FeatureDataset == null)
                    {
                        pFeatureLayer = pEnumLayer.Next() as IFeatureLayer;
                        continue;
                    }
                    else
                    {
                        IDataset ds = pFeatureLayer.FeatureClass as IDataset;
                        string pstring = ds.Workspace.PathName + "\\" + pFeatureLayer.FeatureClass.FeatureDataset.Name + "\\" + ds.Name;
                        if (pstring.ToUpper() == filename.ToUpper())
                        {
                            return pFeatureLayer;
                        }
                        pFeatureLayer = pEnumLayer.Next() as IFeatureLayer;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void Loadvaluestolistbox(ITable Itable, string pfieldname, ComboBox cbo)
        {
            IQueryDef pQueryDef = default(IQueryDef);
            IRow pRow = default(IRow);
            ICursor pCursor = default(ICursor);
            IFeatureWorkspace pFeatureWorkspace = default(IFeatureWorkspace);
            IDataset pDataset = default(IDataset);
            IField pfield = default(IField);
            try
            {
                cbo.Items.Clear();
                pDataset = Itable as IDataset ;
                pFeatureWorkspace = pDataset.Workspace as IFeatureWorkspace;
                pQueryDef = pFeatureWorkspace.CreateQueryDef();
                var _with1 = pQueryDef;
                _with1.Tables = pDataset.Name;
                // Fully qualified table name
                _with1.SubFields = "DISTINCT(" + pfieldname + ")";
                pCursor = _with1.Evaluate();
                pfield = Itable.Fields.get_Field(Itable.Fields.FindField(pfieldname));
                pRow = pCursor.NextRow();
                if (pfield.Type == esriFieldType.esriFieldTypeString)
                {
                    while (!(pRow == null))
                    {
                        cbo.Items.Add("'" + pRow.get_Value(0) + "'");
                        // Note only one field in the cursor
                        pRow = pCursor.NextRow();
                    }
                }
                else if (pfield.Type == esriFieldType.esriFieldTypeDate)
                {
                    while (!(pRow == null))
                    {
                         cbo.Items.Add("'" + pRow.get_Value(0) + "'");
                        // Note only one field in the cursor
                        pRow = pCursor.NextRow();
                    }
                }
                else
                {
                    while (!(pRow == null))
                    {
                        cbo.Items.Add(pRow.get_Value(0));
                        // Note only one field in the cursor
                        pRow = pCursor.NextRow();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox(ex.Message, "Thông báo");
            }
        }
        public static void Loadvaluestolistbox2(ITable Itable, string pfieldname, ListBox cbo)
        {
            IQueryDef pQueryDef = default(IQueryDef);
            IRow pRow = default(IRow);
            ICursor pCursor = default(ICursor);
            IFeatureWorkspace pFeatureWorkspace = default(IFeatureWorkspace);
            IDataset pDataset = default(IDataset);
            IField pfield = default(IField);
            try
            {
                cbo.Items.Clear();
                pDataset = Itable as IDataset;
                pFeatureWorkspace = pDataset.Workspace as IFeatureWorkspace;
                pQueryDef = pFeatureWorkspace.CreateQueryDef();
                var _with1 = pQueryDef;
                _with1.Tables = pDataset.Name;
                // Fully qualified table name
                _with1.SubFields = "DISTINCT(" + pfieldname + ")";
                pCursor = _with1.Evaluate();
                pfield = Itable.Fields.get_Field(Itable.Fields.FindField(pfieldname));
                pRow = pCursor.NextRow();
                if (pfield.Type == esriFieldType.esriFieldTypeString)
                {
                    while (!(pRow == null))
                    {
                        cbo.Items.Add(pRow.get_Value(0));
                        // Note only one field in the cursor
                        pRow = pCursor.NextRow();
                    }
                }
                else if (pfield.Type == esriFieldType.esriFieldTypeDate)
                {
                    while (!(pRow == null))
                    {
                        cbo.Items.Add(pRow.get_Value(0));
                        // Note only one field in the cursor
                        pRow = pCursor.NextRow();
                    }
                }
                else
                {
                    while (!(pRow == null))
                    {
                        cbo.Items.Add(pRow.get_Value(0));
                        // Note only one field in the cursor
                        pRow = pCursor.NextRow();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox(ex.Message, "Thông báo");
            }
        }
        private static void MessageBox(string p, string p_2)
        {
            throw new System.NotImplementedException();
        }
        public static void Loadfieldtocombox(ITable _table, ComboBox cbo)
        {
            DataTable bang = default(DataTable);
            try
            {
                bang = new DataTable();
                bang.Columns.Add("tentt");
                bang.Columns.Add("tendd");
                ITable ptable = _table;
                DataRow dr = default(DataRow);
                dr = bang.NewRow();
                for (int i = 0; i <= ptable.Fields.FieldCount - 1; i++)
                {
                    dr = bang.NewRow();
                    dr["tentt"] = ptable.Fields.get_Field(i).Name;
                    dr["tendd"] = ptable.Fields.get_Field(i).AliasName;
                    bang.Rows.Add(dr);
                }
                cbo.DataSource = bang;
                cbo.ValueMember = "tentt";
                cbo.DisplayMember = "tendd";
            }
            catch (Exception ex)
            {
                MessageBox(ex.Message, "Thong bao");
            }
        }
    }
}
