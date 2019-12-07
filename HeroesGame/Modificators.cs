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


namespace HeroesGame
{
    public interface Ispell
    {
       void Doing(BattleUnitStack UsedUnit , BattleUnitStack OpposeUnit = null,Battle battle = null);
       string Name { get; set; }
        bool solo { get; set; }
        int cooldown { get; set; }
        int duration { get; set; }

    }
    public interface Imod
    {
        //void doing(BattleUnitStack UsedUnit, BattleUnitStack OpposeUnit = null);
        string Name { get; set; }
        int Term { get; set; }

    }



    public class Mod
    {
       // public string type;
        public bool canBeUsed;
        public int terns;
        public int coolDown = 0;
        public Mod(string t,bool b,int te)
        {
            this.canBeUsed = b;
           // this.type = t;
            this.terns = te;
        }
    }

    /*
    public class AllModificators
    {

        public const int HOW_MANY_MODIFICATORS = 3;

        public Mod item;

        public Dictionary<string, Mod> all = new Dictionary<string, Mod>();

        public AllModificators()
        {
                item = new Mod("Fire_Imm",false,0);
                all.Add("Fire_Imm", item);
                item = new Mod("Ice_Imm", false,0);
                all.Add("Ice_Imm", item);
                item = new Mod("NO_Counter",false,0);
                all.Add("No_Counter", item);
          
        }

    }
    public class AllSpells
    {
        public const int HOW_MANY_SPELLS = 6;

        Mod item;

        public Dictionary<string, Mod> all = new Dictionary<string, Mod>();
        public AllSpells()
        {         
            item = new Mod("Extra_Range",false,0);
            all.Add("Extra_Range", item);
            item = new Mod("Extra_Damage", false, 0);
            all.Add("Extra_Damage", item);
            item = new Mod("Extra_Defence", false, 0);
            all.Add("Extra_Defence", item);
            item = new Mod("Extra_Initiative", false, 0);
            all.Add("Extra_Initiative", item);
            item = new Mod("Fire_Ball", false, 0);
            all.Add("Fire_Ball", item);
            item = new Mod("Double_Attack", false, 0);
            all.Add("Double_Attack", item);
            item = new Mod("Ice_Ball", false, 0);
            all.Add("Ice_Ball", item);
        }
     


    }

    public class Posibilities
    {
        
        

        public AllModificators mod = new AllModificators();
        public AllSpells spells = new AllSpells();
      
        public Posibilities(string type)
        {
            whichUnit(type,mod);
        }

        public List<string> Texttip()
        {
            List<string> result = new List<string>();

            foreach (var a in mod.all)
            {
                if (a.Value.canBeUsed == true)
                {
                    string s = a.Key;
                    result.Add(s);
                }
            }

            return result;
        }

        private void whichUnit(string type,AllModificators mod)
        { 
            if (type == "ANGEL")
            {
               Mod a = mod.all["Fire_Imm"];
               a.canBeUsed = true;
                a.terns = 0;
                a = this.mod.all["No_Counter"];
                a.canBeUsed = true;
                a.terns = 0;
            }
            if (type == "LICH")
            {
                Mod a = mod.all["Ice_Imm"];
                a.canBeUsed = true;
                a.terns = 0;

                a = spells.all["Extra_Defence"];
                a.canBeUsed = true;
                a.terns = -1;

                a = spells.all["Ice_Ball"];
                a.canBeUsed = true;
                a.terns = -1;
            }
            if (type == "DEMON")
            {
                Mod a = mod.all["Fire_Imm"];
                a.canBeUsed = true;
                a.terns = 0;

                a = spells.all["Extra_Damage"];
                a.canBeUsed = true;
                a.terns = -1;
                a = spells.all["Fire_Ball"];
                a.canBeUsed = true;
                a.terns = -1;
            }
            if (type == "RANGER")
            {
                Mod a = spells.all["Extra_Damage"];
                a.canBeUsed = true;
                a.terns = -1;
               
            }
            if (type == "WARRIOR")
            {
                Mod a = spells.all["Double_Attack"];
                a.canBeUsed = true;
                a.terns = -1;
                
            }
            if (type == "SCELETON")
            {
                Mod a = mod.all["Fire_Imm"];
                a.canBeUsed = true;
                a.terns = 0;
                a = mod.all["Ice_Imm"];
                a.canBeUsed = true;
                a.terns = 0;
                a = spells.all["Double_Attack"];
                a.canBeUsed = true;
                a.terns = -1;
            }

        }
        */
    }
