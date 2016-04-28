using SFML.Graphics;
using SFML.System;
using SFMLproject.Object;
using SFMLproject.TextureFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLproject.Menu;
using SFMLproject.Command;

namespace SFMLproject.Encounter_ENV
{
    class Encounter
    {
        internal View encounterView;
        private Sprite encounterBkgr;
        private EncounterCharacter player;
        private EncounterCharacter opponent;
        private SpriteEnum spEnum;

        private MenuEncounter baseMenu;
        private MenuEncounter attackMenu;
        private MenuEncounter itemMenu;
        private uint nbAttackExam; 
        private float examTime; 
        private MenuEncounter currentMenu;

        public Encounter(Character ch)
        {
            //Menu back
            //encounterBkgr = new Sprite(spEnum.getEncounterBkgr());
            spEnum = new SpriteEnum();
            examTime = 200;

            encounterView = new View(new FloatRect(200, 200, 300, 200)); 
            itemMenu = new MenuEncounter(new Vector2f(300, 300), 5, 10, encounterView);
            baseMenu = new MenuEncounter(new Vector2f(300, 300), 5, 10, encounterView);
            initAttackMenu(ch); 
            MenuButton attackButton = new MenuButton(new Vector2f(60, 20), new Vector2f(100, 600), attackMenu, "ATTACK");
            MenuButton itemButton = new MenuButton(new Vector2f(60, 20), new Vector2f(200, 600), itemMenu, "ATTACK");
            MenuButton skipButton = new MenuButton(new Vector2f(60, 20), new Vector2f(300, 600), "SKIP");
            attackButton.storeCommand(new AttackMenuCommand(this));
            baseMenu.addElement(attackButton);
            baseMenu.addElement(itemButton);
            baseMenu.addElement(skipButton);
            baseMenu.addElement(new MenuTextElement("SUICIDE", new Vector2f(1, 1)));
            
            player = new EncounterCharacter(ch, new FloatRect(0, 0, 32, 32));
            //opponent = new EncounterCharacter(op, new FloatRect(0, 0, 32, 32));
            nbAttackExam = (uint)ch.getKnowledge();
            currentMenu = baseMenu;
         
        }

        private void initAttackMenu(Character ch)
        {
            attackMenu = new MenuEncounter(new Vector2f(300, 300), 5, 1, encounterView);
           foreach(Attack a in ch.getCurrentAttack()){
                int i = 1; 
                MenuButton attack = new MenuButton(new Vector2f(60, 20), new Vector2f(i*100, 600), a.getName());
                attack.storeCommand(new AttackCommand(this, a.getDamage(), ch));
                attackMenu.addElement(attack);
                ++i;
            }

        }

        public void draw(RenderWindow window)
        {

            window.Clear();
            window.SetView(encounterView);
            player.draw(window);
            currentMenu.draw(window);
            baseMenu.addElement(new MenuTextElement("EXAM TIME LEFT  :  " + getExamTime().ToString(), new Vector2f(10, 200)));
            window.Display(); 
        }

        public Menu.Menu attackSubMenu()
        {
            return currentMenu = attackMenu;
        }

        public float getExamTime()
        {
            return examTime;
        }

        public void setExamTime(float newExamTime)
        {
            examTime = newExamTime; 
        }
        public void setNbAttackLeft()
        {
            nbAttackExam--; 
        }

        public float getNbAttackLeft()
        {
            return nbAttackExam; 
        }


    }
}
