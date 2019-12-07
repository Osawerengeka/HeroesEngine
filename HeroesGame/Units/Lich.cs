using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame
{
    class Lich : Unit
    {
        public Lich() : base("LICH",50,15,15,(12,17),10)
        {
            mod.Add(new Modificators.Fire_Imm());
            mod.Add(new Modificators.Ice_Imm());
            abl.Add(new Abilities.Ice_Ball());
        }
    }
}
