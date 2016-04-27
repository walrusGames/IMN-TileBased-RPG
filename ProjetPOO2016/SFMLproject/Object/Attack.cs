using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Object
{
    class Attack
    {
        private float damage;
        private String name;
        private Dictionary<StaticFields.attackType, float> weaknesses;

        public Attack(String n, float dmg)
        {
            name = n;
            damage = dmg;
        }

        public float getDamage()
        {
            return damage; 
        }

        public String getName()
        {
            return name;

        }
    }
}
