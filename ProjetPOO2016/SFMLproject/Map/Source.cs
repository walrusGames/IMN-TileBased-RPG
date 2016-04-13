using SFML.System;
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
        protected List<Observer> obt = new List<Observer>();
        protected List<Observer> next = new List<Observer>();

        public abstract void notify(Vector2i m);

        public void Attach(Observer ob) { obt.Add(ob); }

        public void Queue(Observer ob) { next.Add(ob); }

        public void Dequeue() { next.ForEach(delegate (Observer obs) { obt.Add(obs); }); next.Clear(); }
        public void KillAll() { obt.Clear(); }

        public void Kill(Observer ob) { obt.Remove(ob); }
    }
}
