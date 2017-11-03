using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class GameObject
    {
        public Vector Position { get; set; }
        public Vector Velocity { get; set; }
        public abstract void Update();
        public abstract void Draw(Graphics g);
        public GameObject()
        {
            Position = new Vector();
            Velocity = new Vector();
        }
    }
}
