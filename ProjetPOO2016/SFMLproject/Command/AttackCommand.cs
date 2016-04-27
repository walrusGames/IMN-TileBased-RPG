using SFMLproject.Encounter_ENV;
using SFMLproject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Command
{
    class AttackCommand : AbstractCommand
    {
        Encounter enc;
        Character ch;
        private Encounter encounter;
        private float v;



        public AttackCommand(Encounter encounter, float v, Character ch)
        {
            this.encounter = encounter;
            this.v = v;
            this.ch = ch;
        }

        public void execute()
        {
            enc.setExamTime(enc.getExamTime() - (v*ch.getStress()/(ch.getEnergy()*ch.getSpeed())));
            enc.setNbAttackLeft();
        }
    }
}
