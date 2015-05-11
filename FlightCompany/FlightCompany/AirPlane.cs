using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightCompany
{   
    [Serializable]
    public class AirPlane:IPlane
    {
        public string Manufacturrer { get; set; }
        public string Model { get; set; }
        public int FlightRange { get; set; }
        public int CruisingSpeed { get; set; }
        public double FuelConsumption { get; set; }
        public int CrewCount { get; set; }
    }
}
