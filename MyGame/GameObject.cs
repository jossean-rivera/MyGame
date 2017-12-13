using System.Drawing;

namespace MyGame
{
    public abstract class GameObject
    {
        public Vector Position { get; set; }
        public Vector Velocity { get; set; }
        public abstract void Update(double elapsed);
        public abstract void Draw(Graphics g);
        public GameObject()
        {
            Position = new Vector();
            Velocity = new Vector();
        }
    }
}
