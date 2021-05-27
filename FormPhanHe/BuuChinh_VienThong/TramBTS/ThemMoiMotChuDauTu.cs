﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS
{
    public partial class ThemMoiMotChuDauTu : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public ThemMoiMotChuDauTu()
        {
            InitializeComponent();
        }

        private void ThemMoiMotChuDauTu_Load(object sender, EventArgs e)
        {
            //showgridControl1();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thêm mới dữ liệu" + " không?", "Thêm dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string INSERT = "[PRC_INSERT_CHUDAUTUBTS]N'" + txtTenChuDauTu.Text + "',N'" + txtGhiChu.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(INSERT, conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới dữ liệu thành công", "Thông báo");
                    this.Close();
                    QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.QuanLyChuDauTu frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.QuanLyChuDauTu();
                    frm.Show();
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu đầy đủ", "Thông báo");
                }
            }
        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            this.Close();
            QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.QuanLyChuDauTu frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.QuanLyChuDauTu();
            frm.Show();
        }

    }
}
