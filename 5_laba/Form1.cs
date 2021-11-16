using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _5_laba.Objects;

namespace _5_laba
{
    public partial class Form1 : Form
    {
        List <BaseObject> objects = new List<BaseObject>();
        Player player;
        Marker marker;
        MyRectangle circle_1;
        MyRectangle circle_2;
        Red RedZone;
        int score = 0;
        //  Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            Random rand = new Random();

            circle_1 = new MyRectangle(rand.Next(30, pbMain.Width - 30), rand.Next(30, pbMain.Height - 30), 0);
            circle_2 = new MyRectangle(rand.Next(30, pbMain.Width - 30), rand.Next(30, pbMain.Height - 30), 0);
            RedZone = new Red(rand.Next(30, pbMain.Width - 30), rand.Next(30, pbMain.Height - 30), 0);
            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);

            // добавляю реакцию на пересечение
            player.OnOverlap += (p, obj) =>
            {
                // txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };
            // добавил реакцию на пересечение с маркером
            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };
            //-------
            player.OnMyRectangleOverlap += (m) =>
            {
                objects.Remove(m);
                circle_1 = null;
                circle_1 = new MyRectangle(0, 0, 0);
                objects.Add(circle_1);
                circle_1.X = rand.Next(30, pbMain.Width - 30);
                circle_1.Y = rand.Next(30, pbMain.Height - 30);
                score++;
            };
            player.OnRedOverlap += (m) =>
            {
                objects.Remove(m);
                RedZone = null;
                RedZone = new Red(0, 0, 0);
                objects.Add(RedZone);
                RedZone.X = rand.Next(30, pbMain.Width - 30);
                RedZone.Y = rand.Next(30, pbMain.Height - 30);
                score--;
            };
            //--

            /*
            circle_1.OnCount += (m) =>
              {
                  //  score++;
                  
                  objects.Remove(m);
                  circle_1 = null;
                  circle_1 = new MyRectangle(0, 0, 0);
                  objects.Add(circle_1);
                  circle_1.X = rand.Next(30, pbMain.Width - 30);
                  circle_1.Y = rand.Next(30, pbMain.Height - 30);
               //   circle_1.count = 100;
                  
                  //circle_1.OnCount-=()=> { };
              };

            */
            /*
            circle_2.OnCount += () =>
            {
                //  score++;
                
                objects.Remove(circle_2);
                circle_2 = null;
                circle_2 = new MyRectangle(0, 0, 0);
                objects.Add(circle_2);
                circle_2.X = rand.Next(30, pbMain.Width - 30);
                circle_2.Y = rand.Next(30, pbMain.Height - 30);
                //circle_2.count = 100;
                
               // circle_2.OnCount -= () => { };
            };
            */

            /*
            if (circle_1.count == 0)
            {
                //  objects.Remove(m);
                // circle_1 = null;
                objects.Remove(circle_1);
                circle_1 = null;
                circle_1 = new MyRectangle(0, 0, 0);
                objects.Add(circle_1);
                circle_1.X = rand.Next(30, pbMain.Width - 30);
                circle_1.Y = rand.Next(30, pbMain.Height - 30);
            }
            */
            objects.Add(RedZone);
            objects.Add(circle_1);
            objects.Add(circle_2);
            
            objects.Add(player);
            //   objects.Add(marker);
           
           
            //  objects.Add(new MyRectangle(50, 50, 0));
            //  objects.Add(new MyRectangle(100, 100, 45));

        }
 


        private void pbMain_Paint(object sender, PaintEventArgs e)
        {

            var g = e.Graphics;       // вытащили объект графики из события

            g.Clear(Color.White);

            //  g.DrawString("Счёт: " + score, new Font("Arial", 14), Brushes.Black, 2, 2);
            label1.Text = "Счёт: " + score;
            updatePlayer();
           
            // пересчитываем пересечения
            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }
            }
            /*
            // рендерим объекты
            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
            */
            
            foreach (var obj in objects.ToList())
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
                //---
             //   circle_1.HELP(obj);
              //  obj.HELP(circle_1);
            }
            //   MyRectangle.HELP(obj);

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pbMain.Invalidate();

        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            // добавил создание маркера по клику если он еще не создан
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker); //не забыть пололжить в objects
            }

            marker.X = e.X;
            marker.Y = e.Y;
        }
        //ускорение игрока
        private void updatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;
                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx /= length;  //разделить переменную на значение и ответ присвоить этой же переменной.
                dy /= length;

              // используем вектор dx, dy
              // как вектор ускорения, точнее даже вектор притяжения
              // который притягивает игрока к маркеру
                player.vX += dx * 1f;
                 player.vY += dy * 1f;

                // расчитываем угол поворота игрока 
                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }
            // тормозящий момент,
            // нужен чтобы, когда игрок достигнет маркера произошло постепенное замедление
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;
            // пересчет позиции игрока с помощью вектора скорости
            player.X += player.vX;
            player.Y += player.vY;
        }
    }
}
