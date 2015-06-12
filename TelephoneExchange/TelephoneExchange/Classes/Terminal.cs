using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;

namespace TelephoneExchange
{
    public class Terminal : ITerminal
    {
        public event EventHandler PlugIn;
        public event EventHandler Unplug;
        public event EventHandler<CallEventArgs> Call;
        public event EventHandler Drop;

        
        public void PlugInTerminal()
        {
            var p = PlugIn;
            if (p != null)
                p(this, new EventArgs());
        }

        public void UnplugTerminal()
        {
            var u = Unplug;
            if (u != null)
                u(this, new EventArgs());
        }

        public void CallTo(int phoneNumber)
        {
            var c = Call;
            if (c != null)
                c(this, new CallEventArgs(phoneNumber));
        }

        public void DropCall()
        {
            var d = Drop;
            if (d != null)
                d(this, new EventArgs());
        }
    }
}
