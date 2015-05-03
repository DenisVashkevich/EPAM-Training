using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public class OutOfStockException:Exception
    {
        public OutOfStockException()
            : base("Out of stock!")
        {

        }

    }
}
