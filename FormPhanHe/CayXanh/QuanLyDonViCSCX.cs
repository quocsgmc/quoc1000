using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using QLHTDT.FormChinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.CayXanh
{
    public partial class QuanLyDonViChamSoc : Form
    {
        private ESRI.ArcGIS.Carto.IMap dmap;
        bool ChinhSua = false;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public static int IDThietBi;
        int IDDVCS;
        //string sql = "select a.OBJECTID,a.DiaChi,b.TENLOAITRAM,c.TENCHUDATU,d.TenPhuong,e.TENHUYEN from TRAMCayXanh a,LOAITRAMCayXanh b,CHUDAUTUCayXanh c,PhuongXa d,QuanHuyen e where a.IDChuDauTu = c.IDCHUDAUTU and a.IDLoaiTram = b.IDLOAITRAM and a.MaXa = d.MaPhuong and e.MAHUYEN = a.MaHuyen";
        string sql = "[PRC_QUERYTABLE_DonViCSCX]";
        public QuanLyDonViChamSoc()
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map;
            GridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);
        }
        void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!GridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, GridView1); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, GridView1); }));
            }
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void QuanLyDonViChamSoc_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            bindingNavigator1.Visible = false;
            showgridControl1();
            if (QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 2 || QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 3)
            {
                btChinhSua.Enabled = false;
                btThemMoi.Enabled = false;
                btXoa.Enabled = false;
            }
        }
        void showgridControl1()
        {
            tb = new DataTable();SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.Fill(ds);
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["MaDonVi"].ToString();
                if (!comboMaDonVi.Items.Contains(val))
                {
                    comboMaDonVi.Items.Add(val);
                }
            }
        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa dữ liệu được chọn " + " không?", "Xóa dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDDVCSCX").ToString(), out IDDVCS);
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string Delelequery = "[PRC_DELETE_DonViCSCX] " + IDDVCS + "";
                    SqlCommand cmd1 = new SqlCommand(Delelequery, conn);
                    cmd1.ExecuteNonQuery();
                    showgridControl1();
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo");
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn dữ liệu cần xóa", "Thông báo");
                }
            }
        }
        private void BtTracuu_Click(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["TenDonVi"],
               new ColumnFilterInfo("[TenDonVi] like '%" + txtTenDonVi.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["MaDonVi"],
               new ColumnFilterInfo("[MaDonVi] like '%" + comboMaDonVi.Text + "%'", ""));
        }
        public void ChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDDVCSCX").ToString(), out IDThietBi);
                QLHTDT.FormPhanHe.CayXanh.ChinhSuaDonViCSCX frm = new QLHTDT.FormPhanHe.CayXanh.ChinhSuaDonViCSCX();
                frm.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn thiết bị chỉnh sửa.","Thông báo");
            }


        }
       
        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            txtTenDonVi.ResetText();
            comboMaDonVi.ResetText();
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn lưu các dữ liệu thay đổi " + " không? Nếu có ấn nút Yes, không thì ấn nút No", "Lưu dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GridView1.MoveNext();
                GridView1.MovePrev();
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);
                bindingSource1.EndEdit();
                DataTable dt = (DataTable)bindingSource1.DataSource;
                dataAdapter1.Update(dt);
            }
        }

        private void txtIDLoaiTram_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["TenDonVi"],
              new ColumnFilterInfo("[TenDonVi] like '%" + txtTenDonVi.Text + "%'", ""));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhanHe.CayXanh.ThemMoiDonViCSCX frm = new QLHTDT.FormPhanHe.CayXanh.ThemMoiDonViCSCX();
            frm.Show();
            this.Close();
            Cursor = Cursors.Default;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["MaDonVi"],
               new ColumnFilterInfo("[MaDonVi] like '%" + comboMaDonVi.Text + "%'", ""));
        }

        private void GridView1_Click(object sender, EventArgs e)
        {
            if (int.Parse(GridView1.FocusedRowHandle.ToString()) >= 0)
            {
                //txtTenThietBi.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenThietBi").ToString();
                //txtGhiChu.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "GhiChu").ToString();
                //comboLoaiThietrBi.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MoTa").ToString();
            }
        }
    }
}
