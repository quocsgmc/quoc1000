using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu
{
    public partial class BackUp : Form
    {
        SaveFileDialog SaveFileDialogSave;
        string save = "";
        public BackUp()
        {
            InitializeComponent();
        }

        private void BackUp_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            try
            {
                DateTime d = DateTime.Now;
                string dd = d.Day + "-" + d.Month;
                string dbname = txtCSDL.Text;// database name

                Server dbServer = new Server(new ServerConnection(txtServer.Text, txtUser.Text, txtPass.Text));
                Backup dbBackup = new Backup() {  Action = BackupActionType.Database, Database = txtCSDL.Text };
                dbBackup.Devices.AddDevice(txtDuongDan.Text, DeviceType.File);
                dbBackup.Initialize = true;
                dbBackup.PercentComplete += DbBackup_PercentComplete;
                dbBackup.Complete += dbBackup_Complete;
                dbBackup.SqlBackupAsync(dbServer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //DateTime d = DateTime.Now;
            //string dd = d.Day + "-" + d.Month;
            //string servname = txtServer.Text;
            //string dbname = txtCSDL.Text;// database name

            //string aaa = @"Data Source=" + servname + ";Integrated Security=True;Initial Catalog=" + dbname + "";
            //SqlConnection con = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH))DAQH));
            ////con.ConnectionString = ConfigurationManager.ConnectionStrings["BackupCatalogDBSoft.Properties.Settings."+dbname+"ConnectionString"].ToString();

            //con.Open();
            ////string str = "USE " + dbname + ";";
            //string str1 = "USE " + dbname + " BACKUP DATABASE " + dbname +
            //    " TO DISK = 'D:\\Program Files\\Microsoft SQL Server\\MSSQL12.MSSQLSERVER\\MSSQL\\Backup" + dbname + "_" + dd +
            //    ".Bak' WITH FORMAT,MEDIANAME = 'Z_SQLServerBackups',NAME = 'Full Backup of " + dbname + "';";
            ////SqlCommand cmd1 = new SqlCommand(str, con);
            //SqlCommand cmd2 = new SqlCommand(str1, con);
            ////cmd1.ExecuteNonQuery();
            //cmd2.ExecuteNonQuery();
            //MessageBox.Show("Successfully Completed Backup. You can find this file (DB Name.Bak) in your Disk D:\\.... never edit this file name.");
            //con.Close();
        }

        private void dbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if(e.Error != null)
            {
                lblThongTin.Invoke((MethodInvoker)delegate
                {
                    lblThongTin.Text = e.Error.Message;
                });
            }
        }

        private void DbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Value = e.Percent;
                    progressBar.Update();
                });
                lblPercent.Invoke((MethodInvoker)delegate
                {
                    lblPercent.Text = $"{e.Percent}%";
                });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialogSave = new System.Windows.Forms.SaveFileDialog();
            SaveFileDialogSave.Filter = "Bak file|*.bak| All files (*.*)|*.*";
            SaveFileDialogSave.InitialDirectory = Properties.Settings.Default.pathPolygon;
            SaveFileDialogSave.FileOk += new System.ComponentModel.CancelEventHandler(SaveFileDialogSave1);
            SaveFileDialogSave.CheckPathExists = true;
            SaveFileDialogSave.ShowDialog();
        }
        private void SaveFileDialogSave1(object sender, CancelEventArgs e)
        {
            //add object file to listbox1
            Cursor = Cursors.WaitCursor;
            save = SaveFileDialogSave.FileName;
            txtDuongDan.Text = SaveFileDialogSave.FileName;
            Cursor = Cursors.Default;
        }
    }
}
