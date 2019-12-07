using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Reflection;
namespace HeroesGame
{
    public class Battle
    {
        //Assembly l = new Assembly();
        public int counter = 0;
        public int whichTern; //0 - player1 ; 1 - player2 
        public int round = 0;
        public List<BattleUnitStack> attem = new List<BattleUnitStack>(18);
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
            for (int i = 0; i < player[0].army.Count; i++)
            {
                player[0].army[i].army = 0;
                attem.Add(player[0].army[i]);
            }
            for (int i = 0; i < player[1].army.Count; i++)
            {
                player[1].army[i].army = 1;
                attem.Add(player[1].army[i]);
            }
        }

        public void colorise(BattleUnitStack u, TextBlock text)
        {
            if (u.canBeUse == true)
            {
                if (player[0].army.Contains(u))
                {
                    text.Foreground = Brushes.Green;

                }
                if (player[1].army.Contains(u))
                {
                    text.Foreground = Brushes.Blue;

                }
            }
            else
            {
                if (player[0].army.Contains(u))
                {
                    text.Foreground = Brushes.LightGreen;

                }
                if (player[1].army.Contains(u))
                {
                    text.Foreground = Brushes.LightBlue;

                }

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

            for (int i = 0; i < player[0].army.Count + player[1].army.Count; i++)
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
                attem.Remove(def);
            }
            else if (player[1].army.Contains(def))
            {
                player[1].army.Remove(def);
                attem.Remove(def);
            }
        }

