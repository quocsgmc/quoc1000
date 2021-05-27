using QLHTDT.FormChinh;
using System;
using System.Collections;
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
    public partial class EditPhongBan : Form
    {
        int IDPB;
        public static string MaHuyen = "null";
        int AddQuan = 0;
        public EditPhongBan()
        {
            InitializeComponent();
        }
        public EditPhongBan(int ID)
        {
            IDPB = ID;
            InitializeComponent();
            //showgridControl1();
        }
        public class typePB
        {
            private int idloai;
            private string tenloai;
            public int IDLoai
            {
                get { return idloai; }
                set { idloai = value; }
            }
            public string TENLOAI
            {
                get { return tenloai; }
                set { tenloai = value; }
            }
            public typePB(int IDLoai, string TENLOAI)
            {
                this.IDLoai = IDLoai;
                this.TENLOAI = TENLOAI;
            }
            public override string ToString()
            {
                return "ID: " + idloai + " | LOAI: " + tenloai;
            }
        }
        private void CbbLOAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbbLOAI.Text == "Phòng ban cấp Sở")
            {
                cbbDVHC.Visible = false;
                cbbPhuongXa.Visible = false;
                cbbDVHC.Text = "";
                cbbPhuongXa.Text = "";
            }
            else if (CbbLOAI.Text == "Phòng ban cấp Quận/Huyện")
            {
                cbbDVHC.Visible = true;
                cbbPhuongXa.Visible = false;
                cbbPhuongXa.Text = "";
            }
            else if (CbbLOAI.Text == "Phòng ban cấp Phường/Xã")
            {
                cbbDVHC.Visible = true;
                cbbPhuongXa.Visible = true;
            }
            else
            {
                cbbPhuongXa.Visible = true;
                cbbDVHC.Visible = true;
                cbbPhuongXa.Visible = true;
            }
        }
        private void cbbDVHC_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddQuan = 1;
            cbbPhuongXa.ResetText();
            if (cbbDVHC.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                AddQuan = 0;
                cbbDVHC.Text = "";
            }
            if (AddQuan == 1)
            {
                MaHuyen = cbbDVHC.SelectedValue.ToString();
                string sqlPhuong = "[PRC_Query_TenXa_By_MAXa] null, " + MaHuyen + " ";

                SqlDataAdapter adp = new SqlDataAdapter(sqlPhuong, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cbbPhuongXa.DataSource = ds.Tables[0];
                cbbPhuongXa.DisplayMember = "TenPhuong";
                cbbPhuongXa.ValueMember = "MaPhuong";

                if (cbbPhuongXa.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    AddQuan = 0;
                    cbbPhuongXa.Text = "";
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn chỉnh sửa Phòng ban không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //check input
                string Quan = "null";
                string Phuong = "null";
                if (cbbDVHC.Text != "")
                {
                    Quan = cbbDVHC.SelectedValue.ToString();
                }
                if (cbbPhuongXa.Text != "")
                {
                    Phuong = cbbPhuongXa.SelectedValue.ToString();
                }
                try
                {
                    if (CbbLOAI.SelectedItem == null)
                    {
                        MessageBox.Show("Chưa chọn Phòng ban!", "Thông báo");
                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        conn.Open();
                        string sql1 = "[PRC_UPDATE_PHONGBAN] "
                                + " " + IDPB
                                + ", N'" + tbTenpb.Text
                                + "', N'" + TbMOTA.Text
                                + "', " + CbbLOAI.SelectedValue
                                + ", '" + Quan
                                + "', '" + Phuong + "'";
                        SqlCommand command4 = new SqlCommand(sql1, conn);
                        command4.ExecuteScalar();
                        //Phần này là lưu nhật ký
                        KienTruc.TBNK = new DataTable();
                        SqlConnection connectionNK = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        KienTruc.dataAdapterNK = new SqlDataAdapter(new SqlCommand("Select * From NhatKy", connectionNK));
                        SqlCommandBuilder cmbl = new SqlCommandBuilder(KienTruc.dataAdapterNK);
                        KienTruc.dataAdapterNK.Fill(KienTruc.TBNK);
                        KienTruc.ChinhSuathuoctinhToolQuanLy("Phòng ban", IDPB);
                        KienTruc.dataAdapterNK.Update(KienTruc.TBNK);
                        MessageBox.Show("Chỉnh sửa thông tin Phòng ban thành công", "Thông báo");
                        this.Hide();
                    }
                }
                catch
                {

                }
            }
        }

        private void EditPhongBan_Load(object sender, EventArgs e)
        {
            ArrayList LoaiPhongBan = new ArrayList();
            LoaiPhongBan.Add(new typePB(0, "Phòng ban cấp Sở"));
            LoaiPhongBan.Add(new typePB(1, "Phòng ban cấp Quận/Huyện"));
            LoaiPhongBan.Add(new typePB(2, "Phòng ban cấp Phường/Xã"));
            LoaiPhongBan.Add(new typePB(3, "Phòng ban khác"));
            CbbLOAI.DataSource = LoaiPhongBan;
            CbbLOAI.DisplayMember = "tenloai";
            CbbLOAI.ValueMember = "idloai";

            string SqlQuan = "[PRC_Query_TenHuyen_By_MAHuyen] null";
            SqlDataAdapter queryQuan = new SqlDataAdapter(SqlQuan, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            DataSet ds = new DataSet();
            queryQuan.Fill(ds);
            cbbDVHC.DataSource = ds.Tables[0];
            cbbDVHC.DisplayMember = "TENHUYEN";
            cbbDVHC.ValueMember = "MAHUYEN";

            DataTable tb = new DataTable();
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand("[PRC_QUERY_PHONGBAN] " + IDPB, connection));
            SqlCommandBuilder cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            tbTenpb.Text = tb.Rows[0][1].ToString();
            TbMOTA.Text = tb.Rows[0][2].ToString();
            CbbLOAI.SelectedValue = tb.Rows[0][8];
            cbbDVHC.Text = tb.Rows[0][3].ToString();
            cbbPhuongXa.Text = tb.Rows[0][4].ToString();
        }
    }
}
