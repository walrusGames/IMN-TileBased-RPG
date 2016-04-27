using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Events
{
    class ActionEventVoid : ActionEvent
    {
        public ActionEventVoid(Character c) : base(c) { }
        public override void execute()
        { throw new InvalidOperationException("Event type not specified."); }
    }
}
