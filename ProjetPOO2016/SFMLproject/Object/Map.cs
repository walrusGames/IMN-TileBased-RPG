using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLproject.Tiles;
using SFML.Graphics;
using SFML.System;

namespace SFMLproject.Object
{
    class Map
    {
        private Tile[,] tiles;
        uint rows, columns;

        public Map(Character c)
        {
            rows = 20;
            columns = 15;

            tiles = new Tile[rows, columns];

            for(uint row = 0; row < rows; row++)
            {
                for(uint column = 0; column < columns; column++)
                {
                    if (column == 0 || row == 0)
                        tiles[row,column] = new TileObstacle(new Vector2f(row * 30, column * 30));
                    else
                        tiles[row,column] = new TileEmpty(new Vector2f(row * 30, column * 30));
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
            for (uint row = 0; row < rows; row++)
            {
                for (uint column = 0; column < columns; column++)
                {
                    tiles[row,column].draw(window);
                }
            }

        }
    }
}
