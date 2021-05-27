using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace QLHTDT.FormPhu
{
    public partial class TraCuuNhanh : Form
    {
        public TraCuuNhanh()
        {
            InitializeComponent();
        }
        private void TraCuuNhanh_Load(object sender, EventArgs e)
        {
            this.lvDanhSach.Columns.Add("OBJECTID_1", 0, HorizontalAlignment.Left);
            this.lvDanhSach.Columns.Add("STT", 50, HorizontalAlignment.Left);
            this.lvDanhSach.Columns.Add("Số tờ", 50, HorizontalAlignment.Left);
            this.lvDanhSach.Columns.Add("Số thửa", 100, HorizontalAlignment.Left);
            this.lvDanhSach.Columns.Add("Chủ SD", 100, HorizontalAlignment.Left);
            this.lvDanhSach.Columns.Add("Loại đất", 100, HorizontalAlignment.Left);
            this.lvDanhSach.Columns.Add("Diện tích", 100, HorizontalAlignment.Left);
            this.lvDanhSach.Columns.Add("Địa chỉ", 0, HorizontalAlignment.Left);
            this.lvDanhSach.View = System.Windows.Forms.View.Details;//trong sách thiếu
        }

        private void cmdTim_Click(object sender, EventArgs e)
        {
            this.lvDanhSach.Items.Clear();//Xóa kết quả tìm kiếm cũ
            ILayer pLayer;
            IFeatureLayer pFlayer;
            IFeatureClass pFClass;
            IFeature pFeature;
            IQueryFilter pQuery; //truy vấn
            IFeatureCursor pCursor; //dùng để tìm kiếm
            pLayer = Global.getLayerbyName(QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.ActiveView.FocusMap, "Ranh giới thửa đất");
            if (pLayer == null)
            { MessageBox.Show("Chưa mở lớp dữ liệu ranh giới thửa đất", "Thông báo"); }
            else
            {
                pFlayer = (IFeatureLayer)pLayer;
                pFClass = pFlayer.FeatureClass;
                pQuery = new QueryFilter();
                if ((this.txtSoTo.Text == "") && (this.txtSoThua.Text == "") && (this.txtDiaChi.Text == ""))// && (this.txtDienTich.Text==""))
                {
                    MessageBox.Show("Nhập số tờ hoặc số thửa hoặc địa chỉ nhà");
                    return;
                }
                string st = "";
                if (this.txtSoTo.Text == "" && this.txtSoThua.Text == "")
                    st = "DiaChi=" + this.txtDiaChi.Text;
                if (this.txtSoTo.Text == "" && this.txtDiaChi.Text == "")
                    st = "SoThua=" + this.txtSoThua.Text;
                if (this.txtDiaChi.Text == "" && this.txtSoThua.Text == "")
                    st = "SoToBD=" + this.txtSoTo.Text;
                if ((this.txtSoTo.Text != "") && (this.txtSoThua.Text != ""))//&&(this.txtDienTich.Text!=""))
                    st = "SoToBD= " + this.txtSoTo.Text + " and SoThua=" + this.txtSoThua.Text;
                if ((this.txtSoTo.Text != "") && (this.txtDiaChi.Text != ""))//&&(this.txtDienTich.Text!=""))
                    st = "SoToBD= " + this.txtSoTo.Text + " and DiaChi=" + this.txtDiaChi.Text;
                if ((this.txtDiaChi.Text != "") && (this.txtSoThua.Text != ""))//&&(this.txtDienTich.Text!=""))
                    st = "DiaChi= " + this.txtDiaChi.Text + " and SoThua=" + this.txtSoThua.Text;
                if ((this.txtDiaChi.Text != "") && (this.txtSoThua.Text != "") && (this.txtSoTo.Text != ""))//&&(this.txtDienTich.Text!=""))
                    st = "DiaChi= " + this.txtDiaChi.Text + " and SoThua=" + this.txtSoThua.Text + " and SoToBD=" + this.txtSoTo.Text;
                pQuery.WhereClause = st;
                pCursor = pFClass.Search(pQuery, false);//chữ and phải có dấu cách đằng trước
                pFeature = pCursor.NextFeature();
                int i = 0;
                while (pFeature != null)
                {

                    this.lvDanhSach.Items.Add(pFeature.get_Value(pFeature.Fields.FindField("OBJECTID_1")).ToString());
                    //Phải để stt dưới objectid thì mới chạy dc
                    this.lvDanhSach.Items[i].SubItems.Add(i.ToString());
                    if (pFeature.get_Value(pFeature.Fields.FindField("SoToBD")) != DBNull.Value)
                        this.lvDanhSach.Items[i].SubItems.Add(pFeature.get_Value(pFeature.Fields.FindField("SoToBD")).ToString());
                    if (pFeature.get_Value(pFeature.Fields.FindField("SoThua")) != DBNull.Value)
                        this.lvDanhSach.Items[i].SubItems.Add(pFeature.get_Value(pFeature.Fields.FindField("SoThua")).ToString());
                    if (pFeature.get_Value(pFeature.Fields.FindField("ChuSD")) != DBNull.Value)
                        this.lvDanhSach.Items[i].SubItems.Add(pFeature.get_Value(pFeature.Fields.FindField("ChuSD")).ToString());
                    if (pFeature.get_Value(pFeature.Fields.FindField("LoaiDat")) != DBNull.Value)
                        this.lvDanhSach.Items[i].SubItems.Add(pFeature.get_Value(pFeature.Fields.FindField("LoaiDat")).ToString());
                    if (pFeature.get_Value(pFeature.Fields.FindField("Shape_Area")) != DBNull.Value)
                        this.lvDanhSach.Items[i].SubItems.Add(pFeature.get_Value(pFeature.Fields.FindField("Shape_Area")).ToString());
                    i++;
                    pFeature = pCursor.NextFeature();

                }
            }
        }
        private void lvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            String obj;
            obj = this.lvDanhSach.FocusedItem.Text;
            if (obj == "") return;
            ILayer pLayer;
            IFeatureLayer pFlayer;
            IFeatureClass pFClass;
            IFeature pFeature;

            pLayer = Global.getLayerbyName(QLHTDT.FormChinh.QuanTriHeThong.axMapControl1.ActiveView.FocusMap, "Ranh giới thửa đất");
            pFlayer = (IFeatureLayer)pLayer;
            pFClass = pFlayer.FeatureClass;
            pFeature = pFClass.GetFeature((int.Parse(obj)));
            textBox4.Text = pFeature.get_Value(pFeature.Fields.FindField("ChuSD")).ToString();
            textBox5.Text = pFeature.get_Value(pFeature.Fields.FindField("LoaiDat")).ToString();
            textBox6.Text = pFeature.get_Value(pFeature.Fields.FindField("DienTich")).ToString();
            textBox7.Text = pFeature.get_Value(pFeature.Fields.FindField("DTPhapLy")).ToString();
            textBox8.Text = pFeature.get_Value(pFeature.Fields.FindField("TTPL")).ToString();
            textBox9.Text = pFeature.get_Value(pFeature.Fields.FindField("KhuQH")).ToString();
            textBox10.Text = pFeature.get_Value(pFeature.Fields.FindField("SoToBD")).ToString();
            textBox11.Text = pFeature.get_Value(pFeature.Fields.FindField("SoThua")).ToString();
            
        }
    }
}
