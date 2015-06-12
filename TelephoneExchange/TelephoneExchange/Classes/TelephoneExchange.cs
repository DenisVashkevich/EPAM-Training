using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TelephoneExchange
{
    public class TelephoneExchange
    {
        private class Connection
        {
            private Port caller;
            private Port receiver;
            private DateTime ConnectionStarted;
            private TimeSpan Duration;
            public Connection(Port port1, Port port2)
            {
                caller = port1;
                receiver =port2;
            }

            private void  AddCallInforecord()
            {

            }
        }

        private List<CallInfo> CallsHistory = new List<CallInfo>();
        public Dictionary<int, Port> Ports = new Dictionary<int, Port>();
        public Dictionary<Port, int> PhoneNumbers = new Dictionary<Port, int>();

        public void OnPortStateChanged(object sender, PropertyChangedEventArgs e)
        {
            Port port1 = sender as Port;
            switch(port1.State)
            {
                case PortState.OutgoingCall :
                    Port port2;
                    Ports.TryGetValue(port1.PhoneNumberInfo, out port2);
                    Connection con = new Connection(port1, port2);

                    break;
            }
        }

        public void OnContractAdded(object sender, ContractAddedEventArgs e)
        {
            foreach (int p in e.TelephoneNumbers)
            {
                Console.WriteLine("ATS : {0}", p);
                Ports.Add(p, new Port());
                //Terminals.Add(p, new Terminal());
            }
        }

    }
}
