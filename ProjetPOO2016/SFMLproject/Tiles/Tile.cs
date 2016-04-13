using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLproject.Object;
using SFML.Graphics;
using SFML.System;

using SFMLproject.StaticFields;
using System.Runtime.InteropServices;

namespace SFMLproject.Tiles
{

 
    abstract class Tile: Observer
    {
        protected Sprite sprite = new Sprite();
        protected TileFactory tileFactory;
        protected Map.Map mapState;

        public Tile()
        {
            tileFactory = TileFactory.getInstance();
            mapState = Map.Map.getState();
        }
        public Tile(Sprite spr)
        {
            tileFactory = TileFactory.getInstance();
            sprite = spr;
            sprite.TextureRect = new IntRect(0, 0, Constants.tileSize, Constants.tileSize);
            sprite.Scale = new Vector2f(1f, 1f);
        }

        public Vector2f getSpritePos()
        {
            return sprite.Position;
        }

        public virtual void moveSprite(Vector2f newPos)
        {
            sprite.Position = newPos;
        }

        abstract public void tileEvent();

        public virtual void draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
    }
}
