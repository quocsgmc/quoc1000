﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormChinh.View
{
    public partial class BieuDo : Form
    {
        public BieuDo()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a ExcelDataSource
            excelDataSource1.Fill();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a ExcelDataSource
            excelDataSource2.Fill();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a ExcelDataSource
            excelDataSource3.Fill();
        }

        private void BieuDo_Load(object sender, EventArgs e)
        {

        }
    }
}
