using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Security;

namespace QLHTDT.FormPhu
{
    public partial class TTLienHeDKySD : Form
    {
        string LayMa;
        string DecryptedString;
        public TTLienHeDKySD()
        {
            InitializeComponent();
        }
        private void TTLienHeDKySD_Load(object sender, EventArgs e)
        {
            GetCPUId();
        }
        
        //public string GetHDDSerialNumber(string drive)
        //{
        //    //check to see if the user provided a drive letter
        //    //if not default it to "C"
        //    if (drive == "" || drive == null)
        //    {
        //        drive = "C";
        //    }
        //    //create our ManagementObject, passing it the drive letter to the
        //    //DevideID using WQL
        //    ManagementObject disk = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
        //    //bind our management object
        //    disk.Get();
        //    textBox6.Text = disk["VolumeSerialNumber"].ToString();
        //    //return the serial number
        //    return disk["VolumeSerialNumber"].ToString();
        //}
        public string GetCPUId()
        {
            string cpuInfo = String.Empty;
            //create an instance of the Managemnet class with the
            //Win32_Processor class
            ManagementClass mgmt = new ManagementClass("Win32_DiskDrive");
            //create a ManagementObjectCollection to loop through
            ManagementObjectCollection objCol = mgmt.GetInstances();
            //start our loop for all processors found

            foreach (ManagementObject obj in objCol)
            {
                if (1==1)
                {
                    // only return cpuInfo from first CPU
                    //cpuInfo = obj.Properties["ProcessorId"].Value.ToString();
                    //textBox6.Text = obj.Properties["ProcessorId"].Value.ToString();
                    LayMa = obj.Properties["SerialNumber"].Value.ToString() + "SGMCVietNam";
                    string EncryptedString1 = QLHTDT.FormPhu.DangKi.MaHoa.EncryptString(LayMa, "7651");
                    string EncryptedString2 = QLHTDT.FormPhu.DangKi.MaHoa.EncryptString(EncryptedString1, "7651");
                    //DecryptedString = QLHTDT.FormPhu.DangKi.MaHoa.DecryptString(EncryptedString, "7651");
                    textBox6.Text = EncryptedString2;
                    DecryptedString = EncryptedString1;
                }
            }
            return cpuInfo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == DecryptedString)
            {
                QLHTDT.Properties.Settings.Default.CheckDangKy = true;
                QLHTDT.Properties.Settings.Default.Save();
                this.Close();
            }
            else { MessageBox.Show("Sai mã kích hoạt xin mời nhập lại", "Thông báo", MessageBoxButtons.OK); }
        }
    }
}
