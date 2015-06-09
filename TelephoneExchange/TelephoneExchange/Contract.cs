using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class Contract
    {
        public Subscriber Client { get; private set; }
        public TariffPlan Plan { get; private set; }
        public DateTime ValidTo { get; private set; }
        public int PhoneNumber { get; private set; }   

        public Contract(Subscriber client, TariffPlan plan,int phoneNum, DateTime validTo)
        {
            Client = client;
            Plan = plan;
            PhoneNumber = phoneNum;
            ValidTo = validTo;
        }


    }
}
