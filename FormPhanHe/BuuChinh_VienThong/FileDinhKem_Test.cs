using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong
{
    public partial class FileDinhKem_Test : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        SqlDataAdapter dataAdapter2;
        SqlCommandBuilder cmbl1;
        string DowloadFile;
        string UpdateFile;
        string link;
        string user = "";
        string pass = "";
        public string file = "";
        int loai = 0;
        List<string> files = new List<string>();
        string linkftp = "";
        public FileDinhKem_Test(string path)
        {
            InitializeComponent();

            listBox1.Items.Clear();
            int stt = 1;
            DirectoryInfo dinfo = new DirectoryInfo(path);
            FileInfo[] Files = dinfo.GetFiles("*.*");
            foreach (FileInfo file in Files)
            {
                listBox1.Items.Add(stt + ". " + file.Name);
                stt = stt + 1;
            }
            link = path;
            loai = 1;
        }
        public FileDinhKem_Test(string SQLLoadFile, string Dowload, string UpLoad, string Delete)
        {
            InitializeComponent();
            listBox1.Items.Clear();
            DowloadFile = Dowload;
            UpdateFile = UpLoad;
            SqlDataAdapter adp1 = new SqlDataAdapter(SQLLoadFile, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            for (int intCount = 0; intCount < ds1.Tables[0].Rows.Count; intCount++)
            {
                var val = ds1.Tables[0].Rows[intCount]["TENFILE"].ToString();

                if (!listBox1.Items.Contains(val))
                {
                    listBox1.Items.Add(val);
                }
            }
            loai = 3;

        }

        public FileDinhKem_Test(string FTPAddress, string username, string password)
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
                            client.DownloadFile(link + "/" + file, fileluu);
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

            SaveACopyfileToServer(@"C:\\temp\"+ openFileDialog.FileName +".jpg", @"\\117.2.120.9\E:\Quoc\" + openFileDialog.FileName+"","sgmcvietnam/Anlth", "Abc!123456");

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
            else if (loai == 3)
            {
                string fileluu = "";
                if (listBox1.SelectedIndex != -1)
                {
                    string file = listBox1.Text;
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    //saveFileDialog1.InitialDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    saveFileDialog1.Title = "Lưu file";
                    //saveFileDialog1.CheckFileExists = true;
                    //saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.FileName = listBox1.Text;
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
                            client.DownloadFile("http://210.245.20.136:3003/" + DowloadFile + file, fileluu);
                        }
                        System.Diagnostics.Process.Start(fileluu);
                    }
                }
                else { MessageBox.Show("Chưa chọn file !", "Thông báo"); }
            }
        }
        private bool UploadFile(string url, string filePath, string srcFilename, string destFileName)
        {
            var uploaded = false;
            try
            {
                var httpClient = new HttpClient();
                var fileStream = File.Open(srcFilename, FileMode.Open);
                var fileInfo = new FileInfo(srcFilename);
                var content = new MultipartFormDataContent();
                content.Headers.Add("filePath", filePath);
                content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", destFileName + fileInfo.Extension));

                var task = httpClient.PostAsync(url, content).ContinueWith(t =>
                {
                    if (t.Status == TaskStatus.RanToCompletion)
                    {
                        var response = t.Result;
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            uploaded = true;
                        }
                    }

                    fileStream.Dispose();
                });

                task.Wait();
                httpClient.Dispose();
            }
            catch (Exception ex)
            {
                uploaded = false;
                throw ex;
            }

            return uploaded;
        }

        public static void SaveACopyfileToServer(string filePath, string savePath, string username, string password)
        {
            var directory = Path.GetDirectoryName(savePath).Trim();
            var filenameToSave = Path.GetFileName(savePath);

            if (!directory.EndsWith("\\"))
                filenameToSave = "\\" + filenameToSave;

            var command = "NET USE " + directory + " /delete";
            ExecuteCommand(command, 5000);

            command = "NET USE " + directory + " /user:" + username + " " + password;
            ExecuteCommand(command, 5000);

            command = " copy \"" + filePath + "\"  \"" + directory + filenameToSave + "\"";

            ExecuteCommand(command, 5000);


            command = "NET USE " + directory + " /delete";
            ExecuteCommand(command, 5000);
        }

        public static int ExecuteCommand(string command, int timeout)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/C " + command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = "C:\\",
            };

            var process = Process.Start(processInfo);
            process.WaitForExit(timeout);
            var exitCode = process.ExitCode;
            process.Close();
            return exitCode;
        }



    }
}
