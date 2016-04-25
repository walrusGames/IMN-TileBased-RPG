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
using System.Runtime.InteropServices;

namespace SFMLproject.Tiles
{


    class TileEmpty : Tile
    {

        public TileEmpty(Sprite spr) : base(spr) { }

        public override bool updateOnOccupy()
        {
            return true;
        }

        public override void updateOnLeave(Vector2i move) { }

        public override void tileEvent() { }
        public override bool updateOnInteract() { return true; }
        public override void updateOnReact(Vector2i ind)
        {
            /*Ne ait rien*/
        }
        public override void updateOnAction()
        {
            Console.WriteLine("Action Button Pressed - Empty tile");
        }
    }
}
