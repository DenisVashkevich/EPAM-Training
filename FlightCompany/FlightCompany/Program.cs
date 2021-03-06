﻿using System;
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

            //DenisJetLines.AddRange(PlanesManualList());

            //DenisJetLines.SaveToFile();
            DenisJetLines.LoadFromfile();
            Console.Clear();
            Console.WriteLine("Airplanes list");
            Console.WriteLine("--------------");
            Console.WriteLine();
            DenisJetLines.DisplayAirplanes();
            Console.WriteLine("________________________________________________________________");
            Console.WriteLine("Total passenger placec in all planes : {0}", DenisJetLines.TotalPassangerPlaces());
            Console.WriteLine("Total cargo capacity of all planes : {0}", DenisJetLines.TotalCargoCapacity());
            Console.WriteLine("________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Sorted ascending");
            Console.WriteLine("----------------");
            Console.WriteLine();
            DenisJetLines.SortByFlightRange();
            DenisJetLines.DisplayAirplanes();
            Console.WriteLine("________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("Sorted descending");
            Console.WriteLine("-----------------");
            Console.WriteLine();
            DenisJetLines.SortByFlightRange(true);
            DenisJetLines.DisplayAirplanes();
            Console.WriteLine("________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("Selected planes by fuel consumption 100-5000");
            Console.WriteLine("--------------------------------------------");
            DenisJetLines.DisplayAirplanes(DenisJetLines.SelectByFuelConsumption(100, 5000));
            Console.WriteLine("________________________________________________________________");

            Console.ReadLine();
        }

        static List<IPlane> PlanesManualList()
        {
            List<IPlane> manualList = new List<IPlane>();

            manualList.Add(new PassengerAirplane()
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

            manualList.Add(new PassengerAirplane()
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

            manualList.Add(new PassengerAirplane()
            {
                Model = "TU-204",
                Manufacturrer = "KAPO",
                FlightRange = 6500,
                CruisingSpeed = 830,
                FuelConsumption = 3200,
                CrewCount = 3,
                EconomyClassPassangerPlaces = 210,
                BusinessClassPassangerPlaces = 0,
                FirstClassPassangerPlaces = 0,
                CargoCapacity = 21000
            });

            manualList.Add(new PassengerAirplane()
            {
                Model = "IL-96",
                Manufacturrer = "VASO",
                FlightRange = 7500,
                CruisingSpeed = 900,
                FuelConsumption = 6700,
                CrewCount = 3,
                EconomyClassPassangerPlaces = 279,
                BusinessClassPassangerPlaces = 28,
                FirstClassPassangerPlaces = 11,
                CargoCapacity = 40000
            });

            manualList.Add(new CargoAirplane()
            {
                Model = "747-8f",
                Manufacturrer = "Boeing",
                FlightRange = 14815,
                CruisingSpeed = 908,
                FuelConsumption = 6400,
                CrewCount = 2,
                CargoCapacity = 134000
            });

            manualList.Add(new PrivateAirplane()
            {
                Model = "G650",
                Manufacturrer = "Gulfstream",
                FlightRange = 12964,
                CruisingSpeed = 904,
                FuelConsumption = 1860,
                CrewCount = 4,
                PassengerPlaces = 18
            });

            manualList.Add(new PrivateAirplane()
            {
                Model = "GChallenger 300",
                Manufacturrer = "Bombardier ",
                FlightRange = 5646,
                CruisingSpeed = 850,
                FuelConsumption = 920,
                CrewCount = 2,
                PassengerPlaces = 8
            });

            manualList.Add(new PrivateAirplane()
            {
                Model = "Falcon 7X",
                Manufacturrer = "Dassault",
                FlightRange = 11020,
                CruisingSpeed = 904,
                FuelConsumption = 1100,
                CrewCount = 2,
                PassengerPlaces = 19
            });
            return manualList;
        }
    }
}
