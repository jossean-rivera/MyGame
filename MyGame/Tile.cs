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

        public void Draw(Graphics g, int x, int y)
        {
            g.DrawImage(Image, x * Width, y * Height, Width, Height);
        }
    }
}
