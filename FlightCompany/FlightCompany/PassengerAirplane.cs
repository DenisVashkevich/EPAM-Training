using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightCompany
{
    public class PassengerAirplane : AirPlane, IPassengerPlane, IHasACargoBay
    {
        public double CargoCapacity
        {
            get { throw new NotImplementedException(); }
        }

        public int GetTotalPassengerPlacec()
        {
            throw new NotImplementedException();
        }
    }
}
