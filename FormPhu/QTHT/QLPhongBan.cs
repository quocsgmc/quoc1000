using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Base;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using QLHTDT.FormChinh;

namespace QLHTDT.FormPhu.QTHT
{
    public partial class QLPhongBan : Form
    {
        DataTable tb;
        SqlDataAdapter dataAdapter;
        SqlCommandBuilder cmbl;
        public QLPhongBan()
        {
            InitializeComponent();
            showgridControl2();
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
        void showgridControl2()
        {
            tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter = new SqlDataAdapter(new SqlCommand("[PRC_QUERY_PHONGBAN] null", connection));
            cmbl = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(tb);
            this.bindingSource1.DataSource = tb;
            //foreach (DataRow dr in dt.Rows) 
            //{
            //    int n = gridView2.AddNewRow();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QTHT.InsertPhongban frm = new QLHTDT.FormPhu.QTHT.InsertPhongban();
            frm.ShowDialog();
            Cursor = Cursors.Default;
            if (frm.Visible == false)
            {
                showgridControl2();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int IDUser = 0;
            QLHTDT.FormPhu.QTHT.EditPhongBan frm = new QLHTDT.FormPhu.QTHT.EditPhongBan();
            int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaPhongBan").ToString(), out IDUser);
            if (IDUser != 0)
            {
                frm = new QLHTDT.FormPhu.QTHT.EditPhongBan(IDUser);
                frm.TopMost = true;
                frm.ShowDialog();
            }
            Cursor = Cursors.Default;
            if (frm.Visible == false)
            {
                showgridControl2();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID;
            if (MessageBox.Show("Bạn muốn xóa phòng ban đã chọn không?", "Xóa dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaPhongBan").ToString(), out ID);
                try
                {
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string Delelequery = "[PRC_DELETE_PHONGBAN] " + ID + "";
                    SqlCommand cmd1 = new SqlCommand(Delelequery, conn);
                    cmd1.ExecuteNonQuery();
                    showgridControl2();
                    //Phần này là lưu nhật ký
                    KienTruc.TBNK = new DataTable();
                    SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                    SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                    KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                    KienTruc.XoaDoiTuong("Phòng ban", ID);
                    KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                    MessageBox.Show("Xóa phòng ban thành công", "Thông báo");
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần xóa", "Thông báo");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int IDUser = 0;
            int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaPhongBan").ToString(), out IDUser);
            if (IDUser != 0)
            {
                QLHTDT.FormPhu.QTHT.QLNguoiDung_PhongBan frm = new QLHTDT.FormPhu.QTHT.QLNguoiDung_PhongBan(IDUser);
                frm.TopMost = true;
                frm.ShowDialog();
            }
            Cursor = Cursors.Default;
        }
    }
}
