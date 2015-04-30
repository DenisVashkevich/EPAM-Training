using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public class Relay:Part,IHasACoil
    {
        int NumNOcont { get; set; }
        int NumNCcont { get; set; }
        int TotalContacts { get; }

        public double CoilVoltage
        {
            get { throw new NotImplementedException(); }
        }
    }
}
