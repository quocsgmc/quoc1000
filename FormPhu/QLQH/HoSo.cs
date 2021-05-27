using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace QLHTDT.FormPhu.QLQH
{
    public partial class HoSo : Form
    {
        ArrayList alist = new ArrayList();
        int filelength;
        Image img;
        public static string SoQDHS;
        public HoSo()
        {
            InitializeComponent();
        }
        public HoSo(string patch, string QD)
        {
            //this.Text = "Quyết định số " + SoQDHS;
            this.Refresh();
            alist.Add(patch);
            InitializeComponent();
           
                pictureBox1.Image = Image.FromFile(patch);
                img = Image.FromFile(patch);
                filelength = img.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(numericUpDown1.Value.ToString(), out ID);
            //pictureBox1.Image = Image.FromFile(alist[ID].ToString());
            if (ID < filelength)
            {
                pictureBox1.Image.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, ID);
                pictureBox1.Refresh();
            }
        }
    }
}
