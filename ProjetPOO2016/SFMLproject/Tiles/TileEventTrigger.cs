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
using SFMLproject.Events;

namespace SFMLproject.Tiles
{
    class TileEventTrigger : Tile
    {
        ActionEvent eventTrigger;
        public TileEventTrigger(Sprite spr, ActionEvent ae) : base(spr)
        {
            eventTrigger = ae;
        }

        public override void tileEvent()
        { /*Ne ait rien*/}

        public override bool updateOnOccupy() { return false; }
        public override bool updateOnInteract() { return true; }
        public override void updateOnLeave(Vector2i move) { }
        public override void updateOnReact(Vector2i move) { }
        public override void updateOnAction() { eventTrigger.execute(); }

    }
}
