using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Abilities
{
    public class Extra_Damage : Ispell
    {
        //public BattleUnitStack b;
        public int duration { get; set; }
        public string Name { get; set; }
        public bool solo { get; set; }
        public int cooldown { get; set; }
        public Extra_Damage()
        {
            Name = "Extra Damage";
            solo = true;
        }
        public void Doing(BattleUnitStack UsedUnit, BattleUnitStack OpposeUnit = null,Battle battle = null)
        {
            UsedUnit.bus.Damage.Item1 *= (int)1.2;
            UsedUnit.bus.Damage.Item2 *= (int)1.2;
            cooldown = 5;
            duration = 3;
        }


    }
}
