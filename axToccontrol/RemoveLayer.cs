// Copyright 2014 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See the use restrictions at <your ArcGIS install location>/DeveloperKit10.2/userestrictions.txt.
// 

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
namespace QLHTDT.FormPhu
{
	public sealed class RemoveLayer : BaseCommand  
	{
		private IMapControl3 m_mapControl;
        private IMapCooker2 mapCooker;
        private IEnvelope iEnvelope;
        
        public RemoveLayer()
		{
			base.m_caption = "Xóa layer";
		}
	
		public override void OnClick()
		{
			ILayer layer =  (ILayer) m_mapControl.CustomProperty;
			m_mapControl.Map.DeleteLayer(layer);
            m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, layer.AreaOfInterest);

            //IMxDocument pMxDoc = ArcMap.Document;
            //IMap pMap = (IMap)pMxDoc.ActiveView;
            //IGeometry pgeom = (IGeometry)pFeature.Shape;
            //pMap.SelectByShape(pgeom, null, false);
            //mapCooker.Clear(layer, iEnvelope);
        }
	
		public override void OnCreate(object hook)
		{
			m_mapControl = (IMapControl3) hook;
		}

	}
}


