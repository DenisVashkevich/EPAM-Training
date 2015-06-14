using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneExchange.Classes;

namespace TelephoneExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            TelephoneExchange ATS = new TelephoneExchange();
            CommunicationCompany DenisTeleCom = new CommunicationCompany(ATS);
            

            DenisTeleCom.NewContractRegistering += ATS.OnNewcontractRegistering;

            #region Add some subscribers
            Subscriber Subscriber1 = new Subscriber("Vasily", "Doroshevich", new DateTime(1986, 6, 25), "KH162689");
            JustCallAndPayContractForPerson Subscriber1Contract = new JustCallAndPayContractForPerson(DenisTeleCom.GenerateNewContractNumber(), DenisTeleCom.GenerateNewTelephoneNumber(), Subscriber1.FirstName, Subscriber1.LastName, Subscriber1.DateOfBirth, Subscriber1.PassportNumber);
            DenisTeleCom.AddContract(Subscriber1, Subscriber1Contract);
            Subscriber Subscriber2 = new Subscriber("Andrey", "Ignatovich", new DateTime(1983, 2, 5), "KH132584");
            JustCallAndPayContractForPerson Subscriber2Contract = new JustCallAndPayContractForPerson(DenisTeleCom.GenerateNewContractNumber(), DenisTeleCom.GenerateNewTelephoneNumber(), Subscriber2.FirstName, Subscriber2.LastName, Subscriber2.DateOfBirth, Subscriber2.PassportNumber);
            DenisTeleCom.AddContract(Subscriber2, Subscriber2Contract);
            Subscriber Subscriber3 = new Subscriber("Evgeniy", "Zagorniy", new DateTime(1992, 9, 14), "KH2685467");
            JustCallAndPayContractForPerson Subscriber3Contract = new JustCallAndPayContractForPerson(DenisTeleCom.GenerateNewContractNumber(), DenisTeleCom.GenerateNewTelephoneNumber(), Subscriber3.FirstName, Subscriber3.LastName, Subscriber3.DateOfBirth, Subscriber3.PassportNumber);
            DenisTeleCom.AddContract(Subscriber3, Subscriber3Contract);
            Subscriber Subscriber4 = new Subscriber("Tatiana", "Bitkevich", new DateTime(1989, 12, 12), "KH2367159");
            JustCallAndPayContractForPerson Subscriber4Contract = new JustCallAndPayContractForPerson(DenisTeleCom.GenerateNewContractNumber(), DenisTeleCom.GenerateNewTelephoneNumber(), Subscriber4.FirstName, Subscriber4.LastName, Subscriber4.DateOfBirth, Subscriber4.PassportNumber);
            DenisTeleCom.AddContract(Subscriber4, Subscriber4Contract);
            Subscriber Subscriber5 = new Subscriber("Olga", "Grinuk", new DateTime(1972, 11, 1), "KH9567561");
            JustCallAndPayContractForPerson Subscriber5Contract = new JustCallAndPayContractForPerson(DenisTeleCom.GenerateNewContractNumber(), DenisTeleCom.GenerateNewTelephoneNumber(), Subscriber5.FirstName, Subscriber5.LastName, Subscriber5.DateOfBirth, Subscriber5.PassportNumber);
            DenisTeleCom.AddContract(Subscriber5, Subscriber5Contract);
            Subscriber Subscriber6 = new Subscriber("Oleg", "Bogdanovich", new DateTime(1978, 1, 15), "KH1698256");
            JustCallAndPayContractForPerson Subscriber6Contract = new JustCallAndPayContractForPerson(DenisTeleCom.GenerateNewContractNumber(), DenisTeleCom.GenerateNewTelephoneNumber(), Subscriber6.FirstName, Subscriber6.LastName, Subscriber6.DateOfBirth, Subscriber6.PassportNumber);
            DenisTeleCom.AddContract(Subscriber6, Subscriber6Contract);
            #endregion Add some subscribers

            Subscriber1.Telephone.CallTo(Subscriber2.Contract.PhoneNumber);
            ATS.GenerateSomeFakeCallInfoRecords(10);

            
            int j = 0;
            IEnumerable<DetalizationLine> detal = DenisTeleCom.GetCSubscriberdetalization(Subscriber1.Contract.PhoneNumber);
            Console.WriteLine("************Detalization for {0}", Subscriber1.Contract.PhoneNumber);
            foreach (var c in detal)
            {

                Console.WriteLine("Record # {5}: Date and Time: {0}\n \t Phone Number: {1}\n \t Code: {2}\n \t Duration: {3}\n \t Cost: {4}", 
                    c.calllDateTime, c.phoneNumber, c.code, c.duration, c.cost, ++j);
            }

            Console.ReadLine();
        }

    }
}
