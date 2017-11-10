namespace MyGame
{
    /// <summary>
    /// All the tile instances are available in this class as static properties. If the game never uses any of the tiles, then we never create an instance of it.
    /// </summary>
    public class TileInstances
    {
        #region Static Properties
        private static Tile _groundtile_under_bottomleftend;

        public static Tile GroundTile_Under_BottomLeftEnd
        {
            get
            {
                if(_groundtile_under_bottomleftend == null) _groundtile_under_bottomleftend = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Under_BottomLeftEnd);
                return _groundtile_under_bottomleftend;
            }
        }


        private static Tile _GroundTile_Under_BottomEnd;

        public static Tile GroundTile_Under_BottomEnd
        {
            get
            {
                if (_GroundTile_Under_BottomEnd == null) _GroundTile_Under_BottomEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Under_BottomEnd);
                return _GroundTile_Under_BottomEnd;
            }
        }


        private static Tile _GroundTile_Under_BottonRightEnd;

        public static Tile GroundTile_Under_BottonRightEnd
        {
            get
            {
                if (_GroundTile_Under_BottonRightEnd == null) _GroundTile_Under_BottonRightEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Under_BottomRightEnd);
                return _GroundTile_Under_BottonRightEnd;
            }
        }


        private static Tile _GroundTile_Top_LeftEnd;

        public static Tile GroundTile_Top_LeftEnd
        {
            get
            {
                if (_GroundTile_Top_LeftEnd == null) _GroundTile_Top_LeftEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Top_LeftEnd);
                return _GroundTile_Top_LeftEnd;
            }
        }

        private static Tile _GroundTile_Top_NoEnd;

        public static Tile GroundTile_Top_NoEnd
        {
            get
            {
                if (_GroundTile_Top_NoEnd == null) _GroundTile_Top_NoEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Top_NoEnd);
                return _GroundTile_Top_NoEnd;
            }
        }


        private static Tile _GroundTile_Top_RightEnd;

        public static Tile GroundTile_Top_RightEnd
        {
            get
            {
                if (_GroundTile_Top_RightEnd == null) _GroundTile_Top_RightEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Top_RightEnd);
                return _GroundTile_Top_RightEnd;
            }
        }




        private static Tile _GroundTile_Under_LeftEnd;
        public static Tile GroundTile_Under_LeftEnd
        {
            get
            {
                if (_GroundTile_Under_LeftEnd == null) _GroundTile_Under_LeftEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Under_LeftEnd);
                return _GroundTile_Under_LeftEnd;
            }
        }



        private static Tile _GroundTile_Under_NoEnd1;
        public static Tile GroundTile_Under_NoEnd1
        {
            get
            {
                if (_GroundTile_Under_NoEnd1 == null) _GroundTile_Under_NoEnd1 = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Under_NoEnd1);
                return _GroundTile_Under_NoEnd1;
            }
        }


        private static Tile _GroundTile_Under_NoEnd2;
        public static Tile GroundTile_Under_NoEnd2
        {
            get
            {
                if (_GroundTile_Under_NoEnd2 == null) _GroundTile_Under_NoEnd2 = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Under_NoEnd2);
                return _GroundTile_Under_NoEnd2;
            }
        }


        private static Tile _GroundTile_Under_NoEnd3;
        public static Tile GroundTile_Under_NoEnd3
        {
            get
            {
                if (_GroundTile_Under_NoEnd3 == null) _GroundTile_Under_NoEnd3 = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Under_NoEnd3);
                return _GroundTile_Under_NoEnd3;
            }
        }


        private static Tile _GroundTile_Under_RightEnd;
        public static Tile GroundTile_Under_RightEnd
        {
            get
            {
                if (_GroundTile_Under_RightEnd == null) _GroundTile_Under_RightEnd = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Under_RightEnd);
                return _GroundTile_Under_RightEnd;
            }
        }



        private static Tile _GroundTile_Top_CurvedRight;
        public static Tile GroundTile_Top_CurvedRight
        {
            get
            {
                if (_GroundTile_Top_CurvedRight == null) _GroundTile_Top_CurvedRight = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Top_CurvedRight);
                return _GroundTile_Top_CurvedRight;
            }
        }



        private static Tile _GroundTile_Top_CurvedLeft;
        public static Tile GroundTile_Top_CurvedLeft
        {
            get
            {
                if (_GroundTile_Top_CurvedLeft == null) _GroundTile_Top_CurvedLeft = new GroundTile(GameWorld.TILES_WIDTH, GameWorld.TILES_HEIGHT, TileType.Under_Ground, GroundTileType.Top_CurvedLeft);
                return _GroundTile_Top_CurvedLeft;
            }
        }



        #endregion
    }
}
