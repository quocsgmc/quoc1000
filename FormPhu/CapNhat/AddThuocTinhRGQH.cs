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
    public partial class AddThuocTinhRGQH : Form
    {
        public static bool check = false;
        public AddThuocTinhRGQH()
        {
            InitializeComponent();
        }
        public AddThuocTinhRGQH(ListBox listBox)
        {
            InitializeComponent();
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                dataGridView1.Rows.Add(listBox.Items[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
