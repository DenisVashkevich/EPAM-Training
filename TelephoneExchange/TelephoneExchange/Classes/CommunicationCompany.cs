using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;
using TelephoneExchange.Classes;

namespace TelephoneExchange
{
    public class CommunicationCompany
    {
        public EventHandler<NewContractEventArgs> NewContractRegistering;
        public EventHandler<ContractSignedEventArgs> ContractSigned;

        public Dictionary<int, ContractHead> Contracts = new Dictionary<int, ContractHead>();
        
        public bool AddContract(ContractHead newContract)
        {
            if (NewContractRegistering != null && ContractSigned != null) 
            {
                Contracts.Add(newContract.ContractNumber, newContract);
                NewContractEventArgs args = new NewContractEventArgs(newContract.PhoneNumber);
                NewContractRegistering(this, args);
                Terminal terminal = new Terminal();
                terminal.PlugIn += args.port.OnTerminalPlugedIn;
                terminal.Unplug += args.port.OnTerminalUnPluged;
                terminal.Call += args.port.OnOutgoingCall;
                terminal.Drop += args.port.OnDropCall;
                ContractSigned(this, new ContractSignedEventArgs(newContract, terminal));
                return true;
            }
            return false;
        }

        public int GenerateNewContractNumber()
        {
            return Contracts.Count + 1;
        }

        public int GenerateNewTelephoneNumber()
        {
            return Contracts.Count + 2700001;

        }
    }
}
