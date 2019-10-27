using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame
{
    
    class Unit
    {
        public (int, int) Damage { get; }
        public string Type { get; }
        public int Hitpoints { get; }
        public int Attack { get; }
        public int Defence { get; }
        public int Initiative { get; }

        public Unit(string typ,int hit,int att,int def,(int,int) dam,int Ini)
        {
            
            Type = typ;
            Hitpoints = hit;
            Attack = att;
            Defence = def;
            Initiative = Ini;
            
        }
    }
}
