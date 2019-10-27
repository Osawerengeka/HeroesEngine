using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame
{
    class BattleArmy
    {
       public List<BattleUnitStack> army;
        public BattleArmy(BattleUnitStack[] Pick)
        {
            army = Pick.ToList();
          
        }
        public BattleArmy(BattleArmy a)
        {
            army = a.army.ToList();
        }
        public void addStack(BattleUnitStack us)
        {
            if (army.Count < 9)
            {
                army.Add(us);
            }
        }
    }
}
