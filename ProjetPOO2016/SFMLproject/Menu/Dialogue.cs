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

        public void afficher()
        {
            
            Executer.window.KeyPressed -= Executer.window_KeyPressed;
            Executer.window.KeyPressed += window_KeyPressed;
            int i = 0;
            Executer.window.Draw(t.getTextBack());
            textAff = new MenuTextElement(text[i], new Vector2f(1,1));
            textAff.draw(Executer.window);
            Executer.window.Display();

            while (i<text.Count)
            {
                
                Executer.window.DispatchEvents();

                if (keyPressed)
                {
                    i++;
                    textAff = new MenuTextElement(text[i], new Vector2f(1, 1));
                    textAff.draw(Executer.window);
                    Executer.window.Draw(t.getTextBack());
                    //Afficher text
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