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

namespace SFMLproject.Tiles
{
    class TileEventTrigger : Tile
    {

        public TileEventTrigger(Vector2f pos,Sprite spr) : base(pos,spr) { }

        public override Tile occupy(Character c)
        {
            return new TileCharacter(c, this, sprite.Position);
        }
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
            return this;
        }

        public override void tileEvent()
        { /*Ne ait rien*/}
    }
}
