using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes
{
    class UnitStack
    {
        Unit _Unit_;
        int qty;
       public UnitStack(Unit U, int qty_)
        {
            _Unit_ = U;
            qty = qty_;
        }

    }
}
