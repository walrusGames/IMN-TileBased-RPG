using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using SFMLproject.Constt;

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
        public Sprite sprite;
        private Vector2i mapPos = new Vector2i(10, 10);

        public Character(){
            perso = new Texture("File\\Perso\\perso 4.png");
            sprite = new Sprite(perso);
            sprite.TextureRect = new IntRect(0, 0, 32, 48);
            sprite.Scale += new Vector2f(1f, 1f);
            sprite.Position = (Vector2f)mapPos * (float)30;
        }
        
        public Character(String filePath, String state){
            perso = new Texture(filePath);
            sprite = new Sprite(perso);
            sprite.TextureRect = new IntRect(0, 0, 32, 48);
            sprite.Scale += new Vector2f(1f, 1f);
            stateCharact = state;
            sprite.Position = (Vector2f)mapPos * (float)30;
        }

        private void changePostureCharacter(String position)
        {
            if (position != stateCharact)
            {
                changeSpriteShow(position);
                stateCharact = position;
            }
        }
       
        private void changeSpriteShow(String position){
            if (position == "Down")
                sprite.TextureRect = new IntRect(0, 0, 32, 48);
            if (position == "Left")
                sprite.TextureRect = new IntRect(0, 48, 32, 48);
            if (position == "Right")
                sprite.TextureRect = new IntRect(0, 96, 32, 48);
            if (position == "Up")
                sprite.TextureRect = new IntRect(0, 144, 32, 48);
        }

        public void moveCharacter(Vector2f posi){
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
            sprite.Position = (Vector2f)mapPos * (float)Constants.tileSize;
        }

        public void moveMapPos(Vector2i pos)
        {
            mapPos += pos;
        }

        public Vector2i getMapPos()
        {
            return mapPos;
        }
    }
}
