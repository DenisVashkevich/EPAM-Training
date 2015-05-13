﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FlightCompany
{
    [Serializable]
    public class PassengerAirplane : AirPlane, IPassengerPlane, IHasACargoBay, ISerializable
    {
        private int _economyclasspassangerplaces;
        private int _businessclasspassangerplaces;
        private int _firstclasspassangerplaces;
        private double _cargocapacity;

        public int EconomyClassPassangerPlaces 
        {
            get { return this._economyclasspassangerplaces; }
            set { this._economyclasspassangerplaces = value; }
        }

        public int BusinessClassPassangerPlaces 
        {
            get { return this._businessclasspassangerplaces; }
            set { this._businessclasspassangerplaces = value; } 
        }

        public int FirstClassPassangerPlaces 
        {
            get { return this._firstclasspassangerplaces; }
            set { this._firstclasspassangerplaces = value; }
        }

        public double CargoCapacity 
        {
            get { return this._cargocapacity; }
            set { this._cargocapacity = value; }
        }

        public PassengerAirplane()
        {

        }

        public int GetTotalPassengerPlaces()
        {
            return _economyclasspassangerplaces + _businessclasspassangerplaces + _firstclasspassangerplaces;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EconomyClassPassangerPlaces", _economyclasspassangerplaces, typeof(int));
            info.AddValue("BusinessClassPassangerPlaces", _businessclasspassangerplaces, typeof(int));
            info.AddValue("FirstClassPassangerPlaces", _firstclasspassangerplaces, typeof(int));
            info.AddValue("CargoCapacity", _cargocapacity, typeof(double));
        }

        public PassengerAirplane(SerializationInfo info, StreamingContext context)
        {
            _economyclasspassangerplaces = (int)info.GetValue("EconomyClassPassangerPlaces", typeof(int));
            _businessclasspassangerplaces = (int)info.GetValue("BusinessClassPassangerPlaces", typeof(int));
            _firstclasspassangerplaces = (int)info.GetValue("FirstClassPassangerPlaces", typeof(int));
            _cargocapacity = (double)info.GetValue("CargoCapacity", typeof(double));
        }

    }
}
