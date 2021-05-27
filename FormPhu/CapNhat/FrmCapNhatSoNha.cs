using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
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
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.LocationUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using System.Data.SqlTypes;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class FrmCapNhatSoNha : Form
    {
        DataTable tb;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        double x1 = 0; double y1 = 0;
        public string NhaDauTien;
        int DiemSoNha; double x2 = 0; double y2 = 0; double x3 = 0; double y3 = 0;
        public string ChonDayNha;
        public static DataTable tt;
        public static DataRow dr;
        string Phuong;
        string Kiet = "";
        string Hem = "";
        string PhuongPhap = "";
        int i;
        int k = 1;
        string NhaKietHem = "";
        public double p;
        public double n;
        public static ILayer LayerDiaChinh;
        string layerget;
        string txtChiaLo;
        ILayer layeredit;
        ILayer layeredit2;
        private ESRI.ArcGIS.Carto.IMap dmap;
        public FrmCapNhatSoNha()
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map;
        }
        private void FrmCapNhatSoNha_Load(object sender, EventArgs e)
        {
            ShowComBoBox();
        }
        void ShowComBoBox()//Lấy dữ liệu Quận Huyện, Hiện tại lấy tạm của BTS
        {
            string sql = "SELECT [PhuongXa],[QuanHuyen] FROM  TRAMBTS";

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                var val2 = ds.Tables[0].Rows[intCount]["QuanHuyen"].ToString();
                if (!cboPhuong.Items.Contains(val))
                {
                    cboPhuong.Items.Add(val);
                }
                if (!cboQuan.Items.Contains(val2))
                {
                    cboQuan.Items.Add(val2);
                }
            }
        }
        private void LoadDataToCollection()//Gợi ý tên Đường
        {
            AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();

            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) + ";Type System Version=SQL Server 2012;");
            string sql = "Select TenDuong from DUONGCHINH_HA";
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            com.CommandText = sql;
            com.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader reader;
            reader = com.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    auto2.Add(reader["TenDuong"].ToString());
                }
            }
            cboDuong.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboDuong.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboDuong.AutoCompleteCustomSource = auto2;
        }
        private void button3_Click(object sender, EventArgs e)//Click Chọn dãy nhà cần cập nhật
        {
            ICommand command = new ControlsSelectTool();
            command.OnCreate(QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Object);
            QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.CurrentTool = command as ITool;
            command.OnClick();

            this.Hide();
            MessageBox.Show("Xin vui lòng chọn 'Nhà đầu tiên' rồi đến nhà 'Kết thúc' ", "Lưu Ý");
            
            QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(MousedownChonDayNha);
        }
        private void MousedownChonDayNha(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //if (e.button == 1)
            //{
                if (DiemSoNha == 0 | DiemSoNha % 2 == 0)
                {
                    if (x2 != Convert.ToDouble(e.mapX.ToString("#######.##")))
                    {
                        x2 = Convert.ToDouble(e.mapX.ToString("#######.##"));
                        y2 = Convert.ToDouble(e.mapY.ToString("#######.##"));
                        DiemSoNha = DiemSoNha + 1;

                        IGraphicsContainer graphicsContainer = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.ActiveView.FocusMap as IGraphicsContainer;
                        IElement element = new MarkerElementClass();
                        IElement element2 = new TextElementClass();
                        IMarkerElement CircleElement = element as IMarkerElement;
                        ITextElement textElement = element2 as ITextElement;
                        IPoint point = new PointClass();
                        point.X = x2;
                        point.Y = y2;
                        IPoint point2 = new PointClass();
                        point2.X = x2 + 1;
                        point2.Y = y2 + 1;
                        element.Geometry = point;
                        element2.Geometry = point2;
                        textElement.Symbol.Size = 5;
                        ISimpleMarkerSymbol smpMrk = new SimpleMarkerSymbol();
                        smpMrk.Size = 10;
                        smpMrk.Style = esriSimpleMarkerStyle.esriSMSCross;
                        //Create a Color for the Mask -Red 
                        IRgbColor rgbClr = new RgbColor();
                        rgbClr.Red = 255;
                        rgbClr.Green = 255;
                        rgbClr.Blue = 255;
                        //Create a Fill Symbol for the Mask 
                        ISimpleFillSymbol smpFill = new SimpleFillSymbol();
                        smpFill.Color = rgbClr;
                        smpFill.Style = esriSimpleFillStyle.esriSFSSolid;
                        //Create a MultiLayerMarkerSymbol
                        IMultiLayerMarkerSymbol multiLyrMrk = new MultiLayerMarkerSymbol();
                        //Add the simple marker to the MultiLayer 
                        multiLyrMrk.AddLayer(smpMrk);
                        //Create a Mask for the MultiLayerMarkerSymbol 
                        IMask mrkMask = (IMask)multiLyrMrk;
                        mrkMask.MaskSymbol = smpFill;
                        mrkMask.MaskStyle = esriMaskStyle.esriMSHalo;
                        CircleElement.Symbol = multiLyrMrk;
                        graphicsContainer.AddElement(element, 0);
                        graphicsContainer.AddElement(element2, 0);

                    }
                }
                else if (x3 != Convert.ToDouble(e.mapX.ToString("#######.##")))
                {
                    x3 = Convert.ToDouble(e.mapX.ToString("#######.##"));
                    y3 = Convert.ToDouble(e.mapY.ToString("#######.##"));
                    DiemSoNha = DiemSoNha + 1;
                    

                    IGraphicsContainer graphicsContainer = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.ActiveView.FocusMap as IGraphicsContainer;
                    IElement element = new MarkerElementClass();
                    IElement element2 = new TextElementClass();
                    IMarkerElement CircleElement = element as IMarkerElement;
                    ITextElement textElement = element2 as ITextElement;
                    IPoint point = new PointClass();
                    point.X = x3;
                    point.Y = y3;
                    IPoint point2 = new PointClass();
                    point2.X = x3 + 1;
                    point2.Y = y3 + 1;
                    element.Geometry = point;
                    element2.Geometry = point2;
                    textElement.Symbol.Size = 5;
                    ISimpleMarkerSymbol smpMrk = new SimpleMarkerSymbol();
                    smpMrk.Size = 10;
                    smpMrk.Style = esriSimpleMarkerStyle.esriSMSCross;
                    //Create a Color for the Mask -Red 
                    IRgbColor rgbClr = new RgbColor();
                    rgbClr.Red = 255;
                    rgbClr.Green = 255;
                    rgbClr.Blue = 255;
                    //Create a Fill Symbol for the Mask 
                    ISimpleFillSymbol smpFill = new SimpleFillSymbol();
                    smpFill.Color = rgbClr;
                    smpFill.Style = esriSimpleFillStyle.esriSFSSolid;
                    //Create a MultiLayerMarkerSymbolcheckBox1
                    IMultiLayerMarkerSymbol multiLyrMrk = new MultiLayerMarkerSymbol();
                    //Add the simple marker to the MultiLayer 
                    multiLyrMrk.AddLayer(smpMrk);
                    //Create a Mask for the MultiLayerMarkerSymbol 
                    IMask mrkMask = (IMask)multiLyrMrk;
                    mrkMask.MaskSymbol = smpFill;
                    mrkMask.MaskStyle = esriMaskStyle.esriMSHalo;
                    CircleElement.Symbol = multiLyrMrk;
                    graphicsContainer.AddElement(element, 0);
                    graphicsContainer.AddElement(element2, 0);
                    QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.OnMouseDown -= new IMapControlEvents2_Ax_OnMouseDownEventHandler(MousedownChonDayNha);
                    this.Show();
                    LoadChiaLo();
                    TenDuongTheoDayNha();

                    ICommand command = new ControlsSelectTool();
                    command.OnCreate(QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Object);
                    QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.CurrentTool = command as ITool;
                    command.OnClick();

            }
            //}
            //DayNha = "DECLARE @DiemDau geometry; SET @DiemDau = geometry::STPointFromText('POINT (" + x2 + " " + y2 + ")', 0); DECLARE @DayNha geometry; SET @DayNha = geometry::STLineFromText('LINESTRING ("+ x2 +" "+ y2 +", "+x3+" "+y3+ ")', 0);SELECT  a.SoToBD, a.SoThua , a.Shape FROM [dbo].[CHIALO_HA] a where @DayNha.STIntersects(a.Shape) = 1 and a.LoaiDat <> 'DGT' ORDER BY  @DiemDau.STDistance(a.shape)";

        }
        private void ReLoad_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = null;
            cboDuong.ResetText();
            txtNhaDau.ResetText();
            txtNhaCuoi.ResetText();
            txtKiet.ResetText();
            txtHem.ResetText();
            txtKhongCoNha.ResetText();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;

            QLHTDT.FormPhu.CapNhat.FrmCapNhatSoNha frm = new QLHTDT.FormPhu.CapNhat.FrmCapNhatSoNha();
            frm.Refresh();
            QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();
            k = 2;

            ICommand command = new ControlsSelectTool();
            command.OnCreate(QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Object);
            QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.CurrentTool = command as ITool;
            command.OnClick();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            { checkBox2.Checked = false;
                //k = 1;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            { checkBox1.Checked = false;
                //k = 1;
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
               
                txtKiet.ReadOnly = false;
                NhaKietHem = txtKiet.Text + "/" + txtNhaDau.Text;
            }
            else
            {
                txtKiet.ReadOnly = true;
                txtKiet.ResetText();
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
       {
          if (checkBox4.Checked == true)
          {
             txtHem.ReadOnly = false;
             NhaKietHem = txtHem.Text + "/" + txtNhaDau.Text;
          }
           else
                {
                    txtHem.ReadOnly = true;
                    txtHem.ResetText();
                }
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
           if(checkBox5.Checked == false)
           {
                txtKhongCoNha.ReadOnly = true;
           }
           else
           {
                txtKhongCoNha.ReadOnly = false;
                txtKhongCoNha.ResetText();
           }
        }
        private void CapNhat_Click(object sender, EventArgs e)
        {
            if (txtNhaDau.Text != "")
            {
                if ((Convert.ToDouble(txtNhaCuoi.Text) - Convert.ToDouble(txtNhaDau.Text)) / 2 == tb.Rows.Count - k)//Đếm số nhà cần cập nhật
                {
                    if (i == tb.Rows.Count)//Lấy số nhà cuối cùng
                    {
                        if (Convert.ToDouble(txtNhaCuoi.Text) == Convert.ToDouble(tb.Rows[i - 1][0].ToString()))//So Sánh số nhà cuối cùng ở Text và DataGridview
                        {
                            DialogResult dlr = MessageBox.Show("Dãy nhà cần cập nhật dữ liệu đúng, Bạn có muôn cập nhật", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (dlr == DialogResult.Yes)
                            {
                                CapNhatSoNha();
                            }
                        }
                        else
                        {
                            DialogResult dlr = MessageBox.Show("Số nhà cuối tuyến chưa đúng, Bạn vẫn muốn cập nhật", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (dlr == DialogResult.Yes)
                            {
                                CapNhatSoNha();
                            }
                        }
                    }
                }
                else
                {
                    if ((Convert.ToDouble(txtNhaCuoi.Text) - Convert.ToDouble(txtNhaDau.Text)) / 2 > tb.Rows.Count - k)
                    {
                        DialogResult dlr = MessageBox.Show("Số nhà cần cập nhật nhiều hơn với dãy nhà được chọn, Bạn vẫn muốn cập nhật", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dlr == DialogResult.Yes)
                        {
                            CapNhatSoNha();
                        }
                    }
                    else
                    {
                        DialogResult dlr = MessageBox.Show("Số nhà cần cập nhật ít hơn với dãy nhà được chọn, Bạn vẫn muốn cập nhật", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dlr == DialogResult.Yes)
                        {
                            CapNhatSoNha();
                        }
                    }
                }
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Bạn cập nhật không có số nhà, Bạn vẫn muốn cập nhật", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    CapNhatSoNha();
                }
            }
        }
        private void CapNhatSoNha()
        {
            try
            {
                for (int i1 = 0; i1 < tb.Rows.Count ; i1++)
                {
                    //Các trường thuộc tính có thể thay đổi

                    string SoNha = tb.Rows[i1][0].ToString();
                    string Object = tb.Rows[i1][4].ToString();
                    string Duong = tb.Rows[i1][5].ToString();
                    string Kiet = txtKiet.Text;
                    string Hem = txtHem.Text;

                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) + ";Type System Version=SQL Server 2012;";
                SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    //Update cập nhật dữ liệu
                    string Update = "update [dbo].[CHIALO_" + Phuong + "] set SoNha = '" + SoNha + "',MaDuongGTChinh = '" + Duong + "', Kiet = '" + Kiet + "', Hem = '" + Hem + "',PhuongPhap = '" + PhuongPhap+"' where [OBJECTID] = " + Object + " ";
                    SqlCommand cmd = new SqlCommand(Update, conn);
                    cmd.CommandText = Update;
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại, kiểm tra các thông tin còn thiếu", "Thông báo");
                }
        }
        private void TenDuongTheoDayNha()//Lấy dữ liệu tên đường khi Click chọn Dãy nhà
        {
            cboDuong.Items.Clear();
            string sql = "DECLARE @H geometry = 'LINESTRING ("+x2+" "+y2+", "+x3+" "+y3+")';DECLARE @g geometry ;set @g = (select @H.STBuffer(100)) SELECT  a.TenDuong, a.Shape FROM [dbo].[DUONGCHINH_"+Phuong+"] a where @g.STIntersects(a.Shape) = 1";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) + ";Type System Version=SQL Server 2012;");
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["TenDuong"].ToString();
                if (!cboDuong.Items.Contains(val))
                {
                    cboDuong.Items.Add(val);
                }
            }
        }
        private void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT [PhuongXa],[QuanHuyen] FROM  TRAMBTS";
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql + " Where [QuanHuyen] = N'" + cboQuan.Text + "'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            adp.FillSchema(ds, SchemaType.Source);
            adp.Fill(ds);
            cboPhuong.Items.Clear();
            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                var val = ds.Tables[0].Rows[intCount]["PhuongXa"].ToString();
                if (!cboPhuong.Items.Contains(val))
                {
                    cboPhuong.Items.Add(val);
                }
            }
        }
        private void LoadChiaLo()
        {
            k = 1;
            tb = new DataTable();
            string sql = "DECLARE @DiemDau geometry; SET @DiemDau = geometry::STPointFromText('POINT (" + x2 + " " + y2 + ")', 0); DECLARE @DayNha geometry; SET @DayNha = geometry::STLineFromText('LINESTRING (" + x2 + " " + y2 + ", " + x3 + " " + y3 + ")', 0);SELECT a.SoNha, a.SoToBD, a.SoThua , a.Shape, a.OBJECTID, a.MaDuongGTChinh FROM [dbo].[CHIALO_"+Phuong+"] a where a.LoaiDat <> 'DGT' and @DayNha.STIntersects(a.Shape) = 1  ORDER BY  @DiemDau.STDistance(a.shape)";
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) +";Type System Version=SQL Server 2012;");
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            bindingSource1.DataSource = tb;
            try
            {
                tb.Rows[0][0] = Convert.ToDouble(txtNhaDau.Text);//Nhận số nhà đầu tiên
                for (i = 1; i < tb.Rows.Count; i++)
                {
                    tb.Rows[i][0] = Convert.ToDouble(tb.Rows[i - 1][0]) + 2;

                    if (checkBox1.Checked == true)//Nếu k có nhà số 4   
                    {

                        if (tb.Rows[i][0].ToString() == "4")
                        {
                            tb.Rows[i][0] = "6";
                            k = 0;
                        }
                    }
                    if (checkBox2.Checked == true)//Nếu k có nhà số 13
                    {
                        if (tb.Rows[i][0].ToString() == "13")
                        {
                            tb.Rows[i][0] = "15";
                            k = 0;
                        }
                    }

                    if (tb.Rows[i][0].ToString() == txtKhongCoNha.Text)
                    {
                       
                        if (checkBox5.Checked == true)//Nếu k có nhà số trong TextKhongCoNha
                        {
                            tb.Rows[i][0] = Convert.ToDouble(tb.Rows[i - 1][0]) + 4;
                            k = 0;
                        }
                        else
                        {
                            tb.Rows[i][0] = Convert.ToDouble(tb.Rows[i - 1][0]) + 2;
                        }
                    }

                }
                if ((Convert.ToDouble(txtNhaCuoi.Text) - Convert.ToDouble(txtNhaDau.Text)) / 2 == tb.Rows.Count - k)//Kiểm số dãy nhà chọn với số nhà nhập vào
                {
                    if (i == tb.Rows.Count)
                    {
                        if (Convert.ToDouble(txtNhaCuoi.Text) == Convert.ToDouble(tb.Rows[i - 1][0].ToString()))//Kiểm tra số nhà cuối ở Text với DataGridview
                        {
                            MessageBox.Show("Dãy nhà cần cập nhật dữ liệu đúng", "Thông báo");
                        }
                        else { MessageBox.Show("Số nhà cuối tuyến chưa đúng", "Thông báo"); }
                    }

                }
                else
                {
                    if ((Convert.ToDouble(txtNhaCuoi.Text) - Convert.ToDouble(txtNhaDau.Text)) / 2 > tb.Rows.Count - k)//Kiểm tra số dãy nhà chọn với số nhà nhập vào
                    {
                        MessageBox.Show("Số nhà cần cập nhật nhiều hơn với dãy nhà được chọn", "Thông báo");
                    }
                    else
                    { MessageBox.Show("Số nhà cần cập nhật ít hơn với dãy nhà được chọn", "Thông báo"); }
                }
                GridView1.RefreshData();
                bindingSource1.ResetBindings(true);
                bindingSource1.DataSource = tb;
            }
            catch
            {
                MessageBox.Show("Bạn chưa nhập thông tin số nhà", "Thông báo");
            }

        }
        private void cboPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhuong.Text == "Hòa An")
            { txtChiaLo = "Chia lô - HA"; layerget = "Đường chính - HA"; Phuong = "HA"; }
            else if (cboPhuong.Text == "Hòa Phát")
            { txtChiaLo = "Chia lô - HP"; layerget = "Đường chính - HP"; Phuong = "HP"; }
            else if (cboPhuong.Text == "Hòa Thọ Tây")
            { txtChiaLo = "Chia lô - HTT"; layerget = "Đường chính - HTT"; Phuong = "HTT"; }
            else if (cboPhuong.Text == "Hòa Thọ Đông")
            { txtChiaLo = "Chia lô - HTD"; layerget = "Đường chính - HTD"; Phuong = "HTD"; }
            else if (cboPhuong.Text == "Hòa Xuân")
            { txtChiaLo = "Chia lô - HX"; layerget = "Đường chính - HX"; Phuong = "HX"; }
            else if (cboPhuong.Text == "Khuê Trung")
            { txtChiaLo = "Chia lô - KT"; layerget = "Đường chính - KT"; Phuong = "KT"; }
            else if (cboPhuong.Text == "Hòa Xuân")
            { txtChiaLo = "Chia lô - HX"; layerget = "Đường chính - HX"; Phuong = "HX"; }

            int KTMoLop = 0;
            string PhuongKT = null;
            try
            {
                PhuongKT = cboPhuong.Text;
                for (int i1 = 0; i1 < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i1++)
                {
                    if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i1).Name == cboPhuong.Text)
                    {
                        ICompositeLayer igroup1 = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.Layer[i1] as ICompositeLayer;
                        for (int i = 0; i < igroup1.Count; i++)
                        {
                            ILayer ilayer1 = igroup1.get_Layer(i) as ILayer;
                            if (ilayer1.Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                layeredit = ilayer1;
                            }
                            ILayer ilayer2 = igroup1.get_Layer(i) as ILayer;
                            if (ilayer2.Name == txtChiaLo)
                            {
                                KTMoLop = KTMoLop + 1;
                                layeredit2 = ilayer2;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
                        {
                            if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == layerget)
                            {
                                KTMoLop = KTMoLop + 1;
                                layeredit = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i);
                            }
                            if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == txtChiaLo)
                            {
                                KTMoLop = KTMoLop + 1;
                                layeredit2 = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i);
                            }
                        }
                    }
                }
                if (KTMoLop == 0)
                {
                    QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + layerget + ".lyr");
                    QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\" + PhuongKT + "\\" + txtChiaLo + ".lyr");
                    QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();

                    for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
                    {
                        if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == layerget)
                        {
                            KTMoLop = KTMoLop + 1;
                            layeredit = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i);
                        }
                        if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == txtChiaLo)
                        {
                            KTMoLop = KTMoLop + 1;
                            layeredit2 = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //ITable tb1 = (layeredit as IFeatureLayer).FeatureClass as ITable;
            //wratbal = new QLHTDT.axToccontrol.Table.TableWrapper(tb1);
            QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Refresh();

        }
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow rowSHP = dgvData.Rows[e.RowIndex];
            //int ID;
            //int.TryParse(rowSHP.Cells[4].Value.ToString(), out ID);
            //IFeatureLayer featureLayer = (IFeatureLayer)FrmCapNhatSoNha.LayerDiaChinh;
            //LayerDiaChinh = FormChinh.QuanTriHeThong.axMapControl1.get_Layer(0);
            //IFeature ife = featureLayer.FeatureClass.GetFeature(ID);
            //if (ife != null)
            //{
            //    //IFeatureLayer featureLayer = new FeatureLayerClass();
            //    //featureLayer.FeatureClass = FrmCapNhat.featureClassSHP;
            //    //ILayer layer = (ILayer)featureLayer;
            //    QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map, FrmCapNhatSoNha.LayerDiaChinh);
            //    IActiveView ActiveView = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.ActiveView;
            //    IEnvelope pEnv = null;
            //    pEnv = ife.ShapeCopy.Envelope;
            //    pEnv.Expand(1.2, 1.2, true);
            //    ActiveView.Extent = pEnv;
            //    ActiveView.Refresh();
            //}
        }
        private void cboDuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select OBJECTID_1 from DuongChinh_" + Phuong + " where TenDuong = N'" + cboDuong.Text + "'";
            DataTable tb1 = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(sql, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH) + ";Type System Version=SQL Server 2012;");
            adp.Fill(tb1);
            string val = tb1.Rows[0]["OBJECTID_1"].ToString();
            for (i = 0; i < tb.Rows.Count; i++)
            {
                tb.Rows[i][5] = val;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                checkBox6.Checked = false;
                PhuongPhap = "0";
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox7.Checked = false;
                PhuongPhap = "1";
            }
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
            try
            {
                for (int i = 0; i < QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.LayerCount; i++)
                {
                    if (QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i).Name == txtChiaLo)
                    {
                        IFeatureLayer ilayer = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.get_Layer(i) as IFeatureLayer;
                        int ID;
                        int.TryParse(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OBJECTID").ToString(), out ID);
                        if (ID == 0) { MessageBox.Show("Không có dữ liệu không gian thửa đất này", "Thông báo"); }
                        else
                        {
                            IFeature ife = ilayer.FeatureClass.GetFeature(ID);
                            if (ife != null)
                            {
                                QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, dmap, ilayer);
                                IActiveView ActiveView = dmap as IActiveView;
                                IEnvelope pEnv = null;
                                pEnv = ife.ShapeCopy.Envelope;
                                ActiveView.Extent = pEnv;
                                QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale = QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.Map.MapScale * 2;
                                ActiveView.Refresh();
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
