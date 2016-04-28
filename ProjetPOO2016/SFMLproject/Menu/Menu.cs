using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLproject.Encounter_ENV;
using SFMLproject.Object;
using SFML.System;

namespace SFMLproject.Menu
{		
    abstract class Menu
    {   internal bool visible;
        private View menuView;
        internal Shape menuBody;
        internal Vector2f dimensions;
        int padding;
        internal float borderSize;
        
        public Color backHigh = new Color(0, 0, 0);
        public Color border = new Color(Color.Black);
        public Color bordHigh = new Color(255, 140, 0);

            public View getMenuView()
            {
                return menuView;
            }

            public void setMenuView(View value)
            {
                menuView = value;
            }
        

        public Menu(Vector2f dim, int pad, float bordS, View v)
        {
            //this.sprite = sprite;
            menuView = v;
            visible = true;
            dimensions = dim;
            padding = pad;
            borderSize = bordS;
           
            menuView = new View(new FloatRect(200, 200, 300, 200));

            //Background
            menuBody = new RectangleShape(menuView.Size);
            menuBody.OutlineThickness = borderSize;
            menuBody.OutlineColor = border;
        }

        public void draw(RenderWindow window)
        {
            if (!visible) return;
                drawImpl(window); 
            return;
        }
        internal void addElement(Attack attackList)
        {
        }

        public void addElement(MenuTextElement attackList)
        {
        }

        public abstract void drawImpl(RenderWindow window);

        public bool isVisible()
        {
            return visible = !(visible);
        }
    }		
}