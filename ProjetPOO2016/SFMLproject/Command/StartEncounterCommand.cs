using SFMLproject.Encounter_ENV;
using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Command
{
    class StartEncounterCommand : AbstractCommand
    {
        Encounter e;
        Character c;  
        StartEncounterCommand(Encounter enc, Character ch)
        {
            enc = e;
            c = ch; 
        }
        void AbstractCommand.execute()
        {
            e.StartEncounterLoop(c);
        }
    }
}
