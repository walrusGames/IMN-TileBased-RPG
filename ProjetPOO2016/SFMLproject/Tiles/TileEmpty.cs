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
    class TileEmpty : Tile
    {
        public TileEmpty(Vector2f pos) : base(pos) { }

        public TileEmpty(Vector2f pos,Sprite spr) : base(pos,spr) { }

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
