using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;

namespace TelephoneExchange
{
    public class JustCallAndPayTariffPlan : ITariffPlan
    {
        public double MinuteCost { get; protected set; }
        public readonly string PlanName = "Just Call and Pay";

        public JustCallAndPayTariffPlan(double minuteCost = 0.03)
        {
            MinuteCost = minuteCost;
        }
        public double CalculateCallCost(CallInfo info)
        {
            return info.Duration.Minutes + (info.Duration.Seconds > 0 ? 1 : 0) * this.MinuteCost;
        }

    }
}
