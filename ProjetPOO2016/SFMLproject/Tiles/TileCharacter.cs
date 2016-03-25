using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFMLproject.Object;

namespace SFMLproject.Tiles
{
    class TileCharacter : Tile
    {
        private Character character;
        private Tile currentTile;

        public TileCharacter(Character c,Tile cur, Vector2f pos) : base(pos)
        {
            character = c;
            currentTile = cur;
        }
        public override Tile occupy(Character c)
        { return this; }

        public override Tile onLeave()
        {
            return currentTile;
        }

        public override void tileEvent()
        { /*Provoque dialog du character*/
          /* A implementer*/
        }
    }
}
