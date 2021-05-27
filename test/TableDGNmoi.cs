using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using QLHTDT.Properties;

namespace QLHTDT.test
{
    public partial class TableDGNmoi : Form
    {
        public TableDGNmoi(DataTable dt1)
        {
            InitializeComponent();
            bindingSource1.DataSource = dt1;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataGridViewRow rowSHP = dataGridView1.SelectedRows;
           //string a = dataGridView1.SelectedCells[1].Value.ToString();
           //string b = a;
            DataGridViewRow rowSHP = dataGridView1.CurrentRow;
            if (rowSHP != null)
            {
                string path = rowSHP.Cells[1].Value.ToString();
                //string path = dataGridView1.SelectedCells[1].Value.ToString();
                System.Diagnostics.Process.Start(path);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openfd = new FolderBrowserDialog();
            openfd.ShowNewFolderButton = true;
            openfd.SelectedPath = QLHTDT.Properties.Settings.Default.pathDGN;
            openfd.Description = "Chọn thư mục lưu file dgn";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                
                QLHTDT.Properties.Settings.Default.pathDGN = @openfd.SelectedPath;
                QLHTDT.Properties.Settings.Default.Save();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (Settings.Default.pathDGN != "")
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Settings.Default.pathDGN);
                // Một mảng các thư mục con.
                DirectoryInfo[] childDirs = dirInfo.GetDirectories();
                // Mảng các file nằm trong thư mục.
                DataTable dtDGNmoi = new DataTable();
                dtDGNmoi = new DataTable();
                dtDGNmoi.Columns.Add("STT", typeof(int));
                dtDGNmoi.Columns.Add("TenFile", typeof(String));
                dtDGNmoi.Columns.Add("NgayCN", typeof(String));
                dtDGNmoi.Columns.Add("NgayTao", typeof(String));
                DataRow drDGNmoi;
                int i = 1;
                foreach (DirectoryInfo childDir in childDirs)
                {
                    FileInfo[] childFiles = childDir.GetFiles("*.dgn");
                    //MessageBox.Show(" - Directory: " + childDir.FullName, "Thông báo");
                    foreach (FileInfo childFile in childFiles)
                    {
                        var date = DateTime.Now;
                        if (childFile.LastWriteTime.Day == dateTimePicker1.Value.Day && childFile.LastWriteTime.Month == dateTimePicker1.Value.Month && childFile.LastWriteTime.Year == dateTimePicker1.Value.Year)
                        {
                            //MessageBox.Show("File: " + childFile.Name + " Thời gian chỉnh sửa cuối cùng " + childFile.LastWriteTime, "Thông báo");
                            drDGNmoi = dtDGNmoi.NewRow();
                            drDGNmoi[0] = i;
                            drDGNmoi[1] = childFile.FullName;
                            drDGNmoi[2] = childFile.LastWriteTime;
                            drDGNmoi[3] = childFile.CreationTime;
                            dtDGNmoi.Rows.Add(drDGNmoi);
                            i = i + 1;
                        }
                    }
                }
                dataGridView1.DataSource = dtDGNmoi;
            }
            else
            {
                MessageBox.Show("Chọn thư mục lưu file DGN", "Thông báo");
                FolderBrowserDialog openfd = new FolderBrowserDialog();
                openfd.ShowNewFolderButton = true;
                openfd.SelectedPath = QLHTDT.Properties.Settings.Default.pathDGN;
                openfd.Description = "Chọn thư mục lưu file DGN";
                if (openfd.ShowDialog() == DialogResult.OK)
                {

                    QLHTDT.Properties.Settings.Default.pathDGN = @openfd.SelectedPath;
                    QLHTDT.Properties.Settings.Default.Save();
                    DirectoryInfo dirInfo = new DirectoryInfo(Settings.Default.pathDGN);
                    // Một mảng các thư mục con.
                    DirectoryInfo[] childDirs = dirInfo.GetDirectories();
                    // Mảng các file nằm trong thư mục.
                    DataTable dtDGNmoi = new DataTable();
                    dtDGNmoi = new DataTable();
                    dtDGNmoi.Columns.Add("STT", typeof(int));
                    dtDGNmoi.Columns.Add("TenFile", typeof(String));
                    dtDGNmoi.Columns.Add("NgayCN", typeof(String));
                    dtDGNmoi.Columns.Add("NgayTao", typeof(String));
                    DataRow drDGNmoi;
                    int i = 1;
                    foreach (DirectoryInfo childDir in childDirs)
                    {
                        FileInfo[] childFiles = childDir.GetFiles("*.dgn");
                        //MessageBox.Show(" - Directory: " + childDir.FullName, "Thông báo");
                        foreach (FileInfo childFile in childFiles)
                        {
                            var date = DateTime.Now;
                            if (childFile.LastWriteTime.Day == dateTimePicker1.Value.Day && childFile.LastWriteTime.Month == dateTimePicker1.Value.Month && childFile.LastWriteTime.Year == dateTimePicker1.Value.Year)
                            {
                                //MessageBox.Show("File: " + childFile.Name + " Thời gian chỉnh sửa cuối cùng " + childFile.LastWriteTime, "Thông báo");
                                drDGNmoi = dtDGNmoi.NewRow();
                                drDGNmoi[0] = i;
                                drDGNmoi[1] = childFile.FullName;
                                drDGNmoi[2] = childFile.LastWriteTime;
                                drDGNmoi[3] = childFile.CreationTime;
                                dtDGNmoi.Rows.Add(drDGNmoi);
                                i = i + 1;
                            }
                        }
                    }
                    dataGridView1.DataSource = dtDGNmoi;
                }
            }
        }

        
    }
}
