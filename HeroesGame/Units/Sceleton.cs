using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Units
{
    class Sceleton : Unit
    {
        private (int, int) Damag;

        public Sceleton() : base("SCELETON",5,1,2,10)
        {
            Damag.Item1 = 1;
            Damag.Item2 = 1;
         Damage = Damag;


        }
    }
}
