using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;
using QLHTDT.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.CapNhatDGN
{
    public partial class FrmCauHinhSDE : Form
    {
        public static string strConnection;
        public static string server;
        public static string user;
        public static string pass;
        string connection = "";
        string SDEfileLocation = "";
        string pathsde = "";
        public FrmCauHinhSDE()
        {
            InitializeComponent();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            button2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }
        public FrmCauHinhSDE(string a)
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = Properties.Settings.Default.pathSDE;
            openFileDialog.Filter = "Geodatabase sde (*.sde)|*.sde";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SDEfileLocation = openFileDialog.FileName;
                txtsde.Text = SDEfileLocation;
            }

            Cursor = Cursors.Default;
        }

        private void Btsave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (checkBox1.Checked == true)
            {
                if (SDEfileLocation != "")
                {
                    try
                    {
                        Btsave.Enabled = true;
                        button1.Enabled = true;
                        QLHTDT.Properties.Settings.Default.Save();
                        IWorkspaceFactory2 workspaceFactory = (IWorkspaceFactory2)new SdeWorkspaceFactoryClass();
                        IFeatureWorkspace featureWorkspaceSDE = (IFeatureWorkspace)workspaceFactory.OpenFromFile(SDEfileLocation, 0);
                        Cursor = Cursors.Default;
                        MessageBox.Show("Kết nối thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Không thể kết nối đến SDE!");
                        Btsave.Enabled = false;
                        button1.Enabled = false;
                    }
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                connection = "Server=" + textBox1.Text + ";Database=" + textBox2.Text + ";User Id=" + textBox3.Text + ";Password=" + textBox4.Text + ";";
                //QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) = "Server=" + textBox1.Text + ";Database= GIS" + ";User Id=" + textBox3.Text + ";Password=" + textBox4.Text + ";";
                //QLHTDT.Properties.Settings.Default.strConnectionLISTDC = "Server=" + textBox1.Text + ";Database= LISTDC" + ";User Id=" + textBox3.Text + ";Password=" + textBox4.Text + ";";
                Properties.Settings.Default.pathcauhinhSDE.SetProperty("Server", textBox1.Text);
                Properties.Settings.Default.pathcauhinhSDE.SetProperty("INSTANCE", "sde:sqlserver:" + textBox1.Text);
                Properties.Settings.Default.pathcauhinhSDE.SetProperty("USER", textBox3.Text);
                Properties.Settings.Default.pathcauhinhSDE.SetProperty("PASSWORD", textBox4.Text);
                Properties.Settings.Default.pathcauhinhSDE.SetProperty("DATABASE", textBox2.Text);
                Properties.Settings.Default.pathcauhinhSDE.SetProperty("VERSION", "DBO.DEFAULT");

             
                SqlConnection conn = new SqlConnection(connection);
                try
                {
                    conn.Open();
                    MessageBox.Show("Kết nối thành công");
                    server = textBox1.Text;
                    user = textBox3.Text;
                    pass = textBox4.Text;
                    button1.Enabled = true;
                    //if (System.IO.File.Exists(Settings.Default.PathData + "\\connectionSDE.sde"))
                    //{ System.IO.File.Move((Settings.Default.PathData + "\\connectionSDE.sde"), (Settings.Default.PathData + "\\connection.bak")); }
                    //workspaceFactory.Create(Settings.Default.PathData, "connection.sde", Properties.Settings.Default.pathcauhinhSDE, 0);
                }
                catch (Exception)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Kết nối không thành công, xin kiểm tra lại!");
                }
                conn.Close();
            }
            Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                QLHTDT.Properties.Settings.Default.checksavepathSDE = false;
                QLHTDT.Properties.Settings.Default.savepathSDE = SDEfileLocation;
                QLHTDT.Properties.Settings.Default.Save();
            }
            else
            {
                QLHTDT.Properties.Settings.Default.checksavepathSDE = true;
                QLHTDT.Properties.Settings.Default.Save();
                QLHTDT.Properties.Settings.Default.savepathSDE = connection;
            }

            QLHTDT.Properties.Settings.Default.Save();
            this.Hide();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button2.Enabled = true;
                checkBox2.CheckState = CheckState.Unchecked;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.CheckState = CheckState.Unchecked;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }
    }
}
