using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            AirCompany DenisJetLines = new AirCompany();

            DenisJetLines.Add(new PassengerAirplane()
            {
                Model = "A330-300",
                Manufacturrer = "Airbus",
                FlightRange = 12500,
                CruisingSpeed = 870,
                FuelConsumption = 5700,
                CrewCount = 2,
                EconomyClassPassangerPlaces = 239,
                BusinessClassPassangerPlaces = 48,
                FirstClassPassangerPlaces = 8,
                CargoCapacity = 51700
            });

            DenisJetLines.Add(new PassengerAirplane()
            {
                Model = "737-300",
                Manufacturrer = "Boeing",
                FlightRange = 4204,
                CruisingSpeed = 910,
                FuelConsumption = 4500,
                CrewCount = 2,
                EconomyClassPassangerPlaces = 118,
                BusinessClassPassangerPlaces = 8,
                FirstClassPassangerPlaces = 0,
                CargoCapacity = 0
            });

            DenisJetLines.Add(new CargoAirplane()
            {
                Model = "747-8f",
                Manufacturrer = "Boeing",
                FlightRange = 14815,
                CruisingSpeed = 908,
                FuelConsumption = 6400,
                CrewCount = 2,
                CargoCapacity = 134000
            });

            DenisJetLines.Add(new PrivateAirplane()
            {
                Model = "G650",
                Manufacturrer = "Gulfstream",
                FlightRange = 12964,
                CruisingSpeed = 904,
                FuelConsumption = 1860,
                CrewCount = 4,
                PassengerPlaces = 18
            });

            //DenisJetLines.SaveToFile();

            //DenisJetLines.LoadFromfile();
            Console.Clear();
            DenisJetLines.DisplayAllPlanes();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sorted ascending");
            Console.WriteLine();
            DenisJetLines.SortByFlightRange();
            DenisJetLines.DisplayAllPlanes();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Sorted descending");
            Console.WriteLine();
            DenisJetLines.SortByFlightRange(true);
            DenisJetLines.DisplayAllPlanes();

            Console.ReadLine();
        }
    }
}
