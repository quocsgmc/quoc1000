using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
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

namespace QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap
{
    public partial class QuanLyToaDoTuyenCapNgam : Form
    {
        private ESRI.ArcGIS.Carto.IMap dmap;
        bool ChinhSua = false;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        int IDTuyenCapNgam = QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.QuanLyTuyenCapNgam.ID1;
        int IDCHUDAUTU;
        DataTable tt; DataRow dr;
        //string sql = "select a.OBJECTID,a.DiaChi,b.TENLOAITRAM,c.TENCHUDATU,d.TenPhuong,e.TENHUYEN from TRAMBTS a,LOAITRAMBTS b,CHUDAUTUBTS c,PhuongXa d,QuanHuyen e where a.IDChuDauTu = c.IDCHUDAUTU and a.IDLoaiTram = b.IDLOAITRAM and a.MaXa = d.MaPhuong and e.MAHUYEN = a.MaHuyen";
        
        public QuanLyToaDoTuyenCapNgam()
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

        private void QuanLyToaDoTuyenCapNgam_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            bindingNavigator1.Visible = false;
            showgridControl1();
            bool ChinhSua = false;
        }
        void showgridControl1()
        {
            string sql = "[PRC_ToaDoTuyenCapNgam_GET_BY_ID] " + IDTuyenCapNgam + "";
            tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            converttable();

        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            this.Close();
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
                btChinhSua.Text = "Chỉnh sửa";
                bindingNavigator1.Visible = false;
                GridView1.OptionsBehavior.Editable = false;
                GridView1.ClearColumnsFilter();
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn lưu các dữ liệu thay đổi " + " không? Nếu có ấn nút Yes, không thì ấn nút No", "Lưu dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "[PRC_ToaDoTuyenCapNgam_GET_BY_ID] " + IDTuyenCapNgam + "";
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


        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.ThemMoiThietBiPhuTro frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TuyenCap.ThemMoiThietBiPhuTro();
            frm.Show();
            this.Close();
            Cursor = Cursors.Default;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn lưu các dữ liệu thay đổi không?", "Lưu dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string shape = "[PRC_UPDATE_SHAPE_TUYENCAPNGAM] " + IDTuyenCapNgam + ", 'LINESTRING (";
                    for (int i = 0; i < tt.Rows.Count; i++)
                    {
                        if (i != tt.Rows.Count - 1)
                        { shape = shape + tt.Rows[i][2].ToString() + " " + tt.Rows[i][3].ToString() + ", "; }
                        else { shape = shape + tt.Rows[i][2].ToString() + " " + tt.Rows[i][3].ToString() + ")'"; }
                    }
                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    conn.Open();
                    string sqlShape = shape;
                    SqlCommand command4 = new SqlCommand(sqlShape, conn);
                    command4.ExecuteScalar();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Lưu dữ liệu thất bại, vui lòng kiểm tra lại","Thông báo");
                }
            }
            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
        }

        public static int numrow;
        public static int ThemDiem = 0;
        private void button2_Click_1(object sender, EventArgs e)
        {
            numrow = tb.Rows.Count;
            ThemMoiToaDo1DiemTuyenCapNgam frm = new ThemMoiToaDo1DiemTuyenCapNgam();
            frm.ShowDialog();
            if (ThemDiem == 1)
            {
                DataRow barackRow = getRow(tb, ThemMoiToaDo1DiemTuyenCapNgam.X, ThemMoiToaDo1DiemTuyenCapNgam.Y);
                tb.Rows.InsertAt(barackRow, ThemMoiToaDo1DiemTuyenCapNgam.STT);
                ThemDiem = 0;
            }
            converttable();
            GridView1.RefreshData();
        }
        static DataRow getRow(DataTable table, double KinhDo, double ViDo)
        {
            DataRow row = table.NewRow();
            row["X"] = KinhDo;
            row["Y"] = ViDo;
            return row;
        }
        private void converttable()
        {
            tt = new DataTable();
            tt.Columns.Add("STT", typeof(String));
            tt.Columns.Add("TenDiem", typeof(String));
            tt.Columns.Add("X", typeof(String));
            tt.Columns.Add("Y", typeof(String));
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                dr = tt.NewRow();
                dr[0] = i + 1;
                if (i == 0)
                {
                    dr[1] = "Điểm xuất tuyến";
                }
                else if (i == tb.Rows.Count - 1)
                {
                    dr[1] = "Điểm kết thúc tuyến";
                }
                else { dr[1] = "Điểm trung gian " + i.ToString(); }
                dr[2] = tb.Rows[i][2].ToString();
                dr[3] = tb.Rows[i][3].ToString();
                tt.Rows.Add(dr);
            }
            this.bindingSource1.DataSource = tt;
        }
        public static void FlashGeometry(IGeometry geometry, IRgbColor color, IDisplay display, System.Int32 delay)
        {
            if (geometry == null || color == null || display == null)
            {
                return;
            }

            display.StartDrawing(display.hDC, (System.Int16)esriScreenCache.esriNoScreenCache); // Explicit Cast
            switch (geometry.GeometryType)
            {
                case esriGeometryType.esriGeometryPolygon:
                    {
                        //Set the flash geometry's symbol.
                        ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
                        simpleFillSymbol.Color = color;
                        ISymbol symbol = simpleFillSymbol as ISymbol; // Dynamic Cast
                        symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

                        //Flash the input polygon geometry.
                        display.SetSymbol(symbol);
                        display.DrawPolygon(geometry);
                        System.Threading.Thread.Sleep(delay);
                        display.DrawPolygon(geometry);
                        break;
                    }
                case esriGeometryType.esriGeometryMultipoint:
                    {
                        //Set the flash geometry's symbol.
                        ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                        simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
                        simpleMarkerSymbol.Size = 12;
                        simpleMarkerSymbol.Color = color;
                        ISymbol symbol = simpleMarkerSymbol as ISymbol; // Dynamic Cast
                        symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

                        //Flash the input multipoint geometry.
                        display.SetSymbol(symbol);
                        display.DrawMultipoint(geometry);
                        System.Threading.Thread.Sleep(delay);
                        display.DrawMultipoint(geometry);
                        break;
                    }
            }
            display.FinishDrawing();
        }
        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            double X = double.Parse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "X").ToString());
            double Y = double.Parse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Y").ToString());
            //IPoint point = new PointClass() as IPoint;
            //point.PutCoords(X, Y);
            ////Geometry Interface to do actual project
            //IGeometry geometry;
            //geometry = point;
            //ESRI.ArcGIS.Display.IRgbColor rgbColor = new ESRI.ArcGIS.Display.RgbColorClass();
            //rgbColor.Red = 150;
            //rgbColor.Green = 0;
            //rgbColor.Blue = 0;

            //IDisplay display = QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView.ScreenDisplay;


            //FlashGeometry(geometry, rgbColor, display,10);
            IGraphicsContainer graphicsContainer = QLHTDT.FormChinh.KienTruc.axMapControl1.Map as IGraphicsContainer;
            IElement element = new TextElementClass();

            ITextElement textElement = new TextElementClass();
            //Create a text symbol.  
            ITextSymbol textSymbol = new TextSymbolClass();
            textSymbol.Size = 25;
            //Set the text element properties.  
            textElement.Symbol = textSymbol;
            textElement.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "STT").ToString();
            element = (IElement)textElement;


            IPoint pZoomCentre = new PointClass();
            element.Geometry = pZoomCentre;
            graphicsContainer.AddElement(element, 0);
            IActiveView activeView = QLHTDT.FormChinh.KienTruc.axMapControl1.Map as IActiveView;
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

            IEnvelope pExtent = QLHTDT.FormChinh.KienTruc.axMapControl1.Extent;
            pZoomCentre.PutCoords(X, Y);
            pZoomCentre.SpatialReference = pExtent.SpatialReference; // important to set spatial reference
            pExtent.CenterAt(pZoomCentre);

            QLHTDT.FormChinh.KienTruc.axMapControl1.Extent = pExtent;
            QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh(); // update view
        }
    }
}
