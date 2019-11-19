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
        public List<BattleUnitStack> attem = new List<BattleUnitStack>(18);
      //  public List<int>[] attem = new List<int>[2]; // 0 - player 1 ; 1 - player 2       
        public BattleArmy[] player = new BattleArmy[2]; 
        public string winner = "";
        public Battle(BattleArmy player1_, BattleArmy player2_)
        {
            whichTern = 0;
            player[0] = new BattleArmy(player1_);
            player[1] = new BattleArmy(player2_);
            ini();
        }


        private void ini()
        {
            for (int i = 0; i < player[0].army.Count;i++)
            {
                attem.Add(player[0].army[i]);
            }
            for (int i = 0; i < player[1].army.Count; i++)
            {
                attem.Add(player[1].army[i]);
            }




        }



        public BattleUnitStack whowillgo()
        {
            for (int i = 0; i < attem.Count; i++)
                if (attem[i].canBeUse == true)
                {
                    return attem[i];
                }
            return null;
        }
        
        public void queue()
        {
            
            for (int i= 0; i < player[0].army.Count + player[1].army.Count; i++)
            {                 
                for (int j = 0; j < player[0].army.Count + player[1].army.Count; j++)
                {
                    if (attem[i].bus.Initiative > attem[j].bus.Initiative)
                    {
                        BattleUnitStack tmp = attem[j];
                        attem[j] = attem[i];
                        attem[i] = tmp;
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
                if (a.canBeUse == false)
                {
                    flag++;
                }
            }
            foreach (var a in player[1].army)
            {
                if (a.canBeUse == false)
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
            u.bus.Initiative = -u.bus.Initiative;
            queue();
        }
        public void defend(BattleUnitStack u)
        {
            u.bus.Defence *=(int)1.3;
            u.canBeUse = false;
        }
        public void updateUnits()
        {
            foreach (var a in player[0].army)
            {
                a.canBeUse = true;
            }
            foreach (var a in player[1].army)
            {
                a.canBeUse = true;
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
