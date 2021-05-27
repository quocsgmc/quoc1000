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

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.QuanLyDiemCCDV2
{
    public partial class QuanLyDiemCCDV2 : Form
    {
        private ESRI.ArcGIS.Carto.IMap dmap;
        bool ChinhSua = false;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public static int IDTram;
        //string sql = "select a.OBJECTID,a.DiaChi,b.TENLOAITRAM,c.TENCHUDATU,d.TenPhuong,e.TENHUYEN from TRAMBTS a,LOAITRAMBTS b,CHUDAUTUBTS c,PhuongXa d,QuanHuyen e where a.IDChuDauTu = c.IDCHUDAUTU and a.IDLoaiTram = b.IDLOAITRAM and a.MaXa = d.MaPhuong and e.MAHUYEN = a.MaHuyen";
        string sql = "[PRC_QUERYTABLETramBTS]";
        public static int ID1;
        string sql1 = "[PRC_QUERYTABLEDaiLyINTERNET_BY_ID] " + ID1 + "";
        public QuanLyDiemCCDV2()
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

        private void QuanLyDiemCCDV2_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            bindingNavigator1.Visible = false;
            //showgridControl1();
            if (ID1 != 0)
            {
                //showgridControl2(sql1);
            }
            if (QLHTDT.Properties.Settings.Default.QuyenSuaDT == true) { button1.Visible = true; } else { button1.Visible = false; }
            bool ChinhSua = false;
        }
        void showgridControl1()
        {
            tb = new DataTable();SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
            //DataSet ds = new DataSet();
            //SqlDataAdapter adp = new SqlDataAdapter(sql, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            //adp.FillSchema(ds, SchemaType.Source);
            //adp.Fill(ds);
            //for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            //{
            //    var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
            //    var val2 = ds.Tables[0].Rows[intCount]["QuanHuyen"].ToString();
            //    var val3 = ds.Tables[0].Rows[intCount]["ChuDauTu"].ToString();
            //    if (!comboBox1.Items.Contains(val))
            //    {
            //        comboBox1.Items.Add(val);
            //    }
            //    if (!comboQuan.Items.Contains(val2))
            //    {
            //        comboQuan.Items.Add(val2);
            //    }
            //    if (!comboBox2.Items.Contains(val3))
            //    {
            //        comboBox2.Items.Add(val3);
            //    }
            //}
        }
        void showgridControl2(string sql1)
        {
            tb = new DataTable(); SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
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
            view.ActiveFilter.Add(view.Columns["PhuongXa"],
              new ColumnFilterInfo("[PhuongXa] like '%" + comboPhuong.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["STT"],
               new ColumnFilterInfo("[STT] like '%" + txtSTT.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["DiaChi"],
               new ColumnFilterInfo("[DiaChi] like '%" + txtDiaChi.Text + "%'", ""));
        }
        public void ChinhSua_Click(object sender, EventArgs e)
        {
            if (btChinhSua.Text == "Chỉnh sửa")
            {
                //GridView1.ClearColumnsFilter();
                //GridView1.RefreshData();
                GridView1.OptionsBehavior.Editable = true;
                bindingNavigator1.Visible = true;
                btChinhSua.Text = "Tắt";
                //comboBox1.ResetText();
                //this.bindingSource1.DataSource = null;
                ChinhSua = false;

            }
            else
            {
                if (ChinhSua == true)
                {
                    //BTS.TBNK = new DataTable();
                    //SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    //BTS.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                    //cmbl = new SqlCommandBuilder(BTS.dataAdapterNK);
                    //BTS.dataAdapterNK.Fill(BTS.TBNK);
                    ////BTS.ChinhSuathuoctinhToolQuanLy("Đồ án Quy hoạch " + comboBox1.Text);
                    //BTS.dataAdapterNK.Update(BTS.TBNK);
                }
                //bindingSource1.ResetBindings(true);
                ////DataTable table = (DataTable)bindingSource1.DataSource;
                //btChinhSua.Text = "Chỉnh sửa";
                //bindingNavigator1.Visible = false;
                //GridView1.OptionsBehavior.Editable = false;
                //tb = new DataTable();
                //SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                //dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
                //cmbl = new SqlCommandBuilder(dataAdapter1);
                //dataAdapter1.Fill(tb);
                //this.bindingSource1.DataSource = tb;
                //GridView1.ClearColumnsFilter();
                //GridView1.RefreshData();

                btChinhSua.Text = "Chỉnh sửa";
                bindingNavigator1.Visible = false;
                GridView1.OptionsBehavior.Editable = false;
                GridView1.ClearColumnsFilter();
                GridView1.RefreshData();

                ColumnView view = GridView1;
                view.ActiveFilter.Add(view.Columns["QuanHuyen"],
                  new ColumnFilterInfo("[QuanHuyen] like '%" + comboQuan.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["PhuongXa"],
                  new ColumnFilterInfo("[PhuongXa] like '%" + comboPhuong.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["STT"],
                   new ColumnFilterInfo("[STT] like '%" + txtSTT.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["DiaChi"],
                   new ColumnFilterInfo("[DiaChi] like '%" + txtDiaChi.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["ChuDauTu"],
                  new ColumnFilterInfo("[ChuDauTu] like '%" + comboTenDaiLy.Text + "%'", ""));
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
                    if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == "Trạm BTS")
                    {
                        IFeatureLayer ilayer1 = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1) as IFeatureLayer;
                        KTMoLop = KTMoLop + 1;
                        int ID;
                        int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                        if (ID == 0)
                        {
                            Cursor = Cursors.WaitCursor;
                            MessageBox.Show("Không có dữ liệu không gian trạm BTS quy hoạch này", "Thông báo");
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
                    DialogResult dialogResult = MessageBox.Show("Chưa mở lớp dữ liệu không gian Trạm BTS \n" + "Có muốn mở lớp dữ liệu này hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Bưu chính - Viễn thông\\Trạm BTS.lyr");
                        QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        for (int i = 0; i < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i).Name == "Trạm BTS")
                            {
                                KTMoLop = KTMoLop + 1;
                                IFeatureLayer ilayer = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i) as IFeatureLayer;
                                int ID;
                                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Trạm BTS", "Thông báo"); }
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

        private void comboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
            comboPhuong.ResetText();
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["QuanHuyen"],
              new ColumnFilterInfo("[QuanHuyen] like '%" + comboQuan.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["STT"],
               new ColumnFilterInfo("[STT] like '%" + txtSTT.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["DiaChi"],
               new ColumnFilterInfo("[DiaChi] like '%" + txtDiaChi.Text + "%'", ""));

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql+ " Where [QuanHuyen] = N'"+ comboQuan.Text +"'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            comboPhuong.Items.Clear();
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                if (!comboPhuong.Items.Contains(val))
                {
                    comboPhuong.Items.Add(val);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["QuanHuyen"],
              new ColumnFilterInfo("[QuanHuyen] like '%" + comboQuan.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["PhuongXa"],
              new ColumnFilterInfo("[PhuongXa] like '%" + comboPhuong.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["STT"],
               new ColumnFilterInfo("[STT] like '%" + txtSTT.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["DiaChi"],
               new ColumnFilterInfo("[DiaChi] like '%" + txtDiaChi.Text + "%'", ""));
        }
        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            txtSTT.ResetText();
            txtDiaChi.ResetText();
            comboQuan.ResetText();
            comboPhuong.ResetText();
            comboTenDaiLy.ResetText();
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
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
              new ColumnFilterInfo("[STT] like '%" + txtSTT.Text + "%'", ""));
        }

        private void txtDiaDiem_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["DiaChi"],
              new ColumnFilterInfo("[DiaChi] like '%" + txtDiaChi.Text + "%'", ""));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.ThemMoiMotDaiLy frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.DaiLyInternet.ThemMoiMotDaiLy();
            frm.Show();
            Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.ThemMoiTuExcel frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.ThemMoiTuExcel();
            frm.Show();
            Cursor = Cursors.Default;
        }
        int ID;
        private void button4_Click(object sender, EventArgs e)
        {
            if (MoRong == 0)
            {
                this.ClientSize = new System.Drawing.Size(440, 746);
                MoRong = 1;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen2;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(775, 746);
                MoRong = 0;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["QuanHuyen"],
              new ColumnFilterInfo("[QuanHuyen] like '%" + comboQuan.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["PhuongXa"],
              new ColumnFilterInfo("[PhuongXa] like '%" + comboPhuong.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["STT"],
               new ColumnFilterInfo("[STT] like '%" + txtSTT.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["DiaChi"],
               new ColumnFilterInfo("[DiaChi] like '%" + txtDiaChi.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["ChuDauTu"],
               new ColumnFilterInfo("[ChuDauTu] like '%" + comboTenDaiLy.Text + "%'", ""));
        }
        int MoRong = 1;
        private void button5_Click(object sender, EventArgs e)
        {
            if (MoRong == 0)
            {
                this.ClientSize = new System.Drawing.Size(440, 746);
                MoRong = 1;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen2;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(775, 746);
                MoRong = 0;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen;
            }
        }
        private void GridView1_Click(object sender, EventArgs e)
        {
            int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID1);
            sql1 = "SELECT * FROM  TRAMBTS where OBJECTID = " + ID1 + "";
            showgridControl2(sql1);
        }
    }
}
