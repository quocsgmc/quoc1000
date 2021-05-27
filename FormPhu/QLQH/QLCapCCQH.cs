using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using QLHTDT.FormPhu.QLQH;
using System.IO;
using QLHTDT.FormPhu.QLKienTruc;

namespace QLHTDT.FormPhu.QLQH
{
    public partial class QLCapCCQH : Form
    {
        public QLCapCCQH()
        {
            InitializeComponent();
            showgridControl1();
            GridView1.OptionsBehavior.Editable = false;
            
        }
        public void showgridControl1()
        {
            DataTable tb = new DataTable();
            string sql = "SELECT * FROM HoSoCapChungChiQH";
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            SqlCommandBuilder cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
        }


        private void btThemHS_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.QLQH.ThemHoSoCapCCQH frmThemHS = new QLHTDT.FormPhu.QLQH.ThemHoSoCapCCQH();
            frmThemHS.Show();
            frmThemHS.FormClosed += new FormClosedEventHandler(frmThemHS_closed);
            //if (frmDangKy.Visible == false)
            //{
            //    showgridControl1();
            //}
        }
        private void frmThemHS_closed(object sender, FormClosedEventArgs e)
        {
            showgridControl1();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                var date = DateTime.Now;
                string Day = date.Day.ToString();
                string Month = date.Month.ToString();
                string Yeah = date.Year.ToString();
                GridView1.ActiveFilterString = (new OperandProperty("NgayNopDon") == DateTime.Today).ToString();
                if (TinhTrang.Text != null)
                {
                    ColumnView view = GridView1;
                    view.ActiveFilter.Add(view.Columns["NgayNopDon"],
                      new ColumnFilterInfo("[NgayNopDon] like '%" +  Month +"/"+ Day + "/" + Yeah + "%'", ""));
                    view.ActiveFilter.Add(view.Columns["TinhTrang"],
                      new ColumnFilterInfo("[TinhTrang] like '%" + TinhTrang.Text + "%'", ""));
                }
            }
            else
            {
                GridView1.ClearColumnsFilter();

            }
        }

        private void GridView1_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRowsCount != 0 && GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Chưa xử lý")
            { btXLHS.Enabled = true; }
            else { btXLHS.Enabled = false; }
            if (GridView1.SelectedRowsCount != 0)
            {
                btFileDinhKem.Enabled = true;
            }
            if (GridView1.SelectedRowsCount != 0 && GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Chưa xử lý")
            { btXLHS.Enabled = true; }
            else { btXLHS.Enabled = false; }

            if (GridView1.SelectedRowsCount != 0 && (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Đang trình phê duyệt") | GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Đã có kết quả")
            { btCapNhatQD.Enabled = true; }
            else { btCapNhatQD.Enabled = false; }
        }

        private void btXLHS_Click(object sender, EventArgs e)
        {
            string nguoigui = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NguoiGui").ToString();
            string hokhau = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "HoKhauThuongTru").ToString();
            string nams = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NamSinh").ToString();
            string sdtcodinh = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SDT").ToString();
            string sdtdidong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SDT").ToString();
            string vitrithuadat = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DiaChiThuaDat").ToString();
            string soto = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString();
            string sothua = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString();
            string to = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ToDanPho").ToString();
            //string to = "16";
            string phuong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Phuong").ToString();
            //string phuong = "Hòa An";
            string mucdich = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MucDich").ToString();
            string MaHS = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString();
            QLHTDT.FormPhu.QLQH.ThemHoSoCapCCQH frmThemHS = new QLHTDT.FormPhu.QLQH.ThemHoSoCapCCQH(nguoigui, hokhau, nams, sdtcodinh, sdtdidong, vitrithuadat, soto, sothua, to, phuong, mucdich, MaHS);
            frmThemHS.Show();
            frmThemHS.FormClosed += new FormClosedEventHandler(frmThemHS_closed);
        }

        private void TinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["TinhTrang"],
              new ColumnFilterInfo("[TinhTrang] like '%" + TinhTrang.Text + "%'", ""));
        }

        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            textBoxNguoiGui.ResetText();
            textBoxDiaChi.ResetText();
            TinhTrang.ResetText();
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
            checkBox1.Checked = false;
        }

        private void btFileDinhKem_Click(object sender, EventArgs e)
        {
            //QLHTDT.FormPhu.QLQH.listfilefolder frm = new listfilefolder(Properties.Settings.Default.PathData + "\\FileDinhKemXNQH\\test");
            //frm.Show();

            string path = Properties.Settings.Default.PathData + "\\FileDinhKemXNQH\\HS" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString();
            if (Directory.Exists(path))
            {
                QLHTDT.FormPhu.QLQH.listfilefolder frm = new listfilefolder(path);
                frm.Show();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Chưa có dữ liệu file đính kèm, Có cập nhật dữ liệu hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Directory.CreateDirectory(path);
                    System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                    openFileDialog.InitialDirectory = @"C:\";
                    openFileDialog.Filter = "All file (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.Multiselect = true;
                    openFileDialog.ShowDialog();
                }
            }
        }

        private void btCapNhatQD_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            if (Properties.Settings.Default.pathPDF != null)
            {
                openFileDialog.InitialDirectory = Properties.Settings.Default.pathPDF;
            }
            else { openFileDialog.InitialDirectory = @"C:\"; }
            openFileDialog.Filter = "file pdf (*.pdf)|*.pdf";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.pathPDF = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                CapNhatSoGPXD frmCapNhatSoGP = new CapNhatSoGPXD();
                frmCapNhatSoGP.ShowDialog();
                if (frmCapNhatSoGP.Visible == false && CapNhatSoGPXD.SoGP != "")
                {
                    try
                    {
                        string sql = "select * from HoSoCapChungChiQH";
                        SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        SqlCommand command = new SqlCommand(sql, connection);
                        command.Connection.Open();
                        string querystr = "UPDATE HoSoCapChungChiQH SET SOGXNQH ='" + CapNhatSoGPXD.SoGP + "' FROM [HoSoCapChungChiQH] WHERE [SoToBD] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + " and [SoThua] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + " and [Phuong] = N'" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Phuong").ToString() + "' AND MaHS = (SELECT max(MaHS) FROM HoSoCapChungChiQH where [SoToBD] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "')";
                        SqlCommand query = new SqlCommand(querystr, connection);
                        string folder = Properties.Settings.Default.PathData + "\\FileDinhKemXNQH\\HS" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString();
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }
                        string file = Properties.Settings.Default.PathData + "\\FileDinhKemXNQH\\HS" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString() + "\\XNQH" + CapNhatSoGPXD.SoGP + ".pdf";
                        if (!File.Exists(file))
                        {
                            query.ExecuteNonQuery();

                            DataTable tbupdate = new DataTable();
                            string sqlupdate = "SELECT * FROM HoSoCapChungChiQH";
                            SqlConnection connectionupdate = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand(sqlupdate, connectionupdate));
                            SqlCommandBuilder cmbl = new SqlCommandBuilder(dataAdapter1);
                            dataAdapter1.Fill(tbupdate);
                            this.bindingSource1.DataSource = tbupdate;

                            System.IO.File.Copy(openFileDialog.FileName, file);
                            string querystr2 = "UPDATE HoSoCapChungChiQH SET [TinhTrang] =N'Đã có kết quả'  FROM HoSoCapChungChiQH WHERE [SoToBD] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + " and [SoThua] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + " and [Phuong] = N'" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Phuong").ToString() + "' AND MaHS = (SELECT max(MaHS) FROM HoSoCapChungChiQH where [SoToBD] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "')";
                            SqlCommand query2 = new SqlCommand(querystr2, connection);
                            query2.ExecuteNonQuery();
                            string querystr3 = "UPDATE HoSoCapChungChiQH SET NgayCapXNQH = '" + CapNhatSoGPXD.Nam + "-" + CapNhatSoGPXD.Thang + "-" + CapNhatSoGPXD.Ngay + "' FROM HoSoCapChungChiQH WHERE [SoToBD] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + " and [SoThua] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + " and [Phuong] = N'" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Phuong").ToString() + "' AND SOGXNQH = (SELECT max(MaHS) FROM HoSoCapChungChiQH where [SoToBD] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "')";
                            SqlCommand query3 = new SqlCommand(querystr3, connection);
                            query3.ExecuteNonQuery();
                            command.Connection.Close();
                            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                            showgridControl1();
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Đã có dữ liệu này, có muốn thay thế hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                query.ExecuteNonQuery();

                                DataTable tbupdate = new DataTable();
                                string sqlupdate = "SELECT * FROM HoSoCapChungChiQH";
                                SqlConnection connectionupdate = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand(sqlupdate, connectionupdate));
                                SqlCommandBuilder cmbl = new SqlCommandBuilder(dataAdapter1);
                                dataAdapter1.Fill(tbupdate);
                                this.bindingSource1.DataSource = tbupdate;

                                System.IO.File.Copy(openFileDialog.FileName, file, true);
                                string querystr2 = "UPDATE HoSoCapChungChiQH SET [TinhTrang] =N'Đã có kết quả' FROM HoSoCapChungChiQH WHERE [SoToBD] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + " and [SoThua] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + " and [Phuong] = N'" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Phuong").ToString() + "' AND MaHS = (SELECT max(MaHS) FROM HoSoCapChungChiQH where [SoToBD] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "')";
                                SqlCommand query2 = new SqlCommand(querystr2, connection);
                                query2.ExecuteNonQuery();
                                string querystr3 = "UPDATE HoSoCapChungChiQH SET NgayCapXNQH = '" + CapNhatSoGPXD.Nam + "-" + CapNhatSoGPXD.Thang + "-" + CapNhatSoGPXD.Ngay + "' FROM HoSoCapChungChiQH WHERE [SoToBD] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + " and [SoThua] =" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + " and [Phuong] = N'" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Phuong").ToString() + "' AND MaHS = (SELECT max(MaHS) FROM HoSoCapChungChiQH where [SoToBD] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoToBD").ToString() + "' and [SoThua] ='" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString() + "')";
                                SqlCommand query3 = new SqlCommand(querystr3, connection);
                                query3.ExecuteNonQuery();
                                command.Connection.Close();
                                showgridControl1();
                                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                            }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void BtTracuu_Click(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["NguoiGui"],
              new ColumnFilterInfo("[NguoiGui] like '%" + textBoxNguoiGui.Text + "%'", ""));

            view.ActiveFilter.Add(view.Columns["DiaChiThuaDat"],
              new ColumnFilterInfo("[DiaChiThuaDat] like '%" + textBoxDiaChi.Text + "%'", ""));
        }

        private void BtExcell_Click(object sender, EventArgs e)
        {
            SaveFileDialog openf = new SaveFileDialog();
            openf.Filter = "xls|*.xls";
            if (openf.ShowDialog() == DialogResult.OK)
            {
                GridView1.ExportToXls(openf.FileName);
            }
        }

        private void textBoxNguoiGui_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
