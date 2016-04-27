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
        List<String> text;
        SpriteEnum t = new SpriteEnum();
        View dialogView;
        MenuTextElement textAff;
        static bool keyPressed = false;

        public Dialogue(List<String> tex)
        {
            text = tex;
            dialogView = new View(new FloatRect(0, 0, Constants.tileSize* Constants.camRow, Constants.tileSize* Constants.camCol));
        }

        public void afficher(Vector2f position)
        {
            Executer.window.Display();

            Executer.window.KeyPressed -= Executer.window_KeyPressed;
            Executer.window.KeyPressed += window_KeyPressed;
            int i = 0;

            // The elements' position of the dialogue box
            Vector2f boxPosition = new Vector2f(position.X - 150, position.Y - 160);
            Vector2f textPosition = new Vector2f(position.X - 140, position.Y - 150);

            // Place the dialogue box on top of the NPC
            Sprite boxSprite = t.getTextBack();
            boxSprite.Position = boxPosition;
            Executer.window.Draw(boxSprite);

            // Place the text inside the dialogue box
            textAff = new MenuTextElement(text[i], textPosition);
            textAff.draw(Executer.window);

            //Show the dialogue box
            
            Executer.window.Display();

            while (i<text.Count -1)
            {
                
                Executer.window.DispatchEvents();

                if (keyPressed)
                {
                    i++;
                    Executer.window.Display();
                    // Change the box to the next line of dialogue
                    Executer.window.Draw(boxSprite);
                    textAff = new MenuTextElement(text[i], textPosition);
                    textAff.draw(Executer.window);

                    //Show the dialogue box
                    Executer.window.Display();

                    keyPressed = false;
                }

            }
           Executer.window.KeyPressed -= window_KeyPressed;
           Executer.window.KeyPressed += Executer.window_KeyPressed;
        }

        static void window_KeyPressed(object sender, KeyEventArgs e)
        {
            if(e.Code == Keyboard.Key.E) keyPressed = true;
        }


    }
}