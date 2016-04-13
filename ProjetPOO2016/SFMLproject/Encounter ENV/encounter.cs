using SFML.Graphics;
using SFML.System;
using SFMLproject.Object;
using SFMLproject.TextureFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Encounter_ENV
{
    class Encounter
    {
        private View encounterView;  
        private Sprite encounterBkgr; 
        private EncounterCharacter player; 
        private EncounterCharacter opponent;
        private SpriteEnum spEnum;

        private Menu baseMenu;
        private Menu attackMenu;
        private Menu itemMenu;

        private Menu currentMenu;

        public Encounter(Character ch, Character op)
        {
            //Menu back
            encounterBkgr = new Sprite(spEnum.getEncounterBkgr());

            attackMenu = new Menu(spEnum.getMenuBkgr());
            attackMenu.addElement(ch.getAttackList());

            itemMenu = new Menu(spEnum.getMenuBkgr());

            baseMenu = new Menu(spEnum.getMenuBkgr());
            baseMenu.addElement(new MenuTextElement("ATTACK", new Vector2f(0, 0),attackMenu));
            baseMenu.addElement(new MenuTextElement("ITEM", new Vector2f(0, 1), itemMenu));
            baseMenu.addElement(new MenuTextElement("SKIP", new Vector2f(1, 0)));
            baseMenu.addElement(new MenuTextElement("SUICIDE", new Vector2f(1, 1)));

            player = new EncounterCharacter(ch, new FloatRect(0, 0, 32, 32));
            opponent = new EncounterCharacter(op, new FloatRect(0, 0, 32, 32));

            currentMenu = baseMenu;
        }

        public void draw(RenderWindow window)
        {
            window.Draw(encounterBkgr);

            opponent.draw(window);
            player.draw(window);

            currentMenu.draw(window);
        }
    }
}
