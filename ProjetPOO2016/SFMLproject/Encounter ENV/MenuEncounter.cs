using SFML.Graphics;
using SFMLproject.Encounter_ENV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Menu
{
    class MenuEncounter : Menu
    {
        internal List<MenuElement> menuContent;
        public MenuEncounter(Sprite sprite) : base(sprite)
        {
            menuContent = new List<MenuElement>();
        }
        public new void addElement(MenuTextElement text)
        {
            menuContent.Add(text);
        }

        public void addElement(MenuButton button)
        {
            menuContent.Add(button);
        }

        public new void draw(RenderWindow window)
        {
            foreach (MenuElement e in menuContent)
            {
                e.draw(window);
            }
            window.Draw(sprite);
        }
    }
}