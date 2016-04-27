using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFMLproject.Menu;

using SFMLproject.Object;
using SFMLproject.TextureFolder;
using SFMLproject.StaticFields;
using System.Runtime.InteropServices;

namespace SFMLproject.Tiles
{
    class TileCharacter : Tile
    {
        private Character character;
        //Dialogue dia;

        private Tile currentTile;

        public TileCharacter(Character c, Tile cur) : base(spr.getBackground())
        {
            character = c;
            currentTile = cur;
            Sprite.Position = cur.getSpritePos();
            //dia = new Dialogue(new List<String> { "Non", "Oui", "Fuck UML" });
        }
        
        public override void moveSprite(Vector2f newPos)
        {
            currentTile.moveSprite(newPos);
            character.sprite.Position = newPos;
        }

        public Vector2i getPos()
        {
            return character.getMapPos();
        }
       

        public override void tileEvent()
        { /*Provoque dialog du character*/
          /* A implementer*/
        }

        public override void draw(RenderWindow window)
        {
            currentTile.draw(window);
            window.Draw(character.sprite);
        }

        public override bool updateOnOccupy() { return false; }
        public override bool updateOnInteract() { return true; }

        public override void updateOnLeave(Vector2i move)
        {
            character.changeCharPosture(move);
            if (Executer.map.getTile(getPos() + move).updateOnOccupy())
            {
                Executer.map.setTile(getPos(), currentTile);
                Executer.map.setTile(getPos() + move, tileFactory.generateTile(new Character(character, move), Executer.map.getTile(getPos() + move)));
                
                Executer.map.Queue(Executer.map.getTile(getPos() + move));
                Executer.map.moveMapView(new Vector2f(move.X, move.Y)*Constants.tileSize);
            }
            else Executer.map.Queue(Executer.map.getTile(getPos())); 
        }

        public override void updateOnReact(Vector2i ind)
        {
            if (Executer.map.getTile(getPos() + ind).updateOnInteract())
            {
                Executer.map.getTile(getPos() + ind).updateOnAction();
            }
        }


        public override void updateOnAction()
        {
            //Console.WriteLine(character.getDialogue().ElementAt(2));
            Executer.inWorld = false;
            character.dia.afficher(currentTile.getSpritePos());
            //dia.afficher();
            Executer.inWorld = true;
        }

        public override void Dispose()
        {
            base.Dispose();
            currentTile.Dispose();
            character.Dispose();
            currentTile = null;
            character = null;
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
