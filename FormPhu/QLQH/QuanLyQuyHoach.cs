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
using QLHTDT.FormPhu.QLKienTruc;
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
using DevExpress.Data.Filtering;

namespace QLHTDT.FormPhu.QLQH
{
    public partial class QuanlyQuyHoach : Form
    {
        private ESRI.ArcGIS.Carto.IMap dmap;
        ILayer layeredit;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        SqlDataAdapter dataAdapter2;
        SqlCommandBuilder cmbl1;
        public static int IDTram;
        string sql = "SELECT *,(select QH.TENHUYEN from Quan QH where QH.MAHUYEN = IDHuyen) as QuanHuyen,(select Xa.TenPhuong from PhuongXa Xa where Xa.MaPhuong = IDPhuong)  as TenPhuong FROM HoSoCapChungChiQH order by NgayNopDon DESC";
        public static int ID1 ;
        public static int LoadLaiForm = 0;

        public static string MaHuyen = "null";
        string sql1 = "[PRC_QUERY_HoSoChungChiQH_BY_ID] '" + ID1 + "'";
        public QuanlyQuyHoach()
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
                    //BeginInvoke(new MethodInvoker(delegate { cal(_Width, GridView1); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                //BeginInvoke(new MethodInvoker(delegate { cal(_Width, GridView1); }));
            }
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void QuanlyQuyHoach_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            bindingNavigator1.Visible = false;
            showgridControl1();
            if (ID1 != 0)
            {
                showgridControl2(sql1);
            }

