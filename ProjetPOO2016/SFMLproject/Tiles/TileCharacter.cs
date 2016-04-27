﻿using System;
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
using SFMLproject.StaticFields;
using System.Runtime.InteropServices;

namespace SFMLproject.Tiles
{
    class TileCharacter : Tile
    {
        private Character character;

        private Tile currentTile;

        public TileCharacter(Character c, Tile cur) : base(spr.getBackground())
        {
            character = c;
            currentTile = cur;
            Sprite.Position = cur.getSpritePos();
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
            mapState = Map.Map.getState();
            character.changeCharPosture(move);
            if (mapState.getTile(getPos() + move).updateOnOccupy())
            {
                mapState.setTile(getPos(), currentTile);
                mapState.setTile(getPos() + move, tileFactory.generateTile(new Character(character, move), mapState.getTile(getPos() + move)));
                
                mapState.Queue(mapState.getTile(getPos() + move));
                mapState.moveMapView(new Vector2f(move.X, move.Y) * Constants.tileSize);
                mapState.setState(mapState);
            }
            //else mapState.Queue(mapState.getTile(getPos())); 
        }

        public override void updateOnReact(Vector2i ind)
        {
            mapState = Map.Map.getState();
            if (mapState.getTile(getPos() + ind).updateOnInteract())
            {
                mapState.getTile(getPos() + ind).updateOnAction();
            }
        }

        public override void updateOnAction()
        {
            Console.WriteLine("Personnage");
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
