using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class TelephoneExchange
    {
        private List<Port> Ports = new List<Port>();

        public TelephoneExchange(int numberOfPorts)
        {
            for (int i = 0; i < numberOfPorts; i++)
            {
                Ports.Add(new Port(this, i));
            }

        }

        public void InitializeTerminal(Port port)
        {
            //if no reason to block port then port.state = ready, else port.state = blocked

        }
    }
}
