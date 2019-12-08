using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Units
{
    public class Demon:Unit
    {
       public Demon() : base("DEMON", 166, 27, 25,(36,66), 11)
       {
            mod.Add(new Modificators.Fire_Imm());
            abl.Add(new Abilities.Extra_Damage());
            abl.Add(new Abilities.Fire_Ball());
        }
    }
}
