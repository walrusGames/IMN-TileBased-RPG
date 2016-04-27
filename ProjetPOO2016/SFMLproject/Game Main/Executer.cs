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

namespace SFMLproject
{

    class Executer
    {
        static ContextSettings context = new ContextSettings();
        static RenderWindow window;

        //Audio State
        static bool Playing = true;

        static Music music = new Music("File\\Music\\Student Life.ogg");

        static Controller controller = new Controller();

        static Object.Character charc = new Object.Character(new Vector2i(3,3));

        static Map.Map map = new Map.Map(charc, "File\\Map\\drago.txt");

        static View wholeView;

        static View mapView = map.getMapview();

        static bool keypressed = false;

        static void initWindow()
        {
            window = new RenderWindow(new VideoMode(1280, 720), "Project IFT 232", Styles.Default, context);
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
                    window.Clear();
                    window.SetView(map.getMapview());
                    //if (controller.ControllerPlugged)
                    //    charc.moveCharacter(controller.getMovementLeftJoystick() / 20);
                    map.draw(window);
                    //window.Draw(charc.sprite);
                    window.Display();
                    keypressed = false;
                }

            }
        }

        //static bool moveCharac(Keyboard.Key e)
        //{
        //    Tile depl;
        //    switch (e)
        //    {
        //        case Keyboard.Key.D:
        //            map.setTile(charc.getMapPos(), map.getTile(charc.getMapPos()).onLeave());
        //            charc.moveMapPos(new Vector2i(1, 0));

        //            depl = map.getTile(charc.getMapPos()).occupy(charc);
        //            if (depl is Character)
        //            {
        //                charc.moveCharacter(new Vector2f(30, 0));
        //                map.setCamera(new Vector2i(charc.getMapPos().X - 5, charc.getMapPos().Y - 5));
        //                return true;
        //            }
        //            else {
        //                charc.moveMapPos(new Vector2i(-1, 0));
        //                return false;
        //            }
        //        case Keyboard.Key.A:
        //            map.setTile(charc.getMapPos(), map.getTile(charc.getMapPos()).onLeave());
        //            charc.moveMapPos(new Vector2i(-1, 0));
        //            depl = map.getTile(charc.getMapPos()).occupy(charc);
        //            if (depl is Character)
        //            {
        //                charc.moveCharacter(new Vector2f(-30, 0));
        //                map.setCamera(new Vector2i(charc.getMapPos().X - Constants.camCol / 2, charc.getMapPos().Y - Constants.camRow / 2));
        //                return true;
        //            }
        //            else {
        //                charc.moveMapPos(new Vector2i(1, 0));
        //                return false;
        //            }
        //        case Keyboard.Key.S:
        //            map.setTile(charc.getMapPos(), map.getTile(charc.getMapPos()).onLeave());
        //            charc.moveMapPos(new Vector2i(0, 1));
        //            depl = map.getTile(charc.getMapPos()).occupy(charc);
        //            if (depl is Character)
        //            {
        //                charc.moveCharacter(new Vector2f(0, 30));
        //                map.setCamera(new Vector2i(charc.getMapPos().X - Constants.camCol / 2, charc.getMapPos().Y - Constants.camRow / 2));
        //                return true;
        //            }
        //            else {
        //                charc.moveMapPos(new Vector2i(0, -1));
        //                return false;
        //            }
        //        case Keyboard.Key.W:
        //            map.setTile(charc.getMapPos(), map.getTile(charc.getMapPos()).onLeave());
        //            charc.moveMapPos(new Vector2i(0, -1));
        //            depl = map.getTile(charc.getMapPos()).occupy(charc);
        //            if (depl is Character)
        //            {
        //                charc.moveCharacter(new Vector2f(0, -30));
        //                map.setCamera(new Vector2i(charc.getMapPos().X - Constants.camCol / 2, charc.getMapPos().Y - Constants.camRow / 2));
        //                return true;
        //            }
        //            else {
        //                charc.moveMapPos(new Vector2i(0, 1));
        //                return false;
        //            }
        //    }
        //    return false;
        //}

        /*Mouse
         Action on the mouse:
         * Mouse.IsButtonPressed(Mouse.Button.XXXXX) retourne un bool
         * Mouse.GetPosition() retourne un Vector2i
         * Mouse.setPosition(Vector2i(X,Y) place la souris
         * event.type == sf::Event::MouseWheelMoved
         */

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
        static void window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (map.moveCharac(e.Code))
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
                default: break;
            }
        }

        /*Window Fonctions*/
        //Call when the window is resized
        static void window_Resized(object sender, SizeEventArgs e)
        {

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
    }
}
