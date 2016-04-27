using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLproject.Menu;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using SFMLproject.StaticFields;
using System.IO;
using System.Security.Permissions;

namespace SFMLproject.Object
{
    class Character : IDisposable
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
        public Dialogue dia;

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

        public Character(String nom, Vector2i pos)
        {
            dialogue = new List<string>();
            String filePath = "File\\Perso\\" + nom + ".txt";
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(fileStream, Encoding.ASCII);
            //Lecture des infos du personnage
            nomPerso = streamReader.ReadLine();
            filePath = streamReader.ReadLine();
            string state = streamReader.ReadLine();


            //Stats
            statKnowledge = uint.Parse(streamReader.ReadLine());
            statEnergy = uint.Parse(streamReader.ReadLine());
            statSpeed = uint.Parse(streamReader.ReadLine());
            statStress = uint.Parse(streamReader.ReadLine());

            perso = new Texture(filePath);
            sprite = new Sprite(perso);
            sprite.TextureRect = new IntRect(32, 0, 32, 32);
            sprite.Scale = new Vector2f(1.5f, 1.5f);
            sprite.Position = (Vector2f)pos * (float)Constants.tileSize;
            changePostureCharacter(state);
            mapPos = pos;
            //Stockage des dialogues
            string ligne;
            do
            {
                ligne = streamReader.ReadLine();
                dialogue.Add(ligne);
            } while (ligne != null);
            dia = new Dialogue(dialogue);
            fileStream.Close();
            streamReader.Close();
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
            string state = streamReader.ReadLine();

            //Stats
            statKnowledge = uint.Parse(streamReader.ReadLine());
            statEnergy = uint.Parse(streamReader.ReadLine());
            statSpeed = uint.Parse(streamReader.ReadLine());
            statStress = uint.Parse(streamReader.ReadLine());

            //Initialisation du perso
            perso = new Texture(filePath);
            sprite = new Sprite(perso);
            sprite.TextureRect = new IntRect(32, 0, 32, 32);
            sprite.Scale = new Vector2f(1.5f, 1.5f);
            sprite.Position = new Vector2f(0, 0);
            changePostureCharacter(state);
            //Stockage des dialogues des NPCs
            string ligne;
            do
            {
                ligne = streamReader.ReadLine();
                dialogue.Add(ligne);
            } while (ligne != null);
            dia = new Dialogue(dialogue);
            fileStream.Close();
            streamReader.Close();

        }

        public Character(String nom, Vector2i pos, String spritePosition)
        {
            dialogue = new List<string>();
            String filePath = "File\\Perso\\" + nom + ".txt";
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(fileStream, Encoding.ASCII);
            //Lecture des infos du personnage
            nomPerso = streamReader.ReadLine();
            filePath = streamReader.ReadLine();
            //string state = streamReader.ReadLine();


            //Stats
            statKnowledge = uint.Parse(streamReader.ReadLine());
            statEnergy = uint.Parse(streamReader.ReadLine());
            statSpeed = uint.Parse(streamReader.ReadLine());
            statStress = uint.Parse(streamReader.ReadLine());

            perso = new Texture(filePath);
            sprite = new Sprite(perso);
            sprite.TextureRect = new IntRect(32, 0, 32, 32);
            sprite.Scale = new Vector2f(1.5f, 1.5f);
            sprite.Position = (Vector2f)pos* (float)Constants.tileSize;
            changePostureCharacter(spritePosition);
            mapPos = pos;
            //Stockage des dialogues
            string ligne;
            do
            {
                ligne = streamReader.ReadLine();
                dialogue.Add(ligne);
            } while (ligne != null);
            dia = new Dialogue(dialogue);
            fileStream.Close();
            streamReader.Close();
        }
public void SaveCharacter()
        {
            String filePath = "File\\Perso\\NouvelEtudiant.txt";
            //File.Delete(filePath);
            var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            var writer = new StreamWriter(fs, Encoding.ASCII);
            //Entete
            writer.WriteLine("Nouvel Etudiant");
            writer.WriteLine("File\\Perso\\perso 4.png");
            writer.WriteLine("Down");
            //Nouveau stats
            writer.WriteLine(Convert.ToString(statKnowledge));
            writer.WriteLine(Convert.ToString(statEnergy));
            writer.WriteLine(Convert.ToString(statSpeed));
            writer.WriteLine(Convert.ToString(statStress));

            writer.Close();
            fs.Close();
        }

        /*public Character(String filePath, String state, Vector2i pos)
        {
            perso = new Texture(filePath);
            sprite = new Sprite(perso);
            sprite.TextureRect = new IntRect(0, 0, 32, 48);
            sprite.Scale = new Vector2f(1.5f, 1.5f);
            stateCharact = state;
            sprite.Position = (Vector2f)pos * (float)Constants.tileSize;
            mapPos = pos;
        }*/

        public void setAttackList(AttackList l) { attList = l; }
        public AttackList getAttackList() { return attList; }

        public Character(Character character, Vector2i move)
        {
            sprite = character.sprite;
            mapPos = character.mapPos;
            moveMapPos(move);
        }

        public Character(Vector2i spawnPos)
        {
            throw new NotImplementedException();
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
                sprite.TextureRect = new IntRect(32, 0, 32, 32);
            if (position == "Left")
                sprite.TextureRect = new IntRect(32, 32, 32, 32);
            if (position == "Right")
                sprite.TextureRect = new IntRect(32, 64, 32, 32);
            if (position == "Up")
                sprite.TextureRect = new IntRect(32, 96, 32, 32);
        }

        public void changeCharPosture(Vector2i posi)
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

        public List<string> getDialogue() { return dialogue; }

        public void Dispose()
        {
            sprite.Dispose();
        }
    }
}