            //Phân quyền người dùng
            if (QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 2 || QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 3)
            {
                btThemMoi.Enabled = false;
                btChinhSua.Enabled = false;
                btXoa.Enabled = false;
                btCapNhatQD.Enabled = false;
                btXuLyHoSo.Enabled = false;
                btFileDinhKem.Enabled = false;
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
        }
        public void ChinhSua_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QLQH.ThemHoSoCapCCQH frmThemHS = new QLHTDT.FormPhu.QLQH.ThemHoSoCapCCQH();
            frmThemHS.ShowDialog();
            showgridControl1();
            frmThemHS.FormClosed += new FormClosedEventHandler(frmThemHS_closed);
            Cursor = Cursors.Default;
        }
        private void frmThemHS_closed(object sender, FormClosedEventArgs e)
        {
            showgridControl1();
        }
       
        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            TinhTrang.ResetText();
            textBoxNguoiGui.ResetText();
            textBoxDiaChi.ResetText();
            checkBox1.Checked = false;
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
            string path = Properties.Settings.Default.PathData + "\\FileDinhKemXNQH\\HS" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString();
            if (Directory.Exists(path))
            {
                QLHTDT.FormPhu.QLQH.listfilefolder frm = new listfilefolder(path);
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
                    openFileDialog.ShowDialog();
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (MoRong == 0)
            {
                this.ClientSize = new System.Drawing.Size(518, 795);
                MoRong = 1;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen2;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(840, 795);
                MoRong = 0;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen;
            }
        }


        int MoRong = 1;
        private void button5_Click(object sender, EventArgs e)
        {
            if(MoRong == 0)
            {
                this.ClientSize = new System.Drawing.Size(515, 795);
                MoRong = 1;
                this.button5.Image = global::QLHTDT.Properties.Resources.MuiTen2;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(840, 795);
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
                    int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString(), out ID1);
                    sql1 = "SELECT * FROM HoSoCapChungChiQH where MaHS = '" + ID1 + "'";
                    showgridControl2(sql1);
                }
                catch
                {
                    MessageBox.Show("Không có dữ liệu, vui lòng chọn lại", "Thông báo");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            if (Properties.Settings.Default.pathPDF != null)
            {
                openFileDialog.InitialDirectory = Properties.Settings.Default.pathPDF;
            }
            else { openFileDialog.InitialDirectory = @"C:\"; }
            openFileDialog.Filter = "file pdf (*.pdf)|*.pdf";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.pathPDF = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                CapNhatSoGPQH frmCapNhatSoGP = new CapNhatSoGPQH();
                frmCapNhatSoGP.ShowDialog();
                if (frmCapNhatSoGP.Visible == false && CapNhatSoGPQH.SoGP != "")
                {
                    try
                    {
                        string sql = "select * from HoSoCapChungChiQH";
                        SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        SqlCommand command = new SqlCommand(sql, connection);
                        command.Connection.Open();
                        string querystr = "UPDATE HoSoCapChungChiQH SET SOGXNQH ='" + CapNhatSoGPQH.SoGP + "' FROM [HoSoCapChungChiQH] WHERE [SoToBD] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + " and [SoThua] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + " and [IDPhuong] = N'" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDPhuong").ToString() + "' AND MaHS = (SELECT max(MaHS) FROM HoSoCapChungChiQH where [SoToBD] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "')";
                        SqlCommand query = new SqlCommand(querystr, connection);
                        string folder = Properties.Settings.Default.PathData + "\\FileDinhKemXNQH\\HS" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString();
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }
                        string file = Properties.Settings.Default.PathData + "\\FileDinhKemXNQH\\HS" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString() + "\\XNQH" + CapNhatSoGPQH.SoGP + ".pdf";
                        if (!File.Exists(file))
                        {
                            query.ExecuteNonQuery();

                            DataTable tbupdate = new DataTable();
                            string sqlupdate = "SELECT * FROM HoSoCapChungChiQH";
                            SqlConnection connectionupdate = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand(sqlupdate, connectionupdate));
                            SqlCommandBuilder cmbl = new SqlCommandBuilder(dataAdapter1);
                            dataAdapter1.Fill(tbupdate);
                            this.bindingSource1.DataSource = tbupdate;

                            System.IO.File.Copy(openFileDialog.FileName, file);
                            string querystr2 = "UPDATE HoSoCapChungChiQH SET [TinhTrang] =N'Đã có kết quả'  FROM HoSoCapChungChiQH WHERE [SoToBD] =" + cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SoToBD").ToString() + " and [SoThua] =" + cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SoThua").ToString() + " and [IDPhuong] = N'" + cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "IDPhuong").ToString() + "' AND MaHS = (SELECT max(MaHS) FROM HoSoCapChungChiQH where [SoToBD] ='" + cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] ='" + cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SoThua").ToString() + "')";
                            SqlCommand query2 = new SqlCommand(querystr2, connection);
                            query2.ExecuteNonQuery();
                            string querystr3 = "UPDATE HoSoCapChungChiQH SET NgayCapXNQH = '" + CapNhatSoGPQH.Nam + "-" + CapNhatSoGPQH.Thang + "-" + CapNhatSoGPQH.Ngay + "' FROM HoSoCapChungChiQH WHERE [SoToBD] =" + cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SoToBD").ToString() + " and [SoThua] =" + cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SoThua").ToString() + " and [IDPhuong] = N'" + cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "IDPhuong").ToString() + "' AND MaHS = (SELECT max(MaHS) FROM HoSoCapChungChiQH where [SoToBD] ='" + cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] ='" + cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SoThua").ToString() + "')";
                            SqlCommand query3 = new SqlCommand(querystr3, connection);
                            query3.ExecuteNonQuery();
                            command.Connection.Close();
                            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                            showgridControl1();
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Đã có dữ liệu này, có muốn thay thế hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                query.ExecuteNonQuery();

                                DataTable tbupdate = new DataTable();
                                string sqlupdate = "SELECT * FROM HoSoCapChungChiQH";
                                SqlConnection connectionupdate = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand(sqlupdate, connectionupdate));
                                SqlCommandBuilder cmbl = new SqlCommandBuilder(dataAdapter1);
                                dataAdapter1.Fill(tbupdate);
                                this.bindingSource1.DataSource = tbupdate;

                                System.IO.File.Copy(openFileDialog.FileName, file, true);
                                string querystr2 = "UPDATE HoSoCapChungChiQH SET [TinhTrang] =N'Đã có kết quả' FROM HoSoCapChungChiQH WHERE [SoToBD] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + " and [SoThua] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + " and [IDPhuong] = N'" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDPhuong").ToString() + "' AND MaHS = (SELECT max(MaHS) FROM HoSoCapChungChiQH where [SoToBD] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "')";
                                SqlCommand query2 = new SqlCommand(querystr2, connection);
                                query2.ExecuteNonQuery();
                                string querystr3 = "UPDATE HoSoCapChungChiQH SET NgayCapXNQH = '" + CapNhatSoGPQH.Nam + "-" + CapNhatSoGPQH.Thang + "-" + CapNhatSoGPQH.Ngay + "' FROM HoSoCapChungChiQH WHERE [SoToBD] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + " and [SoThua] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + " and [Phuong] = N'" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Phuong").ToString() + "' AND MaHS = (SELECT max(MaHS) FROM HoSoCapChungChiQH where [SoToBD] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "')";
                                SqlCommand query3 = new SqlCommand(querystr3, connection);
                                query3.ExecuteNonQuery();
                                command.Connection.Close();
                                showgridControl1();
                                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                            }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
        public static DataTable dt;
        public static DataRow dr;
        private IFeatureLayer fLayer;
        IFeature pFeature;
        private void GridView1_DoubleClick_1(object sender, EventArgs e)
        {
            ViTriTDat(true);
        }
        private void ViTriTDat(bool ThongTinThua)
        {
            try
            {
                string IDPhuong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDPhuong").ToString();
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
                                KienTruc.axMapControl1.Extent = KienTruc.axMapControl1.get_Layer(i).AreaOfInterest;
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
                    if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDPhuong").ToString() == "")
                    {
                        MessageBox.Show("Thông báo", "Chưa chọn phường cần tra cứu");

                    }
                    else if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDPhuong").ToString() != "")
                    {
                        if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() != "" && GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() != "")
                        {
                            pFilter.WhereClause = "[SoToBD] = '" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' AND [SoThua] = '" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "' and IDPhuong = '" + IDPhuong + "'";
                            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);

                        }
                        else if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() != "" && GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() == "")
                        {
                            pFilter.WhereClause = "[SoToBD] = '" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "'and IDPhuong = '" + IDPhuong + "'";
                            featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                        }
                        else if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoTo").ToString() == "" && GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() != "")
                        {
                            pFilter.WhereClause = "[SoThua] = '" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "'and IDPhuong = '" + IDPhuong + "'";
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

        private void GridView1_Click_1(object sender, EventArgs e)
        {
            if (int.Parse(GridView1.FocusedRowHandle.ToString()) >= 0)
            {
                try
                {
                    string Caption = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NguoiGui").ToString();
                    cardView1.CardCaptionFormat = Caption;
                    int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString(), out ID1);
                    sql1 = "[PRC_QUERY_HoSoChungChiQH_BY_ID] '" + ID1 + "'";
                    showgridControl2(sql1);
                }
                catch
                {
                    MessageBox.Show("Không có dữ liệu, vui lòng chọn lại", "Thông báo");
                }
            }
           
            //if (GridView1.SelectedRowsCount != 0)
            //{
            //    btFileDinhKem.Enabled = true;
            //}
            if (QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 1 || QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 0)
            {
                if (GridView1.SelectedRowsCount != 0 && GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Chưa xử lý")
                { btXuLyHoSo.Enabled = true; }
                else { btXuLyHoSo.Enabled = false; }

                if (GridView1.SelectedRowsCount != 0 && GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Chưa xử lý")
                { btXuLyHoSo.Enabled = true; }
                else { btXuLyHoSo.Enabled = false; }

                if (GridView1.SelectedRowsCount != 0 && (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Đang trình phê duyệt") | GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Đã có kết quả")
                { btCapNhatQD.Enabled = true; }
                else { btCapNhatQD.Enabled = false; }

                if (GridView1.SelectedRowsCount != 0 && (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Đã có kết quả") | GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Đã có kết quả")
                { btChinhSua.Enabled = false; }
                else { btChinhSua.Enabled = true; }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (MoRong == 0)
            {
                this.ClientSize = new System.Drawing.Size(518, 795);
                MoRong = 1;
                this.button3.Image = global::QLHTDT.Properties.Resources.MuiTen2;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(840, 795);
                MoRong = 0;
                this.button3.Image = global::QLHTDT.Properties.Resources.MuiTen;
            }
        }

        private void TinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["TinhTrang"],
              new ColumnFilterInfo("[TinhTrang] like '%" + TinhTrang.Text + "%'", ""));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                var date = DateTime.Now;
                string Day = date.Day.ToString();
                string Month = date.Month.ToString();
                string Yeah = date.Year.ToString();
                GridView1.ActiveFilterString = (new OperandProperty("NgayNopDon") == DateTime.Today).ToString();
                if (TinhTrang.Text != null)
                {
                    ColumnView view = GridView1;
                    view.ActiveFilter.Add(view.Columns["NgayNopDon"],
                      new ColumnFilterInfo("[NgayNopDon] like '%" + Month + "/" + Day + "/" + Yeah + "%'", ""));
                    view.ActiveFilter.Add(view.Columns["TinhTrang"],
                      new ColumnFilterInfo("[TinhTrang] like '%" + TinhTrang.Text + "%'", ""));
                }
            }
            else
            {
                GridView1.ClearColumnsFilter();

            }
        }

        private void textBoxNguoiGui_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["NguoiGui"],
              new ColumnFilterInfo("[NguoiGui] like '%" + textBoxNguoiGui.Text + "%'", ""));
        }

        private void textBoxDiaChi_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["DiaChiThuaDat"],
              new ColumnFilterInfo("[DiaChiThuaDat] like '%" + textBoxDiaChi.Text + "%'", ""));
        }

        private void btXuLyHoSo_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string nguoigui = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "NguoiGui").ToString();
            //    string hokhau = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "HoKhauThuongTru").ToString();
            //    string nams = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "NamSinh").ToString();
            //    string sdtcodinh = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SDT").ToString();
            //    string sdtdidong = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SDT").ToString();
            //    string vitrithuadat = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "DiaChiThuaDat").ToString();
            //    string soto = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SoToBD").ToString();
            //    string sothua = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SoThua").ToString();
            //    string to = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "ToDanPho").ToString();
            //    string phuong = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "TenPhuong").ToString();
            //    string quan = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "QuanHuyen").ToString();
            //    string mucdich = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "MucDich").ToString();
            //    string MaHS = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "MaHS").ToString();
            //    string ngaycapGCN = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "NgayCapGCN").ToString();
            //    string photoGCN = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "PhoToGCN").ToString();
            //    QLHTDT.FormPhu.QLQH.DangKyCapCCQH frmThemHS = new QLHTDT.FormPhu.QLQH.DangKyCapCCQH(nguoigui, hokhau, nams, sdtcodinh, sdtdidong, vitrithuadat, soto, sothua, to,quan, phuong, mucdich, MaHS, ngaycapGCN, photoGCN);
            //    frmThemHS.ShowDialog();
            //    showgridControl1();
            //    frmThemHS.FormClosed += new FormClosedEventHandler(frmThemHS_closed);

            //}
            //catch
            //{

            //}

            Cursor = Cursors.WaitCursor;
            if (int.Parse(GridView1.FocusedRowHandle.ToString()) >= 0)
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString(), out ID1);
                QLHTDT.FormPhu.QLQH.DangKyCapCCQH frm = new QLHTDT.FormPhu.QLQH.DangKyCapCCQH();
                frm.Show();
            }
            Cursor = Cursors.Default;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    string nguoigui = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "NguoiGui").ToString();
            //    string hokhau = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "HoKhauThuongTru").ToString();
            //    string nams = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "NamSinh").ToString();
            //    string sdtcodinh = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SDT").ToString();
            //    string sdtdidong = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SDT").ToString();
            //    string vitrithuadat = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "DiaChiThuaDat").ToString();
            //    string soto = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SoToBD").ToString();
            //    string sothua = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "SoThua").ToString();
            //    string to = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "ToDanPho").ToString();
            //    string phuong = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "IDPhuong").ToString();
            //    string mucdich = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "MucDich").ToString();
            //    string MaHS = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "MaHS").ToString();
            //    string ngaycapGCN = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "NgayCapGCN").ToString();
            //    string photoGCN = cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "PhoToGCN").ToString();   
            //    QLHTDT.FormPhu.QLQH.ChinhSuaHoSoQH frmThemHS = new QLHTDT.FormPhu.QLQH.ChinhSuaHoSoQH(nguoigui, hokhau, nams, sdtcodinh, sdtdidong, vitrithuadat, soto, sothua, to, phuong, mucdich, MaHS, ngaycapGCN, photoGCN);
            //    frmThemHS.ShowDialog();
            //    showgridControl1();
            //    frmThemHS.FormClosed += new FormClosedEventHandler(frmThemHS_closed);
            //}
            //catch
            //{

            //}
            Cursor = Cursors.WaitCursor;
            if (int.Parse(GridView1.FocusedRowHandle.ToString()) >= 0)
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString(), out ID1);
                var date = DateTime.Now;
                QLHTDT.FormPhu.QLQH.ChinhSuaHoSoQH frm = new QLHTDT.FormPhu.QLQH.ChinhSuaHoSoQH();
                frm.Show();
            }
            Cursor = Cursors.Default;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa Hồ sơ quy hoạch được chọn " + " không?", "Xóa dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString(), out ID1);
                try
                {
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string Delelequery = "[PRC_DELETE_HoSoQuyHoach_BY_ID] " + ID1 + "";
                    SqlCommand cmd1 = new SqlCommand(Delelequery, conn);
                    cmd1.ExecuteNonQuery();
                    showgridControl1();
                    MessageBox.Show("Xóa Hồ sơ quy hoạch thành công", "Thông báo");
                    //Phần này là lưu nhật ký
                    KienTruc.TBNK = new DataTable();
                    SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                    cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                    KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                    KienTruc.XoaDoiTuong("Hồ sơ chứng chỉ quy hoạch", ID1);
                    KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn Hồ sơ quy hoạch cần xóa", "Thông báo");
                }
            }
        }
    }
}
