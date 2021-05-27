using System;
using System.Data;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Base;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using System.Data.SqlClient;
using QLHTDT.FormPhu.QLQH;
using System.IO;
using System.Net;

namespace QLHTDT.FormPhu.QLKienTruc
{
    public partial class CapPhepXD : Form
    {
        SqlCommandBuilder cmbl;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        private AxMapControl mMapControl;
        private ESRI.ArcGIS.Carto.IMap dmap;

        public CapPhepXD(AxMapControl mapControl)
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map;
            this.mMapControl = mapControl;
            btXuLyHS.Enabled = false;
        }
        public CapPhepXD()
        {
            InitializeComponent();
            dmap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map;
            btXuLyHS.Enabled = false;
        }
        void showgridControl1()
        {
            tb = new DataTable();
            tbcheck = new DataTable();
            string sql = "select * from CPXD";
            SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
            dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql, connection));
            cmbl = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.Fill(tb);
            this.bindingSource1.DataSource = tb;
        }

        private void CapPhepXD_Load(object sender, EventArgs e)
        {
            GridView1.OptionsBehavior.Editable = false;

            //bindingSource1.DataSource = 
            string connectString = QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH);
            //bindingNavigator1.Visible = false;
            showgridControl1();
            //if (QLHTDT.Properties.Settings.Default.QuyenSuaDT == true) { button1.Visible = true; } else { button1.Visible = false; }
        }

        private void btThemHS_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            DangKyCapPhepXD frm = new DangKyCapPhepXD(date.Day.ToString(), date.Month.ToString(), date.Year.ToString());
            frm.Show();
            frm.FormClosed += new FormClosedEventHandler(frmDangKy_closed);
        }
        private void btCapNhatQH_Click(object sender, EventArgs e)
        {
            string sotoqr = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoTo").ToString();
            string sothuaqr = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoTo").ToString();
            string Phuongqr = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDPhuong").ToString();

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
                        string sql = "select * from CPXD";
                        SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                        SqlCommand command = new SqlCommand(sql, connection);
                        command.Connection.Open();
                        string querystr = "UPDATE CPXD SET [SoQD] ='" + CapNhatSoGPXD.SoGP + "' FROM CPXD WHERE [SoTo] =" + sotoqr + " and [SoThua] =" + sothuaqr + " and [Phuong] = N'" + Phuongqr + "' AND ID = (SELECT max(ID) FROM CPXD where [SoTo] ='" + sotoqr + "' and [SoThua] ='" +sothuaqr + "')";
                        SqlCommand query = new SqlCommand(querystr, connection);
                        string folder = Properties.Settings.Default.PathData + "\\FileDinhKemCPXD\\" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString();
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }
                            string file = Properties.Settings.Default.PathData + "\\FileDinhKemCPXD\\" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString() + "\\GPXD" + CapNhatSoGPXD.SoGP + ".pdf";
                        if (!File.Exists(file))
                        {
                            query.ExecuteNonQuery();
                            System.IO.File.Copy(openFileDialog.FileName, file);
                            string querystr2 = "UPDATE CPXD SET [TinhTrang] =N'Đã có kết quả', NgayCap = '" + CapNhatSoGPXD.Nam + "-" + CapNhatSoGPXD.Thang + "-" + CapNhatSoGPXD.Ngay + "' FROM CPXD WHERE [SoTo] =" + sotoqr + " and [SoThua] =" + sothuaqr + " and [Phuong] = N'" + Phuongqr + "'";
                            SqlCommand query2 = new SqlCommand(querystr2, connection);
                            query2.ExecuteNonQuery();
                            command.Connection.Close();
                            using (WebClient client = new WebClient())
                            {
                                client.Credentials = new NetworkCredential("sinhnv", "Abc#12344");
                                client.UploadFile("ftp://117.2.120.9/FileDinhKemCPXD/" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString() + "/GPXD" + CapNhatSoGPXD.SoGP + ".pdf", WebRequestMethods.Ftp.UploadFile, file);
                            }
                            showgridControl1();
                            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                        }
                        else
                        { DialogResult dialogResult = MessageBox.Show("Đã có dữ liệu này, có muốn thay thế hay không ?", "Thông báo", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                query.ExecuteNonQuery();
                                System.IO.File.Copy(openFileDialog.FileName, file,true);
                                string querystr2 = "UPDATE CPXD SET [TinhTrang] =N'Đã có kết quả', NgayCap = '" + CapNhatSoGPXD.Nam + "-" + CapNhatSoGPXD.Thang + "-" + CapNhatSoGPXD.Ngay + "' FROM CPXD WHERE [SoTo] =" + sotoqr + " and [SoThua] =" + sothuaqr + " and [Phuong] = N'" + Phuongqr + "'";
                                SqlCommand query2 = new SqlCommand(querystr2, connection);
                                query2.ExecuteNonQuery();
                                showgridControl1();
                                command.Connection.Close();
                                using (WebClient client = new WebClient())
                                {
                                    client.Credentials = new NetworkCredential("sinhnv", "Abc#1234");
                                    client.UploadFile("ftp://117.2.120.9/FileDinhKemCPXD/" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString() + "/GPXD" + CapNhatSoGPXD.SoGP + ".pdf", WebRequestMethods.Ftp.UploadFile, file);
                                }
                                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                            } 
                        }

                        
                        
                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
            }


        }
        public void CreateFeature(IFeatureClass featureClass, IPolygon Polygon)
        {
            // Ensure the feature class contains points.
            if (featureClass.ShapeType != esriGeometryType.esriGeometryPoint)
            {
                return;
            }

            // Build the feature.
            IFeature feature = featureClass.CreateFeature();
            feature.Shape = Polygon;

            // Apply the appropriate subtype to the feature.
            ISubtypes subtypes = (ISubtypes)featureClass;
            IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
            if (subtypes.HasSubtype)
            {
                // In this example, the value of 3 represents the Cross subtype.
                rowSubtypes.SubtypeCode = 3;
            }

            // Initialize any default values the feature has.
            rowSubtypes.InitDefaultValues();

            // Update the value on a string field that indicates who installed the feature.
            int contractorFieldIndex = featureClass.FindField("SoToBD");
            feature.set_Value(contractorFieldIndex, "999");

            // Commit the new feature to the geodatabase.
            feature.Store();
        }

        private void LoaiHoHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["TinhTrang"],
              new ColumnFilterInfo("[TinhTrang] like '%" + LoaiHoHS.Text + "%'", ""));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                GridView1.ActiveFilterString = (new OperandProperty("NgayThemHS") == DateTime.Today).ToString();
                if (LoaiHoHS.Text != null)
                {
                    ColumnView view = GridView1;
                    view.ActiveFilter.Add(view.Columns["TinhTrang"],
                      new ColumnFilterInfo("[TinhTrang] like '%" + LoaiHoHS.Text + "%'", ""));
                }
            }
            else
            {
                GridView1.ClearColumnsFilter();
            }
        }

        private void Btloadlailop_Click(object sender, EventArgs e)
        {
            LoaiHoHS.Text = "";
            LoaiHoHS.ResetText();
            GridView1.ClearColumnsFilter();
            GridView1.RefreshData();
            checkBox1.Checked = false;
        }
        string IDPhuong;
        private void btXuLyHS_Click(object sender, EventArgs e)
        {
            string cdt = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenCDT").ToString();
            string diachi = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DiaChi").ToString();
            string congtrinh = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "LoaiCT").ToString();
            string thietke = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ThietKe").ToString();////////
            string duong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Duong").ToString();/////////
            string viahe = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ViaHe").ToString();/////////
            string soto = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoTo").ToString();
            string sothua = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoThua").ToString();
            string phuong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Phuong").ToString();
            string khuqh = "";
            if (soto !="" & sothua != "" & phuong != "")
            {

                string table = "";
                if (phuong == "Hòa An")
                { table = "DIACHINH"; IDPhuong = "20306"; }
                else if (phuong == "Hòa Phát")
                { table = "DIACHINH"; IDPhuong = "20305"; }
                else if (phuong == "Hòa Thọ Đông")
                { table = "DIACHINH"; IDPhuong = "20312"; }
                else if (phuong == "Hòa Thọ Tây")
                { table = "DIACHINH"; IDPhuong = "20311"; }
                else if (phuong == "Hòa Xuân")
                { table = "DIACHINH"; IDPhuong = "20314"; }
                else if (phuong == "Khuê Trung")
                { table = "DIACHINH"; IDPhuong = "20260"; }
                else { MessageBox.Show("Chưa có thông tin phường", "Thông báo"); }
                if ((sothua == "") || (soto == "") || (sothua == "" && soto == ""))
                { MessageBox.Show("Chưa có thông tin số tờ hoặc số thửa.", "Thông báo"); }
                SqlConnection conn;
                SqlCommand command;
                conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                conn.Open();
                string sql = "SELECT [KhuQH] FROM " + table + " where SoThua = '" + sothua + "' and SoToBD = '" + soto + "' and IDPhuong = '"+IDPhuong+"'";
                command = new SqlCommand(sql, conn);
                if (command.ExecuteScalar() != DBNull.Value)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        khuqh = reader.GetString(0);
                        break;
                    }
                }
                conn.Close();
            }
            
            string dientich = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DT").ToString();
            string dientichxd = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DTXD").ToString();
            string tongdtsdd = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TongDTSDD").ToString();/////////
            string mdxd = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MDXD").ToString();/////////
            string hesosdd = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "HESOSDD").ToString();/////////
            string chieucaoct = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ChieuCao").ToString();
            string sotang = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoTang").ToString();
            string chieucaocactang = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ChieuCaoCacTang").ToString();/////////
            string cotnenct = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CotNen").ToString();/////////
            string khoanglui = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "KhoangLui").ToString();/////////
            string dovuon = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DoVuon").ToString();/////////
            string serigcn = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "seriGCN").ToString();/////////
            string ngaycapgcn = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NgayCapGCN").ToString();
            string qdkhac = " ";
            //QLHTDT.FormPhu.QLKienTruc.DangKyCapPhepXD frmDangKy = new QLHTDT.FormPhu.QLKienTruc.DangKyCapPhepXD(cdt, diachi, congtrinh, thietke, soto, sothua, duong, viahe, khuqh, phuong, dientich, dientichxd, tongdtsdd, mdxd, hesosdd, chieucaocactang,sotang,chieucaocactang,cotnenct,khoanglui,dovuon,serigcn,ngaycapgcn,qdkhac);
            //frmDangKy.Show();
            //frmDangKy.FormClosed += new FormClosedEventHandler(frmDangKy_closed);
            //if (frmDangKy.Visible == false)
            //{
            //    showgridControl1();
            //}
        }
        private void frmDangKy_closed(object sender, FormClosedEventArgs e)
        {
            showgridControl1();
        }
        private void GridView1_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRowsCount != 0)
            {
                btFileDinhKem.Enabled = true;
            }
            if (GridView1.SelectedRowsCount != 0 && GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Chưa xử lý")
            { btXuLyHS.Enabled = true; }
            else { btXuLyHS.Enabled = false; }

            if (GridView1.SelectedRowsCount != 0 && (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Đang trình phê duyệt")| GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TinhTrang").ToString() == "Đã có kết quả")
            { btCapNhatQH.Enabled = true; }
            else { btCapNhatQH.Enabled = false; }
        }
        private bool FtpDirectoryExists(string directory, string username, string password)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(directory);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(username, password);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return true;
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void btFileDinhKem_Click(object sender, EventArgs e)
        {
            if (FtpDirectoryExists("ftp://117.2.120.9/FileDinhKemCPXD/" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString(), "sinhnv", "Abc#1234"))
            {
                QLHTDT.FormPhu.QLQH.listfilefolder frm = new listfilefolder("ftp://117.2.120.9/FileDinhKemCPXD/" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString(), "sinhnv", "Abc#1234");
                frm.Show();
            }
            else
            {
                WebRequest request = WebRequest.Create("ftp://117.2.120.9/FileDinhKemCPXD/" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString());
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential("sinhnv", "Abc#1234");
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }
            }
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            if (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoQD").ToString() != "" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoQD").ToString()!= null)
            {
                //string file = Properties.Settings.Default.PathData + "\\FileDinhKemCPXD\\" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString() + "\\GPXD" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoQD").ToString().Replace(" ", "").ToString() + ".pdf";
                ////System.Diagnostics.Process.Start(file);
                if (FtpDirectoryExists("ftp://117.2.120.9/FileDinhKemCPXD/" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString() + "/GPXD" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoQD").ToString() + ".pdf", "sinhnv", "Abc#1234"))
                {
                    string file = "";
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"Downloads");
                    saveFileDialog1.Title = "Lưu file";
                    //saveFileDialog1.CheckFileExists = true;
                    //saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.FileName = "GPXD" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoQD").ToString().Replace(" ", "").ToString() + ".pdf";
                    saveFileDialog1.DefaultExt = "txt";
                    saveFileDialog1.Filter = "All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        file = saveFileDialog1.FileName;
                    }
                    if (file != "" & file != null)
                    {
                        using (WebClient client = new WebClient())
                        {
                            client.Credentials = new NetworkCredential("sinhnv", "Abc#1234");
                            client.DownloadFile("ftp://117.2.120.9/FileDinhKemCPXD/" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "MaHS").ToString().Replace(" ", "").ToString() + "/GPXD" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SoQD").ToString() + ".pdf", file);
                        }
                        //System.Diagnostics.Process.Start(fileluu);
                        QLHTDT.FormPhu.ViewPDF frmpdf = new ViewPDF(file);
                        frmpdf.Show();
                    }
                    
                }
                    
            }
            
        }

        private void BtTracuu_Click(object sender, EventArgs e)
        {
            ColumnView view = GridView1;
            view.ActiveFilter.Add(view.Columns["DiaChi"],
              new ColumnFilterInfo("[DiaChi] like '%" + txDiaChi.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["TenCDT"],
              new ColumnFilterInfo("[TenCDT] like '%" + tbChuDauTu.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["SoTo"],
              new ColumnFilterInfo("[SoTo] like '%" + tbSoTo.Text + "%'", ""));
            view.ActiveFilter.Add(view.Columns["SoThua"],
              new ColumnFilterInfo("[SoThua] like '%" + tbSoThua.Text + "%'", ""));
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
    }
}
