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

        #region Static Instances
        public static Tile GroundTile_Under_BottomLeftEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Under_BottomLeftEnd);
        public static Tile GroundTile_Under_BottomEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Under_BottomEnd);
        public static Tile GroundTile_Under_BottonRightEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Under_BottomRightEnd);
        public static Tile GroundTile_Top_LeftEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Top_LeftEnd);
        public static Tile GroundTile_Top_NoEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Top_NoEnd);
        public static Tile GroundTile_Top_RightEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Top_RightEnd);
        #endregion
    }
}
