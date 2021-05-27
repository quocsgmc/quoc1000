using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormPhu.QTHT
{
    public partial class QLNguoiDung_PhongBan : Form
    {
        DataTable tb;
        SqlDataAdapter dataAdapter1;
        DataTable tb2;
        SqlDataAdapter dataAdapter2;
        SqlCommandBuilder cmbl;
        public QLNguoiDung_PhongBan(int MaPhongBan)
        {
            InitializeComponent();
            tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand("[PRC_QUERY_USER_PB] " + MaPhongBan + "", connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
        }

    }
}
