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
        private int _passengerplaces;

        public int PassengerPlaces 
        {
            get { return this._passengerplaces; }
            set { this._passengerplaces = value; }
        }

        public PrivateAirplane()
        {

        }

        public int GetTotalPassengerPlaces()
        {
            return PassengerPlaces;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("PassengerPlaces", _passengerplaces, typeof(int));
        }

        public PrivateAirplane(SerializationInfo info, StreamingContext context) : base (info,context)
        {
            _passengerplaces = (int)info.GetValue("PassengerPlaces", typeof(int));
        }

    }
}
