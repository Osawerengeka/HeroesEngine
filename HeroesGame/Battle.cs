using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame
{
    class Battle
    {
        public int whichTern; //0 - player1 ; 1 - player2 
        public int round = 0;
        public List<int>[] attem = new List<int>[2]; // 0 - player 1 ; 1 - player 2       
        public BattleArmy[] player = new BattleArmy[2]; 
        public string winner = "";
        public Battle(BattleArmy player1_, BattleArmy player2_)
        {
            whichTern = 0;
            player[0] = new BattleArmy(player1_);
            player[1] = new BattleArmy(player2_);
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

        private void whicht()
        {
            int flag = 0;
            foreach (int a in attem[whichTern])
            {
                if ((a != -1) && (player[whichTern].army[a].useInStep == true))
                {
                    flag++;
                }
            }
            whichTern = (flag == 0) ? 1 : 0;
        }
        public int whowillgo()
        {
            whicht();
            foreach (int a in attem[whichTern])
            {
                if ((a != -1 )&&(player[whichTern].army[a].useInStep == true))
                {                   
                    return a;
                }
            }
          
            return -1;
        }

        public void queue()
        {
            
            for (int i=0; i < player[0].army.Count; i++)
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
                    else if (player[0].army[i].bus.Initiative > player[0].army[attem[0][j]].bus.Initiative)
                    {
                        int buff = attem[0][j];
                        attem[0][j] = i;
                        attem[0][j+1] = buff;
                    }
                }
            
            }
            for (int i = 0; i < player[1].army.Count; i++)
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
                    else if (player[1].army[i].bus.Initiative > player[1].army[attem[1][j]].bus.Initiative)
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
            if (player[0].army.Contains(def))
            {
                player[0].army.Remove(def);
            }
            else
                player[1].army.Remove(def);
        }

        public string attack(BattleUnitStack att, BattleUnitStack def)
        {
            double totald1;
            double totald2;
            Random rnd = new Random();
            if (att.bus.Attack > def.bus.Defence)
            {             
                totald1 = att.bus.qty * att.bus.Damage.Item1 * (1 + 0.05 * (att.bus.Attack - def.bus.Defence));
                totald2 = att.bus.qty * att.bus.Damage.Item2 * (1 + 0.05 * (att.bus.Attack - def.bus.Defence));
            }
            else
            {
                totald1 = att.bus.qty * att.bus.Damage.Item1 / (1 + 0.05 * (def.bus.Defence - att.bus.Attack));
                totald2 = att.bus.qty * att.bus.Damage.Item2 / (1 + 0.05 * (def.bus.Defence - att.bus.Attack));
            }
            int totaldamage = rnd.Next((int)totald1,(int)totald2);
            int beat = def.bus.Hitpoints + (def.bus.StandardHitpoints * def.bus.qty);
           

            if ((beat - totaldamage < def.bus.StandardHitpoints) &&(beat - totaldamage !=0))
            {
                def.bus.Hitpoints = beat - totaldamage;
                def.bus.qty = 0;
            }

            if (beat - totaldamage <= 0)
            {
                Kill(def);
                return "Killed";
            }

            def.bus.qty = (beat - totaldamage) / def.bus.StandardHitpoints;
            def.bus.Hitpoints = (beat - totaldamage) % def.bus.StandardHitpoints;
            return "Damaged";
        }
        public bool endOfTheRound()
        {
            int flag = 0;
            foreach(var a in player[0].army)
            {
                if (a.useInStep == false)
                {
                    flag++;
                }
            }
            foreach (var a in player[1].army)
            {
                if (a.useInStep == false)
                {
                    flag++;
                }
            }
            if (flag == (player[0].army.Count + player[1].army.Count))
            {
                return true;
            }
            else
                return false;
        }
        public void wait(BattleUnitStack u)
        {
            u.bus.Initiative = 0;
            queue();
        }
        public void defend(BattleUnitStack u)
        {
            u.bus.Defence *=(int)1.3;

        }
        public void updateUnits()
        {
            foreach (var a in player[0].army)
            {
                a.useInStep = true;
            }
            foreach (var a in player[1].army)
            {
                a.useInStep = true;
            }
        }

        public string winCondition()
        {
            if (player[0].army.Count == 0)
            {
                return "Player 2 win";

            }

            if (player[1].army.Count == 0)
            {
                return "Player 1 win";

            }
            return " ";
        }

        public void Game()
        {
            round++;
            queue();

            int term = 1; // 1 - player1 2 - player2


        }
    }
}
