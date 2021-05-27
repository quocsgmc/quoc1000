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

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS
{
    public partial class ThemMoiTuFileExcel : Form
    {

        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        public ThemMoiTuFileExcel()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ThemMoiTuFileExcel_Load(object sender, EventArgs e)
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
                int TinhTrang = -1;
                int DiaChi = -1;
                int DNSD = -1;
                int DoCao = -1;
                int DungChung = -1;
                int SoGP = -1;
                int SoGCN = -1;
                int KinhDo = -1;
                int LoaiTram = -1;
                int Phuong = -1;
                int Quan = -1;
                int TenChuDauTu = -1;
                int ThongTinKhac = -1;
                int ViDo = -1;
                int Khac = -1;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dgvData.Columns[i].HeaderText == cboxTinhTrang.Text)
                    {
                        TinhTrang = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboDiaChi.Text)
                    {
                        DiaChi = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboDNSD.Text)
                    {
                        DNSD = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboDoCao.Text)
                    {
                        DoCao = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboDungChung.Text)
                    {
                        DungChung = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboGiayPhep.Text)
                    {
                        SoGP = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboSoCN.Text)
                    {
                        SoGCN = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboKinhDo.Text)
                    {
                        KinhDo = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboLoaiTram.Text)
                    {
                        LoaiTram = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboPhuong.Text)
                    {
                        Phuong = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboQuan.Text)
                    {
                        Quan = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboTenChuDauTu.Text)
                    {
                        TenChuDauTu = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboThongTinKhac.Text)
                    {
                        ThongTinKhac = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboViDo.Text)
                    {
                        ViDo = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboKhac.Text)
                    {
                        Khac = i;
                    }


                }
                try
                {
                    for (iLoi = 0; iLoi < dgvData.RowCount - 1; iLoi++)
                    {
                        string ChuDauTu1;
                        string TinhTrang1;
                        string KinhDo1;
                        string ViDo1;
                        string DoCao1;
                        string DNSD1;
                        string LoaiTram1;
                        string ThongTinKhac1;
                        string DiaChi1;
                        string DungChung1;
                        string Khac1;
                        string Phuong1;
                        string Quan1;
                        string SoGP1;
                        string SoGCN1;
                        if (comboTenChuDauTu.Text != "")
                        { ChuDauTu1 = dgvData.Rows[iLoi].Cells[TenChuDauTu].Value.ToString(); }
                        else { ChuDauTu1 = "null"; }
                        if (cboxTinhTrang.Text != "")
                        { TinhTrang1 = dgvData.Rows[iLoi].Cells[TinhTrang].Value.ToString(); }
                        else { TinhTrang1 = "null"; }
                        if (comboKinhDo.Text != "")
                        { KinhDo1 = dgvData.Rows[iLoi].Cells[KinhDo].Value.ToString(); }
                        else { KinhDo1 = "null"; }
                        if (comboViDo.Text != "")
                        { ViDo1 = dgvData.Rows[iLoi].Cells[ViDo].Value.ToString(); }
                        else { ViDo1 = "null"; }
                        if (comboDoCao.Text != "")
                        { DoCao1 = dgvData.Rows[iLoi].Cells[DoCao].Value.ToString(); }
                        else { DoCao1 = "null"; }
                        if (comboDNSD.Text != "")
                        { DNSD1 = dgvData.Rows[iLoi].Cells[DNSD].Value.ToString(); }
                        else { DNSD1 = ""; }
                        if (comboLoaiTram.Text != "")
                        { LoaiTram1 = dgvData.Rows[iLoi].Cells[LoaiTram].Value.ToString(); }
                        else { LoaiTram1 = "null"; }
                        if (comboThongTinKhac.Text != "")
                        { ThongTinKhac1 = dgvData.Rows[iLoi].Cells[ThongTinKhac].Value.ToString(); }
                        else { ThongTinKhac1 = ""; }
                        if (comboDiaChi.Text != "")
                        { DiaChi1 = dgvData.Rows[iLoi].Cells[DiaChi].Value.ToString(); }
                        else { DiaChi1 = ""; }
                        if (comboDungChung.Text != "")
                        { DungChung1 = dgvData.Rows[iLoi].Cells[DungChung].Value.ToString(); }
                        else { DungChung1 = ""; }
                        if (comboKhac.Text != "")
                        { Khac1 = dgvData.Rows[iLoi].Cells[Khac].Value.ToString(); }
                        else { Khac1 = ""; }
                        if (comboPhuong.Text != "")
                        { Phuong1 = dgvData.Rows[iLoi].Cells[Phuong].Value.ToString(); }
                        else { Phuong1 = "null"; }
                        if (comboQuan.Text != "")
                        { Quan1 = dgvData.Rows[iLoi].Cells[Quan].Value.ToString(); }
                        else { Quan1 = "null"; }
                        if (comboGiayPhep.Text != "")
                        { SoGP1 = dgvData.Rows[iLoi].Cells[SoGP].Value.ToString(); }
                        else { SoGP1 = ""; }
                        if(comboSoCN.Text != "")
                        { SoGCN1 = dgvData.Rows[iLoi].Cells[SoGCN].Value.ToString(); }
                        else { SoGCN1 = ""; }


                        ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("TRAMBTS");
                        // tạo mới đối tượng
                        feature = ftClassSDE.CreateFeature();
                        objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        
                        string sql1 = "[PRC_UPDATE_TRAMBTS_XY_BY_ID] "
                            + " '" + objectid
                            + "', N'" + DiaChi1
                            + "', '" + KinhDo1
                            + "', '" + ViDo1
                            + "', " + DoCao1
                            + ", N'" + SoGP1
                            + "', " + dateCP
                            + ", N'" + SoGCN1
                            + "', " + dateGCN
                            + ", '" + DungChung1
                            + "', N'" + ThongTinKhac1
                            + "', " + LoaiTram1
                            + ", " + ChuDauTu1
                            + ", " +Phuong1
                            + ", " + Quan1
                            + ", " + TinhTrang1
                            + ", N'" + DNSD1
                            +"', 'Point(" + KinhDo1 + " " + ViDo1 + ")'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                    }
                    MessageBox.Show("Thêm mới Trạm BTS thành công", "Thông báo");
                    this.Hide(); Cursor = Cursors.Default;
                    BuuChinh_VienThong.QuanLyTramBTS.QuanLyTramBTS.LoadLaiForm = 1;
                }
                catch
                {
                    if (feature != null)
                    { feature.Delete(); }
                    int DongBiLoi = iLoi + 2;
                    MessageBox.Show("Dữ liệu dòng thứ " + DongBiLoi + " bị sai định dạng. Vui lòng thử lại", "Thông báo");
                    Cursor = Cursors.Default;
                }
            }
            catch
            {
                //xóa đối tượng đã tạo nếu có lỗi
                if (feature != null)
                { feature.Delete(); }
                MessageBox.Show("Thêm mới Cây xanh thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                Cursor = Cursors.Default;
            }

            QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
            Cursor = Cursors.Default;
        }
        DataTable dt = new DataTable();
        private void button3_Click(object sender, EventArgs e)
        {
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
            myDataAdapter.Fill(dt);
            dgvData.DataSource = dt;
            comboDiaChi.Items.Clear();
            comboDNSD.Items.Clear();
            comboDoCao.Items.Clear();
            comboDungChung.Items.Clear();
            comboGiayPhep.Items.Clear();
            comboSoCN.Items.Clear();
            comboKinhDo.Items.Clear();
            comboLoaiTram.Items.Clear();
            comboPhuong.Items.Clear();
            comboQuan.Items.Clear();
            comboTenChuDauTu.Items.Clear();
            comboThongTinKhac.Items.Clear();
            comboViDo.Items.Clear();
            comboKhac.Items.Clear();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                comboDiaChi.Items.Add(dgvData.Columns[i].HeaderText);
                comboDNSD.Items.Add(dgvData.Columns[i].HeaderText);
                comboDoCao.Items.Add(dgvData.Columns[i].HeaderText);
                comboDungChung.Items.Add(dgvData.Columns[i].HeaderText);
                comboGiayPhep.Items.Add(dgvData.Columns[i].HeaderText);
                comboSoCN.Items.Add(dgvData.Columns[i].HeaderText);
                comboKinhDo.Items.Add(dgvData.Columns[i].HeaderText);
                comboLoaiTram.Items.Add(dgvData.Columns[i].HeaderText);
                comboPhuong.Items.Add(dgvData.Columns[i].HeaderText);
                comboQuan.Items.Add(dgvData.Columns[i].HeaderText);
                comboTenChuDauTu.Items.Add(dgvData.Columns[i].HeaderText);
                comboThongTinKhac.Items.Add(dgvData.Columns[i].HeaderText);
                comboViDo.Items.Add(dgvData.Columns[i].HeaderText);
                comboKhac.Items.Add(dgvData.Columns[i].HeaderText);
            }
        }
    }

    }
