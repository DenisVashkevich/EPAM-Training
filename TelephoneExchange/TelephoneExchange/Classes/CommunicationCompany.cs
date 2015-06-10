using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class CommunicationCompany
    {
        private List<ContractExemplar> Contracts = new List<ContractExemplar>();
        public void AddContract(ContractExemplar newContract)
        {
            Contracts.Add(newContract);
        }
    }
}
