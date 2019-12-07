﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Abilities
{
    class Double_Attack : Ispell
    {
        public int duration { get; set; }
        public string Name { get; set; }
        public bool solo { get; set; }
        public int cooldown { get; set; }
        public Double_Attack()
        {
            Name = "Double Attack";
            solo = false;

        }
        public void Doing(BattleUnitStack UsedUnit, BattleUnitStack OpposeUnit = null, Battle battle = null)
        {
            cooldown = 5;
            string res =battle.attack(UsedUnit, OpposeUnit);
            if ((res != "Killed") && (res != "Was Failed by"))
            {
                res = battle.attack(UsedUnit, OpposeUnit);              
            }
        }
    }
}
