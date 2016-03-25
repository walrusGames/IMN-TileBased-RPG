using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFMLproject.Object;

namespace SFMLproject.Tiles
{
    class TileEventTrigger : Tile
    {

        public TileEventTrigger(Vector2f pos) : base(pos) { }

        public override Tile occupy(Character c)
        {
            return new TileCharacter(c, this, sprite.Position);
        }
  
        public override Tile onLeave()
        {
            return this;
        }

        public override void tileEvent()
        { /*Ne ait rien*/}
    }
}
