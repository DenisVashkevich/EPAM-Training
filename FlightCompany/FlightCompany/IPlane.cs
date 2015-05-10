using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightCompany
{
    public interface IPlane
    {
        public string Manufacturrer { get; }
        public string Model { get; }
        public int FlightRange { get; }
        public int CruisingSpeed { get; }
        public int FuelConsumption { get; }
        public int CrewCount { get; }
    }
}
