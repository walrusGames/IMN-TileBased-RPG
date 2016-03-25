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
        Sprite background;
        Sprite obstacle;

        public SpriteEnum()
        {
            back = new Texture("File\\Background\\back.png");
            ob = new Texture("File\\Background\\ob.png");

            background = new Sprite(back);
            obstacle = new Sprite(ob);
        }
        public Sprite getBackground()
        {
            return background;
        }
        public Sprite getObstacle()
        {
            return obstacle;
        }
    }
}
