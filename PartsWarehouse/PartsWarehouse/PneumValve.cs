using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public class PneumValve:Part,IPneumatic
    {
        public double OperatingPressure { get; set; }
        public int ConnectionDiameter { get ; set; }
    }
}
