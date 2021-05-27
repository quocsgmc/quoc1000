using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.DataSourcesGDB;
using System.Data.SqlClient;
using QLHTDT.FormChinh;

namespace QLHTDT.FormPhanHe.QuyHoach_KienTruc
{
    public partial class ChinhSuaMBQH : Form
    {
        int AddQuan = 0;
        int IDChinhSua;
        public ChinhSuaMBQH(int OBJECTID)
        {
            InitializeComponent();
            IDChinhSua = OBJECTID;
        }

        private void ChinhSuaMBQH_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from BANGMAULOAIDAT where KyHieu Like '%QH%'", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            adp.Fill(ds);
            ComboTenLoaiDat.DataSource = ds.Tables[0];
            ComboTenLoaiDat.DisplayMember = "tenMucDich";
            ComboTenLoaiDat.ValueMember = "KyHieu";

        }

        private void ComboTenLoaiDat_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            if (ComboTenLoaiDat.SelectedValue.ToString() == "System.Data.DataRowView" || ComboTenLoaiDat.SelectedValue.ToString() == "Chọn trường dữ liệu")
            {
                AddQuan = 0;
                ComboTenLoaiDat.Text = "Chọn trường dữ liệu";
            }
            if (AddQuan == 1)
            {
                DataSet ds2 = new DataSet();
                SqlDataAdapter adp2 = new SqlDataAdapter("select * from BANGMAULOAIDAT where KyHieu Like '%QH%' and tenMucDich = N'" + ComboTenLoaiDat.Text + "' ", QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                adp2.Fill(ds2);
                comboMaLoaiDat.Items.Clear();
                for (int intCount = 0; intCount < ds2.Tables[0].Rows.Count; intCount++)
                {
                    var val = ds2.Tables[0].Rows[intCount]["KyHieu"].ToString();

                    comboMaLoaiDat.Text = val;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (ComboTenLoaiDat.Text != "Chọn trường dữ liệu")
            {

                int objectid;
                objectid = IDChinhSua;
                string TenLoaiDat = "null";
                if (ComboTenLoaiDat.SelectedValue.ToString() == "System.Data.DataRowView" || ComboTenLoaiDat.Text != "")
                {
                    TenLoaiDat = ComboTenLoaiDat.Text;
                }
                else
                {
                    MessageBox.Show("Chưa chọn Tên loại đất!\n" + "Vui lòng chọn lại dữ liệu", "Thông báo");
                    Cursor = Cursors.Default; return;
                }
                //cập nhật thuộc tính đối tượng
                SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                conn.Open();
                string sql1 = "[PRC_UPDATE_MBQH_BY_ID] " //update MBQH
                   + " " + objectid
                   + ", N'" + TenLoaiDat
                   + "', N'" + comboMaLoaiDat.Text
                   + "', N'" + textBox1.Text + "'";
                SqlCommand command4 = new SqlCommand(sql1, conn);
                command4.ExecuteScalar();
                //Phần này là lưu nhật ký
                KienTruc.TBNK = new DataTable();
                SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                KienTruc.ChinhSuathuoctinhToolQuanLy("Mặt bằng quy hoạch", objectid);
                KienTruc.dataAdapterNK.Update(KienTruc.TBNK);

                MessageBox.Show("Chỉnh sửa Mặt bằng quy hoạch thành công", "Thông báo");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Chưa chọn loại đất cần cập nhật", "Thông báo");
            }
             Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
