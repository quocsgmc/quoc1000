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
    public class MyButtonEditPainter : ButtonEditPainter
    {

        public MyButtonEditPainter()
        {

        }

        protected override void DrawContent(ControlGraphicsInfoArgs info)
        {
            Color backColor = info.ViewInfo.Appearance.GetBackColor();
            if (backColor == Color.Empty )backColor = Color.White;
            Brush brush = new SolidBrush(backColor);
            info.Graphics.FillRectangle(brush, info.Bounds);
            base.DrawContent(info);
        }
    }
}
