﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange.Interfaces
{
    interface ITariffPlan
    {
        public string PlanName { get; }
        public decimal CalculateCallCost(CallInfo info);
    }
}
