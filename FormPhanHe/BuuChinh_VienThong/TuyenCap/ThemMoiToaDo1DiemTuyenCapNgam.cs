﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap
{
    public partial class ThemMoiToaDo1DiemTuyenCapNgam : Form
    {
        public static int STT = 0;
        public static double X = 0;
        public static double Y = 0;
        public ThemMoiToaDo1DiemTuyenCapNgam()
        {
            InitializeComponent();
            comboBox2.Enabled = false;
            Loadtocbobox();
        }
        private void Loadtocbobox()
        {
            for (int i = 1; i < QuanLyToaDoTuyenCapNgam.numrow; i++)
            {
                comboBox2.Items.Add(i);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                STT = 0;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                int.TryParse(comboBox2.Text, out STT);
            }
            else STT = QuanLyToaDoTuyenCapTreo.numrow;

            double.TryParse(textBox2.Text, out X);
            double.TryParse(textBox3.Text, out Y);
            this.Hide();
            QuanLyToaDoTuyenCapNgam.ThemDiem = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Enabled = true;
            }
            else
            {
                comboBox2.ResetText();
                comboBox2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
