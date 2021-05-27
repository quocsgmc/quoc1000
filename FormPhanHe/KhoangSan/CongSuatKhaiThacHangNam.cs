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
    public partial class CongSuatKhaiThacHangNam : Form
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
        public static int ID1;
        public CongSuatKhaiThacHangNam()
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

        private void btChinhSua_Click(object sender, EventArgs e)
        {
            if (btChinhSua.Text == "Cập nhật dữ liệu khai thác")
            {
                //GridView1.ClearColumnsFilter();
                //GridView1.RefreshData();
                MessageBox.Show("Vui lòng chọn dữ liệu cần cập nhật", "Thông báo");
                GridView1.OptionsBehavior.Editable = true;
                bindingNavigator1.Visible = true;
                btChinhSua.Text = "Tắt cập nhật dữ liệu khai thác";
                //this.bindingSource1.DataSource = null;
                ChinhSua = false;

            }
            else
            {
                hDKTKSBindingSource.ResetBindings(true); //(Cái này để reset gribview)
                //DataTable table = (DataTable)bindingSource1.DataSource;
                btChinhSua.Text = "Cập nhật dữ liệu khai thác";
                bindingNavigator1.Visible = false;
                GridView1.OptionsBehavior.Editable = false;
                tb = new DataTable();
                string sql = "select [CongSuatKhaiThac],[NamKhaiThac] from [CongSuatKhaiThacHangNam1] where IDMo = " + ID1+"";
                SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
                cmbl = new SqlCommandBuilder(dataAdapter1);
                dataAdapter1.Fill(tb);
                this.hDKTKSBindingSource.DataSource = tb;
                //GridView1.ClearColumnsFilter();
                //GridView1.RefreshData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string NamKhaiThac = txtNam.Text;
                string CongSuat = txtCongSuat.Text;

                string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                SqlConnection conn = new SqlConnection(str);

                //Insert cập nhật dữ liệu
                conn.Open();
                string Insert = "insert into [CongSuatKhaiThacHangNam1](CongSuatKhaiThac,NamKhaiThac,IDMO) values (" + CongSuat + "," + NamKhaiThac + ", " + ID1 + " )";  
                SqlCommand cmd = new SqlCommand(Insert, conn);
                cmd.ExecuteNonQuery();
                txtCongSuat.ResetText();
                txtNam.ResetText();
                //reset datagridview
                showgridControl1();
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Chưa nhập thông tin, vui lòng thử lại", "Thông báo");
            }
        }

        private void CongSuatKhaiThacHangNam_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;
            showgridControl1();
            if (QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 2 || QLHTDT.Properties.Settings.Default.LoaiNguoiDung == 3)
            {
                btChinhSua.Enabled = false;
                button2.Enabled = false;
                button1.Enabled = false;
            }
        }
        void showgridControl1()
        {
            tb = new DataTable();
            tbcheck = new DataTable(); string sql;
            sql = "select NamKhaiThac,CongSuatKhaiThac from [CongSuatKhaiThacHangNam1] where IDMo = " + ID1 + "";
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.hDKTKSBindingSource.DataSource = tb;
            //int i;
            //int val = ID1;
            //for (i = 0; i < tb.Rows.Count; i++)
            //{
            //    tb.Rows[i][2] = val;
            //}
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sql = "select * from [CongSuatKhaiThacHangNam1]";
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

            //for (int i1 = 0; i1 < tb.Rows.Count; i1++)
            //{
            //    //Các trường thuộc tính có thể thay đổi

            //    string NamKhaiThac = tb.Rows[i1][0].ToString();
            //    string CongSuatKhaiThac = tb.Rows[i1][1].ToString();
            //    string IDCSKTHN = tb.Rows[i1][2].ToString();

            //    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) + ";Type System Version=SQL Server 2012;";
            //    SqlConnection conn = new SqlConnection(str);
            //    conn.Open();
            //    //Update cập nhật dữ liệu
            //    string Update = "update [KhoangSan].[dbo].[CongSuatKhaiThacHangNam1] set CongSuatKhaiThac = '" + CongSuatKhaiThac + "',NamKhaiThac = '" + NamKhaiThac + "' where [IDCSKTHN] = " + IDCSKTHN + " ";
            //    SqlCommand cmd = new SqlCommand(Update, conn);
            //    cmd.CommandText = Update;
            //    cmd.ExecuteNonQuery();
            //    GridView1.RefreshData();
            //}
            //MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string NamKhaiThac = txtNam.Text;
                string CongSuat = txtCongSuat.Text;

                string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                SqlConnection conn = new SqlConnection(str);

                //Insert cập nhật dữ liệu
                conn.Open();
                string Insert = "delete into [CongSuatKhaiThacHangNam1] where IDMo = " + ID1 + "";
                SqlCommand cmd = new SqlCommand(Insert, conn);
                cmd.ExecuteNonQuery();
                txtCongSuat.ResetText();
                txtNam.ResetText();
                //reset datagridview
                showgridControl1();
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Chưa nhập thông tin, vui lòng thử lại", "Thông báo");
            }
        }
    }
}