        public string attack(BattleUnitStack att, BattleUnitStack def)
        {
            if (att.bus.Defence != att.bus.StandardDefence)
            {
                att.bus.Defence = att.bus.StandardDefence;

            }
            if (att.army != def.army)
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
                int totaldamage = rnd.Next((int)totald1, (int)totald2);
                int beat = def.bus.Hitpoints + (def.bus.StandardHitpoints * def.bus.qty);

                if (beat - totaldamage <= 0)
                {
                    Kill(def);
                    return "Killed";
                }

                if ((beat - totaldamage < def.bus.StandardHitpoints) && (beat - totaldamage > 0))
                {
                    def.bus.Hitpoints = beat - totaldamage;
                    def.bus.qty = 0;
                }             

                def.bus.qty = (beat - totaldamage) / def.bus.StandardHitpoints;
                def.bus.Hitpoints = (beat - totaldamage) % def.bus.StandardHitpoints;
              //  att.canBeUse = false;
                if (!(att.mod.Contains(new Modificators.No_Counter()))&&(counter == 0))
                 {
                    counter++;
                    var a = counterAttack(att,def);
                    if (a == "Was Failed by")
                    {
                        return "Was Failed by";

                    }
                    counter = 0;
                }
                
                return "Damaged";
            }
            return "Same Army";
        }
        public string counterAttack(BattleUnitStack att, BattleUnitStack def)
        {
            //атака в половину от стандартной
            def.bus.Attack /= 2;
            string a = attack(def, att);
            def.bus.Attack *= 2;
            if (a == "Killed")
            {
                return "Was Failed by";
            }
            
            return " ";
        }
        public bool endOfTheRound()
        {
            if (winCondition() != " ")
            {
                return true;

            }
            int flag = 0;
            foreach (var a in player[0].army)
            {
                if (a.canBeUse == false)
                {
                    flag++;
                    a.bus.Initiative = a.bus.StandardInitiative;
                }
            }
            foreach (var a in player[1].army)
            {
                if (a.canBeUse == false)
                {
                    flag++;
                    a.bus.Initiative = a.bus.StandardInitiative;
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
            u.bus.Defence *= (int)1.3;
            u.canBeUse = false;
        }
        public string defeat(BattleUnitStack u)
        {
            string str = " ";
            if (player[0].army.Contains(u))
            {
                str = "player 2 wins this battle";
            }
            if (player[1].army.Contains(u))
            {
                str = "player 1 wins this battle";
            }

            return str;

        }
        public void updateUnits()
        {
            foreach (var a in player[0].army)
            {
                a.canBeUse = true;
                
                foreach (var b in a.abl)
                {
                    if (b.cooldown > 0)
                        b.cooldown -= 1;
 
                }
            }
            foreach (var a in player[1].army)
            {
                a.canBeUse = true;

                foreach (var b in a.abl)
                {
                    if (b.cooldown > 0)
                        b.cooldown -= 1;

                }
            }
        }

        /*
        public string Magic(string f, BattleUnitStack b, BattleUnitStack def = null)
        {
            if (b.mdf.spells.all[f].coolDown == 0)
            {
                if (f == "Extra_Damage")
                {
                    b.mdf.spells.all["Extra_Damage"].terns = 3;
                    
                    b.bus.Damage.Item1 *= 2;
                    b.bus.Damage.Item2 *= 2;
                    b.mdf.spells.all["Extra_Damage"].coolDown = 6;
                    return b.bus.Type + " Increased his Damage for " + b.mdf.spells.all["Extra_Damage"].terns + " Rounds";
                }
                if (f == "Extra_Initiative")
                {
                    b.mdf.spells.all[f].terns = 2;
                    b.mdf.spells.all[f].coolDown = 4;
                    b.bus.Initiative *= (int)1.5;
                    return b.bus.Type + " Increased his Initiative for " + b.mdf.spells.all["Extra_Initiative"].terns + " Rounds";
                }
                if (f == "Extra_Defence")
                {
                    b.mdf.spells.all[f].terns = 2;
                    b.mdf.spells.all[f].coolDown = 4;
                    b.bus.Defence *= (int)1.5;
                    return b.bus.Type + " Increased his Defence for " + b.mdf.spells.all["Extra_Defence"].terns + " Rounds";
                }
                if (f == "Double_Attack")
                {                  
                    b.mdf.spells.all[f].coolDown = 5;
                    string defender = def.bus.Type;
                    string res = attack(b, def);
                    if ((res != "Killed") && (res != "Was Failed by"))
                    {
                        res = attack(b, def);
                        b.canBeUse = false;
                    }
                    return b.bus.Type + res  + defender + " Two times";
                    
                }
                if (f == "Fire_Ball")
                {
                    if (!def.mdf.mod.all["Fire_Imm"].canBeUsed)
                    {
                        int beat = def.bus.Hitpoints + def.bus.qty * def.bus.StandardHitpoints;
                        int power = b.bus.qty * 40;
                        if (beat - power > 0)
                        {
                            def.bus.qty = (beat - power) / def.bus.StandardHitpoints;
                            def.bus.Hitpoints = (beat - power) % def.bus.StandardHitpoints;
                            b.mdf.spells.all[f].coolDown = 8;
                        }
                        else
                        {
                            string defender = def.bus.Type;
                            Kill(def);
                            return b.bus.Type + " kills " + defender + " using " + f;
                        }
                        b.canBeUse = false;
                        return b.bus.Type + " use" + f + " to " + def.bus.Type;
                    }
                    else
                    {
                        b.mdf.spells.all[f].coolDown = 8;
                        b.canBeUse = false;
                        return def.bus.Type + " Have fire Immune " + ". 0 Damage was inflicted";
                    }
                }
                if (f == "Ice_Ball")
                {
                    
                    if (!def.mdf.mod.all["Ice_Imm"].canBeUsed)
                    {

                        int beat = def.bus.Hitpoints + def.bus.qty * def.bus.StandardHitpoints;
                        int power = b.bus.qty * 40;
                        if (beat - power > 0)
                        {
                            def.bus.qty = (beat - power) / def.bus.StandardHitpoints;
                            def.bus.Hitpoints = (beat - power) % def.bus.StandardHitpoints;
                            b.mdf.spells.all[f].coolDown = 8;
                        }
                        else
                        {
                            string defender = def.bus.Type;
                            Kill(def);
                            return b.bus.Type + " kills " + defender + " using " + f ;
                        }
                        b.canBeUse = false;
                        return b.bus.Type + " use" + f + " to " + def.bus.Type;
                    }
                    else
                    {
                        b.mdf.spells.all[f].coolDown = 8;
                        b.canBeUse = false;
                        return def.bus.Type + " Have Ice Immune " + ". 0 Damage was inflicted";
                    }
                   

                }

            }
            return "Not ready.Wait " + b.mdf.spells.all[f].coolDown + " rounds";
        }
        */
        public string winCondition()
        {
            if (player[0].army.Count == 0)
            {
                winner = "Player 2 ";
                return "Player 2 win";

            }

            if (player[1].army.Count == 0)
            {
                winner = "Player 1 ";
                return "Player 1 win";

            }
            return " ";
        }

        public void Game()
        {
            round++;
            queue();

        }
    }
}
