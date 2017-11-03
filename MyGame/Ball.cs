using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int VelX { get; set; }
        public int VelY { get; set; }
        public int Radius { get; set; }
        public int Diameter
        {
            get
            {
                return (int)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            }
        }

        public Ball(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
            VelX = 5;
            VelY = 5;
        }

        public void Update(int width, int height)
        {
            if (X > width | X < 0)
                VelX *= -1;

            if (Y > height | Y < 0)
                VelY *= -1;

            X += VelX;
            Y += VelY;
        }

        public void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.Black, X, Y, Diameter, Diameter);
        }
    }
}
