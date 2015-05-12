using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FlightCompany
{   
    [Serializable]
    public abstract class AirPlane : IPlane, ISerializable 
    {
        public string Manufacturrer { get; set; }
        public string Model { get; set; }
        public int FlightRange { get; set; }
        public int CruisingSpeed { get; set; }
        public double FuelConsumption { get; set; }
        public int CrewCount { get; set; }

        public AirPlane()
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Manufacturrer", Manufacturrer, typeof(string));
            info.AddValue("Model", Model, typeof(string));
            info.AddValue("FlightRange", FlightRange, typeof(int));
            info.AddValue("CruisingSpeed", CruisingSpeed, typeof(int));
            info.AddValue("FuelConsumption", FuelConsumption, typeof(double));
            info.AddValue("CrewCount", CrewCount, typeof(int));
        }

        public AirPlane(SerializationInfo info, StreamingContext context)
        {
            Manufacturrer = (string)info.GetValue("Manufacturrer", typeof(string));
            Model = (string)info.GetValue("Model", typeof(string));
            FlightRange = (int)info.GetValue("FlightRange", typeof(int));
            CruisingSpeed = (int)info.GetValue("CruisingSpeed", typeof(int));
            FuelConsumption = (double)info.GetValue("FuelConsumption", typeof(double));
            CrewCount = (int)info.GetValue("CrewCount", typeof(int));
        }
    }
}
