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

        
        public void PlugInTerminal()
        {
            if (PlugIn != null) 
                PlugIn(this, new EventArgs());
        }

        public void UnplugTerminal()
        {
            if (Unplug != null) 
                Unplug(this, new EventArgs());
        }

        public void Call()
        {
        }

    }
}
