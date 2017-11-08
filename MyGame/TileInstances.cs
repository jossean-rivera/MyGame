using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class TileInstances
    {
        private static Tile _groundtile_under_bottomleftend;

        public static Tile GroundTile_Under_BottomLeftEnd
        {
            get
            {
                if(_groundtile_under_bottomleftend == null) _groundtile_under_bottomleftend = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Under_BottomLeftEnd);
                return _groundtile_under_bottomleftend;
            }
        }

    }
}
