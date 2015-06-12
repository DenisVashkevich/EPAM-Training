using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            CommunicationCompany MegaComCompany = new CommunicationCompany();
            TelephoneExchange ATS = new TelephoneExchange();

            MegaComCompany.NewContractRegistering += ATS.OnContractAdded;

            #region Add some subscribers
            Subscriber Subscriber1 = new Subscriber("Vasily", "Doroshevich", new DateTime(1986, 6, 25), "KH162689");
            MegaComCompany.AddContract(new JustCallAndPayContractForPerson(MegaComCompany.GenerateNewContractNumber(), MegaComCompany.GenerateNewTelephoneNumber(), Subscriber1.FirstName, Subscriber1.LastName, Subscriber1.DateOfBirth, Subscriber1.PassportNumber));
            Subscriber Subscriber2 = new Subscriber("Andrey", "Ignatovich", new DateTime(1983, 2, 5), "KH132584");
            MegaComCompany.AddContract(new JustCallAndPayContractForPerson(MegaComCompany.GenerateNewContractNumber(), MegaComCompany.GenerateNewTelephoneNumber(), Subscriber2.FirstName, Subscriber2.LastName, Subscriber2.DateOfBirth, Subscriber2.PassportNumber));
            Subscriber Subscriber3 = new Subscriber("Evgeniy", "Zagorniy", new DateTime(1992, 9, 14), "KH2685467");
            MegaComCompany.AddContract(new JustCallAndPayContractForPerson(MegaComCompany.GenerateNewContractNumber(), MegaComCompany.GenerateNewTelephoneNumber(), Subscriber3.FirstName, Subscriber3.LastName, Subscriber3.DateOfBirth, Subscriber3.PassportNumber));
            Subscriber Subscriber4 = new Subscriber("Tatiana", "Bitkevich", new DateTime(1989, 12, 12), "KH2367159");
            MegaComCompany.AddContract(new JustCallAndPayContractForPerson(MegaComCompany.GenerateNewContractNumber(), MegaComCompany.GenerateNewTelephoneNumber(), Subscriber4.FirstName, Subscriber4.LastName, Subscriber4.DateOfBirth, Subscriber4.PassportNumber));
            Subscriber Subscriber5 = new Subscriber("Olga", "Grinuk", new DateTime(1972, 11, 1), "KH9567561");
            MegaComCompany.AddContract(new JustCallAndPayContractForPerson(MegaComCompany.GenerateNewContractNumber(), MegaComCompany.GenerateNewTelephoneNumber(), Subscriber5.FirstName, Subscriber5.LastName, Subscriber5.DateOfBirth, Subscriber5.PassportNumber));
            Subscriber Subscriber6 = new Subscriber("Oleg", "Bogdanovich", new DateTime(1978, 1, 15), "KH1698256");
            MegaComCompany.AddContract(new JustCallAndPayContractForPerson(MegaComCompany.GenerateNewContractNumber(), MegaComCompany.GenerateNewTelephoneNumber(), Subscriber6.FirstName, Subscriber6.LastName, Subscriber6.DateOfBirth, Subscriber6.PassportNumber));
            #endregion Add some subscribers

            foreach (KeyValuePair<int,ContractHead> kp in MegaComCompany.Contracts)
            {
                Console.WriteLine("*********************************************************");
                Console.WriteLine(kp.Key+" "+kp.Value.ContractNumber+" "+kp.Value);
            }

            Console.ReadLine();
        }

    }
}
