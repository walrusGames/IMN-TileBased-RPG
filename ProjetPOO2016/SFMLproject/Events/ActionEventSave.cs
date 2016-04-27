using SFMLproject.Menu;
using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace SFMLproject.Events
{
    class ActionEventSave : ActionEvent
    {
        private List<string> tex;
        Dialogue dia;

        public ActionEventSave(Character c) : base(c) {
            //tex.Add("Saved the game!");
            
        }
        public override void execute()
        {
            tex = new List<string>();
            tex.Add("Saved the game!");
            tex.Add("null");
            dia = new Dialogue(tex);
            Vector2f position = new Vector2f(50, 350);
            character.SaveCharacter();
            dia.afficher(position);
        }
    }
}
