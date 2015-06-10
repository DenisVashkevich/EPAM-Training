using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class PersonContractExemplar : ContractExemplar

    {
        public PersonSubscriber Subscriber { get; private set; }
        public int PhoneNumber { get; private set; }
        private Dictionary<DateTime, TariffPlan> Plan = new Dictionary<DateTime, TariffPlan>();

        public PersonContractExemplar(int contracrNum, PersonSubscriber client, TariffPlan plan, int phoneNum) : base(contracrNum)
        {
            Subscriber = client;
            PhoneNumber = phoneNum;
            Plan.Add(DateTime.Today, plan);
        }

        public TariffPlan GetCurrentTariffPlan()
        {
            return Plan.Last().Value;
        }

    }
}
