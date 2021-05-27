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

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet
{
    public partial class ThemMoiTuFileExcel : Form
    {
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureWorkspace featureWorkspaceSDE;
        public ThemMoiTuFileExcel()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }

        }

        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int iLoi;
        private void button2_Click(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            string dateCP = "null";
            string dateGCN = "null";
            try
            {
                int DiaChi = -1;
                int GhiChu = -1;
                int KinhDo = -1;
                int PhienBan = -1;
                int Phuong = -1;
                int Quan = -1;
                int SoGPKD = -1;
                int SoMay = -1;
                int TenChuDaiLy = -1;
                int TenDaiLy = -1;
                int ViDo = -1;
                int NhaMang = -1;
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    if (dgvData.Columns[i].HeaderText == comboDiaChi.Text)
                    {
                        DiaChi = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboGhiChu.Text)
                    {
                        GhiChu = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboKinhDo.Text)
                    {
                        KinhDo = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboPhienBan.Text)
                    {
                        PhienBan = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboPhuong.Text)
                    {
                        Phuong = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboQuan.Text)
                    {
                        Quan = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboSoGPKD.Text)
                    {
                        SoGPKD = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboSoMay.Text)
                    {
                        SoMay = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboTenChuDaiLy.Text)
                    {
                        TenChuDaiLy = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboTenDaiLy.Text)
                    {
                        TenDaiLy = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboViDo.Text)
                    {
                        ViDo = i;
                    }
                    if (dgvData.Columns[i].HeaderText == CboboxNhaMang.Text)
                    {
                        NhaMang = i;
                    }


                }
                try
                {
                    for (iLoi = 0; iLoi < dgvData.RowCount - 1; iLoi++)
                    {
                        string TenDaiLy1;
                        string DiaChi1;
                        string KinhDo1;
                        string ViDo1;
                        string NhaMang1;
                        string SoMay1;
                        string GhiChu1;
                        string TenChuDaiLy1;
                        string SoGPKD1;
                        string PhienBan1;
                        string Phuong1;
                        if (comboTenDaiLy.Text != "")
                        {  TenDaiLy1 = dgvData.Rows[iLoi].Cells[TenDaiLy].Value.ToString(); }
                        else { TenDaiLy1 = ""; }
                        if (comboDiaChi.Text != "")
                        { DiaChi1 = dgvData.Rows[iLoi].Cells[DiaChi].Value.ToString(); }
                        else { DiaChi1 = ""; }
                        if (comboKinhDo.Text != "")
                        { KinhDo1 = dgvData.Rows[iLoi].Cells[KinhDo].Value.ToString(); }
                        else { KinhDo1 = "null"; }
                        if (comboViDo.Text != "")
                        { ViDo1 = dgvData.Rows[iLoi].Cells[ViDo].Value.ToString(); }
                        else { ViDo1 = "null"; }
                        if (CboboxNhaMang.Text != "")
                        { NhaMang1 = dgvData.Rows[iLoi].Cells[NhaMang].Value.ToString(); }
                        else { NhaMang1 = "null"; }
                        if (comboSoMay.Text != "")
                        { SoMay1 = dgvData.Rows[iLoi].Cells[SoMay].Value.ToString(); }
                        else { SoMay1 = "null"; }
                        if (comboGhiChu.Text != "")
                        { GhiChu1 = dgvData.Rows[iLoi].Cells[GhiChu].Value.ToString(); }
                        else { GhiChu1 = ""; }
                        if (comboTenChuDaiLy.Text != "")
                        { TenChuDaiLy1 = dgvData.Rows[iLoi].Cells[TenChuDaiLy].Value.ToString(); }
                        else { TenChuDaiLy1 = "null"; }
                        if (comboSoGPKD.Text != "")
                        { SoGPKD1 = dgvData.Rows[iLoi].Cells[SoGPKD].Value.ToString(); }
                        else { SoGPKD1 = ""; }
                        if (comboPhienBan.Text != "")
                        { PhienBan1 = dgvData.Rows[iLoi].Cells[PhienBan].Value.ToString(); }
                        else { PhienBan1 = ""; }
                        if (comboPhuong.Text != "")
                        {  Phuong1 = dgvData.Rows[iLoi].Cells[Phuong].Value.ToString(); }
                        else { Phuong1 = "null"; }
                        ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("DaiLyInternet");
                        // tạo mới đối tượng
                        feature = ftClassSDE.CreateFeature();
                        objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_DaiLyInternet_XY_BY_ID] "
                            + " " + objectid
                            + ", N'" + TenDaiLy1
                            + "', N'" + DiaChi1
                            + "', " + KinhDo1
                            + ", " + ViDo1
                            + ", " + NhaMang1
                            + ", " + SoMay1
                            + ", N'" + GhiChu1
                            + "', " + TenChuDaiLy1
                            + ", N'" + SoGPKD1
                            + "', " + dateGCN
                            + ", " + dateCP
                            + ", N'" + PhienBan1
                            + "', " + Phuong1
                            + ", 'Point(" + ViDo1 + " " + KinhDo1 + ")'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        this.Hide(); Cursor = Cursors.Default;
                    }
                    MessageBox.Show("Thêm mới Đại lý Internet thành công", "Thông báo");
                    BuuChinh_VienThong.QuanLyDaiLyInternet2.QuanLyDaiLyInternet2.LoadLaiForm = 1;
                }
                catch
                {
                    if (feature != null)
                    { feature.Delete(); }

                    int DongBiLoi = iLoi + 2;
                    MessageBox.Show("Dữ liệu dòng thứ "+ DongBiLoi+" bị sai định dạng. Vui lòng thử lại", "Thông báo");
                    Cursor = Cursors.Default;
                }
            }
            catch
            {
                //xóa đối tượng đã tạo nếu có lỗi
                if (feature != null)
                { feature.Delete(); }
                int DongBiLoi = iLoi + 1;
                MessageBox.Show("Thêm mới Đại lý Internet thất bại tại dòng "+ DongBiLoi + ". Vui lòng kiểm tra dữ liệu", "Thông báo");
                Cursor = Cursors.Default;
            }

            QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
            Cursor = Cursors.Default;
        }

        private void ThemMoiTuFileExcel_Load(object sender, EventArgs e)
        {
        }

        private void comboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboTenChuDaiLy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CboboxNhaMang_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
      
        private void button3_Click(object sender, EventArgs e)
        {
            comboDiaChi.Items.Clear();
            comboGhiChu.Items.Clear();
            comboKinhDo.Items.Clear();
            comboPhienBan.Items.Clear();
            comboPhuong.Items.Clear();
            comboQuan.Items.Clear();
            comboSoGPKD.Items.Clear();
            comboSoMay.Items.Clear();
            comboTenChuDaiLy.Items.Clear();
            comboTenDaiLy.Items.Clear();
            comboViDo.Items.Clear();

            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Excell|*.xls;*.xlsx;";
            DialogResult dr = od.ShowDialog();
            if (dr == DialogResult.Abort)
                return;
            if (dr == DialogResult.Cancel)
                return;
            textBox1.Text = od.FileName.ToString();
            string sexcelconnectionstring = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + textBox1.Text + ";extended properties=" + "\"excel 12.0;hdr=yes;\"";
            string myexceldataquery = "Select * from [Sheet1$]";
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myexceldataquery, oledbconn);
            DataTable dt = new DataTable();
            myDataAdapter.Fill(dt);
            dgvData.DataSource = dt;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                comboDiaChi.Items.Add(dgvData.Columns[i].HeaderText);
                comboGhiChu.Items.Add(dgvData.Columns[i].HeaderText);
                comboKinhDo.Items.Add(dgvData.Columns[i].HeaderText);
                comboPhienBan.Items.Add(dgvData.Columns[i].HeaderText);
                comboPhuong.Items.Add(dgvData.Columns[i].HeaderText);
                comboQuan.Items.Add(dgvData.Columns[i].HeaderText);
                comboSoGPKD.Items.Add(dgvData.Columns[i].HeaderText);
                comboSoMay.Items.Add(dgvData.Columns[i].HeaderText);
                comboTenChuDaiLy.Items.Add(dgvData.Columns[i].HeaderText);
                comboTenDaiLy.Items.Add(dgvData.Columns[i].HeaderText);
                comboViDo.Items.Add(dgvData.Columns[i].HeaderText);
            }
        }
    }
}
