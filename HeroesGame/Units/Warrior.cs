﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame
{
    class Warrior : Unit
    {
       
        public Warrior() : base("WARRIOR", 16, 5,3,(5,7),16)
        {
            abl.Add(new Abilities.Double_Attack());

        }
    }
}
