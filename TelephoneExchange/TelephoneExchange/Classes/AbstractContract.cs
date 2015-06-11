using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;

namespace TelephoneExchange
{
    public abstract class AbstractContract
    {
        public int ContractNumber { get; private set; }
        protected List<int> PhoneNumbers = new List<int>();
        protected Dictionary<DateTime, ITariffPlan> Plan = new Dictionary<DateTime, ITariffPlan>();

        public bool ChangeTariffPlan(ITariffPlan newPlan)
        {
            return false;
        }

        public ITariffPlan GetCurrentTariffPlan()
        {
            return Plan.Last().Value;
        }

        public IList<int> GetPhoneNumbers()
        {
            return PhoneNumbers.AsReadOnly();
        }
    }
}
