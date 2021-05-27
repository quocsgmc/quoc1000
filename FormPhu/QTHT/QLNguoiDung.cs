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
    public partial class QLNguoiDung : Form
    {
        DataTable tb;
        SqlDataAdapter dataAdapter1;
        DataTable tb2;
        SqlDataAdapter dataAdapter2;
        SqlCommandBuilder cmbl;
        public QLNguoiDung()
        {
            InitializeComponent();
            gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView2_CustomDrawRowIndicator);
            //GridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView1_CustomDrawRowIndicator);

        }
        public QLNguoiDung(int MaPhongBan)
        {
            InitializeComponent();
            tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand("select * from [User] where MaPhongBan = "+ MaPhongBan + "", connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
        }
        void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView2.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView2); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView2); }));
            }
        }
        //void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        //{
        //    if (!GridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
        //    {
        //        if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
        //        {
        //            if (e.RowHandle < 0)
        //            {
        //                e.Info.ImageIndex = 0;
        //                e.Info.DisplayText = string.Empty;
        //            }
        //            else
        //            {
        //                e.Info.ImageIndex = -1; //Không hiển thị hình
        //                e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
        //            }
        //            SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
        //            Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
        //            BeginInvoke(new MethodInvoker(delegate { cal(_Width, GridView1); })); //Tăng kích thước nếu Text vượt quá
        //        }
        //    }
        //    else
        //    {
        //        e.Info.ImageIndex = -1;
        //        e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
        //        SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
        //        Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
        //        BeginInvoke(new MethodInvoker(delegate { cal(_Width, GridView1); }));
        //    }
        //}
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.QTHT.PhanQuyenTruyCap frm = new QLHTDT.FormPhu.QTHT.PhanQuyenTruyCap();
            //frm.show();
            frm.ShowDialog();
        }

        private void QLNguoiDung_Load(object sender, EventArgs e)
        {
            //GridView1.OptionsBehavior.Editable = false;
            gridView2.OptionsBehavior.Editable = false;
            //bindingSource1.DataSource = 
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            //bindingNavigator1.Visible = false;
            //bindingNavigator2.Visible = false;
            showgridControl2();
            showgridControl1();
            //using (SqlConnection connection = new SqlConnection(connectString))
            //{

            //    SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand("Select * From tblLogin", connection));
            //    DataSet ds = new DataSet("Northwind Customers");
            //    ds.Tables.Add("tblLogin");
            //    dataAdapter1.Fill(ds.Tables["tblLogin"]);

            //    // Assign the DataSet as the DataSource for the BindingSource.
            //    this.bindingSource1.DataSource = ds.Tables["tblLogin"];

            //    // Bind the CompanyName field to the TextBox control.

            //}
        }

        private void Btsave_Click(object sender, EventArgs e)
        {
            try 
            {
                gridView2.ActiveFilter.Clear();
                SqlConnection conn;
                SqlCommand command;
                conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                conn.Open();
                string sql = "";
                command = new SqlCommand(sql, conn);


                dataAdapter2.Update((DataTable)bindingSource2.DataSource);
                dataAdapter1.Update((DataTable)bindingSource1.DataSource);
                
                
            }
            catch (Exception ex) 
            { MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            bindingSource1.ResetBindings(false);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int IDUser = 0;
            QLHTDT.FormPhu.QTHT.EditUser frm = new QLHTDT.FormPhu.QTHT.EditUser();
            int.TryParse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "IDNguoiDung").ToString(), out IDUser);
            if (IDUser != 0)
            {
                frm = new QLHTDT.FormPhu.QTHT.EditUser(IDUser);
                frm.TopMost = true;
                frm.ShowDialog();
            }
            Cursor = Cursors.Default;
          if (frm.Visible == false)
            {
                refreshdata();
            }


        }


        void showgridControl1()
        {
            tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand("PRC_QUERY_USER null", connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
            tb.Rows[1][1].ToString();
            //foreach (DataRow dr in dt.Rows) 
            //{
            //    int n = gridView2.AddNewRow();
            //}
        }

        void refreshdata()
        {
            showgridControl1();
            //GridControl1.Refresh();
            gridControl2.Refresh();
            gridView2.RefreshData();
            //GridView1.RefreshData();
            ColumnView view = gridView2;
            view.ActiveFilter.Clear();
        }
        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            //GridControl1.Refresh();
            gridControl2.Refresh();
            gridView2.RefreshData();
            //GridView1.RefreshData();
            ColumnView view = gridView2;
            view.ActiveFilter.Clear();
        }
        void showgridControl2()
        {
            tb2 = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter2 = new SqlDataAdapter(new SqlCommand("Select * From [PhongBanWEB]", connection));
            cmbl = new SqlCommandBuilder(dataAdapter2);
            dataAdapter2.Fill(tb2);
            this.bindingSource2.DataSource = tb2;
        }
                
        private void btDel_Click(object sender, EventArgs e)
        {
            int ID;
            if (MessageBox.Show("Bạn muốn xóa người dùng đã chọn không?", "Xóa dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int.TryParse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "IDNguoiDung").ToString(), out ID);
                try
                {
                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string Delelequery = "[PRC_DELETE_USER] " + ID + "";
                    SqlCommand cmd1 = new SqlCommand(Delelequery, conn);
                    cmd1.ExecuteNonQuery();
                    showgridControl1();
                    //Phần này là lưu nhật ký
                    KienTruc.TBNK = new DataTable();
                    SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                    SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                    KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                    KienTruc.XoaDoiTuong("Người dùng", ID);
                    KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                    MessageBox.Show("Xóa người dùng thành công", "Thông báo");
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần xóa", "Thông báo");
                }
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            QLHTDT.FormPhu.QTHT.InsertUSER frm = new QLHTDT.FormPhu.QTHT.InsertUSER();
            frm.ShowDialog();
            Cursor = Cursors.Default;
            if (frm.Visible == false)
            {
                refreshdata();
            }
        }




    }
}
