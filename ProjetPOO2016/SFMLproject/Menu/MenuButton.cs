using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFMLproject.TextureFolder;
using SFMLproject.Encounter_ENV;


namespace SFMLproject.Menu
{
    class MenuButton : MenuElement, Invoker
    {
        AbstractCommand cmd; 
        private RectangleShape rectShape;
        private Menu link;
        private MenuTextElement menutxt;

        public MenuButton(Vector2f size, Vector2f position, Menu mLink, String txt)
        {
            SpriteEnum t = new SpriteEnum();

            rectShape = new RectangleShape(size);
            rectShape.Position = position;
            rectShape.Texture = t.getTextBackTexture();
            link = mLink;
            menutxt = new MenuTextElement(txt, position, mLink);
        }
        public MenuButton(Vector2f size, Vector2f position, Menu mLink, MenuTextElement txt)
        {
            SpriteEnum t = new SpriteEnum();

            rectShape = new RectangleShape(size);
            rectShape.Position = position;
            rectShape.Texture = t.getTextBackTexture();
            link = mLink;
            menutxt = txt;
        }

        public MenuButton(Vector2f size, Vector2f position, String txt)
        {
            SpriteEnum t = new SpriteEnum();

            rectShape = new RectangleShape(size);
            rectShape.Position = position;
            rectShape.Texture = t.getTextBackTexture();
            menutxt = new MenuTextElement(txt, position);
        }

        public override void draw(RenderWindow window)
        {
            window.Draw(rectShape);
            menutxt.draw(window);
        }

        public Menu onClick()
        {
            return link;
        }
        /*je suis pas trop sure si la fct fonctionne car j'ai pas encore teste*/
        public void mouseSelect(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Vector2i position = Mouse.GetPosition();
                if (rectShape.GetGlobalBounds().Contains(position.X, position.Y)) cmd.execute();
            }
        }

        public void storeCommand(AbstractCommand c)
        {
            cmd = c;
        }
    }
}