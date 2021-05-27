using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Base;
using ESRI.ArcGIS.Controls;
using System.Diagnostics;
using ESRI.ArcGIS.Geometry;
using QLHTDT.FormChinh;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.IO;
using QLHTDT.FormPhu.KhoangSan;

namespace QLHTDT.FormPhu.KhoangSan
{
    public partial class ToaDoMocRanh : Form
    {
        bool ChinhSua = false;
        SqlCommandBuilder cmbl;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;

        private ESRI.ArcGIS.Carto.IMap dmap;
        private AxMapControl mMapControl;
        string layerget;
        string txtQHVungCam;
        ILayer layeredit;
        QLHTDT.axToccontrol.Table.TableWrapper wratbal;
        int IDMo;
        public static int ID2;
        
        public ToaDoMocRanh()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string TenDiem = txtTenDiem.Text;
                string ToaDoX = txtToaDoX.Text;
                string ToaDoY = txtToaDoY.Text;

                string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                SqlConnection conn = new SqlConnection(str);

                //Insert cập nhật dữ liệu
                string Insert = "insert into [ToaDoMocRanh]([TenDiem],[ToaDoX],[ToaDoY],[IDMo]) values (" + TenDiem + "," + ToaDoX + "," + ToaDoY + ", " + ID2 + " )";
                conn.Open();
                SqlCommand cmd = new SqlCommand(Insert, conn);
                cmd.Connection = conn;
                cmd.CommandText = Insert;
                cmd.ExecuteNonQuery();
                txtTenDiem.ResetText();
                txtToaDoX.ResetText();
                txtToaDoY.ResetText();

                //Reset datagridview
                hDKTKSBindingSource.ResetBindings(true);
                tb = new DataTable();
                string sql = "select [TenDiem],[ToaDoX],[ToaDoY] from [ToaDoMocRanh] where IDMo = " + ID2 + "";
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);
                dataAdapter1.Fill(tb);
                this.hDKTKSBindingSource.DataSource = tb;
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Chưa nhập thông tin, vui lòng thử lại", "Thông báo");
            }
        }

        private void btChinhSua_Click(object sender, EventArgs e)
        {
            if (btChinhSua.Text == "Chỉnh sửa dữ liệu mốc ranh")
            {
                //GridView1.ClearColumnsFilter();
                //GridView1.RefreshData();
                MessageBox.Show("Vui lòng chọn dữ liệu cần cập nhật", "Thông báo");
                GridView1.OptionsBehavior.Editable = true;
                bindingNavigator1.Visible = true;
                btChinhSua.Text = "Tắt chỉnh sửa dữ liệu mốc ranh";
                //this.bindingSource1.DataSource = null;
                ChinhSua = false;

            }
            else
            {
                hDKTKSBindingSource.ResetBindings(true); //(Cái này để reset gribview)
                //DataTable table = (DataTable)bindingSource1.DataSource;
                btChinhSua.Text = "Chỉnh sửa dữ liệu mốc ranh";
                bindingNavigator1.Visible = false;
                GridView1.OptionsBehavior.Editable = false;
                tb = new DataTable();
                string sql = "select [TenDiem],[ToaDoX],[ToaDoY] from [ToaDoMocRanh] where IDMo = " + ID2 + "";
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);
                dataAdapter1.Fill(tb);
                this.hDKTKSBindingSource.DataSource = tb;
                //GridView1.ClearColumnsFilter();
                //GridView1.RefreshData();
            }
        }

        private void ToaDoMocRanh_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;
            showgridControl1();
        }
        void showgridControl1()
        {
            tb = new DataTable();
            tbcheck = new DataTable(); string sql;
            sql = "[PRC_ToaDoHoatDongKhaiThacKS_GET_BY_ID] " + ID2 + "";
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.hDKTKSBindingSource.DataSource = tb;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sql = "select [TenDiem],[ToaDoX],[ToaDoY],[IDMo],[IDMocRanh] from [ToaDoMocRanh]";
            GridView1.MoveNext();
            GridView1.MovePrev();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);

            hDKTKSBindingSource.EndEdit();
            DataTable dt = (DataTable)hDKTKSBindingSource.DataSource;
            dataAdapter1.Update(dt);
            GridView1.RefreshData();
            MessageBox.Show("Lưu dữ liệu thay đổi thành công", "Thông báo");
        }
    }
}
