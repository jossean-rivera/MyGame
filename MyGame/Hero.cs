using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Hero : GameObject
    {
        public Image Image { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Hero(int x, int y, int width, int height)
        {
            Position = new Vector();
            Position.X = x;
            Position.Y = y;

            Width = width;
            Height = height;

            string path = Environment.CurrentDirectory;
            if (path.Contains("\\bin\\Debug"))
                path = path.Replace("\\bin\\Debug", string.Empty);

            Image = Image.FromFile(Path.Combine(path, "heroartset\\hero_stand_left.png"));
        }

        public override void Update()
        {
            //throw new NotImplementedException();
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Image, Position.X, Position.Y, Width, Height);
            //g.DrawRectangle(Pens.Red, Position.X , Position.Y , Width, Height);
        }
    }
}
