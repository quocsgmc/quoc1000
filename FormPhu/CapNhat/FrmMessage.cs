using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class FrmMessage : Form
    {
       public static int check = 0;
        public FrmMessage()
        {
            InitializeComponent();
        }

        private void btMoLopMoi_Click(object sender, EventArgs e)
        {
            check = 1;
            this.Hide();
        }

        private void btLayLopDaMo_Click(object sender, EventArgs e)
        {
            check = 2;
            this.Hide();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
