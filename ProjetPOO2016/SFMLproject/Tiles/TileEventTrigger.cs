using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using SFMLproject.Object;

namespace SFMLproject.Tiles
{
    class TileEventTrigger : Tile
    {

        public TileEventTrigger(Sprite spr) : base(spr) { }

        public override void tileEvent()
        { /*Ne ait rien*/}

        public override bool updateOnOccupy() { return true; }
        public override bool updateOnInteract() { return true; }
        public override void updateOnLeave(Vector2i move) { }
        public override void updateOnReact(Vector2i move) { }
        public override void updateOnAction() { Console.WriteLine("Trigger"); }

    }
}
