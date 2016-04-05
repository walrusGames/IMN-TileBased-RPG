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
using SFMLproject.TextureFolder;

namespace SFMLproject.Tiles
{
    class TileCharacter : Tile
    {
        private Character character;

        private Tile currentTile;
        static private SpriteEnum spr = new SpriteEnum();
        private Vector2i pos;

        public TileCharacter(Character c, Tile cur) : base(spr.getBackground())
        {
            character = c;
            currentTile = cur;
        }
        public Character getCharacter()
        {
            return character;
        }

        public Vector2i getPos()
        {
            return pos;
        }
        public void movePos(Vector2i position)
        {
            this.pos += position;
            character.moveCharacter((Vector2f)position);
        }

        public void setPos(Vector2i position) {
            this.pos = position;
        }

        public override Tile occupy(Object.Character c)
        { return new TileObstacle(spr.getBackground()); }


        public override Tile onLeave()
        {
            return currentTile;
        }

        public Tile replaceTile()
        {
            return currentTile;
        }


        public override void tileEvent()
        { /*Provoque dialog du character*/
          /* A implementer*/
        }

        public override void moveSprite(Vector2f newPos)
        {
            sprite.Position = newPos;
            character.sprite.Position = newPos;
        }

        public override void draw(RenderWindow window)
        {
            window.Draw(sprite);
            window.Draw(character.sprite);
        }


        /*
            Transfer this to destination Tile, similar to map.transfer
        */
        //public Character transfer(Tile destination, Vector2i move)
        //{
        //    Tile temp = this;
        //    if (destination.occupy(character) is Character)
        //    {
        //        movePos(move);
        //        temp = destination.onLeave();
        //        return (Character)destination.occupy(character);

        //    }

        //    return this;
        //}
    }
}
