using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Modificators
{
    public class No_Counter : Imod
    {
        public string Name { get; set; }
        public int Term { get; set; }

        public No_Counter()
        {
            Name = "No_Counter";
            Term = -1;
        }
    }
}
