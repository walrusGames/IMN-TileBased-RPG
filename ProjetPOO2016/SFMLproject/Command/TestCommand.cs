using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFMLproject.Command
{
    class TestCommand : Encounter_ENV.Command
    {
        String texte;
        public TestCommand(String test)
        {
            texte = test;
        }
        public void execute()
        {
            Console.WriteLine(texte);
        } 
    }
}
