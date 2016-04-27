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
using SFMLproject.TextureFolder;

namespace SFMLproject.Tiles
{

 
    abstract class Tile: Observer, IDisposable
    {
        protected static TileFactory tileFactory = TileFactory.getInstance();
        protected static SpriteEnum spr = new SpriteEnum();

        protected Sprite Sprite { get; set; } = new Sprite();

        public Tile()
        {
        }
        public Tile(Sprite spr)
        {
            tileFactory = TileFactory.getInstance();
            Sprite = spr;
            Sprite.TextureRect = new IntRect(0, 0, Constants.tileSize, Constants.tileSize);
            Sprite.Scale = new Vector2f(1f, 1f);
        }

        public Vector2f getSpritePos()
        {
            return Sprite.Position;
        }

        public virtual void moveSprite(Vector2f newPos)
        {
            Sprite.Position = newPos;
        }

        public abstract void tileEvent();

        public virtual void draw(RenderWindow window)
        {
            window.Draw(Sprite);
        }

        public virtual void Dispose()
        {
            ((IDisposable)Sprite).Dispose();
            Sprite = null;
        }
    }
}
