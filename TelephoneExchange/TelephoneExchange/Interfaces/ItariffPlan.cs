using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange.Interfaces
{
    public interface ITariffPlan
    {
        double CalculateCallCost(CallInfo info);
    }
}
