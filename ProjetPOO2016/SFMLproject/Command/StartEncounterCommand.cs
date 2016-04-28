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
        Character c;  
        StartEncounterCommand(Executer ex, Character ch)
        {
            c = ch; 
        }
        void AbstractCommand.execute()
        {
            Executer.StartEncounterLoop(c);
        }
    }
}
