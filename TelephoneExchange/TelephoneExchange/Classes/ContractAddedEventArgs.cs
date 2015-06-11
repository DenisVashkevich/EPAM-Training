using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class ContractAddedEventArgs:EventArgs
    {
        public List<int> TelephoneNumbers = new List<int>();

        public ContractAddedEventArgs(IList<int> telephoneNumbers)
        {
            TelephoneNumbers.AddRange(telephoneNumbers);
        }
    }
}
