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
using SFMLproject.Command;

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
            window.Position = new Vector2i(0, 0);
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
            music.Play();
            menuInGame.visible = false;
            while (window.IsOpen)
            {
                MouseAction();
                window.DispatchEvents();
                if (keypressed)
                {
                    drawEverything();
                }
                if (Mouse.IsButtonPressed(Mouse.Button.Right))
                {
                    menuInGame.visible = true;
                    drawEverything();
                }
            }
        }
        public static void drawEverything()
        {
            if (swapFlag) swapMap();
            window.Clear();
            window.SetView(map.getMapview());
            map.draw(window);
            if (menuInGame.visible)
            {
                menuInGame.draw(window);
            }
            window.Display();
            keypressed = false;
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
                    menuInGame.visible =! menuInGame.visible;
                    drawEverything();
                    break;
                case Keyboard.Key.Up:
                    if (menuInGame.visible)
                    {
                        menuInGame.setPosition(menuInGame.position - 1);
                        menuInGame.highlight(menuInGame.position);
                        drawEverything();
                    }break;
                case Keyboard.Key.Down:
                    if (menuInGame.visible)
                    {
                        menuInGame.setPosition(menuInGame.position + 1);
                        menuInGame.highlight(menuInGame.position);
                        drawEverything();
                    } break;
                case Keyboard.Key.LShift:
                    if (menuInGame.visible)
                    {
                        menuInGame.activate(menuInGame.position);
                    } break;
                    default: break;
             }
        }

        public static void MouseAction()
        {
            Vector2f mousePos = new Vector2f(Mouse.GetPosition().X, Mouse.GetPosition().Y) - (new Vector2f(window.Position.X, window.Position.Y) + new Vector2f(6,26));

            if (menuInGame.visible)
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    menuInGame.activate(mousePos);
                    menuInGame.visible = false;
                    drawEverything();
                }

            }
        }
        /*Window Fonctions*/
        //Call when the window is resized
        static void window_Resized(object sender = null, SizeEventArgs e = null)
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
            //TestCommand testCommand = new TestCommand();
            menuInGame.addButton("Sauver", new TestCommand("Sauver"));
            menuInGame.addButton("Attaques", new TestCommand("Attaques"));
            menuInGame.addButton("Stats", new TestCommand("Stats"));
            menuInGame.addButton("Combat", new TestCommand("Combat"));
            menuInGame.show();
            menuInGame.highlight(menuInGame.position);
        }


        static public void closeMenuIntro()
        {
            menuIntro.hide();
        }
    }
}
