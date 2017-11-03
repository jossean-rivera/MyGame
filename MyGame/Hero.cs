using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Hero
    {
        public Vector Position { get; set; }
        public Image Image { get; set; }

        public Hero(int x, int y)
        {
            Position = new Vector();
            Position.X = x;
            Position.Y = y;

            string path = Environment.CurrentDirectory;
            if (path.Contains("\\bin\\Debug"))
                path = path.Replace("\\bin\\Debug", string.Empty);

            Image = Image.FromFile(Path.Combine(path, "heroartset\\hero_stand_left.png"));
        }
    }
}
