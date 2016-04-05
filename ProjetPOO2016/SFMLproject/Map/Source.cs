using SFMLproject.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Map
{
    abstract class Source
    {
        private List<Observer> obt;

        public abstract void notify(Observer ob);

        public void Attach(Observer ob) { obt.Add(ob); }
        public void Kill(Observer ob) { obt.Remove(ob); }
    }
}
