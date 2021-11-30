using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using System.Drawing.Drawing2D;
namespace _5_laba.Objects
{
    class MyRectangle : BaseObject
    {      
        // base(x, y, angle) -- вызывает конструктор родительского класса
        public MyRectangle(float x, float y, float angle) : base(x, y, angle)
        {
           
        }

        // переопределяем Render
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, 30, 30);
          
        }
        //---
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(0, 0, 30, 30);

            return path;
        }
             
    }
}
