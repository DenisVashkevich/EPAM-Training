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

        /// <summary> 
        /// Сохранение списка самолетов на диск
        /// </summary> 
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

            using (FileStream fs = new FileStream("PassengerPlanes.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, pasPlanToSer);
            }

            using (FileStream fs = new FileStream("CargoPlanes.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, carPlanToSer);
            }

            using (FileStream fs = new FileStream("PrivatePlanes.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, privPlanToSer);
            }
        }

        /// <summary> 
        /// Загрузка списка самолетов с диска
        /// </summary> 
        public void LoadFromfile() 
        {
            List<PassengerAirplane> PassengerPlanes = new List<PassengerAirplane>();
            List<CargoAirplane> CargoPlanes = new List<CargoAirplane>();
            List<PrivateAirplane> PrivatePlanes = new List<PrivateAirplane>();

            IFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream("PassengerPlanes.bin", FileMode.Open))
                {
                    PassengerPlanes = (List<PassengerAirplane>)formatter.Deserialize(fs);
                }
            }
            catch(FileNotFoundException ex)
            {

            }

            try
            {
                using (FileStream fs = new FileStream("CargoPlanes.bin", FileMode.Open))
                {
                    CargoPlanes = (List<CargoAirplane>)formatter.Deserialize(fs);
                }
            }
            catch(FileNotFoundException ex)
            {

            }

            try
            {
                using (FileStream fs = new FileStream("PrivatePlanes.bin", FileMode.Open))
                {
                    PrivatePlanes = (List<PrivateAirplane>)formatter.Deserialize(fs);
                }
            }
            catch(FileNotFoundException ex)
            {

            }

            AirPlanes.Clear();
            AirPlanes.AddRange(PassengerPlanes);
            AirPlanes.AddRange(CargoPlanes);
            AirPlanes.AddRange(PrivatePlanes);
        }

        public void AddRange(IEnumerable<IPlane> collection)
        {
            AirPlanes.AddRange(collection);
        }

        /// <summary> 
        /// Выводит на экран все самолеты авиакомпании
        /// </summary> 
        public void DisplayAirplanes()
        {
            DisplayAirplanes(AirPlanes);
        }

        /// <summary> 
        /// Выводит на экран список самолетов
        /// </summary> 
        /// <param name = "AirplanesCollection">Список самолетов для вывода</param> 
        public void DisplayAirplanes(IEnumerable<IPlane> AirplanesCollection)
        {
            foreach (var p in AirplanesCollection)
            {
                Console.WriteLine("{0} {1}  Flight Range: {2}  Fuel Consumption: {3}", p.Manufacturrer, p.Model, p.FlightRange, p.FuelConsumption);
                if (p is IPassengerPlane) Console.WriteLine("   Passenger places: {0}", (p as IPassengerPlane).GetTotalPassengerPlaces());
                if (p is IHasACargoBay) Console.WriteLine("   Cargo capacity: {0}", (p as IHasACargoBay).CargoCapacity);
                Console.WriteLine();
            }
        }

        /// <summary> 
        /// Сортировка самолетов авиакомпании по дальности полета
        /// </summary> 
        /// <param name = "desc">Направление сортировки (desc = true, в порядке убывания)</param> 
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

        /// <summary> 
        /// Выбор самолетов авиакомпании по заданному диапазону расхода топлива
        /// </summary> 
        /// <param name="fconsum1">Нижний предел диапазона</param>
        /// <param name="fconsum2">Верхний предел диапазона</param>
        public IEnumerable<IPlane> SelectByFuelConsumption(double fconsum1 = 0, double fconsum2 = double.MaxValue)
        {
            return from p in AirPlanes where p.FuelConsumption >= fconsum1 && p.FuelConsumption <= fconsum2 select p;
        }

        public int TotalPassangerPlaces()
        {
            int s = 0;
            foreach(var p in AirPlanes)
            {
                if (p is IPassengerPlane) s += (p as IPassengerPlane).GetTotalPassengerPlaces();
            }
            return s;
        }

        public double TotalCargoCapacity()
        {
            double s = 0;
            foreach(var p in AirPlanes)
            {
                if (p is IHasACargoBay) s += (p as IHasACargoBay).CargoCapacity;
            }
            return s;
        }
    }
}
