using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFMLproject.Map;
using SFMLproject.Object;
using SFMLproject.StaticFields;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLproject.TextureFolder;
using SFMLproject.Encounter_ENV;

namespace SFMLproject.Menu
{
    class Dialogue
    {

        List<Character.characDialogueStruc> text;
        SpriteEnum t = new SpriteEnum();
        //View dialogView;
        MenuTextElement textAff;
        //String statText;
        static bool keyPressed = false;

        public Dialogue(List<Character.characDialogueStruc> tex)
        {
            text = tex;
        }

        public void afficher(Vector2f position)
        {
            Executer.window.Display();
           // c.setKnowledge(2);
           // c.setEnergy(-2);

            Executer.window.KeyPressed -= Executer.window_KeyPressed;
            Executer.window.KeyPressed += window_KeyPressed;
            int i = 0;

            // The elements' position of the dialogue box
            Vector2f boxPosition = new Vector2f(position.X - 150, position.Y - 160);
            Vector2f textPosition = new Vector2f(position.X - 140, position.Y - 150);
            Vector2f textPositionAdjust = new Vector2f(position.X - 140, position.Y - 174);

            // Place the dialogue box on top of the NPC
            Sprite boxSprite = t.getTextBack();
            boxSprite.Position = boxPosition;
            Executer.window.Draw(boxSprite);
            int temps = 10;
            if (temps > 0)
            {
                // Place the text inside the dialogue box
               // statText = "Knowledge: " + c.getKnowledge().ToString() + " Energy: " + c.getstatEnergy().ToString() + "\n"
                //           + "Stress: " + c.getstatStress().ToString() + " Speed: " + c.getstatSpeed().ToString() + "\n";
               // statText += "Temps restant: " + temps.ToString() + "\n";
                textAff = new MenuTextElement(text[i].dialogue, textPosition);
                textAff.draw(Executer.window);
            }
            else {
                textAff = new MenuTextElement("GAME OVER", textPosition);
                textAff.draw(Executer.window);
                Executer.window.Display();

                while (true)
                {
                    Executer.window.DispatchEvents();
                    if (keyPressed)
                    {
                        Executer.window.Close();
                        System.Environment.Exit(0);
                    }
                }
            }

            //Show the dialogue box
            Executer.window.Display();

            while (i != -1)
            {

                Executer.window.DispatchEvents();

                if (keyPressed)
                {
                    if (text[i].nextIdList[0] == -1) { i = -1; keyPressed = false; }
                    else {
                        i = text[i].nextIdList[0]; //TODO changer selon choix

                        // Change the box to the next line of dialogue
                        Executer.window.Display();
                        Executer.window.Draw(boxSprite);
                        textAff = new MenuTextElement( text[i].dialogue, textPositionAdjust);
                        textAff.draw(Executer.window);

                        //Show the dialogue box
                        Executer.window.Display();

                        keyPressed = false;
                    }
                }

            }
            Executer.window.KeyPressed -= window_KeyPressed;
            Executer.window.KeyPressed += Executer.window_KeyPressed;
        }

        static void window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.E) keyPressed = true;
        }
    }
}