using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class GroundTile : Tile
    {
        public GroundTileType GroundType { get; set; }

        public GroundTile(int width, int height, TileType type, GroundTileType groundtype) : base(width, height, type)
        {
            GroundType = groundtype;
            string path = Environment.CurrentDirectory;
            if (path.Contains("\\bin\\Debug"))
                path = path.Replace("\\bin\\Debug", string.Empty);

            path = Path.Combine(path, "tileset\\tiles\\" + (int)groundtype + ".png");
            Image = Image.FromFile(path);
        }
        public override void Draw(Graphics g, int x, int y)
        {
            g.DrawImage(Image, x * Width, y * Height, Width, Height);
        }
    }
}
