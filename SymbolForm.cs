// Copyright 2008 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See use restrictions at <your ArcGIS install location>/developerkit/userestrictions.txt.
// 

using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;

namespace QLHTDT
{

	public class SymbolForm : System.Windows.Forms.Form
	{
		private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.ComponentModel.Container components = null;
		public IStyleGalleryItem m_styleGalleryItem;
        public static IStyleGalleryItem stylechon;
		public SymbolForm()
		{

			InitializeComponent();

		}


		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SymbolForm));
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Location = new System.Drawing.Point(8, 8);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(424, 494);
            this.axSymbologyControl1.TabIndex = 0;
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(462, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 96);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(462, 157);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(112, 24);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(462, 125);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(112, 24);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // SymbolForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(586, 514);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.axSymbologyControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SymbolForm";
            this.Text = "SymbolForm";
            this.Load += new System.EventHandler(this.frmSymbol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmSymbol_Load(object sender, System.EventArgs e)
		{
			//Get the ArcGIS install location
            string sInstallPath = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;
            //Load the ESRI.ServerStyle file into the SymbologyControl
            axSymbologyControl1.LoadStyleFile(QLHTDT.Properties.Settings.Default.PathData + "\\SGMCHTDT.ServerStyle");
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassBackgrounds).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassBorders).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassShadows).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassMarkerSymbols).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassLineSymbols).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassFillSymbols).Update();
            axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassTextSymbols).Update();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			m_styleGalleryItem = null;
			this.Hide();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
            QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView.Refresh();
            QLHTDT.FormChinh.KienTruc.axPageLayoutControl1.ActiveView.Refresh();
            this.Hide();
            //QLHTDT.FormChinh.QuanTriHeThong.CopyToPageLayout();

		}

		private void axSymbologyControl1_OnItemSelected(object sender, ESRI.ArcGIS.Controls.ISymbologyControlEvents_OnItemSelectedEvent e)
		{
			//Preview the selected item
			m_styleGalleryItem = (IStyleGalleryItem) e.styleGalleryItem;
            stylechon = m_styleGalleryItem;
			PreviewImage();
		}

		private void PreviewImage()
		{
			//Get and set the style class 
			ISymbologyStyleClass symbologyStyleClass = axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass);

			//Preview an image of the symbol
			stdole.IPictureDisp picture = symbologyStyleClass.PreviewItem(m_styleGalleryItem, pictureBox1.Width, pictureBox1.Height);
			System.Drawing.Image image = System.Drawing.Image.FromHbitmap(new System.IntPtr(picture.Handle));
			pictureBox1.Image = image;
		}

		public IStyleGalleryItem GetItem(esriSymbologyStyleClass styleClass, ISymbol symbol)
		{
				m_styleGalleryItem = null;

				//Get and set the style class
				axSymbologyControl1.StyleClass = styleClass;
				ISymbologyStyleClass symbologyStyleClass = axSymbologyControl1.GetStyleClass(styleClass);

				//Create a new server style gallery item with its style set
				IStyleGalleryItem styleGalleryItem = new ServerStyleGalleryItem();
				styleGalleryItem.Item = symbol;
				styleGalleryItem.Name = "mySymbol";

				//Add the item to the style class and select it
				symbologyStyleClass.AddItem(styleGalleryItem, 0);
				symbologyStyleClass.SelectItem(0);

				//Show the modal form
				this.ShowDialog();

				return m_styleGalleryItem;
		}

		private string ReadRegistry(string sKey) 
		{
			//Open the subkey for reading
			Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sKey, true);
			if (rk == null) return ""; 
			// Get the data from a specified item in the key.
			return (string) rk.GetValue("InstallDir");
		}
	}
}
