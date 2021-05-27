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
using QLHTDT.FormPhu.KhoangSan;
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

namespace QLHTDT.FormPhanHe.KhoangSan.HoatDongKhaiThacKhoanSan2
{
    public partial class HoatDongKhaiThacKhoanSan2 : Form
    {
        private ESRI.ArcGIS.Carto.IMap dmap;
        int AddQuan = 0;
        bool ChinhSua = false;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        SqlDataAdapter dataAdapter2;
        SqlCommandBuilder cmbl1;
        public static int IDTram;
        public static int ID1 ;

        public static string MaHuyen = "null";
        string sql1 = "PRC_QUERY_HoatDongKhaiThacKS_BY_ID " + ID1 + "";
        public HoatDongKhaiThacKhoanSan2()
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

        private void HoatDongKhaiThacKhoanSan2_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;
            cardView1.OptionsBehavior.Editable = false;
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            bindingNavigator1.Visible = false;
            showgridControl1();
            if (ID1 != 0)
            {
                showgridControl2(sql1);
            }
            if (QLHTDT.Properties.Settings.Default.QuyenSuaDT == true) { button1.Visible = true; } else { button1.Visible = false; }

            if (QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 2 || QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 3)
            {
                btChinhSua.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button1.Enabled = false;
            }

        }
        void showgridControl1()
        {
            tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand("PRC_QUERY_HoatDongKhaiThacKS", connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;

            SqlDataAdapter adp = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboQuan.DataSource = ds.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";


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
            view.ActiveFilter.Add(view.Columns["Quan"],
              new ColumnFilterInfo("[Quan] like '%" + comboQuan.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["Phuong"],
              new ColumnFilterInfo("[Phuong] like '%" + comboPhuong.Text + "%'", ""));
        }
        public void ChinhSua_Click(object sender, EventArgs e)
        {
            if (btChinhSua.Text == "Chỉnh sửa           ")
            {
                //GridView1.ClearColumnsFilter();
                //GridView1.RefreshData();
                MessageBox.Show("Vui lòng chọn dữ liệu cần chỉnh sửa", "Thông báo");
                GridView1.OptionsBehavior.Editable = true;
                cardView1.OptionsBehavior.Editable = true;
                bindingNavigator1.Visible = true;
                btChinhSua.Text = "Tắt            ";
                ChinhSua = false;

            }
            else
            {
                bindingSource1.ResetBindings(true); //(Cái này để reset gribview)
                //DataTable table = (DataTable)bindingSource1.DataSource;
                btChinhSua.Text = "Chỉnh sửa           ";
                bindingNavigator1.Visible = false;
                GridView1.OptionsBehavior.Editable = false;
                cardView1.OptionsBehavior.Editable = false;
                tb = new DataTable();
                string sql = "select * from [HoatDongKhaiThac]";
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);
                dataAdapter1.Fill(tb);
                this.bindingSource1.DataSource = tb;
                this.bindingSource2.DataSource = tb;
                //GridView1.ClearColumnsFilter();
                //GridView1.RefreshData();
            }
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
                    if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == "Hoạt động khai thác khoáng sản")
                    {
                        IFeatureLayer ilayer1 = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1) as IFeatureLayer;
                        KTMoLop = KTMoLop + 1;
                        int ID;
                        int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                        if (ID == 0)
                        {
                            Cursor = Cursors.WaitCursor;
                            MessageBox.Show("Không có dữ liệu không gian Hoạt động khai thác khoáng sản này", "Thông báo");
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
                                QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale * 2;
                                ActiveView.Refresh();
                                Cursor = Cursors.Default;
                            }
                        }
                    }
                }
                if (KTMoLop == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa mở lớp dữ liệu không gian Hoạt động khai thác khoáng sản \n" + "Có muốn mở lớp dữ liệu này hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Quản lý tài nguyên khoáng sản\\Hoạt động khai thác khoáng sản.lyr");
                        QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        for (int i = 0; i < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i).Name == "Hoạt động khai thác khoáng sản")
                            {
                                KTMoLop = KTMoLop + 1;
                                IFeatureLayer ilayer = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i) as IFeatureLayer;
                                int ID;
                                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Hoạt động khai thác khoáng sản", "Thông báo"); }
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
                                        QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale * 2;
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
                view.ActiveFilter.Add(view.Columns["QuanHuyen"],
                    new ColumnFilterInfo("[QuanHuyen] like '%" + comboQuan.Text + "%'", ""));
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
            comboQuan.ResetText();
            comboPhuong.ResetText();
            txtTenMo.ResetText();
            txtTenToChuc.ResetText();
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                GridView1.MoveNext();
                GridView1.MovePrev();
                cardView1.MoveNext();
                cardView1.MovePrev();

                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand("SELECT [SoGiayPhep],[TenToChuc],[TenMo],[DienTich],[Quan],[Phuong],[TruLuongKhaiThac],[CongSuatKhaiThac],[LoaiKhoangSan],[ThoiHanKhaiThac],[LyDoDongCuaMo],[ThoiGianDongCuaMo],[TruLuongConLai],[TruLuongCapPhep],[ThoiGianGiaHan],[TinhTrang],[CosCaoKTKT],[TruLuongKhaiThacHangNam],[ChieuDayKhaiThac],[MucDichSDKS],[TruLuongThamDo],[DienTichTiepTucKhaiThac],[LyDoXinGiaHan],[TGTHDeAnDongCuaMo],[ThoiHanGPTD],[GhiChu],[MucDichDongCuaMo],[ViPhamXuPhat],[OBJECTID] FROM [HOATDONGKHAITHAC]", connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);
                bindingSource1.EndEdit();
                DataTable dt = (DataTable)bindingSource1.DataSource;
                dataAdapter1.Update(dt);

                SqlConnection connection1 = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter2 = new SqlDataAdapter(new SqlCommand("SELECT [SoGiayPhep],[TenToChuc],[TenMo],[DienTich],[Quan],[Phuong],[TruLuongKhaiThac],[CongSuatKhaiThac],[LoaiKhoangSan],[ThoiHanKhaiThac],[LyDoDongCuaMo],[ThoiGianDongCuaMo],[TruLuongConLai],[TruLuongCapPhep],[ThoiGianGiaHan],[TinhTrang],[CosCaoKTKT],[TruLuongKhaiThacHangNam],[ChieuDayKhaiThac],[MucDichSDKS],[TruLuongThamDo],[DienTichTiepTucKhaiThac],[LyDoXinGiaHan],[TGTHDeAnDongCuaMo],[ThoiHanGPTD],[GhiChu],[MucDichDongCuaMo],[ViPhamXuPhat],[OBJECTID] FROM [HOATDONGKHAITHAC]", connection1));
                cmbl1 = new SqlCommandBuilder(dataAdapter2);
                bindingSource2.EndEdit();
                DataTable dt1 = (DataTable)bindingSource2.DataSource;
                dataAdapter2.Update(dt1);

                MessageBox.Show("Lưu dữ liệu thay đổi thành công", "Thông báo");
            }
            catch
            {

                MessageBox.Show("Lưu dữ liệu thay đổi thất bại /n vui lòng kiểm tra lại dữ liệu", "Thông báo");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //string DinhKemQuan = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "QuanHuyen").ToString();
                //string DinhKemPhuong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenPhuong").ToString();
                //string path = Properties.Settings.Default.PathData + "\\Bưu chính - Viễn thông" + "\\" + DinhKemQuan + "\\" + DinhKemPhuong + "\\" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString();
                string path = Properties.Settings.Default.PathData + "\\Dữ liệu quy hoạch khoáng sản\\Hồ sơ dữ liệu quy hoạch khoáng sản\\" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString();
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
                MessageBox.Show("Chưa chọn Quy hoạch cần đính kèm file. Vui lòng thử lại", "Thông báo");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MoRong == 0)
            {
                this.ClientSize = new System.Drawing.Size(440, 790);
                MoRong = 1;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen2;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(765, 790);
                MoRong = 0;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen;
            }
        }

        int MoRong = 1;
        private void button5_Click(object sender, EventArgs e)
        {
            if(MoRong == 0)
            {
                this.ClientSize = new System.Drawing.Size(440, 790);
                MoRong = 1;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen2;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(765, 790);
                MoRong = 0;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen;
            }
        }
        private void GridView1_Click(object sender, EventArgs e)
        {
            if (int.Parse(GridView1.FocusedRowHandle.ToString()) >= 0)
            {
                try
                {
                    int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID1);
                    sql1 = "PRC_QUERY_HoatDongKhaiThacKS_BY_ID " + ID1 + "";
                    showgridControl2(sql1);
                }
                catch
                {
                    MessageBox.Show("Không có dữ liệu, vui lòng chọn lại", "Thông báo");
                }
            }
        }

        private void comboQuan_SelectedValueChanged(object sender, EventArgs e)
        {

        }



        private void cboLoaiKhaiThac_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = cardView1;
            ColumnView view1 = GridView1;
            switch (cboLoaiKhaiThac.Text)
            {
                case "Mỏ xin giấy phép thăm dò":
                    ColTruLuongKhaiThac.Visible = false;
                    ColCongSuatKhaiThac.Visible = false;
                    ColLoaiKhoangSan.Visible = true;//đây
                    ColThoiHanKhaiThac.Visible = false;
                    ColLyDoDongCuaMo.Visible = false;
                    ColThoiGianDongCuaMo.Visible = false;
                    ColTruLuongConLai.Visible = false;
                    ColTruLuongCapPhep.Visible = false;
                    ColThoiGianGiaHan.Visible = false;
                    ColCosCaoKTKT.Visible = false;

                    ColChieuDayKhaiThac.Visible = false;
                    ColMucDichSDKS.Visible = true;//đây
                    ColDienTichTiepTucKhaiThac.Visible = false;
                    ColLyDoXinGiaHan.Visible = false;
                    ColTGTHDeAnDongCuaMo.Visible = false;
                    ColThoiHanGPTD.Visible = false;
                    ColTruLuongThamDo.Visible = true;//đây
                    ColMucDichDongCuaMo.Visible = false;
                    ColDienTichDongCuaMo.Visible = false;
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                    new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ xin giấy phép thăm dò" + "%'", ""));
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                    new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ xin giấy phép thăm dò" + "%'", ""));
                    break;
                case "Mỏ đã cấp phép thăm dò":
                    ColTruLuongKhaiThac.Visible = false;
                    ColCongSuatKhaiThac.Visible = false;
                    ColLoaiKhoangSan.Visible = true;//đây
                    ColThoiHanKhaiThac.Visible = false;
                    ColLyDoDongCuaMo.Visible = false;
                    ColThoiGianDongCuaMo.Visible = false;
                    ColTruLuongConLai.Visible = false;
                    ColTruLuongCapPhep.Visible = false;
                    ColThoiGianGiaHan.Visible = false;
                    ColCosCaoKTKT.Visible = false;

                    ColChieuDayKhaiThac.Visible = false;
                    ColMucDichSDKS.Visible = true;//đây
                    ColDienTichTiepTucKhaiThac.Visible = false;
                    ColLyDoXinGiaHan.Visible = false;
                    ColTGTHDeAnDongCuaMo.Visible = true;//đây
                    ColThoiHanGPTD.Visible = true;//đây
                    ColTruLuongThamDo.Visible = true;//đây
                    ColMucDichDongCuaMo.Visible = false;
                    ColDienTichDongCuaMo.Visible = false;
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                    new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ đã cấp phép thăm dò" + "%'", ""));
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                    new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ đã cấp phép thăm dò" + "%'", ""));
                    break;
                case "Mỏ xin cấp phép khai thác":
                    ColTruLuongKhaiThac.Visible = true;//đây
                    ColCongSuatKhaiThac.Visible = true;//đây
                    ColLoaiKhoangSan.Visible = true;//đây
                    ColThoiHanKhaiThac.Visible = false;
                    ColLyDoDongCuaMo.Visible = false;
                    ColThoiGianDongCuaMo.Visible = false;
                    ColTruLuongConLai.Visible = false;
                    ColTruLuongCapPhep.Visible = true;//đây
                    ColThoiGianGiaHan.Visible = false;
                    ColCosCaoKTKT.Visible = true;//đây

                    ColChieuDayKhaiThac.Visible = false;
                    ColMucDichSDKS.Visible = true;//đây
                    ColDienTichTiepTucKhaiThac.Visible = false;
                    ColLyDoXinGiaHan.Visible = false;
                    ColTGTHDeAnDongCuaMo.Visible = false;
                    ColThoiHanGPTD.Visible = false;
                    ColTruLuongThamDo.Visible = false;
                    ColMucDichDongCuaMo.Visible = false;
                    ColDienTichDongCuaMo.Visible = false;
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                    new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ xin cấp phép khai thác" + "%'", ""));
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                    new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ xin cấp phép khai thác" + "%'", ""));
                    break;
                case "Mỏ còn hiệu lực khai thác":
                    ColTruLuongKhaiThac.Visible = true;//đây
                    ColCongSuatKhaiThac.Visible = true;//đây
                    ColLoaiKhoangSan.Visible = true;//đây
                    ColThoiHanKhaiThac.Visible = true;//đây
                    ColLyDoDongCuaMo.Visible = false;
                    ColThoiGianDongCuaMo.Visible = false;
                    ColTruLuongConLai.Visible = true;//đây
                    ColTruLuongCapPhep.Visible = true;//đây
                    ColThoiGianGiaHan.Visible = false;
                    ColCosCaoKTKT.Visible = true;//đây

                    ColChieuDayKhaiThac.Visible = true;//đây
                    ColMucDichSDKS.Visible = true;//đây
                    ColDienTichTiepTucKhaiThac.Visible = false;
                    ColLyDoXinGiaHan.Visible = false;
                    ColTGTHDeAnDongCuaMo.Visible = false;
                    ColThoiHanGPTD.Visible = false;
                    ColTruLuongThamDo.Visible = false;
                    ColMucDichDongCuaMo.Visible = false;
                    ColDienTichDongCuaMo.Visible = false;
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                    new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ còn hiệu lực khai thác" + "%'", ""));
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                    new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ còn hiệu lực khai thác" + "%'", ""));
                    break;
                case "Mỏ đã hết hạn khai thác":
                    ColTruLuongKhaiThac.Visible = true;//đây
                    ColCongSuatKhaiThac.Visible = true;//đây
                    ColLoaiKhoangSan.Visible = true;//đây
                    ColThoiHanKhaiThac.Visible = true;//đây
                    ColLyDoDongCuaMo.Visible = false;
                    ColThoiGianDongCuaMo.Visible = false;
                    ColTruLuongConLai.Visible = true;//đây
                    ColTruLuongCapPhep.Visible = true;//đây
                    ColThoiGianGiaHan.Visible = false;
                    ColCosCaoKTKT.Visible = true;//đây

                    ColChieuDayKhaiThac.Visible = false;
                    ColMucDichSDKS.Visible = true;//đây
                    ColDienTichTiepTucKhaiThac.Visible = false;
                    ColLyDoXinGiaHan.Visible = false;
                    ColTGTHDeAnDongCuaMo.Visible = false;
                    ColThoiHanGPTD.Visible = false;
                    ColTruLuongThamDo.Visible = false;
                    ColMucDichDongCuaMo.Visible = false;
                    ColDienTichDongCuaMo.Visible = false;
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                    new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ đã hết hạn khai thác" + "%'", ""));
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                    new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ đã hết hạn khai thác" + "%'", ""));
                    break;
                case "Mỏ đang gia hạn giấy phép khai thác":
                    ColTruLuongKhaiThac.Visible = false;
                    ColCongSuatKhaiThac.Visible = true;//đây
                    ColLoaiKhoangSan.Visible = true;//đây
                    ColThoiHanKhaiThac.Visible = true;//đây
                    ColLyDoDongCuaMo.Visible = false;
                    ColThoiGianDongCuaMo.Visible = false;
                    ColTruLuongConLai.Visible = true;//đây
                    ColTruLuongCapPhep.Visible = false;
                    ColThoiGianGiaHan.Visible = true;//đây
                    ColCosCaoKTKT.Visible = false;

                    ColChieuDayKhaiThac.Visible = false;
                    ColMucDichSDKS.Visible = false;
                    ColDienTichTiepTucKhaiThac.Visible = true;//đây
                    ColLyDoXinGiaHan.Visible = true;//đây
                    ColTGTHDeAnDongCuaMo.Visible = false;
                    ColThoiHanGPTD.Visible = false;
                    ColTruLuongThamDo.Visible = false;
                    ColMucDichDongCuaMo.Visible = false;
                    ColDienTichDongCuaMo.Visible = false;
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                     new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ đang gia hạn giấy phép khai thác" + "%'", ""));
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                     new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ đang gia hạn giấy phép khai thác" + "%'", ""));
                    break;
                case "Mỏ đang lập thủ tục đóng cửa mỏ":
                    ColTruLuongKhaiThac.Visible = false;
                    ColCongSuatKhaiThac.Visible = false;
                    ColLoaiKhoangSan.Visible = true;//đây
                    ColThoiHanKhaiThac.Visible = false;
                    ColLyDoDongCuaMo.Visible = false;
                    ColThoiGianDongCuaMo.Visible = false;
                    ColTruLuongConLai.Visible = false;
                    ColTruLuongCapPhep.Visible = false;
                    ColThoiGianGiaHan.Visible = false;
                    ColCosCaoKTKT.Visible = false;

                    ColChieuDayKhaiThac.Visible = false;
                    ColMucDichSDKS.Visible = false;
                    ColDienTichTiepTucKhaiThac.Visible = false;
                    ColLyDoXinGiaHan.Visible = false;
                    ColTGTHDeAnDongCuaMo.Visible = true;
                    ColThoiHanGPTD.Visible = false;
                    ColTruLuongThamDo.Visible = false;
                    ColMucDichDongCuaMo.Visible = true;//đây
                    ColDienTichDongCuaMo.Visible = true;//đây
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                     new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ đang lập thủ tục đóng cửa mỏ" + "%'", ""));
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                     new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ đang lập thủ tục đóng cửa mỏ" + "%'", ""));
                    break;
                case "Mỏ đã đóng cửa mỏ":
                    ColTruLuongKhaiThac.Visible = false;
                    ColCongSuatKhaiThac.Visible = false;
                    ColLoaiKhoangSan.Visible = true;//đây
                    ColThoiHanKhaiThac.Visible = false;
                    ColLyDoDongCuaMo.Visible = false;
                    ColThoiGianDongCuaMo.Visible = false;
                    ColTruLuongConLai.Visible = false;
                    ColTruLuongCapPhep.Visible = false;
                    ColThoiGianGiaHan.Visible = false;
                    ColCosCaoKTKT.Visible = false;

                    ColChieuDayKhaiThac.Visible = false;
                    ColMucDichSDKS.Visible = false;
                    ColDienTichTiepTucKhaiThac.Visible = false;
                    ColLyDoXinGiaHan.Visible = false;
                    ColTGTHDeAnDongCuaMo.Visible = false;
                    ColThoiHanGPTD.Visible = false;
                    ColTruLuongThamDo.Visible = false;
                    ColMucDichDongCuaMo.Visible = true;//đây
                    ColDienTichDongCuaMo.Visible = true;//đây
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                      new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ đã đóng cửa mỏ" + "%'", ""));
                    view1.ActiveFilter.Add(view1.Columns["TinhTrang"],
                      new ColumnFilterInfo("[TinhTrang] like '%" + "Mỏ đã đóng cửa mỏ" + "%'", ""));
                    break;
                case "":
                    ColTruLuongKhaiThac.Visible = true;
                    ColCongSuatKhaiThac.Visible = true;
                    ColLoaiKhoangSan.Visible = true;
                    ColThoiHanKhaiThac.Visible = true;
                    ColLyDoDongCuaMo.Visible = true;
                    ColThoiGianDongCuaMo.Visible = true;
                    ColTruLuongConLai.Visible = true;
                    ColTruLuongCapPhep.Visible = true;
                    ColThoiGianGiaHan.Visible = true;
                    ColTinhTrang.Visible = true;
                    ColCosCaoKTKT.Visible = true;

                    ColChieuDayKhaiThac.Visible = true;
                    ColMucDichSDKS.Visible = true;
                    ColDienTichTiepTucKhaiThac.Visible = true;
                    ColLyDoXinGiaHan.Visible = true;
                    ColTGTHDeAnDongCuaMo.Visible = true;
                    ColThoiHanGPTD.Visible = true;
                    ColTruLuongThamDo.Visible = true;
                    ColMucDichDongCuaMo.Visible = true;
                    ColDienTichDongCuaMo.Visible = true;
                    break;
            }
        }
        int ID;
        private void button8_Click(object sender, EventArgs e)
        {
            int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
            Cursor = Cursors.WaitCursor;
            ToaDoMocRanh.ID2 = ID;
            QLHTDT.FormPhu.KhoangSan.ToaDoMocRanh frm = new QLHTDT.FormPhu.KhoangSan.ToaDoMocRanh();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
            Cursor = Cursors.WaitCursor;
            CongSuatKhaiThacHangNam.ID1 = ID;
            QLHTDT.FormPhu.KhoangSan.CongSuatKhaiThacHangNam frm = new QLHTDT.FormPhu.KhoangSan.CongSuatKhaiThacHangNam();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa mỏ được chọn " + " không?", "Xóa dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID1);
                try
                {
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string Delelequery = "[PRC_DELETE_HoatDongKhaiThac_BY_ID] " + ID1 + "";
                    SqlCommand cmd1 = new SqlCommand(Delelequery, conn);
                    cmd1.ExecuteNonQuery();
                    showgridControl1();
                    MessageBox.Show("Xóa mỏ thành công", "Thông báo");
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn mỏ cần xóa", "Thông báo");
                }
            }
        }
    }
}
