using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public class Cylinder:Part,IPneumatic
    {
        public double RodLength { get; set; }
        public double OperatingPressure { get; set; }
        public int ConnectionDiameter { get; set; }
    }
}
