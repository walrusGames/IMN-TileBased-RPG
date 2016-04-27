using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Events
{
    class ActionEventAddStress : ActionEvent
    {
        private uint amount;

        public ActionEventAddStress(Character c, uint i) : base(c) { amount = i; }

        public override void execute()
        {
            character._statStress = character._statStress + amount;
            if (character._statStress < 0) character._statStress = 0;
        }
    }
}
