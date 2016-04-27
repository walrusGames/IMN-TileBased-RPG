using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFMLproject.Object
{
    class Background
    {
        static Texture background;
        public Sprite sprite;
        public IntRect r;

        public Background(String filePath)
        {
            background = new Texture(filePath);
            background.Repeated = false;
            sprite = new Sprite(background);
        }
    }
}
