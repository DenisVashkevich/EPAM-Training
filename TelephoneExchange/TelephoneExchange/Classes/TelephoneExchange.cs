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
            private Terminal caller;
            private Terminal receiver;
            private DateTime ConnectionStarted;
            private TimeSpan Duration;
            public Connection(Terminal T1, Terminal T2)
            {
                caller = T1;
                receiver = T2;
            }


        }

        private List<Port> Ports = new List<Port>();
        private List<CallInfo> CallsHistory = new List<CallInfo>();
        //private Dictionary<int, Port> Ports = new Dictionary<int, Port>();
        private Dictionary<int, Terminal> Terminals = new Dictionary<int, Terminal>();

        public TelephoneExchange()
        {
        }

        public void AddPort(int phoneNum)
        {
            Port newPort = new Port();
            newPort.PropertyChanged += this.OnPortStateChanged;
            Ports.Add(newPort);
            
        }

        public void OnPortStateChanged(object sender, PropertyChangedEventArgs e)
        {
            switch((sender as Port).State)
            {
                case PortState.OutgoingCall : 
                    break;
            }
        }

        private bool DispatchCall(int phoneNumber)
        {
            return true;
        }
    }
}
