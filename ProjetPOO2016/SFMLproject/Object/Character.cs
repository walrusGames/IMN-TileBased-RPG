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
        private string _stateCharact;
        static Texture _perso;
        uint _statKnowledge, _statSpeed, _statEnergy, _statStress;
        string _nomPerso;
        List<String> _dialogue;
        public Dialogue Dia;

        internal int GetStats()
        {
            throw new NotImplementedException();
        }

        internal Sprite GetEncounterSprite()
        {
            throw new NotImplementedException();
        }
        public string GetState()
        {
            return _stateCharact;
        }

        public Sprite Sprite;
        private Vector2i _mapPos;
        private AttackList _attList;

        public Vector2i MapPos
        {
            get
            {
                return _mapPos;
            }

            set
            {
                _mapPos = value;
            }
        }

        public Character(String nom, Vector2i pos)
        {
            _stateCharact = "Down";
            _dialogue = new List<string>();
            String filePath = "File\\Perso\\" + nom + ".txt";
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(fileStream, Encoding.ASCII);
            //Lecture des infos du personnage
            _nomPerso = streamReader.ReadLine();
            filePath = streamReader.ReadLine();
            string state = streamReader.ReadLine();


            //Stats
            _statKnowledge = uint.Parse(streamReader.ReadLine());
            _statEnergy = uint.Parse(streamReader.ReadLine());
            _statSpeed = uint.Parse(streamReader.ReadLine());
            _statStress = uint.Parse(streamReader.ReadLine());

            _perso = new Texture(filePath);
            Sprite = new Sprite(_perso);
            Sprite.TextureRect = new IntRect(32, 0, 32, 32);
            Sprite.Scale = new Vector2f(1.5f, 1.5f);
            Sprite.Position = (Vector2f)pos * (float)Constants.tileSize;
            changePostureCharacter(state);
            MapPos = pos;
            //Stockage des dialogues
            string ligne;
            do
            {
                ligne = streamReader.ReadLine();
                _dialogue.Add(ligne);
            } while (ligne != null);
            Dia = new Dialogue(_dialogue);
            fileStream.Close();
            streamReader.Close();
        }

        public Character(String nom)
        {
            _stateCharact = "Down";
            _dialogue = new List<string>();
            String filePath = "File\\Perso\\" + nom + ".txt";
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(fileStream, Encoding.ASCII);

            //Lecture des infos du personnage
            _nomPerso = streamReader.ReadLine();
            filePath = streamReader.ReadLine();
            string state = streamReader.ReadLine();

            //Stats
            _statKnowledge = uint.Parse(streamReader.ReadLine());
            _statEnergy = uint.Parse(streamReader.ReadLine());
            _statSpeed = uint.Parse(streamReader.ReadLine());
            _statStress = uint.Parse(streamReader.ReadLine());

            //Initialisation du perso
            _perso = new Texture(filePath);
            Sprite = new Sprite(_perso);
            Sprite.TextureRect = new IntRect(32, 0, 32, 32);
            Sprite.Scale = new Vector2f(1.5f, 1.5f);
            Sprite.Position = new Vector2f(0, 0);
            changePostureCharacter(state);
            //Stockage des dialogues des NPCs
            string ligne;
            do
            {
                ligne = streamReader.ReadLine();
                _dialogue.Add(ligne);
            } while (ligne != null);
            Dia = new Dialogue(_dialogue);
            fileStream.Close();
            streamReader.Close();

        }

        public Character(String nom, Vector2i pos, String spritePosition)
        {
            _stateCharact = "Down";
            _dialogue = new List<string>();
            String filePath = "File\\Perso\\" + nom + ".txt";
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(fileStream, Encoding.ASCII);
            //Lecture des infos du personnage
            _nomPerso = streamReader.ReadLine();
            filePath = streamReader.ReadLine();
            //string state = streamReader.ReadLine();


            //Stats
            _statKnowledge = uint.Parse(streamReader.ReadLine());
            _statEnergy = uint.Parse(streamReader.ReadLine());
            _statSpeed = uint.Parse(streamReader.ReadLine());
            _statStress = uint.Parse(streamReader.ReadLine());

            _perso = new Texture(filePath);
            Sprite = new Sprite(_perso);
            Sprite.TextureRect = new IntRect(32, 0, 32, 32);
            Sprite.Scale = new Vector2f(1.5f, 1.5f);
            Sprite.Position = (Vector2f)pos* (float)Constants.tileSize;
            changePostureCharacter(spritePosition);
            MapPos = pos;
            //Stockage des dialogues
            string ligne;
            do
            {
                ligne = streamReader.ReadLine();
                _dialogue.Add(ligne);
            } while (ligne != null);
            Dia = new Dialogue(_dialogue);
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
            writer.WriteLine(Convert.ToString(_statKnowledge));
            writer.WriteLine(Convert.ToString(_statEnergy));
            writer.WriteLine(Convert.ToString(_statSpeed));
            writer.WriteLine(Convert.ToString(_statStress));

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

        public void SetAttackList(AttackList l) { _attList = l; }
        public AttackList GetAttackList() { return _attList; }

        public Character(Character character, Vector2i move)
        {
            Sprite = character.Sprite;
            MapPos = character.MapPos;
            _stateCharact = character._stateCharact;
            changePostureCharacter(_stateCharact);
            MoveMapPos(move);
        }

        public Character(Vector2i spawnPos)
        {
            throw new NotImplementedException();
        }

        private void changePostureCharacter(String position)
        {
            if (position != _stateCharact)
            {
                ChangeSpriteShow(position);
                _stateCharact = position;
            }
        }

        private void ChangeSpriteShow(String position)
        {
            if (position == "Down")
                Sprite.TextureRect = new IntRect(32, 0, 32, 32);
            if (position == "Left")
                Sprite.TextureRect = new IntRect(32, 32, 32, 32);
            if (position == "Right")
                Sprite.TextureRect = new IntRect(32, 64, 32, 32);
            if (position == "Up")
                Sprite.TextureRect = new IntRect(32, 96, 32, 32);
        }

        public void changePostureCharacter(Vector2i posi)
        {
            Vector2f temp = Sprite.Position;
            if (posi.X > 0)
                changePostureCharacter("Right");
            else if (posi.X < 0)
                changePostureCharacter("Left");
            else if (posi.Y < 0)
                changePostureCharacter("Up");
            else if (posi.Y > 0)
                changePostureCharacter("Down");
        }

        public void MoveMapPos(Vector2i pos)
        {
            MapPos += pos;
            Sprite.Position += new Vector2f(pos.X * Constants.tileSize, pos.Y * Constants.tileSize);
        }

        public Vector2i GetMapPos()
        {
            return MapPos;
        }

        public List<string> GetDialogue() { return _dialogue; }

        public void Dispose()
        {
            Sprite.Dispose();
        }
    }
}
