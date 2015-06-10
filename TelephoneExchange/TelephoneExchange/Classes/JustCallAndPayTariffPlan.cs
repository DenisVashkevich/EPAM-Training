using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;

namespace TelephoneExchange
{
    public class JustCallAndPayTariffPlan : ITariffPlan
    {
        public decimal MinuteCost { get; protected set; }

        public string PlanName
        {
            get { throw new NotImplementedException(); }
        }

        public decimal CalculateCallCost(CallInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
