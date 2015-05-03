using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public abstract class Part:IPart
    {
        private int _stock;
        public uint PartNumber{ get; set; }
        public string Name { get; set; }
        public string Description { get;  set; }
        public int Stock { get { return _stock; } }
        public DateTime StockModifiedDate { get; set; }

        public void StockAdd(int count)
        {
            _stock += count;
            StockModifiedDate = DateTime.Today;
        }

        public void StockRemove(int count)
        {
            if ((_stock - count) < 0) throw new OutOfStockException();
            else { _stock -= count; StockModifiedDate = DateTime.Today; }
        }

    }
}
