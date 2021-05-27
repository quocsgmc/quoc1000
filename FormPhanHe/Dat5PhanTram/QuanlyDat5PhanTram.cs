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

namespace QLHTDT.FormPhanHe.Dat5PhanTram.QuanlyDat5PhanTram
{
    public partial class QuanlyDat5PhanTram : Form
    {
        private ESRI.ArcGIS.Carto.IMap dmap;
        ILayer layeredit;
        int AddQuan = 0;
        bool ChinhSua = false;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        SqlDataAdapter dataAdapter2;
        SqlCommandBuilder cmbl1;
        public static int IDTram;
        string sql = "[PRC_QUERY_TABLE_Dat5PhanTram]";
        public static int ID1 ;
        public static int LoadLaiForm = 0;

        public static string MaHuyen = "null";
        string sql1 = "[PRC_QUERY_TABLE_Dat5PhanTram_By_ID] " + ID1 + "";
        string sqlQuan = "[PRC_Query_TenHuyen_By_MAHuyen] null";
        public QuanlyDat5PhanTram()
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

        private void QuanlyDat5PhanTram_Load(object sender, EventArgs e)
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
            bool ChinhSua = false;
            SqlDataAdapter adp = new SqlDataAdapter(sqlQuan, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboQuan.DataSource = ds.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            if (QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 2 || QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 3)
            {
                btChinhSua.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button6.Enabled = false;
                button1.Enabled = false;
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
        }
        public void ChinhSua_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (int.Parse(GridView1.FocusedRowHandle.ToString()) >= 0)
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString(), out ID1);
                QLHTDT.FormPhanHe.Dat5PhanTram.ChinhSuaDat5PhanTram frm = new QLHTDT.FormPhanHe.Dat5PhanTram.ChinhSuaDat5PhanTram();
                frm.Show();
            }
            Cursor = Cursors.Default;
        }
        private void DoRowDoubleClick(GridView view, System.Drawing.Point pt)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string IDPhuong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaXa").ToString();
                string layerget = "Địa chính";
                string tableKT = "TTKIENTRUC";
                int KTMoLop = 0;
                string PhuongKT = "Địa chính";
                try
                {
                    PhuongKT = "Địa chính";
                    for (int i1 = 0; i1 < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i1++)
                    {
                        if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == "Địa chính")
                        {
                            IFeatureLayer ilayer1 = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1) as IFeatureLayer;
                            KTMoLop = KTMoLop + 1;
                            layeredit = ilayer1;
                            KienTruc.axMapControl1.Extent = layeredit.AreaOfInterest;
                        }
                        else
                        {
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                layeredit = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1);
                                KienTruc.axMapControl1.Extent = KienTruc.axMapControl1.get_Layer(i1).AreaOfInterest;
                            }
                        }
                    }
                    if (KTMoLop == 0)
                    {
                        QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Dữ liệu dùng chung\\Địa chính.lyr");
                        QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        for (int i = 0; i < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i).Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                layeredit = FormChinh.KienTruc.axMapControl1.get_Layer(i);
                                //KienTruc.axMapControl1.Extent = KienTruc.axMapControl1.get_Layer(i).AreaOfInterest;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                ICommand command = new ControlsClearSelectionCommand();
                command.OnCreate(KienTruc.axMapControl1.Object);
                KienTruc.axMapControl1.CurrentTool = command as ITool;
                command.OnClick();

                if (layeredit != null)
                {
                    IFeatureLayer pFeatureLayer2 = (IFeatureLayer)layeredit;
                    IFeatureSelection featSelect = pFeatureLayer2 as IFeatureSelection;
                    IQueryFilter pFilter = new QueryFilterClass();
                    EnvelopeClass pEnvelope = new EnvelopeClass();
                    if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaXa").ToString() == "")
                    {
                        MessageBox.Show("Thông báo", "Chưa chọn phường cần tra cứu");

                    }
                    else if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaXa").ToString() != "")
                    {
                        if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SOTO").ToString() != "" && GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SOTHUA").ToString() != "")
                        {
                            pFilter.WhereClause = "[SoToBD] = '" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SOTO").ToString() + "' AND [SoThua] = '" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SOTHUA").ToString() + "' and IDPhuong = '" + IDPhuong + "'";
                            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);

                        }
                        else if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SOTO").ToString() != "" && GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SOTHUA").ToString() == "")
                        {
                            pFilter.WhereClause = "[SoToBD] = '" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SOTO").ToString() + "'and IDPhuong = '" + IDPhuong + "'";
                            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                        }
                        else if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SOTO").ToString() == "" && GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SOTHUA").ToString() != "")
                        {
                            pFilter.WhereClause = "[SoThua] = '" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SOTHUA").ToString() + "'and IDPhuong = '" + IDPhuong + "'";
                            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                        }
                        else
                        {
                            MessageBox.Show("Chưa chọn số tờ bản đồ hoặc số thửa đất cần tra cứu", "Thông báo");
                        }
                        ZoomToLayers();
                    }
                    IEnumIDs idList = featSelect.SelectionSet.IDs;
                    int index = idList.Next();
                    List<int> indexes = new List<int>();
                    while (index != -1)
                    {
                        indexes.Add(index);
                        index = idList.Next();
                    }
                    IFeatureClass featureClass = pFeatureLayer2.FeatureClass;

                    KienTruc.tt = new DataTable();
                    KienTruc.tt.Columns.Add("Mã", typeof(String));
                    KienTruc.tt.Columns.Add("Số tờ bản đồ", typeof(String));
                    KienTruc.tt.Columns.Add("Số thửa", typeof(String));
                    KienTruc.tt.Columns.Add("Diện tích", typeof(String));
                    KienTruc.tt.Columns.Add("Loại đất", typeof(String));
                    KienTruc.tt.Columns.Add("Phường", typeof(String));
                    KienTruc.tt.Columns.Add("Thông tin quy hoạch", typeof(String));
                    KienTruc.tt.Columns.Add("Phường1", typeof(String));
                    KienTruc.tt.Columns.Add("Loại đất1", typeof(String));
                    KienTruc.tt.Columns.Add("TenKhuVuc", typeof(String));
                    KienTruc.tt.Columns.Add("TangCaoXD", typeof(String));
                    KienTruc.tt.Columns.Add("ChiGioiXD", typeof(String));
                    KienTruc.tt.Columns.Add("ChieuCaoTang", typeof(String));
                    KienTruc.tt.Columns.Add("CotNen", typeof(String));
                    KienTruc.tt.Columns.Add("QDKhac", typeof(String));
                    KienTruc.tt.Columns.Add("SoGPXD", typeof(String));
                    KienTruc.tt.Columns.Add("TTCPXD", typeof(String));
                    KienTruc.tt.Columns.Add("MaHSCPXD", typeof(String));
                    if (featSelect.SelectionSet.Count == 0) { MessageBox.Show("Không có thửa đất nào", "Thông báo"); }
                    for (int i2 = 0; i2 < featSelect.SelectionSet.Count; i2++)
                    {
                        IFeature feature = featureClass.GetFeature(indexes[i2]);
                        KienTruc.dr = KienTruc.tt.NewRow();
                        KienTruc.dr[0] = feature.get_Value(feature.Fields.FindField("OBJECTID")).ToString();
                        if (feature.get_Value(feature.Fields.FindField("SoToBD")) != DBNull.Value)
                        {
                            KienTruc.dr[1] = feature.get_Value(feature.Fields.FindField("SoToBD")).ToString();
                        }
                        if (feature.get_Value(feature.Fields.FindField("SoThua")) != DBNull.Value)
                        {
                            KienTruc.dr[2] = feature.get_Value(feature.Fields.FindField("SoThua")).ToString();
                        }
                        if (feature.get_Value(feature.Fields.FindField("DienTich")) != DBNull.Value)
                        {
                            KienTruc.dr[3] = feature.get_Value(feature.Fields.FindField("DienTich")).ToString();
                        }
                        if (feature.get_Value(feature.Fields.FindField("LoaiDat")) != DBNull.Value)
                        {
                            KienTruc.dr[4] = feature.get_Value(feature.Fields.FindField("LoaiDat")).ToString();
                        }
                        if (feature.get_Value(feature.Fields.FindField("IDPhuong")) != DBNull.Value)
                        {
                            //KienTruc.dr[5] = feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString();
                            string IDPhuong1 = feature.get_Value(feature.Fields.FindField("IDPhuong")).ToString().Replace(" ", "");
                            SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            conn.Open();
                            string sql1 = "select TenPhuong from PhuongXa where PhuongXa.MaPhuong = '" + IDPhuong1 + "'";
                            SqlCommand command1 = new SqlCommand(sql1, conn);
                            if (command1.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[5] = (string)command1.ExecuteScalar();
                            }
                        }
                        if (feature.get_Value(feature.Fields.FindField("MaDuAnQH")) != DBNull.Value)
                        {
                            //KienTruc.dr[6] = feature.get_Value(feature.Fields.FindField("TenDuAn")).ToString();
                            string MaDuAnQH = feature.get_Value(feature.Fields.FindField("MaDuAnQH")).ToString().Replace(" ", "");
                            SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            conn.Open();
                            string sql1 = "select TenDuAn from RGDAQH where RGDAQH.MaDuAn = '" + MaDuAnQH + "'";
                            SqlCommand command1 = new SqlCommand(sql1, conn);
                            if (command1.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[6] = (string)command1.ExecuteScalar();
                            }
                        }
                        if (feature.get_Value(feature.Fields.FindField("MaKVKT")) != DBNull.Value)
                        {

                            string MaKT = feature.get_Value(feature.Fields.FindField("MaKVKT")).ToString().Replace(" ", "");
                            SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            conn.Open();
                            string sql1 = "SELECT [TenKhuVuc] FROM " + tableKT + " where MaKV = '" + MaKT + "'";
                            SqlCommand command1 = new SqlCommand(sql1, conn);
                            if (command1.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[9] = (string)command1.ExecuteScalar();
                            }
                            string sql2 = "SELECT [TangCaoXD] FROM " + tableKT + " where MaKV = '" + MaKT + "'";
                            SqlCommand command2 = new SqlCommand(sql2, conn);
                            if (command2.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[10] = (string)command2.ExecuteScalar();
                            }
                            string sql3 = "SELECT [ChiGioiXD] FROM " + tableKT + " where MaKV = '" + MaKT + "'";
                            SqlCommand command3 = new SqlCommand(sql3, conn);
                            if (command3.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[11] = (string)command3.ExecuteScalar();
                            }
                            string sql4 = "SELECT [ChieuCaoTang] FROM " + tableKT + " where MaKV = '" + MaKT + "'";
                            SqlCommand command4 = new SqlCommand(sql4, conn);
                            if (command4.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[12] = (string)command4.ExecuteScalar();
                            }
                            string sql5 = "SELECT [CotNen] FROM " + tableKT + " where MaKV = '" + MaKT + "'";
                            SqlCommand command5 = new SqlCommand(sql5, conn);
                            if (command5.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[13] = (string)command5.ExecuteScalar();
                            }
                            string sql6 = "SELECT [QDKhac] FROM " + tableKT + " where MaKV = '" + MaKT + "'";
                            SqlCommand command6 = new SqlCommand(sql6, conn);
                            if (command6.ExecuteScalar() != DBNull.Value)
                            {
                                KienTruc.dr[14] = (string)command6.ExecuteScalar();
                            }
                        }

                        KienTruc.tt.Rows.Add(KienTruc.dr);

                    }
                    if (featSelect.SelectionSet.Count > 1)
                    {
                        if (KienTruc.frm1Thua != null)
                        {
                            KienTruc.frm1Thua.Close();
                        }
                        if (KienTruc.frmNhieuThua != null)
                        {
                            KienTruc.frmNhieuThua.Close();
                            KienTruc.frmNhieuThua = new QLHTDT.FormPhu.FormChiTietLayer.FrmThuaDat2(KienTruc.tt, pFeatureLayer2);
                            KienTruc.frmNhieuThua.Show();
                        }
                        else
                        {
                            KienTruc.frmNhieuThua = new QLHTDT.FormPhu.FormChiTietLayer.FrmThuaDat2(KienTruc.tt, pFeatureLayer2);
                            KienTruc.frmNhieuThua.Show();
                        }
                    }
                    else if (featSelect.SelectionSet.Count == 1)
                    {
                        if (KienTruc.frmNhieuThua != null)
                        {
                            KienTruc.frmNhieuThua.Close();
                        }
                        if (KienTruc.frm1Thua != null)
                        {
                            KienTruc.frm1Thua.Close();
                            KienTruc.frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(KienTruc.tt);
                            KienTruc.frm1Thua.Show();
                        }
                        else
                        {
                            KienTruc.frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(KienTruc.tt);
                            KienTruc.frm1Thua.Show();
                        }

                    }
                    QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale * 4;
                    QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView.Refresh();

                }
                else { MessageBox.Show("Chưa chọn phường cần tra cứu", "Thông báo"); }

                Cursor = Cursors.Default;
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin", "Thông báo");
            }
        }
        private void ZoomToLayers()
        {
            ICommand command = new ControlsZoomToSelectedCommand();
            command.OnCreate(KienTruc.axMapControl1.Object);
            KienTruc.axMapControl1.CurrentTool = command as ITool;
            command.OnClick();
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
     
            if(comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
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
            textBox1.ResetText();
            textBox2.ResetText();
            comboBox2.ResetText();
            showgridControl1();
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GridView1.MoveNext();
            GridView1.MovePrev();
            cardView1.MoveNext();
            cardView1.MovePrev();

            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            bindingSource1.EndEdit();
            DataTable dt = (DataTable)bindingSource1.DataSource;
            dataAdapter1.Update(dt);

            SqlConnection connection1 = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter2 = new SqlDataAdapter(new SqlCommand(sql1, connection1));
            cmbl1 = new SqlCommandBuilder(dataAdapter2);
            bindingSource2.EndEdit();
            DataTable dt1 = (DataTable)bindingSource2.DataSource;
            dataAdapter1.Update(dt1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //string DinhKemQuan = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "QuanHuyen").ToString();
                //string DinhKemPhuong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenPhuong").ToString();
                //string path = Properties.Settings.Default.PathData + "\\Bưu chính - Viễn thông" + "\\" + DinhKemQuan + "\\" + DinhKemPhuong + "\\" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString();
                string path = Properties.Settings.Default.PathData + "\\Bưu chính - Viễn thông\\Trạm BTS" + "\\" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString();
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
                MessageBox.Show("Chưa chọn Trạm BTS cần đính kèm file. Vui lòng thử lại", "Thông báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhanHe.Dat5PhanTram.ThemMoiDat5PhanTram frm = new QLHTDT.FormPhanHe.Dat5PhanTram.ThemMoiDat5PhanTram();
            frm.ShowDialog(this);
            if (LoadLaiForm == 1)
            {
                showgridControl1();
                LoadLaiForm = 0;
            }
            Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (int.Parse(GridView1.FocusedRowHandle.ToString()) >= 0)
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString(), out ID1);
                QLHTDT.FormPhanHe.Dat5PhanTram.QuanlyBenThueDat.QuanlyBenThueDat frm = new QLHTDT.FormPhanHe.Dat5PhanTram.QuanlyBenThueDat.QuanlyBenThueDat();
                frm.Show();
            }
            Cursor = Cursors.Default;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (MoRong == 0)
            {
                this.ClientSize = new System.Drawing.Size(440, 795);
                MoRong = 1;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen2;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(765, 795);
                MoRong = 0;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen;
            }
        }
        int MoRong = 1;
        private void button5_Click(object sender, EventArgs e)
        {
            if(MoRong == 0)
            {
                this.ClientSize = new System.Drawing.Size(440, 795);
                MoRong = 1;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen2;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(765, 795);
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
                    int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString(), out ID1);
                    sql1 = "[PRC_QUERY_TABLE_Dat5PhanTram_By_ID] " + ID1 + "";
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
            if (MessageBox.Show("Bạn muốn xóa Cấp phép được chọn " + " không?", "Xóa dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString(), out ID1);
                try
                {
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string Delelequery = "[PRC_DELETE_Dat5PhanTram] " + ID1 + "";
                    SqlCommand cmd1 = new SqlCommand(Delelequery, conn);
                    cmd1.ExecuteNonQuery();
                    showgridControl1();
                    MessageBox.Show("Xóa hồ sơ thành công", "Thông báo");
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn hồ sơ cần xóa", "Thông báo");
                }
            }
      

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;

            view.ActiveFilter.Add(view.Columns["SOTO"],
              new ColumnFilterInfo("[SOTO] like '%" + textBox1.Text + "%'", ""));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;

            view.ActiveFilter.Add(view.Columns["SOTHUA"],
              new ColumnFilterInfo("[SOTHUA] like '%" + textBox2.Text + "%'", ""));
        }
    }
}
