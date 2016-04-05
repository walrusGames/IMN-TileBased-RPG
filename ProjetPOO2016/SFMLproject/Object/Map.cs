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
using SFMLproject.Constt;
using SFML.Window;

namespace SFMLproject.Object
{
    class Map
    {

        private Tile[,] tiles;
        //TODO: change row / column for x/y
        private uint mapX, mapY, cameraPrintX, cameraPrintY;
        private Vector2i camera;
        private SpriteEnum spr;
        private TileCharacter player;

        /*
            Load map from textfile
            EntryX, EntryY are character initial position
        */
        public Map(Character c, string filePath, uint entryX, uint entryY)
        {
            
            spr = new SpriteEnum();
            camera = new Vector2i(c.getMapPos().X - Constants.camCol / 2, (int)c.getMapPos().Y - Constants.camRow / 2);
      
            cameraPrintY = Constants.camRow;
            cameraPrintX = Constants.camCol;

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
                        switch (buffer)
                        {
                            // An empty space
                            case '0':
                                tiles[i, j] = new TileEmpty(spr.getBackground());
                                break;

                            //  An Obstacle
                            case '1':
                                tiles[i, j] = new TileObstacle(spr.getObstacle());
                                break;
                        }
                    }
                }
            }
            /*
                TODO
                Init a changer
            */
            player = new TileCharacter(c, new TileEmpty(spr.getBackground()));
            player.setPos(new Vector2i(4, 4));

            tiles[player.getPos().X, player.getPos().Y] = player;
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
            Set camera position
        */
        public void setCamera(Vector2i newPos)
        {
            camera.X = newPos.X;
            camera.Y = newPos.Y;
            if (camera.Y < 0)
            {
                camera.Y = 0;
            }
            if (camera.X < 0)
            {
                camera.X = 0;
            }
            if (camera.X > mapX - cameraPrintX )
            {
                camera.X = (int)(mapX - cameraPrintX );
            }
            if (camera.Y > mapY - cameraPrintY  )
            {
                camera.Y = (int)(mapY - cameraPrintY );
            }
            /*
                TODO
                A changer de place
            */
        }

        /*
           Center de scene at top left of screen 
           TODO
           Seems to not properly work
        */
        public void centerScreen(uint winStartX, uint winStartY)
        {
            for (uint x = (uint)camera.X; x < (uint)camera.X + cameraPrintX ; x++)
            {
                for (uint y = (uint)camera.Y; y < (uint)camera.Y + cameraPrintY; y++)
                {
                    /*
                        TODO
                        ARRANGER CA CALISSE (X et Y) 
                    */
                    Vector2f temp = new Vector2f((winStartX + x - camera.X)*Constants.tileSize, (winStartY + y - camera.Y) * Constants.tileSize);
                    tiles[x, y].moveSprite(temp);
                }
            }
        }

        /*
            Attempt to transfer a character from one tile to another
            If fail, doesn't move
        */
        public void transfer(Tile character, Vector2i move)
        {
            //Verify if can
            if (tiles[player.getPos().X + move.X, player.getPos().Y + move.Y].occupy(((TileCharacter)character).getCharacter()) is TileCharacter) // Ask Phil for details
            {
                tiles[player.getPos().X, player.getPos().Y] = tiles[player.getPos().X + move.X, player.getPos().Y + move.Y].onLeave();
                player.movePos(move);

                tiles[player.getPos().X, player.getPos().Y] = player;

            }

        }

        /*
           Move character WASD
        */
        public bool moveCharac(Keyboard.Key e)
        {

            switch (e)
            {
                case Keyboard.Key.D:
                    transfer(player, new Vector2i(1, 0));
                    //player = player.transfer(tiles[player.getPos().X +1, player.getPos().Y], new Vector2i(1, 0));
                    break;

                case Keyboard.Key.A:
                    transfer(player, new Vector2i(-1, 0));
                    //player = player.transfer(tiles[player.getPos().X - 1, player.getPos().Y], new Vector2i(-1, 0));
                    break;

                case Keyboard.Key.W:
                    transfer(player, new Vector2i(0, -1));
                   // player = player.transfer(tiles[player.getPos().X, player.getPos().Y - 1], new Vector2i(0, -1));
                    break;

                case Keyboard.Key.S:
                    transfer(player, new Vector2i(0, 1));
                    //player = player.transfer(tiles[player.getPos().X, player.getPos().Y + 1], new Vector2i(0, 1));
                    break;
            }
            setCamera(player.getPos() - new Vector2i(Constants.camRow / 2, Constants.camCol / 2));
            return false;
        }

        /*
            Draw all tile in camera sight
        */
        public void draw(RenderWindow window)
        {
            Vector2u win = window.Size;
            uint centerX = win.X / Constants.tileSize,
                 centerY = win.Y / Constants.tileSize;

            centerScreen((centerX - cameraPrintX) / 2, (centerY - cameraPrintY) / 2);

            for (uint x = (uint)camera.X; x < (uint)camera.X + cameraPrintX; x++)
            {
                for (uint y = (uint)camera.Y; y < (uint)camera.Y + cameraPrintY; y++)
                {
                    tiles[x, y].draw(window);
                }
            }
            player.draw(window);
        }
    }
}
