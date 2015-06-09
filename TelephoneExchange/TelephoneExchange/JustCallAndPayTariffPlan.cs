using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class JustCallAndPayTariffPlan : TariffPlan
    {
        public decimal MinuteCost { get; protected set; }

        public JustCallAndPayTariffPlan()
        {
            PlanName = "Just Call And Pay";
            MinuteCost = 0.30M;
        }
    }
}
