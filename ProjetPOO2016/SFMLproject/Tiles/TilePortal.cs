using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace SFMLproject.Tiles
{
    class TilePortal : Tile
    {
        private string mapPath;

        public TilePortal(Sprite spr,string s) : base(spr) {
            mapPath = s;
        }

        public override void tileEvent()
        {
            throw new NotImplementedException();
        }

        public override void updateOnAction()
        {
            Console.WriteLine("Action Button Pressed - Portal tile");
            mapState = Map.Map.getState();
            mapState.setState(new Map.Map(mapPath));
        }

        public override bool updateOnInteract()
        {
            return true;
        }

        public override void updateOnLeave(Vector2i ind)
        {
            throw new NotImplementedException();
        }

        public override bool updateOnOccupy()
        {
            mapState = Map.Map.getState();
            mapState.setState(new Map.Map(mapPath));
            return false;
        }

        public override void updateOnReact(Vector2i ind)
        {
            throw new NotImplementedException();
        }
    }
}
