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

        }

        static void AddSomeClients(CommunicationCompany company)
        {
            PersonSubscriber Client = new PersonSubscriber(1001, "Vasily", "Doroshevich", new DateTime(1986, 6, 25), "KH162689");
            PersonContractExemplar Contract = new PersonContractExemplar(2456, Client, new JustCallAndPayTariffPlan(), 297689245);
            company.AddContract(Contract);
            Client = new PersonSubscriber(1002, "Andrey", "Ignatovich", new DateTime(1983, 2, 5), "KH132584");
            Contract = new PersonContractExemplar(2456, Client, new JustCallAndPayTariffPlan(), 297689245);
            company.AddContract(Contract);
            Client = new PersonSubscriber(1003, "Evgeniy", "Zagorniy", new DateTime(1992, 9, 14), "KH2685467");
            Contract = new PersonContractExemplar(2456, Client, new JustCallAndPayTariffPlan(), 297689245);
            company.AddContract(Contract);
            Client = new PersonSubscriber(1004, "Tatiana", "Bitkevich", new DateTime(1989, 12, 12), "KH2367159");
            Contract = new PersonContractExemplar(2456, Client, new JustCallAndPayTariffPlan(), 297689245);
            company.AddContract(Contract);
            Client = new PersonSubscriber(1005, "Olga", "Grinuk", new DateTime(1972, 11, 1), "KH9567561");
            Contract = new PersonContractExemplar(2456, Client, new JustCallAndPayTariffPlan(), 297689245);
            company.AddContract(Contract);
            Client = new PersonSubscriber(1006, "Oleg", "Bogdanovich", new DateTime(1978, 1, 15), "KH1698256");
            Contract = new PersonContractExemplar(2456, Client, new JustCallAndPayTariffPlan(), 297689245);
            company.AddContract(Contract);
        }

    }
}
