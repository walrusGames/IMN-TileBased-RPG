using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Events
{
    class ActionEventAddKnowledge : ActionEvent
    {
        private uint amount;

        public ActionEventAddKnowledge(Character c, uint i) : base(c) { amount = i; }

        public override void execute()
        {
            character._statKnowledge = character._statKnowledge + amount;
            if (character._statKnowledge < 0) character._statKnowledge = 0;
        }
    }
}
