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
using ESRI.ArcGIS.DataSourcesGDB;
using QLHTDT.Properties;

namespace QLHTDT.CORE
{
    public class Geodatabase
    {
        public IFeatureWorkspace FeatureWorkspace;
        public ILayer featureselectLayer;

        public Geodatabase()
        {

            //FeatureWorkspace = ConnectFile(Settings.Default.PathData + "\\connection.sde") as IFeatureWorkspace;
            IWorkspaceFactory2 workspaceFactory = (IWorkspaceFactory2)new SdeWorkspaceFactoryClass();
            FeatureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(Settings.Default.PathData + "\\connection.sde", 0);
        }

        public IWorkspace ConnectFile(string Filename)
        {
            try
            {
                if (File.Exists(Filename))
                {
                    //Type factoryType = Type.GetTypeFromProgID("esriDataSourcesGDB.AccessWorkspaceFactory");
                    //IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance(factoryType);
                    //FeatureWorkspace = workspaceFactory.OpenFromFile(Filename, 0) as IFeatureWorkspace;
                    IWorkspaceFactory2 workspaceFactory = (IWorkspaceFactory2)new SdeWorkspaceFactoryClass();
                    FeatureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(Filename, 0);
                }
                else
                {
                    FeatureWorkspace = null;
                    MessageBox.Show("Đường dẫn thư mục lưu dữ liệu chưa đúng", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            return FeatureWorkspace as IWorkspace;
        }

        public void Refeshdata(IMap Map)
        {
            (Map as IActiveView).Refresh();
        }
        private ILayer Addlayer(IFeatureClass FeatureClass, string filename, IMap Map)
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
                featureselectLayer = player;
                Map.AddLayer(player);
                return player;

            }
            else
            {
                IFeatureLayer pFlayer = default(IFeatureLayer);
                pFlayer = new FeatureLayer();
                pFlayer.FeatureClass = FeatureClass;
                pFlayer.Name = FeatureClass.AliasName;
                featureselectLayer = pFlayer;
                //LoadFeature(listf)
                Map.AddLayer(pFlayer);
                return pFlayer;
            }
        }
        public List<PropertyLayer> ListFeatureclassFromFdataset(string NamedFataset)
        {
            try
            {
                dynamic list = new List<PropertyLayer>();
                IFeatureDataset Fdatset = FeatureWorkspace.OpenFeatureDataset(NamedFataset);
                IEnumDataset E = Fdatset.Subsets;
                IFeatureClass f = E.Next() as IFeatureClass;
                while ((f != null))
                {
                    PropertyLayer p = new PropertyLayer
                    {
                        _Name = (f as IDataset).Name,
                        _Alias = f.AliasName,
                        Type = f.ShapeType
                    };
                    list.Add(p);
                    f = E.Next() as IFeatureClass;
                }
                return (list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        public IFeatureLayer Openlayer(IFeatureWorkspace F, string Namef, IMap map)
        {
            if (object.ReferenceEquals(Namef.Trim(), string.Empty))
                return null;
            IFeatureClass featureClass = F.OpenFeatureClass(Namef);
            //return Addlayer(featureClass, GetPath(featureClass), map) as IFeatureLayer;
            return Addlayer(featureClass, @"E:\sinh\CamLe\CSDLOnline\CSDLOnline - MayChu\Hòa An\Chia lô - HA.lyr", map) as IFeatureLayer;
        }

        private string GetPath(IFeatureClass F)
        {
            return QLHTDT.Properties.Settings.Default.PathData + "\\Layer\\" + F.FeatureDataset.Name + "\\" + (F as IDataset).Name + ".lyr";
            //return QLHTDT.Properties.Settings.Default.PathData + "\\HÒA An\\"  + (F as IDataset).Name + ".lyr";
        }
    }
    public class PropertyLayer
    {
        public string _Alias { get; set; }
        public string _Name { get; set; }
        public esriGeometryType Type { get; set; }
    }
}