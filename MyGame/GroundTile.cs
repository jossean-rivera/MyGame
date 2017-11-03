using System;
using System.Collections.Generic;
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
        }
    }
}
