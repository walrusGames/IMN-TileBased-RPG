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
    abstract class Tile: Observer
    {
        protected Sprite sprite = new Sprite();
        internal static Tile self;

        public Tile()
        {
            self = this;
        }
        public Tile(Sprite spr)
        {
            sprite = spr;
            sprite.TextureRect = new IntRect(0, 0, Constants.tileSize, Constants.tileSize);
            sprite.Scale = new Vector2f(1f, 1f);
            self = this;
        }


        public virtual void moveSprite(Vector2f newPos)
        {
            sprite.Position = newPos;
        }
        abstract public Tile occupy(Object.Character c);
        abstract public void tileEvent();

        abstract public Tile onLeave();

        public virtual void draw(RenderWindow window)
        {
            window.Draw(sprite);
        }

        public Tile generateCharacterTile(Object.Character charac, Tile cur) {
            return new TileCharacter(charac, cur);
        }
        public Tile generateEmptyTile(Sprite sprite)
        {
            return new TileEmpty(sprite);
        }
        public Tile generateEventTile(Sprite sprite)
        {
            return new TileEventTrigger(sprite);
        }
        public Tile generateObstacleTile(Sprite sprite)
        {
            return new TileObstacle(sprite);
        }

        private bool canOccupy()
        {
            return true;
        }

        public override void updateOnOccupy(TileCharacter c)
        {
            if (canOccupy())
            {
                self = generateCharacterTile(c.getCharacter(), self);
                c.updateOnLeave();
            }
        }

        public override void updateOnLeave() {
            if (self is TileCharacter) ((TileCharacter)self).replaceTile();
        }
    }
}
