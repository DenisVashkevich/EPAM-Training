using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;

namespace TelephoneExchange
{
    public class PersonContract : AbstractContract
    {
        public PersonSubscriber Subscriber { get; private set; }
        
        public PersonContract(int contracrNum, PersonSubscriber client, ITariffPlan plan, List<int> phoneNums)
        {
            Subscriber = client;
            PhoneNumbers.AddRange(phoneNums);
            Plan.Add(DateTime.Today, plan);
        }
    }
}
