using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightCompany
{
    [Serializable]
    public class PassengerAirplane : AirPlane, IPassengerPlane, IHasACargoBay
    {
        public int EconomyClassPassangerPlaces { get; set; }
        public int BusinessClassPassangerPlaces { get; set; }
        public int FirstClassPassangerPlaces { get; set; }
        public double CargoCapacity { get; set; }

        public int GetTotalPassengerPlaces()
        {
            return EconomyClassPassangerPlaces + BusinessClassPassangerPlaces + FirstClassPassangerPlaces;
        }
    }
}
