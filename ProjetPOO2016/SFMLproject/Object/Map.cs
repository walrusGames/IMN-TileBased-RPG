using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Map(Character c,uint x,uint y)
        {
            spr = new SpriteEnum();
            camera = new Vector2i(c.getMapPos().X - (int)x/2, c.getMapPos().Y - (int)y/2);
            rowsPrint = x;
            columnsPrint = y;
            columns = 25;
            rows = 40;
            tiles = new Tile[rows, columns];

            for(uint j = 0; j < columns; j++)
            {
                for(uint i = 0; i < rows; i++)
                {
                    if (j == 0 || i == 0 || j == columns-1 || i == rows-1)
                        tiles[i, j] = new TileObstacle(new Vector2f(i * Constants.tileSize, j * Constants.tileSize),spr.getObstacle());
                    else
                        tiles[i, j] = new TileEmpty(new Vector2f(i * Constants.tileSize, j * Constants.tileSize), spr.getBackground());
                }
            }
            this.c = c;
        }

        public Map(string filePath)
        {
            /* A implementer */
        }

        public void setTile(Vector2i pos, Tile tile)
        {
            tiles[pos.X,pos.Y] = tile;
        }

        public Tile getTile(Vector2i pos)
        {
            return tiles[pos.X,pos.Y];
        }

        public void setCamera(Vector2i add)
        {
            camera.Y = add.X;
            camera.X = add.Y;
            if (camera.Y < 0)
            {
                camera.Y = 0;
            }
            if (camera.X < 0)
            {
                camera.X = 0;
            }
            if (camera.Y > columns - columnsPrint-1)
            {
                camera.Y = (int)(columns - columnsPrint-1);
            }
            if (camera.X > rows - rowsPrint-1)
            {
                camera.X = (int)(rows - rowsPrint-1);
            }
        }
       

        public void draw(RenderWindow window)
        {
            for (uint row = (uint)camera.Y; row < (uint)camera.Y + rowsPrint - 1; row++)
            {
                for (uint column = (uint)camera.X; column < (uint)camera.X + columnsPrint - 1; column++)
                {
                    tiles[row, column].draw(window, new Vector2f((row - (uint)camera.Y) * Constants.tileSize, (column - (uint)camera.X)* Constants.tileSize));
                }
            }
        }
    }
}
