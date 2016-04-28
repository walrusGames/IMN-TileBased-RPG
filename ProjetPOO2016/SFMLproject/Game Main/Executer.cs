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
using SFMLproject.Menu;

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

        static Menu.MenuPrincipal menuInGame = new Menu.MenuPrincipal(new Vector2f(175, 50), 4, 1, map.getMapview());
        static Menu.MenuPrincipal menuIntro = new Menu.MenuPrincipal(new Vector2f(175, 100), 4, 1, map.getMapview());

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
            generateIntroMessage();
            menuIntro.draw(window);
        }

        static void generateIntroMessage()
        {
            List<Character.characDialogueStruc> tex = new List<Character.characDialogueStruc>();
            Character.characDialogueStruc line = new Character.characDialogueStruc();

            line.dialogue = "Press 'e' to interact.";
            line.id = 0;
            line.nextIdList = new List<int>() { 1 };
            tex.Add(line);

            line.dialogue = "Welcome to your school!";
            line.id = 1;
            line.nextIdList = new List<int>() { 2 };
            tex.Add(line);

            line.dialogue = "Get ready for a whole lot of fun!";
            line.id = 2;
            line.nextIdList = new List<int>() { 3 };
            tex.Add(line);

            line.dialogue = "Press WASD to move around.";
            line.id = 3;
            line.nextIdList = new List<int>() { -1 };
            tex.Add(line);

            Dialogue dia = new Dialogue(tex);
            Vector2f position = new Vector2f(550, 350);
            dia.afficherIntro(position);

        }

        static void Main(string[] args)
        {
            loadMenuIntro();
            loadMenu();
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
                    menuInGame.draw(window);
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
                case Keyboard.Key.Space:
                    menuInGame.activate(3);
                                        break;
                    
                    default: break;
                                }
                    }

        public static void window_ButtonPressed(object sender, MouseButtonEvent e)
        {
            Vector2f mousePos = window.MapPixelToCoords(Mouse.GetPosition(window), map.getMapview());

            switch (e.Button)
            {
                case Mouse.Button.Left:
                    if (menuInGame.visible) menuInGame.activate(mousePos);
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
        
        static public void loadMenuIntro()
        {
            Command.StartGameCommand startCommand = new Command.StartGameCommand();
            menuIntro.addButton("Start", startCommand);
            menuIntro.show();
        }

        static public void loadMenu()
        {
            Command.StartGameCommand startCommand = new Command.StartGameCommand();
            menuInGame.addButton("Sauver", startCommand);
            menuInGame.addButton("Attaques", startCommand);
            menuInGame.addButton("Stats", startCommand);
            menuInGame.addButton("Combat", startCommand);
            menuInGame.show();
        }


        static public void closeMenuIntro()
        {
            menuIntro.hide();
        }
    }
}
