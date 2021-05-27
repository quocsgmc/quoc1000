using DevExpress.XtraGrid.Views.Base;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using QLHTDT.FormChinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.GiaoThong.ThemMoi
{
    public partial class ThemMoiLoaiBienBao : Form
    {
        public static string AnhBienBao = null;
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.GiaoThong.QuanLyLoaiBienBao.IDTram;
        public ThemMoiLoaiBienBao()
        {
            InitializeComponent();
            openFileDialogFileShape.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogFileShape_FileOk);
            openFileDialogFileShape.Filter = "Shapefile|*.JPG";
            openFileDialogFileShape.Title = "Chọn biển báo";

            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ThemMoiLoaiBienBao_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thêm mới dữ liệu" + " không?", "Thêm dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string LBien = "null"; ; string LoaiBien = "null";
                    if (comboBox1.Text != "")
                    {
                        LBien = comboBox1.Text;
                        switch (LBien)
                        {
                            case "Biển báo cấm": LoaiBien = "1"; break;
                            case "Biển báo chỉ dẫn": LoaiBien = "2"; break;
                            case "Biển báo hiệu lệnh": LoaiBien = "3"; break;
                            case "Biển báo nguy hiểm": LoaiBien = "4"; break;
                            case "Biển phụ": LoaiBien = "5"; break;
                            case "Danh sách vạch": LoaiBien = "6"; break;
                            default: LoaiBien = "null"; break;
                        }
                    }
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string INSERT = "[PRC_INSERT_LoaiBienBao] " + LoaiBien + ",N'" + textBox2.Text + "',N'" + textBox3.Text + "',N'" + textBox4.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(INSERT, conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới dữ liệu thành công", "Thông báo");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu đầy đủ", "Thông báo");
                }
            }
        }
        OpenFileDialog openFileDialogFileShape = new System.Windows.Forms.OpenFileDialog();
        private void btMo1_Click(object sender, EventArgs e)
        {
            //openFileDialogFileShape.ShowDialog();
            QLHTDT.FormPhanHe.GiaoThong.ChonBienBao frm = new QLHTDT.FormPhanHe.GiaoThong.ChonBienBao();
            frm.ShowDialog();
            frm.Close();
            Pic1.Image = Image.FromFile(@""+AnhBienBao+"");
            Pic1.Visible = true;
            textBox3.Text = AnhBienBao;
        }
        private void openFileDialogFileShape_FileOk(object sender, CancelEventArgs e)
        {
            textBox3.Text = openFileDialogFileShape.FileName;
            Pic1.Image = Image.FromFile(textBox3.Text);
        }
    }
}
