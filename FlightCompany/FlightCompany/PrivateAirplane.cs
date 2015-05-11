using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightCompany
{
    [Serializable]
    public class PrivateAirplane : AirPlane, IPassengerPlane
    {
        public int PassengerPlaces { get; set; }

        public int GetTotalPassengerPlaces()
        {
            return PassengerPlaces;
        }
    }
}
