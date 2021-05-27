using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLHTDT.CORE
{
    class ConvertTableTodatabase
    {
        private ITable table;

        public ConvertTableTodatabase(ITable _table)
        {
            table = _table;

        }

        public DataTable ConvertTabletoDataBale(ILayer layer, IQueryFilter Q)
        {
            DataTable pDatatable = new DataTable();
            if (layer != null)
            {
                ILayerFields Layerfield = layer as ILayerFields;
                for (int i = 0; i <= Layerfield.FieldCount - 1; i++)
                {
                    if (Layerfield.FieldInfo[i].Visible == false) { continue; }
                    DataColumn Cl = new DataColumn();
                    if (table.Fields.Field[i].Type == esriFieldType.esriFieldTypeGeometry) { continue; }
                    if (table.Fields.Field[i].Type == esriFieldType.esriFieldTypeDouble || table.Fields.Field[i].Type == esriFieldType.esriFieldTypeSingle)
                    { Cl.DataType = typeof(double); }
                    else if (table.Fields.Field[i].Type == esriFieldType.esriFieldTypeOID || table.Fields.Field[i].Type == esriFieldType.esriFieldTypeInteger)
                    { Cl.DataType = typeof(int); }
                    else if (table.Fields.Field[i].Type == esriFieldType.esriFieldTypeDate)
                    { Cl.DataType = typeof(DateTime); }
                    else { { Cl.DataType = typeof(string); } }

                    Cl.ColumnName = table.Fields.Field[i].Name;
                    Cl.Caption = Layerfield.FieldInfo[i].Alias;
                    pDatatable.Columns.Add(Cl);

                }
                ICursor CursorByLayer = null;
                CursorByLayer = table.Search(Q, false);
                IRow Row;
                Row = CursorByLayer.NextRow();
                if (Row == null)
                {
                    return pDatatable;
                }
                do
                {
                    DataRow dr = pDatatable.NewRow();
                    for (int i = 0; i <= table.Fields.FieldCount - 1; i++)
                    {
                        if (table.Fields.Field[i].Type == esriFieldType.esriFieldTypeGeometry || table.Fields.Field[i].Name.ToUpper() == "SHAPE.LENGHT" || table.Fields.Field[i].Name.ToUpper() == "SHAPE.AREA") { continue; }
                        dr[(table.Fields.Field[i].Name)] = Row.Value[table.Fields.FindField(table.Fields.Field[i].Name)];
                    }
                    pDatatable.Rows.Add(dr);
                    Row = CursorByLayer.NextRow();
                } while (Row != null);
            }
            return pDatatable;
        }


    }
}
