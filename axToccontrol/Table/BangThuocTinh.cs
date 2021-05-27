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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.DXCore.Controls.Utils;

namespace QLHTDT.axToccontrol.Table
{
    public partial class BangThuocTinh : Form
    {
        public static BindingSource bingdingsouretest;
        public static TableWrapper tbtest;
        public static DataTable tbt;
        private ESRI.ArcGIS.Carto.IMap dmap;
        private IFeatureLayer fLayer;
        
        public BangThuocTinh()
        {
            LoadBangThuocTinh();
        }
        private void LoadBangThuocTinh()
        {
            dmap = QLHTDT.FormChinh.KienTruc.axMapControl1.Map;
            ILayer player = QLHTDT.FormChinh.KienTruc.layer;
            fLayer = player as IFeatureLayer;
            fLayer = QLHTDT.FormChinh.KienTruc.featureLayer;
            ITable tb = fLayer.FeatureClass as ITable;
            //LoadLayertoCbo2();
            QLHTDT.axToccontrol.Table.TableWrapper wratbal = new QLHTDT.axToccontrol.Table.TableWrapper(tb);
            InitializeComponent();
            bindingSource1.DataSource = wratbal;
            gridView1.OptionsBehavior.Editable = false;
            tbtest = wratbal;
            tbt = new DataTable();
            tbt = gridView1.DataSource as DataTable;
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            IFeatureClass featClass = QLHTDT.FormChinh.KienTruc.featureLayer.FeatureClass;
            fLayer = QLHTDT.FormChinh.KienTruc.featureLayer;
            IFeatureLayer pFeatureLayer2 = fLayer as IFeatureLayer;
            int ID;
            int.TryParse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, featClass.OIDFieldName).ToString(), out ID);
            IFeature ife = pFeatureLayer2.FeatureClass.GetFeature(ID);
            if (ife != null)
            {
                QLHTDT.CORE.ZoomtoFeature Zoom = new QLHTDT.CORE.ZoomtoFeature(ife, dmap, pFeatureLayer2);
                IActiveView ActiveView = dmap as IActiveView;
                IEnvelope pEnv = null;
                pEnv = ife.ShapeCopy.Envelope;
                pEnv.Expand(1.2, 1.2, true);
                ActiveView.Extent = pEnv;
                ActiveView.Refresh();
            }


        }

        private void BangThuocTinh_Load(object sender, EventArgs e)
        {
            //BangThuocTinh.bindingNavigator1.Enabled = false;
            // đổi sang điều kiện kiểm tra có phải lớp chỉnh sửa hay không - nếu đúng - cho phép chỉnh sửa.
            //QLHTDT.Properties.Settings.Default.LopChinhSua = QLHTDT.FormChinh.KienTruc.layer.Name;
            if (QLHTDT.FormChinh.KienTruc.layer.Name == QLHTDT.Properties.Settings.Default.LopChinhSua)
            {

                if (QLHTDT.Properties.Settings.Default.ChinhSuaTable == true)
                {
                    bindingNavigator1.Enabled = true;
                    gridView1.OptionsBehavior.Editable = true;
                }
                else
                {
                    bindingNavigator1.Enabled = false;
                    gridView1.OptionsBehavior.Editable = false;
                }
            }
        }

        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {
            //add field
            IField NewField = new FieldClass();
            IFieldEdit2 field = (IFieldEdit2)NewField;
            field.Name_2 = "Parcel_Way";
            field.Type_2 = esriFieldType.esriFieldTypeString;
            field.Length_2 = 50;
            field.DefaultValue_2 = "Parcel";
            for (int i = 0; i < QLHTDT.FormChinh.KienTruc.axMapControl1.Map.LayerCount; i++)
            {
                IFeatureLayer2 fLayer = dmap.Layer[i] as IFeatureLayer2;
            }
            IFeatureClass featureclass = fLayer.FeatureClass;
            try
            {
                featureclass.AddField(NewField);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, ex.Source);
                throw;
            }
        }

        private void bindingNavigatorDeleteItem1_Click(object sender, EventArgs e)
        {
            //remove field
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            QLHTDT.Properties.Settings.Default.KTThayDoiTable = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLHTDT.FormPhu.AddField frm = new QLHTDT.FormPhu.AddField();
            frm.ShowDialog();
            IField NewField = new FieldClass();
            IFieldEdit2 field = (IFieldEdit2)NewField;
            field.Name_2 = QLHTDT.FormPhu.AddField.Name1;
            switch (QLHTDT.FormPhu.AddField.Type1)
            {
                case "Short Interger":
                    field.Type_2 = esriFieldType.esriFieldTypeInteger;
                    break;
                case "Long Interger":
                    field.Type_2 = esriFieldType.esriFieldTypeInteger;
                    break;
                case "Float":
                    field.Type_2 = esriFieldType.esriFieldTypeDouble;
                    break;
                case "Double":
                    field.Type_2 = esriFieldType.esriFieldTypeDouble;
                    break;
                case "Text":
                    field.Type_2 = esriFieldType.esriFieldTypeString;
                    break;
            }
            if (QLHTDT.FormPhu.AddField.Name1 == "Text")
            {
                field.Length_2 = QLHTDT.FormPhu.AddField.Lenght;
            }
            else
            {
                field.Length_2 = 50;
            }
            //field.DefaultValue_2 = "Parcel1";
            for (int i = 0; i < QLHTDT.FormChinh.KienTruc.axMapControl1.Map.LayerCount; i++)
            {
                if (QLHTDT.FormChinh.KienTruc.featureLayer.Name == dmap.Layer[i].Name)
                {
                    IFeatureLayer2 fLayer = dmap.Layer[i] as IFeatureLayer2;
                }
            }
            IFeatureClass featureclass = fLayer.FeatureClass;
            try
            {
                featureclass.AddField(NewField);
                LoadBangThuocTinh();
                bindingSource1.ResetBindings(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Trường thuộc tính đã tồn tại, vui lòng thử lại", "Thông báo");
            }
        }
        string Header = null;
        private void button2_Click(object sender, EventArgs e)
        {
            if (Header == null || Header == "")
            { MessageBox.Show("Vui lòng chọn trường thuộc tính cần xóa", "Thông báo"); }
            else
            {
                try
                {
                    if (MessageBox.Show("Bạn muốn xóa trường " + Header + "" + " không?", "Xóa trường dữ liệu", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (Header != null)
                        {
                            IFeatureClass featureclass = fLayer.FeatureClass;
                            int index = featureclass.FindField(Header);
                            IFields fields = featureclass.Fields;
                            IField field = null;
                            field = fields.get_Field(index);
                            featureclass.DeleteField(field);
                            gridView1.RefreshData();
                            Header = null;
                            MessageBox.Show("Xóa trường thuộc tính thành công", "Thông báo");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Trường dữ liệu không thể xóa", "Thông báo");
                }
            }
        }


        private void gridView1_Click(object sender, EventArgs e)
        {
    
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = gridView1.CalcHitInfo(e.Location);

            if (hitInfo.InColumnPanel)
            {
                GridView view = gridControl1.FocusedView as GridView;
                var info = view.CalcHitInfo(e.Location);
                Header = info.Column.ToString();
            }

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
