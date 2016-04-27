using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFMLproject.Input;
using SFMLproject.Object;
using SFMLproject.Tiles;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFMLproject.Map;

using SFMLproject.StaticFields;
using SFMLproject.Encounter_ENV;

namespace SFMLproject
{

    class Executer
    {
        static ContextSettings context = new ContextSettings();
        public static RenderWindow window = new RenderWindow(new VideoMode(1280, 720), "Project IFT 232", Styles.Default, context);

        //Audio State
        static bool Playing = true;

        static Music music = new Music("File\\Music\\Student Life.ogg");

        static bool swapFlag = false;
        private static string swapPath;

        static Controller controller = new Controller();

        public static Map.Map map = new Map.Map("File\\Map\\drago.txt", new Vector2i(0, 1));

        static bool keypressed = false;

        public static bool inWorld = true;

        static void initWindow()
        {
            window.Closed += window_Closed;
            window.GainedFocus += window_GainedFocus;
            window.LostFocus += window_LostFocus;
            window.Resized += window_Resized;
            window.KeyPressed += window_KeyPressed;
            window.KeyReleased += window_KeyReleased;
            window.SetActive(true);
            window.SetFramerateLimit(60);
            window.SetView(map.getMapview());
            map.draw(window);
            window.Display();
        }

        static void Main(string[] args)
        {
            initWindow();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                if (keypressed)
                {
                    if(swapFlag) swapMap();
                    window.Clear();
                    window.SetView(map.getMapview());
                    //if (controller.ControllerPlugged)
                    //    charc.changePostureCharacter(controller.getMovementLeftJoystick() / 20);

                    map.draw(window);
                    window.Display();
                    keypressed = false;
                }

            }
        }

        /*Map swap*/

        static void swapMap()
        {
            Vector2i charPastState = map.getCharState();
            map.Dispose();
            map = new Map.Map(swapPath, charPastState);
            swapFlag = false;
        }

        /*Keyboard Fonctions*/
        //Call when a key is pressed
        static void window_KeyReleased(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Escape: window.Close(); break;
                default: break;
            }
        }

        //Call when a key is pressed
        public static void window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (map.moveCharac(e.Code) || map.actionButton(e.Code))
            {
                keypressed = true;
                return;
            }
                
            switch (e.Code)
            {
                case Keyboard.Key.P:
                    if (Playing)
                    {
                        music.Pause();
                        Playing = false;
                    }
                    else {
                        music.Play();
                        Playing = true;
                    }
                    break;
                case Keyboard.Key.B:

                    Character c = new Character("sami");
                    Encounter enc = new Encounter(c);
                    enc.StartEncounterLoop(c); 
                    break;
                default: break;
            }
        }

        /*Window Fonctions*/
        //Call when the window is resized
        static void window_Resized(object sender, SizeEventArgs e)
        {
            window.Clear();
            window.SetView(map.getMapview());
            map.draw(window);
            window.Display();
        }

        //Call when the window has LostFocus
        static void window_LostFocus(object sender, EventArgs e)
        {

        }

        //Call when the window has GainedFocus
        static void window_GainedFocus(object sender, EventArgs e)
        {

        }

        //Call when the window is closed
        static void window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }

        public static void setToSwap(string mapPath)
        {
            swapFlag = true;
            swapPath = mapPath;
        }
    }
}
