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

namespace QLHTDT.FormPhu.QTHT
{
    public partial class PhanQuyenTruyCap : Form
    {
        DataTable tb;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public PhanQuyenTruyCap()
        {
            InitializeComponent();
        }

        private void PhanQuyenTruyCap_Load(object sender, EventArgs e)
        {
            tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand("Select * From [HTDTCamLe].[dbo].PhanQuyen", connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
            gridView1.OptionsBehavior.Editable = false;
            bindingNavigator1.Visible = false;
        }

        private void Btsave_Click(object sender, EventArgs e)
        {
            try
            {

                dataAdapter1.Update((DataTable)bindingSource1.DataSource);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bindingSource1.ResetBindings(false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Chỉnh sửa")
            {
                gridView1.OptionsBehavior.Editable = true;
                bindingNavigator1.Visible = true;
                button1.Text = "Tắt";
                button1.Image = QLHTDT.Properties.Resources.tatupdate21;
            }
            else
            { 
                button1.Text = "Chỉnh sửa";
                gridView1.OptionsBehavior.Editable = false;
                bindingNavigator1.Visible = false;
                button1.Image = QLHTDT.Properties.Resources.update2;
            }

        }
    }
}
