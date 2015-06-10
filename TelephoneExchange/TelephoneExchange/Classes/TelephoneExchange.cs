using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TelephoneExchange
{
    public class TelephoneExchange
    {
        private List<Port> Ports = new List<Port>();
        private List<CallInfo> CallsHistory = new List<CallInfo>();

        public TelephoneExchange()
        {
        }

        public void AddPort(int phoneNum)
        {
            Port newPort = new Port(phoneNum);
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
