using SFML.Graphics;
using SFMLproject.Object;
using SFMLproject.StaticFields;
using SFMLproject.TextureFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Tiles
{
    class TileFactory
    {
        static TileFactory instance = new TileFactory();
        static SpriteEnum spriteManager;

        //Si quelqu'un rend se constructeur
        //publique, je lui arrache la tête
        private TileFactory() {
            spriteManager = new SpriteEnum();
        }

        static public TileFactory getInstance()
        {
            return instance;
        }

        public Tile generateTile(int t)
        {
            switch (t)
            {
                case (int)TileType.empty:
                    return new TileEmpty(spriteManager.getBackground());
                case (int)TileType.obstacle:
                    return new TileObstacle(spriteManager.getObstacle());
                case (int)TileType.eventTrigger:
                    return new TileEventTrigger(spriteManager.getBackground());
                case (int)TileType.character:
                    throw new InvalidOperationException("Character tile need a character and current tile on board");
                case (int)TileType.portal:
                    throw new InvalidOperationException("Portal need path, dude.");
                case (int)TileType.desktop:
                    return new TileObstacle(spriteManager.getDesktop());
                case (int)TileType.wall:
                    return new TileEmpty(spriteManager.getWall());
                case (int)TileType.chair:
                    return new TileEmpty(spriteManager.getChair());
                case (int)TileType.computer:
                    return new TileObstacle(spriteManager.getComputer());
                case (int)TileType.board:
                    return new TileEmpty(spriteManager.getBoard());
                case (int)TileType.deskP:
                    return new TileObstacle(spriteManager.getDeskP());
                case (int)TileType.chairD:
                    return new TileEmpty(spriteManager.getChairD());
                case (int)TileType.chairG:
                    return new TileEmpty(spriteManager.getChairG());
                case (int)TileType.chairC:
                    return new TileEmpty(spriteManager.getChairC());
                default:
                    return new TileEmpty(spriteManager.getBackground());
            }

        }

        public Tile generateTile(char c, string s)
        {
            switch(c)
            {
                case '4':
                    return new TilePortal(spriteManager.getPortal(), s);
                default:
                    return new TileEmpty(spriteManager.getBackground());
            }

        }

        public Tile generateTile(Character charac, Tile cur)
        {
            return new TileCharacter(charac, cur);
        }
    }
}
