using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Events
{
    class ActionEventTeleport : ActionEvent
    {
        private String mapPath;

        public ActionEventTeleport(Character c, string s) : base(c) {
            mapPath = s;
        }
        public override void execute()
        {
            Executer.setToSwap(mapPath);
        }
    }
}
