using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Tiles
{
    abstract class Observer
    {
        public abstract void updateOnOccupy(TileCharacter c);
        public abstract void updateOnLeave();
    }
}
