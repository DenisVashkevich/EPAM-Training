using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange.Classes
{
    public class ContractSignedEventArgs : EventArgs
    {
        public readonly ContractHead contract;
        public readonly Terminal terminal;
        public ContractSignedEventArgs(ContractHead newContract, Terminal newTerminal)
        {
            contract = newContract;
            terminal = newTerminal;
        }
    }
}
