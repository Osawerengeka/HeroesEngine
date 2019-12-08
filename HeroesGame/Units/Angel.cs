using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Units
{
    public class Angel : Unit
    {
        public Angel() : base("ANGEL", 180, 27, 27,(45,45), 11)
        {
            mod.Add(new Modificators.No_Counter());
            mod.Add(new Modificators.Fire_Imm());
        }
    }
}
