using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLproject.Object;
using SFML.Graphics;
using SFML.System;

namespace SFMLproject.Tiles
{
    abstract class Tile
    {
        protected Sprite sprite = new Sprite();
        public Tile()
        {

        }
        public Tile(Vector2f pos)
        {
            sprite.Texture = new Texture("File\\Background\\back.png");
            sprite.TextureRect = new IntRect(0, 0, 32, 32);
            sprite.Scale += new Vector2f(1f, 1f);
            sprite.Position = pos;
        }
        public Tile(Vector2f pos,Sprite spr)
        {
            sprite = spr;
            sprite.TextureRect = new IntRect(0, 0, 32, 32);
            sprite.Scale += new Vector2f(1f, 1f);
            sprite.Position = pos;
        }

        abstract public Tile occupy(Character c);
        abstract public void tileEvent();

        abstract public Tile onLeave();
        public void draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
    }
}
