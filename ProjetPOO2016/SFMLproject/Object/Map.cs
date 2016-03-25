using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFMLproject.Tiles;
using SFML.Graphics;
using SFML.System;

using SFMLproject.TextureFolder;

namespace SFMLproject.Object
{
    class Map
    {

        private Tile[,] tiles;
        uint columns, rows, columnsPrint, rowsPrint;
        Vector2i camera;

        public Map(Character c,uint x,uint y)
        {
            SpriteEnum spr = new SpriteEnum();
            camera = new Vector2i(0, 0);
            rowsPrint = x;
            columnsPrint = y;
            columns = 25;
            rows = 15;

            tiles = new Tile[rows, columns];

            for(uint i = 0; i < columns; i++)
            {
                for(uint j = 0; j < rows; j++)
                {
                    if (j == 0 || i == 0 || i == columns-1 || j == rows-1)
                        tiles[j,i] = new TileObstacle(new Vector2f(i * 30, j * 30),spr.getObstacle());
                    else
                        tiles[j,i] = new TileEmpty(new Vector2f(i * 30, j * 30),spr.getBackground());
                }
            }

            tiles[1,1].occupy(c);
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


        public void draw(RenderWindow window)
        {
            for (uint row = (uint)camera.Y; row < (uint)camera.Y + rowsPrint + 1; row++)
            {
                for (uint column = (uint)camera.X; column < (uint)camera.X + columnsPrint + 1; column++)
                {
                    tiles[column, row].draw(window);
                }
            }

        }
    }
}
