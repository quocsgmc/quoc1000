using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils;
using DevExpress.XtraEditors.Drawing;

namespace WindowsApplication1
{
    [UserRepositoryItem("Register")]
    public class RepositoryItemMyButtonEdit : RepositoryItemButtonEdit
    {
        static RepositoryItemMyButtonEdit()
        {
            Register();
        }
        public RepositoryItemMyButtonEdit()
        {
            Register();
        }

        internal const string EditorName = "MyButtonEdit";

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(MyButtonEdit),
                typeof(RepositoryItemMyButtonEdit), typeof(MyButtonEditViewInfo),
                new MyButtonEditPainter(), true, null));
        }
        public override string EditorTypeName
        {
            get { return EditorName; }
        }

        private int _ButtonHeight;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ButtonsHeight
        {
            get { return _ButtonHeight; }
            set { _ButtonHeight = value; }
        }

        private VertAlignment _ButtonAlignment;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public VertAlignment ButtonsAlignment
        {
            get { return _ButtonAlignment; }
            set { _ButtonAlignment = value; }
        }
    }
}