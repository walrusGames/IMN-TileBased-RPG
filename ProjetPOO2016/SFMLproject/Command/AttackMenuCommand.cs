using SFMLproject.Menu;
using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Encounter_ENV
{
    class AttackMenuCommand : Command
    {
        private Encounter e;
        private MenuEncounter m; 
        public AttackMenuCommand(Encounter enc)
        {
            e = enc;
        }

        public AttackMenuCommand(MenuEncounter menu)
        {
            m = menu; 
        }
        public void execute()
        {
            e.attackSubMenu();
        }
    }
}