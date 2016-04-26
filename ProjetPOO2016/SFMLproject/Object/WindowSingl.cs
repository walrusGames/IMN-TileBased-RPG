using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFMLproject.Map;
namespace SFMLproject.Object
{
    class WindowSingl
    {
        private static ContextSettings context = new ContextSettings();
        private RenderWindow window = new RenderWindow(new VideoMode(1280, 720), "Project IFT 232", Styles.Default, context);

        public RenderWindow getInstance()
        {
             return window;
        }
    }
}