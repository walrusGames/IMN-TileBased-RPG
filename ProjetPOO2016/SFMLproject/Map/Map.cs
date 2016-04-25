using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using SFMLproject.Tiles;
using SFML.Graphics;
using SFML.System;

using SFMLproject.TextureFolder;
using SFMLproject.StaticFields;

using SFML.Window;
using SFMLproject.Object;
using System.Runtime.InteropServices;

namespace SFMLproject.Map
{
    class Map : Source
    {

        private Tile[,] tiles;
        //TODO: change row / column for x/y
        private uint mapX, mapY;
        private SpriteEnum spr;
        private TileFactory tileFactory;
        private View mapView;
        private static Map state;

        /*
            Load map from textfile
            EntryX, EntryY are character initial position
        */
        public Map(string filePath)
        {

            spr = new SpriteEnum();

            tileFactory = TileFactory.getInstance();

            mapView = new View(new FloatRect(0,0,Constants.tileSize * Constants.camRow, Constants.tileSize * Constants.camCol));

            char buffer;
            string stringBuffer = "";
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.ASCII))
            {
                // X
                do
                {
                    buffer = (char)streamReader.Read();
                    stringBuffer += buffer;
                } while (buffer != '\n');

                mapX = uint.Parse(stringBuffer);
                stringBuffer = "";
                // Y
                do
                {
                    buffer = (char)streamReader.Read();
                    stringBuffer += buffer;
                } while (buffer != '\n');

                mapY = uint.Parse(stringBuffer);
                tiles = new Tile[mapX, mapY];

                // Reading map
                for (uint j = 0; j < mapY; j++)
                {
                    for (uint i = 0; i < mapX; i++)
                    {
                        buffer = (char)streamReader.Read();
                        tiles[i, j] = tileFactory.generateTile(int.Parse(buffer.ToString()));
                        tiles[i, j].moveSprite(new Vector2f(i * Constants.tileSize, j * Constants.tileSize));
                    }
                }
            }
            /*
                TODO
                Init a changer
            */
            Object.Character c = new Object.Character(new Vector2i(3, 3));
            Object.Character d = new Object.Character("File\\Perso\\perso 1.png", new Vector2i(4, 3));
            tiles[d.getMapPos().X, d.getMapPos().Y] = tileFactory.generateTile(d, tiles[d.getMapPos().X, d.getMapPos().Y]);
            tiles[c.getMapPos().X, c.getMapPos().Y] = tileFactory.generateTile(c, tiles[c.getMapPos().X, c.getMapPos().Y]);
            Attach(tiles[c.getMapPos().X, c.getMapPos().Y]);
            mapView.Center = c.sprite.Position;

            state = this;
        }

        public static Map getState()
        {
            return state;
        }

        public void setState(Map map)
        {
            state = map;
        }

        public View getMapview()
        {
            return mapView;
        }

        public void moveMapView(Vector2f move)
        {
            mapView.Move(move); 
        }

        public void setTile(Vector2i pos, Tile tile)
        {
            tiles[pos.X, pos.Y] = tile;
        }

        public Tile getTile(Vector2i pos)
        {
            return tiles[pos.X, pos.Y];
        }

        /*
           Move character WASD
        */
        public bool moveCharac(Keyboard.Key e)
        {

            switch (e)
            {
                case Keyboard.Key.D:
                    notify(new Vector2i(1, 0));
                    return true;
                    //player = player.notify(tiles[player.getPos().X +1, player.getPos().Y], new Vector2i(1, 0));

                case Keyboard.Key.A:
                    notify(new Vector2i(-1, 0));
                    return true;
                    //player = player.notify(tiles[player.getPos().X - 1, player.getPos().Y], new Vector2i(-1, 0));

                case Keyboard.Key.W:
                    notify(new Vector2i(0, -1));
                    return true;
                    // player = player.notify(tiles[player.getPos().X, player.getPos().Y - 1], new Vector2i(0, -1));

                case Keyboard.Key.S:
                    notify(new Vector2i(0, 1));
                    return true;
                    //player = player.notify(tiles[player.getPos().X, player.getPos().Y + 1], new Vector2i(0, 1));
            }
            return false;
        }

        /*
            Draw all tile in camera sight
        */
        public void draw(RenderWindow window)
        {
            for (int i = (int)mapY - 1; i >= 0; --i)
            {
                for (int j = (int)mapX - 1; j >= 0; --j) {
                    tiles[j, i].draw(window);
                }
            }
        }

        public override void notify(Vector2i m)
        {
            obt.ForEach(delegate (Observer obs)
            {
                obs.updateOnLeave(m);
            });
            KillAll();
            Dequeue();
        }
    
    }
}
