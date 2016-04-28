using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Command
{
    class StartGameCommand : Encounter_ENV.Command
    {
        private bool isStart = false;

        public StartGameCommand() { }

        public void execute()
        {
            isStart = true;
            Executer.closeMenuIntro();
        }
    }
}