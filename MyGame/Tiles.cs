using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    public abstract class Tile
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Image Image { get; set; }
        public TileType Type { get; set; }

        public Tile(int width, int height, TileType type)
        {
            Width = width;
            Height = height;
            Type = type;
        }
    }
}
