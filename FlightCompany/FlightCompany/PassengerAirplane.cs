using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FlightCompany
{
    [Serializable]
    public class PassengerAirplane : AirPlane, IPassengerPlane, IHasACargoBay, ISerializable
    {
        public int EconomyClassPassangerPlaces { get; set; }
        public int BusinessClassPassangerPlaces { get; set; }
        public int FirstClassPassangerPlaces { get; set; }
        public double CargoCapacity { get; set; }

        public PassengerAirplane()
        {

        }

        public int GetTotalPassengerPlaces()
        {
            return EconomyClassPassangerPlaces + BusinessClassPassangerPlaces + FirstClassPassangerPlaces;
        }

        void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EconomyClassPassangerPlaces", EconomyClassPassangerPlaces, typeof(int));
            info.AddValue("BusinessClassPassangerPlaces", BusinessClassPassangerPlaces, typeof(int));
            info.AddValue("FirstClassPassangerPlaces", FirstClassPassangerPlaces, typeof(int));
            info.AddValue("CargoCapacity", CargoCapacity, typeof(double));
        }

        public PassengerAirplane(SerializationInfo info, StreamingContext context)
        {
            EconomyClassPassangerPlaces = (int)info.GetValue("EconomyClassPassangerPlaces", typeof(int));
            BusinessClassPassangerPlaces = (int)info.GetValue("BusinessClassPassangerPlaces", typeof(int));
            FirstClassPassangerPlaces = (int)info.GetValue("FirstClassPassangerPlaces", typeof(int));
            CargoCapacity = (double)info.GetValue("CargoCapacity", typeof(double));
        }

    }
}
