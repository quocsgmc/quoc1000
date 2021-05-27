namespace QLHTDT.View
{
    partial class FrmDanhMucLayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDanhMucLayer));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.MAP_CLASSGridControl = new DevExpress.XtraGrid.GridControl();
            this.GridViewlayer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAliasName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnButton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.addlayer = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Btloadlailop = new System.Windows.Forms.Button();
            this.Cbodataset = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MAP_CLASSGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addlayer)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MAP_CLASSGridControl
            // 
            this.MAP_CLASSGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAP_CLASSGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MAP_CLASSGridControl.Location = new System.Drawing.Point(0, 54);
            this.MAP_CLASSGridControl.MainView = this.GridViewlayer;
            this.MAP_CLASSGridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MAP_CLASSGridControl.Name = "MAP_CLASSGridControl";
            this.MAP_CLASSGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.addlayer});
            this.MAP_CLASSGridControl.Size = new System.Drawing.Size(549, 445);
            this.MAP_CLASSGridControl.TabIndex = 13;
            this.MAP_CLASSGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewlayer});
            // 
            // GridViewlayer
            // 
            this.GridViewlayer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAliasName,
            this.ColumnButton});
            this.GridViewlayer.GridControl = this.MAP_CLASSGridControl;
            this.GridViewlayer.Name = "GridViewlayer";
            this.GridViewlayer.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewlayer.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewlayer.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewlayer.OptionsBehavior.AutoExpandAllGroups = true;
            this.GridViewlayer.OptionsCustomization.AllowColumnMoving = false;
            this.GridViewlayer.OptionsCustomization.AllowQuickHideColumns = false;
            this.GridViewlayer.OptionsMenu.EnableColumnMenu = false;
            this.GridViewlayer.OptionsMenu.EnableFooterMenu = false;
            this.GridViewlayer.OptionsMenu.EnableGroupPanelMenu = false;
            this.GridViewlayer.OptionsMenu.ShowAutoFilterRowItem = false;
            this.GridViewlayer.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.GridViewlayer.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.GridViewlayer.OptionsMenu.ShowSplitItem = false;
            this.GridViewlayer.OptionsPrint.ExpandAllDetails = true;
            this.GridViewlayer.OptionsView.EnableAppearanceEvenRow = true;
            this.GridViewlayer.OptionsView.EnableAppearanceOddRow = true;
            this.GridViewlayer.OptionsView.ShowChildrenInGroupPanel = true;
            this.GridViewlayer.OptionsView.ShowColumnHeaders = false;
            this.GridViewlayer.OptionsView.ShowGroupPanel = false;
            this.GridViewlayer.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewlayer.OptionsView.ShowIndicator = false;
            this.GridViewlayer.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewlayer.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colAliasName
            // 
            this.colAliasName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colAliasName.AppearanceHeader.Options.UseFont = true;
            this.colAliasName.AppearanceHeader.Options.UseTextOptions = true;
            this.colAliasName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAliasName.AppearanceHeader.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Show;
            this.colAliasName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colAliasName.Caption = "Tên lớp";
            this.colAliasName.FieldName = "_Alias";
            this.colAliasName.Name = "colAliasName";
            this.colAliasName.OptionsColumn.AllowEdit = false;
            this.colAliasName.Visible = true;
            this.colAliasName.VisibleIndex = 0;
            this.colAliasName.Width = 203;
            // 
            // ColumnButton
            // 
            this.ColumnButton.AppearanceHeader.Options.UseImage = true;
            this.ColumnButton.ColumnEdit = this.addlayer;
            this.ColumnButton.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.ColumnButton.Name = "ColumnButton";
            this.ColumnButton.OptionsColumn.AllowSize = false;
            this.ColumnButton.Visible = true;
            this.ColumnButton.VisibleIndex = 1;
            this.ColumnButton.Width = 71;
            // 
            // addlayer
            // 
            this.addlayer.AutoHeight = false;
            this.addlayer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Mở lớp", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("addlayer.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Mở lớp", null, null, true)});
            this.addlayer.Name = "addlayer";
            this.addlayer.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.addlayer.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Raddlayer_ButtonClick);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.Btloadlailop);
            this.Panel1.Controls.Add(this.Cbodataset);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(549, 54);
            this.Panel1.TabIndex = 12;
            // 
            // Btloadlailop
            // 
            this.Btloadlailop.Image = ((System.Drawing.Image)(resources.GetObject("Btloadlailop.Image")));
            this.Btloadlailop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btloadlailop.Location = new System.Drawing.Point(371, 2);
            this.Btloadlailop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btloadlailop.Name = "Btloadlailop";
            this.Btloadlailop.Size = new System.Drawing.Size(84, 47);
            this.Btloadlailop.TabIndex = 20;
            this.Btloadlailop.Text = "Tải lại";
            this.Btloadlailop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btloadlailop.UseVisualStyleBackColor = true;
            this.Btloadlailop.Click += new System.EventHandler(this.Btloadlailop_Click);
            // 
            // Cbodataset
            // 
            this.Cbodataset.AllowDrop = true;
            this.Cbodataset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbodataset.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Cbodataset.FormattingEnabled = true;
            this.Cbodataset.Location = new System.Drawing.Point(120, 14);
            this.Cbodataset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cbodataset.Name = "Cbodataset";
            this.Cbodataset.Size = new System.Drawing.Size(238, 25);
            this.Cbodataset.TabIndex = 19;
            this.Cbodataset.SelectionChangeCommitted += new System.EventHandler(this.Cbodataset_SelectionChangeCommitted);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Label2.Location = new System.Drawing.Point(14, 17);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(84, 17);
            this.Label2.TabIndex = 18;
            this.Label2.Text = "Chọn nhóm";
            // 
            // FrmDanhMucLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 499);
            this.Controls.Add(this.MAP_CLASSGridControl);
            this.Controls.Add(this.Panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDanhMucLayer";
            this.Text = "FrmDanhMucLayer";
            ((System.ComponentModel.ISupportInitialize)(this.MAP_CLASSGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addlayer)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl MAP_CLASSGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewlayer;
        private DevExpress.XtraGrid.Columns.GridColumn colAliasName;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnButton;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit addlayer;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button Btloadlailop;
        public System.Windows.Forms.ComboBox Cbodataset;
        internal System.Windows.Forms.Label Label2;
    }
}