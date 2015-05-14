using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FlightCompany
{
    public class AirCompany : ICollection<IPlane>
    {
        private List<IPlane> AirPlanes = new List<IPlane>();

        #region ICollection<IPlane>
        public void Add(IPlane item)
        {
            AirPlanes.Add(item);
        }

        public void Clear()
        {
            AirPlanes.Clear();
        }

        public bool Contains(IPlane item)
        {
            return AirPlanes.Contains(item);
        }

        public void CopyTo(IPlane[] array, int arrayIndex)
        {
            AirPlanes.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return AirPlanes.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(IPlane item)
        {
            return AirPlanes.Remove(item);
        }

        public IEnumerator<IPlane> GetEnumerator()
        {
            return AirPlanes.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion


        public void SaveToFile()
        {
            var PassengerPlanes = from p in AirPlanes where p is PassengerAirplane select p;
            var CargoPlanes = from p in AirPlanes where p is CargoAirplane select p;
            var PrivatePlanes = from p in AirPlanes where p is PrivateAirplane select p;

            List<PassengerAirplane> pasPlanToSer = new List<PassengerAirplane>();
            List<CargoAirplane> carPlanToSer = new List<CargoAirplane>();
            List<PrivateAirplane> privPlanToSer = new List<PrivateAirplane>();

            foreach (PassengerAirplane p in PassengerPlanes)
            {
                pasPlanToSer.Add(p);
            }

            foreach (CargoAirplane p in CargoPlanes)
            {
                carPlanToSer.Add(p);
            }

            foreach (PrivateAirplane p in PrivatePlanes)
            {
                privPlanToSer.Add(p);
            }

            IFormatter formatter = new BinaryFormatter();

            FileStream fs = new FileStream("PassengerPlanes.bin", FileMode.OpenOrCreate);
            formatter.Serialize(fs, pasPlanToSer);
            fs.Close();

            fs = new FileStream("CargoPlanes.bin", FileMode.OpenOrCreate);
            formatter.Serialize(fs, carPlanToSer);
            fs.Close();

            fs = new FileStream("PrivatePlanes.bin", FileMode.OpenOrCreate);
            formatter.Serialize(fs, privPlanToSer);
            fs.Close();

        }

        public void LoadFromfile() 
        {
            IFormatter formatter = new BinaryFormatter();

            FileStream fs = new FileStream("PassengerPlanes.bin", FileMode.Open);
            List<PassengerAirplane> PassengerPlanes = (List<PassengerAirplane>)formatter.Deserialize(fs);
            fs.Close();

            fs = new FileStream("CargoPlanes.bin", FileMode.Open);
            List<CargoAirplane> CargoPlanes = (List<CargoAirplane>)formatter.Deserialize(fs);
            fs.Close();

            fs = new FileStream("PrivatePlanes.bin", FileMode.Open);
            List<PrivateAirplane> PrivatePlanes = (List<PrivateAirplane>)formatter.Deserialize(fs);
            fs.Close();

            //Console.Clear();
            //foreach (var p in PassengerPlanes)
            //{
            //    Console.WriteLine("{0} {1}  Flight Range: {2}  Fuel Consumption: {3}", p.Manufacturrer, p.Model, p.FlightRange, p.FuelConsumption);
            //}
            //Console.ReadLine();

            AirPlanes.Clear();
            AirPlanes.AddRange(PassengerPlanes);
            AirPlanes.AddRange(CargoPlanes);
            AirPlanes.AddRange(PrivatePlanes);
        }

        public void DisplayAllPlanes()
        {
            foreach(var p in AirPlanes)
            {
                Console.WriteLine("{0} {1}  Flight Range: {2}  Fuel Consumption: {3}", p.Manufacturrer, p.Model, p.FlightRange, p.FuelConsumption);
                if (p is IPassengerPlane) Console.WriteLine("   Passenger places: {0}",(p as IPassengerPlane).GetTotalPassengerPlaces());
                if (p is IHasACargoBay) Console.WriteLine("   Cargo capacity: {0}", (p as IHasACargoBay).CargoCapacity);
                Console.WriteLine();
            }
        }

        public void SortByFlightRange(bool desc = false)
        {
            if(desc)
            {
                var sortedPlanes = from p in AirPlanes orderby p.FlightRange descending select p;
                AirPlanes = sortedPlanes.ToList();
            }else
            {
                var sortedPlanes = from p in AirPlanes orderby p.FlightRange select p;
                AirPlanes = sortedPlanes.ToList();
            }
        }

        public void SelectByFuelConsumption(double fconsum1 = 0, double fconsum2 = double.MaxValue)
        {
            var selectedPlanes = from p in AirPlanes where p.FuelConsumption >= fconsum1 && p.FuelConsumption <= fconsum2 select p;

            foreach (var p in selectedPlanes)
            {
                Console.WriteLine("{0} {1}  Flight Range: {2}  Fuel Consumption: {3}", p.Manufacturrer, p.Model, p.FlightRange, p.FuelConsumption);
                if (p is IPassengerPlane) Console.WriteLine("   Passenger places: {0}", (p as IPassengerPlane).GetTotalPassengerPlaces());
                if (p is IHasACargoBay) Console.WriteLine("   Cargo capacity: {0}", (p as IHasACargoBay).CargoCapacity);
                Console.WriteLine();
            }

        }
    }
}
