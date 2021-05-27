﻿using DevExpress.XtraGrid.Views.Base;
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
    public partial class ChinhSuaMotTram : Form
    {
        public static string MaHuyen = "null";
        int AddQuan = 0;
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        int IDChinhSua;
        public ChinhSuaMotTram(int OBJECTID)
        {
            InitializeComponent();
            if (QLHTDT.FormChinh.KienTruc.FeatureWorkspace != null)
            { featureWorkspaceSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace; }
            IDChinhSua = OBJECTID;
        }
        private void ChinhSuaMotTram_Load(object sender, EventArgs e)
        {
            comboHeToaDo.Text = "VN2000";

            SqlDataAdapter adp = new SqlDataAdapter("[PRC_QUERY_TABLE_ChuDauTu]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboTenChuDauTu.DataSource = ds.Tables[0];
            comboTenChuDauTu.DisplayMember = "TENCHUDATU";
            comboTenChuDauTu.ValueMember = "IDCHUDAUTU";


            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            SqlDataAdapter adp2 = new SqlDataAdapter("[PRC_QUERY_TABLE_LOAITRAMBTS]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            comboLoaiTram.DataSource = ds2.Tables[0];
            comboLoaiTram.DisplayMember = "TENLOAITRAM";
            comboLoaiTram.ValueMember = "IDLOAITRAM";

            SqlDataAdapter adp4 = new SqlDataAdapter("[PRC_QUERY_TABLE_TINHTRANGBTS]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds4 = new DataSet();
            adp4.Fill(ds4);
            cboxTinhTrang.DataSource = ds4.Tables[0];
            cboxTinhTrang.DisplayMember = "TinhTrang";
            cboxTinhTrang.ValueMember = "IDTinhTrang";
  
            if (IDChinhSua != 0)
            {
           
                SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERYTramBTS_BY_ID] " + IDChinhSua + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);
                comboTenChuDauTu.Text = ds3.Tables[0].Rows[0]["TenChuDauTu"].ToString();
                txtKinhDo.Text = ds3.Tables[0].Rows[0]["KinhDo"].ToString().Replace(",", ".");
                txtViDo.Text = ds3.Tables[0].Rows[0]["ViDo"].ToString().Replace(",", ".");
                txtDoCao.Text = ds3.Tables[0].Rows[0]["DoCao"].ToString().Replace(",", ".");
                comboLoaiTram.Text = ds3.Tables[0].Rows[0]["TenLoaiTram"].ToString();
                txtDiaChi.Text = ds3.Tables[0].Rows[0]["DiaChi"].ToString();
                comboQuan.Text = ds3.Tables[0].Rows[0]["QuanHuyen"].ToString();
                comboPhuong.Text = ds3.Tables[0].Rows[0]["TenPhuong"].ToString();
                txtSoGiayPhep.Text = ds3.Tables[0].Rows[0]["SoGP"].ToString();
                dateTimePickerCapGP.Text = ds3.Tables[0].Rows[0]["NgayCapGP"].ToString();
                txtSoCN.Text = ds3.Tables[0].Rows[0]["SoCN"].ToString();
                dateTimePickerGCN.Text = ds3.Tables[0].Rows[0]["NgayVaoSoCN"].ToString();
                cboxTinhTrang.Text = ds3.Tables[0].Rows[0]["TinhTrang"].ToString();
                txtDoanhNghiepSuDung.Text = ds3.Tables[0].Rows[0]["DoanhNghiepSuDung"].ToString();
                textBoxDungChung.Text = ds3.Tables[0].Rows[0]["DungChung"].ToString();
                textTTKhac.Text = ds3.Tables[0].Rows[0]["ThongTinKh"].ToString();
                txtKhac.Text = ds3.Tables[0].Rows[0]["Khac"].ToString();
            }

        }

        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn Chỉnh sửa Trạm BTS không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                IFeature feature = null;
                int objectid;
                Cursor = Cursors.WaitCursor;
                bool check = true;
                string dateCP = null;
                string dateGCN = null;
                double KDo; double VDo;
                string CCao = "null"; double ChieuCao;
                //check dữ liệu nhập vào
                bool isNumeric;
                if (isNumeric = double.TryParse(txtKinhDo.Text, out KDo))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Kinh độ!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    check = false; Cursor = Cursors.Default; return;
                }

                isNumeric = true;
                if (isNumeric = double.TryParse(txtViDo.Text, out VDo))
                { }
                else
                {
                    MessageBox.Show("Sai định dạng dữ liệu Vi độ!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                    check = false; Cursor = Cursors.Default; return;
                }

                isNumeric = true;
                if (txtDoCao.Text != "")
                {
                    CCao = txtDoCao.Text;
                    if (double.TryParse(CCao, out ChieuCao))
                    { }
                    else
                    {
                        MessageBox.Show("Sai định dạng dữ liệu Độ cao!\n" + "Vui lòng kiểm tra lại dữ liệu", "Thông báo");
                        check = false; Cursor = Cursors.Default; return;
                    }
                    isNumeric = true;
                }

                if (dateTimePickerGCN.Text == "01 Tháng Giêng 2000")
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa nhập ngày cấp giấy chứng nhận!\n" + "Có muốn tiếp tục hay không?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dateGCN = null;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        check = false; Cursor = Cursors.Default; return;
                    }
                }
                else { dateGCN = dateTimePickerGCN.Value.ToString("MM/dd/yyyy"); }


                if (dateTimePickerCapGP.Text == "01 Tháng Giêng 2000")
                {

                    DialogResult dialogResult = MessageBox.Show("Chưa nhập ngày cấp giấy giấy phép!\n" + "Có muốn tiếp tục hay không?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dateCP = null;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        check = false; Cursor = Cursors.Default; return;
                    }
                }
                else { dateCP = dateTimePickerCapGP.Value.ToString("MM/dd/yyyy"); }

                string ChuDauTu = "null";
                string LoaiTram = "null";
                string Quan = "null";
                string Phuong = "null";
                string TinhTrang = "null";
                if (comboTenChuDauTu.Text != "")
                {
                    ChuDauTu = comboTenChuDauTu.SelectedValue.ToString();
                }
                if (comboLoaiTram.Text != "")
                {
                    LoaiTram = comboLoaiTram.SelectedValue.ToString();
                }
                if (comboPhuong.Text != "")
                {
                    Phuong = comboPhuong.SelectedValue.ToString();
                }
                if (comboQuan.Text != "")
                {
                    Quan = comboQuan.SelectedValue.ToString();
                }
                if (cboxTinhTrang.Text != "")
                {
                    TinhTrang = cboxTinhTrang.SelectedValue.ToString();
                }


                if (check != false)
                {
                    try
                    {
                        if (comboHeToaDo.Text == "VN2000")
                        {
                            objectid = IDChinhSua;
                            //cập nhật thuộc tính đối tượng
                            SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            conn.Open();
                            string sql1 = "[PRC_UPDATE_TRAMBTS_XY_BY_ID] "
                                 + " '" + objectid
                               + "', N'" + txtDiaChi.Text
                               + "', '" + txtKinhDo.Text
                               + "', '" + txtViDo.Text
                               + "', '" + CCao
                               + "', N'" + txtSoGiayPhep.Text
                               + "', '" + dateCP
                               + "', N'" + txtSoCN.Text
                               + "', '" + dateGCN
                               + "', '" + textBoxDungChung.Text
                               + "', N'" + textTTKhac.Text
                               + "', " + LoaiTram
                               + ", " + ChuDauTu
                               + ", " + Phuong
                               + ", " + Quan
                               + ", " + TinhTrang
                               + ", N'" + txtDoanhNghiepSuDung.Text
                               + "', 'Point(" + txtViDo.Text + " " + txtKinhDo.Text + ")'";
                            SqlCommand command4 = new SqlCommand(sql1, conn);
                            command4.ExecuteScalar();

                            MessageBox.Show("Chỉnh sửa Trạm BTS thành công", "Thông báo");
                            //Phần này là lưu nhật ký
                            KienTruc.TBNK = new DataTable();
                            SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                            SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                            KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                            KienTruc.ChinhSuathuoctinhToolQuanLy("Trạm BTS", objectid);
                            KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                            this.Hide(); Cursor = Cursors.Default;
                        }
                        else
                        {
                            objectid = IDChinhSua;
                            //cập nhật thuộc tính đối tượng
                            SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            conn.Open();
                            string sql1 = "[PRC_UPDATE_TRAMBTS_BY_ID] "
                                + " '" + objectid
                               + "', N'" + txtDiaChi.Text
                               + "', '" + txtKinhDo.Text
                               + "', '" + txtViDo.Text
                               + "', '" + CCao
                               + "', N'" + txtSoGiayPhep.Text
                               + "', '" + dateCP
                               + "', N'" + txtSoCN.Text
                               + "', '" + dateGCN
                               + "', '" + textBoxDungChung.Text
                               + "', N'" + textTTKhac.Text
                               + "', " + LoaiTram
                               + ", " + ChuDauTu
                               + ", " + Phuong
                               + ", " + Quan
                               + ", " + TinhTrang
                                + "', N'" + txtDoanhNghiepSuDung.Text + "'";
                            SqlCommand command4 = new SqlCommand(sql1, conn);
                            command4.ExecuteScalar();
                            MessageBox.Show("Chỉnh sửa Trạm BTS thành công", "Thông báo");
                            //Phần này là lưu nhật ký
                            KienTruc.TBNK = new DataTable();
                            SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                            SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                            KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                            KienTruc.ChinhSuathuoctinhToolQuanLy("Trạm BTS", objectid);
                            KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                            this.Hide(); Cursor = Cursors.Default;
                        }
                    }
                    catch
                    {
                        //xóa đối tượng đã tạo nếu có lỗi
                        if (feature != null)
                        { feature.Delete(); }

                        MessageBox.Show("Chỉnh sửa Trạm BTS thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                        Cursor = Cursors.Default;
                    }

                    QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                    Cursor = Cursors.Default;
                }
            }
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
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + " ";

                SqlDataAdapter adp = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds = new DataSet();
                adp.Fill(ds);
                comboPhuong.DataSource = ds.Tables[0];
                comboPhuong.DisplayMember = "TenPhuong";
                comboPhuong.ValueMember = "MaPhuong";

                if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    comboPhuong.Text = "";
                }
            }
        }

        private void comboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
   
        }

        private void comboTenChuDauTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTenChuDauTu.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboTenChuDauTu.Text = "";
            }
        }

        private void comboLoaiTram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLoaiTram.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                comboLoaiTram.Text = "";
            }
        }

        private void comboQuan_SelectedIndexChanged_1(object sender, EventArgs e)
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
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + " ";

                SqlDataAdapter adp = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds = new DataSet();
                adp.Fill(ds);
                comboPhuong.DataSource = ds.Tables[0];
                comboPhuong.DisplayMember = "TenPhuong";
                comboPhuong.ValueMember = "MaPhuong";

                if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    comboPhuong.Text = "";
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
