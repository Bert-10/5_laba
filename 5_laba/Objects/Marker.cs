using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _5_laba.Objects
{
    class Marker : BaseObject
    {
        public Marker(float x, float y, float angle) : base(x, y, angle)
        {
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Gold), -3, -3, 6, 6);
            g.DrawEllipse(new Pen(Color.Gold, 2), -6, -6, 12, 12);
            g.DrawEllipse(new Pen(Color.Gold, 2), -10, -10, 20, 20);
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-3, -3, 6, 6);  //заполняем пустую форму маркером
            return path;
        }
    }
}
