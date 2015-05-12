using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FlightCompany
{
    [Serializable]
    public class PrivateAirplane : AirPlane, IPassengerPlane, ISerializable
    {
        public int PassengerPlaces { get; set; }

        public PrivateAirplane()
        {

        }

        public int GetTotalPassengerPlaces()
        {
            return PassengerPlaces;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PassengerPlaces", PassengerPlaces, typeof(int));
        }

        public PrivateAirplane(SerializationInfo info, StreamingContext context)
        {
            PassengerPlaces = (int)info.GetValue("PassengerPlaces", typeof(int));
        }

    }
}
