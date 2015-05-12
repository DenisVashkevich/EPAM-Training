using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightCompany
{
    public interface IPlane
    {
        string Manufacturrer { get; }
        string Model { get; }
        int FlightRange { get; }
        int CruisingSpeed { get; }
        double FuelConsumption { get; }
        int CrewCount { get; }
    }
}
