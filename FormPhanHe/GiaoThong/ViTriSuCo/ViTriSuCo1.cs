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

namespace QLHTDT.FormPhanHe.GiaoThong.ViTriSuCo.ViTriSuCo
{
    public partial class ViTriSuCo1 : Form
    {
        private ESRI.ArcGIS.Carto.IMap dmap;
        bool ChinhSua = false;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        string sql = "SELECT [OBJECTID],[STT],[ChuDauTu],[DiaChi],[PhuongXa],[QuanHuyen],[KinhDo] ,[ViDo] ,[LoaiTru] ,[DoCao] ,[Ngay] ,[SoGP] ,[NgayCapGP] ,[SoCN] ,[NgayVaoSoCN],[DungChung] ,[Khac] ,[ThongTinKh]  ,[XVN2000],[YVN2000] FROM  TRAMGiaoThong";

        public ViTriSuCo1()
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map;
        }

        private void ViTriSuCo1_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            bindingNavigator1.Visible = false;
            //showgridControl1();
            bool ChinhSua = false;
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
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                var val2 = ds.Tables[0].Rows[intCount]["QuanHuyen"].ToString();
                if (!comboBox1.Items.Contains(val))
                {
                    comboBox1.Items.Add(val);
                }
                if (!comboQuan.Items.Contains(val2))
                {
                    comboQuan.Items.Add(val2);
                }
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
        private void BtTracuu_Click(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["QuanHuyen"],
              new ColumnFilterInfo("[QuanHuyen] like '%" + comboQuan.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["PhuongXa"],
              new ColumnFilterInfo("[PhuongXa] like '%" + comboBox1.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["DiaChi"],
               new ColumnFilterInfo("[DiaChi] like '%" + txtDiaDiem.Text + "%'", ""));
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
                    //GiaoThong.TBNK = new DataTable();
                    //SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    //GiaoThong.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                    //cmbl = new SqlCommandBuilder(GiaoThong.dataAdapterNK);
                    //GiaoThong.dataAdapterNK.Fill(GiaoThong.TBNK);
                    ////GiaoThong.ChinhSuathuoctinhToolQuanLy("Đồ án Quy hoạch " + comboBox1.Text);
                    //GiaoThong.dataAdapterNK.Update(GiaoThong.TBNK);
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
                  new ColumnFilterInfo("[PhuongXa] like '%" + comboBox1.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["DiaChi"],
                   new ColumnFilterInfo("[DiaChi] like '%" + txtDiaDiem.Text + "%'", ""));
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
                    if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == "Trạm GiaoThong")
                    {
                        IFeatureLayer ilayer1 = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1) as IFeatureLayer;
                        KTMoLop = KTMoLop + 1;
                        int ID;
                        int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                        if (ID == 0)
                        {
                            Cursor = Cursors.WaitCursor;
                            MessageBox.Show("Không có dữ liệu không gian trạm GiaoThong quy hoạch này", "Thông báo");
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
                    DialogResult dialogResult = MessageBox.Show("Chưa mở lớp dữ liệu không gian Trạm GiaoThong \n" + "Có muốn mở lớp dữ liệu này hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Trạm GiaoThong.lyr");
                        QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        for (int i = 0; i < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i).Name == "Trạm GiaoThong")
                            {
                                KTMoLop = KTMoLop + 1;
                                IFeatureLayer ilayer = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i) as IFeatureLayer;
                                int ID;
                                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Trạm GiaoThong", "Thông báo"); }
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
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
            comboBox1.ResetText();
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["QuanHuyen"],
              new ColumnFilterInfo("[QuanHuyen] like '%" + comboQuan.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["DiaChi"],
               new ColumnFilterInfo("[DiaChi] like '%" + txtDiaDiem.Text + "%'", ""));

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql+ " Where [QuanHuyen] = N'"+ comboQuan.Text +"'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            comboBox1.Items.Clear();
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                if (!comboBox1.Items.Contains(val))
                {
                    comboBox1.Items.Add(val);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["QuanHuyen"],
              new ColumnFilterInfo("[QuanHuyen] like '%" + comboQuan.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["PhuongXa"],
              new ColumnFilterInfo("[PhuongXa] like '%" + comboBox1.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["DiaChi"],
               new ColumnFilterInfo("[DiaChi] like '%" + txtDiaDiem.Text + "%'", ""));
        }
        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            txtDiaDiem.ResetText();
            comboQuan.ResetText();
            comboBox1.ResetText();
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

        private void txtDiaDiem_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["DiaChi"],
              new ColumnFilterInfo("[DiaChi] like '%" + txtDiaDiem.Text + "%'", ""));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhanHe.GiaoThong.LapKeHoachBaoDuong.LapKeHoachBaoDuong frm = new QLHTDT.FormPhanHe.GiaoThong.LapKeHoachBaoDuong.LapKeHoachBaoDuong();
            frm.Show();
            Cursor = Cursors.Default;
        }
    }
}
