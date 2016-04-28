using SFML.Graphics;
using SFML.System;
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
        public Color background = new Color(Color.Cyan);
        public MenuEncounter(Vector2f dim, int pad, float bordS, View v) : base(dim, pad, bordS, v)
        {
            menuBody.FillColor = background;
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

        public override void drawImpl(RenderWindow window)
        {
            window.SetView(getMenuView()); 
            window.Draw(menuBody);
            window.SetView(window.DefaultView);
            foreach (MenuElement e in menuContent)
            {
                e.draw(window);
            }
            
        }

    }
}
