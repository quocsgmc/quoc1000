using System;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Resources;
using System.Reflection;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

namespace QLHTDT.FormPhu.toolEdit
{
    /// <summary>
    /// Summary description for _1.
    /// </summary>
    [Guid("50fe45ae-46aa-409f-803f-5d2cf0df6a8f")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("QLHTDT.FormPhu.toolEdit._1")]
    public sealed class _1 : BaseTool
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Register(regKey);
            ControlsCommands.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);
            ControlsCommands.Unregister(regKey);
        }

        #endregion
        #endregion

        private long m_lSubType;
        private IHookHelper m_hookHelper = null;
        private IEngineEditor m_engineEditor;
        private IEngineEditLayers m_editLayer;
        private System.Windows.Forms.Cursor m_InsertVertexCursor;
        private System.Windows.Forms.Cursor m_DeleteVertexCursor;
        public _1()
        {
            //
            // TODO: Define values for the public properties
            //
            #region load the cursors

            try
            {
                m_InsertVertexCursor = new System.Windows.Forms.Cursor(GetType().Assembly.GetManifestResourceStream("QLHTDT.FormPhu.toolEdit.InsertVertexCursor.cur"));
                m_DeleteVertexCursor = new System.Windows.Forms.Cursor(GetType().Assembly.GetManifestResourceStream("QLHTDT.FormPhu.toolEdit.DeleteVertexCursor.cur"));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Cursor");
            }
            #endregion
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        //public override void OnCreate(object hook)
        //{
        //    try
        //    {
        //        m_hookHelper = new HookHelperClass();
        //        m_hookHelper.Hook = hook;
        //        m_engineEditor = new EngineEditorClass(); //this class is a singleton
        //        m_editLayer = m_engineEditor as IEngineEditLayers;
        //        if (m_hookHelper.ActiveView == null)
        //        {
        //            m_hookHelper = null;
        //        }
        //    }
        //    catch
        //    {
        //        m_hookHelper = null;
        //    }

        //    if (m_hookHelper == null)
        //        base.m_enabled = false;
        //    else
        //        base.m_enabled = true;

        //    // TODO:  Add other initialization code
        //}
        public override int Cursor
        {
            get
            {
                int iHandle = 0;

                switch (m_lSubType)
                {
                    case 1:
                        iHandle = m_InsertVertexCursor.Handle.ToInt32();
                        break;

                    case 2:
                        iHandle = m_DeleteVertexCursor.Handle.ToInt32();
                        break;
                }

                return (iHandle);
            }
        }
        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            //Find the Modify Feature task and set it as the current task
            IEngineEditTask editTask = m_engineEditor.GetTaskByUniqueName("ControlToolsEditing_ModifyFeatureTask");
            m_engineEditor.CurrentTask = editTask;
        }

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                m_engineEditor = new EngineEditorClass(); //this class is a singleton
                m_editLayer = m_engineEditor as IEngineEditLayers;
            }
            catch
            {
                m_hookHelper = null;
            }
        }
        public override bool Enabled
        {
            get
            {
                //check whether Editing 
                if (m_engineEditor.EditState == esriEngineEditState.esriEngineStateNotEditing)
                {
                    return false;
                }

                //check for appropriate geometry types
                esriGeometryType geomType = m_editLayer.TargetLayer.FeatureClass.ShapeType;
                if ((geomType != esriGeometryType.esriGeometryPolygon) & (geomType != esriGeometryType.esriGeometryPolyline))
                {
                    return false;
                }

                //check that only one feature is currently selected
                IFeatureSelection featureSelection = m_editLayer.TargetLayer as IFeatureSelection;
                ISelectionSet selectionSet = featureSelection.SelectionSet;
                if (selectionSet.Count != 1)
                {
                    return false;
                }

                //conditions have been met so enable the tool
                return true;
            }
        }
        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add _1.OnMouseDown implementation
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add _1.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            try
            {
                IEngineEditSketch editSketch = m_engineEditor as IEngineEditSketch;
                IGeometry editShape = editSketch.Geometry;

                //location clicked as a point object
                IPoint clickedPt = m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);

                #region local variables used in the HitTest

                IHitTest hitShape = editShape as IHitTest;
                IPoint hitPoint = new PointClass();
                double hitDistance = 0;
                int hitPartIndex = 0;
                int hitSegmentIndex = 0;
                bool bRightSide = false;
                esriGeometryHitPartType hitPartType = esriGeometryHitPartType.esriGeometryPartNone;

                //the searchRadius is the maximum distance away, in map units, from the shape that will be used
                //for the test - change to an appropriate value.
                double searchRadius = 1;
                switch (m_lSubType)
                {
                    case 1:
                        hitPartType = esriGeometryHitPartType.esriGeometryPartBoundary;
                        break;

                    case 2:
                        hitPartType = esriGeometryHitPartType.esriGeometryPartVertex;
                        break;
                }

                #endregion

                hitShape.HitTest(clickedPt, searchRadius, hitPartType, hitPoint, ref hitDistance, ref hitPartIndex, ref hitSegmentIndex, ref bRightSide);

                //check whether the HitTest was successful (i.e within the search radius)
                if (hitPoint.IsEmpty == false)
                {
                    IEngineSketchOperation sketchOp = new EngineSketchOperationClass();
                    sketchOp.Start(m_engineEditor);

                    //Get the PointCollection for a specific path or ring by hitPartIndex to handle multi-part features
                    IGeometryCollection geometryCol = editShape as IGeometryCollection;
                    IPointCollection pathOrRingPointCollection = geometryCol.get_Geometry(hitPartIndex) as IPointCollection;

                    object missing = Type.Missing;
                    object hitSegmentIndexObject = new object();
                    hitSegmentIndexObject = hitSegmentIndex;
                    object partIndexObject = new object();
                    partIndexObject = hitPartIndex;
                    esriEngineSketchOperationType opType = esriEngineSketchOperationType.esriEngineSketchOperationGeneral;

                    switch (m_lSubType)
                    {
                        case 1: //Insert Vertex 

                            //add new vertex to the path or ring PointCollection
                            pathOrRingPointCollection.AddPoint(clickedPt, ref missing, ref hitSegmentIndexObject);
                            sketchOp.SetMenuString("Insert Vertex (Custom)");
                            opType = esriEngineSketchOperationType.esriEngineSketchOperationVertexAdded;
                            break;

                        case 2: //Delete Vertex.

                            //delete a vertex from the path or ring PointCollection
                            pathOrRingPointCollection.RemovePoints(hitSegmentIndex, 1);
                            sketchOp.SetMenuString("Delete Vertex (Custom)");
                            opType = esriEngineSketchOperationType.esriEngineSketchOperationVertexDeleted;
                            break;
                    }

                    //remove the old PointCollection from the GeometryCollection and replace with the new one
                    geometryCol.RemoveGeometries(hitPartIndex, 1);
                    geometryCol.AddGeometry(pathOrRingPointCollection as IGeometry, ref partIndexObject, ref missing);

                    sketchOp.Finish(null, opType, clickedPt);

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Unexpected Error");
            }
        }
        #endregion

        #region ICommandSubType Interface

        /// <summary>
        /// Returns the number of subtyped commands
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return 2;
        }

        /// <summary>
        /// Sets the sub-type
        /// </summary>
        /// <param name="SubType"></param>
        public void SetSubType(int SubType)
        {
            m_lSubType = SubType;

            //set a common Command category for all subtypes
            base.m_category = "Vertex Cmds (C#)";

            ResourceManager rm = new ResourceManager("QLHTDT.FormPhu.toolEdit._1.Resources", Assembly.GetExecutingAssembly());

            switch (m_lSubType)
            {
                case 1: //Insert Vertex using the out-of-the-box ControlsEditingSketchInsertPointCommand command

                    base.m_caption = ("captio");
                    base.m_message = ("message");
                    base.m_toolTip = ("toolTip");
                    base.m_name = "VertexCommands_CustomInsertVertex";
                    base.m_cursor = m_InsertVertexCursor;

                    #region bitmap

                    try
                    {
                        base.m_bitmap = (System.Drawing.Bitmap)rm.GetObject("InsertVertex");
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
                    }

                    #endregion

                    break;

                case 2: //Delete vertex at clicked location using the out-of-the-box ControlsEditingSketchDeletePointCommand

                    base.m_caption = (string)rm.GetString("DeleteVertex_CommandCaption");
                    base.m_message = (string)rm.GetString("DeleteVertex_CommandMessage");
                    base.m_toolTip = (string)rm.GetString("DeleteVertex_CommandToolTip");
                    base.m_name = "VertexCommands_CustomDeleteVertex";
                    base.m_cursor = m_DeleteVertexCursor;

                    #region bitmap
                    try
                    {
                        base.m_bitmap = (System.Drawing.Bitmap)rm.GetObject("DeleteVertex");
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
                    }

                    #endregion

                    break;
            }
        }

        #endregion
    }
}
