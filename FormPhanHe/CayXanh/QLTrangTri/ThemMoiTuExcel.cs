using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;
using ESRI.ArcGIS.Geodatabase;

namespace QLHTDT.FormPhanHe.CayXanh.QLTrangTri
{

    public partial class ThemMoiTuExcel : Form
    {
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        public ThemMoiTuExcel()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void button1_Click(object sender, EventArgs e)//Mở file excel
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
            comboMaCay.Items.Clear();
            //comboTenChungLoai.Items.Clear();
            comboQuan.Items.Clear();
            comboPhuong.Items.Clear();
            comboLoaiCay.Items.Clear();
            comboKinhDo.Items.Clear();
            comboViDo.Items.Clear();
            //comboTenDuong.Items.Clear();
            //comboCongVien.Items.Clear();
            //comboDonViQL.Items.Clear();
            comboHienTrang.Items.Clear();
            comboGhiChu.Items.Clear();
            comboDienTich.Items.Clear();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                comboMaCay.Items.Add(dgvData.Columns[i].HeaderText);
                //comboTenChungLoai.Items.Add(dgvData.Columns[i].HeaderText);
                comboQuan.Items.Add(dgvData.Columns[i].HeaderText);
                comboPhuong.Items.Add(dgvData.Columns[i].HeaderText);
                comboLoaiCay.Items.Add(dgvData.Columns[i].HeaderText);
                comboKinhDo.Items.Add(dgvData.Columns[i].HeaderText);
                comboViDo.Items.Add(dgvData.Columns[i].HeaderText);
                //comboTenDuong.Items.Add(dgvData.Columns[i].HeaderText);
                //comboCongVien.Items.Add(dgvData.Columns[i].HeaderText);
                //comboDonViQL.Items.Add(dgvData.Columns[i].HeaderText);
                comboHienTrang.Items.Add(dgvData.Columns[i].HeaderText);
                comboGhiChu.Items.Add(dgvData.Columns[i].HeaderText);
                comboDienTich.Items.Add(dgvData.Columns[i].HeaderText);
            }
        }
        void LoadDatabase(string Query, ComboBox Combobox, string DisplayMember, string ValueMember)
        {
            SqlDataAdapter adp = new SqlDataAdapter(Query, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Combobox.DataSource = ds.Tables[0];
            Combobox.DisplayMember = DisplayMember;
            Combobox.ValueMember = ValueMember;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadDatabase("PRC_Query_TenHuyen_By_MAHuyen null", comboQuan, "TENHUYEN", "MAHUYEN");
            LoadDatabase("PRC_QUERY_DUONGCHINH", comboTenDuong, "TenDuong", "OBJECTID");
            LoadDatabase("PRC_QUERYTABLE_ChungLoaiCayXanh", comboTenChungLoai, "TenChungLoaiCay", "IDChungLoaiCay");
            LoadDatabase("PRC_QUERYTABLE_DonViQLCX", comboDonViQL, "TenDonVi", "IDDVQLCX");
            LoadDatabase("PRC_QUERYTABLE_CONGVIEN", comboCongVien, "TenCongVien", "OBJECTID");
        }

        public void ImportDataFromExcel(string excelFilePath)//Test Cập nhật excel
        {


        }
        int iLoi;
        private void button2_Click_1(object sender, EventArgs e)
        {
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            try
            {
                int TenChungLoai = -1;
                int Quan = -1;
                int Phuong = -1;
                int LoaiCay = -1;
                int KinhDo = -1;
                int ViDo = -1;
                int TenDuong = -1;
                int CongVien = -1;
                int DonViQL = -1;
                int HienTrang = -1;
                int GhiChu = -1;
                int MaCay = -1;
                int DienTich = -1;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dgvData.Columns[i].HeaderText == comboTenChungLoai.Text)
                    {
                        TenChungLoai = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboQuan.Text)
                    {
                        Quan = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboPhuong.Text)
                    {
                        Phuong = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboLoaiCay.Text)
                    {
                        LoaiCay = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboKinhDo.Text)
                    {
                        KinhDo = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboViDo.Text)
                    {
                        ViDo = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboTenDuong.Text)
                    {
                        TenDuong = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboCongVien.Text)
                    {
                        CongVien = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboQuan.Text)
                    {
                        Quan = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboDonViQL.Text)
                    {
                        DonViQL = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboHienTrang.Text)
                    {
                        HienTrang = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboGhiChu.Text)
                    {
                        GhiChu = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboMaCay.Text)
                    {
                        MaCay = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboDienTich.Text)
                    {
                        DienTich = i;
                    }


                }
                try
                {
                    for (iLoi = 0; iLoi < dgvData.RowCount - 1; iLoi++)
                    {
                        string TenChungLoai1;
                        string Quan1;
                        string Phuong1;
                        string LoaiCay1;
                        string KinhDo1;
                        string ViDo1;
                        string TenDuong1;
                        string CongVien1;
                        string DonViQL1;
                        string HienTrang1;
                        string GhiChu1;
                        string MaCay1;
                        string DienTich1;
                        if (comboTenChungLoai.Text != "")
                        { TenChungLoai1 = comboTenChungLoai.SelectedValue.ToString(); }
                        else { TenChungLoai1 = "null"; }
                        if (comboQuan.Text != "")
                        { Quan1 = dgvData.Rows[iLoi].Cells[Quan].Value.ToString(); }
                        else { Quan1 = "null"; }
                        if (comboPhuong.Text != "")
                        { Phuong1 = dgvData.Rows[iLoi].Cells[Phuong].Value.ToString(); }
                        else { Phuong1 = "null"; }
                        if (comboLoaiCay.Text != "")
                        { LoaiCay1 = dgvData.Rows[iLoi].Cells[LoaiCay].Value.ToString(); }
                        else { LoaiCay1 = ""; }
                        if (comboKinhDo.Text != "")
                        { KinhDo1 = dgvData.Rows[iLoi].Cells[KinhDo].Value.ToString(); }
                        else { KinhDo1 = ""; }
                        if (comboViDo.Text != "")
                        { ViDo1 = dgvData.Rows[iLoi].Cells[ViDo].Value.ToString(); }
                        else { ViDo1 = ""; }
                        if (comboTenDuong.Text != "")
                        { TenDuong1 = comboTenDuong.SelectedValue.ToString(); }
                        else { TenDuong1 = "null"; }
                        if (comboCongVien.Text != "")
                        { CongVien1 = comboCongVien.SelectedValue.ToString();}
                        else { CongVien1 = "null"; }
                        if (comboDonViQL.Text != "")
                        { DonViQL1 = comboDonViQL.SelectedValue.ToString(); }
                        else { DonViQL1 = "null"; }
                        if (comboHienTrang.Text != "")
                        { HienTrang1 = dgvData.Rows[iLoi].Cells[HienTrang].Value.ToString(); }
                        else { HienTrang1 = ""; }
                        if (comboGhiChu.Text != "")
                        { GhiChu1 = dgvData.Rows[iLoi].Cells[GhiChu].Value.ToString(); }
                        else { GhiChu1 = ""; }
                        if (comboMaCay.Text != "")
                        { MaCay1 = dgvData.Rows[iLoi].Cells[MaCay].Value.ToString(); }
                        else { MaCay1 = ""; }
                        if (comboDienTich.Text != "")
                        { DienTich1 = dgvData.Rows[iLoi].Cells[DienTich].Value.ToString(); }
                        else { DienTich1 = "null"; }


                        ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("CAYTRANGTRI");
                        // tạo mới đối tượng
                        feature = ftClassSDE.CreateFeature();
                        objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_CAYTRANGTRI_XY_BY_ID] " //update Cây trang trí
                             + " '" + objectid
                             + "', N'" + MaCay1
                             + "', " + DienTich1
                             + ", N'" + HienTrang1
                             + "', N'" + LoaiCay1
                             + "', " + TenDuong1
                             + ", " + Phuong1
                             + ", " + CongVien1
                             + ", " + TenChungLoai1
                             + ", " + DonViQL1
                             + ", '" + KinhDo1
                             + "', '" + ViDo1
                             + "','Point(" + ViDo1 + " " + KinhDo1 + ")'";

                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                    }
                    MessageBox.Show("Thêm mới Cây trang trí thành công", "Thông báo");
                    this.Hide(); Cursor = Cursors.Default;
                    CayXanh.QuanLyTrangTri.QuanLyTrangTri.LoadLaiForm = 1;
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
                MessageBox.Show("Thêm mới Cây trang trí thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                Cursor = Cursors.Default;
            }
            QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
            Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboTenChungLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTenChungLoai.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboTenChungLoai.Text = "";
            }
        }

        private void comboTenDuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTenDuong.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboTenDuong.Text = "";
            }
        }

        private void comboCongVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCongVien.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboCongVien.Text = "";
            }
        }

        private void comboDonViQL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDonViQL.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboDonViQL.Text = "";
            }
        }
    }
}
