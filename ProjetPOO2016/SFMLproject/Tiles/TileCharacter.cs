using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using SFMLproject.Object;
using SFMLproject.TextureFolder;

namespace SFMLproject.Tiles
{
    class TileCharacter : Tile
    {
        private Character character;
        private Tile currentTile;
        static private SpriteEnum spr = new SpriteEnum();

        public TileCharacter(Character c,Tile cur, Vector2f pos) :  base(pos,spr.getBackground())
        {
            character = c;
            currentTile = cur;
        }
        public override Tile occupy(Character c)
        { return this; }
        public override bool isHere(Character c)
        {
            if (sprite.Position.X / 32 == c.getMapPos().X && sprite.Position.Y / 32 == c.getMapPos().Y)
            {
                return true;
            }
            return false;
        }

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
