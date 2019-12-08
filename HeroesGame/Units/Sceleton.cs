﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesGame.Abilities;

namespace HeroesGame.Units
{
    public class Sceleton : Unit
    {

        public Sceleton() : base("SCELETON",5,1,2,(1,1),10)
        {
            mod.Add(new Modificators.Ice_Imm());
            mod.Add(new Modificators.Fire_Imm());
        }
    }
}
