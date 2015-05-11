using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightCompany
{
    [Serializable]
    public class CargoAirplane : AirPlane, IHasACargoBay
    {
        public double CargoCapacity { get; set; }
    }
}
