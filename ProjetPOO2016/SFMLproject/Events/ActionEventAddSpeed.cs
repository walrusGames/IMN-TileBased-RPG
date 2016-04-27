using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Events
{
    class ActionEventAddSpeed : ActionEvent
    {
        private uint amount;

        public ActionEventAddSpeed(Character c, uint i) : base(c) { amount = i; }

        public override void execute()
        {
            character._statSpeed = character._statSpeed + amount;
            if (character._statSpeed < 0) character._statSpeed = 0;
        }
    }
}
