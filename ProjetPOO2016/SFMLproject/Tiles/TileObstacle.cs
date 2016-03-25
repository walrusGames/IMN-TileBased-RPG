using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace SFMLproject.Tiles
{
    class TileObstacle : Tile
    {

        public TileObstacle(Vector2f pos) : base(pos) { }

        public override Tile occupy(Character c)
        {
            return this;
        }

        public override Tile onLeave()
        {
            return this;
        }

        public override void tileEvent()
        { /*Ne ait rien*/}
    }
}
