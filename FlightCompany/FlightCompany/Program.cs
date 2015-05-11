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
                Model = ""
            });
        }
    }
}
