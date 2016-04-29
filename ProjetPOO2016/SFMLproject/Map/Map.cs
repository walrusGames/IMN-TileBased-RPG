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
using SFMLproject.Input;

namespace SFMLproject.Map
{
    class Map : Source, IDisposable
    {

        private Tile[,] tiles;
        //TODO: change row / column for x/y
        private uint mapX, mapY;
        private static TileFactory tileFactory = TileFactory.getInstance();
        private static View mapView = new View(new FloatRect(0, 0, Constants.tileSize * Constants.camRow, Constants.tileSize * Constants.camCol));
        private Vector2i characState;
        private bool disposeFlag = false;
        public Controller controller = new Controller();
        /*
            Load map from textfile
            EntryX, EntryY are character initial position
        */

        public Map(string filePath, Vector2i charSpawnState)
        {
            characState = charSpawnState;
            int spawnPointX = 0;
            int spawnPointY = 0;
            char buffer;
            string line;
            string SpritePositionNPC;
            string SpritePositionMain;
            //string stringBuffer = "";
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.ASCII))
                {

                    line = streamReader.ReadLine();
                    mapX = uint.Parse(line);
                    line = streamReader.ReadLine();
                    mapY = uint.Parse(line);

                    line = streamReader.ReadLine();
                    spawnPointX = int.Parse(line);

                    line = streamReader.ReadLine();
                    spawnPointY = int.Parse(line);

                    SpritePositionMain = streamReader.ReadLine();


                    tiles = new Tile[mapX, mapY];

                    Object.Character c = new Object.Character("NouvelEtudiant", new Vector2i(spawnPointX, spawnPointY), SpritePositionMain);
                    // Reading map
                    for (uint j = 0; j < mapY; j++)
                    {
                        for (uint i = 0; i < mapX; i++)
                        {
                            buffer = (char) streamReader.Read();
                            while (buffer == '\r' || buffer == '\n')
                            {
                                buffer = (char) streamReader.Read();
                            }
                            if (buffer == '2')
                            {
                                line = streamReader.ReadLine();
                                line = streamReader.ReadLine();
                                Object.Character template = new Object.Character(line);
                                tiles[i, j] = tileFactory.generateTile(template,
                                    tileFactory.generateTile((int) TileType.empty));
                                //create character. Line = pathfile
                            }
                            else if(buffer == '3')
                            {
                                line = streamReader.ReadLine();
                                buffer = (char)streamReader.Read();
                                line = streamReader.ReadLine();
                                tiles[i, j] = tileFactory.generateTile(c, buffer);
                            }
                            else if (buffer == '4')
                            {
                                line = streamReader.ReadLine();
                                line = streamReader.ReadLine();
                                tiles[i, j] = tileFactory.generateTile(buffer, line);

                            }
                            else tiles[i, j] = tileFactory.generateTile(buffer - '0');


                            tiles[i, j].moveSprite(new Vector2f(i*Constants.tileSize, j*Constants.tileSize));
                        }
                    }
                    /*
                TODO
                Init a changer
            */

                   
                    c.changePostureCharacter(characState);
                    //Object.Character d = new Object.Character("File\\Perso\\perso 1.png", new Vector2i(4, 3));
                    //tiles[d.getMapPos().X, d.getMapPos().Y] = tileFactory.generateTile(d, tiles[d.getMapPos().X, d.getMapPos().Y]);
                    tiles[c.GetMapPos().X, c.GetMapPos().Y] = tileFactory.generateTile(c,
                        tiles[c.GetMapPos().X, c.GetMapPos().Y]);
                    Attach(tiles[c.GetMapPos().X, c.GetMapPos().Y]);
                    Map.mapView.Center = c.sprite.Position;
                    //tiles[3, 9] = tileFactory.generateTile((int)TileType.eventTrigger);

                    fileStream.Close();
                }
            }
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
           Move character
        */
        public bool moveCharacController(int counter)
        {
            if (controller.isJoystickConnect() && counter == 0)
            {
                Vector2f pos = controller.getMovementLeftJoystick();
                if (pos.X < -5)
                {
                    characState = new Vector2i(-1, 0);
                    notify(characState);
                    return true;
                }
                else if (pos.X > 5)
                {
                    characState = new Vector2i(1, 0);
                    notify(characState);
                    return true;
                }
                else if (pos.Y < -5)
                {
                    characState = new Vector2i(0, -1);
                    notify(characState);
                    return true;
                }
                else if (pos.Y > 5)
                {
                    characState = new Vector2i(0, 1);
                    notify(characState);
                    return true;
                }
            }
            return false;
        }
        public bool moveCharac(Keyboard.Key e)
        {
            
            switch (e)
            {
                case Keyboard.Key.D:
                    characState = new Vector2i(1, 0);
                    notify(characState);
                    return true;
                   

                case Keyboard.Key.A:
                    characState = new Vector2i(-1, 0);
                    notify(characState);
                    return true;
                    

                case Keyboard.Key.W:
                    characState = new Vector2i(0, -1);
                    notify(characState);
                    return true;
                    

                case Keyboard.Key.S:
                    characState = new Vector2i(0, 1);
                    notify(characState);
                    return true;
                    
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
        public bool actionButtonController(int counter)
        {
            if (controller.isJoystickConnect() && counter == 0)
            {
                uint button = controller.buttonPressed();
                if (button == 0)
                {
                    notifyAction(characState);
                    return true;
                }
                else if (button == 1)
                {
                    Console.WriteLine("Stop the action/exit menu.");
                    return true;
                }
                else if (button == 3)
                {
                    Console.WriteLine("MENU");
                    return true;
                }
            }
            return false;
        }
        public bool actionButton(Keyboard.Key e)
        {

            switch (e)
            {
                case Keyboard.Key.E:
                    notifyAction(characState);
                    return true;
                case Keyboard.Key.Q:
                    Console.WriteLine("Stop the action/exit menu.");
                    return true;
                case Keyboard.Key.Return:
                    Console.WriteLine("MENU");
                    return true;
            }
            return false;
        }

        public override void notifyAction(Vector2i m)
        {
            obt.ForEach(delegate (Observer obs)
            {
                obs.updateOnReact(m);
            });
            //KillAll();
            Dequeue();
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
    
        public override void Dispose()
        {
            for (uint j = 0; j < mapY; j++)
            {
                for (uint i = 0; i < mapX; i++)
                {
                    tiles[i, j].Dispose();
                    tiles[i, j] = null;
                }
            }
            base.Dispose();
        }

        public Vector2i getCharState()
        {
            return characState;
        }
    }
}
