using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class TelephoneExchange
    {
        //private List<Port> Ports = new List<Port>();

        public TelephoneExchange(int numberOfPorts)
        {
            for (int portID = 0; portID < numberOfPorts; portID++)
            {
                Ports.Add(new Port(portID));
            }

        }


        public void InitPort(Port port)
        {
            //if no reason to block port then port.state = ready, else port.state = blocked
            switch(port.State)
            {
            }
        }
    }
}
