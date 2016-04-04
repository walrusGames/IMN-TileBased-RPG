using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLproject.Object;
using SFML.Graphics;
using SFML.System;

using SFMLproject.Constt;

namespace SFMLproject.Tiles
{
    abstract class Tile
    {
        protected Sprite sprite = new Sprite();
        public Tile()
        {

        }
        public Tile(Sprite spr)
        {
            sprite = spr;
            sprite.TextureRect = new IntRect(0, 0, Constants.tileSize, Constants.tileSize);
            sprite.Scale = new Vector2f(1f, 1f);
        }

      
        public virtual void moveSprite(Vector2f newPos)
        {
            sprite.Position = newPos;
        }
        abstract public Tile occupy(Character c);
        abstract public void tileEvent();

        abstract public Tile onLeave();

        public virtual void draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
    }
}
