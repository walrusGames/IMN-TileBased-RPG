using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Events
{
    class ActionEventAddEnergy : ActionEvent
    {
        private uint amount;

        public ActionEventAddEnergy(Character c, uint i) : base(c) { amount = i; }

        public override void execute()
        {
            character._statEnergy = character._statEnergy + amount;
            if (character._statEnergy < 0) character._statEnergy = 0;
        }
    }
}
