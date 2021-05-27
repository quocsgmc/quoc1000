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
    public partial class TestQLCayXanh : Form
    {
        bool ChinhSua = false;
        bool ChinhSua1 = false;
        bool ChinhSua2 = false;

        public static string CayXanh = "Cây xanh - HA";
        string phuong;
        string phuong1;
        string phuong2;
        string txtCayXanh;
        SqlCommandBuilder cmbl;
        SqlDataAdapter dataAdapter1;
        DataTable tb;
        DataTable tbcheck;
        private AxMapControl mMapControl;
        private ESRI.ArcGIS.Carto.IMap dmap;
        string layerget;
        public TestQLCayXanh()
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                IActiveView pActiveView;
                pActiveView = QuanTriHeThong.axMapControl1.ActiveView;
                Global.pActiveView = pActiveView;
                CayXanh = "Cây xanh - " + phuong1;
                ILayer pLayer = Global.getLayerbyName(Global.pActiveView.FocusMap, TestQLCayXanh.CayXanh);
                if (pLayer == null)
                {
                    QuanTriHeThong.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + cboPhuong1.SelectedItem.ToString() + "\\" + CayXanh + ".lyr");
                    QuanTriHeThong.axMapControl1.Extent = QuanTriHeThong.axMapControl1.get_Layer(0).AreaOfInterest;
                }
                this.Visible = false;
            }
            catch
            {
                MessageBox.Show("Chưa chọn lớp dữ liệu, vui lòng thử lại", "Thông báo");
            }
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
                    cboPhuong1.Items.Add(val);
                    cboPhuong2.Items.Add(val);
                }
                if (!cboQuan.Items.Contains(val2))
                {
                    cboQuan.Items.Add(val2);
                    cboQuan1.Items.Add(val2);
                    cboQuan2.Items.Add(val2);
                }
                if (!cboQuan.Items.Contains(val3))
                {
                    cboQuan.Items.Add(val3);
                    cboQuan1.Items.Add(val3);
                    cboQuan2.Items.Add(val3);
                }
            }
        }
        private void TestQLCayXanh_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ShowComBoBox();
            showgridControl1();
            Cursor = Cursors.Default;
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

            ColumnView view = gridView1;
            view.ActiveFilter.Add(view.Columns["Phuong"],
              new ColumnFilterInfo("[Phuong] like '%" + cboPhuong.Text + "%'", ""));
        }
        private void cboPhuong1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhuong1.Text == "Hòa An") { phuong1 = "HA"; };
            if (cboPhuong1.Text == "Hòa Phát") { phuong1 = "HP"; };
            if (cboPhuong1.Text == "Hòa Thọ Đông") { phuong1 = "HTD"; };
            if (cboPhuong1.Text == "Hòa Thọ Tây") { phuong1 = "HTT"; };
            if (cboPhuong1.Text == "Hòa Xuân") { phuong1 = "HX"; };
            if (cboPhuong1.Text == "Khuê Trung") { phuong1 = "KT"; };
            cboDuong1.Items.Clear();
            cboDuong1.Items.Add("");
            LoadDataToCollection1();
        }
        private void CboPhuong2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhuong2.Text == "Hòa An") { phuong2 = "HA"; };
            if (cboPhuong2.Text == "Hòa Phát") { phuong2 = "HP"; };
            if (cboPhuong2.Text == "Hòa Thọ Đông") { phuong2 = "HTD"; };
            if (cboPhuong2.Text == "Hòa Thọ Tây") { phuong2 = "HTT"; };
            if (cboPhuong2.Text == "Hòa Xuân") { phuong2 = "HX"; };
            if (cboPhuong2.Text == "Khuê Trung") { phuong2 = "KT"; };
            cboDuong2.Items.Clear();
            cboDuong2.Items.Add("");
            LoadDataToCollection2();
        }
        private void LoadDataToCollection()//Gợi ý tên Đường
        {
            AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) + ";Type System Version=SQL Server 2012;");
            string sql = "Select TenDuong from DUONGCHINH_"+phuong+"";
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
        private void LoadDataToCollection1()//Gợi ý tên Đường
        {
            AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) + ";Type System Version=SQL Server 2012;");
            string sql = "Select TenDuong from DUONGCHINH_" + phuong1 + "";
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
            cboDuong1.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboDuong1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboDuong1.AutoCompleteCustomSource = auto2;

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            cboDuong1.Items.Add("");
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["TenDuong"].ToString();
                if (!cboDuong1.Items.Contains(val))
                {
                    cboDuong1.Items.Add(val);
                }

            }
        }
        private void LoadDataToCollection2()//Gợi ý tên Đường
        {
            AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) + ";Type System Version=SQL Server 2012;");
            string sql = "Select TenDuong from DUONGCHINH_" + phuong2 + "";
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
            cboDuong2.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboDuong2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboDuong2.AutoCompleteCustomSource = auto2;

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            cboDuong2.Items.Add("");
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["TenDuong"].ToString();
                if (!cboDuong2.Items.Contains(val))
                {
                    cboDuong2.Items.Add(val);
                }
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
        private void cboQuan1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT [PhuongXa],[QuanHuyen] FROM  TRAMBTS";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql + " Where [QuanHuyen] = N'" + cboQuan1.Text + "'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            cboPhuong1.Items.Clear();
            cboPhuong1.Items.Add("");
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                if (!cboPhuong1.Items.Contains(val))
                {
                    cboPhuong1.Items.Add(val);
                }
            }
        }
        private void cboQuan2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT [PhuongXa],[QuanHuyen] FROM  TRAMBTS";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql + " Where [QuanHuyen] = N'" + cboQuan2.Text + "'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            cboPhuong2.Items.Clear();
            cboPhuong2.Items.Add("");
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                if (!cboPhuong2.Items.Contains(val))
                {
                    cboPhuong2.Items.Add(val);
                }
            }
        }
        private void BtTracuu_Click(object sender, EventArgs e)
        {
            ColumnView view = gridView1;
            view.ActiveFilter.Add(view.Columns["Quan"],
          new ColumnFilterInfo("[Quan] like '%" + cboQuan.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["Phuong"],
             new ColumnFilterInfo("[Phuong] like '%" + cboPhuong.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["Duong"],
          new ColumnFilterInfo("[Duong] like '%" + cboDuong.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["LoaiCay"],
              new ColumnFilterInfo("[LoaiCay] like '%" + cboLoaiCay.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["MaCay"],
         new ColumnFilterInfo("[MaCay] like '%" + txtMaCay.Text + "%'", ""));
        }
        private void BtTracuu1_Click(object sender, EventArgs e)
        {
            ColumnView view = bandedGridView1;
            view.ActiveFilter.Add(view.Columns["Quan"],
          new ColumnFilterInfo("[Quan] like '%" + cboQuan1.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["Phuong"],
             new ColumnFilterInfo("[Phuong] like '%" + cboPhuong1.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["Duong"],
          new ColumnFilterInfo("[Duong] like '%" + cboDuong1.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["LoaiCay"],
              new ColumnFilterInfo("[LoaiCay] like '%" + cboLoaiCay1.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["MaCay"],
         new ColumnFilterInfo("[MaCay] like '%" + txtMaCay1.Text + "%'", ""));
        }
        private void btTraCuu2_Click(object sender, EventArgs e)
        {
            ColumnView view = gridView2;
            view.ActiveFilter.Add(view.Columns["Quan"],
          new ColumnFilterInfo("[Quan] like '%" + cboQuan2.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["Phuong"],
             new ColumnFilterInfo("[Phuong] like '%" + cboPhuong2.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["Duong"],
          new ColumnFilterInfo("[Duong] like '%" + cboDuong2.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["LoaiCay"],
              new ColumnFilterInfo("[LoaiCay] like '%" + cboLoaiCay2.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["MaCay"],
         new ColumnFilterInfo("[MaCay] like '%" + txtMaCay2.Text + "%'", ""));
        }
        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            cboQuan.ResetText();
            cboPhuong.ResetText();
            cboDuong.ResetText();
            cboLoaiCay.ResetText();
            txtMaCay.ResetText();
            cayXanhBindingSource.ResetBindings(true);
            gridView1.ClearColumnsFilter();
            gridView1.RefreshData();
        }
        private void Btloadlailop1_Click(object sender, EventArgs e)
        {
            cboQuan1.ResetText();
            cboPhuong1.ResetText();
            cboDuong1.ResetText();
            cboLoaiCay1.ResetText();
            txtMaCay1.ResetText();
            chamsocbindingSource.ResetBindings(true);
            bandedGridView1.ClearColumnsFilter();
            bandedGridView1.RefreshData();
        }
        private void btLoadlailop2_Click(object sender, EventArgs e)
        {
            cboQuan2.ResetText();
            cboPhuong2.ResetText();
            cboDuong2.ResetText();
            cboLoaiCay2.ResetText();
            txtMaCay2.ResetText();
            chiphibindingSource.ResetBindings(true);
            gridView2.ClearColumnsFilter();
            gridView2.RefreshData();
        }
        private void btChinhSua_Click(object sender, EventArgs e)
        {
            if (btChinhSua.Text == "Chỉnh sửa")
            {
                gridView1.OptionsBehavior.Editable = true;
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
                gridView1.OptionsBehavior.Editable = false;
                gridView1.ClearColumnsFilter();
                gridView1.RefreshData();
                ColumnView view = gridView1;
                   view.ActiveFilter.Add(view.Columns["Phuong"],
                new ColumnFilterInfo("[Phuong] like '%" + cboPhuong.Text + "%'", ""));
                   view.ActiveFilter.Add(view.Columns["Duong"],
                new ColumnFilterInfo("[Duong] like '%" + cboDuong.Text + "%'", ""));
                   view.ActiveFilter.Add(view.Columns["LoaiCay"],
                new ColumnFilterInfo("[LoaiCay] like '%" + cboLoaiCay.Text + "%'", ""));
                   view.ActiveFilter.Add(view.Columns["MaCay"],
                new ColumnFilterInfo("[MaCay] like '%" + txtMaCay.Text + "%'", ""));
            }
        }
        private void btChinhSua1_Click(object sender, EventArgs e)
        {
            if (btChinhSua1.Text == "Chỉnh sửa")
            {
                bandedGridView1.OptionsBehavior.Editable = true;
                bindingNavigator2.Visible = true;
                btChinhSua1.Text = "Tắt";
                ChinhSua1 = false;
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
                btChinhSua1.Text = "Chỉnh sửa";
                bindingNavigator2.Visible = false;
                bandedGridView1.OptionsBehavior.Editable = false;
                bandedGridView1.ClearColumnsFilter();
                bandedGridView1.RefreshData();
                ColumnView view = bandedGridView1;
                view.ActiveFilter.Add(view.Columns["Quan"],
              new ColumnFilterInfo("[Quan] like '%" + cboQuan1.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["Phuong"],
             new ColumnFilterInfo("[Phuong] like '%" + cboPhuong1.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["Duong"],
             new ColumnFilterInfo("[Duong] like '%" + cboDuong1.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["LoaiCay"],
             new ColumnFilterInfo("[LoaiCay] like '%" + cboLoaiCay1.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["MaCay"],
             new ColumnFilterInfo("[MaCay] like '%" + txtMaCay1.Text + "%'", ""));
            }
        }
        private void btChinhSua2_Click(object sender, EventArgs e)
        {
            if (btChinhSua2.Text == "Chỉnh sửa")
            {
                gridView2.OptionsBehavior.Editable = true;
                bindingNavigator3.Visible = true;
                btChinhSua2.Text = "Tắt";
                ChinhSua2 = false;

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
                btChinhSua2.Text = "Chỉnh sửa";
                bindingNavigator3.Visible = false;
                gridView2.OptionsBehavior.Editable = false;
                gridView2.ClearColumnsFilter();
                gridView2.RefreshData();
                ColumnView view = gridView2;
                view.ActiveFilter.Add(view.Columns["Quan"],
              new ColumnFilterInfo("[Quan] like '%" + cboQuan2.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["Phuong"],
             new ColumnFilterInfo("[Phuong] like '%" + cboPhuong2.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["Duong"],
             new ColumnFilterInfo("[Duong] like '%" + cboDuong2.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["LoaiCay"],
             new ColumnFilterInfo("[LoaiCay] like '%" + cboLoaiCay2.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["MaCay"],
             new ColumnFilterInfo("[MaCay] like '%" + txtMaCay2.Text + "%'", ""));
            }
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                txtCayXanh = "CayXanh_" + phuong;
                string sql = "select Phuong,Duong,LoaiCay, MaCay,TenThongThuong, DuongKinhThan, DuongKinhTan, NamTrong, DoTuoi,ToaDo,TrangThai,GhiChu,OBJECTID from " + txtCayXanh;// Chỉnh sửa lại thuộc tính cái này
                gridView1.MoveNext();
                gridView1.MovePrev();
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);

                cayXanhBindingSource.EndEdit();
                DataTable dt = (DataTable)cayXanhBindingSource.DataSource;
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
            txtCayXanh = "CayXanh_" + phuong1;
            string sql = "select Quan,Phuong,Duong, LoaiCay, MaCay,MatDoChamSoc, CheDoCatTia, ThoiGianCatTia, DienTich, PhuongTien, ChetGayDo,BenhTuoiGia,ThuocDuAnXDCT,ThongTinBaoVe,ThongTinCayBenh,OBJECTID from " + txtCayXanh;// Chỉnh sửa lại thuộc tính cái này
            bandedGridView1.MoveNext();
            bandedGridView1.MovePrev();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);

            chamsocbindingSource.EndEdit();
            DataTable dt = (DataTable)chamsocbindingSource.DataSource;
            dataAdapter1.Update(dt);
        }
        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            txtCayXanh = "CayXanh_" + phuong2;
            string sql = "select Quan,Phuong,Duong,LoaiCay, MaCay,ThoiGianPhatSinh, NhanCong, SoLuong, ChiPhi, MoTa, OBJECTID from " + txtCayXanh;// Chỉnh sửa lại thuộc tính cái này
            gridView2.MoveNext();
            gridView2.MovePrev();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);

            chiphibindingSource.EndEdit();
            DataTable dt = (DataTable)chiphibindingSource.DataSource;
            dataAdapter1.Update(dt);
        }
        private void BtExcell_Click(object sender, EventArgs e)
        {
            SaveFileDialog openf = new SaveFileDialog();
            openf.Filter = "xls|*.xls";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(openf.FileName);
            }
        }
        private void BtExcell1_Click(object sender, EventArgs e)
        {
            SaveFileDialog openf = new SaveFileDialog();
            openf.Filter = "xls|*.xls";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                bandedGridView1.ExportToXls(openf.FileName);
            }
        }
        private void btXExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog openf = new SaveFileDialog();
            openf.Filter = "xls|*.xls";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                gridView2.ExportToXls(openf.FileName);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GridView view1 = (GridView)sender;
            System.Drawing.Point pt1 = view1.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view1.CalcHitInfo(pt1);
            DoRowDoubleClick(view1, pt1);
            Cursor = Cursors.Default;
        }
        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GridView view2 = (GridView)sender;
            System.Drawing.Point pt2 = view2.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view2.CalcHitInfo(pt2);
            DoRowDoubleClick(view2, pt2);
            Cursor = Cursors.Default;
        }
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GridView view3 = (GridView)sender;
            System.Drawing.Point pt3 = view3.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view3.CalcHitInfo(pt3);
            DoRowDoubleClick(view3, pt3);
            Cursor = Cursors.Default;
        }
        private void DoRowDoubleClick(GridView view, System.Drawing.Point pt)
        {
            int KTMoLop = 0;
            string PhuongKT = null;
            try
            {
                string Phuong = "";
                switch (xtraTabControl1.SelectedTabPageIndex)
                {
                    case 0: Phuong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Phuong").ToString(); break;
                    case 1: Phuong = bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "Phuong").ToString(); break;
                    case 2: Phuong = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Phuong").ToString(); ; break;
                }
                switch (Phuong)
                {
                    case "Hòa An": layerget = "Cây xanh - HA"; break;
                    case "Hòa Phát": layerget = "Cây xanh - HP"; break;
                    case "Hòa Thọ Đông": layerget = "Cây xanh - HTD"; break;
                    case "Hòa Thọ Tây": layerget = "Cây xanh - HTT"; break;
                    case "Hòa Xuân": layerget = "Cây xanh - HX"; break;
                    case "Khuê Trung": layerget = "Cây xanh - KT"; break;
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
                                int ID=0;
                                switch (xtraTabControl1.SelectedTabPageIndex)
                                {
                                    case 0: int.TryParse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID); ; break;
                                    case 1: int.TryParse(bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID); ; break;
                                    case 2: int.TryParse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OBJECTID").ToString(), out ID); ; break;
                                }
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Cây xanh này", "Thông báo"); }
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
                                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = 200;
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

                                int ID=0;
                                switch (xtraTabControl1.SelectedTabPageIndex)
                                {
                                    case 0: int.TryParse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID); ; break;
                                    case 1: int.TryParse(bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID); ; break;
                                    case 2: int.TryParse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OBJECTID").ToString(), out ID); ; break;
                                }
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Cây xanh này", "Thông báo"); }
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
                                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = 200;
                                        ActiveView.Refresh();
                                    }
                                }
                            }
                        }
                    }
                }
                if (KTMoLop == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa mở lớp dữ liệu không gian Cây xanh " + PhuongKT + "\n" + "Có muốn mở lớp dữ liệu này hay không ?", "Thông báo", MessageBoxButtons.YesNo);
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

                                int ID=0;
                                switch (xtraTabControl1.SelectedTabPageIndex)
                                {
                                    case 0: int.TryParse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID); ; break;
                                    case 1: int.TryParse(bandedGridView1.GetRowCellValue(bandedGridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID); ; break;
                                    case 2: int.TryParse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OBJECTID").ToString(), out ID); ; break;
                                }
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Cây xanh này", "Thông báo"); }
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
                                        QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = 200;
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
        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ChinhSua = true;
        }
        void showgridControl1()
        {
            tb = new DataTable();
            tbcheck = new DataTable();
            //string sql = "select Objectid,LoaiCay,MaCay,Phuong,Duong,TenThongThuong,DuongKinhThan,DuongKinhTan from CayXanh_HA UNION select Objectid,LoaiCay,MaCay,Phuong,Duong,TenThongThuong,DuongKinhThan,DuongKinhTan from CayXanh_HP UNION select Objectid,LoaiCay,MaCay,Phuong,Duong,TenThongThuong,DuongKinhThan,DuongKinhTan from CayXanh_HTD UNION select Objectid,LoaiCay,MaCay,Phuong,Duong,TenThongThuong,DuongKinhThan,DuongKinhTan from CayXanh_HTT UNION select Objectid,LoaiCay,MaCay,Phuong,Duong,TenThongThuong,DuongKinhThan,DuongKinhTan from CayXanh_HX UNION select Objectid,LoaiCay,MaCay,Phuong,Duong,TenThongThuong,DuongKinhThan,DuongKinhTan from CayXanh_KT ";
            string sql = "select [OBJECTID],LoaiCay,MaCay,Phuong,Duong,TenThongThuong,DuongKinhThan,DuongKinhTan,NamTrong,DoTuoi,TrangThai,ToaDo,GhiChu from CayXanh_HA";
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.cayXanhBindingSource.DataSource = tb;
            this.chamsocbindingSource.DataSource = tb;
            this.chiphibindingSource.DataSource = tb;
            //bingding();
        }

        private void cboDuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = gridView1;
            view.ActiveFilter.Add(view.Columns["Duong"],
              new ColumnFilterInfo("[Duong] like '%" + cboDuong.Text + "%'", ""));
        }

        private void cboLoaiCay_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = gridView1;
            view.ActiveFilter.Add(view.Columns["LoaiCay"],
              new ColumnFilterInfo("[LoaiCay] like '%" + cboLoaiCay.Text + "%'", ""));
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            MyButtonEdit edit = gridView1.ActiveEditor as MyButtonEdit;
            if (edit != null)
            {
                edit.Properties.ButtonsAlignment = DevExpress.Utils.VertAlignment.Center;
                edit.Properties.ButtonsHeight = 25;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ICommand command = new QLyHaTang.CapNhatCayXanh();
            command.OnCreate(QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Object);
            QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.CurrentTool = command as ITool;
        }
    }
}
