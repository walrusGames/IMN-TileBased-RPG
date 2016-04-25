using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using SFMLproject.StaticFields;
using System.IO;

namespace SFMLproject.Object
{
    class Character
    {
        /*Note
         *  One caracter is 48 x 32
         */
        //Character Info
        static String stateCharact = "Down";
        static Texture perso;
        uint statKnowledge, statSpeed, statEnergy, statStress;
        string nomPerso;
        List<String> dialogue;

        internal int getStats()
        {
            throw new NotImplementedException();
        }

        internal Sprite getEncounterSprite()
        {
            throw new NotImplementedException();
        }
        public string getState()
        {
            return stateCharact;
        }

        public Sprite sprite;
        private Vector2i mapPos;
        private AttackList attList;

        public Character(Vector2i pos)
        {
            perso = new Texture("File\\Perso\\perso 4.png");
            sprite = new Sprite(perso);
            sprite.TextureRect = new IntRect(0, 0, 32, 48);
            sprite.Scale += new Vector2f(1f, 1f);
            sprite.Position = (Vector2f)pos * (float)Constants.tileSize;
            mapPos = pos;
        }

        public Character(String nom)
        {

            dialogue = new List<string>();
            String filePath = "File\\Perso\\" + nom + ".txt";
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(fileStream, Encoding.ASCII);

            //Lecture des infos du personnage
            nomPerso = streamReader.ReadLine();
            filePath = streamReader.ReadLine();
            stateCharact = streamReader.ReadLine();
            //string position = stateCharact;
            //changeSpriteShow(position);

            //Stats
            statKnowledge = uint.Parse(streamReader.ReadLine());
            statEnergy = uint.Parse(streamReader.ReadLine());
            statSpeed = uint.Parse(streamReader.ReadLine());
            statStress = uint.Parse(streamReader.ReadLine());

            //Initialisation du perso
            perso = new Texture(filePath);
            sprite = new Sprite(perso);
            sprite.TextureRect = new IntRect(0, 0, 32, 48);
            sprite.Scale += new Vector2f(1f, 1f);
            sprite.Position =  new Vector2f(0,0);
            //Stockage des dialogues des NPCs
            string ligne;
            do
            {
                 ligne = streamReader.ReadLine();
                dialogue.Add(ligne);
            } while (ligne != null) ;

        }

        public Character(String filePath, String state, Vector2i pos)
        {
            perso = new Texture(filePath);
            sprite = new Sprite(perso);
            sprite.TextureRect = new IntRect(0, 0, 32, 48);
            sprite.Scale += new Vector2f(1f, 1f);
            stateCharact = state;
            sprite.Position = (Vector2f)pos * (float)Constants.tileSize;
            mapPos = pos;
        }

        public void setAttackList(AttackList l) { attList = l; }
        public AttackList getAttackList() { return attList; }

        public Character(Character character, Vector2i move)
        {
            sprite = character.sprite;
            mapPos = character.mapPos;
            moveMapPos(move);
        }

        private void changePostureCharacter(String position)
        {
            if (position != stateCharact)
            {
                changeSpriteShow(position);
                stateCharact = position;
            }
        }

        private void changeSpriteShow(String position)
        {
            if (position == "Down")
                sprite.TextureRect = new IntRect(0, 0, 32, 48);
            if (position == "Left")
                sprite.TextureRect = new IntRect(0, 48, 32, 48);
            if (position == "Right")
                sprite.TextureRect = new IntRect(0, 96, 32, 48);
            if (position == "Up")
                sprite.TextureRect = new IntRect(0, 144, 32, 48);
        }

        public void moveCharacter(Vector2i posi)
        {
            Vector2f temp = sprite.Position;
            if (posi.X > 0)
                changePostureCharacter("Right");
            else if (posi.X < 0)
                changePostureCharacter("Left");
            else if (posi.Y < 0)
                changePostureCharacter("Up");
            else if (posi.Y > 0)
                changePostureCharacter("Down");
            /*sprite.Position += posi;*/
           // sprite.Position = (Vector2f)mapPos * (float)Constants.tileSize;
        }

        public void moveMapPos(Vector2i pos)
        {
            mapPos += pos;
            sprite.Position += new Vector2f(pos.X * Constants.tileSize, pos.Y * Constants.tileSize);
        }

        public Vector2i getMapPos()
        {
            return mapPos;
        }

        public List<string> getDialogue(){ return dialogue; }
    }
}
