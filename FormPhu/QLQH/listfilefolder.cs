using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace QLHTDT.FormPhu.QLQH
{
    public partial class listfilefolder : Form
    {
        string link;
        string user = "";
        string pass = "";
        public string file = "";
        int loai = 0;
        List<string> files = new List<string>();
        string linkftp = "";
        public listfilefolder(string path)
        {
            InitializeComponent();

            listBox1.Items.Clear();
            int stt = 1;
            DirectoryInfo dinfo = new DirectoryInfo(path);
            FileInfo[] Files = dinfo.GetFiles("*.*");
            foreach (FileInfo file in Files)
            {
                listBox1.Items.Add(stt +". "+ file.Name);
                stt = stt + 1;
            }
            link = path;
            loai = 1;
        }
        public listfilefolder(string FTPAddress, string username, string password)
        {
            InitializeComponent();
            user = username;
            pass = password;
            link = FTPAddress;
            show(link, user, pass);
            loai = 2;
        }
        private void show(string Address, string username, string password)
        {
            files = new List<string>();
            try
            {
                //Create FTP request
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(Address);

                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(username, password);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;


                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                while (!reader.EndOfStream)
                {
                    Application.DoEvents();
                    files.Add(reader.ReadLine());
                }

                //Clean-up
                reader.Close();
                responseStream.Close(); //redundant
                response.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error connecting to the FTP Server");
            }

            listBox1.Items.Clear();
            int stt = 1;
            //If the list was successfully received, display it to the user
            //through a dialog
            if (files.Count != 0)
            {
                foreach (string file in files)
                {
                    listBox1.Items.Add(stt + ". " + file);
                    stt = stt + 1;
                    //listBox1.Items.Add(file);
                }

            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (loai == 1)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    String[] files = System.IO.Directory.GetFiles(link);
                    string file = files[listBox1.SelectedIndex];
                    System.Diagnostics.Process.Start(file);
                }
                else { MessageBox.Show("Chưa chọn file !", "Thông báo"); }
            }
            else if (loai == 2)
            {
                string fileluu = "";
                if (listBox1.SelectedIndex != -1)
                {
                    string file = files[listBox1.SelectedIndex];
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    saveFileDialog1.Title = "Lưu file";
                    //saveFileDialog1.CheckFileExists = true;
                    //saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.FileName = files[listBox1.SelectedIndex];
                    saveFileDialog1.DefaultExt = "txt";
                    saveFileDialog1.Filter = "All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        fileluu = saveFileDialog1.FileName;
                    }
                    if (fileluu != "" & fileluu != null)
                    {
                        using (WebClient client = new WebClient())
                        {
                            client.Credentials = new NetworkCredential(user, pass);
                            client.DownloadFile(link +"/"+file, fileluu);
                        }
                        System.Diagnostics.Process.Start(fileluu);
                    }
                    
                }
                else { MessageBox.Show("Chưa chọn file !", "Thông báo"); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "All file (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;
            //openFileDialog.ShowDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileNames.Count() == 1)
                {
                    if (loai == 1)
                    System.IO.File.Copy(openFileDialog.FileName, link + "\\" + System.IO.Path.GetFileName(openFileDialog.FileName), true);
                    else if (loai == 2)
                    {
                        using (WebClient client = new WebClient())
                        {
                            client.Credentials = new NetworkCredential(user, pass);
                            client.UploadFile(link + "/"+ System.IO.Path.GetFileName(openFileDialog.FileName), WebRequestMethods.Ftp.UploadFile, openFileDialog.FileName);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < openFileDialog.FileNames.Count(); i++)
                    {
                        if (loai == 1)
                        {
                            System.IO.File.Copy(openFileDialog.FileNames[i], link + "\\" + System.IO.Path.GetFileName(openFileDialog.FileNames[i]), true);
                        }
                        else if (loai == 2)
                        {
                            using (WebClient client = new WebClient())
                            {
                                client.Credentials = new NetworkCredential(user, pass);
                                client.UploadFile(link + "/" + System.IO.Path.GetFileName(openFileDialog.FileNames[i]), WebRequestMethods.Ftp.UploadFile, openFileDialog.FileName);
                            }
                        }
                    }
                }

                listBox1.Items.Clear();
                int stt = 1;
                DirectoryInfo dinfo = new DirectoryInfo(link);
                FileInfo[] Files = dinfo.GetFiles("*.*");
                foreach (FileInfo file in Files)
                {
                    listBox1.Items.Add(stt + ". " + file.Name);
                    stt = stt + 1;
                }
            }
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (loai == 1)
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu " + " không? Nếu có ấn nút Yes, không thì ấn nút No", "Xóa file đính kèm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        String[] files = System.IO.Directory.GetFiles(link);
                        string fileDel = files[listBox1.SelectedIndex];
                        System.IO.File.Delete(fileDel);

                        listBox1.Items.Clear();
                        int stt = 1;
                        DirectoryInfo dinfo = new DirectoryInfo(link);
                        FileInfo[] Files = dinfo.GetFiles("*.*");
                        foreach (FileInfo file in Files)
                        {
                            listBox1.Items.Add(stt + ". " + file.Name);
                            stt = stt + 1;
                        }
                    }

                    else if (loai == 2)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu " + " không? Nếu có ấn nút Yes, không thì ấn nút No", "Xóa file đính kèm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string fileDel = files[listBox1.SelectedIndex];
                            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(link + "/" + fileDel);
                            request.Credentials = new NetworkCredential(user, pass);
                            request.Method = WebRequestMethods.Ftp.DeleteFile;
                            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                            Console.WriteLine("Tình trạng xóa: {0}", response.StatusDescription);
                            response.Close();
                            listBox1.Items.Clear();
                            show(link, user, pass);

                        }
                    }
                }
                    
            }
            catch
            {
                MessageBox.Show("Không có file hoặc bạn chưa chọn file đính kèm để xóa", "Thông báo");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Process.Start(link);
            if (loai == 1)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    String[] files = System.IO.Directory.GetFiles(link);
                    string file = files[listBox1.SelectedIndex];
                    System.Diagnostics.Process.Start(file);
                }
                else { MessageBox.Show("Chưa chọn file !", "Thông báo"); }
            }
            else if (loai == 2)
            {
                string fileluu = "";
                if (listBox1.SelectedIndex != -1)
                {
                    string file = files[listBox1.SelectedIndex];
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    saveFileDialog1.Title = "Lưu file";
                    //saveFileDialog1.CheckFileExists = true;
                    //saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.FileName = files[listBox1.SelectedIndex];
                    saveFileDialog1.DefaultExt = "txt";
                    saveFileDialog1.Filter = "All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        fileluu = saveFileDialog1.FileName;
                    }
                    if (fileluu != "" & fileluu != null)
                    {
                        using (WebClient client = new WebClient())
                        {
                            client.Credentials = new NetworkCredential(user, pass);
                            client.DownloadFile(link + "/" + file, fileluu);
                        }
                        System.Diagnostics.Process.Start(fileluu);
                    }

                }
                else { MessageBox.Show("Chưa chọn file !", "Thông báo"); }
            }
        }
    }
}
