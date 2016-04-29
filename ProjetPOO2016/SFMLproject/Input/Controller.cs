using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


/*
 *
 * Note : This allow to get the trigger on my controller
 * Joystick.GetAxisPosition(controllerIndice, Joystick.Axis.Z)
 * The max value is 99 for the left and -99 for the right
 * 
 * Button for Gamepad F310
 * 
 * a = 0, b = 1, x = 2, y = 3 
 * mini trigger : left = 4 , right = 5
 * select = 6, start = 7
 * joystick press left = 8, joystick press right = 9
 * Trigger Left = 10, Trigger Right = 11
 */
namespace SFMLproject.Input
{
    class Controller
    {
        //Controller stat
        static uint buttonCount;
        static uint controllerIndice;

        public Controller()
        {
        }


        /*JoyStick Fonctions*/
        //Check if a Joystick if connected
        public bool isJoystickConnect()
        {
            Joystick.Update();
            for (uint i = 0; i < 8; i++)
            {
                if (Joystick.IsConnected(i))
                {
                    buttonCount = Joystick.GetButtonCount(i);
                    controllerIndice = i;
                    if (Joystick.HasAxis(i, Joystick.Axis.Z) && Joystick.HasAxis(i, Joystick.Axis.Y) && Joystick.HasAxis(i, Joystick.Axis.X))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Get the movement from the Left Joystick
        public Vector2f getMovementLeftJoystick()
        {
            Joystick.Update();
            return new Vector2f((int)Joystick.GetAxisPosition(controllerIndice, Joystick.Axis.X),
               (int)Joystick.GetAxisPosition(controllerIndice, Joystick.Axis.Y));
        }
        //Get the movement from the Right Joystick
        public Vector2f getMovementRightJoystick()
        {
            Joystick.Update();
            return new Vector2f((int)Joystick.GetAxisPosition(controllerIndice, Joystick.Axis.U),
               (int)Joystick.GetAxisPosition(controllerIndice, Joystick.Axis.R));
        }

        //Get the movement from the D-pad
        public Vector2f getMovementDpad()
        {
            Joystick.Update();
            return new Vector2f((int)Joystick.GetAxisPosition(controllerIndice, Joystick.Axis.PovX),
                   (int)Joystick.GetAxisPosition(controllerIndice, Joystick.Axis.PovY));
        }

        public uint getNumberButton()
        {
            return buttonCount;
        }

        /*
         * Get the number of a button press
         * For the triggers, it returns +0 and +1 of the buttonCount,
         * allowing to interact with the left and right trigger
         * 
         * If no button is pressed, it returns +2 of the buttonCount
        */
        public uint buttonPressed()
        {
            for (uint i = 0; i < buttonCount + 1; i++)
            {
                if (Joystick.IsButtonPressed(controllerIndice, i))
                    return i;
            }
            if (Joystick.GetAxisPosition(controllerIndice, Joystick.Axis.Z) > 10)
                return buttonCount;
            if (Joystick.GetAxisPosition(controllerIndice, Joystick.Axis.Z) < -10)
                return buttonCount + 1;
            return buttonCount + 2;
        }
    }
}
