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
        private double _cargocapacity;

        public double CargoCapacity 
        {
            get { return this._cargocapacity; }
            set { this._cargocapacity = value; }
        }

        public CargoAirplane()
        {

        }
    
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CargoCapacity", _cargocapacity, typeof(double));
        }

        public CargoAirplane(SerializationInfo info, StreamingContext context)
        {
            _cargocapacity = (double)info.GetValue("CargoCapacity", typeof(double));
        }
    
    }
}
