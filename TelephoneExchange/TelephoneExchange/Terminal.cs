using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class Terminal
    {
        private Port MyPort { get; }
        public string MyPhoneNumber { get; }

        public void PlugIn()
        {
            MyPort.TerminalDisconnected();
        }

        public void Unplug()
        {
            MyPort.TerminalConnected();
        }

        public void Call()
        {

        }
    }
}
