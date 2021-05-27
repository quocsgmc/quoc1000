using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace QLHTDT.FormPhu.QTHT
{
    public partial class NhatKi : Form
    {
        DataTable tb;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public NhatKi()
        {
            InitializeComponent();

            gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView2_CustomDrawRowIndicator);
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
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void NhatKi_Load(object sender, EventArgs e)
        {
            gridView2.OptionsBehavior.Editable = false;
            
            //bindingSource1.DataSource = 
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            bindingNavigator1.Visible = false;
            showgridControl1();

            
        }
        void showgridControl1()
        {
            tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
            
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn;
                SqlCommand command;
                conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                conn.Open();
                string sql = "";
                command = new SqlCommand(sql, conn);
                dataAdapter1.Update((DataTable)bindingSource1.DataSource);
                MessageBox.Show("Cập nhật thành công","Thông báo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bindingSource1.ResetBindings(false);
            }
        }

        private void Btsave_Click(object sender, EventArgs e)
        {
            
            if (BtChinhSua.Text == "Chỉnh sửa")
            {
                gridView2.OptionsBehavior.Editable = true;
                bindingNavigator1.Visible = true;
                BtChinhSua.Text = "Tắt chỉnh sửa";
                
            }
            else
            {
                BtChinhSua.Text = "Chỉnh sửa";
                gridView2.OptionsBehavior.Editable = false;
                bindingNavigator1.Visible = false;
               
            }

        }

        private void BtTracuu_Click(object sender, EventArgs e)
        {

            ColumnView view = gridView2;
            if (textBox1.Text != "" && dateEdit2.Text != "" && dateEdit1.Text != "")
            {
                view.ClearColumnsFilter();
                view.ActiveFilter.Add(view.Columns["Người dùng"], new ColumnFilterInfo("[Người dùng] like '%" + textBox1.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["Ngày"], new ColumnFilterInfo("[Ngày] <= '" + dateEdit2.Text + "' And [Ngày] >= '" + dateEdit1.Text + "'", ""));
            }
            else if (textBox1.Text == "" && dateEdit2.Text != "" && dateEdit1.Text != "")
            {
                view.ClearColumnsFilter();
                view.ActiveFilter.Add(view.Columns["Ngày"], new ColumnFilterInfo("[Ngày] <= '" + dateEdit2.Text + "' And [Ngày] >= '" + dateEdit1.Text + "'", ""));
            }
            else if (textBox1.Text != "" && dateEdit2.Text == "" && dateEdit1.Text != "")
            {
                view.ClearColumnsFilter();
                view.ActiveFilter.Add(view.Columns["Người dùng"], new ColumnFilterInfo("[Người dùng] like '%" + textBox1.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["Ngày"], new ColumnFilterInfo("[Ngày] >= '" + dateEdit1.Text + "'", ""));
            }
            else if (textBox1.Text != "" && dateEdit2.Text != "" && dateEdit1.Text == "")
            {
                view.ClearColumnsFilter();
                view.ActiveFilter.Add(view.Columns["Người dùng"], new ColumnFilterInfo("[Người dùng] like '%" + textBox1.Text + "%'", ""));
                view.ActiveFilter.Add(view.Columns["Ngày"], new ColumnFilterInfo("[Ngày] <= '" + dateEdit2.Text + "'", ""));
            }
            else if (textBox1.Text != "" && dateEdit2.Text == "" && dateEdit1.Text == "")
            {
                view.ClearColumnsFilter();
                view.ActiveFilter.Add(view.Columns["Người dùng"], new ColumnFilterInfo("[Người dùng] like '%" + textBox1.Text + "%'", ""));
            }
            else if (textBox1.Text == "" && dateEdit2.Text != "" && dateEdit1.Text == "")
            {
                view.ClearColumnsFilter();
                view.ActiveFilter.Add(view.Columns["Ngày"], new ColumnFilterInfo("[Ngày] <= '" + dateEdit2.Text + "'", ""));
            }
            else if (textBox1.Text == "" && dateEdit2.Text == "" && dateEdit1.Text != "")
            {
                view.ClearColumnsFilter();
                view.ActiveFilter.Add(view.Columns["Ngày"], new ColumnFilterInfo("[Ngày] >= '" + dateEdit1.Text + "'", ""));
            }
        }

        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            //tb = new DataTable();
            //SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            //dataAdapter1 = new SqlDataAdapter(new SqlCommand("Select * From [HTDTCamLe].[dbo].NhatKy", connection));
            //cmbl = new SqlCommandBuilder(dataAdapter1);
            //dataAdapter1.Fill(tb);
            //this.bindingSource1.DataSource = tb;
            //ColumnView view = gridView2;
            //view.ClearColumnsFilter();
            //gridView2.RefreshData();
            dateEdit1.ResetText();
            dateEdit2.ResetText();
            textBox1.ResetText();
            textBox2.ResetText();
            showgridControl1();
            gridView2.ClearColumnsFilter();
            gridView2.RefreshData();
        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            SaveFileDialog openf = new SaveFileDialog();
            openf.Filter = "xls|*.xls";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                gridView2.ExportToXls(openf.FileName);
            }
        }

        private void LuuChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn;
                SqlCommand command;
                conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                conn.Open();
                string sql = "";
                command = new SqlCommand(sql, conn);
                dataAdapter1.Update((DataTable)bindingSource1.DataSource);
                MessageBox.Show("Cập nhật thành công", "Thông báo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bindingSource1.ResetBindings(false);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = gridView2;
            view.ActiveFilter.Add(view.Columns["Người dùng"],
              new ColumnFilterInfo("[Người dùng] like '%" + textBox1.Text + "%'", ""));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ColumnView view = gridView2;
            view.ActiveFilter.Add(view.Columns["OBJECTID"],
              new ColumnFilterInfo("OBJECTID like '%" + textBox2.Text + "%'", ""));
        }
    }
}
