using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public class PartsCompareByStock:IComparer<Part>
    {
        public int Compare(Part x, Part y)
        {
            if (x != null && y != null)
            {
                if (x.Stock > y.Stock)
                {
                    return 1;
                }
                else
                {
                    return (x.Stock == y.Stock) ? 0 : -1;
                }
            }
            else
            {
                return (y == null && x == null) ? 0 : (x != null) ? 1 : -1;
            }
        }
    }
}
