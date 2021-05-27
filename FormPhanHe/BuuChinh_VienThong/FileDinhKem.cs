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
using RestSharp;
using System.Threading;

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong
{
    public partial class FileDinhKem : Form
    {
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        SqlDataAdapter dataAdapter2;
        SqlCommandBuilder cmbl1;
        string DowloadFile; //Đường dẫn dowload file
        string API; //API của đối tượng
        string LoadFile; //Load từ SQL Đính kèm
        string OBJECTID; //File cần xoá
        string Name;//Tên file cần xoá
        int IDMa;
        string user;
        string pass;
        public string file = "";
        List<string> files = new List<string>();
        string linkftp = "";
        string link;
        public FileDinhKem(string path)
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
        }
        public FileDinhKem(string SQLLoadFile, string Dowload, string API_1,int IDMa_1, string Name_1, string OBJECTID_1)
        {
            InitializeComponent();
            listBox1.Items.Clear();
            DowloadFile = Dowload;
            API = API_1;
            LoadFile = SQLLoadFile;
            Name = Name_1;
            OBJECTID = OBJECTID_1;
            IDMa = IDMa_1;
            SqlDataAdapter adp1 = new SqlDataAdapter(LoadFile, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            listBox1.DataSource = ds1.Tables[0];
            listBox1.DisplayMember = Name_1;
            listBox1.ValueMember = OBJECTID_1;

        }
       
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string fileluu = "";
            if (listBox1.SelectedIndex != -1)
            {
                string file = listBox1.Text;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Lưu file";
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
                        client.DownloadFile(QLHTDT.FormPhanHe.URLWeb.URL + DowloadFile + file, fileluu);
                    }
                    System.Diagnostics.Process.Start(fileluu);
                }
            }
            else { MessageBox.Show("Chưa chọn file !", "Thông báo"); }
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
            try
            {
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var client = new RestClient(QLHTDT.FormPhanHe.URLWeb.URL + API);
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", "JWT " + QLHTDT.Properties.Settings.Default.Token);
                    request.AddParameter("OBJECTID", IDMa);
                    request.AddFile("file", openFileDialog.FileName);
                    request.AddParameter("filesDelete", "[]");
                    IRestResponse response = client.Execute(request);
                    Thread.Sleep(1000);

                    SqlDataAdapter adp1 = new SqlDataAdapter(LoadFile, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    DataSet ds1 = new DataSet();
                    adp1.Fill(ds1);
                    listBox1.DataSource = ds1.Tables[0];
                    listBox1.DisplayMember = Name;
                    listBox1.ValueMember = OBJECTID;
                }
            }
            catch
            {
                MessageBox.Show("Tên File quá dài hoặc dung lượng quá lớn!", "Thông báo");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu " + " không? Nếu có ấn nút Yes, không thì ấn nút No", "Xóa file đính kèm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var client = new RestClient(QLHTDT.FormPhanHe.URLWeb.URL + API);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", "JWT " + QLHTDT.Properties.Settings.Default.Token);
                    request.AddParameter("OBJECTID", "\""+listBox1.SelectedValue.ToString()+"\"");
                    request.AddParameter("filesDelete", "[{\"ID\":"+ listBox1.SelectedValue.ToString() + ",\"NAME\":\""+ listBox1 .Text+ "\"}]");
                    IRestResponse response = client.Execute(request);
                    Thread.Sleep(1000);
                    SqlDataAdapter adp1 = new SqlDataAdapter(LoadFile, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    DataSet ds1 = new DataSet();
                    adp1.Fill(ds1);
                    listBox1.DataSource = ds1.Tables[0];
                    listBox1.DisplayMember = Name;
                    listBox1.ValueMember = OBJECTID;
                }
            }
            catch
            {
                MessageBox.Show("Không có file hoặc bạn chưa chọn file đính kèm để xóa", "Thông báo");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fileluu = "";
            if (listBox1.SelectedIndex != -1)
            {
                string file = listBox1.Text;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Lưu file";
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
                        client.DownloadFile(QLHTDT.FormPhanHe.URLWeb.URL + DowloadFile + file + "?key=" + QLHTDT.Properties.Settings.Default.Token, fileluu);
                    }
                    System.Diagnostics.Process.Start(fileluu);
                }
            }
            else { MessageBox.Show("Chưa chọn file !", "Thông báo"); }
        }

    }
}
