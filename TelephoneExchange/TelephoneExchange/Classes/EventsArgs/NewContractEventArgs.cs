using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class NewContractEventArgs : EventArgs
    {
        public int TelephoneNumber;
        public Port port;

        public NewContractEventArgs(int telephoneNumber)
        {
            TelephoneNumber = telephoneNumber;
        }
    }
}
