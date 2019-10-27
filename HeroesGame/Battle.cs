using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame
{
    class Battle
    {
        public int round = 0;
        public BattleArmy player1;
        public BattleArmy player2;
        public string winner = "";
        public Battle(BattleArmy player1_,BattleArmy player2_)
        {
            
            player1 = new BattleArmy(player1_);
            player2 = new BattleArmy(player2_);
        }
        private void whosTurn()
        {

        }
        public void Begin()
        {
            


        }
        
    }
}
