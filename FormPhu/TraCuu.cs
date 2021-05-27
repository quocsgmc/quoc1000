using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace QLHTDT.FormPhu
{
    public partial class TraCuu : Form
    {
        public TraCuu()
        {
            InitializeComponent();
        }

        private void LoadLayertoCbo2()
        {
            QLHTDT.CORE.LoadLayer.LoadFeaturelayerToCombo(comboBox1, QLHTDT.FormChinh.KienTruc.axMapControl1.Map);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Cây xanh")
            { QLHTDT.FormPhanHe.CayXanh.QuanLyCayXanh.QuanLyCayXanh frm = new QLHTDT.FormPhanHe.CayXanh.QuanLyCayXanh.QuanLyCayXanh(); ; frm.Show(); this.Close(); }
            if (comboBox1.Text == "Đường giao thông chính")
            { QLHTDT.FormPhanHe.GiaoThong.QuanLyGiaoThongChinh2.QuanLyGiaoThongChinh2 frm = new QLHTDT.FormPhanHe.GiaoThong.QuanLyGiaoThongChinh2.QuanLyGiaoThongChinh2(); ; frm.Show(); }
            if (comboBox1.Text == "Đường kiệt hẻm")
            { QLHTDT.FormPhanHe.GiaoThong.QuanLyKietHem2.QuanLyKietHem2 frm = new QLHTDT.FormPhanHe.GiaoThong.QuanLyKietHem2.QuanLyKietHem2(); frm.Show(); }
            if (comboBox1.Text == "Mương thoát nước")
            { QLHTDT.FormPhanHe.MuongThoatNuoc.QuanLyMuongThoatNuoc2.QuanLyMuongThoatNuoc2 frm = new QLHTDT.FormPhanHe.MuongThoatNuoc.QuanLyMuongThoatNuoc2.QuanLyMuongThoatNuoc2(); ; frm.Show(); }
            if (comboBox1.Text == "Trụ đèn chiếu sáng kiệt hẻm")
            { QLHTDT.FormPhanHe.ChieuSang.QuanLyTruDienCS2 frm = new QLHTDT.FormPhanHe.ChieuSang.QuanLyTruDienCS2(); ; frm.Show(); }
            if (comboBox1.Text == "Trụ đèn chiếu sáng chính")
            { QLHTDT.FormPhanHe.ChieuSang.QuanLyTruDienCS_DC frm = new QLHTDT.FormPhanHe.ChieuSang.QuanLyTruDienCS_DC(); ; frm.Show(); }
            if (comboBox1.Text == "Tuyến điện chiếu sáng kiệt hẻm")
            { QLHTDT.FormPhanHe.ChieuSang.QuanLyTuyenDienChieuSang frm = new QLHTDT.FormPhanHe.ChieuSang.QuanLyTuyenDienChieuSang(); ; frm.Show(); }
            if (comboBox1.Text == "Tuyến điện chiếu sáng chính")
            { QLHTDT.FormPhanHe.ChieuSang.QuanLyTuyenDienChieuSang_DC frm = new QLHTDT.FormPhanHe.ChieuSang.QuanLyTuyenDienChieuSang_DC(); ; frm.Show(); }
            if (comboBox1.Text == "Thông tin thửa đất")
            {
                QLHTDT.FormPhanHe.DiaChinh.TraCuuDiaChinh frm = new QLHTDT.FormPhanHe.DiaChinh.TraCuuDiaChinh(); frm.Show();
            }
            if (comboBox1.Text == "Thông tin khu quy hoạch")
            {
                QLHTDT.FormPhanHe.QuyHoach_KienTruc.QLDAQH.QLDAQH frm = new QLHTDT.FormPhanHe.QuyHoach_KienTruc.QLDAQH.QLDAQH(); frm.Show();
            }
            if (comboBox1.Text == "Điều lệ quản lý kiến trúc")
            { QLHTDT.FormPhanHe.QuyHoach_KienTruc.QLTTKT.QLTTKT frm = new QLHTDT.FormPhanHe.QuyHoach_KienTruc.QLTTKT.QLTTKT(); frm.Show(); }
            if (comboBox1.Text == "Hồ sơ cấp phép xây dựng")
            { QLHTDT.FormPhu.QLKienTruc.CapPhepXD frm = new QLHTDT.FormPhu.QLKienTruc.CapPhepXD(); frm.Show(); }
            if (comboBox1.Text == "Hồ sơ xác nhận quy hoạch")
            { QLHTDT.FormPhu.QLQH.QLCapCCQH frm = new QLHTDT.FormPhu.QLQH.QLCapCCQH(); frm.Show(); }
        }

        private void TraCuu_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Thông tin thửa đất");
            comboBox1.Items.Add("Đường giao thông chính");
            comboBox1.Items.Add("Đường kiệt hẻm");
            comboBox1.Items.Add("Tuyến điện chiếu sáng chính");
            comboBox1.Items.Add("Tuyến điện chiếu sáng kiệt hẻm");
            comboBox1.Items.Add("Trụ đèn chiếu sáng chính");
            comboBox1.Items.Add("Trụ đèn chiếu sáng kiệt hẻm");
            comboBox1.Items.Add("Cây xanh");
            comboBox1.Items.Add("Mương thoát nước");
            comboBox1.Items.Add("Điều lệ quản lý kiến trúc");
            comboBox1.Items.Add("Thông tin khu quy hoạch");
            comboBox1.Items.Add("Hồ sơ xác nhận quy hoạch");
            comboBox1.Items.Add("Hồ sơ cấp phép xây dựng");
        }
    }
}
