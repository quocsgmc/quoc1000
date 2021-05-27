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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.CayXanh.QuanLyThamCo
{
    public partial class QuanLyThamCo : Form
    {
        private ESRI.ArcGIS.Carto.IMap dmap;
        bool ChinhSua = false;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public static int IDTram;
        int AddQuan = 0;
        public static string MaHuyen = "null";
        //string sql = "select a.OBJECTID,a.DiaChi,b.TENLOAITRAM,c.TENCHUDATU,d.TenPhuong,e.TENHUYEN from TRAMCayXanh a,LOAITRAMCayXanh b,CHUDAUTUCayXanh c,PhuongXa d,QuanHuyen e where a.IDChuDauTu = c.IDCHUDAUTU and a.IDLoaiTram = b.IDLOAITRAM and a.MaXa = d.MaPhuong and e.MAHUYEN = a.MaHuyen";
        string sql = "PRC_QUERYTABLEThamCo";
        public static int ID1;
        string sql1 = "[PRC_QUERYThamCo_BY_ID] " + ID1 + "";
        public QuanLyThamCo()
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

        private void QuanLyThamCo_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            bindingNavigator1.Visible = false;
            showgridControl1();
            if (ID1 != 0)
            {
                showgridControl2(sql1);
            }
            if (QLHTDT.Properties.Settings.Default.QuyenSuaDT == true) { button1.Visible = true; } else { button1.Visible = false; }
            bool ChinhSua = false;
            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            DataSet ds2 = new DataSet();
            SqlDataAdapter adp2 = new SqlDataAdapter("[PRC_QUERY_DUONGCHINH]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp2.Fill(ds2);
            comboTenDuong.Items.Add("");
            for (int intCount = 0; intCount < ds2.Tables[0].Rows.Count; intCount++)
            {
                var val = ds2.Tables[0].Rows[intCount]["TenDuong"].ToString();

                if (!comboTenDuong.Items.Contains(val))
                {
                    comboTenDuong.Items.Add(val);
                }
            }
            DataSet ds3 = new DataSet();
            SqlDataAdapter adp3 = new SqlDataAdapter("[PRC_QUERYTABLE_CONGVIEN]", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp3.Fill(ds3);
            for (int intCount = 0; intCount < ds3.Tables[0].Rows.Count; intCount++)
            {
                var val = ds3.Tables[0].Rows[intCount]["TenCongVien"].ToString();
                if (!comboCongVien.Items.Contains(val))
                {
                    comboCongVien.Items.Add(val);
                }
            }

            if (QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 2 || QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 3)
            {
                btChinhSua.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
                button7.Enabled = false;
            }
        }
        void showgridControl1()
        {
            tb = new DataTable();SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;

         
        }
        void showgridControl2(string sql1)
        {
            tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql1, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource2.DataSource = tb;

        }
        private void BtExcell_Click(object sender, EventArgs e)
        {
            SaveFileDialog openf = new SaveFileDialog();
            openf.Filter = "xls|*.xls";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                GridView1.ExportToXls(openf.FileName);
            }
        }
        private void BtTracuu_Click(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["QuanHuyen"],
              new ColumnFilterInfo("[QuanHuyen] like '%" + comboQuan.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["TenPhuong"],
              new ColumnFilterInfo("[TenPhuong] like '%" + comboPhuong.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["MaThamCo"],
               new ColumnFilterInfo("[MaThamCo] like '%" + txtCX.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["TenChungLoaiCay"],
               new ColumnFilterInfo("[TenChungLoaiCay] like '%" + comboLoaiCay.Text + "%'", ""));
        }
        public void ChinhSua_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (int.Parse(GridView1.FocusedRowHandle.ToString()) >= 0)
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID1);
                QLHTDT.FormPhanHe.CayXanh.QLThamCo.ChinhSuaThamCo frm = new QLHTDT.FormPhanHe.CayXanh.QLThamCo.ChinhSuaThamCo();
                frm.Show();
            }
            Cursor = Cursors.Default;
        }
        private void DoRowDoubleClick(GridView view, System.Drawing.Point pt)
        {
            Cursor = Cursors.WaitCursor;
            int KTMoLop = 0;
            string PhuongKT = null;
            try
            {

                for (int i1 = 0; i1 < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i1++)
                {
                    if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == "Thảm cỏ")
                    {
                        IFeatureLayer ilayer1 = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1) as IFeatureLayer;
                        KTMoLop = KTMoLop + 1;
                        int ID;
                        int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                        if (ID == 0)
                        {
                            Cursor = Cursors.WaitCursor;
                            MessageBox.Show("Không có dữ liệu không gian Thảm cỏ này", "Thông báo");
                        }
                        else
                        {
                            IFeature ife = ilayer1.FeatureClass.GetFeature(ID);
                            if (ife != null)
                            {
                                QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, dmap, ilayer1);
                                IActiveView ActiveView = dmap as IActiveView;
                                IActiveView map = QLHTDT.FormChinh.KienTruc.axMapControl1.Map as IActiveView;
                                ICommand command = new ControlsZoomToSelectedCommand();
                                command.OnCreate(QLHTDT.FormChinh.KienTruc.axMapControl1.Object);
                                QLHTDT.FormChinh.KienTruc.axMapControl1.CurrentTool = command as ITool;
                                command.OnClick();
                                dmap.MapScale = 500;
                                ActiveView.Refresh();
                                Cursor = Cursors.Default;
                            }
                        }
                    }
                }
                if (KTMoLop == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa mở lớp dữ liệu không gian Thảm cỏ \n" + "Có muốn mở lớp dữ liệu này hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Quản lý cây xanh\\Thảm cỏ.lyr");
                        QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        for (int i = 0; i < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i).Name == "Thảm cỏ")
                            {
                                KTMoLop = KTMoLop + 1;
                                IFeatureLayer ilayer = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i) as IFeatureLayer;
                                int ID;
                                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Thảm cỏ", "Thông báo"); }
                                else
                                {
                                    IFeature ife = ilayer.FeatureClass.GetFeature(ID);
                                    if (ife != null)
                                    {
                                        QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, dmap, ilayer);
                                        IActiveView ActiveView = dmap as IActiveView;
                                        IActiveView map = QLHTDT.FormChinh.KienTruc.axMapControl1.Map as IActiveView;
                                        ICommand command = new ControlsZoomToSelectedCommand();
                                        command.OnCreate(QLHTDT.FormChinh.KienTruc.axMapControl1.Object);
                                        QLHTDT.FormChinh.KienTruc.axMapControl1.CurrentTool = command as ITool;
                                        command.OnClick();
                                        dmap.MapScale = 500;
                                        ActiveView.Refresh();
                                        Cursor = Cursors.Default;
                                    }
                                }
                            }
                        }
                    }
                    //MessageBox.Show("Chưa mở lớp dữ liệu không gian phường " + PhuongKT); 
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void GridView1_DoubleClick(object sender, EventArgs e)
        {

            GridView view = (GridView)sender;
            System.Drawing.Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            DoRowDoubleClick(view, pt);
        }

        private void comboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
            comboPhuong.ResetText();
            ColumnView view = GridView1;

            if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                comboQuan.Text = "";
            }
            if (AddQuan == 1)
            {
                view.ActiveFilter.Add(view.Columns["TenQuan"],
                    new ColumnFilterInfo("[TenQuan] like '%" + comboQuan.Text + "%'", ""));
                MaHuyen = comboQuan.SelectedValue.ToString();
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + " ";
                DataSet ds2 = new DataSet();
                SqlDataAdapter adp2 = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                adp2.Fill(ds2);
                comboPhuong.Items.Clear();
                comboPhuong.Items.Add("");
                for (int intCount = 0; intCount < ds2.Tables[0].Rows.Count; intCount++)
                {
                    var val = ds2.Tables[0].Rows[intCount]["TenPhuong"].ToString();

                    if (!comboQuan.Items.Contains(val))
                    {
                        comboPhuong.Items.Add(val);
                    }
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["TenPhuong"],
              new ColumnFilterInfo("[TenPhuong] like '%" + comboPhuong.Text + "%'", ""));
        }
        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            txtCX.ResetText();
            combobox1.Text = "Tất cả";
            comboLoaiCay.ResetText();
            comboQuan.ResetText();
            comboPhuong.ResetText();
            comboTenDuong.ResetText();
            showgridControl1();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
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

        private void txtMaTram_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["STT"],
              new ColumnFilterInfo("[STT] like '%" + txtCX.Text + "%'", ""));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhanHe.CayXanh.QLCayXanh.NhatKyCSCayXanh.NhatKyCSCayXanh frm = new QLHTDT.FormPhanHe.CayXanh.QLCayXanh.NhatKyCSCayXanh.NhatKyCSCayXanh();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //QLHTDT.FormPhanHe.CayXanh.QLCayXanh.ThemMoiMotCayXanh frm = new QLHTDT.FormPhanHe.CayXanh.QLCayXanh.ThemMoiMotCayXanh();
            //frm.Show();
            Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhanHe.CayXanh.QLCayXanh.ThemMoiTuExcel frm = new QLHTDT.FormPhanHe.CayXanh.QLCayXanh.ThemMoiTuExcel();
            frm.Show();
            Cursor = Cursors.Default;
        }
        int ID;
        private void button4_Click(object sender, EventArgs e)
        {
            if (MoRong == 0)
            {
                this.ClientSize = new System.Drawing.Size(440, 795);
                MoRong = 1;
                this.button6.Image = global::QLHTDT.Properties.Resources.MuiTen2;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(760, 795);
                MoRong = 0;
                this.button6.Image = global::QLHTDT.Properties.Resources.MuiTen;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["TenDuong"],
               new ColumnFilterInfo("[TenDuong] like '%" + comboTenDuong.Text + "%'", ""));
        }
        int MoRong = 1;
        private void button5_Click(object sender, EventArgs e)
        {
            if (MoRong == 0)
            {
                this.ClientSize = new System.Drawing.Size(440, 795);
                MoRong = 1;
                this.button6.Image = global::QLHTDT.Properties.Resources.MuiTen2;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(760, 795);
                MoRong = 0;
                this.button6.Image = global::QLHTDT.Properties.Resources.MuiTen;
            }
        }
        private void GridView1_Click(object sender, EventArgs e)
        {
            if (int.Parse(GridView1.FocusedRowHandle.ToString()) >= 0)
            {
                try
                {
                    int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID1);
                    sql1 = "[PRC_QUERYThamCo_BY_ID] " + ID1 + "";
                    showgridControl2(sql1);
                    return;
                }
                catch
                {
                    MessageBox.Show("Không có dữ liệu, vui lòng chọn lại", "Thông báo");
                }
            }
        }

        private void comboLoaiCay_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["TenChungLoaiCay"],
               new ColumnFilterInfo("[TenChungLoaiCay] like '%" + comboLoaiCay.Text + "%'", ""));

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (combobox1.Text)
            {
                case "Tất cả":
                    sql = "PRC_QUERYTABLEThamCo";
                    gridColumn1.Visible = false;//Tên đường
                    gridColumn19.Visible = false; //Tên công viên
                    labelCongVien.Visible = false;
                    comboCongVien.Visible = false;
                    labelTenDuong.Visible = false;
                    comboTenDuong.Visible = false;

                    //gridColumn2.Width =  //Tên công viên
                    gridColumn2.Width = 67; //Quận hyện
                    gridColumn3.Width = 112;//Phường/Xã
                    gridColumn4.Width = 84;//Mã thảm cỏ
                    //gridColumn24.Width = //Tên đường
                    gridColumn7.Width = 124; //Chủng loại
                
                    break;
                case "Đường phố":
                    sql = ""; //query where Đường phố
                    gridColumn1.Visible = true;//Tên đường
                    gridColumn19.Visible = false; //Tên công viên
                    labelCongVien.Visible = false;
                    comboCongVien.Visible = false;
                    labelTenDuong.Visible = false;
                    comboTenDuong.Visible = true;

                    //gridColumn2.Width = 80; //Tên công viên
                    gridColumn2.Width = 70; //Quận hyện
                    gridColumn3.Width = 76;//Phường/Xã
                    gridColumn4.Width = 70;//Mã thảm cỏ
                    gridColumn1.Width = 80;//Tên đường
                    gridColumn7.Width = 70; //Chủng loại
                    break;
                case "Công viên":
                    sql = ""; //query where Công viên
                    gridColumn1.Visible = false;//Tên đường
                    gridColumn19.Visible = true; //Tên công viên
                    labelCongVien.Visible = false;
                    comboCongVien.Visible = true;
                    labelTenDuong.Visible = false;
                    comboTenDuong.Visible = false;

                    gridColumn2.Width = 80; //Tên công viên
                    gridColumn2.Width = 70; //Quận hyện
                    gridColumn3.Width = 76;//Phường/Xã
                    gridColumn4.Width = 70;//Mã thảm cỏ
                    //gridColumn1.Width = 80;//Tên đường
                    gridColumn7.Width = 70; //Chủng loại
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa Thảm cỏ được chọn " + " không?", "Xóa dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID1);
                try
                {
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string Delelequery = "[PRC_DELETE_THAMCO_BY_ID] " + ID1 + "";
                    SqlCommand cmd1 = new SqlCommand(Delelequery, conn);
                    cmd1.ExecuteNonQuery();
                    GridView1.ClearColumnsFilter();
                    GridView1.RefreshData();
                    MessageBox.Show("Xóa Thảm cỏ thành công", "Thông báo");
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn Thảm cỏ cần xóa", "Thông báo");
                }
            }
        }

        private void comboCongVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["TenCongVien"],
               new ColumnFilterInfo("[TenCongVien] like '%" + comboLoaiCay.Text + "%'", ""));
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                //string DinhKemQuan = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "QuanHuyen").ToString();
                //string DinhKemPhuong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenPhuong").ToString();
                //string path = Properties.Settings.Default.PathData + "\\Bưu chính - Viễn thông" + "\\" + DinhKemQuan + "\\" + DinhKemPhuong + "\\" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString();
                string path = Properties.Settings.Default.PathData + "\\Quản lý cây xanh\\Thảm cỏ" + "\\" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaThamCo").ToString();
                if (Directory.Exists(path))
                {
                    QLHTDT.FormPhanHe.BuuChinh_VienThong.FileDinhKem frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.FileDinhKem(path);
                    frm.Show();
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa có dữ liệu file đính kèm, Có cập nhật dữ liệu hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Directory.CreateDirectory(path);
                        System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                        openFileDialog.InitialDirectory = @"C:\";
                        openFileDialog.Filter = "All file (*.*)|*.*";
                        openFileDialog.FilterIndex = 2;
                        openFileDialog.RestoreDirectory = true;
                        openFileDialog.Multiselect = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Chưa chọn Thảm cỏ cần đính kèm file. Vui lòng thử lại", "Thông báo");
            }
        }
    }
}
