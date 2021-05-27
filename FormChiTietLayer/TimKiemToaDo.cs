using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using QLHTDT.FormChinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHTDT.FormChiTietLayer
{
    public partial class TimKiemToaDo : Form
    {
        private ESRI.ArcGIS.Carto.IMap dmap;
        DataTable tb;
        DataTable tbcheck;
        SqlDataAdapter dataAdapter1;
        SqlCommandBuilder cmbl;
        public static ILayer layeredit;
        string PhuongKT = "Địa chính";
        string layerget = "Địa chính";
        public TimKiemToaDo()
        {
            InitializeComponent();
        }
        private void ZoomToLayers()
        {
            ICommand command = new ControlsZoomToSelectedCommand();
            command.OnCreate(QLHTDT.FormChinh.KienTruc.axMapControl1.Object);
            QLHTDT.FormChinh.KienTruc.axMapControl1.CurrentTool = command as ITool;
            command.OnClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    string sql8 = "SELECT TOP 1 [OBJECTID],SoToBD,SoThua,IDPhuong from DIACHINH D where LoaiDat != 'DGT' and IDPhuong = (select top 1 MaPhuong from PhuongXa where Shape.STContains(geometry::STGeomFromText('POINT(" + textBox1.Text + " " + textBox2.Text + ")', 0)) = 1 ) and Shape.STContains(geometry::STGeomFromText('POINT(" + textBox1.Text + " " + textBox2.Text + ")', 0)) = 1 ";
                    DataSet ds = new DataSet();
                    SqlDataAdapter adp = new SqlDataAdapter(sql8, QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    adp.FillSchema(ds, SchemaType.Source);
                    adp.Fill(ds);

                    string SoToBD = ds.Tables[0].Rows[0]["SoToBD"].ToString();
                    string SoThua = ds.Tables[0].Rows[0]["SoThua"].ToString();
                    string IDPhuong = ds.Tables[0].Rows[0]["IDPhuong"].ToString();
                    var val = ds.Tables[0].Rows[0]["OBJECTID"].ToString();
                    int OBJECTIDThuaDat;
                    Int32.TryParse(val, out OBJECTIDThuaDat);
                    string sql9 = "[PRC_QUERY_TABLE_DiaChinh_BY_ID] " + OBJECTIDThuaDat + "";
                    tb = new DataTable();
                    SqlConnection connection = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                    dataAdapter1 = new SqlDataAdapter(new SqlCommand(sql9, connection));
                    cmbl = new SqlCommandBuilder(dataAdapter1);
                    dataAdapter1.Fill(tb);
                    this.bindingSource1.DataSource = tb;

                    try
                    {
                        //string IDPhuong = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDPhuong").ToString();
                        string layerget = "Địa chính";
                        string tableKT = "VungKhongGianKienTruc";
                        int KTMoLop = 0;
                        string PhuongKT = "Địa chính";
                        try
                        {
                            PhuongKT = "Địa chính";
                            for (int i1 = 0; i1 < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i1++)
                            {
                                if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == "Địa chính")
                                {
                                    IFeatureLayer ilayer1 = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1) as IFeatureLayer;
                                    KTMoLop = KTMoLop + 1;
                                    layeredit = ilayer1;
                                    KienTruc.axMapControl1.Extent = layeredit.AreaOfInterest;
                                }
                                else
                                {
                                    if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1).Name == layerget)
                                    {
                                        KTMoLop = KTMoLop + 1;
                                        layeredit = QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i1);
                                        KienTruc.axMapControl1.Extent = KienTruc.axMapControl1.get_Layer(i1).AreaOfInterest;
                                    }
                                }
                            }
                            if (KTMoLop == 0)
                            {
                                QLHTDT.FormChinh.KienTruc.axMapControl1.AddLayerFromFile(QLHTDT.Properties.Settings.Default.PathData + "\\Dữ liệu dùng chung\\Địa chính.lyr");
                                QLHTDT.FormChinh.KienTruc.axMapControl1.Refresh();
                                for (int i = 0; i < QLHTDT.FormChinh.KienTruc.axMapControl1.LayerCount; i++)
                                {
                                    if (QLHTDT.FormChinh.KienTruc.axMapControl1.get_Layer(i).Name == layerget)
                                    {
                                        KTMoLop = KTMoLop + 1;
                                        layeredit = FormChinh.KienTruc.axMapControl1.get_Layer(i);
                                        KienTruc.axMapControl1.Extent = KienTruc.axMapControl1.get_Layer(i).AreaOfInterest;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message);
                        }
                        ICommand command = new ControlsClearSelectionCommand();
                        command.OnCreate(KienTruc.axMapControl1.Object);
                        KienTruc.axMapControl1.CurrentTool = command as ITool;
                        command.OnClick();

                        if (layeredit != null)
                        {
                            IFeatureLayer pFeatureLayer2 = (IFeatureLayer)layeredit;
                            IFeatureSelection featSelect = pFeatureLayer2 as IFeatureSelection;
                            IQueryFilter pFilter = new QueryFilterClass();
                            EnvelopeClass pEnvelope = new EnvelopeClass();
                            if (IDPhuong == "")
                            {
                                MessageBox.Show("Thông báo", "Chưa chọn phường cần tra cứu");

                            }
                            else if (textBox1.Text != "")
                            {
                                if (textBox1.Text != "" && textBox2.Text != "")
                                {
                                    pFilter.WhereClause = "[SoToBD] = '" + SoToBD + "' AND [SoThua] = '" + SoThua + "' and IDPhuong = '" + IDPhuong + "'";
                                    featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);

                                }
                                else if (textBox1.Text != "" && textBox2.Text == "")
                                {
                                    pFilter.WhereClause = "[SoToBD] = '" + SoToBD + "'and IDPhuong = '" + IDPhuong + "'";
                                    featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                                }
                                else if (SoToBD == "" && SoThua != "")
                                {
                                    pFilter.WhereClause = "[SoThua] = '" + SoThua + "'and IDPhuong = '" + IDPhuong + "'";
                                    featSelect.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                                }
                                else
                                {
                                    MessageBox.Show("Chưa chọn số tờ bản đồ hoặc số thửa đất cần tra cứu", "Thông báo");
                                }
                                ZoomToLayers();
                            }
                            IEnumIDs idList = featSelect.SelectionSet.IDs;
                            int index = idList.Next();
                            List<int> indexes = new List<int>();
                            while (index != -1)
                            {
                                indexes.Add(index);
                                index = idList.Next();
                            }
                            IFeatureClass featureClass = pFeatureLayer2.FeatureClass;

                            KienTruc.tt = new DataTable();
                            KienTruc.tt.Columns.Add("Mã", typeof(String));
                            KienTruc.tt.Columns.Add("Số tờ bản đồ", typeof(String));
                            KienTruc.tt.Columns.Add("Số thửa", typeof(String));
                            KienTruc.tt.Columns.Add("Diện tích", typeof(String));
                            KienTruc.tt.Columns.Add("Loại đất", typeof(String));
                            KienTruc.tt.Columns.Add("Phường", typeof(String));
                            KienTruc.tt.Columns.Add("Thông tin quy hoạch", typeof(String));
                            KienTruc.tt.Columns.Add("Phường1", typeof(String));
                            KienTruc.tt.Columns.Add("Loại đất1", typeof(String));
                            KienTruc.tt.Columns.Add("TenKhuVuc", typeof(String));
                            KienTruc.tt.Columns.Add("TangCaoXD", typeof(String));
                            KienTruc.tt.Columns.Add("ChiGioiXD", typeof(String));
                            KienTruc.tt.Columns.Add("ChieuCaoTang", typeof(String));
                            KienTruc.tt.Columns.Add("CotNen", typeof(String));
                            KienTruc.tt.Columns.Add("QDKhac", typeof(String));
                            KienTruc.tt.Columns.Add("SoGPXD", typeof(String));
                            KienTruc.tt.Columns.Add("TTCPXD", typeof(String));
                            KienTruc.tt.Columns.Add("MaHSCPXD", typeof(String));
                            if (featSelect.SelectionSet.Count == 0) { MessageBox.Show("Không có thửa đất nào", "Thông báo"); }
                            for (int i2 = 0; i2 < featSelect.SelectionSet.Count; i2++)
                            {
                                IFeature feature = featureClass.GetFeature(indexes[i2]);
                                KienTruc.dr = KienTruc.tt.NewRow();
                                KienTruc.dr[0] = feature.get_Value(feature.Fields.FindField("OBJECTID")).ToString();
                                if (feature.get_Value(feature.Fields.FindField("SoToBD")) != DBNull.Value)
                                {
                                    KienTruc.dr[1] = feature.get_Value(feature.Fields.FindField("SoToBD")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("SoThua")) != DBNull.Value)
                                {
                                    KienTruc.dr[2] = feature.get_Value(feature.Fields.FindField("SoThua")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("DienTich")) != DBNull.Value)
                                {
                                    KienTruc.dr[3] = feature.get_Value(feature.Fields.FindField("DienTich")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("LoaiDat")) != DBNull.Value)
                                {
                                    KienTruc.dr[4] = feature.get_Value(feature.Fields.FindField("LoaiDat")).ToString();
                                }
                                if (feature.get_Value(feature.Fields.FindField("IDPhuong")) != DBNull.Value)
                                {
                                    //KienTruc.dr[5] = feature.get_Value(feature.Fields.FindField("TenPhuong")).ToString();
                                    string IDPhuong1 = feature.get_Value(feature.Fields.FindField("IDPhuong")).ToString().Replace(" ", "");
                                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                    conn.Open();
                                    string sql1 = "select TenPhuong from PhuongXa where PhuongXa.MaPhuong = '" + IDPhuong1 + "'";
                                    SqlCommand command1 = new SqlCommand(sql1, conn);
                                    if (command1.ExecuteScalar() != DBNull.Value)
                                    {
                                        KienTruc.dr[5] = (string)command1.ExecuteScalar();
                                    }
                                }
                                if (feature.get_Value(feature.Fields.FindField("MaDuAnQH")) != DBNull.Value)
                                {
                                    //KienTruc.dr[6] = feature.get_Value(feature.Fields.FindField("TenDuAn")).ToString();
                                    string MaDuAnQH = feature.get_Value(feature.Fields.FindField("MaDuAnQH")).ToString().Replace(" ", "");
                                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                    conn.Open();
                                    string sql1 = "select Tendoan from DOANQUYHOACH where DOANQUYHOACH.Madoan = '" + MaDuAnQH + "'";
                                    SqlCommand command1 = new SqlCommand(sql1, conn);
                                    if (command1.ExecuteScalar() != DBNull.Value)
                                    {
                                        KienTruc.dr[6] = (string)command1.ExecuteScalar();
                                    }
                                }
                                if (feature.get_Value(feature.Fields.FindField("MaKVKT")) != DBNull.Value)
                                {

                                    string MaKT = feature.get_Value(feature.Fields.FindField("MaKVKT")).ToString().Replace(" ", "");
                                    SqlConnection conn = new SqlConnection(QLHTDT.FormPhu.QTHT.MaHoa.Rot13(QLHTDT.Properties.Settings.Default.strConnectionDAQH));
                                    conn.Open();
                                    string sql1 = "SELECT [TenKhuVuc] FROM VungKhongGianKienTruc where MaKV = '" + MaKT + "'";
                                    SqlCommand command1 = new SqlCommand(sql1, conn);
                                    if (command1.ExecuteScalar() != DBNull.Value)
                                    {
                                        KienTruc.dr[9] = (string)command1.ExecuteScalar();
                                    }
                                    string sql2 = "SELECT [TangCaoXD] FROM VungKhongGianKienTruc where MaKV = '" + MaKT + "'";
                                    SqlCommand command2 = new SqlCommand(sql2, conn);
                                    if (command2.ExecuteScalar() != DBNull.Value)
                                    {
                                        KienTruc.dr[10] = (string)command2.ExecuteScalar();
                                    }
                                    string sql3 = "SELECT [ChiGioiXD] FROM VungKhongGianKienTruc where MaKV = '" + MaKT + "'";
                                    SqlCommand command3 = new SqlCommand(sql3, conn);
                                    if (command3.ExecuteScalar() != DBNull.Value)
                                    {
                                        KienTruc.dr[11] = (string)command3.ExecuteScalar();
                                    }
                                    string sql4 = "SELECT [ChieuCaoTang] FROM VungKhongGianKienTruc where MaKV = '" + MaKT + "'";
                                    SqlCommand command4 = new SqlCommand(sql4, conn);
                                    if (command4.ExecuteScalar() != DBNull.Value)
                                    {
                                        KienTruc.dr[12] = (string)command4.ExecuteScalar();
                                    }
                                    string sql5 = "SELECT [CotNen] FROM VungKhongGianKienTruc where MaKV = '" + MaKT + "'";
                                    SqlCommand command5 = new SqlCommand(sql5, conn);
                                    if (command5.ExecuteScalar() != DBNull.Value)
                                    {
                                        KienTruc.dr[13] = (string)command5.ExecuteScalar();
                                    }
                                    string sql6 = "SELECT [QDKhac] FROM VungKhongGianKienTruc where MaKV = '" + MaKT + "'";
                                    SqlCommand command6 = new SqlCommand(sql6, conn);
                                    if (command6.ExecuteScalar() != DBNull.Value)
                                    {
                                        KienTruc.dr[14] = (string)command6.ExecuteScalar();
                                    }
                                }

                                KienTruc.tt.Rows.Add(KienTruc.dr);

                            }
                            if (featSelect.SelectionSet.Count > 1)
                            {
                                if (KienTruc.frm1Thua != null)
                                {
                                    KienTruc.frm1Thua.Close();
                                }
                                if (KienTruc.frmNhieuThua != null)
                                {
                                    KienTruc.frmNhieuThua.Close();
                                    KienTruc.frmNhieuThua = new QLHTDT.FormPhu.FormChiTietLayer.FrmThuaDat2(KienTruc.tt, pFeatureLayer2);
                                    KienTruc.frmNhieuThua.Show();
                                }
                                else
                                {
                                    KienTruc.frmNhieuThua = new QLHTDT.FormPhu.FormChiTietLayer.FrmThuaDat2(KienTruc.tt, pFeatureLayer2);
                                    KienTruc.frmNhieuThua.Show();
                                }
                            }
                            else if (featSelect.SelectionSet.Count == 1)
                            {
                                if (KienTruc.frmNhieuThua != null)
                                {
                                    KienTruc.frmNhieuThua.Close();
                                }
                                if (KienTruc.frm1Thua != null)
                                {
                                    KienTruc.frm1Thua.Close();
                                    KienTruc.frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(KienTruc.tt);
                                    KienTruc.frm1Thua.Show();
                                }
                                else
                                {
                                    KienTruc.frm1Thua = new QLHTDT.FormPhu.FormChiTietLayer.TTTD(KienTruc.tt);
                                    KienTruc.frm1Thua.Show();
                                }

                            }
                            ZoomToLayers();
                            QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale = QLHTDT.FormChinh.KienTruc.axMapControl1.Map.MapScale * 4;
                            QLHTDT.FormChinh.KienTruc.axMapControl1.ActiveView.Refresh();

                        }
                        else { MessageBox.Show("Chưa chọn phường cần tra cứu", "Thông báo"); }
                    }
                    catch
                    {
                        MessageBox.Show("Không có thông tin thửa đất", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại toạ độ", "Thông báo");
                }
            }
            catch
            {
                MessageBox.Show("Không có thông tin thửa đất", "Thông báo");
            }

        }
    }
}
