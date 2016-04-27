using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Events
{
    abstract class ActionEvent
    {
        protected Character character;

        public ActionEvent(Character c)
        {
            character = c;
        }
        public abstract void execute();


    }
}
