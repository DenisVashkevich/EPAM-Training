using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public class Relay:Part,IHasACoil
    {
        public int NumNOcont { get; set; }
        public int NumNCcont { get; set; }
        public double CoilVoltage { get; set; }
    }
}
