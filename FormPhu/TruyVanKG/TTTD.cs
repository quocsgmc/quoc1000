using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLHTDT.FormPhu.QLKienTruc;
using System.IO;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid.Rows;
using System.Net;

namespace QLHTDT.FormPhu.FormChiTietLayer
{
    public partial class TTTD : Form
    {
        DataTable dta;
        public TTTD(DataTable dt)
        {
            InitializeComponent();
            repositoryItemMemoEdit1.AutoHeight = true;
            vGridControl1.CloseEditor();
            bindingSource1.DataSource = dt;
            dta = dt;
            getTTCPXD();

        }

        private void getTTCPXD()
        {


        }
        private void XuatXN_Click(object sender, EventArgs e)
        {
            string a = vGridControl1.GetCellValue(vGridControl1.Rows[1].ChildRows[0], 0).ToString();
            string b = a;
            var date = DateTime.Now;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Ngay", date.Day.ToString());
            dic.Add("Thang", date.Month.ToString());
            dic.Add("Nam", date.Year.ToString());
            dic.Add("ChuSuDung", "");
            dic.Add("MucDichXacNhan", "");
            dic.Add("SThua", vGridControl1.GetCellValue(vGridControl1.Rows[0].ChildRows[2], 0).ToString());
            dic.Add("STo", vGridControl1.GetCellValue(vGridControl1.Rows[0].ChildRows[1], 0).ToString());
            dic.Add("To", "");
            dic.Add("SoGCN", "");
            dic.Add("NgayCapGCN", "");
            dic.Add("QĐQH", "");
            dic.Add("NgayPDQH", "");
            if (vGridControl1.GetCellValue(vGridControl1.Rows[1].ChildRows[0], 0).ToString() == "Không nằm trong Quy hoạch" || vGridControl1.GetCellValue(vGridControl1.Rows[1].ChildRows[0], 0).ToString() == "Không nằm trong quy hoạch" || vGridControl1.GetCellValue(vGridControl1.Rows[1].ChildRows[0], 0).ToString().Contains("Một phần"))
            {
                dic.Add("KhuQH", vGridControl1.GetCellValue(vGridControl1.Rows[1].ChildRows[0], 0).ToString());
            }
            else { dic.Add("KhuQH", "nằm trong vùng quy hoạch " + vGridControl1.GetCellValue(vGridControl1.Rows[1].ChildRows[0], 0).ToString()); }
            dic.Add("Phuong", vGridControl1.GetCellValue(vGridControl1.Rows[0].ChildRows[4], 0).ToString());
            WWord wd = new WWord(QLHTDT.Properties.Settings.Default.PathData + "\\MauXNQH.dotx", true);
            wd.WriteFields(dic);
        }

        private void vGridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (vGridControl1.FocusedRow.Name.ToString() == "TinhTrangCPXD")
            {
                if (vGridControl1.GetCellValue(vGridControl1.GetRowByName("TinhTrangCPXD"), 0).ToString() != "Chưa có thông tin cấp phép xây dựng.")
                {
                    //string file = "http://210.245.20.136:3003//api/bts/update-file/" + vGridControl1.GetCellValue(vGridControl1.GetRowByName("MaHS"), 0).ToString().Replace(" ", "").ToString() + "/GPXD" + vGridControl1.GetCellValue(vGridControl1.GetRowByName("SoGPXD"), 0).ToString().Replace(" ", "").ToString() + ".pdf";
                    string file = "http://210.245.20.136:3009/connect_file/bts/2020_01_18T02_26_16.506Z_11.xlsx";
                    string fileluu = "";
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    saveFileDialog1.Title = "Lưu file";
                    //saveFileDialog1.CheckFileExists = true;
                    //saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.FileName = "GPXD" + vGridControl1.GetCellValue(vGridControl1.GetRowByName("SoGPXD"), 0).ToString().Replace(" ", "").ToString() + ".pdf";
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
                            client.Credentials = new NetworkCredential("sinhnv", "Abc#1234");
                            client.DownloadFile(file, fileluu);
                        }
                        QLHTDT.FormPhu.ViewPDF frmpdf = new ViewPDF(fileluu);
                        frmpdf.Show();
                    }
                }
            }
        }

        private void vGridControl1_Click(object sender, EventArgs e)
        {
            if (vGridControl1.FocusedRow.Name.ToString() == "TTKienTruc")
            {
                if (vGridControl1.GetRowByName("TTKienTruc").Expanded == true)
                {
                    vGridControl1.GetRowByName("TTKienTruc").Expanded = false;
                }

                else if (vGridControl1.GetRowByName("TTKienTruc").Expanded == false)
                {
                    vGridControl1.GetRowByName("TTKienTruc").Expanded = true;
                }
            }
        }
        //bool expanded = false;
        //private void vGridControl1_Click(object sender, EventArgs e)
        //{
        //    if (vGridControl1.FocusedRow.Name.ToString() == "TTKienTruc")
        //    {
        //        if (vGridControl1.FocusedRow.Expanded == true)
        //        {
        //            if (expanded == true)
        //            { vGridControl1.FocusedRow.Expanded = false; expanded = false; }
        //            else { expanded = true; }
        //            this.Height = 370;
        //            this.Width = 510;
        //            this.Refresh();
        //        }
        //        else
        //        {
        //            if (expanded == false)
        //            { vGridControl1.FocusedRow.Expanded = true; expanded = true; }
        //            else { expanded = false; }
        //            this.Height = 370;
        //            this.Width = 635;
        //            this.Refresh();
        //        }
        //    }

        //    else
        //    {
        //        if (vGridControl1.GetRowByName("TTKienTruc").Expanded == true & expanded == false)
        //        {
        //            expanded = true;
        //            this.Height = 370;
        //            this.Width = 635;
        //            this.Refresh();
        //        }

        //        else if (vGridControl1.GetRowByName("TTKienTruc").Expanded == false & expanded == true)
        //        {
        //            { expanded = false; }
        //            this.Height = 370;
        //            this.Width = 510;
        //            this.Refresh();
        //        }
        //    }
        //}







    }
}
