using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFMLproject.TextureFolder
{
    class SpriteEnum
    {
        Texture back;
        Texture ob;
        Texture blank;
        Texture encounterBkgr;
        Texture portal;
        Texture desk;
        Texture wall;
        Texture chair;
        Texture computer;
        Texture board;
        Texture deskP;
        Texture chairD;
        Texture chairG;

        public SpriteEnum()
        {
            back     = new Texture("File\\Background\\back.png");
            ob       = new Texture("File\\Background\\OB.png");
            blank    = new Texture("File\\Background\\test.png");
            portal   = new Texture("File\\Background\\portal.png");
            desk     = new Texture("File\\Background\\desk.png");
            wall     = new Texture("File\\Background\\wall.png");
            chair    = new Texture("File\\Background\\chair.png");
            computer = new Texture("File\\Background\\computer.png");
            board    = new Texture("File\\Background\\board.png");
            deskP    = new Texture("File\\Background\\deskP.png");
            chairD   = new Texture("File\\Background\\chairD.png");
            chairG   = new Texture("File\\Background\\chairG.png");

        }
        public Sprite getDesktop()
        {
            return new Sprite(desk);
        }
        public Sprite getBackground()
        {
            return new Sprite(back);
        }
        public Sprite getObstacle()
        {
            return new Sprite(ob);
        }

        internal Sprite getMenuBkgr()
        {
            throw new NotImplementedException();
        }

        public Sprite getBlank()
        {
            return new Sprite(blank);
        }

        public Sprite getEncounterBkgr()
        {
            return new Sprite(encounterBkgr);
        }

        public Sprite getPortal()
        {
            return new Sprite(portal);
        }

        public Sprite getWall()
        {
            return new Sprite(wall);
        }

        public Sprite getChair()
        {
            return new Sprite(chair);
        }

        public Sprite getComputer()
        {
            return new Sprite(computer);
        }

        public Sprite getBoard()
        {
            return new Sprite(board);
        }

        public Sprite getDeskP()
        {
            return new Sprite(deskP);
        }

        public Sprite getChairD()
        {
            return new Sprite(chairD);
        }

        public Sprite getChairG()
        {
            return new Sprite(chairG);
        }
    }
}
