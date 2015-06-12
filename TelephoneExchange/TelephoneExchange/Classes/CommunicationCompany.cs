using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;

namespace TelephoneExchange
{
    public class CommunicationCompany
    {
        public EventHandler<ContractAddedEventArgs> ContractAdded;

        private List<AbstractContract> Contracts = new List<AbstractContract>();

        public bool AddContract(AbstractContract newContract)
        {
            if (ContractAdded != null)
            {
                Contracts.Add(newContract);
                ContractAdded(this, new ContractAddedEventArgs(newContract.GetPhoneNumbers()));
                return true;
            }
            return false;
        }

    }
}
