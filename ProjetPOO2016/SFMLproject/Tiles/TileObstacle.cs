using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFMLproject.Tiles
{
    class TileObstacle : Tile
    {
        public TileObstacle(Vector2f pos) {
            sprite.Texture = new Texture("File\\Background\\ob.png");
            sprite.TextureRect = new IntRect(0, 0, 32, 32);
            sprite.Scale += new Vector2f(1f, 1f);
            sprite.Position = pos;
        }
        public TileObstacle(Vector2f pos, Sprite spr)
        {
            sprite = spr;
            sprite.TextureRect = new IntRect(0, 0, 32, 32);
            sprite.Scale += new Vector2f(1f, 1f);
            sprite.Position = pos;
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
