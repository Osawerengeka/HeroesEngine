using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes
{
    class Army
    {
        
       private UnitStack spot1;
       private UnitStack spot2;
       private UnitStack spot3;
       private UnitStack spot4;
       private UnitStack spot5;
       private UnitStack spot6;
        public Army(UnitStack spot1_, UnitStack spot2_, UnitStack spot3_, UnitStack spot4_, UnitStack spot5_, UnitStack spot6_)
        {
            spot1 = spot1_;
            spot2 = spot2_;
            spot3 = spot3_;
            spot4 = spot4_;
            spot5 = spot5_;
            spot6 = spot6_;
        }
        public UnitStack GetArmy(int spot)
        {
            UnitStack n = new UnitStack(null,0);
            if ((spot <= 6) && (spot > 0))
            {
                switch (spot)
                {
                    case 1:
                        return spot1;
                    case 2:
                        return spot2;
                    case 3:
                        return spot3;
                    case 4:
                        return spot4;
                    case 5:
                        return spot5;
                    case 6:
                        return spot6;
                }
            }
            return n;
        }
    }
}
