﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame
{
    class BattleUnitStack
    {
        public int positionX;
        public int positionY;
        public bool useInStep = true;
        public struct BUnitstack
        {
            public (int, int) Damage;
            public string Type;
            public int Hitpoints;
            public int Maxhitpoints;
            public int Attack;
            public int Defence;
            public int Initiative;
            public int qty;

        }
        public BUnitstack bus;
        public BattleUnitStack(UnitStack b)
        {
            bus.qty = b.qty;
            bus.Damage = b._Unit_.Damage;
            bus.Type = b._Unit_.Type;
            bus.Hitpoints = b._Unit_.Hitpoints;
            bus.Attack = b._Unit_.Attack;
            bus.Defence = b._Unit_.Defence;
            bus.Initiative = b._Unit_.Initiative;
        }
        public void changeParametrs((int,int) damch,int hitpointsch,int attch,int defch,int inich)
        {
            this.bus.Damage.Item1 += damch.Item1;
            this.bus.Damage.Item2 += damch.Item2;
            this.bus.Hitpoints += hitpointsch;
            this.bus.Initiative += inich;
            this.bus.Attack += attch;
            this.bus.Defence += defch;
        }
        private void move()
        {
           
        }
        private void wait()
        {


        }
    }
}
