using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

using SFMLproject.Constt;

namespace SFMLproject.Tiles
{
    class TileObstacle : Tile
    {
        public TileObstacle(Sprite spr)
        {
            sprite = spr;
            sprite.TextureRect = new IntRect(0, 0, Constants.tileSize, Constants.tileSize);
            sprite.Scale += new Vector2f(1f, 1f);
        }

        public override Tile occupy(Character c)
        {
            return this;
        }
        public override Tile onLeave()
        {
            return this;
        }

        public override void tileEvent()
        { /*Ne ait rien*/}
    }
}
