using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;
using ESRI.ArcGIS.Geodatabase;
namespace QLHTDT.FormPhanHe.BuuChinh_VienThong
{
    public partial class ThemMoiExcel : Form
    {
        SqlConnection sqlconn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
        IFeatureClass ftClassSDE;
        IFeatureClass featureClass;
        IFeatureWorkspace featureWorkspaceSDE;
        public ThemMoiExcel()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Excell|*.xls;*.xlsx;";
            DialogResult dr = od.ShowDialog();
            if (dr == DialogResult.Abort)
                return;
            if (dr == DialogResult.Cancel)
                return;
            textBox1.Text = od.FileName.ToString();
            string sexcelconnectionstring = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + textBox1.Text + ";extended properties=" + "\"excel 12.0;hdr=yes;\"";
            string myexceldataquery = "Select * from [Sheet1$]";
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myexceldataquery, oledbconn);
            myDataAdapter.Fill(dt);
            dgvData.DataSource = dt;
            comboBox1.Items.Clear();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                comboBox1.Items.Add(dgvData.Columns[i].HeaderText);
                comboBox2.Items.Add(dgvData.Columns[i].HeaderText);
                comboBox3.Items.Add(dgvData.Columns[i].HeaderText);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             try
            {
                int CellKinhDo = -1;
                int CellViDo = -1;
                int CellDiem = -1;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if(dgvData.Columns[i].HeaderText == comboBox1.Text)
                    {
                        CellKinhDo = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboBox2.Text)
                    {
                        CellViDo = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboBox3.Text)
                    {
                        CellDiem = i;
                    }
                }
                for (int i = 0; i < dgvData.RowCount - 1; i++)
                {
                    string KinhDo1 = dgvData.Rows[i].Cells[CellKinhDo].Value.ToString();
                    string ViDo1 = dgvData.Rows[i].Cells[CellViDo].Value.ToString();
                    string DoCao1 = dgvData.Rows[i].Cells[CellDiem].Value.ToString();

                    string str = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();

                    ftClassSDE = QLHTDT.FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("//////");
                    IFeature feature = ftClassSDE.CreateFeature();

                    ISubtypes subtypes = (ISubtypes)ftClassSDE;
                    IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
                    if (subtypes.HasSubtype)
                    {
                        rowSubtypes.SubtypeCode = 3;
                    }
                    rowSubtypes.InitDefaultValues();
                    int KinhDo = ftClassSDE.FindField("KinhDo");
                    if (KinhDo1 != "")
                    {
                        feature.set_Value(KinhDo, KinhDo1);
                    }
                    else { feature.set_Value(KinhDo, null); }

                    int ViDo = ftClassSDE.FindField("ViDo");
                    if (ViDo1 != "")
                    {
                        feature.set_Value(ViDo, ViDo1);
                    }
                    else { feature.set_Value(ViDo, null); }

                    int DoCao = ftClassSDE.FindField("DoCao");
                    if (DoCao1 != "")
                    {
                        feature.set_Value(DoCao, DoCao1);
                    }
                    else { feature.set_Value(DoCao, null); }
                }
            }
            catch
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại. Kiểm tra lại thông tin", "Thông báo");
            }
        }
    }
}
