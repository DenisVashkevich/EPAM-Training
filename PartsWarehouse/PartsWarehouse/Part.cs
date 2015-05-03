using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public abstract class Part:IPart
    {
        private int _stock;
        private DateTime _stockModDate;
        public uint PartNumber{ get; set; }
        public string Name { get; set; }
        public string Description { get;  set; }
        public int Stock { get { return _stock; } }
        public DateTime StockModifiedDate { get { return _stockModDate; } }

        public void StockAdd(int count)
        {
            _stock += count;
            _stockModDate = DateTime.Today;
        }

        public void StockRemove(int count)
        {
            if ((_stock - count) < 0) throw new OutOfStockException();
            else { _stock -= count; _stockModDate = DateTime.Today; }
        }

    }
}
