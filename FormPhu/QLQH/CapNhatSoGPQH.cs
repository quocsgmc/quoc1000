using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.QLQH
{
    public partial class CapNhatSoGPQH : Form
    {
        public static string SoGP;
        public static string Ngay;
        public static string Thang;
        public static string Nam;
        public CapNhatSoGPQH()
        {
            var date = DateTime.Now;
            InitializeComponent();
            SoGP = ""; Ngay = "";Thang = "";Nam = "";
            tbNgay.Text = date.Day.ToString();
            tbThang.Text = date.Month.ToString();
            tbNam.Text = date.Year.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoGP = ""; Ngay = ""; Thang = ""; Nam = "";
            SoGP = textBox1.Text;
            Ngay = tbNgay.Text; Thang = tbThang.Text; Nam = tbNam.Text;
            this.Visible = false;
        }
    }
}
