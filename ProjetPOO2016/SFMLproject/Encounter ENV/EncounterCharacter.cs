using SFML.Graphics;
using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Encounter_ENV
{
    class EncounterCharacter
    {
        private View charView;
        private Sprite charSprite; 
        private int stats; // TO DO add some stats later

        public EncounterCharacter(Character c, FloatRect viewRect)
        {
            stats = c.GetStats();
            charSprite = c.GetEncounterSprite();
            charView = new View(viewRect);
        }

        public void draw(RenderWindow window)
        {
            window.Draw(charSprite);
        }

        public int getStatval()
        {
            return stats;
        }
    }
}
