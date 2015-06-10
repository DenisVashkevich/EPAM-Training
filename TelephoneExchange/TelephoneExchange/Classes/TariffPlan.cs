using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public abstract class TariffPlan
    {
        public string PlanName { get; protected set; }

        public abstract decimal CalculteCallCost(CallInfo info);

    }
}
