using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFMLproject.TextureFolder;
using SFMLproject.Encounter_ENV;

namespace SFMLproject.Menu
{
    class ButtonClickMenu : Invoker
    {
        public RectangleShape shape;
        public Encounter_ENV.Command cmd;
        public Text text;


        public ButtonClickMenu(Encounter_ENV.Command c, RectangleShape s, Text t)
        {
            cmd = c;
            shape = s;
            text = t;
        }

        public ButtonClickMenu(RectangleShape s, Text t)
        {
            cmd = null;
            shape = s;
            text = t;
        }

        public void storeCommand(Encounter_ENV.Command c)
        {
            cmd = c;
        }

        public void execute()
        {
            cmd.execute();
        }
    }
}

