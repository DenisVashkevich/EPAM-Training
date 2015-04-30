using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public interface IElectronic:IPart
    {
        double PowerVoltage { get; }
        int NumDigitalOuts { get; }
        int NumAnalogOuts { get; }
        int TotalOutputs { get; }
    }
}
