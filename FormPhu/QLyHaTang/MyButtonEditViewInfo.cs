using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;

namespace WindowsApplication1
{
    public class MyButtonEditViewInfo : ButtonEditViewInfo
    {
        public RepositoryItemMyButtonEdit MyRepositoryItem
        {
            get { return this.Item as RepositoryItemMyButtonEdit; }
        }

        public MyButtonEditViewInfo(RepositoryItem item)
            : base(item)
        {
            
        }

        Rectangle CalcButtonsBounds(Rectangle buttonBounds)
        {
            Rectangle r = buttonBounds;
            int buttonsHeight = MyRepositoryItem.ButtonsHeight;
            if (buttonsHeight > 0 && buttonsHeight < buttonBounds.Height)
                r.Height = buttonsHeight;

            if (MyRepositoryItem.ButtonsAlignment == DevExpress.Utils.VertAlignment.Bottom)
                r.Y = buttonBounds.Bottom - buttonsHeight;
            if (MyRepositoryItem.ButtonsAlignment == DevExpress.Utils.VertAlignment.Center)
                r.Y = buttonBounds.Top + (buttonBounds.Height - buttonsHeight) / 2;
            return r;
        }

        void CalcButtonsBoundsCore(EditorButtonObjectCollection collection)
        {
            for (int n = collection.Count - 1; n >= 0; n--)
            {
                EditorButtonObjectInfoArgs button = collection[n];
                button.Bounds = CalcButtonsBounds(button.Bounds);
            }
        }

        protected override Rectangle CalcButtons(DevExpress.Utils.Drawing.GraphicsCache cache)
        {
            Rectangle result = base.CalcButtons(cache);
            CalcButtonsBoundsCore(this.LeftButtons);
            CalcButtonsBoundsCore(this.RightButtons);
            return result;
        }
    }
}
