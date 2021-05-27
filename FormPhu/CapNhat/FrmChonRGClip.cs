using ESRI.ArcGIS.Geodatabase;
using QLHTDT.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.CapNhat
{
    public partial class FrmChonRGClip : Form
    {
        public static IFeature ife;
        public static double Xminft = 0;
        public static double Yminft = 0;
        public static double Xmaxft = 0;
        public static double Ymaxft = 0;
         public static string MaHuyen = "null";
        public FrmChonRGClip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmChonRGClip_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_Query_TenHuyen_By_MAHuyen] null", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboQuan.DataSource = ds1.Tables[0];
            comboQuan.DisplayMember = "TENHUYEN";
            comboQuan.ValueMember = "MAHUYEN";

            SqlDataAdapter adp2 = new SqlDataAdapter("Select TenPhanKhu from QUYHOACHPHANKHU", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            comboBox1.DataSource = ds2.Tables[0];
            comboBox1.DisplayMember = "TenPhanKhu";
            comboBox1.ValueMember = "TenPhanKhu";
            comboBox1.ResetText();
        }
        string DAQH;
        int AddQuan = 0;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            comboPhuong.ResetText();
            if (comboQuan.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                comboQuan.Text = "";
            }
            if (AddQuan == 1)
            {
                MaHuyen = comboQuan.SelectedValue.ToString();
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + " ";

                SqlDataAdapter adp = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds = new DataSet();
                adp.Fill(ds);
                comboPhuong.DataSource = ds.Tables[0];
                comboPhuong.DisplayMember = "TenPhuong";
                comboPhuong.ValueMember = "MaPhuong";

                if (comboPhuong.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    comboPhuong.Text = "";
                }
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                comboBox3.Text = "";
            }
            //if (DAQH != "" & DAQH != null)
            if (1==1)
                {
                IFeatureClass featureClass = FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("DOANQUYHOACH");
                
                //string constring = Settings.Default.strConnectionDAQH;
                string quyery = "SELECT "+ featureClass.OIDFieldName+ "  FROM DOANQUYHOACH where [Tendoan] = N'" + comboBox3.Text + "'";
                SqlConnection conDataBase = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                SqlCommand cmdBD = new SqlCommand(quyery, conDataBase);
                try
                {
                    conDataBase.Open();
                    if (cmdBD.ExecuteScalar() != DBNull.Value)
                    {
                        SqlDataReader reader = cmdBD.ExecuteReader();
                        while (reader.Read())
                        {
                            //string id = reader.GetString(0);
                            int ID = reader.GetInt32(0);
                            ife = featureClass.GetFeature(ID);
                            Xminft = ife.Extent.XMin;
                            Yminft = ife.Extent.YMin;
                            Xmaxft = ife.Extent.XMax;
                            Ymaxft = ife.Extent.YMax;
                        }
                    }
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox3.ResetText();
            if (comboPhuong.Text != "" && comboPhuong.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                SqlDataAdapter adp1 = new SqlDataAdapter("[PRC_QUERYRGDAQH_BY_Phuong] " + comboPhuong.SelectedValue.ToString() + "", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds1 = new DataSet();
                adp1.Fill(ds1);
                comboBox3.DataSource = ds1.Tables[0];
                comboBox3.DisplayMember = "Tendoan";
                comboBox3.ValueMember = "Tendoan";
                comboBox3.ResetText();
                //for (int intCount = 0; intCount < ds1.Tables[0].Rows.Count; intCount++)
                //{
                //    var val = ds1.Tables[0].Rows[intCount]["TenDuAn"].ToString();

                //    if (!comboPhuong.Items.Contains(val))
                //    {
                //        comboBox3.Items.Add(val);
                //    }
                //}
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Enabled = false;
                checkBox2.CheckState = CheckState.Unchecked;
            }
            else
            {
                comboBox1.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.CheckState = CheckState.Unchecked;
                comboQuan.Enabled = false;
                comboPhuong.Enabled = false;
                comboBox3.Enabled = false;
            }
            else
            {
                comboQuan.Enabled = true;
                comboPhuong.Enabled = true;
                comboBox3.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            if (comboBox1.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                comboBox1.Text = "";
            }
            if (AddQuan == 1)
            {
                IFeatureClass featureClass = FormChinh.KienTruc.FeatureWorkspace.OpenFeatureClass("QUYHOACHPHANKHU");

                //string constring = Settings.Default.strConnectionDAQH;
                string quyery = "SELECT " + featureClass.OIDFieldName + " FROM QUYHOACHPHANKHU where [TenPhanKhu] = N'" + comboBox1.Text + "'";
                SqlConnection conDataBase = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                SqlCommand cmdBD = new SqlCommand(quyery, conDataBase);
                try
                {
                    conDataBase.Open();
                    if (cmdBD.ExecuteScalar() != DBNull.Value)
                    {
                        SqlDataReader reader = cmdBD.ExecuteReader();
                        while (reader.Read())
                        {
                            //string id = reader.GetString(0);
                            int ID = reader.GetInt32(0);
                            ife = featureClass.GetFeature(ID);
                            Xminft = ife.Extent.XMin;
                            Yminft = ife.Extent.YMin;
                            Xmaxft = ife.Extent.XMax;
                            Ymaxft = ife.Extent.YMax;
                        }
                    }
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
