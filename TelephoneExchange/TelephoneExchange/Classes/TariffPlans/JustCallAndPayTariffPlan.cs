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
        public readonly string PlanName = "Just Call and Pay";

        public JustCallAndPayTariffPlan(decimal minuteCost = 0.03M)
        {
            MinuteCost = minuteCost;
        }
        public decimal CalculateCallCost(CallInfo info)
        {
            throw new NotImplementedException();
        }

    }
}
