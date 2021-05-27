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

using System;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using System.Runtime.InteropServices;
using System.Drawing;

namespace QLHTDT.Trangin
{
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("283181EA-08F8-468f-A8FA-4ADEDC087C74")]

	public sealed class CreateText : BaseTool
	{
		private IHookHelper m_HookHelper; 
		private INewEnvelopeFeedback m_Feedback;
		private IPoint m_Point; 
		private bool m_InUse;
        private ITextSymbol m_textSymbol; 

		//Windows API functions to capture mouse and keyboard
		//input to a window when the mouse is outside the window
		[DllImport("User32", CharSet=CharSet.Auto)]
		private static extern int SetCapture(int hWnd);
		[DllImport("User32", CharSet=CharSet.Auto)]
		private static extern int GetCapture();
		[DllImport("User32", CharSet=CharSet.Auto)]
		private static extern int ReleaseCapture();

		#region Component Category Registration
		[ComRegisterFunction()]
		[ComVisible(false)]
		static void RegisterFunction(String sKey)
		{
			ControlsCommands.Register(sKey);
		}
		[ComUnregisterFunction()]
		[ComVisible(false)]
		static void UnregisterFunction(String sKey)
		{
			ControlsCommands.Unregister(sKey);
		}
		#endregion

		public CreateText()
		{
		    //Create an IHookHelper object
			m_HookHelper = new HookHelperClass();

			//Set the tool properties
            string bitmapResourceName = GetType().Name + ".bmp";
            base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
			base.m_caption = "Tên Bản Đồ";
            base.m_category = "Biên tập trang in";
            base.m_message = "Thêm tên bản đồ";
			base.m_name = "ScaleText";
            base.m_toolTip = "Thêm tên bản đồ";
			base.m_deactivate = true;
		}
	
		public override void OnCreate(object hook)
		{
			m_HookHelper.Hook = hook;
            //QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.OnMouseDown += new IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(OnMouseDown); 
		}
        public override void OnClick()
        {
            //QLHTDT.FormChinh.QuanTriHeThong.axPageLayoutControl1.OnMouseDown -= new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(QLHTDT.FormChinh.QuanTriHeThong.MenuPage);

        }
		public override void OnMouseDown(int Button, int Shift, int X, int Y)
		{
			//Create a point in map coordinates
			m_Point = m_HookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);

			//Start capturing mouse events
			SetCapture(m_HookHelper.ActiveView.ScreenDisplay.hWnd);

			m_InUse = true;	
		}
	
		public override void OnMouseMove(int Button, int Shift, int X, int Y)
		{
			if (m_InUse == false) return;

			//Start an envelope feedback
			if (m_Feedback == null )
			{
				m_Feedback = new NewEnvelopeFeedbackClass();
				m_Feedback.Display = m_HookHelper.ActiveView.ScreenDisplay;
				m_Feedback.Start(m_Point);
			}

			//Move the envelope feedback
			m_Feedback.MoveTo(m_HookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y));
		}
	
		public override void OnMouseUp(int Button, int Shift, int X, int Y)
		{
			if (m_InUse == false) return;

			//Stop capturing mouse events
			if (GetCapture() == m_HookHelper.ActiveView.ScreenDisplay.hWnd)
				ReleaseCapture();

			//If an envelope has not been tracked or its height/width is 0
			if (m_Feedback == null)
			{
				m_Feedback = null;
				m_InUse = false;
				return;
			}
			IEnvelope envelope = m_Feedback.Stop();
			if ((envelope.IsEmpty) || (envelope.Width == 0) || (envelope.Height == 0))
			{
				m_Feedback = null;
				m_InUse = false;
				return;
			}

			//Create the form with the SymbologyControl
            QLHTDT.Trangin.Symboltext symbolForm = new QLHTDT.Trangin.Symboltext();
			//Get the IStyleGalleryItem
			IStyleGalleryItem styleGalleryItem = symbolForm.GetItem(esriSymbologyStyleClass.esriStyleClassTextSymbols);
			//Release the form
			symbolForm.Dispose();
			if (styleGalleryItem == null) return;

			//Get the map frame of the focus map
			IMapFrame mapFrame = (IMapFrame) m_HookHelper.ActiveView.GraphicsContainer.FindFrame(m_HookHelper.ActiveView.FocusMap);

			//Create a map surround frame
			IMapSurroundFrame mapSurroundFrame = new MapSurroundFrameClass(); 
			//Set its map frame and map surround
            
            //mapSurroundFrame.MapFrame = mapFrame;
            //mapSurroundFrame.MapSurround = (IMapSurround) styleGalleryItem.Item;
            m_textSymbol = (ITextSymbol)styleGalleryItem.Item;
			//QI to IElement and set its geometry
            //IElement element = (IElement) mapSurroundFrame;
            int value = (int)QLHTDT.Trangin.Symboltext.txtCoChu.Value;
            m_textSymbol.Size = value;
            ITextElement textElement = new TextElementClass();
            //Set the text to display todays date
            textElement.Text = QLHTDT.Trangin.Symboltext.txtTenBD.Text;
            IElement element = (IElement)textElement;
            textElement.Symbol = m_textSymbol;
            textElement.ScaleText = true;
            
            //Set the TextElement's geometry
            element.Geometry = envelope;

			//Add the element to the graphics container
            m_HookHelper.ActiveView.GraphicsContainer.AddElement(element, 0);

			//Refresh
            m_HookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, element, null);
            element.Locked = false;
			m_Feedback = null;
			m_InUse = false;


		}
        
	}
}
