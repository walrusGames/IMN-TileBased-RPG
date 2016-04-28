using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLproject.Encounter_ENV;
using SFMLproject.Object;

namespace SFMLproject.Menu
{		
    class Menu
    {		
        private View menuView;		
        private Sprite menuSprite;
        internal Sprite sprite;

        public Menu(Sprite sprite)
        {
            this.sprite = sprite;
        }

        internal void addElement(AttackList attackList)
        {
        }

        public void addElement(MenuTextElement attackList)
        {
        }

        public void draw(RenderWindow windoww)
        {
            windoww.Draw(sprite);
        }
    }		
}