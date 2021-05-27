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

namespace QLHTDT.FormPhanHe.CayXanh.QLCayXanh
{

    public partial class ThemMoiTuExcel : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
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
            //string sexcelconnectionstring = @"Provider = Microsoft.ACE.OLEDB.16.0; Data Source = " + textBox1.Text + "; Extended Properties =\"Excel 16.0;ReadOnly=False;HDR=Yes;\"";
            //string sexcelconnectionstring1 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + textBox1.Text + ";Extended Properties=\"EXCEL 12.0 XML; HDR = YES;IMEX = 1";
            string myexceldataquery = "Select * from [Sheet1$]";
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myexceldataquery, oledbconn);
            oledbconn.Open();
            myDataAdapter.Fill(dt);
            dgvData.DataSource = dt;
            comboMaCay.Items.Clear();
            comboTenChungLoai.Items.Clear();
            //comboQuan.Items.Clear();
            //comboPhuong.Items.Clear();
            comboLoaiCay.Items.Clear();
            comboKinhDo.Items.Clear();
            comboViDo.Items.Clear();
            //comboTenDuong.Items.Clear();
            comboSoNha.Items.Clear();
            comboPhanLoai.Items.Clear();
            comboCongVien.Items.Clear();
            comboDuongKinhThan.Items.Clear();
            comboDonViQL.Items.Clear();
            comboNamTrong.Items.Clear();
            comboChieuCao.Items.Clear();
            comboHienTrang.Items.Clear();
            comboGhiChu.Items.Clear();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                comboMaCay.Items.Add(dgvData.Columns[i].HeaderText);
                comboTenChungLoai.Items.Add(dgvData.Columns[i].HeaderText);
                //comboQuan.Items.Add(dgvData.Columns[i].HeaderText);
                //comboPhuong.Items.Add(dgvData.Columns[i].HeaderText);
                comboLoaiCay.Items.Add(dgvData.Columns[i].HeaderText);
                comboKinhDo.Items.Add(dgvData.Columns[i].HeaderText);
                comboViDo.Items.Add(dgvData.Columns[i].HeaderText);
                //comboTenDuong.Items.Add(dgvData.Columns[i].HeaderText);
                //comboPhuong.Items.Add(dgvData.Columns[i].HeaderText);
                //comboQuan.Items.Add(dgvData.Columns[i].HeaderText);
                comboSoNha.Items.Add(dgvData.Columns[i].HeaderText);
                comboPhanLoai.Items.Add(dgvData.Columns[i].HeaderText);
                comboCongVien.Items.Add(dgvData.Columns[i].HeaderText);
                comboDuongKinhThan.Items.Add(dgvData.Columns[i].HeaderText);
                comboDonViQL.Items.Add(dgvData.Columns[i].HeaderText);
                comboNamTrong.Items.Add(dgvData.Columns[i].HeaderText);
                comboChieuCao.Items.Add(dgvData.Columns[i].HeaderText);
                comboHienTrang.Items.Add(dgvData.Columns[i].HeaderText);
                comboGhiChu.Items.Add(dgvData.Columns[i].HeaderText);
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
            //showgridControl1();
            LoadDatabase("PRC_Query_TenHuyen_By_MAHuyen null", comboQuan, "TENHUYEN", "MAHUYEN");
            LoadDatabase("PRC_QUERY_DUONGCHINH", comboTenDuong, "TenDuong", "OBJECTID");
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
                //int Quan = -1;
                //int Phuong = -1;
                int LoaiCay = -1;
                int KinhDo = -1;
                int ViDo = -1;
                //int TenDuong = -1;
                int SoNha = -1;
                int PhanLoai = -1;
                int CongVien = -1;
                int DuongKinhThan = -1;
                int DonViQL = -1;
                int NamTrong = -1;
                int ChieuCao = -1;
                int HienTrang = -1;
                int GhiChu = -1;
                int MaCay = -1;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dgvData.Columns[i].HeaderText == comboTenChungLoai.Text)
                    {
                        TenChungLoai = i;
                    }
                    //if (dgvData.Columns[i].HeaderText == comboQuan.Text)
                    //{
                    //    Quan = i;
                    //}
                    //if (dgvData.Columns[i].HeaderText == comboPhuong.Text)
                    //{
                    //    Phuong = i;
                    //}
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
                    //if (dgvData.Columns[i].HeaderText == comboTenDuong.Text)
                    //{
                    //    TenDuong = i;
                    //}
                    if (dgvData.Columns[i].HeaderText == comboSoNha.Text)
                    {
                        SoNha = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboPhanLoai.Text)
                    {
                        PhanLoai = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboCongVien.Text)
                    {
                        CongVien = i;
                    }
            
                    if (dgvData.Columns[i].HeaderText == comboDuongKinhThan.Text)
                    {
                        DuongKinhThan = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboDonViQL.Text)
                    {
                        DonViQL = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboNamTrong.Text)
                    {
                        NamTrong = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboChieuCao.Text)
                    {
                        ChieuCao = i;
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
                        string SoNha1;
                        string PhanLoai1;
                        string CongVien1;
                        string DuongKinhThan1;
                        string DonViQL1;
                        string NamTrong1;
                        string ChieuCao1;
                        string HienTrang1;
                        string GhiChu1;
                        string MaCay1;
                        if (comboTenChungLoai.Text != "")
                        { TenChungLoai1 = dgvData.Rows[iLoi].Cells[TenChungLoai].Value.ToString(); }
                        else { TenChungLoai1 = "null"; }
                        //if (comboQuan.Text != "")
                        //{ Quan1 = dgvData.Rows[iLoi].Cells[Quan].Value.ToString(); }
                        //else { Quan1 = "null"; }
                        //if (comboPhuong.Text != "")
                        //{ Phuong1 = dgvData.Rows[iLoi].Cells[Phuong].Value.ToString(); }
                        //else { Phuong1 = "null"; }
                        if (comboLoaiCay.Text != "")
                        { LoaiCay1 = dgvData.Rows[iLoi].Cells[LoaiCay].Value.ToString(); }
                        else { LoaiCay1 = "null"; }
                        if (comboKinhDo.Text != "")
                        { KinhDo1 = dgvData.Rows[iLoi].Cells[KinhDo].Value.ToString(); }
                        else { KinhDo1 = ""; }
                        if (comboViDo.Text != "")
                        { ViDo1 = dgvData.Rows[iLoi].Cells[ViDo].Value.ToString(); }
                        else { ViDo1 = ""; }
                        //if (comboTenDuong.Text != "")
                        //{ TenDuong1 = dgvData.Rows[iLoi].Cells[TenDuong].Value.ToString(); }
                        //else { TenDuong1 = "null"; }
                        if (comboSoNha.Text != "")
                        { SoNha1 = dgvData.Rows[iLoi].Cells[SoNha].Value.ToString(); }
                        else { SoNha1 = ""; }
                        if (comboPhanLoai.Text != "")
                        { PhanLoai1 = dgvData.Rows[iLoi].Cells[PhanLoai].Value.ToString(); }
                        else { PhanLoai1 = ""; }
                        if (comboCongVien.Text != "")
                        { CongVien1 = dgvData.Rows[iLoi].Cells[CongVien].Value.ToString(); }
                        else { CongVien1 = "null"; }
                        if (comboDuongKinhThan.Text != "")
                        { DuongKinhThan1 = dgvData.Rows[iLoi].Cells[DuongKinhThan].Value.ToString(); }
                        else { DuongKinhThan1 = "null"; }
                        if (comboDonViQL.Text != "")
                        { DonViQL1 = dgvData.Rows[iLoi].Cells[DonViQL].Value.ToString(); }
                        else { DonViQL1 = "null"; }
                        if (comboNamTrong.Text != "")
                        { NamTrong1 = dgvData.Rows[iLoi].Cells[NamTrong].Value.ToString(); }
                        else { NamTrong1 = "null"; }
                        if (comboChieuCao.Text != "")
                        { ChieuCao1 = dgvData.Rows[iLoi].Cells[ChieuCao].Value.ToString(); }
                        else { ChieuCao1 = "null"; }
                        if (comboHienTrang.Text != "")
                        { HienTrang1 = dgvData.Rows[iLoi].Cells[HienTrang].Value.ToString(); }
                        else { HienTrang1 = ""; }
                        if (comboGhiChu.Text != "")
                        { GhiChu1 = dgvData.Rows[iLoi].Cells[GhiChu].Value.ToString(); }
                        else { GhiChu1 = ""; }
                        if (comboMaCay.Text != "")
                        { MaCay1 = dgvData.Rows[iLoi].Cells[MaCay].Value.ToString(); }
                        else { MaCay1 = ""; }

                        string TenDuong = "null";
                        string Phuong = "null";
                        if (comboTenDuong.Text != "")
                        {
                            TenDuong = comboTenDuong.SelectedValue.ToString();
                        }
                        if (comboPhuong.Text != "")
                        {
                            Phuong = comboPhuong.SelectedValue.ToString();
                        }

                        //ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("CAYBONGMAT");
                        //// tạo mới đối tượng
                        //feature = ftClassSDE.CreateFeature();
                        //objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_INSERT_CAYXANH] " //update Cây xanh
                       //+ " '" + objectid
                       //+ "', " + TenDuong
                       + " " + TenDuong
                       + ", " + Phuong
                       + ", " + CongVien1
                       + ", N'" + SoNha1
                       + "', N'" + MaCay1
                       + "', " + ChieuCao1
                       + ", " + DuongKinhThan1
                       + ", " + NamTrong1
                       + ", N'" + PhanLoai1
                       + "', N'" + HienTrang1
                       + "', " + TenChungLoai1
                       + ", " + DonViQL1
                       + ", N'" + GhiChu1
                       + "', " + LoaiCay1
                       + ", '" + KinhDo1
                       + "', '" + ViDo1
                       + "','Point(" + ViDo1 + " " + KinhDo1 + ")'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                    }
                    MessageBox.Show("Thêm mới Cây xanh thành công", "Thông báo");
                    this.Hide(); Cursor = Cursors.Default;

                    CayXanh.QuanLyCayXanh.QuanLyCayXanh.LoadLaiForm = 1;

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            comboPhuong.ResetText();
            if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                comboQuan.Text = "";
            }
            if (AddQuan == 1)
            {
                MaHuyen = comboQuan.SelectedValue.ToString();
                LoadDatabase("[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + "", comboPhuong, "TenPhuong", "MaPhuong");
                if (comboPhuong.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    comboPhuong.Text = "";
                }
            }
        }

        private void comboTenDuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTenDuong.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboTenDuong.Text = "";
            }
        }

        private void comboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
