using System;
using System.IO;
using System.Drawing;

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

            path = Path.Combine(path, "tileset (night)\\tiles\\" + (int)groundtype + ".png");
            Image = Image.FromFile(path);
        }
    }
}
