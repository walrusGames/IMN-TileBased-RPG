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

        public SpriteEnum()
        {
            back = new Texture("File\\Background\\back.png");
            ob = new Texture("File\\Background\\OB.png");
            blank = new Texture("File\\Background\\test.png");

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
    }
}
