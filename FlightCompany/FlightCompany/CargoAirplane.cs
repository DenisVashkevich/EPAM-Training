using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FlightCompany
{
    [Serializable]
    public class CargoAirplane : AirPlane, IHasACargoBay, ISerializable
    {
        public double CargoCapacity { get; set; }

        public CargoAirplane()
        {

        }
    
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CargoCapacity", CargoCapacity, typeof(double));
        }

        public CargoAirplane(SerializationInfo info, StreamingContext context)
        {
            CargoCapacity = (double)info.GetValue("CargoCapacity", typeof(double));
        }
    
}
}
