using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using SFMLproject.Menu;
using SFMLproject.Object;

namespace SFMLproject.Game_Main
{
    class Easter_Egg
    {
        static bool actif = false;
        public Music activate()
        {
            actif = !actif;
            if (actif) return new Music("File\\Music\\Oeuf.ogg");
            else return new Music("File\\Music\\Student Life.ogg");
        }
    }
}
