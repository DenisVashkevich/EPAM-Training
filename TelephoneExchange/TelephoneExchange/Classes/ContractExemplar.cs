using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    abstract class ContractExemplar
    {
        int ContractNumber { get; private set; }

        public ContractExemplar(int contractNum)
        {
            ContractNumber = contractNum;
        }
    }
}
