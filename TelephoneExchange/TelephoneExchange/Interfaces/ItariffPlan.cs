﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange.Interfaces
{
    public interface ITariffPlan
    {
        string PlanName { get; }
        decimal CalculateCallCost(CallInfo info);
    }
}