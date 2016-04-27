using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLproject.StaticFields;
using SFMLproject.Menu;

namespace SFMLproject.Encounter_ENV
{
    class MenuTextElement : MenuElement
    {
        public Text text;
        private TextProperties tProp = new TextProperties();
        private Menu.Menu link;
        
        public MenuTextElement(string t, Vector2f position)
        {
            text = new Text(t, tProp.font,tProp.size);
            text.Color = tProp.color;
            text.Position = position;
        }

        public MenuTextElement(string t, Vector2f position, Menu.Menu mLink)
        {
            text = new Text(t, tProp.font, tProp.size);
            text.Color = tProp.color;
            text.Position = position;
            link = mLink;
        }

        public Menu.Menu onClick()
        {
            return link;
        }

        internal void execute()
        {
            throw new NotImplementedException();
        }

        public override void draw(RenderWindow window)
        {
            window.Draw(text);
        }
    }
}
