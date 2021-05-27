using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhanHe.CayXanh.QLCayXanh
{
    public partial class ThemURLFileDinhKem : Form
    {
        DataTable dt = new DataTable();
        public ThemURLFileDinhKem()
        {
            InitializeComponent();
        }

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
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                comboBox1.Items.Add(dgvData.Columns[i].HeaderText);
                comboBox2.Items.Add(dgvData.Columns[i].HeaderText);
                comboBox3.Items.Add(dgvData.Columns[i].HeaderText);
            }
        }
        int iLoi;
        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin cập nhật", "Thông báo");
                return;
            }
            IFeature feature = null;
            int objectid;
            Cursor = Cursors.WaitCursor;
            try
            {
                int IDCayXanh = -1;
                int Name = -1;
                int Url = -1;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dgvData.Columns[i].HeaderText == comboBox1.Text)
                    {
                        IDCayXanh = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboBox2.Text)
                    {
                        Name = i;
                    }
                    if (dgvData.Columns[i].HeaderText == comboBox3.Text)
                    {
                        Url = i;
                    }
                }
                try
                {
                    for (iLoi = 0; iLoi < dgvData.RowCount - 1; iLoi++)
                    {
                        string IDCayXanh1;
                        string Name1;
                        string Url1;
                        string Type = "null";
                        if (comboBox1.Text != "")
                        { IDCayXanh1 = dgvData.Rows[iLoi].Cells[IDCayXanh].Value.ToString(); }
                        else { IDCayXanh1 = "null"; }
                        if (comboBox2.Text != "")
                        { Name1 = dgvData.Rows[iLoi].Cells[Name].Value.ToString(); }
                        else { Name1 = "null"; }
                        if (comboBox3.Text != "")
                        { Url1 = dgvData.Rows[iLoi].Cells[Url].Value.ToString(); }
                        else { Url1 = ""; }
                        
                        //cập nhật thuộc tính đối tượng
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_INSERT_CAYXANH_ASSET1] " //update Cây xanh
                       + " " + IDCayXanh1
                       + ", N'" + Name1
                       + "', N'" + Url1
                       + "', " + Type + "";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                    }
                    MessageBox.Show("Thêm mới Url thành công", "Thông báo");
                    this.Hide(); Cursor = Cursors.Default;
                }
                catch
                {
                    if (feature != null)
                    { feature.Delete(); }
                    int DongBiLoi = iLoi + 2;
                    MessageBox.Show("Dữ liệu dòng thứ " + DongBiLoi + " bị sai định dạng. Vui lòng thử lại", "Thông báo");
                    Cursor = Cursors.Default;
                }
            }
            catch
            {
                //xóa đối tượng đã tạo nếu có lỗi
                if (feature != null)
                { feature.Delete(); }

                MessageBox.Show("Thêm mới URL thất bại. Vui lòng kiểm tra dữ liệu", "Thông báo");
                Cursor = Cursors.Default;
            }

            QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
            Cursor = Cursors.Default;
        }
    }
}
