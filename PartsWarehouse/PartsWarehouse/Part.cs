using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public abstract class Part:IPart
    {
        public string PartNumber{ get; set; }
        public string Name { get; set; }
        public string Description { get;  set; }
        public int Stock { get; }
    }
}
