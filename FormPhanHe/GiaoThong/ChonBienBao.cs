using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.GiaoThong
{
    public partial class ChonBienBao : Form
    {
        public static string DuongDan = "";
        PictureBox display;
        string[] Files;
        int i = 1;
        public ChonBienBao()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialogFileShape = new System.Windows.Forms.OpenFileDialog();
        void LoadAnh(string DuongDan)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = true;
            thumbnailsFLP.Visible = true;
            //Files = Directory.GetFiles(DuongDan);
            Files = Directory.GetFiles(QLHTDT.Properties.Settings.Default.PathData + "\\Giao thông\\Layer_BienBao\\" + DuongDan);

            thumbnailsFLP.Controls.Clear();

            foreach (String image in Files)
            {
                if (image.ToLower().EndsWith(".jpg") || image.ToLower().EndsWith(".GIF") ||
                    image.ToLower().EndsWith(".png") || image.ToLower().EndsWith(".bmp") ||
                    image.ToLower().EndsWith(".jpeg"))
                {
                    display = new PictureBox();
                    display.SizeMode = PictureBoxSizeMode.StretchImage;
                    //display.Image = Image.FromFile(image);
                    display.Image = System.Drawing.Bitmap.FromFile(image);
                    display.Name = image;
                    display.Height = 80;
                    display.Width = 80;
                    display.Click += new System.EventHandler(this.display_Click);
                    display.Cursor = Cursors.Hand;
                    thumbnailsFLP.Controls.Add(display);
                }
                if (i++ == 12)
                    Application.DoEvents();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DuongDan = "Biển báo cấm";
            LoadAnh(DuongDan);
            Cursor = Cursors.Default;
        }


        private void thumbnailsFLP_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = false;
            thumbnailsFLP.Visible = false;
            display = null;
            Files = null;
            thumbnailsFLP.Controls.Clear();//Xóa dữ liệu trong FLP
            System.GC.Collect(); //Xóa dữ liệu bộ nhớ đệm
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DuongDan = "Biển báo nguy hiểm";
            LoadAnh(DuongDan);
            Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DuongDan = "Biển báo hiệu lệnh";
            LoadAnh(DuongDan);
            Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DuongDan = "Biển báo chỉ dẫn";
            LoadAnh(DuongDan);
            Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //string DuongDan = "Bien_Bao_Cam";
            //LoadAnh(DuongDan);
            Cursor = Cursors.Default;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //string DuongDan = "Bien_Bao_Cam";
            //LoadAnh(DuongDan);
            Cursor = Cursors.Default;
        }

        private void display_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            QLHTDT.FormPhanHe.GiaoThong.ThemMoi.ThemMoiLoaiBienBao.AnhBienBao = pic.Name;
            QLHTDT.FormPhanHe.GiaoThong.ThemMoi.ThemMoiBienBao.AnhBienBao = pic.Name;
            QLHTDT.FormPhanHe.GiaoThong.ChinhSua.ChinhSuaBienBao.AnhBienBao = pic.Name;
            display = null;
            Files = null;
            thumbnailsFLP.Controls.Clear();
            System.GC.Collect();
            Close();
        }

        private void ChonBienBao_Load(object sender, EventArgs e)
        {
        }
    }
}
