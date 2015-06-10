using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;

namespace TelephoneExchange
{
    public class PersonContract : IContract

    {
        public int ContractNumber
        {
            get ; 
        }

        public PersonSubscriber Subscriber { get; private set; }
        public int PhoneNumber { get; private set; }
        private Dictionary<DateTime, TariffPlan> Plan = new Dictionary<DateTime, TariffPlan>();

        public PersonContract(int contracrNum, PersonSubscriber client, TariffPlan plan, int phoneNum)
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
