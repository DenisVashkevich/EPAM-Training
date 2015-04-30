using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public class Sensor:Part,IElectronic
    {
        public double PowerVoltage { get; set; }
        public int NumDigitalOuts { get; set; }
        public int NumAnalogOuts { get; set; }
        public int TotalOutputs { get { return NumAnalogOuts + NumAnalogOuts; } }
    }
}
