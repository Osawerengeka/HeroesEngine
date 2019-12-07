using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Modificators
{
    public class Fire_Imm : Imod
    {
        public string Name { get; set; }
        public int Term { get; set; }

        public Fire_Imm()
        {
            Name = "FireImm";
            Term = -1;
        }
    }
}
