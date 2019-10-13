using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Units
{
    class Demon:Unit
    {
        private (int, int) Damag;

        public Demon() : base("DEMON", 166, 27, 25, 11)
        {
            Damag.Item1 = 36;
         Damag.Item2 = 66;
         Damage = Damag;

        }
    }
}
