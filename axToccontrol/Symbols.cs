using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace QLHTDT.axToccontrol
{
    public class SnapSymbol_Example
    {
        #region SnapSymbol_Example members
        private IEditor m_editor;
        private IEditEvents_Event m_editorEvents;
        private IEditProperties m_editProperties;
        #endregion

        public SnapSymbol_Example(IEditor editor)
        {
            m_editor = editor;
            m_editorEvents = m_editor as IEditEvents_Event;
            m_editProperties = m_editor as IEditProperties;
            //setup and register delegates
            IEditEvents_OnCurrentLayerChangedEventHandler editEvents_OnCurrentLayerChangedEventHandler = new IEditEvents_OnCurrentLayerChangedEventHandler(this.OnCurrentLayerChanged);
            m_editorEvents.OnCurrentLayerChanged += editEvents_OnCurrentLayerChangedEventHandler;
        }
        public void OnCurrentLayerChanged()
        {
            IEditLayers editLayers = m_editor as IEditLayers;

            //Check that the current layer contains point features
            if (editLayers.CurrentLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
            {
                IGeoFeatureLayer geoFeatureLayer = editLayers.CurrentLayer as IGeoFeatureLayer;
                IFeatureRenderer renderer = geoFeatureLayer.Renderer;
                renderer.ToString();
                //Make sure that a uniquevalue renderer is being used to display the points

                ISymbol symbol = null;
                if (renderer is IUniqueValueRenderer)
                {
                    //Check if data has subtypes
                    ISubtypes layerSubTypes = editLayers.CurrentLayer.FeatureClass as ISubtypes;
                    IUniqueValueRenderer uniqueValueRenderer = geoFeatureLayer.Renderer as IUniqueValueRenderer;

                    if (layerSubTypes.HasSubtype)
                    {
                        int value = editLayers.CurrentSubtype;
                        symbol = uniqueValueRenderer.get_Symbol(value.ToString());
                    }
                    symbol = uniqueValueRenderer.DefaultSymbol;
                }
                if (symbol == null)
                {
                    System.Windows.Forms.MessageBox.Show("Renderer must be UniqueValueRenderer");
                    return;
                }
                //Set the ROP property so the symbol will clear itself on redraw
                symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;
                m_editProperties.SnapSymbol = symbol as IMarkerSymbol;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Layer must be polyline or polygon");
            }
        }


        static void DefineUniqueValueRenderer(IGeoFeatureLayer pGeoFeatureLayer, string fieldName)
        {

            IRandomColorRamp pRandomColorRamp = new RandomColorRampClass();
            //Make the color ramp for the symbols in the renderer.
            pRandomColorRamp.MinSaturation = 20;
            pRandomColorRamp.MaxSaturation = 40;
            pRandomColorRamp.MinValue = 85;
            pRandomColorRamp.MaxValue = 100;
            pRandomColorRamp.StartHue = 76;
            pRandomColorRamp.EndHue = 188;
            pRandomColorRamp.UseSeed = true;
            pRandomColorRamp.Seed = 43;

            //Make the renderer.
            IUniqueValueRenderer pUniqueValueRenderer = new UniqueValueRendererClass();

            ISimpleFillSymbol pSimpleFillSymbol = new SimpleFillSymbolClass();
            pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
            pSimpleFillSymbol.Outline.Width = 0.4;

            //These properties should be set prior to adding values.
            pUniqueValueRenderer.FieldCount = 1;
            pUniqueValueRenderer.set_Field(0, fieldName);
            pUniqueValueRenderer.DefaultSymbol = pSimpleFillSymbol as ISymbol;
            pUniqueValueRenderer.UseDefaultSymbol = true;

            IDisplayTable pDisplayTable = pGeoFeatureLayer as IDisplayTable;
            IFeatureCursor pFeatureCursor = pDisplayTable.SearchDisplayTable(null, false) as IFeatureCursor;
            IFeature pFeature = pFeatureCursor.NextFeature();


            bool ValFound;
            int fieldIndex;

            IFields pFields = pFeatureCursor.Fields;
            fieldIndex = pFields.FindField(fieldName);
            while (pFeature != null)
            {
                ISimpleFillSymbol pClassSymbol = new SimpleFillSymbolClass();
                pClassSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
                pClassSymbol.Outline.Width = 0.4;

                string classValue;
                classValue = pFeature.get_Value(fieldIndex) as string;

                //Test to see if this value was added
                //to the renderer. If not, add it.
                ValFound = false;
                for (int i = 0; i <= pUniqueValueRenderer.ValueCount - 1; i++)
                {
                    if (pUniqueValueRenderer.get_Value(i) == classValue)
                    {
                        ValFound = true;
                        break; //Exit the loop if the value was found.
                    }
                }
                //If the value was not found, it is new and it will be added.
                if (ValFound == false)
                {
                    pUniqueValueRenderer.AddValue(classValue, fieldName, pClassSymbol as ISymbol);
                    pUniqueValueRenderer.set_Label(classValue, classValue);
                    pUniqueValueRenderer.set_Symbol(classValue, pClassSymbol as ISymbol);
                }
                pFeature = pFeatureCursor.NextFeature();
            }
            //Since the number of unique values is known, 
            //the color ramp can be sized and the colors assigned.
            pRandomColorRamp.Size = pUniqueValueRenderer.ValueCount;
            bool bOK;
            pRandomColorRamp.CreateRamp(out bOK);

            IEnumColors pEnumColors = pRandomColorRamp.Colors;
            pEnumColors.Reset();
            for (int j = 0; j <= pUniqueValueRenderer.ValueCount - 1; j++)
            {
                string xv;
                xv = pUniqueValueRenderer.get_Value(j);
                if (xv != "")
                {
                    ISimpleFillSymbol pSimpleFillColor = pUniqueValueRenderer.get_Symbol(xv) as ISimpleFillSymbol;
                    pSimpleFillColor.Color = pEnumColors.Next();
                    pUniqueValueRenderer.set_Symbol(xv, pSimpleFillColor as ISymbol);

                }
            }

            //'** If you didn't use a predefined color ramp
            //'** in a style, use "Custom" here. Otherwise,
            //'** use the name of the color ramp you selected.
            pUniqueValueRenderer.ColorScheme = "Custom";
            ITable pTable = pDisplayTable as ITable;
            bool isString = pTable.Fields.get_Field(fieldIndex).Type == esriFieldType.esriFieldTypeString;
            pUniqueValueRenderer.set_FieldType(0, isString);
            pGeoFeatureLayer.Renderer = pUniqueValueRenderer as IFeatureRenderer;

            //This makes the layer properties symbology tab
            //show the correct interface.
            IUID pUID = new UIDClass();
            pUID.Value = "{683C994E-A17B-11D1-8816-080009EC732A}";
            pGeoFeatureLayer.RendererPropertyPageClassID = pUID as UIDClass;

        }
    }
}
