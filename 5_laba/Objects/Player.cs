using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _5_laba.Objects
{
    class Player : BaseObject
    {
        public Action<Marker> OnMarkerOverlap;
        public Action<MyRectangle> OnMyRectangleOverlap;
        public Action<Red> OnRedOverlap;
        public float vX, vY;    //поля под вектор скорости
        public Player(float x, float y, float angle) : base(x, y, angle)
        {
        }
        public override void Render (Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red),-15, -15, 30, 30);
            g.DrawEllipse(new Pen(Color.Black,2), -15, -15, 30, 30);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);

            return path;
        }
        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);
            if(obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }
            //---
            if (obj is MyRectangle)
            {
                OnMyRectangleOverlap(obj as MyRectangle);
            }
            if (obj is Red)
            {
                OnRedOverlap(obj as Red);
            }
            //--
        }


    }
}
