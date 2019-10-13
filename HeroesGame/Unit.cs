using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes
{
    
    class Unit
    {
        protected (int, int) Damage;
        private string Type;
        private int Hitpoints;
        private int Attack;
        private int Defence;
        private int Initiative;
        
        public Unit(string typ,int hit,int att,int def,int Ini)
        {
            
            Type = typ;
            Hitpoints = hit;
            Attack = att;
            Defence = def;
            Initiative = Ini;
            
        }
    }
}
