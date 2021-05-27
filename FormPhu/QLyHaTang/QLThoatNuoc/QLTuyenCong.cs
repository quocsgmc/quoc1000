using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.QLThoatNuoc
{
    public partial class QLTuyenCong : Form
    {
        public QLTuyenCong()
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map;
        }

        private void QLTuyenCong_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;
            bindingNavigator1.Visible = false;
            showgridControl1();
        }
        private AxMapControl mMapControl;
        private ESRI.ArcGIS.Carto.IMap dmap;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;

        private void BtTracuu_Click(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["CapCong"],
              new ColumnFilterInfo("[CapCong] like '%" + txtCapCong.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["MaCong"],
            new ColumnFilterInfo("[MaCong] = " + txtMaCong + "", ""));
            view.ActiveFilter.Add(view.Columns["TenDuong"],
           new ColumnFilterInfo("[TenDuong] = " + txtTenDuong + "", ""));

        }

        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            txtCapCong.ResetText();
            txtMaCong.ResetText();
            txtTenDuong.ResetText();

            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
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
        void showgridControl1()
        {
            tb = new DataTable();
            tbcheck = new DataTable();
            string sql = "select * from "; //Thêm vào dữ liệu tuyến cống SQL
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
        }
        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GridView view = (GridView)sender;
            System.Drawing.Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            DoRowDoubleClick(view, pt);
            Cursor = Cursors.Default;
        }
        private void DoRowDoubleClick(GridView view, System.Drawing.Point pt)
        {
            //
        }

        private void cboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["Phuong"],
             new ColumnFilterInfo("[Phuong] like '%" + cboPhuong.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["CapCong"],
            new ColumnFilterInfo("[CapCong] like '%" + txtCapCong.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["MaCong"],
            new ColumnFilterInfo("[MaCong] = " + txtMaCong + "", ""));
            view.ActiveFilter.Add(view.Columns["TenDuong"],
            new ColumnFilterInfo("[TenDuong] = " + txtTenDuong + "", ""));

        }
    }
}
