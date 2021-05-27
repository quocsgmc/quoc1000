using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLHTDT.FormChinh;

namespace QLHTDT.FormPhu.QTHT
{
    
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            //QuanTriHeThong frm = new QuanTriHeThong();
            //frm.ShowDialog();
            //InitializeComponent();
            //timer1.Interval = 3000;
            //timer1.Start();
            InitializeComponent();
            timer2.Interval = 3000;
            timer2.Start();
            //timer2.Tick += new System.EventHandler(this.timer1_Tick);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer2.Stop();
            //this.Close();
        }
        public static void a()
        {
            timer2.Stop();
            
        }
    }
}
