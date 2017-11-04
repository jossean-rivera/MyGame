using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Ball : GameObject
    {
        
        public int Radius { get; set; }
        public int Diameter
        {
            get
            {
                return Radius * 2;
            }
        }

        public Ball(int x, int y, int radius) : base()
        {
            Position.X = x;
            Position.Y = y;
            Radius = radius;
            Velocity.X = 1;
            Velocity.Y = 1;
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.Black, Position.X, Position.Y, Diameter, Diameter);
        }

        public override void Update(double elapsed)
        {
            if (Position.X + Diameter > GameWorld.CONTAINER_WIDTH & Velocity.X > 0 | Position.X < 0 & Velocity.X < 0)
                Velocity.X *= -1;

            if (Position.Y + Diameter > GameWorld.CONTAINER_HEIGHT & Velocity.Y > 0 | Position.Y < 0 & Velocity.Y < 0)
                Velocity.Y *= -1;

            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
        }
    }
}
