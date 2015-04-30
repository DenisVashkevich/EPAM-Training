using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public interface IPneumatic:IPart
    {
        double OperatingPressure { get; }
        int ConnectionDiameter { get; }
    }
}
