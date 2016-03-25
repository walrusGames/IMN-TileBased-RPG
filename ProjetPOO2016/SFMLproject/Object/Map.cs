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
        uint columns, rows;

        public Map(Character c)
        {
            columns = 45;
            rows = 15;

            tiles = new Tile[rows, columns];

            for(uint i = 0; i < columns; i++)
            {
                for(uint j = 0; j < rows; j++)
                {
                    if (j == 0 || i == 0 || i == columns-1 || j == rows-1)
                        tiles[j,i] = new TileObstacle(new Vector2f(i * 30, j * 30));
                    else
                        tiles[j,i] = new TileEmpty(new Vector2f(i * 30, j * 30));
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
            for (uint row = 0; row < columns; row++)
            {
                for (uint column = 0; column < rows; column++)
                {
                    tiles[column, row].draw(window);
                }
            }

        }
    }
}
