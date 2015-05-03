using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public class PartsCompareByStockModified:IComparer<Part>
    {
        public int Compare(Part x, Part y)
        {
            if (x != null && y != null)
            {
                if (x.StockModifiedDate > y.StockModifiedDate)
                {
                    return 1;
                }
                else
                {
                    return (x.StockModifiedDate == y.StockModifiedDate) ? 0 : -1;
                }
            }
            else
            {
                return (y == null && x == null) ? 0 : (x != null) ? 1 : -1;
            }
        }
    }
}
