using System;
using System.Data;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Controls;
using System.Data.SqlClient;

namespace QLHTDT.FormPhu.QLQH
{
    public partial class QLHS : Form
    {
        //bool ChkHA;
        //bool ChkHP;
        //bool ChkHTT;
        //bool ChkHTD;
        //bool ChkHX;
        //bool ChkKT;
        //int KTlopQHDaMo = 0;
        //private IFeatureLayer fLayer;
        SqlCommandBuilder cmbl;
        //SqlCommandBuilder cmblsv;
        //SqlDataAdapter dataAdapterSV;
        //DataTable tbsv;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        //ILayer layerchk;
        //ILayer layeredit;
        //IWorkspaceEdit workspaceEdit;
        //QLHTDT.axToccontrol.Table.TableWrapper wratbal;
        private AxMapControl mMapControl;
        private ESRI.ArcGIS.Carto.IMap dmap;
        //int TongDuAn;
        //string layerget;
        //string txtDAQH;
        public QLHS(AxMapControl mapControl)
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map;
            this.mMapControl = mapControl;
        }
        public QLHS()
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map;
        }

        private void QLHS_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;

            //bindingSource1.DataSource = 
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            //bindingNavigator1.Visible = false;
            showgridControl1();
            //if (QLHTDT.Properties.Settings.Default.QuyenSuaDT == true) { button1.Visible = true; } else { button1.Visible = false; }
            Cursor = Cursors.Default;
        }
        void showgridControl1()
        {
            tb = new DataTable();
            tbcheck = new DataTable();
            string sql = "select * from HoSoQD";
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            //string sql = "Select * From DoAnQuyHoach";
            //SqlConnection connection = new SqlConnection(QLHTDT.Properties.Settings.Default.strConnection);
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.QLQH.HoSo.SoQDHS = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoQD").ToString();
            string QD = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoQD").ToString();
            string path = "\\quyet dinh cam le\\QD Phe duyet "+GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Nam").ToString()+"\\"+ GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoQD").ToString() + ".tif";
            //PictureBox picture = new PictureBox();
            //picture.Image = Image.FromFile(path);
            QLHTDT.FormPhu.QLQH.HoSo frm = new QLHTDT.FormPhu.QLQH.HoSo(path,QD);
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //IWorkspaceFactory workspaceFactory11 = new WorkspaceFactory();
            //IWorkspace workspace = workspaceFactory11.OpenFromFile("[Path to an SDE connection file goes here]", 0);

            //var namesEnum = workspace.DatasetNames[esriDatasetType.esriDTFeatureClass];

            //var tempName = namesEnum.Next();
            //while (tempName != null)
            //{
            //    // Add string comparison logic here, e.g. tempName.Name.StartsWith("G")  

            //    Console.WriteLine(tempName.Name);
            

            // tempName = namesEnum.Next();
            //}
        }
    }
}
