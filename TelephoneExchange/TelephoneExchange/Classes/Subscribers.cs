using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange.Classes
{
    abstract public class Subscribers
    {
        protected ContractHead ContractCopy { get; set; }
        abstract public string GetName();
        abstract public void OnContractSigned(object sender, ContractSignedEventArgs e);


    }
}
