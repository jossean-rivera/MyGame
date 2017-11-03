using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public enum GroundTileType : byte
    {
        Top_LeftEnd = 1,
        Top_NoEnd,
        Top_RightEnd,
        Under_LeftEnd,
        Under_NoEnd1,
        Under_RightEnd,
        Top_CurvedRight,
        Under_NoEnd2,
        Under_BottomEnd,
        Under_NoEnd3,
        Top_CurvedLeft,
        Under_RightBottomEnd,
        Air_LeftEnd,
        Air_NoEnd,
        Air_RightEnd,
        Under_BottomLeftEnd
    }
}
