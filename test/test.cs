using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace QLHTDT.test
{
    public partial class test : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            tb = new DataTable();
            tbcheck = new DataTable();
            string sql = "SELECT [fid],[points] FROM [SDE].[sde].[f87]";
            SqlConnection connection = new SqlConnection("Server=192.168.1.7,7651;Database=SDE;User Id=SINHNGUYEN;Password=Sgmcvietnam123;");
            //string sql = "Select * From DoAnQuyHoach";
            //SqlConnection connection = new SqlConnection(QLHTDT.Properties.Settings.Default.strConnection);
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;


            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //SqlConnection con = new SqlConnection("Server=192.168.1.7,7651;Database=SDE;User Id=SINHNGUYEN;Password=Sgmcvietnam123;");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("SELECT [points] FROM [SDE].[sde].[f87] WHERE FID = 10", con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["points"]);
            //    pictureBox1.Image = new Bitmap(ms);

            //}
        }
    }
}
