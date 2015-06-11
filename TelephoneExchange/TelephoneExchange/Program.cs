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


        }

        static void AddSomeClients(CommunicationCompany company)
        {
            PersonSubscriber Client = new PersonSubscriber("Vasily", "Doroshevich", new DateTime(1986, 6, 25), "KH162689");
            PersonContract Contract = new PersonContract(2456, Client, new JustCallAndPayTariffPlan(), new List<int>(1) {297689245});
            company.AddContract(Contract);
            Client = new PersonSubscriber("Andrey", "Ignatovich", new DateTime(1983, 2, 5), "KH132584");
            Contract = new PersonContract(2456, Client, new JustCallAndPayTariffPlan(), new List<int>(1) {297689245});
            company.AddContract(Contract);
            Client = new PersonSubscriber("Evgeniy", "Zagorniy", new DateTime(1992, 9, 14), "KH2685467");
            Contract = new PersonContract(2456, Client, new JustCallAndPayTariffPlan(), new List<int>(1) {297689245});
            company.AddContract(Contract);
            Client = new PersonSubscriber("Tatiana", "Bitkevich", new DateTime(1989, 12, 12), "KH2367159");
            Contract = new PersonContract(2456, Client, new JustCallAndPayTariffPlan(), new List<int>(1) {297689245});
            company.AddContract(Contract);
            Client = new PersonSubscriber("Olga", "Grinuk", new DateTime(1972, 11, 1), "KH9567561");
            Contract = new PersonContract(2456, Client, new JustCallAndPayTariffPlan(), new List<int>(1) {297689245});
            company.AddContract(Contract);
            Client = new PersonSubscriber("Oleg", "Bogdanovich", new DateTime(1978, 1, 15), "KH1698256");
            Contract = new PersonContract(2456, Client, new JustCallAndPayTariffPlan(), new List<int>(1) {297689245});
            company.AddContract(Contract);
        }

    }
}
