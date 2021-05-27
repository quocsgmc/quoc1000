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

namespace QLHTDT.FormPhanHe.HoChua.QuanlyKenhChinh
{
    public partial class QuanlyKenhChinh : Form
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
        string sql = "[PRC_QUERY_TABLE_KenhChinh]";
        public static int ID1 ;
        public static int LoadLaiForm = 0;

        public static string MaHuyen = "null";
        string sql1 = "[PRC_QUERY_TABLE_KenhChinh_BY_ID] " + ID1 + "";
        string sqlQuan = "[PRC_Query_TenHuyen_By_MAHuyen] null";
        string sqlChuDauTu = "PRC_QUERY_TABLE_ChuDauTu";
        public QuanlyKenhChinh()
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map;
        }
        public QuanlyKenhChinh(int IDHo)
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map;
            sql1 = "PRC_QUERY_TABLE_KenhChinh_BY_ID " + IDHo + "";
            showgridControl2(sql1);
        }
        

        private void QuanlyKenhChinh_Load(object sender, EventArgs e)
        {
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            bindingNavigator1.Visible = false;
            showgridControl1();
            if (ID1 != 0)
            {
                showgridControl2(sql1);
            }

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
            //dataAdapter1.Fill(tb);
            //this.bindingSource1.DataSource = tb;
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
        public void ChinhSua_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (int.Parse(cardView1.FocusedRowHandle.ToString()) >= 0)
            {
                int.TryParse(cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "IDKenh").ToString(), out ID1);
                QLHTDT.FormPhanHe.HoChua.ChinhSua.ChinhSuaKenhChinh frm = new QLHTDT.FormPhanHe.HoChua.ChinhSua.ChinhSuaKenhChinh();
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
                    if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == "Kênh chính")
                    {
                        IFeatureLayer ilayer1 = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1) as IFeatureLayer;
                        KTMoLop = KTMoLop + 1;
                        int ID;
                        int.TryParse(cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "IDKenh").ToString(), out ID);
                        if (ID == 0)
                        {
                            Cursor = Cursors.WaitCursor;
                            MessageBox.Show("Không có dữ liệu không gian Kênh chính này", "Thông báo");
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
                    DialogResult dialogResult = MessageBox.Show("Chưa mở lớp dữ liệu không gian Kênh chính \n" + "Có muốn mở lớp dữ liệu này hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Bưu chính - Viễn thông\\Trạm BTS.lyr");
                        QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                        for (int i = 0; i < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i).Name == "Kênh chính")
                            {
                                KTMoLop = KTMoLop + 1;
                                IFeatureLayer ilayer = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i) as IFeatureLayer;
                                int ID;
                                int.TryParse(cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "IDKenh").ToString(), out ID);
                                if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian Kênh chính", "Thông báo"); }
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

        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
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
                string path = Properties.Settings.Default.PathData + "\\Bưu chính - Viễn thông\\Trạm BTS" + "\\" + cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "OBJECTID").ToString();
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
            QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.ThemMoiMotTram frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.ThemMoiMotTram();
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
            QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.ThemMoiTuFileExcel frm = new QLHTDT.FormPhanHe.BuuChinh_VienThong.TramBTS.ThemMoiTuFileExcel();
            frm.ShowDialog(this);
            if (LoadLaiForm == 1)
            {
                showgridControl1();
                LoadLaiForm = 0;
            }
            Cursor = Cursors.Default;
        }

        private void comboQuan_SelectedValueChanged(object sender, EventArgs e)
        {   

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa Kênh chính được chọn " + " không?", "Xóa dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int.TryParse(cardView1.GetRowCellValue(cardView1.FocusedRowHandle, "IDKenh").ToString(), out ID1);
                try
                {
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string Delelequery = "[PRC_DELETE_KenhChinh] " + ID1 + "";
                    SqlCommand cmd1 = new SqlCommand(Delelequery, conn);
                    cmd1.ExecuteNonQuery();
                    showgridControl1();
                    MessageBox.Show("Xóa Kênh chính thành công", "Thông báo");
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn Kênh chính cần xóa", "Thông báo");
                }
            }
      

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
