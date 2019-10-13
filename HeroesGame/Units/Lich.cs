using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Units
{
    class Lich : Unit
    {
        private (int, int) Damag;

        public Lich() : base("LICH",50,15,15,10)
        {

            Damag.Item1 = 12;
            Damag.Item2 = 17;
         Damage = Damag;

        }
    }
}
