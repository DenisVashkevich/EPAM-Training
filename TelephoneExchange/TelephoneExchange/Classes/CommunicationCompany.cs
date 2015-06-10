using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;

namespace TelephoneExchange
{
    public class CommunicationCompany
    {
        private List<IContract> Contracts = new List<IContract>();
        public void AddContract(IContract newContract)
        {
            Contracts.Add(newContract);
        }
    }
}
