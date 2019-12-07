using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Modificators
{
    public class Ice_Imm : Imod
    {
        public string Name { get; set; }
        public int Term { get; set; }

        public Ice_Imm()
        {
            Name = "IceImm";
            Term = -1;
        }
    }
}
