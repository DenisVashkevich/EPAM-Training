using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange.Interfaces
{
    public interface ITerminal
    {
        public void PlugInTerminal();
        public void UnplugTerminal();
        public void Call();
        public void Drop();
    }
}
