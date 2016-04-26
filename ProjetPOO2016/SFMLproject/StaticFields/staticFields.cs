using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;


namespace SFMLproject.StaticFields
{
    static class Constants
    {
        public const int tileSize = 48;

        public const uint hauteur = 1280;
        public const uint largeur = 720;

        public const int camRow = 10;
        public const int camCol = 10;

    }

    public enum TileType
    {
        empty,
        obstacle,
        character,
        eventTrigger,
        portal,
        desktop,
        wall,
        chair,
        computer,
        board,
        deskP,
        chairD,
        chairG,
        chairC
    };

    class TextProperties
    {
        public Font font;
        public Color color;
        public uint size;

        public TextProperties()
        {
            font = new Font(@"U:\POO\projet\ProjetPOO2016\SFMLproject\bin\Debug\File\Font");
            color = new Color(Color.Black);
            size = 20;
        }
        public TextProperties(uint s)
        {
            font = new Font(@"U:\POO\projet\ProjetPOO2016\SFMLproject\bin\Debug\File\Font");
            color = new Color(Color.Black);
            size = s;
        }
        public TextProperties(Color c)
        {
            font = new Font(@"U:\POO\projet\ProjetPOO2016\SFMLproject\bin\Debug\File\Font");
            color = c;
            size = 20;
        }
        public TextProperties(uint s, Color c)
        {
            font = new Font(@"U:\POO\projet\ProjetPOO2016\SFMLproject\bin\Debug\File\Font");
            color = c;
            size = s;
        }
    }
}
