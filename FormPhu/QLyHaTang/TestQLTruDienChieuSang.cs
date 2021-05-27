using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
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
using QLHTDT.FormPhu.TruyVanKG;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using WindowsApplication1;

namespace QLHTDT.FormPhu.QLyHaTang
{
    public partial class TestQLTruDienChieuSang : Form
    {
        bool ChinhSua = false;
        bool ChinhSua1 = false;
        bool ChinhSua2 = false;
        string phuong;
        string phuong1;
        string phuong2;

        SqlCommandBuilder cmbl;
        SqlDataAdapter dataAdapter1;
        DataTable tb;
        DataTable tbcheck;
        private AxMapControl mMapControl;
        private ESRI.ArcGIS.Carto.IMap dmap;
        string layerget;
        string TruDien;
      
        public TestQLTruDienChieuSang()
        {
            InitializeComponent();
            dmap = QuanTriHeThong.axMapControl1.Map;
        }
        void ShowComBoBox()//Lấy dữ liệu Quận Huyện, Hiện tại lấy tạm của BTS
        {
            string sql = "SELECT [PhuongXa],[QuanHuyen] FROM  TRAMBTS";

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                var val2 = ds.Tables[0].Rows[intCount]["QuanHuyen"].ToString();
                var val3 = "";
                if (!cboPhuong.Items.Contains(val))
                {
                    cboPhuong.Items.Add(val);
                    cboPhuong2.Items.Add(val);
                    cboPhuong3.Items.Add(val);
                }
                if (!cboQuan.Items.Contains(val2))
                {
                    cboQuan.Items.Add(val2);
                    cboQuan2.Items.Add(val2);
                    cboQuan3.Items.Add(val2);
                }
                if (!cboQuan.Items.Contains(val3))
                {
                    cboQuan.Items.Add(val3);
                    cboQuan2.Items.Add(val3);
                    cboQuan3.Items.Add(val3);
                }
            }
        }
        private void TestQLTruDienChieuSang_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ShowComBoBox();
            showgridControl1();
            Cursor = Cursors.Default;
        }
        void showgridControl1()
        {
            tb = new DataTable();
            tbcheck = new DataTable();
            string sql = "SELECT [OBJECTID_1],[SoTru],[Phuong] FROM TRUDIEN_HA";
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
            this.bindingSource2.DataSource = tb;
            this.bindingSource3.DataSource = tb;
            //bingding();
        }
        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            int KTMoLop = 0;
            string PhuongKT = null;
            try
            {
                string Phuong = "";
                switch (xtraTabControl1.SelectedTabPageIndex)
                {
                    case 0: Phuong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Phuong").ToString(); break;
                    case 1: Phuong = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "Phuong").ToString(); break;
                    case 2: Phuong = bandedGridView2.GetRowCellValue(bandedGridView2.FocusedRowHandle, "Phuong").ToString(); ; break;
                }
                switch (Phuong)
                {
                    case "Hòa An": layerget = "Trụ điện chiếu sáng - HA"; break;
                    case "Hòa Phát": layerget = "Trụ điện chiếu sáng - HP"; break;
                    case "Hòa Thọ Đông": layerget = "Trụ điện chiếu sáng - HTD"; break;
                    case "Hòa Thọ Tây": layerget = "Trụ điện chiếu sáng - HTT"; break;
                    case "Hòa Xuân": layerget = "Trụ điện chiếu sáng - HX"; break;
                    case "Khuê Trung": layerget = "Trụ điện chiếu sáng - KT"; break;
                }
                PhuongKT = Phuong;
                for (int i1 = 0; i1 < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i1++)
                {
                    if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1).Name == Phuong)
                    {
                        ICompositeLayer igroup1 = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.Layer[i1] as ICompositeLayer;
                        for (int i = 0; i < igroup1.Count; i++)
                        {
                            IFeatureLayer ilayer1 = igroup1.get_Layer(i) as IFeatureLayer;
                            if (ilayer1.Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                int ID = 0;
                                switch (xtraTabControl1.SelectedTabPageIndex)
                                {
                                    case 0: int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID_1").ToString(), out ID); ; break;
                                    case 1: int.TryParse(bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "OBJECTID_1").ToString(), out ID); ; break;
                                    case 2: int.TryParse(bandedGridView2.GetRowCellValue(bandedGridView2.FocusedRowHandle, "OBJECTID_1").ToString(), out ID); ; break;
                                }
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Trụ điện này", "Thông báo"); }
                                else
                                {
                                    IFeature ife = ilayer1.FeatureClass.GetFeature(ID);
                                    if (ife != null)
                                    {
                                        QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, dmap, ilayer1);
                                        IActiveView ActiveView = dmap as IActiveView;
                                        IEnvelope pEnv = null;
                                        IActiveView map = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map as IActiveView;

                                        ICommand command = new ControlsZoomToSelectedCommand();
                                        command.OnCreate(QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Object);
                                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.CurrentTool = command as ITool;
                                        command.OnClick();
                                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale *2;
                                        ActiveView.Refresh();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;

                                IFeatureLayer ilayer = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i) as IFeatureLayer;

                                int ID = 0;
                                switch (xtraTabControl1.SelectedTabPageIndex)
                                {
                                    case 0: int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID_1").ToString(), out ID); ; break;
                                    case 1: int.TryParse(bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "OBJECTID_1").ToString(), out ID); ; break;
                                    case 2: int.TryParse(bandedGridView2.GetRowCellValue(bandedGridView2.FocusedRowHandle, "OBJECTID_1").ToString(), out ID); ; break;
                                }
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Trụ điện này", "Thông báo"); }
                                else
                                {
                                    IFeature ife = ilayer.FeatureClass.GetFeature(ID);
                                    if (ife != null)
                                    {
                                        QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, dmap, ilayer);
                                        IActiveView ActiveView = dmap as IActiveView;
                                        IEnvelope pEnv = null;
                                        IActiveView map = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map as IActiveView;

                                        ICommand command = new ControlsZoomToSelectedCommand();
                                        command.OnCreate(QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Object);
                                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.CurrentTool = command as ITool;
                                        command.OnClick();
                                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale * 2;
                                        ActiveView.Refresh();
                                    }
                                }
                            }
                        }
                    }
                }
                if (KTMoLop == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa mở lớp dữ liệu không gian Trụ điện chiếu sáng " + PhuongKT + "\n" + "Có muốn mở lớp dữ liệu này hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + layerget + ".lyr");
                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();
                        for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;

                                IFeatureLayer ilayer = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i) as IFeatureLayer;

                                int ID = 0;
                                switch (xtraTabControl1.SelectedTabPageIndex)
                                {
                                    case 0: int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID_1").ToString(), out ID); ; break;
                                    case 1: int.TryParse(bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "OBJECTID_1").ToString(), out ID); ; break;
                                    case 2: int.TryParse(bandedGridView2.GetRowCellValue(bandedGridView2.FocusedRowHandle, "OBJECTID_1").ToString(), out ID); ; break;
                                }
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Trụ điện này", "Thông báo"); }
                                else
                                {
                                    IFeature ife = ilayer.FeatureClass.GetFeature(ID);
                                    if (ife != null)
                                    {
                                        QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, dmap, ilayer);
                                        IActiveView ActiveView = dmap as IActiveView;
                                        IEnvelope pEnv = null;
                                        IActiveView map = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map as IActiveView;

                                        ICommand command = new ControlsZoomToSelectedCommand();
                                        command.OnCreate(QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Object);
                                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.CurrentTool = command as ITool;
                                        command.OnClick();
                                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale * 2;
                                        ActiveView.Refresh();

                                    }
                                }


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT [PhuongXa],[QuanHuyen] FROM  TRAMBTS";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql + " Where [QuanHuyen] = N'" + cboQuan.Text + "'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            cboPhuong.Items.Clear();
            cboPhuong.Items.Add("");
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                if (!cboPhuong.Items.Contains(val))
                {
                    cboPhuong.Items.Add(val);
                }
            }
        }
        private void cboQuan2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT [PhuongXa],[QuanHuyen] FROM  TRAMBTS";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql + " Where [QuanHuyen] = N'" + cboQuan.Text + "'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            cboPhuong.Items.Clear();
            cboPhuong.Items.Add("");
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                if (!cboPhuong.Items.Contains(val))
                {
                    cboPhuong.Items.Add(val);
                }
            }
        }
        private void cboQuan3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT [PhuongXa],[QuanHuyen] FROM  TRAMBTS";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql + " Where [QuanHuyen] = N'" + cboQuan.Text + "'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            cboPhuong.Items.Clear();
            cboPhuong.Items.Add("");
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                if (!cboPhuong.Items.Contains(val))
                {
                    cboPhuong.Items.Add(val);
                }
            }
        }
        private void LoadDataToCollection()//Gợi ý tên Đường
        {
            AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) + ";Type System Version=SQL Server 2012;");
            string sql = "Select TenDuong from DUONGCHINH_" + phuong + "";
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            com.CommandText = sql;
            com.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader reader;
            reader = com.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    auto2.Add(reader["TenDuong"].ToString());
                }
            }
            cboDuong.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboDuong.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboDuong.AutoCompleteCustomSource = auto2;

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            cboDuong.Items.Add("");
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["TenDuong"].ToString();
                if (!cboDuong.Items.Contains(val))
                {
                    cboDuong.Items.Add(val);
                }

            }
        }
        private void btChinhSua_Click(object sender, EventArgs e)
        {
            if (btChinhSua.Text == "Chỉnh sửa")
            {
                GridView1.OptionsBehavior.Editable = true;
                bindingNavigator1.Visible = true;
                btChinhSua.Text = "Tắt";
                ChinhSua = false;
            }
            else
            {
                //if (ChinhSua == true)
                //{
                //    QuanTriHeThong.TBNK = new DataTable();
                //    SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                //    QuanTriHeThong.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                //    cmbl = new SqlCommandBuilder(QuanTriHeThong.dataAdapterNK);
                //    QuanTriHeThong.dataAdapterNK.Fill(QuanTriHeThong.TBNK);
                //    QuanTriHeThong.ChinhSuathuoctinhToolQuanLy("Cây xanh" + cboPhuong.Text);
                //    QuanTriHeThong.dataAdapterNK.Update(QuanTriHeThong.TBNK);
                //}
                btChinhSua.Text = "Chỉnh sửa";
                bindingNavigator1.Visible = false;
                GridView1.OptionsBehavior.Editable = false;
                GridView1.ClearColumnsFilter();
                GridView1.RefreshData();
                ColumnView view = GridView1;
                view.ActiveFilter.Add(view.Columns["Phuong"],
             new ColumnFilterInfo("[Phuong] like '%" + cboPhuong.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["Duong"],
             new ColumnFilterInfo("[Duong] like '%" + cboDuong.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["LoaiCay"],
             new ColumnFilterInfo("[SoTru] like '%" + cboSoTru.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["MaCay"],
             new ColumnFilterInfo("[KetCau] like '%" + txtKetCau.Text + "%'", ""));
            }
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                TruDien = "TruDien_" + phuong;
                string sql = "select Phuong,Duong,LoaiCay, MaCay,TenThongThuong, DuongKinhThan, DuongKinhTan, NamTrong, DoTuoi,ToaDo,TrangThai,GhiChu,OBJECTID from " + TruDien;// Chỉnh sửa lại thuộc tính cái này
                GridView1.MoveNext();
                GridView1.MovePrev();
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);

                bindingSource1.EndEdit();
                DataTable dt = (DataTable)bindingSource1.DataSource;
                dataAdapter1.Update(dt);
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Chưa chọn thông tin Phường cần cập nhập", "Thông báo");
            }
        }
        private void cboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhuong.Text == "Hòa An") { phuong = "HA"; };
            if (cboPhuong.Text == "Hòa Phát") { phuong = "HP"; };
            if (cboPhuong.Text == "Hòa Thọ Đông") { phuong = "HTD"; };
            if (cboPhuong.Text == "Hòa Thọ Tây") { phuong = "HTT"; };
            if (cboPhuong.Text == "Hòa Xuân") { phuong = "HX"; };
            if (cboPhuong.Text == "Khuê Trung") { phuong = "KT"; };
            cboDuong.Items.Clear();
            LoadDataToCollection();

            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["Phuong"],
              new ColumnFilterInfo("[Phuong] like '%" + cboPhuong.Text + "%'", ""));
        }
        private void BtTracuu_Click(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["Quan"],
          new ColumnFilterInfo("[Quan] like '%" + cboQuan.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["Phuong"],
             new ColumnFilterInfo("[Phuong] like '%" + cboPhuong.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["Duong"],
          new ColumnFilterInfo("[Duong] like '%" + cboDuong.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["LoaiCay"],
              new ColumnFilterInfo("[LoaiCay] like '%" + cboSoTru.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["KetCau"],
         new ColumnFilterInfo("[KetCau] like '%" + txtKetCau.Text + "%'", ""));
        }
        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            cboQuan.ResetText();
            cboPhuong.ResetText();
            cboDuong.ResetText();
            cboSoTru.ResetText();
            txtMaCay.ResetText();
            bindingSource1.ResetBindings(true);
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                TruDien = "TruDien_" + phuong;
                string sql = "select Phuong,Duong,LoaiCay, MaCay,TenThongThuong, DuongKinhThan, DuongKinhTan, NamTrong, DoTuoi,ToaDo,TrangThai,GhiChu,OBJECTID from " + TruDien;// Chỉnh sửa lại thuộc tính cái này
                GridView1.MoveNext();
                GridView1.MovePrev();
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);

                bindingSource1.EndEdit();
                DataTable dt = (DataTable)bindingSource1.DataSource;
                dataAdapter1.Update(dt);
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Chưa chọn thông tin Phường cần cập nhập", "Thông báo");
            }
        }
        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            try
            {
                TruDien = "TruDien_" + phuong;
                string sql = "select Phuong,Duong,LoaiCay, MaCay,TenThongThuong, DuongKinhThan, DuongKinhTan, NamTrong, DoTuoi,ToaDo,TrangThai,GhiChu,OBJECTID from " + TruDien;// Chỉnh sửa lại thuộc tính cái này
                bandedGridView1.MoveNext();
                bandedGridView1.MovePrev();
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);

                bindingSource2.EndEdit();
                DataTable dt = (DataTable)bindingSource2.DataSource;
                dataAdapter1.Update(dt);
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Chưa chọn thông tin Phường cần cập nhập", "Thông báo");
            }
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
        private void button13_Click(object sender, EventArgs e)
        {
            SaveFileDialog openf = new SaveFileDialog();
            openf.Filter = "xls|*.xls";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                bandedGridView2.ExportToXls(openf.FileName);
            }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            SaveFileDialog openf = new SaveFileDialog();
            openf.Filter = "xls|*.xls";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                bandedGridView1.ExportToXls(openf.FileName);
            }
        }
    }
}
