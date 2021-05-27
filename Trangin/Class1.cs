using System;

using System.Diagnostics;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

[ComVisible(true)]
[Guid("5722878B-CB0C-48BA-87E3-4800155028B7")]
[ClassInterface(ClassInterfaceType.None)]
[ProgId("Custom.CustomFeatureLayer")]
public class CustomFeatureLayer :
    
    ILayer,
    ILayer2,
    IDataLayer,
    IDataLayer2,
    ITemporaryLayer,
    IPublishLayer,
    IFeatureLayer,
    IFeatureLayer2,
    IGeoFeatureLayer,
    IFeatureLayerDefinition,
    IFeatureLayerDefinition2,
    IFeatureSelection,
    IMapLevel,
    ISymbolLevels,
    IDisplayAdmin,
    IDisplayFilterManager,
    IDisplayString,
    IDisplayTable,
    IAttributeTable,
    IConnectionPointContainer,
    IDataset,
    IGeoDataset,

    ILayerDrawingProperties,
    ILayerEffects,
    ILayerExtensions,
    ILayerFields,
    ILayerGeneralProperties,
    ILayerInfo,
    ILayerPosition,
    //ILayerSymbologyExtents,
    ILegendInfo

    /*
    IDisplayRelationshipClass,
    IRelationshipClassCollection,
    IRelationshipClassCollectionEdit,

    IFind,
IHotlinkContainer
IHotlinkExpression
IHotlinkMacro
IHTMLPopupIdentify
IHTMLPopupIdentify2
IHTMLPopupInfo
IHTMLPopupInfo2
IHyperlinkContainer
IIdentify
IIdentify2
IIdentifyDisplay
IObjectClassSchemaEvents (esriGeoDatabase)
IOrderedLayerFields
IPersistStream (esriSystem)
IPropertySupport (esriSystem)
ITable (esriGeoDatabase)
ITableCapabilities (esriGeoDatabase)
ITableDefinition
ITableFields (esriGeoDatabase)
ITableSelection
ITimeData
ITimeDataDisplay
ITimeDimensionDefinition
ITimeDisplayTable
ITimeTableDefinition
IWorkspaceEvents (esriGeoDatabase)
    */
{
    public ILayer m_BaseLayer = null;

    public CustomFeatureLayer()
    {
    }

    public CustomFeatureLayer(IGeoFeatureLayer geoLayer)
    {
        this.m_BaseLayer = geoLayer;
    }

    public void LoadCore(IVariantStream stream)
    {
    }

    public void SaveCore(IVariantStream stream)
    {
    }

    public IEnvelope AreaOfInterest
    {
        get
        {
            Debug.Print("AreaOfInterest get");
            return ((ILayer)this.m_BaseLayer).AreaOfInterest;
        }
    }

    public bool Cached
    {
        get
        {
            Debug.Print("Cached get");
            return ((ILayer)this.m_BaseLayer).Cached;
        }
        set
        {
            Debug.Print("Cached set");
            ((ILayer)this.m_BaseLayer).Cached = value;
        }
    }

    public void Draw(esriDrawPhase DrawPhase, IDisplay Display, ITrackCancel TrackCancel)
    {
        Debug.Print("Draw");

        ((ILayer)this.m_BaseLayer).Draw(DrawPhase, Display, TrackCancel);
    }

    public double MaximumScale
    {
        get
        {
            Debug.Print("MaximumScale get");
            return ((ILayer)this.m_BaseLayer).MaximumScale;
        }
        set
        {
            Debug.Print("MaximumScale set");
            ((ILayer)this.m_BaseLayer).MaximumScale = value;
        }
    }

    public double MinimumScale
    {
        get
        {
            Debug.Print("MinimumScale get");
            return ((ILayer)this.m_BaseLayer).MinimumScale;
        }
        set
        {
            Debug.Print("MinimumScale set");
            ((ILayer)this.m_BaseLayer).MinimumScale = value;
        }
    }

    public string Name
    {
        get
        {
            Debug.Print("Name get");
            return ((ILayer)this.m_BaseLayer).Name;
        }
        set
        {
            Debug.Print("Name set");
            ((ILayer)this.m_BaseLayer).Name = value;
        }
    }

    public bool ShowTips
    {
        get
        {
            Debug.Print("ShowTips get");
            return ((ILayer)this.m_BaseLayer).ShowTips;
        }
        set
        {
            Debug.Print("ShowTips set");
            ((ILayer)this.m_BaseLayer).ShowTips = value;
        }
    }

    public ISpatialReference SpatialReference
    {
        set
        {
            Debug.Print("SpatialReference set");
            ((ILayer)this.m_BaseLayer).SpatialReference = value;
        }
    }

    public int SupportedDrawPhases
    {
        get
        {
            Debug.Print("SupportedDrawPhases get");
            return ((ILayer)this.m_BaseLayer).SupportedDrawPhases;
        }
    }

    public bool Valid
    {
        get
        {
            Debug.Print("Valid get");
            return ((ILayer)this.m_BaseLayer).Valid;
        }
    }

    public bool Visible
    {
        get
        {
            Debug.Print("Visible get");
            return ((ILayer)this.m_BaseLayer).Visible;
        }
        set
        {
            Debug.Print("Visible set");
            ((ILayer)this.m_BaseLayer).Visible = value;
        }
    }

    public string get_TipText(double x, double y, double Tolerance)
    {
        Debug.Print("get_TipText");
        return ((ILayer)this.m_BaseLayer).get_TipText(x, y, Tolerance);
    }

    IEnvelope ILayer2.AreaOfInterest
    {
        get
        {
            Debug.Print("AreaOfInterest get");
            return ((ILayer2)this.m_BaseLayer).AreaOfInterest;
        }
        set
        {
            Debug.Print("AreaOfInterest set");
            ((ILayer2)this.m_BaseLayer).AreaOfInterest = value;
        }
    }

    public bool ScaleRangeReadOnly
    {
        get
        {
            Debug.Print("ScaleRangeReadOnly get");
            return ((ILayer2)this.m_BaseLayer).ScaleRangeReadOnly;
        }
    }

    public bool Connect(IName pOptRepairName)
    {
        Debug.Print("Connect");
        return ((IDataLayer)this.m_BaseLayer).Connect(pOptRepairName);
    }

    public IName DataSourceName
    {
        get
        {
            Debug.Print("DataSourceName get");
            return ((IDataLayer)this.m_BaseLayer).DataSourceName;
        }
        set
        {
            Debug.Print("DataSourceName set");
            ((IDataLayer)this.m_BaseLayer).DataSourceName = value;
        }
    }

    public string RelativeBase
    {
        get
        {
            Debug.Print("RelativeBase get");
            return ((IDataLayer)this.m_BaseLayer).RelativeBase;
        }
        set
        {
            Debug.Print("RelativeBase set");
            ((IDataLayer)this.m_BaseLayer).RelativeBase = value;
        }
    }

    public bool get_DataSourceSupported(IName Name)
    {
        Debug.Print("get_DataSourceSupported");
        return ((IDataLayer)this.m_BaseLayer).get_DataSourceSupported(Name);
    }

    public void Disconnect()
    {
        Debug.Print("Disconnect");
        ((IDataLayer2)this.m_BaseLayer).Disconnect();
    }

    public bool InWorkspace(IWorkspace Workspace)
    {
        Debug.Print("InWorkspace");
        return ((IDataLayer2)this.m_BaseLayer).InWorkspace(Workspace);
    }

    public bool Temporary
    {
        get
        {
            Debug.Print("Temporary get");
            return ((ITemporaryLayer)this.m_BaseLayer).Temporary;
        }
        set
        {
            Debug.Print("Temporary set");
            ((ITemporaryLayer)this.m_BaseLayer).Temporary = value;
        }
    }

    public bool DataValid
    {
        get
        {
            Debug.Print("DataValid get");
            return ((IPublishLayer)this.m_BaseLayer).DataValid;
        }
    }

    public void PrepareForPublishing()
    {
        Debug.Print("PrepareForPublishing");
        ((IPublishLayer)this.m_BaseLayer).PrepareForPublishing();
    }

    public string PublishingDescription
    {
        get
        {
            Debug.Print("PublishingDescription get");
            return
                ((IPublishLayer)this.m_BaseLayer).PublishingDescription;
        }
    }

    public bool SupportsPublishing
    {
        get
        {
            Debug.Print("SupportsPublishing get");
            return ((IPublishLayer)this.m_BaseLayer).SupportsPublishing;
        }
    }

    public string get_DataDetails(string bsPadding)
    {

        Debug.Print("get_DataDetails");
        return
            ((IPublishLayer)this.m_BaseLayer).get_DataDetails(bsPadding);
    }

    public string DataSourceType
    {
        get
        {
            Debug.Print("DataSourceType get");
            return ((IFeatureLayer)this.m_BaseLayer).DataSourceType;
        }
        set
        {
            Debug.Print("DataSourceType set");
            ((IFeatureLayer)this.m_BaseLayer).DataSourceType = value;
        }
    }

    public string DisplayField
    {
        get
        {
            Debug.Print("DisplayField get");
            return ((IFeatureLayer)this.m_BaseLayer).DisplayField;
        }
        set
        {
            Debug.Print("DisplayField set");
            ((IFeatureLayer)this.m_BaseLayer).DisplayField = value;
        }
    }

    public IFeatureClass FeatureClass
    {
        get
        {
            Debug.Print("FeatureClass get");
            return ((IFeatureLayer)this.m_BaseLayer).FeatureClass;
        }
        set
        {
            Debug.Print("FeatureClass set");
            ((IFeatureLayer)this.m_BaseLayer).FeatureClass = value;
        }
    }

    public bool ScaleSymbols
    {
        get
        {
            Debug.Print("ScaleSymbols get");
            return ((IFeatureLayer)this.m_BaseLayer).ScaleSymbols;
        }
        set
        {
            Debug.Print("ScaleSymbols set");
            ((IFeatureLayer)this.m_BaseLayer).ScaleSymbols = value;
        }
    }

    public IFeatureCursor Search(IQueryFilter queryFilter, bool recycling)
    {
        Debug.Print("Search");
        return ((IFeatureLayer)this.m_BaseLayer).Search(queryFilter, recycling);
    }

    public bool Selectable
    {
        get
        {
            Debug.Print("Selectable get");
            return ((IFeatureLayer)this.m_BaseLayer).Selectable;
        }
        set
        {
            Debug.Print("Selectable set");
            ((IFeatureLayer)this.m_BaseLayer).Selectable = value;
        }
    }

    public void ExpandRegionForSymbols(IDisplay Display, IGeometry region)
    {
        Debug.Print("ExpandRegionForSymbols");
        ((IFeatureLayer2)this.m_BaseLayer).ExpandRegionForSymbols(Display, region);
    }

    public esriGeometryType ShapeType
    {
        get
        {
            Debug.Print("esriGeometryType get");
            return ((IFeatureLayer2)this.m_BaseLayer).ShapeType;
        }
    }

    public IAnnotateLayerPropertiesCollection AnnotationProperties
    {
        get
        {
            Debug.Print("IAnnotateLayerPropertiesCollection get");
            return ((IGeoFeatureLayer)this.m_BaseLayer).AnnotationProperties;
        }
        set
        {
            Debug.Print("IAnnotateLayerPropertiesCollection set");
            ((IGeoFeatureLayer)this.m_BaseLayer).AnnotationProperties = value;
        }
    }

    public UID AnnotationPropertiesID
    {
        get
        {
            Debug.Print("AnnotationPropertiesID get");
            return ((IGeoFeatureLayer)this.m_BaseLayer).AnnotationPropertiesID;
        }
        set
        {
            Debug.Print("AnnotationPropertiesID set");
            ((IGeoFeatureLayer)this.m_BaseLayer).AnnotationPropertiesID = value;
        }
    }

    public int CurrentMapLevel
    {
        set
        {
            Debug.Print("CurrentMapLevel set");
            ((IGeoFeatureLayer)this.m_BaseLayer).CurrentMapLevel = value;
        }
    }

    public bool DisplayAnnotation
    {
        get
        {
            Debug.Print("DisplayAnnotation get");
            return ((IGeoFeatureLayer)this.m_BaseLayer).DisplayAnnotation;
        }
        set
        {
            Debug.Print("DisplayAnnotation set");
            ((IGeoFeatureLayer)this.m_BaseLayer).DisplayAnnotation = value;
        }
    }

    public IFeatureClass DisplayFeatureClass
    {
        get
        {
            Debug.Print("DisplayFeatureClass get");
            return ((IGeoFeatureLayer)this.m_BaseLayer).DisplayFeatureClass;
        }
    }

    public IFeatureIDSet ExclusionSet
    {
        get
        {
            Debug.Print("ExclusionSet get");
            return ((IGeoFeatureLayer)this.m_BaseLayer).ExclusionSet;
        }
        set
        {
            Debug.Print("ExclusionSet set");
            ((IGeoFeatureLayer)this.m_BaseLayer).ExclusionSet = value;
        }
    }

    public IFeatureRenderer Renderer
    {
        get
        {
            Debug.Print("Renderer get");
            return ((IGeoFeatureLayer)this.m_BaseLayer).Renderer;
        }
        set
        {
            Debug.Print("Renderer set");
            ((IGeoFeatureLayer)this.m_BaseLayer).Renderer = value;
        }
    }

    public UID RendererPropertyPageClassID
    {
        get
        {
            Debug.Print("RendererPropertyPageClassID get");
            return ((IGeoFeatureLayer)this.m_BaseLayer).RendererPropertyPageClassID;
        }
        set
        {
            Debug.Print("RendererPropertyPageClassID set");
            ((IGeoFeatureLayer)this.m_BaseLayer).RendererPropertyPageClassID = value;
        }
    }

    public IFeatureCursor SearchDisplayFeatures(IQueryFilter queryFilter, bool recycling)
    {
        Debug.Print("SearchDisplayFeatures");
        return ((IGeoFeatureLayer)this.m_BaseLayer).SearchDisplayFeatures(queryFilter, recycling);
    }

    public IFeatureLayer CreateSelectionLayer(string LayerName, bool useCurrentSelection, string joinTableNames, string Expression)
    {
        Debug.Print("CreateSelectionLayer");
        return ((IFeatureLayerDefinition)this.m_BaseLayer).CreateSelectionLayer(LayerName, useCurrentSelection, joinTableNames, Expression);
    }

    public string DefinitionExpression
    {
        get
        {
            Debug.Print("DefinitionExpression get");
            return ((IFeatureLayerDefinition)this.m_BaseLayer).DefinitionExpression;
        }
        set
        {
            Debug.Print("DefinitionExpression set");
            ((IFeatureLayerDefinition)this.m_BaseLayer).DefinitionExpression = value;
        }
    }

    public ISelectionSet DefinitionSelectionSet
    {
        get
        {
            Debug.Print("DefinitionExpression get");
            return ((IFeatureLayerDefinition)this.m_BaseLayer).DefinitionSelectionSet;
        }
    }

    public IRelationshipClass RelationshipClass
    {
        get
        {
            Debug.Print("RelationshipClass get");
            return ((IFeatureLayerDefinition)this.m_BaseLayer).RelationshipClass;
        }
        set
        {
            Debug.Print("RelationshipClass set");
            ((IFeatureLayerDefinition)this.m_BaseLayer).RelationshipClass = value;
        }
    }

    public esriSearchOrder SearchOrder
    {
        get
        {
            Debug.Print("SearchOrder get");
            return ((IFeatureLayerDefinition2)this.m_BaseLayer).SearchOrder;
        }
        set
        {
            Debug.Print("SearchOrder set");
            ((IFeatureLayerDefinition2)this.m_BaseLayer).SearchOrder = value;
        }
    }

    public void Add(IFeature Feature)
    {
        Debug.Print("SearchOrder set");
        ((IFeatureSelection)this.m_BaseLayer).Add(Feature);
    }

    public double BufferDistance
    {
        get
        {
            Debug.Print("BufferDistance get");
            return
            ((IFeatureSelection)this.m_BaseLayer).BufferDistance;
        }
        set
        {
            Debug.Print("BufferDistance set");
            ((IFeatureSelection)this.m_BaseLayer).BufferDistance = value;
        }
    }

    public void Clear()
    {
        Debug.Print("Clear");
        ((IFeatureSelection)this.m_BaseLayer).Clear();
    }

    public esriSelectionResultEnum CombinationMethod
    {
        get
        {
            Debug.Print("CombinationMethod get");
            return
                ((IFeatureSelection)this.m_BaseLayer).CombinationMethod;
        }
        set
        {
            Debug.Print("CombinationMethod set");
            ((IFeatureSelection)this.m_BaseLayer).CombinationMethod = value;
        }
    }

    public void SelectFeatures(IQueryFilter Filter, esriSelectionResultEnum Method, bool justOne)
    {
        Debug.Print("SelectFeatures");
        ((IFeatureSelection)this.m_BaseLayer).SelectFeatures(Filter, Method, justOne);
    }

    public void SelectionChanged()
    {
        Debug.Print("SelectionChanged");
        ((IFeatureSelection)this.m_BaseLayer).SelectionChanged();
    }

    public IColor SelectionColor
    {
        get
        {
            Debug.Print("SelectionColor get");
            return
                ((IFeatureSelection)this.m_BaseLayer).SelectionColor;
        }
        set
        {
            Debug.Print("SelectionColor set");
            ((IFeatureSelection)this.m_BaseLayer).SelectionColor = value;
        }
    }

    public ISelectionSet SelectionSet
    {
        get
        {
            Debug.Print("SelectionSet get");
            return
                ((IFeatureSelection)this.m_BaseLayer).SelectionSet;
        }
        set
        {
            Debug.Print("SelectionSet set");
            ((IFeatureSelection)this.m_BaseLayer).SelectionSet = value;
        }
    }

    public ISymbol SelectionSymbol
    {
        get
        {
            Debug.Print("SelectionSymbol get");
            return
                ((IFeatureSelection)this.m_BaseLayer).SelectionSymbol;
        }
        set
        {
            Debug.Print("SelectionSymbol set");
            ((IFeatureSelection)this.m_BaseLayer).SelectionSymbol = value;
        }
    }

    public bool SetSelectionSymbol
    {
        get
        {
            Debug.Print("SetSelectionSymbol get");
            return
                ((IFeatureSelection)this.m_BaseLayer).SetSelectionSymbol;
        }
        set
        {
            Debug.Print("SetSelectionSymbol set");
            ((IFeatureSelection)this.m_BaseLayer).SetSelectionSymbol = value;
        }
    }

    public int MapLevel
    {
        get
        {
            Debug.Print("MapLevel get");
            return
              ((IMapLevel)this.m_BaseLayer).MapLevel;
        }
        set
        {
            Debug.Print("MapLevel set");
            ((IMapLevel)this.m_BaseLayer).MapLevel = value;
        }
    }

    public bool UseSymbolLevels
    {
        get
        {
            Debug.Print("UseSymbolLevels get");
            return ((ISymbolLevels)this.m_BaseLayer).UseSymbolLevels;
        }
        set
        {
            Debug.Print("UseSymbolLevels set");
            ((ISymbolLevels)this.m_BaseLayer).UseSymbolLevels = value;
        }
    }

    public bool UsesFilter
    {
        get
        {
            Debug.Print("UsesFilter get");
            return ((IDisplayAdmin)this.m_BaseLayer).UsesFilter;
        }
    }

    public IDisplayFilter DisplayFilter
    {
        get
        {
            Debug.Print("DisplayFilter get");
            return ((IDisplayFilterManager)this.m_BaseLayer).DisplayFilter;
        }
        set
        {
            Debug.Print("DisplayFilter set");
            ((IDisplayFilterManager)this.m_BaseLayer).DisplayFilter = value;
        }
    }

    public IDisplayExpressionProperties ExpressionProperties
    {
        get
        {
            Debug.Print("ExpressionProperties get");
            return ((IDisplayString)this.m_BaseLayer).ExpressionProperties;
        }
        set
        {
            Debug.Print("ExpressionProperties set");
            ((IDisplayString)this.m_BaseLayer).ExpressionProperties = value;
        }
    }

    public string FindDisplayString(IObject pObject)
    {
        Debug.Print("FindDisplayString");
        return ((IDisplayString)this.m_BaseLayer).FindDisplayString(pObject);
    }

    public ISelectionSet DisplaySelectionSet
    {
        get
        {
            Debug.Print("DisplaySelectionSet get");
            return ((IDisplayTable)this.m_BaseLayer).DisplaySelectionSet;
        }
    }

    public ITable DisplayTable
    {
        get
        {
            Debug.Print("DisplayTable get");
            return ((IDisplayTable)this.m_BaseLayer).DisplayTable;
        }
    }

    public ICursor SearchDisplayTable(IQueryFilter pQueryFilter, bool recycling)
    {
        Debug.Print("SearchDisplayTable");
        return ((IDisplayTable)this.m_BaseLayer).SearchDisplayTable(pQueryFilter, recycling);
    }

    public ISelectionSet SelectDisplayTable(IQueryFilter pQueryFilter, esriSelectionType selType, esriSelectionOption selOption, IWorkspace pSelWorkspace)
    {
        Debug.Print("SelectDisplayTable");
        return ((IDisplayTable)this.m_BaseLayer).SelectDisplayTable(pQueryFilter, selType, selOption, pSelWorkspace);
    }

    public ITable AttributeTable
    {
        get
        {
            Debug.Print("AttributeTable get");
            return ((IAttributeTable)this.m_BaseLayer).AttributeTable;
        }
    }

    public void EnumConnectionPoints(out IEnumConnectionPoints ppEnum)
    {
        Debug.Print("EnumConnectionPoints");
        ((IConnectionPointContainer)this.m_BaseLayer).EnumConnectionPoints(out ppEnum);
    }

    public void FindConnectionPoint(ref Guid riid, out IConnectionPoint ppCP)
    {
        Debug.Print("FindConnectionPoint");
        ((IConnectionPointContainer)this.m_BaseLayer).FindConnectionPoint(ref riid, out ppCP);
    }

    public string BrowseName
    {
        get
        {
            Debug.Print("BrowseName get");
            return ((IDataset)this.m_BaseLayer).BrowseName;
        }
        set
        {
            Debug.Print("BrowseName set");
            ((IDataset)this.m_BaseLayer).BrowseName = value;
        }
    }

    public bool CanCopy()
    {
        Debug.Print("CanCopy");
        return ((IDataset)this.m_BaseLayer).CanCopy();
    }

    public bool CanDelete()
    {
        Debug.Print("CanDelete");
        return ((IDataset)this.m_BaseLayer).CanDelete();
    }

    public bool CanRename()
    {
        Debug.Print("CanRename");
        return ((IDataset)this.m_BaseLayer).CanRename();
    }

    public string Category
    {
        get
        {
            Debug.Print("Category get");
            return ((IDataset)this.m_BaseLayer).Category;
        }
    }

    public IDataset Copy(string copyName, IWorkspace copyWorkspace)
    {
        Debug.Print("Copy");
        return ((IDataset)this.m_BaseLayer).Copy(copyName, copyWorkspace);
    }

    public void Delete()
    {
        Debug.Print("Delete");
        ((IDataset)this.m_BaseLayer).Delete();
    }

    public IName FullName
    {
        get
        {
            Debug.Print("FullName get");
            return ((IDataset)this.m_BaseLayer).FullName;
        }
    }

    public IPropertySet PropertySet
    {
        get
        {
            Debug.Print("PropertySet get");
            return ((IDataset)this.m_BaseLayer).PropertySet;
        }
    }

    public void Rename(string Name)
    {
        Debug.Print("Rename");
        ((IDataset)this.m_BaseLayer).Rename(Name);
    }

    public IEnumDataset Subsets
    {
        get
        {
            Debug.Print("Subsets get");
            return ((IDataset)this.m_BaseLayer).Subsets;
        }
    }

    public esriDatasetType Type
    {
        get
        {
            Debug.Print("Type get");
            return ((IDataset)this.m_BaseLayer).Type;
        }
    }

    public IWorkspace Workspace
    {
        get
        {
            Debug.Print("Workspace get");
            return ((IDataset)this.m_BaseLayer).Workspace;
        }
    }

    public IEnvelope Extent
    {
        get
        {
            Debug.Print("Extent get");
            return ((IGeoDataset)this.m_BaseLayer).Extent;
        }
    }

    ISpatialReference IGeoDataset.SpatialReference
    {
        get
        {
            Debug.Print("IGeoDataset.SpatialReference get");
            return ((IGeoDataset)this.m_BaseLayer).SpatialReference;
        }
    }

    public bool DrawingPropsDirty
    {
        get
        {
            Debug.Print("DrawingPropsDirty get");
            return
               ((ILayerDrawingProperties)this.m_BaseLayer).DrawingPropsDirty;
        }
        set
        {
            Debug.Print("DrawingPropsDirty set");
            ((ILayerDrawingProperties)this.m_BaseLayer).DrawingPropsDirty = value;
        }
    }

    public short Brightness
    {
        get
        {
            Debug.Print("Brightness get");
            return
                ((ILayerEffects)this.m_BaseLayer).Brightness;
        }
        set
        {
            Debug.Print("Brightness set");
            ((ILayerEffects)this.m_BaseLayer).Brightness = value;
        }
    }

    public short Contrast
    {
        get
        {
            Debug.Print("Contrast get");
            return ((ILayerEffects)this.m_BaseLayer).Contrast;
        }
        set
        {
            Debug.Print("Contrast set");
            ((ILayerEffects)this.m_BaseLayer).Contrast = value;
        }
    }

    public bool SupportsBrightnessChange
    {
        get
        {
            Debug.Print("SupportsBrightnessChange get");
            return ((ILayerEffects)this.m_BaseLayer).SupportsBrightnessChange;
        }
    }

    public bool SupportsContrastChange
    {
        get
        {
            Debug.Print("SupportsContrastChange get");
            return ((ILayerEffects)this.m_BaseLayer).SupportsContrastChange;
        }
    }

    public bool SupportsInteractive
    {
        get
        {
            Debug.Print("SupportsInteractive get");
            return ((ILayerEffects)this.m_BaseLayer).SupportsInteractive;
        }
        set
        {
            Debug.Print("SupportsInteractive set");
            ((ILayerEffects)this.m_BaseLayer).SupportsInteractive = value;
        }
    }

    public bool SupportsTransparency
    {
        get
        {
            Debug.Print("SupportsTransparency get");
            return ((ILayerEffects)this.m_BaseLayer).SupportsTransparency;
        }
    }

    public short Transparency
    {
        get
        {
            Debug.Print("Transparency get");
            return ((ILayerEffects)this.m_BaseLayer).Transparency;
        }
        set
        {
            Debug.Print("Transparency set");
            ((ILayerEffects)this.m_BaseLayer).Transparency = value;
        }
    }

    public void AddExtension(object ext)
    {
        Debug.Print("AddExtension");
        ((ILayerExtensions)this.m_BaseLayer).AddExtension(ext);
    }

    public int ExtensionCount
    {
        get
        {
            Debug.Print("ExtensionCount get");
            return ((ILayerExtensions)this.m_BaseLayer).ExtensionCount;
        }
    }

    public void RemoveExtension(int Index)
    {
        Debug.Print("RemoveExtension");
        ((ILayerExtensions)this.m_BaseLayer).RemoveExtension(Index);
    }

    public object get_Extension(int Index)
    {
        Debug.Print("get_Extension");
        return ((ILayerExtensions)this.m_BaseLayer).get_Extension(Index);
    }

    public int FieldCount
    {
        get
        {
            Debug.Print("FieldCount get");
            return ((ILayerFields)this.m_BaseLayer).FieldCount;
        }
    }

    public int FindField(string FieldName)
    {
        Debug.Print("FindField");
        return ((ILayerFields)this.m_BaseLayer).FindField(FieldName);
    }

    public IField get_Field(int Index)
    {
        Debug.Print("get_Field");
        return ((ILayerFields)this.m_BaseLayer).get_Field(Index);
    }

    public IFieldInfo get_FieldInfo(int Index)
    {
        Debug.Print("get_FieldInfo");
        return ((ILayerFields)this.m_BaseLayer).get_FieldInfo(Index);
    }

    public double LastMaximumScale
    {
        get
        {
            Debug.Print("LastMaximumScale get");
            return ((ILayerGeneralProperties)this.m_BaseLayer).LastMaximumScale;
        }
    }

    public double LastMinimumScale
    {
        get
        {
            Debug.Print("LastMinimumScale get");
            return ((ILayerGeneralProperties)this.m_BaseLayer).LastMinimumScale;
        }
    }

    public string LayerDescription
    {
        get
        {
            Debug.Print("LayerDescription get");
            return ((ILayerGeneralProperties)this.m_BaseLayer).LayerDescription;
        }
        set
        {
            Debug.Print("LayerDescription set");
            ((ILayerGeneralProperties)this.m_BaseLayer).LayerDescription = value;
        }
    }

    public int LargeImage
    {
        get
        {
            Debug.Print("LargeImage get");
            return ((ILayerInfo)this.m_BaseLayer).LargeImage;
        }
    }

    public int LargeSelectedImage
    {
        get
        {
            Debug.Print("LargeSelectedImage get");
            return ((ILayerInfo)this.m_BaseLayer).LargeSelectedImage;
        }
    }

    public int SmallImage
    {
        get
        {
            Debug.Print("SmallImage get");
            return ((ILayerInfo)this.m_BaseLayer).SmallImage;
        }
    }

    public int SmallSelectedImage
    {
        get
        {
            Debug.Print("SmallSelectedImage get");
            return ((ILayerInfo)this.m_BaseLayer).SmallSelectedImage;
        }
    }

    public double LayerWeight
    {
        get
        {
            Debug.Print("LayerWeight get");
            return ((ILayerPosition)this.m_BaseLayer).LayerWeight;
        }
        set
        {
            Debug.Print("LayerWeight get");
            ((ILayerPosition)this.m_BaseLayer).LayerWeight = value;
        }
    }

    public int LegendGroupCount
    {
        get
        {
            Debug.Print("LegendGroupCount get");
            return ((ILegendInfo)this.m_BaseLayer).LegendGroupCount;
        }
    }

    public ILegendItem LegendItem
    {
        get
        {
            Debug.Print("LegendItem get");
            return ((ILegendInfo)this.m_BaseLayer).LegendItem;
        }
    }

    public bool SymbolsAreGraduated
    {
        get
        {
            Debug.Print("SymbolsAreGraduated get");
            return ((ILegendInfo)this.m_BaseLayer).SymbolsAreGraduated;
        }
        set
        {
            Debug.Print("SymbolsAreGraduated get");
            ((ILegendInfo)this.m_BaseLayer).SymbolsAreGraduated = value;
        }
    }

    public ILegendGroup get_LegendGroup(int Index)
    {
        Debug.Print("get_LegendGroup");
        return ((ILegendInfo)this.m_BaseLayer).get_LegendGroup(Index);
    }
}