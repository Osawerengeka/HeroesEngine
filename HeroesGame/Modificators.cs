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

        string typeofmagic { get; set; } // buff debuff invoke

    }
    public interface Imod
    {
        //void doing(BattleUnitStack UsedUnit, BattleUnitStack OpposeUnit = null);
        string Name { get; set; }
        int Term { get; set; }

    }

    }
