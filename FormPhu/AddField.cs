using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu
{
    public partial class AddField : Form
    {
        public static string Name1 = "";
        public static string Type1 = "";
        bool isNumeric;
        public string Lenght1 = "";
        public static int Lenght = 50;
        public AddField()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" & comboBox1.Text != "")
            {
                isNumeric = true;
                if (isNumeric = int.TryParse(textBox2.Text, out Lenght))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu!\n" + "Vui lòng nhập lại", "Thông báo");
                    Cursor = Cursors.Default;
                    return;
                }
                Name1 = textBox1.Text;
                Type1 = comboBox1.Text;
                Lenght1 = textBox2.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Chưa nhập thông tin đầy đủ","Thông báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Text")
            {
                textBox2.Visible = true;
                textBox3.Visible = true;
            }
        }
    }
}
