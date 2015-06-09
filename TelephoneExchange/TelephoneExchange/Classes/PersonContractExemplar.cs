using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class PersonContractExemplar : ContractExemplar

    {
        public PersonSubscriber Subscriber { get; private set; }
        public TariffPlan Plan { get; private set; }
        public DateTime DateTariffChanged { get; private set; }
        public int PhoneNumber { get; private set; }

        public PersonContractExemplar(int contracrNum, PersonSubscriber client, TariffPlan plan, int phoneNum, DateTime validTo) : base(contracrNum)
        {
            Subscriber = client;
            Plan = plan;
            PhoneNumber = phoneNum;
            DateTariffChanged = DateTime.Today;
        }


    }
}
