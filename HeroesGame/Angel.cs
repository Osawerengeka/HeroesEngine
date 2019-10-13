using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes
{
    class Angel : Unit
    {
        private (int, int) Damag;
        
        public Angel() : base("ANGEL", 180, 27, 27, 45)
        {
            Damag.Item1 = 45;
            Damag.Item2 = 45;
            Damage = Damag;
                
            
        }
    }
}
