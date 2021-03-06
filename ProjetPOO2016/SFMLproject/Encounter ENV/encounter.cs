﻿using SFML.Graphics;
using SFML.System;
using SFMLproject.Object;
using SFMLproject.TextureFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLproject.Menu;

namespace SFMLproject.Encounter_ENV
{
    class Encounter
    {
        private View encounterView;  
        private Sprite encounterBkgr; 
        private EncounterCharacter player; 
        private EncounterCharacter opponent;
        private SpriteEnum spEnum;

        private MenuEncounter baseMenu;
        private MenuEncounter attackMenu;
        private MenuEncounter itemMenu;

        private MenuEncounter currentMenu;

        public Encounter(Character ch, Character op)
        {
            //Menu back
            encounterBkgr = new Sprite(spEnum.getEncounterBkgr());

            attackMenu = new MenuEncounter(spEnum.getMenuBkgr());
            itemMenu = new MenuEncounter(spEnum.getMenuBkgr());
            baseMenu = new MenuEncounter(spEnum.getMenuBkgr());

            MenuButton attackButton = new MenuButton(new Vector2f(10, 4), new Vector2f(0, 0), attackMenu, "ATTACK");
            MenuButton itemButton = new MenuButton(new Vector2f(10, 4), new Vector2f(0, 1), itemMenu, "ATTACK");
            MenuButton skipButton = new MenuButton(new Vector2f(10, 4), new Vector2f(1, 0), "SKIP");
            attackButton.storeCommand(new AttackMenuCommand(this)); 
            baseMenu.addElement(attackButton);
            baseMenu.addElement(itemButton);
            baseMenu.addElement(skipButton); 
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

        public Menu.Menu attackSubMenu()
        {
            return currentMenu = attackMenu;
        }
    }
}
