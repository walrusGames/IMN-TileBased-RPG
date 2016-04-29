using SFML.System;
using SFMLproject.Events;
using SFMLproject.Menu;
using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SFMLproject.Command
{ 
    class SaveCommand : Encounter_ENV.Command
    {
        Dialogue dia;
        protected Character character;

        public void execute()

        {
            throw new NotImplementedException();
        }

        public void execute(Character c)
        {
            List<Character.characDialogueStruc> tex = new List<Character.characDialogueStruc>();
            Character.characDialogueStruc line = new Character.characDialogueStruc();
            line.dialogue = "Game has been saved.";
            line.id = 0;
            line.nextIdList = new List<int>() { -1 };
            tex.Add(line);

            dia = new Dialogue(tex);
            Vector2f position = new Vector2f(50, 350);
            character.SaveCharacter();
            dia.afficher(position);
            
        }
    }
}
