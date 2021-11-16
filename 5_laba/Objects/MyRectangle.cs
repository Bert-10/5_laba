using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using System.Drawing.Drawing2D;
namespace _5_laba.Objects
{
    class MyRectangle : BaseObject
    {

       // public delegate void MethodContainer();

        //Событие OnCount c типом делегата MethodContainer.
     //   public event MethodContainer OnCount;

        //public Action <MyRectangle> OnCount;

     //   public int count = 100;
        // base(x, y, angle) -- вызывает конструктор родительского класса
        public MyRectangle(float x, float y, float angle) : base(x, y, angle)
        {
           // count = 100;
        }

        // переопределяем Render
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, 30, 30);
        //    g.DrawString(Convert.ToString(count), new Font("Verdana", 9), new SolidBrush(Color.Green), 15, 26);



         /*           
            if (count == 0)
           {
               // if (OnCount()!= null)
             //   {
                    OnCount();
              //  }              

            }
            */
         //   count--;
        }
        //---
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(0, 0, 30, 30);

            return path;
        }
        /*
        public int Check()
        {

            return count;
        }
        */

        /*
        public void HELP(BaseObject obj)
        {
         //   base.Overlap(obj);
            //---
            /*
            if (count==0)
            {
                delete(obj as MyRectangle);
            }
            
            if ((obj is MyRectangle)&(count==0))
            {
                OnCount(obj as MyRectangle);
            }
            
        }
        */
        
    }
}
