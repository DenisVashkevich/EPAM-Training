using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightCompany
{
    public interface IPassengerPlane
    {
        //public int EconomyClassPassangerPlaces { get; }
        //public int BusinessClassPassangerPlaces { get; }
        //public int FirstClassPassangerPlaces { get; }

        public int GetTotalPassengerPlacec();

    }
}
