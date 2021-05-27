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

namespace QLHTDT.FormPhu.FormChiTietLayer
{
    public partial class QuanLyGiaoThongChinh2 : Form
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
        string sql = "[PRC_QUERY_DUONGCHINH]";
        public static int ID1 ;

        public static string MaHuyen = "null";
        string sql1 = "[PRC_QUERYDuongGTChinh_BY_ID] " + ID1 + "";//
        string sqlQuan = "[PRC_Query_TenHuyen_By_MAHuyen] null";//
        public QuanLyGiaoThongChinh2()
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

        private void QuanLyGiaoThongChinh2_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            if (ID1 != 0)
            {
                showgridControl2(sql1);
            }
    
        }
        void showgridControl1()
        {
            tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
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

        private void DoRowDoubleClick(GridView view, System.Drawing.Point pt)
        {
            Cursor = Cursors.WaitCursor;
            int KTMoLop = 0;
            string PhuongKT = null;
            try
            {

                for (int i1 = 0; i1 < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i1++)
                {
                    if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == "Đường giao thông chính")
                    {
                        IFeatureLayer ilayer1 = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1) as IFeatureLayer;
                        KTMoLop = KTMoLop + 1;
                        int ID;
                        int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                        if (ID == 0)
                        {
                            Cursor = Cursors.WaitCursor;
                            MessageBox.Show("Không có dữ liệu không gian Đường giao thông chính này", "Thông báo");
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
                                dmap.MapScale = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale * 2; ;
                                ActiveView.Refresh();
                                Cursor = Cursors.Default;
                            }
                        }
                    }
                }
                if (KTMoLop == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa mở lớp dữ liệu không gian Đường giao thông chính \n" + "Có muốn mở lớp dữ liệu này hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Giao thông\\Đường giao thông chính.lyr");
                        QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        for (int i = 0; i < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i).Name == "Đường giao thông chính")
                            {
                                KTMoLop = KTMoLop + 1;
                                IFeatureLayer ilayer = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i) as IFeatureLayer;
                                int ID;
                                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Đường giao thông chính", "Thông báo"); }
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
                                        dmap.MapScale = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale * 2; ;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.ThemMoiMotTram frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.ThemMoiMotTram();
            //frm.Show();
            Cursor = Cursors.Default;
        }
        private void GridView1_Click(object sender, EventArgs e)
        {
            if (int.Parse(GridView1.FocusedRowHandle.ToString()) >= 0)
            {
                try
                {
                    string Caption = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenDuong").ToString();
                    cardView1.CardCaptionFormat = Caption;
                    int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID1);
                    sql1 = "[PRC_QUERYDuongGTChinh_BY_ID] " + ID1 + "";
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa Đường giao thông chính được chọn " + " không?", "Xóa dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID1);
                try
                {
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string Delelequery = "[PRC_DELETE_DUONGGTCHINH] " + ID1 + "";
                    SqlCommand cmd1 = new SqlCommand(Delelequery, conn);
                    cmd1.ExecuteNonQuery();
                    showgridControl1();
                    MessageBox.Show("Xóa Đường giao thông chính thành công", "Thông báo");
                    //Phần này là lưu nhật ký
                    KienTruc.TBNK = new DataTable();
                    SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                    cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                    KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                    KienTruc.XoaDoiTuong("Đường giao thông chính", ID1);
                    KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn Đường giao thông chính cần xóa", "Thông báo");
                }
            }
      

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public static DataTable dt;
        public static DataRow dr;
        private IFeatureLayer fLayer;
        IFeature pFeature;
        public void Show(IFeatureCursor pCu)
        {
            dt = new DataTable();
            dt.Columns.Add("OBJECTID", typeof(Double));
            dt.Columns.Add("TenDuong", typeof(String));
            dt.Columns.Add("LoaiDuong", typeof(String));
            dt.Columns.Add("QuanHuyen", typeof(String));
            dt.Columns.Add("TenPhuong", typeof(String));
            dt.Columns.Add("ChieuDai", typeof(String));
            pFeature = pCu.NextFeature();
            int i = 0;
            //int y = 2;
            bindingSource1.DataSource = dt;
            while (pFeature != null)
            {
                dr = dt.NewRow();
                dr[0] = pFeature.get_Value(pFeature.Fields.FindField("OBJECTID")).ToString();
                if (pFeature.get_Value(pFeature.Fields.FindField("TenDuong")) != DBNull.Value)
                {
                    dr[1] = pFeature.get_Value(pFeature.Fields.FindField("TenDuong")).ToString();
                }
                if (pFeature.get_Value(pFeature.Fields.FindField("LoaiDuong")) != DBNull.Value)
                {
                    dr[2] = pFeature.get_Value(pFeature.Fields.FindField("LoaiDuong")).ToString();
                }

                if (pFeature.get_Value(pFeature.Fields.FindField("MaXa")) != DBNull.Value)
                {
                    string MaXa = pFeature.get_Value(pFeature.Fields.FindField("MaXa")).ToString();
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sql1 = "select QH.TENHUYEN from QUAN QH where QH.MAHUYEN = (select Xa.MaQuan from PhuongXa Xa where Xa.MaPhuong = " + MaXa + ")";
                    SqlCommand command1 = new SqlCommand(sql1, conn);
                    if (command1.ExecuteScalar() != DBNull.Value)
                    {
                        dr[3] = (string)command1.ExecuteScalar();
                    }
                }
                if (pFeature.get_Value(pFeature.Fields.FindField("MaXa")) != DBNull.Value)
                {
                    string MaXa = pFeature.get_Value(pFeature.Fields.FindField("MaXa")).ToString();
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sql1 = "SELECT [TenPhuong] FROM [PhuongXa] where MaPhuong = '" + MaXa + "'";
                    SqlCommand command1 = new SqlCommand(sql1, conn);
                    if (command1.ExecuteScalar() != DBNull.Value)
                    {
                        dr[4] = (string)command1.ExecuteScalar();
                    }
                }
                if (pFeature.get_Value(pFeature.Fields.FindField("ChieuDai")) != DBNull.Value)
                {
                    dr[5] = pFeature.get_Value(pFeature.Fields.FindField("ChieuDai")).ToString();
                }

                dt.Rows.Add(dr);
                GridControl1.DataSource = dt;
                i++;
                pFeature = pCu.NextFeature();
            }
            this.Show();
            if (int.TryParse(GridView1.GetRowCellValue(0, "OBJECTID").ToString(), out ID1) == true)
            {
                int.TryParse(GridView1.GetRowCellValue(0, "OBJECTID").ToString(), out ID1);
                sql1 = "[PRC_QUERYDuongGTChinh_BY_ID] " + ID1 + "";
                showgridControl2(sql1);
                string Caption = GridView1.GetRowCellValue(0, "TenDuong").ToString();
                cardView1.CardCaptionFormat = Caption;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (int.Parse(GridView1.FocusedRowHandle.ToString()) >= 0)
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID1);
                QLHTDT.FormPhanHe.GiaoThong.ChinhSua.ChinhSuaGiaoThongChinh frm = new QLHTDT.FormPhanHe.GiaoThong.ChinhSua.ChinhSuaGiaoThongChinh(ID1);
                frm.TopMost = true;
                frm.Show();
            }
            Cursor = Cursors.Default;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
