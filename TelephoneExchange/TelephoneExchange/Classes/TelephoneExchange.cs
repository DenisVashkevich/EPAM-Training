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
            //    receiver =port2;
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
            int tel1;
            PhoneNumbers.TryGetValue(port1, out tel1);
            Console.WriteLine("bla bla bla");
            switch(port1.State)
            {
                case PortState.OutgoingCall :
                    Port port2;
                    Ports.TryGetValue(port1.PhoneNumberInfo, out port2);
                    Console.WriteLine("subscriber {0} is calling to Subscriber {1}", tel1, port1.PhoneNumberInfo);
                    Connection con = new Connection(port1, port2);

                    break;
            }
        }

        public void OnNewcontractRegistering(object sender, NewContractEventArgs e)
        {
            //Console.WriteLine("ATS : {0}", e.TelephoneNumber);
            Port port = new Port();
            port.PropertyChanged += this.OnPortStateChanged;
            e.port = port;
            Ports.Add(e.TelephoneNumber, port);
            PhoneNumbers.Add(port, e.TelephoneNumber);
        }
    }

}
