using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using System.Drawing.Drawing2D;
namespace _5_laba.Objects
{
    class Red : BaseObject
    {
        int x = 3;
        int y = 3;
        public Red(float x, float y, float angle) : base(x, y, angle)
        {
            
        }

        // переопределяем Render
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Tomato), 0-x/2, 0-y/2, x, y);
            x++;
            y++;

        }
        //---
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(0-x/2, 0-y/2, x, y);

            return path;
        }


    }
}
