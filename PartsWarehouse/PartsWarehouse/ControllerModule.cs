using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public class ControllerModule:Part,IElectronic
    {
        public ControllerModules ModuleType { get; set; }
        public double PowerVoltage { get; set; }
        public int NumDigitalOuts { get; set; }
        public int NumAnalogOuts { get; set; }
        public int TotalOutputs { get { return NumAnalogOuts + NumDigitalOuts; } }
    }
}
