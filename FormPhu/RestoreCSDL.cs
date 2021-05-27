using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace QLHTDT.FormPhu
{
    public partial class RestoreCSDL : Form
    {
        public string Database { get; private set; }
        OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
        public RestoreCSDL()
        {
            InitializeComponent();
        }

        private void Restore_Load(object sender, EventArgs e)
        {
            txtServer.Text = QLHTDT.FormChinh.SettingKetNoiCSDL.strConnection;
            txtCSDL.Text = QLHTDT.FormChinh.SettingKetNoiCSDL.server;
            txtUser.Text = QLHTDT.FormChinh.SettingKetNoiCSDL.user;
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
                Restore dbRestore = new Restore { Database = txtCSDL.Text, Action = RestoreActionType.Database, ReplaceDatabase = true, NoRecovery = false };
                dbRestore.Devices.AddDevice(openFileDialog.FileName + ".bak", DeviceType.File);
                dbRestore.PercentComplete += DbBackup_PercentComplete;
                dbRestore.Complete += dbBackup_Complete;
                dbRestore.SqlRestoreAsync(dbServer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            //this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Bak File (*.bak)|*.bak";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            string DuongDan = openFileDialog.FileName;
            txtDuongDan.Text = DuongDan;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDuongDan.Text = DuongDan;
            }
        }
    }
}
