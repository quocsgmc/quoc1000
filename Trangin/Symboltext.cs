using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ESRI.ArcGIS.Display;


namespace QLHTDT.Trangin
{
    public partial class Symboltext : Form
    {
        

        private IStyleGalleryItem m_styleGalleryItem;
        public Symboltext()
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private void Form2_Load(object sender, System.EventArgs e)
        {
            //Get the ArcGIS install location
            string sInstall = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;

            //Load the ESRI.ServerStyle file into the SymbologyControl
            axSymbologyControl1.LoadStyleFile(QLHTDT.Properties.Settings.Default.PathData+"\\SGMCHTDT.ServerStyle");
        }
        public IStyleGalleryItem GetItem(ESRI.ArcGIS.Controls.esriSymbologyStyleClass styleClass)
        {
            m_styleGalleryItem = null;

            //Set the style class of SymbologyControl1
            axSymbologyControl1.StyleClass = styleClass;

            //Change cursor
            this.Cursor = Cursors.Default;

            //Show the modal form
            this.ShowDialog();

            //return the label style that has been selected from the SymbologyControl
            return m_styleGalleryItem;
        }

        private void axSymbologyControl1_OnItemSelected(object sender, ESRI.ArcGIS.Controls.ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            //Get the selected item
            m_styleGalleryItem = (IStyleGalleryItem)e.styleGalleryItem;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //hide the form
            this.Hide();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            m_styleGalleryItem = null;
            //hide the form
            this.Hide();
        }
    }
}
