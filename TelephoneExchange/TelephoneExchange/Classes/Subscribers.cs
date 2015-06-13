using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange.Classes
{
    abstract public class Subscribers
    {
        public ContractHead Contract { get; set; }
        public Terminal Telephone { get; set; }
        
        abstract public string GetName();
    }
}
