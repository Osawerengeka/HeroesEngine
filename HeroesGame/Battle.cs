using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame
{
    class Battle
    {
        public int whichTern = 0; //0 - player1 ; 1 - player2 
        public int round = 0;
        public List<int>[] attem = new List<int>[2]; // 0 - player 1 ; 1 - player 2 
        public BattleArmy player1;
        public BattleArmy player2;
        public string winner = "";
        public Battle(BattleArmy player1_, BattleArmy player2_)
        {

            player1 = new BattleArmy(player1_);
            player2 = new BattleArmy(player2_);
            attem[0] = new List<int>(new int[9]);
                   
            attem[1] = new List<int>(new int[9]);
            ini();

        }
        private void ini()
        {
            for (int i = 0;i < 9;i++)
            {
                attem[0][i] = -1;
                attem[1][i] = -1;
            }
        }            

        public int whowillgo()
        {
            foreach (int a in attem[whichTern])
            {
                if ((a != -1 )&&(player1.army[a].useInStep == true))
                {                   
                    return a;
                }
            }
            return -1;
        }

        public void queue()
        {
            
            for (int i=0; i < player1.army.Count; i++)
            {
                attem[0][8] = i;
                for (int j = 7; j >= 0; j--)
                {
                    if (attem[0][j] == -1)
                    {
                        int buff = attem[0][j];
                        attem[0][j] = i;
                        attem[0][j + 1] = buff;

                    }
                    else if (player1.army[i].bus.Initiative > player1.army[attem[0][j]].bus.Initiative)
                    {
                        int buff = attem[0][j];
                        attem[0][j] = i;
                        attem[0][j+1] = buff;
                    }
                }
            }
            for (int i = 0; i < player2.army.Count; i++)
            {
                attem[1][8] = i;
                for (int j = 7; j >= 0; j--)
                {
                    if (attem[1][j] == -1)
                    {
                        int buff = attem[1][j];
                        attem[1][j] = i;
                        attem[1][j + 1] = buff;

                    }
                    else if (player1.army[i].bus.Initiative > player1.army[attem[1][j]].bus.Initiative)
                    {
                        int buff = attem[1][j];
                        attem[1][j] = i;
                        attem[1][j + 1] = buff;
                    }
                }
            }
        }

        public void Kill(BattleUnitStack def)
        {
            if (player1.army.Contains(def))
            {
                player1.army.Remove(def);
            }
            else
                player2.army.Remove(def);
        }

        public string attack(BattleUnitStack att, BattleUnitStack def)
        {
            double totald1;
            double totald2;
            Random rnd = new Random();
            if (att.bus.Attack > def.bus.Defence)
            {             
                totald1 = att.bus.qty * att.bus.Damage.Item1 * (1 + 0.05 * (att.bus.Damage.Item1 - def.bus.Defence));
                totald2 = att.bus.qty * att.bus.Damage.Item2 * (1 + 0.05 * (att.bus.Damage.Item2 - def.bus.Defence));
            }
            else
            {
                totald1 = att.bus.qty * att.bus.Damage.Item1 * (1 + 0.05 * (def.bus.Defence - att.bus.Damage.Item1));
                totald2 = att.bus.qty * att.bus.Damage.Item2 * (1 + 0.05 * (def.bus.Defence - att.bus.Damage.Item2));
            }
            int totaldamage = rnd.Next((int)totald1,(int)totald2);
            int beat = def.bus.Hitpoints * def.bus.qty;
            def.bus.qty = (beat - totaldamage)/def.bus.Hitpoints;
            if (def.bus.qty <= 0)
            {
                Kill(def);
                return "Killed";
            }
            return "Alive";
        }
        public void endOfTheRound()
        {



        }
        public void wait()
        {


        }
        public void Begin()
        {
            


        }
        public void Game()
        {
            round++;
            queue();

            int term = 1; // 1 - player1 2 - player2


        }
    }
}
