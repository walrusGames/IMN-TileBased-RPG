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
            camera = new Vector2i(0, 0);
            rowsPrint = x;
            columnsPrint = y;
            columns = 45;
            rows = 45;

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

        public void moveCamera(Vector2i add)
        {
            if (tiles[2, 1].isHere(c))
            {
                camera.X += add.Y;
                camera.Y += add.X;
            }
        }


        public void draw(RenderWindow window)
        {
            for (uint row = (uint)camera.Y; row < (uint)camera.Y + rowsPrint + 1; row++)
            {
                for (uint column = (uint)camera.X; column < (uint)camera.X + columnsPrint + 1; column++)
                {
                    tiles[row, column].draw(window);
                }
            }
            /*
            for (uint row = 0; row < rows; row++)
            {
                for (uint column = 0; column < columns; column++)
                {
                    tiles[row, column].draw(window);
                }
            }*/
        }
    }
}
