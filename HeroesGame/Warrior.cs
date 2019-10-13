using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes
{
    class Warrior : Unit
    {
        private (int, int) Damag;

        public Warrior() : base("WARRIOR", 16, 5,3,16)
        {
            Damag.Item1 = 5;
         Damag.Item2 = 7;
         Damage = Damag;


        }
    }
}
