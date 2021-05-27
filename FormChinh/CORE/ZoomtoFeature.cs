using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;

namespace QLHTDT.CORE
{
    class ZoomtoFeature
    {
        private IMap pMap;
        IEnvelope pEnv = null;

        public ZoomtoFeature(IFeature p, IMap _Map, ILayer Layer)
        {
            pMap = _Map;
            pEnv = p.ShapeCopy.Envelope;
            pMap.ClearSelection();
            pMap.SelectFeature(Layer, p);
        }
        

        /// <summary>
        /// Phong to tới điểm
        /// </summary>
        /// <remarks></remarks>
        public void ZoomtoPoint()
        {
            IActiveView ActiveView = pMap as IActiveView;

            ActiveView.Extent = pEnv;
            pMap.MapScale = 1000;
            ActiveView.Refresh();
        }

    }
}
