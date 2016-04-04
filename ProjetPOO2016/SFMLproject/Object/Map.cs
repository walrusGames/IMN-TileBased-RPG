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

namespace SFMLproject.Object
{
    class Map
    {

        private Tile[,] tiles;
        uint columns, rows, columnsPrint, rowsPrint;
        Vector2i camera;
        SpriteEnum spr;
        Character c;

        public Map(Character c, uint x, uint y)
        {
            spr = new SpriteEnum();
            camera = new Vector2i(c.getMapPos().X - Constants.camCol / 2, (int)c.getMapPos().Y - Constants.camRow / 2);
            rowsPrint = x;
            columnsPrint = y;
            columns = 30;
            rows = 25;

            tiles = new Tile[rows, columns];

            for (uint j = 0; j < columns; j++)
            {
                for (uint i = 0; i < rows; i++)
                {
                    if (j == 0 || i == 0 || j == columns - 1 || i == rows - 1)
                        tiles[i, j] = new TileObstacle(new Vector2f(i * Constants.tileSize, j * Constants.tileSize), spr.getObstacle());
                    else
                        tiles[i, j] = new TileEmpty(new Vector2f(i * Constants.tileSize, j * Constants.tileSize), spr.getBackground());
                }
            }
            this.c = c;
        }

        public Map(Character c, string filePath, uint entryX, uint entryY)
        {

            spr = new SpriteEnum();
            camera = new Vector2i(c.getMapPos().X - Constants.camCol / 2, (int)c.getMapPos().Y - Constants.camRow / 2);
            rowsPrint = Constants.camRow;
            columnsPrint = Constants.camCol;

            char buffer;
            string stringBuffer = "";
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.ASCII))
            {
                // COLUMN
                do
                {
                    buffer = (char)streamReader.Read();
                    stringBuffer += buffer;
                } while (buffer != '\n');

                columns = uint.Parse(stringBuffer);
                stringBuffer = "";
                // ROW
                do
                {
                    buffer = (char)streamReader.Read();
                    stringBuffer += buffer;
                } while (buffer != '\n');

                rows = uint.Parse(stringBuffer);
                tiles = new Tile[rows, columns];

                // Reading map
                for (uint j = 0; j < columns; j++)
                {
                    for (uint i = 0; i < rows; i++)
                    {
                        buffer = (char)streamReader.Read();
                        switch (buffer)
                        {
                            // An empty space
                            case '0':
                                tiles[i, j] = new TileEmpty(new Vector2f(i * Constants.tileSize, j * Constants.tileSize), spr.getBackground());
                                break;

                            //  An Obstacle
                            case '1':
                                tiles[i, j] = new TileObstacle(new Vector2f(i * Constants.tileSize, j * Constants.tileSize), spr.getObstacle());
                                break;
                        }
                    }
                }
            }
            this.c = c;
        }

        public void setTile(Vector2i pos, Tile tile)
        {
            tiles[pos.X, pos.Y] = tile;
        }

        public Tile getTile(Vector2i pos)
        {
            return tiles[pos.X, pos.Y];
        }

        public void setCamera(Vector2i add)
        {
            camera.X = add.Y;
            camera.Y = add.X;
            if (camera.Y < 0)
            {
                camera.Y = 0;
            }
            if (camera.X < 0)
            {
                camera.X = 0;
            }
            if (camera.X > columns - columnsPrint)
            {
                camera.X = (int)(columns - columnsPrint);
            }
            if (camera.Y > rows - rowsPrint)
            {
                camera.Y = (int)(rows - rowsPrint);
            }
        }


        public void draw(RenderWindow window)
        {
            for (uint row = (uint)camera.Y; row < (uint)camera.Y + rowsPrint; row++)
            {
                for (uint column = (uint)camera.X; column < (uint)camera.X + columnsPrint; column++)
                {
                    tiles[row, column].draw(window);
                }
            }
        }
    }
}
