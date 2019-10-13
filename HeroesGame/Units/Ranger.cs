using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Units
{
    class Ranger : Unit
    {
        private (int, int) Damag;

        public Ranger() : base("RANGER", 10, 4, 4, 8)
        {
            Damag.Item1 = 2;
            Damag.Item2 = 8;
         Damage = Damag;


        }
    }
}
