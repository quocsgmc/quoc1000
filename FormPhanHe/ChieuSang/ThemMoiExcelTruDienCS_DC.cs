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

namespace QLHTDT.FormPhanHe.ChieuSang
{
    public partial class ThemMoiExcelTruDienCS_DC : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua = QLHTDT.FormPhanHe.ChieuSang.QuanLyTruDienCS_DC.ID1;
        string dateTGT = "null";
        DataTable dt = new DataTable();
        public ThemMoiExcelTruDienCS_DC()
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
        }
        private void ThemMoiExcelTruDienCS_DC_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            SqlDataAdapter adp2 = new SqlDataAdapter("Select TENTUYEN,OBJECTID from [TUYENDIENCSDC]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds2 = new DataSet();
            adp1.Fill(ds1);
            comboTuyenDay.DataSource = ds1.Tables[0];
            comboTuyenDay.DisplayMember = "TENTUYEN";
            //comboTuyenDay.ValueMember = "OBJECTID";
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
            try
            {
                int KinhDo = -1;
                int ViDo = -1;
                int TenTru = -1;
                int DiaChi = -1;
                int LoaiTru = -1;
                int LoaiBong = -1;
                int ThoiGianThay = -1;
                int GhiChu = -1;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dgvData.Columns[i].HeaderText == comboBox1.Text)
                    {
                        ViDo = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboBox2.Text)
                    {
                        KinhDo = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboBox3.Text)
                    {
                        TenTru = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboBox4.Text)
                    {
                        DiaChi = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboBox5.Text)
                    {
                        LoaiTru = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboBox6.Text)
                    {
                        LoaiBong = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboBox7.Text)
                    {
                        ThoiGianThay = i;
                    }

                    if (dgvData.Columns[i].HeaderText == comboBox8.Text)
                    {
                        GhiChu = i;
                    }

                }
                try
                {
                    for (iLoi = 0; iLoi < dgvData.RowCount - 1; iLoi++)
                    {
                        string KinhDo1;
                        string ViDo1;
                        string TenTru1;
                        string DiaChi1;
                        string LoaiTru1;
                        string LoaiBong1;
                        string ThoiGianThay1;
                        string GhiChu1;
                        if (comboBox1.Text != "")
                        { ViDo1 = dgvData.Rows[iLoi].Cells[ViDo].Value.ToString(); }
                        else { ViDo1 = "null"; }
                        if (comboBox2.Text != "")
                        { KinhDo1 = dgvData.Rows[iLoi].Cells[KinhDo].Value.ToString(); }
                        else { KinhDo1 = "null"; }
                        if (comboBox3.Text != "")
                        { TenTru1 = dgvData.Rows[iLoi].Cells[TenTru].Value.ToString(); }
                        else { TenTru1 = ""; }
                        if (comboBox4.Text != "")
                        { DiaChi1 = dgvData.Rows[iLoi].Cells[DiaChi].Value.ToString(); }
                        else { DiaChi1 = ""; }
                        if (comboBox5.Text != "")
                        { LoaiTru1 = dgvData.Rows[iLoi].Cells[LoaiTru].Value.ToString(); }
                        else { LoaiTru1 = ""; }
                        if (comboBox6.Text != "")
                        { LoaiBong1 = dgvData.Rows[iLoi].Cells[LoaiBong].Value.ToString(); }
                        else { LoaiBong1 = ""; }
                        if (comboBox7.Text != "")
                        { ThoiGianThay1 = dgvData.Rows[iLoi].Cells[ThoiGianThay].Value.ToString(); }
                        else { ThoiGianThay1 = "null"; }
                        if (comboBox8.Text != "")
                        { GhiChu1 = dgvData.Rows[iLoi].Cells[GhiChu].Value.ToString(); }
                        else { GhiChu1 = ""; }
                        string TuyenDay = "null";
                        string Phuong = "null";
                        if (comboTuyenDay.Text != "")
                        {
                            TuyenDay = comboTuyenDay.SelectedValue.ToString();
                        }
                        if (comboPhuong.Text != "")
                        {
                            Phuong = comboPhuong.SelectedValue.ToString();
                        }

                        ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("TRUDIENCSDC");
                        // tạo mới đối tượng
                        feature = ftClassSDE.CreateFeature();
                        objectid = feature.OID;
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();

                        string sql1 = "[PRC_UPDATE_TRUDIENCHIEUSANGDC_XY_BY_ID] "
                            + " '" + objectid
                            + "', N'" + TenTru1
                            + "', N'" + DiaChi1
                            + "', N'" + LoaiTru1
                            + "', N'" + LoaiBong1
                            + "', " + ThoiGianThay1
                               + ", '" + ViDo1
                               + "', '" + KinhDo1
                            + "', N'" + GhiChu1
                            + "', " + TuyenDay
                            + ", " + Phuong
                            + ", 'Point(" + ViDo1 + " " + KinhDo1 + ")'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                    }
                    MessageBox.Show("Thêm mới Trụ điện CS thành công", "Thông báo");
                    this.Hide(); Cursor = Cursors.Default;
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

                MessageBox.Show("Thêm mới Trụ điện chiếu sáng thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                Cursor = Cursors.Default;
            }

            QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
            Cursor = Cursors.Default;
        }

        private void comboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                comboQuan.Text = "";
            }
            if (AddQuan == 1)
            {
                MaHuyen = comboQuan.SelectedValue.ToString();
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + " ";
                DataSet ds2 = new DataSet();
                SqlDataAdapter adp2 = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                adp2.Fill(ds2);
                comboPhuong.DataSource = ds2.Tables[0];
                comboPhuong.DisplayMember = "TenPhuong";
                comboPhuong.ValueMember = "MaPhuong";
            }
        }

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
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            //comboQuan.Items.Clear();
            //comboPhuong.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox8.Items.Clear();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                comboBox1.Items.Add(dgvData.Columns[i].HeaderText);
                comboBox2.Items.Add(dgvData.Columns[i].HeaderText);
                //comboQuan.Items.Add(dgvData.Columns[i].HeaderText);
                //comboPhuong.Items.Add(dgvData.Columns[i].HeaderText);
                comboBox3.Items.Add(dgvData.Columns[i].HeaderText);
                comboBox4.Items.Add(dgvData.Columns[i].HeaderText);
                comboBox5.Items.Add(dgvData.Columns[i].HeaderText);
                comboBox6.Items.Add(dgvData.Columns[i].HeaderText);
                comboBox7.Items.Add(dgvData.Columns[i].HeaderText);
                comboBox8.Items.Add(dgvData.Columns[i].HeaderText);
            }
        }

        private void comboTuyenDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTuyenDay.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboTuyenDay.Text = "";
            }
        }
    }
}
