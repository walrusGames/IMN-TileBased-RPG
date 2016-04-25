using SFML.System;
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
        public abstract bool updateOnOccupy();
        public abstract void updateOnLeave(Vector2i ind);
        public abstract void updateOnReact(Vector2i ind);
        public abstract void updateOnAction();
        public abstract bool updateOnInteract();
    }
}
