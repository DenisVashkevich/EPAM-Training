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
        private string _manufacturrer;
        private string _model;
        private int _flightrange;
        private int _cruisingspeed;
        private double _fuelconsumption;
        private int _crewcount;

        public string Manufacturrer
        {
            get { return this._manufacturrer; }
            set { this._manufacturrer = value; }
        }

        public string Model 
        {
            get { return this._model; }
            set { this._model = value; } 
        }

        public int FlightRange 
        {
            get { return this._flightrange; }
            set { this._flightrange = value; } 
        }

        public int CruisingSpeed 
        {
            get { return this._cruisingspeed; }
            set { this._cruisingspeed = value; }
        }

        public double FuelConsumption 
        {
            get { return this._fuelconsumption; }
            set { this._fuelconsumption = value; }
        }

        public int CrewCount 
        {
            get { return this._crewcount; }
            set { this._crewcount = value; }
        }

        public AirPlane()
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Manufacturrer", this._manufacturrer, typeof(string));
            info.AddValue("Model", this._model, typeof(string));
            info.AddValue("FlightRange", this._flightrange, typeof(int));
            info.AddValue("CruisingSpeed", this._cruisingspeed, typeof(int));
            info.AddValue("FuelConsumption", this._fuelconsumption, typeof(double));
            info.AddValue("CrewCount", this._crewcount, typeof(int));
        }

        public AirPlane(SerializationInfo info, StreamingContext context)
        {
            this._manufacturrer = (string)info.GetValue("Manufacturrer", typeof(string));
            this._model = (string)info.GetValue("Model", typeof(string));
            this._flightrange = (int)info.GetValue("FlightRange", typeof(int));
            this._cruisingspeed = (int)info.GetValue("CruisingSpeed", typeof(int));
            this._fuelconsumption = (double)info.GetValue("FuelConsumption", typeof(double));
            this._crewcount = (int)info.GetValue("CrewCount", typeof(int));
        }
    }
}
